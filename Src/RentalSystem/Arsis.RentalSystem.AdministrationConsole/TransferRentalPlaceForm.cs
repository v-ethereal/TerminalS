using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class TransferRentalPlaceForm : Form
    {
        #region Properties

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();

        #endregion

        #region Constructors

        public TransferRentalPlaceForm()
        {
            InitializeComponent();
            lbxRentalPlaces.DataSource = contractService.GetRentalPlaces(cpContractFrom.ContractId);
            cpContractFrom.ContractService = contractService;
            cpContractTo.ContractService = contractService;
        }

        public TransferRentalPlaceForm(int contractId)
        {
            InitializeComponent();
            lbxRentalPlaces.DataSource = contractService.GetRentalPlaces(cpContractFrom.ContractId);
            cpContractFrom.ContractService = contractService;
            cpContractTo.ContractService = contractService;
            //Let's show selected contract as FromContract
            cpContractFrom.ContractId = contractId;
            //Let's shw places in textBox
            cpContractFrom_ValueChanged(null, null);
        }

        #endregion

        #region Private Methods

        private void contractFrom_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cpContractFrom.ContractNumber))
            {
                errorProvider.SetError(cpContractFrom, "Поле обязательно к заполнению");
                e.Cancel = true;
            }
            else
            {
                if (!contractService.CheckContractExistance(cpContractFrom.ContractNumber))
                {
                    errorProvider.SetError(cpContractFrom, "Контракт не существует");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(cpContractFrom, string.Empty);
                }
            }
        }

        private void contractTo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cpContractTo.ContractNumber))
            {
                errorProvider.SetError(cpContractTo, "Поле обязательно к заполнению");
                e.Cancel = true;
            }
            else
            {
                if (!contractService.CheckContractExistance(cpContractTo.ContractNumber))
                {
                    errorProvider.SetError(cpContractTo, "Контракт не существует");
                    e.Cancel = true;
                }
                else
                {
                    if (cpContractFrom.ContractId == cpContractTo.ContractId)
                    {
                        errorProvider.SetError(cpContractTo, "Передача с самого на себя не возможна");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider.SetError(cpContractTo, string.Empty);
                    }
                }
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (MessageBox.Show(this, string.Format("Места будут переданы с договора №{0} на договор №{1}.", cpContractFrom.ContractNumber, cpContractTo.ContractNumber), "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    List<int> rentalPlacesIds = new List<int>();
                    foreach (RentalPlace selectedItem in lbxRentalPlaces.SelectedItems)
                    {
                        rentalPlacesIds.Add(selectedItem.Id);
                    }
                    contractService.Transfer(cpContractFrom.ContractId, cpContractTo.ContractId, rentalPlacesIds, dprDate.Value);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                Validate();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dprDate_Validating(object sender, CancelEventArgs e)
        {
            if (cpContractFrom.ContractNumber != null)
            {
                Contract contract1 = contractService.GetContract(cpContractFrom.ContractId);
                if (dprDate.Value.Date <= contract1.DateFrom.GetValueOrDefault().Date)
                {
                    errorProvider.SetError(dprDate, "Дата передачи должна быть больше даты начала действия договора с которого идет передача");
                    e.Cancel = true;
                }
                else
                {
                    if (dprDate.Value.AddDays(-1).Date > contract1.DateTo.GetValueOrDefault().Date)
                    {
                        errorProvider.SetError(dprDate, "Дата передачи минус один день должна быть меньше либо равна дате окончания действия договора с которого идет передача");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (cpContractTo != null)
                        {
                            Contract contract2 = contractService.GetContract(cpContractTo.ContractId);
                            if (contract2 != null)
                            {
                                if (dprDate.Value.Date < contract2.DateFrom.GetValueOrDefault().Date)
                                {
                                    errorProvider.SetError(dprDate, "Дата передачи должна быть больше либо равна дате начала действия договора на который идет передача");
                                    e.Cancel = true;
                                }
                                else
                                {
                                    if (dprDate.Value.Date > contract2.DateTo.GetValueOrDefault().Date)
                                    {
                                        errorProvider.SetError(dprDate, "Дата передачи должна быть меньше либо равна дате окончания действия договора на который идет передача");
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
                }
            }
        }

        private void cpContractFrom_ValueChanged(object sender, ValueChangedArgs args)
        {
            if (contractService != null && cpContractFrom != null)
            {
                lbxRentalPlaces.DataSource = contractService.GetRentalPlaces(cpContractFrom.ContractId);
            }
        }

        private void cpContractTo_ValueChanged(object sender, ValueChangedArgs args)
        {

        }

        #endregion
    }
}
