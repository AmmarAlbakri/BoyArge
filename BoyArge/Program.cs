using DevExpress.UserSkins;
using System;
using System.IO;
using System.Windows.Forms;

namespace BoyArge
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                BonusSkins.Register();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new LoginForm());

                //Application.Run(new DocumentForm());
            }
            catch (FileLoadException exf)
            {
                MessageBox.Show(exf.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}