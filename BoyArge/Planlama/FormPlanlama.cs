using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class FormPlanlama : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static string conString = "data source=192.168.109.2,1433; user id=arge; password=Arge*2020!; initial catalog=TEKSTIL_UYG_100921; Connection Timeout=1;";
        public static SqlConnection con = new SqlConnection(conString);
        private MamulTree mamulTree = new MamulTree(con);
        private TreeListNode _rootNode = new TreeListNode();
        public bool anaUrunKontrol = true;
        private DataTable renkDurumuDT = new DataTable();

        public FormPlanlama()
        {
            InitializeComponent();
            con.Open();
            rowTarih.Properties.Value = DateTime.Today;
            CreateNewMRPNo();
        }

        private void FormPlanlama_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'deneme5.SPARGE_MRPEVRAK_SELECT' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.MRP_EVRAK_TableAdapter.Fill(this.MRP_EVRAK.SPARGE_MRPEVRAK_SELECT);

            // TODO: Bu kod satırı 'mRP_Baglanti.SPARGE_MRP_SIPARISBAGLANTI_SELECT' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.MRP_BAGLANTI_TableAdapter.Fill(this.MRP_BAGLANTI.SPARGE_MRP_SIPARISBAGLANTI_SELECT);

            comboBoxReceteTipi.SelectedIndex = 0;
            createNewReceteID(comboBoxReceteTipi.SelectedIndex == 0 ? "Mamul" : "Siparis");
            LoadSourcesWithTimer(15);
        }

        private void LoadSourcesWithTimer(int seconds)
        {
            Thread th = new Thread(() => TimerFunc(seconds));

            try
            {
                splashScreenManager1.ShowWaitForm();
                th.Start();

                LoadSources();

                th.Abort();
                splashScreenManager1.CloseWaitForm();
            }
            catch (ThreadStateException ext)
            {
                XtraMessageBox.Show(ext.Message);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void TimerFunc(int seconds)
        {
            for (int i = seconds; i != 0; i--)
            {
                splashScreenManager1.SetWaitFormDescription($"Yükleniyor.. {i}");
                Thread.Sleep(1000);
            }
            splashScreenManager1.SetWaitFormDescription("Bu operasyon beklenenden fazla sürüyor");
        }

        public void LoadSources()
        {
            using (var boyamaSekli = LookUpEditFill.GetBoyamahaneIslemiTable())
            {
                LookUpEditFill.LookUpEdit(L_BoyahaneIslem, new[] { "Code", "Name" }, "Name", "Code", boyamaSekli);
            }
            using (var uretimYeri = LookUpEditFill.GetUretimYeriTable())
            {
                LookUpEditFill.LookUpEdit(L_UretimYeri, new[] { "Code", "Name" }, "Name", "Code", uretimYeri);
            }
            using (var boyamaSekli = LookUpEditFill.GetBoyamaSekliTable())
            {
                LookUpEditFill.LookUpEdit(L_BoyamaSekli, new[] { "Code", "Name" }, "Name", "Code", boyamaSekli);
            }
            using (var miktarDurum = LookUpEditFill.GetMiktarDurum())
            {
                LookUpEditFill.LookUpEdit(L_MiktarDurumu, new[] { "Code", "Name" }, "Name", "Code", miktarDurum);
            }
            using (var renkDurum = LookUpEditFill.GetRenkDurum())
            {
                LookUpEditFill.LookUpEdit(L_RenkDurum, new[] { "Code", "ColorType" }, "ColorType", "Code", renkDurum);
            }
            using (var zone = Database.GetList("SELECT ZoneID,Name  From [dbArge].[dbo].[tblZone] order by ZoneID", con))
            {
                LookUpEditFill.LookUpEdit(L_zoneID, new[] { "ZoneID", "Name" }, "Name", "ZoneID", zone);
            }
            using (var feature = Database.GetList("SELECT ParameterID, Definition FROM [dbArge].[dbo].[tblParameterList]('[dbo].[tblReceipt]','Feature')", con))
            {
                LookUpEditFill.LookUpEdit(L_feature, new[] { "Definition" }, "Definition", "ParameterID", feature);
            }
            using (var touchness = Database.GetList("SELECT ParameterID, Definition FROM [dbArge].[dbo].[tblParameterList] ('[dbo].[tblReceipt]','Touchness')", con))
            {
                LookUpEditFill.LookUpEdit(L_touchness, new[] { "Definition" }, "Definition", "ParameterID", touchness);
            }
            using (var d = MamulTree.LevelTypeList())
            {
                LookUpEditFill.LookUpEdit(seviyeTipiLookUp, new[] { "Caption" }, "Caption", "Code", d);
            }
            using (var d = MamulTree.getSiparisGoster())
            {
                LookUpEditFill.LookUpEdit(siparisGosterLookUp, new[] { "Caption" }, "Caption", "Code", d);
            }

            string sqlString = "SELECT DISTINCT(sg.StockGroupID) as StockGroupID,StockGroup,StockProperty,ProductGroup,StockType,StockProductType,MinValue,MaxValue,NFold FROM [dbArge].[dbo].[vwStockGroup] sg " +
                                                          "INNER JOIN[dbArge].[dbo].tblStockProcessRelation spr on spr.StockGroupID = sg.StockGroupID ORDER BY sg.StockGroupID ASC";
            using (var dStockGroup = Database.GetList(sqlString, con))
            {
                srcLookStockGroupID.DataSource = dStockGroup;
            }

            using (var d = Database.GetList("select ACIKLAMA,KOD from [TEKSTIL_UYG].[dbo].REFKRT where TABLOAD='TEXSPK' AND ALANAD='SKOD5'", con))
            {
                LookUpEditFill.LookUpEdit(lookupEditBoyamaSekli, new[] { "ACIKLAMA" }, "ACIKLAMA", "KOD", d);
            }

            renkDurumuDT.Columns.Add("RENKDURUM");
            renkDurumuDT.Columns.Add("KOD");
            renkDurumuDT.Rows.Add("Ekru", 0);
            renkDurumuDT.Rows.Add("Renkli", 1);
            LookUpEditFill.LookUpEdit(lookupEditRenkDurum, new[] { "RENKDURUM" }, "RENKDURUM", "KOD", renkDurumuDT);

            SelectReceteEVB();

            // Siparişler Default olarak Bugün olarak gelsin
            this.Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"));
            labelControl3.Text = " Filtre:" + " " + simpleButton4.Text + " ";
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            gridView1.Columns["Miktar"].SummaryItem.DisplayFormat = "Toplam: {0:n2}";
            gridView1.Columns["Kalan Miktar"].SummaryItem.DisplayFormat = "Toplam: {0:n2}";
            gridView1.BestFitColumns();

            ////Siparişler Özet LATER
            //this.Sum_Orders_TableAdapter.FillBy_Isletme(this.Sum_Orders.VWARGE_ORDER_CURRENT);
            //labelControl2.Text = " Filtre :" + " " + simpleButton17.Text + " ";
            //this.labelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));

            // Sevk Bekleyenler JUST FOR NOW
            //this.Sevk_Bekleyen_TableAdapter.Fill(this.Sevk_Bekleyen_DataSet.VWARGE_ORDER_CURRENT);
            //gridView2.BestFitColumns();
            //gridView2.Columns["Miktar"].SummaryItem.DisplayFormat = "Toplam: {0:n2}";
            //gridView2.Columns["Stok Miktar"].SummaryItem.DisplayFormat = "Toplam: {0:n2}";
        }

        private void SelectReceteEVB()
        {
            var cmd = con.CreateCommand();
            cmd.CommandText = "[dbo].SPARGE_TEXMRB_SELECT";
            cmd.CommandType = CommandType.StoredProcedure;
            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds, "Mamül Reçete Kayıtları");
            gridControlRecete.DataSource = ds.Tables[0];

            cmd.CommandText = "[dbo].SPARGE_TEXSRB_SELECT";
            cmd.CommandType = CommandType.StoredProcedure;
            var da2 = new SqlDataAdapter(cmd);
            var ds2 = new DataSet();
            da2.Fill(ds2, "Sipariş Reçete Kayıtları");
            gridControlSiparis.DataSource = ds2.Tables[0];

            cmd.CommandText = "[dbo].SPARGE_RECETE_SIPARISLER_SELECT";
            cmd.CommandType = CommandType.StoredProcedure;
            var da3 = new SqlDataAdapter(cmd);
            var ds3 = new DataSet();
            da3.Fill(ds3, "Sipariş Kayıtları");
            gridControlSiparisler.DataSource = ds3.Tables[0];

            //this.Order_All_TableAdapter.FillBy_SiparisRecete(this.Order_All_DataSet.VWARGE_ORDER_ALL);
        }

        private void TreeGroupControl_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Ana Ürün Ekle":
                    if (anaUrunKontrol)
                    {
                        if (string.IsNullOrEmpty(txtMalAdi.Text) && string.IsNullOrEmpty(txtMamulKodu.Text))
                        {
                            XtraMessageBox.Show("Lütfen Mamül Kodunu Giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        CreateRootNode();
                    }
                    else
                    {
                        XtraMessageBox.Show("Sadece Tek Bir Ana Ürün Eklenebilir!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    anaUrunKontrol = false;
                    break;

                case "Alt Ürün Ekle":
                    CreateNode(treeList1.FocusedNode, 1);
                    break;

                case "Hammadde Ekle":
                    CreateNode(treeList1.FocusedNode, 2);
                    break;

                case "Genişlet":
                    treeList1.ExpandAll();
                    break;

                case "Daralt":
                    treeList1.CollapseAll();
                    break;

                case "Satır Sil":
                    DeleteNode(treeList1.FocusedNode);
                    break;

                case "Kaydet":
                    bool isSave = mamulTree.ReceteNoIsSave(txtReceteNo.Text.ToString().Trim(), comboBoxReceteTipi.SelectedIndex == 0 ? "Mamul" : "Siparis");
                    if (isSave)
                    {
                        TreeKaydet();
                    }
                    else
                    {
                        TreeUpdate();
                    }
                    break;

                case "Yeni":
                    createNewReceteID(comboBoxReceteTipi.SelectedIndex == 0 ? "Mamul" : "Siparis");
                    NewRecord();
                    break;

                case "Yeni Mamül Tanımla":
                    using(StokKart form = new StokKart())
                    {
                        form.vGridElyaf.Visible = false;
                        form.vGridOzel.Visible = false;
                        form.vGridMuhasebe.Visible = false;
                        form.rowGrupKodu.Properties.Value = "01";
                        form.rowGrupKodu.Properties.ReadOnly = true;
                        form.CreateNewMamulKod();
                        var result = form.ShowDialog();
                    }
                    break;

                case "Reçeteyi Sil":
                    DeleteEVB();
                    break;
            }
        }

        private void NewRecord()
        {
            treeList1.ClearNodes();
            txtAciklama.Text = txtMalAdi.Text = txtMamulKodu.Text = txtRenkAdi.Text = txtRenkKodu.Text = txtKalemSN.Text = "";
            lookupEditBoyamaSekli.EditValue = lookupEditRenkDurum.EditValue = null;
        }

        private void CreateRootNode()
        {
            treeList1.DataSource = mamulTree.GetTreeColumns();
            treeList1.BeginUnboundLoad();
            _rootNode = treeList1.AppendNode(null, null);
            _rootNode.SetValue(SATIRTIP, 0); // 0 Ana ürün - 1 Alt ürün - 2 Hammade
            _rootNode.SetValue(SEVIYE, 1);
            _rootNode.SetValue(ANASEVIYE, 0);
            _rootNode.SetValue(MALKOD, txtMamulKodu.Text.Trim().ToString());
            _rootNode.SetValue(MALKOD, txtMamulKodu.Text);
            _rootNode.SetValue(MIKTAR, 1);
            _rootNode.SetValue(NKOD2, 0);
            _rootNode.SetValue(NKOD1, 0);
            _rootNode.SetValue(RENKKOD, txtRenkKodu.Text.Trim().ToString());
            _rootNode.SetValue(BKOD1, 1);
            _rootNode.SetValue(BKOD3, 1); // 0 Evet - 1 Hayir
            _rootNode.SetValue(BKOD4, -1);
            _rootNode.SetValue(MKOD1, 0);
            _rootNode.SetValue(ACIKLAMA1, "");
            _rootNode.SetValue(MIKTARDURUM, 0);
            _rootNode.SetValue(MRPTIP, 0);
            _rootNode.SetValue(SIRANO, 1);
            _rootNode.SetValue(SIRANO2, 0);
            _rootNode.SetValue(ANAMALKOD, "");
            _rootNode.SetValue(MAMULKOD, "");
            _rootNode.SetValue(RENKDURUM, 0);
            _rootNode.SetValue(BOYAMASEKLI, 0);
            _rootNode.SetValue(MIKTARDURUM, 0);
            _rootNode.SetValue(MALAD, mamulTree.GetMalAd(txtMamulKodu.Text.ToString().Trim()));
            _rootNode.SetValue(RENKAD, mamulTree.GetRenkAd(txtRenkKodu.Text.ToString().Trim()));
            treeList1.EndUnboundLoad();
            treeList1.Refresh();
            treeList1.RefreshDataSource();
            treeList1.BestFitColumns();
            treeList1.ExpandAll();
        }

        private void CreateNode(TreeListNode rootNode, int levelType)
        {
            if (rootNode == null) return;

            treeList1.BeginUnboundLoad();
            var node = treeList1.AppendNode(null, rootNode);

            node.SetValue(ANASEVIYE, rootNode.GetValue(SEVIYE));
            node.SetValue(SEVIYE, treeList1.AllNodesCount);
            node.SetValue(SATIRTIP, levelType); // 1 - 2
            node.SetValue(MALKOD, 0);
            //node.SetValue(treeMalAdi, 0);
            node.SetValue(NKOD2, 0);
            node.SetValue(MIKTAR, 0);
            node.SetValue(NKOD1, 0);
            node.SetValue(RENKKOD, 0);
            //node.SetValue(treeRenkAdi, 0);
            node.SetValue(BKOD1, 0);
            node.SetValue(BKOD3, 1);
            node.SetValue(BKOD4, 0);
            node.SetValue(MKOD1, 0);
            node.SetValue(ACIKLAMA1, 0);
            node.SetValue(MIKTARDURUM, 0);
            node.SetValue(MRPTIP, 0);
            node.SetValue(SIRANO, treeList1.AllNodesCount);
            node.SetValue(SIRANO2, treeList1.AllNodesCount - 1);
            node.SetValue(ANAMALKOD, "");
            node.SetValue(MAMULKOD, "");
            node.SetValue(RENKDURUM, 0);
            node.SetValue(BOYAMASEKLI, 0);
            //node.SetValue(TEMINYONETIM, 0);
            node.SetValue(MIKTARDURUM, 0);
            node.SetValue(MALAD, 0);
            treeList1.EndUnboundLoad();
            treeList1.Refresh();
            treeList1.RefreshDataSource();
            treeList1.BestFitColumns();
            treeList1.ExpandAll();
        }

        private void DeleteNode(TreeListNode node)
        {
            //if ((DataTable)treeList.DataSource == null || ((DataTable)treeList1.DataSource).Rows.Count == 0) return;

            if (node == null) return;

            if (XtraMessageBox.Show("Bu Satırı silmek istediğinizden emin misiniz?!", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                if (treeList1.FocusedNode.ParentNode == null)
                {
                    anaUrunKontrol = true;
                }
                node.Remove();
                treeList1.Refresh();
                treeList1.RefreshDataSource();
                //DeleteChildNodes(node);
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void TreeKaydet()
        {
            var dtreeList1 = (DataTable)treeList1.DataSource;
            if (dtreeList1 == null) return;

            if (XtraMessageBox.Show($"{txtReceteNo.Text} Numaralı Reçete Bilgilerini Kaydetmek İstediğinizden Emin misiniz?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (comboBoxReceteTipi.SelectedIndex == 0)
            {
                TreeKaydetMamulRecete(dtreeList1);
            }
            else
            {
                TreeKaydetMamulSiparis(dtreeList1);
            }
        }

        private void TreeKaydetMamulRecete(DataTable dtreeList1)
        {
            SqlTransaction transaction = null;
            try
            {
                transaction = con.BeginTransaction("Mamul");
                int result = mamulTree.InsertTEXMRB(txtReceteNo.Text, txtMamulKodu.Text, lookupEditRenkDurum.EditValue.ToString() == "1",
                                                    lookupEditBoyamaSekli.EditValue, txtAciklama.Text, LoginForm.UserName, Environment.UserName,
                                                    LoginForm.UserName, Environment.UserName, txtRenkKodu.Text, transaction);
                if (result <= 0)
                {
                    XtraMessageBox.Show(Properties.Resources.InsertError, "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    transaction.Rollback();
                    return;
                }
                foreach (DataRow row in dtreeList1.Rows)
                {
                    result = mamulTree.InsertTEXMRH(row["SATIRTIP"], row["MALKOD"], row["MIKTAR"], row["NKOD2"],
                        row["NKOD1"], row["RENKKOD"], row["BKOD1"], row["BKOD3"],
                        row["BKOD4"], row["MKOD1"], row["ACIKLAMA1"], row["ANASEVIYE"],
                        row["SEVIYE"], txtReceteNo.Text, LoginForm.UserName, Environment.UserName,
                        row["MIKTARDURUM"], row["MRPTIP"], row["SIRANO"], row["SIRANO2"], row["ANAMALKOD"],
                        row["MAMULKOD"], row["RENKDURUM"], row["BOYAMASEKLI"], row["STOCKGROUPID"], row["TOUCHNESS"], row["FEATURE"], row["ZONEID"], row["BOTTLENECK"],
                        transaction);

                    if (result <= 0)
                    {
                        XtraMessageBox.Show(Properties.Resources.InsertError, "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return;
                    }
                }
                XtraMessageBox.Show(Properties.Resources.InsertInfo, "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                XtraMessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        private void TreeKaydetMamulSiparis(DataTable dtreeList1)
        {
            SqlTransaction transaction = null;
            try
            {
                transaction = con.BeginTransaction("Siparis");
                int result = mamulTree.InsertTEXSRB(txtKalemSN.Text, txtReceteNo.Text, txtMamulKodu.Text, lookupEditRenkDurum.EditValue.ToString() == "1",
                                                    lookupEditBoyamaSekli.EditValue, txtAciklama.Text, LoginForm.UserName, Environment.UserName,
                                                    LoginForm.UserName, Environment.UserName, txtRenkKodu.Text, transaction);
                if (result <= 0)
                {
                    XtraMessageBox.Show(Properties.Resources.InsertError, "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    transaction.Rollback();
                    return;
                }
                foreach (DataRow row in dtreeList1.Rows)
                {
                    result = mamulTree.InsertTEXSRH(txtKalemSN.Text, row["SATIRTIP"], row["MALKOD"], row["MIKTAR"], row["NKOD2"],
                        row["NKOD1"], row["RENKKOD"], row["BKOD1"], row["BKOD3"],
                        row["BKOD4"], row["MKOD1"], row["ACIKLAMA1"], row["ANASEVIYE"],
                        row["SEVIYE"], txtReceteNo.Text, LoginForm.UserName, Environment.UserName,
                        row["MIKTARDURUM"], row["MRPTIP"], row["SIRANO"], row["SIRANO2"], row["ANAMALKOD"],
                        row["MAMULKOD"], row["RENKDURUM"], row["BOYAMASEKLI"], row["STOCKGROUPID"], row["TOUCHNESS"], row["FEATURE"], row["ZONEID"], row["BOTTLENECK"],
                        transaction);

                    if (result <= 0)
                    {
                        XtraMessageBox.Show(Properties.Resources.InsertError, "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return;
                    }
                }
                XtraMessageBox.Show(Properties.Resources.InsertInfo, "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                XtraMessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        private void TreeUpdate()
        {
            var dtreeList1 = (DataTable)treeList1.DataSource;
            if (dtreeList1 == null) return;

            if (XtraMessageBox.Show($"{txtReceteNo.Text} Numaralı Reçete Bilgilerini Güncellemek İstediğinizden Emin misiniz?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (comboBoxReceteTipi.SelectedIndex == 0)
            {
                TreeUpdateMamulRecete(dtreeList1);
            }
            else
            {
                TreeUpdateSiparisRecete(dtreeList1);
            }
        }

        private void TreeUpdateMamulRecete(DataTable dtreeList1)
        {
            SqlTransaction transaction = null;
            try
            {
                transaction = con.BeginTransaction("Mamul");
                int result = mamulTree.UpdateTEXMRB(txtReceteNo.Text, txtMamulKodu.Text, lookupEditRenkDurum.EditValue.ToString() == "1",
                                                    lookupEditBoyamaSekli.EditValue, txtAciklama.Text, LoginForm.UserName, Environment.UserName,
                                                    LoginForm.UserName, Environment.UserName, txtRenkKodu.Text, transaction);
                if (result <= 0)
                {
                    XtraMessageBox.Show(Properties.Resources.UpdateError, "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    transaction.Rollback();
                    return;
                }

                mamulTree.CleanTEXMRHBeforeUpdate(txtReceteNo.Text, transaction);

                foreach (DataRow row in dtreeList1.Rows)
                {
                    result = mamulTree.InsertTEXMRH(row["SATIRTIP"], row["MALKOD"], row["MIKTAR"], row["NKOD2"],
                    row["NKOD1"], row["RENKKOD"], row["BKOD1"], row["BKOD3"],
                    row["BKOD4"], row["MKOD1"], row["ACIKLAMA1"], row["ANASEVIYE"],
                    row["SEVIYE"], txtReceteNo.Text, LoginForm.UserName, Environment.UserName,
                    row["MIKTARDURUM"], row["MRPTIP"], row["SIRANO"], row["SIRANO2"], row["ANAMALKOD"],
                    row["MAMULKOD"], row["RENKDURUM"], row["BOYAMASEKLI"], row["STOCKGROUPID"], row["TOUCHNESS"], row["FEATURE"], row["ZONEID"], row["BOTTLENECK"],
                    transaction);

                    if (result <= 0)
                    {
                        XtraMessageBox.Show(Properties.Resources.UpdateError, "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return;
                    }
                }
                XtraMessageBox.Show("Bilgiler başarılı bir şekilde Güncellendi.", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                XtraMessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        private void TreeUpdateSiparisRecete(DataTable dtreeList1)
        {
            SqlTransaction transaction = null;
            try
            {
                transaction = con.BeginTransaction("Siparis");
                int result = mamulTree.UpdateTEXSRB(txtKalemSN.Text, txtReceteNo.Text, txtMamulKodu.Text, lookupEditRenkDurum.EditValue.ToString() == "1",
                                                    lookupEditBoyamaSekli.EditValue, txtAciklama.Text, LoginForm.UserName, Environment.UserName,
                                                    LoginForm.UserName, Environment.UserName, txtRenkKodu.Text, transaction);
                if (result <= 0)
                {
                    XtraMessageBox.Show(Properties.Resources.UpdateError, "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    transaction.Rollback();
                    return;
                }

                mamulTree.CleanTEXSRHBeforeUpdate(txtReceteNo.Text, transaction);

                foreach (DataRow row in dtreeList1.Rows)
                {
                    result = mamulTree.InsertTEXSRH(txtKalemSN.Text, row["SATIRTIP"], row["MALKOD"], row["MIKTAR"], row["NKOD2"],
                    row["NKOD1"], row["RENKKOD"], row["BKOD1"], row["BKOD3"],
                    row["BKOD4"], row["MKOD1"], row["ACIKLAMA1"], row["ANASEVIYE"],
                    row["SEVIYE"], txtReceteNo.Text, LoginForm.UserName, Environment.UserName,
                    row["MIKTARDURUM"], row["MRPTIP"], row["SIRANO"], row["SIRANO2"], row["ANAMALKOD"],
                    row["MAMULKOD"], row["RENKDURUM"], row["BOYAMASEKLI"], row["STOCKGROUPID"], row["TOUCHNESS"], row["FEATURE"], row["ZONEID"], row["BOTTLENECK"],
                    transaction);

                    if (result <= 0)
                    {
                        XtraMessageBox.Show(Properties.Resources.UpdateError, "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return;
                    }
                }
                XtraMessageBox.Show("Bilgiler başarılı bir şekilde Güncellendi.", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                XtraMessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        private void DeleteEVB()
        {
            if (XtraMessageBox.Show($"{txtReceteNo.Text} Numaralı Reçete Bilgilerini Silmek İstediğinizden Emin misiniz?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            SqlTransaction transaction = null;
            try
            {
                string tableName = comboBoxReceteTipi.SelectedIndex == 0 ? "TEXMRH" : "TEXSRH";
                transaction = con.BeginTransaction("DeleteRecete");
                var cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;

                cmd.CommandText = $"DELETE FROM {tableName} WHERE RECETENO='{txtReceteNo.Text}'";
                cmd.ExecuteNonQuery();

                tableName = comboBoxReceteTipi.SelectedIndex == 0 ? "TEXMRB" : "TEXSRB";

                cmd.CommandText = $"DELETE FROM {tableName} WHERE RECETENO='{txtReceteNo.Text}'";
                cmd.ExecuteNonQuery();

                transaction.Commit();
                XtraMessageBox.Show("Bilgiler başarılı bir şekilde Silindi.", "Bilgi", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                SelectReceteEVB();
                NewRecord();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                XtraMessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
        }

        private void T_RenkKod_Enter(object sender, EventArgs e)
        {
            string renkAd = mamulTree.GetRenkAd(treeList1.GetFocusedDisplayText().ToString());
            treeList1.FocusedNode.SetValue(RENKAD, renkAd);
        }

        private void T_MalKod_Enter(object sender, EventArgs e)
        {
            string malAd = mamulTree.GetMalAd(treeList1.GetFocusedDisplayText().ToString());
            treeList1.FocusedNode.SetValue(MALAD, malAd);
        }

        private string getRenkAdiByRenkKodu(string renkKodu)
        {
            string sqlQuery = $"SELECT TOP(1) RENKAD FROM TEXRAH WHERE RENKKOD='{renkKodu}' ORDER BY ID DESC";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dt = new DataSet();
            dataAdapter.Fill(dt, "Renk Adi");
            if (dt.Tables[0].Rows.Count == 0)
                return "";
            return dt.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        private void txtRenkKodu_Leave(object sender, EventArgs e)
        {
            string renkAdi = getRenkAdiByRenkKodu(txtRenkKodu.Text);
            txtRenkAdi.Text = renkAdi;
        }

        private void txtRenkKodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string renkAdi = getRenkAdiByRenkKodu(txtRenkKodu.Text);
                txtRenkAdi.Text = renkAdi;
            }
        }

        private void createNewReceteID(string receteTip)
        {
            if (!IsReceteNoFull(txtReceteNo.Text))
            {
                CancelReceteNo(txtReceteNo.Text, comboBoxReceteTipi.SelectedIndex == 0 ? "Mamul" : "Siparis");
                //using (var d = Database.GetList($"SELECT AVALUE FROM dbo.PARAME WITH (NOLOCK) WHERE APPNAME = 'DOPTekstil{receteTip}Recete' and AIDENT = 'Seri-1'", con))
                //{
                //    string strReceteNo = d.Rows[0].ItemArray[0].ToString();
                //    strReceteNo = strReceteNo.Remove(0, 2);
                //    int intReceteNo = Convert.ToInt32(strReceteNo);
                //    intReceteNo -= 1;
                //    if (intReceteNo.ToString().Length < 6)
                //    {
                //        strReceteNo = receteTip == "Mamul" ? "MR" : "SR";
                //        for (int i = intReceteNo.ToString().Length; i < 6; i++)
                //        {
                //            strReceteNo += "0";
                //        }
                //        strReceteNo += intReceteNo.ToString();
                //    }
                //    else
                //        strReceteNo = receteTip == "Mamul" ? "MR" : "SR" + intReceteNo.ToString();
                //    txtReceteNo.Text = strReceteNo;
                //}
            }
            var cmd = con.CreateCommand();
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Maybe Gereksiz
            //cmd.CommandText = "EXEC dbo.SPAPP_SERIAL_NAME 'DOPTekstilMamulRecete', 'RECETENO', 'IDRISA', 'PAZ_PLANYONETIM'";
            //cmd.CommandType = CommandType.Text;
            //cmd.ExecuteNonQuery();
            cmd.CommandText = $"EXEC dbo.SPAPP_SERIAL_DBNEW 'DOPTekstil{receteTip}Recete', 'RECETENO', 'Seri-1', ''";
            cmd.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            txtReceteNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        static public void CancelReceteNo(string receteNo, string receteTip)
        {
            if (!IsReceteNoFull(receteNo))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"EXEC dbo.SPAPP_SERIAL_CANCEL 'DOPTekstil{receteTip}Recete', 'RECETENO', 'Seri-1', '{receteNo}'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        static public void CancelMRPNo(string MRPNo)
        {
            if (!IsMRPNoFull(MRPNo))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"EXEC dbo.SPAPP_SERIAL_CANCEL '53', 'EVRAKNO', 'Seri-1', '{MRPNo}'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        static private bool IsReceteNoFull(string receteNo)
        {
            if (receteNo.StartsWith("M"))
            {
                using (var d = Database.GetList($"SELECT TOP 1 TEXMRB.RECETENO FROM dbo.TEXMRB WITH (NOLOCK) where RECETENO = '{receteNo}'", con))
                {
                    if (d.Rows.Count == 0)
                        return false;
                    else
                        return true;
                }
            }
            else if (receteNo.StartsWith("S"))
            {
                using (var d = Database.GetList($"SELECT TOP 1 TEXSRB.RECETENO FROM dbo.TEXSRB WITH (NOLOCK) where RECETENO = '{receteNo}'", con))
                {
                    if (d.Rows.Count == 0)
                        return false;
                    else
                        return true;
                }
            }
            else
                return false;
        }

        private void FormPlanlama_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelReceteNo(txtReceteNo.Text, comboBoxReceteTipi.SelectedIndex == 0 ? "Mamul" : "Siparis");
            CancelMRPNo(GetRowValueWithCheck(rowMRPNo));
            con.Close();
        }

        private void stock_group_control_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Operasyonlar op = new Operasyonlar();
            switch (e.Button.Properties.Caption)
            {
                case "Mamül":
                    DataTable dtMamul = op.Mamul();
                    grdControlMamul.DataSource = dtMamul;
                    break;

                case "Yarı Mamül":
                    DataTable dtYariMamul = op.YariMamul();
                    grdControlMamul.DataSource = dtYariMamul;
                    break;

                case "Elyaf":
                    DataTable dtElyaf = op.Elyaf();
                    grdControlMamul.DataSource = dtElyaf;
                    break;

                case "Tümü":
                    DataTable dtTumu = op.Tumu();
                    grdControlMamul.DataSource = dtTumu;
                    break;
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (treeList1.FocusedValue == null || treeList1.FocusedNode.ParentNode == null)
                return;
            DataRow row = gridViewMamul.GetFocusedDataRow();
            treeList1.FocusedNode.SetValue(MALKOD, row["MALKOD"].ToString());
            treeList1.FocusedNode.SetValue(MALAD, row["MALAD"].ToString());
        }

        private void lookupEditRenkDurum_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEditRenkDurum.Properties.GetDisplayText(lookupEditRenkDurum.EditValue) == "Ekru") // Ekru
            {
                txtRenkKodu.Text = "Ekru";
                txtRenkAdi.Text = "Ekru";
            }
        }

        private string getStockNameByCode(string code)
        {
            var maladi = Database.GetRow($"SELECT MALAD FROM [TEKSTIL_UYG].[dbo].[STKKRT] skr WHERE skr.MALKOD ='{code}'", con);
            if (maladi == null)
                return "";
            else
                return maladi.ItemArray[0].ToString();
        }

        private void txtMamulKodu_TextChanged(object sender, EventArgs e)
        {
            txtMalAdi.Text = getStockNameByCode(txtMamulKodu.Text);
        }

        private void filterButtonClick(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            labelControl3.Text = " Filtre :" + " " + btn.Text + " ";
            labelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            DateTime today = DateTime.Today;
            string format = "yyyy/MM/dd";

            switch (btn.Text)
            {
                case "Bugün":
                    Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, DateTime.Now.ToString(format), DateTime.Now.ToString(format));
                    break;

                case "Dün":
                    DateTime yesterday = DateTime.Today.AddDays(-1);
                    Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, yesterday.ToString(format), yesterday.ToString(format));
                    break;

                case "Bu Hafta":
                    DateTime start_this_week = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, start_this_week.ToString(format), today.ToString(format));
                    break;

                case "Son 2 Hafta":
                    DateTime start_last2_week = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek) - 7);
                    Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, start_last2_week.ToString(format), today.ToString(format));
                    break;

                case "Son 3 Hafta":
                    DateTime start_last3_week = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek) - 14);
                    Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, start_last3_week.ToString(format), today.ToString(format));
                    break;

                case "Bu Ay":
                    var thismonth = new DateTime(today.Year, today.Month, 1);
                    Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, thismonth.ToString(format), today.ToString(format));
                    break;

                case "Son 2 Ay":
                    var last2month = new DateTime(today.Year, today.Month - 1, 1);
                    Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, last2month.ToString(format), today.ToString(format));
                    break;

                case "Son 3 Ay":
                    var last3month = new DateTime(today.Year, today.Month - 2, 1);
                    Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, last3month.ToString(format), today.ToString(format));
                    break;

                case "Son 6 Ay":
                    var last6month = new DateTime(today.Year, today.Month - 6, 1);
                    this.Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, last6month.ToString(format), today.ToString(format));
                    break;

                case "Bu Yıl":
                    var start_year = new DateTime(today.Year, 1, 1);
                    this.Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, start_year.ToString(format), today.ToString(format));
                    break;

                case "Geçen Yıl":
                    var lastyear_startdate = new DateTime(today.Year - 1, 1, 1);
                    var lastyear_finishdate = new DateTime(today.Year - 1, 12, 31);
                    Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, lastyear_startdate.ToString(format), lastyear_finishdate.ToString(format));
                    break;
            }
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.White;
            labelControl3.Text = " Filtre: ";
            comboBoxEdit1.EditValue = "---";
            DateTime today = DateTime.Today;
            string format = "yyyy/MM/dd";
            this.Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, "2020-01-01", today.ToString(format));
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;

            string start_date, finish_date;

            DataTable dt = new DataTable();
            dt.Columns.Add("Month", typeof(string));
            dt.Columns.Add("StartDate", typeof(string));
            dt.Columns.Add("FinishDate", typeof(string));
            dt.Columns.Add("R", typeof(int));
            dt.Columns.Add("G", typeof(int));
            dt.Columns.Add("B", typeof(int));

            dt.Rows.Add("---", "2020-01-01", today.ToString("yyyy-MM-dd"), 255, 255, 255);
            dt.Rows.Add("Ocak", "01-01", "01-31", 255, 224, 192);
            dt.Rows.Add("Şubat", "02-01", "02-28", 255, 224, 192);
            dt.Rows.Add("Mart", "03-01", "03-31", 255, 224, 192);
            dt.Rows.Add("Nisan", "04-01", "04-30", 255, 224, 192);
            dt.Rows.Add("Mayıs", "05-01", "05-31", 255, 224, 192);
            dt.Rows.Add("Haziran", "06-01", "06-30", 255, 224, 192);
            dt.Rows.Add("Temmuz", "07-01", "07-31", 255, 224, 192);
            dt.Rows.Add("Ağustos", "08-01", "08-31", 255, 224, 192);
            dt.Rows.Add("Eylül", "09-01", "09-30", 255, 224, 192);
            dt.Rows.Add("Ekim", "10-01", "10-31", 255, 224, 192);
            dt.Rows.Add("Kasım", "11-01", "11-30", 255, 224, 192);
            dt.Rows.Add("Aralık", "12-01", "12-31", 255, 224, 192);

            foreach (DataRow row in dt.Rows)
            {
                if (row["Month"].ToString() == comboBoxEdit1.EditValue.ToString())
                {
                    if (comboBoxEdit1.EditValue.ToString() == "---")
                    {
                        start_date = row["StartDate"].ToString();
                        finish_date = row["FinishDate"].ToString();
                    }
                    else
                    {
                        start_date = today.Year + "-" + row["StartDate"].ToString();
                        finish_date = today.Year + "-" + row["FinishDate"].ToString();
                    }
                    labelControl3.Text = " Filtre :" + " " + row["Month"].ToString() + " ";
                    this.Order_All_TableAdapter.Fill(this.Order_All_DataSet.VWARGE_ORDER_ALL, start_date, finish_date);
                    this.labelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(row["R"].ToString()), Convert.ToInt32(row["G"].ToString()), Convert.ToInt32(row["B"].ToString()));
                }
            }
        }

        private void filterByButtonClick(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            labelControl2.Text = " Filtre :" + " " + btn.Text + " ";
            labelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);

            Thread th = new Thread(() => TimerFunc(10));

            try
            {
                splashScreenManager1.ShowWaitForm();
                th.Start();

                FillBy(btn.Text);

                th.Abort();
                splashScreenManager1.CloseWaitForm();
            }
            catch (ThreadStateException ext)
            {
                XtraMessageBox.Show(ext.Message);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void FillBy(string filter)
        {
            switch (filter)
            {
                case "İşletme":
                    Sum_Orders_TableAdapter.FillBy_Isletme(Sum_Orders.VWARGE_ORDER_CURRENT);
                    break;

                case "Sipariş Tipi":
                    Sum_Orders_TableAdapter.FillBy_Siparis_Tip(Sum_Orders.VWARGE_ORDER_CURRENT);
                    break;

                case "Sipariş Türü":
                    Sum_Orders_TableAdapter.FillBy_SiparisTuru(Sum_Orders.VWARGE_ORDER_CURRENT);
                    break;

                case "Boyama":
                    Sum_Orders_TableAdapter.FillBy_Boyama(Sum_Orders.VWARGE_ORDER_CURRENT);
                    break;

                case "Kalite":
                    Sum_Orders_TableAdapter.FillBy_Kalite(Sum_Orders.VWARGE_ORDER_CURRENT);
                    break;

                case "Müşteri":
                    Sum_Orders_TableAdapter.FillBy_Musteri(Sum_Orders.VWARGE_ORDER_CURRENT);
                    break;

                case "Renk Kodu":
                    Sum_Orders_TableAdapter.FillBy_Renk(Sum_Orders.VWARGE_ORDER_CURRENT);
                    break;

                default:
                    gridControl3.DataSource = null;
                    labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
                    break;
            }
        }

        private void comboBoxReceteTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewRecord();
            if (comboBoxReceteTipi.SelectedIndex == 0) // Mamul Recete
            {
                using (var d = Database.GetList($"SELECT AVALUE FROM dbo.PARAME WITH (NOLOCK) WHERE APPNAME = 'DOPTekstil{"Mamul"}Recete' and AIDENT = 'Seri-1'", con))
                {
                    string strReceteNo = d.Rows[0].ItemArray[0].ToString();
                    strReceteNo = strReceteNo.Remove(0, 2);
                    int intReceteNo = Convert.ToInt32(strReceteNo);
                    intReceteNo -= 1;
                    if (intReceteNo.ToString().Length < 6)
                    {
                        strReceteNo = "MR";
                        for (int i = intReceteNo.ToString().Length; i < 6; i++)
                        {
                            strReceteNo += "0";
                        }
                        strReceteNo += intReceteNo.ToString();
                    }
                    else
                        strReceteNo = "MR" + intReceteNo.ToString();
                    txtReceteNo.Text = strReceteNo;
                }
            }
            else if (comboBoxReceteTipi.SelectedIndex == 1)  // Siparis Recete
            {
                using (var d = Database.GetList($"SELECT AVALUE FROM dbo.PARAME WITH (NOLOCK) WHERE APPNAME = 'DOPTekstil{"Siparis"}Recete' and AIDENT = 'Seri-1'", con))
                {
                    string strReceteNo = d.Rows[0].ItemArray[0].ToString();
                    strReceteNo = strReceteNo.Remove(0, 2);
                    int intReceteNo = Convert.ToInt32(strReceteNo);
                    intReceteNo -= 1;
                    if (intReceteNo.ToString().Length < 6)
                    {
                        strReceteNo = "SR";
                        for (int i = intReceteNo.ToString().Length; i < 6; i++)
                        {
                            strReceteNo += "0";
                        }
                        strReceteNo += intReceteNo.ToString();
                    }
                    else
                        strReceteNo = "SR" + intReceteNo.ToString();
                    txtReceteNo.Text = strReceteNo;
                }
            }
        }

        private void gridViewMamulRecete_DoubleClick(object sender, EventArgs e)
        {
            CancelReceteNo(txtReceteNo.Text, comboBoxReceteTipi.SelectedIndex == 0 ? "Mamul" : "Siparis");
            DataRow row = gridViewMamulRecete.GetFocusedDataRow();
            txtReceteNo.Text = row["RECETENO"].ToString();
            txtMamulKodu.Text = row["MAMULKOD"].ToString();
            txtMalAdi.Text = row["STKKRT_MALAD"].ToString();
            txtAciklama.Text = row["ACIKLAMA"].ToString();
            txtRenkKodu.Text = row["RENKKOD"].ToString();
            txtRenkAdi.Text = row["TEXRAH_RENKAD"].ToString();

            lookupEditBoyamaSekli.EditValue = lookupEditBoyamaSekli.Properties.GetKeyValueByDisplayValue(row["BOYAMA_SEKLI"].ToString());
            lookupEditRenkDurum.EditValue = "";
            lookupEditRenkDurum.EditValue = lookupEditRenkDurum.Properties.GetKeyValueByDisplayValue(row["RENKDURUM"].ToString());

            var cmd = con.CreateCommand();
            cmd.CommandText = "[dbo].SPARGE_TEXMRH_SELECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RECETENO", SqlDbType.VarChar);
            cmd.Parameters["@RECETENO"].Value = txtReceteNo.Text;
            cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds, "Reçete Kayıtları");

            treeList1.DataSource = ds.Tables[0];
            foreach (DataRow r in ((DataTable)treeList1.DataSource).Rows)
            {
                r["BKOD1"] = L_BoyahaneIslem.GetKeyValueByDisplayValue(r["BKOD1"].ToString());
                r["BKOD4"] = L_UretimYeri.GetKeyValueByDisplayValue(r["BKOD4"].ToString());
            }
            treeList1.ExpandAll();
        }

        private void gridViewSiparisRecete_DoubleClick(object sender, EventArgs e)
        {
            CancelReceteNo(txtReceteNo.Text, comboBoxReceteTipi.SelectedIndex == 0 ? "Mamul" : "Siparis");
            DataRow row = gridViewSiparisRecete.GetFocusedDataRow();
            txtReceteNo.Text = row["RECETENO"].ToString();
            txtMamulKodu.Text = row["MAMULKOD"].ToString();
            txtMalAdi.Text = row["STKKRT_MALAD"].ToString();
            txtAciklama.Text = row["ACIKLAMA"].ToString();
            txtRenkKodu.Text = row["RENKKOD"].ToString();
            txtRenkAdi.Text = row["TEXRAH_RENKAD"].ToString();
            txtKalemSN.Text = row["KALEMSN"].ToString();

            lookupEditBoyamaSekli.EditValue = lookupEditBoyamaSekli.Properties.GetKeyValueByDisplayValue(row["BOYAMA_SEKLI"].ToString());
            lookupEditRenkDurum.EditValue = "";
            lookupEditRenkDurum.EditValue = lookupEditRenkDurum.Properties.GetKeyValueByDisplayValue(row["RENKDURUM"].ToString());

            var cmd = con.CreateCommand();
            cmd.CommandText = "[dbo].SPARGE_TEXSRH_SELECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RECETENO", SqlDbType.VarChar);
            cmd.Parameters["@RECETENO"].Value = txtReceteNo.Text;
            cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add("@KALEMSN", SqlDbType.VarChar);
            cmd.Parameters["@KALEMSN"].Value = txtKalemSN.Text;
            cmd.Parameters["@KALEMSN"].Direction = ParameterDirection.Input;

            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds, "Reçete Kayıtları");

            treeList1.DataSource = ds.Tables[0];
            foreach (DataRow r in ((DataTable)treeList1.DataSource).Rows)
            {
                r["BKOD1"] = L_BoyahaneIslem.GetKeyValueByDisplayValue(r["BKOD1"].ToString());
                r["BKOD4"] = L_UretimYeri.GetKeyValueByDisplayValue(r["BKOD4"].ToString());
            }
            treeList1.ExpandAll();
        }

        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl2.SelectedTabPage.Text == "Mamül Reçete Kayıtları")
            {
                comboBoxReceteTipi.SelectedIndex = 0;
            }
            else if (xtraTabControl2.SelectedTabPage.Text == "Sipariş Reçete Kayıtları" || xtraTabControl2.SelectedTabPage.Text == "Siparişler")
            {
                comboBoxReceteTipi.SelectedIndex = 1;
            }
        }

        private void gridViewSiparisler_DoubleClick(object sender, EventArgs e)
        {
            NewRecord();
            DataRow row = gridViewSiparisler.GetFocusedDataRow();
            txtKalemSN.Text = row["KALEMSN"].ToString();
            txtMamulKodu.Text = row["Malzeme Kodu"].ToString();
            txtRenkKodu.Text = row["Renk Kodu"].ToString();
            lookupEditBoyamaSekli.EditValue = lookupEditBoyamaSekli.Properties.GetKeyValueByDisplayText(row["Boyama Şekli"].ToString());
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
        }

        private void MRP_baglanti_gridView_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = MRP_baglanti_gridView.GetFocusedDataRow();
            rowEvrakNo.Properties.Value = row["EVRAKNO"];
            rowMusteri.Properties.Value = row["Müşteri Kısa Ad"];
            rowKalite.Properties.Value = row["Malzeme Adı"];
            rowIcerik.Properties.Value = row["İçerik"];
            rowRenkKodu.Properties.Value = row["Renk Kodu"];
            rowRenkAdı.Properties.Value = row["Renk Adı"];
            rowMRecete.Properties.Value = row["MamülReçeteNo"];
            rowSRecete.Properties.Value = row["SiparişReçeteNo"];
            rowKullanıcı.Properties.Value = row["GIRENKULLANICI"];
            //rowEvrakNo.Properties.Value = row["EVRAKNO"];
            //rowEvrakNo.Properties.Value = row["EVRAKNO"];
            //rowEvrakNo.Properties.Value = row["EVRAKNO"];
        }

        private void CreateNewMRPNo()
        {
            CancelMRPNo(GetRowValueWithCheck(rowMRPNo));
            var cmd = con.CreateCommand();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            cmd.CommandText = $"EXEC dbo.SPAPP_SERIAL_DBNEW '53', 'EVRAKNO', 'Seri-1', ''";
            cmd.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            rowMRPNo.Properties.Value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        static private bool IsMRPNoFull(string MRPNo)
        {
            using (var d = Database.GetList($"SELECT TOP 1 EVRAKNO FROM dbo.VW_STKHAR WHERE EVRAKTIP=53 AND EVRAKNO = '{MRPNo}'", con))
            {
                if (d.Rows.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        static public string GetRowValueWithCheck(EditorRow row)
        {
            return row.Properties.Value == null ? "" : row.Properties.Value.ToString();
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Yeni":
                    foreach (BaseRow row in vGridControl1.Rows)
                    {
                        if (row.Name != "rowMRPNo")
                            row.Properties.Value = "";
                    }
                    rowTarih.Properties.Value = DateTime.Today;
                    CreateNewMRPNo();
                    break;
            }
        }

        private void MRP_izleyici_gridView_DoubleClick(object sender, EventArgs e)
        { 
            CancelMRPNo(GetRowValueWithCheck(rowMRPNo));
            DataRow row = MRP_izleyici_gridView.GetFocusedDataRow();
            rowMRPNo.Properties.Value = row["EVRAKNO"];
            rowEvrakNo.Properties.Value = row["Sipariş_No"];
            rowMusteri.Properties.Value = row["Müşteri Kısa Ad"];
            //rowKalite.Properties.Value = row["Malzeme Adı"];
            //rowIcerik.Properties.Value = row["İçerik"];
            rowRenkKodu.Properties.Value = row["RENKKOD"];
            rowRenkAdı.Properties.Value = row["Renk"];
            //rowMRecete.Properties.Value = row["MamülReçeteNo"];
            //rowSRecete.Properties.Value = row["SiparişReçeteNo"];
            rowKullanıcı.Properties.Value = row["GIREN_KULLANICI"];
        }

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Elyaf":
                    break;
                case "Yarı Mamül":
                    break;
                case "İplik":
                    break;
                case "Tümü":
                    break;

            }
        }
    }
}