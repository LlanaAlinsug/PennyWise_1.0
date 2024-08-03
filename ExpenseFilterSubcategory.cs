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
    public partial class ExpenseFilterSubcategory : Form
    {
        private Expense _expenseForm;

        public ExpenseFilterSubcategory(Expense expenseForm)
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
        private void EFS_Btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the ComboBox has a selected item
                string subcategory = EFS_Cmb_Subcategory.SelectedIndex >= 0 ? EFS_Cmb_Subcategory.SelectedItem.ToString() : null;

                int userID = Program.MASTER_UserID;

                // Check for subcategory filter
                if (!string.IsNullOrEmpty(subcategory))
                {
                    _expenseForm.FilterBySubcategory(userID, subcategory);
                }
                else
                {
                    MessageBox.Show("Please indicate the subcategory.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide(); // Hide the filter form after applying the filter
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while applying the filter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EFS_Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
