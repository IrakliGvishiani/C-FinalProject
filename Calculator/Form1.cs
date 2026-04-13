namespace Calculator
{
    public partial class Form1 : Form
    {

        double firstNumber = 0;
        string operation = "";
        bool isNewInput = true;
        public Form1()
        {
            InitializeComponent();
        }



        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (isNewInput)
            {
                ResultBox.Text = "";
                isNewInput = false;
            }

            ResultBox.Text += btn.Text;
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            try
            {
                firstNumber = double.Parse(ResultBox.Text);
                Button btn = (Button)sender;
                operation = btn.Text;
                isNewInput = true;

            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input!");
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ResultBox.Text = "";
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            try
            {
                double secondNumber = double.Parse(ResultBox.Text);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;

                    case "-":
                        result = firstNumber - secondNumber;
                        break;

                    case "*":
                        result = firstNumber * secondNumber;
                        break;

                    case "/":
                        if (secondNumber == 0)
                            throw new DivideByZeroException();

                        result = firstNumber / secondNumber;
                        break;

                    default:
                        MessageBox.Show("Choose an operation!");
                        return;
                }

                ResultBox.Text = result.ToString();
                isNewInput = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input!");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Cannot divide by zero!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
