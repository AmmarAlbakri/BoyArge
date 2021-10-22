using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BoyArge
{
    internal static class LookUpEditFill
    {
        private static string GetQueryLookUpEdit(string tableName, string field)
        {
            return
                $"SELECT [KOD] AS [Code] , ACIKLAMA AS [Name] FROM [dbo].[REFKRT] WHERE [TABLOAD] = '{tableName}' AND [ALANAD] = '{field}'";
        }

        private static DataTable GetList(string query, string srcTable)
        {
            if (query == string.Empty)
                return null;

            var cmd = FormPlanlama.con.CreateCommand();
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
                XtraMessageBox.Show(e.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public static void LookUpEdit(LookUpEdit lookUpEdit, string[] visibleFieldName, string displayMember,
            string valueMember, DataTable dLookupEdit)
        {
            lookUpEdit.Properties.DataSource = dLookupEdit;
            lookUpEdit.Properties.DisplayMember = displayMember;
            lookUpEdit.Properties.ValueMember = valueMember;
            lookUpEdit.Properties.NullText = "Seçiniz";

            lookUpEdit.Properties.PopulateColumns();

            foreach (LookUpColumnInfo column in lookUpEdit.Properties.Columns)
            {
                if (!visibleFieldName.Contains(column.FieldName))
                    column.Visible = false;

                if (column.FieldName == "Name")
                    column.Caption = "Adı";
                if (column.FieldName == "Code")
                    column.Caption = "Kodu";
                if (column.FieldName == "Definition")
                    column.Caption = "Tanım";
            }
        }

        public static void LookUpEdit(RepositoryItemLookUpEdit lookUpEdit, string[] visibleFieldName,
            string displayMember, string valueMember, DataTable dLookupEdit)
        {
            lookUpEdit.DataSource = dLookupEdit;
            lookUpEdit.DisplayMember = displayMember;
            lookUpEdit.ValueMember = valueMember;
            lookUpEdit.NullText = "Seçiniz";

            lookUpEdit.PopulateColumns();

            foreach (LookUpColumnInfo column in lookUpEdit.Columns)
            {
                if (!visibleFieldName.Contains(column.FieldName))
                    column.Visible = false;

                if (column.FieldName == "Name")
                    column.Caption = "Adı";

                if (column.FieldName == "Code")
                    column.Caption = "Kodu";

                if (column.FieldName == "Definition")
                    column.Caption = "Tanım";
            }
        }

        public static DataTable GetBoyamahaneIslemiTable()
        {
            return GetList(GetQueryLookUpEdit("TEXMRH", "BKOD1"), "TEXMRH");
        }

        public static DataTable GetUretimYeriTable()
        {
            return GetList(GetQueryLookUpEdit("TEXMRH", "BKOD4"), "TEXMRH");
        }

        public static DataTable GetBoyamaSekliTable()
        {
            return GetList(GetQueryLookUpEdit("TEXSPK", "SKOD5"), "TEXMRH");
        }

        public static DataTable GetMiktarDurum()
        {
            return GetList(GetQueryLookUpEdit("TEXMRH", "MIKTARDURUM"), "TEXMRH");
        }

        public static DataTable GetRenkDurum()
        {
            var dColorType = new DataTable();
            dColorType.Columns.Add("Code", typeof(int));
            dColorType.Columns.Add("ColorType", typeof(string));

            dColorType.Rows.Add(0, "");
            dColorType.Rows.Add(1, "Açık");
            dColorType.Rows.Add(2, "Orta");
            dColorType.Rows.Add(3, "Koyu");
            dColorType.Rows.Add(4, "Süper Koyu");

            return dColorType;
        }
    }
}