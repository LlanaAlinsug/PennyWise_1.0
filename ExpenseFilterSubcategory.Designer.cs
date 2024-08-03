namespace PennyWise
{
    partial class ExpenseFilterSubcategory
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
            this.EFS_Btn_Cancel = new System.Windows.Forms.PictureBox();
            this.EFS_Btn_Apply = new System.Windows.Forms.PictureBox();
            this.EFS_Cmb_Subcategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.EFS_Btn_Cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFS_Btn_Apply)).BeginInit();
            this.SuspendLayout();
            // 
            // EFS_Btn_Cancel
            // 
            this.EFS_Btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.EFS_Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EFS_Btn_Cancel.Location = new System.Drawing.Point(20, 153);
            this.EFS_Btn_Cancel.Name = "EFS_Btn_Cancel";
            this.EFS_Btn_Cancel.Size = new System.Drawing.Size(98, 28);
            this.EFS_Btn_Cancel.TabIndex = 4;
            this.EFS_Btn_Cancel.TabStop = false;
            this.EFS_Btn_Cancel.Click += new System.EventHandler(this.EFS_Btn_Cancel_Click);
            // 
            // EFS_Btn_Apply
            // 
            this.EFS_Btn_Apply.BackColor = System.Drawing.Color.Transparent;
            this.EFS_Btn_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EFS_Btn_Apply.Location = new System.Drawing.Point(129, 153);
            this.EFS_Btn_Apply.Name = "EFS_Btn_Apply";
            this.EFS_Btn_Apply.Size = new System.Drawing.Size(98, 28);
            this.EFS_Btn_Apply.TabIndex = 3;
            this.EFS_Btn_Apply.TabStop = false;
            this.EFS_Btn_Apply.Click += new System.EventHandler(this.EFS_Btn_Apply_Click);
            // 
            // EFS_Cmb_Subcategory
            // 
            this.EFS_Cmb_Subcategory.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.EFS_Cmb_Subcategory.BackColor = System.Drawing.Color.Linen;
            this.EFS_Cmb_Subcategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.EFS_Cmb_Subcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EFS_Cmb_Subcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EFS_Cmb_Subcategory.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EFS_Cmb_Subcategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.EFS_Cmb_Subcategory.FormattingEnabled = true;
            this.EFS_Cmb_Subcategory.Items.AddRange(new object[] {
            "Housing/Rent",
            "Utilities",
            "Food/Beverage",
            "Groceries",
            "Transportation",
            "Hygiene",
            "Healthcare",
            "Entertainment",
            "Subscriptions",
            "Leisure",
            "Shopping",
            "Travel",
            "Emergency",
            "Debt/Loan",
            "Tax Payment",
            "Investment",
            "Others"});
            this.EFS_Cmb_Subcategory.Location = new System.Drawing.Point(20, 103);
            this.EFS_Cmb_Subcategory.Margin = new System.Windows.Forms.Padding(0);
            this.EFS_Cmb_Subcategory.Name = "EFS_Cmb_Subcategory";
            this.EFS_Cmb_Subcategory.Size = new System.Drawing.Size(207, 30);
            this.EFS_Cmb_Subcategory.TabIndex = 0;
            // 
            // ExpenseFilterSubcategory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_ExpenseFilterbysubcategory;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.ControlBox = false;
            this.Controls.Add(this.EFS_Btn_Cancel);
            this.Controls.Add(this.EFS_Btn_Apply);
            this.Controls.Add(this.EFS_Cmb_Subcategory);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpenseFilterSubcategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.EFS_Btn_Cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFS_Btn_Apply)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox EFS_Btn_Cancel;
        private System.Windows.Forms.PictureBox EFS_Btn_Apply;
        private System.Windows.Forms.ComboBox EFS_Cmb_Subcategory;
    }
}