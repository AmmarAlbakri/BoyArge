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
    public partial class ZoneForm : RibbonForm
    {
        #region Definitions

        private readonly Zone _isletme = new Zone(LoginForm.DataConnection);
        private long ZoneId { get; set; }
        private Guid RowGuid { get; set; }

        public ZoneForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void ZoneForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvZone_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
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

        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Resources.AllRecords : Resources.OnlyActiveRecords;
            RefreshList();
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvZone.FocusedRowHandle < 0)
                return;

            var status = Utility.ToInt32(grvZone.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var zoneId = Utility.ToInt32(grvZone.GetFocusedRowCellValue(colZoneID));
            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, Zone.TableName, "ZoneID", zoneId, newStatus);

                XtraMessageBox.Show(result <= 0 ? Resources.UpdateError : Resources.UpdateInfo, Text,
                    MessageBoxButtons.OK, result <= 0 ? MessageBoxIcon.Error : MessageBoxIcon.Information);

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

        private void GrvZone_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvZone.CalcHitInfo(e.Point).InColumn)
                return;

            if (grvZone.GetFocusedDataRow() == null)
                return;

            if (Utility.ToInt32(grvZone.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;

                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdZone.PointToScreen(e.Point));
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdZone.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
                row.Properties.AllowEdit = true;
            }

            _isletme.Record.Reset();

            ZoneId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvZone.FocusedRowHandle >= 0)
            {
                _isletme.Record.Change(grvZone.GetFocusedDataRow());

                rowZoneID.Properties.Value = ZoneId = _isletme.Record.ZoneID;
                rowFirmID.Properties.Value = _isletme.Record.FirmID;
                rowCode.Properties.Value = _isletme.Record.Code;
                rowName.Properties.Value = _isletme.Record.Name;
                rowStatus.Properties.Value = (byte)_isletme.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _isletme.Record.RowGUID;

                foreach (var row in vGrdZone.Rows)
                    if (_isletme.Record.Status == Zone.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _isletme.Record.Reset();
                ZoneId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdZone.FocusNext();
            vGrdZone.Update();

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

                        if (ZoneId == 0)
                        {
                            object zoneId = 0;
                            object guid = Guid.Empty;

                            result = _isletme.Insert(ref zoneId, rowFirmID.Properties.Value, rowName.Properties.Value,
                                rowCode.Properties.Value, rowStatus.Properties.Value, ref guid);

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
                            result = _isletme.Update(ZoneId, rowFirmID.Properties.Value, rowName.Properties.Value,
                                rowCode.Properties.Value, rowStatus.Properties.Value, RowGuid);
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
            if (Utility.ToLong(ZoneId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (ZoneId > 0)
                        {
                            var result = _isletme.Delete(ZoneId);
                            if (result > 0)
                            {
                                _ = XtraMessageBox.Show(Resources.DeleteInfo, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                            else
                            {
                                _ = XtraMessageBox.Show(Resources.DeleteError, Text, MessageBoxButtons.OK,
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
            try
            {
                grdZone.DataSource = Zone.GetList(LoginForm.DataConnection, 0, !toggleSwitch.Checked);
                grdZone.RefreshDataSource();

                grvZone.FocusedRowHandle = -1;
                NewRecord();

                var dFirm = Firm.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, Zone.TableName);

                Format.LookUpEdit(lookFirm, new[] { "Name", "Code" }, "Name", "FirmID", dFirm);
                Format.LookUpEdit(lookGrdFirmID, new[] { "Name", "Code" }, "Name", "FirmID", dFirm);
                Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckRow()
        {
            if (rowName.Properties.Value == null)
                return false;

            if (rowCode.Properties.Value == null)
                return false;

            if (rowFirmID.Properties.Value == null)
                return false;

            return true;
        }

        #endregion Functions
    }
}