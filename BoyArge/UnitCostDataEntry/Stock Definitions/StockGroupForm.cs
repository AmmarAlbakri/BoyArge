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
    public partial class StockGroupForm : RibbonForm
    {
        #region Definitions

        private readonly StockGroup _malzemeGrup = new StockGroup(LoginForm.DataConnection);
        private long StockGroupId { get; set; }
        private Guid RowGuid { get; set; }

        public StockGroupForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void StockGroupForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvStockGroup_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvStockGroup_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvStockGroup.CalcHitInfo(e.Point).InColumn) return;

            if (grvStockGroup.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvStockGroup.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdStockGroup.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvStockGroup.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvStockGroup.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var stockGroupId = Utility.ToInt32(grvStockGroup.GetFocusedRowCellValue(colStockGroupID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, StockGroup.TableName, "StockGroupID",
                    stockGroupId, newStatus);

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

        private void SpinEditMinValue_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void SpinEditMaxValue_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        private void SpinEditNFold_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (spinEdit.Value < 0)
                    e.Cancel = true;
            }
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdStockGroup.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _malzemeGrup.Record.Reset();

            StockGroupId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = StockGroup.Status.Active;
        }

        private void EditRecord()
        {
            if (grvStockGroup.FocusedRowHandle >= 0)
            {
                _malzemeGrup.Record.Change(grvStockGroup.GetFocusedDataRow());

                rowStockGroupID.Properties.Value = StockGroupId = _malzemeGrup.Record.StockGroupID;
                rowZoneID.Properties.Value = _malzemeGrup.Record.ZoneID;
                rowProductGroupID.Properties.Value = _malzemeGrup.Record.ProductGroupID;
                rowStockTypeID.Properties.Value = _malzemeGrup.Record.StockTypeID;
                rowStockPropertyID.Properties.Value = _malzemeGrup.Record.StockPropertyID;
                rowStockProductTypeID.Properties.Value = _malzemeGrup.Record.StockProductTypeID;
                rowUnitID.Properties.Value = _malzemeGrup.Record.UnitID;
                rowName.Properties.Value = _malzemeGrup.Record.Name;
                rowMinValue.Properties.Value = _malzemeGrup.Record.MinValue;
                rowMaxValue.Properties.Value = _malzemeGrup.Record.MaxValue;
                rowNFold.Properties.Value = _malzemeGrup.Record.NFold;
                rowStatus.Properties.Value = (byte)_malzemeGrup.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _malzemeGrup.Record.RowGUID;

                foreach (var row in vGrdStockGroup.Rows)
                    if (_malzemeGrup.Record.Status == StockGroup.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _malzemeGrup.Record.Reset();
                StockGroupId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdStockGroup.FocusNext();
            vGrdStockGroup.Update();

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

                        if (StockGroupId == 0)
                        {
                            object stockGroupId = 0;
                            object guid = Guid.Empty;

                            result = _malzemeGrup.Insert(ref stockGroupId, rowZoneID.Properties.Value,
                                rowProductGroupID.Properties.Value, rowStockTypeID.Properties.Value,
                                rowStockPropertyID.Properties.Value, rowStockProductTypeID.Properties.Value,
                                rowUnitID.Properties.Value, rowName.Properties.Value, rowMinValue.Properties.Value,
                                rowMaxValue.Properties.Value, rowNFold.Properties.Value, rowStatus.Properties.Value,
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
                            result = _malzemeGrup.Update(StockGroupId, rowZoneID.Properties.Value,
                                rowProductGroupID.Properties.Value, rowStockTypeID.Properties.Value,
                                rowStockPropertyID.Properties.Value, rowStockProductTypeID.Properties.Value,
                                rowUnitID.Properties.Value, rowName.Properties.Value, rowMinValue.Properties.Value,
                                rowMaxValue.Properties.Value, rowNFold.Properties.Value, rowStatus.Properties.Value,
                                RowGuid);
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
            if (Utility.ToLong(StockGroupId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (StockGroupId > 0)
                        {
                            var result = _malzemeGrup.Delete(StockGroupId);
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
                grdStockGroup.DataSource = StockGroup.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdStockGroup.RefreshDataSource();

                grvStockGroup.FocusedRowHandle = -1;
                NewRecord();

                var dZone = Zone.GetList(LoginForm.DataConnection, 0);
                var dProductGroup = StockManagement.GetProductGroup(0, 1, LoginForm.DataConnection);
                var dStockType = StockManagement.GetStockType(0, 1, LoginForm.DataConnection);
                var dStockProperty = StockManagement.GetStockProperty(0, 1, LoginForm.DataConnection);
                var dStockProductType = StockManagement.GetStockProductType(0, 1, LoginForm.DataConnection);
                var dUnit = Unit.GetList(LoginForm.DataConnection);
                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, StockGroup.TableName);

                Format.LookUpEdit(lookZoneID, new[] { "Name" }, "Name", "ZoneID", dZone);
                Format.LookUpEdit(lookGrdZoneID, new[] { "Name" }, "Name", "ZoneID", dZone);
                Format.LookUpEdit(lookProductGroupID, new[] { "Name" }, "Name", "ProductGroupID", dProductGroup);
                Format.LookUpEdit(lookGrdProductGroupID, new[] { "Name" }, "Name", "ProductGroupID", dProductGroup);
                Format.LookUpEdit(lookStockTypeID, new[] { "Name" }, "Name", "StockTypeID", dStockType);
                Format.LookUpEdit(lookGrdStockTypeID, new[] { "Name" }, "Name", "StockTypeID", dStockType);
                Format.LookUpEdit(lookStockPropertyID, new[] { "Name" }, "Name", "StockPropertyID", dStockProperty);
                Format.LookUpEdit(lookGrdStockPropertyID, new[] { "Name" }, "Name", "StockPropertyID", dStockProperty);
                Format.LookUpEdit(lookStockProductTypeID, new[] { "Name" }, "Name", "StockProductTypeID",
                    dStockProductType);
                Format.LookUpEdit(lookGrdStockProductTypeID, new[] { "Name" }, "Name", "StockProductTypeID",
                    dStockProductType);
                Format.LookUpEdit(lookUnitID, new[] { "Name" }, "Name", "UnitID", dUnit);
                Format.LookUpEdit(lookGrdUnitID, new[] { "Name" }, "Name", "UnitID", dUnit);
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
            //if (rowStockGroupID.Properties.Value == null)
            //    return false;
            if (rowZoneID.Properties.Value == null)
                return false;
            if (rowProductGroupID.Properties.Value == null)
                return false;
            if (rowStockTypeID.Properties.Value == null)
                return false;
            if (rowStockPropertyID.Properties.Value == null)
                return false;
            if (rowStockProductTypeID.Properties.Value == null)
                return false;
            if (rowUnitID.Properties.Value == null)
                return false;
            if (rowName.Properties.Value == null)
                return false;

            //if (rowAmount.Properties.Value == null)
            //{
            //    return false;
            //}

            return true;
        }

        #endregion Functions
    }
}