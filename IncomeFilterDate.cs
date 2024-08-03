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
    public partial class IncomeFilterDate : Form
    {
        public Income _incomeForm;

        public IncomeFilterDate(Income incomeform)
        {
            InitializeComponent();
            _incomeForm = incomeform;

            IFD_Dtp_StartDate.Value = DateTime.Today;
            IFD_Dtp_StartDate.Checked = true;
            IFD_Dtp_EndDate.Value = DateTime.Today;
            IFD_Dtp_EndDate.Checked = true;

            // Set the start position to Manual
            this.StartPosition = FormStartPosition.Manual;

            // Calculate the position to center the form within the Expense form
            this.Location = new Point(
                _incomeForm.Location.X + (_incomeForm.Width - this.Width) / 2,
                _incomeForm.Location.Y + (_incomeForm.Height - this.Height) / 2
            );
        }

        // BUTTON ----------------------------------------------------------------------------------
        private void IFD_Btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected dates from the DateTimePickers
                DateTime startDate = IFD_Dtp_StartDate.Checked ? IFD_Dtp_StartDate.Value : DateTime.Today;
                DateTime endDate = IFD_Dtp_EndDate.Checked ? IFD_Dtp_EndDate.Value : DateTime.Today;

                int userID = Program.MASTER_UserID;

                // Check if endDate is before startDate
                if (endDate < startDate)
                {
                    MessageBox.Show("The end date must not be before the start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Filter records by the selected dates
                _incomeForm.FilterByDate(userID, startDate, endDate);

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void IFD_Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void IncomeFilterDate_Load(object sender, EventArgs e)
        {
            IFD_Dtp_StartDate.Value = DateTime.Today;
            IFD_Dtp_StartDate.Checked = true;
            IFD_Dtp_EndDate.Value = DateTime.Today;
            IFD_Dtp_EndDate.Checked = true;
        }
    }
}
