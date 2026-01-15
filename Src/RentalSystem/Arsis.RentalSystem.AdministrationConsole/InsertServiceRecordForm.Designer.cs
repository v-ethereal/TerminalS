namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class InsertServiceRecordForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_otherServices = new System.Windows.Forms.RadioButton();
            this.checkBox_parkingWithoutTime = new System.Windows.Forms.RadioButton();
            this.checkBox_parkingPerHour = new System.Windows.Forms.RadioButton();
            this.cbxIsRental = new System.Windows.Forms.RadioButton();
            this.checkBox_usePlaceNumber = new System.Windows.Forms.CheckBox();
            this.btRestoreImage = new System.Windows.Forms.Button();
            this.tb_1SCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPicture = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.cbxIsActive = new System.Windows.Forms.CheckBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbOtherServiceFields.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOtherServiceFields
            // 
            this.gbOtherServiceFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOtherServiceFields.Controls.Add(this.groupBox1);
            this.gbOtherServiceFields.Controls.Add(this.btRestoreImage);
            this.gbOtherServiceFields.Controls.Add(this.tb_1SCode);
            this.gbOtherServiceFields.Controls.Add(this.label1);
            this.gbOtherServiceFields.Controls.Add(this.btnPicture);
            this.gbOtherServiceFields.Controls.Add(this.lblImage);
            this.gbOtherServiceFields.Controls.Add(this.picture);
            this.gbOtherServiceFields.Controls.Add(this.cbxIsActive);
            this.gbOtherServiceFields.Controls.Add(this.tbxDescription);
            this.gbOtherServiceFields.Controls.Add(this.tbxName);
            this.gbOtherServiceFields.Controls.Add(this.lblCaption);
            this.gbOtherServiceFields.Controls.Add(this.lblName);
            this.gbOtherServiceFields.Location = new System.Drawing.Point(12, 10);
            this.gbOtherServiceFields.Name = "gbOtherServiceFields";
            this.gbOtherServiceFields.Size = new System.Drawing.Size(536, 261);
            this.gbOtherServiceFields.TabIndex = 0;
            this.gbOtherServiceFields.TabStop = false;
            this.gbOtherServiceFields.Text = "Поля для заполнения";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_otherServices);
            this.groupBox1.Controls.Add(this.checkBox_parkingWithoutTime);
            this.groupBox1.Controls.Add(this.checkBox_parkingPerHour);
            this.groupBox1.Controls.Add(this.cbxIsRental);
            this.groupBox1.Controls.Add(this.checkBox_usePlaceNumber);
            this.groupBox1.Location = new System.Drawing.Point(6, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 120);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип услуги";
            // 
            // checkBox_otherServices
            // 
            this.checkBox_otherServices.AutoSize = true;
            this.checkBox_otherServices.Location = new System.Drawing.Point(65, 88);
            this.checkBox_otherServices.Name = "checkBox_otherServices";
            this.checkBox_otherServices.Size = new System.Drawing.Size(98, 17);
            this.checkBox_otherServices.TabIndex = 13;
            this.checkBox_otherServices.TabStop = true;
            this.checkBox_otherServices.Text = "Прочие услуги";
            this.toolTip1.SetToolTip(this.checkBox_otherServices, "Прочие услуги");
            this.checkBox_otherServices.UseVisualStyleBackColor = true;
            this.checkBox_otherServices.CheckedChanged += new System.EventHandler(this.checkBox_otherServices_CheckedChanged);
            // 
            // checkBox_parkingWithoutTime
            // 
            this.checkBox_parkingWithoutTime.AutoSize = true;
            this.checkBox_parkingWithoutTime.Location = new System.Drawing.Point(65, 65);
            this.checkBox_parkingWithoutTime.Name = "checkBox_parkingWithoutTime";
            this.checkBox_parkingWithoutTime.Size = new System.Drawing.Size(173, 17);
            this.checkBox_parkingWithoutTime.TabIndex = 12;
            this.checkBox_parkingWithoutTime.TabStop = true;
            this.checkBox_parkingWithoutTime.Text = "Парковка без учета времени";
            this.toolTip1.SetToolTip(this.checkBox_parkingWithoutTime, "Штраф за потерю парковочной карты (является также максимальной суммой оплаты парк" +
                    "овки)");
            this.checkBox_parkingWithoutTime.UseVisualStyleBackColor = true;
            this.checkBox_parkingWithoutTime.CheckedChanged += new System.EventHandler(this.checkBox_parkingWithoutTime_CheckedChanged);
            // 
            // checkBox_parkingPerHour
            // 
            this.checkBox_parkingPerHour.AutoSize = true;
            this.checkBox_parkingPerHour.Location = new System.Drawing.Point(65, 42);
            this.checkBox_parkingPerHour.Name = "checkBox_parkingPerHour";
            this.checkBox_parkingPerHour.Size = new System.Drawing.Size(131, 17);
            this.checkBox_parkingPerHour.TabIndex = 11;
            this.checkBox_parkingPerHour.TabStop = true;
            this.checkBox_parkingPerHour.Text = "Парковка почасовая";
            this.toolTip1.SetToolTip(this.checkBox_parkingPerHour, "Парковка почасовая в зоне разгрузки");
            this.checkBox_parkingPerHour.UseVisualStyleBackColor = true;
            this.checkBox_parkingPerHour.CheckedChanged += new System.EventHandler(this.checkBox_parkingPerHour_CheckedChanged);
            // 
            // cbxIsRental
            // 
            this.cbxIsRental.AutoSize = true;
            this.cbxIsRental.Location = new System.Drawing.Point(65, 19);
            this.cbxIsRental.Name = "cbxIsRental";
            this.cbxIsRental.Size = new System.Drawing.Size(62, 17);
            this.cbxIsRental.TabIndex = 10;
            this.cbxIsRental.TabStop = true;
            this.cbxIsRental.Text = "Аренда";
            this.toolTip1.SetToolTip(this.cbxIsRental, "Аренда торговых мест");
            this.cbxIsRental.UseVisualStyleBackColor = true;
            this.cbxIsRental.CheckedChanged += new System.EventHandler(this.cbxIsRental_CheckedChanged);
            // 
            // checkBox_usePlaceNumber
            // 
            this.checkBox_usePlaceNumber.AutoSize = true;
            this.checkBox_usePlaceNumber.Location = new System.Drawing.Point(169, 89);
            this.checkBox_usePlaceNumber.Name = "checkBox_usePlaceNumber";
            this.checkBox_usePlaceNumber.Size = new System.Drawing.Size(94, 17);
            this.checkBox_usePlaceNumber.TabIndex = 9;
            this.checkBox_usePlaceNumber.Text = "Номер места";
            this.toolTip1.SetToolTip(this.checkBox_usePlaceNumber, "Признак того, что будет запрашиваться ввод номера места на терминале при оплате у" +
                    "слуги");
            this.checkBox_usePlaceNumber.UseVisualStyleBackColor = true;
            // 
            // btRestoreImage
            // 
            this.btRestoreImage.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.undo;
            this.btRestoreImage.Location = new System.Drawing.Point(505, 224);
            this.btRestoreImage.Name = "btRestoreImage";
            this.btRestoreImage.Size = new System.Drawing.Size(25, 25);
            this.btRestoreImage.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btRestoreImage, "Установить иконку по умолчанию");
            this.btRestoreImage.UseVisualStyleBackColor = true;
            this.btRestoreImage.Click += new System.EventHandler(this.btRestoreImage_Click);
            // 
            // tb_1SCode
            // 
            this.tb_1SCode.Location = new System.Drawing.Point(71, 72);
            this.tb_1SCode.MaxLength = 9;
            this.tb_1SCode.Name = "tb_1SCode";
            this.tb_1SCode.Size = new System.Drawing.Size(198, 20);
            this.tb_1SCode.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tb_1SCode, "Код услуги в системе 1С");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Код 1С";
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(474, 224);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(25, 25);
            this.btnPicture.TabIndex = 10;
            this.btnPicture.Text = "...";
            this.toolTip1.SetToolTip(this.btnPicture, "Установить иконку");
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.picture_Click);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(288, 121);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(45, 13);
            this.lblImage.TabIndex = 0;
            this.lblImage.Text = "Иконка";
            // 
            // picture
            // 
            this.picture.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.question;
            this.picture.Location = new System.Drawing.Point(339, 121);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(128, 128);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picture.TabIndex = 5;
            this.picture.TabStop = false;
            this.toolTip1.SetToolTip(this.picture, "Картинка, отображаемая на кнопке услуги на терминале");
            // 
            // cbxIsActive
            // 
            this.cbxIsActive.AutoSize = true;
            this.cbxIsActive.Checked = true;
            this.cbxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIsActive.Location = new System.Drawing.Point(71, 98);
            this.cbxIsActive.Name = "cbxIsActive";
            this.cbxIsActive.Size = new System.Drawing.Size(68, 17);
            this.cbxIsActive.TabIndex = 4;
            this.cbxIsActive.Text = "Активна";
            this.toolTip1.SetToolTip(this.cbxIsActive, "Признак активности услуги (доступность оплаты по услуге)");
            this.cbxIsActive.UseVisualStyleBackColor = true;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDescription.Location = new System.Drawing.Point(71, 46);
            this.tbxDescription.MaxLength = 500;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(459, 20);
            this.tbxDescription.TabIndex = 2;
            this.toolTip1.SetToolTip(this.tbxDescription, "Описание услуги");
            this.tbxDescription.Validating += new System.ComponentModel.CancelEventHandler(this.tbxDescription_Validating);
            // 
            // tbxName
            // 
            this.tbxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxName.Location = new System.Drawing.Point(71, 20);
            this.tbxName.MaxLength = 150;
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(459, 20);
            this.tbxName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbxName, "Название услуги");
            this.tbxName.Validating += new System.ComponentModel.CancelEventHandler(this.tbxName_Validating);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(7, 49);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(57, 13);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Описание";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Изображение (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(342, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnSave, "Сохранить услугу");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(448, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnCancel, "Отменить изменения услуги");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InsertServiceRecordForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(560, 309);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbOtherServiceFields);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 345);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(576, 345);
            this.Name = "InsertServiceRecordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление услуги";
            this.gbOtherServiceFields.ResumeLayout(false);
            this.gbOtherServiceFields.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOtherServiceFields;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox cbxIsActive;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.TextBox tb_1SCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btRestoreImage;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox_usePlaceNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton checkBox_parkingWithoutTime;
        private System.Windows.Forms.RadioButton checkBox_parkingPerHour;
        private System.Windows.Forms.RadioButton cbxIsRental;
        private System.Windows.Forms.RadioButton checkBox_otherServices;
    }
}