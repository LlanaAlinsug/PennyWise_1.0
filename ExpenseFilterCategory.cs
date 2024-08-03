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
    public partial class ExpenseFilterCategory : Form
    {
        private Expense _expenseForm;

        public ExpenseFilterCategory(Expense expenseForm)
        {
            InitializeComponent();

            _expenseForm = expenseForm;

            // Set the start position to Manual
            this.StartPosition = FormStartPosition.Manual;

            // Calculate the position to center the form within the Expense form
            this.Location = new Point(
                _expenseForm.Location.X + (_expenseForm.Width - this.Width) / 2,
                _expenseForm.Location.Y + (_expenseForm.Height - this.Height) / 2
            );
        }

        // BUTTON ----------------------------------------------------------------------------------
        private void EFC_Btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the ComboBox has a selected item
                string category = EFC_Cmb_Category.SelectedIndex >= 0 ? EFC_Cmb_Category.SelectedItem.ToString() : null;

                int userID = Program.MASTER_UserID;

                // Check for category filter
                if (!string.IsNullOrEmpty(category))
                {
                    _expenseForm.FilterByCategory(userID, category);
                }
                else
                {
                    MessageBox.Show("Please indicate the category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide(); // Hide the filter form after applying the filter
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while applying the filter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EFC_Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
