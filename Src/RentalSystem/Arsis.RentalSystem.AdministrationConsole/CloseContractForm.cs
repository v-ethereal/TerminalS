using System;
using System.ComponentModel;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class CloseContractForm : Form
    {
        #region Constants

        private const string CURRENCY_FORMAT = "C2";
        private const string CLOSE_CONFIRMATION_CAPTION = "Подтверждение закрытия";
        private const string CLOSE_CONFIRMATION_TEXT = "Вы действительно хотите закрыть договор?";

        #endregion

        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();

        #endregion
        
        #region Constructors

        public CloseContractForm()
        {
            InitializeComponent();
            cpContract.ContractService = contractService;
        }

        public CloseContractForm(int contractId)
        {
            InitializeComponent();
            cpContract.ContractService = contractService;
            cpContract.ContractId = contractId;
        }

        #endregion

        #region Private Methods

        private void dtpDate_Validating(object sender, CancelEventArgs e)
        {
            if (dprDate.Value >= DateTime.Now)
            {
                errorProvider.SetError(dprDate, "Дата закрытия должна быть не больше сегодняшней даты");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dprDate, string.Empty);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (contractService.CheckContractExistance(cpContract.ContractNumber))
                {
                    if (
                            MessageBox.Show(this,
                                            CLOSE_CONFIRMATION_TEXT,
                                            CLOSE_CONFIRMATION_CAPTION,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        contractService.CloseContract(cpContract.ContractId, dprDate.Value);
                    }
                }
                Close();
            }
            else
            {
                Validate();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            useWaitCursor(true);
            if (contractService.CheckContractExistance(cpContract.ContractNumber))
            {
                decimal renderedAmmount;
                decimal recievedAmmount;
                decimal balance;
                contractService.CalculateContract(cpContract.ContractId,
                                                  dprDate.Value,
                                                  out renderedAmmount,
                                                  out recievedAmmount,
                                                  out balance);
                tbxRenderedAmmount.Text = renderedAmmount.ToString(CURRENCY_FORMAT);
                tbxRecievedAmmount.Text = recievedAmmount.ToString(CURRENCY_FORMAT);
                tbxBalance.Text = balance.ToString(CURRENCY_FORMAT);
            }
            useWaitCursor(false);
        }

        private Form currentForm;
        private void useWaitCursor(bool isUse)
        {
            if (isUse)
            {
                currentForm = this;
                currentForm.Cursor = Cursors.WaitCursor;
            }
            else
            {
                if (currentForm != null)
                {
                    currentForm.Cursor = Cursors.Default;
                    currentForm = null;
                }
            }
        }

        #endregion

    }
}
