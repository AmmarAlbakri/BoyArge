using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class FirmForm : RibbonForm
    {
        #region Definitions

        private readonly Firm _firma = new Firm(LoginForm.DataConnection);
        private long FirmId { get; set; }
        private Guid RowGuid { get; set; }

        private CustomObservableCollection<Firm.Recording> firmItems = new CustomObservableCollection<Firm.Recording>();

        public FirmForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void FirmForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void BtnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewRecord();
        }

        private void BtnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditRecord();
        }

        private void BtnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveRecord();
        }

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();
        }

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void GrvFirm_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvFirm.CalcHitInfo(e.Point).InColumn)
                return;

            if (grvFirm.GetFocusedDataRow() == null)
                return;

            if (Utility.ToInt32(grvFirm.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;

                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdFirm.PointToScreen(e.Point));
        }

        private void GrvFirm_RowClick(object sender, RowClickEventArgs e)
        {
            EditRecord();
        }

        private void GrvFirm_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvFirm.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvFirm.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var firmId = Utility.ToInt32(grvFirm.GetFocusedRowCellValue(colFirmID));

            var message = status == 1
                ? Resources.QuestionPassive
                : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, Firm.TableName, "FirmID", firmId, newStatus);

                if (result <= 0)
                    XtraMessageBox.Show(Resources.UpdateError, Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                    XtraMessageBox.Show(Resources.UpdateInfo, Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                RefreshList();
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Resources.AllRecords : Resources.OnlyActiveRecords;
            RefreshList();
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdFirm.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _firma.Record.Reset();

            FirmId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvFirm.FocusedRowHandle >= 0)
            {
                //_firma.Record.Change(grvFirm.GetFocusedDataRow());

                //rowFirmID.Properties.Value = FirmId = _firma.Record.FirmID;
                //rowCode.Properties.Value = _firma.Record.Code;
                //rowName.Properties.Value = _firma.Record.Name;
                //rowAddress.Properties.Value = _firma.Record.Address;
                //rowEmail.Properties.Value = _firma.Record.Email;
                //rowPhone.Properties.Value = _firma.Record.Phone;
                //rowStatus.Properties.Value = (byte)(_firma.Record.Status == Firm.Status.Active ? CheckState.Checked : CheckState.Unchecked);
                //rowRowGUID.Properties.Value = RowGuid = _firma.Record.RowGUID;

                rowFirmID.Properties.Value = FirmId = firmItems[grvFirm.FocusedRowHandle].FirmID;
                rowCode.Properties.Value = firmItems[grvFirm.FocusedRowHandle].Code;
                rowName.Properties.Value = firmItems[grvFirm.FocusedRowHandle].Name;
                rowAddress.Properties.Value = firmItems[grvFirm.FocusedRowHandle].Address;
                rowEmail.Properties.Value = firmItems[grvFirm.FocusedRowHandle].Email;
                rowPhone.Properties.Value = firmItems[grvFirm.FocusedRowHandle].Phone;
                rowStatus.Properties.Value = firmItems[grvFirm.FocusedRowHandle].Status;
                rowRowGUID.Properties.Value = firmItems[grvFirm.FocusedRowHandle].RowGUID;

                foreach (var row in vGrdFirm.Rows)
                    if (_firma.Record.Status == Firm.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _firma.Record.Reset();
                FirmId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdFirm.FocusNext();
            vGrdFirm.Update();

            if (!ScreenPermission.ScreenPermissionEdit(LoginForm.UserId, Tag.ToString(), LoginForm.DataConnection))
            {
                XtraMessageBox.Show(Resources.PermissionDenied, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!CheckRow())
            {
                XtraMessageBox.Show(Resources.EmptySpaceWarning, Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        int result;

                        if (FirmId == 0)
                        {
                            object firmId = 0;
                            object guid = Guid.Empty;

                            result = _firma.Insert(ref firmId, rowCode.Properties.Value, rowName.Properties.Value,
                                rowPhone.Properties.Value, rowEmail.Properties.Value, rowAddress.Properties.Value,
                                rowStatus.Properties.Value, ref guid);

                            if (result <= 0)
                            {
                                XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                            else
                            {
                                XtraMessageBox.Show(Resources.InsertInfo, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                        }
                        else
                        {
                            result = _firma.Update(FirmId, rowCode.Properties.Value, rowName.Properties.Value,
                                rowPhone.Properties.Value, rowEmail.Properties.Value, rowAddress.Properties.Value,
                                rowStatus.Properties.Value, RowGuid);
                            if (result <= 0)
                            {
                                XtraMessageBox.Show(Resources.UpdateError, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                            else
                            {
                                XtraMessageBox.Show(Resources.UpdateInfo, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
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

        private void DeleteRecord()
        {
            if (Utility.ToLong(FirmId) == 0) return;
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (FirmId > 0)
                        {
                            var result = _firma.Delete(FirmId);
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
            //var dList = Firm.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
            //grdFirm.DataSource = dList;

            firmItems = Firm.GetFirms(LoginForm.DataConnection);

            grdFirm.DataSource = firmItems;

            grdFirm.RefreshDataSource();

            var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, Firm.TableName);

            Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
            Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);

            grvFirm.FocusedRowHandle = -1;
            NewRecord();
        }

        private bool CheckRow()
        {
            if (rowName.Properties.Value == null) return false;
            //if (rowCode.Properties.Value == null)
            //    return false;
            return true;
        }

        #endregion Functions

        private void lookStatus_EditValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(rowStatus.Properties.Value);
        }
    }
}