using System;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class ContractHistoryForm : Form
    {
        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();

        #endregion

        #region Constructors

        public ContractHistoryForm()
        {
            InitializeComponent();
        }

        public ContractHistoryForm(int contractId)
        {
            InitializeComponent();
            lbxHistory.DataSource = contractService.GetHistory(contractId);
        }

        #endregion

        private void ContractHistoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}