using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class InsertPriceListRecordForm : Form
    {
        private readonly IPriceListService priceListService = AppRuntime.Instance.Container.GetComponent<IPriceListService>();
        private readonly IServicesService servicesService = AppRuntime.Instance.Container.GetComponent<IServicesService>();

        public InsertPriceListRecordForm()
        {
            InitializeComponent();
            dprDate.Value = dprDate.Value.AddDays(1);
            cbxService.DataSource = servicesService.GetServices();
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
                Tag = priceListService.AddPriceListRecord(int.Parse(cbxService.SelectedValue.ToString()),
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
