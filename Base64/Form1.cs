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
                lblSuccess.Text = "Please Enter Something Up there!";
                lblSuccess.ForeColor = Color.DarkRed;
                lblSuccess.Visible = true;
                Tools.MakeLabelGo(3000, lblSuccess);
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
    }
}