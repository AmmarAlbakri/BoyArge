namespace BoyArge
{
    partial class RecipeForm
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
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSeviyeTuru = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUretimYeri = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAnaSeviye = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSeviye = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colReceteNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBoyamaIslemi = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMalzemeKodu = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMalzemeAdi = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRenkKodu = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRenkAdi = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMiktar = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFire = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList
            // 
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colID,
            this.colSeviyeTuru,
            this.colUretimYeri,
            this.colAnaSeviye,
            this.colSeviye,
            this.colReceteNo,
            this.colBoyamaIslemi,
            this.colMalzemeKodu,
            this.colMalzemeAdi,
            this.colRenkKodu,
            this.colRenkAdi,
            this.colMiktar,
            this.colFire});
            this.treeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.HierarchyColumn = this.colSeviyeTuru;
            this.treeList.HierarchyFieldName = "Seviye Türü";
            this.treeList.KeyFieldName = "Seviye";
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.EditorShowMode = DevExpress.XtraTreeList.TreeListEditorShowMode.MouseUp;
            this.treeList.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.treeList.OptionsMenu.ShowFooterItem = true;
            this.treeList.OptionsView.AllowGlyphSkinning = true;
            this.treeList.OptionsView.NewItemRowPosition = DevExpress.XtraTreeList.TreeListNewItemRowPosition.Bottom;
            this.treeList.OptionsView.ShowAutoFilterRow = true;
            this.treeList.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways;
            this.treeList.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList.OptionsView.ShowRowFooterSummary = true;
            this.treeList.OptionsView.ShowSummaryFooter = true;
            this.treeList.ParentFieldName = "Ana Seviye";
            this.treeList.Size = new System.Drawing.Size(666, 318);
            this.treeList.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            // 
            // colSeviyeTuru
            // 
            this.colSeviyeTuru.Caption = "Seviye Türü";
            this.colSeviyeTuru.FieldName = "Seviye Türü";
            this.colSeviyeTuru.Name = "colSeviyeTuru";
            this.colSeviyeTuru.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colSeviyeTuru.Visible = true;
            this.colSeviyeTuru.VisibleIndex = 0;
            this.colSeviyeTuru.Width = 76;
            // 
            // colUretimYeri
            // 
            this.colUretimYeri.Caption = "Üretim Yeri";
            this.colUretimYeri.FieldName = "Üretim Yeri";
            this.colUretimYeri.Name = "colUretimYeri";
            this.colUretimYeri.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colUretimYeri.Visible = true;
            this.colUretimYeri.VisibleIndex = 1;
            this.colUretimYeri.Width = 70;
            // 
            // colAnaSeviye
            // 
            this.colAnaSeviye.Caption = "Ana Seviye";
            this.colAnaSeviye.FieldName = "Ana Seviye";
            this.colAnaSeviye.Name = "colAnaSeviye";
            this.colAnaSeviye.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            // 
            // colSeviye
            // 
            this.colSeviye.Caption = "Seviye";
            this.colSeviye.FieldName = "Seviye";
            this.colSeviye.Name = "colSeviye";
            this.colSeviye.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            // 
            // colReceteNo
            // 
            this.colReceteNo.Caption = "Reçete No";
            this.colReceteNo.FieldName = "Reçete No";
            this.colReceteNo.Name = "colReceteNo";
            this.colReceteNo.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            // 
            // colBoyamaIslemi
            // 
            this.colBoyamaIslemi.Caption = "Boyama İşlemi";
            this.colBoyamaIslemi.FieldName = "Boyama İşlemi";
            this.colBoyamaIslemi.Name = "colBoyamaIslemi";
            this.colBoyamaIslemi.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colBoyamaIslemi.Visible = true;
            this.colBoyamaIslemi.VisibleIndex = 2;
            this.colBoyamaIslemi.Width = 85;
            // 
            // colMalzemeKodu
            // 
            this.colMalzemeKodu.Caption = "Malzeme Kodu";
            this.colMalzemeKodu.FieldName = "Malzeme Kodu";
            this.colMalzemeKodu.Name = "colMalzemeKodu";
            this.colMalzemeKodu.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colMalzemeKodu.Visible = true;
            this.colMalzemeKodu.VisibleIndex = 3;
            this.colMalzemeKodu.Width = 88;
            // 
            // colMalzemeAdi
            // 
            this.colMalzemeAdi.Caption = "Malzeme Adı";
            this.colMalzemeAdi.FieldName = "Malzeme Adı";
            this.colMalzemeAdi.Name = "colMalzemeAdi";
            this.colMalzemeAdi.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colMalzemeAdi.Visible = true;
            this.colMalzemeAdi.VisibleIndex = 4;
            this.colMalzemeAdi.Width = 78;
            // 
            // colRenkKodu
            // 
            this.colRenkKodu.Caption = "Renk Kodu";
            this.colRenkKodu.FieldName = "Renk Kodu";
            this.colRenkKodu.Name = "colRenkKodu";
            this.colRenkKodu.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colRenkKodu.Visible = true;
            this.colRenkKodu.VisibleIndex = 5;
            this.colRenkKodu.Width = 72;
            // 
            // colRenkAdi
            // 
            this.colRenkAdi.Caption = "Renk Adı";
            this.colRenkAdi.FieldName = "Renk Adı";
            this.colRenkAdi.Name = "colRenkAdi";
            this.colRenkAdi.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colRenkAdi.Visible = true;
            this.colRenkAdi.VisibleIndex = 6;
            this.colRenkAdi.Width = 62;
            // 
            // colMiktar
            // 
            this.colMiktar.Caption = "Miktar(%)";
            this.colMiktar.FieldName = "Miktar(%)";
            this.colMiktar.Name = "colMiktar";
            this.colMiktar.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colMiktar.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.colMiktar.Visible = true;
            this.colMiktar.VisibleIndex = 7;
            this.colMiktar.Width = 61;
            // 
            // colFire
            // 
            this.colFire.Caption = "Fire(%)";
            this.colFire.FieldName = "Fire(%)";
            this.colFire.Name = "colFire";
            this.colFire.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colFire.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.colFire.Visible = true;
            this.colFire.VisibleIndex = 8;
            this.colFire.Width = 49;
            // 
            // RecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 318);
            this.Controls.Add(this.treeList);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.Name = "RecipeForm";
            this.Text = "Mamül Reçetesi";
            this.Load += new System.EventHandler(this.RecipeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUretimYeri;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAnaSeviye;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSeviye;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colReceteNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBoyamaIslemi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSeviyeTuru;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRenkAdi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRenkKodu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMalzemeKodu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMalzemeAdi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMiktar;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFire;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}