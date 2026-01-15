using System;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.AdministrationConsole.Properties;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class ContractorSelectForm : Form
    {
        #region Constants

        private const string ERROR_MESSAGE = "Ошибка";
        private const string ERROR_TEXT = "Ошибка импорта контрагентов";

        #endregion

        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();

        #endregion

        #region Constructors

        public ContractorSelectForm()
        {
            InitializeComponent();
            try
            {
                string parentCode = Settings.Default.ParentClientCode;
                dgvContractors.DataSource = contractService.GetContractors(parentCode);
            }
            catch (RentalSystemException)
            {
                MessageBox.Show(this, ERROR_TEXT, ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            llClearContractorsFilter.BringToFront();
        }

        #endregion

        #region Private Methods

        private void llClearContractorsFilter_MouseClick(object sender, MouseEventArgs e)
        {
            contractorsFilterExtender.ClearFilters();
        }

        private void llClearContractorsFilter_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is LinkLabel)
            {
                ((LinkLabel)sender).Image = Resources.clearFilter_pressed;
            }
        }

        private void llClearContractorsFilter_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is LinkLabel)
            {
                ((LinkLabel)sender).Image = Resources.clearFilter_default;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvContractors.SelectedRows)
            {
                Contractor contractor = row.DataBoundItem as Contractor;
                if (contractor != null)
                {
                    Tag = contractor.Client1SCode;
                }
                break;
            }
        }

        private void dgvContractors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvContractors.SelectedRows)
            {
                Contractor contractor = row.DataBoundItem as Contractor;
                if (contractor != null)
                {
                    Tag = contractor.Client1SCode;
                }
                DialogResult = DialogResult.OK;
                Close();
                break;
            }
        }

        private void dgvContractors_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    {
                        foreach (DataGridViewRow row in dgvContractors.SelectedRows)
                        {
                            Contractor contractor = row.DataBoundItem as Contractor;
                            if (contractor != null)
                            {
                                Tag = contractor.Client1SCode;
                            }
                            DialogResult = DialogResult.OK;
                            Close();
                            break;
                        }
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            e.Handled = true;
        }

        #endregion
    }
}
