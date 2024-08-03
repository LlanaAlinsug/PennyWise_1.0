namespace PennyWise
{
    partial class CreateAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccount));
            this.C_Txtb_Username = new System.Windows.Forms.TextBox();
            this.C_Txtb_Password = new System.Windows.Forms.TextBox();
            this.C_Txtb_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.C_Btn_CreateAccount = new System.Windows.Forms.PictureBox();
            this.C_Btn_Back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.C_Btn_CreateAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_Btn_Back)).BeginInit();
            this.SuspendLayout();
            // 
            // C_Txtb_Username
            // 
            this.C_Txtb_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Txtb_Username.BackColor = System.Drawing.Color.Linen;
            this.C_Txtb_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.C_Txtb_Username.Font = new System.Drawing.Font("Tw Cen MT", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C_Txtb_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.C_Txtb_Username.Location = new System.Drawing.Point(486, 317);
            this.C_Txtb_Username.Name = "C_Txtb_Username";
            this.C_Txtb_Username.Size = new System.Drawing.Size(339, 29);
            this.C_Txtb_Username.TabIndex = 0;
            this.C_Txtb_Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C_Txtb_Username_KeyDown);
            // 
            // C_Txtb_Password
            // 
            this.C_Txtb_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Txtb_Password.BackColor = System.Drawing.Color.Linen;
            this.C_Txtb_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.C_Txtb_Password.Font = new System.Drawing.Font("Tw Cen MT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C_Txtb_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.C_Txtb_Password.Location = new System.Drawing.Point(486, 387);
            this.C_Txtb_Password.Name = "C_Txtb_Password";
            this.C_Txtb_Password.PasswordChar = '*';
            this.C_Txtb_Password.Size = new System.Drawing.Size(339, 29);
            this.C_Txtb_Password.TabIndex = 1;
            this.C_Txtb_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C_Txtb_Password_KeyDown);
            // 
            // C_Txtb_ConfirmPassword
            // 
            this.C_Txtb_ConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Txtb_ConfirmPassword.BackColor = System.Drawing.Color.Linen;
            this.C_Txtb_ConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.C_Txtb_ConfirmPassword.Font = new System.Drawing.Font("Tw Cen MT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C_Txtb_ConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.C_Txtb_ConfirmPassword.Location = new System.Drawing.Point(486, 454);
            this.C_Txtb_ConfirmPassword.Name = "C_Txtb_ConfirmPassword";
            this.C_Txtb_ConfirmPassword.PasswordChar = '*';
            this.C_Txtb_ConfirmPassword.Size = new System.Drawing.Size(339, 29);
            this.C_Txtb_ConfirmPassword.TabIndex = 5;
            this.C_Txtb_ConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.C_Txtb_ConfirmPassword_KeyDown);
            // 
            // C_Btn_CreateAccount
            // 
            this.C_Btn_CreateAccount.BackColor = System.Drawing.Color.Transparent;
            this.C_Btn_CreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.C_Btn_CreateAccount.Location = new System.Drawing.Point(540, 525);
            this.C_Btn_CreateAccount.Name = "C_Btn_CreateAccount";
            this.C_Btn_CreateAccount.Size = new System.Drawing.Size(230, 60);
            this.C_Btn_CreateAccount.TabIndex = 3;
            this.C_Btn_CreateAccount.TabStop = false;
            this.C_Btn_CreateAccount.Click += new System.EventHandler(this.C_Btn_CreateAccount_Click);
            // 
            // C_Btn_Back
            // 
            this.C_Btn_Back.BackColor = System.Drawing.Color.Transparent;
            this.C_Btn_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.C_Btn_Back.Location = new System.Drawing.Point(0, 41);
            this.C_Btn_Back.Name = "C_Btn_Back";
            this.C_Btn_Back.Size = new System.Drawing.Size(110, 60);
            this.C_Btn_Back.TabIndex = 4;
            this.C_Btn_Back.TabStop = false;
            this.C_Btn_Back.Click += new System.EventHandler(this.C_Btn_Back_Click);
            // 
            // CreateAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_CreateAccount;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1025, 710);
            this.Controls.Add(this.C_Btn_Back);
            this.Controls.Add(this.C_Btn_CreateAccount);
            this.Controls.Add(this.C_Txtb_ConfirmPassword);
            this.Controls.Add(this.C_Txtb_Password);
            this.Controls.Add(this.C_Txtb_Username);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PennyWise";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateAccount_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.C_Btn_CreateAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_Btn_Back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox C_Txtb_Username;
        private System.Windows.Forms.TextBox C_Txtb_Password;
        private System.Windows.Forms.TextBox C_Txtb_ConfirmPassword;
        private System.Windows.Forms.PictureBox C_Btn_CreateAccount;
        private System.Windows.Forms.PictureBox C_Btn_Back;
    }
}