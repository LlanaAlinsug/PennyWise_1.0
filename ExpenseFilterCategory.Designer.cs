namespace PennyWise
{
    partial class ExpenseFilterCategory
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
            this.EFC_Btn_Cancel = new System.Windows.Forms.PictureBox();
            this.EFC_Btn_Apply = new System.Windows.Forms.PictureBox();
            this.EFC_Cmb_Category = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.EFC_Btn_Cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFC_Btn_Apply)).BeginInit();
            this.SuspendLayout();
            // 
            // EFC_Btn_Cancel
            // 
            this.EFC_Btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.EFC_Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EFC_Btn_Cancel.Location = new System.Drawing.Point(20, 153);
            this.EFC_Btn_Cancel.Name = "EFC_Btn_Cancel";
            this.EFC_Btn_Cancel.Size = new System.Drawing.Size(98, 28);
            this.EFC_Btn_Cancel.TabIndex = 4;
            this.EFC_Btn_Cancel.TabStop = false;
            this.EFC_Btn_Cancel.Click += new System.EventHandler(this.EFC_Btn_Cancel_Click);
            // 
            // EFC_Btn_Apply
            // 
            this.EFC_Btn_Apply.BackColor = System.Drawing.Color.Transparent;
            this.EFC_Btn_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EFC_Btn_Apply.Location = new System.Drawing.Point(129, 153);
            this.EFC_Btn_Apply.Name = "EFC_Btn_Apply";
            this.EFC_Btn_Apply.Size = new System.Drawing.Size(98, 28);
            this.EFC_Btn_Apply.TabIndex = 3;
            this.EFC_Btn_Apply.TabStop = false;
            this.EFC_Btn_Apply.Click += new System.EventHandler(this.EFC_Btn_Apply_Click);
            // 
            // EFC_Cmb_Category
            // 
            this.EFC_Cmb_Category.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.EFC_Cmb_Category.BackColor = System.Drawing.Color.Linen;
            this.EFC_Cmb_Category.Cursor = System.Windows.Forms.Cursors.Default;
            this.EFC_Cmb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EFC_Cmb_Category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EFC_Cmb_Category.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EFC_Cmb_Category.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.EFC_Cmb_Category.FormattingEnabled = true;
            this.EFC_Cmb_Category.Items.AddRange(new object[] {
            "Needs",
            "Wants",
            "Funds"});
            this.EFC_Cmb_Category.Location = new System.Drawing.Point(20, 100);
            this.EFC_Cmb_Category.Margin = new System.Windows.Forms.Padding(0);
            this.EFC_Cmb_Category.Name = "EFC_Cmb_Category";
            this.EFC_Cmb_Category.Size = new System.Drawing.Size(207, 30);
            this.EFC_Cmb_Category.TabIndex = 0;
            // 
            // ExpenseFilterCategory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_ExpenseFilterbycategory;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.ControlBox = false;
            this.Controls.Add(this.EFC_Btn_Cancel);
            this.Controls.Add(this.EFC_Btn_Apply);
            this.Controls.Add(this.EFC_Cmb_Category);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpenseFilterCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.EFC_Btn_Cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFC_Btn_Apply)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox EFC_Btn_Cancel;
        private System.Windows.Forms.PictureBox EFC_Btn_Apply;
        private System.Windows.Forms.ComboBox EFC_Cmb_Category;

    }
}