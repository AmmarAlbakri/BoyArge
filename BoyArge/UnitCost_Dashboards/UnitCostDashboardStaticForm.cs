using Business;
using Core;
using DevExpress.DashboardCommon;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class UnitCostDashboardStaticForm : RibbonForm
    {
        #region Definitions

        private bool _panelState = false;
        public UnitCostParameter UnitCostParameter;
        public UnitCostParameter.UnitCostType UnitCostType;

        #endregion Definitions

        #region Events

        public UnitCostDashboardStaticForm()
        {
            InitializeComponent();
        }

        private void UnitCostDashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Sipariş Maliyetleri")
                {
                    lcGroupStatik.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    toggleSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

                LoadSource();

                UnitCostParameter = new UnitCostParameter();

                if (StartForm.Parameter != null)
                {
                    UnitCostParameter = StartForm.Parameter;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
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
                    UnitCostReportType = UnitCostParameter.ReportType.Static,
                    Module = Document.Module.FollowMe
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
        }

        private void DashboardViewer_CustomParameters(object sender, CustomParametersEventArgs e)
        {
            e.Parameters[0].Value = lookProductTreeFiche.EditValue;

            var date = Database.GetRow($"SELECT TOP(1) Convert(date,Date) FROM [dbArge].[dbo].[tblProductTreeFiche] skr WHERE [ProductTreeFicheID] ='{lookProductTreeFiche.EditValue}'", LoginForm.DataConnection);
            if (date != null)
                e.Parameters[1].Value = date.ItemArray[0];
        }

        private void ToggleOrder_EditValueChanged(object sender, EventArgs e)
        {
            int state = -1;

            if (Utility.ToBoolean(toggleOrder.EditValue))
                state = 1;
            else state = 0;

            using (var dProductTreeFiche = ProductTreeFiche.Select(0, "", 0, (byte)ProductTreeFiche.Status.Active, LoginForm.DataConnection, state))
            {
                Format.LookUpEdit(lookProductTreeFiche, new[] { "ProductTreeFicheID", "Date", "StockName", "StockFeatureType", "ColorType", "RingNr", "BukumNr", "FinalNr", "PaymentDateCode", "DeliveryTypeCode", "Code2", "Maliyet" }, (Utility.ToBoolean(toggleOrder.EditValue) ? "Code2" : "StockFeatureType"), "ProductTreeFicheID", dProductTreeFiche);
            }
        }

        #endregion Events

        #region Functions

        private void LoadSource()
        {
            try
            {
                if (!Database.CheckConnection(LoginForm.DataConnection)) return;

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
            try
            {
                if (this.Text == "Kalite Maliyetleri" && lookProductTreeFiche.EditValue == null)
                {
                    XtraMessageBox.Show("Fiş Seçiniz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!toggleSwitch.Checked)
                    toggleSwitch.Checked = true;

                switch (this.Text)
                {
                    case "Kalite Maliyetleri":
                        LoadDashboard("StaticProductUnitCostDashboard");
                        break;

                    case "Sipariş Maliyetleri":
                        LoadDashboard("StaticUnitCostDashboard");
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
                lcGroupStatik.Visibility = LayoutVisibility.Never;
            }
            else
            {
                lcGroupStatik.Visibility = LayoutVisibility.Always;
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

        private void dashboardViewer_DashboardItemDoubleClick(object sender, DevExpress.DashboardWin.DashboardItemMouseActionEventArgs e)
        {
            if (this.Text == "Sipariş Maliyetleri" && e.DashboardItemName == "gridDashboardItem1" && e.GetAxisPoint() != null)
            {
                if (XtraMessageBox.Show("Maliyet Ayrıntıları Açılsın mı?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) return;
                object ID = "";
                DashboardUnderlyingDataSet data = e.GetUnderlyingData();
                if (data != null)
                {
                    for (int i = 0; i < data.RowCount; i++)
                    {
                        foreach (string item in data.GetColumnNames())
                            if (item == "tblProductTreeFiche_ProductTreeFicheID")
                                ID = data.GetValue(i, item);
                        if (ID == null) return;
                        UnitCostDashboardStaticForm form_static = new UnitCostDashboardStaticForm();
                        form_static.Show();
                        form_static.WindowState = FormWindowState.Maximized;
                        form_static.ribbonControl2.Minimized = true;
                        form_static.lcGroupStatik.Visibility = LayoutVisibility.Never;
                        form_static.lookProductTreeFiche.EditValue = ID;
                        form_static.LoadDashboard("StaticProductUnitCostDashboard");
                        //break;
                    }
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.IsMdiChild)
                return;

            UnitCostDashboardStaticForm form3 = new UnitCostDashboardStaticForm();
            object deneme = this.lookProductTreeFiche.EditValue;

            form3.Text = StartForm.manager.View.ActiveDocument.Form.Text;
            StartForm.manager.View.ActiveDocument.Form.Close();
            form3.WindowState = FormWindowState.Maximized;
            form3.Show();
            form3.barButtonItem2.Enabled = false;

            if (form3.Text == "Kalite Maliyetleri" && deneme != null)
            {
                form3.lookProductTreeFiche.EditValue = deneme;
                form3.RefreshList();
            }
            else
            {
                form3.RefreshList();
            }
        }
    }
}