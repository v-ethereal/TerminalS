using System;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class ViewContractRecordForm : Form
    {
        #region Constants

        const string CAPTION = "Экспорт в 1С";
        const string TEXT = "Хотите ли вы, чтобы договор был экспортирован в 1С?";

        #endregion

        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();
        private readonly Contract contract;
        private readonly bool isAlreadyExported;
        private readonly bool isCashless;

        #endregion

        #region Constructors

        public ViewContractRecordForm()
        {
            InitializeComponent();
        }

        public ViewContractRecordForm(int id)
        {
            InitializeComponent();
            contract = contractService.GetContract(id);
            tbxContractNumber.Text = contract.ContractNumber;
            tbxExpirationDateFrom.Text = contract.DateFrom.ToString();
            tbxExpirationDateTo.Text = contract.DateTo.ToString();

            isCashless = contract.IsCashless;
            if (contract.IsCashless)
            {
                tbxPayDate.Text = contract.CashlessPaymentControlDate.ToString();
                lblPayDate.Visible = true;
                tbxPayDate.Visible = true;
            }
            else
            {
                lblPayDate.Visible = false;
                tbxPayDate.Visible = false;
            }
            tbxClient1SCode.Text = contract.Client1SCode;
            tbxClientAddress.Text = contract.ClientAddress;
            tbxContractorName.Text = contract.ClientName;
            tbxClientPhone.Text = contract.ClientPhone;
            tbxClientPostAddress.Text = contract.ClientPostAddress;

            gb1C.Text = contract.Status == 1 ? "1С (готов к экспорту)" : "1С";
            tbxContractCode.Text = contract.Contract1SCode;
            tbxExportResult.Text = contract.StatusMessage;

            gbContractor.Text = contract.IsJuridicalPerson ? "Контрагент (юр. лицо)" : "Контрагент (физ. лицо)";
            tbxPassportNumber.Text = contract.PassportNumber;
            tbxPassportOutlenDate.Text = contract.PassportOutletDate == null ? string.Empty : contract.PassportOutletDate.GetValueOrDefault().ToShortDateString();
            tbxPassportOutletOrgan.Text = contract.PassportOutletOrgan;
            tbxPassportSeries.Text = contract.PassportSeries;
            tbxService.Text = contract.Service.Name;
            isAlreadyExported = (contract.Status != 0);
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Private Methods

        #endregion
    }
}