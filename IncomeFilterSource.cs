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
    public partial class IncomeFilterSource : Form
    {
        public Income _incomeForm;

        public IncomeFilterSource(Income incomeform)
        {
            InitializeComponent();
            _incomeForm = incomeform;

            //Set the start position to Manual
            this.StartPosition = FormStartPosition.Manual;

            //Calculate the position to center the form within the Expense form
            this.Location = new Point(
                _incomeForm.Location.X + (_incomeForm.Width - this.Width) / 2,
                _incomeForm.Location.Y + (_incomeForm.Height - this.Height) / 2
            );
        }

        // BUTTON ----------------------------------------------------------------------------------
        private void IFS_Btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the ComboBox has a selected item
                string source = IFS_Cmb_Source.SelectedIndex >= 0 ? IFS_Cmb_Source.SelectedItem.ToString() : null;

                int userID = Program.MASTER_UserID;

                if (string.IsNullOrEmpty(source))
                {
                    MessageBox.Show("Please indicate the source.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check for only source filter
                if (!string.IsNullOrEmpty(source))
                {
                    _incomeForm.FilterBySource(userID, source);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();

        }

        private void IFS_Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void IncomeFilterSource_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();

        }
    }
}
