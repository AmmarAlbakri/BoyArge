using Business;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class CurrentAccountForm : XtraForm
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        private readonly CPMDatabase _cpm = new CPMDatabase();

        public CurrentAccountForm()
        {
            InitializeComponent();
        }

        private void CurrentAccountForm_Load(object sender, EventArgs e)
        {
            _bindingSource.DataSource = _cpm.GetCurrentAccount();

            grdCurrentAccount.DataSource = _bindingSource;
        }

        private void CustomersTileBarItem_ItemClick(object sender, TileItemEventArgs e)
        {
            _bindingSource.Filter = "";
            grdCurrentAccount.DataSource = _bindingSource;
        }

        private void BtnDisPiyasa_ItemClick(object sender, TileItemEventArgs e)
        {
            _bindingSource.Filter = "FirmaTip = 'Dış Piyasa'";
            grdCurrentAccount.DataSource = _bindingSource;
        }

        private void BtnIcPiyasa_ItemClick(object sender, TileItemEventArgs e)
        {
            _bindingSource.Filter = "FirmaTip = 'İç Piyasa'";
            grdCurrentAccount.DataSource = _bindingSource;
        }
    }
}