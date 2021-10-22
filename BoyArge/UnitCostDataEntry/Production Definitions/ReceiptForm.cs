using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class ReceiptForm : DevExpress.XtraEditors.XtraForm
    {
        #region Definitions

        private readonly Receipt _receipt = new Receipt(LoginForm.DataConnection);
        private readonly CPMDatabase _cpm = new CPMDatabase();
        private long ReceiptId { get; set; }
        private Guid RowGuid { get; set; }

        public ReceiptForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            Format.LookUpEdit(lookOperationCode, new[] { "Operasyon Adı", "Operasyon Kodu", "Operasyon Grubu" },
                "Operasyon Adı", "Operasyon Kodu", _cpm.ViewOperationList());
            Format.LookUpEdit(lookChemicalCode, new[] { "Kimyasal Adı", "Kimyasal Kodu" }, "Kimyasal Adı",
                "Kimyasal Kodu", _cpm.ViewChemicalStockList());
            Format.LookUpEdit(lookCalculateType, new[] { "HesaplamaSekliAd", "HesaplamaSekliKod" }, "HesaplamaSekliAd",
                "HesaplamaSekliKod", _cpm.ViewCalculateTypeList());
            Format.LookUpEdit(lookExchangeTypeID, new[] { "Code" }, "Code", "ExchangeTypeID",
                ExchangeType.GetList(LoginForm.DataConnection));
            Format.LookUpEdit(lookChemicalType, new[] { "Name" }, "Name", "Code",
                TableStatus.GetList(LoginForm.DataConnection, "[dbo].[tblChemicalType]"));
            Format.LookUpEdit(lookLineStatus, new[] { "Name" }, "Name", "Code",
                TableStatus.GetList(LoginForm.DataConnection, ReceiptLine.TableName));

            RefreshList();
        }

        private void GrvReceipt_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvReceipt_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvReceipt.CalcHitInfo(e.Point).InColumn) return;

            if (grvReceipt.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvReceipt.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdReceipt.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvReceipt.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvReceipt.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var receiptId = Utility.ToInt32(grvReceipt.GetFocusedRowCellValue(colReceiptID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, Receipt.TableName, "ReceiptID", receiptId,
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

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();
        }

        private void LookUnitPrice_EditValueChanged(object sender, EventArgs e)
        {
            grvReceiptLine.SetFocusedRowCellValue(colLinePrice, ((LookUpEdit)sender).EditValue);
        }

        private void BtnCalculate_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CalculateRecipe();
        }

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void SpinEditAmount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                e.Cancel = spinEdit.Value < 0;
            }
        }

        private void SpinEditConicAmount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                e.Cancel = spinEdit.Value < 0;
            }
        }

        private void SpinEditFlotte_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                e.Cancel = spinEdit.Value < 0;
            }
        }

        private void SpinEditMaxDyeCapacity_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                e.Cancel = spinEdit.Value < 0;
            }
        }

        private void SpinEditMinDyeCapacity_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                e.Cancel = spinEdit.Value < 0;
            }
        }

        private void SpinEditOrderAmount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                e.Cancel = spinEdit.Value < 0;
            }
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdReceipt.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _receipt.Record.Reset();

            ReceiptId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvReceipt.FocusedRowHandle >= 0)
            {
                _receipt.Record.Change(grvReceipt.GetFocusedDataRow());

                rowReceiptID.Properties.Value = ReceiptId = _receipt.Record.ReceiptID;
                rowStockGroupID.Properties.Value = _receipt.Record.StockGroupID;
                rowStockCode.Properties.Value = _receipt.Record.StockCode;
                rowProcessID.Properties.Value = _receipt.Record.ProcessID;
                rowMachineID.Properties.Value = _receipt.Record.MachineID;
                rowFicheNumber.Properties.Value = _receipt.Record.FicheNumber;
                rowReceiptNumber.Properties.Value = _receipt.Record.ReceiptNumber;
                rowSerialNumber.Properties.Value = _receipt.Record.SerialNumber;
                rowAmount.Properties.Value = _receipt.Record.Amount;
                rowOrderAmount.Properties.Value = _receipt.Record.OrderAmount;
                rowFlotte.Properties.Value = _receipt.Record.Flotte;
                rowConicTypeID.Properties.Value = _receipt.Record.ConicTypeID;
                rowConicAmount.Properties.Value = _receipt.Record.ConicAmount;
                rowColorType.Properties.Value = _receipt.Record.ColorType;
                rowTouchness.Properties.Value = _receipt.Record.Touchness;
                rowFeature.Properties.Value = _receipt.Record.Feature;
                rowMinDyeCapacity.Properties.Value = _receipt.Record.MinDyeCapacity;
                rowMaxDyeCapacity.Properties.Value = _receipt.Record.MaxDyeCapacity;
                rowStatus.Properties.Value = (byte)_receipt.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _receipt.Record.RowGUID;

                foreach (var row in vGrdReceipt.Rows)
                    if (_receipt.Record.Status == Receipt.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
                grdReceiptLine.DataSource = ReceiptLine.Select(ReceiptId, LoginForm.DataConnection);
            }
            else
            {
                _receipt.Record.Reset();
                ReceiptId = 0;
                RowGuid = Guid.Empty;

                grdReceiptLine.DataSource = null;
            }
        }

        private void SaveRecord()
        {
            vGrdReceipt.FocusNext();
            vGrdReceipt.Update();

            this.CalculateRecipe();

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

                        if (ReceiptId == 0)
                        {
                            object receiptId = 0;
                            object guid = Guid.Empty;

                            result = _receipt.Insert(ref receiptId, rowStockGroupID.Properties.Value, rowStockCode.Properties.Value, rowConicTypeID.Properties.Value, rowProcessID.Properties.Value, rowMachineID.Properties.Value, rowFicheNumber.Properties.Value, rowReceiptNumber.Properties.Value, rowSerialNumber.Properties.Value, rowAmount.Properties.Value, rowOrderAmount.Properties.Value, rowFlotte.Properties.Value, rowConicAmount.Properties.Value, rowColorType.Properties.Value, rowTouchness.Properties.Value, rowFeature.Properties.Value, rowMinDyeCapacity.Properties.Value, rowMaxDyeCapacity.Properties.Value, rowStatus.Properties.Value, ref guid);

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
                            result = _receipt.Update(ReceiptId, rowStockGroupID.Properties.Value, rowStockCode.Properties.Value, rowConicTypeID.Properties.Value, rowProcessID.Properties.Value, rowMachineID.Properties.Value, rowFicheNumber.Properties.Value, rowReceiptNumber.Properties.Value, rowSerialNumber.Properties.Value, rowAmount.Properties.Value, rowOrderAmount.Properties.Value, rowFlotte.Properties.Value, rowConicAmount.Properties.Value, rowColorType.Properties.Value, rowTouchness.Properties.Value, rowFeature.Properties.Value, rowMinDyeCapacity.Properties.Value, rowMaxDyeCapacity.Properties.Value, rowStatus.Properties.Value, RowGuid);

                            if (result <= 0)
                            {
                                XtraMessageBox.Show(Resources.UpdateError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                object receiptLineID = 0;

                                for (int index = 0; index < this.grvReceiptLine.RowCount; index++)
                                {
                                    receiptLineID = Utility.ToLong(this.grvReceiptLine.GetRowCellValue(index, colReceiptLineID));
                                    object lineGUID = Utility.ToGuid(this.grvReceiptLine.GetRowCellValue(index, colGrdLineRowGUID));

                                    ReceiptLine receiptLine = new ReceiptLine(LoginForm.DataConnection);
                                    DataRow row = this.grvReceiptLine.GetDataRow(index);

                                    if (Utility.ToLong(receiptLineID) == 0)
                                    {
                                        result = receiptLine.Insert(ref receiptLineID, ReceiptId, row["LineNumber"], row["OperationCode"], row["ChemicalCode"], row["CalculateType"], row["ChemicalType"], row["UnitAmount"], row["TotalAmount"], row["Amount"], row["Note"], row["Price"], row["ExchangeTypeID"], row["Status"], ref lineGUID);
                                    }
                                    else
                                    {
                                        result = receiptLine.Update(receiptLineID, ReceiptId, row["LineNumber"], row["OperationCode"], row["ChemicalCode"], row["CalculateType"], row["ChemicalType"], row["UnitAmount"], row["TotalAmount"], row["Amount"], row["Note"], row["Price"], row["ExchangeTypeID"], row["Status"], row["RowGUID"]);
                                    }
                                }

                                XtraMessageBox.Show(Resources.UpdateInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                        }
                    }
                    catch (SqlException exc)
                    {
                        XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                else
                    XtraMessageBox.Show(Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRecord()
        {
            if (Utility.ToLong(ReceiptId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (ReceiptId > 0)
                        {
                            var result = _receipt.Delete(ReceiptId);
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
                grdReceipt.DataSource = Receipt.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdReceipt.RefreshDataSource();

                grvReceipt.FocusedRowHandle = -1;
                NewRecord();

                var stock = new Stock();
                var dStock = stock.GetList();
                var dStockGroup = StockGroup.GetList(LoginForm.DataConnection);
                var dColorType = ProductTree.ColorTypeList();
                var dMachine = Machine.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                var dConicType = ConicType.GetList(LoginForm.DataConnection);
                var dTouchness =
                    Database.GetList(
                        "SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblReceipt]','Touchness')",
                        LoginForm.DataConnection);
                var dFeature =
                    Database.GetList(
                        "SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblReceipt]','Feature')",
                        LoginForm.DataConnection);
                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, Receipt.TableName);

                Format.LookUpEdit(lookStockGroup, new[] { "StockGroup" }, "StockGroup", "StockGroupID", dStockGroup);
                Format.LookUpEdit(lookGrdStockGroup, new[] { "StockGroup" }, "StockGroup", "StockGroupID", dStockGroup);

                Format.LookUpEdit(lookColorType, new[] { "Code" }, "Code", "ColorType", dColorType);
                Format.LookUpEdit(lookGrdColorType, new[] { "Code" }, "Code", "ColorType", dColorType);

                Format.LookUpEdit(lookStockCode, new[] { "Code", "Name" }, "Name", "Code", dStock);
                Format.LookUpEdit(lookGrdStockCode, new[] { "Code", "Name" }, "Name", "Code", dStock);

                Format.LookUpEdit(lookMachineID, new[] { "Name", "Code" }, "Name", "MachineID", dMachine);
                Format.LookUpEdit(lookGrdMachine, new[] { "Name", "Code" }, "Name", "MachineID", dMachine);

                Format.LookUpEdit(lookConicTypeID, new[] { "Name", "Code" }, "Name", "ConicTypeID", dConicType);
                Format.LookUpEdit(lookGrdConicType, new[] { "Name", "Code" }, "Name", "ConicTypeID", dConicType);

                Format.LookUpEdit(lookTouchness, new[] { "Definition" }, "Definition", "ParameterID", dTouchness);
                Format.LookUpEdit(lookGrdTouchness, new[] { "Definition" }, "Definition", "ParameterID", dTouchness);

                Format.LookUpEdit(lookFeature, new[] { "Definition" }, "Definition", "ParameterID", dFeature);
                Format.LookUpEdit(lookGrdFeature, new[] { "Definition" }, "Definition", "ParameterID", dFeature);

                Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);

                var dProcess = Database.GetList("SELECT ProcessID,Machine_Group,Process FROM [dbo].[vwProcess]", LoginForm.DataConnection);
                Format.LookUpEdit(lookProcessID, new[] { "ProcessID", "Machine_Group", "Process" }, "Process", "ProcessID", dProcess);
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
            if (rowStockCode.Properties.Value == null)
                return false;

            if (rowMachineID.Properties.Value == null)
                return false;
            if (rowStockGroupID.Properties.Value == null)
                return false;
            if (rowOrderAmount.Properties.Value == null)
                return false;
            if (rowAmount.Properties.Value == null)
                return false;
            if (rowFlotte.Properties.Value == null)
                return false;
            if (rowConicAmount.Properties.Value == null)
                return false;
            if (rowConicTypeID.Properties.Value == null)
                return false;
            if (rowColorType.Properties.Value == null)
                return false;
            if (rowTouchness.Properties.Value == null)
                return false;
            if (rowFeature.Properties.Value == null)
                return false;
            if (rowMaxDyeCapacity.Properties.Value == null)
                return false;
            if (rowMinDyeCapacity.Properties.Value == null)
                return false;
            if (Utility.ToDecimal(rowMaxDyeCapacity.Properties.Value) <
                Utility.ToDecimal(rowMinDyeCapacity.Properties.Value))
            {
                XtraMessageBox.Show("Max. kapasite, minimumdan küçük olamaz!", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void CalculateRecipe()
        {
            decimal amount = 0;
            decimal totalAmount = 0;

            for (int index = 0; index < grvReceiptLine.RowCount - 1; index++)
            {
                if (Utility.ToLong(grvReceiptLine.GetRowCellValue(index, colLineCalculateType)) == 0) /* Hesaplama Şekli: Gr/Lt */
                {
                    amount = Utility.ToDecimal(grvReceiptLine.GetRowCellValue(index, colLineUnitAmount)) * Utility.ToDecimal(rowFlotte.Properties.Value);
                    totalAmount = amount * 1000;
                }
                else /* Hesaplama Şekli: % */
                {
                    amount = Utility.ToDecimal(this.rowAmount.Properties.Value) * Utility.ToDecimal(grvReceiptLine.GetRowCellValue(index, colLineUnitAmount));
                    totalAmount = amount * 10;
                }

                grvReceiptLine.SetRowCellValue(index, colReceiptAmount, amount);
                grvReceiptLine.SetRowCellValue(index, colLineTotalAmount, totalAmount);

                //var value = ((LookUpEdit)sender).EditValue;

                //this.grvReceiptLine.SetFocusedRowCellValue(colChemicalCode, value);

                Format.LookUpEdit(lookUnitPrice, new[] { "Kimyasal Adı", "Kimyasal Kodu", "Birim Fiyat", "Döviz Cinsi", "Birim", "Tedarikçi", "Alış Tarihi" }, "Birim Fiyat", "Birim Fiyat", _cpm.GetUnitPrice(grvReceiptLine.GetRowCellValue(index, colLineChemicalCode).ToString()));
            }
        }

        #endregion Functions
    }
}