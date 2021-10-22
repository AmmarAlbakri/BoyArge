
namespace BoyArge
{
    partial class CPMDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPMDashboardForm));
            this.pTop = new System.Windows.Forms.Panel();
            this.dashboardViewer = new DevExpress.DashboardWin.DashboardViewer(this.components);
            this.ribbonControl2 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeStatus = new DevExpress.XtraBars.BarButtonItem();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboardDesigner = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.tum_siparisler = new DevExpress.XtraBars.BarButtonItem();
            this.tum_numuneler = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.CPMDashboardFormlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.pTopitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.seperator1 = new DevExpress.XtraBars.BarHeaderItem();
            this.pTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPMDashboardFormlayoutControl1ConvertedLayout)).BeginInit();
            this.CPMDashboardFormlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTopitem)).BeginInit();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.dashboardViewer);
            this.pTop.Location = new System.Drawing.Point(2, 2);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(952, 558);
            this.pTop.TabIndex = 10;
            // 
            // dashboardViewer
            // 
            this.dashboardViewer.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dashboardViewer.Appearance.Options.UseBackColor = true;
            this.dashboardViewer.AsyncMode = true;
            this.dashboardViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardViewer.Location = new System.Drawing.Point(0, 0);
            this.dashboardViewer.Name = "dashboardViewer";
            this.dashboardViewer.Size = new System.Drawing.Size(952, 558);
            this.dashboardViewer.TabIndex = 1;
            this.dashboardViewer.UseNeutralFilterMode = true;
            this.dashboardViewer.DashboardItemDoubleClick += new DevExpress.DashboardWin.DashboardItemMouseActionEventHandler(this.dashboardViewer_DashboardItemDoubleClick);
            // 
            // ribbonControl2
            // 
            this.ribbonControl2.ExpandCollapseItem.Id = 0;
            this.ribbonControl2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl2.ExpandCollapseItem,
            this.ribbonControl2.SearchEditItem,
            this.btnRefresh,
            this.btnChangeStatus,
            this.barDockingMenuItem1,
            this.barMdiChildrenListItem1,
            this.barButtonItem1,
            this.btnDashboardDesigner,
            this.barButtonItem2,
            this.tum_siparisler,
            this.tum_numuneler,
            this.barButtonItem3});
            this.ribbonControl2.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl2.MaxItemId = 18;
            this.ribbonControl2.Name = "ribbonControl2";
            this.ribbonControl2.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl2.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage3});
            this.ribbonControl2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbonControl2.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl2.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl2.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl2.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl2.ShowToolbarCustomizeItem = false;
            this.ribbonControl2.Size = new System.Drawing.Size(956, 61);
            this.ribbonControl2.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl2.Click += new System.EventHandler(this.ribbonControl2_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Çalıştır";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.SvgImage = global::BoyArge.Properties.Resources.next3;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRefresh_ItemClick);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Caption = "Etkinleştir / Devre Dışı Bırak";
            this.btnChangeStatus.Id = 6;
            this.btnChangeStatus.Name = "btnChangeStatus";
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Caption = "barDockingMenuItem1";
            this.barDockingMenuItem1.Id = 9;
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "barMdiChildrenListItem1";
            this.barMdiChildrenListItem1.Id = 10;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnDashboardDesigner
            // 
            this.btnDashboardDesigner.Caption = "Dashboard Düzenle";
            this.btnDashboardDesigner.Id = 13;
            this.btnDashboardDesigner.ImageOptions.SvgImage = global::BoyArge.Properties.Resources.dashboarddesigner;
            this.btnDashboardDesigner.Name = "btnDashboardDesigner";
            this.btnDashboardDesigner.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDashboardDesigner_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Maximize";
            this.barButtonItem2.Id = 14;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // tum_siparisler
            // 
            this.tum_siparisler.Caption = "Tüm Siparişler";
            this.tum_siparisler.Id = 15;
            this.tum_siparisler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tum_siparisler.ImageOptions.Image")));
            this.tum_siparisler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("tum_siparisler.ImageOptions.LargeImage")));
            this.tum_siparisler.Name = "tum_siparisler";
            this.tum_siparisler.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.tum_siparisler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // tum_numuneler
            // 
            this.tum_numuneler.Caption = "Numune Analizler";
            this.tum_numuneler.Id = 16;
            this.tum_numuneler.ImageOptions.SvgImage = global::BoyArge.Properties.Resources.charttype_line1;
            this.tum_numuneler.Name = "tum_numuneler";
            this.tum_numuneler.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.tum_numuneler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tum_numuneler_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Termin Analizler";
            this.barButtonItem3.Id = 17;
            this.barButtonItem3.ImageOptions.SvgImage = global::BoyArge.Properties.Resources.charttype_line;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_1);
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup3.ItemLinks.Add(this.tum_siparisler);
            this.ribbonPageGroup3.ItemLinks.Add(this.tum_numuneler);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDashboardDesigner);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup3.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
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
            this.barDockControlTop.Size = new System.Drawing.Size(956, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 623);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(956, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 623);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(956, 0);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 623);
            // 
            // popupMenu
            // 
            this.popupMenu.Name = "popupMenu";
            // 
            // CPMDashboardFormlayoutControl1ConvertedLayout
            // 
            this.CPMDashboardFormlayoutControl1ConvertedLayout.Controls.Add(this.pTop);
            this.CPMDashboardFormlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CPMDashboardFormlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 61);
            this.CPMDashboardFormlayoutControl1ConvertedLayout.Name = "CPMDashboardFormlayoutControl1ConvertedLayout";
            this.CPMDashboardFormlayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.CPMDashboardFormlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(956, 562);
            this.CPMDashboardFormlayoutControl1ConvertedLayout.TabIndex = 12;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.pTopitem});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(956, 562);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // pTopitem
            // 
            this.pTopitem.Control = this.pTop;
            this.pTopitem.Location = new System.Drawing.Point(0, 0);
            this.pTopitem.Name = "pTopitem";
            this.pTopitem.Size = new System.Drawing.Size(956, 562);
            this.pTopitem.TextSize = new System.Drawing.Size(0, 0);
            this.pTopitem.TextVisible = false;
            // 
            // seperator1
            // 
            this.seperator1.Caption = "||";
            this.seperator1.Id = 12;
            this.seperator1.Name = "seperator1";
            // 
            // CPMDashboardForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 623);
            this.Controls.Add(this.CPMDashboardFormlayoutControl1ConvertedLayout);
            this.Controls.Add(this.ribbonControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CPMDashboardForm";
            this.Ribbon = this.ribbonControl2;
            this.Text = "CPM Maliyet Dashboard";
            this.Load += new System.EventHandler(this.CPMDashboardForm_Load);
            this.pTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPMDashboardFormlayoutControl1ConvertedLayout)).EndInit();
            this.CPMDashboardFormlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTopitem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pTop;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraLayout.LayoutControl CPMDashboardFormlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem pTopitem;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl2;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnChangeStatus;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnDashboardDesigner;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarHeaderItem seperator1;
        public DevExpress.XtraBars.BarButtonItem tum_siparisler;
        private DevExpress.XtraBars.BarButtonItem tum_numuneler;
        private DevExpress.DashboardWin.DashboardViewer dashboardViewer;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}