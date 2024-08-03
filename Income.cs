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
    public partial class Income : Form
    {
        private Welcome mainForm;

        private int I_MasterUserID = Program.MASTER_UserID;
        private int I_MasterLoginID = Program.MASTER_LoginID;

        // Limit app exit message box
        private bool isExiting = false;

        private bool isProcessing = false; // Flag to indicate if a process is ongoing

        public Income(Welcome mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Enable application exit
            Program.ApplicationExit = true;
            this.FormClosed += Income_FormClosed;

            I_Dgv_Income.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            I_Dgv_Income.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadIncomeData();

            // DISPLAY USERNAME
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                try
                {
                    var user_name = db.uspRetrieveAccountDetails(I_MasterUserID).FirstOrDefault();
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

        private void LoadIncomeData()
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                int userID = Program.MASTER_UserID;
                I_Dgv_Income.DataSource = db.uspGetIncome(userID).ToList();

                var TotalIncome = db.uspGetTotalIncome(userID).FirstOrDefault();
                I_Lbl_TotalIncome.Text = $"{TotalIncome?.ToString("F2") ?? "0.00"}";

                decimal totalIncome = db.uspGetTotalIncome(userID).FirstOrDefault() ?? 0;
                decimal totalExpenses = db.uspGetTotalExpenses(userID).FirstOrDefault() ?? 0;

                decimal currentBalance = totalIncome - totalExpenses;
                I_Lbl_CurrentBalance.Text = currentBalance.ToString("F2");
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

        // TAB BUTTON ------------------------------------------------------
        private async void Btn_Homepage_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                ShowFormAtRelativeCenter(new Homepage(mainForm));
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

        // FORM NAVIGATION ----------------------------------------------------------------------------------
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

        // BUTTONS --------------------------------------------------------------

        // SAVE
        private void I_Btn_Save_Click(object sender, EventArgs e)
        {
            // Check if the ComboBox has a selected item
            if (I_Cmb_Source.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a source of income from the dropdown.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the Amount text box is filled
            if (string.IsNullOrWhiteSpace(I_Txtb_Amount.Text))
            {
                MessageBox.Show("Amount is required. Please fill it out before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the Amount text box contains a valid decimal number
            if (!decimal.TryParse(I_Txtb_Amount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if a valid date is selected in the DateTimePicker
            DateTime selectedDate = I_Dtp_Income.Value;
            if (selectedDate == DateTimePicker.MinimumDateTime || selectedDate == DateTimePicker.MaximumDateTime)
            {
                MessageBox.Show("Please select a valid date for the income.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show confirmation dialog only if all validations pass
            DialogResult result = MessageBox.Show("Are you sure you want to save this information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                    {
                        int userID = Program.MASTER_UserID;
                        int.TryParse(I_Lbl_IncomeID.Text, out int incomeID);

                        // Determine if we are adding or updating
                        if (incomeID == 0)
                        {
                            // Adding new record
                            db.uspAddIncome(null, userID, I_Cmb_Source.Text, amount, selectedDate, I_Txtb_Note.Text);
                        }
                        else
                        {
                            // Updating existing record
                            db.uspUpdateIncome(incomeID, userID, I_Cmb_Source.Text, amount, selectedDate, I_Txtb_Note.Text);
                        }

                        MessageBox.Show("Information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadIncomeData();
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                {
                    LoadIncomeData();
                }
                MessageBox.Show("Save operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        // DELETE
        private void I_Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int incomeID;
                int userID = Program.MASTER_UserID;

                if (int.TryParse(I_Lbl_IncomeID.Text, out incomeID))
                {
                    var confirmResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                        {
                            try
                            {
                                var deleteIncome = db.uspDeleteIncome(userID, incomeID);
                                if (deleteIncome > 0)
                                {
                                    MessageBox.Show("A record has been deleted.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadIncomeData();
                                    clearFields();
                                }
                                else
                                {
                                    MessageBox.Show("Unable to delete record.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                        {
                            LoadIncomeData();
                            clearFields();
                        }
                    }
                }
                else
                {
                    clearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // UNDO
        private void I_Btn_Undo_Click(object sender, EventArgs e)
        {
            try
            {
                using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                {
                    LoadIncomeData();
                    clearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching income data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FILTER-----------------------------------------------
        private Form currentIncomeFilterForm;

        private void ShowIncomeFilterForm(Form IncomefilterForm)
        {
            if (currentIncomeFilterForm != null)
            {
                currentIncomeFilterForm.Close();
            }

            // Set the owner of the filter form to this form
            IncomefilterForm.Owner = this;
            currentIncomeFilterForm = IncomefilterForm;
            currentIncomeFilterForm.Show();
        }

        private void I_Btn_Source_Click(object sender, EventArgs e)
        {
            ShowIncomeFilterForm(new IncomeFilterSource(this));
        }

        private void I_Btn_Date_Click(object sender, EventArgs e)
        {
            ShowIncomeFilterForm(new IncomeFilterDate(this));
        }

        public void FilterBySource(int userID, string source)
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                var query = db.uspFilterIncomeBySource(userID, source);
                I_Dgv_Income.DataSource = query.ToList();
            }
        }

        public void FilterByDate(int userID, DateTime startDate, DateTime endDate)
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                var query = db.uspFilterIncomeByDate(userID, startDate, endDate);
                I_Dgv_Income.DataSource = query.ToList();
            }
        }


        // DATA GRID VIEW ----------------------------------------------------------------------------------

        private int lastClickedRowIndex = -1;

        private void I_Dgv_Income_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex == lastClickedRowIndex)
                {
                    // Clear the relevant TextBox controls
                    I_Lbl_IncomeID.Clear();
                    I_Cmb_Source.SelectedIndex = -1; // Clear ComboBox selection
                    I_Txtb_Amount.Clear();
                    I_Dtp_Income.Value = DateTime.Now; // Reset DateTimePicker to the current date
                    I_Txtb_Note.Clear();

                    // Reset the last clicked row index
                    lastClickedRowIndex = -1;
                }
                else
                {
                    DataGridViewRow clickedRow = I_Dgv_Income.Rows[e.RowIndex];
                    I_Lbl_IncomeID.Text = clickedRow.Cells[0].Value.ToString();
                    I_Cmb_Source.Text = clickedRow.Cells[1].Value.ToString();
                    I_Txtb_Amount.Text = clickedRow.Cells[2].Value.ToString();
                    I_Dtp_Income.Text = clickedRow.Cells[3].Value.ToString();
                    I_Txtb_Note.Text = clickedRow.Cells[4].Value.ToString();

                    // Update the last clicked row index
                    lastClickedRowIndex = e.RowIndex;
                }
            }

        }

        // CLEAR FIELD ----------------------------------------------------------------------------------
        private void clearFields()
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    ((TextBox)item).Clear();
                }

                else if (I_Cmb_Source is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1; // Clear selection
                }
            }
        }

        // SEARCH DESCRIPTION----------------------------------------------------------------------------
        private void I_Txtb_Search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                {
                    int userID = Program.MASTER_UserID;

                    if (string.IsNullOrWhiteSpace(I_Txtb_Search.Text))
                    {
                        I_Dgv_Income.DataSource = db.uspGetIncome(userID).ToList();
                    }
                    else
                    {
                        I_Dgv_Income.DataSource = db.uspSearchIncomeByDesc(userID, I_Txtb_Search.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // CLOSE APPLICATION---------------------------------------------------------------
        private void Income_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Income_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ApplicationExit = true;
        }

        private void I_Btn_Export_Click(object sender, EventArgs e)
        {
            I_Dgv_Income.SelectAll();
            DataObject copydata = I_Dgv_Income.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object miseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            xlr.Select();

            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void I_Txtb_Amount_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
