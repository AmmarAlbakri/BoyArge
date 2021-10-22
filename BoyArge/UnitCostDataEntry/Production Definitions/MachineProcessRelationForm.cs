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
    public partial class MachineProcessRelationForm : RibbonForm
    {
        #region Definitions

        private readonly MachineProcessRelation _makineProsesRel = new MachineProcessRelation(LoginForm.DataConnection);
        private long MachineProcessRelationId { get; set; }
        private Guid RowGuid { get; set; }

        public MachineProcessRelationForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void MachineProcessRelationForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvMachineProcessRelation_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvMachineProcessRelation_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvMachineProcessRelation.CalcHitInfo(e.Point).InColumn) return;

            if (grvMachineProcessRelation.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvMachineProcessRelation.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdMachineProcessRelation.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvMachineProcessRelation.FocusedRowHandle < 0)
                return;

            var status = Utility.ToInt32(grvMachineProcessRelation.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var machineProcessRelationId =
                Utility.ToInt32(grvMachineProcessRelation.GetFocusedRowCellValue(colMachineProcessRelationID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, MachineProcessRelation.TableName,
                    "MachineProcessRelationID", machineProcessRelationId, newStatus);

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
            foreach (var row in vGrdMachineProcessRelation.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _makineProsesRel.Record.Reset();

            MachineProcessRelationId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvMachineProcessRelation.FocusedRowHandle >= 0)
            {
                _makineProsesRel.Record.Change(grvMachineProcessRelation.GetFocusedDataRow());

                rowMachineProcessRelationID.Properties.Value =
                    MachineProcessRelationId = _makineProsesRel.Record.MachineProcessRelationID;
                rowProcessID.Properties.Value = _makineProsesRel.Record.ProcessID;
                rowMachineID.Properties.Value = _makineProsesRel.Record.MachineID;
                rowStatus.Properties.Value = (byte)_makineProsesRel.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _makineProsesRel.Record.RowGUID;

                foreach (var row in vGrdMachineProcessRelation.Rows)
                    if (_makineProsesRel.Record.Status == MachineProcessRelation.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _makineProsesRel.Record.Reset();
                MachineProcessRelationId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdMachineProcessRelation.FocusNext();
            vGrdMachineProcessRelation.Update();

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

                        if (MachineProcessRelationId == 0)
                        {
                            object machineProcessRelationId = 0;
                            object guid = Guid.Empty;

                            result = _makineProsesRel.Insert(ref machineProcessRelationId,
                                rowMachineID.Properties.Value, rowProcessID.Properties.Value,
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
                            result = _makineProsesRel.Update(MachineProcessRelationId, rowMachineID.Properties.Value,
                                rowProcessID.Properties.Value, rowStatus.Properties.Value, RowGuid);

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
            if (Utility.ToLong(MachineProcessRelationId) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (MachineProcessRelationId > 0)
                        {
                            var result = _makineProsesRel.Delete(MachineProcessRelationId);
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
                grdMachineProcessRelation.DataSource =
                    MachineProcessRelation.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                grdMachineProcessRelation.RefreshDataSource();

                grvMachineProcessRelation.FocusedRowHandle = -1;
                NewRecord();

                var dMachine = Machine.GetList(LoginForm.DataConnection, !toggleSwitch.Checked);
                var dProcess = Process.GetList(LoginForm.DataConnection, 0, !toggleSwitch.Checked);
                var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, MachineProcessRelation.TableName);

                Format.LookUpEdit(lookMachine, new[] { "Name", "Code" }, "Name", "MachineID", dMachine);
                Format.LookUpEdit(lookGrdMachineID, new[] { "Name", "Code" }, "Name", "MachineID", dMachine);
                Format.LookUpEdit(lookProcess, new[] { "Name", "Code" }, "Name", "ProcessID", dProcess);
                Format.LookUpEdit(lookGrdProcess, new[] { "Name", "Code" }, "Name", "ProcessID", dProcess);
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
            if (rowMachineID.Properties.Value == null) return false;

            if (rowProcessID.Properties.Value == null) return false;

            return true;
        }

        #endregion Functions
    }
}