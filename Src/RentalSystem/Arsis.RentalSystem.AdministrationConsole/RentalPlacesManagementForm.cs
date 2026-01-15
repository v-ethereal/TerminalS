using System;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class RentalPlacesManagementForm : Form
    {
        #region Properties

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();
        private readonly Contract contract;
        private readonly bool isReadOnly;

        #endregion

        #region Constructors

        public RentalPlacesManagementForm()
        {
            InitializeComponent();
        }

        public RentalPlacesManagementForm(int contractId)
        {
            InitializeComponent();

            contract = contractService.GetContract(contractId);
            tbxContractNumber.Text = contract.ContractNumber;
            lbRentalProperties.DataSource = contractService.GetRentalPlaces(contract.Id);
            cbRentalProperties.DataSource = contractService.GetRentalPlaces();
        }

        public RentalPlacesManagementForm(int contractId, bool isReadOnly)
            : this(contractId)
        {
            this.isReadOnly = isReadOnly;
            setReadOnlyIfNeeded();
        }

        #endregion

        #region Private Methods

        private void setReadOnlyIfNeeded()
        {
            btnAdd.Enabled = 
                btnDelete.Enabled = 
                    btnPeriods.Enabled = 
                        cbRentalProperties.Enabled = !isReadOnly;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbRentalProperties.SelectedValue != null)
            {
                AddRentalPlaceConfirmForm addRentalPlaceConfirmForm = new AddRentalPlaceConfirmForm(contract.Id, int.Parse(cbRentalProperties.SelectedValue.ToString()));
            if (addRentalPlaceConfirmForm.ShowDialog(this) == DialogResult.OK)
                {
                    contractService.AddRentalPlaceToContract(contract.Id, int.Parse(cbRentalProperties.SelectedValue.ToString()), (DateTime)addRentalPlaceConfirmForm.Tag);
                    lbRentalProperties.DataSource = contractService.GetRentalPlaces(contract.Id);
                    cbRentalProperties.DataSource = contractService.GetRentalPlaces();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbRentalProperties.SelectedValue != null)
            {
                RemoveRentalPlaceConfirmForm removeRentalPlaceConfirmForm = new RemoveRentalPlaceConfirmForm(contract.Id, int.Parse(lbRentalProperties.SelectedValue.ToString()));
                if (removeRentalPlaceConfirmForm.ShowDialog(this) == DialogResult.OK)
                {
                    contractService.RemoveRentalPlaceFromContract(contract.Id, int.Parse(lbRentalProperties.SelectedValue.ToString()), (DateTime)removeRentalPlaceConfirmForm.Tag);
                    lbRentalProperties.DataSource = contractService.GetRentalPlaces(contract.Id);
                    cbRentalProperties.DataSource = contractService.GetRentalPlaces();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPeriods_Click(object sender, EventArgs e)
        {
            if (lbRentalProperties.SelectedValue != null)
            {
                UnpayablePeriodsManagementForm unpayablePeriodsManagementForm =
                        new UnpayablePeriodsManagementForm(contract.Id, int.Parse(lbRentalProperties.SelectedValue.ToString()));
                if (unpayablePeriodsManagementForm.ShowDialog(this) == DialogResult.OK) {}
            }
        }

        #endregion
    }
}
