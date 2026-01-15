namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class EditUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbOtherServiceFields = new System.Windows.Forms.GroupBox();
            this.cbxIsActive = new System.Windows.Forms.CheckBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbOtherServiceFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOtherServiceFields
            // 
            this.gbOtherServiceFields.Controls.Add(this.cbxIsActive);
            this.gbOtherServiceFields.Controls.Add(this.tbxPassword);
            this.gbOtherServiceFields.Controls.Add(this.tbxName);
            this.gbOtherServiceFields.Controls.Add(this.lblName);
            this.gbOtherServiceFields.Controls.Add(this.tbxLogin);
            this.gbOtherServiceFields.Controls.Add(this.lblPassword);
            this.gbOtherServiceFields.Controls.Add(this.lblLogin);
            this.gbOtherServiceFields.Location = new System.Drawing.Point(12, 12);
            this.gbOtherServiceFields.Name = "gbOtherServiceFields";
            this.gbOtherServiceFields.Size = new System.Drawing.Size(288, 121);
            this.gbOtherServiceFields.TabIndex = 0;
            this.gbOtherServiceFields.TabStop = false;
            this.gbOtherServiceFields.Text = "Поля для заполнения";
            // 
            // cbxIsActive
            // 
            this.cbxIsActive.AutoSize = true;
            this.cbxIsActive.Location = new System.Drawing.Point(71, 98);
            this.cbxIsActive.Name = "cbxIsActive";
            this.cbxIsActive.Size = new System.Drawing.Size(68, 17);
            this.cbxIsActive.TabIndex = 4;
            this.cbxIsActive.Text = "Активен";
            this.cbxIsActive.UseVisualStyleBackColor = true;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(71, 46);
            this.tbxPassword.MaxLength = 50;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(200, 20);
            this.tbxPassword.TabIndex = 2;
            this.tbxPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPassword_Validating);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(71, 72);
            this.tbxName.MaxLength = 150;
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(200, 20);
            this.tbxName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 75);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ф.И.О.";
            // 
            // tbxLogin
            // 
            this.tbxLogin.Location = new System.Drawing.Point(71, 20);
            this.tbxLogin.MaxLength = 20;
            this.tbxLogin.Name = "tbxLogin";
            this.tbxLogin.Size = new System.Drawing.Size(200, 20);
            this.tbxLogin.TabIndex = 1;
            this.tbxLogin.Validating += new System.ComponentModel.CancelEventHandler(this.tbxLogin_Validating);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(7, 49);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(45, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Пароль";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(7, 23);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(38, 13);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Логин";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(94, 139);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(200, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // EditUserForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(312, 171);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbOtherServiceFields);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditUserForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование пользователя";
            this.gbOtherServiceFields.ResumeLayout(false);
            this.gbOtherServiceFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOtherServiceFields;
        private System.Windows.Forms.TextBox tbxLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox cbxIsActive;
    }
}