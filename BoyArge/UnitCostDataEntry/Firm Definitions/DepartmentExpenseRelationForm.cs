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
    public partial class DepartmentExpenseRelationForm : RibbonForm
    {
        #region Definitions

        private readonly DepartmentExpenseRelation _departmanGiderIliski =
            new DepartmentExpenseRelation(LoginForm.DataConnection);

        private long DepartmentExpenseRelationId { get; set; }
        private Guid RowGuid { get; set; }

        public DepartmentExpenseRelationForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void DepartmentExpenseRelationForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvDepartmentExpenseRelation_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvDepartmentExpenseRelation_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvDepartmentExpenseRelation.CalcHitInfo(e.Point).InColumn) return;

            if (grvDepartmentExpenseRelation.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvDepartmentExpenseRelation.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdDepartmentExpenseRelation.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvDepartmentExpenseRelation.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvDepartmentExpenseRelation.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var departmentExpenseRelationId =
                Utility.ToInt32(grvDepartmentExpenseRelation.GetFocusedRowCellValue(colDepartmentExpenseRelationID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, DepartmentExpenseRelation.TableName,
                    "DepartmentExpenseRelationID", departmentExpenseRelationId, newStatus);

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

        private void Seperator_ItemClick(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Checked = !toggleSwitch.Checked;
        }

        private void SpinEditAmount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void SpinEditPrice_Validating(object sender, CancelEventArgs e)
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
            foreach (var row in vGrdDepartmentExpenseRelation.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _departmanGiderIliski.Record.Reset();

            DepartmentExpenseRelationId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvDepartmentExpenseRelation.FocusedRowHandle >= 0)
            {
                _departmanGiderIliski.Record.Change(grvDepartmentExpenseRelation.GetFocusedDataRow());

                rowDepartmentExpenseRelationID.Properties.Value = DepartmentExpenseRelationId =
                    _departmanGiderIliski.Record.DepartmentExpenseRelationID;
                rowDepartmentID.Properties.Value = _departmanGiderIliski.Record.DepartmentID;
                rowMachineGroupID.Properties.Value = _departmanGiderIliski.Record.MachineGroupID;
                rowExpenseID.Properties.Value = _departmanGiderIliski.Record.ExpenseID;
                rowExchangeTypeID.Properties.Value = _departmanGiderIliski.Record.ExchangeTypeID;
                rowStockCode.Properties.Value = _departmanGiderIliski.Record.StockCode;
                rowUnitID.Properties.Value = _departmanGiderIliski.Record.UnitID;
                rowPrice.Properties.Value = _departmanGiderIliski.Record.Price;
                rowAmount.Properties.Value = _departmanGiderIliski.Record.Amount;
                rowAnnualOrMonthly.Properties.Value = _departmanGiderIliski.Record.AnnualOrMonthly;
                rowDirectOrIndirect.Properties.Value = _departmanGiderIliski.Record.DirectOrIndirect;
                rowMonth.Properties.Value = _departmanGiderIliski.Record.Month;
                rowDate.Properties.Value = _departmanGiderIliski.Record.Date;
                rowStatus.Properties.Value = (byte)_departmanGiderIliski.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _departmanGiderIliski.Record.RowGUID;

                foreach (var row in vGrdDepartmentExpenseRelation.Rows)
                    if (_departmanGiderIliski.Record.Status == DepartmentExpenseRelation.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _departmanGiderIliski.Record.Reset();
                DepartmentExpenseRelationId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdDepartmentExpenseRelation.FocusNext();
            vGrdDepartmentExpenseRelation.Update();

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

                        if (DepartmentExpenseRelationId == 0)
                        {
                            object departmentExpenseRelationId = 0;
                            object guid = Guid.Empty;

                            result = _departmanGiderIliski.Insert(ref departmentExpenseRelationId,
                                rowDepartmentID.Properties.Value, rowMachineGroupID.Properties.Value,
                                rowExpenseID.Properties.Value, rowExchangeTypeID.Properties.Value,
                                rowStockCode.Properties.Value, rowUnitID.Properties.Value, rowPrice.Properties.Value,
                                rowAmount.Properties.Value, rowAnnualOrMonthly.Properties.Value,
                                rowDirectOrIndirect.Properties.Value, rowMonth.Properties.Value,
                                rowDate.Properties.Value, rowStatus.Properties.Value, ref guid);

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
                            result = _departmanGiderIliski.Update(DepartmentExpenseRelationId,
                                rowDepartmentID.Properties.Value, rowMachineGroupID.Properties.Value,
                                rowExpenseID.Properties.Value, rowExchangeTypeID.Properties.Value,
                                rowStockCode.Properties.Value, rowUnitID.Properties.Value, rowPrice.Properties.Value,
                                rowAmount.Properties.Value, rowAnnualOrMonthly.Properties.Value,
                                rowDirectOrIndirect.Properties.Value, rowMonth.Properties.Value,
                                rowDate.Properties.Value, rowStatus.Properties.Value, RowGuid);
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
            if (Utility.ToLong(DepartmentExpenseRelationId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (DepartmentExpenseRelationId > 0)
                        {
                            var result = _departmanGiderIliski.Delete(DepartmentExpenseRelationId);
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
                grdDepartmentExpenseRelation.DataSource =
                    DepartmentExpenseRelation.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdDepartmentExpenseRelation.RefreshDataSource();

                grvDepartmentExpenseRelation.FocusedRowHandle = -1;
                NewRecord();

                using (var dDepartment = Department.GetList(LoginForm.DataConnection, !toggleSwitch.Checked))
                {
                    Format.LookUpEdit(lookDepartment, new[] { "Name", "Code" }, "Name", "DepartmentID", dDepartment);
                    Format.LookUpEdit(lookGrdDepartmentID, new[] { "Name", "Code" }, "Name", "DepartmentID", dDepartment);
                }

                using (var dMachineGroup = MachineGroup.GetList(LoginForm.DataConnection, 0))
                {
                    Format.LookUpEdit(lookMachineGroup, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                    Format.LookUpEdit(lookGridMachineGroup, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                }

                using (var dExpense = Expense.GetList(LoginForm.DataConnection, !toggleSwitch.Checked))
                {
                    Format.LookUpEdit(lookExpense, new[] { "Name", "Code" }, "Name", "ExpenseID", dExpense);
                    Format.LookUpEdit(lookGrdExpense, new[] { "Name", "Code" }, "Name", "ExpenseID", dExpense);
                }

                using (var dExchangeType = ExchangeType.GetList(LoginForm.DataConnection, !toggleSwitch.Checked))
                {
                    Format.LookUpEdit(lookExchangeType, new[] { "Name", "Code" }, "Name", "ExchangeTypeID",
                        dExchangeType);
                    Format.LookUpEdit(lookGrdExchangeType, new[] { "Name", "Code" }, "Name", "ExchangeTypeID",
                        dExchangeType);
                }

                var _stock = new Stock();
                using (var dStock = _stock.GetList())
                {
                    Format.LookUpEdit(lookStockCode, new[] { "Name", "Code" }, "Name", "Code", dStock);
                    Format.LookUpEdit(lookGrdStockCode, new[] { "Name", "Code" }, "Name", "Code", dStock);
                }

                using (var dUnit = Unit.GetList(LoginForm.DataConnection, !toggleSwitch.Checked))
                {
                    Format.LookUpEdit(lookUnitID, new[] { "Name", "Code" }, "Name", "UnitID", dUnit);
                    Format.LookUpEdit(lookGrdUnitID, new[] { "Name", "Code" }, "Name", "UnitID", dUnit);
                }

                using (var dTableStatus =
                    TableStatus.GetList(LoginForm.DataConnection, DepartmentExpenseRelation.TableName))
                {
                    Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                    Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
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
            if (rowDepartmentID.Properties.Value == null)
                return false;
            if (rowExpenseID.Properties.Value == null)
                return false;
            if (rowExchangeTypeID.Properties.Value == null)
                return false;
            if (rowPrice.Properties.Value == null)
                return false;

            return true;
        }

        #endregion Functions
    }
}