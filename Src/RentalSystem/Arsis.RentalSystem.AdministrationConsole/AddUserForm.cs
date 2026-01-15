using System;
using System.ComponentModel;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using System.Text.RegularExpressions;
using Arsis.RentalSystem.Core.Bll;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class AddUserForm : Form
    {
        #region Fields

        private readonly Regex passwordValidator = new Regex("[A-z0-9]{4,16}", RegexOptions.Compiled);
        readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();

        #endregion

        #region Constructors

        public AddUserForm()
        {
            InitializeComponent();
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
                if (userService.CheckUserExistance(tbxLogin.Text))
                {
                    errorProvider.SetError(tbxLogin, "Пользователь с таким логином уже существует");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(tbxLogin, string.Empty);
                }
            }
        }

        private void tbxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPassword.Text))
            {
                errorProvider.SetError(tbxPassword, "Поле обязательно к заполнению");
                e.Cancel = true;
            }
            else
            {
                if (!passwordValidator.IsMatch(tbxPassword.Text.Trim()))
                {
                    errorProvider.SetError(tbxPassword, "Пароль должен содержать только цифры и буквы латинского языка");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(tbxPassword, string.Empty);
                }
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
                Tag = userService.AddUser(tbxLogin.Text, tbxPassword.Text, tbxName.Text, cbxIsActive.Checked, UserServiceHelper.GetNewAccessCode());
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Validate();
            }
        }

        #endregion
        
    }
}