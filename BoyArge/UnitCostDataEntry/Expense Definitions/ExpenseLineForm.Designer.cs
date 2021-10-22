namespace BoyArge
{
    partial class ExpenseLineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseLineForm));
            this.vGrdExpenseLine = new DevExpress.XtraVerticalGrid.VGridControl();
            this.lookStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookExpenseID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookExchangeTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookUnitID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dateRowDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lookStockCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookProcessID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookMachineID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditPrice = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditCode3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lookStockGroupID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowExpenseLineID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowExpenseID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStockCode = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStockGroupID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowProcessID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMachineID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPrice = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowExchangeTypeID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowAmount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUnitID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowNote = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCode3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowRowGUID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdExpenseLine = new DevExpress.XtraGrid.GridControl();
            this.grvExpenseLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colExpenseLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colExpenseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdExpenseID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStockCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStockGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStockGroupID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProcessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdProcessID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdMachineID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchangeTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdExchangeTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdUnitID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateGrdDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditGrdCode3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeStatus = new DevExpress.XtraBars.BarButtonItem();
            this.seperator1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.toggleSwitch = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnEditRecords = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vGrdExpenseLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookExpenseID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookExchangeTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRowDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRowDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProcessID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExpenseLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExpenseLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdExpenseID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdProcessID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachineID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdExchangeTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateGrdDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateGrdDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // vGrdExpenseLine
            // 
            this.vGrdExpenseLine.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrdExpenseLine.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGrdExpenseLine.CustomizationFormBounds = new System.Drawing.Rectangle(457, 176, 214, 258);
            this.vGrdExpenseLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrdExpenseLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGrdExpenseLine.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGrdExpenseLine.Location = new System.Drawing.Point(0, 0);
            this.vGrdExpenseLine.Name = "vGrdExpenseLine";
            this.vGrdExpenseLine.RecordWidth = 158;
            this.vGrdExpenseLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookStatus,
            this.lookExpenseID,
            this.lookExchangeTypeID,
            this.lookUnitID,
            this.dateRowDate,
            this.lookStockCode,
            this.lookProcessID,
            this.lookMachineID,
            this.spinEditPrice,
            this.spinEditAmount,
            this.spinEditCode3,
            this.lookStockGroupID});
            this.vGrdExpenseLine.RowHeaderWidth = 42;
            this.vGrdExpenseLine.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowExpenseLineID,
            this.rowExpenseID,
            this.rowStockCode,
            this.rowStockGroupID,
            this.rowProcessID,
            this.rowMachineID,
            this.rowPrice,
            this.rowExchangeTypeID,
            this.rowAmount,
            this.rowUnitID,
            this.rowDate,
            this.rowNote,
            this.rowCode1,
            this.rowCode2,
            this.rowCode3,
            this.rowStatus,
            this.rowRowGUID});
            this.vGrdExpenseLine.Size = new System.Drawing.Size(704, 211);
            this.vGrdExpenseLine.TabIndex = 0;
            this.vGrdExpenseLine.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.VGrdExpenseLine_CellValueChanged);
            // 
            // lookStatus
            // 
            this.lookStatus.AutoHeight = false;
            this.lookStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.DisplayMember = "Name";
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.NullText = "Durum Seçiniz";
            this.lookStatus.ValueMember = "Code";
            // 
            // lookExpenseID
            // 
            this.lookExpenseID.AutoHeight = false;
            this.lookExpenseID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookExpenseID.DisplayMember = "Name";
            this.lookExpenseID.Name = "lookExpenseID";
            this.lookExpenseID.NullText = "Gider Seçiniz";
            this.lookExpenseID.ValueMember = "ExpenseID";
            // 
            // lookExchangeTypeID
            // 
            this.lookExchangeTypeID.AutoHeight = false;
            this.lookExchangeTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookExchangeTypeID.DisplayMember = "Name";
            this.lookExchangeTypeID.Name = "lookExchangeTypeID";
            this.lookExchangeTypeID.NullText = "Döviz Tipi Seçiniz";
            this.lookExchangeTypeID.ValueMember = "ExchangeTypeID";
            // 
            // lookUnitID
            // 
            this.lookUnitID.AutoHeight = false;
            this.lookUnitID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUnitID.DisplayMember = "Name";
            this.lookUnitID.Name = "lookUnitID";
            this.lookUnitID.NullText = "Birim Seçiniz";
            this.lookUnitID.ValueMember = "UnitID";
            // 
            // dateRowDate
            // 
            this.dateRowDate.AutoHeight = false;
            this.dateRowDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRowDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRowDate.Name = "dateRowDate";
            this.dateRowDate.NullText = "Tarih Giriniz";
            // 
            // lookStockCode
            // 
            this.lookStockCode.AutoHeight = false;
            this.lookStockCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStockCode.DisplayMember = "Name";
            this.lookStockCode.Name = "lookStockCode";
            this.lookStockCode.NullText = "Mamül Seçiniz";
            this.lookStockCode.ValueMember = "Code";
            // 
            // lookProcessID
            // 
            this.lookProcessID.AutoHeight = false;
            this.lookProcessID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookProcessID.DisplayMember = "Name";
            this.lookProcessID.Name = "lookProcessID";
            this.lookProcessID.NullText = "Proses Seçiniz";
            this.lookProcessID.ValueMember = "ProcessID";
            // 
            // lookMachineID
            // 
            this.lookMachineID.AutoHeight = false;
            this.lookMachineID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookMachineID.DisplayMember = "Name";
            this.lookMachineID.Name = "lookMachineID";
            this.lookMachineID.NullText = "Makine Seçiniz";
            this.lookMachineID.ValueMember = "MachineID";
            // 
            // spinEditPrice
            // 
            this.spinEditPrice.AutoHeight = false;
            this.spinEditPrice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditPrice.Name = "spinEditPrice";
            this.spinEditPrice.NullText = "Tutar Giriniz";
            // 
            // spinEditAmount
            // 
            this.spinEditAmount.AutoHeight = false;
            this.spinEditAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditAmount.Name = "spinEditAmount";
            this.spinEditAmount.NullText = "Miktar Seçiniz";
            // 
            // spinEditCode3
            // 
            this.spinEditCode3.AutoHeight = false;
            this.spinEditCode3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCode3.Name = "spinEditCode3";
            // 
            // lookStockGroupID
            // 
            this.lookStockGroupID.AutoHeight = false;
            this.lookStockGroupID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStockGroupID.DisplayMember = "Name";
            this.lookStockGroupID.Name = "lookStockGroupID";
            this.lookStockGroupID.NullText = "Malzeme Grubu Seçiniz";
            this.lookStockGroupID.ValueMember = "StockGroupID";
            // 
            // rowExpenseLineID
            // 
            this.rowExpenseLineID.Name = "rowExpenseLineID";
            this.rowExpenseLineID.Properties.Caption = "ExpenseLineID";
            this.rowExpenseLineID.Properties.FieldName = "ExpenseLineID";
            this.rowExpenseLineID.Visible = false;
            // 
            // rowExpenseID
            // 
            this.rowExpenseID.Height = 16;
            this.rowExpenseID.Name = "rowExpenseID";
            this.rowExpenseID.Properties.Caption = "Gider";
            this.rowExpenseID.Properties.FieldName = "ExpenseID";
            this.rowExpenseID.Properties.RowEdit = this.lookExpenseID;
            // 
            // rowStockCode
            // 
            this.rowStockCode.Name = "rowStockCode";
            this.rowStockCode.Properties.Caption = "Mamül";
            this.rowStockCode.Properties.FieldName = "StockCode";
            this.rowStockCode.Properties.RowEdit = this.lookStockCode;
            // 
            // rowStockGroupID
            // 
            this.rowStockGroupID.Name = "rowStockGroupID";
            this.rowStockGroupID.Properties.Caption = "Malzeme Grubu";
            this.rowStockGroupID.Properties.FieldName = "StockGroupID";
            this.rowStockGroupID.Properties.RowEdit = this.lookStockGroupID;
            // 
            // rowProcessID
            // 
            this.rowProcessID.Name = "rowProcessID";
            this.rowProcessID.Properties.Caption = "Proses";
            this.rowProcessID.Properties.FieldName = "ProcessID";
            this.rowProcessID.Properties.RowEdit = this.lookProcessID;
            // 
            // rowMachineID
            // 
            this.rowMachineID.Name = "rowMachineID";
            this.rowMachineID.Properties.Caption = "Makine";
            this.rowMachineID.Properties.FieldName = "MachineID";
            this.rowMachineID.Properties.RowEdit = this.lookMachineID;
            // 
            // rowPrice
            // 
            this.rowPrice.AppearanceCell.Options.UseTextOptions = true;
            this.rowPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowPrice.Height = 17;
            this.rowPrice.Name = "rowPrice";
            this.rowPrice.Properties.Caption = "Tutar";
            this.rowPrice.Properties.FieldName = "Price";
            this.rowPrice.Properties.RowEdit = this.spinEditPrice;
            // 
            // rowExchangeTypeID
            // 
            this.rowExchangeTypeID.Height = 16;
            this.rowExchangeTypeID.Name = "rowExchangeTypeID";
            this.rowExchangeTypeID.Properties.Caption = "Döviz Tipi";
            this.rowExchangeTypeID.Properties.FieldName = "ExchangeTypeID";
            this.rowExchangeTypeID.Properties.RowEdit = this.lookExchangeTypeID;
            // 
            // rowAmount
            // 
            this.rowAmount.AppearanceCell.Options.UseTextOptions = true;
            this.rowAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowAmount.Height = 16;
            this.rowAmount.Name = "rowAmount";
            this.rowAmount.Properties.Caption = "Miktar";
            this.rowAmount.Properties.FieldName = "Amount";
            this.rowAmount.Properties.RowEdit = this.spinEditAmount;
            // 
            // rowUnitID
            // 
            this.rowUnitID.Height = 16;
            this.rowUnitID.Name = "rowUnitID";
            this.rowUnitID.Properties.Caption = "Birim";
            this.rowUnitID.Properties.FieldName = "UnitID";
            this.rowUnitID.Properties.RowEdit = this.lookUnitID;
            // 
            // rowDate
            // 
            this.rowDate.Name = "rowDate";
            this.rowDate.Properties.Caption = "Tarih";
            this.rowDate.Properties.FieldName = "Date";
            this.rowDate.Properties.RowEdit = this.dateRowDate;
            // 
            // rowNote
            // 
            this.rowNote.Name = "rowNote";
            this.rowNote.Properties.Caption = "Açıklama";
            this.rowNote.Properties.FieldName = "Note";
            // 
            // rowCode1
            // 
            this.rowCode1.Name = "rowCode1";
            this.rowCode1.Properties.Caption = "Ek Alan - 1";
            this.rowCode1.Properties.FieldName = "Code1";
            // 
            // rowCode2
            // 
            this.rowCode2.Name = "rowCode2";
            this.rowCode2.Properties.Caption = "Ek Alan - 2";
            this.rowCode2.Properties.FieldName = "Code2";
            // 
            // rowCode3
            // 
            this.rowCode3.Name = "rowCode3";
            this.rowCode3.Properties.Caption = "Ek Alan - 3";
            this.rowCode3.Properties.FieldName = "Code3";
            this.rowCode3.Properties.RowEdit = this.spinEditCode3;
            // 
            // rowStatus
            // 
            this.rowStatus.Height = 16;
            this.rowStatus.Name = "rowStatus";
            this.rowStatus.Properties.Caption = "Durum";
            this.rowStatus.Properties.FieldName = "Status";
            this.rowStatus.Properties.RowEdit = this.lookStatus;
            // 
            // rowRowGUID
            // 
            this.rowRowGUID.Name = "rowRowGUID";
            this.rowRowGUID.Properties.Caption = "rowRowGUID";
            this.rowRowGUID.Properties.FieldName = "RowGUID";
            this.rowRowGUID.Visible = false;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 72);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.vGrdExpenseLine);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdExpenseLine);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(704, 609);
            this.splitContainerControl1.SplitterPosition = 211;
            this.splitContainerControl1.TabIndex = 5;
            // 
            // grdExpenseLine
            // 
            this.grdExpenseLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdExpenseLine.Location = new System.Drawing.Point(0, 0);
            this.grdExpenseLine.MainView = this.grvExpenseLine;
            this.grdExpenseLine.Name = "grdExpenseLine";
            this.grdExpenseLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookGrdExpenseID,
            this.lookGrdStatus,
            this.lookGrdExchangeTypeID,
            this.lookGrdUnitID,
            this.lookGrdStockCode,
            this.lookGrdProcessID,
            this.lookGrdMachineID,
            this.dateGrdDate,
            this.spinEditGrdCode3,
            this.lookGrdStockGroupID});
            this.grdExpenseLine.Size = new System.Drawing.Size(704, 388);
            this.grdExpenseLine.TabIndex = 0;
            this.grdExpenseLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvExpenseLine});
            // 
            // grvExpenseLine
            // 
            this.grvExpenseLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colExpenseLineID,
            this.colStatus,
            this.colExpenseID,
            this.colStockCode,
            this.colStockGroupID,
            this.colProcessID,
            this.colMachine,
            this.colPrice,
            this.colExchangeTypeID,
            this.colAmount,
            this.colUnitID,
            this.colDate,
            this.colNote,
            this.colRowGUID,
            this.colCode1,
            this.colCode2,
            this.colCode3});
            this.grvExpenseLine.GridControl = this.grdExpenseLine;
            this.grvExpenseLine.Name = "grvExpenseLine";
            this.grvExpenseLine.OptionsBehavior.Editable = false;
            this.grvExpenseLine.OptionsSelection.MultiSelect = true;
            this.grvExpenseLine.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvExpenseLine.OptionsView.ShowAutoFilterRow = true;
            this.grvExpenseLine.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GrvExpenseLine_PopupMenuShowing);
            this.grvExpenseLine.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrvExpenseLine_FocusedRowChanged);
            // 
            // colExpenseLineID
            // 
            this.colExpenseLineID.Caption = "ExpenseLineID";
            this.colExpenseLineID.FieldName = "ExpenseLineID";
            this.colExpenseLineID.Name = "colExpenseLineID";
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Durum";
            this.colStatus.ColumnEdit = this.lookGrdStatus;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 1;
            // 
            // lookGrdStatus
            // 
            this.lookGrdStatus.AutoHeight = false;
            this.lookGrdStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStatus.DisplayMember = "Name";
            this.lookGrdStatus.Name = "lookGrdStatus";
            this.lookGrdStatus.NullText = "Durum Seçiniz";
            this.lookGrdStatus.ValueMember = "Code";
            // 
            // colExpenseID
            // 
            this.colExpenseID.Caption = "Gider Türü";
            this.colExpenseID.ColumnEdit = this.lookGrdExpenseID;
            this.colExpenseID.FieldName = "ExpenseID";
            this.colExpenseID.Name = "colExpenseID";
            this.colExpenseID.Visible = true;
            this.colExpenseID.VisibleIndex = 2;
            // 
            // lookGrdExpenseID
            // 
            this.lookGrdExpenseID.AutoHeight = false;
            this.lookGrdExpenseID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdExpenseID.DisplayMember = "Name";
            this.lookGrdExpenseID.Name = "lookGrdExpenseID";
            this.lookGrdExpenseID.NullText = "Gider Türü Seçiniz";
            this.lookGrdExpenseID.ValueMember = "ExpenseID";
            // 
            // colStockCode
            // 
            this.colStockCode.Caption = "Malzeme";
            this.colStockCode.ColumnEdit = this.lookGrdStockCode;
            this.colStockCode.FieldName = "StockCode";
            this.colStockCode.Name = "colStockCode";
            this.colStockCode.Visible = true;
            this.colStockCode.VisibleIndex = 3;
            // 
            // lookGrdStockCode
            // 
            this.lookGrdStockCode.AutoHeight = false;
            this.lookGrdStockCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStockCode.DisplayMember = "Name";
            this.lookGrdStockCode.Name = "lookGrdStockCode";
            this.lookGrdStockCode.ValueMember = "Code";
            // 
            // colStockGroupID
            // 
            this.colStockGroupID.Caption = "Malzeme Grubu";
            this.colStockGroupID.ColumnEdit = this.lookGrdStockGroupID;
            this.colStockGroupID.FieldName = "StockGroupID";
            this.colStockGroupID.Name = "colStockGroupID";
            this.colStockGroupID.Visible = true;
            this.colStockGroupID.VisibleIndex = 15;
            // 
            // lookGrdStockGroupID
            // 
            this.lookGrdStockGroupID.AutoHeight = false;
            this.lookGrdStockGroupID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStockGroupID.DisplayMember = "Name";
            this.lookGrdStockGroupID.Name = "lookGrdStockGroupID";
            this.lookGrdStockGroupID.ValueMember = "StockGroupID";
            // 
            // colProcessID
            // 
            this.colProcessID.Caption = "Proses Adı";
            this.colProcessID.ColumnEdit = this.lookGrdProcessID;
            this.colProcessID.FieldName = "ProcessID";
            this.colProcessID.Name = "colProcessID";
            this.colProcessID.Visible = true;
            this.colProcessID.VisibleIndex = 4;
            // 
            // lookGrdProcessID
            // 
            this.lookGrdProcessID.AutoHeight = false;
            this.lookGrdProcessID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdProcessID.DisplayMember = "Name";
            this.lookGrdProcessID.Name = "lookGrdProcessID";
            this.lookGrdProcessID.ValueMember = "ProcessID";
            // 
            // colMachine
            // 
            this.colMachine.Caption = "Makine Adı";
            this.colMachine.ColumnEdit = this.lookGrdMachineID;
            this.colMachine.FieldName = "MachineID";
            this.colMachine.Name = "colMachine";
            this.colMachine.Visible = true;
            this.colMachine.VisibleIndex = 5;
            // 
            // lookGrdMachineID
            // 
            this.lookGrdMachineID.AutoHeight = false;
            this.lookGrdMachineID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdMachineID.DisplayMember = "Name";
            this.lookGrdMachineID.Name = "lookGrdMachineID";
            this.lookGrdMachineID.ValueMember = "MachineID";
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Tutar";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 6;
            // 
            // colExchangeTypeID
            // 
            this.colExchangeTypeID.Caption = "Döviz Tipi";
            this.colExchangeTypeID.ColumnEdit = this.lookGrdExchangeTypeID;
            this.colExchangeTypeID.FieldName = "ExchangeTypeID";
            this.colExchangeTypeID.Name = "colExchangeTypeID";
            this.colExchangeTypeID.Visible = true;
            this.colExchangeTypeID.VisibleIndex = 7;
            // 
            // lookGrdExchangeTypeID
            // 
            this.lookGrdExchangeTypeID.AutoHeight = false;
            this.lookGrdExchangeTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdExchangeTypeID.DisplayMember = "Name";
            this.lookGrdExchangeTypeID.Name = "lookGrdExchangeTypeID";
            this.lookGrdExchangeTypeID.NullText = "Döviz Tipi Seçiniz";
            this.lookGrdExchangeTypeID.ValueMember = "ExchangeTypeID";
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Miktar";
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 8;
            // 
            // colUnitID
            // 
            this.colUnitID.Caption = "Birim";
            this.colUnitID.ColumnEdit = this.lookGrdUnitID;
            this.colUnitID.FieldName = "UnitID";
            this.colUnitID.Name = "colUnitID";
            this.colUnitID.Visible = true;
            this.colUnitID.VisibleIndex = 9;
            // 
            // lookGrdUnitID
            // 
            this.lookGrdUnitID.AutoHeight = false;
            this.lookGrdUnitID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdUnitID.DisplayMember = "Name";
            this.lookGrdUnitID.Name = "lookGrdUnitID";
            this.lookGrdUnitID.NullText = "Birim Seçiniz";
            this.lookGrdUnitID.ValueMember = "UnitID";
            // 
            // colDate
            // 
            this.colDate.Caption = "Tarih";
            this.colDate.ColumnEdit = this.dateGrdDate;
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 10;
            // 
            // dateGrdDate
            // 
            this.dateGrdDate.AutoHeight = false;
            this.dateGrdDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateGrdDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateGrdDate.Name = "dateGrdDate";
            // 
            // colNote
            // 
            this.colNote.Caption = "Açıklama";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 11;
            // 
            // colRowGUID
            // 
            this.colRowGUID.Caption = "rowGUID";
            this.colRowGUID.FieldName = "RowGUID";
            this.colRowGUID.Name = "colRowGUID";
            // 
            // colCode1
            // 
            this.colCode1.Caption = "Ek Alan - 1";
            this.colCode1.FieldName = "Code1";
            this.colCode1.Name = "colCode1";
            this.colCode1.Visible = true;
            this.colCode1.VisibleIndex = 12;
            // 
            // colCode2
            // 
            this.colCode2.Caption = "Ek Alan - 2";
            this.colCode2.FieldName = "Code2";
            this.colCode2.Name = "colCode2";
            this.colCode2.Visible = true;
            this.colCode2.VisibleIndex = 13;
            // 
            // colCode3
            // 
            this.colCode3.Caption = "Ek Alan - 3";
            this.colCode3.ColumnEdit = this.spinEditGrdCode3;
            this.colCode3.FieldName = "Code3";
            this.colCode3.Name = "colCode3";
            this.colCode3.Visible = true;
            this.colCode3.VisibleIndex = 14;
            // 
            // spinEditGrdCode3
            // 
            this.spinEditGrdCode3.AutoHeight = false;
            this.spinEditGrdCode3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditGrdCode3.Name = "spinEditGrdCode3";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnRefresh,
            this.btnChangeStatus,
            this.seperator1,
            this.barButtonItem1,
            this.toggleSwitch,
            this.btnEditRecords});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 21);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbonControl1.Size = new System.Drawing.Size(704, 51);
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Yeni";
            this.btnNew.Id = 1;
            this.btnNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNew.ImageOptions.SvgImage")));
            this.btnNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnNew.Name = "btnNew";
            this.btnNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnNew_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Düzenle";
            this.btnEdit.Id = 2;
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnEdit_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Kaydet";
            this.btnSave.Id = 3;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.Name = "btnSave";
            this.btnSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSave_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Sil";
            this.btnDelete.Id = 4;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDelete_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Yenile";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRefresh_ItemClick);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Caption = "-";
            this.btnChangeStatus.Id = 6;
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnChangeStatus_ItemClick);
            // 
            // seperator1
            // 
            this.seperator1.Caption = "||";
            this.seperator1.Id = 7;
            this.seperator1.Name = "seperator1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // toggleSwitch
            // 
            this.toggleSwitch.Caption = global::BoyArge.Properties.Resources.OnlyActiveRecords;
            this.toggleSwitch.Id = 9;
            this.toggleSwitch.Name = "toggleSwitch";
            this.toggleSwitch.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ToggleSwitch_CheckedChanged);
            // 
            // btnEditRecords
            // 
            this.btnEditRecords.Caption = "Toplu Düzenle";
            this.btnEditRecords.Id = 10;
            this.btnEditRecords.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEditRecords.ImageOptions.SvgImage")));
            this.btnEditRecords.Name = "btnEditRecords";
            this.btnEditRecords.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditRecords_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.seperator1);
            this.ribbonPageGroup1.ItemLinks.Add(this.toggleSwitch);
            this.ribbonPageGroup1.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(704, 21);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 681);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(704, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 660);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(704, 21);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 660);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnChangeStatus);
            this.popupMenu.ItemLinks.Add(this.btnEditRecords);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbonControl1;
            // 
            // ExpenseLineForm
            // 
            this.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 681);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "ExpenseLineForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gider Kayıtları Ekranı";
            this.Load += new System.EventHandler(this.ExpenseLineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vGrdExpenseLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookExpenseID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookExchangeTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRowDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRowDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookProcessID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStockGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExpenseLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExpenseLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdExpenseID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStockGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdProcessID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachineID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdExchangeTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateGrdDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateGrdDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditGrdCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraVerticalGrid.VGridControl vGrdExpenseLine;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowExpenseLineID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPrice;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowAmount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRowGUID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookExpenseID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStatus;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnChangeStatus;
        private DevExpress.XtraBars.BarHeaderItem seperator1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarToggleSwitchItem toggleSwitch;
        private DevExpress.XtraGrid.GridControl grdExpenseLine;
        private DevExpress.XtraGrid.Views.Grid.GridView grvExpenseLine;
        private DevExpress.XtraGrid.Columns.GridColumn colExpenseLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdExpenseID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowExpenseID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowExchangeTypeID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn colExpenseID;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdExchangeTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdUnitID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookExchangeTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn colStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessID;
        private DevExpress.XtraGrid.Columns.GridColumn colMachine;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStockCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdProcessID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdMachineID;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dateGrdDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dateRowDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStockCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookProcessID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookMachineID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStockCode;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowNote;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProcessID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMachineID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditCode3;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCode3;
        private DevExpress.XtraGrid.Columns.GridColumn colCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colCode3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditGrdCode3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStockGroupID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStockGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colStockGroupID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStockGroupID;
        private DevExpress.XtraBars.BarButtonItem btnEditRecords;
    }
}