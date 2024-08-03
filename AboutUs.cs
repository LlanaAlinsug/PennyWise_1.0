using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PennyWise
{
    public partial class AboutUs : Form
    {
        private Welcome mainForm;

        // Retrieve user ID & login ID
        private int A_MasterUserID = Program.MASTER_UserID;
        private int A_MasterLoginID = Program.MASTER_LoginID;

        // Limit app exit message box
        private bool isExiting = false;

        private bool isProcessing = false; // Flag to indicate if a process is ongoing

        public AboutUs(Welcome mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Enable application exit
            Program.ApplicationExit = true;

            // DISPLAY USERNAME
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                try
                {
                    var user_name = db.uspRetrieveAccountDetails(A_MasterUserID).FirstOrDefault();
                    if (user_name != null)
                    {
                        Lbl_Username.Text = user_name.username;
                    }
                }
                catch
                {
                    Lbl_Username.Text = "";
                }
            }

            A_Lbl_UserID.Text = Program.MASTER_UserID.ToString();
            A_Lbl_LoginID.Text = Program.MASTER_LoginID.ToString();

        }
        private async Task HandleButtonClickAsync(Func<Task> action)
        {
            if (isProcessing) return;

            try
            {
                isProcessing = true;
                Cursor.Current = Cursors.WaitCursor;
                this.Enabled = false;
                await action();
            }
            finally
            {
                this.Enabled = true;
                Cursor.Current = Cursors.Default;
                isProcessing = false;
            }
        }

        // FORM NAVIGATION ---------------------------------------------------------------------

        // Navigate between pages
        private void ShowFormAtRelativeCenter(Form newForm)
        {
            // Set to not close application
            Program.ApplicationExit = false;

            this.Hide();

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

        private void AboutUs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExiting)
            {
                return; // Prevent re-entry
            }

            // Runs if settings allow to exit application (which is the default)
            // Does not run when set to ApplicationExit=false in ShowFormAtRelativeCenter()
            if (Program.ApplicationExit)
            {
                // Confirm if user wants to exit application
                DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Application Exit",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    isExiting = true; // Set flag to prevent re-entry
                    Application.Exit();
                }
                else
                {
                    // Cancel the form from closing
                    e.Cancel = true;
                }
            }

        }

        private void AboutUs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ApplicationExit = true;

        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Set to not close application
                Program.ApplicationExit = false;

                // Redirect to WelcomeScreen
                mainForm.Show();

                // Close the current form
                this.Close();
            }

            // If result is No, do nothing and remain on the current form
        }

        private void Lklbl_Eval_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // The URL to open
            string url = "https://docs.google.com/forms/d/e/1FAIpQLSfV3f822Hn-JLgQs4pqLyX-VMWbGRbvqrT9vZYkB4ByCdiE8w/viewform";

            try
            {
                // Open the default browser with the specified URL
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open the link. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // TAB BUTTONS
        private async void Btn_Homepage_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                ShowFormAtRelativeCenter(new Homepage(mainForm));
                this.Close();
            });
        }

        private async void Btn_Income_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                ShowFormAtRelativeCenter(new Income(mainForm));
                this.Close();
            });
        }

        private async void Btn_Expense_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                ShowFormAtRelativeCenter(new Expense(mainForm));
                this.Close();
            });
        }

        private async void Btn_Planner_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                ShowFormAtRelativeCenter(new Planner(mainForm));
                this.Close();
            });
        }

        private async void Btn_Summary_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                ShowFormAtRelativeCenter(new Summary(mainForm));
                this.Close();
            });
        }
    }
}
