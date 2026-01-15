namespace Arsis.RentalSystem.AdministrationConsole.UserControls
{
    partial class DatesViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_ChooseSplitMode = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvHolidays = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.mcHolidays = new System.Windows.Forms.MonthCalendar();
            this.HolidaysFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.columnHolidayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidays)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HolidaysFilterExtender)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_ChooseSplitMode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 24);
            this.panel1.TabIndex = 0;
            // 
            // bt_ChooseSplitMode
            // 
            this.bt_ChooseSplitMode.Location = new System.Drawing.Point(14, 1);
            this.bt_ChooseSplitMode.Name = "bt_ChooseSplitMode";
            this.bt_ChooseSplitMode.Size = new System.Drawing.Size(184, 23);
            this.bt_ChooseSplitMode.TabIndex = 0;
            this.bt_ChooseSplitMode.Text = "Динамичный текст";
            this.bt_ChooseSplitMode.UseVisualStyleBackColor = true;
            this.bt_ChooseSplitMode.Click += new System.EventHandler(this.bt_ChooseSplitMode_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 434);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvHolidays);
            this.splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.mcHolidays);
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(622, 434);
            this.splitContainer.SplitterDistance = 470;
            this.splitContainer.TabIndex = 0;
            // 
            // dgvHolidays
            // 
            this.dgvHolidays.AllowUserToAddRows = false;
            this.dgvHolidays.AllowUserToDeleteRows = false;
            this.dgvHolidays.AllowUserToOrderColumns = true;
            this.dgvHolidays.AllowUserToResizeRows = false;
            this.dgvHolidays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvHolidays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHolidays.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHolidays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHolidays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnHolidayDate});
            this.dgvHolidays.ContextMenuStrip = this.contextMenu;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHolidays.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHolidays.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHolidays.Location = new System.Drawing.Point(16, 26);
            this.dgvHolidays.MultiSelect = false;
            this.dgvHolidays.Name = "dgvHolidays";
            this.dgvHolidays.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHolidays.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHolidays.RowHeadersVisible = false;
            this.dgvHolidays.RowHeadersWidth = 22;
            this.dgvHolidays.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvHolidays.RowTemplate.ReadOnly = true;
            this.dgvHolidays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHolidays.Size = new System.Drawing.Size(182, 402);
            this.dgvHolidays.TabIndex = 3;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Add,
            this.tsmi_Delete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(136, 48);
            // 
            // tsmi_Add
            // 
            this.tsmi_Add.Name = "tsmi_Add";
            this.tsmi_Add.Size = new System.Drawing.Size(135, 22);
            this.tsmi_Add.Text = "Добавить";
            this.tsmi_Add.Click += new System.EventHandler(this.tsmi_Add_Click);
            // 
            // tsmi_Delete
            // 
            this.tsmi_Delete.Name = "tsmi_Delete";
            this.tsmi_Delete.Size = new System.Drawing.Size(135, 22);
            this.tsmi_Delete.Text = "Удалить";
            this.tsmi_Delete.Click += new System.EventHandler(this.tsmi_Delete_Click);
            // 
            // mcHolidays
            // 
            this.mcHolidays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.mcHolidays.CalendarDimensions = new System.Drawing.Size(3, 3);
            this.mcHolidays.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mcHolidays.Location = new System.Drawing.Point(0, -3);
            this.mcHolidays.MaxSelectionCount = 1;
            this.mcHolidays.Name = "mcHolidays";
            this.mcHolidays.ShowWeekNumbers = true;
            this.mcHolidays.TabIndex = 3;
            this.mcHolidays.TitleBackColor = System.Drawing.Color.LightSteelBlue;
            // 
            // HolidaysFilterExtender
            // 
            this.HolidaysFilterExtender.DataGridView = this.dgvHolidays;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.HolidaysFilterExtender.FilterFactory = defaultGridFilterFactory1;
            this.HolidaysFilterExtender.FilterTextVisible = false;
            // 
            // columnHolidayDate
            // 
            this.columnHolidayDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnHolidayDate.DataPropertyName = "Date";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy г. (dddd)";
            this.columnHolidayDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnHolidayDate.HeaderText = "Дата";
            this.columnHolidayDate.Name = "columnHolidayDate";
            this.columnHolidayDate.ReadOnly = true;
            // 
            // DatesViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DatesViewer";
            this.Size = new System.Drawing.Size(622, 458);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidays)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HolidaysFilterExtender)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_ChooseSplitMode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvHolidays;
        private System.Windows.Forms.MonthCalendar mcHolidays;
        private GridViewExtensions.DataGridFilterExtender HolidaysFilterExtender;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Add;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnHolidayDate;

    }
}
