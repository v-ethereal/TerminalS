using System;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class EditContractRecordForm : Form
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
        private DateTime dateFrom;
        private DateTime dateTo;

        #endregion

        #region Constructors

        public EditContractRecordForm()
        {
            InitializeComponent();
        }

        public EditContractRecordForm(int id)
        {
            InitializeComponent();
            contract = contractService.GetContract(id);
            tbxContractNumber.Text = contract.ContractNumber;
            dprExpirationDateFrom.Value = contract.DateFrom ?? DateTime.Now;
            dprExpirationDateTo.Value = contract.DateTo ?? DateTime.Now;

            isCashless = contract.IsCashless;
            if (contract.IsCashless)
            {
                contractService.GetMinimalContractDuration(contract.Id, out dateFrom, out dateTo);
                dprDate.Value = contract.CashlessPaymentControlDate.GetValueOrDefault();
                lblPayDate.Visible = true;
                dprDate.Visible = true;
            }
            else
            {
                lblPayDate.Visible = false;
                dprDate.Visible = false;
            }

            gb1C.Text = contract.Status == 1 ? "1С (готов к экспорту)" : "1С";
            tbxContractCode.Text = contract.Contract1SCode;
            tbxExportResult.Text = contract.StatusMessage;

            gbContractor.Text = contract.IsJuridicalPerson ? "Контрагент (юр. лицо)" : "Контрагент (физ. лицо)";
            tbxClient1SCode.Text = contract.Client1SCode;
            tbxContractorName.Text = contract.ClientName;
            tbxClientAddress.Text = contract.ClientAddress;
            tbxClientPostAddress.Text = contract.ClientPostAddress;
            tbxClientPhone.Text = contract.ClientPhone;
            tbxINN.Text = contract.INN;
            tbxPassportSeries.Text = contract.PassportSeries;
            tbxPassportNumber.Text = contract.PassportNumber;
            tbxPassportOutletOrgan.Text = contract.PassportOutletOrgan;
            cbClientIsUrFace.Checked = contract.IsJuridicalPerson;

            DateTime? dtValue = contract.PassportOutletDate;
            if(dtValue.HasValue)
            {
                dtpClientPassportIssuedDate.Checked = true;
                dtpClientPassportIssuedDate.Value = dtValue.Value;
            }
            else
            {
                dtpClientPassportIssuedDate.Checked = false;
            }

            tbxService.Text = contract.Service.Name;
            isAlreadyExported = (contract.Status != 0);
        }

        #endregion

        #region Private Methods


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                bool isExporting = false;
                if (!isAlreadyExported)
                {
                    if (MessageBox.Show(this, TEXT, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                    {
                        isExporting = true;
                    }
                }
                if (isCashless)
                {
                    contractService.UpdateContractRecord(contract.Id, dprExpirationDateFrom.Value.Date, dprExpirationDateTo.Value.Date, dprDate.Value, isExporting);
                }
                else
                {
                    contractService.UpdateContractRecord(contract.Id, dprExpirationDateFrom.Value.Date, dprExpirationDateTo.Value.Date, isExporting);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Validate();
            }
        }

        private void dprExpirationDateFrom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dprExpirationDateFrom.Value.Date > dprExpirationDateTo.Value.Date)
            {
                errorProvider.SetError(dprExpirationDateFrom, "Начальное значение должно быть меньше конечного");
                e.Cancel = true;
            }
            else
            {
                if (isCashless)
                {
                    if (dprExpirationDateFrom.Value.Date > dateFrom.Date)
                    {
                        errorProvider.SetError(dprExpirationDateFrom, "Начальное значение должно быть меньше даты первого безналичного платежа");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider.SetError(dprExpirationDateFrom, string.Empty);
                    }
                }
                else
                {
                    errorProvider.SetError(dprExpirationDateFrom, string.Empty);
                }
            }
        }

        private void dprExpirationDateTo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dprExpirationDateTo.Value.Date < dprExpirationDateFrom.Value.Date)
            {
                errorProvider.SetError(dprExpirationDateTo, "Конечное значение должно быть больше начального");
                e.Cancel = true;
            }
            else
            {
                if (isCashless)
                {
                    if (dprExpirationDateTo.Value.Date < dateTo.Date)
                    {
                        errorProvider.SetError(dprExpirationDateTo, "Конечное значение должно быть больше или равно дате последнего безналичного платежа");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider.SetError(dprExpirationDateTo, string.Empty);
                    }
                }
                else
                {
                    errorProvider.SetError(dprExpirationDateTo, string.Empty);
                }
            }
        }

        #endregion
    }
}