using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class EditPriceListRecordForm : Form
    {
        private readonly IPriceListService priceListService = AppRuntime.Instance.Container.GetComponent<IPriceListService>();
        private readonly IServicesService servicesService = AppRuntime.Instance.Container.GetComponent<IServicesService>();
        private readonly PriceList priceList;

        public EditPriceListRecordForm()
        {
            InitializeComponent();
            cbxService.DataSource = servicesService.GetServices();
        }

        public EditPriceListRecordForm(int priceListRecordId)
        {
            InitializeComponent();
            cbxService.DataSource = servicesService.GetServices();
            priceList = priceListService.GetPriceListRecord(priceListRecordId);
            cbxService.SelectedValue = priceList.ServiceId;
            tbxPrice.ControlValue = priceList.Price;//.ToString("F0");
            dprDate.Value = priceList.ValidFrom ?? DateTime.Now;
        }

        private void tbxPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPrice.Text))
            {
                errorProvider.SetError(tbxPrice, "Поле обязательно к заполнению");
                e.Cancel = true;
            }
            else
            {
                decimal value;
                if (!decimal.TryParse(tbxPrice.Text, out value))
                {
                    errorProvider.SetError(tbxPrice, "Значение должно быть числовым");
                    e.Cancel = true;
                }
                else
                {
                    if (value <= 0)
                    {
                        errorProvider.SetError(tbxPrice, "Значение должно быть больше 0");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider.SetError(dprDate, string.Empty);
                    }
                }
            }
        }

        private void dtpDate_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                priceListService.UpdatePriceListRecord(priceList.Id,
                                                       int.Parse(cbxService.SelectedValue.ToString()),
                                                       decimal.Parse(tbxPrice.Text, NumberStyles.Currency),
                                                       dprDate.Value);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Validate();
            }
        }
    }
}
