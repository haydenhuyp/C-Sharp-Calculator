/*
 * Calculator.cs
 * To Run the Calculator
 * 
 * Revision History:
 *      Huy Pham, Jan 25, 2021: Created
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        double x = 0;
        double y = 0;
        string pendingAction = "";
        bool newNumber = false;

        private void Digits_Click(object sender, EventArgs e)
        {
            if (newNumber)
            {
                txtDisplay.Clear();
                lblEquation.Text = "";
                newNumber = false;
            }

            Button source = (Button)sender;
            txtDisplay.Text += source.Text;
        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {
            if (!(txtDisplay.Text.Contains(".")))
            {
                Digits_Click(sender, e);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            x = Convert.ToDouble(txtDisplay.Text);
            txtDisplay.Clear();

            Button source = (Button)sender;
            pendingAction= source.Text;

            lblEquation.Text += (Convert.ToString(x) + " " + pendingAction + " ");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            lblEquation.Text = "";
            x = 0;
            pendingAction = "";
            newNumber = true;
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            y = Convert.ToDouble(txtDisplay.Text);
            lblEquation.Text += (Convert.ToString(y) + " = ");

            switch (pendingAction)
            {
                case "+":
                    {
                        txtDisplay.Text = Convert.ToString(x + y);
                        lblEquation.Text += Convert.ToString(x + y);
                        break;
                    }
                case "-":
                    {
                        txtDisplay.Text = Convert.ToString(x - y);
                        lblEquation.Text += Convert.ToString(x - y);
                        break;
                    }
                case "*":
                    {
                        txtDisplay.Text = Convert.ToString(x * y);
                        lblEquation.Text += Convert.ToString(x * y);
                        break;
                    }
                case "/":
                    {
                        txtDisplay.Text = Convert.ToString(x / y);
                        lblEquation.Text += Convert.ToString(x / y);
                        break;
                    }
                default:
                    break;
            }
            x = 0;
            y = 0;
            pendingAction = "";
            newNumber = true;
        }
    }
}
