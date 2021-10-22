using Business;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class ScreenPermissionForm : RibbonForm
    {
        #region Definitions

        private CustomObservableCollection<ScreenPermission.Recording> screenPermissionItems =
            new CustomObservableCollection<ScreenPermission.Recording>();

        private readonly List<long> changedRowList = new List<long>();

        #endregion Definitions

        #region Events

        public ScreenPermissionForm()
        {
            InitializeComponent();

            screenPermissionItems = ScreenPermission.GetScreenPermissions(LoginForm.DataConnection);
        }

        private void ScreenPermissionEditForm_Load(object sender, EventArgs e)
        {
            grdPermission.DataSource = screenPermissionItems;

            colAccess.OptionsColumn.AllowEdit = colEdit.OptionsColumn.AllowEdit = true;

            grvPermission.CollapseGroupLevel(1);
        }

        private void GrvPermission_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var _id = screenPermissionItems[e.RowHandle].ScreenPermissionID;

            if (!changedRowList.Contains(_id))
                changedRowList.Add(_id);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Değişiklikler kaydedilsin mi?", Text, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var screenPermission = new ScreenPermission(LoginForm.DataConnection);

                foreach (var record in screenPermissionItems)
                    foreach (var screenPermissionID in changedRowList)
                        if (record.ScreenPermissionID == screenPermissionID)
                            screenPermission.Update(record.ScreenPermissionID, record.UserID, record.ScreenID,
                                record.Access, record.Edit, record.Status, record.RowGUID);
                changedRowList.Clear();
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnUpdateAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = new ScreenPermissionGroupUpdate();
            form.ShowDialog();
            screenPermissionItems = ScreenPermission.GetScreenPermissions(LoginForm.DataConnection);
            grdPermission.DataSource = screenPermissionItems;
        }

        #endregion Events
    }
}