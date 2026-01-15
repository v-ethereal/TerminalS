namespace Shtrih.ParkMaster.CardsManagerUtil
{
    /// <summary>
    /// Форма тестирования работы с картой и ридером
    /// </summary>
    partial class frmCardsManagerTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCardsManagerTest));
            this.lvLOG = new System.Windows.Forms.ListView();
            this.colMessage = new System.Windows.Forms.ColumnHeader();
            this.ImgListParams = new System.Windows.Forms.ImageList(this.components);
            this.toolConfigReader = new System.Windows.Forms.ToolStrip();
            this.tslbComPort = new System.Windows.Forms.ToolStripLabel();
            this.tslbComPortValue = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTypeCard = new System.Windows.Forms.ToolStripLabel();
            this.CardTypeConfig = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripCommands = new System.Windows.Forms.ToolStrip();
            this.tsbtEjectCard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslbCurrentAccount = new System.Windows.Forms.ToolStripLabel();
            this.tscbAccountNumber = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtImportAccount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtWriteDate = new System.Windows.Forms.ToolStripButton();
            this.tsbtWriteAccount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtReadAccount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtReset = new System.Windows.Forms.ToolStripButton();
            this.toolConfigReader.SuspendLayout();
            this.toolStripCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLOG
            // 
            this.lvLOG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLOG.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMessage});
            this.lvLOG.FullRowSelect = true;
            this.lvLOG.Location = new System.Drawing.Point(0, 53);
            this.lvLOG.MultiSelect = false;
            this.lvLOG.Name = "lvLOG";
            this.lvLOG.Size = new System.Drawing.Size(828, 372);
            this.lvLOG.SmallImageList = this.ImgListParams;
            this.lvLOG.TabIndex = 25;
            this.lvLOG.UseCompatibleStateImageBehavior = false;
            this.lvLOG.View = System.Windows.Forms.View.Details;
            // 
            // colMessage
            // 
            this.colMessage.Text = "Событие";
            this.colMessage.Width = 824;
            // 
            // ImgListParams
            // 
            this.ImgListParams.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgListParams.ImageStream")));
            this.ImgListParams.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgListParams.Images.SetKeyName(0, "");
            this.ImgListParams.Images.SetKeyName(1, "");
            this.ImgListParams.Images.SetKeyName(2, "");
            // 
            // toolConfigReader
            // 
            this.toolConfigReader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbComPort,
            this.tslbComPortValue,
            this.toolStripSeparator5,
            this.lblTypeCard,
            this.CardTypeConfig});
            this.toolConfigReader.Location = new System.Drawing.Point(0, 0);
            this.toolConfigReader.Name = "toolConfigReader";
            this.toolConfigReader.Size = new System.Drawing.Size(828, 25);
            this.toolConfigReader.TabIndex = 26;
            this.toolConfigReader.Text = "toolStrip1";
            // 
            // tslbComPort
            // 
            this.tslbComPort.Name = "tslbComPort";
            this.tslbComPort.Size = new System.Drawing.Size(88, 22);
            this.tslbComPort.Text = "Подключение:";
            // 
            // tslbComPortValue
            // 
            this.tslbComPortValue.Name = "tslbComPortValue";
            this.tslbComPortValue.Size = new System.Drawing.Size(70, 22);
            this.tslbComPortValue.Text = "отсутствует";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTypeCard
            // 
            this.lblTypeCard.Name = "lblTypeCard";
            this.lblTypeCard.Size = new System.Drawing.Size(100, 22);
            this.lblTypeCard.Text = "Ожидание карты";
            // 
            // CardTypeConfig
            // 
            this.CardTypeConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CardTypeConfig.Items.AddRange(new object[] {
            "Ничего не читать",
            "Мастер-карта",
            "Пользовательская карта"});
            this.CardTypeConfig.Name = "CardTypeConfig";
            this.CardTypeConfig.Size = new System.Drawing.Size(140, 25);
            // 
            // toolStripCommands
            // 
            this.toolStripCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtEjectCard,
            this.toolStripSeparator1,
            this.tslbCurrentAccount,
            this.tscbAccountNumber,
            this.tsbtImportAccount,
            this.toolStripSeparator3,
            this.tsbtWriteDate,
            this.tsbtWriteAccount,
            this.toolStripSeparator2,
            this.tsbtReadAccount,
            this.toolStripSeparator4,
            this.tsbtReset});
            this.toolStripCommands.Location = new System.Drawing.Point(0, 25);
            this.toolStripCommands.Name = "toolStripCommands";
            this.toolStripCommands.Size = new System.Drawing.Size(828, 25);
            this.toolStripCommands.TabIndex = 5;
            this.toolStripCommands.Text = "toolStrip1";
            // 
            // tsbtEjectCard
            // 
            this.tsbtEjectCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtEjectCard.Image = ((System.Drawing.Image)(resources.GetObject("tsbtEjectCard.Image")));
            this.tsbtEjectCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtEjectCard.Name = "tsbtEjectCard";
            this.tsbtEjectCard.Size = new System.Drawing.Size(90, 22);
            this.tsbtEjectCard.Text = "Выброс карты";
            this.tsbtEjectCard.Click += new System.EventHandler(this.tsbtEjectCard_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslbCurrentAccount
            // 
            this.tslbCurrentAccount.Name = "tslbCurrentAccount";
            this.tslbCurrentAccount.Size = new System.Drawing.Size(97, 22);
            this.tslbCurrentAccount.Text = "Текущий тариф:";
            // 
            // tscbAccountNumber
            // 
            this.tscbAccountNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbAccountNumber.Items.AddRange(new object[] {
            "0 - Разовый",
            "1 - Оплачено (15 минут на выезд)",
            "2 - Внешняя оплата на ParkTime",
            "3 - не используется"});
            this.tscbAccountNumber.Name = "tscbAccountNumber";
            this.tscbAccountNumber.Size = new System.Drawing.Size(121, 25);
            // 
            // tsbtImportAccount
            // 
            this.tsbtImportAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtImportAccount.Image = ((System.Drawing.Image)(resources.GetObject("tsbtImportAccount.Image")));
            this.tsbtImportAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtImportAccount.Name = "tsbtImportAccount";
            this.tsbtImportAccount.Size = new System.Drawing.Size(98, 22);
            this.tsbtImportAccount.Text = "Импорт тарифа";
            this.tsbtImportAccount.Click += new System.EventHandler(this.tsbtImportAccount_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtWriteDate
            // 
            this.tsbtWriteDate.Checked = true;
            this.tsbtWriteDate.CheckOnClick = true;
            this.tsbtWriteDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtWriteDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtWriteDate.Image = ((System.Drawing.Image)(resources.GetObject("tsbtWriteDate.Image")));
            this.tsbtWriteDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtWriteDate.Name = "tsbtWriteDate";
            this.tsbtWriteDate.Size = new System.Drawing.Size(89, 22);
            this.tsbtWriteDate.Text = "Менять время";
            this.tsbtWriteDate.Click += new System.EventHandler(this.tsbtWriteDate_Click);
            // 
            // tsbtWriteAccount
            // 
            this.tsbtWriteAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtWriteAccount.Image = ((System.Drawing.Image)(resources.GetObject("tsbtWriteAccount.Image")));
            this.tsbtWriteAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtWriteAccount.Name = "tsbtWriteAccount";
            this.tsbtWriteAccount.Size = new System.Drawing.Size(93, 22);
            this.tsbtWriteAccount.Text = "Запись тарифа";
            this.tsbtWriteAccount.Click += new System.EventHandler(this.tsbtWriteAccount_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtReadAccount
            // 
            this.tsbtReadAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtReadAccount.Image = ((System.Drawing.Image)(resources.GetObject("tsbtReadAccount.Image")));
            this.tsbtReadAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtReadAccount.Name = "tsbtReadAccount";
            this.tsbtReadAccount.Size = new System.Drawing.Size(86, 22);
            this.tsbtReadAccount.Text = "Чтение карты";
            this.tsbtReadAccount.Click += new System.EventHandler(this.tsbtReadAccount_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtReset
            // 
            this.tsbtReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbtReset.Image")));
            this.tsbtReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtReset.Name = "tsbtReset";
            this.tsbtReset.Size = new System.Drawing.Size(46, 22);
            this.tsbtReset.Text = "Сброс";
            this.tsbtReset.Click += new System.EventHandler(this.tsbtReset_Click);
            // 
            // frmCardsManagerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 424);
            this.Controls.Add(this.toolStripCommands);
            this.Controls.Add(this.toolConfigReader);
            this.Controls.Add(this.lvLOG);
            this.Name = "frmCardsManagerTest";
            this.Text = "Тест работы с парковочными картами";
            this.Load += new System.EventHandler(this.frmCardsManagerTest_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCardsManagerTest_FormClosing);
            this.toolConfigReader.ResumeLayout(false);
            this.toolConfigReader.PerformLayout();
            this.toolStripCommands.ResumeLayout(false);
            this.toolStripCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lvLOG;
        internal System.Windows.Forms.ColumnHeader colMessage;
        private System.Windows.Forms.ImageList ImgListParams;
        private System.Windows.Forms.ToolStrip toolConfigReader;
        private System.Windows.Forms.ToolStripComboBox CardTypeConfig;
        private System.Windows.Forms.ToolStripLabel lblTypeCard;
        private System.Windows.Forms.ToolStrip toolStripCommands;
        private System.Windows.Forms.ToolStripButton tsbtEjectCard;
        private System.Windows.Forms.ToolStripButton tsbtReadAccount;
        private System.Windows.Forms.ToolStripButton tsbtImportAccount;
        private System.Windows.Forms.ToolStripButton tsbtWriteAccount;
        private System.Windows.Forms.ToolStripComboBox tscbAccountNumber;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslbCurrentAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtWriteDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtReset;
        private System.Windows.Forms.ToolStripLabel tslbComPort;
        private System.Windows.Forms.ToolStripLabel tslbComPortValue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}

