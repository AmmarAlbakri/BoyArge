namespace BoyArge
{
    partial class ReceiptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.seperator1 = new DevExpress.XtraBars.BarHeaderItem();
            this.toggleSwitch = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnChangeStatus = new DevExpress.XtraBars.BarButtonItem();
            this.btnCalculate = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.grdReceipt = new DevExpress.XtraGrid.GridControl();
            this.grvReceipt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReceiptID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colGrdStockGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStockGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStockCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProcessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdMachine = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colFicheNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiptNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerialNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiptAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colOrderAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdOrderAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colFlotte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdFlotte = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colConicTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdConicType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colConicAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditConicGrdAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colColorType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdColorType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTouchness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdTouchness = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colFeature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdFeature = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMinDyeCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinMinDyeCapacity = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colMaxDyeCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinMaxDyeCapacity = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdCode3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.vGrdReceipt = new DevExpress.XtraVerticalGrid.VGridControl();
            this.lookStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookStockCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookMachineID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditFlotte = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditConicAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lookConicTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditOrderAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lookStockGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookColorType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditMinDyeCapacity = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditMaxDyeCapacity = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lookTouchness = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookFeature = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookProcessID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowReceiptID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowRowGUID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowFicheNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStockGroupID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStockCode = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowProcessID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMachineID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowReceiptNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSerialNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowAmount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowOrderAmount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowFlotte = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowConicAmount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowConicTypeID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowColorType = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTouchness = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowFeature = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMinDyeCapacity = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMaxDyeCapacity = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.grdReceiptLine = new DevExpress.XtraGrid.GridControl();
            this.grvReceiptLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReceiptLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrdLineReceiptID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrdLineStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookLineStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colGrdLineNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineOperationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookOperationCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLineChemicalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookChemicalCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLineCalculateType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookCalculateType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLineChemicalType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookChemicalType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLineUnitAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrdLineAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineExchangeTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookExchangeTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLineNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrdLineRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUnitPrice = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdOrderAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdFlotte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdConicType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditConicGrdAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdColorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdTouchness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinDyeCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMaxDyeCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditFlotte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditConicAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookConicTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditOrderAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookColorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMinDyeCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMaxDyeCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookTouchness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProcessID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceiptLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReceiptLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLineStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookOperationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChemicalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCalculateType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChemicalType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookExchangeTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
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
            this.btnCalculate});
            this.ribbon.Location = new System.Drawing.Point(0, 21);
            this.ribbon.MaxItemId = 11;
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
            // btnCalculate
            // 
            this.btnCalculate.Caption = "Hesapla";
            this.btnCalculate.Id = 10;
            this.btnCalculate.ImageOptions.SvgImage = global::BoyArge.Properties.Resources.calculatenow;
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnCalculate_ItemClick);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCalculate);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.seperator1);
            this.ribbonPageGroup1.ItemLinks.Add(this.toggleSwitch);
            this.ribbonPageGroup1.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // grdReceipt
            // 
            this.grdReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReceipt.Location = new System.Drawing.Point(0, 0);
            this.grdReceipt.MainView = this.grvReceipt;
            this.grdReceipt.Name = "grdReceipt";
            this.grdReceipt.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookGrdStockCode,
            this.lookGrdStatus,
            this.lookGrdConicType,
            this.lookGrdMachine,
            this.spinEditGrdAmount,
            this.spinEditGrdFlotte,
            this.spinEditConicGrdAmount,
            this.spinEditGrdOrderAmount,
            this.lookGrdStockGroup,
            this.lookGrdColorType,
            this.spinMinDyeCapacity,
            this.spinMaxDyeCapacity,
            this.lookGrdTouchness,
            this.lookGrdFeature});
            this.grdReceipt.Size = new System.Drawing.Size(602, 168);
            this.grdReceipt.TabIndex = 0;
            this.grdReceipt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReceipt});
            // 
            // grvReceipt
            // 
            this.grvReceipt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReceiptID,
            this.colStatus,
            this.colGrdStockGroup,
            this.colStockCode,
            this.colProcessID,
            this.colMachine,
            this.colFicheNumber,
            this.colReceiptNumber,
            this.colSerialNumber,
            this.colReceiptAmount,
            this.colOrderAmount,
            this.colFlotte,
            this.colConicTypeID,
            this.colConicAmount,
            this.colColorType,
            this.colTouchness,
            this.colFeature,
            this.colMinDyeCapacity,
            this.colMaxDyeCapacity,
            this.colRowGUID});
            this.grvReceipt.GridControl = this.grdReceipt;
            this.grvReceipt.Name = "grvReceipt";
            this.grvReceipt.OptionsBehavior.Editable = false;
            this.grvReceipt.OptionsView.ShowAutoFilterRow = true;
            this.grvReceipt.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GrvReceipt_PopupMenuShowing);
            this.grvReceipt.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrvReceipt_FocusedRowChanged);
            // 
            // colReceiptID
            // 
            this.colReceiptID.Caption = "ReceiptID";
            this.colReceiptID.FieldName = "ReceiptID";
            this.colReceiptID.Name = "colReceiptID";
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
            // colGrdStockGroup
            // 
            this.colGrdStockGroup.Caption = "Malzeme Grubu";
            this.colGrdStockGroup.ColumnEdit = this.lookGrdStockGroup;
            this.colGrdStockGroup.FieldName = "StockGroupID";
            this.colGrdStockGroup.Name = "colGrdStockGroup";
            this.colGrdStockGroup.Visible = true;
            this.colGrdStockGroup.VisibleIndex = 1;
            // 
            // lookGrdStockGroup
            // 
            this.lookGrdStockGroup.AutoHeight = false;
            this.lookGrdStockGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStockGroup.DisplayMember = "Name";
            this.lookGrdStockGroup.Name = "lookGrdStockGroup";
            this.lookGrdStockGroup.ValueMember = "StockGroupID";
            // 
            // colStockCode
            // 
            this.colStockCode.Caption = "Malzeme";
            this.colStockCode.ColumnEdit = this.lookGrdStockCode;
            this.colStockCode.FieldName = "StockCode";
            this.colStockCode.Name = "colStockCode";
            this.colStockCode.Visible = true;
            this.colStockCode.VisibleIndex = 2;
            // 
            // lookGrdStockCode
            // 
            this.lookGrdStockCode.AutoHeight = false;
            this.lookGrdStockCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStockCode.DisplayMember = "Name";
            this.lookGrdStockCode.Name = "lookGrdStockCode";
            this.lookGrdStockCode.ValueMember = "Code";
            // 
            // colProcessID
            // 
            this.colProcessID.Caption = "ProcessID";
            this.colProcessID.FieldName = "ProcessID";
            this.colProcessID.Name = "colProcessID";
            this.colProcessID.Visible = true;
            this.colProcessID.VisibleIndex = 4;
            // 
            // colMachine
            // 
            this.colMachine.Caption = "Makine";
            this.colMachine.ColumnEdit = this.lookGrdMachine;
            this.colMachine.FieldName = "MachineID";
            this.colMachine.Name = "colMachine";
            this.colMachine.Visible = true;
            this.colMachine.VisibleIndex = 5;
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
            // colFicheNumber
            // 
            this.colFicheNumber.Caption = "Fiş No (Arge)";
            this.colFicheNumber.FieldName = "FicheNumber";
            this.colFicheNumber.Name = "colFicheNumber";
            this.colFicheNumber.Visible = true;
            this.colFicheNumber.VisibleIndex = 6;
            // 
            // colReceiptNumber
            // 
            this.colReceiptNumber.Caption = "Reçete No";
            this.colReceiptNumber.FieldName = "ReceiptNumber";
            this.colReceiptNumber.Name = "colReceiptNumber";
            this.colReceiptNumber.Visible = true;
            this.colReceiptNumber.VisibleIndex = 7;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.Caption = "Seri No";
            this.colSerialNumber.FieldName = "SerialNumber";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.Visible = true;
            this.colSerialNumber.VisibleIndex = 8;
            // 
            // colReceiptAmount
            // 
            this.colReceiptAmount.Caption = "Miktar";
            this.colReceiptAmount.ColumnEdit = this.spinEditGrdAmount;
            this.colReceiptAmount.FieldName = "Amount";
            this.colReceiptAmount.Name = "colReceiptAmount";
            this.colReceiptAmount.Visible = true;
            this.colReceiptAmount.VisibleIndex = 9;
            // 
            // spinEditGrdAmount
            // 
            this.spinEditGrdAmount.Appearance.Options.UseTextOptions = true;
            this.spinEditGrdAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditGrdAmount.AutoHeight = false;
            this.spinEditGrdAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdAmount.Name = "spinEditGrdAmount";
            // 
            // colOrderAmount
            // 
            this.colOrderAmount.Caption = "Sip.Miktarı";
            this.colOrderAmount.ColumnEdit = this.spinEditGrdOrderAmount;
            this.colOrderAmount.FieldName = "OrderAmount";
            this.colOrderAmount.Name = "colOrderAmount";
            this.colOrderAmount.Visible = true;
            this.colOrderAmount.VisibleIndex = 12;
            // 
            // spinEditGrdOrderAmount
            // 
            this.spinEditGrdOrderAmount.AutoHeight = false;
            this.spinEditGrdOrderAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdOrderAmount.Name = "spinEditGrdOrderAmount";
            // 
            // colFlotte
            // 
            this.colFlotte.Caption = "Flotte";
            this.colFlotte.ColumnEdit = this.spinEditGrdFlotte;
            this.colFlotte.FieldName = "Flotte";
            this.colFlotte.Name = "colFlotte";
            this.colFlotte.Visible = true;
            this.colFlotte.VisibleIndex = 10;
            // 
            // spinEditGrdFlotte
            // 
            this.spinEditGrdFlotte.Appearance.Options.UseTextOptions = true;
            this.spinEditGrdFlotte.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditGrdFlotte.AutoHeight = false;
            this.spinEditGrdFlotte.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdFlotte.Name = "spinEditGrdFlotte";
            // 
            // colConicTypeID
            // 
            this.colConicTypeID.Caption = "Konik Türü";
            this.colConicTypeID.ColumnEdit = this.lookGrdConicType;
            this.colConicTypeID.FieldName = "ConicTypeID";
            this.colConicTypeID.Name = "colConicTypeID";
            this.colConicTypeID.Visible = true;
            this.colConicTypeID.VisibleIndex = 3;
            // 
            // lookGrdConicType
            // 
            this.lookGrdConicType.AutoHeight = false;
            this.lookGrdConicType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdConicType.DisplayMember = "Name";
            this.lookGrdConicType.Name = "lookGrdConicType";
            this.lookGrdConicType.ValueMember = "ConicTypeID";
            // 
            // colConicAmount
            // 
            this.colConicAmount.Caption = "Konik Gramaj";
            this.colConicAmount.ColumnEdit = this.spinEditConicGrdAmount;
            this.colConicAmount.FieldName = "ConicAmount";
            this.colConicAmount.Name = "colConicAmount";
            this.colConicAmount.Visible = true;
            this.colConicAmount.VisibleIndex = 11;
            // 
            // spinEditConicGrdAmount
            // 
            this.spinEditConicGrdAmount.Appearance.Options.UseTextOptions = true;
            this.spinEditConicGrdAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditConicGrdAmount.AutoHeight = false;
            this.spinEditConicGrdAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditConicGrdAmount.Name = "spinEditConicGrdAmount";
            // 
            // colColorType
            // 
            this.colColorType.Caption = "Renk Türü";
            this.colColorType.ColumnEdit = this.lookGrdColorType;
            this.colColorType.FieldName = "ColorType";
            this.colColorType.Name = "colColorType";
            this.colColorType.Visible = true;
            this.colColorType.VisibleIndex = 13;
            // 
            // lookGrdColorType
            // 
            this.lookGrdColorType.AutoHeight = false;
            this.lookGrdColorType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdColorType.DisplayMember = "Code";
            this.lookGrdColorType.Name = "lookGrdColorType";
            this.lookGrdColorType.ValueMember = "ColorType";
            // 
            // colTouchness
            // 
            this.colTouchness.Caption = "Tuşe";
            this.colTouchness.ColumnEdit = this.lookGrdTouchness;
            this.colTouchness.FieldName = "Touchness";
            this.colTouchness.Name = "colTouchness";
            this.colTouchness.Visible = true;
            this.colTouchness.VisibleIndex = 14;
            // 
            // lookGrdTouchness
            // 
            this.lookGrdTouchness.AutoHeight = false;
            this.lookGrdTouchness.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdTouchness.DisplayMember = "Definition";
            this.lookGrdTouchness.Name = "lookGrdTouchness";
            this.lookGrdTouchness.ValueMember = "ParameterID";
            // 
            // colFeature
            // 
            this.colFeature.Caption = "Özellik";
            this.colFeature.ColumnEdit = this.lookGrdFeature;
            this.colFeature.FieldName = "Feature";
            this.colFeature.Name = "colFeature";
            this.colFeature.Visible = true;
            this.colFeature.VisibleIndex = 17;
            // 
            // lookGrdFeature
            // 
            this.lookGrdFeature.AutoHeight = false;
            this.lookGrdFeature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdFeature.DisplayMember = "Definition";
            this.lookGrdFeature.Name = "lookGrdFeature";
            this.lookGrdFeature.ValueMember = "ParameterID";
            // 
            // colMinDyeCapacity
            // 
            this.colMinDyeCapacity.Caption = "Min.Boy.Kap.";
            this.colMinDyeCapacity.ColumnEdit = this.spinMinDyeCapacity;
            this.colMinDyeCapacity.FieldName = "MinDyeCapacity";
            this.colMinDyeCapacity.Name = "colMinDyeCapacity";
            this.colMinDyeCapacity.Visible = true;
            this.colMinDyeCapacity.VisibleIndex = 15;
            // 
            // spinMinDyeCapacity
            // 
            this.spinMinDyeCapacity.AutoHeight = false;
            this.spinMinDyeCapacity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinMinDyeCapacity.Name = "spinMinDyeCapacity";
            // 
            // colMaxDyeCapacity
            // 
            this.colMaxDyeCapacity.Caption = "Maks.Boy.Kap.";
            this.colMaxDyeCapacity.ColumnEdit = this.spinMaxDyeCapacity;
            this.colMaxDyeCapacity.FieldName = "MaxDyeCapacity";
            this.colMaxDyeCapacity.Name = "colMaxDyeCapacity";
            this.colMaxDyeCapacity.Visible = true;
            this.colMaxDyeCapacity.VisibleIndex = 16;
            // 
            // spinMaxDyeCapacity
            // 
            this.spinMaxDyeCapacity.AutoHeight = false;
            this.spinMaxDyeCapacity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinMaxDyeCapacity.Name = "spinMaxDyeCapacity";
            // 
            // colRowGUID
            // 
            this.colRowGUID.Caption = "rowGUID";
            this.colRowGUID.FieldName = "RowGUID";
            this.colRowGUID.Name = "colRowGUID";
            // 
            // spinEditGrdCode3
            // 
            this.spinEditGrdCode3.AutoHeight = false;
            this.spinEditGrdCode3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdCode3.Name = "spinEditGrdCode3";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.vGrdReceipt);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdReceipt);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(602, 399);
            this.splitContainerControl1.SplitterPosition = 221;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // vGrdReceipt
            // 
            this.vGrdReceipt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrdReceipt.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGrdReceipt.CustomizationFormBounds = new System.Drawing.Rectangle(457, 176, 214, 258);
            this.vGrdReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrdReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGrdReceipt.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGrdReceipt.Location = new System.Drawing.Point(0, 0);
            this.vGrdReceipt.Name = "vGrdReceipt";
            this.vGrdReceipt.RecordWidth = 158;
            this.vGrdReceipt.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookStatus,
            this.lookStockCode,
            this.lookMachineID,
            this.spinEditAmount,
            this.spinEditFlotte,
            this.spinEditConicAmount,
            this.lookConicTypeID,
            this.spinEditOrderAmount,
            this.lookStockGroup,
            this.lookColorType,
            this.spinEditMinDyeCapacity,
            this.spinEditMaxDyeCapacity,
            this.lookTouchness,
            this.lookFeature,
            this.lookProcessID});
            this.vGrdReceipt.RowHeaderWidth = 42;
            this.vGrdReceipt.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowReceiptID,
            this.rowStatus,
            this.rowRowGUID,
            this.rowFicheNumber,
            this.rowStockGroupID,
            this.rowStockCode,
            this.rowProcessID,
            this.rowMachineID,
            this.rowReceiptNumber,
            this.rowSerialNumber,
            this.rowAmount,
            this.rowOrderAmount,
            this.rowFlotte,
            this.rowConicAmount,
            this.rowConicTypeID,
            this.rowColorType,
            this.rowTouchness,
            this.rowFeature,
            this.rowMinDyeCapacity,
            this.rowMaxDyeCapacity});
            this.vGrdReceipt.Size = new System.Drawing.Size(602, 221);
            this.vGrdReceipt.TabIndex = 0;
            // 
            // lookStatus
            // 
            this.lookStatus.AutoHeight = false;
            this.lookStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.NullText = "Durum Seçiniz";
            // 
            // lookStockCode
            // 
            this.lookStockCode.AutoHeight = false;
            this.lookStockCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStockCode.DisplayMember = "Name";
            this.lookStockCode.Name = "lookStockCode";
            this.lookStockCode.ValueMember = "Code";
            // 
            // lookMachineID
            // 
            this.lookMachineID.AutoHeight = false;
            this.lookMachineID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookMachineID.DisplayMember = "Name";
            this.lookMachineID.Name = "lookMachineID";
            this.lookMachineID.ValueMember = "MachineID";
            // 
            // spinEditAmount
            // 
            this.spinEditAmount.Appearance.Options.UseTextOptions = true;
            this.spinEditAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditAmount.AutoHeight = false;
            this.spinEditAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditAmount.Name = "spinEditAmount";
            this.spinEditAmount.Validating += new System.ComponentModel.CancelEventHandler(this.SpinEditAmount_Validating);
            // 
            // spinEditFlotte
            // 
            this.spinEditFlotte.Appearance.Options.UseTextOptions = true;
            this.spinEditFlotte.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditFlotte.AutoHeight = false;
            this.spinEditFlotte.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditFlotte.Name = "spinEditFlotte";
            this.spinEditFlotte.Validating += new System.ComponentModel.CancelEventHandler(this.SpinEditFlotte_Validating);
            // 
            // spinEditConicAmount
            // 
            this.spinEditConicAmount.Appearance.Options.UseTextOptions = true;
            this.spinEditConicAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditConicAmount.AutoHeight = false;
            this.spinEditConicAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditConicAmount.Name = "spinEditConicAmount";
            this.spinEditConicAmount.Validating += new System.ComponentModel.CancelEventHandler(this.SpinEditConicAmount_Validating);
            // 
            // lookConicTypeID
            // 
            this.lookConicTypeID.AutoHeight = false;
            this.lookConicTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookConicTypeID.DisplayMember = "Name";
            this.lookConicTypeID.Name = "lookConicTypeID";
            this.lookConicTypeID.ValueMember = "ConicTypeID";
            // 
            // spinEditOrderAmount
            // 
            this.spinEditOrderAmount.Appearance.Options.UseTextOptions = true;
            this.spinEditOrderAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditOrderAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditOrderAmount.Name = "spinEditOrderAmount";
            this.spinEditOrderAmount.Validating += new System.ComponentModel.CancelEventHandler(this.SpinEditOrderAmount_Validating);
            // 
            // lookStockGroup
            // 
            this.lookStockGroup.AutoHeight = false;
            this.lookStockGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStockGroup.DisplayMember = "Name";
            this.lookStockGroup.Name = "lookStockGroup";
            this.lookStockGroup.ValueMember = "StockGroupID";
            // 
            // lookColorType
            // 
            this.lookColorType.AutoHeight = false;
            this.lookColorType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookColorType.DisplayMember = "Code";
            this.lookColorType.Name = "lookColorType";
            this.lookColorType.ValueMember = "ColorType";
            // 
            // spinEditMinDyeCapacity
            // 
            this.spinEditMinDyeCapacity.Appearance.Options.UseTextOptions = true;
            this.spinEditMinDyeCapacity.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditMinDyeCapacity.AutoHeight = false;
            this.spinEditMinDyeCapacity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditMinDyeCapacity.Name = "spinEditMinDyeCapacity";
            this.spinEditMinDyeCapacity.Validating += new System.ComponentModel.CancelEventHandler(this.SpinEditMinDyeCapacity_Validating);
            // 
            // spinEditMaxDyeCapacity
            // 
            this.spinEditMaxDyeCapacity.Appearance.Options.UseTextOptions = true;
            this.spinEditMaxDyeCapacity.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditMaxDyeCapacity.AutoHeight = false;
            this.spinEditMaxDyeCapacity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditMaxDyeCapacity.Name = "spinEditMaxDyeCapacity";
            this.spinEditMaxDyeCapacity.Validating += new System.ComponentModel.CancelEventHandler(this.SpinEditMaxDyeCapacity_Validating);
            // 
            // lookTouchness
            // 
            this.lookTouchness.AutoHeight = false;
            this.lookTouchness.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookTouchness.DisplayMember = "Definition";
            this.lookTouchness.Name = "lookTouchness";
            this.lookTouchness.ValueMember = "ParameterID";
            // 
            // lookFeature
            // 
            this.lookFeature.AutoHeight = false;
            this.lookFeature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookFeature.DisplayMember = "Definition";
            this.lookFeature.Name = "lookFeature";
            this.lookFeature.ValueMember = "ParameterID";
            // 
            // lookProcessID
            // 
            this.lookProcessID.AutoHeight = false;
            this.lookProcessID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookProcessID.Name = "lookProcessID";
            // 
            // rowReceiptID
            // 
            this.rowReceiptID.Name = "rowReceiptID";
            this.rowReceiptID.Properties.Caption = "ReceiptID";
            this.rowReceiptID.Properties.FieldName = "ReceiptID";
            this.rowReceiptID.Visible = false;
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
            // rowFicheNumber
            // 
            this.rowFicheNumber.Name = "rowFicheNumber";
            this.rowFicheNumber.Properties.Caption = "Fiş No";
            this.rowFicheNumber.Properties.FieldName = "FicheNumber";
            // 
            // rowStockGroupID
            // 
            this.rowStockGroupID.Name = "rowStockGroupID";
            this.rowStockGroupID.Properties.Caption = "Malzeme Grubu";
            this.rowStockGroupID.Properties.FieldName = "StockGroupID";
            this.rowStockGroupID.Properties.RowEdit = this.lookStockGroup;
            // 
            // rowStockCode
            // 
            this.rowStockCode.Name = "rowStockCode";
            this.rowStockCode.Properties.Caption = "Malzeme";
            this.rowStockCode.Properties.FieldName = "StockCode";
            this.rowStockCode.Properties.RowEdit = this.lookStockCode;
            // 
            // rowProcessID
            // 
            this.rowProcessID.Name = "rowProcessID";
            this.rowProcessID.Properties.Caption = "ProcessID";
            this.rowProcessID.Properties.RowEdit = this.lookProcessID;
            // 
            // rowMachineID
            // 
            this.rowMachineID.Name = "rowMachineID";
            this.rowMachineID.Properties.Caption = "Makine";
            this.rowMachineID.Properties.FieldName = "MachineID";
            this.rowMachineID.Properties.RowEdit = this.lookMachineID;
            // 
            // rowReceiptNumber
            // 
            this.rowReceiptNumber.Name = "rowReceiptNumber";
            this.rowReceiptNumber.Properties.Caption = "Reçete No";
            this.rowReceiptNumber.Properties.FieldName = "ReceiptNumber";
            // 
            // rowSerialNumber
            // 
            this.rowSerialNumber.Name = "rowSerialNumber";
            this.rowSerialNumber.Properties.Caption = "Seri No";
            this.rowSerialNumber.Properties.FieldName = "SerialNumber";
            // 
            // rowAmount
            // 
            this.rowAmount.AppearanceCell.Options.UseTextOptions = true;
            this.rowAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.rowAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowAmount.Name = "rowAmount";
            this.rowAmount.Properties.Caption = "Miktar";
            this.rowAmount.Properties.FieldName = "Amount";
            this.rowAmount.Properties.RowEdit = this.spinEditAmount;
            // 
            // rowOrderAmount
            // 
            this.rowOrderAmount.AppearanceCell.Options.UseTextOptions = true;
            this.rowOrderAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowOrderAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.rowOrderAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowOrderAmount.Name = "rowOrderAmount";
            this.rowOrderAmount.Properties.Caption = "Sip.Miktarı";
            this.rowOrderAmount.Properties.FieldName = "OrderAmount";
            this.rowOrderAmount.Properties.RowEdit = this.spinEditOrderAmount;
            // 
            // rowFlotte
            // 
            this.rowFlotte.AppearanceCell.Options.UseTextOptions = true;
            this.rowFlotte.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowFlotte.Name = "rowFlotte";
            this.rowFlotte.Properties.Caption = "Flotte";
            this.rowFlotte.Properties.FieldName = "Flotte";
            this.rowFlotte.Properties.RowEdit = this.spinEditFlotte;
            // 
            // rowConicAmount
            // 
            this.rowConicAmount.AppearanceCell.Options.UseTextOptions = true;
            this.rowConicAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowConicAmount.Name = "rowConicAmount";
            this.rowConicAmount.Properties.Caption = "Konik Gramaj";
            this.rowConicAmount.Properties.FieldName = "ConicAmount";
            this.rowConicAmount.Properties.RowEdit = this.spinEditConicAmount;
            // 
            // rowConicTypeID
            // 
            this.rowConicTypeID.Name = "rowConicTypeID";
            this.rowConicTypeID.Properties.Caption = "Konik Türü";
            this.rowConicTypeID.Properties.FieldName = "ConicTypeID";
            this.rowConicTypeID.Properties.RowEdit = this.lookConicTypeID;
            // 
            // rowColorType
            // 
            this.rowColorType.Name = "rowColorType";
            this.rowColorType.Properties.Caption = "Renk Türü";
            this.rowColorType.Properties.FieldName = "ColorType";
            this.rowColorType.Properties.RowEdit = this.lookColorType;
            // 
            // rowTouchness
            // 
            this.rowTouchness.Name = "rowTouchness";
            this.rowTouchness.Properties.Caption = "Tuşe";
            this.rowTouchness.Properties.FieldName = "Touchness";
            this.rowTouchness.Properties.RowEdit = this.lookTouchness;
            // 
            // rowFeature
            // 
            this.rowFeature.Name = "rowFeature";
            this.rowFeature.Properties.Caption = "Özellik";
            this.rowFeature.Properties.FieldName = "Feature";
            this.rowFeature.Properties.RowEdit = this.lookFeature;
            // 
            // rowMinDyeCapacity
            // 
            this.rowMinDyeCapacity.AppearanceCell.Options.UseTextOptions = true;
            this.rowMinDyeCapacity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowMinDyeCapacity.Name = "rowMinDyeCapacity";
            this.rowMinDyeCapacity.Properties.Caption = "Min.Boy.Kap.";
            this.rowMinDyeCapacity.Properties.FieldName = "MinDyeCapacity";
            this.rowMinDyeCapacity.Properties.RowEdit = this.spinEditMinDyeCapacity;
            // 
            // rowMaxDyeCapacity
            // 
            this.rowMaxDyeCapacity.AppearanceCell.Options.UseTextOptions = true;
            this.rowMaxDyeCapacity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowMaxDyeCapacity.Name = "rowMaxDyeCapacity";
            this.rowMaxDyeCapacity.Properties.Caption = "Maks.Boy.Kap.";
            this.rowMaxDyeCapacity.Properties.FieldName = "MaxDyeCapacity";
            this.rowMaxDyeCapacity.Properties.RowEdit = this.spinEditMaxDyeCapacity;
            // 
            // grdReceiptLine
            // 
            this.grdReceiptLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReceiptLine.Location = new System.Drawing.Point(0, 0);
            this.grdReceiptLine.MainView = this.grvReceiptLine;
            this.grdReceiptLine.MenuManager = this.ribbon;
            this.grdReceiptLine.Name = "grdReceiptLine";
            this.grdReceiptLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookExchangeTypeID,
            this.lookOperationCode,
            this.lookChemicalCode,
            this.lookCalculateType,
            this.lookChemicalType,
            this.lookLineStatus,
            this.lookUnitPrice});
            this.grdReceiptLine.Size = new System.Drawing.Size(602, 189);
            this.grdReceiptLine.TabIndex = 1;
            this.grdReceiptLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReceiptLine});
            // 
            // grvReceiptLine
            // 
            this.grvReceiptLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReceiptLineID,
            this.colGrdLineReceiptID,
            this.colGrdLineStatus,
            this.colGrdLineNumber,
            this.colLineOperationCode,
            this.colLineChemicalCode,
            this.colLineCalculateType,
            this.colLineChemicalType,
            this.colLineUnitAmount,
            this.colLineTotalAmount,
            this.colGrdLineAmount,
            this.colLinePrice,
            this.colLineExchangeTypeID,
            this.colLineNote,
            this.colGrdLineRowGUID,
            this.colLineUnitPrice});
            this.grvReceiptLine.GridControl = this.grdReceiptLine;
            this.grvReceiptLine.Name = "grvReceiptLine";
            // 
            // colReceiptLineID
            // 
            this.colReceiptLineID.FieldName = "ReceiptLineID";
            this.colReceiptLineID.Name = "colReceiptLineID";
            // 
            // colGrdLineReceiptID
            // 
            this.colGrdLineReceiptID.Caption = "ReceiptID";
            this.colGrdLineReceiptID.FieldName = "ReceiptID";
            this.colGrdLineReceiptID.Name = "colGrdLineReceiptID";
            // 
            // colGrdLineStatus
            // 
            this.colGrdLineStatus.Caption = "Durum";
            this.colGrdLineStatus.ColumnEdit = this.lookLineStatus;
            this.colGrdLineStatus.FieldName = "Status";
            this.colGrdLineStatus.Name = "colGrdLineStatus";
            this.colGrdLineStatus.Visible = true;
            this.colGrdLineStatus.VisibleIndex = 0;
            // 
            // lookLineStatus
            // 
            this.lookLineStatus.AutoHeight = false;
            this.lookLineStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLineStatus.DisplayMember = "Name";
            this.lookLineStatus.Name = "lookLineStatus";
            this.lookLineStatus.ValueMember = "Code";
            // 
            // colGrdLineNumber
            // 
            this.colGrdLineNumber.Caption = "Sıra No";
            this.colGrdLineNumber.FieldName = "LineNumber";
            this.colGrdLineNumber.Name = "colGrdLineNumber";
            this.colGrdLineNumber.Visible = true;
            this.colGrdLineNumber.VisibleIndex = 1;
            // 
            // colLineOperationCode
            // 
            this.colLineOperationCode.Caption = "Operasyon Kodu";
            this.colLineOperationCode.ColumnEdit = this.lookOperationCode;
            this.colLineOperationCode.FieldName = "OperationCode";
            this.colLineOperationCode.Name = "colLineOperationCode";
            this.colLineOperationCode.Visible = true;
            this.colLineOperationCode.VisibleIndex = 2;
            // 
            // lookOperationCode
            // 
            this.lookOperationCode.AutoHeight = false;
            this.lookOperationCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookOperationCode.DisplayMember = "Operasyon Adı";
            this.lookOperationCode.Name = "lookOperationCode";
            this.lookOperationCode.ValueMember = "Operasyon Kodu";
            // 
            // colLineChemicalCode
            // 
            this.colLineChemicalCode.Caption = "Kimyasal Kodu";
            this.colLineChemicalCode.ColumnEdit = this.lookChemicalCode;
            this.colLineChemicalCode.FieldName = "ChemicalCode";
            this.colLineChemicalCode.Name = "colLineChemicalCode";
            this.colLineChemicalCode.Visible = true;
            this.colLineChemicalCode.VisibleIndex = 3;
            // 
            // lookChemicalCode
            // 
            this.lookChemicalCode.AutoHeight = false;
            this.lookChemicalCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookChemicalCode.DisplayMember = "Kimyasal Adı";
            this.lookChemicalCode.Name = "lookChemicalCode";
            this.lookChemicalCode.ValueMember = "Kimyasal Kodu";
            // 
            // colLineCalculateType
            // 
            this.colLineCalculateType.Caption = "Hesaplama Şekli";
            this.colLineCalculateType.ColumnEdit = this.lookCalculateType;
            this.colLineCalculateType.FieldName = "CalculateType";
            this.colLineCalculateType.Name = "colLineCalculateType";
            this.colLineCalculateType.Visible = true;
            this.colLineCalculateType.VisibleIndex = 4;
            // 
            // lookCalculateType
            // 
            this.lookCalculateType.AutoHeight = false;
            this.lookCalculateType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCalculateType.DisplayMember = "HesaplamaSekliAd";
            this.lookCalculateType.Name = "lookCalculateType";
            this.lookCalculateType.ValueMember = "HesaplamaSekliKod";
            // 
            // colLineChemicalType
            // 
            this.colLineChemicalType.Caption = "Kimyasal Türü";
            this.colLineChemicalType.ColumnEdit = this.lookChemicalType;
            this.colLineChemicalType.FieldName = "ChemicalType";
            this.colLineChemicalType.Name = "colLineChemicalType";
            this.colLineChemicalType.Visible = true;
            this.colLineChemicalType.VisibleIndex = 5;
            // 
            // lookChemicalType
            // 
            this.lookChemicalType.AutoHeight = false;
            this.lookChemicalType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookChemicalType.DisplayMember = "Name";
            this.lookChemicalType.Name = "lookChemicalType";
            this.lookChemicalType.ValueMember = "Code";
            // 
            // colLineUnitAmount
            // 
            this.colLineUnitAmount.Caption = "Birim Miktar";
            this.colLineUnitAmount.FieldName = "UnitAmount";
            this.colLineUnitAmount.Name = "colLineUnitAmount";
            this.colLineUnitAmount.Visible = true;
            this.colLineUnitAmount.VisibleIndex = 6;
            // 
            // colLineTotalAmount
            // 
            this.colLineTotalAmount.Caption = "Miktar (Gr) ";
            this.colLineTotalAmount.FieldName = "TotalAmount";
            this.colLineTotalAmount.Name = "colLineTotalAmount";
            this.colLineTotalAmount.Visible = true;
            this.colLineTotalAmount.VisibleIndex = 7;
            // 
            // colGrdLineAmount
            // 
            this.colGrdLineAmount.Caption = "Miktar (Kg)";
            this.colGrdLineAmount.FieldName = "Amount";
            this.colGrdLineAmount.Name = "colGrdLineAmount";
            this.colGrdLineAmount.Visible = true;
            this.colGrdLineAmount.VisibleIndex = 8;
            // 
            // colLinePrice
            // 
            this.colLinePrice.Caption = "Fiyat";
            this.colLinePrice.FieldName = "Price";
            this.colLinePrice.Name = "colLinePrice";
            this.colLinePrice.Visible = true;
            this.colLinePrice.VisibleIndex = 9;
            // 
            // colLineExchangeTypeID
            // 
            this.colLineExchangeTypeID.Caption = "Birim Fiyat";
            this.colLineExchangeTypeID.ColumnEdit = this.lookExchangeTypeID;
            this.colLineExchangeTypeID.FieldName = "ExchangeTypeID";
            this.colLineExchangeTypeID.Name = "colLineExchangeTypeID";
            this.colLineExchangeTypeID.Visible = true;
            this.colLineExchangeTypeID.VisibleIndex = 10;
            // 
            // lookExchangeTypeID
            // 
            this.lookExchangeTypeID.AutoHeight = false;
            this.lookExchangeTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookExchangeTypeID.DisplayMember = "Code";
            this.lookExchangeTypeID.Name = "lookExchangeTypeID";
            this.lookExchangeTypeID.ValueMember = "ExchangeTypeID";
            // 
            // colLineNote
            // 
            this.colLineNote.Caption = "Açıklama";
            this.colLineNote.FieldName = "Açıklama";
            this.colLineNote.Name = "colLineNote";
            this.colLineNote.Visible = true;
            this.colLineNote.VisibleIndex = 11;
            // 
            // colGrdLineRowGUID
            // 
            this.colGrdLineRowGUID.Caption = "RowGUID";
            this.colGrdLineRowGUID.FieldName = "RowGUID";
            this.colGrdLineRowGUID.Name = "colGrdLineRowGUID";
            // 
            // colLineUnitPrice
            // 
            this.colLineUnitPrice.Caption = "Birim Fiyat";
            this.colLineUnitPrice.ColumnEdit = this.lookUnitPrice;
            this.colLineUnitPrice.Name = "colLineUnitPrice";
            this.colLineUnitPrice.Visible = true;
            this.colLineUnitPrice.VisibleIndex = 12;
            // 
            // lookUnitPrice
            // 
            this.lookUnitPrice.AutoHeight = false;
            this.lookUnitPrice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUnitPrice.Name = "lookUnitPrice";
            this.lookUnitPrice.EditValueChanged += new System.EventHandler(this.LookUnitPrice_EditValueChanged);
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
            this.barDockControlTop.Size = new System.Drawing.Size(602, 21);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 670);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(602, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 649);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(602, 21);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 649);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnChangeStatus);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbon;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 72);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.splitContainerControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.grdReceiptLine);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(602, 598);
            this.splitContainerControl2.SplitterPosition = 399;
            this.splitContainerControl2.TabIndex = 8;
            // 
            // ReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 670);
            this.Controls.Add(this.splitContainerControl2);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ReceiptForm";
            this.Text = "Reçete Tanımı";
            this.Load += new System.EventHandler(this.ReceiptForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdOrderAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdFlotte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdConicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditConicGrdAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdColorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdTouchness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinDyeCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMaxDyeCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGrdReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditFlotte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditConicAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookConicTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditOrderAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookColorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMinDyeCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMaxDyeCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookTouchness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProcessID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceiptLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReceiptLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLineStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookOperationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChemicalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCalculateType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChemicalType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookExchangeTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vGrdReceipt;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowReceiptID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRowGUID;
        private DevExpress.XtraGrid.GridControl grdReceipt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReceipt;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdConicType;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdCode3;
        private DevExpress.XtraGrid.Columns.GridColumn colStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colConicTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colMachine;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colFicheNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colFlotte;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdFlotte;
        private DevExpress.XtraGrid.Columns.GridColumn colConicAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditConicGrdAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStockCode;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFicheNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStockCode;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMachineID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowReceiptNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSerialNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowAmount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFlotte;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowConicAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookMachineID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditFlotte;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditConicAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookConicTypeID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowConicTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdOrderAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditOrderAmount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOrderAmount;
        private DevExpress.XtraGrid.GridControl grdReceiptLine;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReceiptLine;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colGrdLineReceiptID;
        private DevExpress.XtraGrid.Columns.GridColumn colGrdLineNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colLineOperationCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookOperationCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLineChemicalCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookChemicalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLineCalculateType;
        private DevExpress.XtraGrid.Columns.GridColumn colLineChemicalType;
        private DevExpress.XtraGrid.Columns.GridColumn colLineUnitAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colLineTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colGrdLineAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colLineNote;
        private DevExpress.XtraGrid.Columns.GridColumn colLinePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colLineExchangeTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookExchangeTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colGrdLineStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colGrdLineRowGUID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookCalculateType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookChemicalType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookLineStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colGrdStockGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStockGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStockGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStockGroupID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookColorType;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowColorType;
        private DevExpress.XtraGrid.Columns.GridColumn colColorType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdColorType;
        private DevExpress.XtraGrid.Columns.GridColumn colMinDyeCapacity;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinMinDyeCapacity;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxDyeCapacity;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinMaxDyeCapacity;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditMinDyeCapacity;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditMaxDyeCapacity;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMinDyeCapacity;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMaxDyeCapacity;
        private DevExpress.XtraGrid.Columns.GridColumn colTouchness;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdTouchness;
        private DevExpress.XtraGrid.Columns.GridColumn colFeature;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdFeature;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookTouchness;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookFeature;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTouchness;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFeature;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUnitPrice;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraBars.BarButtonItem btnCalculate;
        private DevExpress.XtraGrid.Columns.GridColumn colLineUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProcessID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookProcessID;
    }
}