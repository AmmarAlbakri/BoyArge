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
    public partial class StockProcessRelationForm : RibbonForm
    {
        #region Definitions

        private readonly StockProcessRelation _mamulProsesRel = new StockProcessRelation(LoginForm.DataConnection);
        private long StockProcessRelationId { get; set; }
        private Guid RowGuid { get; set; }

        public StockProcessRelationForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void StockProcessRelationForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvStockProcessRelation_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvStockProcessRelation_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvStockProcessRelation.CalcHitInfo(e.Point).InColumn) return;

            if (grvStockProcessRelation.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvStockProcessRelation.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdStockProcessRelation.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvStockProcessRelation.FocusedRowHandle < 0)
                return;

            var status = Utility.ToInt32(grvStockProcessRelation.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var stockProcessRelationId =
                Utility.ToInt32(grvStockProcessRelation.GetFocusedRowCellValue(colStockProcessRelationID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, StockProcessRelation.TableName,
                    "StockProcessRelationID", stockProcessRelationId, newStatus);

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

        private void BtnEditRecords_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvStockProcessRelation.GetSelectedRows().Length <= 0) return;

            try
            {
                var fStockProcessRelationEdit = new StockProcessRelationEditForm();

                var dSelectedList = Database.GetList("SELECT * FROM [dbo].[tblStockProcessRelation] WHERE 1=0",
                    LoginForm.DataConnection); // new DataTable();

                foreach (var index in grvStockProcessRelation.GetSelectedRows())
                {
                    var row = grvStockProcessRelation.GetDataRow(index);
                    dSelectedList.ImportRow(row);
                }

                fStockProcessRelationEdit.dSelectedList = dSelectedList;

                if (fStockProcessRelationEdit.ShowDialog() == DialogResult.OK)
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

        private void spinEditLineNumber_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void spinEditPeriodCount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void spinEditTurnOver_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void spinEditWastage_Validating(object sender, CancelEventArgs e)
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

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdStockProcessRelation.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _mamulProsesRel.Record.Reset();

            StockProcessRelationId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvStockProcessRelation.FocusedRowHandle >= 0)
            {
                _mamulProsesRel.Record.Change(grvStockProcessRelation.GetFocusedDataRow());

                rowStockProcessRelationID.Properties.Value =
                    StockProcessRelationId = _mamulProsesRel.Record.StockProcessRelationID;
                rowStockGroupID.Properties.Value = _mamulProsesRel.Record.StockGroupID;
                rowProcessID.Properties.Value = _mamulProsesRel.Record.ProcessID;
                rowMachineID.Properties.Value = _mamulProsesRel.Record.MachineID;
                rowArithmeticOperatorID.Properties.Value = _mamulProsesRel.Record.ArithmeticOperatorID;
                rowTurnOver.Properties.Value = _mamulProsesRel.Record.TurnOver;
                rowEfficiency.Properties.Value = _mamulProsesRel.Record.Efficiency;
                rowWastage.Properties.Value = _mamulProsesRel.Record.Wastage;
                rowAmount.Properties.Value = _mamulProsesRel.Record.Amount;
                rowPeriodCount.Properties.Value = _mamulProsesRel.Record.PeriodCount;
                rowWorkerCount.Properties.Value = _mamulProsesRel.Record.WorkerCount;
                rowMachineOrProcess.Properties.Value = _mamulProsesRel.Record.MachineOrProcess;
                rowLineNumber.Properties.Value = _mamulProsesRel.Record.LineNumber;
                rowStatus.Properties.Value = (byte)_mamulProsesRel.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _mamulProsesRel.Record.RowGUID;

                foreach (var row in vGrdStockProcessRelation.Rows)
                    if (_mamulProsesRel.Record.Status == StockProcessRelation.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _mamulProsesRel.Record.Reset();
                StockProcessRelationId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdStockProcessRelation.FocusNext();
            vGrdStockProcessRelation.Update();
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

                        if (StockProcessRelationId == 0)
                        {
                            object stockProcessRelationId = 0;
                            object guid = Guid.Empty;

                            result = _mamulProsesRel.Insert(ref stockProcessRelationId,
                                rowStockGroupID.Properties.Value, rowProcessID.Properties.Value,
                                rowMachineID.Properties.Value, rowArithmeticOperatorID.Properties.Value,
                                rowTurnOver.Properties.Value, rowEfficiency.Properties.Value,
                                rowWastage.Properties.Value, rowAmount.Properties.Value,
                                rowPeriodCount.Properties.Value, rowWorkerCount.Properties.Value,
                                rowMachineOrProcess.Properties.Value, rowLineNumber.Properties.Value,
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
                            result = _mamulProsesRel.Update(StockProcessRelationId, rowStockGroupID.Properties.Value,
                                rowProcessID.Properties.Value, rowMachineID.Properties.Value,
                                rowArithmeticOperatorID.Properties.Value, rowTurnOver.Properties.Value,
                                rowEfficiency.Properties.Value, rowWastage.Properties.Value, rowAmount.Properties.Value,
                                rowPeriodCount.Properties.Value, rowWorkerCount.Properties.Value,
                                rowMachineOrProcess.Properties.Value, rowLineNumber.Properties.Value,
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
            if (Utility.ToLong(StockProcessRelationId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (StockProcessRelationId > 0)
                        {
                            var result = _mamulProsesRel.Delete(StockProcessRelationId);
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
                grdStockProcessRelation.DataSource =
                    StockProcessRelation.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdStockProcessRelation.RefreshDataSource();

                grvStockProcessRelation.FocusedRowHandle = -1;
                NewRecord();

                using (var dStockGroup = StockGroup.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookStock, new[] { "StockGroup" }, "StockGroup", "StockGroupID", dStockGroup);
                    Format.LookUpEdit(lookGrdStockGroupID, new[] { "StockGroup" }, "StockGroup", "StockGroupID",
                        dStockGroup);
                }

                using (var dProcess = Process.GetList(LoginForm.DataConnection, 0, !toggleSwitch.Checked))
                {
                    Format.LookUpEdit(lookProcess, new[] { "Name", "Code" }, "Name", "ProcessID", dProcess);
                    Format.LookUpEdit(lookGrdProcess, new[] { "Name", "Code" }, "Name", "ProcessID", dProcess);
                }

                using (var dMachine = Machine.GetList(LoginForm.DataConnection, !toggleSwitch.Checked))
                {
                    Format.LookUpEdit(lookMachine, new[] { "Name", "Code" }, "Name", "MachineID", dMachine);
                    Format.LookUpEdit(lookGrdMachine, new[] { "Name", "Code" }, "Name", "MachineID", dMachine);
                }

                using (var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, StockProcessRelation.TableName))
                {
                    Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                    Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                }

                using (var dArithmeticOperator =
                    TableStatus.GetList(LoginForm.DataConnection, "[dbo].[tblArithmeticOperator]"))
                {
                    Format.LookUpEdit(lookArithmeticOperatorID, new[] { "Code", "Name" }, "Code", "TableStatusID",
                        dArithmeticOperator);
                    Format.LookUpEdit(lookGrdArithmeticOperatorID, new[] { "Code", "Name" }, "Code", "TableStatusID",
                        dArithmeticOperator);
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
            if (rowStockGroupID.Properties.Value == null)
                return false;

            if (rowProcessID.Properties.Value == null)
                return false;

            if (rowMachineID.Properties.Value == null)
                return false;

            if (rowArithmeticOperatorID.Properties.Value == null)
                return false;

            return true;
        }

        #endregion Functions
    }
}