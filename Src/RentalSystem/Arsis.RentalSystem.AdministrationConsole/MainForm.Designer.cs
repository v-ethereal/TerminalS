using System.Windows.Forms;

namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory3 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory4 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory5 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory6 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory7 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory8 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiServices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPriceList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRentalPropertyList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHolidays = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContracts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRentalPayLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiServicePayLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCashlessPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNotPaidReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaidReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNotTransferedPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPivotTableReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContractStateReport = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_ReportPaidForServices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ReportParkingPays = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.tsbContractsList = new System.Windows.Forms.ToolStripButton();
            this.tsbPriceList = new System.Windows.Forms.ToolStripButton();
            this.tsbRentalPayLog = new System.Windows.Forms.ToolStripButton();
            this.tsbServicePayLog = new System.Windows.Forms.ToolStripButton();
            this.tcTabControl = new System.Windows.Forms.TabControl();
            this.tpServices = new System.Windows.Forms.TabPage();
            this.dgvOtherServices = new System.Windows.Forms.DataGridView();
            this.OtherServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherServiceCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherServiceIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OtherServiceIsRental = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsParkingPerHour = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ParkingWithoutTime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsOtherServices = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UsePlaceNumber = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnServiceCurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OneSColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherServicePictureThumbnail = new System.Windows.Forms.DataGridViewImageColumn();
            this.OtherServicePicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmsOtherService = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddOtherService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditOtherService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveOtherService = new System.Windows.Forms.ToolStripMenuItem();
            this.gbOtherServicesActions = new System.Windows.Forms.GroupBox();
            this.btnServicesListPrint = new System.Windows.Forms.Button();
            this.btnRefreshServicesList = new System.Windows.Forms.Button();
            this.btnDeleteOtherService = new System.Windows.Forms.Button();
            this.btnEditOtherService = new System.Windows.Forms.Button();
            this.btnInsertOtherService = new System.Windows.Forms.Button();
            this.llClearOtherServicesFilter = new System.Windows.Forms.LinkLabel();
            this.tpPriceList = new System.Windows.Forms.TabPage();
            this.llClearPriceListFilter = new System.Windows.Forms.LinkLabel();
            this.dgvPriceList = new System.Windows.Forms.DataGridView();
            this.PriceListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPriceListServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPriceListPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPriceListValidFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPriceList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.csmiAddPriceListRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditPriceListRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemovePriceListRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.gbPriceListActions = new System.Windows.Forms.GroupBox();
            this.btnPriceListPrint = new System.Windows.Forms.Button();
            this.btnRefreshPriceList = new System.Windows.Forms.Button();
            this.btnDeletePriceListItem = new System.Windows.Forms.Button();
            this.btnEditPriceListItem = new System.Windows.Forms.Button();
            this.btnAddPriceListItem = new System.Windows.Forms.Button();
            this.tpRentalPlaceList = new System.Windows.Forms.TabPage();
            this.gbRentalPropertyActions = new System.Windows.Forms.GroupBox();
            this.btnRentalPlacesPrint = new System.Windows.Forms.Button();
            this.btnRentalPlaceUnpaidPeriods = new System.Windows.Forms.Button();
            this.btnRefreshRentalPlaceList = new System.Windows.Forms.Button();
            this.btnDeleteRentalProperty = new System.Windows.Forms.Button();
            this.btnInsertRentalProperty = new System.Windows.Forms.Button();
            this.llClearRentalPropertyFilter = new System.Windows.Forms.LinkLabel();
            this.dgvRentalPlaces = new System.Windows.Forms.DataGridView();
            this.RentalPropertyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRentalPlaceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentalPlaceContractNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRentalPlaceDateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentalPlaceServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRentalPlaceRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsRentalProperty = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddRentalProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveRentalProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRentalPropertyUnpaidDays = new System.Windows.Forms.ToolStripMenuItem();
            this.tpHolidays = new System.Windows.Forms.TabPage();
            this.gbHolidaysActions = new System.Windows.Forms.GroupBox();
            this.btnRefreshHolidaysList = new System.Windows.Forms.Button();
            this.btnDeleteHoliday = new System.Windows.Forms.Button();
            this.btnInsertHoliday = new System.Windows.Forms.Button();
            this.pCalendarView = new System.Windows.Forms.Panel();
            this.datesViewer = new Arsis.RentalSystem.AdministrationConsole.UserControls.DatesViewer();
            this.tpContracts = new System.Windows.Forms.TabPage();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lblContractsDateTo = new System.Windows.Forms.Label();
            this.dprContractsTo = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblContractsDateFrom = new System.Windows.Forms.Label();
            this.rbOpened = new System.Windows.Forms.RadioButton();
            this.rbClosed = new System.Windows.Forms.RadioButton();
            this.dprContractsFrom = new System.Windows.Forms.DateTimePicker();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.gbContractActions = new System.Windows.Forms.GroupBox();
            this.bt_ContractView = new System.Windows.Forms.Button();
            this.btnContractHistory = new System.Windows.Forms.Button();
            this.btnCloseContract = new System.Windows.Forms.Button();
            this.btnRefreshContractsList = new System.Windows.Forms.Button();
            this.btnManageRentalProperties = new System.Windows.Forms.Button();
            this.btnTransferContract = new System.Windows.Forms.Button();
            this.btnEditContract = new System.Windows.Forms.Button();
            this.btnAddContract = new System.Windows.Forms.Button();
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.ContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentalServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnContractNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnContractCreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractCrUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnContractDateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnContractDateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnContractDissolutionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client1SCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contract1SCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportOutletOrgan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPostAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportOutletDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCashless = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnContractCashlessPaymentControlDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsJuridicalPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlacePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractChDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractChUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractUser1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractStatusDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractStatusMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsContract = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddContract = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditContract = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ContractView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRentalProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseContract = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContractHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.llClearContractFilter = new System.Windows.Forms.LinkLabel();
            this.tpTerminalMonitor = new System.Windows.Forms.TabPage();
            this.llClearTerminalFilter = new System.Windows.Forms.LinkLabel();
            this.gbTerminalMonitorActions = new System.Windows.Forms.GroupBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.cbxRefreshAutomaticaly = new System.Windows.Forms.CheckBox();
            this.btnRefreshTerminalsList = new System.Windows.Forms.Button();
            this.dgvTerminalsList = new System.Windows.Forms.DataGridView();
            this.tpRentalPayLog = new System.Windows.Forms.TabPage();
            this.llClearRentalPayLogFilter = new System.Windows.Forms.LinkLabel();
            this.dgvRentalPayLog = new System.Windows.Forms.DataGridView();
            this.RentalPlaceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRentalPayLogDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentalTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPaid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnRentalPropertyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRentalPropertyPaidSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentalStatusMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpRentalPayLogActions = new System.Windows.Forms.GroupBox();
            this.btnRentalPaymentsListPrint = new System.Windows.Forms.Button();
            this.btnRefreshRentalPaylog = new System.Windows.Forms.Button();
            this.btnNotPaidReport = new System.Windows.Forms.Button();
            this.btnPaidReport = new System.Windows.Forms.Button();
            this.gbRentalPayLogFilter = new System.Windows.Forms.GroupBox();
            this.lblRentalPayLogRecordToDate = new System.Windows.Forms.Label();
            this.lblRentalPayLogRecordFromDate = new System.Windows.Forms.Label();
            this.dprRentalPayLogToTime = new System.Windows.Forms.DateTimePicker();
            this.dprRentalPayLogToDate = new System.Windows.Forms.DateTimePicker();
            this.dprRentalPayLogFromTime = new System.Windows.Forms.DateTimePicker();
            this.dprRentalPayLogFromDate = new System.Windows.Forms.DateTimePicker();
            this.tpServicePayLog = new System.Windows.Forms.TabPage();
            this.gbServicePaylogActions = new System.Windows.Forms.GroupBox();
            this.btnServicePaymentsListPrint = new System.Windows.Forms.Button();
            this.btnRefreshServicePaylog = new System.Windows.Forms.Button();
            this.llClearServicePayLogFilter = new System.Windows.Forms.LinkLabel();
            this.gbServicePayLogFilter = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxServices = new System.Windows.Forms.CheckedListBox();
            this.lblServicePayLogRecordToDate = new System.Windows.Forms.Label();
            this.lblServicePayLogRecordFromDate = new System.Windows.Forms.Label();
            this.dprServicePayLogToTime = new System.Windows.Forms.DateTimePicker();
            this.dprServicePayLogToDate = new System.Windows.Forms.DateTimePicker();
            this.dprServicePayLogFromTime = new System.Windows.Forms.DateTimePicker();
            this.dprServicePayLogFromDate = new System.Windows.Forms.DateTimePicker();
            this.dgvServicePayLog = new System.Windows.Forms.DataGridView();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServicePayLogDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServiceRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServicePaidSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceStatusMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpCashlessPaymentLog = new System.Windows.Forms.TabPage();
            this.llClearCashlessPaymentFilter = new System.Windows.Forms.LinkLabel();
            this.dgvCashlessPaymentList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidDateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentPaidDateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentControlDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsCashlessPayment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCashlessPayment_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCashlessPayment_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCashlessPayment_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCashlessPaymentAction = new System.Windows.Forms.GroupBox();
            this.btnCashlessPaymentsListPrint = new System.Windows.Forms.Button();
            this.bt_DeleteCashlessPayment = new System.Windows.Forms.Button();
            this.btnEditCashlessPayment = new System.Windows.Forms.Button();
            this.btnAddCashlessPayment = new System.Windows.Forms.Button();
            this.btnRefreshCashlessPayments = new System.Windows.Forms.Button();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OtherServicesFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.RentalPropertyFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.RentalPayLogFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.ContractFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.PriceListFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.TerminalsListFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.terminalListRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.ServicePayLogFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CashlessPaymentFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.TerminalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTerminalNetworkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalStarted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTerminalTotalPaidSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTerminalRentalPaidSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTerminalServicePaidSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalShiftNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainMenu.SuspendLayout();
            this.ToolsMenu.SuspendLayout();
            this.tcTabControl.SuspendLayout();
            this.tpServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherServices)).BeginInit();
            this.cmsOtherService.SuspendLayout();
            this.gbOtherServicesActions.SuspendLayout();
            this.tpPriceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).BeginInit();
            this.cmsPriceList.SuspendLayout();
            this.gbPriceListActions.SuspendLayout();
            this.tpRentalPlaceList.SuspendLayout();
            this.gbRentalPropertyActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalPlaces)).BeginInit();
            this.cmsRentalProperty.SuspendLayout();
            this.tpHolidays.SuspendLayout();
            this.gbHolidaysActions.SuspendLayout();
            this.pCalendarView.SuspendLayout();
            this.tpContracts.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.gbContractActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.cmsContract.SuspendLayout();
            this.tpTerminalMonitor.SuspendLayout();
            this.gbTerminalMonitorActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminalsList)).BeginInit();
            this.tpRentalPayLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalPayLog)).BeginInit();
            this.gpRentalPayLogActions.SuspendLayout();
            this.gbRentalPayLogFilter.SuspendLayout();
            this.tpServicePayLog.SuspendLayout();
            this.gbServicePaylogActions.SuspendLayout();
            this.gbServicePayLogFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicePayLog)).BeginInit();
            this.tpCashlessPaymentLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashlessPaymentList)).BeginInit();
            this.cmsCashlessPayment.SuspendLayout();
            this.gbCashlessPaymentAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtherServicesFilterExtender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentalPropertyFilterExtender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentalPayLogFilterExtender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractFilterExtender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceListFilterExtender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerminalsListFilterExtender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicePayLogFilterExtender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashlessPaymentFilterExtender)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiDictionary,
            this.tsmiLog,
            this.tsmiReport,
            this.tsmiInfo});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(792, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Главное меню";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExport,
            this.tsmiImport,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "&Файл";
            // 
            // tsmiExport
            // 
            this.tsmiExport.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.export;
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(193, 22);
            this.tsmiExport.Text = "Эксп&орт данных в 1С";
            this.tsmiExport.Visible = false;
            // 
            // tsmiImport
            // 
            this.tsmiImport.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.import;
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(193, 22);
            this.tsmiImport.Text = "&Импорт данных из 1С";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(193, 22);
            this.tsmiExit.Text = "В&ыход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiDictionary
            // 
            this.tsmiDictionary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiServices,
            this.tsmiPriceList,
            this.tsmiRentalPropertyList,
            this.tsmiHolidays,
            this.tsmiUsers});
            this.tsmiDictionary.Name = "tsmiDictionary";
            this.tsmiDictionary.Size = new System.Drawing.Size(94, 20);
            this.tsmiDictionary.Text = "С&правочники";
            // 
            // tsmiServices
            // 
            this.tsmiServices.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.gears;
            this.tsmiServices.Name = "tsmiServices";
            this.tsmiServices.Size = new System.Drawing.Size(163, 22);
            this.tsmiServices.Text = "&Услуги";
            this.tsmiServices.Click += new System.EventHandler(this.tsmiOtherServices_Click);
            // 
            // tsmiPriceList
            // 
            this.tsmiPriceList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.table;
            this.tsmiPriceList.Name = "tsmiPriceList";
            this.tsmiPriceList.Size = new System.Drawing.Size(163, 22);
            this.tsmiPriceList.Text = "Прайс-&лист";
            this.tsmiPriceList.Click += new System.EventHandler(this.tsmiPriceList_Click);
            // 
            // tsmiRentalPropertyList
            // 
            this.tsmiRentalPropertyList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.shoppingcart;
            this.tsmiRentalPropertyList.Name = "tsmiRentalPropertyList";
            this.tsmiRentalPropertyList.Size = new System.Drawing.Size(163, 22);
            this.tsmiRentalPropertyList.Text = "&Торговые места";
            this.tsmiRentalPropertyList.Click += new System.EventHandler(this.tsmiRentalPropertyList_Click);
            // 
            // tsmiHolidays
            // 
            this.tsmiHolidays.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.calendar_small;
            this.tsmiHolidays.Name = "tsmiHolidays";
            this.tsmiHolidays.Size = new System.Drawing.Size(163, 22);
            this.tsmiHolidays.Text = "Нерабочие &дни";
            this.tsmiHolidays.Click += new System.EventHandler(this.tsmiHolidays_Click);
            // 
            // tsmiUsers
            // 
            this.tsmiUsers.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.user_edit;
            this.tsmiUsers.Name = "tsmiUsers";
            this.tsmiUsers.Size = new System.Drawing.Size(163, 22);
            this.tsmiUsers.Text = "&Пользователи";
            this.tsmiUsers.Click += new System.EventHandler(this.tsmiUsers_Click);
            // 
            // tsmiLog
            // 
            this.tsmiLog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiContracts,
            this.tsmiRentalPayLog,
            this.tsmiServicePayLog,
            this.tsmiCashlessPayment});
            this.tsmiLog.Name = "tsmiLog";
            this.tsmiLog.Size = new System.Drawing.Size(72, 20);
            this.tsmiLog.Text = "Ж&урналы";
            // 
            // tsmiContracts
            // 
            this.tsmiContracts.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.list;
            this.tsmiContracts.Name = "tsmiContracts";
            this.tsmiContracts.Size = new System.Drawing.Size(205, 22);
            this.tsmiContracts.Text = "&Договоры аренды";
            this.tsmiContracts.Click += new System.EventHandler(this.tsmiContracts_Click);
            // 
            // tsmiRentalPayLog
            // 
            this.tsmiRentalPayLog.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.money;
            this.tsmiRentalPayLog.Name = "tsmiRentalPayLog";
            this.tsmiRentalPayLog.Size = new System.Drawing.Size(205, 22);
            this.tsmiRentalPayLog.Text = "Оплата &аренды";
            this.tsmiRentalPayLog.Click += new System.EventHandler(this.tsmiPayLog_Click);
            // 
            // tsmiServicePayLog
            // 
            this.tsmiServicePayLog.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.money;
            this.tsmiServicePayLog.Name = "tsmiServicePayLog";
            this.tsmiServicePayLog.Size = new System.Drawing.Size(205, 22);
            this.tsmiServicePayLog.Text = "Оплата &услуг";
            this.tsmiServicePayLog.Click += new System.EventHandler(this.tsmiServicePayLog_Click);
            // 
            // tsmiCashlessPayment
            // 
            this.tsmiCashlessPayment.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.money;
            this.tsmiCashlessPayment.Name = "tsmiCashlessPayment";
            this.tsmiCashlessPayment.Size = new System.Drawing.Size(205, 22);
            this.tsmiCashlessPayment.Text = "Оплата по б/н рассчету";
            this.tsmiCashlessPayment.Click += new System.EventHandler(this.tsmiCashlessPayment_Click);
            // 
            // tsmiReport
            // 
            this.tsmiReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNotPaidReport,
            this.tsmiPaidReport,
            this.tsmiNotTransferedPayment,
            this.tsmiPivotTableReport,
            this.tsmiContractStateReport,
            this.bt_ReportPaidForServices,
            this.toolStripMenuItem_ReportParkingPays});
            this.tsmiReport.Name = "tsmiReport";
            this.tsmiReport.Size = new System.Drawing.Size(60, 20);
            this.tsmiReport.Text = "&Отчеты";
            // 
            // tsmiNotPaidReport
            // 
            this.tsmiNotPaidReport.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.chart;
            this.tsmiNotPaidReport.Name = "tsmiNotPaidReport";
            this.tsmiNotPaidReport.Size = new System.Drawing.Size(318, 22);
            this.tsmiNotPaidReport.Text = "Отчет о н&еоплаченных местах за период";
            this.tsmiNotPaidReport.Click += new System.EventHandler(this.tsmiNotPaidReport_Click);
            // 
            // tsmiPaidReport
            // 
            this.tsmiPaidReport.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.chart;
            this.tsmiPaidReport.Name = "tsmiPaidReport";
            this.tsmiPaidReport.Size = new System.Drawing.Size(318, 22);
            this.tsmiPaidReport.Text = "Отчет об &оплаченных суммах за период";
            this.tsmiPaidReport.Click += new System.EventHandler(this.tsmiPaidReport_Click);
            // 
            // tsmiNotTransferedPayment
            // 
            this.tsmiNotTransferedPayment.Image = ((System.Drawing.Image)(resources.GetObject("tsmiNotTransferedPayment.Image")));
            this.tsmiNotTransferedPayment.Name = "tsmiNotTransferedPayment";
            this.tsmiNotTransferedPayment.Size = new System.Drawing.Size(318, 22);
            this.tsmiNotTransferedPayment.Text = "Отчет по не прошедшим &суммам за период";
            this.tsmiNotTransferedPayment.Click += new System.EventHandler(this.tsmiNotTransferedPayment_Click);
            // 
            // tsmiPivotTableReport
            // 
            this.tsmiPivotTableReport.Image = ((System.Drawing.Image)(resources.GetObject("tsmiPivotTableReport.Image")));
            this.tsmiPivotTableReport.Name = "tsmiPivotTableReport";
            this.tsmiPivotTableReport.Size = new System.Drawing.Size(318, 22);
            this.tsmiPivotTableReport.Text = "Сводная &таблица оплат за период";
            this.tsmiPivotTableReport.Click += new System.EventHandler(this.tsmiPivotTableReport_Click);
            // 
            // tsmiContractStateReport
            // 
            this.tsmiContractStateReport.Image = ((System.Drawing.Image)(resources.GetObject("tsmiContractStateReport.Image")));
            this.tsmiContractStateReport.Name = "tsmiContractStateReport";
            this.tsmiContractStateReport.Size = new System.Drawing.Size(318, 22);
            this.tsmiContractStateReport.Text = "Отчет по состоянию договоров";
            this.tsmiContractStateReport.Click += new System.EventHandler(this.tsmiContractStateReport_Click);
            // 
            // bt_ReportPaidForServices
            // 
            this.bt_ReportPaidForServices.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.chart;
            this.bt_ReportPaidForServices.Name = "bt_ReportPaidForServices";
            this.bt_ReportPaidForServices.Size = new System.Drawing.Size(318, 22);
            this.bt_ReportPaidForServices.Text = "Отчет по платежам за услуги за период";
            this.bt_ReportPaidForServices.Click += new System.EventHandler(this.bt_ReportPaidForServices_Click);
            // 
            // toolStripMenuItem_ReportParkingPays
            // 
            this.toolStripMenuItem_ReportParkingPays.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.chart;
            this.toolStripMenuItem_ReportParkingPays.Name = "toolStripMenuItem_ReportParkingPays";
            this.toolStripMenuItem_ReportParkingPays.Size = new System.Drawing.Size(318, 22);
            this.toolStripMenuItem_ReportParkingPays.Text = "Отчет по платежам за парковку";
            this.toolStripMenuItem_ReportParkingPays.Click += new System.EventHandler(this.toolStripMenuItem_ReportParkingPays_Click);
            // 
            // tsmiInfo
            // 
            this.tsmiInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelp,
            this.tsmiAbout});
            this.tsmiInfo.Name = "tsmiInfo";
            this.tsmiInfo.Size = new System.Drawing.Size(65, 20);
            this.tsmiInfo.Text = "&Справка";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.help2;
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(149, 22);
            this.tsmiHelp.Text = "&Справка";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.about;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(149, 22);
            this.tsmiAbout.Text = "&О программе";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExport,
            this.tsbImport,
            this.tsbContractsList,
            this.tsbPriceList,
            this.tsbRentalPayLog,
            this.tsbServicePayLog});
            this.ToolsMenu.Location = new System.Drawing.Point(0, 24);
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.Size = new System.Drawing.Size(792, 25);
            this.ToolsMenu.TabIndex = 1;
            this.ToolsMenu.Text = "Панель инструментов";
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(98, 22);
            this.tsbExport.Text = "Экспорт в 1С";
            this.tsbExport.Visible = false;
            // 
            // tsbImport
            // 
            this.tsbImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbImport.Image")));
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(103, 22);
            this.tsbImport.Text = "Импорт из 1С";
            this.tsbImport.Click += new System.EventHandler(this.tsbImport_Click);
            // 
            // tsbContractsList
            // 
            this.tsbContractsList.Image = ((System.Drawing.Image)(resources.GetObject("tsbContractsList.Image")));
            this.tsbContractsList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContractsList.Name = "tsbContractsList";
            this.tsbContractsList.Size = new System.Drawing.Size(127, 22);
            this.tsbContractsList.Text = "Договоры аренды";
            this.tsbContractsList.Click += new System.EventHandler(this.tsbContractsList_Click);
            // 
            // tsbPriceList
            // 
            this.tsbPriceList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.table;
            this.tsbPriceList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPriceList.Name = "tsbPriceList";
            this.tsbPriceList.Size = new System.Drawing.Size(92, 22);
            this.tsbPriceList.Text = "Прайс-лист";
            this.tsbPriceList.Click += new System.EventHandler(this.tsbPriceList_Click);
            // 
            // tsbRentalPayLog
            // 
            this.tsbRentalPayLog.Image = ((System.Drawing.Image)(resources.GetObject("tsbRentalPayLog.Image")));
            this.tsbRentalPayLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRentalPayLog.Name = "tsbRentalPayLog";
            this.tsbRentalPayLog.Size = new System.Drawing.Size(111, 22);
            this.tsbRentalPayLog.Text = "Оплата аренды";
            this.tsbRentalPayLog.Click += new System.EventHandler(this.tsbRentalPayLog_Click);
            // 
            // tsbServicePayLog
            // 
            this.tsbServicePayLog.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.money;
            this.tsbServicePayLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbServicePayLog.Name = "tsbServicePayLog";
            this.tsbServicePayLog.Size = new System.Drawing.Size(100, 22);
            this.tsbServicePayLog.Text = "Оплата услуг";
            this.tsbServicePayLog.Click += new System.EventHandler(this.tsbServicePayLog_Click);
            // 
            // tcTabControl
            // 
            this.tcTabControl.Controls.Add(this.tpServices);
            this.tcTabControl.Controls.Add(this.tpPriceList);
            this.tcTabControl.Controls.Add(this.tpRentalPlaceList);
            this.tcTabControl.Controls.Add(this.tpHolidays);
            this.tcTabControl.Controls.Add(this.tpContracts);
            this.tcTabControl.Controls.Add(this.tpTerminalMonitor);
            this.tcTabControl.Controls.Add(this.tpRentalPayLog);
            this.tcTabControl.Controls.Add(this.tpServicePayLog);
            this.tcTabControl.Controls.Add(this.tpCashlessPaymentLog);
            this.tcTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTabControl.Location = new System.Drawing.Point(0, 49);
            this.tcTabControl.Name = "tcTabControl";
            this.tcTabControl.SelectedIndex = 0;
            this.tcTabControl.Size = new System.Drawing.Size(792, 524);
            this.tcTabControl.TabIndex = 2;
            this.tcTabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseDown);
            this.tcTabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseUp);
            this.tcTabControl.SelectedIndexChanged += new System.EventHandler(this.tcTabControl_SelectedIndexChanged);
            // 
            // tpServices
            // 
            this.tpServices.Controls.Add(this.dgvOtherServices);
            this.tpServices.Controls.Add(this.gbOtherServicesActions);
            this.tpServices.Controls.Add(this.llClearOtherServicesFilter);
            this.tpServices.Location = new System.Drawing.Point(4, 22);
            this.tpServices.Name = "tpServices";
            this.tpServices.Padding = new System.Windows.Forms.Padding(3);
            this.tpServices.Size = new System.Drawing.Size(784, 498);
            this.tpServices.TabIndex = 0;
            this.tpServices.Text = "Услуги";
            this.tpServices.UseVisualStyleBackColor = true;
            // 
            // dgvOtherServices
            // 
            this.dgvOtherServices.AllowUserToAddRows = false;
            this.dgvOtherServices.AllowUserToDeleteRows = false;
            this.dgvOtherServices.AllowUserToOrderColumns = true;
            this.dgvOtherServices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOtherServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOtherServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOtherServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOtherServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOtherServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOtherServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OtherServiceId,
            this.columnServiceName,
            this.OtherServiceCaption,
            this.OtherServiceIsActive,
            this.OtherServiceIsRental,
            this.IsParkingPerHour,
            this.ParkingWithoutTime,
            this.IsOtherServices,
            this.UsePlaceNumber,
            this.columnServiceCurrentPrice,
            this.OneSColumn,
            this.OtherServicePictureThumbnail,
            this.OtherServicePicture});
            this.dgvOtherServices.ContextMenuStrip = this.cmsOtherService;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOtherServices.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOtherServices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOtherServices.Location = new System.Drawing.Point(139, 25);
            this.dgvOtherServices.MultiSelect = false;
            this.dgvOtherServices.Name = "dgvOtherServices";
            this.dgvOtherServices.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOtherServices.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOtherServices.RowHeadersVisible = false;
            this.dgvOtherServices.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvOtherServices.RowTemplate.ReadOnly = true;
            this.dgvOtherServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOtherServices.Size = new System.Drawing.Size(637, 464);
            this.dgvOtherServices.TabIndex = 2;
            this.toolTip.SetToolTip(this.dgvOtherServices, "Список услуг");
            this.dgvOtherServices.Enter += new System.EventHandler(this.dgvOtherServices_Enter);
            this.dgvOtherServices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOtherServices_CellDoubleClick);
            this.dgvOtherServices.Leave += new System.EventHandler(this.dgvOtherServices_Leave);
            this.dgvOtherServices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvServices_KeyDown);
            this.dgvOtherServices.SelectionChanged += new System.EventHandler(this.dgvOtherServices_SelectionChanged);
            // 
            // OtherServiceId
            // 
            this.OtherServiceId.DataPropertyName = "Id";
            this.OtherServiceId.HeaderText = "Id";
            this.OtherServiceId.Name = "OtherServiceId";
            this.OtherServiceId.ReadOnly = true;
            this.OtherServiceId.Visible = false;
            this.OtherServiceId.Width = 22;
            // 
            // columnServiceName
            // 
            this.columnServiceName.DataPropertyName = "Name";
            this.columnServiceName.FillWeight = 15.47607F;
            this.columnServiceName.HeaderText = "Название";
            this.columnServiceName.Name = "columnServiceName";
            this.columnServiceName.ReadOnly = true;
            this.columnServiceName.Width = 82;
            // 
            // OtherServiceCaption
            // 
            this.OtherServiceCaption.DataPropertyName = "Description";
            this.OtherServiceCaption.FillWeight = 15.47607F;
            this.OtherServiceCaption.HeaderText = "Описание";
            this.OtherServiceCaption.Name = "OtherServiceCaption";
            this.OtherServiceCaption.ReadOnly = true;
            this.OtherServiceCaption.Width = 82;
            // 
            // OtherServiceIsActive
            // 
            this.OtherServiceIsActive.DataPropertyName = "IsActive";
            this.OtherServiceIsActive.FillWeight = 7.543389F;
            this.OtherServiceIsActive.HeaderText = "Активна";
            this.OtherServiceIsActive.Name = "OtherServiceIsActive";
            this.OtherServiceIsActive.ReadOnly = true;
            this.OtherServiceIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OtherServiceIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OtherServiceIsActive.Width = 74;
            // 
            // OtherServiceIsRental
            // 
            this.OtherServiceIsRental.DataPropertyName = "IsRental";
            this.OtherServiceIsRental.FillWeight = 7.543389F;
            this.OtherServiceIsRental.HeaderText = "Аренда";
            this.OtherServiceIsRental.Name = "OtherServiceIsRental";
            this.OtherServiceIsRental.ReadOnly = true;
            this.OtherServiceIsRental.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OtherServiceIsRental.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OtherServiceIsRental.Width = 69;
            // 
            // IsParkingPerHour
            // 
            this.IsParkingPerHour.DataPropertyName = "IsParkingPerHour";
            this.IsParkingPerHour.HeaderText = "Парковка почасовая";
            this.IsParkingPerHour.Name = "IsParkingPerHour";
            this.IsParkingPerHour.ReadOnly = true;
            this.IsParkingPerHour.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsParkingPerHour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsParkingPerHour.Width = 138;
            // 
            // ParkingWithoutTime
            // 
            this.ParkingWithoutTime.DataPropertyName = "IsParkingWithoutTime";
            this.ParkingWithoutTime.HeaderText = "Парковка без учёта времени";
            this.ParkingWithoutTime.Name = "ParkingWithoutTime";
            this.ParkingWithoutTime.ReadOnly = true;
            this.ParkingWithoutTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ParkingWithoutTime.Width = 180;
            // 
            // IsOtherServices
            // 
            this.IsOtherServices.DataPropertyName = "IsOther";
            this.IsOtherServices.HeaderText = "Прочие услуги";
            this.IsOtherServices.Name = "IsOtherServices";
            this.IsOtherServices.ReadOnly = true;
            this.IsOtherServices.Width = 86;
            // 
            // UsePlaceNumber
            // 
            this.UsePlaceNumber.DataPropertyName = "UsePlaceNumber";
            this.UsePlaceNumber.HeaderText = "Номер места";
            this.UsePlaceNumber.Name = "UsePlaceNumber";
            this.UsePlaceNumber.ReadOnly = true;
            this.UsePlaceNumber.Width = 81;
            // 
            // columnServiceCurrentPrice
            // 
            this.columnServiceCurrentPrice.DataPropertyName = "CurrentPrice";
            this.columnServiceCurrentPrice.FillWeight = 12.57231F;
            this.columnServiceCurrentPrice.HeaderText = "Текущая цена";
            this.columnServiceCurrentPrice.Name = "columnServiceCurrentPrice";
            this.columnServiceCurrentPrice.ReadOnly = true;
            this.columnServiceCurrentPrice.Width = 104;
            // 
            // OneSColumn
            // 
            this.OneSColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OneSColumn.DataPropertyName = "OneSCode";
            this.OneSColumn.FillWeight = 80F;
            this.OneSColumn.HeaderText = "Код 1С";
            this.OneSColumn.MinimumWidth = 80;
            this.OneSColumn.Name = "OneSColumn";
            this.OneSColumn.ReadOnly = true;
            this.OneSColumn.Width = 80;
            // 
            // OtherServicePictureThumbnail
            // 
            this.OtherServicePictureThumbnail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OtherServicePictureThumbnail.DataPropertyName = "PictureThumbnail";
            this.OtherServicePictureThumbnail.FillWeight = 80F;
            this.OtherServicePictureThumbnail.HeaderText = "Иконка";
            this.OtherServicePictureThumbnail.MinimumWidth = 80;
            this.OtherServicePictureThumbnail.Name = "OtherServicePictureThumbnail";
            this.OtherServicePictureThumbnail.ReadOnly = true;
            this.OtherServicePictureThumbnail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OtherServicePictureThumbnail.Width = 80;
            // 
            // OtherServicePicture
            // 
            this.OtherServicePicture.DataPropertyName = "Picture";
            this.OtherServicePicture.HeaderText = "OtherServicePicture";
            this.OtherServicePicture.Name = "OtherServicePicture";
            this.OtherServicePicture.ReadOnly = true;
            this.OtherServicePicture.Visible = false;
            this.OtherServicePicture.Width = 108;
            // 
            // cmsOtherService
            // 
            this.cmsOtherService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddOtherService,
            this.tsmiEditOtherService,
            this.tsmiRemoveOtherService});
            this.cmsOtherService.Name = "cmsOtherService";
            this.cmsOtherService.ShowImageMargin = false;
            this.cmsOtherService.Size = new System.Drawing.Size(130, 70);
            // 
            // tsmiAddOtherService
            // 
            this.tsmiAddOtherService.Name = "tsmiAddOtherService";
            this.tsmiAddOtherService.Size = new System.Drawing.Size(129, 22);
            this.tsmiAddOtherService.Text = "Добавить";
            this.tsmiAddOtherService.Click += new System.EventHandler(this.tsmiAddOtherService_Click);
            // 
            // tsmiEditOtherService
            // 
            this.tsmiEditOtherService.Name = "tsmiEditOtherService";
            this.tsmiEditOtherService.Size = new System.Drawing.Size(129, 22);
            this.tsmiEditOtherService.Text = "Редактировать";
            this.tsmiEditOtherService.Click += new System.EventHandler(this.tsmiEditOtherService_Click);
            // 
            // tsmiRemoveOtherService
            // 
            this.tsmiRemoveOtherService.Name = "tsmiRemoveOtherService";
            this.tsmiRemoveOtherService.Size = new System.Drawing.Size(129, 22);
            this.tsmiRemoveOtherService.Text = "Удалить";
            this.tsmiRemoveOtherService.Click += new System.EventHandler(this.tsmiRemoveOtherService_Click);
            // 
            // gbOtherServicesActions
            // 
            this.gbOtherServicesActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOtherServicesActions.Controls.Add(this.btnServicesListPrint);
            this.gbOtherServicesActions.Controls.Add(this.btnRefreshServicesList);
            this.gbOtherServicesActions.Controls.Add(this.btnDeleteOtherService);
            this.gbOtherServicesActions.Controls.Add(this.btnEditOtherService);
            this.gbOtherServicesActions.Controls.Add(this.btnInsertOtherService);
            this.gbOtherServicesActions.Location = new System.Drawing.Point(8, 25);
            this.gbOtherServicesActions.Name = "gbOtherServicesActions";
            this.gbOtherServicesActions.Size = new System.Drawing.Size(125, 464);
            this.gbOtherServicesActions.TabIndex = 0;
            this.gbOtherServicesActions.TabStop = false;
            this.gbOtherServicesActions.Text = "Действия";
            // 
            // btnServicesListPrint
            // 
            this.btnServicesListPrint.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.table;
            this.btnServicesListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicesListPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnServicesListPrint.Location = new System.Drawing.Point(6, 135);
            this.btnServicesListPrint.Name = "btnServicesListPrint";
            this.btnServicesListPrint.Size = new System.Drawing.Size(113, 25);
            this.btnServicesListPrint.TabIndex = 4;
            this.btnServicesListPrint.Text = "Распечатать";
            this.btnServicesListPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnServicesListPrint, "Распечатать таблицу");
            this.btnServicesListPrint.UseVisualStyleBackColor = true;
            this.btnServicesListPrint.Click += new System.EventHandler(this.btnServicesListPrint_Click);
            // 
            // btnRefreshServicesList
            // 
            this.btnRefreshServicesList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
            this.btnRefreshServicesList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshServicesList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshServicesList.Location = new System.Drawing.Point(6, 106);
            this.btnRefreshServicesList.Name = "btnRefreshServicesList";
            this.btnRefreshServicesList.Size = new System.Drawing.Size(113, 25);
            this.btnRefreshServicesList.TabIndex = 3;
            this.btnRefreshServicesList.Text = "Обновить";
            this.btnRefreshServicesList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRefreshServicesList, "Обновить список услуг");
            this.btnRefreshServicesList.UseVisualStyleBackColor = true;
            this.btnRefreshServicesList.Click += new System.EventHandler(this.btnRefreshServicesList_Click);
            // 
            // btnDeleteOtherService
            // 
            this.btnDeleteOtherService.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
            this.btnDeleteOtherService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteOtherService.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteOtherService.Location = new System.Drawing.Point(6, 77);
            this.btnDeleteOtherService.Name = "btnDeleteOtherService";
            this.btnDeleteOtherService.Size = new System.Drawing.Size(113, 25);
            this.btnDeleteOtherService.TabIndex = 2;
            this.btnDeleteOtherService.Text = "Удалить";
            this.btnDeleteOtherService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnDeleteOtherService, "Удалить услугу");
            this.btnDeleteOtherService.UseVisualStyleBackColor = true;
            this.btnDeleteOtherService.Click += new System.EventHandler(this.btnDeleteOtherService_Click);
            // 
            // btnEditOtherService
            // 
            this.btnEditOtherService.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.edit;
            this.btnEditOtherService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditOtherService.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditOtherService.Location = new System.Drawing.Point(6, 48);
            this.btnEditOtherService.Name = "btnEditOtherService";
            this.btnEditOtherService.Size = new System.Drawing.Size(113, 25);
            this.btnEditOtherService.TabIndex = 1;
            this.btnEditOtherService.Text = "Редактировать";
            this.btnEditOtherService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnEditOtherService, "Редактировать услугу");
            this.btnEditOtherService.UseVisualStyleBackColor = true;
            this.btnEditOtherService.Click += new System.EventHandler(this.btnEditOtherService_Click);
            // 
            // btnInsertOtherService
            // 
            this.btnInsertOtherService.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
            this.btnInsertOtherService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertOtherService.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInsertOtherService.Location = new System.Drawing.Point(6, 19);
            this.btnInsertOtherService.Name = "btnInsertOtherService";
            this.btnInsertOtherService.Size = new System.Drawing.Size(113, 25);
            this.btnInsertOtherService.TabIndex = 0;
            this.btnInsertOtherService.Text = "Добавить";
            this.btnInsertOtherService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnInsertOtherService, "Добавить новую услугу");
            this.btnInsertOtherService.UseVisualStyleBackColor = true;
            this.btnInsertOtherService.Click += new System.EventHandler(this.btnInsertOtherService_Click);
            // 
            // llClearOtherServicesFilter
            // 
            this.llClearOtherServicesFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearOtherServicesFilter.Image = ((System.Drawing.Image)(resources.GetObject("llClearOtherServicesFilter.Image")));
            this.llClearOtherServicesFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearOtherServicesFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearOtherServicesFilter.Location = new System.Drawing.Point(117, 5);
            this.llClearOtherServicesFilter.Name = "llClearOtherServicesFilter";
            this.llClearOtherServicesFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearOtherServicesFilter.TabIndex = 1;
            this.toolTip.SetToolTip(this.llClearOtherServicesFilter, "Очистить фильтр");
            this.llClearOtherServicesFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearOtherServicesFilter_MouseClick);
            this.llClearOtherServicesFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseDown);
            this.llClearOtherServicesFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseUp);
            // 
            // tpPriceList
            // 
            this.tpPriceList.Controls.Add(this.llClearPriceListFilter);
            this.tpPriceList.Controls.Add(this.dgvPriceList);
            this.tpPriceList.Controls.Add(this.gbPriceListActions);
            this.tpPriceList.Location = new System.Drawing.Point(4, 22);
            this.tpPriceList.Name = "tpPriceList";
            this.tpPriceList.Padding = new System.Windows.Forms.Padding(3);
            this.tpPriceList.Size = new System.Drawing.Size(784, 498);
            this.tpPriceList.TabIndex = 6;
            this.tpPriceList.Text = "Прайс-лист";
            this.tpPriceList.UseVisualStyleBackColor = true;
            // 
            // llClearPriceListFilter
            // 
            this.llClearPriceListFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearPriceListFilter.Image = ((System.Drawing.Image)(resources.GetObject("llClearPriceListFilter.Image")));
            this.llClearPriceListFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearPriceListFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearPriceListFilter.Location = new System.Drawing.Point(117, 5);
            this.llClearPriceListFilter.Name = "llClearPriceListFilter";
            this.llClearPriceListFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearPriceListFilter.TabIndex = 4;
            this.toolTip.SetToolTip(this.llClearPriceListFilter, "Очистить фильтр");
            this.llClearPriceListFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearPriceListFilter_MouseClick);
            this.llClearPriceListFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseDown);
            this.llClearPriceListFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseUp);
            // 
            // dgvPriceList
            // 
            this.dgvPriceList.AllowUserToAddRows = false;
            this.dgvPriceList.AllowUserToDeleteRows = false;
            this.dgvPriceList.AllowUserToOrderColumns = true;
            this.dgvPriceList.AllowUserToResizeRows = false;
            this.dgvPriceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPriceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPriceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PriceListId,
            this.columnPriceListServiceName,
            this.columnPriceListPrice,
            this.columnPriceListValidFrom});
            this.dgvPriceList.ContextMenuStrip = this.cmsPriceList;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPriceList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPriceList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPriceList.Location = new System.Drawing.Point(139, 25);
            this.dgvPriceList.MultiSelect = false;
            this.dgvPriceList.Name = "dgvPriceList";
            this.dgvPriceList.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPriceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPriceList.RowHeadersVisible = false;
            this.dgvPriceList.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvPriceList.RowTemplate.ReadOnly = true;
            this.dgvPriceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceList.Size = new System.Drawing.Size(629, 457);
            this.dgvPriceList.TabIndex = 5;
            this.toolTip.SetToolTip(this.dgvPriceList, "Прайс-лист");
            this.dgvPriceList.Enter += new System.EventHandler(this.dgvPriceList_Enter);
            this.dgvPriceList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPriceList_CellDoubleClick);
            this.dgvPriceList.Leave += new System.EventHandler(this.dgvPriceList_Leave);
            this.dgvPriceList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPriceList_KeyDown);
            this.dgvPriceList.SelectionChanged += new System.EventHandler(this.dgvPriceList_SelectionChanged);
            // 
            // PriceListId
            // 
            this.PriceListId.DataPropertyName = "Id";
            this.PriceListId.HeaderText = "Id";
            this.PriceListId.Name = "PriceListId";
            this.PriceListId.ReadOnly = true;
            this.PriceListId.Visible = false;
            // 
            // columnPriceListServiceName
            // 
            this.columnPriceListServiceName.DataPropertyName = "ServiceName";
            this.columnPriceListServiceName.HeaderText = "Услуга";
            this.columnPriceListServiceName.Name = "columnPriceListServiceName";
            this.columnPriceListServiceName.ReadOnly = true;
            // 
            // columnPriceListPrice
            // 
            this.columnPriceListPrice.DataPropertyName = "Price";
            this.columnPriceListPrice.HeaderText = "Цена";
            this.columnPriceListPrice.Name = "columnPriceListPrice";
            this.columnPriceListPrice.ReadOnly = true;
            // 
            // columnPriceListValidFrom
            // 
            this.columnPriceListValidFrom.DataPropertyName = "ValidThrough";
            this.columnPriceListValidFrom.HeaderText = "Действует с";
            this.columnPriceListValidFrom.Name = "columnPriceListValidFrom";
            this.columnPriceListValidFrom.ReadOnly = true;
            // 
            // cmsPriceList
            // 
            this.cmsPriceList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csmiAddPriceListRecord,
            this.tsmiEditPriceListRecord,
            this.tsmiRemovePriceListRecord});
            this.cmsPriceList.Name = "cmsOtherService";
            this.cmsPriceList.ShowImageMargin = false;
            this.cmsPriceList.Size = new System.Drawing.Size(130, 70);
            // 
            // csmiAddPriceListRecord
            // 
            this.csmiAddPriceListRecord.Name = "csmiAddPriceListRecord";
            this.csmiAddPriceListRecord.Size = new System.Drawing.Size(129, 22);
            this.csmiAddPriceListRecord.Text = "Добавить";
            this.csmiAddPriceListRecord.Click += new System.EventHandler(this.csmiAddPriceListRecord_Click);
            // 
            // tsmiEditPriceListRecord
            // 
            this.tsmiEditPriceListRecord.Name = "tsmiEditPriceListRecord";
            this.tsmiEditPriceListRecord.Size = new System.Drawing.Size(129, 22);
            this.tsmiEditPriceListRecord.Text = "Редактировать";
            this.tsmiEditPriceListRecord.Click += new System.EventHandler(this.tsmiEditPriceListRecord_Click);
            // 
            // tsmiRemovePriceListRecord
            // 
            this.tsmiRemovePriceListRecord.Name = "tsmiRemovePriceListRecord";
            this.tsmiRemovePriceListRecord.Size = new System.Drawing.Size(129, 22);
            this.tsmiRemovePriceListRecord.Text = "Удалить";
            this.tsmiRemovePriceListRecord.Click += new System.EventHandler(this.tsmiRemovePriceListRecord_Click);
            // 
            // gbPriceListActions
            // 
            this.gbPriceListActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPriceListActions.Controls.Add(this.btnPriceListPrint);
            this.gbPriceListActions.Controls.Add(this.btnRefreshPriceList);
            this.gbPriceListActions.Controls.Add(this.btnDeletePriceListItem);
            this.gbPriceListActions.Controls.Add(this.btnEditPriceListItem);
            this.gbPriceListActions.Controls.Add(this.btnAddPriceListItem);
            this.gbPriceListActions.Location = new System.Drawing.Point(8, 25);
            this.gbPriceListActions.Name = "gbPriceListActions";
            this.gbPriceListActions.Size = new System.Drawing.Size(125, 457);
            this.gbPriceListActions.TabIndex = 3;
            this.gbPriceListActions.TabStop = false;
            this.gbPriceListActions.Text = "Действия";
            // 
            // btnPriceListPrint
            // 
            this.btnPriceListPrint.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.table;
            this.btnPriceListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPriceListPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPriceListPrint.Location = new System.Drawing.Point(6, 135);
            this.btnPriceListPrint.Name = "btnPriceListPrint";
            this.btnPriceListPrint.Size = new System.Drawing.Size(113, 25);
            this.btnPriceListPrint.TabIndex = 5;
            this.btnPriceListPrint.Text = "Распечатать";
            this.btnPriceListPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnPriceListPrint, "Распечатать таблицу");
            this.btnPriceListPrint.UseVisualStyleBackColor = true;
            this.btnPriceListPrint.Click += new System.EventHandler(this.btnPriceListPrint_Click);
            // 
            // btnRefreshPriceList
            // 
            this.btnRefreshPriceList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
            this.btnRefreshPriceList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshPriceList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshPriceList.Location = new System.Drawing.Point(6, 106);
            this.btnRefreshPriceList.Name = "btnRefreshPriceList";
            this.btnRefreshPriceList.Size = new System.Drawing.Size(113, 25);
            this.btnRefreshPriceList.TabIndex = 3;
            this.btnRefreshPriceList.Text = "Обновить";
            this.btnRefreshPriceList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRefreshPriceList, "Обновить прайс-лист");
            this.btnRefreshPriceList.UseVisualStyleBackColor = true;
            this.btnRefreshPriceList.Click += new System.EventHandler(this.btnRefreshPriceList_Click);
            // 
            // btnDeletePriceListItem
            // 
            this.btnDeletePriceListItem.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
            this.btnDeletePriceListItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletePriceListItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeletePriceListItem.Location = new System.Drawing.Point(6, 77);
            this.btnDeletePriceListItem.Name = "btnDeletePriceListItem";
            this.btnDeletePriceListItem.Size = new System.Drawing.Size(113, 25);
            this.btnDeletePriceListItem.TabIndex = 2;
            this.btnDeletePriceListItem.Text = "Удалить";
            this.btnDeletePriceListItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnDeletePriceListItem, "Удалить запись прайс-листа");
            this.btnDeletePriceListItem.UseVisualStyleBackColor = true;
            this.btnDeletePriceListItem.Click += new System.EventHandler(this.btnDeletePriceListItem_Click);
            // 
            // btnEditPriceListItem
            // 
            this.btnEditPriceListItem.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.edit;
            this.btnEditPriceListItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditPriceListItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditPriceListItem.Location = new System.Drawing.Point(6, 48);
            this.btnEditPriceListItem.Name = "btnEditPriceListItem";
            this.btnEditPriceListItem.Size = new System.Drawing.Size(113, 25);
            this.btnEditPriceListItem.TabIndex = 1;
            this.btnEditPriceListItem.Text = "Редактировать";
            this.btnEditPriceListItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnEditPriceListItem, "Редактировать запись прайс-листа");
            this.btnEditPriceListItem.UseVisualStyleBackColor = true;
            this.btnEditPriceListItem.Click += new System.EventHandler(this.btnEditPriceListItem_Click);
            // 
            // btnAddPriceListItem
            // 
            this.btnAddPriceListItem.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
            this.btnAddPriceListItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPriceListItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddPriceListItem.Location = new System.Drawing.Point(6, 19);
            this.btnAddPriceListItem.Name = "btnAddPriceListItem";
            this.btnAddPriceListItem.Size = new System.Drawing.Size(113, 25);
            this.btnAddPriceListItem.TabIndex = 0;
            this.btnAddPriceListItem.Text = "Добавить";
            this.btnAddPriceListItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnAddPriceListItem, "Добавить новую запись в прайс-лист");
            this.btnAddPriceListItem.UseVisualStyleBackColor = true;
            this.btnAddPriceListItem.Click += new System.EventHandler(this.btnAddPriceListItem_Click);
            // 
            // tpRentalPlaceList
            // 
            this.tpRentalPlaceList.Controls.Add(this.gbRentalPropertyActions);
            this.tpRentalPlaceList.Controls.Add(this.llClearRentalPropertyFilter);
            this.tpRentalPlaceList.Controls.Add(this.dgvRentalPlaces);
            this.tpRentalPlaceList.Location = new System.Drawing.Point(4, 22);
            this.tpRentalPlaceList.Name = "tpRentalPlaceList";
            this.tpRentalPlaceList.Padding = new System.Windows.Forms.Padding(3);
            this.tpRentalPlaceList.Size = new System.Drawing.Size(784, 498);
            this.tpRentalPlaceList.TabIndex = 1;
            this.tpRentalPlaceList.Text = "Торговые места";
            this.tpRentalPlaceList.UseVisualStyleBackColor = true;
            // 
            // gbRentalPropertyActions
            // 
            this.gbRentalPropertyActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbRentalPropertyActions.Controls.Add(this.btnRentalPlacesPrint);
            this.gbRentalPropertyActions.Controls.Add(this.btnRentalPlaceUnpaidPeriods);
            this.gbRentalPropertyActions.Controls.Add(this.btnRefreshRentalPlaceList);
            this.gbRentalPropertyActions.Controls.Add(this.btnDeleteRentalProperty);
            this.gbRentalPropertyActions.Controls.Add(this.btnInsertRentalProperty);
            this.gbRentalPropertyActions.Location = new System.Drawing.Point(8, 25);
            this.gbRentalPropertyActions.Name = "gbRentalPropertyActions";
            this.gbRentalPropertyActions.Size = new System.Drawing.Size(125, 459);
            this.gbRentalPropertyActions.TabIndex = 0;
            this.gbRentalPropertyActions.TabStop = false;
            this.gbRentalPropertyActions.Text = "Действия";
            // 
            // btnRentalPlacesPrint
            // 
            this.btnRentalPlacesPrint.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.table;
            this.btnRentalPlacesPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentalPlacesPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRentalPlacesPrint.Location = new System.Drawing.Point(6, 135);
            this.btnRentalPlacesPrint.Name = "btnRentalPlacesPrint";
            this.btnRentalPlacesPrint.Size = new System.Drawing.Size(113, 25);
            this.btnRentalPlacesPrint.TabIndex = 6;
            this.btnRentalPlacesPrint.Text = "Распечатать";
            this.btnRentalPlacesPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRentalPlacesPrint, "Распечатать таблицу");
            this.btnRentalPlacesPrint.UseVisualStyleBackColor = true;
            this.btnRentalPlacesPrint.Click += new System.EventHandler(this.btnRentalPlacesPrint_Click);
            // 
            // btnRentalPlaceUnpaidPeriods
            // 
            this.btnRentalPlaceUnpaidPeriods.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.calendar_small;
            this.btnRentalPlaceUnpaidPeriods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentalPlaceUnpaidPeriods.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRentalPlaceUnpaidPeriods.Location = new System.Drawing.Point(6, 77);
            this.btnRentalPlaceUnpaidPeriods.Name = "btnRentalPlaceUnpaidPeriods";
            this.btnRentalPlaceUnpaidPeriods.Size = new System.Drawing.Size(113, 25);
            this.btnRentalPlaceUnpaidPeriods.TabIndex = 3;
            this.btnRentalPlaceUnpaidPeriods.Text = "Выходные";
            this.btnRentalPlaceUnpaidPeriods.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRentalPlaceUnpaidPeriods, "Редактировать неоплачеваемые периоды");
            this.btnRentalPlaceUnpaidPeriods.UseVisualStyleBackColor = true;
            this.btnRentalPlaceUnpaidPeriods.Click += new System.EventHandler(this.btnRentalPlaceUnpaidPeriods_Click);
            // 
            // btnRefreshRentalPlaceList
            // 
            this.btnRefreshRentalPlaceList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
            this.btnRefreshRentalPlaceList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshRentalPlaceList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshRentalPlaceList.Location = new System.Drawing.Point(6, 106);
            this.btnRefreshRentalPlaceList.Name = "btnRefreshRentalPlaceList";
            this.btnRefreshRentalPlaceList.Size = new System.Drawing.Size(113, 25);
            this.btnRefreshRentalPlaceList.TabIndex = 3;
            this.btnRefreshRentalPlaceList.Text = "Обновить";
            this.btnRefreshRentalPlaceList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRefreshRentalPlaceList, "Обновить список торговых мест");
            this.btnRefreshRentalPlaceList.UseVisualStyleBackColor = true;
            this.btnRefreshRentalPlaceList.Click += new System.EventHandler(this.btnRefreshRentalPlaceList_Click);
            // 
            // btnDeleteRentalProperty
            // 
            this.btnDeleteRentalProperty.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
            this.btnDeleteRentalProperty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRentalProperty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteRentalProperty.Location = new System.Drawing.Point(6, 48);
            this.btnDeleteRentalProperty.Name = "btnDeleteRentalProperty";
            this.btnDeleteRentalProperty.Size = new System.Drawing.Size(113, 25);
            this.btnDeleteRentalProperty.TabIndex = 2;
            this.btnDeleteRentalProperty.Text = "Удалить";
            this.btnDeleteRentalProperty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnDeleteRentalProperty, "Удалить торговое место");
            this.btnDeleteRentalProperty.UseVisualStyleBackColor = true;
            this.btnDeleteRentalProperty.Click += new System.EventHandler(this.btnDeleteRentalProperty_Click);
            // 
            // btnInsertRentalProperty
            // 
            this.btnInsertRentalProperty.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
            this.btnInsertRentalProperty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertRentalProperty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInsertRentalProperty.Location = new System.Drawing.Point(6, 19);
            this.btnInsertRentalProperty.Name = "btnInsertRentalProperty";
            this.btnInsertRentalProperty.Size = new System.Drawing.Size(113, 25);
            this.btnInsertRentalProperty.TabIndex = 1;
            this.btnInsertRentalProperty.Text = "Добавить";
            this.btnInsertRentalProperty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnInsertRentalProperty, "Добавить новое торговое место");
            this.btnInsertRentalProperty.UseVisualStyleBackColor = true;
            this.btnInsertRentalProperty.Click += new System.EventHandler(this.btnInsertRentalProperty_Click);
            // 
            // llClearRentalPropertyFilter
            // 
            this.llClearRentalPropertyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearRentalPropertyFilter.Image = ((System.Drawing.Image)(resources.GetObject("llClearRentalPropertyFilter.Image")));
            this.llClearRentalPropertyFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearRentalPropertyFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearRentalPropertyFilter.Location = new System.Drawing.Point(117, 5);
            this.llClearRentalPropertyFilter.Name = "llClearRentalPropertyFilter";
            this.llClearRentalPropertyFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearRentalPropertyFilter.TabIndex = 1;
            this.toolTip.SetToolTip(this.llClearRentalPropertyFilter, "Очистить фильтр");
            this.llClearRentalPropertyFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearRentalPropertyFilter_MouseClick);
            this.llClearRentalPropertyFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseDown);
            this.llClearRentalPropertyFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseUp);
            // 
            // dgvRentalPlaces
            // 
            this.dgvRentalPlaces.AllowUserToAddRows = false;
            this.dgvRentalPlaces.AllowUserToDeleteRows = false;
            this.dgvRentalPlaces.AllowUserToOrderColumns = true;
            this.dgvRentalPlaces.AllowUserToResizeRows = false;
            this.dgvRentalPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRentalPlaces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRentalPlaces.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRentalPlaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalPlaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RentalPropertyId,
            this.columnRentalPlaceNumber,
            this.RentalPlaceContractNumber,
            this.columnRentalPlaceDateTo,
            this.RentalPlaceServiceName,
            this.columnRentalPlaceRate});
            this.dgvRentalPlaces.ContextMenuStrip = this.cmsRentalProperty;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRentalPlaces.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRentalPlaces.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRentalPlaces.Location = new System.Drawing.Point(139, 25);
            this.dgvRentalPlaces.MultiSelect = false;
            this.dgvRentalPlaces.Name = "dgvRentalPlaces";
            this.dgvRentalPlaces.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRentalPlaces.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvRentalPlaces.RowHeadersVisible = false;
            this.dgvRentalPlaces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentalPlaces.Size = new System.Drawing.Size(629, 458);
            this.dgvRentalPlaces.TabIndex = 2;
            this.toolTip.SetToolTip(this.dgvRentalPlaces, "Список торговых мест");
            this.dgvRentalPlaces.Enter += new System.EventHandler(this.dgvRentalPlaces_Enter);
            this.dgvRentalPlaces.Leave += new System.EventHandler(this.dgvRentalPlaces_Leave);
            this.dgvRentalPlaces.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRentalPlaces_KeyDown);
            this.dgvRentalPlaces.SelectionChanged += new System.EventHandler(this.dgvRentalPlaces_SelectionChanged);
            // 
            // RentalPropertyId
            // 
            this.RentalPropertyId.DataPropertyName = "Id";
            this.RentalPropertyId.HeaderText = "Id";
            this.RentalPropertyId.Name = "RentalPropertyId";
            this.RentalPropertyId.ReadOnly = true;
            this.RentalPropertyId.Visible = false;
            // 
            // columnRentalPlaceNumber
            // 
            this.columnRentalPlaceNumber.DataPropertyName = "Number";
            this.columnRentalPlaceNumber.HeaderText = "№ места";
            this.columnRentalPlaceNumber.Name = "columnRentalPlaceNumber";
            this.columnRentalPlaceNumber.ReadOnly = true;
            // 
            // RentalPlaceContractNumber
            // 
            this.RentalPlaceContractNumber.DataPropertyName = "ContractNumber";
            this.RentalPlaceContractNumber.HeaderText = "№ договора";
            this.RentalPlaceContractNumber.Name = "RentalPlaceContractNumber";
            this.RentalPlaceContractNumber.ReadOnly = true;
            // 
            // columnRentalPlaceDateTo
            // 
            this.columnRentalPlaceDateTo.DataPropertyName = "DateTo";
            this.columnRentalPlaceDateTo.HeaderText = "Действует до";
            this.columnRentalPlaceDateTo.Name = "columnRentalPlaceDateTo";
            this.columnRentalPlaceDateTo.ReadOnly = true;
            // 
            // RentalPlaceServiceName
            // 
            this.RentalPlaceServiceName.DataPropertyName = "ServiceName";
            this.RentalPlaceServiceName.HeaderText = "Услуга";
            this.RentalPlaceServiceName.Name = "RentalPlaceServiceName";
            this.RentalPlaceServiceName.ReadOnly = true;
            // 
            // columnRentalPlaceRate
            // 
            this.columnRentalPlaceRate.DataPropertyName = "Rate";
            this.columnRentalPlaceRate.HeaderText = "Цена";
            this.columnRentalPlaceRate.Name = "columnRentalPlaceRate";
            this.columnRentalPlaceRate.ReadOnly = true;
            // 
            // cmsRentalProperty
            // 
            this.cmsRentalProperty.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddRentalProperty,
            this.tsmiRemoveRentalProperty,
            this.tsmiRentalPropertyUnpaidDays});
            this.cmsRentalProperty.Name = "cmsOtherService";
            this.cmsRentalProperty.ShowImageMargin = false;
            this.cmsRentalProperty.Size = new System.Drawing.Size(106, 70);
            // 
            // tsmiAddRentalProperty
            // 
            this.tsmiAddRentalProperty.Name = "tsmiAddRentalProperty";
            this.tsmiAddRentalProperty.Size = new System.Drawing.Size(105, 22);
            this.tsmiAddRentalProperty.Text = "Добавить";
            this.tsmiAddRentalProperty.Click += new System.EventHandler(this.tsmiAddRentalProperty_Click);
            // 
            // tsmiRemoveRentalProperty
            // 
            this.tsmiRemoveRentalProperty.Name = "tsmiRemoveRentalProperty";
            this.tsmiRemoveRentalProperty.Size = new System.Drawing.Size(105, 22);
            this.tsmiRemoveRentalProperty.Text = "Удалить";
            this.tsmiRemoveRentalProperty.Click += new System.EventHandler(this.tsmiRemoveRentalProperty_Click);
            // 
            // tsmiRentalPropertyUnpaidDays
            // 
            this.tsmiRentalPropertyUnpaidDays.Name = "tsmiRentalPropertyUnpaidDays";
            this.tsmiRentalPropertyUnpaidDays.Size = new System.Drawing.Size(105, 22);
            this.tsmiRentalPropertyUnpaidDays.Text = "Выходные";
            this.tsmiRentalPropertyUnpaidDays.Click += new System.EventHandler(this.tsmiRentalPropertyUnpaidDays_Click);
            // 
            // tpHolidays
            // 
            this.tpHolidays.Controls.Add(this.gbHolidaysActions);
            this.tpHolidays.Controls.Add(this.pCalendarView);
            this.tpHolidays.Location = new System.Drawing.Point(4, 22);
            this.tpHolidays.Name = "tpHolidays";
            this.tpHolidays.Size = new System.Drawing.Size(784, 498);
            this.tpHolidays.TabIndex = 5;
            this.tpHolidays.Text = "Нерабочие дни";
            this.tpHolidays.UseVisualStyleBackColor = true;
            // 
            // gbHolidaysActions
            // 
            this.gbHolidaysActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbHolidaysActions.Controls.Add(this.btnRefreshHolidaysList);
            this.gbHolidaysActions.Controls.Add(this.btnDeleteHoliday);
            this.gbHolidaysActions.Controls.Add(this.btnInsertHoliday);
            this.gbHolidaysActions.Location = new System.Drawing.Point(8, 25);
            this.gbHolidaysActions.Name = "gbHolidaysActions";
            this.gbHolidaysActions.Size = new System.Drawing.Size(125, 457);
            this.gbHolidaysActions.TabIndex = 1;
            this.gbHolidaysActions.TabStop = false;
            this.gbHolidaysActions.Text = "Действия";
            // 
            // btnRefreshHolidaysList
            // 
            this.btnRefreshHolidaysList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
            this.btnRefreshHolidaysList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshHolidaysList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshHolidaysList.Location = new System.Drawing.Point(6, 77);
            this.btnRefreshHolidaysList.Name = "btnRefreshHolidaysList";
            this.btnRefreshHolidaysList.Size = new System.Drawing.Size(113, 25);
            this.btnRefreshHolidaysList.TabIndex = 2;
            this.btnRefreshHolidaysList.Text = "Обновить";
            this.btnRefreshHolidaysList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRefreshHolidaysList, "Обновить список нерабочих дней");
            this.btnRefreshHolidaysList.UseVisualStyleBackColor = true;
            this.btnRefreshHolidaysList.Click += new System.EventHandler(this.btnRefreshHolidaysList_Click);
            // 
            // btnDeleteHoliday
            // 
            this.btnDeleteHoliday.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
            this.btnDeleteHoliday.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteHoliday.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteHoliday.Location = new System.Drawing.Point(6, 48);
            this.btnDeleteHoliday.Name = "btnDeleteHoliday";
            this.btnDeleteHoliday.Size = new System.Drawing.Size(113, 25);
            this.btnDeleteHoliday.TabIndex = 1;
            this.btnDeleteHoliday.Text = "Удалить";
            this.btnDeleteHoliday.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnDeleteHoliday, "Удалить нерабочий день");
            this.btnDeleteHoliday.UseVisualStyleBackColor = true;
            this.btnDeleteHoliday.Click += new System.EventHandler(this.btnDeleteHoliday_Click);
            // 
            // btnInsertHoliday
            // 
            this.btnInsertHoliday.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
            this.btnInsertHoliday.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertHoliday.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInsertHoliday.Location = new System.Drawing.Point(6, 19);
            this.btnInsertHoliday.Name = "btnInsertHoliday";
            this.btnInsertHoliday.Size = new System.Drawing.Size(113, 25);
            this.btnInsertHoliday.TabIndex = 0;
            this.btnInsertHoliday.Text = "Добавить";
            this.btnInsertHoliday.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnInsertHoliday, "Добавить нерабочий день");
            this.btnInsertHoliday.UseVisualStyleBackColor = true;
            this.btnInsertHoliday.Click += new System.EventHandler(this.btnInsertHoliday_Click);
            // 
            // pCalendarView
            // 
            this.pCalendarView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pCalendarView.Controls.Add(this.datesViewer);
            this.pCalendarView.Location = new System.Drawing.Point(139, 5);
            this.pCalendarView.Name = "pCalendarView";
            this.pCalendarView.Size = new System.Drawing.Size(629, 477);
            this.pCalendarView.TabIndex = 3;
            // 
            // datesViewer
            // 
            this.datesViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datesViewer.Location = new System.Drawing.Point(0, 0);
            this.datesViewer.Name = "datesViewer";
            this.datesViewer.Size = new System.Drawing.Size(629, 477);
            this.datesViewer.TabIndex = 0;
            // 
            // tpContracts
            // 
            this.tpContracts.Controls.Add(this.gbStatus);
            this.tpContracts.Controls.Add(this.gbContractActions);
            this.tpContracts.Controls.Add(this.dgvContracts);
            this.tpContracts.Controls.Add(this.llClearContractFilter);
            this.tpContracts.Location = new System.Drawing.Point(4, 22);
            this.tpContracts.Name = "tpContracts";
            this.tpContracts.Size = new System.Drawing.Size(784, 498);
            this.tpContracts.TabIndex = 4;
            this.tpContracts.Text = "Договоры аренды";
            this.tpContracts.UseVisualStyleBackColor = true;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.lblContractsDateTo);
            this.gbStatus.Controls.Add(this.dprContractsTo);
            this.gbStatus.Controls.Add(this.lblStatus);
            this.gbStatus.Controls.Add(this.lblContractsDateFrom);
            this.gbStatus.Controls.Add(this.rbOpened);
            this.gbStatus.Controls.Add(this.rbClosed);
            this.gbStatus.Controls.Add(this.dprContractsFrom);
            this.gbStatus.Controls.Add(this.rbAll);
            this.gbStatus.Location = new System.Drawing.Point(8, 25);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(125, 204);
            this.gbStatus.TabIndex = 2;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Фильтр";
            // 
            // lblContractsDateTo
            // 
            this.lblContractsDateTo.AutoSize = true;
            this.lblContractsDateTo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblContractsDateTo.Location = new System.Drawing.Point(7, 160);
            this.lblContractsDateTo.Name = "lblContractsDateTo";
            this.lblContractsDateTo.Size = new System.Drawing.Size(19, 13);
            this.lblContractsDateTo.TabIndex = 3;
            this.lblContractsDateTo.Text = "по";
            // 
            // dprContractsTo
            // 
            this.dprContractsTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dprContractsTo.Location = new System.Drawing.Point(6, 176);
            this.dprContractsTo.Name = "dprContractsTo";
            this.dprContractsTo.Size = new System.Drawing.Size(113, 20);
            this.dprContractsTo.TabIndex = 4;
            this.toolTip.SetToolTip(this.dprContractsTo, "Выбрать дату \"по\"");
            this.dprContractsTo.ValueChanged += new System.EventHandler(this.dprContractsTo_ValueChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(7, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Статус";
            // 
            // lblContractsDateFrom
            // 
            this.lblContractsDateFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblContractsDateFrom.Location = new System.Drawing.Point(6, 105);
            this.lblContractsDateFrom.Name = "lblContractsDateFrom";
            this.lblContractsDateFrom.Size = new System.Drawing.Size(116, 29);
            this.lblContractsDateFrom.TabIndex = 0;
            this.lblContractsDateFrom.Text = "Действующие в периоде с ";
            // 
            // rbOpened
            // 
            this.rbOpened.AutoSize = true;
            this.rbOpened.Location = new System.Drawing.Point(6, 72);
            this.rbOpened.Name = "rbOpened";
            this.rbOpened.Size = new System.Drawing.Size(77, 17);
            this.rbOpened.TabIndex = 3;
            this.rbOpened.Text = "Открытые";
            this.rbOpened.UseVisualStyleBackColor = true;
            this.rbOpened.CheckedChanged += new System.EventHandler(this.rbOpened_CheckedChanged);
            // 
            // rbClosed
            // 
            this.rbClosed.AutoSize = true;
            this.rbClosed.Location = new System.Drawing.Point(6, 54);
            this.rbClosed.Name = "rbClosed";
            this.rbClosed.Size = new System.Drawing.Size(77, 17);
            this.rbClosed.TabIndex = 2;
            this.rbClosed.Text = "Закрытые";
            this.rbClosed.UseVisualStyleBackColor = true;
            this.rbClosed.CheckedChanged += new System.EventHandler(this.rbClosed_CheckedChanged);
            // 
            // dprContractsFrom
            // 
            this.dprContractsFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dprContractsFrom.Location = new System.Drawing.Point(6, 137);
            this.dprContractsFrom.Name = "dprContractsFrom";
            this.dprContractsFrom.Size = new System.Drawing.Size(113, 20);
            this.dprContractsFrom.TabIndex = 1;
            this.toolTip.SetToolTip(this.dprContractsFrom, "Выбрать дату \"с\"");
            this.dprContractsFrom.ValueChanged += new System.EventHandler(this.dprContractsFrom_ValueChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(6, 36);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(44, 17);
            this.rbAll.TabIndex = 1;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Все";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // gbContractActions
            // 
            this.gbContractActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbContractActions.Controls.Add(this.bt_ContractView);
            this.gbContractActions.Controls.Add(this.btnContractHistory);
            this.gbContractActions.Controls.Add(this.btnCloseContract);
            this.gbContractActions.Controls.Add(this.btnRefreshContractsList);
            this.gbContractActions.Controls.Add(this.btnManageRentalProperties);
            this.gbContractActions.Controls.Add(this.btnTransferContract);
            this.gbContractActions.Controls.Add(this.btnEditContract);
            this.gbContractActions.Controls.Add(this.btnAddContract);
            this.gbContractActions.Location = new System.Drawing.Point(8, 235);
            this.gbContractActions.Name = "gbContractActions";
            this.gbContractActions.Size = new System.Drawing.Size(125, 264);
            this.gbContractActions.TabIndex = 3;
            this.gbContractActions.TabStop = false;
            this.gbContractActions.Text = "Действия";
            // 
            // bt_ContractView
            // 
            this.bt_ContractView.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.view;
            this.bt_ContractView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ContractView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bt_ContractView.Location = new System.Drawing.Point(7, 79);
            this.bt_ContractView.Name = "bt_ContractView";
            this.bt_ContractView.Size = new System.Drawing.Size(113, 25);
            this.bt_ContractView.TabIndex = 7;
            this.bt_ContractView.Text = "Просмотреть";
            this.bt_ContractView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.bt_ContractView, "Просмотреть договор аренды");
            this.bt_ContractView.UseVisualStyleBackColor = true;
            this.bt_ContractView.Click += new System.EventHandler(this.bt_ContractView_Click);
            // 
            // btnContractHistory
            // 
            this.btnContractHistory.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.script;
            this.btnContractHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContractHistory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContractHistory.Location = new System.Drawing.Point(6, 201);
            this.btnContractHistory.Name = "btnContractHistory";
            this.btnContractHistory.Size = new System.Drawing.Size(113, 25);
            this.btnContractHistory.TabIndex = 5;
            this.btnContractHistory.Text = "История";
            this.btnContractHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnContractHistory, "Нажмите для отображения истории договора");
            this.btnContractHistory.UseVisualStyleBackColor = true;
            this.btnContractHistory.Click += new System.EventHandler(this.btnContractHistory_Click);
            // 
            // btnCloseContract
            // 
            this.btnCloseContract.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
            this.btnCloseContract.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseContract.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCloseContract.Location = new System.Drawing.Point(6, 172);
            this.btnCloseContract.Name = "btnCloseContract";
            this.btnCloseContract.Size = new System.Drawing.Size(113, 25);
            this.btnCloseContract.TabIndex = 4;
            this.btnCloseContract.Text = "Закрыть";
            this.btnCloseContract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnCloseContract, "Произвести закрытие договора");
            this.btnCloseContract.UseVisualStyleBackColor = true;
            this.btnCloseContract.Click += new System.EventHandler(this.btnCloseContract_Click);
            // 
            // btnRefreshContractsList
            // 
            this.btnRefreshContractsList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
            this.btnRefreshContractsList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshContractsList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshContractsList.Location = new System.Drawing.Point(6, 230);
            this.btnRefreshContractsList.Name = "btnRefreshContractsList";
            this.btnRefreshContractsList.Size = new System.Drawing.Size(113, 25);
            this.btnRefreshContractsList.TabIndex = 6;
            this.btnRefreshContractsList.Text = "Обновить";
            this.btnRefreshContractsList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRefreshContractsList, "Обновить список договоров");
            this.btnRefreshContractsList.UseVisualStyleBackColor = true;
            this.btnRefreshContractsList.Click += new System.EventHandler(this.btnRefreshContractsList_Click);
            // 
            // btnManageRentalProperties
            // 
            this.btnManageRentalProperties.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.table;
            this.btnManageRentalProperties.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageRentalProperties.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnManageRentalProperties.Location = new System.Drawing.Point(6, 141);
            this.btnManageRentalProperties.Name = "btnManageRentalProperties";
            this.btnManageRentalProperties.Size = new System.Drawing.Size(113, 25);
            this.btnManageRentalProperties.TabIndex = 3;
            this.btnManageRentalProperties.Text = "Места";
            this.btnManageRentalProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnManageRentalProperties, "Редактировать список торговых мест");
            this.btnManageRentalProperties.UseVisualStyleBackColor = true;
            this.btnManageRentalProperties.Click += new System.EventHandler(this.btnManageRentalProperties_Click);
            // 
            // btnTransferContract
            // 
            this.btnTransferContract.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.transfer;
            this.btnTransferContract.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransferContract.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTransferContract.Location = new System.Drawing.Point(6, 110);
            this.btnTransferContract.Name = "btnTransferContract";
            this.btnTransferContract.Size = new System.Drawing.Size(113, 25);
            this.btnTransferContract.TabIndex = 2;
            this.btnTransferContract.Text = "Передать";
            this.btnTransferContract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnTransferContract, "Передать торговые места с одного договора на другой");
            this.btnTransferContract.UseVisualStyleBackColor = true;
            this.btnTransferContract.Click += new System.EventHandler(this.btnTransferContract_Click);
            // 
            // btnEditContract
            // 
            this.btnEditContract.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.edit;
            this.btnEditContract.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditContract.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditContract.Location = new System.Drawing.Point(6, 48);
            this.btnEditContract.Name = "btnEditContract";
            this.btnEditContract.Size = new System.Drawing.Size(113, 25);
            this.btnEditContract.TabIndex = 1;
            this.btnEditContract.Text = "Редактировать";
            this.btnEditContract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnEditContract, "Редактировать договор аренды");
            this.btnEditContract.UseVisualStyleBackColor = true;
            this.btnEditContract.Click += new System.EventHandler(this.btnEditContract_Click);
            // 
            // btnAddContract
            // 
            this.btnAddContract.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
            this.btnAddContract.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddContract.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddContract.Location = new System.Drawing.Point(6, 19);
            this.btnAddContract.Name = "btnAddContract";
            this.btnAddContract.Size = new System.Drawing.Size(113, 25);
            this.btnAddContract.TabIndex = 0;
            this.btnAddContract.Text = "Добавить";
            this.btnAddContract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnAddContract, "Добавить новый договор аренды");
            this.btnAddContract.UseVisualStyleBackColor = true;
            this.btnAddContract.Click += new System.EventHandler(this.btnAddContract_Click);
            // 
            // dgvContracts
            // 
            this.dgvContracts.AllowUserToAddRows = false;
            this.dgvContracts.AllowUserToDeleteRows = false;
            this.dgvContracts.AllowUserToOrderColumns = true;
            this.dgvContracts.AllowUserToResizeRows = false;
            this.dgvContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContracts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContractId,
            this.RentalServiceId,
            this.columnContractNumber,
            this.columnContractCreationDate,
            this.ContractCrUserId,
            this.columnContractDateFrom,
            this.columnContractDateTo,
            this.columnContractDissolutionDate,
            this.ClientName,
            this.Client1SCode,
            this.Contract1SCode,
            this.PassportOutletOrgan,
            this.ClientAddress,
            this.ClientPostAddress,
            this.ClientPhone,
            this.PassportSeries,
            this.PassportOutletDate,
            this.INN,
            this.IsCashless,
            this.columnContractCashlessPaymentControlDate,
            this.PassportNumber,
            this.IsJuridicalPerson,
            this.PlacePrice,
            this.Service,
            this.ContractChDateTime,
            this.ContractChUserId,
            this.ContractUser,
            this.ContractUser1,
            this.ContractStatus,
            this.ContractStatusDateTime,
            this.ContractStatusMessage});
            this.dgvContracts.ContextMenuStrip = this.cmsContract;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContracts.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvContracts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvContracts.Location = new System.Drawing.Point(139, 25);
            this.dgvContracts.MultiSelect = false;
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContracts.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvContracts.RowHeadersVisible = false;
            this.dgvContracts.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContracts.Size = new System.Drawing.Size(637, 464);
            this.dgvContracts.TabIndex = 2;
            this.toolTip.SetToolTip(this.dgvContracts, "Список договоров аренды");
            this.dgvContracts.Enter += new System.EventHandler(this.dgvContracts_Enter);
            this.dgvContracts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContracts_CellDoubleClick);
            this.dgvContracts.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvContracts_ColumnHeaderMouseClick);
            this.dgvContracts.Leave += new System.EventHandler(this.dgvContracts_Leave);
            this.dgvContracts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvContracts_KeyDown);
            this.dgvContracts.SelectionChanged += new System.EventHandler(this.dgvContracts_SelectionChanged);
            // 
            // ContractId
            // 
            this.ContractId.DataPropertyName = "Id";
            this.ContractId.HeaderText = "Id";
            this.ContractId.Name = "ContractId";
            this.ContractId.ReadOnly = true;
            this.ContractId.Visible = false;
            // 
            // RentalServiceId
            // 
            this.RentalServiceId.DataPropertyName = "RentalServiceId";
            this.RentalServiceId.HeaderText = "RentalServiceId";
            this.RentalServiceId.Name = "RentalServiceId";
            this.RentalServiceId.ReadOnly = true;
            this.RentalServiceId.Visible = false;
            // 
            // columnContractNumber
            // 
            this.columnContractNumber.DataPropertyName = "ContractNumber";
            this.columnContractNumber.FillWeight = 80F;
            this.columnContractNumber.HeaderText = "Номер договора";
            this.columnContractNumber.Name = "columnContractNumber";
            this.columnContractNumber.ReadOnly = true;
            // 
            // columnContractCreationDate
            // 
            this.columnContractCreationDate.DataPropertyName = "CrDateTime";
            this.columnContractCreationDate.HeaderText = "Дата создания";
            this.columnContractCreationDate.Name = "columnContractCreationDate";
            this.columnContractCreationDate.ReadOnly = true;
            this.columnContractCreationDate.Visible = false;
            // 
            // ContractCrUserId
            // 
            this.ContractCrUserId.DataPropertyName = "CrUserId";
            this.ContractCrUserId.HeaderText = "ContractCrUserId";
            this.ContractCrUserId.Name = "ContractCrUserId";
            this.ContractCrUserId.ReadOnly = true;
            this.ContractCrUserId.Visible = false;
            // 
            // columnContractDateFrom
            // 
            this.columnContractDateFrom.DataPropertyName = "DateFrom";
            this.columnContractDateFrom.FillWeight = 80F;
            this.columnContractDateFrom.HeaderText = "Срок действия с";
            this.columnContractDateFrom.Name = "columnContractDateFrom";
            this.columnContractDateFrom.ReadOnly = true;
            // 
            // columnContractDateTo
            // 
            this.columnContractDateTo.DataPropertyName = "DateTo";
            this.columnContractDateTo.FillWeight = 80F;
            this.columnContractDateTo.HeaderText = "Срок действия по";
            this.columnContractDateTo.Name = "columnContractDateTo";
            this.columnContractDateTo.ReadOnly = true;
            // 
            // columnContractDissolutionDate
            // 
            this.columnContractDissolutionDate.DataPropertyName = "DissolutionDate";
            this.columnContractDissolutionDate.FillWeight = 80F;
            this.columnContractDissolutionDate.HeaderText = "Дата закрытия";
            this.columnContractDissolutionDate.Name = "columnContractDissolutionDate";
            this.columnContractDissolutionDate.ReadOnly = true;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.FillWeight = 150F;
            this.ClientName.HeaderText = "Контрагент";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // Client1SCode
            // 
            this.Client1SCode.DataPropertyName = "Client1SCode";
            this.Client1SCode.HeaderText = "Код контрагента";
            this.Client1SCode.Name = "Client1SCode";
            this.Client1SCode.ReadOnly = true;
            // 
            // Contract1SCode
            // 
            this.Contract1SCode.DataPropertyName = "Contract1SCode";
            this.Contract1SCode.HeaderText = "Contract1SCode";
            this.Contract1SCode.Name = "Contract1SCode";
            this.Contract1SCode.ReadOnly = true;
            this.Contract1SCode.Visible = false;
            // 
            // PassportOutletOrgan
            // 
            this.PassportOutletOrgan.DataPropertyName = "PassportOutletOrgan";
            this.PassportOutletOrgan.HeaderText = "PassportOutletOrgan";
            this.PassportOutletOrgan.Name = "PassportOutletOrgan";
            this.PassportOutletOrgan.ReadOnly = true;
            this.PassportOutletOrgan.Visible = false;
            // 
            // ClientAddress
            // 
            this.ClientAddress.DataPropertyName = "ClientAddress";
            this.ClientAddress.HeaderText = "ClientAddress";
            this.ClientAddress.Name = "ClientAddress";
            this.ClientAddress.ReadOnly = true;
            this.ClientAddress.Visible = false;
            // 
            // ClientPostAddress
            // 
            this.ClientPostAddress.DataPropertyName = "ClientPostAddress";
            this.ClientPostAddress.HeaderText = "ClientPostAddress";
            this.ClientPostAddress.Name = "ClientPostAddress";
            this.ClientPostAddress.ReadOnly = true;
            this.ClientPostAddress.Visible = false;
            // 
            // ClientPhone
            // 
            this.ClientPhone.DataPropertyName = "ClientPhone";
            this.ClientPhone.HeaderText = "ClientPhone";
            this.ClientPhone.Name = "ClientPhone";
            this.ClientPhone.ReadOnly = true;
            this.ClientPhone.Visible = false;
            // 
            // PassportSeries
            // 
            this.PassportSeries.DataPropertyName = "PassportSeries";
            this.PassportSeries.HeaderText = "PassportSeries";
            this.PassportSeries.Name = "PassportSeries";
            this.PassportSeries.ReadOnly = true;
            this.PassportSeries.Visible = false;
            // 
            // PassportOutletDate
            // 
            this.PassportOutletDate.DataPropertyName = "PassportOutletDate";
            this.PassportOutletDate.HeaderText = "PassportOutletDate";
            this.PassportOutletDate.Name = "PassportOutletDate";
            this.PassportOutletDate.ReadOnly = true;
            this.PassportOutletDate.Visible = false;
            // 
            // INN
            // 
            this.INN.DataPropertyName = "INN";
            this.INN.HeaderText = "ИНН";
            this.INN.Name = "INN";
            this.INN.ReadOnly = true;
            this.INN.Visible = false;
            // 
            // IsCashless
            // 
            this.IsCashless.DataPropertyName = "IsCashless";
            this.IsCashless.FillWeight = 65F;
            this.IsCashless.HeaderText = "Оплата по б/н";
            this.IsCashless.Name = "IsCashless";
            this.IsCashless.ReadOnly = true;
            this.IsCashless.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCashless.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnContractCashlessPaymentControlDate
            // 
            this.columnContractCashlessPaymentControlDate.DataPropertyName = "CashlessPaymentControlDate";
            this.columnContractCashlessPaymentControlDate.HeaderText = "Дата проверки платежа";
            this.columnContractCashlessPaymentControlDate.Name = "columnContractCashlessPaymentControlDate";
            this.columnContractCashlessPaymentControlDate.ReadOnly = true;
            this.columnContractCashlessPaymentControlDate.Visible = false;
            // 
            // PassportNumber
            // 
            this.PassportNumber.DataPropertyName = "PassportNumber";
            this.PassportNumber.HeaderText = "Номер паспорта";
            this.PassportNumber.Name = "PassportNumber";
            this.PassportNumber.ReadOnly = true;
            this.PassportNumber.Visible = false;
            // 
            // IsJuridicalPerson
            // 
            this.IsJuridicalPerson.DataPropertyName = "IsJuridicalPerson";
            this.IsJuridicalPerson.HeaderText = "Тип договора";
            this.IsJuridicalPerson.Name = "IsJuridicalPerson";
            this.IsJuridicalPerson.ReadOnly = true;
            this.IsJuridicalPerson.Visible = false;
            // 
            // PlacePrice
            // 
            this.PlacePrice.DataPropertyName = "PlacePrice";
            this.PlacePrice.HeaderText = "PlacePrice";
            this.PlacePrice.Name = "PlacePrice";
            this.PlacePrice.ReadOnly = true;
            this.PlacePrice.Visible = false;
            // 
            // Service
            // 
            this.Service.DataPropertyName = "Service";
            this.Service.HeaderText = "Service";
            this.Service.Name = "Service";
            this.Service.ReadOnly = true;
            this.Service.Visible = false;
            // 
            // ContractChDateTime
            // 
            this.ContractChDateTime.DataPropertyName = "ChDateTime";
            this.ContractChDateTime.HeaderText = "ContractChDateTime";
            this.ContractChDateTime.Name = "ContractChDateTime";
            this.ContractChDateTime.ReadOnly = true;
            this.ContractChDateTime.Visible = false;
            // 
            // ContractChUserId
            // 
            this.ContractChUserId.DataPropertyName = "ChUserId";
            this.ContractChUserId.HeaderText = "ContractChUserId";
            this.ContractChUserId.Name = "ContractChUserId";
            this.ContractChUserId.ReadOnly = true;
            this.ContractChUserId.Visible = false;
            // 
            // ContractUser
            // 
            this.ContractUser.DataPropertyName = "User";
            this.ContractUser.HeaderText = "ContractUser";
            this.ContractUser.Name = "ContractUser";
            this.ContractUser.ReadOnly = true;
            this.ContractUser.Visible = false;
            // 
            // ContractUser1
            // 
            this.ContractUser1.DataPropertyName = "User1";
            this.ContractUser1.HeaderText = "ContractUser1";
            this.ContractUser1.Name = "ContractUser1";
            this.ContractUser1.ReadOnly = true;
            this.ContractUser1.Visible = false;
            // 
            // ContractStatus
            // 
            this.ContractStatus.DataPropertyName = "Status";
            this.ContractStatus.HeaderText = "ContractStatus";
            this.ContractStatus.Name = "ContractStatus";
            this.ContractStatus.ReadOnly = true;
            this.ContractStatus.Visible = false;
            // 
            // ContractStatusDateTime
            // 
            this.ContractStatusDateTime.DataPropertyName = "StatusDateTime";
            this.ContractStatusDateTime.HeaderText = "ContractStatusDateTime";
            this.ContractStatusDateTime.Name = "ContractStatusDateTime";
            this.ContractStatusDateTime.ReadOnly = true;
            this.ContractStatusDateTime.Visible = false;
            // 
            // ContractStatusMessage
            // 
            this.ContractStatusMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContractStatusMessage.DataPropertyName = "StatusMessage";
            this.ContractStatusMessage.FillWeight = 150F;
            this.ContractStatusMessage.HeaderText = "Результат выгрузки в 1С";
            this.ContractStatusMessage.Name = "ContractStatusMessage";
            this.ContractStatusMessage.ReadOnly = true;
            // 
            // cmsContract
            // 
            this.cmsContract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddContract,
            this.tsmiEditContract,
            this.tsmi_ContractView,
            this.tsmiTransfer,
            this.tsmiRentalProperties,
            this.tsmiCloseContract,
            this.tsmiContractHistory});
            this.cmsContract.Name = "cmsContract";
            this.cmsContract.ShowImageMargin = false;
            this.cmsContract.Size = new System.Drawing.Size(130, 158);
            // 
            // tsmiAddContract
            // 
            this.tsmiAddContract.Name = "tsmiAddContract";
            this.tsmiAddContract.Size = new System.Drawing.Size(129, 22);
            this.tsmiAddContract.Text = "Добавить";
            this.tsmiAddContract.Click += new System.EventHandler(this.tsmiAddContract_Click);
            // 
            // tsmiEditContract
            // 
            this.tsmiEditContract.Name = "tsmiEditContract";
            this.tsmiEditContract.Size = new System.Drawing.Size(129, 22);
            this.tsmiEditContract.Text = "Редактировать";
            this.tsmiEditContract.Click += new System.EventHandler(this.tsmiEditContract_Click);
            // 
            // tsmi_ContractView
            // 
            this.tsmi_ContractView.Name = "tsmi_ContractView";
            this.tsmi_ContractView.Size = new System.Drawing.Size(129, 22);
            this.tsmi_ContractView.Text = "Просмотреть";
            this.tsmi_ContractView.Click += new System.EventHandler(this.tsmi_ContractView_Click);
            // 
            // tsmiTransfer
            // 
            this.tsmiTransfer.Name = "tsmiTransfer";
            this.tsmiTransfer.Size = new System.Drawing.Size(129, 22);
            this.tsmiTransfer.Text = "Передать";
            this.tsmiTransfer.Click += new System.EventHandler(this.tsmiTransfer_Click);
            // 
            // tsmiRentalProperties
            // 
            this.tsmiRentalProperties.Name = "tsmiRentalProperties";
            this.tsmiRentalProperties.Size = new System.Drawing.Size(129, 22);
            this.tsmiRentalProperties.Text = "Места";
            this.tsmiRentalProperties.Click += new System.EventHandler(this.tsmiRentalProperties_Click);
            // 
            // tsmiCloseContract
            // 
            this.tsmiCloseContract.Name = "tsmiCloseContract";
            this.tsmiCloseContract.Size = new System.Drawing.Size(129, 22);
            this.tsmiCloseContract.Text = "Закрыть";
            this.tsmiCloseContract.Click += new System.EventHandler(this.tsmiCloseContract_Click);
            // 
            // tsmiContractHistory
            // 
            this.tsmiContractHistory.Name = "tsmiContractHistory";
            this.tsmiContractHistory.Size = new System.Drawing.Size(129, 22);
            this.tsmiContractHistory.Text = "История";
            this.tsmiContractHistory.Click += new System.EventHandler(this.tsmiContractHistory_Click);
            // 
            // llClearContractFilter
            // 
            this.llClearContractFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearContractFilter.Image = ((System.Drawing.Image)(resources.GetObject("llClearContractFilter.Image")));
            this.llClearContractFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearContractFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearContractFilter.Location = new System.Drawing.Point(117, 5);
            this.llClearContractFilter.Name = "llClearContractFilter";
            this.llClearContractFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearContractFilter.TabIndex = 1;
            this.toolTip.SetToolTip(this.llClearContractFilter, "Очистить быстрый фильтр");
            this.llClearContractFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearContractFilter_MouseClick);
            this.llClearContractFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseDown);
            this.llClearContractFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseUp);
            // 
            // tpTerminalMonitor
            // 
            this.tpTerminalMonitor.Controls.Add(this.llClearTerminalFilter);
            this.tpTerminalMonitor.Controls.Add(this.gbTerminalMonitorActions);
            this.tpTerminalMonitor.Controls.Add(this.dgvTerminalsList);
            this.tpTerminalMonitor.Location = new System.Drawing.Point(4, 22);
            this.tpTerminalMonitor.Name = "tpTerminalMonitor";
            this.tpTerminalMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tpTerminalMonitor.Size = new System.Drawing.Size(784, 498);
            this.tpTerminalMonitor.TabIndex = 0;
            this.tpTerminalMonitor.Text = "Терминалы";
            this.tpTerminalMonitor.UseVisualStyleBackColor = true;
            // 
            // llClearTerminalFilter
            // 
            this.llClearTerminalFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearTerminalFilter.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.clearFilter_default;
            this.llClearTerminalFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearTerminalFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearTerminalFilter.Location = new System.Drawing.Point(117, 5);
            this.llClearTerminalFilter.Name = "llClearTerminalFilter";
            this.llClearTerminalFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearTerminalFilter.TabIndex = 4;
            this.toolTip.SetToolTip(this.llClearTerminalFilter, "Очистить фильтр");
            this.llClearTerminalFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearTerminalFilter_MouseClick);
            this.llClearTerminalFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseDown);
            this.llClearTerminalFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseUp);
            // 
            // gbTerminalMonitorActions
            // 
            this.gbTerminalMonitorActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbTerminalMonitorActions.Controls.Add(this.lblMinutes);
            this.gbTerminalMonitorActions.Controls.Add(this.nudInterval);
            this.gbTerminalMonitorActions.Controls.Add(this.cbxRefreshAutomaticaly);
            this.gbTerminalMonitorActions.Controls.Add(this.btnRefreshTerminalsList);
            this.gbTerminalMonitorActions.Location = new System.Drawing.Point(8, 25);
            this.gbTerminalMonitorActions.Name = "gbTerminalMonitorActions";
            this.gbTerminalMonitorActions.Size = new System.Drawing.Size(125, 462);
            this.gbTerminalMonitorActions.TabIndex = 3;
            this.gbTerminalMonitorActions.TabStop = false;
            this.gbTerminalMonitorActions.Text = "Действия";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(60, 88);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(37, 13);
            this.lblMinutes.TabIndex = 4;
            this.lblMinutes.Text = "минут";
            this.lblMinutes.Visible = false;
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(14, 85);
            this.nudInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(40, 20);
            this.nudInterval.TabIndex = 3;
            this.nudInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Visible = false;
            this.nudInterval.ValueChanged += new System.EventHandler(this.nudInterval_ValueChanged);
            // 
            // cbxRefreshAutomaticaly
            // 
            this.cbxRefreshAutomaticaly.Location = new System.Drawing.Point(7, 49);
            this.cbxRefreshAutomaticaly.Name = "cbxRefreshAutomaticaly";
            this.cbxRefreshAutomaticaly.Size = new System.Drawing.Size(105, 30);
            this.cbxRefreshAutomaticaly.TabIndex = 2;
            this.cbxRefreshAutomaticaly.Text = "Обновлять автоматически";
            this.toolTip.SetToolTip(this.cbxRefreshAutomaticaly, "Автоматическое обновление списка терминалов");
            this.cbxRefreshAutomaticaly.UseVisualStyleBackColor = true;
            this.cbxRefreshAutomaticaly.CheckedChanged += new System.EventHandler(this.cbxRefreshAutomaticaly_CheckedChanged);
            // 
            // btnRefreshTerminalsList
            // 
            this.btnRefreshTerminalsList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
            this.btnRefreshTerminalsList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshTerminalsList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshTerminalsList.Location = new System.Drawing.Point(6, 19);
            this.btnRefreshTerminalsList.Name = "btnRefreshTerminalsList";
            this.btnRefreshTerminalsList.Size = new System.Drawing.Size(113, 25);
            this.btnRefreshTerminalsList.TabIndex = 1;
            this.btnRefreshTerminalsList.Text = "Обновить";
            this.btnRefreshTerminalsList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRefreshTerminalsList, "Обновить список терминалов");
            this.btnRefreshTerminalsList.UseVisualStyleBackColor = true;
            this.btnRefreshTerminalsList.Click += new System.EventHandler(this.btnRefreshTerminalsList_Click);
            // 
            // dgvTerminalsList
            // 
            this.dgvTerminalsList.AllowUserToAddRows = false;
            this.dgvTerminalsList.AllowUserToDeleteRows = false;
            this.dgvTerminalsList.AllowUserToOrderColumns = true;
            this.dgvTerminalsList.AllowUserToResizeRows = false;
            this.dgvTerminalsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTerminalsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTerminalsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvTerminalsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerminalsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TerminalId,
            this.columnTerminalNetworkName,
            this.TerminalStatus,
            this.TerminalStarted,
            this.columnTerminalTotalPaidSum,
            this.columnTerminalRentalPaidSum,
            this.columnTerminalServicePaidSum,
            this.TerminalShiftNumber});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTerminalsList.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvTerminalsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTerminalsList.Location = new System.Drawing.Point(139, 25);
            this.dgvTerminalsList.MultiSelect = false;
            this.dgvTerminalsList.Name = "dgvTerminalsList";
            this.dgvTerminalsList.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTerminalsList.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvTerminalsList.RowHeadersVisible = false;
            this.dgvTerminalsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTerminalsList.Size = new System.Drawing.Size(637, 461);
            this.dgvTerminalsList.TabIndex = 5;
            this.toolTip.SetToolTip(this.dgvTerminalsList, "Список терминалов");
            this.dgvTerminalsList.Enter += new System.EventHandler(this.dgvTerminalsList_Enter);
            this.dgvTerminalsList.Leave += new System.EventHandler(this.dgvTerminalsList_Leave);
            // 
            // tpRentalPayLog
            // 
            this.tpRentalPayLog.Controls.Add(this.llClearRentalPayLogFilter);
            this.tpRentalPayLog.Controls.Add(this.dgvRentalPayLog);
            this.tpRentalPayLog.Controls.Add(this.gpRentalPayLogActions);
            this.tpRentalPayLog.Controls.Add(this.gbRentalPayLogFilter);
            this.tpRentalPayLog.Location = new System.Drawing.Point(4, 22);
            this.tpRentalPayLog.Name = "tpRentalPayLog";
            this.tpRentalPayLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpRentalPayLog.Size = new System.Drawing.Size(784, 498);
            this.tpRentalPayLog.TabIndex = 3;
            this.tpRentalPayLog.Text = "Оплата аренды";
            this.tpRentalPayLog.UseVisualStyleBackColor = true;
            // 
            // llClearRentalPayLogFilter
            // 
            this.llClearRentalPayLogFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearRentalPayLogFilter.Image = ((System.Drawing.Image)(resources.GetObject("llClearRentalPayLogFilter.Image")));
            this.llClearRentalPayLogFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearRentalPayLogFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearRentalPayLogFilter.Location = new System.Drawing.Point(117, 5);
            this.llClearRentalPayLogFilter.Name = "llClearRentalPayLogFilter";
            this.llClearRentalPayLogFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearRentalPayLogFilter.TabIndex = 24;
            this.toolTip.SetToolTip(this.llClearRentalPayLogFilter, "Очистить фильтр");
            this.llClearRentalPayLogFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearPayLogFilter_MouseClick);
            this.llClearRentalPayLogFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseDown);
            this.llClearRentalPayLogFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseUp);
            // 
            // dgvRentalPayLog
            // 
            this.dgvRentalPayLog.AllowUserToAddRows = false;
            this.dgvRentalPayLog.AllowUserToDeleteRows = false;
            this.dgvRentalPayLog.AllowUserToOrderColumns = true;
            this.dgvRentalPayLog.AllowUserToResizeRows = false;
            this.dgvRentalPayLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRentalPayLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRentalPayLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvRentalPayLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalPayLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RentalPlaceNumber,
            this.Contract,
            this.columnRentalPayLogDate,
            this.RentalTerminal,
            this.isPaid,
            this.columnRentalPropertyRate,
            this.columnRentalPropertyPaidSum,
            this.RentalStatusMessage});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRentalPayLog.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvRentalPayLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRentalPayLog.Location = new System.Drawing.Point(139, 25);
            this.dgvRentalPayLog.MultiSelect = false;
            this.dgvRentalPayLog.Name = "dgvRentalPayLog";
            this.dgvRentalPayLog.ReadOnly = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRentalPayLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvRentalPayLog.RowHeadersVisible = false;
            this.dgvRentalPayLog.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvRentalPayLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentalPayLog.Size = new System.Drawing.Size(637, 462);
            this.dgvRentalPayLog.TabIndex = 8;
            this.toolTip.SetToolTip(this.dgvRentalPayLog, "Оплата аренды");
            this.dgvRentalPayLog.Enter += new System.EventHandler(this.dgvRentalPayLog_Enter);
            this.dgvRentalPayLog.Leave += new System.EventHandler(this.dgvRentalPayLog_Leave);
            // 
            // RentalPlaceNumber
            // 
            this.RentalPlaceNumber.DataPropertyName = "RentalPlaceNumber";
            this.RentalPlaceNumber.HeaderText = "№ места";
            this.RentalPlaceNumber.Name = "RentalPlaceNumber";
            this.RentalPlaceNumber.ReadOnly = true;
            // 
            // Contract
            // 
            this.Contract.DataPropertyName = "ContractNumber";
            this.Contract.HeaderText = "№ договора";
            this.Contract.Name = "Contract";
            this.Contract.ReadOnly = true;
            // 
            // columnRentalPayLogDate
            // 
            this.columnRentalPayLogDate.DataPropertyName = "Date";
            this.columnRentalPayLogDate.HeaderText = "Время оплаты";
            this.columnRentalPayLogDate.Name = "columnRentalPayLogDate";
            this.columnRentalPayLogDate.ReadOnly = true;
            // 
            // RentalTerminal
            // 
            this.RentalTerminal.DataPropertyName = "Terminal";
            this.RentalTerminal.HeaderText = "Терминал";
            this.RentalTerminal.Name = "RentalTerminal";
            this.RentalTerminal.ReadOnly = true;
            // 
            // isPaid
            // 
            this.isPaid.DataPropertyName = "IsPaid";
            this.isPaid.HeaderText = "Флаг оплаты";
            this.isPaid.Name = "isPaid";
            this.isPaid.ReadOnly = true;
            this.isPaid.Visible = false;
            // 
            // columnRentalPropertyRate
            // 
            this.columnRentalPropertyRate.DataPropertyName = "Rate";
            this.columnRentalPropertyRate.HeaderText = "Тариф";
            this.columnRentalPropertyRate.Name = "columnRentalPropertyRate";
            this.columnRentalPropertyRate.ReadOnly = true;
            // 
            // columnRentalPropertyPaidSum
            // 
            this.columnRentalPropertyPaidSum.DataPropertyName = "PaidSum";
            this.columnRentalPropertyPaidSum.HeaderText = "Сумма";
            this.columnRentalPropertyPaidSum.Name = "columnRentalPropertyPaidSum";
            this.columnRentalPropertyPaidSum.ReadOnly = true;
            // 
            // RentalStatusMessage
            // 
            this.RentalStatusMessage.DataPropertyName = "StatusMessage";
            this.RentalStatusMessage.HeaderText = "Результат выгрузки в 1С";
            this.RentalStatusMessage.Name = "RentalStatusMessage";
            this.RentalStatusMessage.ReadOnly = true;
            // 
            // gpRentalPayLogActions
            // 
            this.gpRentalPayLogActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gpRentalPayLogActions.Controls.Add(this.btnRentalPaymentsListPrint);
            this.gpRentalPayLogActions.Controls.Add(this.btnRefreshRentalPaylog);
            this.gpRentalPayLogActions.Controls.Add(this.btnNotPaidReport);
            this.gpRentalPayLogActions.Controls.Add(this.btnPaidReport);
            this.gpRentalPayLogActions.Location = new System.Drawing.Point(8, 199);
            this.gpRentalPayLogActions.Name = "gpRentalPayLogActions";
            this.gpRentalPayLogActions.Size = new System.Drawing.Size(125, 288);
            this.gpRentalPayLogActions.TabIndex = 6;
            this.gpRentalPayLogActions.TabStop = false;
            this.gpRentalPayLogActions.Text = "Действия";
            // 
            // btnRentalPaymentsListPrint
            // 
            this.btnRentalPaymentsListPrint.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.table;
            this.btnRentalPaymentsListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentalPaymentsListPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRentalPaymentsListPrint.Location = new System.Drawing.Point(6, 105);
            this.btnRentalPaymentsListPrint.Name = "btnRentalPaymentsListPrint";
            this.btnRentalPaymentsListPrint.Size = new System.Drawing.Size(113, 25);
            this.btnRentalPaymentsListPrint.TabIndex = 6;
            this.btnRentalPaymentsListPrint.Text = "Распечатать";
            this.btnRentalPaymentsListPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRentalPaymentsListPrint, "Распечатать таблицу");
            this.btnRentalPaymentsListPrint.UseVisualStyleBackColor = true;
            this.btnRentalPaymentsListPrint.Click += new System.EventHandler(this.btnRentalPaymentsListPrint_Click);
            // 
            // btnRefreshRentalPaylog
            // 
            this.btnRefreshRentalPaylog.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
            this.btnRefreshRentalPaylog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshRentalPaylog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshRentalPaylog.Location = new System.Drawing.Point(6, 77);
            this.btnRefreshRentalPaylog.Name = "btnRefreshRentalPaylog";
            this.btnRefreshRentalPaylog.Size = new System.Drawing.Size(113, 25);
            this.btnRefreshRentalPaylog.TabIndex = 3;
            this.btnRefreshRentalPaylog.Text = "Обновить";
            this.btnRefreshRentalPaylog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRefreshRentalPaylog, "Обновить журнал оплаты аренды");
            this.btnRefreshRentalPaylog.UseVisualStyleBackColor = true;
            this.btnRefreshRentalPaylog.Click += new System.EventHandler(this.btnRefreshRentalPaylog_Click);
            // 
            // btnNotPaidReport
            // 
            this.btnNotPaidReport.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.document;
            this.btnNotPaidReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNotPaidReport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNotPaidReport.Location = new System.Drawing.Point(6, 19);
            this.btnNotPaidReport.Name = "btnNotPaidReport";
            this.btnNotPaidReport.Size = new System.Drawing.Size(113, 25);
            this.btnNotPaidReport.TabIndex = 0;
            this.btnNotPaidReport.Text = "Неоплаченные";
            this.btnNotPaidReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnNotPaidReport, "Сформировать отчет о неоплаченных местах за период");
            this.btnNotPaidReport.UseVisualStyleBackColor = true;
            this.btnNotPaidReport.Click += new System.EventHandler(this.btnNotPaidReport_Click);
            // 
            // btnPaidReport
            // 
            this.btnPaidReport.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.document_ok;
            this.btnPaidReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaidReport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPaidReport.Location = new System.Drawing.Point(6, 48);
            this.btnPaidReport.Name = "btnPaidReport";
            this.btnPaidReport.Size = new System.Drawing.Size(113, 25);
            this.btnPaidReport.TabIndex = 1;
            this.btnPaidReport.Text = "Оплаченные";
            this.btnPaidReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnPaidReport, "Сформировать отчет об оплаченных суммах за период");
            this.btnPaidReport.UseVisualStyleBackColor = true;
            this.btnPaidReport.Click += new System.EventHandler(this.btnPaidReport_Click);
            // 
            // gbRentalPayLogFilter
            // 
            this.gbRentalPayLogFilter.Controls.Add(this.lblRentalPayLogRecordToDate);
            this.gbRentalPayLogFilter.Controls.Add(this.lblRentalPayLogRecordFromDate);
            this.gbRentalPayLogFilter.Controls.Add(this.dprRentalPayLogToTime);
            this.gbRentalPayLogFilter.Controls.Add(this.dprRentalPayLogToDate);
            this.gbRentalPayLogFilter.Controls.Add(this.dprRentalPayLogFromTime);
            this.gbRentalPayLogFilter.Controls.Add(this.dprRentalPayLogFromDate);
            this.gbRentalPayLogFilter.Location = new System.Drawing.Point(8, 25);
            this.gbRentalPayLogFilter.Name = "gbRentalPayLogFilter";
            this.gbRentalPayLogFilter.Size = new System.Drawing.Size(125, 168);
            this.gbRentalPayLogFilter.TabIndex = 7;
            this.gbRentalPayLogFilter.TabStop = false;
            this.gbRentalPayLogFilter.Text = "Фильтр";
            // 
            // lblRentalPayLogRecordToDate
            // 
            this.lblRentalPayLogRecordToDate.AutoSize = true;
            this.lblRentalPayLogRecordToDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRentalPayLogRecordToDate.Location = new System.Drawing.Point(6, 97);
            this.lblRentalPayLogRecordToDate.Name = "lblRentalPayLogRecordToDate";
            this.lblRentalPayLogRecordToDate.Size = new System.Drawing.Size(19, 13);
            this.lblRentalPayLogRecordToDate.TabIndex = 3;
            this.lblRentalPayLogRecordToDate.Text = "по";
            // 
            // lblRentalPayLogRecordFromDate
            // 
            this.lblRentalPayLogRecordFromDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRentalPayLogRecordFromDate.Location = new System.Drawing.Point(3, 16);
            this.lblRentalPayLogRecordFromDate.Name = "lblRentalPayLogRecordFromDate";
            this.lblRentalPayLogRecordFromDate.Size = new System.Drawing.Size(116, 29);
            this.lblRentalPayLogRecordFromDate.TabIndex = 0;
            this.lblRentalPayLogRecordFromDate.Text = "Отображать записи с ";
            // 
            // dprRentalPayLogToTime
            // 
            this.dprRentalPayLogToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dprRentalPayLogToTime.Location = new System.Drawing.Point(6, 139);
            this.dprRentalPayLogToTime.Name = "dprRentalPayLogToTime";
            this.dprRentalPayLogToTime.ShowUpDown = true;
            this.dprRentalPayLogToTime.Size = new System.Drawing.Size(113, 20);
            this.dprRentalPayLogToTime.TabIndex = 5;
            this.toolTip.SetToolTip(this.dprRentalPayLogToTime, "Выбрать время \"по\"");
            this.dprRentalPayLogToTime.ValueChanged += new System.EventHandler(this.dprRentalPayLogToTime_ValueChanged);
            // 
            // dprRentalPayLogToDate
            // 
            this.dprRentalPayLogToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dprRentalPayLogToDate.Location = new System.Drawing.Point(6, 113);
            this.dprRentalPayLogToDate.Name = "dprRentalPayLogToDate";
            this.dprRentalPayLogToDate.Size = new System.Drawing.Size(113, 20);
            this.dprRentalPayLogToDate.TabIndex = 4;
            this.toolTip.SetToolTip(this.dprRentalPayLogToDate, "Выбрать дату \"по\"");
            this.dprRentalPayLogToDate.ValueChanged += new System.EventHandler(this.dprRentalPayLogToDate_ValueChanged);
            // 
            // dprRentalPayLogFromTime
            // 
            this.dprRentalPayLogFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dprRentalPayLogFromTime.Location = new System.Drawing.Point(6, 74);
            this.dprRentalPayLogFromTime.Name = "dprRentalPayLogFromTime";
            this.dprRentalPayLogFromTime.ShowUpDown = true;
            this.dprRentalPayLogFromTime.Size = new System.Drawing.Size(113, 20);
            this.dprRentalPayLogFromTime.TabIndex = 2;
            this.toolTip.SetToolTip(this.dprRentalPayLogFromTime, "Выбрать время \"с\"");
            this.dprRentalPayLogFromTime.ValueChanged += new System.EventHandler(this.dprRentalPayLogFromTime_ValueChanged);
            // 
            // dprRentalPayLogFromDate
            // 
            this.dprRentalPayLogFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dprRentalPayLogFromDate.Location = new System.Drawing.Point(6, 48);
            this.dprRentalPayLogFromDate.Name = "dprRentalPayLogFromDate";
            this.dprRentalPayLogFromDate.Size = new System.Drawing.Size(113, 20);
            this.dprRentalPayLogFromDate.TabIndex = 1;
            this.toolTip.SetToolTip(this.dprRentalPayLogFromDate, "Выбрать дату \"с\"");
            this.dprRentalPayLogFromDate.ValueChanged += new System.EventHandler(this.dprRentalPayLogFromDate_ValueChanged);
            // 
            // tpServicePayLog
            // 
            this.tpServicePayLog.Controls.Add(this.gbServicePaylogActions);
            this.tpServicePayLog.Controls.Add(this.llClearServicePayLogFilter);
            this.tpServicePayLog.Controls.Add(this.gbServicePayLogFilter);
            this.tpServicePayLog.Controls.Add(this.dgvServicePayLog);
            this.tpServicePayLog.Location = new System.Drawing.Point(4, 22);
            this.tpServicePayLog.Name = "tpServicePayLog";
            this.tpServicePayLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpServicePayLog.Size = new System.Drawing.Size(784, 498);
            this.tpServicePayLog.TabIndex = 4;
            this.tpServicePayLog.Text = "Оплата услуг";
            this.tpServicePayLog.UseVisualStyleBackColor = true;
            // 
            // gbServicePaylogActions
            // 
            this.gbServicePaylogActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbServicePaylogActions.Controls.Add(this.btnServicePaymentsListPrint);
            this.gbServicePaylogActions.Controls.Add(this.btnRefreshServicePaylog);
            this.gbServicePaylogActions.Location = new System.Drawing.Point(8, 369);
            this.gbServicePaylogActions.Name = "gbServicePaylogActions";
            this.gbServicePaylogActions.Size = new System.Drawing.Size(125, 118);
            this.gbServicePaylogActions.TabIndex = 4;
            this.gbServicePaylogActions.TabStop = false;
            this.gbServicePaylogActions.Text = "Действия";
            // 
            // btnServicePaymentsListPrint
            // 
            this.btnServicePaymentsListPrint.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.table;
            this.btnServicePaymentsListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicePaymentsListPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnServicePaymentsListPrint.Location = new System.Drawing.Point(6, 47);
            this.btnServicePaymentsListPrint.Name = "btnServicePaymentsListPrint";
            this.btnServicePaymentsListPrint.Size = new System.Drawing.Size(113, 25);
            this.btnServicePaymentsListPrint.TabIndex = 6;
            this.btnServicePaymentsListPrint.Text = "Распечатать";
            this.btnServicePaymentsListPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnServicePaymentsListPrint, "Распечатать таблицу");
            this.btnServicePaymentsListPrint.UseVisualStyleBackColor = true;
            this.btnServicePaymentsListPrint.Click += new System.EventHandler(this.btnServicePaymentsListPrint_Click);
            // 
            // btnRefreshServicePaylog
            // 
            this.btnRefreshServicePaylog.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
            this.btnRefreshServicePaylog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshServicePaylog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshServicePaylog.Location = new System.Drawing.Point(6, 19);
            this.btnRefreshServicePaylog.Name = "btnRefreshServicePaylog";
            this.btnRefreshServicePaylog.Size = new System.Drawing.Size(113, 25);
            this.btnRefreshServicePaylog.TabIndex = 0;
            this.btnRefreshServicePaylog.Text = "Обновить";
            this.btnRefreshServicePaylog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRefreshServicePaylog, "Обновить журнал оплаты услуг");
            this.btnRefreshServicePaylog.UseVisualStyleBackColor = true;
            this.btnRefreshServicePaylog.Click += new System.EventHandler(this.btnRefreshServicePaylog_Click);
            // 
            // llClearServicePayLogFilter
            // 
            this.llClearServicePayLogFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearServicePayLogFilter.Image = ((System.Drawing.Image)(resources.GetObject("llClearServicePayLogFilter.Image")));
            this.llClearServicePayLogFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearServicePayLogFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearServicePayLogFilter.Location = new System.Drawing.Point(117, 5);
            this.llClearServicePayLogFilter.Name = "llClearServicePayLogFilter";
            this.llClearServicePayLogFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearServicePayLogFilter.TabIndex = 1;
            this.toolTip.SetToolTip(this.llClearServicePayLogFilter, "Очистить фильтр");
            this.llClearServicePayLogFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearServicePayLogFilter_MouseClick);
            this.llClearServicePayLogFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseDown);
            this.llClearServicePayLogFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseUp);
            // 
            // gbServicePayLogFilter
            // 
            this.gbServicePayLogFilter.Controls.Add(this.label1);
            this.gbServicePayLogFilter.Controls.Add(this.checkedListBoxServices);
            this.gbServicePayLogFilter.Controls.Add(this.lblServicePayLogRecordToDate);
            this.gbServicePayLogFilter.Controls.Add(this.lblServicePayLogRecordFromDate);
            this.gbServicePayLogFilter.Controls.Add(this.dprServicePayLogToTime);
            this.gbServicePayLogFilter.Controls.Add(this.dprServicePayLogToDate);
            this.gbServicePayLogFilter.Controls.Add(this.dprServicePayLogFromTime);
            this.gbServicePayLogFilter.Controls.Add(this.dprServicePayLogFromDate);
            this.gbServicePayLogFilter.Location = new System.Drawing.Point(8, 25);
            this.gbServicePayLogFilter.Name = "gbServicePayLogFilter";
            this.gbServicePayLogFilter.Size = new System.Drawing.Size(125, 338);
            this.gbServicePayLogFilter.TabIndex = 0;
            this.gbServicePayLogFilter.TabStop = false;
            this.gbServicePayLogFilter.Text = "Фильтр";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Услуги";
            // 
            // checkedListBoxServices
            // 
            this.checkedListBoxServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxServices.CheckOnClick = true;
            this.checkedListBoxServices.FormattingEnabled = true;
            this.checkedListBoxServices.Location = new System.Drawing.Point(5, 185);
            this.checkedListBoxServices.MultiColumn = true;
            this.checkedListBoxServices.Name = "checkedListBoxServices";
            this.checkedListBoxServices.Size = new System.Drawing.Size(114, 139);
            this.checkedListBoxServices.TabIndex = 6;
            this.checkedListBoxServices.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxServices_SelectedIndexChanged);
            // 
            // lblServicePayLogRecordToDate
            // 
            this.lblServicePayLogRecordToDate.AutoSize = true;
            this.lblServicePayLogRecordToDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblServicePayLogRecordToDate.Location = new System.Drawing.Point(6, 97);
            this.lblServicePayLogRecordToDate.Name = "lblServicePayLogRecordToDate";
            this.lblServicePayLogRecordToDate.Size = new System.Drawing.Size(19, 13);
            this.lblServicePayLogRecordToDate.TabIndex = 3;
            this.lblServicePayLogRecordToDate.Text = "по";
            // 
            // lblServicePayLogRecordFromDate
            // 
            this.lblServicePayLogRecordFromDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblServicePayLogRecordFromDate.Location = new System.Drawing.Point(3, 16);
            this.lblServicePayLogRecordFromDate.Name = "lblServicePayLogRecordFromDate";
            this.lblServicePayLogRecordFromDate.Size = new System.Drawing.Size(112, 29);
            this.lblServicePayLogRecordFromDate.TabIndex = 0;
            this.lblServicePayLogRecordFromDate.Text = "Отображать записи с ";
            // 
            // dprServicePayLogToTime
            // 
            this.dprServicePayLogToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dprServicePayLogToTime.Location = new System.Drawing.Point(6, 139);
            this.dprServicePayLogToTime.Name = "dprServicePayLogToTime";
            this.dprServicePayLogToTime.ShowUpDown = true;
            this.dprServicePayLogToTime.Size = new System.Drawing.Size(113, 20);
            this.dprServicePayLogToTime.TabIndex = 5;
            this.toolTip.SetToolTip(this.dprServicePayLogToTime, "Выбрать время \"по\"");
            this.dprServicePayLogToTime.ValueChanged += new System.EventHandler(this.dprServicePayLogToTime_ValueChanged);
            // 
            // dprServicePayLogToDate
            // 
            this.dprServicePayLogToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dprServicePayLogToDate.Location = new System.Drawing.Point(6, 113);
            this.dprServicePayLogToDate.Name = "dprServicePayLogToDate";
            this.dprServicePayLogToDate.Size = new System.Drawing.Size(113, 20);
            this.dprServicePayLogToDate.TabIndex = 4;
            this.toolTip.SetToolTip(this.dprServicePayLogToDate, "Выбрать дату \"по\"");
            this.dprServicePayLogToDate.ValueChanged += new System.EventHandler(this.dprServicePayLogToDate_ValueChanged);
            // 
            // dprServicePayLogFromTime
            // 
            this.dprServicePayLogFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dprServicePayLogFromTime.Location = new System.Drawing.Point(6, 74);
            this.dprServicePayLogFromTime.Name = "dprServicePayLogFromTime";
            this.dprServicePayLogFromTime.ShowUpDown = true;
            this.dprServicePayLogFromTime.Size = new System.Drawing.Size(113, 20);
            this.dprServicePayLogFromTime.TabIndex = 2;
            this.toolTip.SetToolTip(this.dprServicePayLogFromTime, "Выбрать время \"с\"");
            this.dprServicePayLogFromTime.ValueChanged += new System.EventHandler(this.dprServicePayLogFromTime_ValueChanged);
            // 
            // dprServicePayLogFromDate
            // 
            this.dprServicePayLogFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dprServicePayLogFromDate.Location = new System.Drawing.Point(6, 48);
            this.dprServicePayLogFromDate.Name = "dprServicePayLogFromDate";
            this.dprServicePayLogFromDate.Size = new System.Drawing.Size(113, 20);
            this.dprServicePayLogFromDate.TabIndex = 1;
            this.toolTip.SetToolTip(this.dprServicePayLogFromDate, "Выбрать дату \"с\"");
            this.dprServicePayLogFromDate.ValueChanged += new System.EventHandler(this.dprServicePayLogFromDate_ValueChanged);
            // 
            // dgvServicePayLog
            // 
            this.dgvServicePayLog.AllowUserToAddRows = false;
            this.dgvServicePayLog.AllowUserToDeleteRows = false;
            this.dgvServicePayLog.AllowUserToOrderColumns = true;
            this.dgvServicePayLog.AllowUserToResizeRows = false;
            this.dgvServicePayLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicePayLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicePayLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvServicePayLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicePayLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceName,
            this.ServiceDescription,
            this.columnServicePayLogDate,
            this.PlaceNumber,
            this.ServiceTerminal,
            this.columnServiceRate,
            this.columnServicePaidSum,
            this.ServiceStatusMessage});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicePayLog.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvServicePayLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvServicePayLog.Location = new System.Drawing.Point(139, 25);
            this.dgvServicePayLog.MultiSelect = false;
            this.dgvServicePayLog.Name = "dgvServicePayLog";
            this.dgvServicePayLog.ReadOnly = true;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicePayLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvServicePayLog.RowHeadersVisible = false;
            this.dgvServicePayLog.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvServicePayLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicePayLog.Size = new System.Drawing.Size(637, 462);
            this.dgvServicePayLog.TabIndex = 2;
            this.toolTip.SetToolTip(this.dgvServicePayLog, "Оплата услуг");
            this.dgvServicePayLog.Enter += new System.EventHandler(this.dgvServicePayLog_Enter);
            this.dgvServicePayLog.Leave += new System.EventHandler(this.dgvServicePayLog_Leave);
            // 
            // ServiceName
            // 
            this.ServiceName.DataPropertyName = "Name";
            this.ServiceName.FillWeight = 70F;
            this.ServiceName.HeaderText = "Услуга";
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.ReadOnly = true;
            // 
            // ServiceDescription
            // 
            this.ServiceDescription.DataPropertyName = "Description";
            this.ServiceDescription.HeaderText = "Описание";
            this.ServiceDescription.Name = "ServiceDescription";
            this.ServiceDescription.ReadOnly = true;
            // 
            // columnServicePayLogDate
            // 
            this.columnServicePayLogDate.DataPropertyName = "Date";
            this.columnServicePayLogDate.FillWeight = 50F;
            this.columnServicePayLogDate.HeaderText = "Время оплаты";
            this.columnServicePayLogDate.Name = "columnServicePayLogDate";
            this.columnServicePayLogDate.ReadOnly = true;
            // 
            // PlaceNumber
            // 
            this.PlaceNumber.DataPropertyName = "PlaceNumber";
            this.PlaceNumber.FillWeight = 50F;
            this.PlaceNumber.HeaderText = "Место №";
            this.PlaceNumber.Name = "PlaceNumber";
            this.PlaceNumber.ReadOnly = true;
            // 
            // ServiceTerminal
            // 
            this.ServiceTerminal.DataPropertyName = "Terminal";
            this.ServiceTerminal.FillWeight = 50F;
            this.ServiceTerminal.HeaderText = "Терминал";
            this.ServiceTerminal.Name = "ServiceTerminal";
            this.ServiceTerminal.ReadOnly = true;
            // 
            // columnServiceRate
            // 
            this.columnServiceRate.DataPropertyName = "Rate";
            this.columnServiceRate.FillWeight = 50F;
            this.columnServiceRate.HeaderText = "Тариф";
            this.columnServiceRate.Name = "columnServiceRate";
            this.columnServiceRate.ReadOnly = true;
            // 
            // columnServicePaidSum
            // 
            this.columnServicePaidSum.DataPropertyName = "PaidSum";
            this.columnServicePaidSum.FillWeight = 50F;
            this.columnServicePaidSum.HeaderText = "Сумма";
            this.columnServicePaidSum.Name = "columnServicePaidSum";
            this.columnServicePaidSum.ReadOnly = true;
            // 
            // ServiceStatusMessage
            // 
            this.ServiceStatusMessage.DataPropertyName = "StatusMessage";
            this.ServiceStatusMessage.HeaderText = "Результат выгрузки в 1С";
            this.ServiceStatusMessage.Name = "ServiceStatusMessage";
            this.ServiceStatusMessage.ReadOnly = true;
            // 
            // tpCashlessPaymentLog
            // 
            this.tpCashlessPaymentLog.Controls.Add(this.llClearCashlessPaymentFilter);
            this.tpCashlessPaymentLog.Controls.Add(this.dgvCashlessPaymentList);
            this.tpCashlessPaymentLog.Controls.Add(this.gbCashlessPaymentAction);
            this.tpCashlessPaymentLog.Location = new System.Drawing.Point(4, 22);
            this.tpCashlessPaymentLog.Name = "tpCashlessPaymentLog";
            this.tpCashlessPaymentLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpCashlessPaymentLog.Size = new System.Drawing.Size(784, 498);
            this.tpCashlessPaymentLog.TabIndex = 5;
            this.tpCashlessPaymentLog.Text = "Оплата по б/н рассчету";
            this.tpCashlessPaymentLog.UseVisualStyleBackColor = true;
            // 
            // llClearCashlessPaymentFilter
            // 
            this.llClearCashlessPaymentFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearCashlessPaymentFilter.Image = ((System.Drawing.Image)(resources.GetObject("llClearCashlessPaymentFilter.Image")));
            this.llClearCashlessPaymentFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearCashlessPaymentFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearCashlessPaymentFilter.Location = new System.Drawing.Point(117, 5);
            this.llClearCashlessPaymentFilter.Name = "llClearCashlessPaymentFilter";
            this.llClearCashlessPaymentFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearCashlessPaymentFilter.TabIndex = 1;
            this.toolTip.SetToolTip(this.llClearCashlessPaymentFilter, "Очистить фильтр");
            this.llClearCashlessPaymentFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearCashlessPaymentFilter_MouseClick);
            this.llClearCashlessPaymentFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseDown);
            this.llClearCashlessPaymentFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearFilter_MouseUp);
            // 
            // dgvCashlessPaymentList
            // 
            this.dgvCashlessPaymentList.AllowUserToAddRows = false;
            this.dgvCashlessPaymentList.AllowUserToDeleteRows = false;
            this.dgvCashlessPaymentList.AllowUserToOrderColumns = true;
            this.dgvCashlessPaymentList.AllowUserToResizeRows = false;
            this.dgvCashlessPaymentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCashlessPaymentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashlessPaymentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvCashlessPaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashlessPaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.PaidDateFrom,
            this.PaymentPaidDateTo,
            this.PaymentControlDate});
            this.dgvCashlessPaymentList.ContextMenuStrip = this.cmsCashlessPayment;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashlessPaymentList.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgvCashlessPaymentList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCashlessPaymentList.Location = new System.Drawing.Point(139, 25);
            this.dgvCashlessPaymentList.MultiSelect = false;
            this.dgvCashlessPaymentList.Name = "dgvCashlessPaymentList";
            this.dgvCashlessPaymentList.ReadOnly = true;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashlessPaymentList.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvCashlessPaymentList.RowHeadersVisible = false;
            this.dgvCashlessPaymentList.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvCashlessPaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashlessPaymentList.Size = new System.Drawing.Size(637, 462);
            this.dgvCashlessPaymentList.TabIndex = 6;
            this.toolTip.SetToolTip(this.dgvCashlessPaymentList, "Оплата по б/н рассчету");
            this.dgvCashlessPaymentList.Enter += new System.EventHandler(this.dgvCashlessPaymentList_Enter);
            this.dgvCashlessPaymentList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCashlessPaymentList_CellDoubleClick);
            this.dgvCashlessPaymentList.Leave += new System.EventHandler(this.dgvCashlessPaymentList_Leave);
            this.dgvCashlessPaymentList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCashlessPaymentList_KeyDown);
            this.dgvCashlessPaymentList.SelectionChanged += new System.EventHandler(this.dgvCashlessPaymentList_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ContractNumber";
            this.dataGridViewTextBoxColumn3.HeaderText = "№ договора";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // PaidDateFrom
            // 
            this.PaidDateFrom.DataPropertyName = "PaidDateFrom";
            this.PaidDateFrom.HeaderText = "Оплачено с";
            this.PaidDateFrom.Name = "PaidDateFrom";
            this.PaidDateFrom.ReadOnly = true;
            // 
            // PaymentPaidDateTo
            // 
            this.PaymentPaidDateTo.DataPropertyName = "PaidDateTo";
            this.PaymentPaidDateTo.HeaderText = "Оплачено по";
            this.PaymentPaidDateTo.Name = "PaymentPaidDateTo";
            this.PaymentPaidDateTo.ReadOnly = true;
            // 
            // PaymentControlDate
            // 
            this.PaymentControlDate.DataPropertyName = "ControlDate";
            this.PaymentControlDate.HeaderText = "Дата контроля";
            this.PaymentControlDate.Name = "PaymentControlDate";
            this.PaymentControlDate.ReadOnly = true;
            // 
            // cmsCashlessPayment
            // 
            this.cmsCashlessPayment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCashlessPayment_Add,
            this.tsmiCashlessPayment_Edit,
            this.tsmiCashlessPayment_Delete});
            this.cmsCashlessPayment.Name = "cmsCashlessPayment";
            this.cmsCashlessPayment.ShowImageMargin = false;
            this.cmsCashlessPayment.Size = new System.Drawing.Size(130, 70);
            // 
            // tsmiCashlessPayment_Add
            // 
            this.tsmiCashlessPayment_Add.Name = "tsmiCashlessPayment_Add";
            this.tsmiCashlessPayment_Add.Size = new System.Drawing.Size(129, 22);
            this.tsmiCashlessPayment_Add.Text = "Добавить";
            this.tsmiCashlessPayment_Add.Click += new System.EventHandler(this.tsmiCashlessPayment_Add_Click);
            // 
            // tsmiCashlessPayment_Edit
            // 
            this.tsmiCashlessPayment_Edit.Name = "tsmiCashlessPayment_Edit";
            this.tsmiCashlessPayment_Edit.Size = new System.Drawing.Size(129, 22);
            this.tsmiCashlessPayment_Edit.Text = "Редактировать";
            this.tsmiCashlessPayment_Edit.Click += new System.EventHandler(this.tsmiCashlessPayment_Edit_Click);
            // 
            // tsmiCashlessPayment_Delete
            // 
            this.tsmiCashlessPayment_Delete.Name = "tsmiCashlessPayment_Delete";
            this.tsmiCashlessPayment_Delete.Size = new System.Drawing.Size(129, 22);
            this.tsmiCashlessPayment_Delete.Text = "Удалить";
            this.tsmiCashlessPayment_Delete.Click += new System.EventHandler(this.tsmiCashlessPayment_Delete_Click);
            // 
            // gbCashlessPaymentAction
            // 
            this.gbCashlessPaymentAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCashlessPaymentAction.Controls.Add(this.btnCashlessPaymentsListPrint);
            this.gbCashlessPaymentAction.Controls.Add(this.bt_DeleteCashlessPayment);
            this.gbCashlessPaymentAction.Controls.Add(this.btnEditCashlessPayment);
            this.gbCashlessPaymentAction.Controls.Add(this.btnAddCashlessPayment);
            this.gbCashlessPaymentAction.Controls.Add(this.btnRefreshCashlessPayments);
            this.gbCashlessPaymentAction.Location = new System.Drawing.Point(8, 25);
            this.gbCashlessPaymentAction.Name = "gbCashlessPaymentAction";
            this.gbCashlessPaymentAction.Size = new System.Drawing.Size(125, 462);
            this.gbCashlessPaymentAction.TabIndex = 0;
            this.gbCashlessPaymentAction.TabStop = false;
            this.gbCashlessPaymentAction.Text = "Действия";
            // 
            // btnCashlessPaymentsListPrint
            // 
            this.btnCashlessPaymentsListPrint.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.table;
            this.btnCashlessPaymentsListPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCashlessPaymentsListPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCashlessPaymentsListPrint.Location = new System.Drawing.Point(6, 135);
            this.btnCashlessPaymentsListPrint.Name = "btnCashlessPaymentsListPrint";
            this.btnCashlessPaymentsListPrint.Size = new System.Drawing.Size(113, 25);
            this.btnCashlessPaymentsListPrint.TabIndex = 6;
            this.btnCashlessPaymentsListPrint.Text = "Распечатать";
            this.btnCashlessPaymentsListPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnCashlessPaymentsListPrint, "Распечатать таблицу");
            this.btnCashlessPaymentsListPrint.UseVisualStyleBackColor = true;
            this.btnCashlessPaymentsListPrint.Click += new System.EventHandler(this.btnCashlessPaymentsListPrint_Click);
            // 
            // bt_DeleteCashlessPayment
            // 
            this.bt_DeleteCashlessPayment.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
            this.bt_DeleteCashlessPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_DeleteCashlessPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bt_DeleteCashlessPayment.Location = new System.Drawing.Point(6, 77);
            this.bt_DeleteCashlessPayment.Name = "bt_DeleteCashlessPayment";
            this.bt_DeleteCashlessPayment.Size = new System.Drawing.Size(113, 25);
            this.bt_DeleteCashlessPayment.TabIndex = 4;
            this.bt_DeleteCashlessPayment.Text = "Удалить";
            this.bt_DeleteCashlessPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_DeleteCashlessPayment.UseVisualStyleBackColor = true;
            this.bt_DeleteCashlessPayment.Click += new System.EventHandler(this.bt_DeleteCashlessPayment_Click);
            // 
            // btnEditCashlessPayment
            // 
            this.btnEditCashlessPayment.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.edit;
            this.btnEditCashlessPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCashlessPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditCashlessPayment.Location = new System.Drawing.Point(6, 48);
            this.btnEditCashlessPayment.Name = "btnEditCashlessPayment";
            this.btnEditCashlessPayment.Size = new System.Drawing.Size(113, 25);
            this.btnEditCashlessPayment.TabIndex = 3;
            this.btnEditCashlessPayment.Text = "Редактировать";
            this.btnEditCashlessPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditCashlessPayment.UseVisualStyleBackColor = true;
            this.btnEditCashlessPayment.Click += new System.EventHandler(this.btnEditCashlessPayment_Click);
            // 
            // btnAddCashlessPayment
            // 
            this.btnAddCashlessPayment.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
            this.btnAddCashlessPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCashlessPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddCashlessPayment.Location = new System.Drawing.Point(6, 19);
            this.btnAddCashlessPayment.Name = "btnAddCashlessPayment";
            this.btnAddCashlessPayment.Size = new System.Drawing.Size(113, 25);
            this.btnAddCashlessPayment.TabIndex = 2;
            this.btnAddCashlessPayment.Text = "Добавить";
            this.btnAddCashlessPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnAddCashlessPayment, "Нажмите чтобы добавить информацию о безналичном рассчете");
            this.btnAddCashlessPayment.UseVisualStyleBackColor = true;
            this.btnAddCashlessPayment.Click += new System.EventHandler(this.btnAddCashlessPayment_Click);
            // 
            // btnRefreshCashlessPayments
            // 
            this.btnRefreshCashlessPayments.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
            this.btnRefreshCashlessPayments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshCashlessPayments.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshCashlessPayments.Location = new System.Drawing.Point(6, 106);
            this.btnRefreshCashlessPayments.Name = "btnRefreshCashlessPayments";
            this.btnRefreshCashlessPayments.Size = new System.Drawing.Size(113, 25);
            this.btnRefreshCashlessPayments.TabIndex = 5;
            this.btnRefreshCashlessPayments.Text = "Обновить";
            this.btnRefreshCashlessPayments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRefreshCashlessPayments, "Обновить журнал оплаты аренды");
            this.btnRefreshCashlessPayments.UseVisualStyleBackColor = true;
            this.btnRefreshCashlessPayments.Click += new System.EventHandler(this.btnRefreshCashlessPayments_Click);
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataSource = typeof(Arsis.RentalSystem.Core.Domain.Service);
            // 
            // OtherServicesFilterExtender
            // 
            this.OtherServicesFilterExtender.DataGridView = this.dgvOtherServices;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.OtherServicesFilterExtender.FilterFactory = defaultGridFilterFactory1;
            this.OtherServicesFilterExtender.FilterText = "";
            this.OtherServicesFilterExtender.FilterTextVisible = false;
            // 
            // RentalPropertyFilterExtender
            // 
            this.RentalPropertyFilterExtender.DataGridView = this.dgvRentalPlaces;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.RentalPropertyFilterExtender.FilterFactory = defaultGridFilterFactory2;
            this.RentalPropertyFilterExtender.FilterText = "";
            this.RentalPropertyFilterExtender.FilterTextVisible = false;
            // 
            // RentalPayLogFilterExtender
            // 
            this.RentalPayLogFilterExtender.DataGridView = this.dgvRentalPayLog;
            defaultGridFilterFactory3.CreateDistinctGridFilters = false;
            defaultGridFilterFactory3.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory3.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory3.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory3.HandleEnumerationTypes = true;
            defaultGridFilterFactory3.MaximumDistinctValues = 20;
            this.RentalPayLogFilterExtender.FilterFactory = defaultGridFilterFactory3;
            this.RentalPayLogFilterExtender.FilterText = "";
            this.RentalPayLogFilterExtender.FilterTextVisible = false;
            // 
            // ContractFilterExtender
            // 
            this.ContractFilterExtender.DataGridView = this.dgvContracts;
            defaultGridFilterFactory4.CreateDistinctGridFilters = false;
            defaultGridFilterFactory4.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory4.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory4.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory4.HandleEnumerationTypes = true;
            defaultGridFilterFactory4.MaximumDistinctValues = 20;
            this.ContractFilterExtender.FilterFactory = defaultGridFilterFactory4;
            this.ContractFilterExtender.FilterText = "";
            this.ContractFilterExtender.FilterTextVisible = false;
            // 
            // PriceListFilterExtender
            // 
            this.PriceListFilterExtender.DataGridView = this.dgvPriceList;
            defaultGridFilterFactory5.CreateDistinctGridFilters = false;
            defaultGridFilterFactory5.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory5.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory5.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory5.HandleEnumerationTypes = true;
            defaultGridFilterFactory5.MaximumDistinctValues = 20;
            this.PriceListFilterExtender.FilterFactory = defaultGridFilterFactory5;
            this.PriceListFilterExtender.FilterText = "";
            this.PriceListFilterExtender.FilterTextVisible = false;
            // 
            // TerminalsListFilterExtender
            // 
            this.TerminalsListFilterExtender.DataGridView = this.dgvTerminalsList;
            defaultGridFilterFactory6.CreateDistinctGridFilters = false;
            defaultGridFilterFactory6.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory6.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory6.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory6.HandleEnumerationTypes = true;
            defaultGridFilterFactory6.MaximumDistinctValues = 20;
            this.TerminalsListFilterExtender.FilterFactory = defaultGridFilterFactory6;
            this.TerminalsListFilterExtender.FilterText = "";
            this.TerminalsListFilterExtender.FilterTextVisible = false;
            // 
            // terminalListRefreshTimer
            // 
            this.terminalListRefreshTimer.Interval = 60000;
            this.terminalListRefreshTimer.Tick += new System.EventHandler(this.terminalListRefreshTimer_Tick);
            // 
            // ServicePayLogFilterExtender
            // 
            this.ServicePayLogFilterExtender.DataGridView = this.dgvServicePayLog;
            defaultGridFilterFactory7.CreateDistinctGridFilters = false;
            defaultGridFilterFactory7.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory7.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory7.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory7.HandleEnumerationTypes = true;
            defaultGridFilterFactory7.MaximumDistinctValues = 20;
            this.ServicePayLogFilterExtender.FilterFactory = defaultGridFilterFactory7;
            this.ServicePayLogFilterExtender.FilterText = "";
            this.ServicePayLogFilterExtender.FilterTextVisible = false;
            // 
            // CashlessPaymentFilterExtender
            // 
            this.CashlessPaymentFilterExtender.DataGridView = this.dgvCashlessPaymentList;
            defaultGridFilterFactory8.CreateDistinctGridFilters = false;
            defaultGridFilterFactory8.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory8.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory8.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory8.HandleEnumerationTypes = true;
            defaultGridFilterFactory8.MaximumDistinctValues = 20;
            this.CashlessPaymentFilterExtender.FilterFactory = defaultGridFilterFactory8;
            this.CashlessPaymentFilterExtender.FilterText = "";
            this.CashlessPaymentFilterExtender.FilterTextVisible = false;
            // 
            // TerminalId
            // 
            this.TerminalId.DataPropertyName = "Id";
            this.TerminalId.HeaderText = "TerminalId";
            this.TerminalId.Name = "TerminalId";
            this.TerminalId.ReadOnly = true;
            this.TerminalId.Visible = false;
            // 
            // columnTerminalNetworkName
            // 
            this.columnTerminalNetworkName.DataPropertyName = "NetworkName";
            this.columnTerminalNetworkName.HeaderText = "Сетевое имя";
            this.columnTerminalNetworkName.Name = "columnTerminalNetworkName";
            this.columnTerminalNetworkName.ReadOnly = true;
            // 
            // TerminalStatus
            // 
            this.TerminalStatus.DataPropertyName = "Status";
            this.TerminalStatus.HeaderText = "Статус";
            this.TerminalStatus.Name = "TerminalStatus";
            this.TerminalStatus.ReadOnly = true;
            // 
            // TerminalStarted
            // 
            this.TerminalStarted.DataPropertyName = "DateTime";
            this.TerminalStarted.HeaderText = "В текущем состоянии с";
            this.TerminalStarted.Name = "TerminalStarted";
            this.TerminalStarted.ReadOnly = true;
            // 
            // columnTerminalTotalPaidSum
            // 
            this.columnTerminalTotalPaidSum.DataPropertyName = "TotalPaidSum";
            this.columnTerminalTotalPaidSum.HeaderText = "Сумма денежных средств";
            this.columnTerminalTotalPaidSum.Name = "columnTerminalTotalPaidSum";
            this.columnTerminalTotalPaidSum.ReadOnly = true;
            // 
            // columnTerminalRentalPaidSum
            // 
            this.columnTerminalRentalPaidSum.DataPropertyName = "RentalPaidSum";
            this.columnTerminalRentalPaidSum.HeaderText = "Сумма платежей за аренду";
            this.columnTerminalRentalPaidSum.Name = "columnTerminalRentalPaidSum";
            this.columnTerminalRentalPaidSum.ReadOnly = true;
            // 
            // columnTerminalServicePaidSum
            // 
            this.columnTerminalServicePaidSum.DataPropertyName = "ServicePaidSum";
            this.columnTerminalServicePaidSum.HeaderText = "Сумма платежей за услуги";
            this.columnTerminalServicePaidSum.Name = "columnTerminalServicePaidSum";
            this.columnTerminalServicePaidSum.ReadOnly = true;
            // 
            // TerminalShiftNumber
            // 
            this.TerminalShiftNumber.DataPropertyName = "ShiftNumber";
            this.TerminalShiftNumber.HeaderText = "TerminalShiftNumber";
            this.TerminalShiftNumber.Name = "TerminalShiftNumber";
            this.TerminalShiftNumber.ReadOnly = true;
            this.TerminalShiftNumber.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tcTabControl);
            this.Controls.Add(this.ToolsMenu);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Консоль администратора автоматизированной платежной системы";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ToolsMenu.ResumeLayout(false);
            this.ToolsMenu.PerformLayout();
            this.tcTabControl.ResumeLayout(false);
            this.tpServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherServices)).EndInit();
            this.cmsOtherService.ResumeLayout(false);
            this.gbOtherServicesActions.ResumeLayout(false);
            this.tpPriceList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).EndInit();
            this.cmsPriceList.ResumeLayout(false);
            this.gbPriceListActions.ResumeLayout(false);
            this.tpRentalPlaceList.ResumeLayout(false);
            this.gbRentalPropertyActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalPlaces)).EndInit();
            this.cmsRentalProperty.ResumeLayout(false);
            this.tpHolidays.ResumeLayout(false);
            this.gbHolidaysActions.ResumeLayout(false);
            this.pCalendarView.ResumeLayout(false);
            this.tpContracts.ResumeLayout(false);
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.gbContractActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.cmsContract.ResumeLayout(false);
            this.tpTerminalMonitor.ResumeLayout(false);
            this.gbTerminalMonitorActions.ResumeLayout(false);
            this.gbTerminalMonitorActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminalsList)).EndInit();
            this.tpRentalPayLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalPayLog)).EndInit();
            this.gpRentalPayLogActions.ResumeLayout(false);
            this.gbRentalPayLogFilter.ResumeLayout(false);
            this.gbRentalPayLogFilter.PerformLayout();
            this.tpServicePayLog.ResumeLayout(false);
            this.gbServicePaylogActions.ResumeLayout(false);
            this.gbServicePayLogFilter.ResumeLayout(false);
            this.gbServicePayLogFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicePayLog)).EndInit();
            this.tpCashlessPaymentLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashlessPaymentList)).EndInit();
            this.cmsCashlessPayment.ResumeLayout(false);
            this.gbCashlessPaymentAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtherServicesFilterExtender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentalPropertyFilterExtender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentalPayLogFilterExtender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractFilterExtender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceListFilterExtender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerminalsListFilterExtender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicePayLogFilterExtender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashlessPaymentFilterExtender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiRentalPayLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiNotPaidReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaidReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiPivotTableReport;
        private System.Windows.Forms.ToolStrip ToolsMenu;
        private System.Windows.Forms.ToolStripButton tsbRentalPayLog;
        private ToolStripMenuItem tsmiInfo;
        private ToolStripMenuItem tsmiHelp;
        private ToolStripMenuItem tsmiAbout;
        private ToolStripMenuItem tsmiDictionary;
        private ToolStripMenuItem tsmiServices;
        private ToolStripMenuItem tsmiRentalPropertyList;
        private ToolStripMenuItem tsmiNotTransferedPayment;
        private ToolStripButton tsbContractsList;
        private TabControl tcTabControl;
        private TabPage tpServices;
        private TabPage tpRentalPlaceList;
        private TabPage tpRentalPayLog;
        private Button btnInsertOtherService;
        private Button btnEditOtherService;
        private GroupBox gbOtherServicesActions;
        private Button btnDeleteOtherService;
        private GroupBox gbRentalPropertyActions;
        private Button btnDeleteRentalProperty;
        private Button btnInsertRentalProperty;
        private DataGridView dgvRentalPlaces;
        private GridViewExtensions.DataGridFilterExtender OtherServicesFilterExtender;
        private GridViewExtensions.DataGridFilterExtender RentalPropertyFilterExtender;
        private LinkLabel llClearOtherServicesFilter;
        private LinkLabel llClearRentalPropertyFilter;
        private DataGridView dgvRentalPayLog;
        private GroupBox gbRentalPayLogFilter;
        private Label lblRentalPayLogRecordToDate;
        private Label lblRentalPayLogRecordFromDate;
        private DateTimePicker dprRentalPayLogToDate;
        private DateTimePicker dprRentalPayLogFromDate;
        private GroupBox gpRentalPayLogActions;
        private Button btnNotPaidReport;
        private Button btnPaidReport;
        private GridViewExtensions.DataGridFilterExtender RentalPayLogFilterExtender;
        private LinkLabel llClearRentalPayLogFilter;
        private TabPage tpContracts;
        private TabPage tpHolidays;
        private DataGridView dgvOtherServices;
        private GroupBox gbContractActions;
        private Button btnTransferContract;
        private Button btnEditContract;
        private Button btnAddContract;
        private LinkLabel llClearContractFilter;
        private DataGridView dgvContracts;
        private GridViewExtensions.DataGridFilterExtender ContractFilterExtender;
        private Button btnManageRentalProperties;
        private ToolStripButton tsbExport;
        private ToolStripButton tsbImport;
        private ContextMenuStrip cmsOtherService;
        private ToolStripMenuItem tsmiAddOtherService;
        private ToolStripMenuItem tsmiEditOtherService;
        private ToolStripMenuItem tsmiRemoveOtherService;
        private ContextMenuStrip cmsRentalProperty;
        private ToolStripMenuItem tsmiAddRentalProperty;
        private ToolStripMenuItem tsmiRemoveRentalProperty;
        private ContextMenuStrip cmsContract;
        private ToolStripMenuItem tsmiEditContract;
        private ToolStripMenuItem tsmiAddContract;
        private ToolStripMenuItem tsmiTransfer;
        private ToolStripMenuItem tsmiRentalProperties;
        //private DataGridViewTextBoxColumn RentalPropertyNumber;
        private ToolStripMenuItem tsmiUsers;
        private TabPage tpPriceList;
        private DataGridView dgvPriceList;
        private LinkLabel llClearPriceListFilter;
        private GroupBox gbPriceListActions;
        private Button btnDeletePriceListItem;
        private Button btnEditPriceListItem;
        private Button btnAddPriceListItem;
        private GridViewExtensions.DataGridFilterExtender PriceListFilterExtender;
        private ContextMenuStrip cmsPriceList;
        private ToolStripMenuItem tsmiEditPriceListRecord;
        private ToolStripMenuItem csmiAddPriceListRecord;
        private ToolStripMenuItem tsmiRemovePriceListRecord;
        private DataGridViewTextBoxColumn PriceListId;
        private DataGridViewTextBoxColumn columnPriceListServiceName;
        private DataGridViewTextBoxColumn columnPriceListPrice;
        private DataGridViewTextBoxColumn columnPriceListValidFrom;
        private TabPage tpTerminalMonitor;
        private GroupBox gbTerminalMonitorActions;
        private Button btnRefreshTerminalsList;
        private LinkLabel llClearTerminalFilter;
        private DataGridView dgvTerminalsList;
        private GridViewExtensions.DataGridFilterExtender TerminalsListFilterExtender;
        private Timer terminalListRefreshTimer;
        private CheckBox cbxRefreshAutomaticaly;
        private Label lblMinutes;
        private NumericUpDown nudInterval;
        private ToolStripMenuItem tsmiHolidays;
        private ToolStripButton tsbPriceList;
        private GroupBox gbHolidaysActions;
        private Button btnDeleteHoliday;
        private Button btnInsertHoliday;
        private TabPage tpServicePayLog;
        private LinkLabel llClearServicePayLogFilter;
        private DataGridView dgvServicePayLog;
        private GroupBox gbServicePayLogFilter;
        private Label lblServicePayLogRecordToDate;
        private Label lblServicePayLogRecordFromDate;
        private DateTimePicker dprServicePayLogToDate;
        private DateTimePicker dprServicePayLogFromDate;
        private GridViewExtensions.DataGridFilterExtender ServicePayLogFilterExtender;
        private ToolStripButton tsbServicePayLog;
        private GroupBox gbServicePaylogActions;
        private Button btnRefreshServicePaylog;
        private Button btnRefreshContractsList;
        private Button btnRefreshHolidaysList;
        private Button btnRefreshPriceList;
        private Button btnRefreshRentalPaylog;
        private Button btnRefreshRentalPlaceList;
        private Button btnRefreshServicesList;
        private Button btnRentalPlaceUnpaidPeriods;
        private Button btnCloseContract;
        private DataGridViewTextBoxColumn RentalPropertyId;
        private DataGridViewTextBoxColumn columnRentalPlaceNumber;
        private DataGridViewTextBoxColumn RentalPlaceContractNumber;
        private DataGridViewTextBoxColumn columnRentalPlaceDateTo;
        private DataGridViewTextBoxColumn RentalPlaceServiceName;
        private DataGridViewTextBoxColumn columnRentalPlaceRate;
        private ToolTip toolTip;
        private ToolStripMenuItem tsmiContractStateReport;
        private ToolStripMenuItem tsmiServicePayLog;
        private ToolStripMenuItem tsmiPriceList;
        private ToolStripMenuItem tsmiContracts;
        private Button btnContractHistory;
        private ToolStripMenuItem tsmiCloseContract;
        private ToolStripMenuItem tsmiContractHistory;
        private Panel pCalendarView;
        private GroupBox gbStatus;
        private RadioButton rbOpened;
        private RadioButton rbClosed;
        private RadioButton rbAll;
        private DateTimePicker dprRentalPayLogFromTime;
        private DateTimePicker dprRentalPayLogToTime;
        private DateTimePicker dprServicePayLogFromTime;
        private DateTimePicker dprServicePayLogToTime;
        private Label lblStatus;
        private TabPage tpCashlessPaymentLog;
        private LinkLabel llClearCashlessPaymentFilter;
        private DataGridView dgvCashlessPaymentList;
        private GroupBox gbCashlessPaymentAction;
        private Button btnAddCashlessPayment;
        private Button btnRefreshCashlessPayments;
        private GridViewExtensions.DataGridFilterExtender CashlessPaymentFilterExtender;
        private DataGridViewTextBoxColumn RentalPlaceNumber;
        private DataGridViewTextBoxColumn Contract;
        private DataGridViewTextBoxColumn columnRentalPayLogDate;
        private DataGridViewTextBoxColumn RentalTerminal;
        private DataGridViewCheckBoxColumn isPaid;
        private DataGridViewTextBoxColumn columnRentalPropertyRate;
        private DataGridViewTextBoxColumn columnRentalPropertyPaidSum;
        private DataGridViewTextBoxColumn RentalStatusMessage;
        private Button btnEditCashlessPayment;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn PaidDateFrom;
        private DataGridViewTextBoxColumn PaymentPaidDateTo;
        private DataGridViewTextBoxColumn PaymentControlDate;
        private DataGridViewTextBoxColumn ContractId;
        private DataGridViewTextBoxColumn RentalServiceId;
        private DataGridViewTextBoxColumn columnContractNumber;
        private DataGridViewTextBoxColumn columnContractCreationDate;
        private DataGridViewTextBoxColumn ContractCrUserId;
        private DataGridViewTextBoxColumn columnContractDateFrom;
        private DataGridViewTextBoxColumn columnContractDateTo;
        private DataGridViewTextBoxColumn columnContractDissolutionDate;
        private DataGridViewTextBoxColumn ClientName;
        private DataGridViewTextBoxColumn Client1SCode;
        private DataGridViewTextBoxColumn Contract1SCode;
        private DataGridViewTextBoxColumn PassportOutletOrgan;
        private DataGridViewTextBoxColumn ClientAddress;
        private DataGridViewTextBoxColumn ClientPostAddress;
        private DataGridViewTextBoxColumn ClientPhone;
        private DataGridViewTextBoxColumn PassportSeries;
        private DataGridViewTextBoxColumn PassportOutletDate;
        private DataGridViewTextBoxColumn INN;
        private DataGridViewCheckBoxColumn IsCashless;
        private DataGridViewTextBoxColumn columnContractCashlessPaymentControlDate;
        private DataGridViewTextBoxColumn PassportNumber;
        private DataGridViewTextBoxColumn IsJuridicalPerson;
        private DataGridViewTextBoxColumn PlacePrice;
        private DataGridViewTextBoxColumn Service;
        private DataGridViewTextBoxColumn ContractChDateTime;
        private DataGridViewTextBoxColumn ContractChUserId;
        private DataGridViewTextBoxColumn ContractUser;
        private DataGridViewTextBoxColumn ContractUser1;
        private DataGridViewTextBoxColumn ContractStatus;
        private DataGridViewTextBoxColumn ContractStatusDateTime;
        private DataGridViewTextBoxColumn ContractStatusMessage;
        private Button bt_DeleteCashlessPayment;
        private ToolStripMenuItem bt_ReportPaidForServices;
        private ContextMenuStrip cmsCashlessPayment;
        private ToolStripMenuItem tsmiCashlessPayment_Add;
        private ToolStripMenuItem tsmiCashlessPayment_Edit;
        private ToolStripMenuItem tsmiCashlessPayment_Delete;
        private ToolStripMenuItem tsmiCashlessPayment;
        private ToolStripMenuItem tsmiRentalPropertyUnpaidDays;
        private Button bt_ContractView;
        private ToolStripMenuItem tsmi_ContractView;
        private Arsis.RentalSystem.AdministrationConsole.UserControls.DatesViewer datesViewer;
        private Label lblContractsDateTo;
        private Label lblContractsDateFrom;
        private DateTimePicker dprContractsTo;
        private DateTimePicker dprContractsFrom;
        private ToolStripMenuItem toolStripMenuItem_ReportParkingPays;
        private Label label1;
        private BindingSource serviceBindingSource;
        private CheckedListBox checkedListBoxServices;
        private Button btnServicesListPrint;
        private Button btnPriceListPrint;
        private Button btnRentalPlacesPrint;
        private Button btnRentalPaymentsListPrint;
        private Button btnServicePaymentsListPrint;
        private Button btnCashlessPaymentsListPrint;
        private DataGridViewTextBoxColumn OtherServiceId;
        private DataGridViewTextBoxColumn columnServiceName;
        private DataGridViewTextBoxColumn OtherServiceCaption;
        private DataGridViewCheckBoxColumn OtherServiceIsActive;
        private DataGridViewCheckBoxColumn OtherServiceIsRental;
        private DataGridViewCheckBoxColumn IsParkingPerHour;
        private DataGridViewCheckBoxColumn ParkingWithoutTime;
        private DataGridViewCheckBoxColumn IsOtherServices;
        private DataGridViewCheckBoxColumn UsePlaceNumber;
        private DataGridViewTextBoxColumn columnServiceCurrentPrice;
        private DataGridViewTextBoxColumn OneSColumn;
        private DataGridViewImageColumn OtherServicePictureThumbnail;
        private DataGridViewImageColumn OtherServicePicture;
        private DataGridViewTextBoxColumn ServiceName;
        private DataGridViewTextBoxColumn ServiceDescription;
        private DataGridViewTextBoxColumn columnServicePayLogDate;
        private DataGridViewTextBoxColumn PlaceNumber;
        private DataGridViewTextBoxColumn ServiceTerminal;
        private DataGridViewTextBoxColumn columnServiceRate;
        private DataGridViewTextBoxColumn columnServicePaidSum;
        private DataGridViewTextBoxColumn ServiceStatusMessage;
        private DataGridViewTextBoxColumn TerminalId;
        private DataGridViewTextBoxColumn columnTerminalNetworkName;
        private DataGridViewTextBoxColumn TerminalStatus;
        private DataGridViewTextBoxColumn TerminalStarted;
        private DataGridViewTextBoxColumn columnTerminalTotalPaidSum;
        private DataGridViewTextBoxColumn columnTerminalRentalPaidSum;
        private DataGridViewTextBoxColumn columnTerminalServicePaidSum;
        private DataGridViewTextBoxColumn TerminalShiftNumber;
    }
}