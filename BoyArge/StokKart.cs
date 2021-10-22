using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class StokKart : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static readonly string conString = "data source=192.168.109.2,1433; user id=arge; password=Arge*2020!; initial catalog=TEKSTIL_UYG_100921; Connection Timeout=1;";
        readonly public static SqlConnection con = new SqlConnection(conString);
        private readonly List<RepositoryItemLookUpEdit> lookups;

        private readonly List<string> alanAdlari = new List<string> { "GRUPKOD", "KDVORAN", "TIPKOD", "SKOD9", "LKOD8", "LKOD9", "OZELKOD", "BIRIM", "MKOD1", "MKOD2",
            "MKOD5", "MKOD7", "MKOD6", "MKOD8", "MKOD9", "SKOD1", "SKOD2", "SKOD3", "SKOD4", "SKOD5", "SKOD6" };

        private bool closing = false;

        public StokKart()
        {
            InitializeComponent();
            con.Open();
            lookups = new List<RepositoryItemLookUpEdit> { lookupeditGrupKod, lookueditKDVOran, lookupeditUrunTip , lookupeditBolum , lookupeditStokGrupKod ,
                lookupeditDepoGrupKod , lookupEditUrunGrubu ,lookupeditBirim,lookupeditIplikKati,lookupeditIplikOlcuBirimi,lookupeditIplikOzelligi,
                lookupeditIplikEfekt,lookupeditIplikGorunum,lookupeditIplikTipi1,lookupeditIplikTip2,lookupeditElyafKod1,
                lookupeditElyafKod2,lookupeditElyafTanim1,lookupeditElyafTanim2,lookupeditElyafOzellik1,lookupeditElyafOzellik2};

            LoadSource();
        }

        private void LoadSource()
        {
            for (int i = 0; i < alanAdlari.Count; i++)
            {
                if (alanAdlari[i] == "BIRIM")
                {
                    string sql = "SELECT [Property] FROM[dbArge].[dbo].[tblParameters] WHERE TableName = 'CPM' AND Definition = 'Birimler'";
                    using (var d = Database.GetList(sql, con))
                    {
                        Format.LookUpEdit(lookups[i], new[] { "Property" }, "Property", "Property", d);
                    }
                }
                else
                {
                    using (var d = Database.GetList($"SELECT *  FROM [dbo].REFKRT WHERE TABLOAD = 'STKKRT' AND ALANAD = '{alanAdlari[i]}'", con))
                    {
                        Format.LookUpEdit(lookups[i], new[] { "ACIKLAMA" }, "ACIKLAMA", "KOD", d);
                    }
                }
            }

            string sqlCmd = "SELECT STKKRT.BIRIM, STKKRT.MALKOD, STKKRT.MALAD, STKKRT.ACIKLAMA1, STKKRT.ACIKLAMA2, STKKRT.ACIKLAMA4, STKKRT.DEGISTIRENKULLANICI," +
                " STKKRT.DEGISTIRENTARIH, STKKRT.GIRENKULLANICI," + " STKKRT.GIRENTARIH, STKKRT.GRUPKOD, STKKRT.LKOD8, STKKRT.LKOD9, STKKRT.MALAD2, STKKRT.MALKOD2," +
                " STKKRT.MHSSATISIADEKOD, STKKRT.MHSSATISKOD, STKKRT.MHSYURTDISISATISKOD, STKKRT.MKOD1, STKKRT.MKOD2," + " STKKRT.MKOD5, STKKRT.MKOD6, STKKRT.MKOD7," +
                " STKKRT.MKOD8, STKKRT.MKOD9, STKKRT.NKOD1, STKKRT.NKOD7, STKKRT.NKOD8, STKKRT.NKOD9, STKKRT.NOT1, STKKRT.NOT2, STKKRT.SKOD1, STKKRT.SKOD2, STKKRT.SKOD3," +
                " STKKRT.SKOD4, STKKRT.SKOD5, STKKRT.SKOD6, STKKRT.SKOD9 FROM dbo.STKKRT STKKRT WITH (NOLOCK) " +
                "LEFT OUTER JOIN dbo.CARKRT CRKURT WITH (NOLOCK) ON (  CRKURT.HESAPKOD = STKKRT.URETICIKOD ) " +
                "LEFT OUTER JOIN dbo.CARKRT CRKTMY WITH (NOLOCK) ON (  CRKTMY.HESAPKOD = STKKRT.TEMINYER ) " +
                "LEFT OUTER JOIN dbo.STKRES STKRES WITH(NOLOCK) ON(STKRES.MALKOD = STKKRT.MALKOD) WHERE STKKRT.MALTIP = 0 ORDER BY STKKRT.GRUPKOD ASC, STKKRT.MALKOD ASC";

            using (var d = Database.GetList(sqlCmd, con))
            {
                grdStokViewer.DataSource = d;
            }

            using (var d = Database.GetList("select ELYAFAD,ELYAFKOD from [dbo].TEXELF", con))
            {
                Format.LookUpEdit(lookupEditFinalCins, new[] { "ELYAFAD" }, "ELYAFAD", "ELYAFKOD", d);
                Format.LookUpEdit(lookupEditFitilCins, new[] { "ELYAFAD" }, "ELYAFAD", "ELYAFKOD", d);
            }

            DataTable dataSource = new DataTable();
            dataSource.Columns.Add("ELYAFCINSI");
            dataSource.Columns.Add("ELYAFORANI");
            gridKarisim.DataSource = dataSource.Clone();
            gridFitil.DataSource = dataSource.Clone();
        }

        private void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewRecord();
        }

        private void NewRecord()
        {
            foreach (var r in vGridStok.Rows)
            {
                if (!r.Name.StartsWith("category"))
                    r.Properties.Value = "";
            }
            foreach (var r in vGridOzel.Rows)
            {
                if (!r.Name.StartsWith("category"))
                    r.Properties.Value = "";
            }
            foreach (var r in vGridIplik.Rows)
            {
                if (!r.Name.StartsWith("category"))
                    r.Properties.Value = "";
            }
            foreach (var r in vGridElyaf.Rows)
            {
                if (!r.Name.StartsWith("category"))
                    r.Properties.Value = "";
            }
            foreach (var r in vGridMuhasebe.Rows)
            {
                if (!r.Name.StartsWith("category"))
                    r.Properties.Value = "";
            }

            if (rowGrupKodu.Properties.ReadOnly == true)
            {
                rowGrupKodu.Properties.Value = "01";
                CreateNewMamulKod();
            }
            checkFitil.Checked = false;
            checkTekKat.Checked = false;
            LoadSource();
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UnFocusRow(sender, e);

            if (CheckNull())
            {
                XtraMessageBox.Show("Lütfen Tüm Bilgileri Eksiksiz Doldurun!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (isSave())
                SaveRecord();
            else
                UpdateRecord();
        }

        private void CreateParamsForInsert(SqlCommand cmd)
        {
            SqlParameterCollection param = cmd.Parameters;
            {
                param.Add("@GRUPKOD", SqlDbType.VarChar);
                param.Add("@MALKOD", SqlDbType.VarChar);
                param.Add("@MALKOD2", SqlDbType.VarChar);
                param.Add("@URUNTANIM", SqlDbType.VarChar);
                param.Add("@MALAD", SqlDbType.VarChar);
                param.Add("@KDVORAN", SqlDbType.Decimal);
                param.Add("@TIPKOD", SqlDbType.VarChar);
                param.Add("@MALAD2", SqlDbType.VarChar);
                param.Add("@BOLUM", SqlDbType.VarChar);
                param.Add("@STOKGRUPKOD", SqlDbType.VarChar);
                param.Add("@DEPOGRUPKOD", SqlDbType.VarChar);
                param.Add("@KARISIMTIPLERI", SqlDbType.VarChar);
                param.Add("@FITILICERIK", SqlDbType.VarChar);
                param.Add("@FITILORANI", SqlDbType.Decimal);
                param.Add("@KARISIMORAN", SqlDbType.VarChar);
                param.Add("@URUNTANIMDP", SqlDbType.VarChar);
                param.Add("@ACIKLAMA1", SqlDbType.VarChar);
                param.Add("@ACIKLAMA2", SqlDbType.VarChar);
                param.Add("@URUNGRUP", SqlDbType.VarChar);
                param.Add("@URETICIYERI", SqlDbType.VarChar);
                param.Add("@TEKNIKAD", SqlDbType.VarChar);
                param.Add("@BIRIM", SqlDbType.VarChar);
                param.Add("@RIN", SqlDbType.Decimal);
                param.Add("@BIN", SqlDbType.Decimal);
                param.Add("@FIN", SqlDbType.Decimal);
                param.Add("@IPLIKNUM", SqlDbType.Decimal);
                param.Add("@IPLIKKAT", SqlDbType.VarChar);
                param.Add("@IPLIKOLCUBIRIMI", SqlDbType.VarChar);
                param.Add("@IPLIKOZL", SqlDbType.VarChar);
                param.Add("@IPLIKEFEKTOZL", SqlDbType.VarChar);
                param.Add("@IPLIKGORUNUM", SqlDbType.VarChar);
                param.Add("@IPLIKTIP1", SqlDbType.VarChar);
                param.Add("@IPLIKTIP2", SqlDbType.VarChar);
                param.Add("@ELYAFTANIM1", SqlDbType.VarChar);
                param.Add("@ELYAFTANIM2", SqlDbType.VarChar);
                param.Add("@ELYAFOZL1", SqlDbType.VarChar);
                param.Add("@ELYAFOZL2", SqlDbType.VarChar);
                param.Add("@ELYAFKOD1", SqlDbType.VarChar);
                param.Add("@ELYAFKOD2", SqlDbType.VarChar);
                param.Add("@ALIMLARHESABI", SqlDbType.VarChar);
                param.Add("@ALIMDANIADE", SqlDbType.VarChar);
                param.Add("@SATISLARHESABI", SqlDbType.VarChar);
                param.Add("@SATISTANIADE", SqlDbType.VarChar);
                param.Add("@SATISISK", SqlDbType.VarChar);
                param.Add("@YDSATISLAR", SqlDbType.VarChar);

                param["@GRUPKOD"].Value = GetRowValueWithCheck(rowGrupKodu);
                param["@MALKOD"].Value = GetRowValueWithCheck(rowMalKodu1);
                param["@MALKOD2"].Value = GetRowValueWithCheck(rowMalKodu2);
                param["@URUNTANIM"].Value = GetRowValueWithCheck(rowUrunTanimi);
                param["@MALAD"].Value = GetRowValueWithCheck(rowMalAdi);
                param["@KDVORAN"].Value = Convert.ToDecimal(18);
                param["@TIPKOD"].Value = GetRowValueWithCheck(rowUrunTipi);
                param["@MALAD2"].Value = GetRowValueWithCheck(rowUrunTanimi);
                param["@BOLUM"].Value = GetRowValueWithCheck(rowBolum);
                param["@STOKGRUPKOD"].Value = GetRowValueWithCheck(rowStockGrupKodu);
                param["@DEPOGRUPKOD"].Value = GetRowValueWithCheck(rowDepoGrupKodu);
                param["@KARISIMTIPLERI"].Value = GetRowValueWithCheck(rowKarisimTipleri);
                param["@FITILICERIK"].Value = GetRowValueWithCheck(rowFitilIcerik);
                param["@FITILORANI"].Value = Convert.ToDecimal(GetRowValueWithCheck(rowFitilOran) == "" ? "0" : GetRowValueWithCheck(rowFitilOran));
                param["@KARISIMORAN"].Value = GetRowValueWithCheck(rowKarisimOranlari);
                param["@URUNTANIMDP"].Value = GetRowValueWithCheck(rowUrunTanimiDIS);
                param["@ACIKLAMA1"].Value = GetRowValueWithCheck(rowAciklama1);
                param["@ACIKLAMA2"].Value = GetRowValueWithCheck(rowAciklama2);
                param["@URUNGRUP"].Value = GetRowValueWithCheck(rowUrunGrubu);
                param["@URETICIYERI"].Value = GetRowValueWithCheck(rowUreticiYeri);
                param["@TEKNIKAD"].Value = GetRowValueWithCheck(rowTeknikAdi);
                param["@BIRIM"].Value = GetRowValueWithCheck(rowBirim);
                param["@RIN"].Value = Convert.ToDecimal(GetRowValueWithCheck(rowRingNo) == "" ? "0" : GetRowValueWithCheck(rowRingNo));
                param["@BIN"].Value = Convert.ToDecimal(GetRowValueWithCheck(rowBin) == "" ? "0" : GetRowValueWithCheck(rowBin));
                param["@FIN"].Value = Convert.ToDecimal(GetRowValueWithCheck(rowFin) == "" ? "0" : GetRowValueWithCheck(rowFin));
                param["@IPLIKNUM"].Value = Convert.ToDecimal(GetRowValueWithCheck(rowIplikNumarasi) == "" ? "0" : GetRowValueWithCheck(rowIplikNumarasi));
                param["@IPLIKKAT"].Value = GetRowValueWithCheck(rowIplikKati);
                param["@IPLIKOLCUBIRIMI"].Value = GetRowValueWithCheck(rowIplikOlcuBirimi);
                param["@IPLIKOZL"].Value = GetRowValueWithCheck(rowIplikOzelligi);
                param["@IPLIKEFEKTOZL"].Value = GetRowValueWithCheck(rowIplikEfekt);
                param["@IPLIKGORUNUM"].Value = GetRowValueWithCheck(rowIplikGorunum);
                param["@IPLIKTIP1"].Value = GetRowValueWithCheck(rowIplikTip1);
                param["@IPLIKTIP2"].Value = GetRowValueWithCheck(rowIplikTip2);
                param["@ELYAFTANIM1"].Value = GetRowValueWithCheck(rowElyafTanim1);
                param["@ELYAFTANIM2"].Value = GetRowValueWithCheck(rowElyafTanim2);
                param["@ELYAFOZL1"].Value = GetRowValueWithCheck(rowElyafOzellik1);
                param["@ELYAFOZL2"].Value = GetRowValueWithCheck(rowElyafOzellik2);
                param["@ELYAFKOD1"].Value = GetRowValueWithCheck(rowElyafKod1);
                param["@ELYAFKOD2"].Value = GetRowValueWithCheck(rowELyafKod2);
                param["@ALIMLARHESABI"].Value = GetRowValueWithCheck(rowAlimlarHesabi);
                param["@ALIMDANIADE"].Value = GetRowValueWithCheck(rowAlimdanIadeHEsabi);
                param["@SATISLARHESABI"].Value = GetRowValueWithCheck(rowSatislarHesabi);
                param["@SATISTANIADE"].Value = GetRowValueWithCheck(rowSatistanIadeHesabi);
                param["@SATISISK"].Value = GetRowValueWithCheck(rowSatisIskHesabi);
                param["@YDSATISLAR"].Value = GetRowValueWithCheck(rowYDSatislarHesabi);

                foreach (SqlParameter p in param)
                {
                    p.Direction = ParameterDirection.Input;
                }
            }
        }

        private bool isSave()
        {
            using (var d = Database.GetList($"select * from [dbo].STKKRT WHERE MALKOD = '{GetRowValueWithCheck(rowMalKodu1)}'", con))
            {
                if (d == null || d.Rows.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        private void SaveRecord()
        {
            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) != DialogResult.Yes) return;

            SqlCommand cmd = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("TranStokKartInsert");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[SPARGE_STKKRT_INSERT]";
            cmd.Transaction = transaction;

            try
            {
                CreateParamsForInsert(cmd);
                cmd.ExecuteNonQuery();
                InsertTEXSKR(transaction, "Fitil");
                InsertTEXSKR(transaction, "Final");
                if (checkFitil.Checked || checkTekKat.Checked)
                {
                    AutoInsertSTKKRT(transaction);
                }
                transaction.Commit();
                XtraMessageBox.Show(Resources.InsertInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                XtraMessageBox.Show(e.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private void AutoInsertSTKKRT(SqlTransaction transaction)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[AUTO_STKKRT_INSERT]";
            cmd.Transaction = transaction;

            cmd.Parameters.Add("@CHECK_TEKKAT", SqlDbType.Int);
            cmd.Parameters["@CHECK_TEKKAT"].Direction = ParameterDirection.Input;
            cmd.Parameters["@CHECK_TEKKAT"].Value = checkTekKat.Checked ? 1 : 0;

            cmd.Parameters.Add("@CHECK_FITIL", SqlDbType.Int);
            cmd.Parameters["@CHECK_FITIL"].Direction = ParameterDirection.Input;
            cmd.Parameters["@CHECK_FITIL"].Value = checkFitil.Checked ? 1 : 0;

            cmd.Parameters.Add("@ANAMALKOD", SqlDbType.VarChar);
            cmd.Parameters["@ANAMALKOD"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ANAMALKOD"].Value = GetRowValueWithCheck(rowMalKodu1);

            cmd.ExecuteNonQuery();
        }

        private void UpdateRecord()
        {
            if (XtraMessageBox.Show(Resources.QuestionUpdate, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            SqlCommand cmd = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("TranStokKartInsert");

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[SPARGE_STKKRT_UPDATE]";
            cmd.Transaction = transaction;
            try
            {
                CreateParamsForInsert(cmd);
                cmd.ExecuteNonQuery();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM TEXSKR where MALKOD = '{GetRowValueWithCheck(rowMalKodu1)}'";
                cmd.ExecuteNonQuery();
                InsertTEXSKR(transaction, "Fitil");
                InsertTEXSKR(transaction, "Final");
                transaction.Commit();
                XtraMessageBox.Show(Resources.UpdateInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                XtraMessageBox.Show(e.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private void InsertTEXSKR(SqlTransaction transaction, string type)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[SPARGE_TEXSKR_INSERT]";
            cmd.Transaction = transaction;

            cmd.Parameters.Add("@MALKOD", SqlDbType.VarChar);
            cmd.Parameters["@MALKOD"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add("@ELYAFCINS", SqlDbType.VarChar);
            cmd.Parameters["@ELYAFCINS"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add("@ELYAFORAN", SqlDbType.Real);
            cmd.Parameters["@ELYAFORAN"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add("@URUNTIPI", SqlDbType.VarChar);
            cmd.Parameters["@URUNTIPI"].Direction = ParameterDirection.Input;

            try
            {
                DataView dv = type == "Fitil" ? gridViewFitil.DataSource as DataView : gridViewKarisim.DataSource as DataView;
                DataTable dt = dv.ToTable();
                foreach (DataRow row in dt.Rows)
                {
                    cmd.Parameters["@MALKOD"].Value = GetRowValueWithCheck(rowMalKodu1);
                    cmd.Parameters["@ELYAFCINS"].Value = Utility.ToDBNull(row.ItemArray[0]);
                    cmd.Parameters["@ELYAFORAN"].Value = Utility.ToDBNull(row.ItemArray[1]);
                    cmd.Parameters["@URUNTIPI"].Value = type == "Fitil" ? 0 : 1;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            string malKod = xtraTabControl1.SelectedTabPage.Name == "tabPageStok" ? GetRowValueWithCheck(rowMalKodu1) : gridView2.GetFocusedRowCellValue("MALKOD").ToString();
            SqlCommand cmd = con.CreateCommand();
            SqlTransaction transaction = con.BeginTransaction("DELETE_STKKRT");
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            cmd.CommandText = $"DELETE FROM [dbo].STKKRT WHERE MALKOD = '{malKod}'";
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"DELETE FROM TEXSKR WHERE MALKOD = '{malKod}'";
                cmd.ExecuteNonQuery();
                LoadSource();
                if (xtraTabControl1.SelectedTabPage.Name == "tabPageStok")
                    NewRecord();
                transaction.Commit();
                XtraMessageBox.Show(Resources.DeleteInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException)
            {
                transaction.Rollback();
                XtraMessageBox.Show("Stoka Bağlı Hareketler Bulunmaktadır, Stok Silinemez!!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private void UnFocusRow(object sender, EventArgs e)
        {
            vGridStok.PostEditor();
            vGridElyaf.PostEditor();
            vGridIplik.PostEditor();
            vGridMuhasebe.PostEditor();
            gridViewKarisim.PostEditor();
            gridViewFitil.PostEditor();

            checkFitil.Enabled = false;
            checkTekKat.Enabled = false;

            if (GetRowValueWithCheck(rowGrupKodu) == "01") // Iplik
            {
                rowMalAdi.Properties.Value = GetRowValueWithCheck(rowUrunTanimi) + " " + GetRowValueWithCheck(rowIplikOlcuBirimi) + " " +
                                             GetRowValueWithCheck(rowIplikNumarasi) + "/" + GetRowValueWithCheck(rowIplikKati);

                if (GetRowValueWithCheck(rowBolum) != "03") // DIS ALIM
                    checkFitil.Enabled = true;
                checkTekKat.Enabled = true;
            }
            checkFitil.Checked = checkFitil.Enabled && checkFitil.Checked;
            checkTekKat.Checked = checkTekKat.Enabled && checkTekKat.Checked;
        }

        private string GetRowValueWithCheck(EditorRow row)
        {
            if (!closing)
            {
                try
                {
                    return row.Properties.Value == null ? "" : row.Properties.Value.ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }
            return "";
        }

        public void CreateNewMamulKod()
        {
            string type;

            switch (GetRowValueWithCheck(rowGrupKodu))
            {
                case "01":
                    type = "IPL";
                    break;

                case "02":
                    type = "ELF";
                    break;

                case "03":
                    type = "BOY";
                    break;

                case "04":
                    type = "KIM";
                    break;

                case "09":
                    type = "YAM";
                    break;

                case "11":
                    type = "TPS";
                    break;

                default:
                    type = "";
                    break;
            }
            string sqlCmd = "SELECT ISNULL(MAX(SUBSTRING(MALKOD,4,4)),0)+1 as SIRANO FROM [dbo].STKKRT WITH (NOLOCK) " +
                "WHERE SIRKETNO='B01' AND MALTIP=0 AND SUBSTRING(MALKOD,1,3)=" + "'" + type + "'";

            using (var d = Database.GetList(sqlCmd, con))
            {
                if (d != null)
                {
                    rowMalKodu1.Properties.Value = type + d.Rows[0].ItemArray[0].ToString();
                    rowMalKodu1.Properties.ReadOnly = true;
                }
                else
                {
                    rowMalKodu1.Properties.Value = "";
                    rowMalKodu1.Properties.ReadOnly = false;
                }
            }
        }

        private void lookupeditGrupKod_Leave(object sender, EventArgs e)
        {
            CreateNewMamulKod();
        }

        private bool CheckNull()
        {
            if (GetRowValueWithCheck(rowMalKodu1) == "") return true;
            if (GetRowValueWithCheck(rowMalAdi) == "") return true;
            if (GetRowValueWithCheck(rowIplikNumarasi) == "") return true;
            if (GetRowValueWithCheck(rowRingNo) == "") return true;
            if (GetRowValueWithCheck(rowIplikKati) == "") return true;
            if (GetRowValueWithCheck(rowIplikTip1) == "") return true;
            if (GetRowValueWithCheck(rowUrunTanimi) == "") return true;

            DataView dv = gridViewKarisim.DataSource as DataView;
            DataTable dt = dv.ToTable();
            foreach (DataRow row in dt.Rows)
            {
                if (row.ItemArray[0].ToString() == "" || row.ItemArray[1].ToString() == "")
                {
                    return true;
                }
            }
            DataView dv2 = gridViewFitil.DataSource as DataView;
            DataTable dt2 = dv2.ToTable();
            foreach (DataRow row in dt2.Rows)
            {
                if (row.ItemArray[0].ToString() == "" || row.ItemArray[1].ToString() == "")
                {
                    return true;
                }
            }

            return false;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadSource();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridView2.GetFocusedDataRow();

            if (row["MALKOD"].ToString().StartsWith("IPL") || row["MALKOD"].ToString().StartsWith("IP"))
                rowGrupKodu.Properties.Value = "01";
            else if (row["MALKOD"].ToString().StartsWith("ELF") || row["MALKOD"].ToString().StartsWith("EL"))
                rowGrupKodu.Properties.Value = "02";
            else if (row["MALKOD"].ToString().StartsWith("BOY") || row["MALKOD"].ToString().StartsWith("BO"))
                rowGrupKodu.Properties.Value = "03";
            else if (row["MALKOD"].ToString().StartsWith("KIM") || row["MALKOD"].ToString().StartsWith("KI"))
                rowGrupKodu.Properties.Value = "04";
            else if (row["MALKOD"].ToString().StartsWith("YMM") || row["MALKOD"].ToString().StartsWith("YAM"))
                rowGrupKodu.Properties.Value = "09";
            else if (row["MALKOD"].ToString().StartsWith("TPS") || row["MALKOD"].ToString().StartsWith("TP"))
                rowGrupKodu.Properties.Value = "11";

            rowMalKodu1.Properties.Value = row["MALKOD"];
            rowMalKodu2.Properties.Value = row["MALKOD2"];
            rowMalAdi.Properties.Value = row["MALAD"];

            rowUrunTanimi.Properties.Value = row["MALAD2"];
            rowUrunTanimiIC.Properties.Value = row["ACIKLAMA4"];

            rowAciklama1.Properties.Value = row["ACIKLAMA1"];
            rowFitilIcerik.Properties.Value = row["ACIKLAMA2"];

            rowBolum.Properties.Value = row["SKOD9"];
            rowStockGrupKodu.Properties.Value = row["LKOD8"];
            rowDepoGrupKodu.Properties.Value = row["LKOD9"];
            rowKarisimTipleri.Properties.Value = row["NOT2"];
            rowKarisimOranlari.Properties.Value = row["NOT1"];

            rowBirim.Properties.Value = row["BIRIM"];

            rowRingNo.Properties.Value = row["NKOD7"];
            rowBin.Properties.Value = row["NKOD8"];
            rowFin.Properties.Value = row["NKOD9"];

            rowIplikNumarasi.Properties.Value = row["NKOD1"];
            rowIplikKati.Properties.Value = row["MKOD1"];
            rowIplikOlcuBirimi.Properties.Value = row["MKOD2"];
            rowIplikOzelligi.Properties.Value = row["MKOD5"];
            rowIplikEfekt.Properties.Value = row["MKOD7"];
            rowIplikGorunum.Properties.Value = row["MKOD6"];
            rowIplikTip1.Properties.Value = row["MKOD8"];
            rowIplikTip2.Properties.Value = row["MKOD9"];

            rowElyafKod1.Properties.Value = row["SKOD1"];
            rowELyafKod2.Properties.Value = row["SKOD2"];
            rowElyafTanim1.Properties.Value = row["SKOD3"];
            rowElyafTanim2.Properties.Value = row["SKOD4"];
            rowElyafOzellik1.Properties.Value = row["SKOD5"];
            rowElyafOzellik2.Properties.Value = row["SKOD6"];

            rowSatislarHesabi.Properties.Value = row["MHSSATISKOD"];
            rowSatistanIadeHesabi.Properties.Value = row["MHSSATISIADEKOD"];
            rowYDSatislarHesabi.Properties.Value = row["MHSYURTDISISATISKOD"];

            using (var d = Database.GetList($"select ELYAFCINS [ELYAFCINSI], ELYAFORAN [ELYAFORANI] from [dbo].TEXSKR where MALKOD = '{row["MALKOD"]}'", con))
            {
                gridKarisim.DataSource = d;
            }

            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[0];
        } // Decide which field is for what

        private void StokKart_Load(object sender, EventArgs e)
        {
            rowBirim.Properties.Value = "KG";
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFitilOran.Text))
                return;

            ((DataTable)gridKarisim.DataSource).Clear();

            foreach (DataRow row in ((DataTable)gridFitil.DataSource).Rows)
            {
                if (row["ELYAFCINSI"] == null || row["ELYAFORANI"] == null)
                    continue;

                rowFitilOran.Properties.Value = txtFitilOran.Text;
                rowFitilOran.Properties.ReadOnly = true;

                DataRow newRow = ((DataTable)gridKarisim.DataSource).NewRow();

                newRow.ItemArray = row.ItemArray.Clone() as object[];

                newRow["ELYAFORANI"] = Convert.ToDouble(newRow["ELYAFORANI"].ToString()) * Convert.ToDouble(txtFitilOran.Text) / 100;

                ((DataTable)gridKarisim.DataSource).Rows.Add(newRow);
            }
        }

        private void gridViewFitil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridViewKarisim.DeleteRow(gridViewKarisim.GetFocusedDataSourceRowIndex());
            }
        }

        private void gridViewKarisim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridViewKarisim.DeleteRow(gridViewKarisim.GetFocusedDataSourceRowIndex());
            }
        }

        private void gridViewFitil_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataView dv = gridViewFitil.DataSource as DataView;
            DataTable dt = dv.ToTable();
            rowFitilIcerik.Properties.Value = "";
            foreach (DataRow row in dt.Rows)
            {
                rowFitilIcerik.Properties.Value += "%" + row.ItemArray[1].ToString() + lookupEditFinalCins.GetDisplayValueByKeyValue(row.ItemArray[0].ToString()) + "+";
            }
            rowFitilIcerik.Properties.Value = rowFitilIcerik.Properties.Value.ToString().Remove(rowFitilIcerik.Properties.Value.ToString().LastIndexOf("+"));
        }

        private void ConcatenateStringKarisim()
        {
            DataView dv = gridViewKarisim.DataSource as DataView;
            DataTable dt = dv.ToTable();
            if (dt.Rows.Count == 0) return;
            rowKarisimTipleri.Properties.Value = "";
            rowKarisimOranlari.Properties.Value = "";
            foreach (DataRow row in dt.Rows)
            {
                rowKarisimTipleri.Properties.Value += lookupEditFinalCins.GetDisplayValueByKeyValue(row.ItemArray[0].ToString()) + "+";
                rowKarisimOranlari.Properties.Value += "%" + row.ItemArray[1].ToString() + lookupEditFinalCins.GetDisplayValueByKeyValue(row.ItemArray[0].ToString()) + "+";
            }
            rowKarisimTipleri.Properties.Value = rowKarisimTipleri.Properties.Value.ToString().Remove(rowKarisimTipleri.Properties.Value.ToString().LastIndexOf("+"));
            rowKarisimOranlari.Properties.Value = rowKarisimOranlari.Properties.Value.ToString().Remove(rowKarisimOranlari.Properties.Value.ToString().LastIndexOf("+"));
        }

        private void gridViewKarisim_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ConcatenateStringKarisim();
        }

        private void gridViewKarisim_RowCountChanged(object sender, EventArgs e)
        {
            ConcatenateStringKarisim();
        }

        private void StokKart_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            con.Close();
            con.Dispose();
            DialogResult = DialogResult.OK;
        }
    }
}