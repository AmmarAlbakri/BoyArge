using Core;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Business
{
    public class Stock
    {
        /// <summary>
        ///     Sql bağlantı nesnesi
        /// </summary>
        private readonly SqlConnection _dataConnection;

        public Stock()
        {
            _dataConnection = Database.Connect(new SqlConnectionStringBuilder
            {
                DataSource = "CPM",
                InitialCatalog = "TEKSTIL_UYG",
                UserID = "arge",
                Password = "Arge*2020!"
            });
        }

        ~Stock()
        {
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

        /// <summary>
        ///     CPM Malzeme Listesini döndürür, Tablo: STKKRT
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetList()
        {
            var sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine("    STKKRT.MALKOD AS [Code],");
            sql.AppendLine("	STKKRT.MALAD AS [Name],");
            //sql.AppendLine("    ,STKKRT.ACIKLAMA1 AS [Açıklama-1],");
            //sql.AppendLine("    STKKRT.ACIKLAMA2 AS [Açıklama-2],");
            //sql.AppendLine("    STKKRT.ACIKLAMA4 AS [Ürün Tanımı-2],");
            //sql.AppendLine("    GRUPKOD.ACIKLAMA AS [Grup Kodu],");
            //sql.AppendLine("	OZELKOD.ACIKLAMA AS [Özel Kod],");
            //sql.AppendLine("    STKKRT.MALAD2 AS [Ürün Tanımı],");
            //sql.AppendLine("    STKKRT.MALKOD2 AS [Mal Kodu-2],");
            sql.AppendLine("	MKOD1.ACIKLAMA AS [İplik Katı],");
            sql.AppendLine("    MKOD2.ACIKLAMA AS [İplik Ölçü Birimi],");
            sql.AppendLine("    MKOD5.ACIKLAMA AS [İplik Özelliği],");
            sql.AppendLine("    MKOD6.ACIKLAMA AS [İplik Görünüm],");
            sql.AppendLine("    MKOD7.ACIKLAMA AS [İplik Efekt+Özellik],");
            sql.AppendLine("    MKOD8.ACIKLAMA AS [İplik Tip-1],");
            sql.AppendLine("    MKOD9.ACIKLAMA AS [İplik Tip-2],");
            //sql.AppendLine("	CONVERT(float,STKKRT.NKOD1) AS [İplik Numarası],");
            sql.AppendLine("    STKKRT.NOT1 AS [Karışım Oranları]");
            //sql.AppendLine("    STKKRT.NOT2 AS [Karışım Tipleri] ,");
            //sql.AppendLine("    SKOD1.ACIKLAMA AS [Elyaf Kod-1],");
            //sql.AppendLine("    SKOD2.ACIKLAMA AS [Elyaf Kod-2],");
            //sql.AppendLine("    SKOD3.ACIKLAMA  AS [Elyaf Tanım-1],");
            //sql.AppendLine("    SKOD4.ACIKLAMA AS [Elyaf Tanım-2],");
            //sql.AppendLine("    SKOD5.ACIKLAMA AS [Elyaf Özellik-1],");
            //sql.AppendLine("    SKOD6.ACIKLAMA AS [Elyaf Özellik-2],");
            //sql.AppendLine("	STKKRT.BIRIM AS [Birim]");
            sql.AppendLine("FROM dbo.STKKRT STKKRT WITH(NOLOCK)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT MKOD1 WITH(NOLOCK) ON(MKOD1.TABLOAD = 'STKKRT' AND MKOD1.ALANAD = 'MKOD1' AND MKOD1.KOD = STKKRT.MKOD1)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT MKOD2 WITH(NOLOCK) ON(MKOD2.TABLOAD = 'STKKRT' AND MKOD2.ALANAD = 'MKOD2' AND MKOD2.KOD = STKKRT.MKOD2)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT MKOD5 WITH(NOLOCK) ON(MKOD5.TABLOAD = 'STKKRT' AND MKOD5.ALANAD = 'MKOD5' AND MKOD5.KOD = STKKRT.MKOD5)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT MKOD6 WITH(NOLOCK) ON(MKOD6.TABLOAD = 'STKKRT' AND MKOD6.ALANAD = 'MKOD6' AND MKOD6.KOD = STKKRT.MKOD6)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT MKOD7 WITH(NOLOCK) ON(MKOD7.TABLOAD = 'STKKRT' AND MKOD7.ALANAD = 'MKOD7' AND MKOD7.KOD = STKKRT.MKOD7)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT MKOD8 WITH(NOLOCK) ON(MKOD8.TABLOAD = 'STKKRT' AND MKOD8.ALANAD = 'MKOD8' AND MKOD8.KOD = STKKRT.MKOD8)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT MKOD9 WITH(NOLOCK) ON(MKOD9.TABLOAD = 'STKKRT' AND MKOD9.ALANAD = 'MKOD9' AND MKOD9.KOD = STKKRT.MKOD9)");
            sql.AppendLine(
                " 	 LEFT OUTER JOIN dbo.REFKRT NKOD1 WITH(NOLOCK) ON(NKOD1.TABLOAD = 'STKKRT' AND NKOD1.ALANAD = 'NKOD1' AND NKOD1.KOD = CONVERT(varchar(50),STKKRT.NKOD1))");
            sql.AppendLine(
                " 	 LEFT OUTER JOIN dbo.REFKRT GRUPKOD WITH(NOLOCK) ON(GRUPKOD.TABLOAD = 'STKKRT' AND GRUPKOD.ALANAD = 'GRUPKOD' AND GRUPKOD.KOD = STKKRT.GRUPKOD)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT OZELKOD WITH(NOLOCK) ON(OZELKOD.TABLOAD = 'STKKRT' AND OZELKOD.ALANAD = 'OZELKOD' AND OZELKOD.KOD = STKKRT.OZELKOD)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT SKOD1 WITH(NOLOCK) ON(SKOD1.TABLOAD = 'STKKRT' AND SKOD1.ALANAD = 'SKOD1' AND SKOD1.KOD = STKKRT.SKOD1)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT SKOD2 WITH(NOLOCK) ON(SKOD2.TABLOAD = 'STKKRT' AND SKOD2.ALANAD = 'SKOD2' AND SKOD2.KOD = STKKRT.SKOD2)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT SKOD3 WITH(NOLOCK) ON(SKOD3.TABLOAD = 'STKKRT' AND SKOD3.ALANAD = 'SKOD3' AND SKOD3.KOD = STKKRT.SKOD3)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT SKOD4 WITH(NOLOCK) ON(SKOD4.TABLOAD = 'STKKRT' AND SKOD4.ALANAD = 'SKOD4' AND SKOD4.KOD = STKKRT.SKOD4)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT SKOD5 WITH(NOLOCK) ON(SKOD5.TABLOAD = 'STKKRT' AND SKOD5.ALANAD = 'SKOD5' AND SKOD5.KOD = STKKRT.SKOD5)");
            sql.AppendLine(
                "	 LEFT OUTER JOIN dbo.REFKRT SKOD6 WITH(NOLOCK) ON(SKOD6.TABLOAD = 'STKKRT' AND SKOD6.ALANAD = 'SKOD6' AND SKOD6.KOD = STKKRT.SKOD6)");

            sql.AppendLine("WHERE STKKRT.MALTIP = 0");
            sql.AppendLine("ORDER BY STKKRT.GRUPKOD ASC, STKKRT.MALKOD ASC");

            return GetList(sql.ToString(), "STKKRT");
        }

        /// <summary>
        ///     İplik Tipi Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:MKOD1
        ///     Örnek: 1, 1x2, 1x3, . . . , x8
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable IplikTipiList()
        {
            return GetList(GetQueryString("STKKRT", "MKOD1"), "STKKRT");
        }

        /// <summary>
        ///     İplik Ölçü Birimi Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:MKOD2
        ///     Örnek: NE, NM
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable IplikOlcuBirimiList()
        {
            return GetList(GetQueryString("STKKRT", "MKOD2"), "STKKRT");
        }

        /// <summary>
        ///     İplik Özelliği Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:MKOD5
        ///     Örnek: LASE, MULINE, BUKLET
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable IplikOzelligiList()
        {
            return GetList(GetQueryString("STKKRT", "MKOD5"), "STKKRT");
        }

        /// <summary>
        ///     İplik Gorunum Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:MKOD6
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable IplikGorunumList()
        {
            return GetList(GetQueryString("STKKRT", "MKOD6"), "STKKRT");
        }

        /// <summary>
        ///     İplik Efekt+Özellik Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:MKOD7
        ///     Örnek: ŞARDON, FLAM, FİTİL
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable IplikEfektOzellikList()
        {
            return GetList(GetQueryString("STKKRT", "MKOD7"), "STKKRT");
        }

        /// <summary>
        ///     İplik Tip-1 Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:MKOD8
        ///     Örnek: RX, HB
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable IplikTip1List()
        {
            return GetList(GetQueryString("STKKRT", "MKOD8"), "STKKRT");
        }

        /// <summary>
        ///     İplik Tip-2 Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:MKOD9
        ///     Örnek: İğne Sayısı
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable IplikTip2List()
        {
            return GetList(GetQueryString("STKKRT", "MKOD9"), "STKKRT");
        }

        /// <summary>
        ///     İplik Numara Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:NKOD1
        ///     Örnek: 1, 1.1 , 1.3, ....., 24.5
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable IplikNumaraList()
        {
            return GetList(GetQueryString("STKKRT", "NKOD1"), "STKKRT");
        }

        /// <summary>
        ///     İplik Numara Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:OZELKOD
        ///     Örnek: 01-Genel, 02-Akrilik, 03-Pamuk
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable UrunGrubuList()
        {
            return GetList(GetQueryString("STKKRT", "OZELKOD"), "STKKRT");
        }

        /// <summary>
        ///     İplik Numara Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:SKOD1
        ///     Örnek: 1.65 DTEX, 23 MICRON, 70 DENYE
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ElyafKod1List()
        {
            return GetList(GetQueryString("STKKRT", "SKOD1"), "STKKRT");
        }

        /// <summary>
        ///     İplik Numara Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:SKOD2
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ElyafKod2List()
        {
            return GetList(GetQueryString("STKKRT", "SKOD2"), "STKKRT");
        }

        /// <summary>
        ///     İplik Numara Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:SKOD3
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ElyafTanim1List()
        {
            return GetList(GetQueryString("STKKRT", "SKOD3"), "STKKRT");
        }

        /// <summary>
        ///     İplik Numara Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:SKOD4
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ElyafTanim2List()
        {
            return GetList(GetQueryString("STKKRT", "SKOD4"), "STKKRT");
        }

        /// <summary>
        ///     İplik Numara Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:SKOD5
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ElyafOzellik1List()
        {
            return GetList(GetQueryString("STKKRT", "SKOD5"), "STKKRT");
        }

        /// <summary>
        ///     İplik Numara Listesini geri döndürür
        ///     Tablo:STKKRT  Kolon:SKOD6
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ElyafOzellik2List()
        {
            return GetList(GetQueryString("STKKRT", "SKOD6"), "STKKRT");
        }

        /// <summary>
        ///     Boyama Türü Tablo: TEXSPK Kolon: SKOD5
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable PaintType()
        {
            return GetList(GetQueryString("TEXSPK", "SKOD5"), "TEXSPK");
        }

        /// <summary>
        ///     REFKRT tablosundan, parametrelerini girdiğimiz Tablo ve Alanlara ilişkin sorguyu oluşturur
        /// </summary>
        /// <param name="tableName">Tablo Adı</param>
        /// <param name="field">Kolon Adı</param>
        /// <returns></returns>
        private string GetQueryString(string tableName, string field)
        {
            return
                $"SELECT [KOD] AS [Code] , ACIKLAMA AS [Name] FROM [dbo].[REFKRT] WHERE [TABLOAD] = '{tableName}' AND [ALANAD] = '{field}'";
        }

        public static DataTable ChemicalTypeList()
        {
            var dDyeProcess = new DataTable();
            dDyeProcess.Columns.Add("DyeOrChemical", typeof(int));
            dDyeProcess.Columns.Add("Code", typeof(string));

            dDyeProcess.Rows.Add(0, "Boya");
            dDyeProcess.Rows.Add(1, "Kimyasal");

            return dDyeProcess;
        }
    }
}