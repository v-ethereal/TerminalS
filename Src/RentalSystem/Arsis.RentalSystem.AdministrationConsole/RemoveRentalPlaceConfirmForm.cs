using System;
using System.ComponentModel;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class RemoveRentalPlaceConfirmForm : Form
    {
        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();
        private readonly Contract contract;
        private DateTime rentalPlaceFromDate;

        #endregion

        #region Constructors

        public RemoveRentalPlaceConfirmForm()
        {
            InitializeComponent();
            dprDate.Value = dprDate.Value.AddDays(1);
        }

        public RemoveRentalPlaceConfirmForm(int contractId, int placeId)
        {
            InitializeComponent();
            dprDate.Value = dprDate.Value.AddDays(1);
            contract = contractService.GetContract(contractId);
            rentalPlaceFromDate = contractService.GetContractRentalPlaceFromDate(contractId, placeId);
        }

        #endregion

        #region Private Methods

        private void dprDate_Validating(object sender, CancelEventArgs e)
        {
            if (contract.DissolutionDate != null
                && contract.DissolutionDate.GetValueOrDefault().Date <= DateTime.Now.Date)
            {
                errorProvider.SetError(dprDate, "Договор закрыт");
                e.Cancel = true;
            }
            else
            {
                if (dprDate.Value.Date <= rentalPlaceFromDate.Date)
                {
                    errorProvider.SetError(dprDate,
                                           "Дата удаления места должна быть больше даты с которой место привязано к договору");
                    e.Cancel = true;
                }
                else
                {
                    if (dprDate.Value.Date > contract.DateTo.GetValueOrDefault().Date)
                    {
                        errorProvider.SetError(dprDate,
                                               "Дата удаления места должна быть меньше либо равна дате окончания действия договора");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider.SetError(dprDate, string.Empty);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Tag = dprDate.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Validate();
            }
        }

        #endregion

    }
}
