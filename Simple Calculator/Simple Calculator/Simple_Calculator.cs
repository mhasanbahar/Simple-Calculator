using System.Data;
using System.Diagnostics;

namespace Simple_Calculator
{
    public partial class Simple_Calculator : Form
    {
        public Simple_Calculator()
        {
            InitializeComponent();
        }

        private bool isOperatorClicked = false;
        private double conclusion = 0; //A variable to store the result
        private string currentExpression = ""; //A variable to accumulate the transaction
        private bool CommaExtension = false; // Has the comma been added before?

        private void DigitClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text.Trim() + button.Text;
            currentExpression += button.Text; //Accumulates transaction
            text_expression.Text += button.Text; //Shows the process
        }
        private void button1_Click(object sender, EventArgs e) //1
        {
            DigitClicked(sender, e);
        }

        private void button2_Click(object sender, EventArgs e) //2
        {
            DigitClicked(sender, e);
        }

        private void button3_Click(object sender, EventArgs e) //3
        {
            DigitClicked(sender, e);
        }

        private void button4_Click(object sender, EventArgs e) //4
        {
            DigitClicked(sender, e);
        }

        private void button5_Click(object sender, EventArgs e) //5
        {
            DigitClicked(sender, e);
        }

        private void button6_Click(object sender, EventArgs e) //6
        {
            DigitClicked(sender, e);
        }

        private void button7_Click(object sender, EventArgs e) //7
        {
            DigitClicked(sender, e);
        }

        private void button8_Click(object sender, EventArgs e) //8
        {
            DigitClicked(sender, e);
        }

        private void button9_Click(object sender, EventArgs e) //9
        {
            DigitClicked(sender, e);
        }

        private void button12_Click(object sender, EventArgs e) //Collection
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Invalid format. Enter a number first.");
                return;
            }
            try
            {
                double number = double.Parse(textBox1.Text);
                conclusion += number;

                // Accumulate transaction
                if (isOperatorClicked)
                {
                    currentExpression += " + " + number;
                }
                else
                {
                    currentExpression = number.ToString() + " + ";
                }

                textBox1.Clear();
                text_expression.Text = currentExpression;
                isOperatorClicked = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format. Please enter a correct number.");
                textBox1.Clear();
            }
        }

        private void button10_Click(object sender, EventArgs e) //0(none)
        {
            DigitClicked(sender, e);
        }

        private void button13_Click(object sender, EventArgs e) //extraction
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Invalid format. Enter a number first.");
                return;
            }
            try
            {
                double number = double.Parse(textBox1.Text);
                conclusion -= number;

                // Accumulate transaction
                if (isOperatorClicked)
                {
                    currentExpression += " - " + number;
                }
                else
                {
                    currentExpression = number.ToString() + " - ";
                }

                textBox1.Clear();
                text_expression.Text = currentExpression;
                isOperatorClicked = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format. Please enter a correct number.");
                textBox1.Clear();
            }
        }

        private void button14_Click(object sender, EventArgs e) //Multiplication
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Invalid format. Enter a number first.");
                return;
            }
            try
            {
                double number = double.Parse(textBox1.Text);
                conclusion *= number;

                // Accumulate transaction
                if (isOperatorClicked)
                {
                    currentExpression += " * " + number;
                }
                else
                {
                    currentExpression = number.ToString() + " * ";
                }

                textBox1.Clear();
                text_expression.Text = currentExpression;
                isOperatorClicked = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format. Please enter a correct number.");
                textBox1.Clear();
            }
        }

        private void button15_Click(object sender, EventArgs e) //Division
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Invalid format. Enter a number first.");
                return;
            }
            try
            {
                double sy = double.Parse(textBox1.Text);

                if (isOperatorClicked)
                {
                    if (sy != 0)
                    {
                        conclusion /= sy;
                        currentExpression += " / " + sy;
                    }
                    else
                    {
                        MessageBox.Show("You cannot divide by zero!!");
                        textBox1.Clear();
                        return; // Bölme sýfýra denk gelirse iþlemi sonlandýr
                    }
                }
                else
                {
                    conclusion = sy;
                    currentExpression = sy.ToString() + " / ";
                    isOperatorClicked = true;
                }

                textBox1.Clear();
                text_expression.Text = currentExpression;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format. Please enter a correct number.");
                textBox1.Clear();
            }
        }

        private void button16_Click(object sender, EventArgs e) //percentage
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Invalid format. Enter a number first.");
                return;
            }
            try
            {
                double sy = double.Parse(textBox1.Text);

                if (isOperatorClicked)
                {
                    double percentageResult = conclusion * sy / 100.0;
                    textBox1.Text = percentageResult.ToString(); // Show result
                }
                else
                {
                    double percentageResult = sy / 100.0;
                    textBox1.Text = percentageResult.ToString(); // Show result
                }

                currentExpression = textBox1.Text; // Update action statement
                text_expression.Text = currentExpression;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format. Please enter a correct number.");
                textBox1.Clear();
            }
        }

        private void button18_Click(object sender, EventArgs e) //Clear
        {
            textBox1.Clear();
            text_conclusion.Clear();
            text_expression.Clear();
            conclusion = 0;
            currentExpression = "";
            CommaExtension = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!isOperatorClicked || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return; //If the operation button is not clicked or there is no input, display a warning and continue the operation.
            }
            try
            {
                currentExpression = currentExpression.Replace(',', '.');

                DataTable dt = new DataTable();
                dt.Columns.Add("bill", typeof(string), currentExpression);

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                conclusion = double.Parse((string)dr["bill"]);
                text_conclusion.Text = conclusion.ToString().Replace(",", ".").Replace(",", "."); //Show result with comma
                text_expression.Text = currentExpression.Replace(',', '.') + " = " + conclusion.ToString().Replace('.', ',');


            }
            catch (Exception ex)
            {
                MessageBox.Show("Calculation Error: " + ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e) //Comma
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                // If textBox1 is empty, simply add "0,"
                textBox1.Text = "0,";
                text_expression.Text += "0,";
                currentExpression += "0,";

            }
            else if (!CommaExtension && !textBox1.Text.Contains(","))
            {
                // If a comma has not been added previously, simply add a comma.
                textBox1.Text += ",";
                text_expression.Text += ",";
                currentExpression += ",";
                CommaExtension = false;
            }
        }
    }
}
