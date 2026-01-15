namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class CloseContractForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbOtherServiceFields = new System.Windows.Forms.GroupBox();
            this.cpContract = new Arsis.RentalSystem.AdministrationConsole.UserControls.ContractPicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.dprDate = new System.Windows.Forms.DateTimePicker();
            this.lblContract = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFinancialInfo = new System.Windows.Forms.GroupBox();
            this.tbxBalance = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.tbxRecievedAmmount = new System.Windows.Forms.TextBox();
            this.lblRecievedAmmount = new System.Windows.Forms.Label();
            this.tbxRenderedAmmount = new System.Windows.Forms.TextBox();
            this.lblRenderedAmmount = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbOtherServiceFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbFinancialInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(199, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnCancel, "Отменяет операцию закрытия");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btnClose.Location = new System.Drawing.Point(93, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnClose, "Закрывает договор");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbOtherServiceFields
            // 
            this.gbOtherServiceFields.Controls.Add(this.cpContract);
            this.gbOtherServiceFields.Controls.Add(this.lblDate);
            this.gbOtherServiceFields.Controls.Add(this.dprDate);
            this.gbOtherServiceFields.Controls.Add(this.lblContract);
            this.gbOtherServiceFields.Location = new System.Drawing.Point(12, 12);
            this.gbOtherServiceFields.Name = "gbOtherServiceFields";
            this.gbOtherServiceFields.Size = new System.Drawing.Size(287, 70);
            this.gbOtherServiceFields.TabIndex = 0;
            this.gbOtherServiceFields.TabStop = false;
            this.gbOtherServiceFields.Text = "Поля для заполнения";
            // 
            // cpContract
            // 
            this.cpContract.ContractId = 0;
            this.cpContract.ContractService = null;
            this.cpContract.Enabled = false;
            this.cpContract.Location = new System.Drawing.Point(114, 18);
            this.cpContract.Name = "cpContract";
            this.cpContract.Size = new System.Drawing.Size(157, 20);
			this.cpContract.State = Arsis.RentalSystem.Core.Bll.ContractState.Active;
            this.cpContract.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(85, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата закрытия";
            // 
            // dprDate
            // 
            this.dprDate.Location = new System.Drawing.Point(114, 44);
            this.dprDate.Name = "dprDate";
            this.dprDate.Size = new System.Drawing.Size(157, 20);
            this.dprDate.TabIndex = 2;
            this.dprDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDate_Validating);
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Location = new System.Drawing.Point(7, 20);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(68, 13);
            this.lblContract.TabIndex = 0;
            this.lblContract.Text = "№ договора";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // gbFinancialInfo
            // 
            this.gbFinancialInfo.Controls.Add(this.tbxBalance);
            this.gbFinancialInfo.Controls.Add(this.lblBalance);
            this.gbFinancialInfo.Controls.Add(this.tbxRecievedAmmount);
            this.gbFinancialInfo.Controls.Add(this.lblRecievedAmmount);
            this.gbFinancialInfo.Controls.Add(this.tbxRenderedAmmount);
            this.gbFinancialInfo.Controls.Add(this.lblRenderedAmmount);
            this.gbFinancialInfo.Location = new System.Drawing.Point(12, 117);
            this.gbFinancialInfo.Name = "gbFinancialInfo";
            this.gbFinancialInfo.Size = new System.Drawing.Size(287, 95);
            this.gbFinancialInfo.TabIndex = 1;
            this.gbFinancialInfo.TabStop = false;
            this.gbFinancialInfo.Text = "Оборот";
            // 
            // tbxBalance
            // 
            this.tbxBalance.Location = new System.Drawing.Point(139, 65);
            this.tbxBalance.Name = "tbxBalance";
            this.tbxBalance.ReadOnly = true;
            this.tbxBalance.Size = new System.Drawing.Size(131, 20);
            this.tbxBalance.TabIndex = 2;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(6, 68);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(79, 13);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Сальдо,  (руб.)";
            // 
            // tbxRecievedAmmount
            // 
            this.tbxRecievedAmmount.Location = new System.Drawing.Point(139, 39);
            this.tbxRecievedAmmount.Name = "tbxRecievedAmmount";
            this.tbxRecievedAmmount.ReadOnly = true;
            this.tbxRecievedAmmount.Size = new System.Drawing.Size(131, 20);
            this.tbxRecievedAmmount.TabIndex = 1;
            // 
            // lblRecievedAmmount
            // 
            this.lblRecievedAmmount.AutoSize = true;
            this.lblRecievedAmmount.Location = new System.Drawing.Point(6, 42);
            this.lblRecievedAmmount.Name = "lblRecievedAmmount";
            this.lblRecievedAmmount.Size = new System.Drawing.Size(90, 13);
            this.lblRecievedAmmount.TabIndex = 0;
            this.lblRecievedAmmount.Text = "Получено,  (руб.)";
            // 
            // tbxRenderedAmmount
            // 
            this.tbxRenderedAmmount.Location = new System.Drawing.Point(140, 13);
            this.tbxRenderedAmmount.Name = "tbxRenderedAmmount";
            this.tbxRenderedAmmount.ReadOnly = true;
            this.tbxRenderedAmmount.Size = new System.Drawing.Size(130, 20);
            this.tbxRenderedAmmount.TabIndex = 0;
            // 
            // lblRenderedAmmount
            // 
            this.lblRenderedAmmount.AutoSize = true;
            this.lblRenderedAmmount.Location = new System.Drawing.Point(6, 16);
            this.lblRenderedAmmount.Name = "lblRenderedAmmount";
            this.lblRenderedAmmount.Size = new System.Drawing.Size(131, 13);
            this.lblRenderedAmmount.TabIndex = 0;
            this.lblRenderedAmmount.Text = "Оказано услуг на,  (руб.)";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.calculator;
            this.btnCalculate.Location = new System.Drawing.Point(109, 88);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnCalculate, "Позволяет рассчитать оборот по выбранному договору и дате закрытия");
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // CloseContractForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(311, 250);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.gbFinancialInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbOtherServiceFields);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CloseContractForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Закрытие договора";
            this.gbOtherServiceFields.ResumeLayout(false);
            this.gbOtherServiceFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbFinancialInfo.ResumeLayout(false);
            this.gbFinancialInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbOtherServiceFields;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dprDate;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox gbFinancialInfo;
        private System.Windows.Forms.Label lblRenderedAmmount;
        private System.Windows.Forms.TextBox tbxBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox tbxRecievedAmmount;
        private System.Windows.Forms.Label lblRecievedAmmount;
        private System.Windows.Forms.TextBox tbxRenderedAmmount;
        private System.Windows.Forms.ToolTip toolTip;
        private UserControls.ContractPicker cpContract;
    }
}