namespace PennyWise
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.L_Btn_Login = new System.Windows.Forms.PictureBox();
            this.L_Btn_Back = new System.Windows.Forms.PictureBox();
            this.L_Txtb_Username = new System.Windows.Forms.TextBox();
            this.L_Txtb_Password = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.L_Btn_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.L_Btn_Back)).BeginInit();
            this.SuspendLayout();
            // 
            // L_Btn_Login
            // 
            this.L_Btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.L_Btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_Btn_Login.Location = new System.Drawing.Point(500, 509);
            this.L_Btn_Login.Name = "L_Btn_Login";
            this.L_Btn_Login.Size = new System.Drawing.Size(230, 60);
            this.L_Btn_Login.TabIndex = 3;
            this.L_Btn_Login.TabStop = false;
            this.L_Btn_Login.Click += new System.EventHandler(this.L_Btn_Login_Click);
            // 
            // L_Btn_Back
            // 
            this.L_Btn_Back.BackColor = System.Drawing.Color.Transparent;
            this.L_Btn_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_Btn_Back.Location = new System.Drawing.Point(0, 41);
            this.L_Btn_Back.Name = "L_Btn_Back";
            this.L_Btn_Back.Size = new System.Drawing.Size(110, 60);
            this.L_Btn_Back.TabIndex = 0;
            this.L_Btn_Back.TabStop = false;
            this.L_Btn_Back.Click += new System.EventHandler(this.L_Btn_Back_Click);
            // 
            // L_Txtb_Username
            // 
            this.L_Txtb_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Txtb_Username.BackColor = System.Drawing.Color.Linen;
            this.L_Txtb_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.L_Txtb_Username.Font = new System.Drawing.Font("Tw Cen MT", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Txtb_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.L_Txtb_Username.Location = new System.Drawing.Point(422, 329);
            this.L_Txtb_Username.Name = "L_Txtb_Username";
            this.L_Txtb_Username.Size = new System.Drawing.Size(385, 29);
            this.L_Txtb_Username.TabIndex = 1;
            this.L_Txtb_Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.L_Txtb_Username_KeyDown);
            // 
            // L_Txtb_Password
            // 
            this.L_Txtb_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Txtb_Password.BackColor = System.Drawing.Color.Linen;
            this.L_Txtb_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.L_Txtb_Password.Font = new System.Drawing.Font("Tw Cen MT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Txtb_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(76)))), ((int)(((byte)(44)))));
            this.L_Txtb_Password.Location = new System.Drawing.Point(422, 430);
            this.L_Txtb_Password.Name = "L_Txtb_Password";
            this.L_Txtb_Password.PasswordChar = '*';
            this.L_Txtb_Password.Size = new System.Drawing.Size(385, 29);
            this.L_Txtb_Password.TabIndex = 2;
            this.L_Txtb_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.L_Txtb_Password_KeyDown);
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PennyWise.Properties.Resources.BG_Login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1025, 710);
            this.Controls.Add(this.L_Btn_Back);
            this.Controls.Add(this.L_Btn_Login);
            this.Controls.Add(this.L_Txtb_Password);
            this.Controls.Add(this.L_Txtb_Username);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PennyWise";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.L_Btn_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.L_Btn_Back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox L_Btn_Login;
        private System.Windows.Forms.PictureBox L_Btn_Back;
        private System.Windows.Forms.TextBox L_Txtb_Username;
        private System.Windows.Forms.TextBox L_Txtb_Password;
    }
}