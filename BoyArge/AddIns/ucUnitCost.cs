using System.Windows.Forms;

namespace BoyArge
{
    public partial class UcUnitCost : UserControl
    {
        public UcUnitCost()
        {
            InitializeComponent();
        }

        public object UnitCost
        {
            set => lblUnitCost.Text = value.ToString();
        }

        public object BottleNeck
        {
            set => lblBottleNeck.Text = value.ToString();
        }
    }
}