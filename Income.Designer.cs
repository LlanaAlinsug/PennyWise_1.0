using System.Windows.Forms;

namespace PennyWise
{
    partial class Income
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Income));
            this.Btn_Homepage = new System.Windows.Forms.PictureBox();
            this.Btn_Expense = new System.Windows.Forms.PictureBox();
            this.Btn_Planner = new System.Windows.Forms.PictureBox();
            this.Btn_Summary = new System.Windows.Forms.PictureBox();
            this.Btn_AboutUs = new System.Windows.Forms.PictureBox();
            this.Lbl_Username = new System.Windows.Forms.Label();
            this.I_Lbl_UserID = new System.Windows.Forms.Label();
            this.I_Lbl_LoginID = new System.Windows.Forms.Label();
            this.I_Btn_Source = new System.Windows.Forms.PictureBox();
            this.I_Btn_Save = new System.Windows.Forms.PictureBox();
            this.I_Btn_Delete = new System.Windows.Forms.PictureBox();
            this.I_Btn_Undo = new System.Windows.Forms.PictureBox();
            this.I_Txtb_Amount = new System.Windows.Forms.TextBox();
            this.I_Txtb_Note = new System.Windows.Forms.TextBox();
            this.I_Dtp_Income = new System.Windows.Forms.DateTimePicker();
            this.I_Dgv_Income = new System.Windows.Forms.DataGridView();
            this.I_Cmb_Source = new System.Windows.Forms.ComboBox();
            this.I_Btn_Date = new System.Windows.Forms.PictureBox();
            this.I_Lbl_IncomeID = new System.Windows.Forms.TextBox();
            this.I_Txtb_Search = new System.Windows.Forms.TextBox();
            this.I_Lbl_TotalIncome = new System.Windows.Forms.Label();
            this.I_Lbl_CurrentBalance = new System.Windows.Forms.Label();
            this.I_Btn_Export = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Homepage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Expense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Planner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Summary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_AboutUs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Undo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Dgv_Income)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Export)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Homepage
            // 
            this.Btn_Homepage.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Homepage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Homepage.Location = new System.Drawing.Point(0, 0);
            this.Btn_Homepage.Name = "Btn_Homepage";
            this.Btn_Homepage.Size = new System.Drawing.Size(256, 70);
            this.Btn_Homepage.TabIndex = 0;
            this.Btn_Homepage.TabStop = false;
            this.Btn_Homepage.Click += new System.EventHandler(this.Btn_Homepage_Click);
            // 
            // Btn_Expense
            // 
            this.Btn_Expense.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Expense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Expense.Location = new System.Drawing.Point(403, 0);
            this.Btn_Expense.Name = "Btn_Expense";
            this.Btn_Expense.Size = new System.Drawing.Size(151, 70);
            this.Btn_Expense.TabIndex = 1;
            this.Btn_Expense.TabStop = false;
            this.Btn_Expense.Click += new System.EventHandler(this.Btn_Expense_Click);
            // 
            // Btn_Planner
            // 
            this.Btn_Planner.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Planner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Planner.Location = new System.Drawing.Point(553, 0);
            this.Btn_Planner.Name = "Btn_Planner";
            this.Btn_Planner.Size = new System.Drawing.Size(150, 70);
            this.Btn_Planner.TabIndex = 2;
            this.Btn_Planner.TabStop = false;
            this.Btn_Planner.Click += new System.EventHandler(this.Btn_Planner_Click);
            // 
            // Btn_Summary
            // 
            this.Btn_Summary.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Summary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Summary.Location = new System.Drawing.Point(701, 0);
            this.Btn_Summary.Name = "Btn_Summary";
            this.Btn_Summary.Size = new System.Drawing.Size(150, 70);
            this.Btn_Summary.TabIndex = 3;
            this.Btn_Summary.TabStop = false;
            this.Btn_Summary.Click += new System.EventHandler(this.Btn_Summary_Click);
            // 
            // Btn_AboutUs
            // 
            this.Btn_AboutUs.BackColor = System.Drawing.Color.Transparent;
            this.Btn_AboutUs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_AboutUs.Location = new System.Drawing.Point(851, 0);
            this.Btn_AboutUs.Name = "Btn_AboutUs";
            this.Btn_AboutUs.Size = new System.Drawing.Size(173, 70);
            this.Btn_AboutUs.TabIndex = 4;
            this.Btn_AboutUs.TabStop = false;
            this.Btn_AboutUs.Click += new System.EventHandler(this.Btn_AboutUs_Click);
            // 
            // Lbl_Username
            // 
            this.Lbl_Username.AutoSize = true;
            this.Lbl_Username.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Username.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Lbl_Username.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lbl_Username.Font = new System.Drawing.Font("Tw Cen MT", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.Lbl_Username.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Lbl_Username.Location = new System.Drawing.Point(856, 25);
            this.Lbl_Username.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_Username.Name = "Lbl_Username";
            this.Lbl_Username.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_Username.Size = new System.Drawing.Size(100, 27);
            this.Lbl_Username.TabIndex = 5;
            this.Lbl_Username.Text = "username";
            this.Lbl_Username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Lbl_Username.Click += new System.EventHandler(this.Lbl_Username_Click);
            // 
            // I_Lbl_UserID
            // 
            this.I_Lbl_UserID.AutoSize = true;
            this.I_Lbl_UserID.BackColor = System.Drawing.Color.Transparent;
            this.I_Lbl_UserID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.I_Lbl_UserID.Font = new System.Drawing.Font("Tw Cen MT", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Lbl_UserID.Location = new System.Drawing.Point(6, 672);
            this.I_Lbl_UserID.Name = "I_Lbl_UserID";
            this.I_Lbl_UserID.Size = new System.Drawing.Size(39, 15);
            this.I_Lbl_UserID.TabIndex = 21;
            this.I_Lbl_UserID.Text = "userID";
            this.I_Lbl_UserID.Visible = false;
            // 
            // I_Lbl_LoginID
            // 
            this.I_Lbl_LoginID.AutoSize = true;
            this.I_Lbl_LoginID.BackColor = System.Drawing.Color.Transparent;
            this.I_Lbl_LoginID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.I_Lbl_LoginID.Font = new System.Drawing.Font("Tw Cen MT", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Lbl_LoginID.Location = new System.Drawing.Point(6, 687);
            this.I_Lbl_LoginID.Name = "I_Lbl_LoginID";
            this.I_Lbl_LoginID.Size = new System.Drawing.Size(44, 15);
            this.I_Lbl_LoginID.TabIndex = 22;
            this.I_Lbl_LoginID.Text = "loginID";
            this.I_Lbl_LoginID.Visible = false;
            // 
            // I_Btn_Source
            // 
            this.I_Btn_Source.BackColor = System.Drawing.Color.Transparent;
            this.I_Btn_Source.Cursor = System.Windows.Forms.Cursors.Hand;
            this.I_Btn_Source.Location = new System.Drawing.Point(521, 308);
            this.I_Btn_Source.Name = "I_Btn_Source";
            this.I_Btn_Source.Size = new System.Drawing.Size(116, 30);
            this.I_Btn_Source.TabIndex = 12;
            this.I_Btn_Source.TabStop = false;
            this.I_Btn_Source.Click += new System.EventHandler(this.I_Btn_Source_Click);
            // 
            // I_Btn_Save
            // 
            this.I_Btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.I_Btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.I_Btn_Save.Location = new System.Drawing.Point(271, 411);
            this.I_Btn_Save.Name = "I_Btn_Save";
            this.I_Btn_Save.Size = new System.Drawing.Size(116, 30);
            this.I_Btn_Save.TabIndex = 10;
            this.I_Btn_Save.TabStop = false;
            this.I_Btn_Save.Click += new System.EventHandler(this.I_Btn_Save_Click);
            // 
            // I_Btn_Delete
            // 
            this.I_Btn_Delete.BackColor = System.Drawing.Color.Transparent;
            this.I_Btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.I_Btn_Delete.Location = new System.Drawing.Point(237, 412);
            this.I_Btn_Delete.Name = "I_Btn_Delete";
            this.I_Btn_Delete.Size = new System.Drawing.Size(26, 30);
            this.I_Btn_Delete.TabIndex = 11;
            this.I_Btn_Delete.TabStop = false;
            this.I_Btn_Delete.Click += new System.EventHandler(this.I_Btn_Delete_Click);
            // 
            // I_Btn_Undo
            // 
            this.I_Btn_Undo.BackColor = System.Drawing.Color.Transparent;
            this.I_Btn_Undo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.I_Btn_Undo.Location = new System.Drawing.Point(770, 311);
            this.I_Btn_Undo.Name = "I_Btn_Undo";
            this.I_Btn_Undo.Size = new System.Drawing.Size(25, 25);
            this.I_Btn_Undo.TabIndex = 17;
            this.I_Btn_Undo.TabStop = false;
            this.I_Btn_Undo.Click += new System.EventHandler(this.I_Btn_Undo_Click);
            // 
            // I_Txtb_Amount
            // 
            this.I_Txtb_Amount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.I_Txtb_Amount.BackColor = System.Drawing.Color.Linen;
            this.I_Txtb_Amount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.I_Txtb_Amount.Font = new System.Drawing.Font("Tw Cen MT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Txtb_Amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.I_Txtb_Amount.Location = new System.Drawing.Point(194, 260);
            this.I_Txtb_Amount.Name = "I_Txtb_Amount";
            this.I_Txtb_Amount.Size = new System.Drawing.Size(178, 26);
            this.I_Txtb_Amount.TabIndex = 7;
            this.I_Txtb_Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.I_Txtb_Amount_KeyPress);
            // 
            // I_Txtb_Note
            // 
            this.I_Txtb_Note.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.I_Txtb_Note.BackColor = System.Drawing.Color.Linen;
            this.I_Txtb_Note.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.I_Txtb_Note.Font = new System.Drawing.Font("Tw Cen MT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Txtb_Note.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.I_Txtb_Note.Location = new System.Drawing.Point(149, 367);
            this.I_Txtb_Note.Name = "I_Txtb_Note";
            this.I_Txtb_Note.Size = new System.Drawing.Size(230, 26);
            this.I_Txtb_Note.TabIndex = 9;
            // 
            // I_Dtp_Income
            // 
            this.I_Dtp_Income.CalendarForeColor = System.Drawing.Color.Linen;
            this.I_Dtp_Income.CalendarMonthBackground = System.Drawing.Color.Linen;
            this.I_Dtp_Income.CalendarTitleBackColor = System.Drawing.Color.Linen;
            this.I_Dtp_Income.CalendarTitleForeColor = System.Drawing.Color.Linen;
            this.I_Dtp_Income.CalendarTrailingForeColor = System.Drawing.Color.Linen;
            this.I_Dtp_Income.Font = new System.Drawing.Font("Tw Cen MT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Dtp_Income.Location = new System.Drawing.Point(140, 311);
            this.I_Dtp_Income.Name = "I_Dtp_Income";
            this.I_Dtp_Income.Size = new System.Drawing.Size(249, 33);
            this.I_Dtp_Income.TabIndex = 8;
            // 
            // I_Dgv_Income
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(84)))), ((int)(((byte)(62)))));
            this.I_Dgv_Income.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.I_Dgv_Income.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.I_Dgv_Income.BackgroundColor = System.Drawing.Color.Linen;
            this.I_Dgv_Income.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(84)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.I_Dgv_Income.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.I_Dgv_Income.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(84)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.I_Dgv_Income.DefaultCellStyle = dataGridViewCellStyle3;
            this.I_Dgv_Income.GridColor = System.Drawing.Color.Linen;
            this.I_Dgv_Income.Location = new System.Drawing.Point(435, 356);
            this.I_Dgv_Income.Name = "I_Dgv_Income";
            this.I_Dgv_Income.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(84)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.I_Dgv_Income.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.I_Dgv_Income.RowHeadersWidth = 51;
            this.I_Dgv_Income.RowTemplate.Height = 24;
            this.I_Dgv_Income.Size = new System.Drawing.Size(536, 282);
            this.I_Dgv_Income.TabIndex = 18;
            this.I_Dgv_Income.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.I_Dgv_Income_CellContentClick);
            // 
            // I_Cmb_Source
            // 
            this.I_Cmb_Source.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.I_Cmb_Source.BackColor = System.Drawing.Color.Linen;
            this.I_Cmb_Source.Cursor = System.Windows.Forms.Cursors.Default;
            this.I_Cmb_Source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.I_Cmb_Source.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.I_Cmb_Source.Font = new System.Drawing.Font("Tw Cen MT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Cmb_Source.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.I_Cmb_Source.FormattingEnabled = true;
            this.I_Cmb_Source.Items.AddRange(new object[] {
            "Salary",
            "Allowance",
            "Others"});
            this.I_Cmb_Source.Location = new System.Drawing.Point(140, 199);
            this.I_Cmb_Source.Margin = new System.Windows.Forms.Padding(0);
            this.I_Cmb_Source.Name = "I_Cmb_Source";
            this.I_Cmb_Source.Size = new System.Drawing.Size(249, 35);
            this.I_Cmb_Source.TabIndex = 6;
            // 
            // I_Btn_Date
            // 
            this.I_Btn_Date.BackColor = System.Drawing.Color.Transparent;
            this.I_Btn_Date.Cursor = System.Windows.Forms.Cursors.Hand;
            this.I_Btn_Date.Location = new System.Drawing.Point(645, 308);
            this.I_Btn_Date.Name = "I_Btn_Date";
            this.I_Btn_Date.Size = new System.Drawing.Size(116, 30);
            this.I_Btn_Date.TabIndex = 16;
            this.I_Btn_Date.TabStop = false;
            this.I_Btn_Date.Click += new System.EventHandler(this.I_Btn_Date_Click);
            // 
            // I_Lbl_IncomeID
            // 
            this.I_Lbl_IncomeID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.I_Lbl_IncomeID.BackColor = System.Drawing.Color.Linen;
            this.I_Lbl_IncomeID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.I_Lbl_IncomeID.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Lbl_IncomeID.ForeColor = System.Drawing.Color.Black;
            this.I_Lbl_IncomeID.Location = new System.Drawing.Point(78, 182);
            this.I_Lbl_IncomeID.Name = "I_Lbl_IncomeID";
            this.I_Lbl_IncomeID.Size = new System.Drawing.Size(42, 22);
            this.I_Lbl_IncomeID.TabIndex = 22;
            this.I_Lbl_IncomeID.Visible = false;
            // 
            // I_Txtb_Search
            // 
            this.I_Txtb_Search.BackColor = System.Drawing.Color.Linen;
            this.I_Txtb_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.I_Txtb_Search.Font = new System.Drawing.Font("Tw Cen MT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Txtb_Search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.I_Txtb_Search.Location = new System.Drawing.Point(521, 260);
            this.I_Txtb_Search.Name = "I_Txtb_Search";
            this.I_Txtb_Search.Size = new System.Drawing.Size(438, 26);
            this.I_Txtb_Search.TabIndex = 14;
            this.I_Txtb_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.I_Txtb_Search_KeyDown);
            // 
            // I_Lbl_TotalIncome
            // 
            this.I_Lbl_TotalIncome.BackColor = System.Drawing.Color.Transparent;
            this.I_Lbl_TotalIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.I_Lbl_TotalIncome.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Lbl_TotalIncome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(84)))), ((int)(((byte)(62)))));
            this.I_Lbl_TotalIncome.Location = new System.Drawing.Point(581, 207);
            this.I_Lbl_TotalIncome.Name = "I_Lbl_TotalIncome";
            this.I_Lbl_TotalIncome.Size = new System.Drawing.Size(88, 19);
            this.I_Lbl_TotalIncome.TabIndex = 12;
            this.I_Lbl_TotalIncome.Text = "0.00";
            this.I_Lbl_TotalIncome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // I_Lbl_CurrentBalance
            // 
            this.I_Lbl_CurrentBalance.BackColor = System.Drawing.Color.Transparent;
            this.I_Lbl_CurrentBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.I_Lbl_CurrentBalance.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Lbl_CurrentBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(84)))), ((int)(((byte)(62)))));
            this.I_Lbl_CurrentBalance.Location = new System.Drawing.Point(876, 207);
            this.I_Lbl_CurrentBalance.Name = "I_Lbl_CurrentBalance";
            this.I_Lbl_CurrentBalance.Size = new System.Drawing.Size(83, 19);
            this.I_Lbl_CurrentBalance.TabIndex = 13;
            this.I_Lbl_CurrentBalance.Text = "0.00";
            this.I_Lbl_CurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // I_Btn_Export
            // 
            this.I_Btn_Export.BackColor = System.Drawing.Color.Transparent;
            this.I_Btn_Export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.I_Btn_Export.Location = new System.Drawing.Point(837, 653);
            this.I_Btn_Export.Name = "I_Btn_Export";
            this.I_Btn_Export.Size = new System.Drawing.Size(134, 34);
            this.I_Btn_Export.TabIndex = 19;
            this.I_Btn_Export.TabStop = false;
            this.I_Btn_Export.Click += new System.EventHandler(this.I_Btn_Export_Click);
            // 
            // Income
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_Income;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1025, 710);
            this.Controls.Add(this.I_Btn_Export);
            this.Controls.Add(this.I_Lbl_CurrentBalance);
            this.Controls.Add(this.I_Lbl_TotalIncome);
            this.Controls.Add(this.I_Txtb_Search);
            this.Controls.Add(this.I_Lbl_IncomeID);
            this.Controls.Add(this.I_Btn_Date);
            this.Controls.Add(this.I_Cmb_Source);
            this.Controls.Add(this.I_Dgv_Income);
            this.Controls.Add(this.I_Dtp_Income);
            this.Controls.Add(this.I_Txtb_Note);
            this.Controls.Add(this.I_Txtb_Amount);
            this.Controls.Add(this.I_Btn_Undo);
            this.Controls.Add(this.I_Btn_Delete);
            this.Controls.Add(this.I_Btn_Save);
            this.Controls.Add(this.I_Btn_Source);
            this.Controls.Add(this.I_Lbl_LoginID);
            this.Controls.Add(this.I_Lbl_UserID);
            this.Controls.Add(this.Lbl_Username);
            this.Controls.Add(this.Btn_AboutUs);
            this.Controls.Add(this.Btn_Summary);
            this.Controls.Add(this.Btn_Planner);
            this.Controls.Add(this.Btn_Expense);
            this.Controls.Add(this.Btn_Homepage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Income";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PennyWise";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Income_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Income_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Homepage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Expense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Planner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Summary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_AboutUs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Undo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Dgv_Income)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_Btn_Export)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Btn_Homepage;
        private System.Windows.Forms.PictureBox Btn_Expense;
        private System.Windows.Forms.PictureBox Btn_Planner;
        private System.Windows.Forms.PictureBox Btn_Summary;
        private System.Windows.Forms.PictureBox Btn_AboutUs;
        private System.Windows.Forms.Label Lbl_Username;
        private System.Windows.Forms.Label I_Lbl_UserID;
        private System.Windows.Forms.Label I_Lbl_LoginID;
        private System.Windows.Forms.PictureBox I_Btn_Source;
        private System.Windows.Forms.PictureBox I_Btn_Save;
        private System.Windows.Forms.PictureBox I_Btn_Delete;
        private System.Windows.Forms.PictureBox I_Btn_Undo;
        private System.Windows.Forms.TextBox I_Txtb_Amount;
        private System.Windows.Forms.TextBox I_Txtb_Note;
        private System.Windows.Forms.DateTimePicker I_Dtp_Income;
        private System.Windows.Forms.DataGridView I_Dgv_Income;
        private ComboBox I_Cmb_Source;
        private PictureBox I_Btn_Date;
        private TextBox I_Lbl_IncomeID;
        private TextBox I_Txtb_Search;
        private Label I_Lbl_TotalIncome;
        private Label I_Lbl_CurrentBalance;
        private PictureBox I_Btn_Export;
    }
}