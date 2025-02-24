using System;
using System.Windows.Forms;

namespace WinProg_2_20
{
    public partial class Form1 : Form
    {
        private string currentInput = "";
        private double firstOperand;
        private char currentOperator;
        private bool isNewNumber = true;

        public Form1()
        {
            InitializeComponent();
        }

        // 数字按钮公共处理方法
        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (isNewNumber)
            {
                currentInput = "";
                isNewNumber = false;
            }

            Button button = (Button)sender;
            currentInput += button.Text;  // 将按钮文字（数字）拼接到 currentInput
            textBox1.Text = currentInput;
        }


        // 运算符公共处理方法
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(currentInput))
            {
                firstOperand = double.Parse(currentInput);
                currentOperator = button.Text[0];
                isNewNumber = true;
            }
            else if (currentOperator != '\0')
            {
                currentOperator = button.Text[0];
            }
        }

        // 等于号
        private void operatorResult_Click(object sender, EventArgs e)
        {
            if (currentOperator == '\0' || currentInput == "") return;

            double secondOperand = double.Parse(currentInput);
            double result = 0;

            switch (currentOperator)
            {
                case '+':
                    result = firstOperand + secondOperand;
                    break;
                case '-':
                    result = firstOperand - secondOperand;
                    break;
                case '×':
                    result = firstOperand * secondOperand;
                    break;
                case '÷':
                    if (secondOperand == 0)
                    {
                        MessageBox.Show("不能除以零！");
                        return;
                    }
                    result = firstOperand / secondOperand;
                    break;
            }

            textBox1.Text = result.ToString("G29");
            currentInput = result.ToString();
            firstOperand = result;
            isNewNumber = true;
            currentOperator = '\0';
        }

        // 清除
        private void operatorClear_Click(object sender, EventArgs e)
        {
            currentInput = "";
            firstOperand = 0;
            currentOperator = '\0';
            textBox1.Text = "";
            isNewNumber = true;
        }

        // 退格
        private void operatorBack_Click(object sender, EventArgs e)
        {
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                textBox1.Text = currentInput;
            }
        }

        // 将数字按钮事件绑定到公共处理方法
        private void Num1_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);
        private void Num2_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);
        private void Num3_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);
        private void Num4_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);
        private void Num5_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);
        private void Num6_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);
        private void Num7_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);
        private void Num8_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);
        private void Num9_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);
        private void Num0_Click(object sender, EventArgs e) => NumberButton_Click(sender, e);

        // 运算符按钮事件绑定
        private void operatorAdd_Click(object sender, EventArgs e) => OperatorButton_Click(sender, e);
        private void operatorSub_Click(object sender, EventArgs e) => OperatorButton_Click(sender, e);
        private void operatorMult_Click(object sender, EventArgs e) => OperatorButton_Click(sender, e);
        private void operatorDiv_Click(object sender, EventArgs e) => OperatorButton_Click(sender, e);


        private void Form1_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }


    }
}
