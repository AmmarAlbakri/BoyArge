using System;
using Business;
using System.Windows.Forms;
using DevExpress.XtraVerticalGrid.Rows;
using Core;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors;

namespace BoyArge
{
    public partial class ZoneGroupForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Definitions
        ZoneGroup isletmeGrup = new ZoneGroup(LoginForm.DataConnection);
        public long ZoneGroupID { get; set; }
        public long ZoneID { get; set; }
        public Guid RowGUID { get; set; }
        public ZoneGroupForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void ZoneGroupForm_Load(object sender, EventArgs e)
        {
            this.RefreshList();
        }

        private void GrvZoneGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void ZoneGroupForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    this.DeleteRecord();
                    break;
                case Keys.F5:
                    this.RefreshList();
                    break;
                case Keys.Control | Keys.N:
                    this.NewRecord();
                    break;
                case Keys.Control | Keys.S:
                    this.SaveRecord();
                    break;
                default:
                    break;
            }
        }

        private void BtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.NewRecord();
        }

        private void BtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.EditRecord();
        }

        private void BtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SaveRecord();
        }

        private void BtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.RefreshList();
        }

        private void BtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DeleteRecord();
        }
        
        private void grvZoneGroup_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (Utility.ToInt32(this.grvZoneGroup.GetRowCellValue(e.RowHandle, colStatus)) != 0) return;

            e.Appearance.BackColor = Color.DimGray;
            e.Appearance.ForeColor = Color.LightGray;
            e.Appearance.Font = new Font(FontFamily.GenericSansSerif, (float)8.25, FontStyle.Strikeout);

            this.grdZoneGroup.RefreshDataSource();
        }

        private void grvZoneGroup_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (grvZoneGroup.CalcHitInfo(e.Point).InColumn) return;
            if (grvZoneGroup.GetFocusedDataRow() == null) return;

            if (Utility.ToInt32(grvZoneGroup.GetFocusedRowCellValue(colStatus)) == 1)
            {
                btnChangeStatus.ImageOptions.Image = Properties.Resources._unchecked;
                btnChangeStatus.Caption = Properties.Resources.PopupMenuShowing_Passive;
            }
            else
            {
                btnChangeStatus.ImageOptions.Image = Properties.Resources._checked;
                btnChangeStatus.Caption = Properties.Resources.PopupMenuShowing_Active;
            }

            popupMenu.ShowPopup(grdZoneGroup.PointToScreen(e.Point));
        }

        private void btnChangeStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvZoneGroup.FocusedRowHandle < 0)
                return;

            var status = Utility.ToInt32(grvZoneGroup.GetFocusedRowCellValue(colStatus));

            var newStatus = (int)status == 1 ? 0 : 1;


            int ZoneGroupID = Utility.ToInt32(grvZoneGroup.GetFocusedRowCellValue(colZoneGroupID));

            var message = "";

            message = status == 1
                ? Properties.Resources.QuestionPassive
                : Properties.Resources.QuestionActive;


            if (XtraMessageBox.Show(message, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes) return;
            try
            {
                var result = TableStatus.Toggle(LoginForm.DataConnection, ZoneGroup.TableName, "ZoneGroupID", ZoneGroupID, newStatus);

                if (result <= 0)
                    XtraMessageBox.Show(Properties.Resources.UpdateError, this.Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                    XtraMessageBox.Show(Properties.Resources.UpdateInfo, this.Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                this.RefreshList();
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

        }

        private void toggleSwitch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Properties.Resources.AllRecords : Properties.Resources.OnlyActiveRecords;
            this.RefreshList();
        }
        #endregion

        #region Functions
        public void NewRecord()
        {
            foreach (BaseRow row in vGrdZoneGroup.Rows)
                row.Properties.Value = null;

            isletmeGrup.Record.Reset();

            this.ZoneGroupID = this.ZoneID = 0;
            this.RowGUID = Guid.Empty;
        }
        private void EditRecord()
        {
            if (grvZoneGroup.FocusedRowHandle >= 0)
            {
                isletmeGrup.Record.Change(grvZoneGroup.GetFocusedDataRow());

                rowZoneGroupID.Properties.Value = this.ZoneGroupID = isletmeGrup.Record.ZoneGroupID;
                rowZoneID.Properties.Value = this.ZoneID = isletmeGrup.Record.ZoneID;
                rowCode.Properties.Value = isletmeGrup.Record.Code;
                rowName.Properties.Value = isletmeGrup.Record.Name;
                rowStatus.Properties.Value = (isletmeGrup.Record.Status);
                rowRowGUID.Properties.Value = this.RowGUID = isletmeGrup.Record.RowGUID;

                foreach (var row in vGrdZoneGroup.Rows)
                {
                    if (isletmeGrup.Record.Status == ZoneGroup.Status.Active)
                        row.Properties.AllowEdit = true;
                    else
                        row.Properties.AllowEdit = row.Properties.FieldName == "Status";
                }
            }
            else
            {
                isletmeGrup.Record.Reset();
                this.ZoneGroupID = 0;
                this.RowGUID = Guid.Empty;
            }
        }
        private void SaveRecord()
        {
            if (!CheckRow())
            {
                XtraMessageBox.Show(Properties.Resources.EmptySpaceWarning, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (XtraMessageBox.Show(Properties.Resources.QuestionSave, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (Database.CheckConnection(LoginForm.DataConnection))
                {
                    try
                    {
                        int result = 0;

                        if (this.ZoneGroupID == 0)
                        {
                            object ZoneGroupID = 0;
                            object guid = Guid.Empty;

                            result = isletmeGrup.Insert(ref ZoneGroupID, rowZoneID.Properties.Value, rowCode.Properties.Value, rowName.Properties.Value, rowStatus.Properties.Value, ref guid);

                            if (result <= 0)
                                XtraMessageBox.Show(Properties.Resources.InsertError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                XtraMessageBox.Show(Properties.Resources.InsertInfo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.NewRecord();
                                this.RefreshList();
                            }
                        }
                        else
                        {
                            result = isletmeGrup.Update(this.ZoneGroupID, rowZoneID.Properties.Value, rowCode.Properties.Value, rowName.Properties.Value, rowStatus.Properties.Value, this.RowGUID);
                            if (result <= 0)
                                XtraMessageBox.Show(Properties.Resources.UpdateError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                XtraMessageBox.Show(Properties.Resources.UpdateInfo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.NewRecord();
                                this.RefreshList();
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
                else XtraMessageBox.Show(Properties.Resources.DatabaseConnectionError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DeleteRecord()
        {
            if (XtraMessageBox.Show(Properties.Resources.QuestionDelete, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                {
                    try
                    {
                        if (this.ZoneGroupID > 0)
                        {
                            int result = isletmeGrup.Delete(this.ZoneGroupID);
                            if (result > 0)
                            {
                                XtraMessageBox.Show(Properties.Resources.DeleteInfo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.NewRecord();
                                this.RefreshList();
                            }
                            else
                                XtraMessageBox.Show(Properties.Resources.DeleteError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else XtraMessageBox.Show(Properties.Resources.DatabaseConnectionError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshList()
        {
            try
            {
                this.grdZoneGroup.DataSource = ZoneGroup.GetList(LoginForm.DataConnection, this.ZoneID, !this.toggleSwitch.Checked);
                this.grdZoneGroup.RefreshDataSource();

                this.grvZoneGroup.FocusedRowHandle = -1;
                this.NewRecord();

                DataTable dZone = Zone.GetList(LoginForm.DataConnection, 0, !this.toggleSwitch.Checked);
                DataTable dTableStatus = TableStatus.GetList(LoginForm.DataConnection, ZoneGroup.TableName);

                Format.LookUpEdit(this.lookZone, new string[] { "Name", "Code" }, "Name", "ZoneID", dZone);
                Format.LookUpEdit(this.lookGrdZoneID, new string[] { "Name", "Code" }, "Name", "ZoneID", dZone);
                Format.LookUpEdit(this.lookStatus, new string[] { "Name" }, "Name", "Code", dTableStatus);
                Format.LookUpEdit(this.lookGrdStatus, new string[] { "Name" }, "Name", "Code", dTableStatus);

            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckRow()
        {
            if (rowName.Properties.Value == null)
                return false;
            if (rowCode.Properties.Value == null)
                return false;
            return true;
        }
        #endregion
    }
}