
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
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.grdPermission = new DevExpress.XtraGrid.GridControl();
            this.grvPermission = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colModuleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlatform = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScreen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefinition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScreenPermissionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScreenID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chSelection = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnUpdateAll = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnAccept);
            this.layoutControl1.Controls.Add(this.grdPermission);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 36);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(312, 313, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup2;
            this.layoutControl1.Size = new System.Drawing.Size(1223, 510);
            this.layoutControl1.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(613, 462);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(598, 36);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAccept.Appearance.Options.UseFont = true;
            this.btnAccept.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAccept.ImageOptions.SvgImage")));
            this.btnAccept.Location = new System.Drawing.Point(12, 462);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(597, 36);
            this.btnAccept.StyleController = this.layoutControl1;
            this.btnAccept.TabIndex = 18;
            this.btnAccept.Text = "Güncelle";
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // grdPermission
            // 
            this.grdPermission.Location = new System.Drawing.Point(12, 12);
            this.grdPermission.MainView = this.grvPermission;
            this.grdPermission.Name = "grdPermission";
            this.grdPermission.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chSelection,
            this.repositoryItemCheckEdit1});
            this.grdPermission.Size = new System.Drawing.Size(1199, 446);
            this.grdPermission.TabIndex = 0;
            this.grdPermission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPermission});
            // 
            // grvPermission
            // 
            this.grvPermission.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModuleID,
            this.colPlatform,
            this.colModule,
            this.colUserID,
            this.colUserName,
            this.colScreen,
            this.colDefinition,
            this.colAccess,
            this.colEdit,
            this.colScreenPermissionID,
            this.colStatus,
            this.colRowGUID,
            this.colScreenID});
            this.grvPermission.GridControl = this.grdPermission;
            this.grvPermission.GroupCount = 2;
            this.grvPermission.Name = "grvPermission";
            this.grvPermission.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvPermission.OptionsFilter.AllowColumnMRUFilterList = false;
            this.grvPermission.OptionsFilter.AllowFilterEditor = false;
            this.grvPermission.OptionsSelection.MultiSelect = true;
            this.grvPermission.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPermission.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colModule, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvPermission.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GrvPermission_CellValueChanged);
            // 
            // colModuleID
            // 
            this.colModuleID.FieldName = "ModuleID";
            this.colModuleID.Name = "colModuleID";
            this.colModuleID.OptionsColumn.AllowEdit = false;
            this.colModuleID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colModuleID.OptionsColumn.AllowMove = false;
            this.colModuleID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colPlatform
            // 
            this.colPlatform.FieldName = "Platform";
            this.colPlatform.Name = "colPlatform";
            this.colPlatform.OptionsColumn.AllowEdit = false;
            this.colPlatform.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPlatform.OptionsColumn.AllowMove = false;
            this.colPlatform.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colModule
            // 
            this.colModule.Caption = "Modül";
            this.colModule.FieldName = "Module";
            this.colModule.Name = "colModule";
            this.colModule.OptionsColumn.AllowEdit = false;
            this.colModule.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colModule.OptionsColumn.AllowMove = false;
            this.colModule.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colModule.Visible = true;
            this.colModule.VisibleIndex = 3;
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.OptionsColumn.AllowEdit = false;
            this.colUserID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUserID.OptionsColumn.AllowMove = false;
            this.colUserID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Kullanıcı";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUserName.OptionsColumn.AllowMove = false;
            this.colUserName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 5;
            // 
            // colScreen
            // 
            this.colScreen.Caption = "Ekran";
            this.colScreen.FieldName = "Screen";
            this.colScreen.Name = "colScreen";
            this.colScreen.OptionsColumn.AllowEdit = false;
            this.colScreen.OptionsColumn.AllowMove = false;
            this.colScreen.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colScreen.Visible = true;
            this.colScreen.VisibleIndex = 0;
            // 
            // colDefinition
            // 
            this.colDefinition.Caption = "Ekran Tanımı";
            this.colDefinition.FieldName = "Definition";
            this.colDefinition.Name = "colDefinition";
            this.colDefinition.Visible = true;
            this.colDefinition.VisibleIndex = 1;
            // 
            // colAccess
            // 
            this.colAccess.Caption = "Erişim";
            this.colAccess.FieldName = "Access";
            this.colAccess.Name = "colAccess";
            this.colAccess.OptionsColumn.AllowMove = false;
            this.colAccess.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAccess.Visible = true;
            this.colAccess.VisibleIndex = 2;
            this.colAccess.Width = 98;
            // 
            // colEdit
            // 
            this.colEdit.Caption = "Düzenleme";
            this.colEdit.FieldName = "Edit";
            this.colEdit.Name = "colEdit";
            this.colEdit.OptionsColumn.AllowMove = false;
            this.colEdit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 3;
            // 
            // colScreenPermissionID
            // 
            this.colScreenPermissionID.Caption = "ScreenPermissionID";
            this.colScreenPermissionID.FieldName = "ScreenPermissionID";
            this.colScreenPermissionID.Name = "colScreenPermissionID";
            this.colScreenPermissionID.OptionsColumn.AllowEdit = false;
            this.colScreenPermissionID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colScreenPermissionID.OptionsColumn.AllowMove = false;
            this.colScreenPermissionID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colStatus.OptionsColumn.AllowMove = false;
            this.colStatus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colRowGUID
            // 
            this.colRowGUID.Caption = "RowGUID";
            this.colRowGUID.FieldName = "RowGUID";
            this.colRowGUID.Name = "colRowGUID";
            this.colRowGUID.OptionsColumn.AllowEdit = false;
            this.colRowGUID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colRowGUID.OptionsColumn.AllowMove = false;
            this.colRowGUID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colScreenID
            // 
            this.colScreenID.Caption = "ScreenID";
            this.colScreenID.FieldName = "ScreenID";
            this.colScreenID.Name = "colScreenID";
            this.colScreenID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colScreenID.OptionsColumn.AllowMove = false;
            this.colScreenID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // chSelection
            // 
            this.chSelection.AutoHeight = false;
            this.chSelection.Name = "chSelection";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1223, 510);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdPermission;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1203, 450);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAccept;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 450);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(601, 40);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCancel;
            this.layoutControlItem3.Location = new System.Drawing.Point(601, 450);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(602, 40);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnUpdateAll});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1223, 36);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.Caption = "Toplu Güncelleme";
            this.btnUpdateAll.Id = 1;
            this.btnUpdateAll.ImageOptions.SvgImage = global::BoyArge.Properties.Resources.updatedataextract;
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnUpdateAll_ItemClick);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnUpdateAll);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbonControl1;
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
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
            this.barDockControlTop.Size = new System.Drawing.Size(1223, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 546);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1223, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 546);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1223, 0);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 546);
            // 
            // ScreenPermissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 546);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ScreenPermissionForm";
            this.ribbonControl1.SetPopupContextMenu(this, this.popupMenu);
            this.barManager.SetPopupContextMenu(this, this.popupMenu);
            this.Ribbon = this.ribbonControl1;
            this.Text = "Ekran İzinleri";
            this.Load += new System.EventHandler(this.ScreenPermissionEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.GridControl grdPermission;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPermission;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleID;
        private DevExpress.XtraGrid.Columns.GridColumn colPlatform;
        private DevExpress.XtraGrid.Columns.GridColumn colModule;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colScreen;
        private DevExpress.XtraGrid.Columns.GridColumn colAccess;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colScreenPermissionID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraGrid.Columns.GridColumn colScreenID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chSelection;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnUpdateAll;
        private DevExpress.XtraGrid.Columns.GridColumn colDefinition;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}