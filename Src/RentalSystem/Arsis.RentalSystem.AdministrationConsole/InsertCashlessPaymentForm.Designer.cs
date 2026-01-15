namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class InsertCashlessPaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbOtherServiceFields = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_ControlDate = new System.Windows.Forms.DateTimePicker();
            this.cpContract = new Arsis.RentalSystem.AdministrationConsole.UserControls.ContractPicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dprDateTo = new System.Windows.Forms.DateTimePicker();
            this.dprDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblContract = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbOtherServiceFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(200, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(94, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbOtherServiceFields
            // 
            this.gbOtherServiceFields.Controls.Add(this.label1);
            this.gbOtherServiceFields.Controls.Add(this.dtp_ControlDate);
            this.gbOtherServiceFields.Controls.Add(this.cpContract);
            this.gbOtherServiceFields.Controls.Add(this.lblDateTo);
            this.gbOtherServiceFields.Controls.Add(this.lblDateFrom);
            this.gbOtherServiceFields.Controls.Add(this.dprDateTo);
            this.gbOtherServiceFields.Controls.Add(this.dprDateFrom);
            this.gbOtherServiceFields.Controls.Add(this.lblContract);
            this.gbOtherServiceFields.Location = new System.Drawing.Point(12, 12);
            this.gbOtherServiceFields.Name = "gbOtherServiceFields";
            this.gbOtherServiceFields.Size = new System.Drawing.Size(288, 125);
            this.gbOtherServiceFields.TabIndex = 0;
            this.gbOtherServiceFields.TabStop = false;
            this.gbOtherServiceFields.Text = "Поля для заполнения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Дата контроля";
            // 
            // dtp_ControlDate
            // 
            this.dtp_ControlDate.Location = new System.Drawing.Point(91, 97);
            this.dtp_ControlDate.Name = "dtp_ControlDate";
            this.dtp_ControlDate.Size = new System.Drawing.Size(180, 20);
            this.dtp_ControlDate.TabIndex = 4;
            this.dtp_ControlDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtp_ControlDate_Validating);
            // 
            // cpContract
            // 
            this.cpContract.ContractId = 0;
            this.cpContract.ContractService = null;
            this.cpContract.Location = new System.Drawing.Point(91, 19);
            this.cpContract.Name = "cpContract";
            this.cpContract.Size = new System.Drawing.Size(180, 20);
			this.cpContract.State = Arsis.RentalSystem.Core.Bll.ContractState.Cashless;
            this.cpContract.TabIndex = 1;
            this.cpContract.ValueChanged += new ValueChangedEventHandler(this.cpContract_ValueChanged);
            this.cpContract.Validating += new System.ComponentModel.CancelEventHandler(this.cpContract_Validating);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(7, 75);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(48, 13);
            this.lblDateTo.TabIndex = 6;
            this.lblDateTo.Text = "Дата по";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(7, 49);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(42, 13);
            this.lblDateFrom.TabIndex = 7;
            this.lblDateFrom.Text = "Дата с";
            // 
            // dprDateTo
            // 
            this.dprDateTo.Location = new System.Drawing.Point(91, 71);
            this.dprDateTo.Name = "dprDateTo";
            this.dprDateTo.Size = new System.Drawing.Size(180, 20);
            this.dprDateTo.TabIndex = 3;
            this.dprDateTo.Validating += new System.ComponentModel.CancelEventHandler(this.dprDateTo_Validating);
            // 
            // dprDateFrom
            // 
            this.dprDateFrom.Location = new System.Drawing.Point(91, 45);
            this.dprDateFrom.Name = "dprDateFrom";
            this.dprDateFrom.Size = new System.Drawing.Size(180, 20);
            this.dprDateFrom.TabIndex = 2;
            this.dprDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.dprDateFrom_Validating);
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Location = new System.Drawing.Point(7, 23);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(65, 13);
            this.lblContract.TabIndex = 0;
            this.lblContract.Text = "Договор №";
            // 
            // InsertCashlessPaymentForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(308, 174);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbOtherServiceFields);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertCashlessPaymentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Внесение безналичного платежа";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbOtherServiceFields.ResumeLayout(false);
            this.gbOtherServiceFields.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbOtherServiceFields;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dprDateTo;
        private System.Windows.Forms.DateTimePicker dprDateFrom;
        private UserControls.ContractPicker cpContract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_ControlDate;
    }
}