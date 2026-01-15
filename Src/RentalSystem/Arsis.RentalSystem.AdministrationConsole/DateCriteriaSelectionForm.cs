using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Arsis.RentalSystem.Core.Domain;

using Microsoft.Reporting.WinForms;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class DateCriteriaSelectionForm : Form
    {
        #region Fields

        private readonly ReportTypes reportType;

        #endregion

        #region Constructors

        public DateCriteriaSelectionForm()
        {
            InitializeComponent();
            dprFromDate.Value = GetFirstDayOfMonth();
            dprToDate.Value = GetLastDayOfMonth();
        }

        public DateCriteriaSelectionForm(ReportTypes reportType)
        {
            InitializeComponent();
            this.reportType = reportType;
            dprFromDate.Value = GetFirstDayOfMonth();
            dprToDate.Value = GetLastDayOfMonth();

            if (reportType == ReportTypes.ParkingPaysReport)
            {
                dprFromDate.Format = dprToDate.Format = DateTimePickerFormat.Custom;
                dprFromDate.CustomFormat = dprToDate.CustomFormat = @"dd.MM.yyyy HH:mm";
            }
        }

        #endregion

        #region Private Methods

        private void btnNext_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var parameters = new List<ReportParameter> {
                new ReportParameter(ReportParameterNames.DATE_FROM, dprFromDate.Value.ToString()), 
                new ReportParameter(ReportParameterNames.DATE_TO, dprToDate.Value.ToString())};
            var reportForm = new ReportForm(reportType, parameters);
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
