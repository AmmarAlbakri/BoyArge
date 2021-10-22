using BoyArge.Properties;
using Business;
using Core;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Screen = Business.Screen;
using Settings = Business.Settings;

namespace BoyArge
{
    public partial class StartForm : RibbonForm
    {
        #region Definitions

        private string _skin;
        private string _palette;
        public static UnitCostParameter Parameter { get; set; }
        public static CPMDashboardParameter CPMParameter { get; set; }

        #endregion Definitions

        #region Events

        #region Form

        public static DocumentManager manager;

        public StartForm()
        {
            InitializeComponent();

            manager = new DocumentManager();
            manager.MdiParent = this;

            CPMParameter = new CPMDashboardParameter();
            Parameter = new UnitCostParameter();

            // manager.View.FloatingDocumentContainer = FloatingDocumentContainer.DocumentsHost;
            //manager.View.CustomDocumentsHostWindow += View_CustomDocumentsHostWindow;
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            //DocumentManager dm = new DocumentManager(components);
            //dm.MdiParent = this;
            //dm.View = new NativeMdiView();

            //using (var dPermissionList = Business.ScreenPermission.GetUserPermissions(LoginForm.UserId, LoginForm.DataConnection))
            //{
            //    if (dPermissionList == null) return;

            //    foreach (DevExpress.XtraBars.BarItem btn in this.ribbonControl1.Items)
            //    {
            //        if (btn is BarButtonItem && (btn.Name.Contains("btn") || btn.Name.Contains("Btn"))) //user defined buttons
            //        {
            //            foreach (DataRow row in dPermissionList.Rows)
            //            {
            //                if (row["ControlName"].ToString() == btn.Name)
            //                    btn.Enabled = Utility.ToBoolean(row["Access"]);
            //            }
            //        }
            //        else continue;
            //    }
            //}

            ConfigurationManager.RefreshSection("appSettings");
            _skin = ConfigurationManager.AppSettings["Skin"];
            _palette = ConfigurationManager.AppSettings["Palette"];
            UserLookAndFeel.Default.SetSkinStyle(_skin, _palette);

            btnProductUnitCost.Tag = UnitCostParameter.UnitCostType.ProductUnitCost;
            btnProductUnitCost.Tag = UnitCostParameter.UnitCostType.Capacity;

            barHeaderItemDataSource.Caption = $"Server: {Settings.Decrypt(LoginForm.Settings.DataSource, Settings.Key)}";
            //barHeaderItemInitialCatalog.Caption =$"Veritabanı: {Settings.Decrypt(LoginForm.Settings.InitialCatalog, Settings.Key)}";
            barName.Caption = $"Kullanıcı: {User.Select(LoginForm.UserId, (int)User.Status.Active, LoginForm.DataConnection).Rows[0]["FullName"]}";

            var (item1, item2, item3) = ExchangeType.GetCurrency(LoginForm.DataConnection);

            barStaticItem3.Caption = $"USD: { Decimal.Round(item1, 2)}";
            barStaticItem4.Caption = $"EUR: {Decimal.Round(item2, 2)}";
            barStaticItem5.Caption = $"GBP: {Decimal.Round(item3, 2)}";
            barStaticItem2.Caption = $"EUR to USD: { Decimal.Round(item2 / item1, 3)}";
            barStaticItem6.Caption = $"GBP to USD: {Decimal.Round(item3 / item1, 3)}";

            timer.Enabled = true;
            timer.Start();

            barStaticItem1.Caption = DateTime.Now.ToLongDateString();

            //barStaticItem2.Caption = DateTime.Now.ToLongTimeString();

            //if (LoginForm.UserId == 11)
            //{
            //    ribbonPageMrSmart.Visible = false;
            //    ribbonPageSettings.Visible = false;
            //}

            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            DataTable table = ScreenPermission.GetUserPermissions(LoginForm.UserId, LoginForm.DataConnection);

            foreach (var item in ribbonControl1.Items)
            {
                if (item is BarButtonItem)
                {
                    BarButtonItem bbi = item as BarButtonItem;
                    foreach (DataRow row in table.Rows)
                    {
                        if (bbi.Name.Equals(row["ControlName"]))
                        {
                            bbi.Visibility = Utility.ToBoolean(row["Access"]) ? BarItemVisibility.Always : BarItemVisibility.Never;
                        }
                    }
                }
            }

            //if (LoginForm.UserId != 1)
            //{
            //    this.btnScreenPermission.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    this.btnScreenForm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    this.btnTableStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    this.btnUser.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    this.btnSettings.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigurationManager.AppSettings.Set("DefaultAppSkin", UserLookAndFeel.Default.ActiveSkinName);
            ConfigurationManager.AppSettings.Set("DefaultPalette", UserLookAndFeel.Default.ActiveSvgPaletteName);

            Properties.Settings.Default.Save();

            FormPlanlama frm = (FormPlanlama)Application.OpenForms["FormPlanlama"];
            if (frm != null)
            {
                FormPlanlama.CancelReceteNo(frm.txtReceteNo.Text, frm.comboBoxReceteTipi.SelectedIndex == 0 ? "Mamul" : "Siparis");
                FormPlanlama.CancelMRPNo(FormPlanlama.GetRowValueWithCheck(frm.rowMRPNo));
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            barStaticItem1.Caption = DateTime.Now.ToLongDateString();
            // barStaticItem2.Caption = DateTime.Now.ToLongTimeString();
        }

        #endregion Form

        #region List

        #region MrSmart

        private void BtnProductCost_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fMain = new UnitCostMainForm();

            try
            {
                Screen.CheckScreen(fMain.Name, e.Item.Name, e.Item.Caption, 1, LoginForm.DataConnection);

                fMain.Show();
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            //finally
            //{
            //fMain.Dispose();
            //}
        }

        private void BtnProductUnitCost_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenDashboard(UnitCostParameter.UnitCostType.ProductUnitCost, e.Item.Caption);
        }

