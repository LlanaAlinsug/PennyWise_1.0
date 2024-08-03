using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PennyWise
{
    public partial class Welcome : Form
    {
        // Limit app exit message box
        //private bool isExiting = false;

        public Welcome()
        {
            InitializeComponent();
        }
        
        // CLOSE SIMILAR FORMS ----------------------------------------------------------
        private Form currentForm;

        private void ShowFormAtRelativeCenter(Form newForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = newForm;

            // Calculate the center point of the current form
            int currentFormCenterX = this.Left + (this.Width / 2);
            int currentFormCenterY = this.Top + (this.Height / 2);

            // Calculate the left and top positions of the new form to center it relative to the current form
            int newFormLeft = currentFormCenterX - (newForm.Width / 2);
            int newFormTop = currentFormCenterY - (newForm.Height / 2);

            // Set the position of the new form
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = new Point(newFormLeft, newFormTop);

            // Show the new form
            newForm.Show();
        }

        // LOGIN BUTTON
        private void W_Btn_Login_Click(object sender, EventArgs e)
        {
            ShowFormAtRelativeCenter(new Login(this));
            this.Hide();
        }

        // CREATE ACCOUNT BUTTON
        private void W_Btn_CreateAccount_Click(object sender, EventArgs e)
        {
            ShowFormAtRelativeCenter(new CreateAccount(this));
            this.Hide();
        }

        private void Welcome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowFormAtRelativeCenter(new Login(this));
                this.Hide();
            }
        }

        // CLOSE APP ---------------------------------------------------------------------------------------
        private void Welcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Exit the application when the form is closed
            Application.Exit();
        }
    }
}
