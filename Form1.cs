using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public enum calcExpression
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
    
    public delegate double ExpressionHandler(double x1, double x2);
    
    public partial class Form1 : Form
    {
        public static ManualResetEvent mre = new ManualResetEvent(true);
        private double arg1;
        private double arg2=0;
        private double result=0;
        private calcExpression exp;
        private ExpressionHandler calculate=null;

        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(butttonClicked);
            button2.Click += new EventHandler(butttonClicked);
            button3.Click += new EventHandler(butttonClicked);
            button4.Click += new EventHandler(butttonClicked);
            button5.Click += new EventHandler(butttonClicked);
            button6.Click += new EventHandler(butttonClicked);
            button7.Click += new EventHandler(butttonClicked);
            button8.Click += new EventHandler(butttonClicked);
            button9.Click += new EventHandler(butttonClicked);
            button0.Click += new EventHandler(butttonClicked);
            dotButton.Click += new EventHandler(butttonClicked);
        }

        private void butttonClicked(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;

                switch (btn.Name)
                {
                    case "button1":
                        resultTextBox.Text += "1";
                        break;
                    case "button2":
                        resultTextBox.Text += "2";
                        break;
                    case "button3":
                        resultTextBox.Text += "3";
                        break;
                    case "button4":
                        resultTextBox.Text += "4";
                        break;
                    case "button5":
                        resultTextBox.Text += "5";
                        break;
                    case "button6":
                        resultTextBox.Text += "6";
                        break;
                    case "button7":
                        resultTextBox.Text += "7";
                        break;
                    case "button8":
                        resultTextBox.Text += "8";
                        break;
                    case "button9":
                        resultTextBox.Text += "9";
                        break;
                    case "button0":
                        resultTextBox.Text += "0";
                        break;
                    case "dotButton":
                        if (!resultTextBox.Text.Contains("."))
                            resultTextBox.Text += ".";
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " +
                    ex.Message);
            } 
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            equals();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           arg1 = 2;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            arg1 = Convert.ToDouble(resultTextBox.Text);
            resultTextBox.Text = string.Empty;
            exp = calcExpression.Add;
        }

        private void equals()
        {
            arg2 = Convert.ToDouble(resultTextBox.Text);          
            resultTextBox.Text = result.ToString();
            arg1 = calculateExp(exp, arg1, arg2);
            resultTextBox.Text = arg1.ToString();
        }

        private double Add(double x1, double x2)
        {
            return x1 + x2;
        }

        private double Subtract(double x1, double x2)
        {
            return x1 - x2;
        }

        private double Multiply(double x1, double x2)
        {
            return x1 * x2;
        }

        private double Divide(double x1, double x2) {
            return x1 / x2;
        }

        double calculateExp(calcExpression type, double x, double y)
        {
            switch (type)
            {
                case calcExpression.Add:
                    calculate += new ExpressionHandler(Add);
                    break;
                case calcExpression.Subtract:
                    calculate += new ExpressionHandler(Subtract);
                    break;
                case calcExpression.Multiply:
                    calculate += new ExpressionHandler(Multiply);
                    break;
                case calcExpression.Divide:
                    calculate += new ExpressionHandler(Divide);
                    break;
            }
            return calculate(x, y);
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            arg1 = Convert.ToDouble(resultTextBox.Text);
            resultTextBox.Text = string.Empty;
            exp = calcExpression.Subtract;
        }

        private void timesButton_Click(object sender, EventArgs e)
        {
            arg1 = Convert.ToDouble(resultTextBox.Text);
            resultTextBox.Text = string.Empty;
            exp = calcExpression.Multiply;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            arg1 = 0;
            arg2 = 0;
            resultTextBox.Text = "";
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            arg1 = Convert.ToDouble(resultTextBox.Text);
            exp = calcExpression.Divide;
            resultTextBox.Text = string.Empty;
        }
        

    }
}
