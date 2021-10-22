using Business;
using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class StockForm : XtraForm
    {
        #region Definitions

        private Stock _stock;
        private CPMDatabase _cpm;

        #endregion Definitions

        #region Events

        public StockForm()
        {
            InitializeComponent();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            _stock = new Stock();
            _cpm = new CPMDatabase();
            grdStock.DataSource = _stock.GetList();
        }

        private void ItemStockDataSet_Click(object sender, EventArgs e)
        {
            var fStockDataSet = new StockDataSetForm();

            fStockDataSet.ShowDialog();
        }

        private void ItemRecipe_Click(object sender, EventArgs e)
        {
            if (grvStock.FocusedRowHandle >= 0)
            {
                var dRecipe = _cpm.GetRecipe(grvStock.GetFocusedRowCellValue("Code").ToString());
                var fRecipe = new RecipeForm();

                try
                {
                    if (dRecipe != null && dRecipe.Rows.Count > 0)
                    {
                        fRecipe.DRecipe = dRecipe;

                        fRecipe.ShowDialog();
                    }
                }
                catch (SqlException exc)
                {
                    XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                finally
                {
                    fRecipe.Dispose();
                }
            }
        }

        private void ItemProductTree_Click(object sender, EventArgs e)
        {
            if (grvStock.FocusedRowHandle >= 0)
            {
                var fProductTree = new CalculateForm();

                try
                {
                    fProductTree.Tag = grvStock.GetFocusedRowCellValue("Code").ToString();
                    fProductTree.ShowDialog();
                }
                catch (SqlException exc)
                {
                    XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                finally
                {
                    fProductTree.Dispose();
                }
            }
        }

        #endregion Events
    }
}