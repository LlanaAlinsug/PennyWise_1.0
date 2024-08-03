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
    public partial class Expense : Form
    {
        private Welcome mainForm;

        private int E_MasterUserID = Program.MASTER_UserID;
        private int E_MasterLoginID = Program.MASTER_LoginID;

        // Limit app exit message box
        private bool isExiting = false;

        private bool isProcessing = false; // Flag to indicate if a process is ongoing

        public Expense(Welcome mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Enable application exit
            Program.ApplicationExit = true;
            this.FormClosed += Expense_FormClosed;

            E_Dgv_Expense.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            E_Dgv_Expense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadExpenseData();

            // DISPLAY USERNAME
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                try
                {
                    var user_name = db.uspRetrieveAccountDetails(E_MasterUserID).FirstOrDefault();
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

        private void LoadExpenseData()
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                int userID = Program.MASTER_UserID;
                E_Dgv_Expense.DataSource = db.uspGetExpenses(userID).ToList();

                var TotalExpenses = db.uspGetTotalExpenses(userID).FirstOrDefault();
                E_Lbl_TotalExpense.Text = $"{(TotalExpenses?.ToString("F2") ?? "0.00")}";

                decimal totalIncome = db.uspGetTotalIncome(userID).FirstOrDefault() ?? 0;
                decimal totalExpenses = db.uspGetTotalExpenses(userID).FirstOrDefault() ?? 0;

                decimal currentBalance = totalIncome - totalExpenses;
                E_Lbl_CurrentBalance.Text = currentBalance.ToString("F2");
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

        private async void Btn_Income_Click(object sender, EventArgs e)
        {
            await HandleButtonClickAsync(async () =>
            {
                ShowFormAtRelativeCenter(new Income(mainForm));
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

        // BUTTONS ----------------------------------------------------------------------------------
        
        // SAVE 
        private void E_Btn_Save_Click(object sender, EventArgs e)
        {
            // Check if the Amount text box is filled
            if (string.IsNullOrWhiteSpace(E_Txtb_Amount.Text))
            {
                MessageBox.Show("Amount is required. Please fill it out before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the Amount text box contains a valid decimal number
            if (!decimal.TryParse(E_Txtb_Amount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the ComboBox has a selected item
            if (E_Cmb_Category.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category from the dropdown.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (E_Cmb_Subcategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a sub-category from the dropdown.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if a valid date is selected in the DateTimePicker
            DateTime selectedDate = E_Dtp_Expense.Value;
            if (selectedDate == DateTimePicker.MinimumDateTime || selectedDate == DateTimePicker.MaximumDateTime)
            {
                MessageBox.Show("Please select a valid date for the expense.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        int.TryParse(E_Lbl_ExpenseID.Text, out int expenseID);

                        if (expenseID == 0)
                        {
                            // Adding new record
                            db.uspAddExpense(userID, null, E_Txtb_Description.Text, amount, E_Cmb_Category.Text, E_Cmb_Subcategory.Text, selectedDate);
                        }
                        else
                        {
                            //Updating a record
                            db.uspUpdateExpense(userID, expenseID, E_Txtb_Description.Text, amount, E_Cmb_Category.Text, E_Cmb_Subcategory.Text, selectedDate);
                        }

                        MessageBox.Show("Information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadExpenseData();
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
                    LoadExpenseData();

                }
                MessageBox.Show("Save operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        // DELETE
        private void E_Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int expenseID;
                int userID = Program.MASTER_UserID;
                if (int.TryParse(E_Lbl_ExpenseID.Text, out expenseID))
                {
                    var confirmResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                        {
                            try
                            {
                                var deleteExpense = db.uspDeleteExpense(userID, expenseID);
                                if (deleteExpense > 0)
                                {
                                    MessageBox.Show("A record has been deleted.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadExpenseData();
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
                            LoadExpenseData();
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
        private void E_Btn_Undo_Click(object sender, EventArgs e)
        {
            try
            {
                using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                {
                    int userID = Program.MASTER_UserID;
                    LoadExpenseData();
                    clearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while undoing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // EXPENSE INFO
        private void E_Btn_Info_Click(object sender, EventArgs e)
        {
            ShowExpenseFilterForm(new ExpenseInfo(this));
        }

        // METHODS------------------------------------------------------------------------------------------------
        // FILTERS--------------------------------------------------------------------
        private Form currentExpenseFilterForm;

        private void ShowExpenseFilterForm(Form ExpensefilterForm)
        {
            if (currentExpenseFilterForm != null)
            {
                currentExpenseFilterForm.Close();
            }

            // Set the owner of the filter form to this form
            ExpensefilterForm.Owner = this;
            currentExpenseFilterForm = ExpensefilterForm;
            currentExpenseFilterForm.Show();
        }

        private void E_Btn_Category_Click(object sender, EventArgs e)
        {
            ShowExpenseFilterForm(new ExpenseFilterCategory(this));
        }

        private void E_Btn_Subcategory_Click(object sender, EventArgs e)
        {
            ShowExpenseFilterForm(new ExpenseFilterSubcategory(this));
        }

        private void E_Btn_Date_Click(object sender, EventArgs e)
        {
            ShowExpenseFilterForm(new ExpenseFilterDate(this));
        }

        // CLEAR FIELDS ----------------------------------------------------------------------------------
        private void clearFields()
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    ((TextBox)item).Clear();
                }

                else if (E_Cmb_Category is ComboBox comboBox && E_Cmb_Subcategory is ComboBox comboBox2)
                {
                    comboBox.SelectedIndex = -1; // Clear selection
                    comboBox2.SelectedIndex = -1; // Clear selection
                }
            }
        }

        // SEARCH DESCRIPTION ----------------------------------------------------------------------------------
        private void E_Txtb_Search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
                {
                    int userID = Program.MASTER_UserID;

                    if (string.IsNullOrWhiteSpace(E_Txtb_Search.Text))
                    {
                        E_Dgv_Expense.DataSource = db.uspGetExpenses(userID).ToList();
                    }
                    else
                    {
                        E_Dgv_Expense.DataSource = db.uspSearchExpensesByDesc(userID, E_Txtb_Search.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FOR FILTER FORMS ----------------------------------------------------------------------------------

        public void FilterByCategory(int userID, string category)
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                var query = db.uspFilterExpensesByCategory(userID, category);
                E_Dgv_Expense.DataSource = query.ToList();
            }
        }

        public void FilterBySubcategory(int userID, string subcategory)
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                var query = db.uspFilterExpensesBySubcategory(userID, subcategory);
                E_Dgv_Expense.DataSource = query.ToList();
            }
        }

        public void FilterByDate(int userID, DateTime startdate, DateTime enddate)
        {
            using (PennyWiseCloudDBEntities db = new PennyWiseCloudDBEntities())
            {
                var query = db.uspFilterExpensesByDate(userID, startdate, enddate);
                E_Dgv_Expense.DataSource = query.ToList();
            }
        }

        // DATAGRIDVIEW SELECTION------------------------------------------------------------------------
        private int lastClickedRowIndex = -1;

        private void E_Dgv_Expense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex == lastClickedRowIndex)
                {
                    // Clear the relevant TextBox controls
                    E_Lbl_ExpenseID.Clear();
                    E_Txtb_Description.Clear();
                    E_Cmb_Category.SelectedIndex = -1; // Clear ComboBox selection
                    E_Cmb_Subcategory.SelectedIndex = -1; // Clear ComboBox selection
                    E_Txtb_Amount.Clear();
                    E_Dtp_Expense.Value = DateTime.Now; // Reset DateTimePicker to the current date

                    // Reset the last clicked row index
                    lastClickedRowIndex = -1;
                }
                else
                {
                    DataGridViewRow clickedRow = E_Dgv_Expense.Rows[e.RowIndex];
                    E_Lbl_ExpenseID.Text = clickedRow.Cells[0].Value.ToString();
                    E_Txtb_Description.Text = clickedRow.Cells[1].Value.ToString();
                    E_Txtb_Amount.Text = clickedRow.Cells[2].Value.ToString();
                    E_Cmb_Category.Text = clickedRow.Cells[3].Value.ToString();
                    E_Cmb_Subcategory.Text = clickedRow.Cells[4].Value.ToString();
                    E_Dtp_Expense.Text = clickedRow.Cells[5].Value.ToString();

                    // Update the last clicked row index
                    lastClickedRowIndex = e.RowIndex;
                }
            }

        }

        // CLOSE APPLICATION------------------------------------------------------------------------
        private void Expense_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Expense_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ApplicationExit = true;
        }

        private void E_Btn_Export_Click(object sender, EventArgs e)
        {
            E_Dgv_Expense.SelectAll();
            DataObject copydata = E_Dgv_Expense.GetClipboardContent();
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

        private void E_Txtb_Amount_KeyPress(object sender, KeyPressEventArgs e)
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
