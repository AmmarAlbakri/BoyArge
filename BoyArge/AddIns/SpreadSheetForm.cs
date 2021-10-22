using DevExpress.XtraEditors;
using System;
using System.IO;

namespace BoyArge
{
    public partial class SpreadSheetForm : XtraForm
    {
        public SpreadSheetForm()
        {
            InitializeComponent();
        }

        public Stream StreamData { get; set; }

        private void SpreadSheetForm_Load(object sender, EventArgs e)
        {
            try
            {
                spreadsheetControl.LoadDocument(StreamData);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}