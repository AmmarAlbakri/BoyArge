using DevExpress.DashboardCommon;

namespace BoyArge
{
    public partial class ProductionOrderDashboard : Dashboard
    {
        public ProductionOrderDashboard()
        {
            InitializeComponent();

            //this.Parameters["Year"].Value = StartForm.CPMParameter.Year;

            //string[] years = new string[DateTime.Now.Year - 2014];

            //for (int i = DateTime.Now.Year; i > 2014; i--)
            //    years[DateTime.Now.Year-i] = i.ToString();

            //StaticListLookUpSettings staticListLookUpSettings1 = new StaticListLookUpSettings();
            //staticListLookUpSettings1.Values = years;

            //this.Parameters["Year"].LookUpSettings = staticListLookUpSettings1;
            //this.Parameters["EvrakDurum"].Value = StartForm.CPMParameter.EvrakDurum;
            //this.Parameters["UretimDurum"].Value = StartForm.CPMParameter.UretimDurum;
        }
    }
}