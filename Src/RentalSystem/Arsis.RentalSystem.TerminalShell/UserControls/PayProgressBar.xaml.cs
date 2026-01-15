using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell.UserControls
{
    /// <summary>
    /// Interaction logic for PayProgressBar.xaml
    /// </summary>
    public partial class PayProgressBar
    {
        internal enum State { FullPaid, PartialPaid, NotPaid, Holiday }
        internal enum DaysOfWeek { Пн = 0, Вт, Ср, Чт, Пт, Сб, Вс }
        private readonly IRentalFeeService rentalFeeService = AppRuntime.Instance.Container.GetComponent<IRentalFeeService>();
        private decimal totalSum;
        private decimal currentDayPaidSum; 
        private int currentDayCount;
        private DateTime payDate;
        private List<PayDateInformation> payDatesInformation;

        public PayProgressBar()
        {
            InitializeComponent();
        }

        public void Initialize(string contractNumber, string placeNumber)
        {
            payDatesInformation = rentalFeeService.GetPayDates(contractNumber, placeNumber);

            //First day of the payable period
            if (rentalFeeService.IsFirstBelongDate(contractNumber, placeNumber, payDatesInformation[currentDayCount].Date))
            {
                if (payDatesInformation[currentDayCount].IsPartialyPaid)
                {
                    AddNewDate(payDatesInformation[currentDayCount].Date, State.PartialPaid);
                    double progress = 1;
                    if (payDatesInformation[currentDayCount].Rate != 0)
                    {
                        progress = Convert.ToDouble(payDatesInformation[currentDayCount].PaidAmount / payDatesInformation[currentDayCount].Rate);
                    }
                    UpdateDate(payDatesInformation[currentDayCount].Date, State.PartialPaid, progress);
                }
                else
                {
                    AddNewDate(payDatesInformation[currentDayCount].Date, State.NotPaid);
                }
            }
            else //Not first day of payable period
            {
                //Show first day as HOLIDAY or FULLPAID
                if (rentalFeeService.IsHoliday(contractNumber, placeNumber, payDatesInformation[currentDayCount].Date.AddDays(-1)))
                {
                    AddNewDate(payDatesInformation[currentDayCount].Date.AddDays(-1), State.Holiday);
                }
                else
                {
                    AddNewDate(payDatesInformation[currentDayCount].Date.AddDays(-1), State.FullPaid);
                }

                //Show second day as PARTIALY or NOTPAID
                if (payDatesInformation[currentDayCount].IsPartialyPaid)
                {
                    AddNewDate(payDatesInformation[currentDayCount].Date, State.PartialPaid);
                    double progress = 1;
                    if (payDatesInformation[currentDayCount].Rate != 0)
                    {
                        progress = Convert.ToDouble(payDatesInformation[currentDayCount].PaidAmount / payDatesInformation[currentDayCount].Rate);
                    }
                    UpdateDate(payDatesInformation[currentDayCount].Date, State.PartialPaid, progress);
                }
                else
                {
                    AddNewDate(payDatesInformation[currentDayCount].Date, State.NotPaid);
                }
            }

            //At this point we have 6(if period beginning) or 5 days to show
            if (payDatesInformation[currentDayCount].IsPartialyPaid)
            {
                totalSum = payDatesInformation[currentDayCount].PaidAmount;
            }

            payDate = payDatesInformation[currentDayCount].Date;
            
            while (Workspace.Children.Count < 7)
            {
                payDate = payDate.AddDays(1);
                bool found = false;
                foreach (PayDateInformation information in payDatesInformation)
                {
                    if (information.Date.Date == payDate.Date)
                    {
                        found = true;
                    }
                    if (information.Date.Date > payDate.Date)
                    {
                        break;
                    }
                }

                if (!found)
                {
                    AddNewDate(payDate, State.Holiday);
                }
                else
                {
                    AddNewDate(payDate, State.NotPaid);
                }
            }
        }

        public void Update(decimal moneyAmmount)
        {
            totalSum += moneyAmmount;
            if (totalSum < (payDatesInformation[currentDayCount].Rate - currentDayPaidSum))
            {
                double progress = 1;
                if (payDatesInformation[currentDayCount].Rate != 0)
                {
                    progress = Convert.ToDouble((totalSum + currentDayPaidSum)/ payDatesInformation[currentDayCount].Rate);
                }

                UpdateDate(payDatesInformation[currentDayCount].Date, State.PartialPaid, progress);
                currentDayPaidSum += totalSum;
                totalSum = 0;
            }
            else
            {
                //oleg: Here seems to be an error with equaling to 0
                while (totalSum > 0)
                {
                    if (totalSum > (payDatesInformation[currentDayCount].Rate - currentDayPaidSum))
                    {
                        UpdateDate(payDatesInformation[currentDayCount].Date, State.FullPaid);

                        totalSum -= (payDatesInformation[currentDayCount].Rate - currentDayPaidSum);
                        currentDayPaidSum = payDatesInformation[currentDayCount].Rate;

                        if (currentDayCount == payDatesInformation.Count - 1)
                        {
                            break;
                        }
                    }
                    else
                    {
                        double progress = 1;
                        if (payDatesInformation[currentDayCount].Rate != 0)
                        {
                            progress = Convert.ToDouble((currentDayPaidSum + totalSum)/ payDatesInformation[currentDayCount].Rate);
                        }

                        if ((currentDayPaidSum + totalSum) == payDatesInformation[currentDayCount].Rate)
                        {
                            UpdateDate(payDatesInformation[currentDayCount].Date, State.FullPaid);
                        }
                        else
                        {
                            UpdateDate(payDatesInformation[currentDayCount].Date, State.PartialPaid, progress);
                        }

                        currentDayPaidSum += totalSum;

                        totalSum = 0;
                    }

                    if (totalSum > 0 && currentDayCount < payDatesInformation.Count - 1)
                    {
                        currentDayCount++;
                        currentDayPaidSum = 0;
                    }
                }
            }
        }
        private void UpdateDate(DateTime date, State state)
        {
            UpdateDate(date, state, 1);
        }

        private void UpdateDate(DateTime date, State state, double progress)
        {
            bool moveNext = true;
            foreach (Border border in Workspace.Children)
            {
                if (border != null)
                {
                    if ((DateTime)border.Tag == date)
                    {
                        moveNext = false;
                        switch (state)
                        {
                            case State.FullPaid:
                                border.Background = (Brush)FindResource("FullPaidBrush");
                                break;
                            case State.PartialPaid:
                                LinearGradientBrush brush = (LinearGradientBrush)FindResource("PartialyPaidBrush");
                                brush.GradientStops[0].Offset = progress;
                                border.Background = brush;
                                break;
                            case State.NotPaid:
                                border.Background = (Brush)FindResource("NotPaidBrush");
                                break;
                            case State.Holiday:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("state");
                        }
                        break;
                    }
                }
            }

            if (moveNext)
            {
                Workspace.Children.Clear();
                AddNewDate(date, state);
                payDate = payDate.AddDays(1);
                while (Workspace.Children.Count < 7)
                {
                    payDate = payDate.AddDays(1);
                    bool found = false;
                    foreach (PayDateInformation information in payDatesInformation)
                    {
                        if (information.Date.Date == payDate.Date)
                        {
                            found = true;
                        }
                        if (information.Date.Date > payDate.Date)
                        {
                            break;
                        }
                    }
                    if (!found)
                    {
                        AddNewDate(payDate, State.Holiday);
                    }
                    else
                    {
                        AddNewDate(payDate, State.NotPaid);
                    }
                }
            }
        }

        private void AddNewDate(DateTime date, State state)
        {
            //Here is available opportunity for all-time Russian culture
            TextBlock textBlock = new TextBlock
            {
                Text = string.Format("{0} {1}", date.ToString("ddd", CultureInfo.GetCultureInfo("ru-RU")), date.ToShortDateString()),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 18
            };

            Border border = new Border();
            border.Width = 125;
            border.Height = 75;
            border.BorderThickness = new Thickness(2);
            border.Margin = new Thickness(10);
            border.CornerRadius = new CornerRadius(5);
            border.BorderBrush = Brushes.Black;
            border.Child = textBlock;
            border.Tag = date.Date;
            switch (state)
            {
                case State.FullPaid:
                    border.Background = (Brush)FindResource("FullPaidBrush");
                    break;
                case State.PartialPaid:
                    border.Background = (Brush)FindResource("PartialyPaidBrush");
                    break;
                case State.NotPaid:
                    border.Background = (Brush)FindResource("NotPaidBrush");
                    break;
                case State.Holiday:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state");
            }
            Workspace.Children.Add(border);
        }
    }
}
