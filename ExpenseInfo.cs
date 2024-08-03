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
    public partial class ExpenseInfo : Form
    {
        private Expense _expenseForm;

        public ExpenseInfo(Expense expenseForm)
        {
            InitializeComponent();

            _expenseForm = expenseForm;
        }

        private void EI_Btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
