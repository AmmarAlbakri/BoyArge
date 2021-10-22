using System;
using System.Data;
using System.Data.SqlClient;

namespace BoyArge
{
    internal class Operasyonlar
    {
        public DataTable Mamul()
        {
            string sqlQuery = "SELECT MALKOD, MALTIP, STKKRT.ACIKLAMA4, STKKRT.ACIKLAMA5, GRUPKOD.ACIKLAMA AS GRUPKOD, " +
                              "LKOD8, LKOD9, MALAD, MALAD2, MKOD1, MKOD2, MKOD5.ACIKLAMA AS MKOD5, MKOD6.ACIKLAMA AS MKOD6, " +
                              "MKOD7.ACIKLAMA AS MKOD7, MKOD8.ACIKLAMA AS MKOD8, MKOD9.ACIKLAMA AS MKOD9, NKOD1, NOT1, NOT2, " +
                              "STKKRT.OZELKOD, SKOD1, SKOD2, SKOD3, SKOD4, SKOD5, SKOD6, SKOD9, TIPKOD.ACIKLAMA AS TIPKOD FROM " +
                              "dbo.STKKRT STKKRT WITH(NOLOCK) " +
                              "LEFT JOIN REFKRT MKOD8 ON MKOD8.TABLOAD = 'STKKRT' AND MKOD8.ALANAD = 'MKOD8' AND MKOD8.KOD = STKKRT.MKOD8 " +
                              "LEFT JOIN REFKRT MKOD5 ON MKOD5.TABLOAD = 'STKKRT' AND MKOD5.ALANAD = 'MKOD5' AND MKOD5.KOD = STKKRT.MKOD5 " +
                              "LEFT JOIN REFKRT MKOD6 ON MKOD6.TABLOAD = 'STKKRT' AND MKOD6.ALANAD = 'MKOD6' AND MKOD6.KOD = STKKRT.MKOD6 " +
                              "LEFT JOIN REFKRT TIPKOD ON TIPKOD.TABLOAD = 'STKKRT' AND TIPKOD.ALANAD = 'TIPKOD' AND TIPKOD.KOD = STKKRT.TIPKOD " +
                              "LEFT JOIN REFKRT GRUPKOD ON GRUPKOD.TABLOAD = 'STKKRT' AND GRUPKOD.ALANAD = 'GRUPKOD' AND GRUPKOD.KOD = STKKRT.GRUPKOD " +
                              "LEFT JOIN REFKRT MKOD7 ON MKOD7.TABLOAD = 'STKKRT' AND MKOD7.ALANAD = 'MKOD7' AND MKOD7.KOD = STKKRT.MKOD7 " +
                              "LEFT JOIN REFKRT MKOD9 ON MKOD9.TABLOAD = 'STKKRT' AND MKOD9.ALANAD = 'MKOD9' AND MKOD9.KOD = STKKRT.MKOD9 " +
                              "WHERE STKKRT.GRUPKOD = '01' AND SIRKETNO = 'B01' AND MALTIP = 0";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, FormPlanlama.con);
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt);
            return dt;
        }

        public DataTable YariMamul()
        {
            //string sqlQuery = "SELECT MALKOD, MALTIP, ACIKLAMA4,   ACIKLAMA5,   GRUPKOD,   LKOD8,   LKOD9,   MALAD,   MALAD2,   MKOD1,   MKOD2,   MKOD5," +
            //    " MKOD6,   MKOD7,   MKOD8,   MKOD9,   NKOD1,   NOT1,   NOT2,   OZELKOD,   SKOD1,   SKOD2,   SKOD3,   SKOD4,   SKOD5,   SKOD6,   SKOD9," +
            //    " TIPKOD FROM dbo.STKKRT STKKRT WITH(NOLOCK) WHERE GRUPKOD = '09' AND SIRKETNO = 'B01' AND MALTIP = 0";
            string sqlQuery = "SELECT MALKOD, MALTIP, STKKRT.ACIKLAMA4, STKKRT.ACIKLAMA5, GRUPKOD.ACIKLAMA AS GRUPKOD, " +
                  "LKOD8, LKOD9, MALAD, MALAD2, MKOD1, MKOD2, MKOD5.ACIKLAMA AS MKOD5, MKOD6.ACIKLAMA AS MKOD6, " +
                  "MKOD7.ACIKLAMA AS MKOD7, MKOD8.ACIKLAMA AS MKOD8, MKOD9.ACIKLAMA AS MKOD9, NKOD1, NOT1, NOT2, " +
                  "STKKRT.OZELKOD, SKOD1, SKOD2, SKOD3, SKOD4, SKOD5, SKOD6, SKOD9, TIPKOD.ACIKLAMA AS TIPKOD FROM " +
                  "dbo.STKKRT STKKRT WITH(NOLOCK) " +
                  "LEFT JOIN REFKRT MKOD8 ON MKOD8.TABLOAD = 'STKKRT' AND MKOD8.ALANAD = 'MKOD8' AND MKOD8.KOD = STKKRT.MKOD8 " +
                  "LEFT JOIN REFKRT MKOD5 ON MKOD5.TABLOAD = 'STKKRT' AND MKOD5.ALANAD = 'MKOD5' AND MKOD5.KOD = STKKRT.MKOD5 " +
                  "LEFT JOIN REFKRT MKOD6 ON MKOD6.TABLOAD = 'STKKRT' AND MKOD6.ALANAD = 'MKOD6' AND MKOD6.KOD = STKKRT.MKOD6 " +
                  "LEFT JOIN REFKRT TIPKOD ON TIPKOD.TABLOAD = 'STKKRT' AND TIPKOD.ALANAD = 'TIPKOD' AND TIPKOD.KOD = STKKRT.TIPKOD " +
                  "LEFT JOIN REFKRT GRUPKOD ON GRUPKOD.TABLOAD = 'STKKRT' AND GRUPKOD.ALANAD = 'GRUPKOD' AND GRUPKOD.KOD = STKKRT.GRUPKOD " +
                  "LEFT JOIN REFKRT MKOD7 ON MKOD7.TABLOAD = 'STKKRT' AND MKOD7.ALANAD = 'MKOD7' AND MKOD7.KOD = STKKRT.MKOD7 " +
                  "LEFT JOIN REFKRT MKOD9 ON MKOD9.TABLOAD = 'STKKRT' AND MKOD9.ALANAD = 'MKOD9' AND MKOD9.KOD = STKKRT.MKOD9 " +
                  "WHERE STKKRT.GRUPKOD = '09' AND SIRKETNO = 'B01' AND MALTIP = 0";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, FormPlanlama.con);
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt);
            return dt;
        }

        public DataTable Elyaf()
        {
            string sqlQuery = "SELECT MALKOD, MALTIP, STKKRT.ACIKLAMA4, STKKRT.ACIKLAMA5, GRUPKOD.ACIKLAMA AS GRUPKOD, " +
                "LKOD8, LKOD9, MALAD, MALAD2, MKOD1, MKOD2, MKOD5.ACIKLAMA AS MKOD5, MKOD6.ACIKLAMA AS MKOD6, " +
                "MKOD7.ACIKLAMA AS MKOD7, MKOD8.ACIKLAMA AS MKOD8, MKOD9.ACIKLAMA AS MKOD9, NKOD1, NOT1, NOT2, " +
                "STKKRT.OZELKOD, SKOD1, SKOD2, SKOD3, SKOD4, SKOD5, SKOD6, SKOD9, TIPKOD.ACIKLAMA AS TIPKOD FROM " +
                "dbo.STKKRT STKKRT WITH(NOLOCK) " +
                "LEFT JOIN REFKRT MKOD8 ON MKOD8.TABLOAD = 'STKKRT' AND MKOD8.ALANAD = 'MKOD8' AND MKOD8.KOD = STKKRT.MKOD8 " +
                "LEFT JOIN REFKRT MKOD5 ON MKOD5.TABLOAD = 'STKKRT' AND MKOD5.ALANAD = 'MKOD5' AND MKOD5.KOD = STKKRT.MKOD5 " +
                "LEFT JOIN REFKRT MKOD6 ON MKOD6.TABLOAD = 'STKKRT' AND MKOD6.ALANAD = 'MKOD6' AND MKOD6.KOD = STKKRT.MKOD6 " +
                "LEFT JOIN REFKRT TIPKOD ON TIPKOD.TABLOAD = 'STKKRT' AND TIPKOD.ALANAD = 'TIPKOD' AND TIPKOD.KOD = STKKRT.TIPKOD " +
                "LEFT JOIN REFKRT GRUPKOD ON GRUPKOD.TABLOAD = 'STKKRT' AND GRUPKOD.ALANAD = 'GRUPKOD' AND GRUPKOD.KOD = STKKRT.GRUPKOD " +
                "LEFT JOIN REFKRT MKOD7 ON MKOD7.TABLOAD = 'STKKRT' AND MKOD7.ALANAD = 'MKOD7' AND MKOD7.KOD = STKKRT.MKOD7 " +
                "LEFT JOIN REFKRT MKOD9 ON MKOD9.TABLOAD = 'STKKRT' AND MKOD9.ALANAD = 'MKOD9' AND MKOD9.KOD = STKKRT.MKOD9 " +
                "WHERE STKKRT.GRUPKOD = '02' AND SIRKETNO = 'B01' AND MALTIP = 0";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, FormPlanlama.con);
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt);
            return dt;
        }

        public DataTable Tumu()
        {
            string sqlQuery = "SELECT MALKOD, MALTIP, STKKRT.ACIKLAMA4, STKKRT.ACIKLAMA5, GRUPKOD.ACIKLAMA AS GRUPKOD, " +
                              "LKOD8, LKOD9, MALAD, MALAD2, MKOD1, MKOD2, MKOD5.ACIKLAMA AS MKOD5, MKOD6.ACIKLAMA AS MKOD6, " +
                              "MKOD7.ACIKLAMA AS MKOD7, MKOD8.ACIKLAMA AS MKOD8, MKOD9.ACIKLAMA AS MKOD9, NKOD1, NOT1, NOT2, " +
                              "STKKRT.OZELKOD, SKOD1, SKOD2, SKOD3, SKOD4, SKOD5, SKOD6, SKOD9, TIPKOD.ACIKLAMA AS TIPKOD FROM " +
                              "dbo.STKKRT STKKRT WITH(NOLOCK) " +
                              "LEFT JOIN REFKRT MKOD8 ON MKOD8.TABLOAD = 'STKKRT' AND MKOD8.ALANAD = 'MKOD8' AND MKOD8.KOD = STKKRT.MKOD8 " +
                              "LEFT JOIN REFKRT MKOD5 ON MKOD5.TABLOAD = 'STKKRT' AND MKOD5.ALANAD = 'MKOD5' AND MKOD5.KOD = STKKRT.MKOD5 " +
                              "LEFT JOIN REFKRT MKOD6 ON MKOD6.TABLOAD = 'STKKRT' AND MKOD6.ALANAD = 'MKOD6' AND MKOD6.KOD = STKKRT.MKOD6 " +
                              "LEFT JOIN REFKRT TIPKOD ON TIPKOD.TABLOAD = 'STKKRT' AND TIPKOD.ALANAD = 'TIPKOD' AND TIPKOD.KOD = STKKRT.TIPKOD " +
                              "LEFT JOIN REFKRT GRUPKOD ON GRUPKOD.TABLOAD = 'STKKRT' AND GRUPKOD.ALANAD = 'GRUPKOD' AND GRUPKOD.KOD = STKKRT.GRUPKOD " +
                              "LEFT JOIN REFKRT MKOD7 ON MKOD7.TABLOAD = 'STKKRT' AND MKOD7.ALANAD = 'MKOD7' AND MKOD7.KOD = STKKRT.MKOD7 " +
                              "LEFT JOIN REFKRT MKOD9 ON MKOD9.TABLOAD = 'STKKRT' AND MKOD9.ALANAD = 'MKOD9' AND MKOD9.KOD = STKKRT.MKOD9 " +
                              "WHERE (STKKRT.GRUPKOD = '01' OR STKKRT.GRUPKOD = '02' OR STKKRT.GRUPKOD = '09') AND SIRKETNO = 'B01' AND MALTIP = 0 " +
                              "ORDER BY STKKRT.GRUPKOD";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, FormPlanlama.con);
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt);
            return dt;
        }

        //Kaldırılan kodlar.
        #region

        public static int InsertTEXMRB(//ref object TEXMRBID,
            object receteNo, object mamulKod, object renkDurum,
            object boyamaSekli, object aciklama1, object girenKullanici, object girenSurum, object degistirenKullanici,
            object degistirenSurum, SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = "[dbo].[spTEXMRB_insert]";
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@ID", SqlDbType.Int);
                //cmd.Parameters["@ID"].Value = Convert.ToInt32( TEXMRBID);
                //cmd.Parameters["@ID"].Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add("@RECETENO", SqlDbType.Int);
                cmd.Parameters["@RECETENO"].Value = Convert.ToInt32(receteNo);
                cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MAMULKOD", SqlDbType.Int);
                cmd.Parameters["@MAMULKOD"].Value = Convert.ToInt32(mamulKod);
                cmd.Parameters["@MAMULKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKDURUM", SqlDbType.VarChar);
                cmd.Parameters["@RENKDURUM"].Value = renkDurum.ToString();
                cmd.Parameters["@RENKDURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BOYAMASEKLI", SqlDbType.VarChar);
                cmd.Parameters["@BOYAMASEKLI"].Value = boyamaSekli.ToString();
                cmd.Parameters["@BOYAMASEKLI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ACIKLAMA1", SqlDbType.VarChar);
                cmd.Parameters["@ACIKLAMA1"].Value = aciklama1.ToString();
                cmd.Parameters["@ACIKLAMA1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENKULLANICI", SqlDbType.VarChar);
                cmd.Parameters["@GIRENKULLANICI"].Value = girenKullanici.ToString();
                cmd.Parameters["@GIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENSURUM", SqlDbType.VarChar);
                cmd.Parameters["@GIRENSURUM"].Value = girenSurum.ToString();
                cmd.Parameters["@GIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENKULLANICI", SqlDbType.VarChar);
                cmd.Parameters["@DEGISTIRENKULLANICI"].Value = degistirenKullanici;
                cmd.Parameters["@DEGISTIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENSURUM", SqlDbType.VarChar);
                cmd.Parameters["@DEGISTIRENSURUM"].Value = degistirenSurum.ToString();
                cmd.Parameters["@DEGISTIRENSURUM"].Direction = ParameterDirection.Input;

                //Common.AddLog(ref cmd, Utility.ToLong(UserID), Utility.ToGuid(RowGUID), true, true);

                cmd.Parameters.Add("@Result", SqlDbType.Int);
                cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                //TEXMRBID = cmd.Parameters["@ID"].Value;

                return (int)cmd.Parameters["@Result"].Value;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        //Fire = NKOD2, İplik Katı = NKOD1, Renk Adı = TEXRAH_RENKAD, Boyahane İşlemi = BKOD1, Siparişte Göster = BKOD3, Üretim Yeri BKOD4, Lot = MKOD1
        //Maladı = STTKRT_MALAD

        public int InsertTEXMRH(object satirTip, object malKod, object aciklama2, object miktar, object fire,
            object iplikKati, object renkKod, object boyahane_islemi, object aciklama3, object siparisteGoster,
            object uretimYeri, object lotNumarasi, object aciklama1, SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = "[dbo].[spTEXMRH_insert]";
                cmd.CommandType = CommandType.StoredProcedure;
                //@MALKOD
                cmd.Parameters.Add("@SATIRTIP", SqlDbType.Int);
                cmd.Parameters["@SATIRTIP"].Value = Convert.ToInt32(satirTip);
                cmd.Parameters["@SATIRTIP"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MALKOD", SqlDbType.VarChar);
                cmd.Parameters["@MALKOD"].Value = malKod.ToString();
                cmd.Parameters["@MALKOD"].Direction = ParameterDirection.Input;
                //@ACIKLAMA2
                cmd.Parameters.Add("@ACIKLAMA2", SqlDbType.VarChar);
                cmd.Parameters["@ACIKLAMA2"].Value = aciklama2.ToString();
                cmd.Parameters["@ACIKLAMA2"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MIKTAR", SqlDbType.Int);
                cmd.Parameters["@MIKTAR"].Value = Convert.ToInt32(miktar);
                cmd.Parameters["@MIKTAR"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@NKOD2", SqlDbType.Int);
                cmd.Parameters["@NKOD2"].Value = Convert.ToInt32(fire);
                cmd.Parameters["@NKOD2"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@NKOD1", SqlDbType.Int);
                cmd.Parameters["@NKOD1"].Value = Convert.ToInt32(iplikKati);
                cmd.Parameters["@NKOD1"].Direction = ParameterDirection.Input;
                //@RENKKOD
                cmd.Parameters.Add("@RENKKOD", SqlDbType.VarChar);
                cmd.Parameters["@RENKKOD"].Value = renkKod.ToString();
                cmd.Parameters["@RENKKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BKOD1", SqlDbType.SmallInt);
                cmd.Parameters["@BKOD1"].Value = Convert.ToInt32(boyahane_islemi);
                cmd.Parameters["@BKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ACIKLAMA3", SqlDbType.VarChar);
                cmd.Parameters["@ACIKLAMA3"].Value = aciklama3.ToString();
                cmd.Parameters["@ACIKLAMA3"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BKOD3", SqlDbType.SmallInt);
                cmd.Parameters["@BKOD3"].Value = Convert.ToInt32(siparisteGoster);
                cmd.Parameters["@BKOD3"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BKOD4", SqlDbType.SmallInt);
                cmd.Parameters["@BKOD4"].Value = Convert.ToInt32(uretimYeri);
                cmd.Parameters["@BKOD4"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MKOD1", SqlDbType.Int);
                cmd.Parameters["@MKOD1"].Value = lotNumarasi.ToString();
                cmd.Parameters["@MKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ACIKLAMA1", SqlDbType.VarChar);
                cmd.Parameters["@ACIKLAMA1"].Value = aciklama1.ToString();
                cmd.Parameters["@ACIKLAMA1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@Result", SqlDbType.Int);
                cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@Result"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        #endregion
    }
}