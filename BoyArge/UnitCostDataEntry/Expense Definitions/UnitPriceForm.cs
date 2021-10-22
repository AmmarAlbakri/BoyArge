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
    public partial class UnitPriceForm : RibbonForm
    {
        private void spinEditAmount_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (Utility.ToDecimal(spinEdit.EditValue) < 0)
                    e.Cancel = true;
            }
        }

        private void spinEditPrice_Validating(object sender, CancelEventArgs e)
        {
            using (var spinEdit = sender as SpinEdit)
            {
                if (Utility.ToDecimal(spinEdit.EditValue) < 0)
                    e.Cancel = true;
            }
        }

        #region Definitions

        private readonly UnitPrice _birimFiyat = new UnitPrice(LoginForm.DataConnection);
        private long UnitPriceId { get; set; }
        private Guid RowGuid { get; set; }

        public UnitPriceForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void UnitPriceForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvUnitPrice_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvUnitPrice_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvUnitPrice.CalcHitInfo(e.Point).InColumn) return;

            if (grvUnitPrice.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvUnitPrice.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdUnitPrice.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvUnitPrice.FocusedRowHandle < 0) return;

            var status = Utility.ToInt32(grvUnitPrice.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var unitPriceId = Utility.ToInt32(grvUnitPrice.GetFocusedRowCellValue(colUnitPriceID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, UnitPrice.TableName, "UnitPriceID",
                    unitPriceId, newStatus);

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
            foreach (var row in vGrdUnitPrice.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _birimFiyat.Record.Reset();

            UnitPriceId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = UnitPrice.Status.Active;
        }

        private void EditRecord()
        {
            if (grvUnitPrice.FocusedRowHandle >= 0)
            {
                _birimFiyat.Record.Change(grvUnitPrice.GetFocusedDataRow());

                rowUnitPriceID.Properties.Value = UnitPriceId = _birimFiyat.Record.UnitPriceID;
                rowExpenseID.Properties.Value = _birimFiyat.Record.ExpenseID;
                rowStockCode.Properties.Value = _birimFiyat.Record.StockCode;
                rowPrice.Properties.Value = _birimFiyat.Record.Price;
                rowExchangeTypeID.Properties.Value = _birimFiyat.Record.ExchangeTypeID;
                rowExpireDay.Properties.Value = _birimFiyat.Record.ExpireDay;
                rowDate.Properties.Value = _birimFiyat.Record.Date;
                rowStatus.Properties.Value = (byte)_birimFiyat.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _birimFiyat.Record.RowGUID;

                foreach (var row in vGrdUnitPrice.Rows)
                    if (_birimFiyat.Record.Status == UnitPrice.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _birimFiyat.Record.Reset();
                UnitPriceId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdUnitPrice.FocusNext();
            vGrdUnitPrice.Update();

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

                        if (UnitPriceId == 0)
                        {
                            object unitPriceId = 0;
                            object guid = Guid.Empty;

                            result = _birimFiyat.Insert(ref unitPriceId, rowExpenseID.Properties.Value,
                                rowStockCode.Properties.Value, rowExchangeTypeID.Properties.Value,
                                rowPrice.Properties.Value, rowExpireDay.Properties.Value, rowDate.Properties.Value,
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
                            result = _birimFiyat.Update(UnitPriceId, rowExpenseID.Properties.Value,
                                rowStockCode.Properties.Value, rowExchangeTypeID.Properties.Value,
                                rowPrice.Properties.Value, rowExpireDay.Properties.Value, rowDate.Properties.Value,
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
            if (Utility.ToLong(UnitPriceId) == 0) return;
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (UnitPriceId > 0)
                        {
                            var result = _birimFiyat.Delete(UnitPriceId);
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
                grdUnitPrice.DataSource = UnitPrice.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdUnitPrice.RefreshDataSource();

                grvUnitPrice.FocusedRowHandle = -1;
                NewRecord();

                var stock = new Stock();
                var dStock = stock.GetList();
                var dExpense = Expense.GetList(LoginForm.DataConnection);
                var dExchangeType = ExchangeType.GetList(LoginForm.DataConnection);
                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, UnitPrice.TableName);

                Format.LookUpEdit(lookExpenseID, new[] { "Name" }, "Name", "ExpenseID", dExpense);
                Format.LookUpEdit(lookGrdExpenseID, new[] { "Name" }, "Name", "ExpenseID", dExpense);
                Format.LookUpEdit(lookStockCode, new[] { "Code", "Name" }, "Name", "Code", dStock);
                Format.LookUpEdit(lookGrdStockCode, new[] { "Code", "Name" }, "Name", "Code", dStock);
                Format.LookUpEdit(lookExchangeTypeID, new[] { "Name" }, "Name", "ExchangeTypeID", dExchangeType);
                Format.LookUpEdit(lookGrdExchangeTypeID, new[] { "Name" }, "Name", "ExchangeTypeID", dExchangeType);
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
            if (rowExpenseID.Properties.Value == null) return false;

            //if (rowStockCode.Properties.Value == null)
            //{
            //    return false;
            //}

            if (rowPrice.Properties.Value == null) return false;

            if (rowExpireDay.Properties.Value == null) return false;

            if (rowExchangeTypeID.Properties.Value == null) return false;

            return true;
        }

        #endregion Functions
    }
}