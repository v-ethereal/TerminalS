using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.AdministrationConsole.Properties;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class EditServiceRecordForm : Form
    {
        #region Constants

        private const int WIDTH = 128;
        private const int HEIGHT = 128;

        #endregion

        #region Fields

        private readonly IServicesService servicesService = AppRuntime.Instance.Container.GetComponent<IServicesService>();

        private readonly Service serviceRecord;

        #endregion

        #region Constructors

        public EditServiceRecordForm()
        {
            InitializeComponent();
        }

        public EditServiceRecordForm(int id)
        {
            InitializeComponent();

            serviceRecord = servicesService.GetServiceRecord(id);

            tbxName.Text = serviceRecord.Name;
            tbxDescription.Text = serviceRecord.Description;
            cbxIsRental.Checked = serviceRecord.IsRental;
            cbxIsActive.Checked = serviceRecord.IsActive;
            tb_1SCode.Text = serviceRecord.Service1SCode;
        	checkBox_parkingPerHour.Checked = serviceRecord.IsParkingPerHour;
        	checkBox_parkingWithoutTime.Checked = serviceRecord.IsParkingWithoutTime;
        	checkBox_otherServices.Checked = serviceRecord.IsOther;
            checkBox_usePlaceNumber.Checked = serviceRecord.UsePlaceNumber;
            checkBox_usePlaceNumber.Enabled = checkBox_otherServices.Checked;

            if (serviceRecord.Picture != null)
            {
                using (var stream = new MemoryStream(serviceRecord.Picture))
                {
                    picture.Image = Image.FromStream(stream);
                }
            }
        }

        #endregion

        #region Private Methods

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            servicesService.UpdateServiceRecord(serviceRecord.Id,
                                                tbxName.Text,
                                                tbxDescription.Text, 
												cbxIsRental.Checked, 
												cbxIsActive.Checked,
												checkBox_parkingPerHour.Checked,
												checkBox_parkingWithoutTime.Checked,
												checkBox_otherServices.Checked,
                                                checkBox_usePlaceNumber.Checked,
                                                GetImage(), 
												tb_1SCode.Text
			);
            Close();
        }

        private void tbxName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                errorProvider.SetError(tbxName, "Поле обязательно к заполнению");
                e.Cancel = true;
            }
            else
            {
                if (serviceRecord.Name != tbxName.Text.Trim()
                    && servicesService.CheckServiceExistance(tbxName.Text.Trim()))
                {
                    errorProvider.SetError(tbxName, "Услуга с таким именем существует");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(tbxName, string.Empty);
                }
            }
        }

        private void tbxDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxDescription.Text))
            {
                errorProvider.SetError(tbxDescription, "Поле обязательно к заполнению");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbxDescription, string.Empty);
            }
        }

        private byte[] GetImage()
        {
            byte[] buffer = null;
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                byte[] imageData;
                using (Stream stream = openFileDialog.OpenFile())
                {
                    imageData = new byte[stream.Length];
                    stream.Read(imageData, 0, int.Parse(stream.Length.ToString()));
                }

                if (imageData.Length > 0)
                {
                    using (var stream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        Image.GetThumbnailImageAbort myCallback = ThumbnailCallback;
                        Image thumbImage = image.GetThumbnailImage(WIDTH, HEIGHT, myCallback, IntPtr.Zero);

                        using (var memoryStream = new MemoryStream())
                        {
                            thumbImage.Save(memoryStream, ImageFormat.Png);
                            stream.Flush();
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            buffer = new byte[memoryStream.Length];
                            memoryStream.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
            return buffer;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }

        private void picture_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                byte[] imageData;
                using (Stream stream = openFileDialog.OpenFile())
                {
                    imageData = new byte[stream.Length];
                    stream.Read(imageData, 0, int.Parse(stream.Length.ToString()));
                }

                if (imageData.Length > 0)
                {
                    using (var stream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        Image.GetThumbnailImageAbort myCallback = ThumbnailCallback;

                        Image thumbImage = image.GetThumbnailImage(WIDTH, HEIGHT, myCallback, IntPtr.Zero);

                        using (var memoryStream = new MemoryStream())
                        {
                            thumbImage.Save(memoryStream, ImageFormat.Png);
                            stream.Flush();
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            picture.Image = Image.FromStream(memoryStream);
                        }
                    }
                }
            }
        }

        private void btRestoreImage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Установить иконку по умолчанию?", "Вопрос",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                picture.Image = Resources.question;
            }
        }

        #endregion

        private void cbxIsRental_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxIsRental.Checked)
            {
                checkBox_parkingPerHour.Checked = false;
                checkBox_otherServices.Checked = false;
                checkBox_parkingWithoutTime.Checked = false;
            }
        }

        private void checkBox_parkingPerHour_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_parkingPerHour.Checked)
            {
                cbxIsRental.Checked = false;
                checkBox_otherServices.Checked = false;
                checkBox_parkingWithoutTime.Checked = false;
            }
        }

        private void checkBox_otherServices_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_otherServices.Checked)
            {
                cbxIsRental.Checked = false;
                checkBox_parkingPerHour.Checked = false;
                checkBox_parkingWithoutTime.Checked = false;
                checkBox_usePlaceNumber.Enabled = true;
            }
            else
            {
                checkBox_usePlaceNumber.Enabled = false;
            }
        }

        private void checkBox_parkingWithoutTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_parkingWithoutTime.Checked)
            {
                cbxIsRental.Checked = false;
                checkBox_otherServices.Checked = false;
                checkBox_parkingPerHour.Checked = false;
            }
        }
    }
}