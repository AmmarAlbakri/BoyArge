using BoyArge.Properties;
using Business;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class ExpenseLineEditForm : XtraForm
    {
        #region Functions

        private void LoadSources()
        {
            try
            {
                grdExpenseLine.DataSource = ExpenseLine.GetList(LoginForm.DataConnection);
                grdExpenseLine.RefreshDataSource();

                using (var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, ExpenseLine.TableName))
                {
                    Format.LookUpEdit(StatusLookUpEdit, new[] { "Name" }, "Name", "Code", dTableStatus);
                    Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                }

                using (var dExpense = Expense.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(ExpenseIDLookUpEdit, new[] { "Name" }, "Name", "ExpenseID", dExpense);
                    Format.LookUpEdit(lookGrdExpenseID, new[] { "Name" }, "Name", "ExpenseID", dExpense);
                }

                using (var dStock = new Stock().GetList())
                {
                    //Format.LookUpEdit(StockCode, new[] { "Code", "Name" }, "Name", "Code", dStock);
                    Format.LookUpEdit(lookGrdStockCode, new[] { "Code", "Name" }, "Name", "Code", dStock);
                }

                using (var dStockGroup = StockGroup.GetList(LoginForm.DataConnection, true))
                {
                    Format.LookUpEdit(StockGroupIDLookUpEdit, new[] { "Name" }, "Name", "StockGroupID", dStockGroup);
                    Format.LookUpEdit(lookGrdStockGroupID, new[] { "Name" }, "Name", "StockGroupID", dStockGroup);
                }

                using (var dProcess = Process.GetList(LoginForm.DataConnection, 0))
                {
                    Format.LookUpEdit(ProcessIDLookUpEdit, new[] { "Name" }, "Name", "ProcessID", dProcess);
                    Format.LookUpEdit(lookGrdProcessID, new[] { "Name" }, "Name", "ProcessID", dProcess);
                }

                using (var dMachine = Machine.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(MachineIDLookUpEdit, new[] { "Name" }, "Name", "MachineID", dMachine);
                    Format.LookUpEdit(lookGrdMachineID, new[] { "Name" }, "Name", "MachineID", dMachine);
                }

                using (var dExchangeType = ExchangeType.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(ExchangeTypeIDLookUpEdit, new[] { "Name" }, "Name", "ExchangeTypeID",
                        dExchangeType);
                    Format.LookUpEdit(lookGrdExchangeTypeID, new[] { "Name" }, "Name", "ExchangeTypeID", dExchangeType);
                }

                using (var dUnit = Unit.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(UnitIDLookUpEdit, new[] { "Name" }, "Name", "UnitID", dUnit);
                    Format.LookUpEdit(lookGrdUnitID, new[] { "Name" }, "Name", "UnitID", dUnit);
                }

                using (dSelectedList)
                {
                    grdExpenseLine.DataSource = dSelectedList;
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

        #endregion Functions

        #region Definitions

        public DataTable dSelectedList = new DataTable();
        private readonly ExpenseLine _giderler = new ExpenseLine(LoginForm.DataConnection);

        #endregion Definitions

        #region Events

        public ExpenseLineEditForm()
        {
            InitializeComponent();
        }

        private void ExpenseLineEditForm_Load(object sender, EventArgs e)
        {
            LoadSources();
            ExpenseIDLookUpEdit.Enabled = StockGroupIDLookUpEdit.Enabled = ProcessIDLookUpEdit.Enabled =
                MachineIDLookUpEdit.Enabled = ExchangeTypeIDLookUpEdit.Enabled = UnitIDLookUpEdit.Enabled =
                    PriceSpinEdit.Enabled = AmountSpinEdit.Enabled = DateDateEdit.Enabled = NoteTextEdit.Enabled =
                        Code1TextEdit.Enabled = Code2TextEdit.Enabled =
                            Code3SpinEdit.Enabled = StatusLookUpEdit.Enabled = false;
        }

        private void ChkExpenseID_CheckedChanged(object sender, EventArgs e)
        {
            ExpenseIDLookUpEdit.Enabled = chkExpenseID.Checked;
        }

        private void ChkStockGroupID_CheckedChanged(object sender, EventArgs e)
        {
            StockGroupIDLookUpEdit.Enabled = chkStockGroupID.Checked;
        }

        private void ChkProcessID_CheckedChanged(object sender, EventArgs e)
        {
            ProcessIDLookUpEdit.Enabled = chkProcessID.Checked;
        }

        private void ChkMachineID_CheckedChanged(object sender, EventArgs e)
        {
            MachineIDLookUpEdit.Enabled = chkMachineID.Checked;
        }

        private void ChkExchangeTypeID_CheckedChanged(object sender, EventArgs e)
        {
            ExchangeTypeIDLookUpEdit.Enabled = chkExchangeTypeID.Checked;
        }

        private void ChkUnit_CheckedChanged(object sender, EventArgs e)
        {
            UnitIDLookUpEdit.Enabled = chkUnit.Checked;
        }

        private void ChkPrice_CheckedChanged(object sender, EventArgs e)
        {
            PriceSpinEdit.Enabled = chkPrice.Checked;
        }

        private void ChkAmount_CheckedChanged(object sender, EventArgs e)
        {
            AmountSpinEdit.Enabled = chkAmount.Checked;
        }

        private void ChkDate_CheckedChanged(object sender, EventArgs e)
        {
            DateDateEdit.Enabled = chkDate.Checked;
        }

        private void ChkNote_CheckedChanged(object sender, EventArgs e)
        {
            NoteTextEdit.Enabled = chkNote.Checked;
        }

        private void ChkCode1_CheckedChanged(object sender, EventArgs e)
        {
            Code1TextEdit.Enabled = chkCode1.Checked;
        }

        private void ChkCode2_CheckedChanged(object sender, EventArgs e)
        {
            Code2TextEdit.Enabled = chkCode2.Checked;
        }

        private void ChkCode3_CheckedChanged(object sender, EventArgs e)
        {
            Code3SpinEdit.Enabled = chkCode3.Checked;
        }

        private void ChkStatus_CheckedChanged(object sender, EventArgs e)
        {
            StatusLookUpEdit.Enabled = chkStatus.Checked;
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            chkAmount.Checked = chkCode1.Checked = chkCode2.Checked = chkCode3.Checked = chkDate.Checked =
                chkExpenseID.Checked = chkStockGroupID.Checked = chkProcessID.Checked = chkPrice.Checked =
                    chkMachineID.Checked = chkExchangeTypeID.Checked = chkUnit.Checked =
                        chkUnit.Checked = chkNote.Checked = chkStatus.Checked = chkAll.Checked;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                if (chkExpenseID.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colExpenseID, ExpenseIDLookUpEdit.EditValue);
                if (chkStockGroupID.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colStockGroupID, StockGroupIDLookUpEdit.EditValue);
                if (chkProcessID.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colProcessID, ProcessIDLookUpEdit.EditValue);
                if (chkMachineID.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colMachine, MachineIDLookUpEdit.EditValue);
                if (chkExchangeTypeID.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colExchangeTypeID, ExchangeTypeIDLookUpEdit.EditValue);
                if (chkUnit.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colUnitID, UnitIDLookUpEdit.EditValue);
                if (chkPrice.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colPrice, PriceSpinEdit.EditValue);
                if (chkAmount.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colAmount, AmountSpinEdit.EditValue);
                if (chkDate.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colDate, DateDateEdit.EditValue);

                if (chkNote.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colNote, NoteTextEdit.EditValue);
                if (chkCode1.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colCode1, Code1TextEdit.EditValue);
                if (chkCode2.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colCode2, Code2TextEdit.EditValue);
                if (chkStatus.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colStatus, StatusLookUpEdit.EditValue);
                if (chkCode3.Checked)
                    for (var index = 0; index < grvExpenseLine.RowCount; index++)
                        grvExpenseLine.SetRowCellValue(index, colCode3, Code3SpinEdit.EditValue);

                if (grvExpenseLine.RowCount <= 0) return;

                for (var index = 0; index < grvExpenseLine.RowCount; index++)
                {
                    var row = grvExpenseLine.GetDataRow(index);

                    _giderler.Update(row["ExpenseLineID"], row["ExpenseID"], row["StockCode"], row["StockGroupID"],
                        row["ProcessID"], row["MachineID"], row["ExchangeTypeID"], row["UnitID"], row["Price"],
                        row["Amount"], row["Date"], row["Note"], row["Code1"], row["Code2"], row["Code3"],
                        row["Status"], row["RowGUID"]);
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show(
                "Yalnızca Güncellemek istenilen kutuları seçerek, güncellemek istediğiniz değerleri girip güncelleyebilirsiniz",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Events
    }
}