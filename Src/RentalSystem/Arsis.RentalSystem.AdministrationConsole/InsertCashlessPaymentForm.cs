#region
using System;
using System.ComponentModel;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

#endregion

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class InsertCashlessPaymentForm : Form
    {
        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();

        private readonly IFeeService feeService = AppRuntime.Instance.Container.GetComponent<IFeeService>();
        private Contract contract;
        private DateTime paymentControlDate;

        #endregion

        #region Constructors

        public InsertCashlessPaymentForm()
        {
            InitializeComponent();
            cpContract.ContractService = contractService;
        }

        #endregion

        #region Private Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (feeService.IsPaymentExistsInPeriod(cpContract.ContractId, null, dprDateFrom.Value, dprDateTo.Value))
                {
                    MessageBox.Show(this, "ƒл€ выбранного периода уже существует платеж", "ќшибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                Tag = feeService.InsertRentalFeeRecord(cpContract.ContractId,
                                                       dprDateFrom.Value,
                                                       dprDateTo.Value,
                                                       dtp_ControlDate.Value);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Validate();
            }
        }

        private void cpContract_ValueChanged(object sender, ValueChangedArgs args)
        {
            //This value is the _control date_, not just _from date_
            paymentControlDate = contractService.GetCashlessPaymentControlDate(cpContract.ContractId);

            DateTime prevDateToPeriod;
            DateTime[] lastPaymentPeriod = contractService.GetLastRentalCashlessPaymentForContract(cpContract.ContractId);

            contract = contractService.GetContract(cpContract.ContractId);

            //Set DateFrom and DateTo value 
            if (lastPaymentPeriod != null)
            {
                dprDateFrom.Value = lastPaymentPeriod[1].AddDays(1);
                prevDateToPeriod = lastPaymentPeriod[1];

                int daysToAdd = lastPaymentPeriod[1].Subtract(lastPaymentPeriod[0]).Days;
                dprDateTo.Value = dprDateFrom.Value.AddDays(daysToAdd);
            }
            else
            {
                dprDateFrom.Value = contract.DateFrom.Value;
                prevDateToPeriod = contract.DateFrom.Value;

                dprDateTo.Value = dprDateFrom.Value.AddMonths(1).AddDays(-1);
            }

            //Last check for DateTo value 
            if (dprDateTo.Value > contract.DateTo)
            {
                dprDateTo.Value = contract.DateTo.Value;
            }

            //Calculate ControlDate value
            dtp_ControlDate.Value =   contract.CashlessPaymentControlDate.HasValue
                                    ? dprDateTo.Value.AddDays((paymentControlDate - prevDateToPeriod).Days)
                                    : dprDateTo.Value.AddDays(1);
        }

        private void dprDateFrom_Validating(object sender, CancelEventArgs e)
        {
            bool noError = true;
            if (contract != null)
            {
                if (dprDateFrom.Value.Date < contract.DateFrom.GetValueOrDefault().Date)
                {
                    errorProvider.SetError(dprDateFrom,
                                           "Ќачальное значение должно быть больше либо равно дате начала действи€ договора");
                    e.Cancel = true;
                    noError = false;
                }

                if (dprDateFrom.Value.Date > contract.DateTo.GetValueOrDefault().Date)
                {
                    errorProvider.SetError(dprDateFrom,
                                           "Ќачальное значение должно быть меньше либо равно дате окончани€ действи€ договора");
                    e.Cancel = true;
                    noError = false;
                }
            }

            if (noError)
            {
                errorProvider.SetError(dprDateFrom, string.Empty);
            }
        }

        private void dprDateTo_Validating(object sender, CancelEventArgs e)
        {
            bool noError = true;
            if (contract != null)
            {
                if (dprDateTo.Value.Date < dprDateFrom.Value.Date)
                {
                    errorProvider.SetError(dprDateTo, " онечное значение должно быть больше либо равно начальному");
                    e.Cancel = true;
                    noError = false;
                }

                if (dprDateTo.Value.Date > contract.DateTo.GetValueOrDefault().Date)
                {
                    errorProvider.SetError(dprDateTo,
                                           " онечное значение должно быть меньше либо равно дате окончани€ действи€ договора");
                    e.Cancel = true;
                    noError = false;
                }
            }

            if (noError)
            {
                errorProvider.SetError(dprDateTo, string.Empty);
            }
        }

        private void cpContract_Validating(object sender, CancelEventArgs e)
        {
            if (contract == null)
            {
                errorProvider.SetError(cpContract, "Ќеобходимо выбрать договор");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cpContract, string.Empty);
            }
        }

        private void dtp_ControlDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtp_ControlDate.Value.Date <= dprDateTo.Value.Date)
            {
                errorProvider.SetError(dtp_ControlDate,
                                       "ƒата контрол€ должна быть больше конечного значени€ периода оплаты");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtp_ControlDate, string.Empty);
            }
        }

        #endregion
    }
}