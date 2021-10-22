using Business;
using Core;
using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class CPMDashboardForm : RibbonForm
    {
        #region Definitions

        private static string Caption = "";

        public CPMDashboardForm()
        {
            InitializeComponent();
        }

        private void CPMDashboardForm_Load(object sender, EventArgs e)
        {
            //DataTable table = ScreenPermission.GetUserPermissions(LoginForm.UserId, LoginForm.DataConnection);
            //string dashboardName = this.Text;

            //foreach (DataRow row in table.Rows)
            //{
            //    if (dashboardName.Equals(row["Definition"]))
            //    {
            //        btnDashboardDesigner.Visibility = Utility.ToBoolean(row["Edit"]) ? BarItemVisibility.Always : BarItemVisibility.Never;
            //    }
            //}

            string a = ((CPMDashboardParameter.ReportType)Utility.ToInt32((byte)StartForm.CPMParameter.ReportType_)).ToString();
            if (a == "Orders")
            {
                this.tum_siparisler.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            if (a == "Samples")
            {
                this.tum_numuneler.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            if (a == "Termin")
            {
                this.barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Caption = StartForm.manager.View.ActiveDocument.Form.Text;
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                if (!Database.CheckConnection(LoginForm.DataConnection)) return;
                switch (Caption)
                {
                    case "Onay Sistemi":
                        LoadDashboard("ConfirmSystemDashboard");
                        this.Text = "Onay Sistemi";
                        break;

                    case "MRP":
                        LoadDashboard("MRPDashboard");
                        this.Text = "MRP";
                        break;

                    case "Siparişler":
                        LoadDashboard("OrdersDashboard");
                        this.Text = "Siparişler";
                        break;

                    case "Sipariş Detay":
                        LoadDashboard("PreviewDashboard");
                        this.Text = "Sipariş Detay";
                        break;

                    case "Üretim Reçeteleri":
                        LoadDashboard("ReceiptStatusDashboard");
                        this.Text = "Üretim Reçeteleri";
                        break;

                    case "Sevkiyat":
                        LoadDashboard("ShipmentDashboard");
                        this.Text = "Sevkiyat";
                        break;

                    case "Termin":
                        LoadDashboard("TerminDashboard");
                        this.Text = "Termin";
                        break;

                    case "Depo Dashboard":
                        LoadDashboard("StockDashboard");
                        this.Text = "Depo Dashboard";
                        break;

                    case "Depo Özet":
                        LoadDashboard("StockAnalyzeDashboard");
                        this.Text = "Depo Özet";
                        break;

                    case "Numuneler":
                        LoadDashboard("SamplesDashboard");
                        this.Text = "Numuneler";
                        break;

                    case "Refakat İzleyici":
                        LoadDashboard("ProductionOrderDashboard");
                        this.Text = "Refakat İzleyici";
                        break;

                    case "Numune Analizler":
                        LoadDashboard("AllSamplesDashboard");
                        this.Text = "Numune Analizler";
                        break;

                    case "Tüm Siparişler":
                        LoadDashboard("AllOrdersDashboard");
                        this.Text = "Tüm Siparişler";
                        break;

                    case "Termin Analizler":
                        LoadDashboard("TerminAnalyzeDashboard");
                        this.Text = "Termin Analizler";
                        break;
                }
                //switch ((CPMDashboardParameter.ReportType)Utility.ToInt32((byte)StartForm.CPMParameter.ReportType_))
                //{
                //    case CPMDashboardParameter.ReportType.Orders:
                //        LoadDashboard("OrdersDashboard");
                //        this.Text = "Siparişler";
                //        break;
                //    case CPMDashboardParameter.ReportType.ConfirmSystem:
                //        LoadDashboard("ConfirmSystemDashboard");
                //        this.Text = "Onay Sistemi";
                //        break;

                //    case CPMDashboardParameter.ReportType.Preview:
                //        LoadDashboard("PreviewDashboard");
                //        this.Text = "Sipariş Detay";
                //        break;

                //    case CPMDashboardParameter.ReportType.Shipment:
                //        LoadDashboard("ShipmentDashboard");
                //        this.Text = "Sevkiyat";
                //        break;

                //    case CPMDashboardParameter.ReportType.MRP:
                //        LoadDashboard("MRPDashboard");
                //        this.Text = "MRP";
                //        break;

                //    case CPMDashboardParameter.ReportType.ProductionOrder:
                //        LoadDashboard("ProductionOrderDashboard");
                //        this.Text = "Refakat İzleyici";
                //        break;
                //    case CPMDashboardParameter.ReportType.ReceiptStatus:
                //        LoadDashboard("ReceiptStatusDashboard");
                //        this.Text = "Üretim Reçeteleri";
                //        break;

                //    case CPMDashboardParameter.ReportType.Termin:
                //        LoadDashboard("TerminDashboard");
                //        this.Text = "Termin";
                //        break;

                //    case CPMDashboardParameter.ReportType.Stock:
                //        LoadDashboard("StockDashboard");
                //        this.Text = "Depo Dashboard";

                //        break;
                //    case CPMDashboardParameter.ReportType.StockAnalyze:
                //        LoadDashboard("StockAnalyzeDashboard");
                //        this.Text = "Depo Özet";
                //        break;

                //    case CPMDashboardParameter.ReportType.AllOrders:
                //        LoadDashboard("AllOrdersDashboard");
                //        this.Text = "Tüm Siparişler";
                //        break;

                //    case CPMDashboardParameter.ReportType.Samples:
                //        LoadDashboard("SamplesDashboard");
                //        this.Text = "Numuneler";
                //        break;

                //    case CPMDashboardParameter.ReportType.AllSamples:
                //        LoadDashboard("AllSamplesDashboard");
                //        this.Text = "Numune Analizler";
                //        break;
                //}
            }
            catch (InvalidOperationException exi)
            {
                XtraMessageBox.Show(exi.Message);
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

        private void LoadDashboard(string DashboardName)
        {
            try
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                {
                    var dash = new Dashboard();
                    dash.LoadFromXDocument(Business.Document.LoadDashboard(DashboardName, LoginForm.UserStatus, LoginForm.DataConnection));
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

        #endregion Definitions

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.IsMdiChild)
                return;

            CPMDashboardForm form3 = new CPMDashboardForm();
            form3.Text = StartForm.manager.View.ActiveDocument.Form.Text;
            StartForm.manager.View.ActiveDocument.Form.Close();
            form3.WindowState = FormWindowState.Maximized;
            form3.Show();
            form3.barButtonItem2.Enabled = false;

            Caption = form3.Text;

            if (form3.Text == "Tüm Siparişler")
                form3.LoadDashboard("AllOrdersDashboard");
            else if (form3.Text == "Numune Analizler")
                form3.LoadDashboard("AllSamplesDashboard");
            else if (form3.Text == "Termin Analizler")
                form3.LoadDashboard("TerminAnalyzeDashboard");
            else
                form3.RefreshList();

            //form3.ribbonControl2.Minimized = true;
        }

        private void DashboardDesigner()
        {
            if (LoginForm.UserId == 11) return;

            try
            {
                string check;
                if (this.IsMdiChild)
                    check = StartForm.manager.View.ActiveDocument.Form.Text;
                else
                    check = this.Text;

                if (this.Text == "Tüm Siparişler")
                {
                    var dashboardDesignerForm = new DashboardDesignerForm
                    {
                        Caption = check,
                        //ReportType = CPMDashboardParameter.ReportType.AllOrders,
                        DashboardType_ = DashboardDesignerForm.DashboardType.CPM,
                        Module = Business.Document.Module.DrCPM
                    };
                    dashboardDesignerForm.BringToFront();

                    dashboardDesignerForm.WindowState = FormWindowState.Maximized;
                    dashboardDesignerForm.Show();
                }
                else if (this.Text == "Numune Analizler")
                {
                    var dashboardDesignerForm = new DashboardDesignerForm
                    {
                        Caption = check,
                        //ReportType = CPMDashboardParameter.ReportType.AllSamples,
                        DashboardType_ = DashboardDesignerForm.DashboardType.CPM,
                        Module = Business.Document.Module.DrCPM
                    };
                    dashboardDesignerForm.BringToFront();

                    dashboardDesignerForm.WindowState = FormWindowState.Maximized;
                    dashboardDesignerForm.Show();
                }
                else if (this.Text == "Termin Analizler")
                {
                    var dashboardDesignerForm = new DashboardDesignerForm
                    {
                        Caption = check,//ReportType = CPMDashboardParameter.ReportType.TerminAnalyze,
                        DashboardType_ = DashboardDesignerForm.DashboardType.CPM,
                        Module = Business.Document.Module.DrCPM
                    };
                    dashboardDesignerForm.BringToFront();

                    dashboardDesignerForm.WindowState = FormWindowState.Maximized;
                    dashboardDesignerForm.Show();
                }
                else
                {
                    var dashboardDesignerForm = new DashboardDesignerForm
                    {
                        Caption = check, //((CPMDashboardParameter.ReportType)Utility.ToInt32((byte)StartForm.CPMParameter.ReportType_)),
                        DashboardType_ = DashboardDesignerForm.DashboardType.CPM,
                        Module = Business.Document.Module.DrCPM
                    };
                    dashboardDesignerForm.BringToFront();

                    dashboardDesignerForm.WindowState = FormWindowState.Maximized;
                    dashboardDesignerForm.Show();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnDashboardDesigner_ItemClick(object sender, ItemClickEventArgs e)
        {
            DashboardDesigner();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!Database.CheckConnection(LoginForm.DataConnection)) return;
                LoadDashboard("AllOrdersDashboard");
                this.Text = "Tüm Siparişler";
            }
            catch (InvalidOperationException exi)
            {
                XtraMessageBox.Show(exi.Message);
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

        private void tum_numuneler_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!Database.CheckConnection(LoginForm.DataConnection)) return;
                LoadDashboard("AllSamplesDashboard");
                this.Text = "Numune Analizler";
            }
            catch (InvalidOperationException exi)
            {
                XtraMessageBox.Show(exi.Message);
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

        private void ribbonControl2_Click(object sender, EventArgs e)
        {
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!Database.CheckConnection(LoginForm.DataConnection)) return;
                LoadDashboard("TerminAnalyzeDashboard");
                this.Text = "Termin Analizler";
            }
            catch (InvalidOperationException exi)
            {
                XtraMessageBox.Show(exi.Message);
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

        private void dashboardViewer_DashboardItemDoubleClick(object sender, DevExpress.DashboardWin.DashboardItemMouseActionEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            object deneme = "";

            sb.AppendLine("Dimensions: ");
            foreach (string axis in e.Data.GetAxisNames())
            {
                AxisPoint axisPoint = e.GetAxisPoint(axis);
                if (axisPoint == null) continue;
                sb.AppendLine(string.Format("\tAxis: {0}", axis));
                foreach (var dim in e.Data.GetDimensions(axis))
                {
                    DimensionValue dimValue = axisPoint.GetDimensionValue(dim);
                    if (dimValue == null) continue;
                    sb.AppendLine(string.Format("\t\t{0}: {1}", dim.Name, dimValue.DisplayText));
                    if (dim.Name == "KS_Yönetim")
                    {
                        if (XtraMessageBox.Show("Yönetim onayı verilsin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) return;

                        var cmd = LoginForm.DataConnection.CreateCommand();
                        try
                        {
                            cmd.CommandText = "[CPM].[TEKSTIL_UYG].[dbo].[SPARGE_YONETIMONAY]";
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@KALEMSN", SqlDbType.Int);
                            cmd.Parameters["@KALEMSN"].Value = Int32.Parse(dimValue.DisplayText.ToString());
                            cmd.Parameters["@KALEMSN"].Direction = ParameterDirection.Input;

                            cmd.Parameters.Add("@KULLANICI", SqlDbType.VarChar);
                            cmd.Parameters["@KULLANICI"].Value = LoginForm.UserName;
                            cmd.Parameters["@KULLANICI"].Direction = ParameterDirection.Input;

                            cmd.ExecuteNonQuery();
                            XtraMessageBox.Show("Sipariş Onaylandı");
                            dashboardViewer.ReloadData();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message);
                        }
                        break;
                    }
                }
            }
        }
    }
}

//        private void CPMDashboardForm_Load(object sender, EventArgs e)
//        {
//            LoadSource();

//            lookYear.EditValue = "2021,2020";
//            checkedcmbEvrakDurum.EditValue = "Açık";
//            checkedcmbUretimDurum.EditValue = "Açık,Kapalı";

//            if (ReportType == CPMDashboardParameter.ReportType.Stock || ReportType == CPMDashboardParameter.ReportType.StockAnalyze || ReportType == CPMDashboardParameter.ReportType.Shipment || ReportType == CPMDashboardParameter.ReportType.ConfirmSystem)
//                lcGroupHeader.Visibility = LayoutVisibility.Never;
//            try
//            {
//                if (!Database.CheckConnection(LoginForm.DataConnection)) return;

//                Format.LookUpEdit(lookReportType, new[] { "ReportType" }, "ReportType", "TypeListID", CPMDashboardParameter.GetTypeList());

//                CPMDashboardParameter = new CPMDashboardParameter();

//                if (StartForm.CPMParameter != null)
//                {
//                    LoadParameter();

//                    CPMDashboardParameter = StartForm.CPMParameter;
//                }

//                lookReportType.EditValue = Utility.ToInt32((byte)ReportType);
//            }
//            catch (Exception ex)
//            {
//                XtraMessageBox.Show(ex.Message);
//            }
//        }

//        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
//        {
//            //if (ReportType == CPMDashboardParameter.ReportType.Stock || ReportType == CPMDashboardParameter.ReportType.StockAnalyze || ReportType == CPMDashboardParameter.ReportType.Shipment || ReportType == CPMDashboardParameter.ReportType.ConfirmSystem)
//            //{
//            //    lcGroupHeader.Visibility = LayoutVisibility.Never;
//            //    return;
//            //}

//            //_panelState = !_panelState;

//            //if (_panelState)
//            //    lcGroupHeader.Visibility = LayoutVisibility.Always;
//            //else
//            //    lcGroupHeader.Visibility = LayoutVisibility.Never;
//        }

//        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
//        {
//            //splashScreenManager1.ShowWaitForm();

//            ((StartForm)this.MdiParent).ribbonControl1.Minimized = true;

//            WaitForm fWait = new WaitForm(10)
//            {
//                StartPosition = FormStartPosition.CenterScreen
//            };
//            fWait.Show();

//            if (!toggleSwitch.Checked)
//                toggleSwitch.Checked = true;

//            RefreshList();
//            //splashScreenManager1.CloseWaitForm();
//        }
//        private void BtnDashboardDesigner_ItemClick(object sender, ItemClickEventArgs e)
//        {
//            if (LoginForm.UserId == 11) return;

//            try
//            {
//                var dashboardDesignerForm = new DashboardDesignerForm
//                {
//                    ReportType = (CPMDashboardParameter.ReportType)lookReportType.EditValue,
//                    DashboardType_ = DashboardDesignerForm.DashboardType.CPM,
//                    Module = Document.Module.DrCPM
//                };

//                dashboardDesignerForm.BringToFront();

//                dashboardDesignerForm.WindowState = FormWindowState.Maximized;
//                dashboardDesignerForm.Show();
//            }
//            catch (Exception ex)
//            {
//                XtraMessageBox.Show(ex.Message);
//            }
//        }

//        private void DashboardViewer_CustomParameters(object sender, CustomParametersEventArgs e)
//        {
//            //LoadDashboardParameter(dashboardViewer.Dashboard);

//            //if (e.Parameters.Count == dashboardViewer.Dashboard.Parameters.Count)
//            //    for (var index = 0; index < e.Parameters.Count; index++)
//            //        e.Parameters[index] = dashboardViewer.Dashboard.Parameters[index];
//            //else
//            //    XtraMessageBox.Show("Parametre sayısı uyumsuz olduğu için Veriler Hatalı olabilir!", Text,
//            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
//        }
//        private void LoadSource()
//        {
//            try
//            {
//                if (!Database.CheckConnection(LoginForm.DataConnection)) return;

//                Format.LookUpEdit(lookReportType, new[] { "ReportType" }, "ReportType", "TypeListID", CPMDashboardParameter.GetTypeList());

//                using (var dtYear = new DataTable())
//                {
//                    dtYear.Columns.Add("Yıl", typeof(int));

//                    for (var i = DateTime.Now.Year; i > 2014; i--)
//                        dtYear.Rows.Add(i);

//                    lookYear.Properties.DataSource = dtYear;
//                    lookYear.Properties.DisplayMember = "Yıl";
//                    lookYear.Properties.ValueMember = "Yıl";
//                }

//                using (var dState = new DataTable())
//                {
//                    dState.Columns.Add("Durum", typeof(string));
//                    dState.Rows.Add("Açık");
//                    dState.Rows.Add("Kapalı");

//                    checkedcmbEvrakDurum.Properties.DataSource = checkedcmbUretimDurum.Properties.DataSource = dState;
//                    checkedcmbEvrakDurum.Properties.DisplayMember =
//                        checkedcmbUretimDurum.Properties.DisplayMember = "Durum";
//                }
//            }
//            catch (SqlException exc)
//            {
//                MessageBox.Show(exc.Message);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//        private void RefreshList()
//        {
//            try
//            {
//                if (lookYear.EditValue == null) return;

//                //CPMDashboardParameter.Change((CPMDashboardParameter.ReportType) lookReportType.EditValue,lookYear.EditValue, checkedcmbEvrakDurum.Text, checkedcmbUretimDurum.Text);

//                StartForm.CPMParameter = CPMDashboardParameter;

//                switch ((CPMDashboardParameter.ReportType)Utility.ToInt32((byte)ReportType))
//                {
//                    case CPMDashboardParameter.ReportType.Orders:
//                        LoadDashboard("OrdersDashboard");
//                        break;

//                    case CPMDashboardParameter.ReportType.ConfirmSystem:
//                        LoadDashboard("ConfirmSystemDashboard");
//                        break;
//                    case CPMDashboardParameter.ReportType.Preview:
//                        LoadDashboard("PreviewDashboard");
//                        break;
//                    case CPMDashboardParameter.ReportType.Shipment:
//                        LoadDashboard("ShipmentDashboard");
//                        break;
//                    case CPMDashboardParameter.ReportType.MRP:
//                        LoadDashboard("MRPDashboard");
//                        break;
//                    case CPMDashboardParameter.ReportType.ProductionOrder:
//                        LoadDashboard("ProductionOrderDashboard");
//                        break;
//                    case CPMDashboardParameter.ReportType.ReceiptStatus:
//                        LoadDashboard("ReceiptStatusDashboard");
//                        break;
//                    case CPMDashboardParameter.ReportType.Termin:
//                        LoadDashboard("TerminDashboard");
//                        break;

//                    case CPMDashboardParameter.ReportType.Stock:
//                        LoadDashboard("StockDashboard");
//                        break;
//                    case CPMDashboardParameter.ReportType.StockAnalyze:
//                        LoadDashboard("StockAnalyzeDashboard");
//                        break;
//                }
//            }
//            catch (InvalidOperationException exi)
//            {
//                XtraMessageBox.Show(exi.Message);
//            }
//            catch (SqlException exc)
//            {
//                XtraMessageBox.Show(exc.Message);
//            }
//            catch (Exception ex)
//            {
//                XtraMessageBox.Show(ex.Message);
//            }
//        }
//        private void LoadDashboard(string DashboardName)
//        {
//            try
//            {
//                if (Database.CheckConnection(LoginForm.DataConnection))
//                {
//                    var dash = new Dashboard();
//                    dash.LoadFromXDocument(Document.LoadDashboard(DashboardName, LoginForm.DataConnection));
//                    dashboardViewer.Dashboard = dash;
//                }

//                foreach (var parameter in dashboardViewer.Dashboard.Parameters)
//                    parameter.Visible = true;
//            }
//            catch (SqlException exc)
//            {
//                XtraMessageBox.Show(exc.Message);
//            }
//            catch (Exception ex)
//            {
//                XtraMessageBox.Show(ex.Message);
//            }
//        }
//#endregion
//        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
//        {
//            CPMDashboardForm form3 = new CPMDashboardForm();
//            form3.Show();
//        }
//        private void LoadDashboardParameter(Dashboard dash)
//        {
//            if (lookYear.EditValue.ToString().Split(',').Length > 0)
//            {
//                var str_array = new string[lookYear.EditValue.ToString().Split(',').Length];

//                lookYear.EditValue.ToString().Split(',').Select(p => p.Trim()).ToArray().CopyTo(str_array, 0);

//                var staticListLookUpSettings1 = new StaticListLookUpSettings
//                {
//                    Values = str_array
//                };
//                dash.Parameters["Year"].LookUpSettings = staticListLookUpSettings1;
//                dash.Parameters["Year"].SelectAllValues = true;
//            }
//            else
//            {
//                dash.Parameters["Year"].Value = StartForm.CPMParameter.Year;
//            }

//            if (checkedcmbEvrakDurum.EditValue.ToString().Split(',').Length > 0)
//            {
//                var str_array = new string[checkedcmbEvrakDurum.EditValue.ToString().Split(',').Length];

//                checkedcmbEvrakDurum.EditValue.ToString().Split(',').Select(p => p.Trim()).ToArray()
//                    .CopyTo(str_array, 0);
//                var staticListLookUpSettings1 = new StaticListLookUpSettings
//                {
//                    Values = str_array
//                };
//                dash.Parameters["EvrakDurum"].LookUpSettings = staticListLookUpSettings1;
//                dash.Parameters["EvrakDurum"].SelectAllValues = true;
//            }
//            else
//            {
//                dash.Parameters["EvrakDurum"].Value = StartForm.CPMParameter.EvrakDurum;
//            }

//            if (checkedcmbUretimDurum.EditValue.ToString().Split(',').Length > 0)
//            {
//                var str_array = new string[checkedcmbUretimDurum.EditValue.ToString().Split(',').Length];

//                checkedcmbUretimDurum.EditValue.ToString().Split(',').Select(p => p.Trim()).ToArray()
//                    .CopyTo(str_array, 0);

//                var staticListLookUpSettings1 = new StaticListLookUpSettings
//                {
//                    Values = str_array
//                };
//                dash.Parameters["UretimDurum"].LookUpSettings = staticListLookUpSettings1;
//                dash.Parameters["UretimDurum"].SelectAllValues = true;
//            }
//            else
//            {
//                dash.Parameters["UretimDurum"].Value = StartForm.CPMParameter.UretimDurum;
//            }
//        }
//        private void LoadParameter()
//        {
//            try
//            {
//                lookYear.EditValue = StartForm.CPMParameter.Year;
//                checkedcmbEvrakDurum.EditValue = StartForm.CPMParameter.EvrakDurum;
//                checkedcmbUretimDurum.EditValue = StartForm.CPMParameter.UretimDurum;
//            }
//            catch (Exception ex)
//            {
//                XtraMessageBox.Show(ex.Message);
//            }
//        }