        private void BtnUnitCostDashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenDashboard(UnitCostParameter.UnitCostType.UnitCost, e.Item.Caption);
        }

        #endregion MrSmart

        #region DrCPM

        private void BtnOrders_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.Orders, CPMDashboardParameter.ModuleID);

            // ((StartForm)this.MdiParent).barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void BtnPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.Preview, CPMDashboardParameter.ModuleID);

            //CPMDashboardForm form3 = new CPMDashboardForm();
            //form3.tum_siparisler.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void BtnConfirmSystem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.ConfirmSystem, CPMDashboardParameter.ModuleID);
        }

        private void BtnShipment_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.Shipment, CPMDashboardParameter.ModuleID);
        }

        private void BtnMRP_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.MRP, CPMDashboardParameter.ModuleID);
        }

        private void BtnProductionOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.ProductionOrder, CPMDashboardParameter.ModuleID);
        }

        private void BtnReceiptStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.ReceiptStatus, CPMDashboardParameter.ModuleID);
        }

        private void BtnTermin_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.Termin, CPMDashboardParameter.ModuleID);
        }

        private void BtnDepoDashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.Stock, CPMDashboardParameter.ModuleID);
        }

        private void BtnDepoOzet_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.StockAnalyze, CPMDashboardParameter.ModuleID);
        }

        #endregion DrCPM

        #region Settings

        private void BtnPasswordChange_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new PasswordChangeForm(), e.Item.Name, e.Item.Caption);
            BringToFront();
        }

        private void BtnSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new SettingsForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new UserForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnTableStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new TableStatusForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnScreenForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ScreenForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnScreenPermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ScreenPermissionForm(), e.Item.Name, e.Item.Caption);
        }

        #endregion Settings

        #region AddIns

        private void BtnDashboardDesigner_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fDashboardDesigner = new DashboardDesignerForm();

            try
            {
                fDashboardDesigner.Show();
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

        private void BtnTextEditor_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fTextEditor = new TextEditorForm();
            fTextEditor.ShowDialog();
        }

        private void BtnDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fDocument = new DocumentForm();
            ViewChildForm(fDocument);
        }

        private void BtnDashboardViewer_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fDashboardViewer = new DashboardViewerForm();
            ViewChildForm(fDashboardViewer);
        }

        #endregion AddIns

        #region Theme

        private void SkinRibbonGalleryBarItem1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            _skin = e.Item.Value.ToString();
            SaveSkin();
        }

        private void SkinPaletteRibbonGalleryBarItem1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            _palette = e.Item.Value.ToString();
            SaveSkin();
        }

        #endregion Theme

        #endregion List

        #endregion Events

        #region Functions

        public void ViewChildForm(Form form)
        {
            try
            {
                //if (!IsFormActived(form))
                //{
                form.MdiParent = this;
                form.Show();
                ribbonControl1.Minimized = true;
                //((StartForm)MdiParent).ribbonControl1.Minimized = true;
                // new FormChild() { MdiParent = this, Text = category + " - " + i }.Show();

                //}
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void OpenDashboard(UnitCostParameter.UnitCostType costType, string caption)
        {
            try
            {
                var form = new UnitCostDashboardStaticForm
                {
                    UnitCostType = costType,
                    Text = caption
                };

                ViewChildForm(form);

                if (form.DialogResult == DialogResult.OK)
                    ViewChildForm(form);
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

        private void OpenForm(CPMDashboardForm form, string ControlName, string Definition, CPMDashboardParameter.ReportType reportType, int ModuleID)
        {
            try
            {
                form.MaximizeBox = true;

                form.Tag = ControlName;
                //form.ReportType = reportType;
                CPMParameter.ReportType_ = reportType;
                form.Text = Definition;

                Screen.CheckScreen(form.Name, ControlName, Definition, ModuleID, LoginForm.DataConnection);

                ViewChildForm(form);

                if (form.DialogResult == DialogResult.OK)
                    ViewChildForm(form);
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
                XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void OpenForm(XtraForm form, string ControlName, string Definition)
        {
            try
            {
                form.MaximizeBox = true;
                form.Tag = ControlName;

                Screen.CheckScreen(form.Name, ControlName, Definition, 1, LoginForm.DataConnection);

                ViewChildForm(form);

                if (form.DialogResult == DialogResult.OK)
                    ViewChildForm(form);
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void SaveSkin()
        {
            //UserLookAndFeel.Default.SkinName = "Frost Blue";
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Skin"].Value = _skin;
            config.AppSettings.Settings["Palette"].Value = _palette;
            config.Save(ConfigurationSaveMode.Modified);
        }

        #endregion Functions

        private void btnCalculateForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            string calculatePassword;
            if (LoginForm.UserId == 1 || LoginForm.UserId == 4)
            {
                var fMain = new CalculateForm();
                fMain.Tag = e.Item.Name;
                try
                {
                    Screen.CheckScreen(fMain.Name, e.Item.Name, e.Item.Caption, 1, LoginForm.DataConnection);
                    fMain.Show();
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
            else
            {
                var result = XtraInputBox.Show("Sistem Bilgilendirme", "Maliyet hesaplamak için şifre giriniz", "");
                //Begin getting password from db
                var cmd = LoginForm.DataConnection.CreateCommand();
                try
                {
                    cmd.CommandText = "select Property from tblParameters where Definition = 'CalculateForm'";
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader passwordReader = cmd.ExecuteReader();
                    passwordReader.Read();

                    calculatePassword = passwordReader["Property"].ToString();
                    passwordReader.Close();
                }
                catch (Exception ex) { throw ex; }
                //End of getting password from db
                if (result.Equals(calculatePassword))
                {
                    var fMain = new CalculateForm();
                    fMain.Tag = e.Item.Name;
                    try
                    {
                        Screen.CheckScreen(fMain.Name, e.Item.Name, e.Item.Caption, 1, LoginForm.DataConnection);
                        fMain.Show();
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
                else
                {
                    XtraMessageBox.Show("Lütfen doğru şifre girdiğinize emin olunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            UnitCostDashboardForm form = new UnitCostDashboardForm();
            ViewChildForm(form);

            if (form.DialogResult == DialogResult.OK)
                ViewChildForm(form);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CPMDashboardForm(), e.Item.Name, e.Item.Caption, CPMDashboardParameter.ReportType.Samples, CPMDashboardParameter.ModuleID);
        }

        private void btnOrderFollow_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Hazırlama";
        }

        private void btnRing_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Ring";
        }

        private void barFinal_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Final";
        }

        private void barBoyahane_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Boyama";
        }

        private void barOperasyonlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Boyama Operasyonları";
        }

        private void barVigure_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Vigüre";
        }

        private void barFantezi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Fantezi";
        }

        private void barFanteziFinal_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Fantezi Final";
        }

        private void barLase_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Lase";
        }

        private void barSardon_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Şardon";
        }

        private void barVolufil_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Aktarma Volufil";
        }

        private void barCile_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Çile Aktarma";
        }

        private void barBobin_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Bobin Aktarma";
        }

        private void ribbonControl1_DpiChangedAfterParent(object sender, EventArgs e)
        {
        }

        private void StartForm_MdiChildActivate(object sender, EventArgs e)
        {
            //XtraMessageBox.Show("deneme");
        }

        private void barSiparisDurum_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Sipariş Durum";
        }

        private void barUretimHesap_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Üretim Hesabı";
        }

        private void barUretimOperasyon_ItemClick(object sender, ItemClickEventArgs e)
        {
            FollowMeDashboardForm form = new FollowMeDashboardForm();
            ViewChildForm(form);
            form.Text = "Üretim Operasyonlar";
        }

        private void btnIsEmriKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void btnProductionPlanning_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fMain = new FormPlanlama();
            fMain.Tag = e.Item.Name;
            try
            {
                Screen.CheckScreen(fMain.Name, e.Item.Name, e.Item.Caption, 1, LoginForm.DataConnection);
                fMain.Show();
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

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var fMain = new StokKart();
            fMain.Tag = e.Item.Name;
            try
            {
                Screen.CheckScreen(fMain.Name, e.Item.Name, e.Item.Caption, 1, LoginForm.DataConnection);
                fMain.Show();
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
    }
}

//private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
//{
//}