using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraEditors; //using Business;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class TextEditorForm : XtraForm
    {
        public TextEditorForm()
        {
            InitializeComponent();
        }

        public object TextData { get; set; }
        public object ModuleID { get; set; }
        public object DocumentID { get; set; }
        public object DocumentName { get; set; }
        public object Caption { get; set; }
        public object FileType { get; set; }
        public object RowGUID { get; set; }

        private void TextEditorForm_Load(object sender, EventArgs e)
        {
            if (TextData != null)
                richEditControl1.Text = TextData.ToString();
        }

        private void BtnUpdateDatasource_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Utility.ToLong(DocumentID) == 0)
                return;

            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo,
    MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (Database.CheckConnection(LoginForm.DataConnection))
            {
                var document = new Document(LoginForm.DataConnection);
                try
                {
                    //var ByteArray = Document.ObjectToByteArray(richEditControl1.Text);

                    string utfStr = Regex.Replace(richEditControl1.Text, @"[\u0000-\u0007\0]", "").Replace("�", "");

                    byte[] ByteArray = Encoding.UTF8.GetBytes(utfStr);
#if DEBUG
                    var utfString = Encoding.UTF8.GetString(ByteArray, 0, ByteArray.Length);
#endif
                    var result = document.Update(DocumentID, ModuleID, DocumentName, Caption, FileType, ByteArray, DateTime.Now, (byte)Document.Status.Active, RowGUID);

                    if (result > 0)
                    {
                        XtraMessageBox.Show("Başarı ile kaydedildi!", Text, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
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
    }
}