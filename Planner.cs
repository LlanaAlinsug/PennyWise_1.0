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
using System.Windows.Forms.DataVisualization.Charting;

namespace PennyWise
{
    public partial class Planner : Form
    {
        private Welcome mainForm;

        private int P_MasterPlannerID;
        private int P_MasterUserID = Program.MASTER_UserID;
        private bool HasNeededPlanDetails = false;

        // Limit app exit message box
        private bool isExiting = false;

        private bool isProcessing = false; // Flag to indicate if a process is ongoing

        public Planner(Welcome mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            LoadBudgtPlanDetails();
            LoadPieChart();

            // Enable application exit
            Program.ApplicationExit = true;
            this.FormClosed += Planner_FormClosed;

            // DISPLAY USERNAME
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                try
                {
                    var user_name = db.uspRetrieveAccountDetails(P_MasterUserID).FirstOrDefault();
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

        }

        private async Task HandleButtonClickAsync(Func<Task> action)
        {
            if (isProcessing) return;

            try
            {
                isProcessing = true;
                SetCursor(System.Windows.Forms.Cursors.WaitCursor); // Fully qualify System.Windows.Forms.Cursor
                this.Enabled = false;
                await action();
            }
            finally
            {
                this.Enabled = true;
                SetCursor(System.Windows.Forms.Cursors.Default); // Fully qualify System.Windows.Forms.Cursor
                isProcessing = false;
            }
        }

        private void SetCursor(System.Windows.Forms.Cursor cursor)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => Cursor = cursor));
            }
            else
            {
                Cursor = cursor;
            }
        }

        // TAB BUTTON ------------------------------------------------------
        private async void Btn_Homepage_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                BlockNewFormForSaveChanges(new Homepage(mainForm));
                //ShowFormAtRelativeCenter(new Homepage(mainForm));
                this.Close();
            });
        }

        private async void Btn_Income_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                BlockNewFormForSaveChanges(new Income(mainForm));
                //ShowFormAtRelativeCenter(new Income(mainForm));
                this.Close();
            });
        }

        private async void Btn_Expense_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                BlockNewFormForSaveChanges(new Expense(mainForm));
                //ShowFormAtRelativeCenter(new Expense(mainForm));
                this.Close();
            });
        }

        private async void Btn_Summary_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                BlockNewFormForSaveChanges(new Summary(mainForm));
                //ShowFormAtRelativeCenter(new Summary(mainForm));
                this.Close();
            });
        }

        private async void Btn_AboutUs_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                BlockNewFormForSaveChanges(new AboutUs(mainForm));
                //ShowFormAtRelativeCenter(new AboutUs(mainForm));
                this.Close();
            });
        }

        private async void Lbl_Username_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                BlockNewFormForSaveChanges(new AboutUs(mainForm));
                //ShowFormAtRelativeCenter(new AboutUs(mainForm));
                this.Close();
            });
        }
        // BUTTONS -----------------------------------------------------------------------------------------
        private void P_Btn_SeeCurrentAllowance_Click(object sender, EventArgs e)
        {
            string buttonName = "'See Current Allowance'";
            if (!DateValidation(buttonName)) return;

            // Get current balance
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                // Retrieve user ID from program settings
                int userID = Program.MASTER_UserID;

                // Get output of stored procs and send to labels with default value if null
                decimal totalIncome = db.uspGetTotalIncome(userID).FirstOrDefault() ?? 0;
                decimal totalExpenses = db.uspGetTotalExpenses(userID).FirstOrDefault() ?? 0;

                decimal currentBalance = totalIncome - totalExpenses;
                P_Txtb_Allowance.Text = currentBalance.ToString("F2");
            }

        }

        private void P_Btn_Enter_Click(object sender, EventArgs e)
        {
            // Exit early if date validation fails
            string buttonName = "'Enter Budget Details'";
            if (!DateValidation(buttonName)) return;

            EnterBudgetDetails();
        }

        private void P_Txtb_SavingsGoal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Exit early if date validation fails
                string buttonName = "'Enter Budget Details'";
                if (!DateValidation(buttonName)) return;

                EnterBudgetDetails();
            }
        }

        private void P_Btn_ApplyBudget_Click(object sender, EventArgs e)
        {
            if (HasNeededPlanDetails) // Runs if budget details are complete
            {
                // Exit early if date validation fails
                string buttonName = "'Apply Budget'";
                if (!DateValidation(buttonName)) return;

                DialogResult result = MessageBox.Show("Are you sure you want to save your new budget?",
                      "Apply New Budget", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                    ApplyBudget();
                }
            }
            else
            {
                MessageBox.Show("Apply failed. Incomplete budget details.", "Apply Budget Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void P_Btn_Customize_Click(object sender, EventArgs e)
        {
            int plannerID = P_MasterPlannerID > 0 ? P_MasterPlannerID : 0;

            if (plannerID > 0) // Has previous record
            {
                // Open Planner Customize
                ShowFormAtRelativeCenter(new PlannerCustomize(mainForm));
                this.Close();
            }

            else // No budget plan yet
            {
                // Prompt to save scheme customization if not yet applied
                DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to apply the budget before customizing?",
                                                      "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ApplyBudget();

                    //Proceed to customize page
                    ShowFormAtRelativeCenter(new PlannerCustomize(mainForm));
                    this.Close();
                }
                else
                {
                    //Proceed to customize page
                    ShowFormAtRelativeCenter(new PlannerCustomize(mainForm));
                    this.Close();
                }    
            }
        }

        private void P_Btn_Reset_Click(object sender, EventArgs e)
        {
            // Prompt to save scheme customization if not yet applied
            DialogResult result = MessageBox.Show("Are you sure you want to reset scheme to default 50/30/20?",
                                                  "Default Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (HasNeededPlanDetails)
                {
                    // Set to need to save changes
                    Program.P_SchemeCustomizeUpdate = true;

                    // Set scheme to default
                    Program.NeedsPercentage = 0.5f;
                    Program.WantsPercentage = 0.3f;
                    Program.FundsPercentage = 0.2f;

                    // Delete after test: Check percentage
                    P_Lbl_NeedsPercent.Text = Program.NeedsPercentage.ToString();
                    P_Lbl_WantsPercent.Text = Program.WantsPercentage.ToString();
                    P_Lbl_FundsPercent.Text = Program.FundsPercentage.ToString();

                    // Update amounts based on default
                    using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                    {
                        // Get the user ID from the program's master user ID
                        int userID = Program.MASTER_UserID;

                        // Get the start and end dates from the DateTimePickers
                        DateTime startDate = P_Dtp_StartDate.Value.Date;
                        DateTime endDate = P_Dtp_EndDate.Value.Date;

                        // Parse savings goal from text box input
                        decimal savingsGoal = decimal.Parse(P_Txtb_SavingsGoal.Text);

                        // Retrieve current allowance from text box input
                        string currentAllowanceText = P_Txtb_Allowance.Text.Trim();
                        // Remove the currency sign
                        string currentAllowanceEdit = currentAllowanceText.Replace("₱", "");
                        decimal currentAllowance;

                        if (!decimal.TryParse(currentAllowanceEdit, out currentAllowance))
                        {
                            MessageBox.Show("Please enter a valid number for Current Allowance.", "Invalid Current Allowance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return; // Exit method or handle the error appropriately
                        }

                        // Calculate current budget after subtracting savings goal
                        decimal currentBudget = (currentAllowance - savingsGoal);

                        // Calculate amounts based on percentage scheme
                        decimal needsAmount = (decimal)Program.NeedsPercentage * currentBudget;
                        decimal wantsAmount = (decimal)Program.WantsPercentage * currentBudget;
                        decimal fundsAmount = (decimal)Program.FundsPercentage * currentBudget;

                        // Update the label with the calculated amounts
                        P_Lbl_NeedsAmount.Text = $"{needsAmount:N2}";
                        P_Lbl_WantsAmount.Text = $"{wantsAmount:N2}";
                        P_Lbl_FundsAmount.Text = $"{fundsAmount:N2}";
                    }

                    // Update pie chart
                    MessageBox.Show("Budget scheme set to default 50/30/20.", "Scheme Updated",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowFormAtRelativeCenter(new Planner(mainForm));
                }
                else
                {
                    // Dont run if lacking details
                    MessageBox.Show("Please make sure all needed budget details are\nin place before changing scheme",
                                    "Unable to Change Scheme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        // METHODS -----------------------------------------------------------------------------------------
        private bool ConfirmedOneWeekDuration = false;

        private bool DateValidation(string buttonName)
        {
            // Get the start and end dates from the DateTimePickers
            DateTime startDate = P_Dtp_StartDate.Value.Date;
            DateTime endDate = P_Dtp_EndDate.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Date range overlaps. Please make sure the start date is not beyond the end date",
                                "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Check if date range is less than a week and confirmation is needed
            int daysDifference = (endDate - startDate).Days;
            if (daysDifference < 7 && !ConfirmedOneWeekDuration)
            {
                DialogResult result = MessageBox.Show("Your date range appears to be less than a week, which is shorter than the recommended duration.\n" +
                                                      "While your budget still applies, are you certain about this shorter timeframe?",
                                                      "Warning: Date Range Is Less Than A Week", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ConfirmedOneWeekDuration = true;
                    return true;
                }
                else
                {
                    MessageBox.Show($"The {buttonName} button was not applied. Please adjust the date range and try again.",
                                   "Edit Date Range", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        private void BlockNewFormForSaveChanges(Form newForm)
        {
            if (Program.P_SchemeCustomizeUpdate)
            {
                // Prompt to save scheme customization if not yet applied
                DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to apply the budget before leaving page?",
                                                      "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    // Proceed to desired form
                    ShowFormAtRelativeCenter(newForm);
                    this.Close();
                }
                else
                {
                    ApplyBudget();

                    // Proceed to desired form
                    ShowFormAtRelativeCenter(newForm);
                    this.Close();
                }
            }
            else
            {
                // Proceed to desired form
                ShowFormAtRelativeCenter(newForm);
                this.Close();
            }
        }

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

        private int GetMostRecentPlannerID(int userID)
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                var mostRecentPlannerID = db.plannerTables
                                            .Where(p => p.userID == userID)
                                            .OrderByDescending(p => p.plannerID)
                                            .Select(p => p.plannerID)
                                            .FirstOrDefault();
                return mostRecentPlannerID;
            }
        }

        private void LoadBudgtPlanDetails()
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                // Retrieve user ID from program settings
                int userID = Program.MASTER_UserID;

                // Retrieve the most recent plannerID for the given userID
                var MostRecentPlannerID = GetMostRecentPlannerID(userID);

                // Fetch the planner record based on the most recent plannerID
                var plannerRecord = db.plannerTables
                    .FirstOrDefault(p => p.plannerID == MostRecentPlannerID);

                // Update UI elements based on the fetched planner record
                if (plannerRecord != null)
                {
                    P_MasterPlannerID = plannerRecord.plannerID;
                    P_Dtp_StartDate.Value = plannerRecord.date_start;
                    P_Dtp_EndDate.Value = plannerRecord.date_end;
                    P_Txtb_Allowance.Text = $"{plannerRecord.allowance.ToString("F2")}";
                    P_Txtb_SavingsGoal.Text = plannerRecord.savings_goal.ToString("0.00");
                    P_Lbl_NeedsAmount.Text = $"{plannerRecord.needs_amount:N2}";
                    P_Lbl_WantsAmount.Text = $"{plannerRecord.wants_amount:N2}";
                    P_Lbl_FundsAmount.Text = $"{plannerRecord.funds_amount:N2}";

                    // Update percentage acc to planTable only when opening planner
                    // Otherwise, update percentage acc to Program.Percentage
                    if (Program.P_SchemeCustomizeUpdate == false)
                    {
                        Program.NeedsPercentage = (float)plannerRecord.needs_percentage;
                        Program.WantsPercentage = (float)plannerRecord.wants_percentage;
                        Program.FundsPercentage = (float)plannerRecord.funds_percentage;
                    }

                    HasNeededPlanDetails = true;
                }

                // Load data depending on presence of new scheme customization
                if (Program.P_SchemeCustomizeUpdate)
                {
                    // Update allocated budget based on NEW SCHEME
                    EnterBudgetDetails();
                }

                // For refernce only. Delete segment after testing
                P_Lbl_NeedsPercent.Text = Program.NeedsPercentage.ToString();
                P_Lbl_WantsPercent.Text = Program.WantsPercentage.ToString();
                P_Lbl_FundsPercent.Text = Program.FundsPercentage.ToString();
            }

            Console.WriteLine(Program.NeedsPercentage);
            Console.WriteLine(Program.WantsPercentage);
            Console.WriteLine(Program.FundsPercentage);
        }

        private void EnterBudgetDetails()
        {
            // Prompt to enter Savings Goal if NULL
            if (string.IsNullOrEmpty(P_Txtb_SavingsGoal.Text))
            {
                if (!Program.P_SchemeCustomizeUpdate)
                {
                    MessageBox.Show("Please enter a Savings Goal.", "Missing Savings Goal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    P_Txtb_SavingsGoal.Focus(); // Set focus to the text box for user input
                }
            }
            else
            {
                // Calculate and update budget allocations based on current allowance and savings goal
                using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                {
                    // Get user ID from program settings
                    int userID = Program.MASTER_UserID;

                    // Get start and end dates from DateTimePicker controls, only date part
                    DateTime startDate = P_Dtp_StartDate.Value.Date;
                    DateTime endDate = P_Dtp_EndDate.Value.Date;

                    // Parse savings goal from text box input
                    decimal savingsGoal = 0;
                    try
                    {
                        savingsGoal = decimal.Parse(P_Txtb_SavingsGoal.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Please only enter digits for Savings Goal.", "Invalid Savings Goal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Retrieve current allowance from text box input
                    string currentAllowanceText = P_Txtb_Allowance.Text.Trim();
                    // Remove the currency sign
                    string currentAllowanceEdit = currentAllowanceText.Replace("₱", "");
                    decimal currentAllowance;

                    if (!decimal.TryParse(currentAllowanceEdit, out currentAllowance))
                    {
                        MessageBox.Show("Please enter a valid number for Current Allowance.", "Invalid Current Allowance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Exit method or handle the error appropriately
                    }

                    // Calculate current budget after subtracting savings goal
                    decimal currentBudget = currentAllowance - savingsGoal;

                    // If total budget = 0 or negative, alert user 
                    if (currentBudget <= 0)
                    {
                        MessageBox.Show("Your total budget is insufficient or zero. Please review your savings goal and current allowance.",
                                        "Budget Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Optionally, you can take additional actions here based on your application's logic
                    }
                    else
                    {
                        // Update labels with calculated budget allocations for Needs, Wants, and Funds
                        P_Lbl_NeedsAmount.Text = $"{currentBudget * (decimal)Program.NeedsPercentage:N2}";
                        P_Lbl_WantsAmount.Text = $"{currentBudget * (decimal)Program.WantsPercentage:N2}";
                        P_Lbl_FundsAmount.Text = $"{currentBudget * (decimal)Program.FundsPercentage:N2}";

                        // Update pie chart based on the calculated budget allocations

                        // Activate Apply Budget button
                        HasNeededPlanDetails = true;

                        // Set for alert to save changes
                        Program.P_SchemeCustomizeUpdate = true;
                    }
                }
            }
        }

        private void P_Txtb_SavingsGoal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys and digits
            OnlyDigitsEntry(e, sender as TextBox);
        }

        private void P_Btn_Tutorial_Click(object sender, EventArgs e)
        {
            // The URL to open
            string url = "https://drive.google.com/file/d/1LxZoas7GBe1vUKxKyRcdO3S91fPWkR7I/view";

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

        private void P_Txtb_Allowance_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys and digits
            OnlyDigitsEntry(e, sender as TextBox);
        }

        private void OnlyDigitsEntry(KeyPressEventArgs e, TextBox textBox)
        {
            // Allow control keys and digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Allow only one decimal point
                if (e.KeyChar == '.' && textBox.Text.Contains("."))
                {
                    e.Handled = true; // Prevent entering more than one decimal point
                }
                else if (e.KeyChar != '.')
                {
                    e.Handled = true; // Block any other non-digit characters
                }
            }
        }

        private void ApplyBudget()
        {
            EnterBudgetDetails();

            if (HasNeededPlanDetails) // Runs if budget details are complete
            {
                // Save new record in Planner Table
                using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                {
                    // Get the user ID from the program's master user ID
                    int userID = Program.MASTER_UserID;

                    // Get the start and end dates from the DateTimePickers
                    DateTime startDate = P_Dtp_StartDate.Value.Date;
                    DateTime endDate = P_Dtp_EndDate.Value.Date;

                    // Retrieve current allowance from text box input
                    string currentAllowanceText = P_Txtb_Allowance.Text.Trim();
                    // Remove the currency sign
                    string currentAllowanceEdit = currentAllowanceText.Replace("₱", "");
                    decimal currentAllowance;

                    if (!decimal.TryParse(currentAllowanceEdit, out currentAllowance))
                    {
                        MessageBox.Show("Please enter a valid number for Current Allowance.", "Invalid Current Allowance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Exit method or handle the error appropriately
                    }

                    // Parse savings goal from text box input
                    decimal savingsGoal = 0;
                    try
                    {
                        savingsGoal = decimal.Parse(P_Txtb_SavingsGoal.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("Please only enter digits for Savings Goal.", "Invalid Savings Goal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Clean up the text and convert to decimal 
                    string needsAmountText = new string(P_Lbl_NeedsAmount.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());
                    decimal needsAmount = Convert.ToDecimal(needsAmountText);
                    string fundsAmountText = new string(P_Lbl_FundsAmount.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());
                    decimal fundsAmount = Convert.ToDecimal(fundsAmountText);
                    string wantsAmountText = new string(P_Lbl_WantsAmount.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());
                    decimal wantsAmount = Convert.ToDecimal(wantsAmountText);

                    // Retrieve the percentage values for needs, funds, and wants from the program
                    float needsPercent = Program.NeedsPercentage;
                    float fundsPercent = Program.FundsPercentage;
                    float wantsPercent = Program.WantsPercentage;

                    // Assign plannerID based on MasterPlannerID:
                    // If MasterPlannerID is greater than 0, use its value; otherwise, default to 0.
                    // Handles if user already has a budget plan or not
                    int plannerID = P_MasterPlannerID > 0 ? P_MasterPlannerID : 0;

                    // Output the variables to the console for debugging or logging
                    Console.WriteLine($"plannerID: {plannerID}");
                    Console.WriteLine($"userID: {userID}");
                    Console.WriteLine($"startDate: {startDate}");
                    Console.WriteLine($"endDate: {endDate}");
                    Console.WriteLine($"currentAllowance: {currentAllowance}");
                    Console.WriteLine($"savingsGoal: {savingsGoal}");
                    Console.WriteLine($"needsAmount: {needsAmount}");
                    Console.WriteLine($"wantsAmount: {wantsAmount}");
                    Console.WriteLine($"fundsAmount: {fundsAmount}");
                    Console.WriteLine($"needsPercent: {needsPercent}");
                    Console.WriteLine($"wantsPercent: {wantsPercent}");
                    Console.WriteLine($"fundsPercent: {fundsPercent}");

                    // Apply or modify the budget plan in the database with the calculated values
                    try
                    {
                        db.uspApplyOrModifyBudgetPlan(plannerID, userID, startDate, endDate,
                                currentAllowance, savingsGoal,
                                needsAmount, wantsAmount, fundsAmount,
                                needsPercent, wantsPercent, fundsPercent);
                    }
                    catch { }

                    if (plannerID > 0) // Has previous record
                    {
                        // Show a message box if the stored procedure was successful
                        MessageBox.Show("Budget Plan has been applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Make sure we scratch the scheme customization value
                        Program.P_SchemeCustomizeUpdate = false;

                        LoadBudgtPlanDetails();
                    }
                    else // Created a new budget
                    {
                        // Show a message box if the stored procedure was successful
                        MessageBox.Show("Congratulations with your first budget plan! \nGood luck!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Make sure we scratch the scheme customization value
                        Program.P_SchemeCustomizeUpdate = false;

                        LoadBudgtPlanDetails();
                    }
                }
            }
            else
            {
                MessageBox.Show("Apply failed. Incomplete budget details.", "Apply Budget Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadPieChart()
        {
            // Create a series named "s1" if it doesn't exist
            Series series = P_Cht_Scheme.Series.FindByName("s1");
            if (series == null)
            {
                series = new Series("s1")
                {
                    ChartType = SeriesChartType.Pie,
                    BackSecondaryColor = Color.Transparent // doesn't work
                };
                P_Cht_Scheme.Series.Add(series);
            }

            P_Cht_Scheme.Series["s1"].Points.AddXY("Needs " + 100 * Program.NeedsPercentage + "%", Program.NeedsPercentage);
            P_Cht_Scheme.Series["s1"].Points.AddXY("Wants " + 100 * Program.WantsPercentage + "%", Program.WantsPercentage);
            P_Cht_Scheme.Series["s1"].Points.AddXY("Funds " + 100 * Program.FundsPercentage + "%", Program.FundsPercentage);
        }

        private void Planner_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Planner_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ApplicationExit = true;
        }

        // CLOSE APPLICATION

    }
}
