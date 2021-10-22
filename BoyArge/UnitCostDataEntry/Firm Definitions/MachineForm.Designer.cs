namespace BoyArge
{
    partial class MachineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.separator1 = new DevExpress.XtraBars.BarHeaderItem();
            this.toggleSwitch = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnChangeStatus = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.grdMachine = new DevExpress.XtraGrid.GridControl();
            this.grvMachine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdMachineGroupID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProductionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdProductionType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModelYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNeedleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFNeedleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdCode3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.vGrdMachine = new DevExpress.XtraVerticalGrid.VGridControl();
            this.lookMachineGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookProductionType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditCode3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.dateEditDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rowMachineID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMachineGroupID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowProductionTypeID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowModel = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSpecode = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowModelYear = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowNeedleCount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowFNeedleCount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowNote = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowRowGUID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.spinEditNeedleCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditFNeedleCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachineGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdProductionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProductionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNeedleCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditFNeedleCount)).BeginInit();
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
            this.separator1,
            this.toggleSwitch,
            this.btnChangeStatus});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbon.Size = new System.Drawing.Size(602, 87);
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
            // separator1
            // 
            this.separator1.Caption = "||";
            this.separator1.Id = 6;
            this.separator1.Name = "separator1";
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
            this.btnChangeStatus.Caption = "btnChangeStatus";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.separator1);
            this.ribbonPageGroup1.ItemLinks.Add(this.toggleSwitch);
            this.ribbonPageGroup1.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // grdMachine
            // 
            this.grdMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMachine.Location = new System.Drawing.Point(0, 0);
            this.grdMachine.MainView = this.grvMachine;
            this.grdMachine.Name = "grdMachine";
            this.grdMachine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookGrdMachineGroupID,
            this.lookGrdStatus,
            this.lookGrdProductionType,
            this.spinEditGrdCode3});
            this.grdMachine.Size = new System.Drawing.Size(602, 198);
            this.grdMachine.TabIndex = 4;
            this.grdMachine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMachine});
            // 
            // grvMachine
            // 
            this.grvMachine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachineID,
            this.colMachineGroup,
            this.colProductionType,
            this.colName,
            this.colCode,
            this.colModel,
            this.colSpecode,
            this.colModelYear,
            this.colNeedleCount,
            this.colFNeedleCount,
            this.colDate,
            this.colNote,
            this.colCode1,
            this.colCode2,
            this.colCode3,
            this.colStatus,
            this.colRowGUID});
            this.grvMachine.GridControl = this.grdMachine;
            this.grvMachine.Name = "grvMachine";
            this.grvMachine.OptionsBehavior.Editable = false;
            this.grvMachine.OptionsView.ShowAutoFilterRow = true;
            this.grvMachine.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GrvMachine_PopupMenuShowing);
            this.grvMachine.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrvMachine_FocusedRowChanged);
            // 
            // colMachineID
            // 
            this.colMachineID.Caption = "MachineID";
            this.colMachineID.FieldName = "MachineID";
            this.colMachineID.Name = "colMachineID";
            // 
            // colMachineGroup
            // 
            this.colMachineGroup.Caption = "Makine Grubu";
            this.colMachineGroup.ColumnEdit = this.lookGrdMachineGroupID;
            this.colMachineGroup.FieldName = "MachineGroupID";
            this.colMachineGroup.Name = "colMachineGroup";
            this.colMachineGroup.Visible = true;
            this.colMachineGroup.VisibleIndex = 1;
            // 
            // lookGrdMachineGroupID
            // 
            this.lookGrdMachineGroupID.AutoHeight = false;
            this.lookGrdMachineGroupID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdMachineGroupID.DisplayMember = "Name";
            this.lookGrdMachineGroupID.Name = "lookGrdMachineGroupID";
            this.lookGrdMachineGroupID.ValueMember = "MachineGroupID";
            // 
            // colProductionType
            // 
            this.colProductionType.Caption = "Üretim Tipi";
            this.colProductionType.ColumnEdit = this.lookGrdProductionType;
            this.colProductionType.FieldName = "ProductionTypeID";
            this.colProductionType.Name = "colProductionType";
            this.colProductionType.Visible = true;
            this.colProductionType.VisibleIndex = 4;
            // 
            // lookGrdProductionType
            // 
            this.lookGrdProductionType.AutoHeight = false;
            this.lookGrdProductionType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdProductionType.Name = "lookGrdProductionType";
            // 
            // colName
            // 
            this.colName.Caption = "Makine Adı";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colCode
            // 
            this.colCode.Caption = "Makine Kodu";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 3;
            // 
            // colModel
            // 
            this.colModel.Caption = "Model";
            this.colModel.FieldName = "Model";
            this.colModel.Name = "colModel";
            this.colModel.Visible = true;
            this.colModel.VisibleIndex = 5;
            // 
            // colSpecode
            // 
            this.colSpecode.Caption = "Özellik";
            this.colSpecode.FieldName = "Specode";
            this.colSpecode.Name = "colSpecode";
            this.colSpecode.Visible = true;
            this.colSpecode.VisibleIndex = 6;
            // 
            // colModelYear
            // 
            this.colModelYear.Caption = "Model Yılı";
            this.colModelYear.FieldName = "ModelYear";
            this.colModelYear.Name = "colModelYear";
            this.colModelYear.Visible = true;
            this.colModelYear.VisibleIndex = 7;
            // 
            // colNeedleCount
            // 
            this.colNeedleCount.Caption = "İğ Sayısı";
            this.colNeedleCount.FieldName = "NeedleCount";
            this.colNeedleCount.Name = "colNeedleCount";
            this.colNeedleCount.Visible = true;
            this.colNeedleCount.VisibleIndex = 8;
            // 
            // colFNeedleCount
            // 
            this.colFNeedleCount.Caption = "Besleme Göz Sayısı";
            this.colFNeedleCount.FieldName = "FNeedleCount";
            this.colFNeedleCount.Name = "colFNeedleCount";
            this.colFNeedleCount.Visible = true;
            this.colFNeedleCount.VisibleIndex = 9;
            // 
            // colDate
            // 
            this.colDate.Caption = "Tarih";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 10;
            // 
            // colNote
            // 
            this.colNote.Caption = "Açıklama";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 11;
            // 
            // colCode1
            // 
            this.colCode1.Caption = "Ek Alan - 1";
            this.colCode1.FieldName = "Code1";
            this.colCode1.Name = "colCode1";
            this.colCode1.Visible = true;
            this.colCode1.VisibleIndex = 12;
            // 
            // colCode2
            // 
            this.colCode2.Caption = "Ek Alan - 2";
            this.colCode2.FieldName = "Code2";
            this.colCode2.Name = "colCode2";
            this.colCode2.Visible = true;
            this.colCode2.VisibleIndex = 13;
            // 
            // colCode3
            // 
            this.colCode3.Caption = "Ek Alan - 3";
            this.colCode3.ColumnEdit = this.spinEditGrdCode3;
            this.colCode3.FieldName = "Code3";
            this.colCode3.Name = "colCode3";
            this.colCode3.Visible = true;
            this.colCode3.VisibleIndex = 14;
            // 
            // spinEditGrdCode3
            // 
            this.spinEditGrdCode3.AutoHeight = false;
            this.spinEditGrdCode3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdCode3.Name = "spinEditGrdCode3";
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 87);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.vGrdMachine);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdMachine);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(602, 477);
            this.splitContainerControl1.SplitterPosition = 269;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // vGrdMachine
            // 
            this.vGrdMachine.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrdMachine.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGrdMachine.CustomizationFormBounds = new System.Drawing.Rectangle(457, 176, 214, 258);
            this.vGrdMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrdMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGrdMachine.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGrdMachine.Location = new System.Drawing.Point(0, 0);
            this.vGrdMachine.Name = "vGrdMachine";
            this.vGrdMachine.RecordWidth = 158;
            this.vGrdMachine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookMachineGroup,
            this.lookStatus,
            this.lookProductionType,
            this.spinEditCode3,
            this.dateEditDate,
            this.spinEditNeedleCount,
            this.spinEditFNeedleCount});
            this.vGrdMachine.RowHeaderWidth = 42;
            this.vGrdMachine.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowMachineID,
            this.rowMachineGroupID,
            this.rowProductionTypeID,
            this.rowName,
            this.rowCode,
            this.rowModel,
            this.rowSpecode,
            this.rowModelYear,
            this.rowNeedleCount,
            this.rowFNeedleCount,
            this.rowDate,
            this.rowNote,
            this.rowCode1,
            this.rowCode2,
            this.rowCode3,
            this.rowStatus,
            this.rowRowGUID});
            this.vGrdMachine.Size = new System.Drawing.Size(602, 269);
            this.vGrdMachine.TabIndex = 4;
            // 
            // lookMachineGroup
            // 
            this.lookMachineGroup.AutoHeight = false;
            this.lookMachineGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookMachineGroup.Name = "lookMachineGroup";
            this.lookMachineGroup.NullText = "Makine Grubu Seçiniz";
            // 
            // lookStatus
            // 
            this.lookStatus.AutoHeight = false;
            this.lookStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.NullText = "Durum Seçiniz";
            // 
            // lookProductionType
            // 
            this.lookProductionType.AutoHeight = false;
            this.lookProductionType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookProductionType.DisplayMember = "Name";
            this.lookProductionType.Name = "lookProductionType";
            this.lookProductionType.ValueMember = "ProductionTypeID";
            // 
            // spinEditCode3
            // 
            this.spinEditCode3.AutoHeight = false;
            this.spinEditCode3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCode3.Name = "spinEditCode3";
            // 
            // dateEditDate
            // 
            this.dateEditDate.AutoHeight = false;
            this.dateEditDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.Name = "dateEditDate";
            // 
            // rowMachineID
            // 
            this.rowMachineID.Name = "rowMachineID";
            this.rowMachineID.Properties.Caption = "MachineID";
            this.rowMachineID.Properties.FieldName = "MachineID";
            this.rowMachineID.Visible = false;
            // 
            // rowMachineGroupID
            // 
            this.rowMachineGroupID.Height = 16;
            this.rowMachineGroupID.Name = "rowMachineGroupID";
            this.rowMachineGroupID.Properties.Caption = "Makine Grubu";
            this.rowMachineGroupID.Properties.FieldName = "MachineGroupID";
            this.rowMachineGroupID.Properties.RowEdit = this.lookMachineGroup;
            // 
            // rowProductionTypeID
            // 
            this.rowProductionTypeID.Name = "rowProductionTypeID";
            this.rowProductionTypeID.Properties.Caption = "Tip";
            this.rowProductionTypeID.Properties.FieldName = "ProductionTypeID";
            this.rowProductionTypeID.Properties.RowEdit = this.lookProductionType;
            // 
            // rowName
            // 
            this.rowName.Height = 16;
            this.rowName.Name = "rowName";
            this.rowName.Properties.Caption = "Makine Adı";
            this.rowName.Properties.FieldName = "Name";
            // 
            // rowCode
            // 
            this.rowCode.Height = 16;
            this.rowCode.Name = "rowCode";
            this.rowCode.Properties.Caption = "Makine Kodu";
            this.rowCode.Properties.FieldName = "Code";
            // 
            // rowModel
            // 
            this.rowModel.Name = "rowModel";
            this.rowModel.Properties.Caption = "Model";
            this.rowModel.Properties.FieldName = "Model";
            // 
            // rowSpecode
            // 
            this.rowSpecode.Name = "rowSpecode";
            this.rowSpecode.Properties.Caption = "Özellik";
            this.rowSpecode.Properties.FieldName = "Specode";
            // 
            // rowModelYear
            // 
            this.rowModelYear.Name = "rowModelYear";
            this.rowModelYear.Properties.Caption = "Model Yıl";
            this.rowModelYear.Properties.FieldName = "ModelYear";
            // 
            // rowNeedleCount
            // 
            this.rowNeedleCount.AppearanceCell.Options.UseTextOptions = true;
            this.rowNeedleCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowNeedleCount.Name = "rowNeedleCount";
            this.rowNeedleCount.Properties.Caption = "İğ Sayısı";
            this.rowNeedleCount.Properties.FieldName = "NeedleCount";
            this.rowNeedleCount.Properties.RowEdit = this.spinEditNeedleCount;
            // 
            // rowFNeedleCount
            // 
            this.rowFNeedleCount.AppearanceCell.Options.UseTextOptions = true;
            this.rowFNeedleCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowFNeedleCount.Name = "rowFNeedleCount";
            this.rowFNeedleCount.Properties.Caption = "Besleme Göz Sayısı";
            this.rowFNeedleCount.Properties.FieldName = "FNeedleCount";
            this.rowFNeedleCount.Properties.RowEdit = this.spinEditFNeedleCount;
            // 
            // rowDate
            // 
            this.rowDate.Name = "rowDate";
            this.rowDate.Properties.Caption = "Tarih";
            this.rowDate.Properties.FieldName = "Date";
            this.rowDate.Properties.RowEdit = this.dateEditDate;
            // 
            // rowNote
            // 
            this.rowNote.Name = "rowNote";
            this.rowNote.Properties.Caption = "Açıklama";
            this.rowNote.Properties.FieldName = "Note";
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
            this.rowCode3.AppearanceCell.Options.UseTextOptions = true;
            this.rowCode3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
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
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(602, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 564);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(602, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 564);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(602, 0);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 564);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnChangeStatus);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbon;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // spinEditNeedleCount
            // 
            this.spinEditNeedleCount.AutoHeight = false;
            this.spinEditNeedleCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditNeedleCount.Name = "spinEditNeedleCount";
            this.spinEditNeedleCount.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditNeedleCount_Validating);
            // 
            // spinEditFNeedleCount
            // 
            this.spinEditFNeedleCount.AutoHeight = false;
            this.spinEditFNeedleCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditFNeedleCount.Name = "spinEditFNeedleCount";
            this.spinEditFNeedleCount.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditFNeedleCount_Validating);
            // 
            // MachineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 564);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MachineForm";
            this.Ribbon = this.ribbon;
            this.Text = "Makine Tanımı";
            this.Load += new System.EventHandler(this.MachineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachineGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdProductionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGrdMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProductionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNeedleCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditFNeedleCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vGrdMachine;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookMachineGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMachineID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMachineGroupID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRowGUID;
        private DevExpress.XtraGrid.GridControl grdMachine;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdMachineGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookProductionType;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProductionTypeID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowModel;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSpecode;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowModelYear;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowNeedleCount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFNeedleCount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowNote;
        private DevExpress.XtraGrid.Columns.GridColumn colProductionType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdProductionType;
        private DevExpress.XtraGrid.Columns.GridColumn colModel;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecode;
        private DevExpress.XtraGrid.Columns.GridColumn colModelYear;
        private DevExpress.XtraGrid.Columns.GridColumn colNeedleCount;
        private DevExpress.XtraGrid.Columns.GridColumn colFNeedleCount;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraBars.BarHeaderItem separator1;
        private DevExpress.XtraBars.BarToggleSwitchItem toggleSwitch;
        private DevExpress.XtraBars.BarButtonItem btnChangeStatus;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colCode3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdCode3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditCode3;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode3;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dateEditDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditNeedleCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditFNeedleCount;
    }
}