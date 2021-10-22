using Business;
using Core;
using DevExpress.XtraEditors;
using System;

namespace BoyArge
{
    public partial class OrderReportForm : XtraForm
    {
        public OrderReportForm()
        {
            InitializeComponent();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            var cpm = new CPMDatabase();
            pivotGridControl1.DataSource = cpm.GetOrderReportDaily(Utility.ToDateTime(dateEditStart.DateTime.Date),
                Utility.ToDateTime(dateEditEnd.DateTime.Date));
        }

        private void OrderReportForm_Load(object sender, EventArgs e)
        {
            dateEditStart.EditValue = DateTime.Now.Date;
            dateEditEnd.EditValue = DateTime.Now.Date;
        }
    }
}