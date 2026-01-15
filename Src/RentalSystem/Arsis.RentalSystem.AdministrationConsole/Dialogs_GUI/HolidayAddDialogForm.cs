using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Arsis.RentalSystem.AdministrationConsole.Dialogs_GUI
{
    public partial class HolidayAddDialogForm : Form
    {
        private List<SimpleDateTimeItem> datesList;

        public HolidayAddDialogForm()
        {
            InitializeComponent();
            defaultInitialize();
        }

        private void defaultInitialize()
        {
            datesList = new List<SimpleDateTimeItem>();
            bindingSource.DataSource = datesList;
            dgv_Dates.DataSource = bindingSource;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            SimpleDateTimeItem item = new SimpleDateTimeItem(dtpNewDate.Value);
            if (!datesList.Exists(date => item.DateValue == date.DateValue))
            {
                bindingSource.Add(item);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if(dgv_Dates.SelectedRows.Count > 0)
            {
                bindingSource.Remove(dgv_Dates.SelectedRows[0].DataBoundItem);
            }
        }

        public List<DateTime> Dates
        {
            get
            {
                List<DateTime> dtList = new List<DateTime>();
                datesList.ForEach(date => dtList.Add(date.DateValue));
                return dtList;
            }
        }
    }
}
