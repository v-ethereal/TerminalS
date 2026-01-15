namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class InsertPriceListRecordForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbOtherServiceFields = new System.Windows.Forms.GroupBox();
            this.tbxPrice = new Arsis.RentalSystem.AdministrationConsole.UserControls.NullableDecimalEdit();
            this.lblDate = new System.Windows.Forms.Label();
            this.dprDate = new System.Windows.Forms.DateTimePicker();
            this.cbxService = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbOtherServiceFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(342, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(236, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbOtherServiceFields
            // 
            this.gbOtherServiceFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOtherServiceFields.Controls.Add(this.tbxPrice);
            this.gbOtherServiceFields.Controls.Add(this.lblDate);
            this.gbOtherServiceFields.Controls.Add(this.dprDate);
            this.gbOtherServiceFields.Controls.Add(this.cbxService);
            this.gbOtherServiceFields.Controls.Add(this.lblPrice);
            this.gbOtherServiceFields.Controls.Add(this.lblService);
            this.gbOtherServiceFields.Location = new System.Drawing.Point(12, 12);
            this.gbOtherServiceFields.Name = "gbOtherServiceFields";
            this.gbOtherServiceFields.Size = new System.Drawing.Size(430, 98);
            this.gbOtherServiceFields.TabIndex = 0;
            this.gbOtherServiceFields.TabStop = false;
            this.gbOtherServiceFields.Text = "Поля для заполнения";
            // 
            // tbxPrice
            // 
            this.tbxPrice.AllowNegative = false;
            this.tbxPrice.Location = new System.Drawing.Point(91, 46);
            this.tbxPrice.MaxValue = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tbxPrice.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.NumericPrecision = 9;
            this.tbxPrice.NumericScale = 2;
            this.tbxPrice.Size = new System.Drawing.Size(150, 20);
            this.tbxPrice.TabIndex = 4;
            this.tbxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxPrice.ZeroIsValid = true;
            this.tbxPrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPrice_Validating);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 76);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(70, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Действует с";
            // 
            // dprDate
            // 
            this.dprDate.Location = new System.Drawing.Point(91, 72);
            this.dprDate.Name = "dprDate";
            this.dprDate.Size = new System.Drawing.Size(150, 20);
            this.dprDate.TabIndex = 3;
            this.dprDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDate_Validating);
            // 
            // cbxService
            // 
            this.cbxService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxService.DisplayMember = "Name";
            this.cbxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxService.FormattingEnabled = true;
            this.cbxService.Location = new System.Drawing.Point(91, 17);
            this.cbxService.Name = "cbxService";
            this.cbxService.Size = new System.Drawing.Size(322, 21);
            this.cbxService.TabIndex = 1;
            this.cbxService.ValueMember = "Id";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(7, 49);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(68, 13);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Цена,  (руб.)";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(7, 20);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(43, 13);
            this.lblService.TabIndex = 0;
            this.lblService.Text = "Услуга";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // InsertPriceListRecordForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(454, 147);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbOtherServiceFields);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 183);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 183);
            this.Name = "InsertPriceListRecordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление позиции прайс-листа";
            this.gbOtherServiceFields.ResumeLayout(false);
            this.gbOtherServiceFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbOtherServiceFields;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cbxService;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dprDate;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Arsis.RentalSystem.AdministrationConsole.UserControls.NullableDecimalEdit tbxPrice;
    }
}