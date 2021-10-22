using Business;
using System;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class StockDataSetForm : Form
    {
        private readonly Stock _stock = new Stock();

        public StockDataSetForm()
        {
            InitializeComponent();
        }

        private void StockDataSetForm_Load(object sender, EventArgs e)
        {
            grdIplikOzelligi.DataSource = _stock.IplikOzelligiList();
            grdIplikGorunum.DataSource = _stock.IplikGorunumList();
            grdIplikOlcuBirimi.DataSource = _stock.IplikOlcuBirimiList();
            grdIplikTipi.DataSource = _stock.IplikTipiList();
        }
    }
}