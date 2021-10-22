namespace BoyArge
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.txtDataSource = new DevExpress.XtraEditors.TextEdit();
            this.SettingsFormlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.txtTmp = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtInitialCatalog = new DevExpress.XtraEditors.TextEdit();
            this.chcIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtPassworditem = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUserNameitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtInitialCatalogitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDataSourceitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.chcIntegratedSecurityitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.panel2item = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsFormlayoutControl1ConvertedLayout)).BeginInit();
            this.SettingsFormlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTmp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialCatalog.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassworditem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNameitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialCatalogitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataSourceitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcIntegratedSecurityitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(131, 12);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDataSource.Properties.Appearance.Options.UseFont = true;
            this.txtDataSource.Size = new System.Drawing.Size(145, 22);
            this.txtDataSource.StyleController = this.SettingsFormlayoutControl1ConvertedLayout;
            this.txtDataSource.TabIndex = 0;
            // 
            // SettingsFormlayoutControl1ConvertedLayout
            // 
            this.SettingsFormlayoutControl1ConvertedLayout.BackColor = System.Drawing.Color.Transparent;
            this.SettingsFormlayoutControl1ConvertedLayout.Controls.Add(this.txtTmp);
            this.SettingsFormlayoutControl1ConvertedLayout.Controls.Add(this.txtPassword);
            this.SettingsFormlayoutControl1ConvertedLayout.Controls.Add(this.txtUserName);
            this.SettingsFormlayoutControl1ConvertedLayout.Controls.Add(this.txtInitialCatalog);
            this.SettingsFormlayoutControl1ConvertedLayout.Controls.Add(this.txtDataSource);
            this.SettingsFormlayoutControl1ConvertedLayout.Controls.Add(this.chcIntegratedSecurity);
            this.SettingsFormlayoutControl1ConvertedLayout.Controls.Add(this.panel2);
            this.SettingsFormlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsFormlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.SettingsFormlayoutControl1ConvertedLayout.Name = "SettingsFormlayoutControl1ConvertedLayout";
            this.SettingsFormlayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(335, 0, 650, 400);
            this.SettingsFormlayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.SettingsFormlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(288, 247);
            this.SettingsFormlayoutControl1ConvertedLayout.TabIndex = 0;
            // 
            // txtTmp
            // 
            this.txtTmp.Location = new System.Drawing.Point(164, 156);
            this.txtTmp.Name = "txtTmp";
            this.txtTmp.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTmp.Properties.Appearance.Options.UseFont = true;
            this.txtTmp.Size = new System.Drawing.Size(112, 30);
            this.txtTmp.StyleController = this.SettingsFormlayoutControl1ConvertedLayout;
            this.txtTmp.TabIndex = 14;
            this.txtTmp.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "";
            this.txtPassword.Location = new System.Drawing.Point(131, 120);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(145, 22);
            this.txtPassword.StyleController = this.SettingsFormlayoutControl1ConvertedLayout;
            this.txtPassword.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(131, 84);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Size = new System.Drawing.Size(145, 22);
            this.txtUserName.StyleController = this.SettingsFormlayoutControl1ConvertedLayout;
            this.txtUserName.TabIndex = 2;
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Location = new System.Drawing.Point(131, 48);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtInitialCatalog.Properties.Appearance.Options.UseFont = true;
            this.txtInitialCatalog.Size = new System.Drawing.Size(145, 22);
            this.txtInitialCatalog.StyleController = this.SettingsFormlayoutControl1ConvertedLayout;
            this.txtInitialCatalog.TabIndex = 1;
            // 
            // chcIntegratedSecurity
            // 
            this.chcIntegratedSecurity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chcIntegratedSecurity.Image = global::BoyArge.Properties.Resources.lock_16x16;
            this.chcIntegratedSecurity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chcIntegratedSecurity.Location = new System.Drawing.Point(12, 156);
            this.chcIntegratedSecurity.Name = "chcIntegratedSecurity";
            this.chcIntegratedSecurity.Size = new System.Drawing.Size(148, 20);
            this.chcIntegratedSecurity.TabIndex = 4;
            this.chcIntegratedSecurity.Text = "    Entegre Güvenlik";
            this.chcIntegratedSecurity.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chcIntegratedSecurity.UseVisualStyleBackColor = true;
            this.chcIntegratedSecurity.CheckedChanged += new System.EventHandler(this.ChcIntegratedSecurity_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(12, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 45);
            this.panel2.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(187, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceGroup.Options.UseBackColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.txtPassworditem,
            this.txtUserNameitem,
            this.txtInitialCatalogitem,
            this.txtDataSourceitem,
            this.chcIntegratedSecurityitem,
            this.panel2item,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(288, 247);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtPassworditem
            // 
            this.txtPassworditem.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPassworditem.AppearanceItemCaption.Options.UseFont = true;
            this.txtPassworditem.Control = this.txtPassword;
            this.txtPassworditem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtPassworditem.ImageOptions.SvgImage")));
            this.txtPassworditem.Location = new System.Drawing.Point(0, 108);
            this.txtPassworditem.Name = "txtPassworditem";
            this.txtPassworditem.Size = new System.Drawing.Size(268, 36);
            this.txtPassworditem.Text = "Parola";
            this.txtPassworditem.TextLocation = DevExpress.Utils.Locations.Left;
            this.txtPassworditem.TextSize = new System.Drawing.Size(116, 32);
            // 
            // txtUserNameitem
            // 
            this.txtUserNameitem.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUserNameitem.AppearanceItemCaption.Options.UseFont = true;
            this.txtUserNameitem.Control = this.txtUserName;
            this.txtUserNameitem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtUserNameitem.ImageOptions.SvgImage")));
            this.txtUserNameitem.Location = new System.Drawing.Point(0, 72);
            this.txtUserNameitem.Name = "txtUserNameitem";
            this.txtUserNameitem.Size = new System.Drawing.Size(268, 36);
            this.txtUserNameitem.Text = "Kullanıcı Adı";
            this.txtUserNameitem.TextLocation = DevExpress.Utils.Locations.Left;
            this.txtUserNameitem.TextSize = new System.Drawing.Size(116, 32);
            // 
            // txtInitialCatalogitem
            // 
            this.txtInitialCatalogitem.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtInitialCatalogitem.AppearanceItemCaption.Options.UseFont = true;
            this.txtInitialCatalogitem.Control = this.txtInitialCatalog;
            this.txtInitialCatalogitem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtInitialCatalogitem.ImageOptions.SvgImage")));
            this.txtInitialCatalogitem.Location = new System.Drawing.Point(0, 36);
            this.txtInitialCatalogitem.Name = "txtInitialCatalogitem";
            this.txtInitialCatalogitem.Size = new System.Drawing.Size(268, 36);
            this.txtInitialCatalogitem.Text = "Veritabanı Adı";
            this.txtInitialCatalogitem.TextLocation = DevExpress.Utils.Locations.Left;
            this.txtInitialCatalogitem.TextSize = new System.Drawing.Size(116, 32);
            // 
            // txtDataSourceitem
            // 
            this.txtDataSourceitem.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDataSourceitem.AppearanceItemCaption.Options.UseFont = true;
            this.txtDataSourceitem.Control = this.txtDataSource;
            this.txtDataSourceitem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtDataSourceitem.ImageOptions.SvgImage")));
            this.txtDataSourceitem.Location = new System.Drawing.Point(0, 0);
            this.txtDataSourceitem.Name = "txtDataSourceitem";
            this.txtDataSourceitem.Size = new System.Drawing.Size(268, 36);
            this.txtDataSourceitem.Text = "Sunucu";
            this.txtDataSourceitem.TextLocation = DevExpress.Utils.Locations.Left;
            this.txtDataSourceitem.TextSize = new System.Drawing.Size(116, 32);
            // 
            // chcIntegratedSecurityitem
            // 
            this.chcIntegratedSecurityitem.Control = this.chcIntegratedSecurity;
            this.chcIntegratedSecurityitem.Location = new System.Drawing.Point(0, 144);
            this.chcIntegratedSecurityitem.Name = "chcIntegratedSecurityitem";
            this.chcIntegratedSecurityitem.Size = new System.Drawing.Size(152, 34);
            this.chcIntegratedSecurityitem.TextSize = new System.Drawing.Size(0, 0);
            this.chcIntegratedSecurityitem.TextVisible = false;
            // 
            // panel2item
            // 
            this.panel2item.Control = this.panel2;
            this.panel2item.Location = new System.Drawing.Point(0, 178);
            this.panel2item.Name = "panel2item";
            this.panel2item.Size = new System.Drawing.Size(268, 49);
            this.panel2item.TextSize = new System.Drawing.Size(0, 0);
            this.panel2item.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTmp;
            this.layoutControlItem2.Location = new System.Drawing.Point(152, 144);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(116, 34);
            this.layoutControlItem2.Text = " ";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 247);
            this.Controls.Add(this.SettingsFormlayoutControl1ConvertedLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veritabanı Ayarları";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsFormlayoutControl1ConvertedLayout)).EndInit();
            this.SettingsFormlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTmp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialCatalog.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassworditem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNameitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialCatalogitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataSourceitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcIntegratedSecurityitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtDataSource;
        private DevExpress.XtraEditors.TextEdit txtInitialCatalog;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private System.Windows.Forms.CheckBox chcIntegratedSecurity;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraLayout.LayoutControl SettingsFormlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem txtPassworditem;
        private DevExpress.XtraLayout.LayoutControlItem txtUserNameitem;
        private DevExpress.XtraLayout.LayoutControlItem txtInitialCatalogitem;
        private DevExpress.XtraLayout.LayoutControlItem txtDataSourceitem;
        private DevExpress.XtraLayout.LayoutControlItem chcIntegratedSecurityitem;
        private DevExpress.XtraLayout.LayoutControlItem panel2item;
        private DevExpress.XtraEditors.TextEdit txtTmp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}