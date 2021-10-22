using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class DocumentForm : RibbonForm
    {
        #region Definitions

        public long DocumentID { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public object FileContent { get; set; }
        public object ByteArray { get; set; }
        public string FileType { get; set; }
        public Stream FileStream { get; set; }

        #endregion Definitions

        #region Event

        public DocumentForm()
        {
            InitializeComponent();
        }

        private void DocumentForm_Load(object sender, EventArgs e)
        {
            Format.LookUpEdit(this.lookModule, new[] { "Code", "Name", "Platform" }, "Name", "ModuleID", Document.ModuleSelect(0, 0, LoginForm.DataConnection));
            DateDateEdit.EditValue = DateTime.Now.Date;

            RefreshList();
            NewRecord();
            TypeTextEdit.Enabled = true;
            TypeTextEdit.Text = "XML";
        }

        private void BtnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewRecord();
            TypeTextEdit.Enabled = true;
            TypeTextEdit.Text = "XML";
        }

        private void BtnFileLoad_Click(object sender, EventArgs e)
        {
            try
            {
                xtraOpenFileDialog.Filter = "All files (*.*)|*.*|XML files (*.xml)|*.xml|PDF Files (*.PDF)|*.PDF|Excel Files (*.xlsx)|*.xlsx";

                if (xtraOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = xtraOpenFileDialog.FileName;
                    FileType = this.TypeTextEdit.Text = FilePath.Split('.')[1].ToUpper().Trim();
                    this.DateDateEdit.EditValue = DateTime.Now;
                    NameTextEdit.Text = FileName = FilePath.Split('.')[0].Split('\\').Last().Trim();
                    FileStream = xtraOpenFileDialog.OpenFile();

                    //if(FileType != "XML" || FileType != "PDF" || FileType != "XLS" || FileType != "XLSX")
                    //{
                    //    XtraMessageBox.Show("Uygun dosya biçimi seçilmedi!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    if (FileType == "PDF")
                    {
                        PDFViewerForm form = new PDFViewerForm();
                        form.pdfViewer1.LoadDocument(FileStream);
                        form.Show();

                        MemoryStream stream = new MemoryStream();

                        form.pdfViewer1.SaveDocument(stream);
                        FileStream = stream;
                    }
                    //Read the contents of the file into a stream

                    var reader = new StreamReader(FileStream, Encoding.UTF8);
                    reader.BaseStream.Position = 0;
                    FileContent = reader.ReadToEnd();
                    ByteArray = Encoding.UTF8.GetBytes(FileContent.ToString().Trim());

                    //var ms = new MemoryStream();
                    //reader.BaseStream.CopyTo(ms);
                    //this.ByteArray = ms.ToArray();

                    DataButtonEdit.EditValue = DataButtonEdit.ToolTip = FileContent.ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LcGroupGrid_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            if (this.grvDocument.FocusedRowHandle < 0) return;
            FileType = grvDocument.GetFocusedRowCellValue(colType).ToString();

            try
            {
                switch (FileType)
                {
                    case "PDF":
                        var fPDFViewer = new PDFViewerForm();
                        FileStream = new MemoryStream((byte[])grvDocument.GetFocusedRowCellValue(colData));
                        fPDFViewer.PdfStreamData = (MemoryStream)FileStream;
                        fPDFViewer.Show();
                        break;

                    case "XML":
                    case "Dashboard":
                        //byte[] byteArray = (byte[])this.grvDocument.GetFocusedRowCellValue(colData);
                        //var x = Document.ByteArrayToObject(byteArray);
                        TextEditorForm fTextEditor = null;
                        try
                        {
                            var utfString = Encoding.UTF8.GetString((byte[])grvDocument.GetFocusedRowCellValue(colData), 0, ((byte[])grvDocument.GetFocusedRowCellValue(colData)).Length);
                            //utfString = Regex.Replace(utfString, @"[\u0000-\u0006\0]", "").Replace("�","");

                            fTextEditor = new TextEditorForm
                            {
                                TextData = utfString.Trim(),
                                ModuleID = grvDocument.GetFocusedRowCellValue(colModuleID),
                                DocumentID = grvDocument.GetFocusedRowCellValue(colDocumentID),
                                DocumentName = grvDocument.GetFocusedRowCellValue(colName),
                                Caption = grvDocument.GetFocusedRowCellValue(colCaption),
                                FileType = grvDocument.GetFocusedRowCellValue(colType),
                                RowGUID = grvDocument.GetFocusedRowCellValue(colRowGUID)
                            };

                            fTextEditor.ShowDialog();
                            //if (fTextEditor.ShowDialog() == DialogResult.OK)
                            //    fTextEditor.Hide();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            fTextEditor.Dispose();
                        }
                        break;

                    case "XLS":
                    case "XLSX":
                        var fSpreadSheet = new SpreadSheetForm();

                        FileStream = new MemoryStream((byte[])grvDocument.GetFocusedRowCellValue(colData));
                        fSpreadSheet.StreamData = new MemoryStream();
                        FileStream.CopyTo(fSpreadSheet.StreamData);
                        fSpreadSheet.Show();
                        break;
                }
                this.RefreshList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveRecord();
            NewRecord();
            TypeTextEdit.Enabled = true;
            TypeTextEdit.Text = "XML";
        }

        private void DataButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (DataButtonEdit.EditValue == null) return;

            TextEditorForm fTextEditor = new TextEditorForm();

            try
            {
                fTextEditor.TextData = DataButtonEdit.EditValue;
                fTextEditor.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                fTextEditor.Dispose();
            }
        }

        private void GrvDocument_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EditRecord();
            TypeTextEdit.Enabled = false;
        }

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();
        }

        private void BtnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditRecord();
        }

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Resources.AllRecords : Resources.OnlyActiveRecords;
            RefreshList();
        }

        #endregion Event

        #region Function

        private void NewRecord()
        {
            this.lookModule.EditValue = this.DateDateEdit.EditValue = null;
            this.ByteArray = null;
            this.NameTextEdit.EditValue = this.TypeTextEdit.EditValue = this.txtCaption.EditValue = this.DataButtonEdit.EditValue = this.txtRowGUID.Text = "";
            this.FileContent = this.FileType = this.FileName = this.FilePath = "";
            this.FileStream = Stream.Null;
            this.DocumentID = 0;
        }

        private void EditRecord()
        {
            if (grvDocument.FocusedRowHandle < 0)
                return;

            try
            {
                Document.Recording record = new Document.Recording();

                record.Change(grvDocument.GetFocusedDataRow());

                this.DocumentID = record.DocumentID;
                lookModule.EditValue = Utility.ToInt32(record.ModuleID);
                DateDateEdit.EditValue = record.Date;
                NameTextEdit.EditValue = record.Name;
                txtCaption.Text = record.Caption;
                TypeTextEdit.EditValue = FileType = record.Type;

                ByteArray = record.Data;
                FileStream = new MemoryStream((byte[])ByteArray);

                var reader = new StreamReader(FileStream, Encoding.UTF8);
                reader.BaseStream.Position = 0;
                FileContent = reader.ReadToEnd();

                DataButtonEdit.EditValue = FileContent.ToString();
                txtRowGUID.EditValue = record.RowGUID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void SaveRecord()
        {
            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (Database.CheckConnection(LoginForm.DataConnection))
            {
                var document = new Document(LoginForm.DataConnection);
                try
                {
                    object documentId = 0;
                    object guid = Guid.Empty;
                    int result = 0;

                    documentId = this.DocumentID;

                    if (this.DocumentID == 0)
                        result = document.Insert(ref documentId, lookModule.EditValue, NameTextEdit.Text, txtCaption.EditValue, TypeTextEdit.EditValue, ByteArray, DateDateEdit.EditValue, (byte)Document.Status.Active, ref guid);
                    else
                          if (XtraMessageBox.Show("İlgili Dashboard güncellensin mi ? ", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    result = document.Update(this.DocumentID, lookModule.EditValue, NameTextEdit.Text, txtCaption.EditValue, TypeTextEdit.EditValue, ByteArray, DateDateEdit.EditValue, (byte)Document.Status.Active, Utility.ToGuid(txtRowGUID.Text));

                    if (result > 0)
                    {
                        XtraMessageBox.Show("Başarı ile kaydedildi!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshList();
                    }
                    else
                    {
                        XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException exc)
                {
                    XtraMessageBox.Show(exc.Message);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            else
            {
                XtraMessageBox.Show(Resources.ConnectionFailed, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRecord()
        {
            if (Utility.ToLong(DocumentID) == 0) return;
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (DocumentID > 0)
                        {
                            Document _document = new Document(LoginForm.DataConnection);

                            var result = _document.Delete(DocumentID);
                            if (result > 0)
                            {
                                XtraMessageBox.Show(Resources.DeleteInfo, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                            else
                            {
                                XtraMessageBox.Show(Resources.DeleteError, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (SqlException exc)
                    {
                        XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                    }
                else
                    XtraMessageBox.Show(Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void RefreshList()
        {
            int _status = toggleSwitch.Checked ? 0 : 1;
            grdDocument.DataSource = Document.Select(-1, "", LoginForm.UserStatus, LoginForm.DataConnection);
        }

        #endregion Function

        private void ribbon_Click(object sender, EventArgs e)
        {
        }
    }
}