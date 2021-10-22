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
using CellValueChangedEventArgs = DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs;

namespace BoyArge
{
    public partial class ExpenseLineForm : RibbonForm
    {
        #region Definitions

        private readonly ExpenseLine _giderler = new ExpenseLine(LoginForm.DataConnection);

        //CPMDatabase cpm = new CPMDatabase();
        private long ExpenseLineId { get; set; }

        private Guid RowGuid { get; set; }

        public ExpenseLineForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void ExpenseLineForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvExpenseLine_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvExpenseLine_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvExpenseLine.CalcHitInfo(e.Point).InColumn) return;

            if (grvExpenseLine.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvExpenseLine.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdExpenseLine.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvExpenseLine.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvExpenseLine.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var expenseLineId = Utility.ToInt32(grvExpenseLine.GetFocusedRowCellValue(colExpenseLineID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, ExpenseLine.TableName, "ExpenseLineID",
                    expenseLineId, newStatus);

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

        private void VGrdExpenseLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Row != rowStockCode) return;

            try
            {
                var dProcess = Process.SelectByStock(rowStockCode.Properties.Value.ToString(),
                    (int)Process.Status.Active, LoginForm.DataConnection);
                if (dProcess == null || dProcess.Rows.Count == 0)
                {
                    lookProcessID.NullText = "Mamüle bağlı Proses Bulunamadı";
                    vGrdExpenseLine.Refresh();
                }
                else
                {
                    Format.LookUpEdit(lookProcessID, new[] { "Name", "Code" }, "Name", "ProcessID", dProcess);
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

        private void btnEditRecords_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvExpenseLine.GetSelectedRows().Length <= 0) return;

            try
            {
                var fExpenseLineEdit = new ExpenseLineEditForm();

                var dSelectedList = Database.GetList("SELECT * FROM [dbo].[tblExpenseLine] WHERE 1=0",
                    LoginForm.DataConnection); // new DataTable();

                foreach (var index in grvExpenseLine.GetSelectedRows())
                {
                    var row = grvExpenseLine.GetDataRow(index);
                    dSelectedList.ImportRow(row);
                }

                fExpenseLineEdit.dSelectedList = dSelectedList;

                if (fExpenseLineEdit.ShowDialog() == DialogResult.OK)
                    RefreshList();
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

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdExpenseLine.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _giderler.Record.Reset();

            ExpenseLineId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvExpenseLine.FocusedRowHandle >= 0)
            {
                _giderler.Record.Change(grvExpenseLine.GetFocusedDataRow());

                rowExpenseLineID.Properties.Value = ExpenseLineId = _giderler.Record.ExpenseLineID;
                rowExpenseID.Properties.Value = _giderler.Record.ExpenseID;
                rowStockCode.Properties.Value = _giderler.Record.StockCode;
                rowStockGroupID.Properties.Value = _giderler.Record.StockGroupID;
                rowProcessID.Properties.Value = _giderler.Record.ProcessID;
                rowMachineID.Properties.Value = _giderler.Record.MachineID;
                rowPrice.Properties.Value = _giderler.Record.Price;
                rowExchangeTypeID.Properties.Value = _giderler.Record.ExchangeTypeID;
                rowAmount.Properties.Value = _giderler.Record.Amount;
                rowUnitID.Properties.Value = _giderler.Record.UnitID;
                rowDate.Properties.Value = _giderler.Record.Date;
                rowNote.Properties.Value = _giderler.Record.Note;
                rowCode1.Properties.Value = _giderler.Record.Code1;
                rowCode2.Properties.Value = _giderler.Record.Code2;
                rowCode3.Properties.Value = _giderler.Record.Code3;
                rowStatus.Properties.Value = (byte)_giderler.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _giderler.Record.RowGUID;

                foreach (var row in vGrdExpenseLine.Rows)
                    if (_giderler.Record.Status == ExpenseLine.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _giderler.Record.Reset();
                ExpenseLineId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdExpenseLine.FocusNext();
            vGrdExpenseLine.Update();

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

                        if (ExpenseLineId == 0)
                        {
                            object expenseLineId = 0;
                            object guid = Guid.Empty;

                            result = _giderler.Insert(ref expenseLineId, rowExpenseID.Properties.Value,
                                rowStockCode.Properties.Value, rowStockGroupID.Properties.Value,
                                rowProcessID.Properties.Value, rowMachineID.Properties.Value,
                                rowExchangeTypeID.Properties.Value, rowUnitID.Properties.Value,
                                rowPrice.Properties.Value, rowAmount.Properties.Value, rowDate.Properties.Value,
                                rowNote.Properties.Value, rowCode1.Properties.Value, rowCode2.Properties.Value,
                                rowCode3.Properties.Value, rowStatus.Properties.Value, ref guid);

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
                            result = _giderler.Update(ExpenseLineId, rowExpenseID.Properties.Value,
                                rowStockCode.Properties.Value, rowStockGroupID.Properties.Value,
                                rowProcessID.Properties.Value, rowMachineID.Properties.Value,
                                rowExchangeTypeID.Properties.Value, rowUnitID.Properties.Value,
                                rowPrice.Properties.Value, rowAmount.Properties.Value, rowDate.Properties.Value,
                                rowNote.Properties.Value, rowCode1.Properties.Value, rowCode2.Properties.Value,
                                rowCode3.Properties.Value, rowStatus.Properties.Value, RowGuid);
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
            if (Utility.ToLong(ExpenseLineId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (ExpenseLineId > 0)
                        {
                            var result = _giderler.Delete(ExpenseLineId);
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
                grdExpenseLine.DataSource = ExpenseLine.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdExpenseLine.RefreshDataSource();

                grvExpenseLine.FocusedRowHandle = -1;
                NewRecord();

                var stock = new Stock();

                using (var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, ExpenseLine.TableName))
                {
                    Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                    Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                }

                using (var dExpense = Expense.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookExpenseID, new[] { "Name" }, "Name", "ExpenseID", dExpense);
                    Format.LookUpEdit(lookGrdExpenseID, new[] { "Name" }, "Name", "ExpenseID", dExpense);
                }

                using (var dStock = stock.GetList())
                {
                    Format.LookUpEdit(lookStockCode, new[] { "Code", "Name" }, "Name", "Code", dStock);
                    Format.LookUpEdit(lookGrdStockCode, new[] { "Code", "Name" }, "Name", "Code", dStock);
                }

                using (var dStockGroup = StockGroup.GetList(LoginForm.DataConnection, true))
                {
                    Format.LookUpEdit(lookStockGroupID, new[] { "Name", "MinValue", "MaxValue" }, "Name", "StockGroupID",
                        dStockGroup);
                    Format.LookUpEdit(lookGrdStockGroupID, new[] { "Name", "MinValue", "MaxValue" }, "Name",
                        "StockGroupID", dStockGroup);
                }

                using (var dProcess = Process.GetList(LoginForm.DataConnection, 0))
                {
                    Format.LookUpEdit(lookProcessID, new[] { "Name" }, "Name", "ProcessID", dProcess);
                    Format.LookUpEdit(lookGrdProcessID, new[] { "Name" }, "Name", "ProcessID", dProcess);
                }

                using (var dMachine = Machine.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookMachineID, new[] { "Name" }, "Name", "MachineID", dMachine);
                    Format.LookUpEdit(lookGrdMachineID, new[] { "Name" }, "Name", "MachineID", dMachine);
                }

                using (var dExchangeType = ExchangeType.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookExchangeTypeID, new[] { "Name" }, "Name", "ExchangeTypeID", dExchangeType);
                    Format.LookUpEdit(lookGrdExchangeTypeID, new[] { "Name" }, "Name", "ExchangeTypeID", dExchangeType);
                }

                using (var dUnit = Unit.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookUnitID, new[] { "Name" }, "Name", "UnitID", dUnit);
                    Format.LookUpEdit(lookGrdUnitID, new[] { "Name" }, "Name", "UnitID", dUnit);
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
            if (rowExpenseID.Properties.Value == null)
                return false;

            if (rowStockCode.Properties.Value == null)
                return false;

            if (rowProcessID.Properties.Value == null)
                return false;

            if (rowMachineID.Properties.Value == null)
                return false;

            if (rowPrice.Properties.Value == null)
                return false;

            if (rowAmount.Properties.Value == null)
                return false;

            if (rowExchangeTypeID.Properties.Value == null)
                return false;

            if (rowUnitID.Properties.Value == null)
                return false;

            return true;
        }

        #endregion Functions
    }
}