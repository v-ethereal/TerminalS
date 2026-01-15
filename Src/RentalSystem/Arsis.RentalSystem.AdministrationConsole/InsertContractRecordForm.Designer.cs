namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class InsertContractRecordForm
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblINN = new System.Windows.Forms.Label();
            this.lblPassportOutletOrgan = new System.Windows.Forms.Label();
            this.tbxINN = new System.Windows.Forms.TextBox();
            this.cbxService = new System.Windows.Forms.ComboBox();
            this.lblService = new System.Windows.Forms.Label();
            this.tbxContractNumber = new System.Windows.Forms.TextBox();
            this.lblContractNumber = new System.Windows.Forms.Label();
            this.dprExpirationDateTo = new System.Windows.Forms.DateTimePicker();
            this.dprExpirationDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblExpirationTo = new System.Windows.Forms.Label();
            this.lblExpirationFrom = new System.Windows.Forms.Label();
            this.lblPassportNumber = new System.Windows.Forms.Label();
            this.tbxPassportOutletOrgan = new System.Windows.Forms.TextBox();
            this.tbxPassportNumber = new System.Windows.Forms.TextBox();
            this.tbxClientAddress = new System.Windows.Forms.TextBox();
            this.lblContractorName = new System.Windows.Forms.Label();
            this.lblClient1SCode = new System.Windows.Forms.Label();
            this.cbxIsCashless = new System.Windows.Forms.CheckBox();
            this.lblPayDate = new System.Windows.Forms.Label();
            this.gbOtherServiceFields = new System.Windows.Forms.GroupBox();
            this.dprDate = new System.Windows.Forms.DateTimePicker();
            this.gbContractor = new System.Windows.Forms.GroupBox();
            this.cbClientIsUrFace = new System.Windows.Forms.CheckBox();
            this.dtpClientPassportIssuedDate = new System.Windows.Forms.DateTimePicker();
            this.lblPassportSeries = new System.Windows.Forms.Label();
            this.tbxPassportSeries = new System.Windows.Forms.TextBox();
            this.tbxClientPhone = new System.Windows.Forms.TextBox();
            this.tbxClientPostAddress = new System.Windows.Forms.TextBox();
            this.lblClientPhone = new System.Windows.Forms.Label();
            this.lblClientPostAddress = new System.Windows.Forms.Label();
            this.tbxContractorName = new System.Windows.Forms.TextBox();
            this.lblClientAddress = new System.Windows.Forms.Label();
            this.tbxClient1SCode = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbOtherServiceFields.SuspendLayout();
            this.gbContractor.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // lblINN
            // 
            this.lblINN.AutoSize = true;
            this.lblINN.Location = new System.Drawing.Point(16, 166);
            this.lblINN.Name = "lblINN";
            this.lblINN.Size = new System.Drawing.Size(31, 13);
            this.lblINN.TabIndex = 0;
            this.lblINN.Text = "ИНН";
            // 
            // lblPassportOutletOrgan
            // 
            this.lblPassportOutletOrgan.AutoSize = true;
            this.lblPassportOutletOrgan.Location = new System.Drawing.Point(16, 248);
            this.lblPassportOutletOrgan.Name = "lblPassportOutletOrgan";
            this.lblPassportOutletOrgan.Size = new System.Drawing.Size(40, 13);
            this.lblPassportOutletOrgan.TabIndex = 0;
            this.lblPassportOutletOrgan.Text = "Выдан";
            // 
            // tbxINN
            // 
            this.tbxINN.Location = new System.Drawing.Point(137, 163);
            this.tbxINN.Name = "tbxINN";
            this.tbxINN.ReadOnly = true;
            this.tbxINN.Size = new System.Drawing.Size(200, 20);
            this.tbxINN.TabIndex = 6;
            // 
            // cbxService
            // 
            this.cbxService.DisplayMember = "Name";
            this.cbxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxService.FormattingEnabled = true;
            this.cbxService.Location = new System.Drawing.Point(85, 74);
            this.cbxService.Name = "cbxService";
            this.cbxService.Size = new System.Drawing.Size(191, 21);
            this.cbxService.TabIndex = 4;
            this.cbxService.ValueMember = "Id";
            this.cbxService.Validating += new System.ComponentModel.CancelEventHandler(this.cbxService_Validating);
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(9, 77);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(67, 13);
            this.lblService.TabIndex = 0;
            this.lblService.Text = "Тип аренды";
            // 
            // tbxContractNumber
            // 
            this.tbxContractNumber.Location = new System.Drawing.Point(85, 22);
            this.tbxContractNumber.MaxLength = 25;
            this.tbxContractNumber.Name = "tbxContractNumber";
            this.tbxContractNumber.Size = new System.Drawing.Size(200, 20);
            this.tbxContractNumber.TabIndex = 1;
            this.tbxContractNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbxContractNumber_Validating);
            // 
            // lblContractNumber
            // 
            this.lblContractNumber.AutoSize = true;
            this.lblContractNumber.Location = new System.Drawing.Point(9, 25);
            this.lblContractNumber.Name = "lblContractNumber";
            this.lblContractNumber.Size = new System.Drawing.Size(68, 13);
            this.lblContractNumber.TabIndex = 0;
            this.lblContractNumber.Text = "№ договора";
            // 
            // dprExpirationDateTo
            // 
            this.dprExpirationDateTo.Location = new System.Drawing.Point(238, 48);
            this.dprExpirationDateTo.Name = "dprExpirationDateTo";
            this.dprExpirationDateTo.Size = new System.Drawing.Size(122, 20);
            this.dprExpirationDateTo.TabIndex = 3;
            this.dprExpirationDateTo.Validating += new System.ComponentModel.CancelEventHandler(this.dprExpirationDateTo_Validating);
            // 
            // dprExpirationDateFrom
            // 
            this.dprExpirationDateFrom.Location = new System.Drawing.Point(85, 48);
            this.dprExpirationDateFrom.Name = "dprExpirationDateFrom";
            this.dprExpirationDateFrom.Size = new System.Drawing.Size(122, 20);
            this.dprExpirationDateFrom.TabIndex = 2;
            this.dprExpirationDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.dprExpirationDateFrom_Validating);
            // 
            // lblExpirationTo
            // 
            this.lblExpirationTo.AutoSize = true;
            this.lblExpirationTo.Location = new System.Drawing.Point(213, 52);
            this.lblExpirationTo.Name = "lblExpirationTo";
            this.lblExpirationTo.Size = new System.Drawing.Size(19, 13);
            this.lblExpirationTo.TabIndex = 0;
            this.lblExpirationTo.Text = "по";
            // 
            // lblExpirationFrom
            // 
            this.lblExpirationFrom.AutoSize = true;
            this.lblExpirationFrom.Location = new System.Drawing.Point(9, 52);
            this.lblExpirationFrom.Name = "lblExpirationFrom";
            this.lblExpirationFrom.Size = new System.Drawing.Size(70, 13);
            this.lblExpirationFrom.TabIndex = 0;
            this.lblExpirationFrom.Text = "Действует с";
            // 
            // lblPassportNumber
            // 
            this.lblPassportNumber.AutoSize = true;
            this.lblPassportNumber.Location = new System.Drawing.Point(16, 192);
            this.lblPassportNumber.Name = "lblPassportNumber";
            this.lblPassportNumber.Size = new System.Drawing.Size(68, 13);
            this.lblPassportNumber.TabIndex = 0;
            this.lblPassportNumber.Text = "№ паспорта";
            // 
            // tbxPassportOutletOrgan
            // 
            this.tbxPassportOutletOrgan.Location = new System.Drawing.Point(137, 267);
            this.tbxPassportOutletOrgan.Multiline = true;
            this.tbxPassportOutletOrgan.Name = "tbxPassportOutletOrgan";
            this.tbxPassportOutletOrgan.ReadOnly = true;
            this.tbxPassportOutletOrgan.Size = new System.Drawing.Size(200, 60);
            this.tbxPassportOutletOrgan.TabIndex = 10;
            // 
            // tbxPassportNumber
            // 
            this.tbxPassportNumber.Location = new System.Drawing.Point(137, 189);
            this.tbxPassportNumber.Name = "tbxPassportNumber";
            this.tbxPassportNumber.ReadOnly = true;
            this.tbxPassportNumber.Size = new System.Drawing.Size(200, 20);
            this.tbxPassportNumber.TabIndex = 7;
            // 
            // tbxClientAddress
            // 
            this.tbxClientAddress.Location = new System.Drawing.Point(137, 71);
            this.tbxClientAddress.Name = "tbxClientAddress";
            this.tbxClientAddress.ReadOnly = true;
            this.tbxClientAddress.Size = new System.Drawing.Size(200, 20);
            this.tbxClientAddress.TabIndex = 3;
            // 
            // lblContractorName
            // 
            this.lblContractorName.AutoSize = true;
            this.lblContractorName.Location = new System.Drawing.Point(16, 48);
            this.lblContractorName.Name = "lblContractorName";
            this.lblContractorName.Size = new System.Drawing.Size(57, 13);
            this.lblContractorName.TabIndex = 0;
            this.lblContractorName.Text = "Название";
            // 
            // lblClient1SCode
            // 
            this.lblClient1SCode.AutoSize = true;
            this.lblClient1SCode.Location = new System.Drawing.Point(16, 22);
            this.lblClient1SCode.Name = "lblClient1SCode";
            this.lblClient1SCode.Size = new System.Drawing.Size(41, 13);
            this.lblClient1SCode.TabIndex = 0;
            this.lblClient1SCode.Text = "1С код";
            // 
            // cbxIsCashless
            // 
            this.cbxIsCashless.Location = new System.Drawing.Point(85, 101);
            this.cbxIsCashless.Name = "cbxIsCashless";
            this.cbxIsCashless.Size = new System.Drawing.Size(195, 17);
            this.cbxIsCashless.TabIndex = 5;
            this.cbxIsCashless.Text = "Оплата по безналичному расчету";
            this.cbxIsCashless.UseVisualStyleBackColor = true;
            this.cbxIsCashless.CheckedChanged += new System.EventHandler(this.cbxIsCashless_CheckedChanged);
            // 
            // lblPayDate
            // 
            this.lblPayDate.AutoSize = true;
            this.lblPayDate.Location = new System.Drawing.Point(9, 128);
            this.lblPayDate.Name = "lblPayDate";
            this.lblPayDate.Size = new System.Drawing.Size(129, 13);
            this.lblPayDate.TabIndex = 0;
            this.lblPayDate.Text = "Дата контроля платежа";
            this.lblPayDate.Visible = false;
            // 
            // gbOtherServiceFields
            // 
            this.gbOtherServiceFields.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbOtherServiceFields.Controls.Add(this.dprDate);
            this.gbOtherServiceFields.Controls.Add(this.cbxIsCashless);
            this.gbOtherServiceFields.Controls.Add(this.lblExpirationTo);
            this.gbOtherServiceFields.Controls.Add(this.lblPayDate);
            this.gbOtherServiceFields.Controls.Add(this.dprExpirationDateFrom);
            this.gbOtherServiceFields.Controls.Add(this.cbxService);
            this.gbOtherServiceFields.Controls.Add(this.lblExpirationFrom);
            this.gbOtherServiceFields.Controls.Add(this.tbxContractNumber);
            this.gbOtherServiceFields.Controls.Add(this.dprExpirationDateTo);
            this.gbOtherServiceFields.Controls.Add(this.lblService);
            this.gbOtherServiceFields.Controls.Add(this.lblContractNumber);
            this.gbOtherServiceFields.Location = new System.Drawing.Point(12, 12);
            this.gbOtherServiceFields.Name = "gbOtherServiceFields";
            this.gbOtherServiceFields.Size = new System.Drawing.Size(367, 156);
            this.gbOtherServiceFields.TabIndex = 0;
            this.gbOtherServiceFields.TabStop = false;
            this.gbOtherServiceFields.Text = "Поля для заполнения";
            // 
            // dprDate
            // 
            this.dprDate.Location = new System.Drawing.Point(144, 124);
            this.dprDate.Name = "dprDate";
            this.dprDate.Size = new System.Drawing.Size(132, 20);
            this.dprDate.TabIndex = 6;
            this.dprDate.Visible = false;
            // 
            // gbContractor
            // 
            this.gbContractor.Controls.Add(this.cbClientIsUrFace);
            this.gbContractor.Controls.Add(this.dtpClientPassportIssuedDate);
            this.gbContractor.Controls.Add(this.lblPassportOutletOrgan);
            this.gbContractor.Controls.Add(this.lblPassportSeries);
            this.gbContractor.Controls.Add(this.lblPassportNumber);
            this.gbContractor.Controls.Add(this.tbxPassportOutletOrgan);
            this.gbContractor.Controls.Add(this.lblINN);
            this.gbContractor.Controls.Add(this.tbxPassportSeries);
            this.gbContractor.Controls.Add(this.tbxPassportNumber);
            this.gbContractor.Controls.Add(this.tbxClientPhone);
            this.gbContractor.Controls.Add(this.tbxClientPostAddress);
            this.gbContractor.Controls.Add(this.tbxClientAddress);
            this.gbContractor.Controls.Add(this.tbxINN);
            this.gbContractor.Controls.Add(this.lblClient1SCode);
            this.gbContractor.Controls.Add(this.lblClientPhone);
            this.gbContractor.Controls.Add(this.lblContractorName);
            this.gbContractor.Controls.Add(this.lblClientPostAddress);
            this.gbContractor.Controls.Add(this.tbxContractorName);
            this.gbContractor.Controls.Add(this.lblClientAddress);
            this.gbContractor.Controls.Add(this.tbxClient1SCode);
            this.gbContractor.Location = new System.Drawing.Point(12, 203);
            this.gbContractor.Name = "gbContractor";
            this.gbContractor.Size = new System.Drawing.Size(367, 342);
            this.gbContractor.TabIndex = 2;
            this.gbContractor.TabStop = false;
            this.gbContractor.Text = "Контрагент";
            // 
            // cbClientIsUrFace
            // 
            this.cbClientIsUrFace.AutoSize = true;
            this.cbClientIsUrFace.Checked = true;
            this.cbClientIsUrFace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClientIsUrFace.Location = new System.Drawing.Point(19, 310);
            this.cbClientIsUrFace.Name = "cbClientIsUrFace";
            this.cbClientIsUrFace.Size = new System.Drawing.Size(71, 17);
            this.cbClientIsUrFace.TabIndex = 12;
            this.cbClientIsUrFace.Text = "Юр. лицо";
            this.cbClientIsUrFace.UseVisualStyleBackColor = true;
            // 
            // dtpClientPassportIssuedDate
            // 
            this.dtpClientPassportIssuedDate.Checked = false;
            this.dtpClientPassportIssuedDate.Location = new System.Drawing.Point(137, 242);
            this.dtpClientPassportIssuedDate.Name = "dtpClientPassportIssuedDate";
            this.dtpClientPassportIssuedDate.ShowCheckBox = true;
            this.dtpClientPassportIssuedDate.Size = new System.Drawing.Size(200, 20);
            this.dtpClientPassportIssuedDate.TabIndex = 11;
            // 
            // lblPassportSeries
            // 
            this.lblPassportSeries.AutoSize = true;
            this.lblPassportSeries.Location = new System.Drawing.Point(16, 218);
            this.lblPassportSeries.Name = "lblPassportSeries";
            this.lblPassportSeries.Size = new System.Drawing.Size(88, 13);
            this.lblPassportSeries.TabIndex = 0;
            this.lblPassportSeries.Text = "Серия паспорта";
            // 
            // tbxPassportSeries
            // 
            this.tbxPassportSeries.Location = new System.Drawing.Point(137, 215);
            this.tbxPassportSeries.Name = "tbxPassportSeries";
            this.tbxPassportSeries.ReadOnly = true;
            this.tbxPassportSeries.Size = new System.Drawing.Size(200, 20);
            this.tbxPassportSeries.TabIndex = 8;
            // 
            // tbxClientPhone
            // 
            this.tbxClientPhone.Location = new System.Drawing.Point(137, 137);
            this.tbxClientPhone.Name = "tbxClientPhone";
            this.tbxClientPhone.ReadOnly = true;
            this.tbxClientPhone.Size = new System.Drawing.Size(200, 20);
            this.tbxClientPhone.TabIndex = 5;
            // 
            // tbxClientPostAddress
            // 
            this.tbxClientPostAddress.Location = new System.Drawing.Point(137, 97);
            this.tbxClientPostAddress.Multiline = true;
            this.tbxClientPostAddress.Name = "tbxClientPostAddress";
            this.tbxClientPostAddress.ReadOnly = true;
            this.tbxClientPostAddress.Size = new System.Drawing.Size(200, 34);
            this.tbxClientPostAddress.TabIndex = 4;
            // 
            // lblClientPhone
            // 
            this.lblClientPhone.AutoSize = true;
            this.lblClientPhone.Location = new System.Drawing.Point(16, 140);
            this.lblClientPhone.Name = "lblClientPhone";
            this.lblClientPhone.Size = new System.Drawing.Size(52, 13);
            this.lblClientPhone.TabIndex = 0;
            this.lblClientPhone.Text = "Телефон";
            // 
            // lblClientPostAddress
            // 
            this.lblClientPostAddress.AutoSize = true;
            this.lblClientPostAddress.Location = new System.Drawing.Point(16, 100);
            this.lblClientPostAddress.Name = "lblClientPostAddress";
            this.lblClientPostAddress.Size = new System.Drawing.Size(90, 13);
            this.lblClientPostAddress.TabIndex = 0;
            this.lblClientPostAddress.Text = "Почтовый адрес";
            // 
            // tbxContractorName
            // 
            this.tbxContractorName.Location = new System.Drawing.Point(137, 45);
            this.tbxContractorName.Name = "tbxContractorName";
            this.tbxContractorName.ReadOnly = true;
            this.tbxContractorName.Size = new System.Drawing.Size(200, 20);
            this.tbxContractorName.TabIndex = 2;
            // 
            // lblClientAddress
            // 
            this.lblClientAddress.AutoSize = true;
            this.lblClientAddress.Location = new System.Drawing.Point(16, 74);
            this.lblClientAddress.Name = "lblClientAddress";
            this.lblClientAddress.Size = new System.Drawing.Size(38, 13);
            this.lblClientAddress.TabIndex = 0;
            this.lblClientAddress.Text = "Адрес";
            // 
            // tbxClient1SCode
            // 
            this.tbxClient1SCode.Location = new System.Drawing.Point(137, 19);
            this.tbxClient1SCode.Name = "tbxClient1SCode";
            this.tbxClient1SCode.ReadOnly = true;
            this.tbxClient1SCode.Size = new System.Drawing.Size(200, 20);
            this.tbxClient1SCode.TabIndex = 1;
            this.tbxClient1SCode.Validating += new System.ComponentModel.CancelEventHandler(this.tbxClient1SCode_Validating);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 551);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnCancel, "Отменяет произведенные изменения");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(173, 551);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnSave, "Сохраняет произведенные изменения");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImport
            // 
            this.btnImport.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.user_edit;
            this.btnImport.Location = new System.Drawing.Point(12, 174);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(138, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Выбор контрагента";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnImport, "Нажмите для импорта контрагента из системы 1С");
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // InsertContractRecordForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(390, 582);
            this.Controls.Add(this.gbContractor);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbOtherServiceFields);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertContractRecordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление договора";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbOtherServiceFields.ResumeLayout(false);
            this.gbOtherServiceFields.PerformLayout();
            this.gbContractor.ResumeLayout(false);
            this.gbContractor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox gbOtherServiceFields;
        private System.Windows.Forms.CheckBox cbxIsCashless;
        private System.Windows.Forms.Label lblPayDate;
        private System.Windows.Forms.GroupBox gbContractor;
        private System.Windows.Forms.Label lblPassportOutletOrgan;
        private System.Windows.Forms.Label lblPassportNumber;
        private System.Windows.Forms.TextBox tbxPassportOutletOrgan;
        private System.Windows.Forms.TextBox tbxPassportNumber;
        private System.Windows.Forms.TextBox tbxClientAddress;
        private System.Windows.Forms.Label lblClient1SCode;
        private System.Windows.Forms.Label lblContractorName;
        private System.Windows.Forms.TextBox tbxContractorName;
        private System.Windows.Forms.Label lblClientAddress;
        private System.Windows.Forms.TextBox tbxClient1SCode;
        private System.Windows.Forms.Label lblINN;
        private System.Windows.Forms.TextBox tbxINN;
        private System.Windows.Forms.TextBox tbxContractNumber;
        private System.Windows.Forms.Label lblContractNumber;
        private System.Windows.Forms.DateTimePicker dprExpirationDateTo;
        private System.Windows.Forms.DateTimePicker dprExpirationDateFrom;
        private System.Windows.Forms.Label lblExpirationTo;
        private System.Windows.Forms.Label lblExpirationFrom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxService;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox tbxClientPhone;
        private System.Windows.Forms.TextBox tbxClientPostAddress;
        private System.Windows.Forms.Label lblClientPhone;
        private System.Windows.Forms.Label lblClientPostAddress;
        private System.Windows.Forms.Label lblPassportSeries;
        private System.Windows.Forms.TextBox tbxPassportSeries;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DateTimePicker dprDate;
        private System.Windows.Forms.DateTimePicker dtpClientPassportIssuedDate;
        private System.Windows.Forms.CheckBox cbClientIsUrFace;

    }
}