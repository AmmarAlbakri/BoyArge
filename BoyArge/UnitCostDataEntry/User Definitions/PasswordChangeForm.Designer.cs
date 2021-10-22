namespace BoyArge
{
    partial class PasswordChangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordChangeForm));
            this.peStrength = new DevExpress.XtraEditors.PictureEdit();
            this.lblPassword2 = new DevExpress.XtraEditors.LabelControl();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.pBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.txtPassword2 = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblState = new DevExpress.XtraEditors.LabelControl();
            this.txtOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblOldPassword = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.peStrength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // peStrength
            // 
            this.peStrength.EditValue = ((object)(resources.GetObject("peStrength.EditValue")));
            this.peStrength.Location = new System.Drawing.Point(12, 168);
            this.peStrength.Name = "peStrength";
            this.peStrength.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peStrength.Properties.Appearance.Options.UseBackColor = true;
            this.peStrength.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peStrength.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.peStrength.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peStrength.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.peStrength.Size = new System.Drawing.Size(23, 19);
            this.peStrength.TabIndex = 6;
            // 
            // lblPassword2
            // 
            this.lblPassword2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPassword2.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
            this.lblPassword2.Appearance.Options.UseFont = true;
            this.lblPassword2.Appearance.Options.UseForeColor = true;
            this.lblPassword2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.lblPassword2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblPassword2.ImageOptions.Image")));
            this.lblPassword2.Location = new System.Drawing.Point(5, 116);
            this.lblPassword2.Name = "lblPassword2";
            this.lblPassword2.Size = new System.Drawing.Size(135, 20);
            this.lblPassword2.TabIndex = 4;
            this.lblPassword2.Text = "Yeni Parola (Tekrar)";
            // 
            // lblPassword
            // 
            this.lblPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPassword.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
            this.lblPassword.Appearance.Options.UseFont = true;
            this.lblPassword.Appearance.Options.UseForeColor = true;
            this.lblPassword.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.lblPassword.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblPassword.ImageOptions.Image")));
            this.lblPassword.Location = new System.Drawing.Point(12, 64);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(84, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Yeni Parola";
            // 
            // pBarControl
            // 
            this.pBarControl.Location = new System.Drawing.Point(12, 193);
            this.pBarControl.Name = "pBarControl";
            this.pBarControl.Properties.Maximum = 3;
            this.pBarControl.Size = new System.Drawing.Size(188, 15);
            this.pBarControl.TabIndex = 8;
            this.pBarControl.EditValueChanged += new System.EventHandler(this.PBarControl_EditValueChanged);
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(12, 142);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPassword2.Properties.Appearance.Options.UseFont = true;
            this.txtPassword2.Properties.PasswordChar = '•';
            this.txtPassword2.Size = new System.Drawing.Size(188, 20);
            this.txtPassword2.TabIndex = 5;
            this.txtPassword2.EditValueChanged += new System.EventHandler(this.TxtPassword2_EditValueChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(188, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.EditValueChanged += new System.EventHandler(this.TxtPassword_EditValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(123, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 32);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(12, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 32);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(42, 171);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(4, 13);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "-";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(12, 38);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOldPassword.Properties.Appearance.Options.UseFont = true;
            this.txtOldPassword.Properties.PasswordChar = '•';
            this.txtOldPassword.Size = new System.Drawing.Size(188, 20);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.EditValueChanged += new System.EventHandler(this.TxtPassword_EditValueChanged);
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOldPassword.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
            this.lblOldPassword.Appearance.Options.UseFont = true;
            this.lblOldPassword.Appearance.Options.UseForeColor = true;
            this.lblOldPassword.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.lblOldPassword.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lblOldPassword.ImageOptions.SvgImage")));
            this.lblOldPassword.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lblOldPassword.Location = new System.Drawing.Point(12, 12);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(102, 20);
            this.lblOldPassword.TabIndex = 0;
            this.lblOldPassword.Text = "Mevcut Parola";
            // 
            // PasswordChangeForm
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 264);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.peStrength);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.lblPassword2);
            this.Controls.Add(this.pBarControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PasswordChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parola Değiştir";
            ((System.ComponentModel.ISupportInitialize)(this.peStrength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lblPassword2;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.ProgressBarControl pBarControl;
        private DevExpress.XtraEditors.TextEdit txtPassword2;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.PictureEdit peStrength;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblState;
        private DevExpress.XtraEditors.TextEdit txtOldPassword;
        private DevExpress.XtraEditors.LabelControl lblOldPassword;
    }
}