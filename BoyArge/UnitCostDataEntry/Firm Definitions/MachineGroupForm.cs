using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class MachineGroupForm : RibbonForm
    {
        #region Definitions

        private readonly MachineGroup _makineGrup = new MachineGroup(LoginForm.DataConnection);
        private long MachineGroupId { get; set; }
        private Guid RowGuid { get; set; }

        public MachineGroupForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void MachineGroupForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvMachineGroup_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvMachineGroup_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvMachineGroup.CalcHitInfo(e.Point).InColumn) return;

            if (grvMachineGroup.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvMachineGroup.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;

                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdMachineGroup.PointToScreen(e.Point));
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

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvMachineGroup.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvMachineGroup.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var machineGroupId = Utility.ToInt32(grvMachineGroup.GetFocusedRowCellValue(colMachineGroupID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, MachineGroup.TableName, "MachineGroupID",
                    machineGroupId, newStatus);

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

        private void SpinEditPersonelDay_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void SpinEditPersonelHour_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void SpinEditShiftCount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void SpinEditShiftDay_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void SpinEditShiftHour_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void SpinEditZoneExpensePercent_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdMachineGroup.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _makineGrup.Record.Reset();

            MachineGroupId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvMachineGroup.FocusedRowHandle >= 0)
            {
                _makineGrup.Record.Change(grvMachineGroup.GetFocusedDataRow());

                rowMachineGroupID.Properties.Value = MachineGroupId = _makineGrup.Record.MachineGroupID;
                rowZoneID.Properties.Value = _makineGrup.Record.ZoneID;
                rowCode.Properties.Value = _makineGrup.Record.Code;
                rowName.Properties.Value = _makineGrup.Record.Name;
                rowShiftHour.Properties.Value = _makineGrup.Record.ShiftHour;
                rowShiftDay.Properties.Value = _makineGrup.Record.ShiftDay;
                rowShiftCount.Properties.Value = _makineGrup.Record.ShiftCount;
                rowPersonelHour.Properties.Value = _makineGrup.Record.PersonelHour;
                rowPersonelDay.Properties.Value = _makineGrup.Record.PersonelDay;
                rowZoneExpensePercent.Properties.Value = _makineGrup.Record.ZoneExpensePercent;
                rowStatus.Properties.Value = (byte)_makineGrup.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _makineGrup.Record.RowGUID;

                foreach (var row in vGrdMachineGroup.Rows)
                    if (_makineGrup.Record.Status == MachineGroup.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _makineGrup.Record.Reset();
                MachineGroupId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdMachineGroup.FocusNext();
            vGrdMachineGroup.Update();

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

                        if (MachineGroupId == 0)
                        {
                            object machineGroupId = 0;
                            object guid = Guid.Empty;

                            result = _makineGrup.Insert(ref machineGroupId, rowZoneID.Properties.Value,
                                rowName.Properties.Value, rowCode.Properties.Value, rowShiftHour.Properties.Value,
                                rowShiftDay.Properties.Value, rowShiftCount.Properties.Value,
                                rowPersonelHour.Properties.Value, rowPersonelDay.Properties.Value,
                                rowZoneExpensePercent.Properties.Value, rowStatus.Properties.Value, ref guid);

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
                            result = _makineGrup.Update(MachineGroupId, rowZoneID.Properties.Value,
                                rowName.Properties.Value, rowCode.Properties.Value, rowShiftHour.Properties.Value,
                                rowShiftDay.Properties.Value, rowShiftCount.Properties.Value,
                                rowPersonelHour.Properties.Value, rowPersonelDay.Properties.Value,
                                rowZoneExpensePercent.Properties.Value, rowStatus.Properties.Value, RowGuid);
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
            if (Utility.ToLong(MachineGroupId) == 0) return;
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (MachineGroupId > 0)
                        {
                            var result = _makineGrup.Delete(MachineGroupId);
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
            try
            {
                grdMachineGroup.DataSource = MachineGroup.GetList(LoginForm.DataConnection, 0);
                grdMachineGroup.RefreshDataSource();

                grvMachineGroup.FocusedRowHandle = -1;
                NewRecord();

                var dZone = Zone.GetList(LoginForm.DataConnection, 0);
                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, MachineGroup.TableName);

                Format.LookUpEdit(lookZone, new[] { "Name", "Code" }, "Name", "ZoneID", dZone);
                Format.LookUpEdit(lookGrdZoneID, new[] { "Name", "Code" }, "Name", "ZoneID", dZone);
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
            if (rowZoneID.Properties.Value == null)
                return false;

            if (rowName.Properties.Value == null)
                return false;

            if (rowCode.Properties.Value == null)
                return false;

            return true;
        }

        #endregion Functions
    }
}