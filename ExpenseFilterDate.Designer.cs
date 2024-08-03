namespace PennyWise
{
    partial class ExpenseFilterDate
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
            this.EFD_Dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.EFD_Dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.EFD_Btn_Apply = new System.Windows.Forms.PictureBox();
            this.EFD_Btn_Cancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.EFD_Btn_Apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFD_Btn_Cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // EFD_Dtp_StartDate
            // 
            this.EFD_Dtp_StartDate.CalendarForeColor = System.Drawing.Color.Linen;
            this.EFD_Dtp_StartDate.CalendarMonthBackground = System.Drawing.Color.Linen;
            this.EFD_Dtp_StartDate.CalendarTitleBackColor = System.Drawing.Color.Linen;
            this.EFD_Dtp_StartDate.CalendarTitleForeColor = System.Drawing.Color.Linen;
            this.EFD_Dtp_StartDate.CalendarTrailingForeColor = System.Drawing.Color.Linen;
            this.EFD_Dtp_StartDate.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EFD_Dtp_StartDate.Location = new System.Drawing.Point(126, 86);
            this.EFD_Dtp_StartDate.Name = "EFD_Dtp_StartDate";
            this.EFD_Dtp_StartDate.Size = new System.Drawing.Size(198, 28);
            this.EFD_Dtp_StartDate.TabIndex = 0;
            // 
            // EFD_Dtp_EndDate
            // 
            this.EFD_Dtp_EndDate.CalendarForeColor = System.Drawing.Color.Linen;
            this.EFD_Dtp_EndDate.CalendarMonthBackground = System.Drawing.Color.Linen;
            this.EFD_Dtp_EndDate.CalendarTitleBackColor = System.Drawing.Color.Linen;
            this.EFD_Dtp_EndDate.CalendarTitleForeColor = System.Drawing.Color.Linen;
            this.EFD_Dtp_EndDate.CalendarTrailingForeColor = System.Drawing.Color.Linen;
            this.EFD_Dtp_EndDate.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EFD_Dtp_EndDate.Location = new System.Drawing.Point(126, 135);
            this.EFD_Dtp_EndDate.Name = "EFD_Dtp_EndDate";
            this.EFD_Dtp_EndDate.Size = new System.Drawing.Size(198, 28);
            this.EFD_Dtp_EndDate.TabIndex = 1;
            // 
            // EFD_Btn_Apply
            // 
            this.EFD_Btn_Apply.BackColor = System.Drawing.Color.Transparent;
            this.EFD_Btn_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EFD_Btn_Apply.Location = new System.Drawing.Point(231, 189);
            this.EFD_Btn_Apply.Name = "EFD_Btn_Apply";
            this.EFD_Btn_Apply.Size = new System.Drawing.Size(93, 25);
            this.EFD_Btn_Apply.TabIndex = 3;
            this.EFD_Btn_Apply.TabStop = false;
            this.EFD_Btn_Apply.Click += new System.EventHandler(this.EFD_Btn_Apply_Click);
            // 
            // EFD_Btn_Cancel
            // 
            this.EFD_Btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.EFD_Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EFD_Btn_Cancel.Location = new System.Drawing.Point(126, 189);
            this.EFD_Btn_Cancel.Name = "EFD_Btn_Cancel";
            this.EFD_Btn_Cancel.Size = new System.Drawing.Size(93, 25);
            this.EFD_Btn_Cancel.TabIndex = 4;
            this.EFD_Btn_Cancel.TabStop = false;
            this.EFD_Btn_Cancel.Click += new System.EventHandler(this.EFD_Btn_Cancel_Click);
            // 
            // ExpenseFilterDate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_ExpenseFilterbydate;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.ControlBox = false;
            this.Controls.Add(this.EFD_Btn_Cancel);
            this.Controls.Add(this.EFD_Btn_Apply);
            this.Controls.Add(this.EFD_Dtp_EndDate);
            this.Controls.Add(this.EFD_Dtp_StartDate);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpenseFilterDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ExpenseFilterDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EFD_Btn_Apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFD_Btn_Cancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker EFD_Dtp_StartDate;
        private System.Windows.Forms.DateTimePicker EFD_Dtp_EndDate;
        private System.Windows.Forms.PictureBox EFD_Btn_Cancel;
        private System.Windows.Forms.PictureBox EFD_Btn_Apply;
    }
}