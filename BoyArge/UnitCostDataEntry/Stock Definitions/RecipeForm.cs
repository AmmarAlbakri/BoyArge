using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class RecipeForm : XtraForm
    {
        public RecipeForm()
        {
            InitializeComponent();
        }

        public DataTable DRecipe { get; set; }

        private void RecipeForm_Load(object sender, EventArgs e)
        {
            if (DRecipe.Rows.Count > 0)
                Text += " - " + DRecipe.Rows[0]["Reçete No"];

            try
            {
                treeList.DataSource = DRecipe;
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}