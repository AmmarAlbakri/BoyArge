using Business;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class SettingsForm : XtraForm
    {
        #region Definitions

        public string DataSource
        {
            get => txtDataSource.Text;
            set => txtDataSource.Text = value;
        }

        public string InitialCatalog
        {
            get => txtInitialCatalog.Text;
            set => txtInitialCatalog.Text = value;
        }

        public string UserName
        {
            get => txtUserName.Text;
            set => txtUserName.Text = value;
        }

        public string Password
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value;
        }

        public bool IntegratedSecurity
        {
            get => chcIntegratedSecurity.Checked;
            set => chcIntegratedSecurity.Checked = value;
        }

        #endregion Definitions

        #region Events

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(@"settings.json")) return;
                LoginForm.Settings = Settings.ReadSettings();

                DataSource = Settings.Decrypt(LoginForm.Settings.DataSource, Settings.Key);
                InitialCatalog = Settings.Decrypt(LoginForm.Settings.InitialCatalog, Settings.Key);
                UserName = Settings.Decrypt(LoginForm.Settings.UserName, Settings.Key);
                Password = Settings.Decrypt(LoginForm.Settings.Password, Settings.Key);
                IntegratedSecurity = LoginForm.Settings.IntegratedSecurity;
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

        private void ChcIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (chcIntegratedSecurity.Checked)
                chcIntegratedSecurity.Font =
                    new Font(chcIntegratedSecurity.Font.FontFamily.Name, chcIntegratedSecurity.Font.Size,
                        FontStyle.Bold);
            else
                chcIntegratedSecurity.Font = new Font(chcIntegratedSecurity.Font.FontFamily.Name,
                    chcIntegratedSecurity.Font.Size, FontStyle.Regular);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"settings.json")) File.Delete(@"settings.json");

            var settings = new Settings
            {
                DataSource = Settings.Encrypt(txtDataSource.Text, Settings.Key),
                InitialCatalog = Settings.Encrypt(txtInitialCatalog.Text, Settings.Key),
                UserName = Settings.Encrypt(txtUserName.Text, Settings.Key),
                Password = Settings.Encrypt(txtPassword.Text, Settings.Key),
                IntegratedSecurity = chcIntegratedSecurity.Checked
            };

            try
            {
                SplashScreenManager.ShowForm(typeof(WaitForm));
                Settings.WriteJsonSettings(settings);
                SplashScreenManager.CloseForm();

                XtraMessageBox.Show("Kaydedildi, Yeniden Oturum Açın!", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Events
    }
}