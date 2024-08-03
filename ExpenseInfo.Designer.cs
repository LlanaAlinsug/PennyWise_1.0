namespace PennyWise
{
    partial class ExpenseInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseInfo));
            this.EI_Btn_Back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.EI_Btn_Back)).BeginInit();
            this.SuspendLayout();
            // 
            // EI_Btn_Back
            // 
            this.EI_Btn_Back.BackColor = System.Drawing.Color.Transparent;
            this.EI_Btn_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EI_Btn_Back.Location = new System.Drawing.Point(33, 628);
            this.EI_Btn_Back.Name = "EI_Btn_Back";
            this.EI_Btn_Back.Size = new System.Drawing.Size(153, 42);
            this.EI_Btn_Back.TabIndex = 12;
            this.EI_Btn_Back.TabStop = false;
            this.EI_Btn_Back.Click += new System.EventHandler(this.EI_Btn_Back_Click);
            // 
            // ExpenseInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_ExpenseInfo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1025, 710);
            this.Controls.Add(this.EI_Btn_Back);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpenseInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PennyWise";
            ((System.ComponentModel.ISupportInitialize)(this.EI_Btn_Back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox EI_Btn_Back;
    }
}