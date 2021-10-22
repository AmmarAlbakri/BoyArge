using Core;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Business
{
    public class CPMDatabase
    {
        private readonly SqlConnection _dataConnection;

        public CPMDatabase()
        {
            _dataConnection = Database.Connect(new SqlConnectionStringBuilder
            {
                DataSource = "CPM",
                InitialCatalog = "TEKSTIL_UYG",
                UserID = "arge",
                Password = "Arge*2020!"
            });
        }

        private DataTable GetList(string query, string srcTable)
        {
            if (query == string.Empty)
                return null;

            if (Database.CheckConnection(_dataConnection))
            {
                var cmd = _dataConnection.CreateCommand();
                try
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, srcTable);

                    return ds.Tables[0];
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

            return null;
        }

        public DataTable GetExchangeRateDaily()
        {
            var sql = new StringBuilder();

            sql.AppendLine("WITH Memory ");
            sql.AppendLine("     AS (SELECT DVZHAR.DOVIZCINS,");
            sql.AppendLine("                CASE");
            sql.AppendLine("                    WHEN DVZHAR.DOVIZTIP = 0");
            sql.AppendLine("                         AND DOVIZTARIH = CONVERT(DATE, GETDATE() - 1)");
            sql.AppendLine("                    THEN DOVIZKUR");
            sql.AppendLine("                END AS DünAlış,");
            sql.AppendLine("                CASE");
            sql.AppendLine("                    WHEN DVZHAR.DOVIZTIP = 0");
            sql.AppendLine("                         AND DOVIZTARIH = CONVERT(DATE, GETDATE())");
            sql.AppendLine("                    THEN DOVIZKUR");
            sql.AppendLine("                END AS Alış,");
            sql.AppendLine("                CASE");
            sql.AppendLine("                    WHEN DVZHAR.DOVIZTIP = 1");
            sql.AppendLine("                         AND DOVIZTARIH = CONVERT(DATE, GETDATE() - 1)");
            sql.AppendLine("                    THEN DOVIZKUR");
            sql.AppendLine("                END AS DünSatış,");
            sql.AppendLine("                CASE");
            sql.AppendLine("                    WHEN DVZHAR.DOVIZTIP = 1");
            sql.AppendLine("                         AND DOVIZTARIH = CONVERT(DATE, GETDATE())");
            sql.AppendLine("                    THEN DOVIZKUR");
            sql.AppendLine("                END AS Satış");
            sql.AppendLine("         FROM dbo.DVZHAR");
            sql.AppendLine("         WHERE DOVIZTARIH >= CONVERT(DATE, GETDATE() - 1)");
            sql.AppendLine("         GROUP BY DOVIZTARIH,");
            sql.AppendLine("                  DOVIZTIP,");
            sql.AppendLine("                  DOVIZCINS,");
            sql.AppendLine("                  DOVIZKUR,");
            sql.AppendLine("                  DOVIZCINS)");
            sql.AppendLine("     SELECT m.DOVIZCINS,");
            sql.AppendLine("            MAX(m.DünAlış) AS [YBuyingPrice],");
            sql.AppendLine("            MAX(m.DünSatış) AS [YSellingPrice],");
            sql.AppendLine("            MAX(m.Alış) AS [BuyingPrice],");
            sql.AppendLine("            MAX(m.Satış) AS [SellingPrice]");
            sql.AppendLine("     FROM Memory m");
            sql.AppendLine("     GROUP BY m.DOVIZCINS;");

            return GetList(sql.ToString(), "DVZHAR");
        }

        public DataTable GetOrderReportDaily(DateTime startDate, DateTime endDate)
        {
            var sql = new StringBuilder();

            sql.AppendLine("SELECT STKHAR.[SIRKETNO],");
            sql.AppendLine("       STKHAR.[EVRAKTIP],");
            sql.AppendLine("       STKHAR.[EVRAKNO],");
            sql.AppendLine("       STKHAR.[EVRAKTARIH],");
            sql.AppendLine("       STKHAR.[HESAPKOD],");
            sql.AppendLine("       STKHAR.[CARKRT_UNVAN],");
            sql.AppendLine("       STKHAR.[MALKOD],");
            sql.AppendLine("       STKHAR.[STKKRT_MALAD],");
            sql.AppendLine("       STKHAR.[TEXSPK_RENKKOD],");
            sql.AppendLine("       STKHAR.[TEXRAH_RENKAD],");
            sql.AppendLine("       STKHAR.[_KALEMSAY],");
            sql.AppendLine("       STKHAR.[MIKTAR],");
            sql.AppendLine("       STKHAR.[KULLANILANMIKTAR],");
            sql.AppendLine("       STKHAR.[_KALANMIKTAR],");
            sql.AppendLine("       STKHAR.[_STOKMIKTAR01],");
            sql.AppendLine("       STKHAR.[_STOKMIKTAR02] ");
            sql.AppendLine("FROM dbo.VWTEX_SIPARIS_ANALIZ_01 STKHAR WITH(NOLOCK) ");
            sql.AppendLine(
                $"WHERE CONVERT(DATE, STKHAR.EVRAKTARIH) BETWEEN CONVERT(DATE,  '{startDate:yyyy-MM-dd}') AND  CONVERT(DATE,  '{endDate:yyyy-MM-dd}')");
            sql.AppendLine("      AND STKHAR.SIRKETNO = 'B01'");
            sql.AppendLine("      AND STKHAR.EVRAKTIP = 14");
            sql.AppendLine("ORDER BY STKHAR.CARKRT_UNVAN ASC,");
            sql.AppendLine("         STKHAR.STKKRT_MALAD ASC,");
            sql.AppendLine("         STKHAR.TEXSPK_RENKKOD ASC,");
            sql.AppendLine("         STKHAR.EVRAKTARIH ASC;");

            return GetList(sql.ToString(), "VWTEX_SIPARIS_ANALIZ_01");
        }

        public DataTable GetCurrentAccount()
        {
            var sql = new StringBuilder();

            sql.AppendLine("SELECT CASE CARKRT.FIRMATIP");
            sql.AppendLine("           WHEN 0");
            sql.AppendLine("           THEN 'İç Piyasa'");
            sql.AppendLine("           WHEN 1");
            sql.AppendLine("           THEN 'Dış Piyasa'");
            sql.AppendLine("       END[FirmaTip],");
            sql.AppendLine("       CARKRT.HESAPKOD AS[CariKod],");
            sql.AppendLine("       CARKRT.UNVAN AS[CariAd],");
            sql.AppendLine("       CARKRT.DOVIZCINS AS[DovizCins],");
            sql.AppendLine("       CARKRT.FATURAADRES1 + ' ' + CARKRT.FATURAADRES2 AS[Adres],");
            sql.AppendLine("       CARKRT.FATURAADRES4 AS[Ilce],");
            sql.AppendLine("       SHRKRT.SEHIRAD AS[Il],");
            sql.AppendLine("       CARKRT.EMAIL1 AS[Email],");
            sql.AppendLine("       MusteriGrup.ACIKLAMA AS[MusteriGrup],");
            sql.AppendLine("       MusteriTur.ACIKLAMA AS[MusteriTur]");
            sql.AppendLine("FROM dbo.CARKRT WITH(NOLOCK)");
            sql.AppendLine("     LEFT OUTER JOIN dbo.CARRES WITH(NOLOCK) ON (CARRES.HESAPKOD = CARKRT.HESAPKOD)");
            sql.AppendLine("     LEFT OUTER JOIN dbo.SHRKRT WITH(NOLOCK) ON(SHRKRT.SEHIRKOD = CARKRT.FATURAADRES5)");
            sql.AppendLine(
                "     LEFT OUTER JOIN[dbo].[REFKRT] FirmaTip WITH(NOLOCK) ON(FirmaTip.TABLOAD = 'CARK01' AND FirmaTip.ALANAD = 'FIRMATIP' AND FirmaTip.KOD = CARKRT.FIRMATIP)");
            sql.AppendLine(
                "     LEFT OUTER JOIN[dbo].[REFKRT] MusteriGrup WITH(NOLOCK) ON(MusteriGrup.TABLOAD = 'CARK01' AND MusteriGrup.ALANAD = 'BKOD1' AND MusteriGrup.KOD = CARKRT.BKOD1)");
            sql.AppendLine(
                "     LEFT OUTER JOIN[dbo].[REFKRT] MusteriTur WITH(NOLOCK) ON(MusteriTur.TABLOAD = 'CARK01' AND MusteriTur.ALANAD = 'BKOD2' AND MusteriTur.KOD = CARKRT.BKOD2)");
            sql.AppendLine("WHERE CARKRT.HESAPTIP = 1");

            return GetList(sql.ToString(), "CARKRT");
        }

        public DataTable ViewOperationList()
        {
            return GetList(
                "SELECT [ID] ,[Operasyon Tipi] ,[Operasyon Grubu] ,[Operasyon Kodu] ,[Operasyon Adı] FROM [TEKSTIL_UYG].[dbo].[VWARGE_OPERATIONS]",
                "VWARGE_OPERATIONS");
        }

        public DataTable ViewChemicalStockList()
        {
            return GetList(
                "SELECT [Kimyasal Kodu], [Kimyasal Adı], [Birim] FROM [TEKSTIL_UYG].[dbo].[VWARGE_CHEMICALSTOCKS]",
                "VWARGE_CHEMICALSTOCKS");
        }

        public DataTable ViewCalculateTypeList()
        {
            return GetList(
                "SELECT KOD [HesaplamaSekliKod], ACIKLAMA [HesaplamaSekliAd] FROM REFKRT WHERE TABLOAD = 'TEXRAD' AND ALANAD = 'HESAPLAMASEKLI'",
                "REFKRT");
        }

        public DataTable GetRecipe(string mamulKod)
        {
            if (Database.CheckConnection(_dataConnection))
            {
                var cmd = _dataConnection.CreateCommand();
                try
                {
                    var sql = new StringBuilder();

                    sql.AppendLine($"DECLARE @MamulKod VARCHAR(500)= '{mamulKod}'");
                    sql.AppendLine("DECLARE @SirketNo VARCHAR(500)= 'B01'");
                    sql.AppendLine("SELECT TEXMRH.ID,");
                    sql.AppendLine("       URETIMYERI.ACIKLAMA [Üretim Yeri],");
                    sql.AppendLine("       TEXMRH.ANASEVIYE [Ana Seviye],");
                    sql.AppendLine("       TEXMRH.SEVIYE [Seviye],");
                    sql.AppendLine("       TEXMRH.RECETENO [Reçete No],");
                    sql.AppendLine("	   BOYAMAISLEMI.ACIKLAMA [Boyama İşlemi],");
                    sql.AppendLine("       SATIRTIP.ACIKLAMA [Seviye Türü],");
                    sql.AppendLine("       RENKAD.ACIKLAMA [Renk Adı],");
                    sql.AppendLine("	   TEXMRH.RENKKOD [Renk Kodu],");
                    sql.AppendLine("       TEXMRH.MALKOD [Malzeme Kodu],");
                    sql.AppendLine("       STKKRT.MALAD [Malzeme Adı],");
                    sql.AppendLine("       TEXMRH.MIKTAR [Miktar(%)],");
                    sql.AppendLine("       TEXMRH.NKOD2 [Fire(%)]");
                    sql.AppendLine("FROM dbo.TEXMRH TEXMRH");
                    sql.AppendLine(
                        "     LEFT OUTER JOIN dbo.VWTEX_RENKLIST TEXRAH ON(TEXRAH.RENKKOD = TEXMRH.RENKKOD)");
                    sql.AppendLine("     LEFT OUTER JOIN dbo.STKKRT STKKRT ON (STKKRT.MALKOD = TEXMRH.MALKOD)");
                    sql.AppendLine(
                        "     LEFT OUTER JOIN dbo.REFKRT RENKAD ON (RENKAD.TABLOAD = 'TEXMRB' AND RENKAD.ALANAD = 'TEXRAH_RENKAD' AND RENKAD.KOD = TEXRAH.RENKKOD)");
                    sql.AppendLine(
                        "	 LEFT OUTER JOIN dbo.REFKRT BOYAMAISLEMI ON (BOYAMAISLEMI.TABLOAD = 'TEXMRH' AND BOYAMAISLEMI.ALANAD = 'BKOD1' AND BOYAMAISLEMI.KOD = TEXMRH.BKOD1)");
                    sql.AppendLine(
                        "     LEFT OUTER JOIN dbo.REFKRT URETIMYERI ON(URETIMYERI.TABLOAD = 'TEXMRH' AND URETIMYERI.ALANAD = 'BKOD4' AND URETIMYERI.KOD = TEXMRH.BKOD4)");
                    sql.AppendLine(
                        "     LEFT OUTER JOIN dbo.REFKRT SATIRTIP ON(SATIRTIP.TABLOAD = 'TEXMRH' AND SATIRTIP.ALANAD = 'SATIRTIP' AND SATIRTIP.KOD = TEXMRH.SATIRTIP)");
                    sql.AppendLine("WHERE TEXMRH.SIRKETNO = @SirketNo");
                    sql.AppendLine("      AND TEXMRH.MAMULKOD = @MamulKod");
                    sql.AppendLine("      AND TEXMRH.RECETENO IN");
                    sql.AppendLine("(");
                    sql.AppendLine("    SELECT RECETENO");
                    sql.AppendLine("    FROM [TEKSTIL_UYG].[dbo].[TEXMRB]");
                    sql.AppendLine("    WHERE MAMULKOD = @MamulKod");
                    sql.AppendLine("          AND RENKDURUM = 0");
                    sql.AppendLine(")");

                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, "TEXMRH");

                    return ds.Tables[0];
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

            return null;
        }

        public DataTable GetChemicalRecipe()
        {
            if (Database.CheckConnection(_dataConnection))
            {
                var cmd = _dataConnection.CreateCommand();
                try
                {
                    var sql = new StringBuilder();

                    sql.AppendLine("SELECT TEXURD.[ID],");
                    sql.AppendLine("       TEXURD.[BATCHNO] [Reçete No],");
                    sql.AppendLine("       TEXURD.[BATCHTARIH] [Tarih],");
                    sql.AppendLine("       CARKRT.UNVAN [Müşteri],");
                    sql.AppendLine("       TEXURD.[MALKOD] [Malzeme Kodu],");
                    sql.AppendLine("       STKKRT.[MALAD] [Malzeme Adı],");
                    sql.AppendLine("       STKKRT.NOT1 [Karışım],");
                    sql.AppendLine("       TEXUSK.RENKKOD [Renk Kodu],");
                    sql.AppendLine("       TEXRAH.RENKAD [Renk Adı],");
                    sql.AppendLine("       TEXUSK.SKOD5 [BoyamaTipKod],");
                    sql.AppendLine("       BOYAMA.ACIKLAMA [Boyama Tipi],");
                    sql.AppendLine("       TEXURD.[SERINO] [Seri No],");
                    sql.AppendLine("       CONVERT(float,TEXUSK.MIKTAR) [Miktar],");
                    sql.AppendLine("       CONVERT(float,TEXURB.URETIMKG) [Üretim Miktar]");
                    sql.AppendLine("FROM dbo.TEXURD WITH(NOLOCK)");
                    sql.AppendLine("     LEFT JOIN dbo.TEXUSK TEXUSK WITH(NOLOCK) ON(TEXUSK.SERINO = TEXURD.SERINO)");
                    sql.AppendLine("     LEFT JOIN dbo.VWTEX_RENKLIST TEXRAH WITH(NOLOCK) ON(TEXRAH.RENKKOD = TEXUSK.RENKKOD)");
                    sql.AppendLine("     LEFT JOIN dbo.CARKRT CARKRT WITH(NOLOCK) ON(CARKRT.HESAPKOD = TEXUSK.HESAPKOD)");
                    sql.AppendLine("     LEFT JOIN dbo.STKKRT STKKRT WITH(NOLOCK) ON(STKKRT.MALKOD = TEXURD.MALKOD)");
                    sql.AppendLine("     LEFT JOIN dbo.REFKRT BOYAMA WITH(NOLOCK) ON(BOYAMA.TABLOAD = 'TEXSPK' AND BOYAMA.ALANAD = 'SKOD5' AND BOYAMA.KOD = TEXUSK.SKOD5)");
                    sql.AppendLine("     LEFT JOIN dbo.TEXURB TEXURB WITH(NOLOCK) ON(TEXURB.BATCHNO = TEXURD.BATCHNO)");
                    sql.AppendLine("WHERE TEXURD.TIP = 0");

                    //sql.AppendLine("ORDER BY [STKKRT].[MALAD]");

                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, "TEXURD");

                    return ds.Tables[0];
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

            return null;
        }

        /// <summary>
        ///     TableName : TEXURR
        /// </summary>
        /// <param name="receteNo"></param>
        /// <returns></returns>
        public DataTable GetOperation(string receteNo)
        {
            if (Database.CheckConnection(_dataConnection))
            {
                var cmd = _dataConnection.CreateCommand();
                try
                {
                    var sql = new StringBuilder();

                    sql.AppendLine("SELECT TEXURR.[ID],");
                    sql.AppendLine("       TEXURR.[SIRANO] [Sıra No],");
                    sql.AppendLine("       OPTIP.[ACIKLAMA] [Operasyon Tipi],");
                    sql.AppendLine("       OP.ACIKLAMA [Operasyon Grubu],");
                    sql.AppendLine("       t.[ACIKLAMA] [Yer],");
                    sql.AppendLine("       TEXROP.OPERASYONAD [Operasyon Adı],");
                    sql.AppendLine("       TEXURR.[DTEX],");
                    sql.AppendLine("       TEXURR.[ELYAFCINS] [Elyaf Cinsi],");
                    sql.AppendLine("       STKKRT.MALAD [Elyaf Adı],");
                    sql.AppendLine("       TEXURR.[OPERASYONKOD] [Operasyon Kodu],");
                    sql.AppendLine("       TEXURR.[ELYAFKOD] [Elyaf Kodu],");
                    sql.AppendLine("       TEXURR.[ELYAFORAN] [Elyaf Oranı],");
                    sql.AppendLine("       TEXURR.[RETARDER] [Retarder],");
                    sql.AppendLine("       TEXURR.[ACIKLAMA] [Açıklama]");
                    sql.AppendLine("FROM dbo.TEXURR TEXURR WITH(NOLOCK)");
                    sql.AppendLine(
                        "     LEFT OUTER JOIN dbo.TEXROP TEXROP WITH(NOLOCK) ON(TEXROP.OPERASYONKOD = TEXURR.OPERASYONKOD)");
                    sql.AppendLine(
                        "     LEFT OUTER JOIN dbo.STKKRT STKKRT WITH(NOLOCK) ON(STKKRT.MALKOD = TEXURR.ELYAFKOD)");
                    sql.AppendLine("     LEFT OUTER JOIN dbo.REFKRT t ON t.TABLOAD = 'TEXURB'");
                    sql.AppendLine("                                     AND ALANAD = 'TIP'");
                    sql.AppendLine("                                     AND TEXURR.TIP = t.KOD");
                    sql.AppendLine("     LEFT OUTER JOIN dbo.REFKRT OP ON OP.TABLOAD = 'TEXROP'");
                    sql.AppendLine("                                      AND OP.ALANAD = 'OPERASYONGRUP'");
                    sql.AppendLine("                                      AND TEXROP.OPERASYONGRUP = OP.KOD");
                    sql.AppendLine("     LEFT OUTER JOIN dbo.REFKRT OPTIP ON OPTIP.TABLOAD = 'TEXROP'");
                    sql.AppendLine("                                         AND OPTIP.ALANAD = 'TIP'");
                    sql.AppendLine("                                         AND TEXROP.TIP = OPTIP.KOD");
                    sql.AppendLine($"WHERE TEXURR.BATCHNO = '{receteNo}'");
                    sql.AppendLine("ORDER BY [SIRANO]");

                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, "TEXURR");

                    return ds.Tables[0];
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

            return null;
        }

        /// <summary>
        ///     TableName : TEXURH
        /// </summary>
        /// <param name="receteNo"></param>
        /// <returns></returns>
        public DataTable GetReceiptLine(string receteNo)
        {
            if (Database.CheckConnection(_dataConnection))
            {
                var cmd = _dataConnection.CreateCommand();
                try
                {
                    var sql = new StringBuilder();

                    sql.AppendLine(
                        $"SELECT 0 AS [ReceiptID], [ID] AS ReceiptLineID, [Sıra No] AS [LineNumber], [Operasyon Kodu] AS [OperationCode], [Kimyasal Kodu] AS [ChemicalCode], [Hesaplama Şekli] AS [CalculateType], [Boya - Kimyasal] AS [DyeOrChemical] , [Birim Miktar] AS [UnitAmount], [Toplam Miktar] AS [TotalAmount], [Miktar] AS [Amount], [Açıklama] AS [Note], [Birim Fiyat] AS [Price], CASE [Doviz Cinsi] WHEN 'TL' THEN 1 WHEN 'USD' THEN 2 WHEN 'EUR' THEN 3 WHEN 'GBP' THEN 4 END AS [ExchangeTypeID], 0 AS UnitPrice FROM [TEKSTIL_UYG].[dbo].[VWARGE_SUBITEMS] WHERE [Reçete No] = '{receteNo}' ORDER BY LineNumber");

                    cmd.CommandText = sql.ToString();
                    cmd.CommandType = CommandType.Text;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, "TEXURH");

                    return ds.Tables[0];
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

            return null;
        }

        public DataTable GetUnitPrice(string stockCode)
        {
            if (Database.CheckConnection(_dataConnection))
            {
                var cmd = _dataConnection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[SPARGE_CHEMICALUNITPRICE]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StockCode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@StockCode"].Value = stockCode;
                    cmd.Parameters["@StockCode"].Direction = ParameterDirection.Input;

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, "SPARGE_CHEMICALUNITPRICE");

                    return ds.Tables[0];
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

            return null;

            //return Database.GetRow($"EXEC [dbo].[SPARGE_CHEMICALUNITPRICE] '{StockCode}'", DataConnection);
        }

        public static DataTable GetCPMProduct(SqlConnection connection) //string MainStockCode,
        {
            if (Database.CheckConnection(connection))
            {
                DataTable dt = new DataTable();

                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spCPMProductSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var da = new SqlDataAdapter(cmd);

                    da.Fill(dt);

                    return dt;
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

            return null;
        }

        public static DataTable GetCPMOrder(SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                DataTable dt = new DataTable();

                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spCPMOrderSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var da = new SqlDataAdapter(cmd);
                    //var ds = new DataSet();
                    da.Fill(dt);

                    return dt;
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

            return null;
        }

        public static DataTable GetCPMCostOrder(object check, SqlConnection connection)
        {
            if (Database.CheckConnection(connection))
            {
                DataTable dt = new DataTable();

                var cmd = connection.CreateCommand();
                try
                {
                    cmd.CommandText = "[dbo].[spCPMCostOrderSelect]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Check", SqlDbType.Int);
                    cmd.Parameters["@Check"].Value = Utility.ToDBNull(check);
                    cmd.Parameters["@Check"].Direction = ParameterDirection.Input;

                    var da = new SqlDataAdapter(cmd);
                    //var ds = new DataSet();
                    da.Fill(dt);

                    return dt;
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

            return null;
        }
    }
}