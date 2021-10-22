using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using FocusedRowChangedEventArgs = DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs;
using PopupMenuShowingEventArgs = DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs;

namespace BoyArge
{
    public partial class ProcessForm : RibbonForm
    {
        private void VGrdProcess_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Row == rowZoneID)
            {
                var dMachineGroup = MachineGroup.Select(0, Utility.ToLong(rowZoneID.Properties.Value),
                    (int)MachineGroup.Status.Active, LoginForm.DataConnection);
                Format.LookUpEdit(lookMachineGroup, new[] { "Name", "Code" }, "Name", "MachineGroupID", dMachineGroup);
            }
        }

        #region Definitions

        private readonly Process _proses = new Process(LoginForm.DataConnection);
        private long ProcessId { get; set; }
        private long ZoneId { get; set; }
        private Guid RowGuid { get; set; }

        public ProcessForm()
        {
            InitializeComponent();
        }

        #endregion Definitions

        #region Events

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrvProcess_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void GrvProcess_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grvProcess.CalcHitInfo(e.Point).InColumn)
                return;

            if (grvProcess.GetFocusedDataRow() == null)
                return;

            if (Utility.ToInt32(grvProcess.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Resources._unchecked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Resources._checked;
                btnChangeStatus.Caption = Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdProcess.PointToScreen(e.Point));
        }

        private void BtnChangeStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grvProcess.FocusedRowHandle < 0)
                return;

            var status = Utility.ToInt32(grvProcess.GetFocusedRowCellValue(colStatus));

            var newStatus = status == 1 ? 0 : 1;

            var processId = Utility.ToInt32(grvProcess.GetFocusedRowCellValue(colProcessID));

            var message = status == 1 ? Resources.QuestionPassive : Resources.QuestionActive;

            if (XtraMessageBox.Show(message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, Process.TableName, "ProcessID", processId,
                    newStatus);
                XtraMessageBox.Show(result <= 0 ? Resources.UpdateError : Resources.UpdateInfo, Text,
                    MessageBoxButtons.OK, result <= 0 ? MessageBoxIcon.Error : MessageBoxIcon.Information);

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

        #endregion Events

        #region Functions

        private void NewRecord()
        {
            foreach (var row in vGrdProcess.Rows)
            {
                row.Properties.Value = null;
                row.Properties.AllowEdit = true;
            }

            _proses.Record.Reset();

            ProcessId = ZoneId = 0;
            RowGuid = Guid.Empty;
            rowStatus.Properties.Value = ExpenseLine.Status.Active;
        }

        private void EditRecord()
        {
            if (grvProcess.FocusedRowHandle >= 0)
            {
                _proses.Record.Change(grvProcess.GetFocusedDataRow());

                rowProcessID.Properties.Value = ProcessId = _proses.Record.ProcessID;
                rowZoneID.Properties.Value = ZoneId = _proses.Record.ZoneID;

                var dMachineGroup = MachineGroup.Select(0, Utility.ToLong(rowZoneID.Properties.Value),
                    (int)MachineGroup.Status.Active, LoginForm.DataConnection);
                Format.LookUpEdit(lookMachineGroup, new[] { "Name", "Code" }, "Name", "MachineGroupID", dMachineGroup);

                rowProcessTypeID.Properties.Value = _proses.Record.ProcessTypeID;
                rowMachineGroupID.Properties.Value = _proses.Record.MachineGroupID;
                rowSpecode.Properties.Value = _proses.Record.Specode;
                rowCode.Properties.Value = _proses.Record.Code;
                rowName.Properties.Value = _proses.Record.Name;
                rowNote.Properties.Value = _proses.Record.Note;
                rowCode1.Properties.Value = _proses.Record.Code1;
                rowCode2.Properties.Value = _proses.Record.Code2;
                rowCode3.Properties.Value = _proses.Record.Code3;
                rowStatus.Properties.Value = (byte)_proses.Record.Status;
                rowRowGUID.Properties.Value = RowGuid = _proses.Record.RowGUID;

                foreach (var row in vGrdProcess.Rows)
                    if (_proses.Record.Status == Process.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
            }
            else
            {
                _proses.Record.Reset();
                ProcessId = ZoneId = 0;
                RowGuid = Guid.Empty;
            }
        }

        private void SaveRecord()
        {
            vGrdProcess.FocusNext();
            vGrdProcess.Update();

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

                        if (ProcessId == 0)
                        {
                            object processId = 0;
                            object guid = Guid.Empty;

                            result = _proses.Insert(ref processId, rowZoneID.Properties.Value,
                                rowMachineGroupID.Properties.Value, rowProcessTypeID.Properties.Value,
                                rowSpecode.Properties.Value
                                , rowName.Properties.Value, rowCode.Properties.Value, rowNote.Properties.Value,
                                rowCode1.Properties.Value, rowCode2.Properties.Value, rowCode3.Properties.Value,
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
                            result = _proses.Update(ProcessId, rowZoneID.Properties.Value,
                                rowMachineGroupID.Properties.Value, rowProcessTypeID.Properties.Value,
                                rowSpecode.Properties.Value, rowName.Properties.Value, rowCode.Properties.Value,
                                rowNote.Properties.Value, rowCode1.Properties.Value, rowCode2.Properties.Value,
                                rowCode3.Properties.Value, rowStatus.Properties.Value, RowGuid);

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
            if (Utility.ToLong(ProcessId) == 0) return;
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        if (ProcessId <= 0) return;

                        var result = _proses.Delete(ProcessId);
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
                grdProcess.DataSource = Process.GetList(LoginForm.DataConnection, ZoneId, !toggleSwitch.Checked);
                grdProcess.RefreshDataSource();

                grvProcess.FocusedRowHandle = -1;
                NewRecord();

                using (var dZone = Zone.GetList(LoginForm.DataConnection, 0, !toggleSwitch.Checked))
                {
                    Format.LookUpEdit(lookZone, new[] { "Name", "Code" }, "Name", "ZoneID", dZone);
                    Format.LookUpEdit(lookGrdZoneID, new[] { "Name", "Code" }, "Name", "ZoneID", dZone);
                }

                using (var dMachineGroup =
                    MachineGroup.GetList(LoginForm.DataConnection, ZoneId, !toggleSwitch.Checked))
                {
                    Format.LookUpEdit(lookMachineGroup, new[] { "Name", "Code" }, "Name", "MachineGroupID",
                        dMachineGroup);
                    Format.LookUpEdit(lookGrdMachineGroup, new[] { "Name", "Code" }, "Name", "MachineGroupID",
                        dMachineGroup);
                }

                using (var dProcessType = ProcessType.GetList(LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookProcessType, new[] { "Name", "Code" }, "Name", "ProcessTypeID", dProcessType);
                    Format.LookUpEdit(lookGrdProcessType, new[] { "Name", "Code" }, "Name", "ProcessTypeID",
                        dProcessType);
                }

                using (var dTableStatus = TableStatus.GetList(LoginForm.DataConnection, Process.TableName))
                {
                    Format.LookUpEdit(lookStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                    Format.LookUpEdit(lookGrdStatus, new[] { "Name" }, "Name", "Code", dTableStatus);
                }
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

            if (rowCode.Properties.Value == null)
                return false;

            if (rowZoneID.Properties.Value == null)
                return false;

            if (rowMachineGroupID.Properties.Value == null)
                return false;
            if (rowProcessTypeID.Properties.Value == null)
                return false;

            return true;
        }

        #endregion Functions
    }
}