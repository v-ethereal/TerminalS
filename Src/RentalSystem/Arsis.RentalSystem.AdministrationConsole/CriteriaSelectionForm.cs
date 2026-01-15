using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using Microsoft.Reporting.WinForms;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class CriteriaSelectionForm : Form
    {
        #region Fields

        private readonly IContractService contractService = AppRuntime.Instance.Container.GetComponent<IContractService>();

        #endregion
        
        #region Constructors

        public CriteriaSelectionForm()
        {
            InitializeComponent();
            cpContract.ContractService = contractService;
            dprFromDate.Value = GetFirstDayOfMonth();
            dprToDate.Value = GetLastDayOfMonth();
            cbxContractors.DataSource = contractService.GetContractorsFilter();
        }

        #endregion

        #region Private Methods

        private void btnNext_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var parameters = new List<ReportParameter> {new ReportParameter(ReportParameterNames.DATE_FROM, dprFromDate.Value.ToString()),
                new ReportParameter(ReportParameterNames.DATE_TO, dprToDate.Value.ToString()),
                new ReportParameter(ReportParameterNames.CONTRACT_NUMBER, cpContract.ContractNumber),
                new ReportParameter(ReportParameterNames.CLIENT, 
                    cbxContractors.SelectedIndex == 0 || cbxContractors.SelectedValue == null ? null : cbxContractors.SelectedValue.ToString())};
            var reportForm = new ReportForm(ReportTypes.ContractStateReport, parameters);
            reportForm.ShowDialog(this);
            Cursor = Cursors.Default;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private static DateTime GetFirstDayOfMonth()
        {
            DateTime now = DateTime.Now;
            return new DateTime(now.Year, now.Month, 1, 0, 0, 0, 0);
        }

        private static DateTime GetLastDayOfMonth()
        {
            DateTime now = DateTime.Now;
            return new DateTime(now.Year, now.Month, 1, 0, 0, 0, 0).AddMonths(1).AddDays(-1);
        }

        private void cpContract_ValueChanged(object sender, ValueChangedArgs args)
        {

        }
        
        #endregion

        private void dprFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dprFromDate.Value > dprToDate.Value)
            {
                dprToDate.Value = dprFromDate.Value;
            }
        }

        private void dprToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dprToDate.Value < dprFromDate.Value)
            {
                dprFromDate.Value = dprToDate.Value;
            }
        }
    }
}
