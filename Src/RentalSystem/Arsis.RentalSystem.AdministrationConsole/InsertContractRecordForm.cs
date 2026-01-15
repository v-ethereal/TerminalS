using System;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Dal;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class InsertContractRecordForm : Form
    {
        #region Constants

        private const string CAPTION = "Экспорт в 1С";
        private const string TEXT = "Хотите ли вы, чтобы договор был экспортирован в 1С?";
        private const string ERROR_MESSAGE = "Ошибка";
        private const string ERROR_TEXT = "Ошибка импорта контрагентов";

        #endregion

        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();
        private readonly IServicesService servicesService = AppRuntime.Instance.Container.GetComponent<IServicesService>();
        private readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();
        private string contractorCode;
        private bool is1SDBAvailable;
    
        #endregion

        #region Constructors

        public InsertContractRecordForm()
        {
            InitializeComponent();
            cbxService.DataSource = servicesService.GetRentalServices();
            is1SDBAvailable = false;
            updateFormVisibilityByConnectionExistance();
        }
        
        private bool Is1SDBAvailable
        {
            get { return is1SDBAvailable; }
        }

        private void updateFormVisibilityByConnectionExistance()
        {
            bool is1SExists = OdbcHelper.IsOdbcConnectionExists();

            btnImport.Enabled = 
            tbxClient1SCode.ReadOnly =
            tbxContractorName.ReadOnly =
            tbxClientAddress.ReadOnly =
            tbxClientPostAddress.ReadOnly =
            tbxClientPhone.ReadOnly =
            tbxINN.ReadOnly =
            tbxPassportNumber.ReadOnly =
            tbxPassportSeries.ReadOnly =
            tbxPassportOutletOrgan.ReadOnly = is1SExists;

            dtpClientPassportIssuedDate.Enabled =
            cbClientIsUrFace.Enabled = !is1SExists;

            is1SDBAvailable = is1SExists;
        }

        #endregion

        #region Private Methods
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Contract contract;
                bool isExporting = false;

                if (MessageBox.Show(this, TEXT, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    isExporting = true;
                }

                int serviceId = int.Parse(cbxService.SelectedValue.ToString());
                
                if(is1SDBAvailable)
                {
                    Contractor contractor = OdbcHelper.GetContractor(contractorCode);

                    contract = new Contract
                    {
                        ContractNumber = tbxContractNumber.Text,
                        DateFrom = dprExpirationDateFrom.Value.Date,
                        DateTo = dprExpirationDateTo.Value.Date,
                        Client1SCode = contractor.Client1SCode,
                        ClientName = contractor.ClientName,
                        IsJuridicalPerson = contractor.IsJuridicalPerson,
                        ClientAddress = contractor.ClientAddress,
                        ClientPostAddress = contractor.ClientPostAddress,
                        ClientPhone = contractor.ClientPhone,
                        INN = contractor.INN,
                        PassportSeries = contractor.PassportSeries,
                        PassportNumber = contractor.PassportNumber,
                        PassportOutletOrgan = contractor.PassportOutletOrgan,
                        PassportOutletDate = (string.IsNullOrEmpty(contractor.PassportOutletDate)
                                ? (DateTime?)null
                                : DateTime.Parse(contractor.PassportOutletDate).
                                Date),
                        IsCashless = cbxIsCashless.Checked,
                        CrDateTime = DateTime.Now,
                        CrUserId = userService.CurrentUser.Id,
                        Service = servicesService.GetServiceRecord((serviceId)),
                        Status = Convert.ToByte(isExporting ? 1 : 0),
                        PlacePrice = servicesService.GetServicePrice(serviceId)
                    };
                }
                else
                {   
                    contract = new Contract
                    {
                        ContractNumber = tbxContractNumber.Text,
                        DateFrom = dprExpirationDateFrom.Value.Date,
                        DateTo = dprExpirationDateTo.Value.Date,
                        Client1SCode = tbxClient1SCode.Text,
                        ClientName = tbxContractorName.Text,
                        IsJuridicalPerson = cbClientIsUrFace.Checked,
                        ClientAddress = tbxClientAddress.Text,
                        ClientPostAddress = tbxClientPostAddress.Text,
                        ClientPhone = tbxClientPhone.Text,
                        INN = tbxINN.Text,
                        PassportSeries = tbxPassportSeries.Text,
                        PassportNumber = tbxPassportNumber.Text,
                        PassportOutletOrgan = tbxPassportOutletOrgan.Text,
                        PassportOutletDate = null,
                        IsCashless = cbxIsCashless.Checked,
                        CrDateTime = DateTime.Now,
                        CrUserId = userService.CurrentUser.Id,
                        Service = servicesService.GetServiceRecord((serviceId)),
                        Status = Convert.ToByte(isExporting ? 1 : 0),
                        PlacePrice = servicesService.GetServicePrice(serviceId)
                    };

                    if(dtpClientPassportIssuedDate.Checked)
                    {
                        contract.PassportOutletDate = dtpClientPassportIssuedDate.Value;
                    }
                }

                //Cashless payment check date has to be inserted here if needed
                if(cbxIsCashless.Checked)
                {
                    contract.CashlessPaymentControlDate = dprDate.Value;
                }

                //Higher level gets the contract id
                Tag = contractService.InsertContractRecord(contract, serviceId);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Validate();
            }
        }

        private void cbxIsCashless_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxIsCashless.Checked)
            {
                lblPayDate.Visible = true;
                dprDate.Visible = true;
            }
            else
            {
                lblPayDate.Visible = false;
                dprDate.Visible = false;
            }
        }

        private void dprExpirationDateFrom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dprExpirationDateFrom.Value.Date > dprExpirationDateTo.Value.Date)
            {
                errorProvider.SetError(dprExpirationDateFrom, "Начальное значение должно быть меньше конечного");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dprExpirationDateFrom, string.Empty);
            }
        }

        private void dprExpirationDateTo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dprExpirationDateTo.Value.Date < dprExpirationDateFrom.Value.Date)
            {
                errorProvider.SetError(dprExpirationDateTo, "Конечное значение должно быть больше начального");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dprExpirationDateTo, string.Empty);
            }
        }

        private void tbxContractNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxContractNumber.Text))
            {
                errorProvider.SetError(tbxContractNumber, "Поле обязательно к заполнению");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbxContractNumber, string.Empty);
            }

        }

        private void cbxService_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbxService.SelectedValue == null)
            {
                errorProvider.SetError(cbxService, "Выберите тип аренды");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbxService, string.Empty);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ContractorSelectForm contractorSelectForm = new ContractorSelectForm();
            if (contractorSelectForm.ShowDialog() == DialogResult.OK)
            {
                if (contractorSelectForm.Tag != null)
                {
                    contractorCode = contractorSelectForm.Tag.ToString();
                    Contractor contractor = null;
                    try
                    {
                        contractor = contractService.GetContractor(contractorCode);
                    }
                    catch (RentalSystemException)
                    {
                        MessageBox.Show(this, ERROR_TEXT, ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (contractor != null)
                    {
                        tbxClient1SCode.Text = contractor.Client1SCode;
                        gbContractor.Text = contractor.IsJuridicalPerson
                                ? "Контрагент (юр. лицо)"
                                : "Контрагент (физ. лицо)";
                        tbxContractorName.Text = contractor.ClientName;
                        tbxClientAddress.Text = contractor.ClientAddress;
                        tbxClientPostAddress.Text = contractor.ClientPostAddress;
                        tbxClientPhone.Text = contractor.ClientPhone;
                        tbxINN.Text = contractor.INN;
                        tbxPassportSeries.Text = contractor.PassportSeries;
                        tbxPassportNumber.Text = contractor.PassportNumber;
                        tbxPassportOutletOrgan.Text = contractor.PassportOutletOrgan;
                        DateTime dtValue;
                        if(DateTime.TryParse(contractor.PassportOutletDate, out dtValue))
                        {
                            dtpClientPassportIssuedDate.ShowCheckBox = true;
                            dtpClientPassportIssuedDate.Value = dtValue;
                        }
                        else
                        {
                            dtpClientPassportIssuedDate.ShowCheckBox = false;
                        }
                    }
                }
            }
        }

        #endregion

        private void tbxClient1SCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!is1SDBAvailable && string.IsNullOrEmpty(tbxClient1SCode.Text))
            {
                errorProvider.SetError(tbxClient1SCode, "Поле обязательно к заполнению");
                e.Cancel = true;
                return;
            }

            errorProvider.Clear();
        }
    }
}