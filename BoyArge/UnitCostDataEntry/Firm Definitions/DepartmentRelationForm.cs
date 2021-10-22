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
    public partial class DepartmentRelationForm : RibbonForm
    {
        private void spinEditCost_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void spinEditPersonelCount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void spinEditWorkerCount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        #region Definitions

        private readonly DepartmentRelation _departman = new DepartmentRelation(LoginForm.DataConnection);
        private long DepartmentRelationId { get; set; }
        private Guid RowGuid { get; set; }

        public DepartmentRelationForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void DepartmentRelationForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvDepartmentRelation_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Resources.AllRecords : Resources.OnlyActiveRecords;
            RefreshList();
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvDepartmentRelation.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvDepartmentRelation.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var departmentRelationId =
                Utility.ToInt32(grvDepartmentRelation.GetFocusedRowCellValue(colDepartmentRelationID));
            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, DepartmentRelation.TableName,
                    "DepartmentRelationID", departmentRelationId, newStatus);

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

        private void GrvDepartmentRelation_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvDepartmentRelation.CalcHitInfo(e.Point).InColumn) return;

            if (grvDepartmentRelation.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvDepartmentRelation.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;

                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdDepartmentRelation.PointToScreen(e.Point));
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

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdDepartmentRelation.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _departman.Record.Reset();

            DepartmentRelationId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvDepartmentRelation.FocusedRowHandle >= 0)
            {
                _departman.Record.Change(grvDepartmentRelation.GetFocusedDataRow());

                rowDepartmentRelationID.Properties.Value =
                    DepartmentRelationId = _departman.Record.DepartmentRelationID;
                rowDepartmentID.Properties.Value = _departman.Record.DepartmentID;
                rowMachineGroupID.Properties.Value = _departman.Record.MachineGroupID;
                rowTitleID.Properties.Value = _departman.Record.TitleID;
                rowExchangeTypeID.Properties.Value = _departman.Record.ExchangeTypeID;
                rowWorkerCount.Properties.Value = _departman.Record.WorkerCount;
                rowCost.Properties.Value = _departman.Record.Cost;
                rowDirectOrIndirect.Properties.Value = _departman.Record.DirectOrIndirect;
                rowPrivateOrPublic.Properties.Value = _departman.Record.PrivateOrPublic;
                rowSalaryOrOvertime.Properties.Value = _departman.Record.SalaryOrOvertime;
                rowAnnualorMonthly.Properties.Value = _departman.Record.AnnualorMonthly;
                rowShiftorDaytime.Properties.Value = _departman.Record.ShiftorDaytime;
                rowMonth.Properties.Value = _departman.Record.Month;
                rowDate.Properties.Value = _departman.Record.Date;
                rowStatus.Properties.Value = (byte)_departman.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _departman.Record.RowGUID;

                foreach (var row in vGrdDepartmentRelation.Rows)
                    if (_departman.Record.Status == DepartmentRelation.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _departman.Record.Reset();
                DepartmentRelationId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdDepartmentRelation.FocusNext();
            vGrdDepartmentRelation.Update();

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

                        if (DepartmentRelationId == 0)
                        {
                            object departmentRelationId = 0;
                            object guid = Guid.Empty;

                            result = _departman.Insert(ref departmentRelationId, rowMachineGroupID.Properties.Value,
                                rowDepartmentID.Properties.Value, rowTitleID.Properties.Value,
                                rowExchangeTypeID.Properties.Value, rowWorkerCount.Properties.Value,
                                rowCost.Properties.Value, rowDirectOrIndirect.Properties.Value,
                                rowPrivateOrPublic.Properties.Value, rowSalaryOrOvertime.Properties.Value,
                                rowAnnualorMonthly.Properties.Value, rowShiftorDaytime.Properties.Value,
                                rowMonth.Properties.Value, rowDate.Properties.Value, rowStatus.Properties.Value,
                                ref guid);

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
                            result = _departman.Update(DepartmentRelationId, rowMachineGroupID.Properties.Value,
                                rowDepartmentID.Properties.Value, rowTitleID.Properties.Value,
                                rowExchangeTypeID.Properties.Value, rowWorkerCount.Properties.Value,
                                rowCost.Properties.Value, rowDirectOrIndirect.Properties.Value,
                                rowPrivateOrPublic.Properties.Value, rowSalaryOrOvertime.Properties.Value,
                                rowAnnualorMonthly.Properties.Value, rowShiftorDaytime.Properties.Value,
                                rowMonth.Properties.Value, rowDate.Properties.Value, rowStatus.Properties.Value,
                                RowGuid);
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
            if (Utility.ToLong(DepartmentRelationId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (DepartmentRelationId > 0)
                        {
                            var result = _departman.Delete(DepartmentRelationId);
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
                grdDepartmentRelation.DataSource =
                    DepartmentRelation.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdDepartmentRelation.RefreshDataSource();

                grvDepartmentRelation.FocusedRowHandle = -1;
                NewRecord();

                using (var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, DepartmentRelation.TableName))
                {
                    Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                    Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                }

                using (var dDepartment = Department.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookDepartmentID, new[] { "Name" }, "Name", "DepartmentID", dDepartment);
                    Format.LookUpEdit(lookGrdDepartmentID, new[] { "Name" }, "Name", "DepartmentID", dDepartment);
                }

                using (var dMachineGroup = MachineGroup.GetList(LoginForm.DataConnection, 0))
                {
                    Format.LookUpEdit(lookMachineGroupID, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                    Format.LookUpEdit(lookGrdMachineGroup, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                }

                using (var dTitle = Title.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookTitleID, new[] { "Name" }, "Name", "TitleID", dTitle);
                    Format.LookUpEdit(lookGrdTitleID, new[] { "Name" }, "Name", "TitleID", dTitle);
                }

                using (var dExchangeType = ExchangeType.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookExchangeTypeID, new[] { "Code" }, "Code", "ExchangeTypeID", dExchangeType);
                    Format.LookUpEdit(lookGrdExchangeTypeID, new[] { "Name" }, "Name", "ExchangeTypeID", dExchangeType);
                }
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
            if (rowDepartmentID.Properties.Value == null) return false;

            if (rowTitleID.Properties.Value == null) return false;

            return true;
        }

        #endregion Functions
    }
}