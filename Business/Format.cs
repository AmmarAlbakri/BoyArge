using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System.Data;
using System.Linq;

namespace Business
{
    public class Format
    {
        ~Format()
        {
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
    }
}