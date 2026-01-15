using System;
using System.Windows.Forms;
using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole.UserControls
{
    public partial class ContractPicker : UserControl
    {
        #region Constructor

        public ContractPicker()
        {
            InitializeComponent();
        }

        #endregion

        #region Fields

        private IContractService contractService;
        private string contractNumber;
        private int contractId;
        private ContractState state;

        #endregion

        #region Events

        public event ValueChangedEventHandler ValueChanged;

        #endregion

        #region Properties

        public IContractService ContractService
        {
            get { return contractService; }
            set { contractService = value; }
        }

        public ContractState State
        {
            get { return state; }
            set { state = value; }
        }

        public int ContractId
        {
            get { return contractId; }
            set
            {
                contractId = value;
                if (contractService != null)
                {
                    Contract contract = contractService.GetContract(contractId);
                    if (contract != null)
                    {
                        contractNumber = contract.ContractNumber;
                        tbxContract.Text = contractNumber;
                    }
                }
            }
        }

        public string ContractNumber
        {
            get { return contractNumber; }
        }

        #endregion

        #region Private Methods

        private void btnChoose_Click(object sender, EventArgs e)
        {
            ContractSelectForm contractSelectForm;
            Cursor = Cursors.WaitCursor;
            if (contractId != 0)
            {
                contractSelectForm = new ContractSelectForm(state, contractId);
            }
            else
            {
                contractSelectForm = new ContractSelectForm(state);
            }
            Cursor = Cursors.Default;
            if (contractSelectForm.ShowDialog(this) == DialogResult.OK)
            {
                if (contractSelectForm.Tag != null)
                {
                    if (contractService != null)
                    {
                        Contract contract = contractService.GetContract((int)contractSelectForm.Tag);
                        contractNumber = contract.ContractNumber;
                        contractId = contract.Id;
                        tbxContract.Text = contractNumber;
                        ValueChangedArgs args = new ValueChangedArgs(contractId, contractNumber);
                        ValueChanged(this, args);
                    }
                }
            }
        }

        #endregion
    }
}

public delegate void ValueChangedEventHandler(object sender, ValueChangedArgs args);

public class ValueChangedArgs
{
    #region Constructors

    public ValueChangedArgs(int contractId, string contractNumber)
    {
        this.contractId = contractId;
        this.contractNumber = contractNumber;
    }

    #endregion

    #region Fields
    
    private int contractId;
    private string contractNumber;

    #endregion

    #region Properties

    public int ContractId
    {
        get { return contractId; }
        set { contractId = value; }
    }

    public string ContractNumber
    {
        get { return contractNumber; }
        set { contractNumber = value; }
    }

    #endregion

}