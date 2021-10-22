namespace BoyArge
{
    partial class DepartmentRelationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentRelationForm));
            this.grdDepartmentRelation = new DevExpress.XtraGrid.GridControl();
            this.grvDepartmentRelation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDepartmentRelationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdDepartmentID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMachineGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdMachineGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTitleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdTitleID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colWorkerCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDirectOrIndirect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrivateOrPublic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDirectIndirect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrivatePublic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalaryOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnnualMonthly = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftDaytime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchangeTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGrdExchangeTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSalaryOrOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnnualorMonthly = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftorDaytime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRowGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vGrdDepartmentRelation = new DevExpress.XtraVerticalGrid.VGridControl();
            this.lookStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinEditPersonelCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinEditCost = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.toggleDirectOrIndirect = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.lookExchangeTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookDepartmentID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookTitleID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.togglePrivateOrPublic = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.repositoryItemDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemMonth = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lookMachineGroupID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.toggleSalaryOrOvertime = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.toggleAnnualorMonthly = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.toggleShiftorDaytime = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.spinEditWorkerCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rowDepartmentRelationID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDepartmentID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMachineGroupID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTitleID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowWorkerCount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCost = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowExchangeTypeID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDirectOrIndirect = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPrivateOrPublic = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSalaryOrOvertime = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowAnnualorMonthly = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowShiftorDaytime = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMonth = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowRowGUID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.seperator1 = new DevExpress.XtraBars.BarHeaderItem();
            this.toggleSwitch = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnChangeStatus = new DevExpress.XtraBars.BarButtonItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartmentRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartmentRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdDepartmentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachineGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdTitleID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdExchangeTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdDepartmentRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPersonelCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleDirectOrIndirect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookExchangeTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookDepartmentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookTitleID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.togglePrivateOrPublic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMonth.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSalaryOrOvertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleAnnualorMonthly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleShiftorDaytime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWorkerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDepartmentRelation
            // 
            this.grdDepartmentRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDepartmentRelation.Location = new System.Drawing.Point(0, 0);
            this.grdDepartmentRelation.MainView = this.grvDepartmentRelation;
            this.grdDepartmentRelation.Name = "grdDepartmentRelation";
            this.grdDepartmentRelation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookGrdStatus,
            this.lookGrdExchangeTypeID,
            this.lookGrdDepartmentID,
            this.lookGrdTitleID,
            this.lookGrdMachineGroup});
            this.grdDepartmentRelation.Size = new System.Drawing.Size(704, 337);
            this.grdDepartmentRelation.TabIndex = 0;
            this.grdDepartmentRelation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDepartmentRelation});
            // 
            // grvDepartmentRelation
            // 
            this.grvDepartmentRelation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDepartmentRelationID,
            this.colStatus,
            this.colDepartmentID,
            this.colMachineGroupID,
            this.colTitleID,
            this.colWorkerCount,
            this.colCost,
            this.colDirectOrIndirect,
            this.colPrivateOrPublic,
            this.colDirectIndirect,
            this.colPrivatePublic,
            this.colSalaryOvertime,
            this.colAnnualMonthly,
            this.colShiftDaytime,
            this.colExchangeTypeID,
            this.colSalaryOrOvertime,
            this.colAnnualorMonthly,
            this.colShiftorDaytime,
            this.colMonth,
            this.colDate,
            this.colRowGUID});
            this.grvDepartmentRelation.GridControl = this.grdDepartmentRelation;
            this.grvDepartmentRelation.Name = "grvDepartmentRelation";
            this.grvDepartmentRelation.OptionsBehavior.Editable = false;
            this.grvDepartmentRelation.OptionsView.ShowAutoFilterRow = true;
            this.grvDepartmentRelation.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GrvDepartmentRelation_PopupMenuShowing);
            this.grvDepartmentRelation.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrvDepartmentRelation_FocusedRowChanged);
            // 
            // colDepartmentRelationID
            // 
            this.colDepartmentRelationID.Caption = "DepartmentRelationID";
            this.colDepartmentRelationID.FieldName = "DepartmentRelationID";
            this.colDepartmentRelationID.Name = "colDepartmentRelationID";
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Durum";
            this.colStatus.ColumnEdit = this.lookGrdStatus;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 0;
            // 
            // lookGrdStatus
            // 
            this.lookGrdStatus.AutoHeight = false;
            this.lookGrdStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdStatus.Name = "lookGrdStatus";
            this.lookGrdStatus.NullText = "Durum Seçiniz";
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.Caption = "Departman";
            this.colDepartmentID.ColumnEdit = this.lookGrdDepartmentID;
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.Visible = true;
            this.colDepartmentID.VisibleIndex = 1;
            // 
            // lookGrdDepartmentID
            // 
            this.lookGrdDepartmentID.AutoHeight = false;
            this.lookGrdDepartmentID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdDepartmentID.DisplayMember = "Name";
            this.lookGrdDepartmentID.Name = "lookGrdDepartmentID";
            this.lookGrdDepartmentID.ValueMember = "DepartmentID";
            // 
            // colMachineGroupID
            // 
            this.colMachineGroupID.Caption = "Makine Grubu";
            this.colMachineGroupID.ColumnEdit = this.lookGrdMachineGroup;
            this.colMachineGroupID.FieldName = "MachineGroupID";
            this.colMachineGroupID.Name = "colMachineGroupID";
            this.colMachineGroupID.Visible = true;
            this.colMachineGroupID.VisibleIndex = 2;
            // 
            // lookGrdMachineGroup
            // 
            this.lookGrdMachineGroup.AutoHeight = false;
            this.lookGrdMachineGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdMachineGroup.Name = "lookGrdMachineGroup";
            // 
            // colTitleID
            // 
            this.colTitleID.Caption = "Ünvan";
            this.colTitleID.ColumnEdit = this.lookGrdTitleID;
            this.colTitleID.FieldName = "TitleID";
            this.colTitleID.Name = "colTitleID";
            this.colTitleID.Visible = true;
            this.colTitleID.VisibleIndex = 3;
            // 
            // lookGrdTitleID
            // 
            this.lookGrdTitleID.AutoHeight = false;
            this.lookGrdTitleID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrdTitleID.DisplayMember = "Name";
            this.lookGrdTitleID.Name = "lookGrdTitleID";
            this.lookGrdTitleID.ValueMember = "TitleID";
            // 
            // colWorkerCount
            // 
            this.colWorkerCount.Caption = "İşçi Sayısı";
            this.colWorkerCount.FieldName = "WorkerCount";
            this.colWorkerCount.Name = "colWorkerCount";
            this.colWorkerCount.Visible = true;
            this.colWorkerCount.VisibleIndex = 13;
            // 
            // colCost
            // 
            this.colCost.Caption = "Ort. Maaş";
            this.colCost.FieldName = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.Visible = true;
            this.colCost.VisibleIndex = 4;
            // 
            // colDirectOrIndirect
            // 
            this.colDirectOrIndirect.Caption = "Direkt/Endirekt";
            this.colDirectOrIndirect.FieldName = "DirectOrIndirect";
            this.colDirectOrIndirect.Name = "colDirectOrIndirect";
            // 
            // colPrivateOrPublic
            // 
            this.colPrivateOrPublic.Caption = "Bireysel/Toplu";
            this.colPrivateOrPublic.FieldName = "PrivateOrPublic";
            this.colPrivateOrPublic.Name = "colPrivateOrPublic";
            // 
            // colDirectIndirect
            // 
            this.colDirectIndirect.Caption = "Direkt/Endirekt";
            this.colDirectIndirect.FieldName = "DirectIndirect";
            this.colDirectIndirect.Name = "colDirectIndirect";
            this.colDirectIndirect.Visible = true;
            this.colDirectIndirect.VisibleIndex = 5;
            // 
            // colPrivatePublic
            // 
            this.colPrivatePublic.Caption = "Bireysel/Toplu";
            this.colPrivatePublic.FieldName = "PrivatePublic";
            this.colPrivatePublic.Name = "colPrivatePublic";
            this.colPrivatePublic.Visible = true;
            this.colPrivatePublic.VisibleIndex = 6;
            // 
            // colSalaryOvertime
            // 
            this.colSalaryOvertime.Caption = "Maaş/Mesai";
            this.colSalaryOvertime.FieldName = "SalaryOvertime";
            this.colSalaryOvertime.Name = "colSalaryOvertime";
            this.colSalaryOvertime.Visible = true;
            this.colSalaryOvertime.VisibleIndex = 10;
            // 
            // colAnnualMonthly
            // 
            this.colAnnualMonthly.Caption = "Yıllık/Aylık";
            this.colAnnualMonthly.FieldName = "AnnualMonthly";
            this.colAnnualMonthly.Name = "colAnnualMonthly";
            this.colAnnualMonthly.Visible = true;
            this.colAnnualMonthly.VisibleIndex = 11;
            // 
            // colShiftDaytime
            // 
            this.colShiftDaytime.Caption = "Vardiya/Gündüz";
            this.colShiftDaytime.FieldName = "ShiftDaytime";
            this.colShiftDaytime.Name = "colShiftDaytime";
            this.colShiftDaytime.Visible = true;
            this.colShiftDaytime.VisibleIndex = 12;
            // 
            // colExchangeTypeID
            // 
            this.colExchangeTypeID.Caption = "Para Birimi";
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
            this.lookGrdExchangeTypeID.Name = "lookGrdExchangeTypeID";
            // 
            // colSalaryOrOvertime
            // 
            this.colSalaryOrOvertime.Caption = "Maaş/Mesai";
            this.colSalaryOrOvertime.FieldName = "SalaryOrOvertime";
            this.colSalaryOrOvertime.Name = "colSalaryOrOvertime";
            // 
            // colAnnualorMonthly
            // 
            this.colAnnualorMonthly.Caption = "Yıllık/Aylık";
            this.colAnnualorMonthly.FieldName = "AnnualorMonthly";
            this.colAnnualorMonthly.Name = "colAnnualorMonthly";
            // 
            // colShiftorDaytime
            // 
            this.colShiftorDaytime.Caption = "Vardiya/Gündüz";
            this.colShiftorDaytime.FieldName = "ShiftorDayTime";
            this.colShiftorDaytime.Name = "colShiftorDaytime";
            // 
            // colMonth
            // 
            this.colMonth.Caption = "Ay";
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.Visible = true;
            this.colMonth.VisibleIndex = 8;
            // 
            // colDate
            // 
            this.colDate.Caption = "Tarih";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 9;
            // 
            // colRowGUID
            // 
            this.colRowGUID.Caption = "rowGUID";
            this.colRowGUID.FieldName = "RowGUID";
            this.colRowGUID.Name = "colRowGUID";
            // 
            // vGrdDepartmentRelation
            // 
            this.vGrdDepartmentRelation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.vGrdDepartmentRelation.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGrdDepartmentRelation.CustomizationFormBounds = new System.Drawing.Rectangle(457, 176, 214, 258);
            this.vGrdDepartmentRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGrdDepartmentRelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGrdDepartmentRelation.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGrdDepartmentRelation.Location = new System.Drawing.Point(0, 0);
            this.vGrdDepartmentRelation.Name = "vGrdDepartmentRelation";
            this.vGrdDepartmentRelation.RecordWidth = 158;
            this.vGrdDepartmentRelation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookStatus,
            this.spinEditPersonelCount,
            this.spinEditCost,
            this.toggleDirectOrIndirect,
            this.lookExchangeTypeID,
            this.lookDepartmentID,
            this.lookTitleID,
            this.togglePrivateOrPublic,
            this.repositoryItemDate,
            this.repositoryItemMonth,
            this.lookMachineGroupID,
            this.toggleSalaryOrOvertime,
            this.toggleAnnualorMonthly,
            this.toggleShiftorDaytime,
            this.spinEditWorkerCount});
            this.vGrdDepartmentRelation.RowHeaderWidth = 42;
            this.vGrdDepartmentRelation.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowDepartmentRelationID,
            this.rowDepartmentID,
            this.rowMachineGroupID,
            this.rowTitleID,
            this.rowWorkerCount,
            this.rowCost,
            this.rowExchangeTypeID,
            this.rowDirectOrIndirect,
            this.rowPrivateOrPublic,
            this.rowSalaryOrOvertime,
            this.rowAnnualorMonthly,
            this.rowShiftorDaytime,
            this.rowMonth,
            this.rowDate,
            this.rowStatus,
            this.rowRowGUID});
            this.vGrdDepartmentRelation.Size = new System.Drawing.Size(704, 260);
            this.vGrdDepartmentRelation.TabIndex = 0;
            // 
            // lookStatus
            // 
            this.lookStatus.AutoHeight = false;
            this.lookStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.NullText = "Durum Seçiniz";
            // 
            // spinEditPersonelCount
            // 
            this.spinEditPersonelCount.AutoHeight = false;
            this.spinEditPersonelCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditPersonelCount.Name = "spinEditPersonelCount";
            this.spinEditPersonelCount.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditPersonelCount_Validating);
            // 
            // spinEditCost
            // 
            this.spinEditCost.AutoHeight = false;
            this.spinEditCost.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCost.Name = "spinEditCost";
            this.spinEditCost.NullText = "Ort. Maaş Giriniz";
            this.spinEditCost.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditCost_Validating);
            // 
            // toggleDirectOrIndirect
            // 
            this.toggleDirectOrIndirect.AutoHeight = false;
            this.toggleDirectOrIndirect.Name = "toggleDirectOrIndirect";
            this.toggleDirectOrIndirect.OffText = "Doğrudan";
            this.toggleDirectOrIndirect.OnText = "Dolaylı";
            // 
            // lookExchangeTypeID
            // 
            this.lookExchangeTypeID.AutoHeight = false;
            this.lookExchangeTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookExchangeTypeID.Name = "lookExchangeTypeID";
            this.lookExchangeTypeID.NullText = "Para Birimi Seçiniz";
            // 
            // lookDepartmentID
            // 
            this.lookDepartmentID.AutoHeight = false;
            this.lookDepartmentID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookDepartmentID.DisplayMember = "Name";
            this.lookDepartmentID.Name = "lookDepartmentID";
            this.lookDepartmentID.NullText = "Departman Seçiniz";
            this.lookDepartmentID.ValueMember = "DepartmentID";
            // 
            // lookTitleID
            // 
            this.lookTitleID.AutoHeight = false;
            this.lookTitleID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookTitleID.DisplayMember = "Name";
            this.lookTitleID.Name = "lookTitleID";
            this.lookTitleID.NullText = "Ünvan Seçiniz";
            this.lookTitleID.ValueMember = "TitleID";
            // 
            // togglePrivateOrPublic
            // 
            this.togglePrivateOrPublic.AutoHeight = false;
            this.togglePrivateOrPublic.Name = "togglePrivateOrPublic";
            this.togglePrivateOrPublic.OffText = "Bireysel";
            this.togglePrivateOrPublic.OnText = "Toplu";
            // 
            // repositoryItemDate
            // 
            this.repositoryItemDate.AutoHeight = false;
            this.repositoryItemDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDate.Name = "repositoryItemDate";
            this.repositoryItemDate.NullText = "Tarih Giriniz";
            // 
            // repositoryItemMonth
            // 
            this.repositoryItemMonth.AutoHeight = false;
            this.repositoryItemMonth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMonth.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMonth.Name = "repositoryItemMonth";
            this.repositoryItemMonth.NullText = "Ay Bilgisini Giriniz";
            // 
            // lookMachineGroupID
            // 
            this.lookMachineGroupID.AutoHeight = false;
            this.lookMachineGroupID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookMachineGroupID.DisplayMember = "Name";
            this.lookMachineGroupID.Name = "lookMachineGroupID";
            this.lookMachineGroupID.NullText = "Makine Grubu Seçiniz";
            this.lookMachineGroupID.ValueMember = "MachineGroupID";
            // 
            // toggleSalaryOrOvertime
            // 
            this.toggleSalaryOrOvertime.AutoHeight = false;
            this.toggleSalaryOrOvertime.Name = "toggleSalaryOrOvertime";
            this.toggleSalaryOrOvertime.OffText = "Maaş";
            this.toggleSalaryOrOvertime.OnText = "Mesai";
            // 
            // toggleAnnualorMonthly
            // 
            this.toggleAnnualorMonthly.AutoHeight = false;
            this.toggleAnnualorMonthly.Name = "toggleAnnualorMonthly";
            this.toggleAnnualorMonthly.OffText = "Yıllık";
            this.toggleAnnualorMonthly.OnText = "Aylık";
            // 
            // toggleShiftorDaytime
            // 
            this.toggleShiftorDaytime.AutoHeight = false;
            this.toggleShiftorDaytime.Name = "toggleShiftorDaytime";
            this.toggleShiftorDaytime.OffText = "Off";
            this.toggleShiftorDaytime.OnText = "On";
            // 
            // spinEditWorkerCount
            // 
            this.spinEditWorkerCount.AutoHeight = false;
            this.spinEditWorkerCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditWorkerCount.Name = "spinEditWorkerCount";
            this.spinEditWorkerCount.NullText = "İşçi Sayısını Giriniz";
            this.spinEditWorkerCount.Validating += new System.ComponentModel.CancelEventHandler(this.spinEditWorkerCount_Validating);
            // 
            // rowDepartmentRelationID
            // 
            this.rowDepartmentRelationID.Name = "rowDepartmentRelationID";
            this.rowDepartmentRelationID.Properties.Caption = "DepartmentRelationID";
            this.rowDepartmentRelationID.Properties.FieldName = "DepartmentRelationID";
            this.rowDepartmentRelationID.Visible = false;
            // 
            // rowDepartmentID
            // 
            this.rowDepartmentID.Height = 16;
            this.rowDepartmentID.Name = "rowDepartmentID";
            this.rowDepartmentID.Properties.Caption = "Departman";
            this.rowDepartmentID.Properties.FieldName = "DepartmentID";
            this.rowDepartmentID.Properties.RowEdit = this.lookDepartmentID;
            // 
            // rowMachineGroupID
            // 
            this.rowMachineGroupID.Name = "rowMachineGroupID";
            this.rowMachineGroupID.Properties.Caption = "Makine Grubu";
            this.rowMachineGroupID.Properties.FieldName = "MachineGroupID";
            this.rowMachineGroupID.Properties.RowEdit = this.lookMachineGroupID;
            // 
            // rowTitleID
            // 
            this.rowTitleID.Height = 16;
            this.rowTitleID.Name = "rowTitleID";
            this.rowTitleID.Properties.Caption = "Ünvan";
            this.rowTitleID.Properties.FieldName = "TitleID";
            this.rowTitleID.Properties.RowEdit = this.lookTitleID;
            // 
            // rowWorkerCount
            // 
            this.rowWorkerCount.Name = "rowWorkerCount";
            this.rowWorkerCount.Properties.Caption = "İşçi Sayısı";
            this.rowWorkerCount.Properties.FieldName = "WorkerCount";
            this.rowWorkerCount.Properties.RowEdit = this.spinEditWorkerCount;
            // 
            // rowCost
            // 
            this.rowCost.AppearanceCell.Options.UseTextOptions = true;
            this.rowCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rowCost.Name = "rowCost";
            this.rowCost.Properties.Caption = "Ort. Maaş";
            this.rowCost.Properties.FieldName = "Cost";
            this.rowCost.Properties.RowEdit = this.spinEditCost;
            // 
            // rowExchangeTypeID
            // 
            this.rowExchangeTypeID.Name = "rowExchangeTypeID";
            this.rowExchangeTypeID.Properties.Caption = "Para Birimi";
            this.rowExchangeTypeID.Properties.FieldName = "ExchangeTypeID";
            this.rowExchangeTypeID.Properties.RowEdit = this.lookExchangeTypeID;
            // 
            // rowDirectOrIndirect
            // 
            this.rowDirectOrIndirect.Name = "rowDirectOrIndirect";
            this.rowDirectOrIndirect.Properties.Caption = "Direkt/Endirekt";
            this.rowDirectOrIndirect.Properties.RowEdit = this.toggleDirectOrIndirect;
            // 
            // rowPrivateOrPublic
            // 
            this.rowPrivateOrPublic.Name = "rowPrivateOrPublic";
            this.rowPrivateOrPublic.Properties.Caption = "Bireysel/Toplu";
            this.rowPrivateOrPublic.Properties.FieldName = "PrivateOrPublic";
            this.rowPrivateOrPublic.Properties.RowEdit = this.togglePrivateOrPublic;
            // 
            // rowSalaryOrOvertime
            // 
            this.rowSalaryOrOvertime.Name = "rowSalaryOrOvertime";
            this.rowSalaryOrOvertime.Properties.Caption = "Maaş/Mesai";
            this.rowSalaryOrOvertime.Properties.FieldName = "SalaryOrOvertime";
            this.rowSalaryOrOvertime.Properties.RowEdit = this.toggleSalaryOrOvertime;
            // 
            // rowAnnualorMonthly
            // 
            this.rowAnnualorMonthly.Name = "rowAnnualorMonthly";
            this.rowAnnualorMonthly.Properties.Caption = "Yıllık/Aylık";
            this.rowAnnualorMonthly.Properties.FieldName = "AnnualorMonthly";
            this.rowAnnualorMonthly.Properties.RowEdit = this.toggleAnnualorMonthly;
            // 
            // rowShiftorDaytime
            // 
            this.rowShiftorDaytime.Name = "rowShiftorDaytime";
            this.rowShiftorDaytime.Properties.Caption = "Vardiya/Gündüz";
            this.rowShiftorDaytime.Properties.FieldName = "ShiftorDaytime";
            this.rowShiftorDaytime.Properties.RowEdit = this.toggleShiftorDaytime;
            // 
            // rowMonth
            // 
            this.rowMonth.Name = "rowMonth";
            this.rowMonth.Properties.Caption = "Ay";
            this.rowMonth.Properties.FieldName = "Month";
            this.rowMonth.Properties.RowEdit = this.repositoryItemMonth;
            // 
            // rowDate
            // 
            this.rowDate.Name = "rowDate";
            this.rowDate.Properties.Caption = "Tarih";
            this.rowDate.Properties.FieldName = "Date";
            this.rowDate.Properties.RowEdit = this.repositoryItemDate;
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 74);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.vGrdDepartmentRelation);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdDepartmentRelation);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(704, 607);
            this.splitContainerControl1.SplitterPosition = 260;
            this.splitContainerControl1.TabIndex = 5;
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
            this.seperator1,
            this.toggleSwitch,
            this.btnChangeStatus});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 23);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbonControl1.Size = new System.Drawing.Size(704, 51);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Below;
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
            // seperator1
            // 
            this.seperator1.Caption = "||";
            this.seperator1.Id = 6;
            this.seperator1.Name = "seperator1";
            // 
            // toggleSwitch
            // 
            this.toggleSwitch.Caption = global::BoyArge.Properties.Resources.OnlyActiveRecords;
            this.toggleSwitch.Id = 7;
            this.toggleSwitch.Name = "toggleSwitch";
            this.toggleSwitch.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ToggleSwitch_CheckedChanged);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Caption = "-";
            this.btnChangeStatus.Id = 8;
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnChangeStatus_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(704, 23);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 23);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 658);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(704, 23);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 658);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnChangeStatus);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbonControl1;
            // 
            // DepartmentRelationForm
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
            this.Name = "DepartmentRelationForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departman İlişki Tanımı";
            this.Load += new System.EventHandler(this.DepartmentRelationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartmentRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartmentRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdDepartmentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdMachineGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdTitleID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrdExchangeTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGrdDepartmentRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPersonelCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleDirectOrIndirect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookExchangeTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookDepartmentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookTitleID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.togglePrivateOrPublic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMonth.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMachineGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSalaryOrOvertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleAnnualorMonthly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleShiftorDaytime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWorkerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdDepartmentRelation;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDepartmentRelation;
        private DevExpress.XtraVerticalGrid.VGridControl vGrdDepartmentRelation;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentRelationID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn colTitleID;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGUID;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDepartmentRelationID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDepartmentID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTitleID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRowGUID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdStatus;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarHeaderItem seperator1;
        private DevExpress.XtraBars.BarToggleSwitchItem toggleSwitch;
        private DevExpress.XtraBars.BarButtonItem btnChangeStatus;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditPersonelCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch toggleDirectOrIndirect;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCost;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDirectOrIndirect;
        private DevExpress.XtraGrid.Columns.GridColumn colCost;
        private DevExpress.XtraGrid.Columns.GridColumn colDirectOrIndirect;
        private DevExpress.XtraGrid.Columns.GridColumn colDirectIndirect;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdExchangeTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookExchangeTypeID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowExchangeTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdDepartmentID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdTitleID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookDepartmentID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookTitleID;
        private DevExpress.XtraGrid.Columns.GridColumn colPrivateOrPublic;
        private DevExpress.XtraGrid.Columns.GridColumn colPrivatePublic;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPrivateOrPublic;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch togglePrivateOrPublic;
        private DevExpress.XtraGrid.Columns.GridColumn colSalaryOrOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colAnnualorMonthly;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookMachineGroupID;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch toggleSalaryOrOvertime;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch toggleAnnualorMonthly;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMachineGroupID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSalaryOrOvertime;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowAnnualorMonthly;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMonth;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDate;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineGroupID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookGrdMachineGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colSalaryOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colAnnualMonthly;
        private DevExpress.XtraGrid.Columns.GridColumn colShiftDaytime;
        private DevExpress.XtraGrid.Columns.GridColumn colShiftorDaytime;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch toggleShiftorDaytime;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowShiftorDaytime;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkerCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinEditWorkerCount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowWorkerCount;
    }
}