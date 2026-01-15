using System;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class EditCashlessPaymentForm : Form
    {
        #region Fields

        private readonly IFeeService feeService = AppRuntime.Instance.Container.GetComponent<IFeeService>();
        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();
        private readonly int recordId;
        private Contract contract;

        #endregion

        #region Constructors

        public EditCashlessPaymentForm()
        {
            InitializeComponent();
            cpContract.ContractService = contractService;
        }

        public EditCashlessPaymentForm(int id)
        {
            InitializeComponent();
            cpContract.ContractService = contractService;
            recordId = id;
            RentalCashlessPayment feeRecord = feeService.GetRentalFeeRecord(recordId);
            dprDateFrom.Value = feeRecord.PaidDateFrom;
            dprDateTo.Value = feeRecord.PaidDateTo;
            cpContract.ContractId = feeRecord.ContractId;
            contract = contractService.GetContract(cpContract.ContractId);

            //Show current control date for user
            updateControlDateValue();
        }

        #endregion

        #region Private Methods
        
        private void updateControlDateValue()
        {
            dtp_ControlDate.Value = contract.CashlessPaymentControlDate.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (feeService.IsPaymentExistsInPeriod(cpContract.ContractId, recordId, dprDateFrom.Value, dprDateTo.Value))
                {
                    MessageBox.Show(this, "Для выбранного периода уже существует платеж", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                feeService.UpdateRentalFeeRecord(recordId, cpContract.ContractId,
                                                 dprDateFrom.Value,
                                                 dprDateTo.Value);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Validate();
            }
        }

        private void dprDateFrom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dprDateFrom.Value.Date < contract.DateFrom.GetValueOrDefault().Date)
            {
                errorProvider.SetError(dprDateFrom, "Начальное значение должно быть больше либо равно дате начала действия договора");
                e.Cancel = true;
            }
            else
            {
                if (dprDateFrom.Value.Date > contract.DateTo.GetValueOrDefault().Date)
                {
                    errorProvider.SetError(dprDateFrom, "Начальное значение должно быть меньше либо равно дате окончания действия договора");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(dprDateFrom, string.Empty);
                }
            }
        }

        private void dprDateTo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dprDateTo.Value.Date < dprDateFrom.Value.Date)
            {
                errorProvider.SetError(dprDateTo, "Конечное значение должно быть больше либо равно начальному");
                e.Cancel = true;
            }
            else
            {
                if (dprDateTo.Value.Date > contract.DateTo.GetValueOrDefault().Date)
                {
                    errorProvider.SetError(dprDateTo, "Конечное значение должно быть меньше либо равно дате окончания действия договора");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(dprDateTo, string.Empty);
                }
            }
        }

        private void cpContract_ValueChanged(object sender, ValueChangedArgs args)
        {
            contract = contractService.GetContract(args.ContractId);
            updateControlDateValue();
        }

        #endregion
    }
}