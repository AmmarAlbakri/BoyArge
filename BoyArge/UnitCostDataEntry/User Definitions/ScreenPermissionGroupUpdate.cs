using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class ScreenPermissionGroupUpdate : XtraForm
    {
        public ScreenPermissionGroupUpdate()
        {
            InitializeComponent();
        }

        private void ScreenPermissionGroupUpdate_Load(object sender, EventArgs e)
        {
            Format.LookUpEdit(ModuleLookUpEdit, new[] { "Code", "Name", "Platform" }, "Name", "ModuleID",
                Database.GetList(
                    "SELECT [ModuleID], [Code], [Name], [Platform] FROM [dbo].[tblModule] WHERE [Status] > 0",
                    LoginForm.DataConnection));
            Format.LookUpEdit(UserNameLookUpEdit, new[] { "UserName", "UserID" }, "UserName", "UserID",
                User.GetList(LoginForm.DataConnection));

            var PermissionTypes = new DataTable("PermissionTypes");
            PermissionTypes.Columns.Add("Tip", typeof(string));
            PermissionTypes.Columns.Add("ID", typeof(int));

            PermissionTypes.Rows.Add("Tümü", 0);
            PermissionTypes.Rows.Add("Erişim", 1);
            PermissionTypes.Rows.Add("Düzenleme", 2);

            Format.LookUpEdit(PermissionTypeLookUpEdit, new[] { "Tip" }, "Tip", "ID", PermissionTypes);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (!checkRow()) return;

            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes) return;

            try
            {
                int result;

                var screenPermission = new ScreenPermission(LoginForm.DataConnection);

                result = screenPermission.BatchUpdate(
                    Utility.ToInt32(PermissionTypeLookUpEdit.EditValue),
                    Utility.ToInt32(ModuleLookUpEdit.EditValue),
                    Utility.ToInt32(UserNameLookUpEdit.EditValue),
                    Utility.ToBoolean(chkPermission.Checked)
                );

                if (result <= 0)
                {
                    XtraMessageBox.Show(Resources.UpdateError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show(Resources.UpdateInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ModuleLookUpEdit.EditValue = null;
                    UserNameLookUpEdit.EditValue = null;
                    PermissionTypeLookUpEdit.EditValue = null;
                    chkPermission.Checked = false;
                }
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text);
            }
        }

        private bool checkRow()
        {
            if (PermissionTypeLookUpEdit.EditValue == null) return false;

            if (ModuleLookUpEdit.EditValue == null) return false;

            if (UserNameLookUpEdit.EditValue == null) return false;

            return true;
        }
    }
}