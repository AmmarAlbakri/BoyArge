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
    public partial class MachineForm : RibbonForm
    {
        #region Definitions

        private readonly Machine _makine = new Machine(LoginForm.DataConnection);
        private long MachineId { get; set; }
        private Guid RowGuid { get; set; }

        public MachineForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void MachineForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvMachine_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvMachine_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvMachine.CalcHitInfo(e.Point).InColumn) return;

            if (grvMachine.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvMachine.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;

                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdMachine.PointToScreen(e.Point));
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
            if (grvMachine.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvMachine.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var machineId = Utility.ToInt32(grvMachine.GetFocusedRowCellValue(colMachineID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, Machine.TableName, "MachineID", machineId,
                    newStatus);

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

        private void spinEditNeedleCount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (Utility.ToDecimal(spinEdit.Value) < 0)
                    e.Cancel = true;
            }
        }

        private void spinEditFNeedleCount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (Utility.ToDecimal(spinEdit.Value) < 0)
                    e.Cancel = true;
            }
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdMachine.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _makine.Record.Reset();

            MachineId = 0;
            RowGuid = Guid.Empty;
        }

        private void EditRecord()
        {
            if (grvMachine.FocusedRowHandle >= 0)
            {
                _makine.Record.Change(grvMachine.GetFocusedDataRow());

                rowMachineID.Properties.Value = MachineId = _makine.Record.MachineID;
                rowMachineGroupID.Properties.Value = _makine.Record.MachineGroupID;
                rowProductionTypeID.Properties.Value = _makine.Record.ProductionTypeID;
                rowName.Properties.Value = _makine.Record.Name;
                rowCode.Properties.Value = _makine.Record.Code;
                rowModel.Properties.Value = _makine.Record.Model;
                rowSpecode.Properties.Value = _makine.Record.Specode;
                rowModelYear.Properties.Value = _makine.Record.ModelYear;
                rowNeedleCount.Properties.Value = _makine.Record.NeedleCount;
                rowFNeedleCount.Properties.Value = _makine.Record.FNeedleCount;
                rowDate.Properties.Value = _makine.Record.Date;
                rowNote.Properties.Value = _makine.Record.Note;
                rowCode1.Properties.Value = _makine.Record.Code1;
                rowCode2.Properties.Value = _makine.Record.Code2;
                rowCode3.Properties.Value = _makine.Record.Code3;
                rowStatus.Properties.Value = (byte)_makine.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _makine.Record.RowGUID;

                foreach (var row in vGrdMachine.Rows)
                    if (_makine.Record.Status == Machine.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _makine.Record.Reset();
                MachineId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdMachine.FocusNext();
            vGrdMachine.Update();

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

                        if (MachineId == 0)
                        {
                            object machineId = 0;
                            object guid = Guid.Empty;

                            result = _makine.Insert(ref machineId, rowMachineGroupID.Properties.Value,
                                rowProductionTypeID.Properties.Value, rowName.Properties.Value,
                                rowCode.Properties.Value, rowModel.Properties.Value, rowSpecode.Properties.Value,
                                rowModelYear.Properties.Value, rowNeedleCount.Properties.Value,
                                rowFNeedleCount.Properties.Value, rowDate.Properties.Value, rowNote.Properties.Value,
                                rowCode1.Properties.Value, rowCode2.Properties.Value, rowCode3.Properties.Value,
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
                            result = _makine.Update(MachineId, rowMachineGroupID.Properties.Value,
                                rowProductionTypeID.Properties.Value, rowName.Properties.Value,
                                rowCode.Properties.Value, rowModel.Properties.Value, rowSpecode.Properties.Value,
                                rowModelYear.Properties.Value, rowNeedleCount.Properties.Value,
                                rowFNeedleCount.Properties.Value, rowDate.Properties.Value, rowNote.Properties.Value,
                                rowCode1.Properties.Value, rowCode2.Properties.Value, rowCode3.Properties.Value,
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
            if (Utility.ToLong(MachineId) == 0) return;
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (MachineId > 0)
                        {
                            var result = _makine.Delete(MachineId);
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
                grdMachine.DataSource = Machine.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdMachine.RefreshDataSource();

                grvMachine.FocusedRowHandle = -1;
                NewRecord();

                var dMachineGroup = MachineGroup.GetList(LoginForm.DataConnection, 0, !toggleSwitch.Checked);
                var dProductionType = ProductionType.GetList(LoginForm.DataConnection);
                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, Machine.TableName);

                Format.LookUpEdit(lookMachineGroup, new[] { "Name", "Code" }, "Name", "MachineGroupID", dMachineGroup);
                Format.LookUpEdit(lookGrdMachineGroupID, new[] { "Name", "Code" }, "Name", "MachineGroupID",
                    dMachineGroup);
                Format.LookUpEdit(lookProductionType, new[] { "Name", "Code" }, "Name", "ProductionTypeID",
                    dProductionType);
                Format.LookUpEdit(lookGrdProductionType, new[] { "Name", "Code" }, "Name", "ProductionTypeID",
                    dProductionType);
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
            if (rowMachineGroupID.Properties.Value == null) return false;

            if (rowProductionTypeID.Properties.Value == null) return false;

            if (rowName.Properties.Value == null) return false;

            if (rowCode.Properties.Value == null) return false;

            return true;
        }

        #endregion Functions
    }
}