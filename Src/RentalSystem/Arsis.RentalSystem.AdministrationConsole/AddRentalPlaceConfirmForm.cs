using System;
using System.ComponentModel;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class AddRentalPlaceConfirmForm : Form
    {
        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();
        private readonly Contract contract;
        private readonly int placeId;

        #endregion

        #region Constructors

        public AddRentalPlaceConfirmForm()
        {
            InitializeComponent();
            dprDate.Value = dprDate.Value.AddDays(1);
        }

        public AddRentalPlaceConfirmForm(int contractId, int placeId)
        {
            InitializeComponent();
            dprDate.Value = dprDate.Value.AddDays(1);
            contract = contractService.GetContract(contractId);
            this.placeId = placeId;
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
                if (dprDate.Value.Date < DateTime.Now.AddDays(1).Date)
                {
                    errorProvider.SetError(dprDate, "Дата добавления места должна быть больше сегодняшней");
                    e.Cancel = true;
                }
                else
                {
                    if (dprDate.Value.Date > contract.DateTo.GetValueOrDefault().Date)
                    {
                        errorProvider.SetError(dprDate,
                                               "Дата добавления места должна быть меньше либо равна дате окончания действия договора");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (contractService.CheckAddingPlaceDateIntersection(contract.Id,
                                                                             placeId,
                                                                             dprDate.Value,
                                                                             contract.DateTo.GetValueOrDefault()))
                        {
                            errorProvider.SetError(dprDate, "На данном диапазоне дат выбранное место уже используется");
                            e.Cancel = true;
                        }
                        else
                        {
                            errorProvider.SetError(dprDate, string.Empty);
                        }
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
