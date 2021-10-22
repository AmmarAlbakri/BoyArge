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
    public partial class StockGroupRelationForm : RibbonForm
    {
        #region Definitions

        private readonly StockGroupRelation _stokGrupIliski = new StockGroupRelation(LoginForm.DataConnection);
        private long StockGroupRelationId { get; set; }
        private Guid RowGuid { get; set; }

        public StockGroupRelationForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void StockGroupRelationForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvStockGroupRelation_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvStockGroupRelation_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvStockGroupRelation.CalcHitInfo(e.Point).InColumn) return;

            if (grvStockGroupRelation.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvStockGroupRelation.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdStockGroupRelation.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvStockGroupRelation.FocusedRowHandle < 0)
                return;

            var status = Utility.ToInt32(grvStockGroupRelation.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var stockGroupRelationId =
                Utility.ToInt32(grvStockGroupRelation.GetFocusedRowCellValue(colStockGroupRelationID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, StockGroupRelation.TableName,
                    "StockGroupRelationID", stockGroupRelationId, newStatus);

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

        private void BtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();
        }

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void Seperator_ItemClick(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Checked = !toggleSwitch.Checked;
        }

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdStockGroupRelation.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _stokGrupIliski.Record.Reset();

            StockGroupRelationId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvStockGroupRelation.FocusedRowHandle >= 0)
            {
                _stokGrupIliski.Record.Change(grvStockGroupRelation.GetFocusedDataRow());

                rowStockGroupRelationID.Properties.Value =
                    StockGroupRelationId = _stokGrupIliski.Record.StockGroupRelationID;
                rowStockGroupID.Properties.Value = _stokGrupIliski.Record.StockGroupID;
                rowStockCode.Properties.Value = _stokGrupIliski.Record.StockCode;
                rowStatus.Properties.Value = (byte)_stokGrupIliski.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _stokGrupIliski.Record.RowGUID;

                foreach (var row in vGrdStockGroupRelation.Rows)
                    if (_stokGrupIliski.Record.Status == StockGroupRelation.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _stokGrupIliski.Record.Reset();
                StockGroupRelationId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdStockGroupRelation.FocusNext();
            vGrdStockGroupRelation.Update();

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

                        if (StockGroupRelationId == 0)
                        {
                            object stockGroupRelationId = 0;
                            object guid = Guid.Empty;

                            result = _stokGrupIliski.Insert(ref stockGroupRelationId, rowStockCode.Properties.Value,
                                rowStockGroupID.Properties.Value, rowStatus.Properties.Value, ref guid);

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
                            result = _stokGrupIliski.Update(StockGroupRelationId, rowStockCode.Properties.Value,
                                rowStockGroupID.Properties.Value, rowStatus.Properties.Value, RowGuid);
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
            if (Utility.ToLong(StockGroupRelationId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (StockGroupRelationId > 0)
                        {
                            var result = _stokGrupIliski.Delete(StockGroupRelationId);
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
                grdStockGroupRelation.DataSource =
                    StockGroupRelation.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdStockGroupRelation.RefreshDataSource();

                grvStockGroupRelation.FocusedRowHandle = -1;
                NewRecord();

                var stock = new Stock();
                var dStock = stock.GetList();
                var dStockGroup = StockGroup.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, StockGroupRelation.TableName);

                Format.LookUpEdit(lookStock, new[] { "Code", "Name" }, "Name", "Code", dStock);
                Format.LookUpEdit(lookGrdStockCode, new[] { "Code", "Name" }, "Name", "Code", dStock);
                Format.LookUpEdit(lookStockGroup, new[] { "Name", "Code", "MinValue", "MaxValue" }, "Name",
                    "StockGroupID", dStockGroup);
                Format.LookUpEdit(lookGrdStockGroup, new[] { "Name", "Code" }, "Name", "StockGroupID", dStockGroup);
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
            if (rowStockCode.Properties.Value == null) return false;

            if (rowStockGroupID.Properties.Value == null) return false;

            return true;
        }

        #endregion Functions
    }
}