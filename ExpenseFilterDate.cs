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
    public partial class ExpenseFilterDate : Form
    {
        private Expense _expenseForm;

        public ExpenseFilterDate(Expense expenseForm)
        {
            InitializeComponent();

            _expenseForm = expenseForm;

            EFD_Dtp_StartDate.Value = DateTime.Today;
            EFD_Dtp_StartDate.Checked = true;
            EFD_Dtp_EndDate.Value = DateTime.Today;
            EFD_Dtp_EndDate.Checked = true;

            // Set the start position to Manual
            this.StartPosition = FormStartPosition.Manual;

            // Calculate the position to center the form within the Expense form
            this.Location = new Point(
                _expenseForm.Location.X + (_expenseForm.Width - this.Width) / 2,
                _expenseForm.Location.Y + (_expenseForm.Height - this.Height) / 2
            );
        }

        // BUTTON ----------------------------------------------------------------------------------

        // APPLY
        private void EFD_Btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the date is selected in the DateTimePicker
                DateTime? startdate = EFD_Dtp_StartDate.Checked ? (DateTime?)EFD_Dtp_StartDate.Value : null;
                DateTime? enddate = EFD_Dtp_EndDate.Checked ? (DateTime?)EFD_Dtp_EndDate.Value : null;

                int userID = Program.MASTER_UserID;

                // Check for date filter
                if (enddate < startdate)
                {
                    MessageBox.Show("The end date must not be before the start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (startdate.HasValue && enddate.HasValue)
                {
                    _expenseForm.FilterByDate(userID, startdate.Value, enddate.Value);
                }
                else
                {
                    MessageBox.Show("Please select valid start and end dates.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide(); // Hide the filter form after applying the filter
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while applying the filter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // CANCEL
        private void EFD_Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Load Expense Filter Date to set date to current date ----------------------------------------------------------------------------------

        private void ExpenseFilterDate_Load(object sender, EventArgs e)
        {
            EFD_Dtp_StartDate.Value = DateTime.Today;
            EFD_Dtp_StartDate.Checked = true;
            EFD_Dtp_EndDate.Value = DateTime.Today;
            EFD_Dtp_EndDate.Checked = true;

        }
    }
}
