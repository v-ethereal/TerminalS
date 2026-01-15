using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.UserControls
{
    public partial class DatesViewer : UserControl
    {
        public delegate List<DateTime> GetHolidaysDelegate();
        public delegate BindingListView<HolidayDictionary> GetHolidayDictionariesDelegate();
        public delegate int OperationWithHolidayDelegate(IList<DateTime> holidayDates);

        public event GetHolidaysDelegate GetHolidaysRequest;
        public event GetHolidayDictionariesDelegate GetHolidayDictionariesRequest;
        public event EventHandler AddHoliday;
        public event EventHandler DeleteHoliday;

        public event EventHandler SelectionChanged;

        private bool isCalendarMode;
        private int lastHolidayId;

        public DatesViewer()
        {
            InitializeComponent();
        }

        public void DefaultInitialize()
        {
            dgvHolidays.Enter += dgvHolidays_Enter;
            dgvHolidays.Leave += dgvHolidays_Leave;
            dgvHolidays.KeyDown += dgvHolidays_KeyDown;
            dgvHolidays.SelectionChanged += dgvHolidays_SelectionChanged;
            dgvHolidays.AutoGenerateColumns = false;

            LastHolidayId = -1;
            isCalendarMode = false;
            setSplitterMode(isCalendarMode);
        }

        private void setSplitterMode(bool isCal)
        {
            if (isCal)
            {
                bt_ChooseSplitMode.Text = ">> Перейти к режиму списка";
                splitContainer.SplitterDistance = 0;
            }
            else
            {
                bt_ChooseSplitMode.Text = "<< Перейти к режиму календаря";
                splitContainer.SplitterDistance = splitContainer.Width;
            }

            refreshHolidaysList(lastHolidayId, isCal);
        }

        private void refreshHolidaysList(int id, bool isCal)
        {
            if (isCal)
            {
                mcHolidays.AnnuallyBoldedDates = GetHolidaysRequest().ToArray();
            }
            else
            {
                HolidayDictionary holidayDictionary = null;
                if (id == -1)
                {
                    foreach (DataGridViewRow row in dgvHolidays.SelectedRows)
                    {
                        holidayDictionary = row.DataBoundItem as HolidayDictionary;
                        if (holidayDictionary != null)
                        {
                            break;
                        }
                    }
                }

                updateDgvDataSource();

                HolidaysFilterExtender.RefreshFilters();
                if (columnHolidayDate != null)
                {
                    if (dgvHolidays.Columns != null)
                    {
                        dgvHolidays.Sort(dgvHolidays.Columns[columnHolidayDate.Name], ListSortDirection.Ascending);
                    }
                }

                if (id == -1)
                {
                    foreach (DataGridViewRow row in dgvHolidays.Rows)
                    {
                        HolidayDictionary actual = row.DataBoundItem as HolidayDictionary;
                        if (holidayDictionary != null
                            && actual != null)
                        {
                            if (holidayDictionary.Id == actual.Id)
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgvHolidays.Rows)
                    {
                        HolidayDictionary actual = row.DataBoundItem as HolidayDictionary;
                        if (actual != null)
                        {
                            if (id == actual.Id)
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                }
                dgvHolidays.Focus();
            }
        }

        private void updateDgvDataSource()
        {
            HolidaysFilterExtender.DataGridView = null;
            dgvHolidays.DataSource = getHolidayDictionariesRequest();
            HolidaysFilterExtender.DataGridView = dgvHolidays;
        }

        private void bt_ChooseSplitMode_Click(object sender, EventArgs e)
        {
            isCalendarMode = !isCalendarMode;
            setSplitterMode(isCalendarMode);
        }

        private void dgvHolidays_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHolidays.Rows)
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

        private void dgvHolidays_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHolidays.Rows)
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

        private void dgvHolidays_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 46:
                    {
                        foreach (DataGridViewRow row in dgvHolidays.SelectedRows)
                        {
                            HolidayDictionary holidayDictionary = row.DataBoundItem as HolidayDictionary;
                            if (holidayDictionary != null)
                            {
                                if (
                                    MessageBox.Show(this,
                                                    string.Format("Выходной день '{0}' будет удален",
                                                                  holidayDictionary.Date.ToShortDateString()),
                                                    "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) ==
                                    DialogResult.OK)
                                {
                                    tsmi_Delete_Click(sender, e);
                                }
                            }
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

        private void dgvHolidays_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHolidays.SelectedRows.Count > 0)
            {
                updateContextMenu(true);
                SelectionChanged(sender, e);
            }
            else
            {
                updateContextMenu(false);
                SelectionChanged(sender, null);
            }
        }

        private void updateContextMenu(bool isEnabled)
        {
            tsmi_Delete.Enabled = isEnabled;
        }

        public List<DateTime> RemoveHoliday()
        {
            List<DateTime> returnList = new List<DateTime>();
            if (isCalendarMode)
            {
                if (
                    MessageBox.Show(this,
                                    string.Format("Выходной день '{0}' будет удален",
                                                  mcHolidays.SelectionStart.ToShortDateString()), "Внимание",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    returnList.Add(mcHolidays.SelectionStart);
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvHolidays.SelectedRows)
                {
                    HolidayDictionary holidayDictionary = row.DataBoundItem as HolidayDictionary;
                    if (holidayDictionary != null)
                    {
                        if (
                            MessageBox.Show(this,
                                            string.Format("Выходной день '{0}' будет удален",
                                                          holidayDictionary.Date.ToShortDateString()), "Внимание",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            returnList.Add(holidayDictionary.Date);
                        }
                    }
                    break;
                }
            }

            return returnList;
        }

        public int LastHolidayId
        {
            set
            {
                lastHolidayId = value;
                refreshHolidaysList(lastHolidayId, isCalendarMode);
            }
        }

        public void RefreshList()
        {
            RefreshList(-1);
        }

        public void RefreshList(int id)
        {
            if (isCalendarMode)
            {
                refreshHolidaysList(-1, isCalendarMode);
            }
            else
            {
                refreshHolidaysList(id, isCalendarMode);
            }
        }

        private BindingListView<HolidayDictionary> getHolidayDictionariesRequest()
        {
            if (GetHolidayDictionariesRequest != null)
            {
                return GetHolidayDictionariesRequest();
            }

            return null;
        }

        private void tsmi_Add_Click(object sender, EventArgs e)
        {
            if (AddHoliday != null)
            {
                AddHoliday(sender, e);
            }
        }

        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            if (DeleteHoliday != null)
            {
                DeleteHoliday(sender, e);
            }
        }
    }
}
