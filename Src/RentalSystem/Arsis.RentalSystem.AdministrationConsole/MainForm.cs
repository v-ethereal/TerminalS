using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.AccessRightsUtility;
using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.AdministrationConsole.Dialogs_GUI;
using Arsis.RentalSystem.AdministrationConsole.Properties;
using System.IO;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class MainForm : Form
    {
        #region Constants

        private const string ERROR_MESSAGE = "Ошибка";
        private const string CURRENCY_FORMAT = "C2";
        private const string SHORT_DATE_FORMAT = "d";
        private const int TIME_MULTIPLIFIER = 60000;
        private const string NOTIFICATION_CAPTION = "Внимание";
        private const string CONTRACT_CLOSED_MESSAGE = "Договор закрыт";
        private const string HELP_FILE_PATH = "UserManual.chm";

        #endregion

        #region Fields

        private readonly IServicesService servicesService = AppRuntime.Instance.Container.GetComponent<IServicesService>();
        private readonly IRentalPlaceService rentalPlaceService = AppRuntime.Instance.Container.GetComponent<IRentalPlaceService>();
        private readonly IHolidayDictionaryService holidayDictionaryService = AppRuntime.Instance.Container.GetComponent<IHolidayDictionaryService>();
        private readonly IFeeService feeService = AppRuntime.Instance.Container.GetComponent<IFeeService>();
        private readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();
        private readonly IPriceListService priceListService = AppRuntime.Instance.Container.GetComponent<IPriceListService>();
        private readonly ITerminalService terminalService = AppRuntime.Instance.Container.GetComponent<ITerminalService>();
        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();
        private readonly ISyncService syncService = AppRuntime.Instance.Container.GetComponent<ISyncService>();

        private bool isServiceListFirstSelected = true;
        private bool isRentalPlaceListFirstSelected = true;
        private bool isHolidaysListFirstSelected = true;
        private bool isContractsListFirstSelected = true;
        private bool isRentalPayLogFirstSelected = true;
        private bool isPriceListFirstSelected = true;
        private bool isTerminalListFirstSelected = true;
        private bool isServicePayLogFirstSelected = true;
        private bool isCashlessPaymentLogFirstSelected = true;
        private bool isDataGridViewPrintingShowPreview = false;

        #endregion

        #region Constructors

        public MainForm()
        {
            SplashScreen.SetStatus("Инициализация компонентов...");
            Thread.Sleep(200);

            InitializeComponent();

            //datesViewer Events
            datesViewer.GetHolidaysRequest += datesViewer_GetHolidaysRequest;
            datesViewer.GetHolidayDictionariesRequest += datesViewer_GetHolidayDictionariesRequest;
            datesViewer.SelectionChanged += datesViewer_SelectionChanged;
            datesViewer.DeleteHoliday += btnDeleteHoliday_Click;
            datesViewer.DefaultInitialize();
            //TODO: uncomment in release version
            //syncService.ReplyScan();

            if (columnRentalPropertyRate != null)
            {
                columnRentalPropertyRate.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }
            if (columnTerminalTotalPaidSum != null)
            {
                columnTerminalTotalPaidSum.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }
            if (columnTerminalRentalPaidSum != null)
            {
                columnTerminalRentalPaidSum.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }
            if (columnTerminalServicePaidSum != null)
            {
                columnTerminalServicePaidSum.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }
            if (columnRentalPropertyPaidSum != null)
            {
                columnRentalPropertyPaidSum.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }
            if (columnServiceRate != null)
            {
                columnServiceRate.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }
            if (columnServicePaidSum != null)
            {
                columnServicePaidSum.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }
            if (columnPriceListPrice != null)
            {
                columnPriceListPrice.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }
            if (columnPriceListValidFrom != null)
            {
                columnPriceListValidFrom.DefaultCellStyle.Format = SHORT_DATE_FORMAT;
            }
            if (columnContractCreationDate != null)
            {
                columnContractCreationDate.DefaultCellStyle.Format = SHORT_DATE_FORMAT;
            }
            if (columnContractDateFrom != null)
            {
                columnContractDateFrom.DefaultCellStyle.Format = SHORT_DATE_FORMAT;
            }
            if (columnContractDateTo != null)
            {
                columnContractDateTo.DefaultCellStyle.Format = SHORT_DATE_FORMAT;
            }
            if (columnContractDissolutionDate != null)
            {
                columnContractDissolutionDate.DefaultCellStyle.Format = SHORT_DATE_FORMAT;
            }
            if (columnContractCashlessPaymentControlDate != null)
            {
                columnContractCashlessPaymentControlDate.DefaultCellStyle.Format = SHORT_DATE_FORMAT;
            }
            if (columnRentalPlaceDateTo != null)
            {
                columnRentalPlaceDateTo.DefaultCellStyle.Format = SHORT_DATE_FORMAT;
            }
            if (columnRentalPlaceRate != null)
            {
                columnRentalPlaceRate.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }
            if (columnServiceCurrentPrice != null)
            {
                columnServiceCurrentPrice.DefaultCellStyle.Format = CURRENCY_FORMAT;
            }

            var dt = DateTime.Now;
            dprRentalPayLogFromTime.Value = dt.Date;
            dprRentalPayLogToTime.Value = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);

            dprServicePayLogFromTime.Value = dt.Date;
            dprServicePayLogToTime.Value = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);

            ApplySecurityRestrictions();

            SplashScreen.SetStatus("Инициализация контекста данных...");
            Thread.Sleep(200);

            dgvOtherServices.DataSource = servicesService.GetServices();

            if (columnServiceName != null)
            {
                dgvOtherServices.Sort(dgvOtherServices.Columns[columnServiceName.Name], ListSortDirection.Ascending);
            }

            isDataGridViewPrintingShowPreview = Settings.Default.TablePrintShowPreview;

            SplashScreen.SetStatus("Добро пожаловать!");
            Thread.Sleep(200);
        }

        #endregion

        #region Private Methods

        #region RentalPlaces
        private void RefreshRentalPlaceList()
        {
            RefreshRentalPlaceList(-1);
        }

        private void RefreshRentalPlaceList(int id)
        {
            RentalPlaceInformationExt rentalPlaceInformation = null;
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvRentalPlaces.SelectedRows)
                {
                    rentalPlaceInformation = row.DataBoundItem as RentalPlaceInformationExt;
                    if (rentalPlaceInformation != null)
                    {
                        break;
                    }
                }
            }

            RentalPropertyFilterExtender.DataGridView = null;
            dgvRentalPlaces.DataSource = rentalPlaceService.GetRentalPlaces();
            RentalPropertyFilterExtender.DataGridView = dgvRentalPlaces;
            RentalPropertyFilterExtender.RefreshFilters();
            if (columnRentalPlaceNumber != null)
            {
                dgvRentalPlaces.Sort(dgvRentalPlaces.Columns[columnRentalPlaceNumber.Name], ListSortDirection.Ascending);
            }
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvRentalPlaces.Rows)
                {
                    RentalPlaceInformationExt actual = row.DataBoundItem as RentalPlaceInformationExt;
                    if (rentalPlaceInformation != null
                            && actual != null)
                    {
                        if (rentalPlaceInformation.Id == actual.Id)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvRentalPlaces.Rows)
                {
                    RentalPlaceInformationExt actual = row.DataBoundItem as RentalPlaceInformationExt;
                    if (actual != null)
                    {
                        if (id == actual.Id)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            dgvRentalPlaces.Focus();
        }

        private void dgvRentalPlaces_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRentalPlaces.Rows)
            {
                setDataGridViewColor(row, true);
            }
        }

        private void dgvRentalPlaces_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRentalPlaces.Rows)
            {
                setDataGridViewColor(row, false);
            }
        }

        private void btnInsertRentalProperty_Click(object sender, EventArgs e)
        {
            InsertRentalPlaceRecordForm insertRentalPlaceRecordForm = new InsertRentalPlaceRecordForm();
            if (insertRentalPlaceRecordForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshRentalPlaceList((int)insertRentalPlaceRecordForm.Tag);
            }
        }

        private void DeleteRentalPlace()
        {
            foreach (DataGridViewRow row in dgvRentalPlaces.SelectedRows)
            {
                RentalPlaceInformationExt rentalProperty = row.DataBoundItem as RentalPlaceInformationExt;
                if (rentalProperty != null)
                {
                    if (MessageBox.Show(this, string.Format("Вы действительно хотите удалить место №{0}?", rentalProperty.Number), "Удаление торгового места", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        try
                        {
                            rentalPlaceService.DeleteRentalPlaceRecord(rentalProperty.Id);
                        }
                        catch (RentalSystemException)
                        {
                            MessageBox.Show(
                                    "Невозможно удалить торговое место. Данное торговое место используется в системе.",
                                    ERROR_MESSAGE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                        }
                        RefreshRentalPlaceList();
                    }
                }
                break;
            }

        }

        private void btnDeleteRentalProperty_Click(object sender, EventArgs e)
        {
            DeleteRentalPlace();
        }

        private void llClearRentalPropertyFilter_MouseClick(object sender, MouseEventArgs e)
        {
            RentalPropertyFilterExtender.ClearFilters();
        }

        private void tsmiAddRentalProperty_Click(object sender, EventArgs e)
        {
            InsertRentalPlaceRecordForm insertRentalPlaceRecordForm = new InsertRentalPlaceRecordForm();
            if (insertRentalPlaceRecordForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshRentalPlaceList((int)insertRentalPlaceRecordForm.Tag);
            }
        }

        private void tsmiRemoveRentalProperty_Click(object sender, EventArgs e)
        {
            DeleteRentalPlace();
        }

        private void btnRefreshRentalPlaceList_Click(object sender, EventArgs e)
        {
            RefreshRentalPlaceList();
        }

        private void btnRentalPlaceUnpaidPeriods_Click(object sender, EventArgs e)
        {
            if (!userService.HasRight(UserActions.RentalPlaces_ModifyUnpayablePeriods))
            {
                return;
            }

            foreach (DataGridViewRow row in dgvRentalPlaces.SelectedRows)
            {
                    RentalPlaceInformation rentalProperty = row.DataBoundItem as RentalPlaceInformation;
                    if (rentalProperty != null)
                    {
                        if (!string.IsNullOrEmpty(rentalProperty.ContractNumber)
                            && !string.IsNullOrEmpty(rentalProperty.Number))
                        {
                            UnpayablePeriodsManagementForm unpayablePeriodsManagementForm =
                                new UnpayablePeriodsManagementForm(
                                    contractService.GetContractByNumber(rentalProperty.ContractNumber).Id,
                                    rentalPlaceService.GetRentalPlaceByNumber(rentalProperty.Number).Id);

                            if (unpayablePeriodsManagementForm.ShowDialog(this) == DialogResult.OK)
                            {
                            }
                        }
                    }
                    break;
            }
        }

        private void dgvServices_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 45:
                    {
                        InsertServiceRecordForm insertServiceRecordForm = new InsertServiceRecordForm();
                        if (insertServiceRecordForm.ShowDialog(this) == DialogResult.OK)
                        {
                            RefreshServicesList((int)insertServiceRecordForm.Tag);
                        }
                        break;
                    }
                case 13:
                    {
                        EditService();
                        break;
                    }
                case 46:
                    {
                        DeleteServiceRecord();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            e.Handled = true;
        }

        private void dgvRentalPlaces_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 45:
                    {
                        InsertRentalPlaceRecordForm insertRentalPlaceRecordForm = new InsertRentalPlaceRecordForm();
                        if (insertRentalPlaceRecordForm.ShowDialog(this) == DialogResult.OK)
                        {
                            RefreshRentalPlaceList((int)insertRentalPlaceRecordForm.Tag);
                        }
                        break;
                    }
                case 46:
                    {
                        DeleteRentalPlace();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            e.Handled = true;
        }

        private void tsmiRentalPropertyUnpaidDays_Click(object sender, EventArgs e)
        {
            btnRentalPlaceUnpaidPeriods_Click(sender, e);
        }

        private void dgvRentalPlaces_SelectionChanged(object sender, EventArgs e)
        {
            bool enableButtonHolidays = false;
            bool enableButtonDelete = false;

            foreach (DataGridViewRow row in dgvRentalPlaces.SelectedRows)
            {
                enableButtonDelete = true;
                RentalPlaceInformation rentalProperty = row.DataBoundItem as RentalPlaceInformation;
                if (rentalProperty != null)
                {
                    enableButtonHolidays = (!string.IsNullOrEmpty(rentalProperty.ContractNumber)
                                     && !string.IsNullOrEmpty(rentalProperty.Number));
                }
                break;
            }

            enableControlsByFlag(enableButtonHolidays, btnRentalPlaceUnpaidPeriods, tsmiRentalPropertyUnpaidDays);
            enableControlsByFlag(enableButtonDelete, btnDeleteRentalProperty, tsmiRemoveRentalProperty);
        }

        #endregion

        #region Form

        private void llClearFilter_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is LinkLabel)
            {
                ((LinkLabel)sender).Image = Resources.clearFilter_default;
            }
        }

        private void tsmiServicePayLog_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpServicePayLog);
        }

        private void tsmiCashlessPayment_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpCashlessPaymentLog);
        }

        private void llClearFilter_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is LinkLabel)
            {
                ((LinkLabel)sender).Image = Resources.clearFilter_pressed;
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void tsmiRentalPropertyList_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpRentalPlaceList);
        }

        private void tsmiPayLog_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpRentalPayLog);
        }

        private void tsbRentalPayLog_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpRentalPayLog);
        }

        private void tcTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcTabControl.SelectedTab == tpServices)
            {
                if (isServiceListFirstSelected)
                {
                    RefreshServicesList();
                    isServiceListFirstSelected = false;
                }
            }
            if (tcTabControl.SelectedTab == tpRentalPlaceList)
            {
                if (isRentalPlaceListFirstSelected)
                {
                    RefreshRentalPlaceList();
                    isRentalPlaceListFirstSelected = false;
                }
            }
            if (tcTabControl.SelectedTab == tpHolidays)
            {
                if (isHolidaysListFirstSelected)
                {
                    datesViewer.RefreshList();
                    isHolidaysListFirstSelected = false;
                }
            }
            if (tcTabControl.SelectedTab == tpContracts)
            {
                if (isContractsListFirstSelected)
                {
                    RefreshContractsList();
                    isContractsListFirstSelected = false;
                }
            }
            if (tcTabControl.SelectedTab == tpRentalPayLog)
            {
                if (isRentalPayLogFirstSelected)
                {
                    RefreshRentalPayLog();
                    isRentalPayLogFirstSelected = false;
                }
            }
            if (tcTabControl.SelectedTab == tpPriceList)
            {
                if (isPriceListFirstSelected)
                {
                    RefreshPriceList();
                    isPriceListFirstSelected = false;
                }
            }
            if (tcTabControl.SelectedTab == tpTerminalMonitor)
            {
                if (isTerminalListFirstSelected)
                {
                    RefreshTerminalList();
                    isTerminalListFirstSelected = false;
                }
            }
            if (tcTabControl.SelectedTab == tpServicePayLog)
            {
                checkedListBoxServices.DataSource = null;
                checkedListBoxServices.DataSource = servicesService.GetAllServices().ToList();

                if (isServicePayLogFirstSelected)
                {
                    RefreshServicePayLog();
                    isServicePayLogFirstSelected = false;
                }
            }
            if (tcTabControl.SelectedTab == tpCashlessPaymentLog)
            {
                if (isCashlessPaymentLogFirstSelected)
                {
                    RefreshCashlessPaymentsList();
                    isCashlessPaymentLogFirstSelected = false;
                }
            }
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            syncService.ReplyScan();
        }

        private void tsmiOtherServices_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpServices);
        }

        private void tsmiPriceList_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpPriceList);
        }

        private void tsmiContracts_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpContracts);
        }

        private void tsmiNotPaidReport_Click(object sender, EventArgs e)
        {
            DateCriteriaSelectionForm dateCriteriaSelectionForm = new DateCriteriaSelectionForm(ReportTypes.NotPaidReport);
            dateCriteriaSelectionForm.ShowDialog(this);
        }

        private void tsmiPaidReport_Click(object sender, EventArgs e)
        {
            DateCriteriaSelectionForm dateCriteriaSelectionForm = new DateCriteriaSelectionForm(ReportTypes.PaidReport);
            dateCriteriaSelectionForm.ShowDialog(this);
        }

        private void tsmiNotTransferedPayment_Click(object sender, EventArgs e)
        {
            DateCriteriaSelectionForm dateCriteriaSelectionForm = new DateCriteriaSelectionForm(ReportTypes.NotTransferedPaymentReport);
            dateCriteriaSelectionForm.ShowDialog(this);
        }

        private void tsmiContractStateReport_Click(object sender, EventArgs e)
        {
            CriteriaSelectionForm criteriaSelectionForm = new CriteriaSelectionForm();
            criteriaSelectionForm.ShowDialog(this);
        }

        private void tsmiPivotTableReport_Click(object sender, EventArgs e)
        {
            DateCriteriaSelectionForm dateCriteriaSelectionForm = new DateCriteriaSelectionForm(ReportTypes.PivotTableReport);
            dateCriteriaSelectionForm.ShowDialog(this);
        }

        private void btnNotPaidReport_Click(object sender, EventArgs e)
        {
            DateCriteriaSelectionForm dateCriteriaSelectionForm = new DateCriteriaSelectionForm(ReportTypes.NotPaidReport);
            dateCriteriaSelectionForm.ShowDialog(this);
        }

        private void btnPaidReport_Click(object sender, EventArgs e)
        {
            DateCriteriaSelectionForm dateCriteriaSelectionForm = new DateCriteriaSelectionForm(ReportTypes.PaidReport);
            dateCriteriaSelectionForm.ShowDialog(this);
        }

        private void bt_ReportPaidForServices_Click(object sender, EventArgs e)
        {
            DateCriteriaSelectionForm dateCriteriaSelectionForm = new DateCriteriaSelectionForm(ReportTypes.PaidForServices);
            dateCriteriaSelectionForm.ShowDialog(this);
        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            UserManagementForm userManagementForm = new UserManagementForm();
            userManagementForm.ShowDialog(this);
            
            if(userManagementForm.IsCurrentUserChangedRights)
            {
                ApplySecurityRestrictions();
            }
        }

        private void tsbServicePayLog_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpServicePayLog);
        }

        /// <summary>
        /// Apply's security options for GUI visibility
        /// </summary>
        private void ApplySecurityRestrictions()
        {
            useWaitCursor(true);

            bool isAccountant = userService.IsInRole(Roles.Accountant.ToString());
            bool isAdmin = userService.IsInRole(Roles.SystemAdmin.ToString());

            //Only for accountant
            if (isAccountant)
            {
                //Hide
                if (!isAdmin)
                {
                    if (tcTabControl.Controls.Contains(tpTerminalMonitor))
                    {
                        tcTabControl.Controls.Remove(tpTerminalMonitor);
                    }
                    tsmiUsers.Visible = false;
                }

                //Show
                if (!tcTabControl.Controls.Contains(tpContracts))
                {
                    tcTabControl.TabPages.Insert(4, tpContracts);
                }
                tsmiContracts.Visible = true;
                tsbContractsList.Visible = true;
            }

            //Only for admin
            if (isAdmin)
            {
                //Hide
                if (!isAccountant)
                {
                    if (tcTabControl.Controls.Contains(tpContracts))
                    {
                        tcTabControl.Controls.Remove(tpContracts);
                    }
                    tsmiContracts.Visible = false;
                    tsbContractsList.Visible = false;
                }

                //Show
                if (!tcTabControl.Controls.Contains(tpTerminalMonitor))
                {
                    int keyToInsert = tcTabControl.Controls.Contains(tpContracts) ? 5 : 4;
                    tcTabControl.TabPages.Insert(keyToInsert, tpTerminalMonitor);
                }
                tsmiUsers.Visible = true;
            }

           useWaitCursor(false);
        }

        private Form currentForm;
        private void useWaitCursor(bool isUse)
        {
            if(isUse)
            {
                currentForm = this;
                currentForm.Cursor = Cursors.WaitCursor;
            }
            else
            {
                if(currentForm != null)
                {
                    currentForm.Cursor = Cursors.Default;
                    currentForm = null;
                }
            }
        }

        private void tsmiHolidays_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpHolidays);
        }

        private void tsbContractsList_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpContracts);
        }

        private void tsbPriceList_Click(object sender, EventArgs e)
        {
            tcTabControl.SelectTab(tpPriceList);
        }

        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            if (File.Exists(HELP_FILE_PATH))
            {
                Process process = new Process();
                process.StartInfo.FileName = HELP_FILE_PATH;
                process.Start();
            }
            else
            {
                MessageBox.Show("Файл справки не доступен.\nОбратитесь к администратору системы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            syncService.ReplyScan();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshContractsList();
        }

        private void rbClosed_CheckedChanged(object sender, EventArgs e)
        {
            RefreshContractsList();
        }

        private void rbOpened_CheckedChanged(object sender, EventArgs e)
        {
            RefreshContractsList();
        }

        #endregion

        #region Services

        private void RefreshServicesList()
        {
            RefreshServicesList(-1);
        }

        private void btnInsertOtherService_Click(object sender, EventArgs e)
        {
            InsertServiceRecordForm insertServiceRecordForm = new InsertServiceRecordForm();
            if (insertServiceRecordForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshServicesList((int)insertServiceRecordForm.Tag);
            }
        }

        private void RefreshServicesList(int id)
        {
            ServiceInformation serviceRecord = null;
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvOtherServices.SelectedRows)
                {
                    serviceRecord = row.DataBoundItem as ServiceInformation;
                    if (serviceRecord != null)
                    {
                        break;
                    }
                }
            }
            OtherServicesFilterExtender.DataGridView = null;
            dgvOtherServices.DataSource = servicesService.GetServices();
            OtherServicesFilterExtender.DataGridView = dgvOtherServices;
            OtherServicesFilterExtender.RefreshFilters();
            if (columnServiceName != null)
            {
                dgvOtherServices.Sort(dgvOtherServices.Columns[columnServiceName.Name], ListSortDirection.Ascending);
            }
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvOtherServices.Rows)
                {
                    ServiceInformation actual = row.DataBoundItem as ServiceInformation;
                    if (serviceRecord != null
                            && actual != null)
                    {
                        if (serviceRecord.Id == actual.Id)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvOtherServices.Rows)
                {
                    ServiceInformation actual = row.DataBoundItem as ServiceInformation;
                    if (actual != null)
                    {
                        if (id == actual.Id)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            dgvOtherServices.Focus();
        }

        private void btnEditOtherService_Click(object sender, EventArgs e)
        {
            EditOtherService();
        }

        private void EditOtherService()
        {
            
            foreach (DataGridViewRow row in dgvOtherServices.SelectedRows)
            {
                ServiceInformationExt serviceRecord = row.DataBoundItem as ServiceInformationExt;

                if (serviceRecord != null)
                {
                    EditServiceRecordForm editServiceRecordForm =
                            new EditServiceRecordForm(serviceRecord.Id);
                    if (editServiceRecordForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshServicesList();
                    }
                }
                break;
            }
        }

        private void dgvOtherServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditOtherService();
            }
        }

        private void btnDeleteOtherService_Click(object sender, EventArgs e)
        {
            DeleteServiceRecord();
        }

        private void DeleteServiceRecord()
        {
            foreach (DataGridViewRow row in dgvOtherServices.SelectedRows)
            {
                ServiceInformationExt serviceRecord = row.DataBoundItem as ServiceInformationExt;
                if (serviceRecord != null)
                {
                    if (MessageBox.Show(this, string.Format("Вы действительно хотите удалить услугу '{0}'?", serviceRecord.Name), "Удаление услуги", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        try
                        {
                            servicesService.DeleteServiceRecord(serviceRecord.Id);
                        }
                        catch (RentalSystemException)
                        {
                            MessageBox.Show("Невозможно удалить услугу. Данная услуга используется в системе",
                                            ERROR_MESSAGE,
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                        RefreshServicesList();
                    }
                }
                break;
            }
        }

        private void llClearOtherServicesFilter_MouseClick(object sender, MouseEventArgs e)
        {
            OtherServicesFilterExtender.ClearFilters();
        }

        private void tsmiEditOtherService_Click(object sender, EventArgs e)
        {
            EditOtherService();
        }

        private void tsmiAddOtherService_Click(object sender, EventArgs e)
        {
            InsertServiceRecordForm insertServiceRecordForm = new InsertServiceRecordForm();
            if (insertServiceRecordForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshServicesList((int)insertServiceRecordForm.Tag);
            }
        }

        private void tsmiRemoveOtherService_Click(object sender, EventArgs e)
        {
            DeleteServiceRecord();
        }

        private void btnRefreshServicesList_Click(object sender, EventArgs e)
        {
            dgvOtherServices.AllowUserToResizeRows = false;
            RefreshServicesList();
        }

        private void dgvOtherServices_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOtherServices.Rows)
            {
                setDataGridViewColor(row, true);
            }
        }

        private void dgvOtherServices_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOtherServices.Rows)
            {
                setDataGridViewColor(row, false);
            }
        }

        #endregion

        #region Rental Pay Log

        private void llClearPayLogFilter_MouseClick(object sender, MouseEventArgs e)
        {
            RentalPayLogFilterExtender.ClearFilters();
        }

        private void btnRefreshRentalPaylog_Click(object sender, EventArgs e)
        {
            RefreshRentalPayLog();
        }

        private void RefreshRentalPayLog()
        {
            RentalPayLogRecord payLogRecord = null;

            foreach (DataGridViewRow row in dgvRentalPayLog.SelectedRows)
            {
                payLogRecord = row.DataBoundItem as RentalPayLogRecord;
                if (payLogRecord != null)
                {
                    break;
                }
            }

            RentalPayLogFilterExtender.DataGridView = null;
            DateTime from = new DateTime(dprRentalPayLogFromDate.Value.Year, dprRentalPayLogFromDate.Value.Month, dprRentalPayLogFromDate.Value.Day, dprRentalPayLogFromTime.Value.Hour, dprRentalPayLogFromTime.Value.Minute, dprRentalPayLogFromTime.Value.Second);
            DateTime to = new DateTime(dprRentalPayLogToDate.Value.Year, dprRentalPayLogToDate.Value.Month, dprRentalPayLogToDate.Value.Day, dprRentalPayLogToTime.Value.Hour, dprRentalPayLogToTime.Value.Minute, dprRentalPayLogToTime.Value.Second);
            dgvRentalPayLog.DataSource = feeService.GetPaidRentalFees(from, to);
            RentalPayLogFilterExtender.DataGridView = dgvRentalPayLog;
            RentalPayLogFilterExtender.RefreshFilters();
            if (columnRentalPayLogDate != null)
            {
                dgvRentalPayLog.Sort(dgvRentalPayLog.Columns[columnRentalPayLogDate.Name], ListSortDirection.Descending);
            }
            foreach (DataGridViewRow row in dgvRentalPayLog.Rows)
            {
                RentalPayLogRecord actual = row.DataBoundItem as RentalPayLogRecord;
                if (payLogRecord != null
                        && actual != null)
                {
                    if (payLogRecord.Equals(actual))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }

            dgvRentalPayLog.Focus();
        }

        private void dgvRentalPayLog_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRentalPayLog.Rows)
            {
                setDataGridViewColor(row, true);
            }
        }

        private void dgvRentalPayLog_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRentalPayLog.Rows)
            {
                setDataGridViewColor(row, false);
            }
        }

        #endregion

        #region Holidays

        private void btnDeleteHoliday_Click(object sender, EventArgs e)
        {
            datesViewer.RemoveHoliday().ForEach(date => holidayDictionaryService.DeleteHoliday(date));
            datesViewer.RefreshList();
        }

        private void btnRefreshHolidaysList_Click(object sender, EventArgs e)
        {
            datesViewer.RefreshList();
        }

        private void btnInsertHoliday_Click(object sender, EventArgs e)
        {
            HolidayAddDialogForm addDialog = new HolidayAddDialogForm();

            if(addDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                int addedId = -1;
                addDialog.Dates.ForEach(date => { addedId = holidayDictionaryService.AddHolidayRecord(date); });
                datesViewer.RefreshList(addedId);
            }
        }

        void datesViewer_SelectionChanged(object sender, EventArgs e)
        {
            enableControlsByFlag(e != null ? true : false, btnDeleteHoliday);
        }

        GridViewExtensions.BindingListView<HolidayDictionary> datesViewer_GetHolidayDictionariesRequest()
        {
            return holidayDictionaryService.GetHolidayDictionaries();
        }

        System.Collections.Generic.List<DateTime> datesViewer_GetHolidaysRequest()
        {
            return holidayDictionaryService.GetHolidays();
        }

        #endregion

        #region Contracts

        private void tsmi_ContractView_Click(object sender, EventArgs e)
        {
            viewContract();
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            InsertContractRecordForm insertContractRecordForm = new InsertContractRecordForm();
            if (insertContractRecordForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshContractsList((int)insertContractRecordForm.Tag);
            }
        }

        private void bt_ContractView_Click(object sender, EventArgs e)
        {
            viewContract();
        }

        private void RefreshContractsList()
        {
            RefreshContractsList(-1);
        }

        private void RefreshContractsList(int id)
        {
            Contract contract = null;
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvContracts.SelectedRows)
                {
                    contract = row.DataBoundItem as Contract;
                    if (contract != null)
                    {
                        break;
                    }
                }
            }

            ContractFilterExtender.DataGridView = null;
            ContractState state;
            if (rbAll.Checked)
            {
                state = ContractState.All;
            }
            else if (rbClosed.Checked)
                 {
                    state = ContractState.Closed;
                 }
                 else
                 {
                    state = ContractState.Active;
                 }

            DateTime dateFrom = dprContractsFrom.Value;
            dateFrom = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day);
            DateTime dateTo = dprContractsTo.Value;
            dateTo = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day);

            dgvContracts.DataSource = contractService.GetContracts(state, dateFrom, dateTo);
            ContractFilterExtender.DataGridView = dgvContracts;
            ContractFilterExtender.RefreshFilters();

            if (columnContractNumber != null)
            {
                dgvContracts.Sort(dgvContracts.Columns[columnContractNumber.Name], ListSortDirection.Ascending);
            }

            dgvContractsApplyStyleAndSelected(id == -1 && contract != null ? contract.Id : id);

            dgvContracts.Focus();
        }

        private void dgvContractsApplyStyleAndSelected(int id)
        {
            foreach (DataGridViewRow row in dgvContracts.Rows)
            {
                Contract actual = row.DataBoundItem as Contract;

                if (actual != null)
                {
                    if (id == actual.Id)
                    {
                        row.Selected = true;
                    }

                    if (actual.DissolutionDate != null)
                    {
                        row.DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Italic);
                    }
                }
            }
        }

        private void dgvContracts_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvContracts.Rows)
            {
                setDataGridViewColor(row, true);
            }
        }

        private void dgvContracts_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvContracts.Rows)
            {
                setDataGridViewColor(row, false);
            }
        }

        private void EditService()
        {
            Service service;
            foreach (DataGridViewRow row in dgvOtherServices.SelectedRows)
            {
                service = row.DataBoundItem as Service;
                if (service != null)
                {
                    EditServiceRecordForm editServiceRecordForm = new EditServiceRecordForm(service.Id);
                    if (editServiceRecordForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshServicesList();
                    }
                }
                break;
            }
        }

        private void EditContract()
        {
            Contract contract;
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    if (contract.DissolutionDate != null)
                    {
                        ViewContractRecordForm viewContractRecordForm = new ViewContractRecordForm(contract.Id);
                        viewContractRecordForm.ShowDialog(this);
                    }
                    else
                    {
                        EditContractRecordForm editContractRecordForm = new EditContractRecordForm(contract.Id);
                        if (editContractRecordForm.ShowDialog(this) == DialogResult.OK)
                        {
                            RefreshContractsList();
                        }
                    }
                }
                break;
            }
        }

        private void viewContract()
        {
            Contract contract;
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    ViewContractRecordForm viewContractRecordForm = new ViewContractRecordForm(contract.Id);
                    viewContractRecordForm.ShowDialog(this);
                }
                break;
            }
        }

        private void btnEditContract_Click(object sender, EventArgs e)
        {
            EditContract();
        }

        private void dgvContracts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditContract();
            }
        }

        private void btnManageRentalProperties_Click(object sender, EventArgs e)
        {
            Contract contract;
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    bool isReadOnly = (contract.DissolutionDate != null
                                       && contract.DissolutionDate.GetValueOrDefault().Date <= DateTime.Now.Date);

                    RentalPlacesManagementForm rentalPlacesManagementForm = new RentalPlacesManagementForm(contract.Id, isReadOnly);
                    if (rentalPlacesManagementForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshContractsList();
                    }
                }
                break;
            }
        }

        private void btnTransferContract_Click(object sender, EventArgs e)
        {
            Contract contract;
            TransferRentalPlaceForm transferRentalPlaceForm = new TransferRentalPlaceForm();

            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    transferRentalPlaceForm = new TransferRentalPlaceForm(contract.Id);

                }
                break;
            }
            if (transferRentalPlaceForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshContractsList();
            }
        }

        private void llClearContractFilter_MouseClick(object sender, MouseEventArgs e)
        {
            ContractFilterExtender.ClearFilters();
        }

        private void tsmiEditContract_Click(object sender, EventArgs e)
        {
            EditContract();
        }

        private void tsmiAddContract_Click(object sender, EventArgs e)
        {
            InsertContractRecordForm insertContractRecordForm = new InsertContractRecordForm();
            if (insertContractRecordForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshContractsList((int)insertContractRecordForm.Tag);
            }
        }

        private void tsmiTransfer_Click(object sender, EventArgs e)
        {
            Contract contract;
            TransferRentalPlaceForm transferRentalPlaceForm = new TransferRentalPlaceForm();

            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    transferRentalPlaceForm = new TransferRentalPlaceForm(contract.Id);

                }
                break;
            }
            if (transferRentalPlaceForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshContractsList();
            }
        }

        private void tsmiRentalProperties_Click(object sender, EventArgs e)
        {
            btnManageRentalProperties_Click(sender, e);
        }

        private void btnCloseContract_Click(object sender, EventArgs e)
        {
            Contract contract;
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    if (contract.DissolutionDate != null)
                    {
                        MessageBox.Show(this, CONTRACT_CLOSED_MESSAGE, NOTIFICATION_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                    CloseContractForm closeContractForm = new CloseContractForm(contract.Id);
                    if (closeContractForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshContractsList();
                    }
                }
                break;
            }
        }

        private void tsmiCloseContract_Click(object sender, EventArgs e)
        {
            Contract contract;
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    if (contract.DissolutionDate != null)
                    {
                        MessageBox.Show(this, CONTRACT_CLOSED_MESSAGE, NOTIFICATION_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                    CloseContractForm closeContractForm = new CloseContractForm(contract.Id);
                    if (closeContractForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshContractsList();
                    }
                }
                break;
            }
        }

        private void tsmiContractHistory_Click(object sender, EventArgs e)
        {
            Contract contract;
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    ContractHistoryForm contractHistoryForm = new ContractHistoryForm(contract.Id);
                    contractHistoryForm.ShowDialog(this);
                }
                break;
            }
        }

        private void btnContractHistory_Click(object sender, EventArgs e)
        {
            Contract contract;
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    ContractHistoryForm contractHistoryForm = new ContractHistoryForm(contract.Id);
                    contractHistoryForm.ShowDialog(this);
                }
                break;
            }
        }

        private void btnRefreshContractsList_Click(object sender, EventArgs e)
        {
            RefreshContractsList();
        }

        private void dgvContracts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 45:
                    {
                        InsertContractRecordForm insertContractRecordForm = new InsertContractRecordForm();
                        if (insertContractRecordForm.ShowDialog(this) == DialogResult.OK)
                        {
                            RefreshContractsList((int)insertContractRecordForm.Tag);
                        }
                        break;
                    }
                case 13:
                    {
                        EditContract();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            e.Handled = true;
        }

        private void dgvContracts_SelectionChanged(object sender, EventArgs e)
        {
            bool enableButton = false;
            bool enableViewButton = dgvContracts.SelectedRows.Count > 0;

            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                Contract contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    enableButton = (contract.DissolutionDate == null);
                }
                break;
            }

            enableControlsByFlag(enableButton,
                                 btnTransferContract,
                                 btnCloseContract,
                                 btnEditContract,
                                 tsmiTransfer,
                                 tsmiCloseContract,
                                 tsmiEditContract);

            enableControlsByFlag(enableViewButton, bt_ContractView, tsmi_ContractView);
        }

        private void dgvContracts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvContractsApplyStyleAndSelected(-1);
        }


        private void dprContractsFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dprContractsFrom.Value > dprContractsTo.Value)
            {
                dprContractsTo.Value = dprContractsFrom.Value;
            }
        }

        private void dprContractsTo_ValueChanged(object sender, EventArgs e)
        {
            if (dprContractsTo.Value < dprContractsFrom.Value)
            {
                dprContractsFrom.Value = dprContractsTo.Value;
            }
        }

        private void dprRentalPayLogFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dprRentalPayLogFromDate.Value > dprRentalPayLogToDate.Value)
            {
                dprRentalPayLogToDate.Value = dprRentalPayLogFromDate.Value;
            }
            if (dprRentalPayLogFromDate.Value == dprRentalPayLogToDate.Value && dprRentalPayLogFromTime.Value > dprRentalPayLogToTime.Value)
            {
                dprRentalPayLogToTime.Value = dprRentalPayLogFromTime.Value;
            }
        }

        private void dprRentalPayLogToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dprRentalPayLogToDate.Value < dprRentalPayLogFromDate.Value)
            {
                dprRentalPayLogFromDate.Value = dprRentalPayLogToDate.Value;
            }
            if (dprRentalPayLogFromDate.Value == dprRentalPayLogToDate.Value && dprRentalPayLogToTime.Value < dprRentalPayLogFromTime.Value)
            {
                dprRentalPayLogFromTime.Value = dprRentalPayLogToTime.Value;
            }
        }

        private void dprRentalPayLogFromTime_ValueChanged(object sender, EventArgs e)
        {
            if (dprRentalPayLogFromDate.Value == dprRentalPayLogToDate.Value && dprRentalPayLogFromTime.Value > dprRentalPayLogToTime.Value)
            {
                dprRentalPayLogToTime.Value = dprRentalPayLogFromTime.Value;
            }
        }

        private void dprRentalPayLogToTime_ValueChanged(object sender, EventArgs e)
        {
            if (dprRentalPayLogFromDate.Value == dprRentalPayLogToDate.Value && dprRentalPayLogToTime.Value < dprRentalPayLogFromTime.Value)
            {
                dprRentalPayLogFromTime.Value = dprRentalPayLogToTime.Value;
            }
        }

        private void dprServicePayLogFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dprServicePayLogFromDate.Value > dprServicePayLogToDate.Value)
            {
                dprServicePayLogToDate.Value = dprServicePayLogFromDate.Value;
            }
            if (dprServicePayLogFromDate.Value == dprServicePayLogToDate.Value && dprServicePayLogFromTime.Value > dprServicePayLogToTime.Value)
            {
                dprServicePayLogToTime.Value = dprServicePayLogFromTime.Value;
            }
        }

        private void dprServicePayLogToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dprServicePayLogToDate.Value < dprServicePayLogFromDate.Value)
            {
                dprServicePayLogFromDate.Value = dprServicePayLogToDate.Value;
            }
            if (dprServicePayLogFromDate.Value == dprServicePayLogToDate.Value && dprServicePayLogToTime.Value < dprServicePayLogFromTime.Value)
            {
                dprServicePayLogFromTime.Value = dprServicePayLogToTime.Value;
            }
        }

        private void dprServicePayLogFromTime_ValueChanged(object sender, EventArgs e)
        {
            if (dprServicePayLogFromDate.Value == dprServicePayLogToDate.Value && dprServicePayLogFromTime.Value > dprServicePayLogToTime.Value)
            {
                dprServicePayLogToTime.Value = dprServicePayLogFromTime.Value;
            }
        }

        private void dprServicePayLogToTime_ValueChanged(object sender, EventArgs e)
        {
            if (dprServicePayLogFromDate.Value == dprServicePayLogToDate.Value && dprServicePayLogToTime.Value < dprServicePayLogFromTime.Value)
            {
                dprServicePayLogFromTime.Value = dprServicePayLogToTime.Value;
            }
        }

        #endregion

        #region Price List

        private void EditPriceListItem()
        {
            PriceListRecord priceList;
            foreach (DataGridViewRow row in dgvPriceList.SelectedRows)
            {
                priceList = row.DataBoundItem as PriceListRecord;
                if (priceList != null)
                {
                    EditPriceListRecordForm editPriceListRecordForm = new EditPriceListRecordForm(priceList.Id);
                    if (editPriceListRecordForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshPriceList();
                    }
                }
                break;
            }
        }

        private void btnEditPriceListItem_Click(object sender, EventArgs e)
        {
            EditPriceListItem();
        }

        private void RefreshPriceList()
        {
            RefreshPriceList(-1);
        }

        private void RefreshPriceList(int id)
        {
            PriceListRecord priceList = null;
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvPriceList.SelectedRows)
                {
                    priceList = row.DataBoundItem as PriceListRecord;
                    if (priceList != null)
                    {
                        break;
                    }
                }
            }
            PriceListFilterExtender.DataGridView = null;
            dgvPriceList.DataSource = priceListService.GetPriceLists();
            PriceListFilterExtender.DataGridView = dgvPriceList;
            PriceListFilterExtender.RefreshFilters();
            if (columnPriceListServiceName != null)
            {
                dgvPriceList.Sort(dgvPriceList.Columns[columnPriceListServiceName.Name], ListSortDirection.Ascending);
            }
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvPriceList.Rows)
                {
                    PriceListRecord actual = row.DataBoundItem as PriceListRecord;
                    if (priceList != null
                            && actual != null)
                    {
                        if (priceList.Id == actual.Id)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvPriceList.Rows)
                {
                    PriceListRecord actual = row.DataBoundItem as PriceListRecord;
                    if (actual != null)
                    {
                        if (id == actual.Id)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            dgvPriceList.Focus();
        }

        private void dgvPriceList_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPriceList.Rows)
            {
                setDataGridViewColor(row, true);
            }
        }

        private void dgvPriceList_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPriceList.Rows)
            {
                setDataGridViewColor(row, false);
            }
        }

        private void tsmiEditPriceListRecord_Click(object sender, EventArgs e)
        {
            EditPriceListItem();
        }

        private void dgvPriceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditPriceListItem();
            }
        }

        private void csmiAddPriceListRecord_Click(object sender, EventArgs e)
        {
            InsertPriceListRecordForm insertPriceListRecordForm = new InsertPriceListRecordForm();
            if (insertPriceListRecordForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshPriceList((int)insertPriceListRecordForm.Tag);
            }
        }

        private void btnAddPriceListItem_Click(object sender, EventArgs e)
        {
            InsertPriceListRecordForm insertPriceListRecordForm = new InsertPriceListRecordForm();
            if (insertPriceListRecordForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshPriceList((int)insertPriceListRecordForm.Tag);
            }
        }

        private void DeletePriceListRecord()
        {
            foreach (DataGridViewRow row in dgvPriceList.SelectedRows)
            {
                PriceListRecord priceList = row.DataBoundItem as PriceListRecord;
                if (priceList != null)
                {
                    if (
                            MessageBox.Show(this,
                                            string.Format("Вы действительно хотите удалить позицию прайс-листа для услуги '{0}'?", priceList.ServiceName),
                                            "Удаление позиции прайс листа",
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        try
                        {
                            priceListService.DeletePriceListRecord(priceList.Id);
                        }
                        catch (RentalSystemException)
                        {
                            MessageBox.Show(
                                    "Невозможно удалить позицию прайс-листа. Данная позиция используется в системе.",
                                    ERROR_MESSAGE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                        }
                        RefreshPriceList();
                    }
                }
                break;
            }
        }

        private void btnDeletePriceListItem_Click(object sender, EventArgs e)
        {
            DeletePriceListRecord();
        }

        private void tsmiRemovePriceListRecord_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPriceList.SelectedRows)
            {
                PriceListRecord priceList = row.DataBoundItem as PriceListRecord;
                if (priceList != null)
                {
                    priceListService.DeletePriceListRecord(priceList.Id);
                    RefreshPriceList();
                }
                break;
            }
        }

        private void llClearPriceListFilter_MouseClick(object sender, MouseEventArgs e)
        {
            PriceListFilterExtender.ClearFilters();
        }

        private void btnRefreshPriceList_Click(object sender, EventArgs e)
        {
            RefreshPriceList();
        }

        private void dgvPriceList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 45:
                    {
                        InsertPriceListRecordForm insertPriceListRecordForm = new InsertPriceListRecordForm();
                        if (insertPriceListRecordForm.ShowDialog(this) == DialogResult.OK)
                        {
                            RefreshPriceList((int)insertPriceListRecordForm.Tag);
                        }
                        break;
                    }
                case 46:
                    {
                        DeletePriceListRecord();
                        break;
                    }
                case 13:
                    {
                        EditPriceListItem();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            e.Handled = true;
        }

        private void dgvPriceList_SelectionChanged(object sender, EventArgs e)
        {
            bool isEnabled = false;

            if (dgvPriceList.SelectedRows.Count > 0)
            {
                isEnabled = true;
            }

            enableControlsByFlag(isEnabled,
                                 btnEditPriceListItem,
                                 btnDeletePriceListItem,
                                 tsmiEditPriceListRecord,
                                 tsmiRemovePriceListRecord);
        }

        #endregion

        #region Terminal List

        private void RefreshTerminalList()
        {
            TerminalInformation terminalInformation = null;
            foreach (DataGridViewRow row in dgvTerminalsList.SelectedRows)
            {
                terminalInformation = row.DataBoundItem as TerminalInformation;
                if (terminalInformation != null)
                {
                    break;
                }
            }
            TerminalsListFilterExtender.DataGridView = null;
            dgvTerminalsList.DataSource = terminalService.GetTerminals();
            TerminalsListFilterExtender.DataGridView = dgvTerminalsList;
            TerminalsListFilterExtender.RefreshFilters();
            if (columnTerminalNetworkName != null)
            {
                dgvTerminalsList.Sort(dgvTerminalsList.Columns[columnTerminalNetworkName.Name], ListSortDirection.Ascending);
            }
            foreach (DataGridViewRow row in dgvTerminalsList.Rows)
            {
                TerminalInformation actual = row.DataBoundItem as TerminalInformation;
                if (terminalInformation != null
                    && actual != null)
                {
                    if (terminalInformation.Id == actual.Id)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void dgvTerminalsList_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTerminalsList.Rows)
            {
                setDataGridViewColor(row, true);
            }
        }

        private void dgvTerminalsList_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTerminalsList.Rows)
            {
                setDataGridViewColor(row, false);
            }
        }

        private void btnRefreshTerminalsList_Click(object sender, EventArgs e)
        {
            RefreshTerminalList();
        }

        private void llClearTerminalFilter_MouseClick(object sender, MouseEventArgs e)
        {
            TerminalsListFilterExtender.ClearFilters();
        }

        private void cbxRefreshAutomaticaly_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRefreshAutomaticaly.Checked)
            {
                nudInterval.Visible = true;
                lblMinutes.Visible = true;
                terminalListRefreshTimer.Start();
            }
            else
            {
                nudInterval.Visible = false;
                lblMinutes.Visible = false;
                terminalListRefreshTimer.Stop();
            }

        }

        private void terminalListRefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshTerminalList();
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            terminalListRefreshTimer.Interval = decimal.ToInt32(nudInterval.Value * TIME_MULTIPLIFIER);
        }

        #endregion

        #region Service Pay Log

        private void RefreshServicePayLog()
        {
            ServicePayLogRecord servicePayLogRecord = null;
            foreach (DataGridViewRow row in dgvServicePayLog.SelectedRows)
            {
                servicePayLogRecord = row.DataBoundItem as ServicePayLogRecord;
                if (servicePayLogRecord != null)
                {
                    break;
                }
            }
            ServicePayLogFilterExtender.DataGridView = null;
            DateTime from = new DateTime(dprServicePayLogFromDate.Value.Year, dprServicePayLogFromDate.Value.Month, dprServicePayLogFromDate.Value.Day, dprServicePayLogFromTime.Value.Hour, dprServicePayLogFromTime.Value.Minute, dprServicePayLogFromTime.Value.Second);
            DateTime to = new DateTime(dprServicePayLogToDate.Value.Year, dprServicePayLogToDate.Value.Month, dprServicePayLogToDate.Value.Day, dprServicePayLogToTime.Value.Hour, dprServicePayLogToTime.Value.Minute, dprServicePayLogToTime.Value.Second);

            int[] serviceIdArr = checkedListBoxServices.CheckedItems.Cast<ServiceInformation>().Select(item => item.Id).ToArray();

            if (serviceIdArr.Length == 0)
            {
                dgvServicePayLog.DataSource = feeService.GetServiceFees(from, to);
            }
            else
            {
                dgvServicePayLog.DataSource = feeService.GetServiceFeesExt(from, to, serviceIdArr);
            }

            ServicePayLogFilterExtender.DataGridView = dgvServicePayLog;
            ServicePayLogFilterExtender.RefreshFilters();

            if (columnServicePayLogDate != null)
            {
                dgvServicePayLog.Sort(dgvServicePayLog.Columns[columnServicePayLogDate.Name], ListSortDirection.Descending);
            }
            foreach (DataGridViewRow row in dgvServicePayLog.Rows)
            {
                ServicePayLogRecord actual = row.DataBoundItem as ServicePayLogRecord;
                if (servicePayLogRecord != null
                    && actual != null)
                {
                    if (servicePayLogRecord.Date == actual.Date
                        && servicePayLogRecord.Name == actual.Name
                        && servicePayLogRecord.PaidSum == actual.PaidSum
                        && servicePayLogRecord.Rate == actual.Rate)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            dgvServicePayLog.Focus();
        }

        private void dgvServicePayLog_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvServicePayLog.Rows)
            {
                setDataGridViewColor(row, true);
            }
        }

        private void dgvServicePayLog_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvServicePayLog.Rows)
            {
                setDataGridViewColor(row, false);
            }
        }

        private void llClearServicePayLogFilter_MouseClick(object sender, MouseEventArgs e)
        {
            ServicePayLogFilterExtender.ClearFilters();
        }

        private void btnRefreshServicePaylog_Click(object sender, EventArgs e)
        {
            RefreshServicePayLog();
        }

        private void dgvOtherServices_SelectionChanged(object sender, EventArgs e)
        {
            bool isEnabled = false;

            if(dgvOtherServices.SelectedRows.Count > 0)
            {
                isEnabled = true;
            }

            enableControlsByFlag(isEnabled, 
                                 btnEditOtherService, 
                                 btnDeleteOtherService, 
                                 tsmiEditOtherService,
                                 tsmiRemoveOtherService);
        }

        #endregion

        #region Cashless Payments

        private void tsmiCashlessPayment_Add_Click(object sender, EventArgs e)
        {
            btnAddCashlessPayment_Click(sender, e);
        }

        private void tsmiCashlessPayment_Edit_Click(object sender, EventArgs e)
        {
            btnEditCashlessPayment_Click(sender, e);
        }

        private void tsmiCashlessPayment_Delete_Click(object sender, EventArgs e)
        {
            bt_DeleteCashlessPayment_Click(sender, e);
        }

        private void llClearCashlessPaymentFilter_MouseClick(object sender, MouseEventArgs e)
        {
            CashlessPaymentFilterExtender.ClearFilters();
        }

        private void RefreshCashlessPaymentsList()
        {
            RefreshCashlessPaymentsList(-1);
        }

        private void RefreshCashlessPaymentsList(int id)
        {
            CashlessPayLogRecord priceList = null;
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvCashlessPaymentList.SelectedRows)
                {
                    priceList = row.DataBoundItem as CashlessPayLogRecord;
                    if (priceList != null)
                    {
                        break;
                    }
                }
            }

            CashlessPaymentFilterExtender.DataGridView = null;
            dgvCashlessPaymentList.DataSource = feeService.GetRentalCashlessPayments();
            CashlessPaymentFilterExtender.DataGridView = dgvCashlessPaymentList;
            CashlessPaymentFilterExtender.RefreshFilters();

            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvCashlessPaymentList.Rows)
                {
                    CashlessPayLogRecord actual = row.DataBoundItem as CashlessPayLogRecord;
                    if (priceList != null
                            && actual != null)
                    {
                        if (priceList.Id == actual.Id)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                DataGridViewRow dgvRow = findInCashlessDgvRowById(id);

                if(dgvRow != null)
                {
                    dgvRow.Selected = true;
                }
            }
            dgvCashlessPaymentList.Focus();
        }

        private DataGridViewRow findInCashlessDgvRowById(int searchId)
        {
            foreach (DataGridViewRow row in dgvCashlessPaymentList.Rows)
            {
                CashlessPayLogRecord actual = row.DataBoundItem as CashlessPayLogRecord;
                if (actual != null)
                {
                    if (searchId == actual.Id)
                    {
                        return row;
                    }
                }
            }

            return null;
        }

        private void EditCashlessRentalPayLogRecord()
        {
            CashlessPayLogRecord payLogRecord;
            foreach (DataGridViewRow row in dgvCashlessPaymentList.SelectedRows)
            {
                payLogRecord = row.DataBoundItem as CashlessPayLogRecord;
                if (payLogRecord != null)
                {
                    EditCashlessPaymentForm editCashlessPaymentForm = new EditCashlessPaymentForm(payLogRecord.Id);
                    if (editCashlessPaymentForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshCashlessPaymentsList();
                    }
                }
                break;
            }
        }

        private void AddCashlessRentalPayLogRecord()
        {
            InsertCashlessPaymentForm insertCashlessPaymentForm = new InsertCashlessPaymentForm();
            if (insertCashlessPaymentForm.ShowDialog(this) == DialogResult.OK)
            {
                if (insertCashlessPaymentForm.Tag != null)
                {
                    RefreshCashlessPaymentsList((int)insertCashlessPaymentForm.Tag);
                }
            }
        }

        private void deleteCashlessRentaPayLogRecord()
        {
            if (dgvCashlessPaymentList.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(this, "Вы действительно хотите удалить оплату?", "Удаление оплаты", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
            }

            int previousRecordId = -1;
            CashlessPayLogRecord payLogRecord;
            foreach (DataGridViewRow row in dgvCashlessPaymentList.SelectedRows)
            {
                payLogRecord = row.DataBoundItem as CashlessPayLogRecord;

                if(row.Index > 0)
                {
                    previousRecordId =
                        ((dgvCashlessPaymentList.Rows[row.Index - 1].DataBoundItem) as CashlessPayLogRecord).Id;
                }

                if (payLogRecord != null)
                {
                    feeService.DeleteRentalFeeRecord(payLogRecord.Id);
                }
            }

            RefreshCashlessPaymentsList(previousRecordId);
        }

        private void btnRefreshCashlessPayments_Click(object sender, EventArgs e)
        {
            RefreshCashlessPaymentsList();
        }

        private void btnAddCashlessPayment_Click(object sender, EventArgs e)
        {
            AddCashlessRentalPayLogRecord();
        }

        private void btnEditCashlessPayment_Click(object sender, EventArgs e)
        {
            EditCashlessRentalPayLogRecord();
        }

        private void bt_DeleteCashlessPayment_Click(object sender, EventArgs e)
        {
            deleteCashlessRentaPayLogRecord();
        }

        private void dgvCashlessPaymentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditCashlessRentalPayLogRecord();
            }
        }

        private void dgvCashlessPaymentList_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCashlessPaymentList.Rows)
            {
                setDataGridViewColor(row, true);
            }
        }

        private void dgvCashlessPaymentList_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCashlessPaymentList.Rows)
            {
                setDataGridViewColor(row, false);
            }
        }

        private void dgvCashlessPaymentList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 45:
                    {
                        AddCashlessRentalPayLogRecord();
                        break;
                    }
                case 13:
                    {
                        EditCashlessRentalPayLogRecord();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            e.Handled = true;
        }

        private void dgvCashlessPaymentList_SelectionChanged(object sender, EventArgs e)
        {
            enableControlsByFlag((dgvCashlessPaymentList.SelectedRows.Count > 0),
                                 btnEditCashlessPayment,
                                 bt_DeleteCashlessPayment,
                                 tsmiCashlessPayment_Edit,
                                 tsmiCashlessPayment_Delete);
        }

        #endregion

        #region CommonTools
        private static void setDataGridViewColor(DataGridViewRow row, bool isOnEnter)
        {
            if (isOnEnter)
            {
                if (row.Selected)
                {
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = Color.Empty;
                    row.DefaultCellStyle.SelectionForeColor = Color.Empty;
                }
            }
            else
            {
                if (row.Selected)
                {
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    //row.DefaultCellStyle.SelectionForeColor = SystemColors.InfoText;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
            }
        }

        private static void enableControlsByFlag(bool isEnable, params object[] controls)
        {
            foreach (var control in controls)
            {
                if (control is Control)
                {
                    ((Control)control).Enabled = isEnable;
                }
                else if (control is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)control).Enabled = isEnable;
                }
            }
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход из приложения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        #endregion

		private void toolStripMenuItem_ReportParkingPays_Click(object sender, EventArgs e)
		{
			DateCriteriaSelectionForm dateCriteriaSelectionForm = new DateCriteriaSelectionForm(ReportTypes.ParkingPaysReport);
			dateCriteriaSelectionForm.ShowDialog(this);
		}

        private void checkedListBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var info = checkedListBoxServices.SelectedItem as ServiceInformation;
            if (info == null) return;

            toolTip.SetToolTip(checkedListBoxServices, info.Name);
        }

        private void checkedListBoxServices_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void btnServicesListPrint_Click(object sender, EventArgs e)
        {
            DataGridViewPrinting.Instance.Print("Список услуг", dgvOtherServices, isDataGridViewPrintingShowPreview);
        }

        private void btnPriceListPrint_Click(object sender, EventArgs e)
        {
            DataGridViewPrinting.Instance.Print("Прайс-лист", dgvPriceList, isDataGridViewPrintingShowPreview);
        }

        private void btnRentalPlacesPrint_Click(object sender, EventArgs e)
        {
            DataGridViewPrinting.Instance.Print("Список торговых мест", dgvRentalPlaces, isDataGridViewPrintingShowPreview);
        }

        private void btnRentalPaymentsListPrint_Click(object sender, EventArgs e)
        {
            DataGridViewPrinting.Instance.Print("Список платежей за аренду", dgvRentalPayLog, isDataGridViewPrintingShowPreview);
        }

        private void btnServicePaymentsListPrint_Click(object sender, EventArgs e)
        {
            DataGridViewPrinting.Instance.Print("Список платежей за прочие услуги", dgvServicePayLog, isDataGridViewPrintingShowPreview);
        }

        private void btnCashlessPaymentsListPrint_Click(object sender, EventArgs e)
        {
            DataGridViewPrinting.Instance.Print("Список безналичных платежей за аренду", dgvCashlessPaymentList, isDataGridViewPrintingShowPreview);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SplashScreen.CloseForm();
            WindowState = FormWindowState.Maximized;
        }
    }
}