using Core;
using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class FollowMeDashboardForm : RibbonForm
    {
        #region Definitions

        private object ID = 0;

        public FollowMeDashboardForm()
        {
            InitializeComponent();
        }

        private void CPMDashboardForm_Load(object sender, EventArgs e)
        {
        }

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                if (!Database.CheckConnection(LoginForm.DataConnection)) return;

                switch (this.Text)
                {
                    case "Hazırlama":
                        LoadDashboard("HazırlamaDashboard");
                        this.Text = "Hazırlama";
                        break;

                    case "Ring":
                        LoadDashboard("RingDashboard");
                        this.Text = "Ring";
                        break;

                    case "Final":
                        LoadDashboard("FinalDashboard");
                        this.Text = "Final";
                        break;

                    case "Boyama":
                        LoadDashboard("BoyahaneKazanDashboard");
                        this.Text = "Boyama";
                        break;

                    case "Boyama Operasyonları":
                        LoadDashboard("BoyahaneDashboard");
                        this.Text = "Boyama Operasyonları";
                        break;

                    case "Vigüre":
                        LoadDashboard("VigüreDashboard");
                        this.Text = "Vigüre";
                        break;

                    case "Fantezi":
                        LoadDashboard("FanteziDashboard");
                        this.Text = "Fantezi";
                        break;

                    case "Fantezi Final":
                        LoadDashboard("FanteziFinalDashboard");
                        this.Text = "Fantezi Final";
                        break;

                    case "Lase":
                        LoadDashboard("LaseDashboard");
                        this.Text = "Lase";
                        break;

                    case "Şardon":
                        LoadDashboard("SardonDashboard");
                        this.Text = "Şardon";
                        break;

                    case "Aktarma Volufil":
                        LoadDashboard("AktarmaVolufilDashboard");
                        this.Text = "Aktarma Volufil";
                        break;

                    case "Çile Aktarma":
                        LoadDashboard("CileAktarmaDashboard");
                        this.Text = "Çile Aktarma";
                        break;

                    case "Bobin Aktarma":
                        LoadDashboard("BobinAktarmaDashboard");
                        this.Text = "Bobin Aktarma";
                        break;

                    case "Sipariş Durum":
                        LoadDashboard("SiparisDurumDashboard");
                        this.Text = "Sipariş Durum";
                        break;

                    case "Üretim Operasyonlar":
                        LoadDashboard("OperasyonlarDashboard");
                        this.Text = "Üretim Operasyonlar";
                        break;

                    case "Üretim Hesabı":
                        LoadDashboard("UretimHesabıDashboard");
                        this.Text = "Üretim Hesabı";
                        break;
                }
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

            FollowMeDashboardForm form3 = new FollowMeDashboardForm();
            form3.Text = StartForm.manager.View.ActiveDocument.Form.Text;
            StartForm.manager.View.ActiveDocument.Form.Close();
            form3.WindowState = FormWindowState.Maximized;
            form3.Show();
            form3.barButtonItem2.Enabled = false;

            if (form3.Text == "Tüm Siparişler")
                form3.LoadDashboard("AllOrdersDashboard");
            else if (form3.Text == "Numune Analizler")
                form3.LoadDashboard("AllSamplesDashboard");
            else
                form3.RefreshList();

            //form3.ribbonControl2.Minimized = true;
        }

        private void DashboardDesigner()
        {
            if (LoginForm.UserId == 11) return;

            string check;
            if (this.IsMdiChild)
                check = StartForm.manager.View.ActiveDocument.Form.Text;
            else
                check = this.Text;

            try
            {
                var dashboardDesignerForm = new DashboardDesignerForm
                {
                    Caption = check,
                    DashboardType_ = DashboardDesignerForm.DashboardType.FollowMe,
                    Module = Business.Document.Module.FollowMe
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

        private void dashboardViewer_MasterFilterSet(object sender, MasterFilterSetEventArgs e)
        {
        }

        private void dashboardViewer_DashboardItemSelectionChanged(object sender, DevExpress.DashboardWin.DashboardItemSelectionChangedEventArgs e)
        {
        }

        private void dashboardViewer_SetInitialDashboardState(object sender, DevExpress.DashboardWin.SetInitialDashboardStateEventArgs e)
        {
        }

        private void dashboardViewer_DashboardItemClick(object sender, DevExpress.DashboardWin.DashboardItemMouseActionEventArgs e)
        {
            //if (this.Text == "Sipariş Durum" && e.GetAxisPoint() != null && e.DashboardItemName == "gridDashboardItem3")
            //{
            //    DevExpress.DashboardCommon.DashboardUnderlyingDataSet data = e.GetUnderlyingData();
            //    if (data != null)
            //        for (int i = 0; i < data.RowCount; i++)
            //        {
            //            foreach (string item in data.GetColumnNames())
            //                if (item == "KALEMSN")
            //                    ID = data.GetValue(i, item);
            //            if (ID == null) return;
            //            barKALEMSN.Caption = ID.ToString();
            //            //MessageBox.Show(barKALEMSN.Caption.ToString());

            //            break;
            //        }

            //    //if (dashboardViewer.CanClearMasterFilter("gridDashboardItem1"))
            //    //    dashboardViewer.ClearMasterFilter("gridDashboardItem1");

            //    //dashboardViewer.ReloadData();

            //}

            if (this.Text == "Sipariş Durum" && e.GetAxisPoint() != null && e.DashboardItemName == "gridDashboardItem3")
            {
                if (dashboardViewer.CanClearMasterFilter("gridDashboardItem1"))
                    dashboardViewer.ClearMasterFilter("gridDashboardItem1");
            }
        }

        private void dashboardViewer_DashboardItemDoubleClick(object sender, DevExpress.DashboardWin.DashboardItemMouseActionEventArgs e)
        {
            //if (this.Text == "Sipariş Durum" && e.GetAxisPoint() != null && e.DashboardItemName == "gridDashboardItem3")

            //{
            //    // XtraMessageBox.Show("çalıştı");

            //    dashboardViewer.ClearMasterFilter("gridDashboardItem1");

            //    //dashboardViewer.ClearMasterFilterAsync("gridDashboardItem1");
            //    //dashboardViewer.CanClearMasterFilter("gridDashboardItem1");

            //}
            //dashboardViewer.ReloadData("gridDashboardItem1");
            //dashboardViewer.ReloadData("gridDashboardItem2");
            //dashboardViewer.ReloadData("cardDashboardItem1");

            //dashboardViewer.ReloadData();

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
                    if (dim.Name == "Refakat No")
                    {
                        deneme = dimValue.DisplayText;
                        if (XtraMessageBox.Show("Refakat operasyon işlemleri açılsın mı?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) return;
                        Form1 frm3 = new Form1();
                        frm3.isEmriNumarasi.Text = deneme.ToString().Trim();
                        frm3.ShowDialog();
                    }

                    continue;
                }
            }
            //MessageBox.Show(deneme.ToString());
        }

        private void dashboardViewer_CustomParameters(object sender, CustomParametersEventArgs e)
        {
            // e.Parameters[0].Value =Utility.ToInt32(barKALEMSN.Caption.ToString());
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