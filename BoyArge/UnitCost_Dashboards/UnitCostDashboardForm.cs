using Business;
using Core;
using DevExpress.DashboardCommon;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class UnitCostDashboardForm : RibbonForm
    {
        #region Definitions

        private bool _panelState = false;
        public UnitCostParameter UnitCostParameter;
        public UnitCostParameter.UnitCostType UnitCostType;

        private int sayi;

        #endregion Definitions

        #region Events

        public UnitCostDashboardForm()
        {
            InitializeComponent();
        }

        private void UnitCostDashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSource();

                UnitCostParameter = new UnitCostParameter();

                if (StartForm.Parameter != null)
                {
                    LoadParameter();

                    UnitCostParameter = StartForm.Parameter;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void SpinEditOrderAmount_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinEditOrderAmount.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinRingBobinNr_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinRingBobinNr.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinFinalNr_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinFinalNr.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinBukumNr_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinBukumNr.EditValue) < 0)
                e.Cancel = true;
        }

        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ChangePanelState();
        }

        private void BtnDashboardDesigner_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string check;
                if (this.IsMdiChild)
                    check = StartForm.manager.View.ActiveDocument.Form.Text;
                else
                    check = this.Text;

                var dashboardDesignerForm = new DashboardDesignerForm
                {
                    Caption = check,//(UnitCostParameter.UnitCostType)Utility.ToInt32((byte)UnitCostType),
                    DashboardType_ = DashboardDesignerForm.DashboardType.UnitCost,
                    UnitCostReportType = UnitCostParameter.ReportType.Dynamic,
                    Module = Document.Module.MrSmart
                };

                dashboardDesignerForm.BringToFront();

                dashboardDesignerForm.WindowState = FormWindowState.Maximized;
                dashboardDesignerForm.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();

            if (toggleSwitch1.IsOn == false)
            {
                sayi = 45;
                timer1.Enabled = true;
                timer1.Interval = 1000;
            }
        }

        private void DashboardViewer_CustomParameters(object sender, CustomParametersEventArgs e)
        {
            if (e.Parameters.Count == dashboardViewer.Dashboard.Parameters.Count)
                for (var index = 0; index < e.Parameters.Count; index++)
                    e.Parameters[index] = UnitCostParameter.parameterList[index];
            else
                XtraMessageBox.Show("Parametre sayısı uyumsuz olduğu için Veriler Hatalı olabilir!", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion Events

        #region Functions

        private void LoadParameter()
        {
            try
            {
                //dateEdit.EditValue = StartForm.Parameter.Date;
                lookMainProduct.EditValue = StartForm.Parameter.MainStockCode;
                lookStockFeatureTypeID1.EditValue = StartForm.Parameter.StockFeatureTypeID;
                spinEditOrderAmount.EditValue = StartForm.Parameter.OrderAmount;
                lookCapacityType.EditValue = StartForm.Parameter.CapacityType;
                spinRingBobinNr.EditValue = StartForm.Parameter.RingNo;
                spinBukumNr.EditValue = StartForm.Parameter.BukumNo;
                spinFinalNr.EditValue = StartForm.Parameter.FinalNo;
                lookOrderType.EditValue = StartForm.Parameter.OrderType;
                lookDeliveryType.EditValue = StartForm.Parameter.DeliveryType;
                lookPaymentDate.EditValue = StartForm.Parameter.PaymentDate;
                lookPackageType.EditValue = StartForm.Parameter.PackageType;
                lookProductTreeFiche.EditValue = StartForm.Parameter.ProductTreeFicheID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LoadSource()
        {
            try
            {
                dateEdit.DateTime = DateTime.Now;

                if (!Database.CheckConnection(LoginForm.DataConnection)) return;

                var stokfeaturetype = Database.GetList($"SELECT [StockFeatureTypeID],[Name],[StockCode] FROM [dbArge].[dbo].[tblStockFeatureType] ", LoginForm.DataConnection);
                if (stokfeaturetype == null)
                    return;
                else
                    Format.LookUpEdit(lookStockFeatureTypeID1, new[] { "Name" }, "Name", "StockFeatureTypeID", stokfeaturetype);

                var dStock = new Stock().GetList();
                using (dStock)
                {
                    Format.LookUpEdit(lookMainProduct, new[] { "Code", "Name" }, "Name", "Code", dStock);
                }

                using (var dPaymentDate =
                    Database.GetList(
                        "SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','PaymentDate')",
                        LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookPaymentDate, new[] { "Definition" }, "Definition", "ParameterID", dPaymentDate);
                }

                using (var dOrderType =
                    Database.GetList(
                        "SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','OrderType')",
                        LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookOrderType, new[] { "Definition" }, "Definition", "ParameterID", dOrderType);
                }

                using (var dCapacityType =
                    Database.GetList(
                        "SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','CapacityType')",
                        LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookCapacityType, new[] { "Definition" }, "Definition", "ParameterID",
                        dCapacityType);
                }

                using (var dPackageType =
                    Database.GetList(
                        "SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','PackageType')",
                        LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookPackageType, new[] { "Definition" }, "Definition", "ParameterID", dPackageType);
                }

                using (var dDeliveryType =
                    Database.GetList(
                        "SELECT ParameterID, Definition, Feature, Property FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','DeliveryType')",
                        LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookDeliveryType, new[] { "Definition", "Feature", "Property" }, "Definition", "ParameterID", dDeliveryType);
                }

                using (var dProductTreeFiche = ProductTreeFiche.Select(0, "", 0, (byte)ProductTreeFiche.Status.Active, LoginForm.DataConnection, 0))
                {
                    Format.LookUpEdit(lookProductTreeFiche, new[] { "ProductTreeFicheID", "Date", "StockName", "StockFeatureType", "ColorType", "RingNr", "BukumNr", "FinalNr", "PaymentDateCode", "DeliveryTypeCode", "Maliyet" }, "StockFeatureType", "ProductTreeFicheID", dProductTreeFiche);
                }
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshList()
        {
            if (lookProductTreeFiche.EditValue.ToString() == "0" || lookProductTreeFiche.EditValue == null || lookProductTreeFiche.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Fiş Seçiniz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (!toggleSwitch.Checked)
                    toggleSwitch.Checked = true;

                int calculate_type;
                if (toggleSwitch1.IsOn == true)
                    calculate_type = 1;
                else
                    calculate_type = 0;

                UnitCostParameter.Change((UnitCostParameter.UnitCostType)Utility.ToInt32((byte)UnitCostType), dateEdit.DateTime.Date, lookMainProduct.EditValue, lookStockFeatureTypeID1.EditValue, spinEditOrderAmount.EditValue, lookCapacityType.EditValue, spinRingBobinNr.EditValue, spinBukumNr.EditValue, spinFinalNr.EditValue, calculate_type, lookOrderType.EditValue, lookDeliveryType.EditValue, lookPaymentDate.EditValue, lookPackageType.EditValue, lookProductTreeFiche.EditValue);

                StartForm.Parameter = UnitCostParameter;

                switch ((UnitCostParameter.UnitCostType)Utility.ToInt32((byte)UnitCostType))
                {
                    case UnitCostParameter.UnitCostType.ProductUnitCost:

                        LoadDashboard("DynamicProductUnitCostDashboard");
                        break;

                    case UnitCostParameter.UnitCostType.ProcessUnitCost:

                        LoadDashboard("DynamicProcessUnitCostDashboard");
                        break;

                    case UnitCostParameter.UnitCostType.ZoneExpense:

                        LoadDashboard("DynamicZoneExpenseDashboard");
                        break;

                    case UnitCostParameter.UnitCostType.Capacity:

                        LoadDashboard("DynamicCapacityDashboard");
                        break;

                    case UnitCostParameter.UnitCostType.UnitCost:

                        LoadDashboard("DynamicUnitCostDashboard");
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void ChangePanelState()
        {
            _panelState = !_panelState;

            if (_panelState)
            {
                lcGroupDynamic.Visibility = LayoutVisibility.Never;
            }
            else
            {
                lcGroupDynamic.Visibility = LayoutVisibility.Always;
            }
        }

        private void LoadDashboard(string DashboardName)
        {
            try
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                {
                    var dash = new Dashboard();
                    dash.LoadFromXDocument(Document.LoadDashboard(DashboardName, LoginForm.UserStatus, LoginForm.DataConnection));
                    dashboardViewer.Dashboard = dash;
                }
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        #endregion Functions

        private void lookProductTreeFiche_EditValueChanged(object sender, EventArgs e)
        {
            if (lookProductTreeFiche.EditValue == null) return;

            DataRow row;
            try
            {
                row = Database.GetRow($"SELECT [ProductTreeFicheID]" +
                    $",[StockFeatureTypeID]" +
                    $",[MainStockCode]" +
                    $",[Date]" +
                    $",[OrderType]" +
                    $",[CapacityType]" +
                    $",[DeliveryType]" +
                    $",[PaymentDate]" +
                    $",[PackageType]" +
                    $",[OrderAmount]" +
                    $",[RingNr]" +
                    $",[BukumNr]" +
                    $",[FinalNr]" +
                    $",[DyeType]" +
                    $",[Code1]" +
                    $",[Code2]" +
                    $",[Code3]" +
                    $"FROM [dbArge].[dbo].[tblProductTreeFiche] WHERE [ProductTreeFicheID] ='{lookProductTreeFiche.EditValue}'", LoginForm.DataConnection);

                if (row != null)
                {
                    spinEditOrderAmount.EditValue = row["OrderAmount"];
                    spinRingBobinNr.EditValue = row["RingNr"];
                    spinBukumNr.EditValue = row["BukumNr"];
                    spinFinalNr.EditValue = row["FinalNr"];
                    lookStockFeatureTypeID1.EditValue = row["StockFeatureTypeID"];
                    lookMainProduct.EditValue = row["MainStockCode"];
                    lookCapacityType.EditValue = row["CapacityType"];
                    lookPaymentDate.EditValue = row["PaymentDate"];
                    lookPackageType.EditValue = row["PackageType"];
                    lookOrderType.EditValue = row["OrderType"];
                    lookDeliveryType.EditValue = row["DeliveryType"];

                    if (toggleSwitch1.IsOn == true)
                        dateEdit.EditValue = DateTime.Now;
                    else
                        dateEdit.EditValue = row["Date"];
                }
                else
                {
                    spinRingBobinNr.EditValue = spinBukumNr.EditValue = spinFinalNr.EditValue = null;
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

            //var mainproduct = Database.GetRow($"SELECT MainStockCode FROM [dbArge].[dbo].[tblProductTreeFiche] skr WHERE [ProductTreeFicheID] ='{lookProductTreeFiche.EditValue}'", LoginForm.DataConnection);
            //if (mainproduct == null)
            //    return;
            //else
            //    lookMainProduct.EditValue = mainproduct.ItemArray[0].ToString();
        }

        private void toggleSwitch1_EditValueChanged(object sender, EventArgs e)
        {
            lookMainProduct.EditValue = null;
            lookStockFeatureTypeID1.EditValue = null;
            spinEditOrderAmount.EditValue = 0;
            lookCapacityType.EditValue = null;
            spinRingBobinNr.EditValue = 0;
            spinBukumNr.EditValue = 0;
            spinFinalNr.EditValue = 0;
            lookOrderType.EditValue = null;
            lookDeliveryType.EditValue = null;
            lookPaymentDate.EditValue = null;
            lookPackageType.EditValue = null;
            lookProductTreeFiche.EditValue = 0;

            if (toggleSwitch1.IsOn == true)
            {
                spinEditOrderAmount.Enabled = false;
                spinRingBobinNr.Enabled = false;
                spinBukumNr.Enabled = false;
                spinFinalNr.Enabled = false;
                //lookStockFeatureTypeID1.Enabled = false;
                //lookMainProduct.Enabled = false;
                lookCapacityType.Enabled = false;
                lookPaymentDate.Enabled = false;
                lookPackageType.Enabled = false;
                lookOrderType.Enabled = false;
                lookDeliveryType.Enabled = false;
                dateEdit.ReadOnly = true;
                dateEdit.DateTime = DateTime.Now;
            }
            else
            {
                spinEditOrderAmount.Enabled = true;
                spinRingBobinNr.Enabled = true;
                spinBukumNr.Enabled = true;
                spinFinalNr.Enabled = true;
                //lookStockFeatureTypeID1.Enabled = true;
                //lookMainProduct.Enabled = true;
                lookCapacityType.Enabled = true;
                lookPaymentDate.Enabled = true;
                lookPackageType.Enabled = true;
                lookOrderType.Enabled = true;
                lookDeliveryType.Enabled = true;
                dateEdit.ReadOnly = false;
            }
        }

        private void dashboardViewer_DashboardLoaded(object sender, DevExpress.DashboardWin.DashboardLoadedEventArgs e)
        {
        }

        private void dashboardViewer_DataInspectorFormLoad(object sender, DevExpress.DashboardWin.DataInspectorFormLoadEventArgs e)
        {
        }

        private void dashboardViewer_DataLoading(object sender, DataLoadingEventArgs e)
        {
        }

        private void dashboardViewer_DashboardItemControlCreated(object sender, DevExpress.DashboardWin.DashboardItemControlEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayi--; //timer her saniyede sayıyı 1 azaltacak

            if (sayi == 0)
            {
                timer1.Enabled = false;
                try
                {
                    var cmd = LoginForm.DataConnection.CreateCommand();

                    cmd.CommandText = $"Delete from [dbArge].[dbo].[TmpProductUnitCost] where [ProductTreeFicheID]='{lookProductTreeFiche.EditValue}' and [CalculateType]=0 ";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    var cmd1 = LoginForm.DataConnection.CreateCommand();

                    cmd1.CommandText = $"Delete from [dbArge].[dbo].[TmpProcessUnitCost] where [ProductTreeFicheID]='{lookProductTreeFiche.EditValue}' and [CalculateType]=0 ";
                    cmd1.CommandType = CommandType.Text;
                    cmd1.ExecuteNonQuery();
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.IsMdiChild)
                return;

            UnitCostDashboardForm form3 = new UnitCostDashboardForm();
            form3.Text = StartForm.manager.View.ActiveDocument.Form.Text;
            StartForm.manager.View.ActiveDocument.Form.Close();
            form3.WindowState = FormWindowState.Maximized;
            form3.Show();
            form3.barButtonItem2.Enabled = false;
        }
    }
}