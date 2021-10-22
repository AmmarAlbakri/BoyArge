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
    public partial class ProductionTypeForm : RibbonForm
    {
        #region Definitions

        private readonly ProductionType _uretimTuru = new ProductionType(LoginForm.DataConnection);
        private long ProductionTypeId { get; set; }
        private Guid RowGuid { get; set; }

        public ProductionTypeForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void ProductionTypeForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvProductionType_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvProductionType_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvProductionType.CalcHitInfo(e.Point).InColumn) return;

            if (grvProductionType.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvProductionType.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdProductionType.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvProductionType.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvProductionType.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var productionTypeId = Utility.ToInt32(grvProductionType.GetFocusedRowCellValue(colProductionTypeID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, ProductionType.TableName, "ProductionTypeID",
                    productionTypeId, newStatus);

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
            foreach (var row in vGrdProductionType.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _uretimTuru.Record.Reset();

            ProductionTypeId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvProductionType.FocusedRowHandle >= 0)
            {
                _uretimTuru.Record.Change(grvProductionType.GetFocusedDataRow());

                rowProductionTypeID.Properties.Value = ProductionTypeId = _uretimTuru.Record.ProductionTypeID;
                rowCode.Properties.Value = _uretimTuru.Record.Code;
                rowName.Properties.Value = _uretimTuru.Record.Name;
                rowStatus.Properties.Value = (byte)_uretimTuru.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _uretimTuru.Record.RowGUID;

                foreach (var row in vGrdProductionType.Rows)
                    if (_uretimTuru.Record.Status == ProductionType.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _uretimTuru.Record.Reset();
                ProductionTypeId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdProductionType.FocusNext();
            vGrdProductionType.Update();

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
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (Database.CheckConnection(LoginForm.DataConnection))
                try
                {
                    int result;

                    if (ProductionTypeId == 0)
                    {
                        object productionTypeId = 0;
                        object guid = Guid.Empty;

                        result = _uretimTuru.Insert(ref productionTypeId, rowName.Properties.Value,
                            rowCode.Properties.Value, rowStatus.Properties.Value, ref guid);

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
                        result = _uretimTuru.Update(ProductionTypeId, rowName.Properties.Value,
                            rowCode.Properties.Value, rowStatus.Properties.Value, RowGuid);
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
            if (Utility.ToLong(ProductionTypeId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (ProductionTypeId > 0)
                        {
                            var result = _uretimTuru.Delete(ProductionTypeId);
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
                grdProductionType.DataSource = ProductionType.GetList(LoginForm.DataConnection);
                grdProductionType.RefreshDataSource();

                grvProductionType.FocusedRowHandle = -1;
                NewRecord();

                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, ProductionType.TableName);

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

            return true;
        }

        #endregion Functions
    }
}