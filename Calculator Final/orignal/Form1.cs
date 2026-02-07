using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace orignal
{
    public partial class Form1 : Form
    {
        double enterFirstValue, enterSecondValue;
        String op;
        public Form1()
        {
            InitializeComponent();
        }

        private void EnterNumbers(object sender, EventArgs e)
        {
            Button num = (Button)sender;

            if (txtResult.Text == "0")
                txtResult.Text = "";
            {
                if (num.Text == ".")
                {
                    if (!txtResult.Text.Contains("."))
                        txtResult.Text = txtResult.Text + num.Text;
                }
                else
                {
                    txtResult.Text = txtResult.Text + num.Text;
                }
            }
        }

        private void numberOper(object sender, EventArgs e)
        {
            Button num = (Button)sender;

            try
            {
                enterFirstValue = Convert.ToDouble(txtResult.Text);
                op = num.Text;
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                enterSecondValue = Convert.ToDouble(txtResult.Text);

                switch (op)
                {
                    case "+":
                        txtResult.Text = (enterFirstValue + enterSecondValue).ToString();
                        break;
                    case "-":
                        txtResult.Text = (enterFirstValue - enterSecondValue).ToString();
                        break;
                    case "*":
                        txtResult.Text = (enterFirstValue * enterSecondValue).ToString();
                        break;
                    case "/":
                        if (enterSecondValue == 0)
                        {
                            MessageBox.Show("Division by zero is not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                            return;
                        }
                        txtResult.Text = (enterFirstValue / enterSecondValue).ToString();
                        break;
                    case "Mod":
                        if (enterSecondValue == 0)
                        {
                            MessageBox.Show("Modulus by zero is not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                            return;
                        }
                        txtResult.Text = (enterFirstValue % enterSecondValue).ToString();
                        break;
                    case "Exp":
                        txtResult.Text = Math.Pow(enterFirstValue, enterSecondValue).ToString();
                        break;
                    case "Sin":
                        try
                        {
                            // For sine, we take the input value as degrees
                            double angleInDegrees = enterSecondValue;
                            double sinRad = angleInDegrees * (Math.PI / 180.0); // Convert degrees to radians
                            double sinResult = Math.Sin(sinRad);
                            // Clean up near-zero results (for angles like 180, 360, etc.)
                            if (Math.Abs(sinResult) < 1E-15) sinResult = 0;
                            txtResult.Text = sinResult.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error calculating sine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                        }
                        break;
                    case "Cos":
                        try
                        {
                            // For cosine, we take the input value as degrees
                            double angleInDegrees = enterSecondValue;
                            double cosRad = angleInDegrees * (Math.PI / 180.0); // Convert degrees to radians
                            double cosResult = Math.Cos(cosRad);
                            // Clean up near-zero results (for angles like 90, 270, etc.)
                            if (Math.Abs(cosResult) < 1E-15) cosResult = 0;
                            txtResult.Text = cosResult.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error calculating cosine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                        }
                        break;
                    case "Tan":
                        try
                        {
                            // For tangent, we take the input value as degrees
                            double angleInDegrees = enterSecondValue;
                            double tanRad = angleInDegrees * (Math.PI / 180.0); // Convert degrees to radians

                            // Check for undefined tan values (90°, 270°, etc.)
                            if (Math.Abs(Math.Cos(tanRad)) < 1E-15)
                            {
                                MessageBox.Show("Tangent is undefined for this angle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtResult.Text = "0";
                                return;
                            }

                            double tanResult = Math.Tan(tanRad);
                            // Clean up near-zero results
                            if (Math.Abs(tanResult) < 1E-15) tanResult = 0;
                            txtResult.Text = tanResult.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error calculating tangent.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                        }
                        break;
                    case "Log":
                        if (enterSecondValue <= 0)
                        {
                            MessageBox.Show("Logarithm is undefined for non-positive numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                            return;
                        }
                        txtResult.Text = Math.Log10(enterSecondValue).ToString();
                        break;
                    case "Ln":
                        if (enterSecondValue <= 0)
                        {
                            MessageBox.Show("Natural logarithm is undefined for non-positive numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                            return;
                        }
                        txtResult.Text = Math.Log(enterSecondValue).ToString();
                        break;
                    case "Sinh":
                        try
                        {
                            double value = enterSecondValue;
                            double result = Math.Sinh(value);
                            if (Math.Abs(result) < 1E-15) result = 0; // Clean up near-zero results
                            txtResult.Text = result.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error calculating hyperbolic sine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                        }
                        break;
                    case "Cosh":
                        try
                        {
                            double value = enterSecondValue;
                            double result = Math.Cosh(value);
                            if (Math.Abs(result) < 1E-15) result = 0; // Clean up near-zero results
                            txtResult.Text = result.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error calculating hyperbolic cosine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                        }
                        break;
                    case "Tanh":
                        try
                        {
                            double value = enterSecondValue;
                            double result = Math.Tanh(value);
                            if (Math.Abs(result) < 1E-15) result = 0; // Clean up near-zero results
                            txtResult.Text = result.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error calculating hyperbolic tangent.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtResult.Text = "0";
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Length > 0)
            {
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1, 1);
            }
            if (txtResult.Text == "")
            {
                txtResult.Text = "0";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            enterFirstValue = 0;
            enterSecondValue = 0;
            op = "";
        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            try
            {
                double q = Convert.ToDouble(txtResult.Text);
                txtResult.Text = Convert.ToString(-1 * q);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 250;
            txtResult.Width = 215;
        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 501;
            txtResult.Width = 467;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitCal;
            exitCal = MessageBox.Show("Do you want to exit ?", "Scientific Calculator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitCal == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            txtResult.Text = Math.PI.ToString();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                enterFirstValue = Convert.ToDouble(txtResult.Text);
                op = "Log";
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnSq_Click(object sender, EventArgs e)
        {
            try
            {
                double sq = Convert.ToDouble(txtResult.Text);
                if (sq < 0)
                {
                    MessageBox.Show("Square root is undefined for negative numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResult.Text = "0";
                    return;
                }
                sq = Math.Sqrt(sq);
                txtResult.Text = Convert.ToString(sq);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnx2_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtResult.Text);
                x = x * x;
                txtResult.Text = Convert.ToString(x);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnx3_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtResult.Text);
                x = Math.Pow(x, 3);
                txtResult.Text = Convert.ToString(x);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnSinh_Click(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(txtResult.Text);
                enterFirstValue = value;
                op = "Sinh";
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnCosh_Click(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(txtResult.Text);
                enterFirstValue = value;
                op = "Cosh";
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnTanh_Click(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(txtResult.Text);
                enterFirstValue = value;
                op = "Tanh";
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(txtResult.Text);
                enterFirstValue = value;
                op = "Sin";
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(txtResult.Text);
                enterFirstValue = value;
                op = "Cos";
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(txtResult.Text);
                enterFirstValue = value;
                op = "Tan";
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnper_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtResult.Text);
                if (!string.IsNullOrEmpty(op))
                {
                    a = (enterFirstValue * a) / 100;
                    txtResult.Text = Convert.ToString(a);
                }
                else
                {
                    a = a / 100;
                    txtResult.Text = Convert.ToString(a);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            try
            {
                double dec = Convert.ToDouble(txtResult.Text);
                int d = (int)dec;
                txtResult.Text = Convert.ToString(d);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtResult.Text);
                if (a < 0)
                {
                    MessageBox.Show("Binary conversion is only supported for non-negative integers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResult.Text = "0";
                    return;
                }
                txtResult.Text = Convert.ToString(a, 2);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtResult.Text);
                if (a < 0)
                {
                    MessageBox.Show("Hexadecimal conversion is only supported for non-negative integers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResult.Text = "0";
                    return;
                }
                txtResult.Text = Convert.ToString(a, 16).ToUpper();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnOcta_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtResult.Text);
                if (a < 0)
                {
                    MessageBox.Show("Octal conversion is only supported for non-negative integers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResult.Text = "0";
                    return;
                }
                txtResult.Text = Convert.ToString(a, 8);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btn1x_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtResult.Text);
                if (a == 0)
                {
                    MessageBox.Show("Reciprocal of zero is undefined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResult.Text = "0";
                    return;
                }
                a = 1.0 / a;
                txtResult.Text = Convert.ToString(a);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnln_Click(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(txtResult.Text);
                if (value <= 0)
                {
                    MessageBox.Show("Natural logarithm is undefined for non-positive numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtResult.Text = Math.Log(value).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating natural logarithm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            try
            {
                enterFirstValue = Convert.ToDouble(txtResult.Text);
                op = "Exp";
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                enterFirstValue = Convert.ToDouble(txtResult.Text);
                op = "Mod";
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "0";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 250;
            txtResult.Width = 215;
        }
    }
}
