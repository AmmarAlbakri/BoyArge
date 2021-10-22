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

namespace BoyArge
{
    public partial class TableStatusForm : RibbonForm
    {
        #region Definitions

        private readonly TableStatus _tableStatus = new TableStatus(LoginForm.DataConnection);
        private long TableStatusId { get; set; }
        private Guid RowGuid { get; set; }

        public TableStatusForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void TableStatusForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvTableStatus_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
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

        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Resources.AllRecords : Resources.OnlyActiveRecords;
            RefreshList();
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvTableStatus.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvTableStatus.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var tableStatusId = Utility.ToInt32(grvTableStatus.GetFocusedRowCellValue(colTableStatusID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, TableStatus._TableName, "TableStatusID",
                    tableStatusId, newStatus);

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

        private void GrvTableStatus_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvTableStatus.CalcHitInfo(e.Point).InColumn) return;

            if (grvTableStatus.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvTableStatus.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;

                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdTableStatus.PointToScreen(e.Point));
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdTableStatus.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _tableStatus.Record.Reset();

            TableStatusId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvTableStatus.FocusedRowHandle >= 0)
            {
                _tableStatus.Record.Change(grvTableStatus.GetFocusedDataRow());

                rowTableStatusID.Properties.Value = TableStatusId = _tableStatus.Record.TableStatusID;
                rowTableName.Properties.Value = _tableStatus.Record.TableName;
                rowCode.Properties.Value = _tableStatus.Record.Code;
                rowName.Properties.Value = _tableStatus.Record.Name;
                rowNameEn.Properties.Value = _tableStatus.Record.NameEn;
                rowStatus.Properties.Value = (byte)_tableStatus.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _tableStatus.Record.RowGUID;

                foreach (var row in vGrdTableStatus.Rows)
                    if (_tableStatus.Record.Status == TableStatus.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _tableStatus.Record.Reset();
                TableStatusId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
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

            if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (Database.CheckConnection(LoginForm.DataConnection))
                try
                {
                    int result;

                    if (TableStatusId == 0)
                    {
                        object tableStatusId = 0;
                        object guid = Guid.Empty;

                        result = _tableStatus.Insert(ref tableStatusId, rowTableName.Properties.Value,
                            rowName.Properties.Value, rowNameEn.Properties.Value, rowCode.Properties.Value,
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
                        result = _tableStatus.Update(TableStatusId, rowTableName.Properties.Value,
                            rowName.Properties.Value, rowNameEn.Properties.Value, rowCode.Properties.Value,
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

        private void DeleteRecord()
        {
            if (Utility.ToLong(TableStatusId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (Database.CheckConnection(LoginForm.DataConnection))
                try
                {
                    if (TableStatusId <= 0) return;

                    var result = _tableStatus.Delete(TableStatusId);
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
            try
            {
                grdTableStatus.DataSource = TableStatus.GetList(LoginForm.DataConnection, "");
                grdTableStatus.RefreshDataSource();

                grvTableStatus.FocusedRowHandle = -1;
                NewRecord();

                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, TableStatus._TableName);

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
            if (rowName.Properties.Value == null) return false;

            if (rowCode.Properties.Value == null) return false;

            if (rowTableName.Properties.Value == null) return false;

            return true;
        }

        #endregion Functions
    }
}