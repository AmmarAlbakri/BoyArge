namespace BoyArge
{
    partial class CurrentAccountForm
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentAccountForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.tileBar = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroupCustomer = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.customersTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarGroup2 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.btnIcPiyasa = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarGroup3 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.btnDisPiyasa = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.grdCurrentAccount = new DevExpress.XtraGrid.GridControl();
            this.grvCurrentAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFirmaTip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCariKod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCariAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDovizCins = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdres = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIlce = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriGrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriTur = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCurrentAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // tileBar
            // 
            this.tileBar.AllowGlyphSkinning = true;
            this.tileBar.AllowSelectedItem = true;
            this.tileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tileBar.AppearanceGroupText.Options.UseForeColor = true;
            this.tileBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tileBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileBar.DropDownButtonWidth = 30;
            this.tileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar.Groups.Add(this.tileBarGroupCustomer);
            this.tileBar.Groups.Add(this.tileBarGroup2);
            this.tileBar.Groups.Add(this.tileBarGroup3);
            this.tileBar.IndentBetweenGroups = 10;
            this.tileBar.IndentBetweenItems = 10;
            this.tileBar.ItemPadding = new System.Windows.Forms.Padding(8, 6, 12, 6);
            this.tileBar.Location = new System.Drawing.Point(0, 0);
            this.tileBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tileBar.MaxId = 5;
            this.tileBar.MaximumSize = new System.Drawing.Size(0, 110);
            this.tileBar.MinimumSize = new System.Drawing.Size(100, 110);
            this.tileBar.Name = "tileBar";
            this.tileBar.Padding = new System.Windows.Forms.Padding(29, 11, 29, 11);
            this.tileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.None;
            this.tileBar.SelectionBorderWidth = 2;
            this.tileBar.SelectionColorMode = DevExpress.XtraBars.Navigation.SelectionColorMode.UseItemBackColor;
            this.tileBar.ShowGroupText = false;
            this.tileBar.Size = new System.Drawing.Size(712, 110);
            this.tileBar.TabIndex = 2;
            this.tileBar.Text = "tileBar";
            this.tileBar.WideTileWidth = 150;
            // 
            // tileBarGroupCustomer
            // 
            this.tileBarGroupCustomer.Items.Add(this.customersTileBarItem);
            this.tileBarGroupCustomer.Name = "tileBarGroupCustomer";
            this.tileBarGroupCustomer.Text = "TABLES";
            // 
            // customersTileBarItem
            // 
            this.customersTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.ImageOptions.ImageUri.Uri = "Cube;Size32x32;GrayScaled";
            tileItemElement1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage")));
            tileItemElement1.Text = "";
            this.customersTileBarItem.Elements.Add(tileItemElement1);
            this.customersTileBarItem.Id = 2;
            this.customersTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Medium;
            this.customersTileBarItem.Name = "customersTileBarItem";
            toolTipTitleItem1.Text = "Tüm Müşteriler";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.customersTileBarItem.SuperTip = superToolTip1;
            this.customersTileBarItem.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.CustomersTileBarItem_ItemClick);
            // 
            // tileBarGroup2
            // 
            this.tileBarGroup2.Items.Add(this.btnIcPiyasa);
            this.tileBarGroup2.Name = "tileBarGroup2";
            // 
            // btnIcPiyasa
            // 
            this.btnIcPiyasa.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.ImageOptions.Image = global::BoyArge.Properties.Resources.TR_64x64;
            tileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement2.Text = "İç Piyasa";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            this.btnIcPiyasa.Elements.Add(tileItemElement2);
            this.btnIcPiyasa.Id = 3;
            this.btnIcPiyasa.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Medium;
            this.btnIcPiyasa.Name = "btnIcPiyasa";
            this.btnIcPiyasa.ShowItemShadow = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem2.Text = "İç Piyasa";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnIcPiyasa.SuperTip = superToolTip2;
            this.btnIcPiyasa.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.BtnIcPiyasa_ItemClick);
            // 
            // tileBarGroup3
            // 
            this.tileBarGroup3.Items.Add(this.btnDisPiyasa);
            this.tileBarGroup3.Name = "tileBarGroup3";
            // 
            // btnDisPiyasa
            // 
            this.btnDisPiyasa.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage1")));
            tileItemElement3.Text = "Dış Piyasa";
            this.btnDisPiyasa.Elements.Add(tileItemElement3);
            this.btnDisPiyasa.Id = 4;
            this.btnDisPiyasa.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Medium;
            this.btnDisPiyasa.Name = "btnDisPiyasa";
            this.btnDisPiyasa.ShowItemShadow = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem3.Text = "Dış Piyasa";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnDisPiyasa.SuperTip = superToolTip3;
            this.btnDisPiyasa.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.BtnDisPiyasa_ItemClick);
            // 
            // grdCurrentAccount
            // 
            this.grdCurrentAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCurrentAccount.Location = new System.Drawing.Point(0, 110);
            this.grdCurrentAccount.MainView = this.grvCurrentAccount;
            this.grdCurrentAccount.Name = "grdCurrentAccount";
            this.grdCurrentAccount.Size = new System.Drawing.Size(712, 344);
            this.grdCurrentAccount.TabIndex = 4;
            this.grdCurrentAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCurrentAccount});
            // 
            // grvCurrentAccount
            // 
            this.grvCurrentAccount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFirmaTip,
            this.colCariKod,
            this.colCariAd,
            this.colDovizCins,
            this.colAdres,
            this.colIlce,
            this.colIl,
            this.colEmail,
            this.colMusteriGrup,
            this.colMusteriTur});
            this.grvCurrentAccount.GridControl = this.grdCurrentAccount;
            this.grvCurrentAccount.Name = "grvCurrentAccount";
            this.grvCurrentAccount.OptionsBehavior.Editable = false;
            this.grvCurrentAccount.OptionsView.ShowAutoFilterRow = true;
            // 
            // colFirmaTip
            // 
            this.colFirmaTip.Caption = "Firma Tipi";
            this.colFirmaTip.FieldName = "FirmaTip";
            this.colFirmaTip.Name = "colFirmaTip";
            this.colFirmaTip.Visible = true;
            this.colFirmaTip.VisibleIndex = 0;
            // 
            // colCariKod
            // 
            this.colCariKod.Caption = "Müşteri Kodu";
            this.colCariKod.FieldName = "CariKod";
            this.colCariKod.Name = "colCariKod";
            this.colCariKod.Visible = true;
            this.colCariKod.VisibleIndex = 1;
            // 
            // colCariAd
            // 
            this.colCariAd.Caption = "Müşteri Adı";
            this.colCariAd.FieldName = "CariAd";
            this.colCariAd.Name = "colCariAd";
            this.colCariAd.Visible = true;
            this.colCariAd.VisibleIndex = 2;
            // 
            // colDovizCins
            // 
            this.colDovizCins.Caption = "Döviz Cinsi";
            this.colDovizCins.FieldName = "DovizCins";
            this.colDovizCins.Name = "colDovizCins";
            this.colDovizCins.Visible = true;
            this.colDovizCins.VisibleIndex = 3;
            // 
            // colAdres
            // 
            this.colAdres.Caption = "Adres";
            this.colAdres.FieldName = "Adres";
            this.colAdres.Name = "colAdres";
            this.colAdres.Visible = true;
            this.colAdres.VisibleIndex = 4;
            // 
            // colIlce
            // 
            this.colIlce.Caption = "İlçe";
            this.colIlce.FieldName = "Ilce";
            this.colIlce.Name = "colIlce";
            this.colIlce.Visible = true;
            this.colIlce.VisibleIndex = 5;
            // 
            // colIl
            // 
            this.colIl.Caption = "İl";
            this.colIl.FieldName = "Il";
            this.colIl.Name = "colIl";
            this.colIl.Visible = true;
            this.colIl.VisibleIndex = 6;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "E-posta";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 7;
            // 
            // colMusteriGrup
            // 
            this.colMusteriGrup.Caption = "Müşteri Grup";
            this.colMusteriGrup.FieldName = "MusteriGrup";
            this.colMusteriGrup.Name = "colMusteriGrup";
            this.colMusteriGrup.Visible = true;
            this.colMusteriGrup.VisibleIndex = 8;
            // 
            // colMusteriTur
            // 
            this.colMusteriTur.Caption = "Müşteri Tür";
            this.colMusteriTur.FieldName = "MusteriTur";
            this.colMusteriTur.Name = "colMusteriTur";
            this.colMusteriTur.Visible = true;
            this.colMusteriTur.VisibleIndex = 9;
            // 
            // CurrentAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 454);
            this.Controls.Add(this.grdCurrentAccount);
            this.Controls.Add(this.tileBar);
            this.Name = "CurrentAccountForm";
            this.Text = "Müşteri Tanımı";
            this.Load += new System.EventHandler(this.CurrentAccountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCurrentAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileBar tileBar;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroupCustomer;
        private DevExpress.XtraBars.Navigation.TileBarItem customersTileBarItem;
        private DevExpress.XtraGrid.GridControl grdCurrentAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCurrentAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colFirmaTip;
        private DevExpress.XtraGrid.Columns.GridColumn colCariKod;
        private DevExpress.XtraGrid.Columns.GridColumn colCariAd;
        private DevExpress.XtraGrid.Columns.GridColumn colDovizCins;
        private DevExpress.XtraGrid.Columns.GridColumn colAdres;
        private DevExpress.XtraGrid.Columns.GridColumn colIlce;
        private DevExpress.XtraGrid.Columns.GridColumn colIl;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriGrup;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriTur;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup2;
        private DevExpress.XtraBars.Navigation.TileBarItem btnIcPiyasa;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup3;
        private DevExpress.XtraBars.Navigation.TileBarItem btnDisPiyasa;
    }
}