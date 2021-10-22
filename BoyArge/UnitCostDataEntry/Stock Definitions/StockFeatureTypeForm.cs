using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class StockFeatureTypeForm : RibbonForm
    {
        #region Definition

        private readonly StockFeatureType stockFeatureType = new StockFeatureType(LoginForm.DataConnection);
        public object StockCode { get; set; }

        #endregion Definition

        #region Event

        public StockFeatureTypeForm()
        {
            InitializeComponent();
        }

        private void StockFeatureTypeForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void GrdStockFeatureType_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            switch (e.Button.ButtonType)
            {
                case NavigatorButtonType.EndEdit:
                    var row = grvStockFeatureType.GetFocusedDataRow();

                    if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (row == null) return;

                        try
                        {
                            object stockFeatureTypeID = Utility.ToInt32(row["StockFeatureTypeID"]);
                            object guid = Guid.NewGuid();

                            int result;
                            if (Utility.ToInt32(row["StockFeatureTypeID"]) <= 0)

                                result = stockFeatureType.Insert(ref stockFeatureTypeID, StockCodeLookUpEdit.EditValue,
                                    NameTextEdit.Text, Utility.ToInt32(MachineGroup1IDLookUpEdit.EditValue),
                                    Utility.ToInt32(MachineGroup2IDLookUpEdit.EditValue),
                                    Utility.ToInt32(MachineGroup3IDLookUpEdit.EditValue),
                                    Utility.ToInt32(MachineGroup4IDLookUpEdit.EditValue), Code1TextEdit.Text,
                                    Code2TextEdit.Text, Utility.ToDecimal(Code3SpinEdit.EditValue),
                                    Utility.ToInt32(ColorTypeLookUpEdit.EditValue),
                                    Utility.ToInt32(TouchnessLookUpEdit.EditValue),
                                    Utility.ToInt32(FeatureLookUpEdit.EditValue), 1, ref guid);
                            else
                                result = stockFeatureType.Update(stockFeatureTypeID, StockCodeLookUpEdit.EditValue,
                                    NameTextEdit.Text, Utility.ToInt32(MachineGroup1IDLookUpEdit.EditValue),
                                    Utility.ToInt32(MachineGroup2IDLookUpEdit.EditValue),
                                    Utility.ToInt32(MachineGroup3IDLookUpEdit.EditValue),
                                    Utility.ToInt32(MachineGroup4IDLookUpEdit.EditValue), Code1TextEdit.Text,
                                    Code2TextEdit.Text, Utility.ToDecimal(Code3SpinEdit.EditValue),
                                    Utility.ToInt32(ColorTypeLookUpEdit.EditValue),
                                    Utility.ToInt32(TouchnessLookUpEdit.EditValue),
                                    Utility.ToInt32(FeatureLookUpEdit.EditValue), 1, RowGUIDTextEdit.Text);

                            if (result > 0)
                                XtraMessageBox.Show(Resources.InsertInfo, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            else if (result > 0)
                                XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        }
                        catch (SqlException exc)
                        {
                            XtraMessageBox.Show(exc.Message);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message);
                        }
                    }

                    break;
            }
        }

        private void Root_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Yenile":
                    RefreshList();
                    break;

                case "Temizle":
                    RefreshList();
                    break;
            }
        }

        private void GrvStockFeatureType_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EditRecord();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            SaveRecord();
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

        private void ToggleSwitch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            toggleSwitch.Caption = toggleSwitch.Checked ? Resources.AllRecords : Resources.OnlyActiveRecords;
            RefreshList();
        }

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        #endregion Event

        #region Function

        private void NewRecord()
        {
            MachineGroup1IDLookUpEdit.EditValue = MachineGroup2IDLookUpEdit.EditValue =
                MachineGroup3IDLookUpEdit.EditValue = MachineGroup4IDLookUpEdit.EditValue = null;
            ColorTypeLookUpEdit.EditValue = TouchnessLookUpEdit.EditValue = FeatureLookUpEdit.EditValue = null;
            NameTextEdit.Text = Code1TextEdit.Text =
                Code2TextEdit.Text = StockFeatureTypeIDTextEdit.Text = RowGUIDTextEdit.Text = string.Empty;
            Code3SpinEdit.Value = 0;

            StockCodeLookUpEdit.EditValue = StockCode;
        }

        private void RefreshList()
        {
            try
            {
                ClearItems();

                var _dStock = new Stock().GetList();
                using (_dStock)
                {
                    Format.LookUpEdit(StockCodeLookUpEdit, new[] { "Code", "Name" }, "Name", "Code", _dStock);
                }

                using (var dMachineGroup = MachineGroup.GetList(LoginForm.DataConnection, 1))
                {
                    Format.LookUpEdit(lookMachineGroup1ID, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                    Format.LookUpEdit(lookMachineGroup2ID, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                    Format.LookUpEdit(lookMachineGroup3ID, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                    Format.LookUpEdit(lookMachineGroup4ID, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);

                    Format.LookUpEdit(MachineGroup1IDLookUpEdit, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                    Format.LookUpEdit(MachineGroup2IDLookUpEdit, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                    Format.LookUpEdit(MachineGroup3IDLookUpEdit, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                    Format.LookUpEdit(MachineGroup4IDLookUpEdit, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);

                    //MachineGroup1IDLookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("", "", dMachineGroup));
                }

                using (var dStockFeatureType =
                    StockFeatureType.GetList(LoginForm.DataConnection, !toggleSwitch.Checked))
                {
                    grdStockFeatureType.DataSource = dStockFeatureType;
                }

                grvStockFeatureType.FocusedRowHandle = -1;

                using (var dColorType =
                    Database.GetList(
                        "SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblReceipt]','ColorType')",
                        LoginForm.DataConnection))
                {
                    Format.LookUpEdit(ColorTypeLookUpEdit, new[] { "Definition" }, "Definition", "ParameterID",
                        dColorType);
                    Format.LookUpEdit(lookColorType, new[] { "Definition" }, "Definition", "ParameterID",
                        dColorType);
                }

                using (var dTouchness =
                    Database.GetList(
                        "SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblReceipt]','Touchness')",
                        LoginForm.DataConnection))
                {
                    Format.LookUpEdit(TouchnessLookUpEdit, new[] { "Definition" }, "Definition", "ParameterID",
                        dTouchness);
                    Format.LookUpEdit(lookTouchness, new[] { "Definition" }, "Definition", "ParameterID", dTouchness);
                }

                using (var dFeature =
                    Database.GetList(
                        "SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblReceipt]','Feature')",
                        LoginForm.DataConnection))
                {
                    Format.LookUpEdit(FeatureLookUpEdit, new[] { "Definition" }, "Definition", "ParameterID", dFeature);
                    Format.LookUpEdit(lookFeature, new[] { "Definition" }, "Definition", "ParameterID", dFeature);
                }

                NewRecord();
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

        private void ClearItems()
        {
            MachineGroup1IDLookUpEdit.EditValue = MachineGroup2IDLookUpEdit.EditValue =
                MachineGroup3IDLookUpEdit.EditValue = MachineGroup4IDLookUpEdit.EditValue = null;
            StockCodeLookUpEdit.EditValue = NameTextEdit.Text = Code1TextEdit.Text =
                Code2TextEdit.Text = StockFeatureTypeIDTextEdit.Text = RowGUIDTextEdit.Text = string.Empty;
            Code3SpinEdit.Value = 0;
        }

        private void EditRecord()
        {
            DataRow row = null;
            if (grvStockFeatureType.FocusedRowHandle >= 0)
                row = grvStockFeatureType.GetFocusedDataRow();

            if (row != null)
            {
                StockCodeLookUpEdit.EditValue = row["StockCode"].ToString();
                NameTextEdit.Text = row["Name"].ToString();
                MachineGroup1IDLookUpEdit.EditValue = row["MachineGroup1ID"];
                MachineGroup2IDLookUpEdit.EditValue = row["MachineGroup2ID"];
                MachineGroup3IDLookUpEdit.EditValue = row["MachineGroup3ID"];
                MachineGroup4IDLookUpEdit.EditValue = row["MachineGroup4ID"];
                Code1TextEdit.Text = row["Code1"].ToString();
                Code2TextEdit.Text = row["Code2"].ToString();
                Code3SpinEdit.Value = Utility.ToDecimal(row["Code3"]);
                ColorTypeLookUpEdit.EditValue = Utility.ToInt32(row["ColorTypeID"]);
                TouchnessLookUpEdit.EditValue = Utility.ToInt32(row["TouchnessID"]);
                FeatureLookUpEdit.EditValue = Utility.ToInt32(row["FeatureID"]);
                StockFeatureTypeIDTextEdit.Text = row["StockFeatureTypeID"].ToString();
                RowGUIDTextEdit.Text = row["RowGUID"].ToString();
            }
        }

        private void SaveRecord()
        {
            if (!ScreenPermission.ScreenPermissionEdit(LoginForm.UserId, Tag.ToString(), LoginForm.DataConnection))
            {
                XtraMessageBox.Show(Resources.PermissionDenied, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (StockCodeLookUpEdit.EditValue == null || NameTextEdit.Text == "")
            {
                XtraMessageBox.Show(Resources.EmptySpaceWarning, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

                return;
            }

            if (XtraMessageBox.Show(
                    Utility.ToInt32(StockFeatureTypeIDTextEdit.Text) > 0
                        ? Resources.QuestionUpdate
                        : Resources.QuestionSave, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    object stockFeatureTypeID = Utility.ToInt32(StockFeatureTypeIDTextEdit.Text);
                    object guid = Guid.NewGuid();

                    int result;
                    if (Utility.ToInt32(stockFeatureTypeID) <= 0)
                        result = stockFeatureType.Insert(ref stockFeatureTypeID, StockCodeLookUpEdit.EditValue,
                            NameTextEdit.Text, Utility.ToLong(MachineGroup1IDLookUpEdit.EditValue),
                            Utility.ToLong(MachineGroup2IDLookUpEdit.EditValue),
                            Utility.ToLong(MachineGroup3IDLookUpEdit.EditValue),
                            Utility.ToLong(MachineGroup4IDLookUpEdit.EditValue), Code1TextEdit.Text, Code2TextEdit.Text,
                            Utility.ToDecimal(Code3SpinEdit.EditValue), Utility.ToInt32(ColorTypeLookUpEdit.EditValue),
                            Utility.ToInt32(TouchnessLookUpEdit.EditValue),
                            Utility.ToInt32(FeatureLookUpEdit.EditValue), 1, ref guid);
                    else
                        result = stockFeatureType.Update(stockFeatureTypeID, StockCodeLookUpEdit.EditValue,
                            NameTextEdit.Text, Utility.ToLong(MachineGroup1IDLookUpEdit.EditValue),
                            Utility.ToLong(MachineGroup2IDLookUpEdit.EditValue),
                            Utility.ToLong(MachineGroup3IDLookUpEdit.EditValue),
                            Utility.ToLong(MachineGroup4IDLookUpEdit.EditValue), Code1TextEdit.Text, Code2TextEdit.Text,
                            Utility.ToDecimal(Code3SpinEdit.EditValue), Utility.ToInt32(ColorTypeLookUpEdit.EditValue),
                            Utility.ToInt32(TouchnessLookUpEdit.EditValue),
                            Utility.ToInt32(FeatureLookUpEdit.EditValue), 1, Utility.ToGuid(RowGUIDTextEdit.Text));

                    if (result > 0)
                        XtraMessageBox.Show(Resources.InsertInfo, Text, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    else if (result > 0)
                        XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    RefreshList();
                }
                catch (SqlException exc)
                {
                    XtraMessageBox.Show(exc.Message);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
        }

        private void DeleteRecord()
        {
            if (Utility.ToLong(StockFeatureTypeIDTextEdit.Text) == 0) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (Database.CheckConnection(LoginForm.DataConnection))
                    try
                    {
                        var stockFeatureTypeID = Utility.ToInt32(StockFeatureTypeIDTextEdit.Text);

                        if (stockFeatureTypeID > 0)
                        {
                            var result = stockFeatureType.Delete(stockFeatureTypeID);
                            if (result > 0)
                            {
                                XtraMessageBox.Show(Resources.DeleteInfo, Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                ClearItems();
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

        #endregion Function
    }
}