namespace PennyWise
{
    partial class IncomeFilterSource
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
            this.IFS_Cmb_Source = new System.Windows.Forms.ComboBox();
            this.IFS_Btn_Apply = new System.Windows.Forms.PictureBox();
            this.IFS_Btn_Cancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IFS_Btn_Apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFS_Btn_Cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // IFS_Cmb_Source
            // 
            this.IFS_Cmb_Source.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IFS_Cmb_Source.BackColor = System.Drawing.Color.Linen;
            this.IFS_Cmb_Source.Cursor = System.Windows.Forms.Cursors.Default;
            this.IFS_Cmb_Source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IFS_Cmb_Source.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IFS_Cmb_Source.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IFS_Cmb_Source.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.IFS_Cmb_Source.FormattingEnabled = true;
            this.IFS_Cmb_Source.Items.AddRange(new object[] {
            "Salary",
            "Allowance",
            "Others"});
            this.IFS_Cmb_Source.Location = new System.Drawing.Point(20, 82);
            this.IFS_Cmb_Source.Margin = new System.Windows.Forms.Padding(0);
            this.IFS_Cmb_Source.Name = "IFS_Cmb_Source";
            this.IFS_Cmb_Source.Size = new System.Drawing.Size(207, 30);
            this.IFS_Cmb_Source.TabIndex = 0;
            // 
            // IFS_Btn_Apply
            // 
            this.IFS_Btn_Apply.BackColor = System.Drawing.Color.Transparent;
            this.IFS_Btn_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IFS_Btn_Apply.Location = new System.Drawing.Point(129, 135);
            this.IFS_Btn_Apply.Name = "IFS_Btn_Apply";
            this.IFS_Btn_Apply.Size = new System.Drawing.Size(98, 28);
            this.IFS_Btn_Apply.TabIndex = 3;
            this.IFS_Btn_Apply.TabStop = false;
            this.IFS_Btn_Apply.Click += new System.EventHandler(this.IFS_Btn_Apply_Click);
            // 
            // IFS_Btn_Cancel
            // 
            this.IFS_Btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.IFS_Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IFS_Btn_Cancel.Location = new System.Drawing.Point(20, 135);
            this.IFS_Btn_Cancel.Name = "IFS_Btn_Cancel";
            this.IFS_Btn_Cancel.Size = new System.Drawing.Size(98, 28);
            this.IFS_Btn_Cancel.TabIndex = 4;
            this.IFS_Btn_Cancel.TabStop = false;
            this.IFS_Btn_Cancel.Click += new System.EventHandler(this.IFS_Btn_Cancel_Click);
            // 
            // IncomeFilterSource
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_IncomeFilterbysource;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.ControlBox = false;
            this.Controls.Add(this.IFS_Btn_Cancel);
            this.Controls.Add(this.IFS_Btn_Apply);
            this.Controls.Add(this.IFS_Cmb_Source);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncomeFilterSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IncomeFilterSource_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.IFS_Btn_Apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFS_Btn_Cancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox IFS_Cmb_Source;
        private System.Windows.Forms.PictureBox IFS_Btn_Apply;
        private System.Windows.Forms.PictureBox IFS_Btn_Cancel;
    }
}