using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PennyWise
{
    public partial class Login : Form
    {
        private Welcome mainForm;

        public static int L_MasterUserID;
        public static int L_MasterLoginID;

        // Limit app exit message box
        private bool isExiting = false;

        public Login(Welcome mainForm)
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

        // BUTTONS -----------------------------------------------------------------------------------
        private void L_Btn_Back_Click(object sender, EventArgs e)
        {
            ShowFormAtRelativeCenter(new Welcome());
            this.Close();
        }

        private void L_Btn_Login_Click(object sender, EventArgs e)
        {
            ProcessLogin();
        }

        private void L_Txtb_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Move focus to L_Txtb_Password when Enter key is pressed
                L_Txtb_Password.Focus();

                // Mark the event as handled to prevent the beep sound
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void L_Txtb_Password_KeyDown(object sender, KeyEventArgs e)
        {
            // Login if enter is pressed in password txtb
            if (e.KeyCode == Keys.Enter)
            {
                ProcessLogin();
            }
        }

        // METHODS -------------------------------------------------------------------------------------------------------

        private async void ProcessLogin()
        {
            L_Btn_Login.Enabled = false;
            L_Txtb_Username.KeyDown -= L_Txtb_Username_KeyDown;
            L_Txtb_Password.KeyDown -= L_Txtb_Password_KeyDown;

            // Change cursor to loading
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Validate absence of inputs
                if (string.IsNullOrWhiteSpace(L_Txtb_Username.Text))
                {
                    MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(L_Txtb_Password.Text))
                {
                    MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate inputs from db
                using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                {
                    string Username = L_Txtb_Username.Text.Trim();
                    string Password = L_Txtb_Password.Text.Trim();

                    // Define output parameters
                    ObjectParameter returnValueParam = new ObjectParameter("returnvalue", typeof(int));
                    ObjectParameter userIDParam = new ObjectParameter("userID", typeof(int));
                    ObjectParameter loginIDParam = new ObjectParameter("loginID", typeof(int));

                    // Call the stored procedure asynchronously
                    await Task.Run(() => db.uspLogIn(Username, Password, returnValueParam, userIDParam, loginIDParam));

                    // Retrieve output parameter values
                    int returnValue = Convert.ToInt32(returnValueParam.Value);

                    // Use switch statement to handle different return values
                    switch (returnValue)
                    {
                        case 1: // Login successful, use userID
                                // Retrieve IDs from output of uspLogin
                            int userID = Convert.ToInt32(userIDParam.Value);
                            int loginID = Convert.ToInt32(loginIDParam.Value);

                            // send userID & loginID to public instance 
                            Program.MASTER_UserID = userID;
                            Program.MASTER_LoginID = loginID;

                            // proceed to homepage
                            ShowFormAtRelativeCenter(new Homepage(mainForm));

                            // Close current login form
                            this.Close();
                            break;

                        case 2: // Username does not exist
                            MessageBox.Show("Invalid Username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case 3: // Password does not match
                            MessageBox.Show("Invalid Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        default: // Handle unexpected return value if necessary
                            MessageBox.Show("Login Error.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restore cursor to default
                this.Cursor = Cursors.Default;
                L_Btn_Login.Enabled = true;
                L_Txtb_Username.KeyDown += L_Txtb_Username_KeyDown;
                L_Txtb_Password.KeyDown += L_Txtb_Password_KeyDown;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExiting)
            {
                return; // Prevent re-entry
            }
            Console.WriteLine("Form closing ran");

            // Runs if settings allow to exit application (which is the default)
            // Does not run when set to ApplicationExit=false in ShowFormAtRelativeCenter()
            if (Program.ApplicationExit)
            {
                // Confirm if user wants to exit application
                DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Application Exit",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    // Logout user
                    using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                    {
                        int userID = Program.MASTER_UserID;
                        int loginID = Program.MASTER_LoginID;

                        db.uspLogOut(userID, loginID);
                    }

                    isExiting = true; // Set flag to prevent re-entry
                    Console.WriteLine("Near application exit");
                    Application.Exit();
                }
                else
                {
                    // Cancel the form from closing
                    e.Cancel = true;
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ApplicationExit = true;
        }
    }
}
