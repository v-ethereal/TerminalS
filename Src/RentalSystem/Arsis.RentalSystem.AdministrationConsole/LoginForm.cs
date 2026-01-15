using System;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.AdministrationConsole.Properties;
using Arsis.RentalSystem.Core.Bll;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class LoginForm : Form
    {
        private readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                bool canLogin =  userService.CanLogin(tbxLogin.Text.Trim());
                
                if (canLogin)
                {
                    if (userService.Logon(tbxLogin.Text.Trim(), tbxPassword.Text.Trim()))
                    {
                        DialogResult = DialogResult.OK;

                        try
                        {
                            //Сохраняем логин после успешной авторизации в настройки пользователя
                            Settings.Default.LoginName = tbxLogin.Text.Trim();
                            Settings.Default.Save();
                        }
                        catch {}

                        Close();
                    }
                    else
                    {
                        MessageBox.Show(CommonSR.AuthorizationError_WrongLoginPassword,
                                        CommonSR.AuthorizationError,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        tbxPassword.Clear();
                    }
                }
                else
                {
                    MessageBox.Show(CommonSR.AuthorizationError_AccessDenied,
                                    CommonSR.AuthorizationError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    tbxPassword.Clear();
                }
            }
            catch
            {
                MessageBox.Show(CommonSR.AuthorizationError_CannotLogin,
                                   CommonSR.AuthorizationError,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Восстанавливаем логин, сохраненный после успешной авторизации в настройки пользователя
                tbxLogin.Text = Settings.Default.LoginName ?? "";
            }
            catch { }

            if (tbxLogin.Text.Trim().Length > 0)
            {
                tbxPassword.Focus();
            }
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            if (tbxLogin.Text.Trim().Length > 0)
            {
                tbxPassword.Focus();
            }
        }
    }
}
