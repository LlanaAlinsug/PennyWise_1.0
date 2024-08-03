namespace PennyWise
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.W_Btn_Login = new System.Windows.Forms.PictureBox();
            this.W_Btn_CreateAccount = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.W_Btn_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.W_Btn_CreateAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // W_Btn_Login
            // 
            this.W_Btn_Login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.W_Btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.W_Btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.W_Btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.W_Btn_Login.ForeColor = System.Drawing.Color.Transparent;
            this.W_Btn_Login.Location = new System.Drawing.Point(193, 552);
            this.W_Btn_Login.Name = "W_Btn_Login";
            this.W_Btn_Login.Size = new System.Drawing.Size(230, 60);
            this.W_Btn_Login.TabIndex = 0;
            this.W_Btn_Login.TabStop = false;
            this.W_Btn_Login.Click += new System.EventHandler(this.W_Btn_Login_Click);
            // 
            // W_Btn_CreateAccount
            // 
            this.W_Btn_CreateAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.W_Btn_CreateAccount.BackColor = System.Drawing.Color.Transparent;
            this.W_Btn_CreateAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.W_Btn_CreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.W_Btn_CreateAccount.ForeColor = System.Drawing.Color.Transparent;
            this.W_Btn_CreateAccount.Location = new System.Drawing.Point(603, 552);
            this.W_Btn_CreateAccount.Name = "W_Btn_CreateAccount";
            this.W_Btn_CreateAccount.Size = new System.Drawing.Size(230, 60);
            this.W_Btn_CreateAccount.TabIndex = 1;
            this.W_Btn_CreateAccount.TabStop = false;
            this.W_Btn_CreateAccount.Click += new System.EventHandler(this.W_Btn_CreateAccount_Click);
            // 
            // Welcome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_Welcome;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1025, 710);
            this.Controls.Add(this.W_Btn_CreateAccount);
            this.Controls.Add(this.W_Btn_Login);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PennyWise";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Welcome_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Welcome_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.W_Btn_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.W_Btn_CreateAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox W_Btn_Login;
        private System.Windows.Forms.PictureBox W_Btn_CreateAccount;
    }
}

