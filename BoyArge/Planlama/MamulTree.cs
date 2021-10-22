using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public class MamulTree
    {
        private readonly SqlConnection con;

        public MamulTree(SqlConnection connection)
        {
            con = connection;
        }

        public int InsertTEXMRH(object satirTip, object malKod, object miktar, object fire,
                                object iplikKati, object renkKod, object boyahane_islemi, object siparisteGoster,
                                object uretimYeri, object lotNumarasi, object aciklama1, object anaSeviye,
                                object seviye, object receteNo, object girenKullanici, object girenSurum,
                                object miktarDurum, object mrpTip, object siraNo, object siraNo2,
                                object anaMalKod, object mamulKod, object renkDurum, object boyamaSekli,
                                object stockGroupID, object touchness, object feature, object zoneID, object bottleNeck,
                                SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.Transaction = transaction;
            cmd.CommandText = "[dbo].[SPARGE_TEXMRH_INSERT]";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Object a = siparisteGoster.GetType();

                cmd.Parameters.Add("@RECETENO", SqlDbType.NVarChar);
                cmd.Parameters["@RECETENO"].Value = receteNo.ToString();
                cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MAMULKOD", SqlDbType.NVarChar);
                cmd.Parameters["@MAMULKOD"].Value = mamulKod.ToString();
                cmd.Parameters["@MAMULKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKDURUM", SqlDbType.SmallInt);
                cmd.Parameters["@RENKDURUM"].Value = Convert.ToInt32(renkDurum);
                cmd.Parameters["@RENKDURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BOYAMASEKLI", SqlDbType.VarChar);
                cmd.Parameters["@BOYAMASEKLI"].Value = boyamaSekli.ToString();
                cmd.Parameters["@BOYAMASEKLI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKKOD", SqlDbType.NVarChar);
                cmd.Parameters["@RENKKOD"].Value = renkKod.ToString();
                cmd.Parameters["@RENKKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ANAMALKOD", SqlDbType.NVarChar);
                cmd.Parameters["@ANAMALKOD"].Value = anaMalKod.ToString();
                cmd.Parameters["@ANAMALKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MALKOD", SqlDbType.NVarChar);
                cmd.Parameters["@MALKOD"].Value = malKod.ToString();
                cmd.Parameters["@MALKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SIRANO", SqlDbType.SmallInt);
                cmd.Parameters["@SIRANO"].Value = Convert.ToInt32(siraNo);
                cmd.Parameters["@SIRANO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SIRANO2", SqlDbType.SmallInt);
                cmd.Parameters["@SIRANO2"].Value = Convert.ToInt32(siraNo2);
                cmd.Parameters["@SIRANO2"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SEVIYE", SqlDbType.SmallInt);
                cmd.Parameters["@SEVIYE"].Value = Convert.ToInt32(seviye);
                cmd.Parameters["@SEVIYE"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ANASEVIYE", SqlDbType.NVarChar);
                cmd.Parameters["@ANASEVIYE"].Value = anaSeviye.ToString();
                cmd.Parameters["@ANASEVIYE"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SATIRTIP", SqlDbType.SmallInt);
                cmd.Parameters["@SATIRTIP"].Value = Convert.ToInt32(satirTip);
                cmd.Parameters["@SATIRTIP"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MRPTIP", SqlDbType.SmallInt);
                cmd.Parameters["@MRPTIP"].Value = Convert.ToInt32(mrpTip);
                cmd.Parameters["@MRPTIP"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MIKTARDURUM", SqlDbType.SmallInt);
                cmd.Parameters["@MIKTARDURUM"].Value = Convert.ToInt32(miktarDurum);
                cmd.Parameters["@MIKTARDURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MIKTAR", SqlDbType.Int);
                cmd.Parameters["@MIKTAR"].Value = Convert.ToInt32(miktar);
                cmd.Parameters["@MIKTAR"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD1", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD1"].Value = stockGroupID.ToString();
                cmd.Parameters["@SKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD2", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD2"].Value = touchness.ToString();
                cmd.Parameters["@SKOD2"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD3", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD3"].Value = feature.ToString();
                cmd.Parameters["@SKOD3"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD4", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD4"].Value = zoneID.ToString();
                cmd.Parameters["@SKOD4"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD5", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD5"].Value = bottleNeck.ToString();
                cmd.Parameters["@SKOD5"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MKOD1", SqlDbType.NVarChar);
                cmd.Parameters["@MKOD1"].Value = lotNumarasi.ToString();
                cmd.Parameters["@MKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BKOD1", SqlDbType.SmallInt);
                cmd.Parameters["@BKOD1"].Value = Convert.ToInt32(boyahane_islemi);
                cmd.Parameters["@BKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BKOD3", SqlDbType.SmallInt);
                cmd.Parameters["@BKOD3"].Value = Convert.ToInt32(siparisteGoster);
                cmd.Parameters["@BKOD3"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BKOD4", SqlDbType.SmallInt);
                cmd.Parameters["@BKOD4"].Value = Convert.ToInt32(uretimYeri);
                cmd.Parameters["@BKOD4"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@NKOD1", SqlDbType.Int);
                cmd.Parameters["@NKOD1"].Value = Convert.ToInt32(iplikKati);
                cmd.Parameters["@NKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@NKOD2", SqlDbType.Int);
                cmd.Parameters["@NKOD2"].Value = Convert.ToInt32(fire);
                cmd.Parameters["@NKOD2"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ACIKLAMA1", SqlDbType.NVarChar);
                cmd.Parameters["@ACIKLAMA1"].Value = aciklama1.ToString();
                cmd.Parameters["@ACIKLAMA1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENKULLANICI"].Value = girenKullanici.ToString();
                cmd.Parameters["@GIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENSURUM"].Value = girenSurum.ToString();
                cmd.Parameters["@GIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENKULLANICI"].Value = girenKullanici.ToString();
                cmd.Parameters["@DEGISTIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENSURUM"].Value = girenSurum.ToString();
                cmd.Parameters["@DEGISTIRENSURUM"].Direction = ParameterDirection.Input;

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

        public int InsertTEXSRH(object kalemSN, object satirTip, object malKod, object miktar, object fire,
                        object iplikKati, object renkKod, object boyahane_islemi, object siparisteGoster,
                        object uretimYeri, object lotNumarasi, object aciklama1, object anaSeviye,
                        object seviye, object receteNo, object girenKullanici, object girenSurum,
                        object miktarDurum, object mrpTip, object siraNo, object siraNo2,
                        object anaMalKod, object mamulKod, object renkDurum, object boyamaSekli,
                        object stockGroupID, object touchness, object feature, object zoneID, object bottleNeck,
                        SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.Transaction = transaction;
            cmd.CommandText = "[dbo].[SPARGE_TEXSRH_INSERT]";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Object a = siparisteGoster.GetType();

                cmd.Parameters.Add("@KALEMSN", SqlDbType.NVarChar);
                cmd.Parameters["@KALEMSN"].Value = kalemSN.ToString();
                cmd.Parameters["@KALEMSN"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RECETENO", SqlDbType.NVarChar);
                cmd.Parameters["@RECETENO"].Value = receteNo.ToString();
                cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MAMULKOD", SqlDbType.NVarChar);
                cmd.Parameters["@MAMULKOD"].Value = mamulKod.ToString();
                cmd.Parameters["@MAMULKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKDURUM", SqlDbType.SmallInt);
                cmd.Parameters["@RENKDURUM"].Value = Convert.ToInt32(renkDurum);
                cmd.Parameters["@RENKDURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BOYAMASEKLI", SqlDbType.VarChar);
                cmd.Parameters["@BOYAMASEKLI"].Value = boyamaSekli.ToString();
                cmd.Parameters["@BOYAMASEKLI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKKOD", SqlDbType.NVarChar);
                cmd.Parameters["@RENKKOD"].Value = renkKod.ToString();
                cmd.Parameters["@RENKKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ANAMALKOD", SqlDbType.NVarChar);
                cmd.Parameters["@ANAMALKOD"].Value = anaMalKod.ToString();
                cmd.Parameters["@ANAMALKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MALKOD", SqlDbType.NVarChar);
                cmd.Parameters["@MALKOD"].Value = malKod.ToString();
                cmd.Parameters["@MALKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SIRANO", SqlDbType.SmallInt);
                cmd.Parameters["@SIRANO"].Value = Convert.ToInt32(siraNo);
                cmd.Parameters["@SIRANO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SIRANO2", SqlDbType.SmallInt);
                cmd.Parameters["@SIRANO2"].Value = Convert.ToInt32(siraNo2);
                cmd.Parameters["@SIRANO2"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SEVIYE", SqlDbType.SmallInt);
                cmd.Parameters["@SEVIYE"].Value = Convert.ToInt32(seviye);
                cmd.Parameters["@SEVIYE"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ANASEVIYE", SqlDbType.NVarChar);
                cmd.Parameters["@ANASEVIYE"].Value = anaSeviye.ToString();
                cmd.Parameters["@ANASEVIYE"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SATIRTIP", SqlDbType.SmallInt);
                cmd.Parameters["@SATIRTIP"].Value = Convert.ToInt32(satirTip);
                cmd.Parameters["@SATIRTIP"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MRPTIP", SqlDbType.SmallInt);
                cmd.Parameters["@MRPTIP"].Value = Convert.ToInt32(mrpTip);
                cmd.Parameters["@MRPTIP"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MIKTARDURUM", SqlDbType.SmallInt);
                cmd.Parameters["@MIKTARDURUM"].Value = Convert.ToInt32(miktarDurum);
                cmd.Parameters["@MIKTARDURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MIKTAR", SqlDbType.Int);
                cmd.Parameters["@MIKTAR"].Value = Convert.ToInt32(miktar);
                cmd.Parameters["@MIKTAR"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD1", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD1"].Value = stockGroupID.ToString();
                cmd.Parameters["@SKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD2", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD2"].Value = touchness.ToString();
                cmd.Parameters["@SKOD2"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD3", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD3"].Value = feature.ToString();
                cmd.Parameters["@SKOD3"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD4", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD4"].Value = zoneID.ToString();
                cmd.Parameters["@SKOD4"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@SKOD5", SqlDbType.NVarChar);
                cmd.Parameters["@SKOD5"].Value = bottleNeck.ToString();
                cmd.Parameters["@SKOD5"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MKOD1", SqlDbType.NVarChar);
                cmd.Parameters["@MKOD1"].Value = lotNumarasi.ToString();
                cmd.Parameters["@MKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BKOD1", SqlDbType.SmallInt);
                cmd.Parameters["@BKOD1"].Value = Convert.ToInt32(boyahane_islemi);
                cmd.Parameters["@BKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BKOD3", SqlDbType.SmallInt);
                cmd.Parameters["@BKOD3"].Value = Convert.ToInt32(siparisteGoster);
                cmd.Parameters["@BKOD3"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BKOD4", SqlDbType.SmallInt);
                cmd.Parameters["@BKOD4"].Value = Convert.ToInt32(uretimYeri);
                cmd.Parameters["@BKOD4"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@NKOD1", SqlDbType.Int);
                cmd.Parameters["@NKOD1"].Value = Convert.ToInt32(iplikKati);
                cmd.Parameters["@NKOD1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@NKOD2", SqlDbType.Int);
                cmd.Parameters["@NKOD2"].Value = Convert.ToInt32(fire);
                cmd.Parameters["@NKOD2"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ACIKLAMA1", SqlDbType.NVarChar);
                cmd.Parameters["@ACIKLAMA1"].Value = aciklama1.ToString();
                cmd.Parameters["@ACIKLAMA1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENKULLANICI"].Value = girenKullanici.ToString();
                cmd.Parameters["@GIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENSURUM"].Value = girenSurum.ToString();
                cmd.Parameters["@GIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENKULLANICI"].Value = girenKullanici.ToString();
                cmd.Parameters["@DEGISTIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENSURUM"].Value = girenSurum.ToString();
                cmd.Parameters["@DEGISTIRENSURUM"].Direction = ParameterDirection.Input;

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

        public int InsertTEXMRB(object receteNo, object mamulKod, object renkDurum,
                                object boyamaSekli, object aciklama1, object girenKullanici, object girenSurum, object degistirenKullanici,
                                object degistirenSurum, object renkKodu, SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.Transaction = transaction;
            cmd.CommandText = "[dbo].[SPARGE_TEXMRB_INSERT]";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@RECETENO", SqlDbType.NVarChar);
                cmd.Parameters["@RECETENO"].Value = receteNo.ToString();
                cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MAMULKOD", SqlDbType.NVarChar);
                cmd.Parameters["@MAMULKOD"].Value = mamulKod.ToString();
                cmd.Parameters["@MAMULKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKDURUM", SqlDbType.Bit);
                cmd.Parameters["@RENKDURUM"].Value = Convert.ToBoolean(renkDurum);
                cmd.Parameters["@RENKDURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BOYAMASEKLI", SqlDbType.NVarChar);
                cmd.Parameters["@BOYAMASEKLI"].Value = boyamaSekli.ToString();
                cmd.Parameters["@BOYAMASEKLI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ACIKLAMA1", SqlDbType.NVarChar);
                cmd.Parameters["@ACIKLAMA1"].Value = aciklama1.ToString();
                cmd.Parameters["@ACIKLAMA1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENKULLANICI"].Value = girenKullanici.ToString();
                cmd.Parameters["@GIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENSURUM"].Value = girenSurum.ToString();
                cmd.Parameters["@GIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENKULLANICI"].Value = degistirenKullanici.ToString();
                cmd.Parameters["@DEGISTIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENSURUM"].Value = degistirenSurum.ToString();
                cmd.Parameters["@DEGISTIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKKOD", SqlDbType.NVarChar);
                cmd.Parameters["@RENKKOD"].Value = renkKodu.ToString();
                cmd.Parameters["@RENKKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@Result", SqlDbType.Int);
                cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

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

        public int InsertTEXSRB(object kalemSN, object receteNo, object mamulKod, object renkDurum,
                                object boyamaSekli, object aciklama1, object girenKullanici, object girenSurum, object degistirenKullanici,
                                object degistirenSurum, object renkKodu, SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.Transaction = transaction;
            cmd.CommandText = "[dbo].[SPARGE_TEXSRB_INSERT]";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@KALEMSN", SqlDbType.NVarChar);
                cmd.Parameters["@KALEMSN"].Value = kalemSN.ToString();
                cmd.Parameters["@KALEMSN"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RECETENO", SqlDbType.NVarChar);
                cmd.Parameters["@RECETENO"].Value = receteNo.ToString();
                cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MAMULKOD", SqlDbType.NVarChar);
                cmd.Parameters["@MAMULKOD"].Value = mamulKod.ToString();
                cmd.Parameters["@MAMULKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKDURUM", SqlDbType.Bit);
                cmd.Parameters["@RENKDURUM"].Value = Convert.ToBoolean(renkDurum);
                cmd.Parameters["@RENKDURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BOYAMASEKLI", SqlDbType.NVarChar);
                cmd.Parameters["@BOYAMASEKLI"].Value = boyamaSekli.ToString();
                cmd.Parameters["@BOYAMASEKLI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ACIKLAMA1", SqlDbType.NVarChar);
                cmd.Parameters["@ACIKLAMA1"].Value = aciklama1.ToString();
                cmd.Parameters["@ACIKLAMA1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENKULLANICI"].Value = girenKullanici.ToString();
                cmd.Parameters["@GIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENSURUM"].Value = girenSurum.ToString();
                cmd.Parameters["@GIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENKULLANICI"].Value = degistirenKullanici.ToString();
                cmd.Parameters["@DEGISTIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENSURUM"].Value = degistirenSurum.ToString();
                cmd.Parameters["@DEGISTIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKKOD", SqlDbType.NVarChar);
                cmd.Parameters["@RENKKOD"].Value = renkKodu.ToString();
                cmd.Parameters["@RENKKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@Result", SqlDbType.Int);
                cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

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

        //public int UpdateTEXMRH(object satirTip, object malKod, object miktar, object fire,
        //    object iplikKati, object renkKod, object boyahane_islemi, object siparisteGoster,
        //    object uretimYeri, object lotNumarasi, object aciklama1, object anaSeviye,
        //    object seviye, object receteNo, object girenKullanici, object girenSurum,
        //    object miktarDurum, object mrpTip, object siraNo, object siraNo2,
        //    object anaMalKod, object mamulKod, object renkDurum, object boyamaSekli, SqlTransaction transaction)
        //{
        //    var cmd = FormPlanlama.con.CreateCommand();
        //    cmd.Transaction = transaction;
        //    try
        //    {
        //        Object a = siparisteGoster.GetType();

        //        cmd.CommandText = "[dbo].[SPARGE_TEXMRH_UPDATE]";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add("@RECETENO", SqlDbType.NVarChar);
        //        cmd.Parameters["@RECETENO"].Value = receteNo.ToString();
        //        cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@MAMULKOD", SqlDbType.NVarChar);
        //        cmd.Parameters["@MAMULKOD"].Value = mamulKod.ToString();
        //        cmd.Parameters["@MAMULKOD"].Direction = ParameterDirection.Input;
        //        //@MALKOD
        //        cmd.Parameters.Add("@SATIRTIP", SqlDbType.Int);
        //        cmd.Parameters["@SATIRTIP"].Value = Convert.ToInt32(satirTip);
        //        cmd.Parameters["@SATIRTIP"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@MALKOD", SqlDbType.NVarChar);
        //        cmd.Parameters["@MALKOD"].Value = malKod.ToString();
        //        cmd.Parameters["@MALKOD"].Direction = ParameterDirection.Input;
        //        //@ACIKLAMA2
        //        //cmd.Parameters.Add("@ACIKLAMA2", SqlDbType.VarChar);
        //        //cmd.Parameters["@ACIKLAMA2"].Value = aciklama2.ToString();
        //        //cmd.Parameters["@ACIKLAMA2"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@MIKTAR", SqlDbType.Int);
        //        cmd.Parameters["@MIKTAR"].Value = Convert.ToInt32(miktar);
        //        cmd.Parameters["@MIKTAR"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@NKOD2", SqlDbType.Int);
        //        cmd.Parameters["@NKOD2"].Value = Convert.ToInt32(fire);
        //        cmd.Parameters["@NKOD2"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@NKOD1", SqlDbType.Int);
        //        cmd.Parameters["@NKOD1"].Value = Convert.ToInt32(iplikKati);
        //        cmd.Parameters["@NKOD1"].Direction = ParameterDirection.Input;
        //        //@RENKKOD
        //        cmd.Parameters.Add("@RENKKOD", SqlDbType.Int);
        //        cmd.Parameters["@RENKKOD"].Value = Convert.ToInt32(renkKod);
        //        cmd.Parameters["@RENKKOD"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@BKOD1", SqlDbType.SmallInt);
        //        cmd.Parameters["@BKOD1"].Value = Convert.ToInt32(boyahane_islemi);
        //        cmd.Parameters["@BKOD1"].Direction = ParameterDirection.Input;

        //        //cmd.Parameters.Add("@ACIKLAMA3", SqlDbType.VarChar);
        //        //cmd.Parameters["@ACIKLAMA3"].Value = aciklama3.ToString();
        //        //cmd.Parameters["@ACIKLAMA3"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@BKOD3", SqlDbType.SmallInt);
        //        cmd.Parameters["@BKOD3"].Value = Convert.ToInt32(siparisteGoster);
        //        cmd.Parameters["@BKOD3"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@BKOD4", SqlDbType.SmallInt);
        //        cmd.Parameters["@BKOD4"].Value = Convert.ToInt32(uretimYeri);
        //        cmd.Parameters["@BKOD4"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@MKOD1", SqlDbType.NVarChar);
        //        cmd.Parameters["@MKOD1"].Value = lotNumarasi.ToString();
        //        cmd.Parameters["@MKOD1"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@ACIKLAMA1", SqlDbType.NVarChar);
        //        cmd.Parameters["@ACIKLAMA1"].Value = aciklama1.ToString();
        //        cmd.Parameters["@ACIKLAMA1"].Direction = ParameterDirection.Input;
        //        //@SEVIYE, @ANASEVIYE

        //        cmd.Parameters.Add("@SEVIYE", SqlDbType.Int);
        //        cmd.Parameters["@SEVIYE"].Value = Convert.ToInt32(seviye);
        //        cmd.Parameters["@SEVIYE"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@ANASEVIYE", SqlDbType.NVarChar);
        //        cmd.Parameters["@ANASEVIYE"].Value = anaSeviye.ToString();
        //        cmd.Parameters["@ANASEVIYE"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@GIRENKULLANICI", SqlDbType.NVarChar);
        //        cmd.Parameters["@GIRENKULLANICI"].Value = girenKullanici.ToString();
        //        cmd.Parameters["@GIRENKULLANICI"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@GIRENSURUM", SqlDbType.NVarChar);
        //        cmd.Parameters["@GIRENSURUM"].Value = girenSurum.ToString();
        //        cmd.Parameters["@GIRENSURUM"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@DEGISTIRENKULLANICI", SqlDbType.NVarChar);
        //        cmd.Parameters["@DEGISTIRENKULLANICI"].Value = girenKullanici.ToString();
        //        cmd.Parameters["@DEGISTIRENKULLANICI"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@DEGISTIRENSURUM", SqlDbType.NVarChar);
        //        cmd.Parameters["@DEGISTIRENSURUM"].Value = girenSurum.ToString();
        //        cmd.Parameters["@DEGISTIRENSURUM"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@MIKTARDURUM", SqlDbType.SmallInt);
        //        cmd.Parameters["@MIKTARDURUM"].Value = Convert.ToInt32(miktarDurum);
        //        cmd.Parameters["@MIKTARDURUM"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@MRPTIP", SqlDbType.SmallInt);
        //        cmd.Parameters["@MRPTIP"].Value = Convert.ToInt32(mrpTip);
        //        cmd.Parameters["@MRPTIP"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@SIRANO", SqlDbType.SmallInt);
        //        cmd.Parameters["@SIRANO"].Value = Convert.ToInt32(siraNo);
        //        cmd.Parameters["@SIRANO"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@SIRANO2", SqlDbType.SmallInt);
        //        cmd.Parameters["@SIRANO2"].Value = Convert.ToInt32(siraNo2);
        //        cmd.Parameters["@SIRANO2"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@ANAMALKOD", SqlDbType.NVarChar);
        //        cmd.Parameters["@ANAMALKOD"].Value = anaMalKod.ToString();
        //        cmd.Parameters["@ANAMALKOD"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@RENKDURUM", SqlDbType.SmallInt);
        //        cmd.Parameters["@RENKDURUM"].Value = Convert.ToInt32(renkDurum);
        //        cmd.Parameters["@RENKDURUM"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@BOYAMASEKLI", SqlDbType.SmallInt);
        //        cmd.Parameters["@BOYAMASEKLI"].Value = Convert.ToInt32(boyamaSekli);
        //        cmd.Parameters["@BOYAMASEKLI"].Direction = ParameterDirection.Input;

        //        cmd.Parameters.Add("@Result", SqlDbType.Int);
        //        cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

        //        cmd.ExecuteNonQuery();

        //        return (int)cmd.Parameters["@Result"].Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        cmd.Dispose();
        //    }
        //}

        public int UpdateTEXMRB(object receteNo, object mamulKod, object renkDurum,
                                object boyamaSekli, object aciklama1, object girenKullanici, object girenSurum, object degistirenKullanici,
                                object degistirenSurum, object renkKodu, SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = "[dbo].[SPARGE_TEXMRB_UPDATE]";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@RECETENO", SqlDbType.NVarChar);
                cmd.Parameters["@RECETENO"].Value = receteNo.ToString();
                cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MAMULKOD", SqlDbType.NVarChar);
                cmd.Parameters["@MAMULKOD"].Value = mamulKod.ToString();
                cmd.Parameters["@MAMULKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKDURUM", SqlDbType.Bit);
                cmd.Parameters["@RENKDURUM"].Value = Convert.ToBoolean(renkDurum);
                cmd.Parameters["@RENKDURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BOYAMASEKLI", SqlDbType.NVarChar);
                cmd.Parameters["@BOYAMASEKLI"].Value = boyamaSekli.ToString();
                cmd.Parameters["@BOYAMASEKLI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ACIKLAMA1", SqlDbType.NVarChar);
                cmd.Parameters["@ACIKLAMA1"].Value = aciklama1.ToString();
                cmd.Parameters["@ACIKLAMA1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENKULLANICI"].Value = girenKullanici.ToString();
                cmd.Parameters["@GIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENSURUM"].Value = girenSurum.ToString();
                cmd.Parameters["@GIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENKULLANICI"].Value = degistirenKullanici;
                cmd.Parameters["@DEGISTIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENSURUM"].Value = degistirenSurum.ToString();
                cmd.Parameters["@DEGISTIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKKOD", SqlDbType.NVarChar);
                cmd.Parameters["@RENKKOD"].Value = renkKodu.ToString();
                cmd.Parameters["@RENKKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@Result", SqlDbType.Int);
                cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

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

        public int UpdateTEXSRB(object kalemSN, object receteNo, object mamulKod, object renkDurum,
                                object boyamaSekli, object aciklama1, object girenKullanici, object girenSurum, object degistirenKullanici,
                                object degistirenSurum, object renkKodu, SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = "[dbo].[SPARGE_TEXSRB_UPDATE]";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@KALEMSN", SqlDbType.NVarChar);
                cmd.Parameters["@KALEMSN"].Value = kalemSN.ToString();
                cmd.Parameters["@KALEMSN"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RECETENO", SqlDbType.NVarChar);
                cmd.Parameters["@RECETENO"].Value = receteNo.ToString();
                cmd.Parameters["@RECETENO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@MAMULKOD", SqlDbType.NVarChar);
                cmd.Parameters["@MAMULKOD"].Value = mamulKod.ToString();
                cmd.Parameters["@MAMULKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKDURUM", SqlDbType.Bit);
                cmd.Parameters["@RENKDURUM"].Value = Convert.ToBoolean(renkDurum);
                cmd.Parameters["@RENKDURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@BOYAMASEKLI", SqlDbType.NVarChar);
                cmd.Parameters["@BOYAMASEKLI"].Value = boyamaSekli.ToString();
                cmd.Parameters["@BOYAMASEKLI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ACIKLAMA1", SqlDbType.NVarChar);
                cmd.Parameters["@ACIKLAMA1"].Value = aciklama1.ToString();
                cmd.Parameters["@ACIKLAMA1"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENKULLANICI"].Value = girenKullanici.ToString();
                cmd.Parameters["@GIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@GIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@GIRENSURUM"].Value = girenSurum.ToString();
                cmd.Parameters["@GIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENKULLANICI", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENKULLANICI"].Value = degistirenKullanici;
                cmd.Parameters["@DEGISTIRENKULLANICI"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@DEGISTIRENSURUM", SqlDbType.NVarChar);
                cmd.Parameters["@DEGISTIRENSURUM"].Value = degistirenSurum.ToString();
                cmd.Parameters["@DEGISTIRENSURUM"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@RENKKOD", SqlDbType.NVarChar);
                cmd.Parameters["@RENKKOD"].Value = renkKodu.ToString();
                cmd.Parameters["@RENKKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@Result", SqlDbType.Int);
                cmd.Parameters["@Result"].Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@Result"].Value;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public DataTable GetTreeColumns()
        {
            string TableName = " ";
            string sqlGetlist =
            "SELECT   SATIRTIP,'' as stockGroupID,'' as zoneID, T.MALKOD, T.ACIKLAMA2, MIKTAR, T.NKOD2, T.NKOD1, T.RENKKOD, T.BKOD1, T.ACIKLAMA3, T.BKOD3, T.BKOD4, " +
            "T.MKOD1, T.ACIKLAMA1, SEVIYE, ANASEVIYE, SATIRTIP, MIKTARDURUM, T.MRPTIP, SIRANO, SIRANO2, T.ANAMALKOD, " +
            "MAMULKOD, T.RENKDURUM, BOYAMASEKLI, MALAD, RENKAD, '' as unitCost, '' as totalCost, '' as Touchness, '' as Feature FROM TEXMRH AS T LEFT JOIN[TEKSTIL_UYG].[dbo].[STKKRT] " +
            "ON T.MALKOD = [TEKSTIL_UYG].[dbo].[STKKRT].MALKOD LEFT JOIN TEXRAH ON TEXRAH.RENKKOD = T.RENKKOD WHERE 0 = 1";
            SqlCommand cmd = new SqlCommand(sqlGetlist, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet set = new DataSet();
            adapter.Fill(set, TableName);
            return set.Tables[0];
        }

        public static DataTable LevelTypeList()
        {
            var dLevelType = new DataTable();
            dLevelType.Columns.Add("Code", typeof(int));
            dLevelType.Columns.Add("Caption", typeof(string));

            dLevelType.Rows.Add(0, "Ana Ürün");
            dLevelType.Rows.Add(1, "Alt Ürün");
            dLevelType.Rows.Add(2, "Hammadde");

            return dLevelType;
        }

        public static DataTable getSiparisGoster()
        {
            var dLevelType = new DataTable();
            dLevelType.Columns.Add("Code", typeof(int));
            dLevelType.Columns.Add("Caption", typeof(string));

            dLevelType.Rows.Add(0, "Evet");
            dLevelType.Rows.Add(1, "Hayır");

            return dLevelType;
        }

        public bool ReceteNoIsSave(string rowValue, string receteTipi)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            string tableName = receteTipi == "Mamul" ? "TEXMRH" : "TEXSRH";
            cmd.CommandText = $"SELECT RECETENO from {tableName } WHERE RECETENO = '{rowValue}'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Table");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            return false;
        }

        public string GetMalAd(string malKod)
        {
            SqlDataReader reader = null;
            string malAd;
            try
            {
                string query = $"SELECT MALAD FROM [TEKSTIL_UYG].[dbo].[STKKRT] WHERE MALKOD = '{malKod}'";
                var cmd = FormPlanlama.con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader();
                reader.Read();
                malAd = reader["MALAD"].ToString();
                reader.Close();
                return malAd;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return "";
            }
        }

        public string GetRenkAd(string renkKod)
        {
            SqlDataReader reader = null;
            string renkAd = null;
            try
            {
                string query = $"SELECT RENKAD FROM [TEKSTIL_UYG].[dbo].[TEXRAH] WHERE RENKKOD = '{renkKod}'";
                var cmd = FormPlanlama.con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader();
                reader.Read();
                renkAd = reader["RENKAD"].ToString();
                reader.Close();
                return renkAd;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return "";
            }
        }

        public void CleanTEXMRHBeforeUpdate(string receteNo, SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.CommandText = $"DELETE FROM TEXMRH WHERE RECETENO = '{receteNo}'";
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
        }

        public void CleanTEXSRHBeforeUpdate(string receteNo, SqlTransaction transaction)
        {
            var cmd = FormPlanlama.con.CreateCommand();
            cmd.CommandText = $"DELETE FROM TEXSRH WHERE RECETENO = '{receteNo}'";
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
        }
    }
}