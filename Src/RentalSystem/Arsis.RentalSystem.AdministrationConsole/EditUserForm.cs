using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class EditUserForm : Form
    {
        #region Fields

        private readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();
        private readonly User user;
        private readonly Regex passwordValidator = new Regex("[A-z0-9]{4,16}", RegexOptions.Compiled);

        #endregion

        #region Constructors

        public EditUserForm()
        {
            InitializeComponent();
        }

        public EditUserForm(string login)
        {
            InitializeComponent();
            user = userService.GetUser(login);
            tbxName.Text = user.Name;
            tbxLogin.Text = user.Login;
            cbxIsActive.Checked = user.IsActive;
            cbxIsActive.Enabled = (userService.CurrentUser.Id != user.Id);
            tbxPassword.Text = string.Empty;
        }

        #endregion

        #region Private Methods

        private void tbxLogin_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxLogin.Text))
            {
                errorProvider.SetError(tbxLogin, "Поле обязательно к заполнению");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbxLogin, string.Empty);
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
                userService.EditUser(user.Login, tbxLogin.Text, tbxPassword.Text, tbxName.Text, cbxIsActive.Checked);
                Close();
            }
        }

        #endregion

        private void tbxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxPassword.Text))
            {
                if (!passwordValidator.IsMatch(tbxPassword.Text.Trim()))
                {
                    errorProvider.SetError(tbxPassword, "Пароль должен содержать только цифры и буквы латинского языка и быть длинной от 4 до 16 символов");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(tbxPassword, string.Empty);
                }
            }
        }
    }
}