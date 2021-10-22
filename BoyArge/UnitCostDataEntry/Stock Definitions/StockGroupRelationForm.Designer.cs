namespace BoyArge
{
    partial class StockGroupRelationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockGroupRelationForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.seperator = new DevExpress.XtraBars.BarHeaderItem();
            this.toggleSwitch = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnChangeStatus = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.grdStockGroupRelation = new DevExpress.XtraGrid.GridControl();
            this.grvStockGroupRelation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStockGroupRelationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStockGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStockGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStockCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.vGrdStockGroupRelation = new DevExpress.XtraVerticalGrid.VGridControl();
            this.lookStock = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookStockGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowStockGroupRelationID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStockCode = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStockGroupID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdStockGroupRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockGroupRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdStockGroupRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).BeginInit();
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
            this.seperator,
            this.toggleSwitch,
            this.btnChangeStatus});
            this.ribbon.Location = new System.Drawing.Point(0, 21);
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
            // seperator
            // 
            this.seperator.Caption = " ";
            this.seperator.Id = 6;
            this.seperator.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("seperator.ImageOptions.Image")));
            this.seperator.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("seperator.ImageOptions.LargeImage")));
            this.seperator.Name = "seperator";
            this.seperator.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.seperator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Seperator_ItemClick);
            // 
            // toggleSwitch
            // 
            this.toggleSwitch.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
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
            this.ribbonPageGroup1.ItemLinks.Add(this.seperator);
            this.ribbonPageGroup1.ItemLinks.Add(this.toggleSwitch);
            this.ribbonPageGroup1.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // grdStockGroupRelation
            // 
            this.grdStockGroupRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStockGroupRelation.Location = new System.Drawing.Point(0, 0);
            this.grdStockGroupRelation.MainView = this.grvStockGroupRelation;
            this.grdStockGroupRelation.Name = "grdStockGroupRelation";
            this.grdStockGroupRelation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookGrdStockCode,
            this.lookGrdStatus,
            this.lookGrdStockGroup});
            this.grdStockGroupRelation.Size = new System.Drawing.Size(602, 209);
            this.grdStockGroupRelation.TabIndex = 0;
            this.grdStockGroupRelation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockGroupRelation});
            // 
            // grvStockGroupRelation
            // 
            this.grvStockGroupRelation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStockGroupRelationID,
            this.colStatus,
            this.colStockGroup,
            this.colStock,
            this.colRowGUID});
            this.grvStockGroupRelation.GridControl = this.grdStockGroupRelation;
            this.grvStockGroupRelation.Name = "grvStockGroupRelation";
            this.grvStockGroupRelation.OptionsBehavior.Editable = false;
            this.grvStockGroupRelation.OptionsView.ShowAutoFilterRow = true;
            this.grvStockGroupRelation.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GrvStockGroupRelation_PopupMenuShowing);
            this.grvStockGroupRelation.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrvStockGroupRelation_FocusedRowChanged);
            // 
            // colStockGroupRelationID
            // 
            this.colStockGroupRelationID.Caption = "StockGroupRelationID";
            this.colStockGroupRelationID.FieldName = "StockGroupRelationID";
            this.colStockGroupRelationID.Name = "colStockGroupRelationID";
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
            // colStockGroup
            // 
            this.colStockGroup.Caption = "Mamül Grubu";
            this.colStockGroup.ColumnEdit = this.lookGrdStockGroup;
            this.colStockGroup.FieldName = "StockGroupID";
            this.colStockGroup.Name = "colStockGroup";
            this.colStockGroup.Visible = true;
            this.colStockGroup.VisibleIndex = 2;
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
            // colStock
            // 
            this.colStock.Caption = "Mamül";
            this.colStock.ColumnEdit = this.lookGrdStockCode;
            this.colStock.FieldName = "StockCode";
            this.colStock.Name = "colStock";
            this.colStock.Visible = true;
            this.colStock.VisibleIndex = 1;
            // 
            // lookGrdStockCode
            // 
            this.lookGrdStockCode.AutoHeight = false;
            this.lookGrdStockCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStockCode.DisplayMember = "Name";
            this.lookGrdStockCode.Name = "lookGrdStockCode";
            this.lookGrdStockCode.ValueMember = "StockCode";
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 72);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.vGrdStockGroupRelation);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdStockGroupRelation);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(602, 400);
            this.splitContainerControl1.SplitterPosition = 181;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // vGrdStockGroupRelation
            // 
            this.vGrdStockGroupRelation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrdStockGroupRelation.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGrdStockGroupRelation.CustomizationFormBounds = new System.Drawing.Rectangle(457, 176, 214, 258);
            this.vGrdStockGroupRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrdStockGroupRelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGrdStockGroupRelation.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGrdStockGroupRelation.Location = new System.Drawing.Point(0, 0);
            this.vGrdStockGroupRelation.Name = "vGrdStockGroupRelation";
            this.vGrdStockGroupRelation.RecordWidth = 158;
            this.vGrdStockGroupRelation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookStock,
            this.lookStockGroup,
            this.lookStatus});
            this.vGrdStockGroupRelation.RowHeaderWidth = 42;
            this.vGrdStockGroupRelation.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowStockGroupRelationID,
            this.rowStockCode,
            this.rowStockGroupID,
            this.rowStatus,
            this.rowRowGUID});
            this.vGrdStockGroupRelation.Size = new System.Drawing.Size(602, 181);
            this.vGrdStockGroupRelation.TabIndex = 0;
            // 
            // lookStock
            // 
            this.lookStock.AutoHeight = false;
            this.lookStock.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStock.Name = "lookStock";
            this.lookStock.NullText = "Mamül Seçiniz";
            this.lookStock.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            // 
            // lookStockGroup
            // 
            this.lookStockGroup.AutoHeight = false;
            this.lookStockGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStockGroup.DisplayMember = "Name";
            this.lookStockGroup.Name = "lookStockGroup";
            this.lookStockGroup.NullText = "Mamül Grubu Seçiniz";
            this.lookStockGroup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookStockGroup.ValueMember = "StockGroupID";
            // 
            // lookStatus
            // 
            this.lookStatus.AutoHeight = false;
            this.lookStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.NullText = "Durum Seçiniz";
            // 
            // rowStockGroupRelationID
            // 
            this.rowStockGroupRelationID.Name = "rowStockGroupRelationID";
            this.rowStockGroupRelationID.Properties.Caption = "StockGroupRelationID";
            this.rowStockGroupRelationID.Properties.FieldName = "StockGroupRelationID";
            this.rowStockGroupRelationID.Visible = false;
            // 
            // rowStockCode
            // 
            this.rowStockCode.Name = "rowStockCode";
            this.rowStockCode.Properties.Caption = "Mamül";
            this.rowStockCode.Properties.FieldName = "StockCode";
            this.rowStockCode.Properties.RowEdit = this.lookStock;
            // 
            // rowStockGroupID
            // 
            this.rowStockGroupID.Name = "rowStockGroupID";
            this.rowStockGroupID.Properties.Caption = "Mamül Grubu";
            this.rowStockGroupID.Properties.FieldName = "StockGroupID";
            this.rowStockGroupID.Properties.RowEdit = this.lookStockGroup;
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
            this.barDockControlTop.Size = new System.Drawing.Size(602, 21);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 451);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(602, 21);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 451);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnChangeStatus);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbon;
            // 
            // StockGroupRelationForm
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
            this.Name = "StockGroupRelationForm";
            this.Ribbon = this.ribbon;
            this.Text = "Mamül - Grup İlişki Tanımı";
            this.Load += new System.EventHandler(this.StockGroupRelationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockGroupRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockGroupRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGrdStockGroupRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).EndInit();
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
        private DevExpress.XtraVerticalGrid.VGridControl vGrdStockGroupRelation;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStock;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStockGroupRelationID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRowGUID;
        private DevExpress.XtraGrid.GridControl grdStockGroupRelation;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStockGroupRelation;
        private DevExpress.XtraGrid.Columns.GridColumn colStockGroupRelationID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStock;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStockGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStockGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colStockGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStockGroup;
        private DevExpress.XtraBars.BarHeaderItem seperator;
        private DevExpress.XtraBars.BarToggleSwitchItem toggleSwitch;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnChangeStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStockCode;
    }
}