﻿namespace BoyArge
{
    partial class DepartmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentForm));
            this.grdDepartment = new DevExpress.XtraGrid.GridControl();
            this.grvDepartment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZoneID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdZone = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNWorker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdNWorker = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdFirmID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.vGrdDepartment = new DevExpress.XtraVerticalGrid.VGridControl();
            this.lookFirm = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditNWorker = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lookZoneID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowDepartmentID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowNWorker = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowZoneID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowRowGUID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.seperator1 = new DevExpress.XtraBars.BarHeaderItem();
            this.toggleSwitch = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnChangeStatus = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdNWorker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdFirmID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookFirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNWorker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookZoneID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDepartment
            // 
            this.grdDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDepartment.Location = new System.Drawing.Point(0, 0);
            this.grdDepartment.MainView = this.grvDepartment;
            this.grdDepartment.Name = "grdDepartment";
            this.grdDepartment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookGrdFirmID,
            this.lookGrdStatus,
            this.spinEditGrdNWorker,
            this.lookGrdZone});
            this.grdDepartment.Size = new System.Drawing.Size(704, 386);
            this.grdDepartment.TabIndex = 0;
            this.grdDepartment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDepartment});
            // 
            // grvDepartment
            // 
            this.grvDepartment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDepartmentID,
            this.colStatus,
            this.colName,
            this.colCode,
            this.colZoneID,
            this.colNWorker,
            this.colRowGUID});
            this.grvDepartment.GridControl = this.grdDepartment;
            this.grvDepartment.Name = "grvDepartment";
            this.grvDepartment.OptionsBehavior.Editable = false;
            this.grvDepartment.OptionsView.ShowAutoFilterRow = true;
            this.grvDepartment.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GrvDepartment_PopupMenuShowing);
            this.grvDepartment.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrvDepartment_FocusedRowChanged);
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.Caption = "DepartmentID";
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Durum";
            this.colStatus.ColumnEdit = this.lookGrdStatus;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 0;
            // 
            // lookGrdStatus
            // 
            this.lookGrdStatus.AutoHeight = false;
            this.lookGrdStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStatus.Name = "lookGrdStatus";
            this.lookGrdStatus.NullText = "Durum Seçiniz";
            // 
            // colName
            // 
            this.colName.Caption = "Departman Adı";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colCode
            // 
            this.colCode.Caption = "Departman Kodu";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 2;
            // 
            // colZoneID
            // 
            this.colZoneID.Caption = "İşletme";
            this.colZoneID.ColumnEdit = this.lookGrdZone;
            this.colZoneID.FieldName = "ZoneID";
            this.colZoneID.Name = "colZoneID";
            this.colZoneID.Visible = true;
            this.colZoneID.VisibleIndex = 4;
            // 
            // lookGrdZone
            // 
            this.lookGrdZone.AutoHeight = false;
            this.lookGrdZone.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdZone.Name = "lookGrdZone";
            // 
            // colNWorker
            // 
            this.colNWorker.Caption = "Çalışan Sayısı";
            this.colNWorker.ColumnEdit = this.spinEditGrdNWorker;
            this.colNWorker.FieldName = "NWorker";
            this.colNWorker.Name = "colNWorker";
            this.colNWorker.Visible = true;
            this.colNWorker.VisibleIndex = 3;
            // 
            // spinEditGrdNWorker
            // 
            this.spinEditGrdNWorker.AutoHeight = false;
            this.spinEditGrdNWorker.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdNWorker.Name = "spinEditGrdNWorker";
            // 
            // colRowGUID
            // 
            this.colRowGUID.Caption = "rowGUID";
            this.colRowGUID.FieldName = "RowGUID";
            this.colRowGUID.Name = "colRowGUID";
            // 
            // lookGrdFirmID
            // 
            this.lookGrdFirmID.AutoHeight = false;
            this.lookGrdFirmID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdFirmID.DisplayMember = "Name";
            this.lookGrdFirmID.Name = "lookGrdFirmID";
            this.lookGrdFirmID.ValueMember = "FirmID";
            // 
            // vGrdDepartment
            // 
            this.vGrdDepartment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrdDepartment.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.vGrdDepartment.CustomizationFormBounds = new System.Drawing.Rectangle(457, 176, 214, 258);
            this.vGrdDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrdDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGrdDepartment.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGrdDepartment.Location = new System.Drawing.Point(0, 0);
            this.vGrdDepartment.Name = "vGrdDepartment";
            this.vGrdDepartment.RecordWidth = 158;
            this.vGrdDepartment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookFirm,
            this.lookStatus,
            this.spinEditNWorker,
            this.lookZoneID});
            this.vGrdDepartment.RowHeaderWidth = 42;
            this.vGrdDepartment.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowDepartmentID,
            this.rowName,
            this.rowCode,
            this.rowNWorker,
            this.rowZoneID,
            this.rowStatus,
            this.rowRowGUID});
            this.vGrdDepartment.Size = new System.Drawing.Size(704, 211);
            this.vGrdDepartment.TabIndex = 0;
            // 
            // lookFirm
            // 
            this.lookFirm.AutoHeight = false;
            this.lookFirm.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookFirm.Name = "lookFirm";
            this.lookFirm.NullText = "Firma Seçiniz";
            // 
            // lookStatus
            // 
            this.lookStatus.AutoHeight = false;
            this.lookStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.NullText = "Durum Seçiniz";
            // 
            // spinEditNWorker
            // 
            this.spinEditNWorker.Appearance.Options.UseTextOptions = true;
            this.spinEditNWorker.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditNWorker.AutoHeight = false;
            this.spinEditNWorker.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditNWorker.DisplayFormat.FormatString = "N0";
            this.spinEditNWorker.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditNWorker.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditNWorker.Name = "spinEditNWorker";
            this.spinEditNWorker.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditNWorker_Validating);
            // 
            // lookZoneID
            // 
            this.lookZoneID.AutoHeight = false;
            this.lookZoneID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookZoneID.Name = "lookZoneID";
            // 
            // rowDepartmentID
            // 
            this.rowDepartmentID.Name = "rowDepartmentID";
            this.rowDepartmentID.Properties.Caption = "DepartmentID";
            this.rowDepartmentID.Properties.FieldName = "DepartmentID";
            this.rowDepartmentID.Visible = false;
            // 
            // rowName
            // 
            this.rowName.Height = 16;
            this.rowName.Name = "rowName";
            this.rowName.Properties.Caption = "Departman Adı";
            this.rowName.Properties.FieldName = "Name";
            // 
            // rowCode
            // 
            this.rowCode.Height = 16;
            this.rowCode.Name = "rowCode";
            this.rowCode.Properties.Caption = "Departman Kodu";
            this.rowCode.Properties.FieldName = "Code";
            // 
            // rowNWorker
            // 
            this.rowNWorker.AppearanceCell.Options.UseTextOptions = true;
            this.rowNWorker.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowNWorker.Name = "rowNWorker";
            this.rowNWorker.Properties.Caption = "Çalışan Sayısı";
            this.rowNWorker.Properties.FieldName = "NWorker";
            this.rowNWorker.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rowNWorker.Properties.RowEdit = this.spinEditNWorker;
            // 
            // rowZoneID
            // 
            this.rowZoneID.Name = "rowZoneID";
            this.rowZoneID.Properties.Caption = "İşletme";
            this.rowZoneID.Properties.FieldName = "ZoneID";
            this.rowZoneID.Properties.RowEdit = this.lookZoneID;
            // 
            // rowStatus
            // 
            this.rowStatus.Height = 16;
            this.rowStatus.Name = "rowStatus";
            this.rowStatus.Properties.Caption = "Durum";
            this.rowStatus.Properties.FieldName = "Status";
            this.rowStatus.Properties.RowEdit = this.lookStatus;
            // 
            // rowRowGUID
            // 
            this.rowRowGUID.Name = "rowRowGUID";
            this.rowRowGUID.Properties.Caption = "rowRowGUID";
            this.rowRowGUID.Properties.FieldName = "RowGUID";
            this.rowRowGUID.Visible = false;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 74);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.vGrdDepartment);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdDepartment);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(704, 607);
            this.splitContainerControl1.SplitterPosition = 211;
            this.splitContainerControl1.TabIndex = 5;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnRefresh,
            this.seperator1,
            this.toggleSwitch,
            this.btnChangeStatus});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 23);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbonControl1.Size = new System.Drawing.Size(704, 51);
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Yeni";
            this.btnNew.Id = 1;
            this.btnNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNew.ImageOptions.SvgImage")));
            this.btnNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnNew.Name = "btnNew";
            this.btnNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnNew_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Düzenle";
            this.btnEdit.Id = 2;
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnEdit_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Kaydet";
            this.btnSave.Id = 3;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.Name = "btnSave";
            this.btnSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSave_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Sil";
            this.btnDelete.Id = 4;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDelete_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Yenile";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRefresh_ItemClick);
            // 
            // seperator1
            // 
            this.seperator1.Caption = "||";
            this.seperator1.Id = 6;
            this.seperator1.Name = "seperator1";
            // 
            // toggleSwitch
            // 
            this.toggleSwitch.Caption = global::BoyArge.Properties.Resources.OnlyActiveRecords;
            this.toggleSwitch.Id = 7;
            this.toggleSwitch.Name = "toggleSwitch";
            this.toggleSwitch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ToggleSwitch_ItemClick);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Caption = "-";
            this.btnChangeStatus.Id = 8;
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnChangeStatus_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.seperator1);
            this.ribbonPageGroup1.ItemLinks.Add(this.toggleSwitch);
            this.ribbonPageGroup1.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(704, 23);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 681);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(704, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 23);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 658);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(704, 23);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 658);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnChangeStatus);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbonControl1;
            // 
            // DepartmentForm
            // 
            this.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 681);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "DepartmentForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departman Tanım Ekranı";
            this.Load += new System.EventHandler(this.DepartmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdNWorker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdFirmID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookFirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNWorker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookZoneID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDepartment;
        private DevExpress.XtraVerticalGrid.VGridControl vGrdDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDepartmentID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRowGUID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookFirm;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdFirmID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStatus;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarHeaderItem seperator1;
        private DevExpress.XtraBars.BarToggleSwitchItem toggleSwitch;
        private DevExpress.XtraBars.BarButtonItem btnChangeStatus;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraGrid.Columns.GridColumn colNWorker;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdNWorker;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowNWorker;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditNWorker;
        private DevExpress.XtraGrid.Columns.GridColumn colZoneID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdZone;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookZoneID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowZoneID;
    }
}