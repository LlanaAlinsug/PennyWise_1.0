using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PennyWise
{
    public partial class Homepage : Form
    {
        private Welcome mainForm;

        // Retrieve user ID & login ID
        private int H_MasterUserID = Program.MASTER_UserID;
        private int H_MasterLoginID = Program.MASTER_LoginID;

        // Limit app exit message box
        private bool isExiting = false;

        private bool isProcessing = false; // Flag to indicate if a process is ongoing

        public Homepage(Welcome mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Enable application exit
            Program.ApplicationExit = true;
            this.FormClosed += Homepage_FormClosed;

            // Generate user data
            UpdateHomescreenData();
            LoadChartData();
            LoadPersonalizedMessage();

            // DISPLAY USERNAME
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                try
                {
                    var user_name = db.uspRetrieveAccountDetails(H_MasterUserID).FirstOrDefault();
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

        // FORM NAVIGATION ----------------------------------------------------------------------------------
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

        // TAB BUTTON ------------------------------------------------------
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

        // METHODS -------------------------------------------------------------------------------------------------------

        // Update data on screen
        private void UpdateHomescreenData()
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                int userID = Program.MASTER_UserID;

                // Get output of stored procs and send to labels with default value if null
                var TotalIncome = db.uspGetTotalIncome(userID).FirstOrDefault();
                H_Lbl_TotalIncome.Text = $"{TotalIncome?.ToString("F2") ?? "0.00"}";

                var TotalExpenses = db.uspGetTotalExpenses(userID).FirstOrDefault();
                H_Lbl_TotalExpense.Text = $"{(TotalExpenses?.ToString("F2") ?? "0.00")}";

                decimal totalIncome = db.uspGetTotalIncome(userID).FirstOrDefault() ?? 0;
                decimal totalExpenses = db.uspGetTotalExpenses(userID).FirstOrDefault() ?? 0;

                decimal currentBalance = totalIncome - totalExpenses;
                H_Lbl_CurrentBalance.Text = currentBalance.ToString("F2");

                var SavingsGoal = db.uspGetSavingsGoal(userID).FirstOrDefault();
                H_Lbl_SavingsGoal.Text = $"{(SavingsGoal?.ToString("F2") ?? "0.00")}";
            }

        }

        // Generate line chart visualization for finance summary within planner/default date range
        private void LoadChartData()
        {
            // Define the userID
            int userID = Program.MASTER_UserID;

            // Get the Entity Framework connection string from app.config
            string entityConnectionString = "Data Source=mssql-177468-0.cloudclusters.net,10033;Initial Catalog=PennyWiseCloudDB;Persist Security Info=True;User ID=PennyWise;Password=BenildePenny1098";

            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                // Process validation for no planner notification
                // Retrieve the most recent plannerID for the given userID
                var mostRecentPlannerID = db.plannerTables
                                .Where(p => p.userID == userID)
                                .OrderByDescending(p => p.plannerID)
                                .Select(p => p.plannerID)
                                .FirstOrDefault();

                Console.WriteLine("PlannerID = {0}", mostRecentPlannerID);

                if (mostRecentPlannerID <= 0)   // Verify no planner
                {
                    // Prompt user to make planner upon opening app ONLY ONCE
                    if (Program.PlannerNotifLimit == 0)
                    {
                        Program.PlannerNotifLimit += 1; // Limits planner notification 
                        DelayNoPlannerMessage(); // Delayed since homepage needs time to load
                    }
                }

                // Retrieve historical data (past 30 days)
                // Get start & end date chart references
                DateTime startDate = DateTime.Now.AddDays(-30);
                DateTime endDate = DateTime.Now;
                DateTime preStartDate = startDate.AddDays(-1);

                // Use ADO.NET to query for income and expense within the date range
                using (SqlConnection sqlConnection = new SqlConnection(entityConnectionString))
                {
                    string query = @"
                    SELECT [Date], SUM(Amount) AS TotalAmount, 'Income' AS Type
                    FROM incomeTable
                    WHERE userID = @userID AND [Date] BETWEEN @startDate AND @endDate
                    GROUP BY [Date]
                    UNION ALL
                    SELECT [Date], SUM(Amount) AS TotalAmount, 'Expense' AS Type
                    FROM expenseTable
                    WHERE userID = @userID AND [Date] BETWEEN @startDate AND @endDate
                    GROUP BY [Date]
                    ORDER BY [Date]";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@userID", userID);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                    DataTable FinanceRecordsTable = new DataTable();
                    dataAdapter.Fill(FinanceRecordsTable);

                    ChtHomepage.DataSource = FinanceRecordsTable;

                    // Create a series for Income
                    Series incomeSeries = new Series("Income")
                    {
                        XValueType = ChartValueType.DateTime,
                        YValueType = ChartValueType.Double,
                        ChartType = SeriesChartType.Line,
                        BorderWidth = 3
                    };

                    // Create a series for Expense
                    Series expenseSeries = new Series("Expense")
                    {
                        XValueType = ChartValueType.DateTime,
                        YValueType = ChartValueType.Double,
                        ChartType = SeriesChartType.Line,
                        BorderWidth = 3
                    };

                    // Add the zero-value starting point
                    incomeSeries.Points.AddXY(preStartDate, 0);
                    expenseSeries.Points.AddXY(preStartDate, 0);

                    // Bind the data points from the database
                    foreach (DataRow row in FinanceRecordsTable.Rows)
                    {
                        DateTime date = (DateTime)row["Date"];
                        double amount = Convert.ToDouble(row["TotalAmount"]);
                        string type = (string)row["Type"];

                        if (type == "Income")
                        {
                            incomeSeries.Points.AddXY(date, amount);
                        }
                        else if (type == "Expense")
                        {
                            expenseSeries.Points.AddXY(date, amount);
                        }
                    }

                    ChtHomepage.Series.Clear();
                    ChtHomepage.Series.Add(incomeSeries);
                    ChtHomepage.Series.Add(expenseSeries);

                    ChtHomepage.DataBind();
                }
            }
        }


        private async void DelayNoPlannerMessage()
        {
            await Task.Delay(1000); // 1 second delay

            // Prompt users (likely new) to create a budget
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                var usernameRef = db.uspRetrieveAccountDetails(H_MasterUserID).FirstOrDefault();
                string username = usernameRef.username;
                string NewUserMessage = $"Welcome, {username}!\nStart your financial journey strong with a budget planner!";
                DialogResult result = MessageBox.Show(NewUserMessage, "Create a Budget Plan Now", MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    // User clicked Yes
                    ShowFormAtRelativeCenter(new Planner(mainForm));
                    this.Close();
                }
            }

        }

        private void LoadPersonalizedMessage()
        {
            int userID = Program.MASTER_UserID;

            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                try // Randomize output depending on Positivity Score
                {
                    // Get planner ID
                    int mostRecentPlannerID = db.plannerTables
                        .Where(p => p.userID == userID)
                        .OrderByDescending(p => p.plannerID)
                        .Select(p => p.plannerID)
                        .FirstOrDefault();

                    // Get Positivity Score based on financial performance 
                    var PositivityScore = db.uspCalculateExpenseIncomeRatioCounts(mostRecentPlannerID).FirstOrDefault();

                    // Get Personalized Message based on Positivity Score
                    var PersonalizedMessage = db.uspGetPersonalizedMessageByPositivityScore(PositivityScore).FirstOrDefault();

                    // Output personalized message 
                    if (PersonalizedMessage != null)
                    {
                        H_Lbl_PersonalizedMessage.Text = PersonalizedMessage.Trim();
                    }
                    else
                    {
                        var altPersonalizedMessage = db.uspGetPersonalizedMessage().FirstOrDefault();
                        H_Lbl_PersonalizedMessage.Text = altPersonalizedMessage.Trim();
                    }
                }
                catch  // Randomize output irrelvant of Positivity Score
                {
                    // Get Personalized Message based on Positivity Score
                    var PersonalizedMessage = db.uspGetPersonalizedMessage().FirstOrDefault();

                    // Output personalized message 
                    H_Lbl_PersonalizedMessage.Text = PersonalizedMessage.Trim();
                }
            }
            CenterPersonalizedMessage();
        }

        private void CenterPersonalizedMessage()
        {
            // Center text to screen
            H_Lbl_PersonalizedMessage.TextAlign = ContentAlignment.MiddleCenter; // Center the text horizontally
            H_Lbl_PersonalizedMessage.Location = new Point
            (
                (this.ClientSize.Width - H_Lbl_PersonalizedMessage.Width) / 2, // Center horizontally
                    130 - H_Lbl_PersonalizedMessage.Height / 2 // Center vertically at Y position 115
            );
        }

        // CLOSE APP ---------------------------------------------------------------------------------------
        private void Homepage_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ApplicationExit = true;
        }
    }
}
