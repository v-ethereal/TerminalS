using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using Microsoft.Reporting.WinForms;
using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class ReportForm : Form
    {
        #region Constants

        private const string ERROR_MSG = "Ошибка";
        private const string ERROR_TEXT = "Файл отчета не найден";

        #endregion

        #region Fields

        private readonly IFeeService feeService = AppRuntime.Instance.Container.GetComponent<IFeeService>();

        #endregion

        #region Constructors

        public ReportForm(ReportTypes report, IEnumerable<ReportParameter> parameters)
        {
            InitializeComponent();
          


            try
            {
            	DateTime? from = null;
                DateTime? to = null;
                string contractNumber = null;
                string client = null;
                var paramEnum = parameters.GetEnumerator();
                while (paramEnum.MoveNext())
                {
                    var param = paramEnum.Current;
                    if (param != null)
                    {
                    	DateTime dt;
                    	switch (param.Name)
                        {
                            case ReportParameterNames.DATE_FROM:
                                if (DateTime.TryParse(param.Values[0], out dt))
                                {
                                    from = dt;
                                }
                                break;
                            case ReportParameterNames.DATE_TO:
                                if (DateTime.TryParse(param.Values[0], out dt))
                                {
                                    to = dt;
                                }
                                break;
                            case ReportParameterNames.CONTRACT_NUMBER:
                                contractNumber = param.Values[0];
                                break;
                            case ReportParameterNames.CLIENT:
                                client = param.Values[0];
                                break;
                            default:
                                break;
                        }
                    }
                }
                

                switch (report)
                {
                    case ReportTypes.NotPaidReport:
                        {
							Text += " о неоплаченных местах за период";

                            if (File.Exists(".\\Reports\\NotPaidReport.rdlc"))
                            {
                                reportViewer.LocalReport.ReportPath = ".\\Reports\\NotPaidReport.rdlc";
                            }
                            else
                            {
                                throw new FileNotFoundException(ERROR_TEXT);
                            }
                            if (from == null)
                            {
                                throw new ApplicationException("Не задана дата начала");
                            }
                            if (to == null)
                            {
                                throw new ApplicationException("Не задана дата конца");
                            }

                        reportViewer.LocalReport.SetParameters(parameters);
                            reportViewer.LocalReport.DataSources.Add(
                                    new ReportDataSource("Arsis_RentalSystem_AdministrationConsole_DAL_PayLogRecord",
                                                         feeService.GetNotPaidRentalFees(from.Value, to.Value)));
                            break;
                        }
                    case ReportTypes.PaidReport:
                        {
							Text += " об оплаченных суммах за период";

                            if (File.Exists(".\\Reports\\PaidReport.rdlc"))
                            {
                                reportViewer.LocalReport.ReportPath = ".\\Reports\\PaidReport.rdlc";
                            }
                            else
                            {
                                throw new FileNotFoundException(ERROR_TEXT);
                            }
                            if (from == null)
                            {
                                throw new ApplicationException("Не задана дата начала");
                            }
                            if (to == null)
                            {
                                throw new ApplicationException("Не задана дата конца");
                            }

                            from = new DateTime(from.Value.Year, from.Value.Month, from.Value.Day, 0, 0, 0);
                            to = new DateTime(to.Value.Year, to.Value.Month, to.Value.Day, 23, 59, 59);
                            reportViewer.LocalReport.SetParameters(parameters);
                            reportViewer.LocalReport.DataSources.Add(
                                    new ReportDataSource("Arsis_RentalSystem_AdministrationConsole_DAL_PayLogRecord",
                                                         feeService.GetPaidRentalFees(from.Value, to.Value)));
                            break;
                        }
                    case ReportTypes.NotTransferedPaymentReport:
                        {
							Text += " по не прошедшим суммам за период";

                            if (File.Exists(".\\Reports\\NotTransferedPaymentReport.rdlc"))
                            {
                                reportViewer.LocalReport.ReportPath = ".\\Reports\\NotTransferedPaymentReport.rdlc";
                            }
                            else
                            {
                                throw new FileNotFoundException(ERROR_TEXT);
                            }
                            if (from == null)
                            {
                                throw new ApplicationException("Не задана дата начала");
                            }
                            if (to == null)
                            {
                                throw new ApplicationException("Не задана дата конца");
                            }

                            reportViewer.LocalReport.SetParameters(parameters);
                            reportViewer.LocalReport.DataSources.Add(
                                    new ReportDataSource("Arsis_RentalSystem_AdministrationConsole_DAL_PayLogRecord",
                                                         feeService.GetNotTransferedPayment(from.Value, to.Value)));
                            break;
                        }
                    case ReportTypes.PivotTableReport:
                        {
							Text += " со сводной таблицей оплат за период";

                            if (File.Exists(".\\Reports\\PivotTableReport.rdlc"))
                            {
                                reportViewer.LocalReport.ReportPath = ".\\Reports\\PivotTableReport.rdlc";
                            }
                            else
                            {
                                throw new FileNotFoundException(ERROR_TEXT);
                            }
                            if (from == null)
                            {
                                throw new ApplicationException("Не задана дата начала");
                            }
                            if (to == null)
                            {
                                throw new ApplicationException("Не задана дата конца");
                            }

                            reportViewer.LocalReport.SetParameters(parameters);
                            reportViewer.LocalReport.DataSources.Add(
                                    new ReportDataSource("Arsis_RentalSystem_AdministrationConsole_DAL_PayLogRecord",
                                                         feeService.GetRentalFees(from.Value, to.Value)));
                            break;
                        }
                    case ReportTypes.ContractStateReport:
                        {
							Text += " по состоянию договоров";

                            if (File.Exists(".\\Reports\\ContractStateReport.rdlc"))
                            {
                                reportViewer.LocalReport.ReportPath = ".\\Reports\\ContractStateReport.rdlc";
                            }
                            else
                            {
                                throw new FileNotFoundException(ERROR_TEXT);
                            }
                            if (from == null)
                            {
                                throw new ApplicationException("Не задана дата начала");
                            }
                            if (to == null)
                            {
                                throw new ApplicationException("Не задана дата конца");
                            }

                            reportViewer.LocalReport.SetParameters(parameters);
                            reportViewer.LocalReport.DataSources.Add(
                                    new ReportDataSource("Arsis_RentalSystem_AdministrationConsole_DAL_ContractStateInformation",
                                                         feeService.GetContractState(from.Value, to.Value, contractNumber, client)));
                            break;
                        }
                    case ReportTypes.PaidForServices:
                        {
							Text += " по платежам за услуги за период";

                            if (File.Exists(".\\Reports\\PaidForServices.rdlc"))
                            {
                                reportViewer.LocalReport.ReportPath = ".\\Reports\\PaidForServices.rdlc";
                            }
                            else
                            {
                                throw new FileNotFoundException(ERROR_TEXT);
                            }
                            if (from == null)
                            {
                                throw new ApplicationException("Не задана дата начала");
                            }
                            if (to == null)
                            {
                                throw new ApplicationException("Не задана дата конца");
                            }

                            DateTime fromD = from.Value;
                            fromD = new DateTime(fromD.Year, fromD.Month, fromD.Day);
                            DateTime toD = to.Value;
                            toD = new DateTime(toD.Year, toD.Month, toD.Day, 23, 59, 59, 999);
                            reportViewer.LocalReport.SetParameters(parameters);
                            reportViewer.LocalReport.DataSources.Add(
                                    new ReportDataSource("Arsis_RentalSystem_AdministrationConsole_DAL_ServicePayLogRecord",
                                                         feeService.GetServiceFees(fromD, toD)));
                        }
                        break;
					case ReportTypes.ParkingPaysReport:
                		{
							Text += " по платежам за парковку";

							if (File.Exists(".\\Reports\\ParkingPaysReport.rdlc"))
							{
								reportViewer.LocalReport.ReportPath = ".\\Reports\\ParkingPaysReport.rdlc";
							}
							else
							{
								throw new FileNotFoundException(ERROR_TEXT);
							}
							if (from == null)
							{
								throw new ApplicationException("Не задана дата начала");
							}
							if (to == null)
							{
								throw new ApplicationException("Не задана дата конца");
							}

							reportViewer.LocalReport.SetParameters(parameters);

							IParkingService parkingService = AppRuntime.Instance.Container.GetComponent<IParkingService>();

							reportViewer.LocalReport.DataSources.Add(
									new ReportDataSource("Arsis_RentalSystem_AdministrationConsole_DAL_ParkingTicketInfo",
                                                         parkingService.GetParkingPays(from.Value, to.Value)));

							break;
                		}
						

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : ""), ERROR_MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    	public override sealed string Text
    	{
    		get { return base.Text; }
    		set { base.Text = value; }
    	}

    	private void ReportForm_Load(object sender, EventArgs e)
        {

            reportViewer.RefreshReport();
        }

        #endregion


        private void reportViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
        }
    }
}