using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class UserForm : XtraForm
    {
        #region Definitions

        private readonly User _user = new User(LoginForm.DataConnection);
        private long UserId { get; set; }
        private Guid RowGuid { get; set; }

        public UserForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void UserForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.AddRange(new object[] { User.StatusList() });

            RefreshList();

            lookgrdUser.DataSource = User.GetList(LoginForm.DataConnection);
        }

        private void GrvUser_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void BtnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewRecord();
        }

        private void BtnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditRecord();
        }

        private void BtnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveRecord();
        }

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();
        }

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void GrvUser_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvUser.CalcHitInfo(e.Point).InColumn) return;

            if (grvUser.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvUser.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdUser.PointToScreen(e.Point));
        }

        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Resources.AllRecords : Resources.OnlyActiveRecords;
            RefreshList();
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvUser.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvUser.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var userId = Utility.ToInt32(grvUser.GetFocusedRowCellValue(colUserID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, User.TableName, "UserID", userId, newStatus);

                if (result <= 0)
                    XtraMessageBox.Show(Resources.UpdateError, Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                    XtraMessageBox.Show(Resources.UpdateInfo, Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                RefreshList();
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdUser.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _user.Record.Reset();

            UserId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvUser.FocusedRowHandle >= 0)
            {
                _user.Record.Change(grvUser.GetFocusedDataRow());

                rowUserID.Properties.Value = UserId = _user.Record.UserID;
                rowSurname.Properties.Value = _user.Record.Surname;
                rowName.Properties.Value = _user.Record.Name;
                rowUserName.Properties.Value = _user.Record.UserName;
                rowEmail.Properties.Value = _user.Record.Email;
                rowPhone.Properties.Value = _user.Record.Phone;
                rowStatus.Properties.Value = (byte)(_user.Record.Status == User.Status.Active
                    ? CheckState.Checked
                    : CheckState.Unchecked);
                rowRowGUID.Properties.Value = RowGuid = _user.Record.RowGUID;

                foreach (var row in vGrdUser.Rows)
                    if (_user.Record.Status == User.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _user.Record.Reset();
                UserId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdUser.FocusNext();
            vGrdUser.Update();

            if (!ScreenPermission.ScreenPermissionEdit(LoginForm.UserId, Tag.ToString(), LoginForm.DataConnection))
            {
                XtraMessageBox.Show(Resources.PermissionDenied, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!CheckRow())
            {
                XtraMessageBox.Show(Resources.EmptySpaceWarning, Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        int result;

                        if (UserId == 0)
                        {
                            object userId = 0;
                            object guid = Guid.Empty;

                            result = _user.Insert(ref userId, rowUserName.Properties.Value, rowName.Properties.Value,
                                rowSurname.Properties.Value, rowPassword.Properties.Value, rowEmail.Properties.Value,
                                rowPhone.Properties.Value, rowStatus.Properties.Value, ref guid);

                            if (result <= 0)
                            {
                                XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                            else
                            {
                                XtraMessageBox.Show(Resources.InsertInfo, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                        }
                        else
                        {
                            result = _user.Update(UserId, rowUserName.Properties.Value, rowName.Properties.Value,
                                rowSurname.Properties.Value, rowPassword.Properties.Value, rowEmail.Properties.Value,
                                rowPhone.Properties.Value, rowStatus.Properties.Value, RowGuid);
                            if (result <= 0)
                            {
                                XtraMessageBox.Show(Resources.UpdateError, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                            else
                            {
                                XtraMessageBox.Show(Resources.UpdateInfo, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                        }
                    }
                    catch (SqlException exc)
                    {
                        XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                    }
                else
                    XtraMessageBox.Show(Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void DeleteRecord()
        {
            if (Utility.ToLong(UserId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (Database.CheckConnection(LoginForm.DataConnection))
                try
                {
                    if (UserId <= 0) return;

                    var result = _user.Delete(UserId);
                    if (result > 0)
                    {
                        XtraMessageBox.Show(Resources.DeleteInfo, Text, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        NewRecord();
                        RefreshList();
                    }
                    else
                    {
                        XtraMessageBox.Show(Resources.DeleteError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException exc)
                {
                    XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
            else
                XtraMessageBox.Show(Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void RefreshList()
        {
            grdUser.DataSource = User.GetList(LoginForm.DataConnection);
            grdUser.RefreshDataSource();

            var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, User.TableName);

            Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
            Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);

            grvUser.FocusedRowHandle = -1;
            NewRecord();
        }

        private bool CheckRow()
        {
            if (rowName.Properties.Value == null)
                return false;

            if (rowSurname.Properties.Value == null)
                return false;
            if (rowUserName.Properties.Value == null)
                return false;

            return true;
        }

        #endregion Functions
    }
}