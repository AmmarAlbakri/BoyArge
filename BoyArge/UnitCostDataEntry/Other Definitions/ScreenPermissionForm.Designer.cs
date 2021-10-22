namespace BoyArge
{
    partial class ScreenPermissionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenPermissionForm));
            this.grdScreenPermission = new DevExpress.XtraGrid.GridControl();
            this.grvScreenPermission = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colScreenPermissionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colScreenID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdScreen = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdUser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vGrdScreenPermission = new DevExpress.XtraVerticalGrid.VGridControl();
            this.lookStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookUserID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookScreen = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowScreenPermissionID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowScreenID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUserID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowAccess = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowEdit = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
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
            this.toggleAccess = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.toggleEdit = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.toggleGrdAccess = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.toggleGrdEdit = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.grdScreenPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvScreenPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdScreenPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleGrdAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleGrdEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // grdScreenPermission
            // 
            this.grdScreenPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdScreenPermission.Location = new System.Drawing.Point(0, 0);
            this.grdScreenPermission.MainView = this.grvScreenPermission;
            this.grdScreenPermission.Name = "grdScreenPermission";
            this.grdScreenPermission.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookGrdStatus,
            this.lookGrdUser,
            this.lookGrdScreen,
            this.toggleGrdAccess,
            this.toggleGrdEdit});
            this.grdScreenPermission.Size = new System.Drawing.Size(704, 386);
            this.grdScreenPermission.TabIndex = 0;
            this.grdScreenPermission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvScreenPermission});
            // 
            // grvScreenPermission
            // 
            this.grvScreenPermission.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colScreenPermissionID,
            this.colStatus,
            this.colScreenID,
            this.colUserID,
            this.colEdit,
            this.colAccess,
            this.colRowGUID});
            this.grvScreenPermission.GridControl = this.grdScreenPermission;
            this.grvScreenPermission.GroupCount = 1;
            this.grvScreenPermission.Name = "grvScreenPermission";
            this.grvScreenPermission.OptionsBehavior.Editable = false;
            this.grvScreenPermission.OptionsView.ShowAutoFilterRow = true;
            this.grvScreenPermission.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvScreenPermission.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GrvScreenPermission_PopupMenuShowing);
            this.grvScreenPermission.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrvScreenPermission_FocusedRowChanged);
            // 
            // colScreenPermissionID
            // 
            this.colScreenPermissionID.Caption = "ScreenPermissionID";
            this.colScreenPermissionID.FieldName = "ScreenPermissionID";
            this.colScreenPermissionID.Name = "colScreenPermissionID";
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
            // colScreenID
            // 
            this.colScreenID.Caption = "Ekran Adı";
            this.colScreenID.ColumnEdit = this.lookGrdScreen;
            this.colScreenID.FieldName = "ScreenID";
            this.colScreenID.Name = "colScreenID";
            this.colScreenID.Visible = true;
            this.colScreenID.VisibleIndex = 1;
            // 
            // lookGrdScreen
            // 
            this.lookGrdScreen.AutoHeight = false;
            this.lookGrdScreen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdScreen.DisplayMember = "Name";
            this.lookGrdScreen.Name = "lookGrdScreen";
            this.lookGrdScreen.ValueMember = "ScreenID";
            // 
            // colUserID
            // 
            this.colUserID.Caption = "Kullanıcı";
            this.colUserID.ColumnEdit = this.lookGrdUser;
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 2;
            // 
            // lookGrdUser
            // 
            this.lookGrdUser.AutoHeight = false;
            this.lookGrdUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdUser.Name = "lookGrdUser";
            // 
            // colEdit
            // 
            this.colEdit.Caption = "Düzenleme Yetkisi";
            this.colEdit.ColumnEdit = this.toggleGrdAccess;
            this.colEdit.FieldName = "Edit";
            this.colEdit.Name = "colEdit";
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 3;
            // 
            // colAccess
            // 
            this.colAccess.Caption = "Erişim Yetkisi";
            this.colAccess.ColumnEdit = this.toggleGrdEdit;
            this.colAccess.FieldName = "Access";
            this.colAccess.Name = "colAccess";
            this.colAccess.Visible = true;
            this.colAccess.VisibleIndex = 2;
            // 
            // colRowGUID
            // 
            this.colRowGUID.Caption = "rowGUID";
            this.colRowGUID.FieldName = "RowGUID";
            this.colRowGUID.Name = "colRowGUID";
            // 
            // vGrdScreenPermission
            // 
            this.vGrdScreenPermission.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrdScreenPermission.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.vGrdScreenPermission.CustomizationFormBounds = new System.Drawing.Rectangle(457, 176, 214, 258);
            this.vGrdScreenPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrdScreenPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGrdScreenPermission.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGrdScreenPermission.Location = new System.Drawing.Point(0, 0);
            this.vGrdScreenPermission.Name = "vGrdScreenPermission";
            this.vGrdScreenPermission.RecordWidth = 158;
            this.vGrdScreenPermission.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookStatus,
            this.lookUserID,
            this.lookScreen,
            this.toggleAccess,
            this.toggleEdit});
            this.vGrdScreenPermission.RowHeaderWidth = 42;
            this.vGrdScreenPermission.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowScreenPermissionID,
            this.rowScreenID,
            this.rowUserID,
            this.rowAccess,
            this.rowEdit,
            this.rowStatus,
            this.rowRowGUID});
            this.vGrdScreenPermission.Size = new System.Drawing.Size(704, 211);
            this.vGrdScreenPermission.TabIndex = 0;
            // 
            // lookStatus
            // 
            this.lookStatus.AutoHeight = false;
            this.lookStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.NullText = "Durum Seçiniz";
            // 
            // lookUserID
            // 
            this.lookUserID.AutoHeight = false;
            this.lookUserID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUserID.Name = "lookUserID";
            this.lookUserID.ValueMember = "UserID";
            // 
            // lookScreen
            // 
            this.lookScreen.AutoHeight = false;
            this.lookScreen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookScreen.DisplayMember = "Name";
            this.lookScreen.Name = "lookScreen";
            this.lookScreen.ValueMember = "ScreenID";
            // 
            // rowScreenPermissionID
            // 
            this.rowScreenPermissionID.Name = "rowScreenPermissionID";
            this.rowScreenPermissionID.Properties.Caption = "ScreenPermissionID";
            this.rowScreenPermissionID.Properties.FieldName = "ScreenPermissionID";
            this.rowScreenPermissionID.Visible = false;
            // 
            // rowScreenID
            // 
            this.rowScreenID.Height = 16;
            this.rowScreenID.Name = "rowScreenID";
            this.rowScreenID.Properties.Caption = "Ekran Adı";
            this.rowScreenID.Properties.FieldName = "ScreenID";
            this.rowScreenID.Properties.RowEdit = this.lookScreen;
            // 
            // rowUserID
            // 
            this.rowUserID.Name = "rowUserID";
            this.rowUserID.Properties.Caption = "Kullanıcı Adı";
            this.rowUserID.Properties.FieldName = "UserID";
            this.rowUserID.Properties.RowEdit = this.lookUserID;
            // 
            // rowAccess
            // 
            this.rowAccess.Name = "rowAccess";
            this.rowAccess.Properties.Caption = "Erişim Yetkisi";
            this.rowAccess.Properties.FieldName = "Access";
            this.rowAccess.Properties.RowEdit = this.toggleAccess;
            // 
            // rowEdit
            // 
            this.rowEdit.Name = "rowEdit";
            this.rowEdit.Properties.Caption = "Düzenleme Yetkisi";
            this.rowEdit.Properties.FieldName = "Edit";
            this.rowEdit.Properties.RowEdit = this.toggleEdit;
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
            this.splitContainerControl1.Panel1.Controls.Add(this.vGrdScreenPermission);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdScreenPermission);
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
            // toggleAccess
            // 
            this.toggleAccess.AutoHeight = false;
            this.toggleAccess.Name = "toggleAccess";
            this.toggleAccess.OffText = "Off";
            this.toggleAccess.OnText = "On";
            // 
            // toggleEdit
            // 
            this.toggleEdit.AutoHeight = false;
            this.toggleEdit.Name = "toggleEdit";
            this.toggleEdit.OffText = "Off";
            this.toggleEdit.OnText = "On";
            // 
            // toggleGrdAccess
            // 
            this.toggleGrdAccess.AutoHeight = false;
            this.toggleGrdAccess.Name = "toggleGrdAccess";
            this.toggleGrdAccess.OffText = "Off";
            this.toggleGrdAccess.OnText = "On";
            // 
            // toggleGrdEdit
            // 
            this.toggleGrdEdit.AutoHeight = false;
            this.toggleGrdEdit.Name = "toggleGrdEdit";
            this.toggleGrdEdit.OffText = "Off";
            this.toggleGrdEdit.OnText = "On";
            // 
            // ScreenPermissionForm
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
            this.Name = "ScreenPermissionForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekran İzinleri";
            this.Load += new System.EventHandler(this.ScreenPermissionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdScreenPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvScreenPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdScreenPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleGrdAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleGrdEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdScreenPermission;
        private DevExpress.XtraGrid.Views.Grid.GridView grvScreenPermission;
        private DevExpress.XtraVerticalGrid.VGridControl vGrdScreenPermission;
        private DevExpress.XtraGrid.Columns.GridColumn colScreenPermissionID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colScreenID;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowScreenPermissionID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowScreenID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRowGUID;
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
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUserID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colAccess;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowAccess;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdScreen;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookScreen;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch toggleGrdAccess;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch toggleGrdEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch toggleAccess;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch toggleEdit;
    }
}