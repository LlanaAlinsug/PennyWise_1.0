namespace PennyWise
{
    partial class IncomeFilterDate
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
            this.IFD_Dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.IFD_Dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.IFD_Btn_Apply = new System.Windows.Forms.PictureBox();
            this.IFD_Btn_Cancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IFD_Btn_Apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFD_Btn_Cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // IFD_Dtp_StartDate
            // 
            this.IFD_Dtp_StartDate.CalendarForeColor = System.Drawing.Color.Linen;
            this.IFD_Dtp_StartDate.CalendarMonthBackground = System.Drawing.Color.Linen;
            this.IFD_Dtp_StartDate.CalendarTitleBackColor = System.Drawing.Color.Linen;
            this.IFD_Dtp_StartDate.CalendarTitleForeColor = System.Drawing.Color.Linen;
            this.IFD_Dtp_StartDate.CalendarTrailingForeColor = System.Drawing.Color.Linen;
            this.IFD_Dtp_StartDate.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IFD_Dtp_StartDate.Location = new System.Drawing.Point(126, 87);
            this.IFD_Dtp_StartDate.Name = "IFD_Dtp_StartDate";
            this.IFD_Dtp_StartDate.Size = new System.Drawing.Size(198, 28);
            this.IFD_Dtp_StartDate.TabIndex = 0;
            // 
            // IFD_Dtp_EndDate
            // 
            this.IFD_Dtp_EndDate.CalendarForeColor = System.Drawing.Color.Linen;
            this.IFD_Dtp_EndDate.CalendarMonthBackground = System.Drawing.Color.Linen;
            this.IFD_Dtp_EndDate.CalendarTitleBackColor = System.Drawing.Color.Linen;
            this.IFD_Dtp_EndDate.CalendarTitleForeColor = System.Drawing.Color.Linen;
            this.IFD_Dtp_EndDate.CalendarTrailingForeColor = System.Drawing.Color.Linen;
            this.IFD_Dtp_EndDate.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IFD_Dtp_EndDate.Location = new System.Drawing.Point(126, 134);
            this.IFD_Dtp_EndDate.Name = "IFD_Dtp_EndDate";
            this.IFD_Dtp_EndDate.Size = new System.Drawing.Size(198, 28);
            this.IFD_Dtp_EndDate.TabIndex = 1;
            // 
            // IFD_Btn_Apply
            // 
            this.IFD_Btn_Apply.BackColor = System.Drawing.Color.Transparent;
            this.IFD_Btn_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IFD_Btn_Apply.Location = new System.Drawing.Point(231, 189);
            this.IFD_Btn_Apply.Name = "IFD_Btn_Apply";
            this.IFD_Btn_Apply.Size = new System.Drawing.Size(93, 25);
            this.IFD_Btn_Apply.TabIndex = 3;
            this.IFD_Btn_Apply.TabStop = false;
            this.IFD_Btn_Apply.Click += new System.EventHandler(this.IFD_Btn_Apply_Click);
            // 
            // IFD_Btn_Cancel
            // 
            this.IFD_Btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.IFD_Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IFD_Btn_Cancel.Location = new System.Drawing.Point(126, 189);
            this.IFD_Btn_Cancel.Name = "IFD_Btn_Cancel";
            this.IFD_Btn_Cancel.Size = new System.Drawing.Size(93, 25);
            this.IFD_Btn_Cancel.TabIndex = 4;
            this.IFD_Btn_Cancel.TabStop = false;
            this.IFD_Btn_Cancel.Click += new System.EventHandler(this.IFD_Btn_Cancel_Click);
            // 
            // IncomeFilterDate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_IncomeFilterbydate;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.ControlBox = false;
            this.Controls.Add(this.IFD_Btn_Cancel);
            this.Controls.Add(this.IFD_Btn_Apply);
            this.Controls.Add(this.IFD_Dtp_EndDate);
            this.Controls.Add(this.IFD_Dtp_StartDate);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncomeFilterDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.IncomeFilterDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IFD_Btn_Apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFD_Btn_Cancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker IFD_Dtp_StartDate;
        private System.Windows.Forms.DateTimePicker IFD_Dtp_EndDate;
        private System.Windows.Forms.PictureBox IFD_Btn_Apply;
        private System.Windows.Forms.PictureBox IFD_Btn_Cancel;
    }
}