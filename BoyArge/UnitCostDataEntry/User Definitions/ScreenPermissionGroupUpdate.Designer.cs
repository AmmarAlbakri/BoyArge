
namespace BoyArge
{
    partial class ScreenPermissionGroupUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenPermissionGroupUpdate));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.PermissionTypeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.chkPermission = new System.Windows.Forms.CheckBox();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ModuleLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.UserNameLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForModule = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PermissionTypeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.PermissionTypeLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.chkPermission);
            this.dataLayoutControl1.Controls.Add(this.btnAccept);
            this.dataLayoutControl1.Controls.Add(this.btnCancel);
            this.dataLayoutControl1.Controls.Add(this.ModuleLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.UserNameLookUpEdit);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(551, 79, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(298, 156);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // PermissionTypeLookUpEdit
            // 
            this.PermissionTypeLookUpEdit.Location = new System.Drawing.Point(111, 84);
            this.PermissionTypeLookUpEdit.Name = "PermissionTypeLookUpEdit";
            this.PermissionTypeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PermissionTypeLookUpEdit.Size = new System.Drawing.Size(175, 20);
            this.PermissionTypeLookUpEdit.StyleController = this.dataLayoutControl1;
            this.PermissionTypeLookUpEdit.TabIndex = 21;
            // 
            // chkPermission
            // 
            this.chkPermission.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPermission.Location = new System.Drawing.Point(12, 60);
            this.chkPermission.Name = "chkPermission";
            this.chkPermission.Size = new System.Drawing.Size(274, 20);
            this.chkPermission.TabIndex = 20;
            this.chkPermission.Text = "Yetki Durumu";
            this.chkPermission.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAccept.Appearance.Options.UseFont = true;
            this.btnAccept.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAccept.ImageOptions.SvgImage")));
            this.btnAccept.Location = new System.Drawing.Point(12, 108);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(135, 36);
            this.btnAccept.StyleController = this.dataLayoutControl1;
            this.btnAccept.TabIndex = 18;
            this.btnAccept.Text = "Güncelle";
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(151, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 36);
            this.btnCancel.StyleController = this.dataLayoutControl1;
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ModuleLookUpEdit
            // 
            this.ModuleLookUpEdit.Location = new System.Drawing.Point(107, 12);
            this.ModuleLookUpEdit.Name = "ModuleLookUpEdit";
            this.ModuleLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ModuleLookUpEdit.Properties.NullText = "";
            this.ModuleLookUpEdit.Size = new System.Drawing.Size(179, 20);
            this.ModuleLookUpEdit.StyleController = this.dataLayoutControl1;
            this.ModuleLookUpEdit.TabIndex = 5;
            // 
            // UserNameLookUpEdit
            // 
            this.UserNameLookUpEdit.Location = new System.Drawing.Point(107, 36);
            this.UserNameLookUpEdit.Name = "UserNameLookUpEdit";
            this.UserNameLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UserNameLookUpEdit.Properties.DisplayMember = "UserName";
            this.UserNameLookUpEdit.Properties.NullText = "";
            this.UserNameLookUpEdit.Properties.ValueMember = "UserID";
            this.UserNameLookUpEdit.Size = new System.Drawing.Size(179, 20);
            this.UserNameLookUpEdit.StyleController = this.dataLayoutControl1;
            this.UserNameLookUpEdit.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(298, 156);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForModule,
            this.ItemForUserName});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(278, 48);
            // 
            // ItemForModule
            // 
            this.ItemForModule.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ItemForModule.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForModule.Control = this.ModuleLookUpEdit;
            this.ItemForModule.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ItemForModule.ImageOptions.SvgImage")));
            this.ItemForModule.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.ItemForModule.Location = new System.Drawing.Point(0, 0);
            this.ItemForModule.Name = "ItemForModule";
            this.ItemForModule.Size = new System.Drawing.Size(278, 24);
            this.ItemForModule.Text = "Modül";
            this.ItemForModule.TextSize = new System.Drawing.Size(92, 20);
            // 
            // ItemForUserName
            // 
            this.ItemForUserName.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ItemForUserName.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForUserName.Control = this.UserNameLookUpEdit;
            this.ItemForUserName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ItemForUserName.ImageOptions.SvgImage")));
            this.ItemForUserName.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.ItemForUserName.Location = new System.Drawing.Point(0, 24);
            this.ItemForUserName.Name = "ItemForUserName";
            this.ItemForUserName.Size = new System.Drawing.Size(278, 24);
            this.ItemForUserName.Text = "Kullanıcı Adı";
            this.ItemForUserName.TextSize = new System.Drawing.Size(92, 20);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.ContentVertAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(139, 96);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(139, 40);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.ContentVertAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.layoutControlItem1.Control = this.btnAccept;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(139, 40);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkPermission;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(278, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.PermissionTypeLookUpEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(278, 24);
            this.layoutControlItem4.Text = "Yetki Tipi";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(92, 13);
            // 
            // ScreenPermissionGroupUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 156);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "ScreenPermissionGroupUpdate";
            this.Text = "Toplu Yetki Güncelleme Ekranı";
            this.Load += new System.EventHandler(this.ScreenPermissionGroupUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PermissionTypeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.LookUpEdit ModuleLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit UserNameLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModule;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserName;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit PermissionTypeLookUpEdit;
        private System.Windows.Forms.CheckBox chkPermission;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}