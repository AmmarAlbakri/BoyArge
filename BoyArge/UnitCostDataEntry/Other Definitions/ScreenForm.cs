using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Screen = Business.Screen;

namespace BoyArge
{
    public partial class ScreenForm : RibbonForm
    {
        #region Definitions

        private readonly Screen _ekran = new Screen(LoginForm.DataConnection);
        private long ScreenId { get; set; }
        private Guid RowGuid { get; set; }

        #endregion Definitions

        #region Events

        public ScreenForm()
        {
            InitializeComponent();
        }

        private void ScreenForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvScreen_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvScreen_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvScreen.CalcHitInfo(e.Point).InColumn) return;

            if (grvScreen.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvScreen.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdScreen.PointToScreen(e.Point));
        }

        private void ToggleSwitch_ItemClick(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Resources.AllRecords : Resources.OnlyActiveRecords;
            RefreshList();
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvScreen.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvScreen.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var ScreenId = Utility.ToInt32(grvScreen.GetFocusedRowCellValue(colScreenID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, Screen.TableName, "ScreenID", ScreenId,
                    newStatus);

                if (result <= 0)
                    _ = XtraMessageBox.Show(Resources.UpdateError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    _ = XtraMessageBox.Show(Resources.UpdateInfo, Text, MessageBoxButtons.OK,
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

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdScreen.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _ekran.Record.Reset();

            ScreenId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvScreen.FocusedRowHandle >= 0)
            {
                _ekran.Record.Change(grvScreen.GetFocusedDataRow());

                rowScreenID.Properties.Value = ScreenId = _ekran.Record.ScreenID;
                rowParentID.Properties.Value = _ekran.Record.ParentID;
                rowName.Properties.Value = _ekran.Record.Name;
                rowControlName.Properties.Value = _ekran.Record.ControlName;
                rowDefinition.Properties.Value = _ekran.Record.Definition;
                rowStatus.Properties.Value = (byte)_ekran.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _ekran.Record.RowGUID;

                foreach (var row in vGrdScreen.Rows)
                    if (_ekran.Record.Status == Screen.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _ekran.Record.Reset();
                ScreenId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdScreen.FocusNext();
            vGrdScreen.Update();

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

                        if (ScreenId == 0)
                        {
                            object ScreenId = 0;
                            object guid = Guid.Empty;

                            result = _ekran.Insert(ref ScreenId, rowParentID.Properties.Value, rowName.Properties.Value,
                                rowControlName.Properties.Value, rowDefinition.Properties.Value,
                                rowStatus.Properties.Value, ref guid);

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
                            result = _ekran.Update(ScreenId, rowParentID.Properties.Value, rowName.Properties.Value,
                                rowControlName.Properties.Value, rowDefinition.Properties.Value,
                                rowStatus.Properties.Value, RowGuid);
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
            if (Utility.ToLong(ScreenId) == 0) return;
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (ScreenId > 0)
                        {
                            var result = _ekran.Delete(ScreenId);
                            if (result > 0)
                            {
                                XtraMessageBox.Show(Resources.DeleteInfo, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                NewRecord();
                                RefreshList();
                            }
                            else
                            {
                                XtraMessageBox.Show(Resources.DeleteError, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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

        private void RefreshList()
        {
            try
            {
                grdScreen.DataSource = Screen.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdScreen.RefreshDataSource();

                grvScreen.FocusedRowHandle = -1;
                NewRecord();

                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, Screen.TableName);
                var dParent = Screen.GetList(LoginForm.DataConnection);

                Format.LookUpEdit(lookParentID, new[] { "Name" }, "Name", "ScreenID", dParent);
                Format.LookUpEdit(lookGrdParent, new[] { "Name" }, "Name", "ScreenID", dParent);
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
            if (rowName.Properties.Value == null)
                return false;

            return true;
        }

        #endregion Functions
    }
}