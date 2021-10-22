using System;

namespace BoyArge
{
    public partial class WaitFormTest : DevExpress.XtraWaitForm.WaitForm

    {
        public WaitFormTest()
        {
            InitializeComponent();

            this.Width = 300;
            SetCaption("Lütfen Bekleyiniz.");
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion Overrides

        public enum WaitFormCommand
        {
        }
    }
}