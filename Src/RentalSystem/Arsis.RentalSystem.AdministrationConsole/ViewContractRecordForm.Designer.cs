namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class ViewContractRecordForm
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
            this.lblPassportNumber = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbxPassportOutletOrgan = new System.Windows.Forms.TextBox();
            this.gbContractor = new System.Windows.Forms.GroupBox();
            this.lblPassportOutletOrgan = new System.Windows.Forms.Label();
            this.lblPassportSeries = new System.Windows.Forms.Label();
            this.lblINN = new System.Windows.Forms.Label();
            this.tbxPassportOutlenDate = new System.Windows.Forms.TextBox();
            this.tbxPassportSeries = new System.Windows.Forms.TextBox();
            this.tbxPassportNumber = new System.Windows.Forms.TextBox();
            this.tbxClientPhone = new System.Windows.Forms.TextBox();
            this.tbxClientPostAddress = new System.Windows.Forms.TextBox();
            this.tbxClientAddress = new System.Windows.Forms.TextBox();
            this.tbxINN = new System.Windows.Forms.TextBox();
            this.lblClient1SCode = new System.Windows.Forms.Label();
            this.lblClientPhone = new System.Windows.Forms.Label();
            this.lblContractorName = new System.Windows.Forms.Label();
            this.lblClientPostAddress = new System.Windows.Forms.Label();
            this.tbxContractorName = new System.Windows.Forms.TextBox();
            this.lblClientAddress = new System.Windows.Forms.Label();
            this.tbxClient1SCode = new System.Windows.Forms.TextBox();
            this.gbOtherServiceFields = new System.Windows.Forms.GroupBox();
            this.lblService = new System.Windows.Forms.Label();
            this.lblExpirationTo = new System.Windows.Forms.Label();
            this.lblPayDate = new System.Windows.Forms.Label();
            this.tbxExpirationDateTo = new System.Windows.Forms.TextBox();
            this.tbxExpirationDateFrom = new System.Windows.Forms.TextBox();
            this.tbxPayDate = new System.Windows.Forms.TextBox();
            this.tbxService = new System.Windows.Forms.TextBox();
            this.lblExpirationFrom = new System.Windows.Forms.Label();
            this.tbxContractNumber = new System.Windows.Forms.TextBox();
            this.lblContractNumber = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gb1C = new System.Windows.Forms.GroupBox();
            this.lblExportResult = new System.Windows.Forms.Label();
            this.lblContractCode = new System.Windows.Forms.Label();
            this.tbxExportResult = new System.Windows.Forms.TextBox();
            this.tbxContractCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbContractor.SuspendLayout();
            this.gbOtherServiceFields.SuspendLayout();
            this.gb1C.SuspendLayout();
            this.SuspendLayout();
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
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
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
            // gbContractor
            // 
            this.gbContractor.Controls.Add(this.lblPassportOutletOrgan);
            this.gbContractor.Controls.Add(this.lblPassportSeries);
            this.gbContractor.Controls.Add(this.lblPassportNumber);
            this.gbContractor.Controls.Add(this.tbxPassportOutletOrgan);
            this.gbContractor.Controls.Add(this.lblINN);
            this.gbContractor.Controls.Add(this.tbxPassportOutlenDate);
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
            this.gbContractor.Location = new System.Drawing.Point(10, 230);
            this.gbContractor.Name = "gbContractor";
            this.gbContractor.Size = new System.Drawing.Size(367, 342);
            this.gbContractor.TabIndex = 1;
            this.gbContractor.TabStop = false;
            this.gbContractor.Text = "Контрагент";
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
            // lblPassportSeries
            // 
            this.lblPassportSeries.AutoSize = true;
            this.lblPassportSeries.Location = new System.Drawing.Point(16, 218);
            this.lblPassportSeries.Name = "lblPassportSeries";
            this.lblPassportSeries.Size = new System.Drawing.Size(88, 13);
            this.lblPassportSeries.TabIndex = 0;
            this.lblPassportSeries.Text = "Серия паспорта";
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
            // tbxPassportOutlenDate
            // 
            this.tbxPassportOutlenDate.Location = new System.Drawing.Point(137, 241);
            this.tbxPassportOutlenDate.Name = "tbxPassportOutlenDate";
            this.tbxPassportOutlenDate.ReadOnly = true;
            this.tbxPassportOutlenDate.Size = new System.Drawing.Size(200, 20);
            this.tbxPassportOutlenDate.TabIndex = 9;
            // 
            // tbxPassportSeries
            // 
            this.tbxPassportSeries.Location = new System.Drawing.Point(137, 215);
            this.tbxPassportSeries.Name = "tbxPassportSeries";
            this.tbxPassportSeries.ReadOnly = true;
            this.tbxPassportSeries.Size = new System.Drawing.Size(200, 20);
            this.tbxPassportSeries.TabIndex = 8;
            // 
            // tbxPassportNumber
            // 
            this.tbxPassportNumber.Location = new System.Drawing.Point(137, 189);
            this.tbxPassportNumber.Name = "tbxPassportNumber";
            this.tbxPassportNumber.ReadOnly = true;
            this.tbxPassportNumber.Size = new System.Drawing.Size(200, 20);
            this.tbxPassportNumber.TabIndex = 7;
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
            // tbxClientAddress
            // 
            this.tbxClientAddress.Location = new System.Drawing.Point(137, 71);
            this.tbxClientAddress.Name = "tbxClientAddress";
            this.tbxClientAddress.ReadOnly = true;
            this.tbxClientAddress.Size = new System.Drawing.Size(200, 20);
            this.tbxClientAddress.TabIndex = 3;
            // 
            // tbxINN
            // 
            this.tbxINN.Location = new System.Drawing.Point(137, 163);
            this.tbxINN.Name = "tbxINN";
            this.tbxINN.ReadOnly = true;
            this.tbxINN.Size = new System.Drawing.Size(200, 20);
            this.tbxINN.TabIndex = 6;
            // 
            // lblClient1SCode
            // 
            this.lblClient1SCode.AutoSize = true;
            this.lblClient1SCode.Location = new System.Drawing.Point(16, 22);
            this.lblClient1SCode.Name = "lblClient1SCode";
            this.lblClient1SCode.Size = new System.Drawing.Size(26, 13);
            this.lblClient1SCode.TabIndex = 0;
            this.lblClient1SCode.Text = "Код";
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
            // lblContractorName
            // 
            this.lblContractorName.AutoSize = true;
            this.lblContractorName.Location = new System.Drawing.Point(16, 48);
            this.lblContractorName.Name = "lblContractorName";
            this.lblContractorName.Size = new System.Drawing.Size(57, 13);
            this.lblContractorName.TabIndex = 0;
            this.lblContractorName.Text = "Название";
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
            // 
            // gbOtherServiceFields
            // 
            this.gbOtherServiceFields.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbOtherServiceFields.Controls.Add(this.lblService);
            this.gbOtherServiceFields.Controls.Add(this.lblExpirationTo);
            this.gbOtherServiceFields.Controls.Add(this.lblPayDate);
            this.gbOtherServiceFields.Controls.Add(this.tbxExpirationDateTo);
            this.gbOtherServiceFields.Controls.Add(this.tbxExpirationDateFrom);
            this.gbOtherServiceFields.Controls.Add(this.tbxPayDate);
            this.gbOtherServiceFields.Controls.Add(this.tbxService);
            this.gbOtherServiceFields.Controls.Add(this.lblExpirationFrom);
            this.gbOtherServiceFields.Controls.Add(this.tbxContractNumber);
            this.gbOtherServiceFields.Controls.Add(this.lblContractNumber);
            this.gbOtherServiceFields.Location = new System.Drawing.Point(10, 16);
            this.gbOtherServiceFields.Name = "gbOtherServiceFields";
            this.gbOtherServiceFields.Size = new System.Drawing.Size(367, 127);
            this.gbOtherServiceFields.TabIndex = 0;
            this.gbOtherServiceFields.TabStop = false;
            this.gbOtherServiceFields.Text = "Договор";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(9, 103);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(67, 13);
            this.lblService.TabIndex = 12;
            this.lblService.Text = "Тип аренды";
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
            // lblPayDate
            // 
            this.lblPayDate.AutoSize = true;
            this.lblPayDate.Location = new System.Drawing.Point(9, 76);
            this.lblPayDate.Name = "lblPayDate";
            this.lblPayDate.Size = new System.Drawing.Size(129, 13);
            this.lblPayDate.TabIndex = 0;
            this.lblPayDate.Text = "Дата контроля платежа";
            this.lblPayDate.Visible = false;
            // 
            // tbxExpirationDateTo
            // 
            this.tbxExpirationDateTo.Location = new System.Drawing.Point(238, 49);
            this.tbxExpirationDateTo.Name = "tbxExpirationDateTo";
            this.tbxExpirationDateTo.ReadOnly = true;
            this.tbxExpirationDateTo.Size = new System.Drawing.Size(122, 20);
            this.tbxExpirationDateTo.TabIndex = 11;
            // 
            // tbxExpirationDateFrom
            // 
            this.tbxExpirationDateFrom.Location = new System.Drawing.Point(85, 49);
            this.tbxExpirationDateFrom.Name = "tbxExpirationDateFrom";
            this.tbxExpirationDateFrom.ReadOnly = true;
            this.tbxExpirationDateFrom.Size = new System.Drawing.Size(122, 20);
            this.tbxExpirationDateFrom.TabIndex = 11;
            // 
            // tbxPayDate
            // 
            this.tbxPayDate.Location = new System.Drawing.Point(144, 73);
            this.tbxPayDate.Name = "tbxPayDate";
            this.tbxPayDate.ReadOnly = true;
            this.tbxPayDate.Size = new System.Drawing.Size(120, 20);
            this.tbxPayDate.TabIndex = 11;
            // 
            // tbxService
            // 
            this.tbxService.Location = new System.Drawing.Point(85, 100);
            this.tbxService.Name = "tbxService";
            this.tbxService.ReadOnly = true;
            this.tbxService.Size = new System.Drawing.Size(200, 20);
            this.tbxService.TabIndex = 11;
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
            // tbxContractNumber
            // 
            this.tbxContractNumber.Location = new System.Drawing.Point(85, 22);
            this.tbxContractNumber.Name = "tbxContractNumber";
            this.tbxContractNumber.ReadOnly = true;
            this.tbxContractNumber.Size = new System.Drawing.Size(200, 20);
            this.tbxContractNumber.TabIndex = 1;
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
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(277, 578);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gb1C
            // 
            this.gb1C.Controls.Add(this.lblExportResult);
            this.gb1C.Controls.Add(this.lblContractCode);
            this.gb1C.Controls.Add(this.tbxExportResult);
            this.gb1C.Controls.Add(this.tbxContractCode);
            this.gb1C.Location = new System.Drawing.Point(10, 149);
            this.gb1C.Name = "gb1C";
            this.gb1C.Size = new System.Drawing.Size(367, 75);
            this.gb1C.TabIndex = 4;
            this.gb1C.TabStop = false;
            this.gb1C.Text = "1С";
            // 
            // lblExportResult
            // 
            this.lblExportResult.AutoSize = true;
            this.lblExportResult.Location = new System.Drawing.Point(16, 48);
            this.lblExportResult.Name = "lblExportResult";
            this.lblExportResult.Size = new System.Drawing.Size(109, 13);
            this.lblExportResult.TabIndex = 14;
            this.lblExportResult.Text = "Результат экспорта";
            // 
            // lblContractCode
            // 
            this.lblContractCode.AutoSize = true;
            this.lblContractCode.Location = new System.Drawing.Point(16, 22);
            this.lblContractCode.Name = "lblContractCode";
            this.lblContractCode.Size = new System.Drawing.Size(41, 13);
            this.lblContractCode.TabIndex = 12;
            this.lblContractCode.Text = "1С код";
            // 
            // tbxExportResult
            // 
            this.tbxExportResult.Location = new System.Drawing.Point(137, 45);
            this.tbxExportResult.Name = "tbxExportResult";
            this.tbxExportResult.ReadOnly = true;
            this.tbxExportResult.Size = new System.Drawing.Size(200, 20);
            this.tbxExportResult.TabIndex = 10;
            // 
            // tbxContractCode
            // 
            this.tbxContractCode.Location = new System.Drawing.Point(137, 19);
            this.tbxContractCode.Name = "tbxContractCode";
            this.tbxContractCode.ReadOnly = true;
            this.tbxContractCode.Size = new System.Drawing.Size(200, 20);
            this.tbxContractCode.TabIndex = 11;
            // 
            // ViewContractRecordForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(388, 607);
            this.Controls.Add(this.gb1C);
            this.Controls.Add(this.gbContractor);
            this.Controls.Add(this.gbOtherServiceFields);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewContractRecordForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр закрытого договора";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbContractor.ResumeLayout(false);
            this.gbContractor.PerformLayout();
            this.gbOtherServiceFields.ResumeLayout(false);
            this.gbOtherServiceFields.PerformLayout();
            this.gb1C.ResumeLayout(false);
            this.gb1C.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPassportNumber;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox gbContractor;
        private System.Windows.Forms.Label lblPassportOutletOrgan;
        private System.Windows.Forms.Label lblPassportSeries;
        private System.Windows.Forms.TextBox tbxPassportOutletOrgan;
        private System.Windows.Forms.Label lblINN;
        private System.Windows.Forms.TextBox tbxPassportOutlenDate;
        private System.Windows.Forms.TextBox tbxPassportSeries;
        private System.Windows.Forms.TextBox tbxPassportNumber;
        private System.Windows.Forms.TextBox tbxClientPhone;
        private System.Windows.Forms.TextBox tbxClientPostAddress;
        private System.Windows.Forms.TextBox tbxClientAddress;
        private System.Windows.Forms.TextBox tbxINN;
        private System.Windows.Forms.Label lblClient1SCode;
        private System.Windows.Forms.Label lblClientPhone;
        private System.Windows.Forms.Label lblContractorName;
        private System.Windows.Forms.Label lblClientPostAddress;
        private System.Windows.Forms.TextBox tbxContractorName;
        private System.Windows.Forms.Label lblClientAddress;
        private System.Windows.Forms.TextBox tbxClient1SCode;
        private System.Windows.Forms.GroupBox gbOtherServiceFields;
        private System.Windows.Forms.Label lblExpirationTo;
        private System.Windows.Forms.Label lblPayDate;
        private System.Windows.Forms.Label lblExpirationFrom;
        private System.Windows.Forms.TextBox tbxContractNumber;
        private System.Windows.Forms.Label lblContractNumber;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gb1C;
        private System.Windows.Forms.Label lblExportResult;
        private System.Windows.Forms.Label lblContractCode;
        private System.Windows.Forms.TextBox tbxExportResult;
        private System.Windows.Forms.TextBox tbxContractCode;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.TextBox tbxService;
        private System.Windows.Forms.TextBox tbxExpirationDateTo;
        private System.Windows.Forms.TextBox tbxExpirationDateFrom;
        private System.Windows.Forms.TextBox tbxPayDate;

    }
}