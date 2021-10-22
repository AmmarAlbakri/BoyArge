using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Business;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace BoyArge
{
    public partial class ScreenPermissionForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Definitions
       private readonly Business.ScreenPermission _ekran = new Business.ScreenPermission(LoginForm.DataConnection);
        private long ScreenPermissionId { get; set; }
        private Guid RowGuid { get; set; }
        #endregion

        #region Events
        public ScreenPermissionForm()
        {
            InitializeComponent();
        }

        private void ScreenPermissionForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvScreenPermission_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvScreenPermission_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvScreenPermission.CalcHitInfo(e.Point).InColumn)
            {
                return;
            }

            if (grvScreenPermission.GetFocusedDataRow() == null)
            {
                return;
            }

            if (Utility.ToInt32(grvScreenPermission.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Properties.Resources._unchecked;
                btnChangeStatus.Caption = Properties.Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Properties.Resources._checked;
                btnChangeStatus.Caption = Properties.Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdScreenPermission.PointToScreen(e.Point));
        }

        private void ToggleSwitch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Properties.Resources.AllRecords : Properties.Resources.OnlyActiveRecords;
            RefreshList();
        }

        private void BtnChangeStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvScreenPermission.FocusedRowHandle < 0)
            {
                return;
            }

            var status = Utility.ToInt32(grvScreenPermission.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;


            int ScreenPermissionId = Utility.ToInt32(grvScreenPermission.GetFocusedRowCellValue(colScreenPermissionID));

            string message = status == 1 ? Properties.Resources.QuestionPassive : Properties.Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
            {
                return;
            }

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, Business.ScreenPermission.TableName, "ScreenPermissionID", ScreenPermissionId, newStatus);

                if (result <= 0)
                {
                    _ = XtraMessageBox.Show(Properties.Resources.UpdateError, Text, MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
                else
                {
                    _ = XtraMessageBox.Show(Properties.Resources.UpdateInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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

        private void BtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewRecord();
        }

        private void BtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditRecord();
        }

        private void BtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveRecord();
        }

        private void BtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void BtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region Functions
        private void NewRecord()
        {
            foreach (var row in vGrdScreenPermission.Rows)
            {
                row.Properties.Value = null; row.Properties.AllowEdit = true;
            }

            _ekran.Record.Reset();

            ScreenPermissionId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }
        private void EditRecord()
        {
            if (grvScreenPermission.FocusedRowHandle >= 0)
            {
                _ekran.Record.Change(grvScreenPermission.GetFocusedDataRow());

                rowScreenPermissionID.Properties.Value = ScreenPermissionId = _ekran.Record.ScreenPermissionID;
                rowUserID.Properties.Value = _ekran.Record.UserID;
                rowScreenID.Properties.Value = _ekran.Record.ScreenID;
                rowAccess.Properties.Value = _ekran.Record.Access;
                rowEdit.Properties.Value = _ekran.Record.Edit;
                rowStatus.Properties.Value = (byte)(_ekran.Record.Status);
                rowRowGUID.Properties.Value = RowGuid = _ekran.Record.RowGUID;

                foreach (var row in vGrdScreenPermission.Rows)
                {
                    if (_ekran.Record.Status == Business.ScreenPermission.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
                }
            }
            else
            {
                _ekran.Record.Reset();
                ScreenPermissionId = 0;
                RowGuid = Guid.Empty;
            }
        }
        private void SaveRecord()
        {
            this.vGrdScreenPermission.FocusNext();
            this.vGrdScreenPermission.Update();

            if (!Business.ScreenPermission.ScreenPermissionEdit(LoginForm.UserId, this.Tag.ToString(), LoginForm.DataConnection))
            {
                XtraMessageBox.Show(Properties.Resources.PermissionDenied, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (!CheckRow())
            {
                XtraMessageBox.Show(Properties.Resources.EmptySpaceWarning, Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (XtraMessageBox.Show(Properties.Resources.QuestionSave, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (Database.CheckConnection(LoginForm.DataConnection))
                {
                    try
                    {
                        int result;

                        if (ScreenPermissionId == 0)
                        {
                            object ScreenPermissionId = 0;
                            object guid = Guid.Empty;

                            result = _ekran.Insert(ref ScreenPermissionId, rowUserID.Properties.Value, rowScreenID.Properties.Value, rowAccess.Properties.Value, rowEdit.Properties.Value, rowStatus.Properties.Value, ref guid);

                            if (result <= 0)
                            {
                                XtraMessageBox.Show(Properties.Resources.InsertError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                XtraMessageBox.Show(Properties.Resources.InsertInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                        }
                        else
                        {
                            result = _ekran.Update(ScreenPermissionId, rowUserID.Properties.Value, rowScreenID.Properties.Value, rowAccess.Properties.Value, rowEdit.Properties.Value, rowStatus.Properties.Value, RowGuid);
                            if (result <= 0)
                            {
                                XtraMessageBox.Show(Properties.Resources.UpdateError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                XtraMessageBox.Show(Properties.Resources.UpdateInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                        }
                    }
                    catch (SqlException exc)
                    {
                        XtraMessageBox.Show(exc.Message, Properties.Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, Properties.Resources.ExceptionMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    XtraMessageBox.Show(Properties.Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DeleteRecord()
        {
            if (Utility.ToLong(this.ScreenPermissionId) == 0) return;
            if (XtraMessageBox.Show(Properties.Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                {
                    try
                    {
                        if (ScreenPermissionId > 0)
                        {
                            int result = _ekran.Delete(ScreenPermissionId);
                            if (result > 0)
                            {
                                XtraMessageBox.Show(Properties.Resources.DeleteInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                            else
                            {
                                XtraMessageBox.Show(Properties.Resources.DeleteError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    catch (SqlException exc)
                    {
                        XtraMessageBox.Show(exc.Message, Properties.Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, Properties.Resources.ExceptionMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    XtraMessageBox.Show(Properties.Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RefreshList()
        {
            try
            {
                grdScreenPermission.DataSource = Business.ScreenPermission.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdScreenPermission.RefreshDataSource();

                grvScreenPermission.FocusedRowHandle = -1;
                NewRecord();

                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, Business.ScreenPermission.TableName);
                var dScreen = Business.Screen.GetList(LoginForm.DataConnection);
                var dUser = Business.User.GetList(LoginForm.DataConnection);

                Format.LookUpEdit(lookUserID, new[] { "FullName" }, "UserName", "UserID", dUser);
                Format.LookUpEdit(lookGrdUser, new[] { "FullName" }, "UserName", "UserID", dUser);
                Format.LookUpEdit(lookScreen, new[] { "Definition" }, "Definition", "ScreenID", dScreen);
                Format.LookUpEdit(lookGrdScreen, new[] { "Definition" }, "Definition", "ScreenID", dScreen);
                Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckRow()
        {
            if (rowScreenID.Properties.Value == null)
                return false;
            if (rowUserID.Properties.Value == null)
                return false;

            return true;
        }
        #endregion
    }
}
