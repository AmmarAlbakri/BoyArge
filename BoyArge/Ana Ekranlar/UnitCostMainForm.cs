using BoyArge.Properties;
using Business;
using Core;
using DevExpress.DashboardCommon;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
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
    public partial class UnitCostMainForm : RibbonForm
    {
        #region Definitions

        private string _skin;
        private string _palette;

        #endregion Definitions

        #region Events

        public UnitCostMainForm()
        {
            InitializeComponent();
        }

        private void UnitCostMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dPermissionList =
                    ScreenPermission.GetUserPermissions(LoginForm.UserId, LoginForm.DataConnection))
                {
                    if (dPermissionList == null) return;

                    foreach (BarItem btn in ribbonControl1.Items)
                        if (btn is BarButtonItem && (btn.Name.Contains("btn") || btn.Name.Contains("Btn"))
                        ) //user defined buttons
                        {
                            foreach (DataRow row in dPermissionList.Rows)
                                if (row["ControlName"].ToString() == btn.Name)
                                    btn.Enabled = Utility.ToBoolean(row["Access"]);
                        }
                        else
                        {
                        }
                }

                ConfigurationManager.RefreshSection("appSettings");
                _skin = ConfigurationManager.AppSettings["Skin"];
                _palette = ConfigurationManager.AppSettings["Palette"];
                UserLookAndFeel.Default.SetSkinStyle(_skin, _palette);

                barHeaderItemDataSource.Caption =
                    $"Server: {Settings.Decrypt(LoginForm.Settings.DataSource, Settings.Key)}";
                barHeaderItemInitialCatalog.Caption =
                    $"Veritabanı:  {Settings.Decrypt(LoginForm.Settings.InitialCatalog, Settings.Key)}";
                barName.Caption =
                    $"Kullanıcı: {User.Select(LoginForm.UserId, (int)User.Status.Active, LoginForm.DataConnection).Rows[0]["FullName"]}";

                timer.Start();
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

        private void UnitCostMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigurationManager.AppSettings.Set("DefaultAppSkin", UserLookAndFeel.Default.ActiveSkinName);
            ConfigurationManager.AppSettings.Set("DefaultPalette", UserLookAndFeel.Default.ActiveSvgPaletteName);

            Properties.Settings.Default.Save();
        }

        private void SkinPaletteRibbonGalleryBarItem1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            _palette = e.Item.Value.ToString();
            SaveSkin();
        }

        private void SkinRibbonGalleryBarItem1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            _skin = e.Item.Value.ToString();
            SaveSkin();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            barStaticItem1.Caption = DateTime.Now.ToLongDateString();
            barStaticItem2.Caption = DateTime.Now.ToShortTimeString();
        }

        #endregion Events

        #region Functions

        private void SaveSkin()
        {
            //UserLookAndFeel.Default.SkinName = "Frost Blue";
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Skin"].Value = _skin;
            config.AppSettings.Settings["Palette"].Value = _palette;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void OpenForm(RibbonForm form, string ControlName, string Definition)
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

        private bool IsFormActived(Form form)
        {
            var isOpenend = false;
            if (MdiChildren.Length > 0)
                foreach (var item in MdiChildren)
                    if (form.Name == item.Name)
                    {
                        xtraTabbedMdiManager1.Pages[item].MdiChild.Activate();
                        isOpenend = true;
                    }

            return isOpenend;
        }

        public void ViewChildForm(Form form)
        {
            try
            {
                if (!IsFormActived(form))
                {
                    form.MdiParent = this;
                    form.Show();
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
        }

        private void ViewDashboard(Dashboard dashboard)
        {
            var fDashboardViewer = new DashboardViewerForm
            {
                MaximizeBox = true,
                Dashboard = dashboard
            };

            ViewChildForm(fDashboardViewer);

            if (fDashboardViewer.DialogResult == DialogResult.OK) ViewChildForm(fDashboardViewer);
        }

        #endregion Functions

        #region List

        private void BtnFirm_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FirmForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnZone_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ZoneForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnExpenseType_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ExpenseTypeForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new UnitForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnExchangeType_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ExchangeTypeForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnMachineGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new MachineGroupForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ProcessForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnProduction_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ProductionTypeForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnProcessType_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ProcessTypeForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnMachine_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new MachineForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnCurrentAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new CurrentAccountForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnOrderPivot_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new OrderReportForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnExpense_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ExpenseForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnMachineProcessRelation_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new MachineProcessRelationForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new StockForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnStockProcessRelation_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new StockProcessRelationForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnExpenseLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ExpenseLineForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnUnitPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new UnitPriceForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new DepartmentForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnTitle_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new TitleForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnDepartmentRelation_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new DepartmentRelationForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnDepartmentExpenseRelation_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new DepartmentExpenseRelationForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtndashboardOrderGraph_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewDashboard(new DashboardOrderGraph());
        }

        private void BtnCPMAnalyze_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ViewDashboard(new DashboardCPMAnalyze());
        }

        private void BtnChemicalRecipe_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ChemicalRecipeForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnStockGroupContent_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new StockGroupContentForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnStockGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new StockGroupForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnStockGroupRelation_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new StockGroupRelationForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnConicType_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ConicTypeForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnReceipt_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new ReceiptForm(), e.Item.Name, e.Item.Caption);
        }

        private void BtnCalculate_ItemClick(object sender, ItemClickEventArgs e)
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

        private void BtnStockFeatureType_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new StockFeatureTypeForm(), e.Item.Name, e.Item.Caption);
        }

        #endregion List
    }
}