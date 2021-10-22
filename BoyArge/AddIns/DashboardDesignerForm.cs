using BoyArge.Properties;
using Business;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class DashboardDesignerForm : RibbonForm
    {
        public enum DashboardType
        {
            CPM,
            UnitCost,
            FollowMe
        }

        public DashboardDesignerForm()
        {
            InitializeComponent();
        }

        public string DashboardName { get; set; }
        public CPMDashboardParameter.ReportType ReportType { get; set; }

        public Document.Module Module { get; set; }

        public DashboardType DashboardType_ { get; set; }

        public UnitCostParameter.ReportType UnitCostReportType { get; set; }

        public UnitCostParameter.UnitCostType UnitCostType { get; set; }

        public string Caption { get; set; }

        private void DashboardDesignerForm_Load(object sender, EventArgs e)
        {
            if (DashboardType_ == DashboardType.CPM)
            {
                if (Caption == null)
                {
                    btnUpdateDatasource.Visibility = BarItemVisibility.Never;
                    return;
                }

                // Caption = StartForm.manager.View.ActiveDocument.Form.Text;
                switch (Caption)
                {
                    case "Onay Sistemi":
                        Text = "Onay Sistemi";
                        Caption = "ConfirmSystem";
                        break;

                    case "MRP":
                        Text = "MRP";
                        Caption = "MRP";
                        break;

                    case "Siparişler":
                        Text = "Siparişler";
                        Caption = "Orders";
                        break;

                    case "Sipariş Detay":
                        Text = "Sipariş Detay";
                        Caption = "Preview";
                        break;

                    case "Üretim Reçeteleri":
                        Text = "Üretim Reçeteleri";
                        Caption = "ReceiptStatus";
                        break;

                    case "Sevkiyat":
                        Text = "Sevkiyat";
                        Caption = "Shipment";
                        break;

                    case "Termin":
                        Text = "Termin";
                        Caption = "Termin";
                        break;

                    case "Depo Dashboard":
                        Text = "Depo Dashboard";
                        Caption = "Stock";
                        break;

                    case "Depo Özet":
                        Text = "Depo Özet";
                        Caption = "StockAnalyze";
                        break;

                    case "Numuneler":
                        Text = "Numuneler";
                        Caption = "Samples";
                        break;

                    case "Refakat İzleyici":
                        Text = "Refakat İzleyici";
                        Caption = "ProductionOrder";
                        break;

                    case "Termin Analizler":
                        Text = "Termin Analizler";
                        Caption = "TerminAnalyze";
                        break;

                    case "Numune Analizler":
                        Text = "Numune Analizler";
                        Caption = "AllSamples";
                        break;

                    case "Tüm Siparişler":
                        Text = "Tüm Siparişler";
                        Caption = "AllOrders";
                        break;
                }
                DashboardName = Caption + "Dashboard";
            }
            else if (DashboardType_ == DashboardType.UnitCost)
            {
                if (Caption == null)
                {
                    btnUpdateDatasource.Visibility = BarItemVisibility.Never;
                    return;
                }

                switch (Caption)
                {
                    case "Dinamik Kalite Maliyetleri":
                        Text = "Dinamik Kalite Maliyetleri";
                        Caption = "DynamicUnitCost";
                        break;

                    case "Sipariş Maliyetleri":
                        Text = "Sipariş Maliyetleri";
                        Caption = "StaticUnitCost";
                        break;

                    case "Kalite Maliyetleri":
                        Text = "Kalite Maliyetleri";
                        Caption = "StaticProductUnitCost";
                        break;
                }

                DashboardName = Caption + "Dashboard";
            }
            else if (DashboardType_ == DashboardType.FollowMe)
            {
                switch (Caption)
                {
                    case "Hazırlama":
                        Caption = "HazırlamaDashboard";
                        break;

                    case "Ring":
                        Caption = "RingDashboard";
                        break;

                    case "Final":
                        Caption = "FinalDashboard";
                        break;

                    case "Boyama":
                        Caption = "BoyahaneKazanDashboard";
                        break;

                    case "Boyama Operasyonları":
                        Caption = "BoyahaneDashboard";
                        break;

                    case "Vigüre":
                        Caption = "VigüreDashboard";
                        break;

                    case "Fantezi":
                        Caption = "FanteziDashboard";
                        break;

                    case "Fantezi Final":
                        Caption = "FanteziFinalDashboard";
                        break;

                    case "Lase":
                        Caption = "LaseDashboard";
                        break;

                    case "Şardon":
                        Caption = "SardonDashboard";
                        break;

                    case "Aktarma Volufil":
                        Caption = "AktarmaVolufilDashboard";

                        break;

                    case "Çile Aktarma":
                        Caption = "CileAktarmaDashboard";
                        break;

                    case "Bobin Aktarma":
                        Caption = "BobinAktarmaDashboard";
                        break;

                    case "Sipariş Durum":
                        Caption = "SiparisDurumDashboard";
                        Text = "Sipariş Durum";
                        break;

                    case "Üretim Operasyonlar":
                        Caption = "OperasyonlarDashboard";
                        Text = "Üretim Operasyonlar";
                        break;

                    case "Üretim Hesabı":
                        Caption = "UretimHesabıDashboard";
                        Text = "Üretim Hesabı";
                        break;
                }
                //DashboardName = Caption + "Dashboard";
                DashboardName = Caption;
            }

            try
            {
                Text += " - Dashboard Tasarım Ekranı";

                dashboardDesigner1.Dashboard.LoadFromXDocument(Document.LoadDashboard(DashboardName, LoginForm.UserStatus, LoginForm.DataConnection));
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text);
            }
        }

        private void BtnUpdateDataSource_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    var result1 = "";
                    string calculatePassword = "";
                    if (LoginForm.UserId != 1)
                    {
                        result1 = Interaction.InputBox("", "Lütfen şifre giriniz", "", 250, 250);
                        //Begin getting password from db
                        try
                        {
                            SqlCommand cmd = new SqlCommand("select Property from [dbArge].[dbo].[tblParameters] where Definition = 'DashboardDesignForm' and Feature='Code'", LoginForm.DataConnection);
                            cmd.CommandType = CommandType.Text;

                            SqlDataReader passwordReader = cmd.ExecuteReader();
                            passwordReader.Read();

                            calculatePassword = passwordReader["Property"].ToString();
                            passwordReader.Close();
                        }
                        catch (Exception ex) { throw ex; }
                        //End of getting password from db
                    }

                    if (result1.Equals(calculatePassword) || LoginForm.UserId == 1)
                    {
                        var result = Document.AddOrUpdateDashboard(dashboardDesigner1.Dashboard, (byte)Module, DashboardName, dashboardDesigner1.Dashboard.Title.Text, LoginForm.UserStatus, LoginForm.DataConnection);

                        if (result > 0)
                            XtraMessageBox.Show(Resources.UpdateInfo, Text, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show(Resources.UpdateError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        XtraMessageBox.Show("Şifreyi yanlış girdiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (SqlException exc)
                {
                    XtraMessageBox.Show(exc.Message, Text);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, Text);
                }
        }

        private void DashboardDesigner1_DashboardLoaded(object sender, DashboardLoadedEventArgs e)
        {
            foreach (var parameter in dashboardDesigner1.Dashboard.Parameters)
                parameter.Visible = true;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            CardCollection cards = (dashboardDesigner1.Dashboard.Items["cardDashboardItem1"] as CardDashboardItem).Cards;
            foreach (var card in cards)
            {
                CardLayout layout = card.LayoutTemplate.GetLayout().Clone();
                IEnumerable<CardRow> rows = layout.Rows.Where(row => row is CardRow).Cast<CardRow>();
                foreach (var row in rows)
                {
                    IEnumerable<CardRowTextElementBase> textElements = row.Elements.Where(element => element is CardRowTextElementBase).Cast<CardRowTextElementBase>();
                    foreach (var element in textElements)
                        element.FontSize += 2;
                }
                card.LayoutTemplate = new CardCustomLayoutTemplate() { Layout = layout };
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            CardCollection cards = (dashboardDesigner1.Dashboard.Items["cardDashboardItem1"] as CardDashboardItem).Cards;
            foreach (var card in cards)
            {
                CardLayout layout = card.LayoutTemplate.GetLayout().Clone();
                IEnumerable<CardRow> rows = layout.Rows.Where(row => row is CardRow).Cast<CardRow>();
                foreach (var row in rows)
                {
                    IEnumerable<CardRowTextElementBase> textElements = row.Elements.Where(element => element is CardRowTextElementBase).Cast<CardRowTextElementBase>();
                    foreach (var element in textElements)
                        element.FontSize -= 2;
                }
                card.LayoutTemplate = new CardCustomLayoutTemplate() { Layout = layout };
            }
        }
    }
}