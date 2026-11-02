using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
      
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = "";

        private void Number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            txtDisplay.Text += button.Text; 
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDisplay.Text) && operation == "")
                {
                    Button button = (Button)sender;
                    firstNumber = double.Parse(txtDisplay.Text); 
                    operation = button.Text;                    
                    txtDisplay.Text += button.Text;            
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода числа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(operation) || string.IsNullOrEmpty(txtDisplay.Text))
                    return;

               
                int opIndex = txtDisplay.Text.IndexOf(operation);
                string secondPart = txtDisplay.Text.Substring(opIndex + 1);

                secondNumber = double.Parse(secondPart);
                double result = 0;

                switch (operation)
                {
                    case "+": result = firstNumber + secondNumber; break;
                    case "-": result = firstNumber - secondNumber; break;
                    case "*": result = firstNumber * secondNumber; break;
                    case "/":
                        if (secondNumber == 0) 
                {
                    MessageBox.Show("Деление на ноль невозможно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDisplay.Clear();
                    operation = "";
                    return;
                }
                 result = firstNumber / secondNumber;
                 break;
                }

                txtDisplay.Text += Environment.NewLine + "      " + result.ToString();
                operation = ""; 
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка вычисления выражения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
        }

    }
}
