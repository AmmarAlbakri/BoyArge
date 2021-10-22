using BoyArge.Properties;
using Business;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class CalculateForm : RibbonForm
    {
        #region Definitions

        private DataTable _dStock;
        //private DataTable _dGroupUnitCost;
        //private DataTable _dProcessUnitCost;

        private readonly Stock _stock = new Stock();
        private readonly ProductTree _productTree = new ProductTree(LoginForm.DataConnection);
        private readonly ProductTreeFiche _productTreeFiche = new ProductTreeFiche(LoginForm.DataConnection);
        private TreeListNode _rootNode = new TreeListNode();

        public enum IconType
        {
            Save = 0,
            Update = 1
        }

        public long ProductTreeId { get; set; }
        public long ProductTreeFicheId { get; set; }
        public string CpmStockCode { get; set; }
        public string FicheGuid
        {
            get
            {
                if (lookProductTreeFiche.EditValue != null)
                    return lookProductTreeFiche.EditValue.ToString();
                return "";
            }
            set
            {
                if (value != null)
                    lookProductTreeFiche.EditValue = value;
                else
                    lookProductTreeFiche.EditValue = null;
            }
        }
        public string FicheRowGuid { get; set; }
        #endregion

        #region Events
        public CalculateForm()
        {
            InitializeComponent();
        }
        private void CalculateForm_Load(object sender, EventArgs e)
        {
            _dStock = _stock.GetList();
            Format.LookUpEdit(lookMainProduct, new[] { "Code", "Name" }, "Name", "Code", _dStock);

            dateEdit.EditValue = DateTime.Now.Date;

            if (Tag != null)
            {
                //lookMainProduct.EditValue = Tag.ToString();
                //lookMainProduct.Enabled = false;
                //this.btnAddProduct.Enabled = false;
            }

            LoadSource();

            var (item1, item2, item3) = ExchangeType.GetCurrency(LoginForm.DataConnection);

            spinUSD.EditValue = item1;
            spinEUR.EditValue = item2;
            spinGBP.EditValue = item3;

            this.groupControlProductTree.CustomHeaderButtons[0].Properties.Enabled = false;
            this.lookCPMOrder.Enabled = true;
            this.lookProduct.Enabled = false;

            this.ribbonControl.Minimized = true;



        }

        private void LookStockFeatureTypeID_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                this.NewStockFeatureType();
            }
        }

        private void TreeList_RowClick(object sender, RowClickEventArgs e)
        {
            //this.BindingDataSource(Utility.ToLong(treeList.FocusedNode.GetValue(colStockGroupID)));
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            //** 0 yeni ürün, 1 mamül ürün, 2 sipariş ürün ** //

            if (radioGroup1.EditValue.ToString() == "0")
            {

                this.groupControlProductTree.CustomHeaderButtons[0].Properties.Enabled = true;
                this.lookCPMOrder.Enabled = false;
                this.lookProduct.Enabled = true;

                txtCode1.Text = "";
                txtCode2.Text = "";
            }

            else if (radioGroup1.EditValue.ToString() == "1")
            {

                this.groupControlProductTree.CustomHeaderButtons[0].Properties.Enabled = false;
                this.lookCPMOrder.Enabled = true;
                this.lookProduct.Enabled = false;
            }

            else if (radioGroup1.EditValue.ToString() == "2")
            {

                this.groupControlProductTree.CustomHeaderButtons[0].Properties.Enabled = false;
                this.lookCPMOrder.Enabled = true;
                this.lookProduct.Enabled = false;
            }
            RunFunctionWithTimer(5, "LoadSource");
            ClearList();
            //LoadSource();
            //if (lookMainProduct.EditValue == null) return;
            //if (Utility.ToInt32(lookStockFeatureTypeID.EditValue) <= 0) return;
            //this.RunFunctionWithTimer(15, "RefreshList");
        }

        private void TabControl_CustomHeaderButtonClick(object sender, CustomHeaderButtonEventArgs e)
        {
            if (e.Button.Caption == "Tümünü Gör")
            {
                //RunFunctionWithTimer(30, "ViewAll");
            }
        }

        private void TreeList_DoubleClick(object sender, EventArgs e)
        {
            //if (treeList.FocusedNode != null)
            //BindingDataSource(Utility.ToLong(treeList.FocusedNode.GetValue(colStockGroupID)));
        }

        private void GroupControlProductTree_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Ana Ürün Ekle":
                    CreateRootNode();
                    break;
                case "Alt Ürün Ekle":
                    CreateNode(treeList.FocusedNode, 1);
                    break;
                case "Hammadde Ekle":
                    CreateNode(treeList.FocusedNode, 2);
                    break;
                case "Sil":
                    DeleteNode(treeList.FocusedNode);
                    break;
                case "Hesapla":
                    if (!CheckControl())
                        break;
                    Calculate();
                    //RunFunctionWithTimer(25,"Calculate");                    
                    break;
                case "Bul":
                    //this.RefreshList();
                    //LoadTreeList();
                    break;
                case "Genişlet":
                    treeList.ExpandAll();
                    break;
                case "Daralt":
                    treeList.CollapseAll();
                    break;
                case "Ağacı Sıfırla":
                    LoadTreeList(); 
                    break;
                case "Sıfırla":
                    ClearList();
                    break;
                case "Fiş Sil":
                    DeleteFiche();
                    break;
                case "Birim Fiyatları":
                    UnitPriceForm form = new UnitPriceForm();
                    form.Show();
                    break;
                case "Kimyasal Reçete":
                    ChemicalRecipeForm form2 = new ChemicalRecipeForm();
                    form2.Show();
                    break;
                case "Kimyasal Reçete İzleyici":
                    ReceiptForm form3 = new ReceiptForm();
                    form3.Show();
                    break;
            }
        }

        private void LookProductTreeFiche_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
                ClearList();
        }

        private void BtnFicheLoad_Click(object sender, EventArgs e)
        {

        }

        private void LookMainProduct_EditValueChanged(object sender, EventArgs e)
        {
            if (lookMainProduct.EditValue == null) return;

            DataRow row;
            try
            {
                if (Utility.ToDecimal(spinRingBobinNr.EditValue) * Utility.ToDecimal(spinBukumNr.EditValue) *
                    Utility.ToDecimal(spinFinalNr.EditValue) == 0)
                {
                    row = Database.GetRow(
                        $"SELECT [RingBobinNr], [BukumNr], [FinalNr] FROM tblStockFeature('{lookMainProduct.EditValue}')",
                        LoginForm.DataConnection);

                    if (row != null)
                    {
                        spinRingBobinNr.EditValue = row["RingBobinNr"];
                        spinBukumNr.EditValue = row["BukumNr"];
                        spinFinalNr.EditValue = row["FinalNr"];
                    }
                    else
                    {
                        spinRingBobinNr.EditValue = spinBukumNr.EditValue = spinFinalNr.EditValue = null;
                    }
                }

                row = Database.GetRow(
                    $"SELECT [İplik Katı], [İplik Tip-1-geçici],[İplik Görünüm],[İplik Efekt+Özellik],[İplik Özelliği] FROM [dbo].[VW_STOCK] WHERE [StockCode] = '{lookMainProduct.EditValue}'",
                    LoginForm.DataConnection);

                if (row != null)
                {
                    txtNfold.Text = row["İplik Katı"].ToString();
                    lookUretimTipi.EditValue = row["İplik Tip-1-geçici"];
                    lookUrunOzellik.EditValue = row["İplik Özelliği"];
                    lookUrunEfekt.EditValue = row["İplik Efekt+Özellik"];
                    lookUrunGorunum.EditValue = row["İplik Görünüm"];
                }
                else
                {
                    txtNfold.Text = string.Empty;
                }


                if (lookMainProduct.EditValue == null) return;
                using (var dStockFeatureType = StockFeatureType.Select(lookMainProduct.EditValue.ToString(),
                    (byte)StockFeatureType.Status.Active, LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookStockFeatureTypeID,
                        new[] { "StockCode", "Name", "MachineGroup1", "MachineGroup2", "MachineGroup3", "MachineGroup4" },
                        "Name", "StockFeatureTypeID", dStockFeatureType);
                }
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LookStockFeatureTypeID_EditValueChanged(object sender, EventArgs e)
        {
            //if (this.lookStockFeatureTypeID.EditValue == null) return;
            //this.RefreshList();
        }

        private void SpinEditOrderAmount_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinEditOrderAmount.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinShiftDayCount_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinShiftDayCount.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinPersonelDayCount_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinPersonelDayCount.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinPersonelHour_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinPersonelHour.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinShiftCount_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinShiftCount.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinRingBobinNr_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinRingBobinNr.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinFinalNr_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinFinalNr.EditValue) < 0)
                e.Cancel = true;
        }

        private void SpinBukumNr_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(spinBukumNr.EditValue) < 0)
                e.Cancel = true;
        }

        private void TxtNfold_Validating(object sender, CancelEventArgs e)
        {
            if (Utility.ToDecimal(txtNfold.EditValue) < 0)
                e.Cancel = true;
        }

        private void GrvAnnualDepartmentExpenseRelation_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            colDepartment.FilterInfo = new ColumnFilterInfo(colDepartment,
                grvAnnualDepartmentExpenseRelation.GetRowCellValue(e.FocusedRowHandle, colADDepartment));
        }

        private void LcGroupCPM_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            GridViewerForm fGridViewer = new GridViewerForm();

            try
            {
                fGridViewer.Seconds = 15;
                fGridViewer.Data = this.grdCPMOrder.DataSource;
                fGridViewer.StartPosition = FormStartPosition.CenterScreen;
                fGridViewer.WindowState = FormWindowState.Maximized;
                fGridViewer.ShowDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                fGridViewer.Dispose();
            }
        }

        private void lookCPMOrder_EditValueChanged(object sender, EventArgs e)
        {
            if (lookCPMOrder.EditValue != null)
            {
                lookProduct.Enabled = true;
                lookMainProduct.Enabled = false;

                groupControlProductTree.CustomHeaderButtons[0].Properties.Enabled = false;
                groupControlProductTree.CustomHeaderButtons[1].Properties.Enabled = true;
                groupControlProductTree.CustomHeaderButtons[2].Properties.Enabled = true;
                groupControlProductTree.CustomHeaderButtons[3].Properties.Enabled = true;
                groupControlProductTree.CustomHeaderButtons[9].Properties.Enabled = false;


                lookProductTreeFiche.EditValue = null;
                treeList.DataSource = null;
                try
                {
                    LoadTreeList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //ClearList();

            //ProductTree.Select(ProductTreeFicheId, lookMainProduct.EditValue.ToString(), Utility.ToInt32(lookStockFeatureTypeID.EditValue), (byte)ProductTree.Status.Active, LoginForm.DataConnection);
        }

        private void lookProductTreeFiche_EditValueChanged(object sender, EventArgs e)
        {
            if (lookProductTreeFiche.EditValue != null)
            {
                lookProduct.Enabled = false;
                lookMainProduct.Enabled = false;
                lookMainProduct.Enabled = groupControlProductTree.CustomHeaderButtons[0].Properties.Enabled = false;
                lookMainProduct.Enabled = groupControlProductTree.CustomHeaderButtons[1].Properties.Enabled = false;
                lookMainProduct.Enabled = groupControlProductTree.CustomHeaderButtons[2].Properties.Enabled = false;
                lookMainProduct.Enabled = groupControlProductTree.CustomHeaderButtons[3].Properties.Enabled = false;

                groupControlProductTree.CustomHeaderButtons[9].Properties.Enabled = true;


                lookCPMOrder.EditValue = null;
                treeList.DataSource = null;
                LoadFiche();
                //RunFunctionWithTimer(20, "PrintResult");
            }
        }
        private void lookStockCode_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit textEditor = (LookUpEdit)sender;

            treeList.FocusedNode.SetValue(colStockName, getStockNameByCode(textEditor.EditValue.ToString()));
        }
        #endregion

        #region Functions

        private void CreateRootNode()
        {
            if (lookMainProduct.EditValue == null || lookMainProduct.EditValue.ToString() == "") return;

            treeList.DataSource = Database.GetList("SELECT tblProductTree.*,'---' as StockName FROM tblProductTree WHERE 1 = 0", LoginForm.DataConnection);


            treeList.BeginUnboundLoad();

            _rootNode = treeList.AppendNode(null, null);

            _rootNode.SetValue(colProductTreeID, 0);
            _rootNode.SetValue(colStockGroupID, 0);
            _rootNode.SetValue(colParentID, 0);
            _rootNode.SetValue(colLevel, 1);
            _rootNode.SetValue(colDate, DateTime.Now);
            _rootNode.SetValue(colLevelType, 0);
            _rootNode.SetValue(colZoneID, -1);
            _rootNode.SetValue(colDyeProcess, -1);
            _rootNode.SetValue(colStockCode, lookMainProduct.EditValue.ToString());
            _rootNode.SetValue(colStockName, getStockNameByCode(lookMainProduct.EditValue.ToString())); // @MiA DÜZELTİLTİ 11.07.2021 
            _rootNode.SetValue(colColorType, -1);
            _rootNode.SetValue(colAmount, 100);
            _rootNode.SetValue(colWastage, 0);
            _rootNode.SetValue(colProductTreeIndex, 0);
            //rootNode.SetValue(colPrice, 0);
            _rootNode.SetValue(colStatus, (short)ProductTree.Status.Active);
            //_rootNode.SetValue(colRowGUID, Guid.Empty);
            _rootNode.SetValue(colTotal, 0);
            //rootNode.SetValue(colCalculatedWorkerCount, 0);
            //rootNode.SetValue(colCalculatedMachineCount, 0);
            _rootNode.SetValue(colNFold, 0);
            _rootNode.SetValue(colTouchness, 0);
            _rootNode.SetValue(colFeature, 0);
            //rootNode.SetValue(colCalculatedBottleNeck, 0);
            //rootNode.SetValue(colDGZ, 0);
            //rootNode.SetValue(colELK, 0);
            //rootNode.SetValue(colWater, 0);

            treeList.EndUnboundLoad();
            treeList.Refresh();
            treeList.RefreshDataSource();
            
            lookMainProduct.Enabled = false;

            
        }

        private void CreateNode(TreeListNode rootNode, int levelType)
        {
            if (lookProduct.EditValue == null || lookProduct.EditValue.ToString() == string.Empty ||
                rootNode == null) return;

            treeList.BeginUnboundLoad();
            var node = treeList.AppendNode(null, rootNode);

            node.SetValue(colProductTreeID, 0);
            node.SetValue(colStockGroupID, 0);
            node.SetValue(colParentID, rootNode.GetValue(colLevel));
            node.SetValue(colLevel, treeList.AllNodesCount);
            node.SetValue(colDate, DateTime.Now);
            node.SetValue(colLevelType, levelType);
            node.SetValue(colZoneID, -1);
            node.SetValue(colDyeProcess, -1);
            node.SetValue(colStockCode, lookProduct.EditValue);
            node.SetValue(colStockName,getStockNameByCode(lookProduct.EditValue.ToString()));
            node.SetValue(colColorType, -1);
            node.SetValue(colAmount, 0);
            node.SetValue(colWastage, 0);
            node.SetValue(colProductTreeIndex, 0);
            node.SetValue(colStatus, (short)ProductTree.Status.Active);
            //node.SetValue(colRowGUID, "");
            node.SetValue(colTotal, 0);
            node.SetValue(colNFold, 0);
            node.SetValue(colTouchness, 0);
            node.SetValue(colFeature, 0);


            treeList.EndUnboundLoad();
            treeList.Refresh();
            treeList.RefreshDataSource();
        }

        private void ClearList()
        {
            try
            {
                treeList.DataSource = null;

                grdAnnualCosts.DataSource = null;
                grdAnnualDepartmentExpenseRelation.DataSource = null;
                grdChemical.DataSource = null;
                grdGroupUnitCost.DataSource = null;
                grdIndirectExpense.DataSource = null;
                grdInvoiceExpense.DataSource = null;
                grdProcessUnitCost.DataSource = null;
                grdProductUnitCost.DataSource = null;
                grdWorkerExpense.DataSource = null;
                //grdWorkExpenseGroup.DataSource = null;
                lookProductTreeFiche.EditValue = null;
                lookCPMOrder.EditValue = null;
                lookProductTreeFiche.EditValue = null;
                lookMainProduct.EditValue = null;
                lookStockFeatureTypeID.Properties.DataSource = DBNull.Value;
                lookProduct.EditValue = null;
                lookDyeType.EditValue = null;
                lookPackageType.EditValue = null;
                lookPaymentDate.EditValue = null;
                lookDeliveryType.EditValue = null;
                lookCapacityType.EditValue = null;
                lookOrderType.EditValue = null;
                ucUnitCost1.UnitCost = 0;
                ucUnitCost1.BottleNeck = 0;

                // FicheGuid = FicheRowGuid = 
                txtCode1.Text = txtCode2.Text = string.Empty;

                spinEditOrderAmount.EditValue = spinEditCode3.EditValue = 0;
                ProductTreeFicheId = ProductTreeId = 0;
                if (radioGroup1.EditValue.ToString() == "0")
                {
                    lookMainProduct.Enabled = true;
                    this.groupControlProductTree.CustomHeaderButtons[0].Properties.Enabled = true;
                    this.groupControlProductTree.CustomHeaderButtons[1].Properties.Enabled = true;
                    this.groupControlProductTree.CustomHeaderButtons[2].Properties.Enabled = true;
                    this.groupControlProductTree.CustomHeaderButtons[3].Properties.Enabled = true;
                }
                else
                {
                    lookMainProduct.Enabled = false;
                    this.groupControlProductTree.CustomHeaderButtons[0].Properties.Enabled = false;
                    this.groupControlProductTree.CustomHeaderButtons[1].Properties.Enabled = true;
                    this.groupControlProductTree.CustomHeaderButtons[2].Properties.Enabled = true;
                    this.groupControlProductTree.CustomHeaderButtons[3].Properties.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DeleteNode(TreeListNode node)
        {
            if ((DataTable)treeList.DataSource == null || ((DataTable)treeList.DataSource).Rows.Count == 0) return;

            if (node == null) return;

            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (!Database.CheckConnection(LoginForm.DataConnection))
                XtraMessageBox.Show(Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            try
            {
                node.Remove();
                //DeleteChildNodes(node);

                // var result = _productTree.Delete(Utility.ToLong(node.GetValue(colProductTreeID)));

                //RunFunctionWithTimer(15, "RefreshList");

                //if (result <= 0)
                //    XtraMessageBox.Show(Resources.DeleteError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //else
                //    XtraMessageBox.Show(Resources.DeleteInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void DeleteChildNodes(TreeListNode node)
        {
            try
            {
                TreeListNodes subNodes = node.Nodes;
                foreach (TreeListNode subNode in subNodes)
                {
                    if (subNode.HasChildren)
                        DeleteChildNodes(subNode);
                    else
                    {
                        //((DataTable)treeList.DataSource).Rows.Remove(((DataTable)treeList.DataSource).Rows[subNode.Id]);
                        node.Nodes.Remove(subNode);
                    }


                    //if (Utility.ToLong(subNode.GetValue("ProductTreeID")) > 0)
                    //    _productTree.Delete(Utility.ToLong(subNode.GetValue("ProductTreeID")));
                }

                //((DataTable)treeList.DataSource).Rows.Remove(((DataTable)treeList.DataSource).Rows[node.Id]);
                node.Remove();

            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadTreeList()
        {
            DataRowView rowCPMOrder = (DataRowView)lookCPMOrder.GetSelectedDataRow();

            if (radioGroup1.EditValue.ToString() == "0")
            {
                GetArgeProductTree(Utility.ToInt32(lookProductTreeFiche.EditValue));
            }


            else if (radioGroup1.EditValue.ToString() == "1")
            {
                if (rowCPMOrder != null)
                {
                    treeList.DataSource = ProductTree.GetCPMProductTree(rowCPMOrder["Reçete No"], Utility.ToDateTime(dateEdit.DateTime), LoginForm.DataConnection);

                    this.lookMainProduct.EditValue = rowCPMOrder["Mal Kodu"];
                    this.txtCode1.Text = rowCPMOrder["Reçete No"].ToString();

                    this.lookCapacityType.EditValue = 16; // Full Kapasite
                    this.lookPackageType.EditValue = 21;// çuval
                    this.lookOrderType.EditValue = 25; // Genel
                    this.lookPaymentDate.EditValue = 5; // Peşin
                    this.spinEditOrderAmount.EditValue = 5000; // ortalama sipariş miktarı belirlenmiştir
                    this.lookDeliveryType.EditValue = 35; // EXW Gazaintep
                }
                else
                {
                    GetArgeProductTree(Utility.ToInt32(lookProductTreeFiche.EditValue));



                    //using (var dCpmOrder = ProductTree.GetRawMaterialCost(ProductTreeFicheId, Utility.ToDateTime(dateEdit.DateTime), LoginForm.DataConnection))
                    //{
                    //    grdCPMOrder3.DataSource = dCpmOrder;
                    //}
                }

            }


            else if (radioGroup1.EditValue.ToString() == "2")
            {
                if (rowCPMOrder != null)
                {
                    if (String.IsNullOrEmpty(rowCPMOrder["Sipariş Reçete No"].ToString()) && String.IsNullOrEmpty(rowCPMOrder["Reçete No"].ToString())) // eğer sipariş reçetesi ve mamül reçetesi boşsa uyarı ver
                    {
                        XtraMessageBox.Show("Sistemde tanımlı mamül veya sipariş reçetesi bulunamamıştır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearList();
                        return;
                    }

                    else if (String.IsNullOrEmpty(rowCPMOrder["Sipariş Reçete No"].ToString())) // eğer sipariş reçetesi boşsa mamül reçetesini kullan
                    {
                        this.lookMainProduct.EditValue = rowCPMOrder["Mal Kodu"];
                        this.txtCode1.Text = rowCPMOrder["Reçete No"].ToString();
                        this.txtCode2.Text = rowCPMOrder["KalemSN"].ToString();


                        treeList.DataSource = ProductTree.GetCPMProductTree(rowCPMOrder["Reçete No"], Utility.ToDateTime(dateEdit.DateTime), LoginForm.DataConnection);

                        this.lookCPMOrder.EditValue = rowCPMOrder["Reçete No"].ToString();

                        var row = Database.GetRow("SELECT ParameterID FROM [dbo].[tblParameters] where Definition= '" + rowCPMOrder["Ambalaj Şekli"].ToString() + "'", LoginForm.DataConnection);
                        this.lookPackageType.EditValue = row.ItemArray[0];

                        var row2 = Database.GetRow("SELECT ParameterID FROM [dbo].[tblParameters] where Definition= '" + rowCPMOrder["Sipariş Türü"].ToString() + "'", LoginForm.DataConnection);
                        this.lookOrderType.EditValue = row2.ItemArray[0];

                        var row3 = Database.GetRow("SELECT ParameterID FROM [dbo].[tblParameters] where Definition= '" + rowCPMOrder["Ödeme Şekli"].ToString() + "'", LoginForm.DataConnection);
                        this.lookPaymentDate.EditValue = row3.ItemArray[0];

                        this.lookDyeType.EditValue = rowCPMOrder["Boyama_Code"].ToString();
                        this.spinEditOrderAmount.EditValue = Utility.ToFloat(rowCPMOrder["Miktar"]);
                    }
                    else
                    {
                        this.lookMainProduct.EditValue = rowCPMOrder["Mal Kodu"];
                        this.txtCode1.Text = rowCPMOrder["Sipariş Reçete No"].ToString();
                        this.txtCode2.Text = rowCPMOrder["KalemSN"].ToString();


                        treeList.DataSource = ProductTree.GetCPMOrderProductTree(rowCPMOrder["Sipariş Reçete No"], Utility.ToDateTime(dateEdit.DateTime), LoginForm.DataConnection);

                        var row = Database.GetRow("SELECT ParameterID FROM [dbo].[tblParameters] where Definition= '" + rowCPMOrder["Ambalaj Şekli"].ToString() + "'", LoginForm.DataConnection);
                        this.lookPackageType.EditValue = row.ItemArray[0];

                        var row2 = Database.GetRow("SELECT ParameterID FROM [dbo].[tblParameters] where Definition= '" + rowCPMOrder["Sipariş Türü"].ToString() + "'", LoginForm.DataConnection);
                        this.lookOrderType.EditValue = row2.ItemArray[0];

                        var row3 = Database.GetRow("SELECT ParameterID FROM [dbo].[tblParameters] where Definition= '" + rowCPMOrder["Ödeme Şekli"].ToString() + "'", LoginForm.DataConnection);
                        this.lookPaymentDate.EditValue = row3.ItemArray[0];

                        this.lookDyeType.EditValue = rowCPMOrder["Boyama_Code"].ToString();
                        this.spinEditOrderAmount.EditValue = Utility.ToFloat(rowCPMOrder["Miktar"]);
                    }
                }
                else
                {
                    GetArgeProductTree(Utility.ToInt32(lookProductTreeFiche.EditValue));
                }

            }

            treeList.BestFitColumns();
            treeList.ExpandAll();
        }

        private void RefreshList()
        {
            try
            {
                LoadSource();
                LoadTreeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateRecord(int productTreeFicheID)
        {
            var dTreeList = (DataTable)treeList.DataSource;

            if (Database.CheckConnection(LoginForm.DataConnection))
            {
                SqlTransaction transaction = null;

                try
                {
                    // YENİ ÜRÜN veya CPM MAMÜL ÜRÜNLER vey CPM SİPARİŞLER

                    int result = 0;
                    object productTreeFicheId = 0;
                    transaction = LoginForm.DataConnection.BeginTransaction("TranProductTreeFiche");


                    //**ProductTreeFiche UPDATE **//
                    ProductTreeFicheId = Utility.ToLong(productTreeFicheID);

                    result = _productTreeFiche.Update(ProductTreeFicheId, lookStockFeatureTypeID.EditValue,
                        lookMainProduct.EditValue.ToString(), Utility.ToDateTime(dateEdit.EditValue),
                        lookOrderType.EditValue, lookCapacityType.EditValue, lookDeliveryType.EditValue,
                        lookPaymentDate.EditValue, lookPackageType.EditValue, spinEditOrderAmount.EditValue,
                        spinRingBobinNr.EditValue, spinBukumNr.EditValue, spinFinalNr.EditValue,
                        lookDyeType.EditValue, txtCode1.Text, txtCode2.Text, spinEditCode3.EditValue,
                        (byte)ProductTreeFiche.Status.Active,
                        transaction);


                    if (result <= 0)
                    {
                        transaction.Rollback();
                        XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //**ProductTreeFiche UPDATE END**//


                    //**ProductTree UPDATE **//
                    foreach (DataRow row in dTreeList.Rows)
                    {
                        ProductTreeId = Utility.ToLong(row["ProductTreeID"]);
                        result = _productTree.Update(row["ProductTreeID"], ProductTreeFicheId, row["StockGroupID"],
                        Utility.ToDateTime(dateEdit.EditValue), row["Touchness"], row["Feature"], row["Level"],
                        row["LevelType"], row["ParentID"], row["ZoneID"], row["DyeProcess"], row["StockCode"],
                        row["ColorType"], row["Amount"], row["Wastage"], row["Total"], row["NFold"],
                        row["ProductTreeIndex"], "", "", null, Utility.ToDecimal(row["UnitCost"]), row["Status"],
                        row["ColorCode"], row["Color"],
                        transaction);
                    }




                    if (result <= 0)
                    {
                        transaction.Rollback();
                        XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        transaction.Commit();

                        // XtraMessageBox.Show(Resources.InsertInfo, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //**ProductTree UPDATE END**//
                }


                catch (SqlException exc)
                {
                    transaction?.Rollback();

                    //FicheGuid = "";

                    XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();

                    //FicheGuid = "";

                    XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
                finally
                {
                    transaction?.Dispose();
                }
            }
            else
            {
                XtraMessageBox.Show(Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SaveRecord()
        {
            var dTreeList = (DataTable)treeList.DataSource;

            if (Database.CheckConnection(LoginForm.DataConnection))
            {
                SqlTransaction transaction = null;

                try
                {
                    // Yeni Ürün veya CPM Mamül veya CPM Sipariş İçin aynı insert işlemi uygalnıyor
                    int result = 0;
                    object productTreeFicheId = 0;
                    transaction = LoginForm.DataConnection.BeginTransaction("TranProductTreeFiche");

                    //**ProductTreeFiche INSERT **//
                    result = _productTreeFiche.Insert(ref productTreeFicheId, lookStockFeatureTypeID.EditValue,
                        lookMainProduct.EditValue.ToString(), Utility.ToDateTime(dateEdit.EditValue),
                        lookOrderType.EditValue, lookCapacityType.EditValue, lookDeliveryType.EditValue,
                        lookPaymentDate.EditValue, lookPackageType.EditValue, spinEditOrderAmount.EditValue,
                        spinRingBobinNr.EditValue, spinBukumNr.EditValue, spinFinalNr.EditValue,
                        lookDyeType.EditValue, txtCode1.Text, txtCode2.Text, spinEditCode3.EditValue,
                        (byte)ProductTreeFiche.Status.Active, transaction);

                    ProductTreeFicheId = Utility.ToLong(productTreeFicheId);

                    if (result <= 0)
                    {
                        transaction.Rollback();
                        XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //**ProductTreeFiche INSERT END **//


                    //**ProductTree INSERT **//
                    foreach (DataRow row in dTreeList.Rows)
                    {
                        ProductTreeId = Utility.ToLong(row["ProductTreeID"]);
                        object productTreeId = 0;
                        object rowGuid = Guid.Empty;

                        result = _productTree.Insert(ref productTreeId, ProductTreeFicheId, row["StockGroupID"],
                        Utility.ToDateTime(dateEdit.EditValue), row["Touchness"], row["Feature"], row["Level"],
                        row["LevelType"], row["ParentID"], row["ZoneID"], row["DyeProcess"], row["StockCode"],
                        row["ColorType"], row["Amount"], row["Wastage"], row["Total"], row["NFold"],
                        row["ProductTreeIndex"], "", "", null, Utility.ToDecimal(row["UnitCost"]),
                        (byte)ProductTree.Status.Active, row["ColorCode"], row["Color"], transaction);


                        row["ProductTreeID"] = productTreeId; //treelist'i set eder
                    }



                    // PRODUCT TREE BİRİM FİYATLARI UPDATE
                    var cmd = LoginForm.DataConnection.CreateCommand();

                    try
                    {
                        cmd.CommandText = "[dbo].[spGetRawMaterialCost]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ProductTreeFicheID", SqlDbType.Int);
                        cmd.Parameters["@ProductTreeFicheID"].Direction = ParameterDirection.Input;
                        cmd.Parameters["@ProductTreeFicheID"].Value = Utility.ToDBNull(ProductTreeFicheId);

                        cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                        cmd.Parameters["@Date"].Direction = ParameterDirection.Input;
                        cmd.Parameters["@Date"].Value = Utility.ToDBNull(Utility.ToDateTime(dateEdit.EditValue));

                        var da = new SqlDataAdapter(cmd);

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                    }
                    // PRODUCT TREE BİRİM FİYATLARI UPDATE



                    if (result <= 0) //**Hata Mesajları **//
                    {
                        transaction.Rollback();
                        XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        transaction.Commit();
                        LoadFiche();
                    }
                    //**ProductTree INSERT END**//
                }

                catch (SqlException exc)
                {
                    transaction?.Rollback();

                    //FicheGuid = "";

                    XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();

                    //FicheGuid = "";

                    XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
                finally
                {
                    transaction?.Dispose();
                }
            }
            else
            {
                XtraMessageBox.Show(Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Calculate()
        {
            DataRow recete_veya_siparis_no = null;


            if (radioGroup1.EditValue.ToString() == "0")
            {
                recete_veya_siparis_no = Database.GetRow("SELECT ProductTreeFicheID FROM [dbo].[tblProductTreeFiche] where ProductTreeFicheID= '" + ProductTreeFicheId.ToString() + "'", LoginForm.DataConnection); // kaydedilmek istenen ptfID daha önce kaydedilmiş mi kontrol ediliyor
            }

            else if (radioGroup1.EditValue.ToString() == "1")
            {
                recete_veya_siparis_no = Database.GetRow("SELECT ProductTreeFicheID FROM [dbo].[tblProductTreeFiche] where Code1= '" + txtCode1.Text.ToString() + "'", LoginForm.DataConnection); // kaydedilmek istenen reçete daha önce kaydedilmiş mi kontrol ediliyor
            }
            else if (radioGroup1.EditValue.ToString() == "2")
            {
                recete_veya_siparis_no = Database.GetRow("SELECT ProductTreeFicheID FROM [dbo].[tblProductTreeFiche] where Code2= '" + txtCode2.Text.ToString() + "'", LoginForm.DataConnection); // kaydedilmek istenen sipariş daha önce kaydedilmiş mi kontrol ediliyor
            }

            if (recete_veya_siparis_no != null && Utility.ToLong(recete_veya_siparis_no.ItemArray[0].ToString()) > 0) // ProductTreeFiche ve ProductTree UPDATE
            {
                if (XtraMessageBox.Show("Kayıtlı siparişi güncellemek ister misiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                UpdateRecord(Utility.ToInt32(recete_veya_siparis_no.ItemArray[0]));
            }
            else // ProductTreeFiche ve ProductTree INSERT
            {
                SaveRecord();
            }
            LoadSource();

            RunFunctionWithTimer(20, "PrintResult");

            //RunFunctionWithTimer(10, "RunProcessUnitCost");

            //Thread processThread = new Thread(() => RunProcessUnitCost());
            //processThread.Start();
            //processThread.Abort();

        }

        private void LoadSource()
        {
            try
            {
                if (!Database.CheckConnection(LoginForm.DataConnection)) return;


                using (var dCpmOrder = CPMDatabase.GetCPMCostOrder(0, LoginForm.DataConnection))
                {
                    grdCPMOrder.DataSource = dCpmOrder;

                }

                using (var dCpmOrder = CPMDatabase.GetCPMCostOrder(1, LoginForm.DataConnection))
                {
                    grdCPMOrder2.DataSource = dCpmOrder;

                }

                using (var dCpmOrder = CPMDatabase.GetCPMCostOrder(2, LoginForm.DataConnection))
                {
                    grdCPMOrder3.DataSource = dCpmOrder;

                }

                String sqlCmd = "SELECT sf.Name,SKOD5.ACIKLAMA [DyeType],pay.Definition [PaymentDate],pac.[Definition] [PackageType],ptf.* FROM tblProductTreeFiche ptf " +
                                "LEFT OUTER JOIN [dbo].[tblStockFeatureType] sf ON sf.[StockFeatureTypeID] = ptf.[StockFeatureTypeID] " +
                                "LEFT OUTER JOIN [dbo].[tblParameters] pay ON pay.[ParameterID] = ptf.[PaymentDate] AND pay.[TableName] = '[dbo].[tblProductTree]' AND pay.[ColumnName] = 'PaymentDate'" +
                                "LEFT OUTER JOIN [dbo].[tblParameters] pac ON pac.[ParameterID] = ptf.[PackageType] AND pac.[TableName] = '[dbo].[tblProductTree]' AND pac.[ColumnName] = 'PackageType'" +
                                "LEFT OUTER JOIN [TEKSTIL_UYG].[dbo].REFKRT SKOD5 WITH (NOLOCK) ON (SKOD5.TABLOAD = 'TEXSPK' AND SKOD5.ALANAD = 'SKOD5' AND SKOD5.KOD = ptf.DyeType)";

                if (radioGroup1.EditValue.ToString() == "0")
                {
                    lookMainProduct.Enabled = true;
                    sqlCmd += " WHERE ptf.Code1 = '' AND ptf.Code2 = ''";
                }
                else if (radioGroup1.EditValue.ToString() == "1")
                {
                    lookMainProduct.Enabled = false;

                    sqlCmd += " WHERE ptf.Code1 <> '' AND ptf.Code2 =''";

                    using (var dCpmOrder = CPMDatabase.GetCPMProduct(LoginForm.DataConnection))
                    {
                        Format.LookUpEdit(lookCPMOrder, new[] { "Reçete No", "Mal Kodu", "Mal Ad", "İçerik", "Evrak Tarihi", "Renk Kodu", "Renk", "Görünüm", "Efekt", "Özellik" }, "Reçete No", "Reçete No", dCpmOrder);
                    }
                }
                else if (radioGroup1.EditValue.ToString() == "2")
                {
                    lookMainProduct.Enabled = false;
                    sqlCmd += " WHERE ptf.Code1 <> '' AND ptf.Code2 <> ''";

                    using (var dCpmOrder = CPMDatabase.GetCPMOrder(LoginForm.DataConnection))
                    {
                        Format.LookUpEdit(lookCPMOrder, new[] { "Evrak No", "KalemSN", "Evrak Tarih", "Reçete No", "Sipariş Reçete No", "Müşteri", "Mal Kodu", "Mal Adı", "Miktar", "Boyama Şekli", "Sipariş Tipi", "Renk Kodu", "Sipariş Türü", "Ödeme Şekli" }, "Evrak No", "KalemSN", dCpmOrder);
                    }

                }

                using (var dProductTreeFiche = Database.GetList(sqlCmd, LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookProductTreeFiche,
                        new[]
                        {
                            "Name", "ProductTreeFicheID",  "MainStockCode","Date", "PaymentDate", "PackageType", "DyeType","Code1","Code2","Code3","RegisDate","UpdateDate","OrderAmount"
                        }, "Name", "ProductTreeFicheID", dProductTreeFiche);
                }
                //ProductTreeFiche.Select(0, "", 0, (byte)ProductTreeFiche.Status.Active, LoginForm.DataConnection, 0)


                using (_dStock)
                {
                    Format.LookUpEdit(lookProduct, new[] { "Code", "Name" }, "Name", "Code", _dStock);
                    Format.LookUpEdit(lookStockCode, new[] { "Code", "Name" }, "Code", "Code", _dStock);
                }

                using (var dIplikTipi = _stock.IplikTip1List())
                {
                    Format.LookUpEdit(lookUretimTipi, new[] { "Code", "Name" }, "Name", "Code", dIplikTipi);
                }

                using (var dZone = Zone.GetList(LoginForm.DataConnection, 0))
                {
                    Format.LookUpEdit(lookZone, new[] { "Name" }, "Name", "ZoneID", dZone);
                }

                using (var dMachineGroup = MachineGroup.GetList(LoginForm.DataConnection, 0))
                {
                    Format.LookUpEdit(lookMachineGroup, new[] { "Name" }, "Name", "MachineGroupID", dMachineGroup);
                }

                using (var dDyeType = _stock.PaintType())
                {
                    Format.LookUpEdit(lookDyeType, new[] { "Code", "Name" }, "Name", "Code", dDyeType);

                }

                using (var dLevelType = ProductTree.LevelTypeList())
                {
                    Format.LookUpEdit(lookLevelType, new[] { "Code" }, "Code", "LevelType", dLevelType);
                }

                using (var dDyeProcessList = ProductTree.DyeProcessList())
                {
                    Format.LookUpEdit(lookDyeProcess, new[] { "Code" }, "Code", "DyeProcess", dDyeProcessList);
                }

                using (var dColorType = ProductTree.ColorTypeList())
                {
                    Format.LookUpEdit(lookColorType, new[] { "Code" }, "Code", "ColorType", dColorType);
                }

                using (var dTouchness = Database.GetList("SELECT ParameterID, Definition FROM [dbo].[tblParameterList] ('[dbo].[tblReceipt]','Touchness')", LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookTouchness, new[] { "Definition" }, "Definition", "ParameterID", dTouchness);
                }

                using (var dFeature = Database.GetList("SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblReceipt]','Feature')", LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookFeature, new[] { "Definition" }, "Definition", "ParameterID", dFeature);
                }

                using (var dPaymentDate = Database.GetList("SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','PaymentDate')", LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookPaymentDate, new[] { "Definition" }, "Definition", "ParameterID", dPaymentDate);
                }

                using (var dOrderType = Database.GetList("SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','OrderType')", LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookOrderType, new[] { "Definition" }, "Definition", "ParameterID", dOrderType);
                }

                using (var dCapacityType = Database.GetList("SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','CapacityType')", LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookCapacityType, new[] { "Definition" }, "Definition", "ParameterID", dCapacityType);
                    lookCapacityType.EditValue = 16;
                }

                using (var dPackageType = Database.GetList("SELECT ParameterID, Definition FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','PackageType')", LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookPackageType, new[] { "Definition" }, "Definition", "ParameterID", dPackageType);
                }

                using (var dDeliveryType = Database.GetList("SELECT ParameterID, Definition, Feature, Property FROM [dbo].[tblParameterList]('[dbo].[tblProductTree]','DeliveryType')", LoginForm.DataConnection))
                {
                    Format.LookUpEdit(lookDeliveryType, new[] { "Definition", "Feature", "Property" }, "Definition", "ParameterID", dDeliveryType);
                    lookDeliveryType.EditValue = 36;
                }


                //using (var dStockGroup = Database.GetList("SELECT StockGroupID,StockGroup,ProductGroup,StockType,StockProductType,MinValue,MaxValue,NFold FROM [dbo].[vwStockGroup]", LoginForm.DataConnection))
                //{
                //    Format.LookUpEdit(lookStockCode, new[] { "StockGroupID", "StockGroup", "ProductGroup", "StockType", "StockProductType", "MinValue", "MaxValue", "NFold" }, "StockGroup", "StockGroupID", dStockGroup);
                //}

                using (var dStockGroup = Database.GetList("SELECT DISTINCT(sg.StockGroupID) as StockGroupID,StockGroup,StockProperty,ProductGroup,StockType,StockProductType,MinValue,MaxValue,NFold FROM [dbo].[vwStockGroup] sg " +
                                                          "INNER JOIN tblStockProcessRelation spr on spr.StockGroupID=sg.StockGroupID ORDER BY sg.StockGroupID ASC", LoginForm.DataConnection))
                {
                    srcLookStockGroupID.DataSource = dStockGroup;
                }

                using (var dUrunOzellik = new Stock().IplikOzelligiList())
                {
                    Format.LookUpEdit(lookUrunOzellik, new[] { "Code", "Name" }, "Name", "Name", dUrunOzellik);
                }

                using (var dUrunEfekt = new Stock().IplikEfektOzellikList())
                {
                    Format.LookUpEdit(lookUrunEfekt, new[] { "Code", "Name" }, "Name", "Name", dUrunEfekt);
                }

                using (var dUrunGorunum = new Stock().IplikGorunumList())
                {
                    Format.LookUpEdit(lookUrunGorunum, new[] { "Code", "Name" }, "Name", "Name", dUrunGorunum);
                }



                using (var dAnnualDer = ProductTree.GetProcess("StockGroupID", LoginForm.DataConnection))
                {
                    processdetail.DataSource = dAnnualDer;
                }

                using (var dStockGroup = Database.GetList("SELECT * FROM [dbo].[vwExpenseLine]", LoginForm.DataConnection))
                {
                    grdExpenseLine.DataSource = dStockGroup;
                }
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindingDataSource(long stockGroupId)
        {
            //if (lookMainProduct.EditValue == null || lookMainProduct.EditValue.ToString() == string.Empty) return;

            //try
            //{
            //    if (!Database.CheckConnection(LoginForm.DataConnection)) return;

            //    using (var dChemical = ProductTree.GetChemicalExpense(lookMainProduct.EditValue.ToString(),
            //        Utility.ToLong(lookStockFeatureTypeID.EditValue), LoginForm.DataConnection))
            //    {
            //        grdChemical.DataSource = dChemical;
            //    }


            //}
            //catch (SqlException exc)
            //{
            //    MessageBox.Show(exc.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void PrintResult()
        {
            float unitCost = 0;
            float bottleNeck = 0;

            try
            {
                //using (var dGroupUnitCost = ProductTreeFiche.GetGroupUnitCost(this.lookMainProduct.EditValue, this.lookStockFeatureTypeID.EditValue, this.spinEditOrderAmount.EditValue, this.spinRingBobinNr.EditValue, this.spinBukumNr.EditValue, this.spinFinalNr.EditValue, dateEdit.EditValue, this.lookCapacityType.EditValue, true, LoginForm.DataConnection))
                //{
                //    this._dGroupUnitCost = dGroupUnitCost;
                //    this.grdGroupUnitCost.DataSource = dGroupUnitCost;

                //    max = (from DataRow row in dGroupUnitCost.Rows select Utility.ToFloat(row["DailyGroupBottleNeck"])).Prepend(max).Max();
                //}
                //using (var dProcessUnitCost = ProductTreeFiche.GetProcessUnitCost(this.lookMainProduct.EditValue, this.lookStockFeatureTypeID.EditValue, this.spinEditOrderAmount.EditValue, this.spinRingBobinNr.EditValue, this.spinBukumNr.EditValue, this.spinFinalNr.EditValue, dateEdit.EditValue, this.lookCapacityType.EditValue, true, this.ProductTreeFicheId, LoginForm.DataConnection))
                //{
                //    this._dProcessUnitCost = dProcessUnitCost;
                //    this.grdProcessUnitCost.DataSource = dProcessUnitCost;
                //}p

                using (var dProductUnitCost = ProductTreeFiche.GetProductUnitCost(lookMainProduct.EditValue,
                    lookStockFeatureTypeID.EditValue, spinEditOrderAmount.EditValue, spinRingBobinNr.EditValue,
                    spinBukumNr.EditValue, spinFinalNr.EditValue, dateEdit.EditValue, lookCapacityType.EditValue,
                    lookPaymentDate.EditValue, lookPackageType.EditValue, lookOrderType.EditValue,
                    lookDeliveryType.EditValue, true, ProductTreeFicheId, LoginForm.DataConnection))
                {

                    if (dProductUnitCost != null && dProductUnitCost.Rows.Count > 0)
                    {
                        bottleNeck = Utility.ToFloat(dProductUnitCost.Rows[0]["DailyProductBottleNeck"]);
                        unitCost = Utility.ToFloat(dProductUnitCost.Rows[0]["UnitCost"]);

                        if (ProductTreeFicheId * unitCost > 0)
                            if (Database.CheckConnection(LoginForm.DataConnection))
                                ProductTreeFiche.UpdateUnitCost(ProductTreeFicheId, Utility.ToDecimal(unitCost), Utility.ToDecimal(bottleNeck), LoginForm.DataConnection);
                    }
                }

                using (var dAnnualDer = ProductTreeFiche.GetTmpProductUnitCost(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdProductUnitCost.DataSource = dAnnualDer;
                }
                using (var dAnnualDer = ProductTreeFiche.GetTmpGroupUnitCost(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdGroupUnitCost.DataSource = dAnnualDer;
                }
                using (var dAnnualDer = ProductTreeFiche.GetTmpProcessUnitCost(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdProcessUnitCost.DataSource = dAnnualDer;
                }
                ucUnitCost1.UnitCost = unitCost;
                ucUnitCost1.BottleNeck = bottleNeck;

                labelComponent1.Text = bottleNeck.ToString(CultureInfo.InvariantCulture);

                ProductTree.UpdateRawMaterialCost(ProductTreeFicheId, Utility.ToDateTime(dateEdit.EditValue), LoginForm.DataConnection);
                //ProductTree.GetCapacity(ProductTreeFicheId, LoginForm.DataConnection);
                LoadFiche();
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void RunProcessUnitCost()
        {
            using (var dProcessUnitCost = ProductTreeFiche.GetProcessUnitCost(lookMainProduct.EditValue,
                       lookStockFeatureTypeID.EditValue, spinEditOrderAmount.EditValue, spinRingBobinNr.EditValue,
                       spinBukumNr.EditValue, spinFinalNr.EditValue, dateEdit.EditValue, lookCapacityType.EditValue, true,
                       ProductTreeFicheId, LoginForm.DataConnection))
            {
                grdProcessUnitCost.DataSource = dProcessUnitCost;

                this.grdWorkerExpense.DataSource = dProcessUnitCost;
            }
            using (var dAnnualDer = ProductTreeFiche.GetTmpProcessUnitCost(ProductTreeFicheId, LoginForm.DataConnection))
            {
                grdProcessUnitCost.DataSource = dAnnualDer;
            }
        }

        private void GetArgeProductTree(int _ProductTreeFicheId)
        {
            if (lookMainProduct.EditValue.ToString() == string.Empty) return;

            if (Utility.ToInt32(lookStockFeatureTypeID.EditValue) <= 0) return;
            try
            {
                using (var dProductTree = ProductTree.Select(_ProductTreeFicheId,
                    //lookMainProduct.EditValue.ToString(),
                    //Utility.ToInt32(lookStockFeatureTypeID.EditValue),
                    (byte)ProductTree.Status.Active,
                    LoginForm.DataConnection))
                {
                    treeList.DataSource = dProductTree;
                }
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckControl()
        {
            if (!ScreenPermission.ScreenPermissionEdit(LoginForm.UserId, Tag.ToString(), LoginForm.DataConnection))
            {
                XtraMessageBox.Show(Resources.PermissionDenied, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (lookMainProduct.EditValue == null)
            {
                XtraMessageBox.Show("Ana Ürün seçiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lookStockFeatureTypeID.EditValue == null)
            {
                XtraMessageBox.Show("Ürün Türevi seçiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dateEdit.EditValue == null)
            {
                XtraMessageBox.Show("Tarih seçiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lookCapacityType.EditValue == null)
            {
                XtraMessageBox.Show("Kapasite Türü seçiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lookOrderType.EditValue == null)
            {
                XtraMessageBox.Show("Sipariş Türü seçiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Utility.ToDecimal(spinEditOrderAmount.EditValue) == 0)
            {
                XtraMessageBox.Show("Sipariş Miktarı giriniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lookPackageType.EditValue == null)
            {
                XtraMessageBox.Show("Ambalaj Tipi seçiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lookDeliveryType.EditValue == null)
            {
                XtraMessageBox.Show("Teslim Şekli seçiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lookPaymentDate.EditValue == null)
            {
                XtraMessageBox.Show("Vade seçiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }



            if ((DataTable)treeList.DataSource == null || ((DataTable)treeList.DataSource).Rows.Count == 0)
            {
                XtraMessageBox.Show("Ürün Ağacı bilgilerini giriniz", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataRow row in ((DataTable)treeList.DataSource).Rows)
            {

                if ((row["LevelType"].ToString() == "2" && (row["DyeProcess"].ToString() == "1" || row["DyeProcess"].ToString() == "2")) && (String.IsNullOrEmpty(row["StockGroupID"].ToString()) || row["StockGroupID"].ToString() == "0" || row["StockGroupID"].ToString() == "0")) // hammadde olanlarının boyamaları yoksa  grupları boş bırakalabilir
                {
                    XtraMessageBox.Show("StockGroupID boş bırakılamaz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (row["LevelType"].ToString() == "2" && Utility.ToDecimal(row["UnitCost"]) <= 0)
                {
                    XtraMessageBox.Show("Hammadde birim fiyatları tanımlanmalıdır", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (row["DyeProcess"].ToString() == "1")
                {
                    if ((String.IsNullOrEmpty(row["ColorType"].ToString()) || row["ColorType"].ToString() == "0" || String.IsNullOrEmpty(row["Touchness"].ToString()) || row["Touchness"].ToString() == "0"))
                    {
                        XtraMessageBox.Show("Boyamaya ait Tuşe veya Renk türü boş bırakılamaz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }


                    //var d = Convert.ToDecimal(spinEditOrderAmount.EditValue, new CultureInfo("en-GB"));

                    //return  double.TryParse(spinEditOrderAmount.EditValue, NumberStyles.Any, CultureInfo.InvariantCulture, out value);


                    //usCulture = new CultureInfo("en-GB");
                    //Thread.CurrentThread.CurrentCulture = usCulture;
                    //Thread.CurrentThread.CurrentUICulture = usCulture;
                    //usCulture = Thread.CurrentThread.CurrentCulture;
                    //dbNumberFormat = usCulture.NumberFormat;
                    //number = decimal.Parse("1,332.23", dbNumberFormat); //123.456.789,00


                    DateTime dt = Utility.ToDateTime(dateEdit.EditValue);
                    string strDate = dt.ToString("yyyy-MM-dd");


                    var chemical = Database.GetRow($"SELECT TotalCost  FROM [dbo].[tblChemicalReceiptCost] ({Utility.ToDouble(spinEditOrderAmount.EditValue)},{row["StockGroupID"]},{Utility.ToInt16(row["ColorType"])},{row["Touchness"]},{row["Feature"]},'{strDate}' ) ", LoginForm.DataConnection);

                    if (chemical == null)
                    {
                        XtraMessageBox.Show("Kimyasal Reçete tanımlı değildir", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    //string chemical_check = chemical.ItemArray[0].ToString();

                    //if (String.IsNullOrEmpty(chemical_check) || Utility.ToInt16(chemical_check)==0)
                    //{
                    //    XtraMessageBox.Show("Kimyasal Reçeteyi kontrol ediniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return false;

                    //}                   
                }

            }

            return true;
        }

        private void LoadFiche()
        {
            if (lookProductTreeFiche.EditValue == null) return;

            var row = (DataRowView)lookProductTreeFiche.Properties.GetDataSourceRowByKeyValue(lookProductTreeFiche
                .EditValue);

            using (var dFiche = ProductTreeFiche.Select(Utility.ToLong(row["ProductTreeFicheID"]),
                row["MainStockCode"].ToString(), Utility.ToInt32(row["StockFeatureTypeID"]),
                (byte)ProductTreeFiche.Status.Active, LoginForm.DataConnection))
            {
                if (dFiche.Rows.Count != 1) return;
                var fiche = new ProductTreeFiche(LoginForm.DataConnection);

                fiche.Record.Change(dFiche.Rows[0]);

                ProductTreeFicheId = fiche.Record.ProductTreeFicheID;
                dateEdit.EditValue = fiche.Record.Date;
                lookDeliveryType.EditValue = fiche.Record.DeliveryType;
                lookPackageType.EditValue = fiche.Record.PackageType;
                lookOrderType.EditValue = fiche.Record.OrderType;
                spinEditOrderAmount.EditValue = fiche.Record.OrderAmount;
                lookCapacityType.EditValue = fiche.Record.CapacityType;
                lookPaymentDate.EditValue = fiche.Record.PaymentDate;
                spinRingBobinNr.EditValue = fiche.Record.RingNr;
                spinBukumNr.EditValue = fiche.Record.BukumNr;
                spinFinalNr.EditValue = fiche.Record.FinalNr;
                lookDyeType.EditValue = fiche.Record.DyeType;
                txtCode1.Text = fiche.Record.Code1;
                txtCode2.Text = fiche.Record.Code2;
                lookMainProduct.EditValue = CpmStockCode = fiche.Record.MainStockCode;
                lookStockFeatureTypeID.EditValue = Utility.ToInt32(fiche.Record.StockFeatureTypeID);
                ucUnitCost1.UnitCost = fiche.Record.Code3;
                ucUnitCost1.BottleNeck = fiche.Record.BottleNeck;

                LoadTreeList();

                using (var dAnnualDer = ProductTreeFiche.GetTmpProductUnitCost(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdProductUnitCost.DataSource = dAnnualDer;
                }

                using (var dAnnualDer = ProductTreeFiche.GetTmpProcessUnitCost(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdProcessUnitCost.DataSource = dAnnualDer;
                }


                using (var dAnnualDer = ProductTreeFiche.GetTmpGroupUnitCost(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdGroupUnitCost.DataSource = dAnnualDer;
                }

                using (var dAnnualDer = ProductTree.GetChemicalExpense(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdChemical.DataSource = dAnnualDer;
                }

                using (var dWorkerExpense = ProductTree.GetWorkerExpense(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdWorkerExpense.DataSource = dWorkerExpense;
                    //grdWorkExpenseGroup.DataSource = dWorkerExpense;
                }

                using (var dInvoiceExpense = ProductTree.GetInvoiceExpense(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdInvoiceExpense.DataSource = dInvoiceExpense;
                }
                using (var dIndirectExpense = ProductTree.GetIndirectExpense(Utility.ToDateTime(dateEdit.EditValue).Month, Utility.ToDateTime(dateEdit.EditValue).Year,
                    LoginForm.DataConnection))
                {
                    grdIndirectExpense.DataSource = dIndirectExpense;
                }

                using (var dAnnualDer = ProductTree.GetAnnualDER(LoginForm.DataConnection))
                {
                    grdAnnualDepartmentExpenseRelation.DataSource = dAnnualDer;
                }

                using (var dAnnualCost = ProductTree.GetAnnualCosts(LoginForm.DataConnection))
                {
                    grdAnnualCosts.DataSource = dAnnualCost;
                    grvAnnualCosts.ExpandAllGroups();
                }

                using (var dAnnualCost = ProductTree.GetCapacity(ProductTreeFicheId, LoginForm.DataConnection))
                {
                    grdCapacity.DataSource = dAnnualCost;
                }

            }
        }

        private void NewStockFeatureType()
        {
            try
            {
                if (lookMainProduct.EditValue == null || lookMainProduct.EditValue.ToString() == "") return;

                using (var fStockFeatureType = new StockFeatureTypeForm())
                {
                    fStockFeatureType.StockCode = lookMainProduct.EditValue;
                    fStockFeatureType.Tag = "btnStockFeatureType";
                    fStockFeatureType.ShowDialog();

                    using (var dStockFeatureType = StockFeatureType.Select(lookMainProduct.EditValue.ToString(), 1,
                        LoginForm.DataConnection))
                    {
                        Format.LookUpEdit(lookStockFeatureTypeID,
                            new[]
                            {
                                "StockCode", "Name", "MachineGroup1", "MachineGroup2", "MachineGroup3", "MachineGroup4"
                            }, "Name", "StockFeatureTypeID", dStockFeatureType);
                    }
                }
            }
            catch (SqlException exc)
            {
                XtraMessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunFunctionWithTimer(int seconds, string funcName)
        {
            if (seconds <= 0) return;

            Thread th = new Thread(() => TimerFunc(seconds));

            try
            {
                splashScreenManager1.ShowWaitForm();
                th.Start();

                switch (funcName)
                {
                    case "RefreshList":
                        RefreshList();
                        break;
                    case "LoadFicheAndRefresh":
                        LoadFicheAndRefresh();
                        break;

                    case "ViewAll":
                        ViewAll();
                        break;
                    case "LoadSource":
                        LoadSource();
                        break;
                    case "Calculate":
                        Calculate();
                        break;
                    case "PrintResult":
                        PrintResult();
                        break;
                    default:
                        break;
                }

                th.Abort();
                splashScreenManager1.CloseWaitForm();

            }
            catch (ThreadStateException ext)
            {
                XtraMessageBox.Show(ext.Message);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void TimerFunc(int seconds)
        {
            for (int i = seconds; i != 0; i--)
            {
                splashScreenManager1.SetWaitFormDescription($"Yükleniyor.. {i}");
                Thread.Sleep(1000);
            }
            splashScreenManager1.SetWaitFormDescription("Bu operasyon beklenenden fazla sürüyor");
        }

        private void LoadFicheAndRefresh()
        {
            LoadFiche();
            this.RefreshList();
        }

        private void ViewAll()
        {

            BindingDataSource(0);

            //using (var dGroupUnitCost = ProductTreeFiche.GetGroupUnitCost(lookMainProduct.EditValue,
            //    lookStockFeatureTypeID.EditValue, spinEditOrderAmount.EditValue, spinRingBobinNr.EditValue,
            //    spinBukumNr.EditValue, spinFinalNr.EditValue, dateEdit.EditValue, lookCapacityType.EditValue, true,
            //    LoginForm.DataConnection))
            //{
            //    grdGroupUnitCost.DataSource = dGroupUnitCost;
            //    this.grdWorkExpenseGroup.DataSource = dGroupUnitCost;
            //}

            using (var dProcessUnitCost = ProductTreeFiche.GetProcessUnitCost(lookMainProduct.EditValue,
                lookStockFeatureTypeID.EditValue, spinEditOrderAmount.EditValue, spinRingBobinNr.EditValue,
                spinBukumNr.EditValue, spinFinalNr.EditValue, dateEdit.EditValue, lookCapacityType.EditValue, true,
                ProductTreeFicheId, LoginForm.DataConnection))
            {
                grdProcessUnitCost.DataSource = dProcessUnitCost;

                this.grdWorkerExpense.DataSource = dProcessUnitCost;
            }
        }

        private void DeleteFiche()
        {
            if (lookProductTreeFiche.EditValue == null) return;
            if (XtraMessageBox.Show(Resources.QuestionDelete, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            ProductTreeFiche.Delete(lookProductTreeFiche.EditValue, LoginForm.DataConnection);
            ClearList();
        }

        private void SaveRecord_Eski()
        {
            if (!ScreenPermission.ScreenPermissionEdit(LoginForm.UserId, Tag.ToString(), LoginForm.DataConnection))
            {
                XtraMessageBox.Show(Resources.PermissionDenied, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            var dTreeList = (DataTable)treeList.DataSource;

            if (dTreeList == null || dTreeList.Rows.Count == 0) return;

            //if (XtraMessageBox.Show(Resources.QuestionSave, Text, MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (Database.CheckConnection(LoginForm.DataConnection))
            {
                SqlTransaction transaction = null;

                try
                {
                    int result;

                    if (CpmStockCode != null && CpmStockCode != lookMainProduct.EditValue.ToString())
                    {
                        XtraMessageBox.Show("Malzeme Kodları Uyumsuz!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    transaction = LoginForm.DataConnection.BeginTransaction("TranProductTreeFiche");

                    //if (FicheGuid == "") // Select veya İnsert
                    //{
                    object productTreeFicheId = 0;
                    //object ficheRowGuid = Guid.Empty;

                    //var ficheGuid = Guid.NewGuid().ToString();

                    result = _productTreeFiche.Insert(ref productTreeFicheId, lookStockFeatureTypeID.EditValue,
                        lookMainProduct.EditValue.ToString(), Utility.ToDateTime(dateEdit.EditValue),
                        lookOrderType.EditValue, lookCapacityType.EditValue, lookDeliveryType.EditValue,
                        lookPaymentDate.EditValue, lookPackageType.EditValue, spinEditOrderAmount.EditValue,
                        spinRingBobinNr.EditValue, spinBukumNr.EditValue, spinFinalNr.EditValue,
                        lookDyeType.EditValue, txtCode1.Text, txtCode2.Text, spinEditCode3.EditValue,
                        (byte)ProductTreeFiche.Status.Active,
                        //ref ficheRowGuid, Utility.ToGuid(ficheGuid),
                        transaction);

                    ProductTreeFicheId = Utility.ToLong(productTreeFicheId);
                    //FicheGuid = ficheGuid.ToString();
                    //  }
                    // else
                    //{
                    result = _productTreeFiche.Update(ProductTreeFicheId, lookStockFeatureTypeID.EditValue,
                        lookMainProduct.EditValue.ToString(), Utility.ToDateTime(dateEdit.EditValue),
                        lookOrderType.EditValue, lookCapacityType.EditValue, lookDeliveryType.EditValue,
                        lookPaymentDate.EditValue, lookPackageType.EditValue, spinEditOrderAmount.EditValue,
                        spinRingBobinNr.EditValue, spinBukumNr.EditValue, spinFinalNr.EditValue,
                        lookDyeType.EditValue, txtCode1.Text, txtCode2.Text, spinEditCode3.EditValue,
                        (byte)ProductTreeFiche.Status.Active,
                        //Utility.ToGuid(FicheRowGuid),Utility.ToGuid(FicheGuid),
                        transaction);
                    // }

                    if (result <= 0)
                    {
                        transaction.Rollback();

                        //FicheGuid = "";

                        XtraMessageBox.Show("Fiş kaydedilemedi!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (DataRow row in dTreeList.Rows)
                    {
                        ProductTreeId = Utility.ToLong(row["ProductTreeID"]);

                        if (ProductTreeId == 0)
                        {
                            object productTreeId = 0;
                            object rowGuid = Guid.Empty;

                            result = _productTree.Insert(ref productTreeId, ProductTreeFicheId, row["StockGroupID"],
                            Utility.ToDateTime(dateEdit.EditValue), row["Touchness"], row["Feature"], row["Level"],
                            row["LevelType"], row["ParentID"], row["ZoneID"], row["DyeProcess"], row["StockCode"],
                            row["ColorType"], row["Amount"], row["Wastage"], row["Total"], row["NFold"],
                            row["ProductTreeIndex"], "", "", null, Utility.ToDecimal(row["UnitCost"]),
                            (byte)ProductTree.Status.Active, row["ColorCode"], row["Color"],
                            //ref rowGuid, Utility.ToGuid(FicheGuid),
                            transaction);

                            row["ProductTreeID"] = productTreeId; //treelist'i set eder
                                                                  //row["RowGUID"] = rowGuid;
                                                                  //row["FicheGUID"] = FicheGuid;
                        }
                        else
                        {
                            result = _productTree.Update(row["ProductTreeID"], ProductTreeFicheId, row["StockGroupID"],
                            Utility.ToDateTime(dateEdit.EditValue), row["Touchness"], row["Feature"], row["Level"],
                            row["LevelType"], row["ParentID"], row["ZoneID"], row["DyeProcess"], row["StockCode"],
                            row["ColorType"], row["Amount"], row["Wastage"], row["Total"], row["NFold"],
                            row["ProductTreeIndex"], "", "", null, Utility.ToDecimal(row["UnitCost"]), row["Status"],
                            row["ColorCode"], row["Color"],
                            //row["RowGUID"], Utility.ToGuid(FicheGuid),
                            transaction);
                        }
                    }

                    if (result <= 0)
                    {
                        transaction.Rollback();

                        //FicheGuid = "";

                        XtraMessageBox.Show(Resources.InsertError, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        transaction.Commit();
                        XtraMessageBox.Show(Resources.InsertInfo, Text, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (SqlException exc)
                {
                    transaction?.Rollback();

                    //FicheGuid = "";

                    XtraMessageBox.Show(exc.Message, Resources.SqlException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();

                    //FicheGuid = "";

                    XtraMessageBox.Show(ex.Message, Resources.ExceptionMessage, MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
                finally
                {
                    transaction?.Dispose();
                }
            }
            else
            {
                XtraMessageBox.Show(Resources.DatabaseConnectionError, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private String getStockNameByCode(String code)
        {
            var maladi = Database.GetRow($"SELECT MALAD FROM [TEKSTIL_UYG].[dbo].[STKKRT] skr WHERE skr.MALKOD ='{code}'", LoginForm.DataConnection);
            if (maladi == null)
                return "";
            else
                return maladi.ItemArray[0].ToString();
        }
        #endregion
    }
}