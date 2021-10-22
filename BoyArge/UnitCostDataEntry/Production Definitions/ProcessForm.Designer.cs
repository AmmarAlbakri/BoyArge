namespace BoyArge
{
    partial class ProcessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
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
            this.grdProcess = new DevExpress.XtraGrid.GridControl();
            this.grvProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProcessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMachineGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdMachineGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colZone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdZoneID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProcessType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdProcessType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSpecode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdCode3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.vGrdProcess = new DevExpress.XtraVerticalGrid.VGridControl();
            this.lookZone = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookMachineGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookProcessType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditCode3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rowProcessID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowZoneID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMachineGroupID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowProcessTypeID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowNote = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSpecode = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowRowGUID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachineGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdZoneID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdProcessType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProcessType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnRefresh,
            this.seperator1,
            this.toggleSwitch,
            this.btnChangeStatus});
            this.ribbon.Location = new System.Drawing.Point(0, 23);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbon.Size = new System.Drawing.Size(602, 51);
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
            this.toggleSwitch.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ToggleSwitch_CheckedChanged);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Caption = "-";
            this.btnChangeStatus.Id = 9;
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
            // grdProcess
            // 
            this.grdProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProcess.Location = new System.Drawing.Point(0, 0);
            this.grdProcess.MainView = this.grvProcess;
            this.grdProcess.Name = "grdProcess";
            this.grdProcess.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookGrdZoneID,
            this.lookGrdStatus,
            this.lookGrdMachineGroup,
            this.lookGrdProcessType});
            this.grdProcess.Size = new System.Drawing.Size(602, 207);
            this.grdProcess.TabIndex = 0;
            this.grdProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProcess});
            // 
            // grvProcess
            // 
            this.grvProcess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProcessID,
            this.colStatus,
            this.colMachineGroup,
            this.colZone,
            this.colProcessType,
            this.colSpecode,
            this.colName,
            this.colCode,
            this.colCode1,
            this.colCode2,
            this.colCode3,
            this.colRowGUID});
            this.grvProcess.GridControl = this.grdProcess;
            this.grvProcess.Name = "grvProcess";
            this.grvProcess.OptionsBehavior.Editable = false;
            this.grvProcess.OptionsView.ShowAutoFilterRow = true;
            this.grvProcess.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GrvProcess_PopupMenuShowing);
            this.grvProcess.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrvProcess_FocusedRowChanged);
            // 
            // colProcessID
            // 
            this.colProcessID.Caption = "ProcessID";
            this.colProcessID.FieldName = "ProcessID";
            this.colProcessID.Name = "colProcessID";
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
            // colMachineGroup
            // 
            this.colMachineGroup.Caption = "Makine Grubu";
            this.colMachineGroup.ColumnEdit = this.lookGrdMachineGroup;
            this.colMachineGroup.FieldName = "MachineGroupID";
            this.colMachineGroup.Name = "colMachineGroup";
            this.colMachineGroup.Visible = true;
            this.colMachineGroup.VisibleIndex = 4;
            // 
            // lookGrdMachineGroup
            // 
            this.lookGrdMachineGroup.AutoHeight = false;
            this.lookGrdMachineGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdMachineGroup.DisplayMember = "Name";
            this.lookGrdMachineGroup.Name = "lookGrdMachineGroup";
            this.lookGrdMachineGroup.ValueMember = "MachineGroupID";
            // 
            // colZone
            // 
            this.colZone.Caption = "İşletme";
            this.colZone.ColumnEdit = this.lookGrdZoneID;
            this.colZone.FieldName = "ZoneID";
            this.colZone.Name = "colZone";
            this.colZone.Visible = true;
            this.colZone.VisibleIndex = 1;
            // 
            // lookGrdZoneID
            // 
            this.lookGrdZoneID.AutoHeight = false;
            this.lookGrdZoneID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdZoneID.DisplayMember = "Name";
            this.lookGrdZoneID.Name = "lookGrdZoneID";
            this.lookGrdZoneID.ValueMember = "ZoneID";
            // 
            // colProcessType
            // 
            this.colProcessType.Caption = "Proses Türü";
            this.colProcessType.ColumnEdit = this.lookGrdProcessType;
            this.colProcessType.FieldName = "ProcessTypeID";
            this.colProcessType.Name = "colProcessType";
            this.colProcessType.Visible = true;
            this.colProcessType.VisibleIndex = 5;
            // 
            // lookGrdProcessType
            // 
            this.lookGrdProcessType.AutoHeight = false;
            this.lookGrdProcessType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdProcessType.DisplayMember = "Name";
            this.lookGrdProcessType.Name = "lookGrdProcessType";
            this.lookGrdProcessType.ValueMember = "ProcessTypeID";
            // 
            // colSpecode
            // 
            this.colSpecode.Caption = "Özel Kod";
            this.colSpecode.FieldName = "Specode";
            this.colSpecode.Name = "colSpecode";
            this.colSpecode.Visible = true;
            this.colSpecode.VisibleIndex = 6;
            // 
            // colName
            // 
            this.colName.Caption = "Proses Adı";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colCode
            // 
            this.colCode.Caption = "Proses Kodu";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 3;
            // 
            // colCode1
            // 
            this.colCode1.Caption = "Ek Alan - 1";
            this.colCode1.FieldName = "Code1";
            this.colCode1.Name = "colCode1";
            this.colCode1.Visible = true;
            this.colCode1.VisibleIndex = 7;
            // 
            // colCode2
            // 
            this.colCode2.Caption = "Ek Alan - 2";
            this.colCode2.FieldName = "Code2";
            this.colCode2.Name = "colCode2";
            this.colCode2.Visible = true;
            this.colCode2.VisibleIndex = 8;
            // 
            // colCode3
            // 
            this.colCode3.Caption = "Ek Alan - 3";
            this.colCode3.ColumnEdit = this.spinEditGrdCode3;
            this.colCode3.FieldName = "Code3";
            this.colCode3.Name = "colCode3";
            this.colCode3.Visible = true;
            this.colCode3.VisibleIndex = 9;
            // 
            // spinEditGrdCode3
            // 
            this.spinEditGrdCode3.AutoHeight = false;
            this.spinEditGrdCode3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdCode3.Name = "spinEditGrdCode3";
            // 
            // colRowGUID
            // 
            this.colRowGUID.Caption = "rowGUID";
            this.colRowGUID.FieldName = "RowGUID";
            this.colRowGUID.Name = "colRowGUID";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 74);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.vGrdProcess);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdProcess);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(602, 398);
            this.splitContainerControl1.SplitterPosition = 181;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // vGrdProcess
            // 
            this.vGrdProcess.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrdProcess.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGrdProcess.CustomizationFormBounds = new System.Drawing.Rectangle(457, 176, 214, 258);
            this.vGrdProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrdProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGrdProcess.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGrdProcess.Location = new System.Drawing.Point(0, 0);
            this.vGrdProcess.Name = "vGrdProcess";
            this.vGrdProcess.RecordWidth = 158;
            this.vGrdProcess.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookZone,
            this.lookMachineGroup,
            this.lookStatus,
            this.lookProcessType,
            this.spinEditCode3});
            this.vGrdProcess.RowHeaderWidth = 42;
            this.vGrdProcess.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowProcessID,
            this.rowZoneID,
            this.rowMachineGroupID,
            this.rowProcessTypeID,
            this.rowName,
            this.rowCode,
            this.rowNote,
            this.rowSpecode,
            this.rowCode1,
            this.rowCode2,
            this.rowCode3,
            this.rowStatus,
            this.rowRowGUID});
            this.vGrdProcess.Size = new System.Drawing.Size(602, 181);
            this.vGrdProcess.TabIndex = 0;
            this.vGrdProcess.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.VGrdProcess_CellValueChanged);
            // 
            // lookZone
            // 
            this.lookZone.AutoHeight = false;
            this.lookZone.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookZone.Name = "lookZone";
            this.lookZone.NullText = "İşletme Seçiniz";
            // 
            // lookMachineGroup
            // 
            this.lookMachineGroup.AutoHeight = false;
            this.lookMachineGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookMachineGroup.DisplayMember = "Name";
            this.lookMachineGroup.Name = "lookMachineGroup";
            this.lookMachineGroup.NullText = "Makine Grubu Seçiniz";
            this.lookMachineGroup.ValueMember = "MachineGroupID";
            // 
            // lookStatus
            // 
            this.lookStatus.AutoHeight = false;
            this.lookStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.NullText = "Durum Seçiniz";
            // 
            // lookProcessType
            // 
            this.lookProcessType.AutoHeight = false;
            this.lookProcessType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookProcessType.DisplayMember = "Name";
            this.lookProcessType.Name = "lookProcessType";
            this.lookProcessType.NullText = "Proses Türü Seçiniz";
            this.lookProcessType.ValueMember = "ProcessTypeID";
            // 
            // spinEditCode3
            // 
            this.spinEditCode3.Appearance.Options.UseTextOptions = true;
            this.spinEditCode3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditCode3.AutoHeight = false;
            this.spinEditCode3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCode3.Name = "spinEditCode3";
            // 
            // rowProcessID
            // 
            this.rowProcessID.Name = "rowProcessID";
            this.rowProcessID.Properties.Caption = "ProcessID";
            this.rowProcessID.Properties.FieldName = "ProcessID";
            this.rowProcessID.Visible = false;
            // 
            // rowZoneID
            // 
            this.rowZoneID.Name = "rowZoneID";
            this.rowZoneID.Properties.Caption = "İşletme";
            this.rowZoneID.Properties.FieldName = "ZoneID";
            this.rowZoneID.Properties.RowEdit = this.lookZone;
            // 
            // rowMachineGroupID
            // 
            this.rowMachineGroupID.Name = "rowMachineGroupID";
            this.rowMachineGroupID.Properties.Caption = "Makine Grubu";
            this.rowMachineGroupID.Properties.FieldName = "MachineGroupID";
            this.rowMachineGroupID.Properties.RowEdit = this.lookMachineGroup;
            // 
            // rowProcessTypeID
            // 
            this.rowProcessTypeID.Name = "rowProcessTypeID";
            this.rowProcessTypeID.Properties.Caption = "Proses Tipi";
            this.rowProcessTypeID.Properties.FieldName = "ProcessTypeID";
            this.rowProcessTypeID.Properties.RowEdit = this.lookProcessType;
            // 
            // rowName
            // 
            this.rowName.Height = 16;
            this.rowName.Name = "rowName";
            this.rowName.Properties.Caption = "Proses Adı";
            this.rowName.Properties.FieldName = "Name";
            // 
            // rowCode
            // 
            this.rowCode.Height = 16;
            this.rowCode.Name = "rowCode";
            this.rowCode.Properties.Caption = "Proses Kodu";
            this.rowCode.Properties.FieldName = "Code";
            // 
            // rowNote
            // 
            this.rowNote.Name = "rowNote";
            this.rowNote.Properties.Caption = "Açıklama";
            this.rowNote.Properties.FieldName = "Note";
            // 
            // rowSpecode
            // 
            this.rowSpecode.Height = 18;
            this.rowSpecode.Name = "rowSpecode";
            this.rowSpecode.Properties.Caption = "Özel Kod";
            this.rowSpecode.Properties.FieldName = "Specode";
            // 
            // rowCode1
            // 
            this.rowCode1.Name = "rowCode1";
            this.rowCode1.Properties.Caption = "Ek Alan - 1";
            this.rowCode1.Properties.FieldName = "Code1";
            // 
            // rowCode2
            // 
            this.rowCode2.Name = "rowCode2";
            this.rowCode2.Properties.Caption = "Ek Alan - 2";
            this.rowCode2.Properties.FieldName = "Code2";
            // 
            // rowCode3
            // 
            this.rowCode3.Name = "rowCode3";
            this.rowCode3.Properties.Caption = "Ek Alan - 3";
            this.rowCode3.Properties.FieldName = "Code3";
            this.rowCode3.Properties.RowEdit = this.spinEditCode3;
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
            this.barDockControlTop.Size = new System.Drawing.Size(602, 23);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 472);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(602, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 23);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 449);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(602, 23);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 449);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnChangeStatus);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbon;
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 472);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProcessForm";
            this.Ribbon = this.ribbon;
            this.Text = "Proses Tanımı";
            this.Load += new System.EventHandler(this.ProcessForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachineGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdZoneID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdProcessType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGrdProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProcessType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vGrdProcess;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookZone;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProcessID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRowGUID;
        private DevExpress.XtraGrid.GridControl grdProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colZone;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdZoneID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookMachineGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMachineGroupID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowNote;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSpecode;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProcessTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookProcessType;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdMachineGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdProcessType;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecode;
        private DevExpress.XtraBars.BarHeaderItem seperator1;
        private DevExpress.XtraBars.BarToggleSwitchItem toggleSwitch;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnChangeStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowZoneID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditCode3;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode3;
        private DevExpress.XtraGrid.Columns.GridColumn colCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colCode3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdCode3;

    }
}