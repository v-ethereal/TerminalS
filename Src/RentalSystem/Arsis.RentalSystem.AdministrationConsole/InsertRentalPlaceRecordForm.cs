using System;
using System.ComponentModel;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class InsertRentalPlaceRecordForm : Form
    {
        private readonly IRentalPlaceService rentalPlaceService = AppRuntime.Instance.Container.GetComponent<IRentalPlaceService>();

        #region Constructors

        public InsertRentalPlaceRecordForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void tbxNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxNumber.Text))
            {
                errorProvider.SetError(tbxNumber, "Поле обязательно к заполнению");
                e.Cancel = true;
            }
            else
            {
                decimal value;
                if (!decimal.TryParse(tbxNumber.Text, out value))
                {
                    errorProvider.SetError(tbxNumber, "Значение должно быть цифровым");
                    e.Cancel = true;
                }
                else
                {
                    if (value <= 0)
                    {
                        errorProvider.SetError(tbxNumber, "Значение должно быть положительным числом");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (rentalPlaceService.CheckRentalPlaceExistance(tbxNumber.Text))
                        {
                            errorProvider.SetError(tbxNumber, "Место с таким номером уже существует");
                            e.Cancel = true;
                        }
                        else
                        {
                            errorProvider.SetError(tbxNumber, string.Empty);
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
                Tag = rentalPlaceService.InsertRentalPlaceRecord(tbxNumber.Text);
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
