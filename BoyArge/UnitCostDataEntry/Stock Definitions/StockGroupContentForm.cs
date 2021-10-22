using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class StockGroupContentForm : RibbonForm
    {
        private void SpinEditRowAmount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        #region Definitions

        private readonly StockGroupContent _malzemeGrupIcerik = new StockGroupContent(LoginForm.DataConnection);
        private long StockGroupContentId { get; set; }
        private Guid RowGuid { get; set; }

        public StockGroupContentForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void StockGroupContentForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvStockGroupContent_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvStockGroupContent_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvStockGroupContent.CalcHitInfo(e.Point).InColumn) return;

            if (grvStockGroupContent.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvStockGroupContent.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdStockGroupContent.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvStockGroupContent.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvStockGroupContent.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var stockGroupContentId =
                Utility.ToInt32(grvStockGroupContent.GetFocusedRowCellValue(colStockGroupContentID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, StockGroupContent.TableName,
                    "StockGroupContentID", stockGroupContentId, newStatus);

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

        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Resources.AllRecords : Resources.OnlyActiveRecords;
            RefreshList();
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
            foreach (var row in vGrdStockGroupContent.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _malzemeGrupIcerik.Record.Reset();

            StockGroupContentId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = StockGroupContent.Status.Active;
        }

        private void EditRecord()
        {
            if (grvStockGroupContent.FocusedRowHandle >= 0)
            {
                _malzemeGrupIcerik.Record.Change(grvStockGroupContent.GetFocusedDataRow());

                rowStockGroupContentID.Properties.Value =
                    StockGroupContentId = _malzemeGrupIcerik.Record.StockGroupContentID;
                rowStockContentID.Properties.Value = _malzemeGrupIcerik.Record.StockContentID;
                rowStockGroupID.Properties.Value = _malzemeGrupIcerik.Record.StockGroupID;
                rowAmount.Properties.Value = _malzemeGrupIcerik.Record.Amount;
                rowDying.Properties.Value = _malzemeGrupIcerik.Record.Dying;
                rowStatus.Properties.Value = (byte)_malzemeGrupIcerik.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _malzemeGrupIcerik.Record.RowGUID;

                foreach (var row in vGrdStockGroupContent.Rows)
                    if (_malzemeGrupIcerik.Record.Status == StockGroupContent.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _malzemeGrupIcerik.Record.Reset();
                StockGroupContentId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdStockGroupContent.FocusNext();
            vGrdStockGroupContent.Update();

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

                        if (StockGroupContentId == 0)
                        {
                            object stockGroupContentId = 0;
                            object guid = Guid.Empty;

                            result = _malzemeGrupIcerik.Insert(ref stockGroupContentId,
                                rowStockGroupID.Properties.Value, rowStockContentID.Properties.Value,
                                rowAmount.Properties.Value, rowDying.Properties.Value, rowStatus.Properties.Value,
                                ref guid);

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
                            result = _malzemeGrupIcerik.Update(StockGroupContentId, rowStockGroupID.Properties.Value,
                                rowStockContentID.Properties.Value, rowAmount.Properties.Value,
                                rowDying.Properties.Value, rowStatus.Properties.Value, RowGuid);
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
            if (Utility.ToLong(StockGroupContentId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (StockGroupContentId > 0)
                        {
                            var result = _malzemeGrupIcerik.Delete(StockGroupContentId);
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
                grdStockGroupContent.DataSource =
                    StockGroupContent.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdStockGroupContent.RefreshDataSource();

                grvStockGroupContent.FocusedRowHandle = -1;
                NewRecord();

                var dStockGroup = StockGroup.GetList(LoginForm.DataConnection);
                var dStockContent = StockManagement.GetStockContent(0, 1, LoginForm.DataConnection);
                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, StockGroupContent.TableName);

                Format.LookUpEdit(lookStockGroupID, new[] { "StockGroup" }, "StockGroup", "StockGroupID", dStockGroup);
                Format.LookUpEdit(lookGrdStockGroupID, new[] { "StockGroup" }, "StockGroup", "StockGroupID", dStockGroup);
                Format.LookUpEdit(lookStockContentID, new[] { "Name" }, "Name", "StockContentID", dStockContent);
                Format.LookUpEdit(lookGrdStockContentID, new[] { "Name" }, "Name", "StockContentID", dStockContent);
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
            if (rowStockGroupID.Properties.Value == null)
                return false;
            if (rowStockContentID.Properties.Value == null)
                return false;
            if (rowAmount.Properties.Value == null)
                return false;

            return true;
        }

        #endregion Functions
    }
}