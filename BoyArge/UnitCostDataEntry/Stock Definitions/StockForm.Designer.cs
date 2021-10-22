namespace BoyArge
{
    partial class StockForm
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
            this.grdStock = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemStockDataSet = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.itemProductTree = new System.Windows.Forms.ToolStripMenuItem();
            this.grvStock = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdStock)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // grdStock
            // 
            this.grdStock.ContextMenuStrip = this.contextMenuStrip;
            this.grdStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStock.Location = new System.Drawing.Point(0, 0);
            this.grdStock.MainView = this.grvStock;
            this.grdStock.Name = "grdStock";
            this.grdStock.Size = new System.Drawing.Size(800, 450);
            this.grdStock.TabIndex = 0;
            this.grdStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStock});
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemStockDataSet,
            this.itemRecipe,
            this.itemProductTree});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(203, 92);
            // 
            // itemStockDataSet
            // 
            this.itemStockDataSet.Image = global::BoyArge.Properties.Resources.stock;
            this.itemStockDataSet.Name = "itemStockDataSet";
            this.itemStockDataSet.Size = new System.Drawing.Size(202, 22);
            this.itemStockDataSet.Text = "Veri Seti Görüntüle";
            this.itemStockDataSet.Click += new System.EventHandler(this.ItemStockDataSet_Click);
            // 
            // itemRecipe
            // 
            this.itemRecipe.Image = global::BoyArge.Properties.Resources.recipe;
            this.itemRecipe.Name = "itemRecipe";
            this.itemRecipe.Size = new System.Drawing.Size(202, 22);
            this.itemRecipe.Text = "Reçete Görüntüle (CPM)";
            this.itemRecipe.Click += new System.EventHandler(this.ItemRecipe_Click);
            // 
            // itemProductTree
            // 
            this.itemProductTree.Image = global::BoyArge.Properties.Resources.binary_tree;
            this.itemProductTree.Name = "itemProductTree";
            this.itemProductTree.Size = new System.Drawing.Size(202, 22);
            this.itemProductTree.Text = "Maliyet Görüntüle";
            this.itemProductTree.Click += new System.EventHandler(this.ItemProductTree_Click);
            // 
            // grvStock
            // 
            this.grvStock.GridControl = this.grdStock;
            this.grvStock.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Birim", null, "")});
            this.grvStock.Name = "grvStock";
            this.grvStock.OptionsBehavior.Editable = false;
            this.grvStock.OptionsView.ShowAutoFilterRow = true;
            this.grvStock.OptionsView.ShowFooter = true;
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdStock);
            this.Name = "StockForm";
            this.Text = "Malzeme Listesi Ekranı";
            this.Load += new System.EventHandler(this.StockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStock)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdStock;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStock;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem itemStockDataSet;
        private System.Windows.Forms.ToolStripMenuItem itemRecipe;
        private System.Windows.Forms.ToolStripMenuItem itemProductTree;
    }
}