namespace BoyArge
{
    partial class StockProcessRelationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockProcessRelationForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.seperator1 = new DevExpress.XtraBars.BarHeaderItem();
            this.toggleSwitch = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnChangeStatus = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditRecords = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.grdStockProcessRelation = new DevExpress.XtraGrid.GridControl();
            this.grvStockProcessRelation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStockProcessRelationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMachineOrProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacPro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStockGroupID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProcessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdProcess = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMachineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdMachine = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTurnOver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdTurnOver = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colEfficiency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdEfficiency = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colWastage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdWastage = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colPeriodCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdPeriodCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colArithmeticOperatorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdArithmeticOperatorID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colWorkerCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdWorkerCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colLineNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdLineNumber = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.vGrdStockProcessRelation = new DevExpress.XtraVerticalGrid.VGridControl();
            this.lookStock = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookProcess = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookMachine = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditTurnOver = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditEfficiency = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditWastage = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditPeriodCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lookArithmeticOperatorID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditWorkerCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.toggleMachineOrProcess = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.spinEditLineNumber = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rowStockProcessRelationID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStockGroupID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowProcessID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMachineID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTurnOver = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowEfficiency = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowWastage = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowAmount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPeriodCount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMachineOrProcess = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowArithmeticOperatorID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowWorkerCount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowRowGUID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowLineNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::BoyArge.WaitForm), true, true, true);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockProcessRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockProcessRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdTurnOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdEfficiency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdWastage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdPeriodCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdArithmeticOperatorID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdWorkerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdLineNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdStockProcessRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTurnOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditEfficiency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWastage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPeriodCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookArithmeticOperatorID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWorkerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleMachineOrProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLineNumber)).BeginInit();
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
            this.btnChangeStatus,
            this.btnEditRecords});
            this.ribbon.Location = new System.Drawing.Point(0, 23);
            this.ribbon.MaxItemId = 11;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbon.Size = new System.Drawing.Size(1305, 87);
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
            // btnEditRecords
            // 
            this.btnEditRecords.Caption = "Toplu Düzenle";
            this.btnEditRecords.Id = 10;
            this.btnEditRecords.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEditRecords.ImageOptions.SvgImage")));
            this.btnEditRecords.Name = "btnEditRecords";
            this.btnEditRecords.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnEditRecords_ItemClick);
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
            // grdStockProcessRelation
            // 
            this.grdStockProcessRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStockProcessRelation.Location = new System.Drawing.Point(0, 0);
            this.grdStockProcessRelation.MainView = this.grvStockProcessRelation;
            this.grdStockProcessRelation.Name = "grdStockProcessRelation";
            this.grdStockProcessRelation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookGrdStockGroupID,
            this.lookGrdStatus,
            this.lookGrdProcess,
            this.lookGrdMachine,
            this.lookGrdArithmeticOperatorID,
            this.spinEditGrdLineNumber,
            this.spinEditGrdWorkerCount,
            this.spinEditGrdPeriodCount,
            this.spinEditGrdAmount,
            this.spinEditGrdWastage,
            this.spinEditGrdEfficiency,
            this.spinEditGrdTurnOver});
            this.grdStockProcessRelation.Size = new System.Drawing.Size(1305, 332);
            this.grdStockProcessRelation.TabIndex = 0;
            this.grdStockProcessRelation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockProcessRelation});
            // 
            // grvStockProcessRelation
            // 
            this.grvStockProcessRelation.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.grvStockProcessRelation.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grvStockProcessRelation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStockProcessRelationID,
            this.colStatus,
            this.colMachineOrProcess,
            this.colMacPro,
            this.colStockGroupID,
            this.colProcessID,
            this.colMachineID,
            this.colTurnOver,
            this.colEfficiency,
            this.colWastage,
            this.colAmount,
            this.colPeriodCount,
            this.colArithmeticOperatorID,
            this.colWorkerCount,
            this.colLineNumber,
            this.colRowGUID});
            this.grvStockProcessRelation.GridControl = this.grdStockProcessRelation;
            this.grvStockProcessRelation.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.grvStockProcessRelation.Name = "grvStockProcessRelation";
            this.grvStockProcessRelation.OptionsMenu.ShowFooterItem = true;
            this.grvStockProcessRelation.OptionsSelection.MultiSelect = true;
            this.grvStockProcessRelation.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvStockProcessRelation.OptionsView.ShowAutoFilterRow = true;
            this.grvStockProcessRelation.OptionsView.ShowFooter = true;
            this.grvStockProcessRelation.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GrvStockProcessRelation_PopupMenuShowing);
            this.grvStockProcessRelation.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrvStockProcessRelation_FocusedRowChanged);
            // 
            // colStockProcessRelationID
            // 
            this.colStockProcessRelationID.Caption = "StockProcessRelationID";
            this.colStockProcessRelationID.FieldName = "StockProcessRelationID";
            this.colStockProcessRelationID.Name = "colStockProcessRelationID";
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStatus.Caption = "Durum";
            this.colStatus.ColumnEdit = this.lookGrdStatus;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Status", "Kayıt Sayısı: {0}")});
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 1;
            // 
            // lookGrdStatus
            // 
            this.lookGrdStatus.AutoHeight = false;
            this.lookGrdStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStatus.DisplayMember = "Name";
            this.lookGrdStatus.Name = "lookGrdStatus";
            this.lookGrdStatus.NullText = "Durum Seçiniz";
            this.lookGrdStatus.ValueMember = "Code";
            // 
            // colMachineOrProcess
            // 
            this.colMachineOrProcess.Caption = "Makine/Process";
            this.colMachineOrProcess.CustomizationCaption = " ";
            this.colMachineOrProcess.FieldName = "MachineOrProcess";
            this.colMachineOrProcess.Name = "colMachineOrProcess";
            // 
            // colMacPro
            // 
            this.colMacPro.Caption = "Makine/Process";
            this.colMacPro.FieldName = "MakineProses";
            this.colMacPro.Name = "colMacPro";
            this.colMacPro.Visible = true;
            this.colMacPro.VisibleIndex = 12;
            // 
            // colStockGroupID
            // 
            this.colStockGroupID.Caption = "Mamül Grubu";
            this.colStockGroupID.ColumnEdit = this.lookGrdStockGroupID;
            this.colStockGroupID.FieldName = "StockGroupID";
            this.colStockGroupID.Name = "colStockGroupID";
            this.colStockGroupID.Visible = true;
            this.colStockGroupID.VisibleIndex = 2;
            // 
            // lookGrdStockGroupID
            // 
            this.lookGrdStockGroupID.AutoHeight = false;
            this.lookGrdStockGroupID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStockGroupID.DisplayMember = "Name";
            this.lookGrdStockGroupID.Name = "lookGrdStockGroupID";
            this.lookGrdStockGroupID.NullText = "Mamül Grubu Seçiniz";
            this.lookGrdStockGroupID.ValueMember = "StockGroupID";
            // 
            // colProcessID
            // 
            this.colProcessID.Caption = "Proses";
            this.colProcessID.ColumnEdit = this.lookGrdProcess;
            this.colProcessID.FieldName = "ProcessID";
            this.colProcessID.Name = "colProcessID";
            this.colProcessID.Visible = true;
            this.colProcessID.VisibleIndex = 3;
            // 
            // lookGrdProcess
            // 
            this.lookGrdProcess.AutoHeight = false;
            this.lookGrdProcess.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdProcess.DisplayMember = "Name";
            this.lookGrdProcess.Name = "lookGrdProcess";
            this.lookGrdProcess.ValueMember = "ProcessID";
            // 
            // colMachineID
            // 
            this.colMachineID.Caption = "Makine";
            this.colMachineID.ColumnEdit = this.lookGrdMachine;
            this.colMachineID.FieldName = "MachineID";
            this.colMachineID.Name = "colMachineID";
            this.colMachineID.Visible = true;
            this.colMachineID.VisibleIndex = 4;
            // 
            // lookGrdMachine
            // 
            this.lookGrdMachine.AutoHeight = false;
            this.lookGrdMachine.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdMachine.DisplayMember = "Name";
            this.lookGrdMachine.Name = "lookGrdMachine";
            this.lookGrdMachine.ValueMember = "MachineID";
            // 
            // colTurnOver
            // 
            this.colTurnOver.Caption = "Devir Hızı";
            this.colTurnOver.ColumnEdit = this.spinEditGrdTurnOver;
            this.colTurnOver.FieldName = "TurnOver";
            this.colTurnOver.Name = "colTurnOver";
            this.colTurnOver.Visible = true;
            this.colTurnOver.VisibleIndex = 5;
            // 
            // spinEditGrdTurnOver
            // 
            this.spinEditGrdTurnOver.AutoHeight = false;
            this.spinEditGrdTurnOver.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdTurnOver.Name = "spinEditGrdTurnOver";
            // 
            // colEfficiency
            // 
            this.colEfficiency.Caption = "Randıman(%)";
            this.colEfficiency.ColumnEdit = this.spinEditGrdEfficiency;
            this.colEfficiency.FieldName = "Efficiency";
            this.colEfficiency.Name = "colEfficiency";
            this.colEfficiency.Visible = true;
            this.colEfficiency.VisibleIndex = 6;
            // 
            // spinEditGrdEfficiency
            // 
            this.spinEditGrdEfficiency.AutoHeight = false;
            this.spinEditGrdEfficiency.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdEfficiency.Name = "spinEditGrdEfficiency";
            // 
            // colWastage
            // 
            this.colWastage.Caption = "Fire";
            this.colWastage.ColumnEdit = this.spinEditGrdWastage;
            this.colWastage.FieldName = "Wastage";
            this.colWastage.Name = "colWastage";
            this.colWastage.Visible = true;
            this.colWastage.VisibleIndex = 7;
            // 
            // spinEditGrdWastage
            // 
            this.spinEditGrdWastage.AutoHeight = false;
            this.spinEditGrdWastage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdWastage.Name = "spinEditGrdWastage";
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Miktar";
            this.colAmount.ColumnEdit = this.spinEditGrdAmount;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 8;
            // 
            // spinEditGrdAmount
            // 
            this.spinEditGrdAmount.AutoHeight = false;
            this.spinEditGrdAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdAmount.Name = "spinEditGrdAmount";
            // 
            // colPeriodCount
            // 
            this.colPeriodCount.Caption = "Periyot Sayısı";
            this.colPeriodCount.ColumnEdit = this.spinEditGrdPeriodCount;
            this.colPeriodCount.FieldName = "PeriodCount";
            this.colPeriodCount.Name = "colPeriodCount";
            this.colPeriodCount.Visible = true;
            this.colPeriodCount.VisibleIndex = 9;
            // 
            // spinEditGrdPeriodCount
            // 
            this.spinEditGrdPeriodCount.AutoHeight = false;
            this.spinEditGrdPeriodCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdPeriodCount.Name = "spinEditGrdPeriodCount";
            // 
            // colArithmeticOperatorID
            // 
            this.colArithmeticOperatorID.Caption = "İşlem Operatörü";
            this.colArithmeticOperatorID.ColumnEdit = this.lookGrdArithmeticOperatorID;
            this.colArithmeticOperatorID.FieldName = "ArithmeticOperatorID";
            this.colArithmeticOperatorID.Name = "colArithmeticOperatorID";
            this.colArithmeticOperatorID.Visible = true;
            this.colArithmeticOperatorID.VisibleIndex = 10;
            // 
            // lookGrdArithmeticOperatorID
            // 
            this.lookGrdArithmeticOperatorID.AutoHeight = false;
            this.lookGrdArithmeticOperatorID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdArithmeticOperatorID.DisplayMember = "Code";
            this.lookGrdArithmeticOperatorID.Name = "lookGrdArithmeticOperatorID";
            this.lookGrdArithmeticOperatorID.ValueMember = "TableStatusID";
            // 
            // colWorkerCount
            // 
            this.colWorkerCount.Caption = "İşçi Sayısı";
            this.colWorkerCount.ColumnEdit = this.spinEditGrdWorkerCount;
            this.colWorkerCount.FieldName = "WorkerCount";
            this.colWorkerCount.Name = "colWorkerCount";
            this.colWorkerCount.Visible = true;
            this.colWorkerCount.VisibleIndex = 11;
            // 
            // spinEditGrdWorkerCount
            // 
            this.spinEditGrdWorkerCount.AutoHeight = false;
            this.spinEditGrdWorkerCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdWorkerCount.Name = "spinEditGrdWorkerCount";
            // 
            // colLineNumber
            // 
            this.colLineNumber.Caption = "Sıra No";
            this.colLineNumber.ColumnEdit = this.spinEditGrdLineNumber;
            this.colLineNumber.FieldName = "LineNumber";
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.Visible = true;
            this.colLineNumber.VisibleIndex = 13;
            // 
            // spinEditGrdLineNumber
            // 
            this.spinEditGrdLineNumber.AutoHeight = false;
            this.spinEditGrdLineNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdLineNumber.Name = "spinEditGrdLineNumber";
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 110);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.vGrdStockProcessRelation);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdStockProcessRelation);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1305, 610);
            this.splitContainerControl1.SplitterPosition = 268;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // vGrdStockProcessRelation
            // 
            this.vGrdStockProcessRelation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrdStockProcessRelation.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.vGrdStockProcessRelation.CustomizationFormBounds = new System.Drawing.Rectangle(457, 176, 214, 258);
            this.vGrdStockProcessRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrdStockProcessRelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGrdStockProcessRelation.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGrdStockProcessRelation.Location = new System.Drawing.Point(0, 0);
            this.vGrdStockProcessRelation.Name = "vGrdStockProcessRelation";
            this.vGrdStockProcessRelation.RecordWidth = 158;
            this.vGrdStockProcessRelation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookStock,
            this.lookProcess,
            this.lookMachine,
            this.lookStatus,
            this.spinEditTurnOver,
            this.spinEditEfficiency,
            this.spinEditWastage,
            this.spinEditAmount,
            this.spinEditPeriodCount,
            this.lookArithmeticOperatorID,
            this.spinEditWorkerCount,
            this.toggleMachineOrProcess,
            this.spinEditLineNumber});
            this.vGrdStockProcessRelation.RowHeaderWidth = 42;
            this.vGrdStockProcessRelation.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowStockProcessRelationID,
            this.rowStockGroupID,
            this.rowProcessID,
            this.rowMachineID,
            this.rowTurnOver,
            this.rowEfficiency,
            this.rowWastage,
            this.rowAmount,
            this.rowPeriodCount,
            this.rowMachineOrProcess,
            this.rowArithmeticOperatorID,
            this.rowWorkerCount,
            this.rowRowGUID,
            this.rowStatus,
            this.rowLineNumber});
            this.vGrdStockProcessRelation.Size = new System.Drawing.Size(1305, 268);
            this.vGrdStockProcessRelation.TabIndex = 0;
            // 
            // lookStock
            // 
            this.lookStock.AutoHeight = false;
            this.lookStock.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStock.Name = "lookStock";
            this.lookStock.NullText = "Mamül Seçiniz";
            // 
            // lookProcess
            // 
            this.lookProcess.AutoHeight = false;
            this.lookProcess.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookProcess.DisplayMember = "Name";
            this.lookProcess.Name = "lookProcess";
            this.lookProcess.NullText = "Proses Seçiniz";
            this.lookProcess.ValueMember = "ProcessID";
            // 
            // lookMachine
            // 
            this.lookMachine.AutoHeight = false;
            this.lookMachine.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookMachine.DisplayMember = "Name";
            this.lookMachine.Name = "lookMachine";
            this.lookMachine.NullText = "Makine Seçiniz";
            this.lookMachine.ValueMember = "MachineID";
            // 
            // lookStatus
            // 
            this.lookStatus.AutoHeight = false;
            this.lookStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.DisplayMember = "Name";
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.NullText = "Durum Seçiniz";
            this.lookStatus.ValueMember = "Code";
            // 
            // spinEditTurnOver
            // 
            this.spinEditTurnOver.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditTurnOver.Name = "spinEditTurnOver";
            this.spinEditTurnOver.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditTurnOver_Validating);
            // 
            // spinEditEfficiency
            // 
            this.spinEditEfficiency.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditEfficiency.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditEfficiency.Name = "spinEditEfficiency";
            // 
            // spinEditWastage
            // 
            this.spinEditWastage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditWastage.Name = "spinEditWastage";
            this.spinEditWastage.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditWastage_Validating);
            // 
            // spinEditAmount
            // 
            this.spinEditAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditAmount.Name = "spinEditAmount";
            // 
            // spinEditPeriodCount
            // 
            this.spinEditPeriodCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditPeriodCount.Name = "spinEditPeriodCount";
            this.spinEditPeriodCount.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditPeriodCount_Validating);
            // 
            // lookArithmeticOperatorID
            // 
            this.lookArithmeticOperatorID.AutoHeight = false;
            this.lookArithmeticOperatorID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookArithmeticOperatorID.DisplayMember = "Code";
            this.lookArithmeticOperatorID.Name = "lookArithmeticOperatorID";
            this.lookArithmeticOperatorID.NullText = "İşlem Operatörü Seçiniz";
            this.lookArithmeticOperatorID.ValueMember = "TableStatusID";
            // 
            // spinEditWorkerCount
            // 
            this.spinEditWorkerCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditWorkerCount.Name = "spinEditWorkerCount";
            this.spinEditWorkerCount.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditWorkerCount_Validating);
            // 
            // toggleMachineOrProcess
            // 
            this.toggleMachineOrProcess.Name = "toggleMachineOrProcess";
            this.toggleMachineOrProcess.OffText = "Makine Bazlı";
            this.toggleMachineOrProcess.OnText = "Proses Bazlı";
            // 
            // spinEditLineNumber
            // 
            this.spinEditLineNumber.AutoHeight = false;
            this.spinEditLineNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditLineNumber.Name = "spinEditLineNumber";
            this.spinEditLineNumber.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditLineNumber_Validating);
            // 
            // rowStockProcessRelationID
            // 
            this.rowStockProcessRelationID.Name = "rowStockProcessRelationID";
            this.rowStockProcessRelationID.Properties.Caption = "StockProcessRelationID";
            this.rowStockProcessRelationID.Properties.FieldName = "StockProcessRelationID";
            this.rowStockProcessRelationID.Visible = false;
            // 
            // rowStockGroupID
            // 
            this.rowStockGroupID.Name = "rowStockGroupID";
            this.rowStockGroupID.Properties.Caption = "Mamül Grubu";
            this.rowStockGroupID.Properties.FieldName = "StockGroupID";
            this.rowStockGroupID.Properties.RowEdit = this.lookStock;
            // 
            // rowProcessID
            // 
            this.rowProcessID.Name = "rowProcessID";
            this.rowProcessID.Properties.Caption = "Proses";
            this.rowProcessID.Properties.FieldName = "ProcessID";
            this.rowProcessID.Properties.RowEdit = this.lookProcess;
            // 
            // rowMachineID
            // 
            this.rowMachineID.Name = "rowMachineID";
            this.rowMachineID.Properties.Caption = "Makine";
            this.rowMachineID.Properties.FieldName = "MachineID";
            this.rowMachineID.Properties.RowEdit = this.lookMachine;
            // 
            // rowTurnOver
            // 
            this.rowTurnOver.AppearanceCell.Options.UseTextOptions = true;
            this.rowTurnOver.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowTurnOver.Name = "rowTurnOver";
            this.rowTurnOver.Properties.Caption = "Devir Hızı";
            this.rowTurnOver.Properties.FieldName = "TurnOver";
            this.rowTurnOver.Properties.RowEdit = this.spinEditTurnOver;
            // 
            // rowEfficiency
            // 
            this.rowEfficiency.AppearanceCell.Options.UseTextOptions = true;
            this.rowEfficiency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowEfficiency.Name = "rowEfficiency";
            this.rowEfficiency.Properties.Caption = "Randıman(%)";
            this.rowEfficiency.Properties.FieldName = "Efficiency";
            this.rowEfficiency.Properties.RowEdit = this.spinEditEfficiency;
            // 
            // rowWastage
            // 
            this.rowWastage.AppearanceCell.Options.UseTextOptions = true;
            this.rowWastage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowWastage.Name = "rowWastage";
            this.rowWastage.Properties.Caption = "Fire";
            this.rowWastage.Properties.FieldName = "Wastage";
            this.rowWastage.Properties.RowEdit = this.spinEditWastage;
            // 
            // rowAmount
            // 
            this.rowAmount.AppearanceCell.Options.UseTextOptions = true;
            this.rowAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowAmount.Name = "rowAmount";
            this.rowAmount.Properties.Caption = "Miktar";
            this.rowAmount.Properties.FieldName = "Amount";
            this.rowAmount.Properties.RowEdit = this.spinEditAmount;
            // 
            // rowPeriodCount
            // 
            this.rowPeriodCount.AppearanceCell.Options.UseTextOptions = true;
            this.rowPeriodCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowPeriodCount.Name = "rowPeriodCount";
            this.rowPeriodCount.Properties.Caption = "Periyot Sayısı";
            this.rowPeriodCount.Properties.FieldName = "PeriodCount";
            this.rowPeriodCount.Properties.RowEdit = this.spinEditPeriodCount;
            // 
            // rowMachineOrProcess
            // 
            this.rowMachineOrProcess.Name = "rowMachineOrProcess";
            this.rowMachineOrProcess.Properties.Caption = "Makine Bazlı / Proses Bazlı";
            this.rowMachineOrProcess.Properties.FieldName = "MachineOrProcess";
            this.rowMachineOrProcess.Properties.RowEdit = this.toggleMachineOrProcess;
            // 
            // rowArithmeticOperatorID
            // 
            this.rowArithmeticOperatorID.Name = "rowArithmeticOperatorID";
            this.rowArithmeticOperatorID.Properties.Caption = "İşlem Operatörü";
            this.rowArithmeticOperatorID.Properties.FieldName = "ArithmeticOperatorID";
            this.rowArithmeticOperatorID.Properties.RowEdit = this.lookArithmeticOperatorID;
            // 
            // rowWorkerCount
            // 
            this.rowWorkerCount.AppearanceCell.Options.UseTextOptions = true;
            this.rowWorkerCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowWorkerCount.Name = "rowWorkerCount";
            this.rowWorkerCount.Properties.Caption = "İşçi Sayısı";
            this.rowWorkerCount.Properties.FieldName = "WorkerCount";
            this.rowWorkerCount.Properties.RowEdit = this.spinEditWorkerCount;
            // 
            // rowRowGUID
            // 
            this.rowRowGUID.Name = "rowRowGUID";
            this.rowRowGUID.Properties.Caption = "rowRowGUID";
            this.rowRowGUID.Properties.FieldName = "RowGUID";
            this.rowRowGUID.Visible = false;
            // 
            // rowStatus
            // 
            this.rowStatus.Name = "rowStatus";
            this.rowStatus.Properties.Caption = "Durum";
            this.rowStatus.Properties.FieldName = "Status";
            this.rowStatus.Properties.RowEdit = this.lookStatus;
            // 
            // rowLineNumber
            // 
            this.rowLineNumber.AppearanceCell.Options.UseTextOptions = true;
            this.rowLineNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowLineNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.rowLineNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowLineNumber.Name = "rowLineNumber";
            this.rowLineNumber.Properties.Caption = "Sıra No";
            this.rowLineNumber.Properties.FieldName = "LineNumber";
            this.rowLineNumber.Properties.RowEdit = this.spinEditLineNumber;
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
            this.barDockControlTop.Size = new System.Drawing.Size(1305, 23);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 720);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1305, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 23);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 697);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1305, 23);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 697);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnChangeStatus);
            this.popupMenu.ItemLinks.Add(this.btnEditRecords);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbon;
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // StockProcessRelationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 720);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StockProcessRelationForm";
            this.Ribbon = this.ribbon;
            this.Text = "Mamül - Proses - Makine Kapasite Tanımı";
            this.Load += new System.EventHandler(this.StockProcessRelationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockProcessRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockProcessRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdTurnOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdEfficiency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdWastage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdPeriodCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdArithmeticOperatorID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdWorkerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdLineNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGrdStockProcessRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTurnOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditEfficiency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWastage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPeriodCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookArithmeticOperatorID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWorkerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleMachineOrProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLineNumber)).EndInit();
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
        private DevExpress.XtraVerticalGrid.VGridControl vGrdStockProcessRelation;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStock;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStockProcessRelationID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRowGUID;
        private DevExpress.XtraGrid.GridControl grdStockProcessRelation;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStockProcessRelation;
        private DevExpress.XtraGrid.Columns.GridColumn colStockProcessRelationID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStockGroupID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStockGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookProcess;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProcessID;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdProcess;
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
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStockGroupID;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdMachine;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookMachine;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMachineID;
        private DevExpress.XtraGrid.Columns.GridColumn colTurnOver;
        private DevExpress.XtraGrid.Columns.GridColumn colEfficiency;
        private DevExpress.XtraGrid.Columns.GridColumn colWastage;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodCount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTurnOver;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowEfficiency;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowWastage;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowAmount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPeriodCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditTurnOver;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditEfficiency;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditWastage;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditPeriodCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookArithmeticOperatorID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditWorkerCount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMachineOrProcess;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowArithmeticOperatorID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowWorkerCount;
        private DevExpress.XtraGrid.Columns.GridColumn colArithmeticOperatorID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdArithmeticOperatorID;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch toggleMachineOrProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineOrProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colMacPro;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkerCount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdTurnOver;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdEfficiency;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdWastage;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdPeriodCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdWorkerCount;
        private DevExpress.XtraGrid.Columns.GridColumn colLineNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdLineNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowLineNumber;
        private DevExpress.XtraBars.BarButtonItem btnEditRecords;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditLineNumber;
    }
}