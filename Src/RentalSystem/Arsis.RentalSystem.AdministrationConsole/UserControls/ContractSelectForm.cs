using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.AdministrationConsole.Properties;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole.UserControls
{
    public partial class ContractSelectForm : Form
    {
        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();

        #endregion

        #region Constructors

        public ContractSelectForm(ContractState state)
        {
            InitializeComponent();

            DateTime dateFrom = DateTime.Now;
            dateFrom = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day);
            DateTime dateTo = dateFrom;
            dateTo = new DateTime(dateTo.Year - 1, dateTo.Month, dateTo.Day);

            dgvContracts.DataSource = contractService.GetContracts(state, dateFrom, dateTo);
            contractFilterExtender.DataGridView = dgvContracts;
            contractFilterExtender.RefreshFilters();
            if (columnContractNumber != null)
            {
                dgvContracts.Sort(dgvContracts.Columns[columnContractNumber.Name], ListSortDirection.Ascending);
            } 
            foreach (DataGridViewRow row in dgvContracts.Rows)
            {
                Contract contract = row.DataBoundItem as Contract;
                if (contract != null
                    && contract.DissolutionDate != null)
                {
                    row.DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Italic);
                }
            }
            dgvContracts.Focus();
        }

        public ContractSelectForm(ContractState state, int id)
        {
            InitializeComponent();

            DateTime dateFrom = DateTime.Now;
            dateFrom = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day);
            DateTime dateTo = dateFrom;
            dateTo = new DateTime(dateTo.Year - 1, dateTo.Month, dateTo.Day);

            dgvContracts.DataSource = contractService.GetContracts(state, dateFrom, dateTo);
            contractFilterExtender.DataGridView = dgvContracts;
            contractFilterExtender.RefreshFilters();
            if (columnContractNumber != null)
            {
                dgvContracts.Sort(dgvContracts.Columns[columnContractNumber.Name], ListSortDirection.Ascending);
            }
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                Contract contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    if (contract.Id == id)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private void llClearContractsFilter_MouseClick(object sender, MouseEventArgs e)
        {
            contractFilterExtender.ClearFilters();
        }

        private void llClearContractsFilter_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is LinkLabel)
            {
                ((LinkLabel)sender).Image = Resources.clearFilter_pressed;
            }
        }

        private void llClearContractsFilter_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is LinkLabel)
            {
                ((LinkLabel)sender).Image = Resources.clearFilter_default;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                Contract contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    Tag = contract.Id;
                }
                break;
            }
        }

        private void dgvContracts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvContracts.SelectedRows)
            {
                Contract contract = row.DataBoundItem as Contract;
                if (contract != null)
                {
                    Tag = contract.Id;
                }
                DialogResult = DialogResult.OK;
                Close();
                break;
            }
        }

        private void dgvContracts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    {
                        foreach (DataGridViewRow row in dgvContracts.SelectedRows)
                        {
                            Contract contract = row.DataBoundItem as Contract;
                            if (contract != null)
                            {
                                Tag = contract.Id;
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

        private void dgvContracts_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvContracts.Rows)
            {
                if (row.Selected)
                {
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = Color.Empty;
                    row.DefaultCellStyle.SelectionForeColor = Color.Empty;
                }
            }
        }

        private void dgvContracts_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvContracts.Rows)
            {
                if (row.Selected)
                {
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveCaption;
                    row.DefaultCellStyle.SelectionForeColor = SystemColors.InactiveCaptionText;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
            }
        }

        #endregion
    }
}