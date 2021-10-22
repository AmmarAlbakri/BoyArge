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
    public partial class ExpenseForm : RibbonForm
    {
        #region Definitions

        private readonly Expense _giderler = new Expense(LoginForm.DataConnection);
        private long ExpenseId { get; set; }
        private Guid RowGuid { get; set; }

        public ExpenseForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void ExpenseForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvExpense_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvExpense_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvExpense.CalcHitInfo(e.Point).InColumn) return;

            if (grvExpense.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvExpense.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdExpense.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvExpense.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvExpense.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var expenseId = Utility.ToInt32(grvExpense.GetFocusedRowCellValue(colExpenseID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, Expense.TableName, "ExpenseID", expenseId,
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
            foreach (var row in vGrdExpense.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _giderler.Record.Reset();

            ExpenseId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvExpense.FocusedRowHandle >= 0)
            {
                _giderler.Record.Change(grvExpense.GetFocusedDataRow());

                rowExpenseID.Properties.Value = ExpenseId = _giderler.Record.ExpenseID;
                rowCode.Properties.Value = _giderler.Record.Code;
                rowName.Properties.Value = _giderler.Record.Name;
                rowStatus.Properties.Value = (byte)_giderler.Record.Status;
                rowExpenseTypeID.Properties.Value = _giderler.Record.ExpenseTypeID;
                rowUnitID.Properties.Value = _giderler.Record.UnitID;
                rowRowGUID.Properties.Value = RowGuid = _giderler.Record.RowGUID;

                foreach (var row in vGrdExpense.Rows)
                    if (_giderler.Record.Status == Expense.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _giderler.Record.Reset();
                ExpenseId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdExpense.FocusNext();
            vGrdExpense.Update();

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

                        if (ExpenseId == 0)
                        {
                            object expenseId = 0;
                            object guid = Guid.Empty;

                            result = _giderler.Insert(ref expenseId, rowExpenseTypeID.Properties.Value,
                                rowUnitID.Properties.Value, rowName.Properties.Value, rowCode.Properties.Value,
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
                            result = _giderler.Update(ExpenseId, rowExpenseTypeID.Properties.Value,
                                rowUnitID.Properties.Value, rowName.Properties.Value, rowCode.Properties.Value,
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
            if (Utility.ToLong(ExpenseId) == 0) return;
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (ExpenseId > 0)
                        {
                            var result = _giderler.Delete(ExpenseId);
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
                grdExpense.DataSource = Expense.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdExpense.RefreshDataSource();

                grvExpense.FocusedRowHandle = -1;
                NewRecord();

                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, Expense.TableName);
                var dExpenseType = ExpenseType.GetList(LoginForm.DataConnection);
                var dUnit = Unit.GetList(LoginForm.DataConnection);

                Format.LookUpEdit(lookExpenseTypeID, new[] { "Name" }, "Name", "ExpenseTypeID", dExpenseType);
                Format.LookUpEdit(lookGrdExpenseTypeID, new[] { "Name" }, "Name", "ExpenseTypeID", dExpenseType);
                Format.LookUpEdit(lookUnitID, new[] { "Name" }, "Name", "UnitID", dUnit);
                Format.LookUpEdit(lookGrdUnitID, new[] { "Name" }, "Name", "UnitID", dUnit);
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
            if (rowName.Properties.Value == null) return false;

            if (rowCode.Properties.Value == null) return false;

            if (rowExpenseTypeID.Properties.Value == null) return false;

            if (rowUnitID.Properties.Value == null) return false;

            return true;
        }

        #endregion Functions
    }
}