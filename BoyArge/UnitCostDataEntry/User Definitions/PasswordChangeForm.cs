using BoyArge.Properties;
using Business;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class PasswordChangeForm : XtraForm
    {
        #region Definitions

        private string OldPassword
        {
            get => txtOldPassword.Text;
            set => txtOldPassword.Text = value;
        }

        private string NewPassword
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value;
        }

        private string NewPassword2
        {
            get => txtPassword2.Text;
            set => txtPassword2.Text = value;
        }

        #endregion Definitions

        #region Events

        public PasswordChangeForm()
        {
            InitializeComponent();
        }

        private void PBarControl_EditValueChanged(object sender, EventArgs e)
        {
            switch (pBarControl.EditValue)
            {
                case 0:
                    pBarControl.ForeColor = Color.Red;
                    lblState.ForeColor = Color.Red;
                    lblState.Text = "";
                    break;

                case 1:
                    pBarControl.ForeColor = Color.DimGray;
                    lblState.ForeColor = Color.DimGray;
                    lblState.Text = "Zayıf";
                    break;

                case 2:
                    pBarControl.ForeColor = Color.Orange;
                    lblState.ForeColor = Color.Orange;
                    lblState.Text = "Orta";
                    break;

                case 3:
                    pBarControl.ForeColor = Color.Green;
                    lblState.ForeColor = Color.Green;
                    lblState.Text = "Güçlü";
                    break;
            }
        }

        private void TxtPassword_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                pBarControl.EditValue = 0;
            }
            else
            {
                var score = 0;

                if (txtPassword.Text.Length < 4)
                    score += 1;

                if (txtPassword.Text.Length >= 4)
                    score += 4;

                if (txtPassword.Text.Length >= 12)
                    score += 5;

                if (Regex.IsMatch(txtPassword.Text, @"[a-z]") && Regex.IsMatch(txtPassword.Text, @"[A-Z]"))
                    score += 2;

                if (Regex.IsMatch(txtPassword.Text, @"[!@#\$%\^&\*\?_~\-\(\);\.\+:]+"))
                    score += 3;

                if (score < 2)
                    pBarControl.EditValue = 0;
                else if (score < 6)
                    pBarControl.EditValue = 1;
                else if (score < 12)
                    pBarControl.EditValue = 2;
                else
                    pBarControl.EditValue = 3;
            }
        }

        private void TxtPassword2_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPassword2.Text)
            {
                lblState.ForeColor = Color.Red;
                lblState.Text = "Parola Eşleşmiyor";
            }
            else
            {
                lblState.ForeColor = Color.Black;
                lblState.Text = "";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (NewPassword.Length == 0 || NewPassword2.Length == 0 || OldPassword.Length == 0)
            {
                XtraMessageBox.Show(UserLookAndFeel.Default, Resources.EmptySpaceWarning, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (NewPassword != NewPassword2)
            {
                XtraMessageBox.Show(UserLookAndFeel.Default, "Parolalar eşleşmiyor!", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (NewPassword.Length < 4)
            {
                XtraMessageBox.Show(UserLookAndFeel.Default, "Parola en az 4 karakter uzunluğunda olmalıdır!", Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                var result = User.UpdatePassword(LoginForm.DataConnection, LoginForm.UserId, OldPassword, NewPassword);

                if (result <= 0) return;

                XtraMessageBox.Show(UserLookAndFeel.Default, "Parolanız Değişti!", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(UserLookAndFeel.Default, exc.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(UserLookAndFeel.Default, ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Events
    }
}