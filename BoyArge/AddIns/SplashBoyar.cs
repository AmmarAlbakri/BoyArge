using DevExpress.XtraSplashScreen;
using System;

namespace BoyArge
{
    public partial class SplashBoyar : SplashScreen
    {
        public enum SplashScreenCommand
        {
        }

        public SplashBoyar()
        {
            InitializeComponent();
            labelCopyright.Text = $"Copyright ©  {DateTime.Now.Year}";
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion Overrides
    }
}