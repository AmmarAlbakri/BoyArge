namespace BoyArge
{
    partial class DashboardViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardViewerForm));
            this.dashboardViewer = new DevExpress.DashboardWin.DashboardViewer(this.components);
            this.dataLayoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.lookReportType = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcGroupDashboardList = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemUnitCostType = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl)).BeginInit();
            this.dataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupDashboardList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemUnitCostType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dashboardViewer
            // 
            this.dashboardViewer.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dashboardViewer.Appearance.Options.UseBackColor = true;
            this.dashboardViewer.AsyncMode = true;
            this.dashboardViewer.Location = new System.Drawing.Point(12, 64);
            this.dashboardViewer.Name = "dashboardViewer";
            this.dashboardViewer.Size = new System.Drawing.Size(739, 434);
            this.dashboardViewer.TabIndex = 2;
            this.dashboardViewer.UseNeutralFilterMode = true;
            // 
            // dataLayoutControl
            // 
            this.dataLayoutControl.Controls.Add(this.btnSelect);
            this.dataLayoutControl.Controls.Add(this.dashboardViewer);
            this.dataLayoutControl.Controls.Add(this.lookReportType);
            this.dataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl.Name = "dataLayoutControl";
            this.dataLayoutControl.Root = this.Root;
            this.dataLayoutControl.Size = new System.Drawing.Size(763, 510);
            this.dataLayoutControl.TabIndex = 0;
            this.dataLayoutControl.Text = " ";
            // 
            // btnSelect
            // 
            this.btnSelect.ImageOptions.SvgImage = global::BoyArge.Properties.Resources.find;
            this.btnSelect.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnSelect.Location = new System.Drawing.Point(713, 24);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(26, 24);
            this.btnSelect.StyleController = this.dataLayoutControl;
            this.btnSelect.TabIndex = 1;
            this.btnSelect.ToolTip = "Görüntüle";
            this.btnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // lookReportType
            // 
            this.lookReportType.Location = new System.Drawing.Point(137, 24);
            this.lookReportType.Name = "lookReportType";
            this.lookReportType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lookReportType.Properties.Appearance.Options.UseFont = true;
            this.lookReportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookReportType.Properties.DisplayMember = "Name";
            this.lookReportType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookReportType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookReportType.Properties.ValueMember = "DocumentID";
            this.lookReportType.Size = new System.Drawing.Size(572, 24);
            this.lookReportType.StyleController = this.dataLayoutControl;
            this.lookReportType.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupDashboardList,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(763, 510);
            this.Root.TextVisible = false;
            // 
            // lcGroupDashboardList
            // 
            this.lcGroupDashboardList.CustomizationFormText = "-";
            this.lcGroupDashboardList.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemUnitCostType,
            this.layoutControlItem2});
            this.lcGroupDashboardList.Location = new System.Drawing.Point(0, 0);
            this.lcGroupDashboardList.Name = "lcGroupDashboardList";
            this.lcGroupDashboardList.Size = new System.Drawing.Size(743, 52);
            this.lcGroupDashboardList.Text = "-";
            this.lcGroupDashboardList.TextVisible = false;
            // 
            // lcItemUnitCostType
            // 
            this.lcItemUnitCostType.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold);
            this.lcItemUnitCostType.AppearanceItemCaption.Options.UseFont = true;
            this.lcItemUnitCostType.Control = this.lookReportType;
            this.lcItemUnitCostType.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lcItemUnitCostType.CustomizationFormText = "Rapor Türü";
            this.lcItemUnitCostType.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lcItemUnitCostType.ImageOptions.SvgImage")));
            this.lcItemUnitCostType.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lcItemUnitCostType.Location = new System.Drawing.Point(0, 0);
            this.lcItemUnitCostType.Name = "lcItemUnitCostType";
            this.lcItemUnitCostType.Size = new System.Drawing.Size(689, 28);
            this.lcItemUnitCostType.Text = "Rapor Seçimi";
            this.lcItemUnitCostType.TextSize = new System.Drawing.Size(110, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSelect;
            this.layoutControlItem2.Location = new System.Drawing.Point(689, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(30, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dashboardViewer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(743, 438);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DashboardViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 510);
            this.Controls.Add(this.dataLayoutControl);
            this.Name = "DashboardViewerForm";
            this.Text = "Dashboard İzleyici";
            this.Load += new System.EventHandler(this.DashboardViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl)).EndInit();
            this.dataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupDashboardList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemUnitCostType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.DashboardWin.DashboardViewer dashboardViewer;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupDashboardList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lookReportType;
        private DevExpress.XtraLayout.LayoutControlItem lcItemUnitCostType;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.Timer timer1;
    }
}