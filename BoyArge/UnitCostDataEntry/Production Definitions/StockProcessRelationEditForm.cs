using BoyArge.Properties;
using Business;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class StockProcessRelationEditForm : XtraForm
    {
        #region Functions

        private void LoadSources()
        {
            try
            {
                using (var dStockGroup = StockGroup.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(StockGroupIDLookUpEdit, new[] { "StockGroup" }, "StockGroup", "StockGroupID",
                        dStockGroup);
                    Format.LookUpEdit(lookGrdStockGroupID, new[] { "Name" }, "Name", "StockGroupID", dStockGroup);
                }

                using (var dProcess = Process.GetList(LoginForm.DataConnection, 0))
                {
                    Format.LookUpEdit(ProcessIDLookUpEdit, new[] { "Name", "Code" }, "Name", "ProcessID", dProcess);
                    Format.LookUpEdit(lookGrdProcess, new[] { "Name", "Code" }, "Name", "ProcessID", dProcess);
                }

                using (var dMachine = Machine.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(MachineIDLookUpEdit, new[] { "Name", "Code" }, "Name", "MachineID", dMachine);
                    Format.LookUpEdit(lookGrdMachine, new[] { "Name", "Code" }, "Name", "MachineID", dMachine);
                }

                using (var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, StockProcessRelation.TableName))
                {
                    Format.LookUpEdit(StatusLookUpEdit, new[] { "Name" }, "Name", "Code", dTableStatus);
                    Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                }

                using (var dArithmeticOperator =
                    TableStatus.GetList(LoginForm.DataConnection, "[dbo].[tblArithmeticOperator]"))
                {
                    Format.LookUpEdit(ArithmeticOperatorIDLookUpEdit, new[] { "Code", "Name" }, "Code", "TableStatusID",
                        dArithmeticOperator);
                    Format.LookUpEdit(lookGrdArithmeticOperatorID, new[] { "Code", "Name" }, "Code", "TableStatusID",
                        dArithmeticOperator);
                }

                using (dSelectedList)
                {
                    grdStockProcessRelation.DataSource = dSelectedList;
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
        private readonly StockProcessRelation _kapasite = new StockProcessRelation(LoginForm.DataConnection);

        #endregion Definitions

        #region Events

        public StockProcessRelationEditForm()
        {
            InitializeComponent();
        }

        private void StockProcessRelationEditForm_Load(object sender, EventArgs e)
        {
            LoadSources();

            StockGroupIDLookUpEdit.Enabled = ProcessIDLookUpEdit.Enabled = MachineIDLookUpEdit.Enabled =
                ArithmeticOperatorIDLookUpEdit.Enabled = TurnOverSpinEdit.Enabled = EfficiencySpinEdit.Enabled =
                    AmountSpinEdit.Enabled = WastageSpinEdit.Enabled = PeriodCountSpinEdit.Enabled =
                        WorkerCountSpinEdit.Enabled =
                            MachineOrProcessLookupEdit.Enabled = StatusLookUpEdit.Enabled = false;
        }

        private void chcStockGroup_CheckedChanged(object sender, EventArgs e)
        {
            StockGroupIDLookUpEdit.Enabled = chkStockGroup.Checked;
        }

        private void chkProcess_CheckedChanged(object sender, EventArgs e)
        {
            ProcessIDLookUpEdit.Enabled = chkProcess.Checked;
        }

        private void chkMachine_CheckedChanged(object sender, EventArgs e)
        {
            MachineIDLookUpEdit.Enabled = chkMachine.Checked;
        }

        private void chkArithmeticOperator_CheckedChanged(object sender, EventArgs e)
        {
            ArithmeticOperatorIDLookUpEdit.Enabled = chkArithmeticOperator.Checked;
        }

        private void chkAmount_CheckedChanged(object sender, EventArgs e)
        {
            AmountSpinEdit.Enabled = chkAmount.Checked;
        }

        private void chkPeriodCount_CheckedChanged(object sender, EventArgs e)
        {
            PeriodCountSpinEdit.Enabled = chkPeriodCount.Checked;
        }

        private void chkWastage_CheckedChanged(object sender, EventArgs e)
        {
            WastageSpinEdit.Enabled = chkWastage.Checked;
        }

        private void chkWorkerCount_CheckedChanged(object sender, EventArgs e)
        {
            WorkerCountSpinEdit.Enabled = chkWorkerCount.Checked;
        }

        private void chkMachineOrProcess_CheckedChanged(object sender, EventArgs e)
        {
            MachineOrProcessLookupEdit.Enabled = chkMachineOrProcess.Checked;
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            StatusLookUpEdit.Enabled = chkStatus.Checked;
        }

        private void chkTurnOver_CheckedChanged(object sender, EventArgs e)
        {
            TurnOverSpinEdit.Enabled = chkTurnOver.Checked;
        }

        private void chkEfficiency_CheckedChanged(object sender, EventArgs e)
        {
            EfficiencySpinEdit.Enabled = chkEfficiency.Checked;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            chkStockGroup.Checked = chkProcess.Checked = chkMachine.Checked = chkArithmeticOperator.Checked =
                chkTurnOver.Checked = chkEfficiency.Checked = chkAmount.Checked = chkWastage.Checked =
                    chkPeriodCount.Checked = chkWorkerCount.Checked =
                        chkMachineOrProcess.Checked = chkStatus.Checked = chkAll.Checked;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                if (chkStockGroup.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colStockGroupID,
                            StockGroupIDLookUpEdit.EditValue);
                if (chkProcess.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colProcessID, ProcessIDLookUpEdit.EditValue);
                if (chkMachine.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colMachineID, MachineIDLookUpEdit.EditValue);
                if (chkArithmeticOperator.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colArithmeticOperatorID,
                            ArithmeticOperatorIDLookUpEdit.EditValue);
                if (chkTurnOver.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colTurnOver, TurnOverSpinEdit.EditValue);
                if (chkEfficiency.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colEfficiency, EfficiencySpinEdit.EditValue);
                if (chkAmount.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colAmount, AmountSpinEdit.EditValue);
                if (chkWastage.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colWastage, WastageSpinEdit.EditValue);
                if (chkPeriodCount.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colPeriodCount, PeriodCountSpinEdit.EditValue);
                if (chkWorkerCount.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colWorkerCount, WorkerCountSpinEdit.EditValue);
                if (chkMachineOrProcess.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colMachineOrProcess,
                            MachineOrProcessLookupEdit.EditValue);
                if (chkStatus.Checked)
                    for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                        grvStockProcessRelation.SetRowCellValue(index, colStatus, StatusLookUpEdit.EditValue);

                if (grvStockProcessRelation.RowCount <= 0) return;

                for (var index = 0; index < grvStockProcessRelation.RowCount; index++)
                {
                    var row = grvStockProcessRelation.GetDataRow(index);

                    _kapasite.Update(row["StockProcessRelationID"], row["StockGroupID"], row["ProcessID"],
                        row["MachineID"], row["ArithmeticOperatorID"], row["TurnOver"], row["Efficiency"],
                        row["Wastage"], row["Amount"], row["PeriodCount"], row["WorkerCount"], row["MachineOrProcess"],
                        row["LineNumber"], row["Status"], row["RowGUID"]);
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show(
                "Yalnızca Güncellemek istenilen kutuları seçerek, güncellemek istediğiniz değerleri girip güncelleyebilirsiniz",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Events
    }
}