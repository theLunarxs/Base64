using System.Windows.Forms;

namespace Base64
{
    public partial class Base64Converter : Form
    {
        public Base64Converter()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                txtResult.Text = string.Empty;
                lblSuccess.Text = "Success!";
                lblSuccess.ForeColor = Color.SeaGreen;
                lblSuccess.Visible = true;
                Tools.MakeLabelGo(5000, lblSuccess);


                txtResult.Text = Tools.ConvertToBase64(txtInput.Text, chckbxIOS.Checked);
            }

            else
            {
                lblSuccess.Text = "Please Enter Something as Input!";
                lblSuccess.ForeColor = Color.DarkRed;
                lblSuccess.Visible = true;
                Tools.MakeLabelGo(5000, lblSuccess);
            }

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        private void chckbxIOS_CheckedChanged(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Open a file selection dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog.FileName;
            }
            else
            {
                lblSuccess.Text = "Error in File";
                lblSuccess.ForeColor = Color.DarkRed;
                lblSuccess.Visible = true;
                Tools.MakeLabelGo(5000, lblSuccess);
            }
        }

        private void btnOverWrite_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                lblSuccess.Text = "Please Enter Something as Input!";
                lblSuccess.ForeColor = Color.DarkRed;
                lblSuccess.Visible = true;
                Tools.MakeLabelGo(3000, lblSuccess);
            }
            else
            {
                if (txtPath.Text.Length == 0)
                {
                    lblSuccess.Text = "Path is Empty";
                    lblSuccess.ForeColor = Color.DarkRed;
                    lblSuccess.Visible = true;
                    Tools.MakeLabelGo(3000, lblSuccess);
                }
                else
                {
                    txtResult.Text = string.Empty;
                    lblSuccess.Text = "Success!";
                    lblSuccess.ForeColor = Color.SeaGreen;
                    lblSuccess.Visible = true;
                    Tools.MakeLabelGo(5000, lblSuccess);
                    var result = Tools.ConvertToBase64(txtInput.Text, chckbxIOS.Checked);
                    txtResult.Text = result;

                    _ = Tools.WriteToFileAsync(txtPath.Text, result, false);
                }
            }

        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                lblSuccess.Text = "Please Enter Something as Input!";
                lblSuccess.ForeColor = Color.DarkRed;
                lblSuccess.Visible = true;
                Tools.MakeLabelGo(3000, lblSuccess);
            }
            else
            {
                if (txtPath.Text.Length == 0)
                {
                    lblSuccess.Text = "Path is Empty";
                    lblSuccess.ForeColor = Color.DarkRed;
                    lblSuccess.Visible = true;
                    Tools.MakeLabelGo(3000, lblSuccess);
                }
                else
                {
                    txtResult.Text = string.Empty;
                    lblSuccess.Text = "Success!";
                    lblSuccess.ForeColor = Color.SeaGreen;
                    lblSuccess.Visible = true;
                    Tools.MakeLabelGo(5000, lblSuccess);
                    var result = Tools.ConvertToBase64(txtInput.Text, chckbxIOS.Checked);
                    txtResult.Text = result;

                    _ = Tools.WriteToFileAsync(txtPath.Text, result, true);
                }
            }

        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }
    }
}