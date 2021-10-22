
namespace BoyArge
{
    partial class GridViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridViewerForm));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pTop = new DevExpress.Utils.Layout.StackPanel();
            this.lblSeconds = new DevExpress.XtraEditors.LabelControl();
            this.btnPlayPause = new DevExpress.XtraEditors.SimpleButton();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTop)).BeginInit();
            this.pTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 42);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(800, 408);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl;
            this.gridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // pTop
            // 
            this.pTop.Appearance.BackColor = System.Drawing.Color.White;
            this.pTop.Appearance.Options.UseBackColor = true;
            this.pTop.AutoScroll = true;
            this.pTop.AutoSize = true;
            this.pTop.Controls.Add(this.lblSeconds);
            this.pTop.Controls.Add(this.btnPlayPause);
            this.pTop.Controls.Add(this.btnStop);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(800, 42);
            this.pTop.TabIndex = 0;
            // 
            // lblSeconds
            // 
            this.lblSeconds.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lblSeconds.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblSeconds.Appearance.Options.UseFont = true;
            this.lblSeconds.Appearance.Options.UseForeColor = true;
            this.lblSeconds.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblSeconds.ImageOptions.SvgImage = global::BoyArge.Properties.Resources.time;
            this.lblSeconds.Location = new System.Drawing.Point(3, 3);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(53, 36);
            this.lblSeconds.TabIndex = 1;
            this.lblSeconds.Text = "01";
            this.lblSeconds.ToolTip = "Kalan Süre";
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.ImageOptions.SvgImage = global::BoyArge.Properties.Resources.pause;
            this.btnPlayPause.Location = new System.Drawing.Point(62, 6);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPlayPause.Size = new System.Drawing.Size(40, 30);
            this.btnPlayPause.TabIndex = 0;
            this.btnPlayPause.ToolTip = "Duraklat/Devam";
            this.btnPlayPause.Click += new System.EventHandler(this.BtnPlayPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnStop.ImageOptions.SvgImage")));
            this.btnStop.Location = new System.Drawing.Point(108, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.ToolTip = "Kapat";
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // GridViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GridViewerForm";
            this.Text = "Tablo İzleyici";
            this.Load += new System.EventHandler(this.GridViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTop)).EndInit();
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.Utils.Layout.StackPanel pTop;
        private DevExpress.XtraEditors.LabelControl lblSeconds;
        private DevExpress.XtraEditors.SimpleButton btnPlayPause;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraEditors.SimpleButton btnStop;
    }
}