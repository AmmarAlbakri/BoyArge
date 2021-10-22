using BoyArge.Properties;
using Business;
using Core;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Settings = Business.Settings;

namespace BoyArge
{
    public partial class LoginForm : Form
    {
        #region Definitions

        public static SqlConnection DataConnection;
        public static Settings Settings;
        public static long UserId { get; set; }
        public static string UserStatus { get; set; }

        public static string UserName { get; set; }

        #endregion Definitions

        #region Events

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            checkBoxBeniHatirla.Checked = Properties.Settings.Default.checkBeniHatirla;
            SetConnection();
            txtUserName.Text = Properties.Settings.Default.userName.ToString().Trim();
            txtPassword.Text = Properties.Settings.Default.Password.ToString().Trim();
            //txtUserName.Text = "admin";
            //txtPassword.Text = "123";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var fSettings = new SettingsForm();

            try
            {
                fSettings.ShowDialog();

                if (Settings == null)
                {
                    XtraMessageBox.Show(Resources.ConnectionFailed, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
            }
            finally
            {
                fSettings.Dispose();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Resources.QuestionExit, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close();
        }

        #endregion Events

        #region Functions

        public void SetConnection()
        {
            try
            {
                if (File.Exists(@"settings.json")) Settings = Settings.ReadSettings();

                if (Settings == null)
                {
                    var fSettings = new SettingsForm();
                    fSettings.ShowDialog();
                }

                if (Settings != null)
                    DataConnection = Database.Connect(new SqlConnectionStringBuilder
                    {
                        DataSource = Settings.Decrypt(Settings.DataSource, Settings.Key),
                        InitialCatalog = Settings.Decrypt(Settings.InitialCatalog, Settings.Key),
                        UserID = Settings.Decrypt(Settings.UserName, Settings.Key),
                        Password = Settings.Decrypt(Settings.Password, Settings.Key)
                    });
            }
            catch (FileLoadException exf)
            {
                MessageBox.Show(exf.Message);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        public void Login()
        {
            if (checkBoxBeniHatirla.Checked)
            {
                Properties.Settings.Default.checkBeniHatirla = true;
                Properties.Settings.Default.userName = txtUserName.Text.ToString().Trim();
                Properties.Settings.Default.Password = txtPassword.Text.ToString().Trim();
            }
            if (!checkBoxBeniHatirla.Checked)
            {
                Properties.Settings.Default.checkBeniHatirla = false;
                Properties.Settings.Default.userName = "";
                Properties.Settings.Default.Password = "";
            }
            if (Database.CheckConnection(DataConnection))
                try
                {
                    if (txtUserName.Text.Length == 0 || txtPassword.Text.Length == 0)
                    {
                        XtraMessageBox.Show(UserLookAndFeel.Default, Resources.EmptySpaceWarning, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    UserId = User.Login(DataConnection, txtUserName.Text, txtPassword.Text);
                    UserName = txtUserName.Text;

                    if (UserId <= 0)
                    {
                        XtraMessageBox.Show(UserLookAndFeel.Default, Resources.WrongPassword, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        SqlCommand cmd = new SqlCommand($"SELECT * FROM tblUser where UserID={UserId}", DataConnection);
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader passwordReader = cmd.ExecuteReader();
                        passwordReader.Read();

                        UserStatus = passwordReader["Phone"].ToString();

                        passwordReader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    Hide();

                    SplashScreenManager.ShowForm(typeof(SplashBoyar));
                    Thread.Sleep(1000);
                    SplashScreenManager.CloseForm();

                    var fStart = new StartForm();
                    fStart.ShowDialog();

                    Close();
                }
                catch (SqlException exc)
                {
                    XtraMessageBox.Show(UserLookAndFeel.Default, exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(UserLookAndFeel.Default, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                XtraMessageBox.Show(UserLookAndFeel.Default, Resources.LoginFailed, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion Functions
    }
}