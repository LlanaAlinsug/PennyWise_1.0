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
    public partial class CreateAccount : Form
    {
        private Welcome mainForm;

        // Limit app exit message box
        private bool isExiting = false;

        public CreateAccount(Welcome mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Enable application exit
            Program.ApplicationExit = true;
        }

        // CLOSE SIMILAR FORMS --------------------------------------
        private Form currentForm;

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

        // BUTTONS ------------------------------------------------------
        private void C_Btn_Back_Click(object sender, EventArgs e)
        {
            ShowFormAtRelativeCenter(new Welcome());
            this.Close();
        }

        private void C_Btn_CreateAccount_Click(object sender, EventArgs e)
        {
            ProcessNewAccount();
        }

        // EVENT HANDLERS -----------------------------------------------------------------------------------
        private void C_Txtb_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Move focus to L_Txtb_Password when Enter key is pressed
                C_Txtb_Password.Focus();

                // Mark the event as handled to prevent the beep sound
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void C_Txtb_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Move focus to L_Txtb_Password when Enter key is pressed
                C_Txtb_ConfirmPassword.Focus();

                // Mark the event as handled to prevent the beep sound
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void C_Txtb_ConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessNewAccount();
            }
        }

        // METHODS ----------------------------------------------------------------------------------------
        private async void ProcessNewAccount()
        {
            try
            {
                // Change cursor to loading
                this.Cursor = Cursors.WaitCursor;

                // Validate inputs
                if (string.IsNullOrWhiteSpace(C_Txtb_Username.Text))
                {
                    MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(C_Txtb_Password.Text))
                {
                    MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(C_Txtb_ConfirmPassword.Text))
                {
                    MessageBox.Show("Confirm Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (C_Txtb_Password.Text != C_Txtb_ConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // insert codes for adding new account
                    using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                    {
                        string Username = C_Txtb_Username.Text.Trim();
                        string Password = C_Txtb_Password.Text.Trim();
                        var returnValueParam = new System.Data.Entity.Core.Objects.ObjectParameter("returnvalue", typeof(int));

                        await Task.Run(() =>
                        {
                            try
                            {
                                db.uspCreateNewAccount(Username, Password, returnValueParam);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Stored procedure call failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        });

                        // Retrieve output parameter values
                        int returnValue = Convert.ToInt32(returnValueParam.Value);

                        // Use switch statement to handle different return values
                        switch (returnValue)
                        {
                            case 1: // Account created successfully
                                    // Proceed to homepage
                                ShowFormAtRelativeCenter(new Login(mainForm));
                                // Close current login form
                                this.Close();
                                break;

                            case 2: // Username already exists
                                MessageBox.Show("Username unavailable, please choose another", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;

                            default: // Handle unexpected return value if necessary
                                MessageBox.Show($"Create Account Error. Return value: {returnValue}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                // Log or handle the exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                // Reset cursor to default
                this.Cursor = Cursors.Default;
            }
        }

        // CLOSE APP -------------------------------------------------------------------------------------------
        private void CreateAccount_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
