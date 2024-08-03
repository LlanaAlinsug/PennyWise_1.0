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
    public partial class PlannerCustomize : Form
    {
        private Welcome mainForm;

        // QUESTIONNAIRE VARIABLES
        int score_50_30_20 = 0;
        int score_70_20_10 = 0;
        int score_40_40_20 = 0;
        int score_30_10_60 = 0;

        // Limit app exit message box
        private bool isExiting = false;

        public PlannerCustomize(Welcome mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Enable application exit
            Program.ApplicationExit = true;

            // Convert input and output to whole numbers of percentage
            PC_Txtb_Needs.Text = (Program.NeedsPercentage * 100).ToString();
            PC_Txtb_Wants.Text = (Program.WantsPercentage * 100).ToString();
            PC_Txtb_Funds.Text = (Program.FundsPercentage * 100).ToString();

            // Only accept digits
            PC_Txtb_Needs.KeyPress += FilterDataEntry;
            PC_Txtb_Wants.KeyPress += FilterDataEntry;
            PC_Txtb_Funds.KeyPress += FilterDataEntry;

            PC_Picb_Scheme.Visible = false;

        }

        private void PC_Btn_Apply_Click(object sender, EventArgs e)
        {
            ApplyScheme();
        }

        private void PC_Txtb_Funds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyScheme();
            }
        }

        private void PC_Btn_GetResult_Click(object sender, EventArgs e)
        {
            // Check if all questions have been answered
            if (!PC_Rbtn_Q1_SA.Checked && !PC_Rbtn_Q1_A.Checked && !PC_Rbtn_Q1_D.Checked && !PC_Rbtn_Q1_SD.Checked)
            {
                MessageBox.Show("Please answer Question 1.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!PC_Rbtn_Q2_SA.Checked && !PC_Rbtn_Q2_A.Checked && !PC_Rbtn_Q2_D.Checked && !PC_Rbtn_Q2_SD.Checked)
            {
                MessageBox.Show("Please answer Question 2.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!PC_Rbtn_Q3_SA.Checked && !PC_Rbtn_Q3_A.Checked && !PC_Rbtn_Q3_D.Checked && !PC_Rbtn_Q3_SD.Checked)
            {
                MessageBox.Show("Please answer Question 3.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!PC_Rbtn_Q4_SA.Checked && !PC_Rbtn_Q4_A.Checked && !PC_Rbtn_Q4_D.Checked && !PC_Rbtn_Q4_SD.Checked)
            {
                MessageBox.Show("Please answer Question 4.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!PC_Rbtn_Q5_SA.Checked && !PC_Rbtn_Q5_A.Checked && !PC_Rbtn_Q5_D.Checked && !PC_Rbtn_Q5_SD.Checked)
            {
                MessageBox.Show("Please answer Question 5.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!PC_Rbtn_Q6_SA.Checked && !PC_Rbtn_Q6_A.Checked && !PC_Rbtn_Q6_D.Checked && !PC_Rbtn_Q6_SD.Checked)
            {
                MessageBox.Show("Please answer Question 6.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!PC_Rbtn_Q7_Needs.Checked && !PC_Rbtn_Q7_Wants.Checked && !PC_Rbtn_Q7_Funds.Checked && !PC_Rbtn_Q7_NotSure.Checked)
            {
                MessageBox.Show("Please answer Question 7.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // QUESTION 1
            if (PC_Rbtn_Q1_SA.Checked)
            {
                score_50_30_20 += 4;
                score_40_40_20 += 4;
            }
            else if (PC_Rbtn_Q1_A.Checked)
            {
                score_50_30_20 += 3;
                score_40_40_20 += 3;
            }
            else if (PC_Rbtn_Q1_D.Checked)
            {
                score_50_30_20 += 2;
                score_40_40_20 += 2;
            }
            else if (PC_Rbtn_Q1_D.Checked)
            {
                score_50_30_20++;
                score_40_40_20++;
            }

            // QUESTION 2
            if (PC_Rbtn_Q2_SA.Checked)
            {
                score_30_10_60 += 4;
            }
            else if (PC_Rbtn_Q2_A.Checked)
            {
                score_30_10_60 += 3;
            }
            else if (PC_Rbtn_Q2_D.Checked)
            {
                score_30_10_60 += 2;
            }
            else if (PC_Rbtn_Q2_D.Checked)
            {
                score_30_10_60++;
            }

            // QUESTION 3
            if (PC_Rbtn_Q3_SA.Checked)
            {
                score_50_30_20 += 4;
            }
            else if (PC_Rbtn_Q3_A.Checked)
            {
                score_50_30_20 += 3;
            }
            else if (PC_Rbtn_Q3_D.Checked)
            {
                score_50_30_20 += 2;
            }
            else if (PC_Rbtn_Q3_D.Checked)
            {
                score_50_30_20++;
            }

            // QUESITION 4
            if (PC_Rbtn_Q4_SA.Checked)
            {
                score_70_20_10 += 4;
            }
            else if (PC_Rbtn_Q4_A.Checked)
            {
                score_70_20_10 += 3;
            }
            else if (PC_Rbtn_Q4_D.Checked)
            {
                score_70_20_10 += 2;
            }
            else if (PC_Rbtn_Q4_D.Checked)
            {
                score_70_20_10++;
            }

            // QUESITION 5
            if (PC_Rbtn_Q5_SA.Checked)
            {
                score_30_10_60 += 4;
            }
            else if (PC_Rbtn_Q5_A.Checked)
            {
                score_30_10_60 += 3;
            }
            else if (PC_Rbtn_Q5_D.Checked)
            {
                score_30_10_60 += 2;
            }
            else if (PC_Rbtn_Q5_D.Checked)
            {
                score_30_10_60++;
            }

            // QUESITION 6
            if (PC_Rbtn_Q6_SA.Checked)
            {
                score_70_20_10 += 4;
                score_40_40_20 += 4;
            }
            else if (PC_Rbtn_Q6_A.Checked)
            {
                score_70_20_10 += 3;
                score_40_40_20 += 3;
            }
            else if (PC_Rbtn_Q6_D.Checked)
            {
                score_70_20_10 += 2;
                score_40_40_20 += 2;
            }
            else if (PC_Rbtn_Q6_D.Checked)
            {
                score_70_20_10++;
                score_40_40_20++;
            }

            // QUESITION 7
            if (PC_Rbtn_Q7_Needs.Checked)
            {
                score_70_20_10 += 4;
            }
            else if (PC_Rbtn_Q7_Wants.Checked)
            {
                score_40_40_20 += 4;
            }
            else if (PC_Rbtn_Q7_Funds.Checked)
            {
                score_30_10_60 += 4;
            }
            else if (PC_Rbtn_Q7_NotSure.Checked)
            {
                score_50_30_20 += 4;
            }

            // CALCULATE RESULTS
            // 50-30-20
            if (score_50_30_20 > score_30_10_60 && score_50_30_20 > score_40_40_20 && score_50_30_20 > score_70_20_10)
            {
                PC_Txtb_Needs.Text = 50.ToString();
                PC_Txtb_Wants.Text = 30.ToString();
                PC_Txtb_Funds.Text = 20.ToString();

                PC_Picb_Scheme.Visible = true;
                PC_Picb_Scheme.Image = Properties.Resources.BudgetScheme2;
            }
            // 70-20-10
            if (score_70_20_10 > score_50_30_20 && score_70_20_10 > score_30_10_60 && score_70_20_10 > score_40_40_20)
            {
                PC_Txtb_Needs.Text = 70.ToString();
                PC_Txtb_Wants.Text = 20.ToString();
                PC_Txtb_Funds.Text = 10.ToString();

                PC_Picb_Scheme.Visible = true;
                PC_Picb_Scheme.Image = Properties.Resources.BudgetScheme1;
            }
            // 40-40-20
            if (score_40_40_20 > score_50_30_20 && score_40_40_20 > score_30_10_60 && score_40_40_20 > score_70_20_10)
            {
                PC_Txtb_Needs.Text = 40.ToString();
                PC_Txtb_Wants.Text = 40.ToString();
                PC_Txtb_Funds.Text = 20.ToString();

                PC_Picb_Scheme.Visible = true;
                PC_Picb_Scheme.Image = Properties.Resources.BudgetScheme3;
            }
            // 30-10-60
            if (score_30_10_60 > score_40_40_20 && score_30_10_60 > score_50_30_20 && score_30_10_60 > score_70_20_10)
            {
                PC_Txtb_Needs.Text = 30.ToString();
                PC_Txtb_Wants.Text = 10.ToString();
                PC_Txtb_Funds.Text = 60.ToString();

                PC_Picb_Scheme.Visible = true;
                PC_Picb_Scheme.Image = Properties.Resources.BudgetScheme4;
            }

        }

        private void PC_Btn_Retake_Click(object sender, EventArgs e)
        {
            score_50_30_20 = 0;
            score_70_20_10 = 0;
            score_40_40_20 = 0;
            score_30_10_60 = 0;

            PC_Picb_Scheme.Visible = false;

            PC_Rbtn_Q1_SA.Checked = false;
            PC_Rbtn_Q1_A.Checked = false;
            PC_Rbtn_Q1_D.Checked = false;
            PC_Rbtn_Q1_SD.Checked = false;

            PC_Rbtn_Q2_SA.Checked = false;
            PC_Rbtn_Q2_A.Checked = false;
            PC_Rbtn_Q2_D.Checked = false;
            PC_Rbtn_Q2_SD.Checked = false;

            PC_Rbtn_Q3_SA.Checked = false;
            PC_Rbtn_Q3_A.Checked = false;
            PC_Rbtn_Q3_D.Checked = false;
            PC_Rbtn_Q3_SD.Checked = false;

            PC_Rbtn_Q4_SA.Checked = false;
            PC_Rbtn_Q4_A.Checked = false;
            PC_Rbtn_Q4_D.Checked = false;
            PC_Rbtn_Q4_SD.Checked = false;

            PC_Rbtn_Q5_SA.Checked = false;
            PC_Rbtn_Q5_A.Checked = false;
            PC_Rbtn_Q5_D.Checked = false;
            PC_Rbtn_Q5_SD.Checked = false;

            PC_Rbtn_Q6_SA.Checked = false;
            PC_Rbtn_Q6_A.Checked = false;
            PC_Rbtn_Q6_D.Checked = false;
            PC_Rbtn_Q6_SD.Checked = false;

            PC_Rbtn_Q7_Needs.Checked = false;
            PC_Rbtn_Q7_Wants.Checked = false;
            PC_Rbtn_Q7_Funds.Checked = false;
            PC_Rbtn_Q7_NotSure.Checked = false;

        }

        private void PC_Btn_Back_Click(object sender, EventArgs e)
        {
            ShowFormAtRelativeCenter(new Planner(mainForm));
            this.Close();

        }

        private void ApplyScheme()
        {
            if (ValidateTextBoxes()) // Proceed since all TextBoxes are validated
            {
                int needsInput = int.Parse(PC_Txtb_Needs.Text);
                int wantsInput = int.Parse(PC_Txtb_Wants.Text);
                int fundsInput = int.Parse(PC_Txtb_Funds.Text);

                // Declare variables for needs, wants, and funds
                float needsPercentage = needsInput / 100;
                float wantsPercentage = needsInput / 100;
                float fundsPercentage = needsInput / 100;

                // Try to parse the text from text boxes into the float variables
                float.TryParse(PC_Txtb_Needs.Text, out needsPercentage);
                float.TryParse(PC_Txtb_Wants.Text, out wantsPercentage);
                float.TryParse(PC_Txtb_Funds.Text, out fundsPercentage);

                // Update application settings with the parsed values
                Program.NeedsPercentage = needsPercentage / 100;
                Program.FundsPercentage = fundsPercentage / 100;
                Program.WantsPercentage = wantsPercentage / 100;

                Program.P_SchemeCustomizeUpdate = true;

                ShowFormAtRelativeCenter(new Planner(mainForm));
                this.Close();
            }
        }

        private void ShowFormAtRelativeCenter(Form newForm)
        {
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
        private bool ValidateTextBoxes()
        {
            // Check if Needs is empty
            if (string.IsNullOrEmpty(PC_Txtb_Needs.Text))
            {
                MessageBox.Show("Please enter a value for Needs.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if Wants is empty
            if (string.IsNullOrEmpty(PC_Txtb_Wants.Text))
            {
                MessageBox.Show("Please enter a value for Wants.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if Funds is empty
            if (string.IsNullOrEmpty(PC_Txtb_Funds.Text))
            {
                MessageBox.Show("Please enter a value for Funds.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate numeric inputs
            int needsInput, wantsInput, fundsInput;

            if (!int.TryParse(PC_Txtb_Needs.Text, out needsInput) || needsInput < 0 || needsInput > 100)
            {
                MessageBox.Show("Please enter a valid integer value between 0 and 100 for Needs.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(PC_Txtb_Wants.Text, out wantsInput) || wantsInput < 0 || wantsInput > 100)
            {
                MessageBox.Show("Please enter a valid integer value between 0 and 100 for Wants.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(PC_Txtb_Funds.Text, out fundsInput) || fundsInput < 0 || fundsInput > 100)
            {
                MessageBox.Show("Please enter a valid integer value between 0 and 100 for Funds.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if total exceeds 100%
            if (needsInput + wantsInput + fundsInput != 100)
            {
                MessageBox.Show("The sum of Needs, Wants, and Funds must be equal to 100%.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // All validations passed
        }
        private void FilterDataEntry(object sender, KeyPressEventArgs e)
        {
            // Allow control keys and digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block any non-control key that is not a digit
            }
        }
    }
}