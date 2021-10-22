using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class ChemicalRecipeForm : XtraForm
    {
        #region Definitions

        private readonly CPMDatabase _cpm = new CPMDatabase();
        private readonly Receipt _receipt = new Receipt(LoginForm.DataConnection);
        private readonly ReceiptLine _receiptLine = new ReceiptLine(LoginForm.DataConnection);
        private long ReceiptId { get; set; }

        #endregion Definitions

        #region Events

        public ChemicalRecipeForm()
        {
            InitializeComponent();
        }

        private void ChemicalRecipeForm_Load(object sender, EventArgs e)
        {
            Format.LookUpEdit(lookChemicalRecipe, new[] { "Reçete No", "Malzeme Kodu", "Malzeme Adı", "Renk Kodu", "Renk Adı", "Miktar", "Karışım", "Üretim Miktar" }, "Malzeme Adı", "Reçete No", _cpm.GetChemicalRecipe());
            Format.LookUpEdit(lookBoiler, new[] { "MachineGroup", "Kodu", "Adı", "İğ Sayısı", "Min", "Max", "Flotte", "Specode" }, "Adı", "MachineID", Machine.GetBoiler(LoginForm.DataConnection));
            Format.LookUpEdit(lookConicType, new[] { "Name", "Type", "Amount" }, "Amount", "ConicTypeID", ConicType.GetList(LoginForm.DataConnection));
            Format.LookUpEdit(lookOperation, new[] { "Operasyon Adı", "Operasyon Kodu", "Operasyon Grubu" }, "Operasyon Adı", "Operasyon Kodu", _cpm.ViewOperationList());
            Format.LookUpEdit(lookChemical, new[] { "Kimyasal Adı", "Kimyasal Kodu" }, "Kimyasal Adı", "Kimyasal Kodu", _cpm.ViewChemicalStockList());
            Format.LookUpEdit(lookCalculateType, new[] { "HesaplamaSekliAd", "HesaplamaSekliKod" }, "HesaplamaSekliAd", "HesaplamaSekliKod", _cpm.ViewCalculateTypeList());
            Format.LookUpEdit(lookGrdExchangeType, new[] { "Code" }, "Code", "ExchangeTypeID", ExchangeType.GetList(LoginForm.DataConnection));
            Format.LookUpEdit(lookStockGroup, new[] { "Name" }, "Name", "StockGroupID", StockGroup.GetList(LoginForm.DataConnection, true));
            Format.LookUpEdit(lookColorType, new[] { "Code" }, "Code", "ColorType", ProductTree.ColorTypeList());
            Format.LookUpEdit(lookChemicalType, new[] { "Code" }, "Code", "DyeOrChemical", Stock.ChemicalTypeList());

            var dTouchness = Database.GetList("SELECT [ParameterID], [Definition] FROM [dbo].[tblParameterList]('[dbo].[tblReceipt]','Touchness')", LoginForm.DataConnection);
            var dFeature = Database.GetList("SELECT [ParameterID], [Definition] FROM [dbo].[tblParameterList]('[dbo].[tblReceipt]','Feature')", LoginForm.DataConnection);

            Format.LookUpEdit(lookTouchness, new[] { "Definition" }, "Definition", "ParameterID", dTouchness);
            Format.LookUpEdit(lookFeature, new[] { "Definition" }, "Definition", "ParameterID", dFeature);

            var dProcess = Database.GetList("SELECT ProcessID,Machine_Group,Process FROM [dbo].[vwProcess]", LoginForm.DataConnection);
            Format.LookUpEdit(lookProcess, new[] { "ProcessID", "Machine_Group", "Process" }, "Process", "ProcessID", dProcess);

            ReceiptId = 0;
            grdReceiptLine.DataSource = ReceiptLine.Select(ReceiptId, LoginForm.DataConnection);
        }

        private void LookChemicalRecipe_EditValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void LookBoiler_EditValueChanged(object sender, EventArgs e)
        {
            if (Utility.ToLong(lookBoiler.EditValue) > 0)
            {
                if (lookBoiler.Properties.GetDataSourceRowByKeyValue(lookBoiler.EditValue) is DataRowView row)
                    spinEditFlotte.EditValue = Utility.ToInt32(row["Flotte"]);
            }
            else
            {
                spinEditFlotte.Value = 0;
            }

            GetAmount();
        }

        private void GroupControlGridControl_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Yenile":
                    RefreshList();
                    break;

                case "Kaydet":
                    SaveRecord();
                    break;

                case "Hesapla":
                    CalculateRecipe();
                    break;
            }
        }

        private void LookConicType_EditValueChanged(object sender, EventArgs e)
        {
            GetAmount();
        }

        private void ToggleReceipt_Toggled(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void LookChemical_EditValueChanged(object sender, EventArgs e)
        {
            var value = ((LookUpEdit)sender).EditValue;

            grvReceiptLine.SetFocusedRowCellValue(colChemicalCode, value);

            Format.LookUpEdit(lookUnitPrice, new[] { "Kimyasal Adı", "Kimyasal Kodu", "Birim Fiyat", "Döviz Cinsi", "Birim", "Tedarikçi", "Alış Tarihi" }, "Birim Fiyat", "Birim Fiyat", _cpm.GetUnitPrice(value.ToString()));
        }

        private void LookUnitPrice_EditValueChanged(object sender, EventArgs e)
        {
            grvReceiptLine.SetFocusedRowCellValue(colPrice, ((LookUpEdit)sender).EditValue);
        }

        private void GrvReceiptLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (!toggleReceipt.Enabled)
                return;

            if (e.Column != colUnitAmount) return;
            if (grvReceiptLine.GetRowCellValue(e.RowHandle, colCalculateType) == null) return;

            decimal amount;
            decimal totalAmount;

            if (Utility.ToLong(grvReceiptLine.GetRowCellValue(e.RowHandle, colCalculateType)) == 0
            ) /* Hesaplama Şekli: 'Gr/Lt' */
            {
                totalAmount = (decimal)e.Value * spinEditFlotte.Value;
                amount = totalAmount / 1000;
            }
            else /* Hesaplama Şekli: '% 'Yüzde  */
            {
                totalAmount = spinEditAmount.Value * (decimal)e.Value * 10;
                amount = totalAmount / 1000;
            }

            grvReceiptLine.SetRowCellValue(e.RowHandle, colAmount, amount);
            grvReceiptLine.SetRowCellValue(e.RowHandle, colTotalAmount, totalAmount);
        }

        private void GrvReceiptLine_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            Format.LookUpEdit(lookUnitPrice, new[] { "Kimyasal Adı", "Kimyasal Kodu", "Birim Fiyat", "Döviz Cinsi", "Birim", "Tedarikçi", "Alış Tarihi" }, "Birim Fiyat", "Birim Fiyat", _cpm.GetUnitPrice(grvReceiptLine.GetRowCellValue(e.FocusedRowHandle, colChemicalCode).ToString()));
        }

        private void SpinEditFlotte_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = spinEditFlotte.Value < 0;
        }

        private void SpinEditOrderAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = spinEditOrderAmount.Value < 0;
        }

        private void SpinEditAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = spinEditAmount.Value < 0;
        }

        private void SpinMinDyeCapacity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = spinMinDyeCapacity.Value < 0;
        }

        private void SpinMaxDyeCapacity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = spinMaxDyeCapacity.Value < 0;
        }

        #endregion Events

        #region Functions

        private void CalculateRecipe()
        {
            decimal amount;
            decimal totalAmount;

            for (var index = 0; index < grvReceiptLine.RowCount - 1; index++)
            {
                /* Hesaplama Şekli: Gr/Lt */
                if (Utility.ToLong(grvReceiptLine.GetRowCellValue(index, colCalculateType)) == 0)
                {
                    totalAmount = Utility.ToDecimal(grvReceiptLine.GetRowCellValue(index, colUnitAmount)) * spinEditFlotte.Value; //gr
                    amount = totalAmount / 1000; //kg
                }
                /* Hesaplama Şekli: % */
                else
                {
                    totalAmount = Utility.ToDecimal(grvReceiptLine.GetRowCellValue(index, colUnitAmount)) * spinEditAmount.Value * 10; //gr
                    amount = totalAmount / 1000; //kg
                }

                grvReceiptLine.SetRowCellValue(index, colAmount, amount);
                grvReceiptLine.SetRowCellValue(index, colTotalAmount, totalAmount);

                //var value = ((LookUpEdit)sender).EditValue;

                //this.grvReceiptLine.SetFocusedRowCellValue(colChemicalCode, value);

                Format.LookUpEdit(lookUnitPrice, new[] { "Kimyasal Adı", "Kimyasal Kodu", "Birim Fiyat", "Döviz Cinsi", "Birim", "Tedarikçi", "Alış Tarihi" }, "Birim Fiyat", "Birim Fiyat", _cpm.GetUnitPrice(grvReceiptLine.GetRowCellValue(index, colChemicalCode).ToString()));
            }
        }

        private void GetAmount()
        {
            if (!(lookBoiler.Properties.GetDataSourceRowByKeyValue(lookBoiler.EditValue) is DataRowView rowBoiler)) return;

            switch (txtPaintType.Text)
            {
                case "BOBİN":
                    if (!(lookConicType.Properties.GetDataSourceRowByKeyValue(lookConicType.EditValue) is DataRowView
                        rowConic)) return;

                    if (rowConic["Type"].ToString() == "Piko")
                    {
                        spinMinConic.Value = Utility.ToDecimal(rowBoiler["Code3"]); //Minimum Konik Sayısı
                        spinMaxConic.Value = Utility.ToDecimal(rowBoiler["İğ Sayısı"]);
                        spinMinAmount.Value = Utility.ToDecimal(rowBoiler["Code3"]) * Utility.ToDecimal(rowConic["Amount"]) / 1000;
                        spinMaxAmount.Value = Utility.ToDecimal(rowBoiler["İğ Sayısı"]) * Utility.ToDecimal(rowConic["Amount"]) / 1000;
                    }
                    else if (rowConic["Type"].ToString() == "Silindir")
                    {
                        spinMinConic.Value = Utility.ToDecimal(rowBoiler["Code3"]) * Utility.ToDecimal(rowConic["ConicConverterFactor"]);
                        spinMaxConic.Value = Utility.ToDecimal(rowBoiler["İğ Sayısı"]) * Utility.ToDecimal(rowConic["ConicConverterFactor"]);

                        spinMinAmount.Value = Utility.ToDecimal(rowBoiler["Code3"]) * (Utility.ToDecimal(rowConic["Amount"]) / 1000) * Utility.ToDecimal(rowConic["ConicConverterFactor"]);
                        spinMaxAmount.Value = Utility.ToDecimal(rowBoiler["İğ Sayısı"]) * (Utility.ToDecimal(rowConic["Amount"]) / 1000) * Utility.ToDecimal(rowConic["ConicConverterFactor"]);
                    }

                    break;

                default:
                    spinMinAmount.Value = Utility.ToDecimal(rowBoiler["Min"]);
                    spinMaxAmount.Value = Utility.ToDecimal(rowBoiler["Max"]);

                    break;
            }

            if (Utility.ToBoolean(toggleReceipt.EditValue))
                spinEditAmount.Properties.MaxValue = spinMaxAmount.Value;
            else
                spinEditAmount.Properties.MaxValue = spinEditAmount.Value = spinMaxAmount.Value;

            //spinEditAmount.Properties.MaxValue = spinEditAmount.Value = spinMaxAmount.Value;
        }

        private bool CheckRow()
        {
            if (lookChemicalRecipe.EditValue == null || lookChemicalRecipe.EditValue.ToString().Length <= 0)
            {
                XtraMessageBox.Show("Reçete No seçiniz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (lookBoiler.EditValue == null || Utility.ToLong(lookBoiler.EditValue) <= 0)
            {
                XtraMessageBox.Show("Boya kazanı seçiniz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (spinEditAmount.Value == 0)
            {
                XtraMessageBox.Show("Miktar giriniz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            for (int index = 0; index < grvReceiptLine.RowCount - 1; index++)
                if (grvReceiptLine.GetRowCellValue(index, colExchangeTypeID) == null || Utility.ToLong(grvReceiptLine.GetRowCellValue(index, colExchangeTypeID)) <= 0)
                {
                    XtraMessageBox.Show("Döviz Türü seçiniz", $"{(index + 1)}. satır");
                    return false;
                }

            return true;
        }

        private void RefreshList()
        {
            ReceiptId = 0;
            txtCurrentAccount.Text = txtSerialNumber.Text = txtPaintType.Text = txtRecipeNumber.Text = "";

            spinMinConic.Value = spinMaxConic.Value = spinMinAmount.Value = spinMaxAmount.Value = spinEditAmount.Value = 0;
            lookBoiler.EditValue = lookConicType.EditValue = null;
            grdReceiptLine.DataSource = null;

            if (lookChemicalRecipe.EditValue == null || lookChemicalRecipe.EditValue.ToString().Length <= 0) return;

            var row = (DataRowView)lookChemicalRecipe.Properties.GetDataSourceRowByKeyValue(lookChemicalRecipe.EditValue);

            if (row == null) return;

            txtSerialNumber.Text = row["Seri No"].ToString();
            txtCurrentAccount.Text = row["Müşteri"].ToString();
            txtPaintType.Text = row["Boyama Tipi"].ToString();
            spinEditOrderAmount.EditValue = Utility.ToDecimal(row["Miktar"]);
            txtRecipeNumber.Text = row["Reçete No"].ToString();
            txtMix.Text = row["Karışım"].ToString();

            //this.grdOperation.DataSource = stock.GetOperation(row["Reçete No"].ToString());

            lookConicType.Enabled = txtPaintType.Text == "BOBİN";

            grdReceiptLine.DataSource = Utility.ToBoolean(toggleReceipt.EditValue) ? _cpm.GetReceiptLine(row["Reçete No"].ToString()) : ReceiptLine.Select(ReceiptId, LoginForm.DataConnection);
        }

        private void SaveRecord()
        {
            CalculateRecipe();

            if (!ScreenPermission.ScreenPermissionEdit(LoginForm.UserId, Tag.ToString(), LoginForm.DataConnection))
            {
                XtraMessageBox.Show(Resources.PermissionDenied, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!CheckRow())
                return;

            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (!Database.CheckConnection(LoginForm.DataConnection))
            {
                XtraMessageBox.Show(Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                grvReceiptLine.FocusedRowHandle = -1;
                if (ReceiptId == 0)
                {
                    object receiptId = 0;
                    object guid = Guid.Empty;
                    object conicAmount = 0;

                    if (lookConicType.EditValue != null)
                        conicAmount = lookConicType.Text;

                    var row = (DataRowView)lookChemicalRecipe.Properties.GetDataSourceRowByKeyValue(lookChemicalRecipe.EditValue);

                    var result = _receipt.Insert(ref receiptId, lookStockGroup.EditValue, row["Malzeme Kodu"].ToString(), lookConicType.EditValue, lookProcess.EditValue, lookBoiler.EditValue, "", txtRecipeNumber.Text, txtSerialNumber.Text, spinEditAmount.EditValue, spinEditOrderAmount.EditValue, spinEditFlotte.EditValue, conicAmount, lookColorType.EditValue, lookTouchness.EditValue, lookFeature.EditValue, spinMinDyeCapacity.EditValue, spinMaxDyeCapacity.EditValue, Receipt.Status.Active, ref guid);

                    ReceiptId = Utility.ToLong(receiptId);

                    if (result <= 0)
                    {
                        XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        object receiptLineId = 0;
                        object rowGuid = Guid.Empty;

                        for (int index = 0; index < grvReceiptLine.RowCount; index++)
                            if (grvReceiptLine.IsDataRow(index))
                                _receiptLine.Insert(ref receiptLineId, ReceiptId, grvReceiptLine.GetRowCellValue(index, colLineNumber), grvReceiptLine.GetRowCellValue(index, colOperationCode), grvReceiptLine.GetRowCellValue(index, colChemicalCode), grvReceiptLine.GetRowCellValue(index, colCalculateType), grvReceiptLine.GetRowCellValue(index, colChemicalType), grvReceiptLine.GetRowCellValue(index, colUnitAmount), grvReceiptLine.GetRowCellValue(index, colTotalAmount), grvReceiptLine.GetRowCellValue(index, colAmount), grvReceiptLine.GetRowCellValue(index, colNote), grvReceiptLine.GetRowCellValue(index, colPrice), grvReceiptLine.GetRowCellValue(index, colExchangeTypeID), ReceiptLine.Status.Active, ref rowGuid);

                        XtraMessageBox.Show(Resources.InsertInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ResetForm();
                RefreshList();
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ResetForm()
        {
            ReceiptId = 0;
            spinEditAmount.EditValue = spinEditFlotte.EditValue = spinEditOrderAmount.EditValue = spinMinDyeCapacity.EditValue = spinMaxDyeCapacity.EditValue = spinMinConic.EditValue = spinMaxConic.EditValue = 0;
            txtCurrentAccount.Text = txtSerialNumber.Text = txtPaintType.Text = txtRecipeNumber.Text = txtMix.Text = "";
            grdReceiptLine.DataSource = null;
            lookStockGroup.EditValue = lookColorType.EditValue = lookTouchness.EditValue = lookFeature.EditValue = lookBoiler.EditValue = lookConicType.EditValue = lookChemicalRecipe.EditValue = lookProcess.EditValue = null;
        }

        #endregion Functions
    }
}