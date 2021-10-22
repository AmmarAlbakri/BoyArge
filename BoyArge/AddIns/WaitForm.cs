using System;

namespace BoyArge
{
    public partial class WaitForm : DevExpress.XtraWaitForm.WaitForm
    {
        public int Seconds { get; set; }
        private readonly System.Windows.Forms.Timer timer;

        public enum WaitFormCommand
        {
        }

        public WaitForm(int seconds = 0)
        {
            InitializeComponent();

            this.Seconds = seconds;
            progressPanel.AutoHeight = true;

            if (this.Seconds <= 0) return;

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += Tick;
            timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            this.progressPanel.Description = $"Yükleniyor... {this.Seconds}";

            this.Seconds--;

            if (this.Seconds == 0)
            {
                this.timer.Stop();
                this.Dispose();
            }
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion Overrides
    }
}