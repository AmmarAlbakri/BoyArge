using System;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class GridViewerForm : Form
    {
        public int Seconds { get; set; }
        public bool StatePause = false;
        public object Data { get; set; }

        public GridViewerForm()
        {
            InitializeComponent();
        }

        private void GridViewerForm_Load(object sender, EventArgs e)
        {
            if (Seconds <= 0) return;

            this.lblSeconds.Text = Seconds.ToString();

            this.gridControl.DataSource = Data;
            this.gridView.BestFitColumns();

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Seconds--;
            this.lblSeconds.Text = Seconds.ToString();

            if (Seconds == 0)
            {
                timer.Stop();
                this.Close();
            }
        }

        private void BtnPlayPause_Click(object sender, EventArgs e)
        {
            StatePause = !StatePause;

            if (StatePause)
            {
                timer.Stop();
                this.btnPlayPause.ImageOptions.SvgImage = Properties.Resources.next;
            }
            else
            {
                timer.Start();
                this.btnPlayPause.ImageOptions.SvgImage = Properties.Resources.pause;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}