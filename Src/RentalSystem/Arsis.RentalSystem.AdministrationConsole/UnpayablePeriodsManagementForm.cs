using System;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class UnpayablePeriodsManagementForm : Form
    {
        #region Constants

        private const string CAPTION = "Ошибка проверки параметров";

        #endregion
        
        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();
        private readonly IUnpayablePeriodsService unpayablePeriodsService = AppRuntime.Instance.Container.GetComponent<IUnpayablePeriodsService>();
        private readonly IRentalPlaceService rentalPlaceService = AppRuntime.Instance.Container.GetComponent<IRentalPlaceService>();
        private readonly Contract contract;
        private readonly RentalPlace rentalPlace;

        #endregion

        #region Constructors
        
        public UnpayablePeriodsManagementForm()
        {
            InitializeComponent();
            RefreshPeriodsList();
        }

        public UnpayablePeriodsManagementForm(int contractId, int rentalPlaceId)
        {
            InitializeComponent();
            contract = contractService.GetContract(contractId);
            rentalPlace = rentalPlaceService.GetRentalPlace(rentalPlaceId);
            tbxContractNumber.Text = contract.ContractNumber;
            tbxPlaceNumber.Text = rentalPlace.Number;
            RefreshPeriodsList();
        }

        #endregion

        #region Private Methods

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dprDateFrom.Value.Date > dprDateTo.Value.Date)
            {
                MessageBox.Show(this,
                                "Начальное значение должно быть меньше конечного",
                                CAPTION,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else if (dprDateFrom.Value.Date > dprDateTo.Value.Date)
            {
                MessageBox.Show(this,
                                "Конечное значение должно быть больше начального",
                                CAPTION,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else if (unpayablePeriodsService.CheckIntersection(contract.Id, rentalPlace.Id, dprDateFrom.Value, dprDateTo.Value))
            {
                MessageBox.Show(this,
                                "Диапазоны значений не должны пересекаться",
                                CAPTION,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                unpayablePeriodsService.AddPeriod(contract.Id, rentalPlace.Id, dprDateFrom.Value, dprDateTo.Value, tbxReason.Text);
                RefreshPeriodsList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbxPeriods.SelectedValue != null)
            {
                unpayablePeriodsService.DeletePeriod(((ContractUnpayablePeriod)lbxPeriods.SelectedItem).Id);
            }
            RefreshPeriodsList();
        }

        private void RefreshPeriodsList()
        {
            lbxPeriods.DataSource = unpayablePeriodsService.GetContractUnpayablePeriods(contract.Id, rentalPlace.Id);
        }

        private void lbxPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContractUnpayablePeriod selectedItem = lbxPeriods.SelectedItem as ContractUnpayablePeriod;
            if (selectedItem != null)
            {
                tbxReason.Text = selectedItem.Reason;
            }
        }

        #endregion
    }
}
