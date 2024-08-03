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
    public partial class Summary : Form
    {
        private Welcome mainForm;

        // Retrieve user ID & login ID
        private int S_MasterUserID = Program.MASTER_UserID;
        private int S_MasterLoginID = Program.MASTER_LoginID;

        // Limit app exit message box
        private bool isExiting = false;

        private bool isProcessing = false; // Flag to indicate if a process is ongoing

        public Summary(Welcome mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Enable application exit
            Program.ApplicationExit = true;
            this.FormClosed += Summary_FormClosed;
            this.FormClosing += Summary_FormClosing;

            LoadPlannerData();

            // DISPLAY USERNAME
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                try
                {
                    var user_name = db.uspRetrieveAccountDetails(S_MasterUserID).FirstOrDefault();
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

            // Display note depending on their planned vs actual expense difference
            decimal spendingleft;
            decimal.TryParse(S_Lbl_ForSpending.Text, out spendingleft);

            if (spendingleft > 0) // positive amount: user still has more to spend
            {
                S_Lbl_Note.Text = "Sige may karapatan ka pa gumastos.";
            }

            else if (spendingleft < 0) // negative amount: user spent more than what was planned
            {
                S_Lbl_Note.Text = "Hello gastador :)";
            }

            else if (spendingleft == 0) // 0
            {
                S_Lbl_Note.Text = "Deserve mo ang financial stability!";
            }

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

        // TAB BUTTONS--------------------------------------------------------------------------------
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

        private async void Btn_AboutUs_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                ShowFormAtRelativeCenter(new AboutUs(mainForm));
                this.Close();
            });
        }

        private async void Lbl_Username_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                ShowFormAtRelativeCenter(new AboutUs(mainForm));
                this.Close();
            });
        }

        // METHODS -----------------------------------------------------------------------------------------
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
        private void LoadPlannerData()
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                // Retrieve user ID from program settings
                int userID = Program.MASTER_UserID;

                // Fetch the planner record based on the most recent plannerID
                var plannerRecord = db.plannerTables
                        .Where(p => p.userID == userID)
                        .OrderByDescending(p => p.plannerID)
                        .FirstOrDefault();

                // DISPLAY PLANNED PERCENTAGE AND AMOUNT
                try
                {
                    // Update UI elements
                    if (plannerRecord != null) // Update based on planner record
                    {
                        S_Lbl_StartDate.Text = plannerRecord.date_start.ToString();
                        S_Lbl_EndDate.Text = plannerRecord.date_end.ToString();

                        S_Lbl_P_NeedsPercent.Text = Math.Round(100 * plannerRecord.needs_percentage, 0).ToString() + "%";
                        S_Lbl_P_WantsPercent.Text = Math.Round(100 * plannerRecord.wants_percentage, 0).ToString() + "%";
                        S_Lbl_P_FundsPercent.Text = Math.Round(100 * plannerRecord.funds_percentage, 0).ToString() + "%";

                        S_Lbl_P_NeedsAmount.Text = $"{plannerRecord.needs_amount:N2}";
                        S_Lbl_P_WantsAmount.Text = $"{plannerRecord.wants_amount:N2}";
                        S_Lbl_P_FundsAmount.Text = $"{plannerRecord.funds_amount:N2}";
                    }
                    else // Update to default values
                    {
                        // Set both DateTimePicker values to today's date
                        S_Lbl_StartDate.Text = DateTime.Today.ToString();
                        S_Lbl_EndDate.Text = DateTime.Today.ToString();

                        // Default to 0
                        S_Lbl_P_NeedsAmount.Text = "0.00";
                        S_Lbl_P_WantsAmount.Text = "0.00";
                        S_Lbl_P_FundsAmount.Text = "0.00";
                    }
                }
                catch
                {
                    // Set both DateTimePicker values to today's date
                    S_Lbl_StartDate.Text = DateTime.Today.ToString();
                    S_Lbl_EndDate.Text = DateTime.Today.ToString();

                    // Default to 0
                    S_Lbl_P_NeedsAmount.Text = "0.00";
                    S_Lbl_P_WantsAmount.Text = "0.00";
                    S_Lbl_P_FundsAmount.Text = "0.00";
                }
            }

            // DISPLAY ACTUAL PERCENTAGE AND AMOUNT
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                int userID = Program.MASTER_UserID;
                DateTime startdate;
                DateTime enddate;

                DateTime.TryParse(S_Lbl_StartDate.Text, out startdate);
                DateTime.TryParse(S_Lbl_EndDate.Text, out enddate);

                // PERCENTAGES
                try
                {
                    var actualexpenses_percentage = db.uspGetActualExpensesPercentage(userID, startdate, enddate).FirstOrDefault();
                    if (actualexpenses_percentage != null)
                    {
                        S_Lbl_E_NeedsPercent.Text = actualexpenses_percentage.percentage_needs.HasValue
                            ? Math.Round(100 * actualexpenses_percentage.percentage_needs.Value / 100, 0).ToString() + "%"
                            : "0";

                        S_Lbl_E_WantsPercent.Text = actualexpenses_percentage.percentage_wants.HasValue
                            ? Math.Round(100 * actualexpenses_percentage.percentage_wants.Value / 100, 0).ToString() + "%"
                            : "0";

                        S_Lbl_E_FundsPercent.Text = actualexpenses_percentage.percentage_funds.HasValue
                            ? Math.Round(100 * actualexpenses_percentage.percentage_funds.Value / 100, 0).ToString() + "%"
                            : "0";
                    }
                    else
                    {
                        // Default to 0
                        S_Lbl_E_NeedsPercent.Text = "0";
                        S_Lbl_E_WantsPercent.Text = "0";
                        S_Lbl_E_FundsPercent.Text = "0";
                    }
                }
                catch
                {
                    // Default to 0
                    S_Lbl_E_NeedsPercent.Text = "0";
                    S_Lbl_E_WantsPercent.Text = "0";
                    S_Lbl_E_FundsPercent.Text = "0";
                }

                // NEEDS AMOUNT
                try
                {
                    var AE_NeedsAmount = db.uspGetActualExpenses_NeedsAmount(userID, startdate, enddate).FirstOrDefault();
                    if (AE_NeedsAmount != null)
                    {
                        S_Lbl_E_NeedsAmount.Text = $"{AE_NeedsAmount:N2}";
                    }
                    else
                    {
                        // Default to 0
                        S_Lbl_E_NeedsAmount.Text = "0.00";
                    }
                }
                catch
                {
                    // Default to 0
                    S_Lbl_E_NeedsAmount.Text = "0.00";
                }

                // WANTS AMOUNT
                try
                {
                    var AE_WantsAmount = db.uspGetActualExpenses_WantsAmount(userID, startdate, enddate).FirstOrDefault();
                    if (AE_WantsAmount != null)
                    {
                        S_Lbl_E_WantsAmount.Text = $"{AE_WantsAmount:N2}";
                    }
                    else
                    {
                        // Default to 0
                        S_Lbl_E_WantsAmount.Text = "0.00";
                    }
                }
                catch
                {
                    // Default to 0
                    S_Lbl_E_WantsAmount.Text = "0.00";
                }

                // FUNDS AMOUNT
                try
                {
                    var AE_FundsAmount = db.uspGetActualExpenses_FundsAmount(userID, startdate, enddate).FirstOrDefault();
                    if (AE_FundsAmount != null)
                    {
                        S_Lbl_E_FundsAmount.Text = $"{AE_FundsAmount:N2}";
                    }
                    else
                    {
                        // Default to 0
                        S_Lbl_E_FundsAmount.Text = "0.00";
                    }
                }
                catch
                {
                    // Default to 0
                    S_Lbl_E_FundsAmount.Text = "0.00";
                }

                // PLANNED VS ACTUAL
                try
                {
                    var plannedvsactual = db.uspPlannedAndActualDiff(userID, startdate, enddate).FirstOrDefault();
                    if (plannedvsactual != null)
                    {
                        S_Lbl_ForSpending.Text = $"{plannedvsactual:N2}";
                    }
                }
                catch
                {
                    S_Lbl_ForSpending.Text = "0.00";
                }
            }

            // Visualization (Column Chart)
            S_Cht_Summary.Series["Planned Expenses"].Points.AddXY("Needs", S_Lbl_P_NeedsAmount.Text);
            S_Cht_Summary.Series["Planned Expenses"].Points.AddXY("Wants", S_Lbl_P_WantsAmount.Text);
            S_Cht_Summary.Series["Planned Expenses"].Points.AddXY("Funds", S_Lbl_P_FundsAmount.Text);

            S_Cht_Summary.Series["Actual Expenses"].Points.AddXY("Needs", S_Lbl_E_NeedsAmount.Text);
            S_Cht_Summary.Series["Actual Expenses"].Points.AddXY("Wants", S_Lbl_E_WantsAmount.Text);
            S_Cht_Summary.Series["Actual Expenses"].Points.AddXY("Funds", S_Lbl_E_FundsAmount.Text);
        }

        private void Summary_FormClosing(object sender, FormClosingEventArgs e)
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
                    // Logout user
                    using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                    {
                        int userID = Program.MASTER_UserID;
                        int loginID = Program.MASTER_LoginID;

                        db.uspLogOut(userID, loginID);
                    }

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

        private void Summary_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ApplicationExit = true;
        }
    }
}
