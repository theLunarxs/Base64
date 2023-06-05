using Base64.Utility.Classes;
using Base64.Utility.LegacyFuncs;
using System.Diagnostics;

namespace Base64
{
    public partial class LegacyForm : Form
    {
        bool useNumberAndLetter;
        string resultFile = string.Empty;
        public LegacyForm()
        {
            InitializeComponent();
            btnBrowse.Enabled = false;

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                txtResult.Text = string.Empty;
                lblSuccess.Text = "Success!";
                lblSuccess.ForeColor = Color.SeaGreen;
                lblSuccess.Visible = true;
                Visual.MakeLabelGo(5000, lblSuccess);


                txtResult.Text = LegacyFuncs.ConvertToBase64(txtInput.Text, chckbxIOS.Checked);
            }

            else
            {
                lblSuccess.Text = "Please Enter Something as Input!";
                lblSuccess.ForeColor = Color.DarkRed;
                lblSuccess.Visible = true;
                Visual.MakeLabelGo(5000, lblSuccess);
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Open a file selection dialog

            if (rdCreateFile.Checked)
            {
                FolderBrowserDialog dialog = new();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = dialog.SelectedPath;
                }
                else
                {
                    lblSuccess.Text = "Error in Path!";
                    lblSuccess.ForeColor = Color.DarkRed;
                    lblSuccess.Visible = true;
                    Visual.MakeLabelGo(5000, lblSuccess);
                }
            }
            if (rdSelectFile.Checked)
            {
                OpenFileDialog openFileDialog = new();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = openFileDialog.FileName;
                }
                else
                {
                    lblSuccess.Text = "Error in File!";
                    lblSuccess.ForeColor = Color.DarkRed;
                    lblSuccess.Visible = true;
                    Visual.MakeLabelGo(5000, lblSuccess);
                }
            }


        }

        private async void btnOverWrite_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                lblSuccess.Text = "Please Enter Something as Input!";
                lblSuccess.ForeColor = Color.DarkRed;
                lblSuccess.Visible = true;
                Visual.MakeLabelGo(3000, lblSuccess);
            }
            else
            {
                if (txtPath.Text.Length == 0)
                {
                    lblSuccess.Text = "Path is Empty";
                    lblSuccess.ForeColor = Color.DarkRed;
                    lblSuccess.Visible = true;
                    Visual.MakeLabelGo(3000, lblSuccess);
                }
                else
                {
                    txtResult.Text = string.Empty;
                    lblSuccess.Text = "Success!";
                    lblSuccess.ForeColor = Color.SeaGreen;
                    lblSuccess.Visible = true;
                    Visual.MakeLabelGo(5000, lblSuccess);
                    var result = LegacyFuncs.ConvertToBase64(txtInput.Text, chckbxIOS.Checked);
                    txtResult.Text = result;

                    resultFile = await LegacyFuncs.WriteToFileAsync(txtPath.Text, result, false, chckUnique.Checked, useNumberAndLetter);
                    btnShowInFolder.Visible = true;

                }
            }

        }

        private async void btnAppend_ClickAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                lblSuccess.Text = "Please Enter Something as Input!";
                lblSuccess.ForeColor = Color.DarkRed;
                lblSuccess.Visible = true;
                Visual.MakeLabelGo(3000, lblSuccess);
            }
            else
            {
                if (txtPath.Text.Length == 0)
                {
                    lblSuccess.Text = "Path is Empty!";
                    lblSuccess.ForeColor = Color.DarkRed;
                    lblSuccess.Visible = true;
                    Visual.MakeLabelGo(3000, lblSuccess);
                }
                else
                {
                    txtResult.Text = string.Empty;
                    lblSuccess.Text = "Success!";
                    lblSuccess.ForeColor = Color.SeaGreen;
                    lblSuccess.Visible = true;
                    Visual.MakeLabelGo(5000, lblSuccess);
                    var result = LegacyFuncs.ConvertToBase64(txtInput.Text, chckbxIOS.Checked);
                    txtResult.Text = result;

                    resultFile = await LegacyFuncs.WriteToFileAsync(txtPath.Text, result, true, chckUnique.Checked, useNumberAndLetter);
                    btnShowInFolder.Visible = true;
                }
            }

        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        private void chckbxIOS_CheckedChanged(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = comboBox1.SelectedIndex == 0 ? false : true;
            useNumberAndLetter = x;
        }

        private void chckUnique_CheckedChanged(object sender, EventArgs e)
        {
            if (chckUnique.Checked)
            {
                if (!string.IsNullOrEmpty(txtPath.Text))
                {
                    comboBox1.Visible = true;
                }
                else
                {
                    lblSuccess.Text = "Path is Empty!";
                    lblSuccess.ForeColor = Color.DarkRed;
                    lblSuccess.Visible = true;
                    Visual.MakeLabelGo(3000, lblSuccess);
                    chckUnique.Checked = false;
                }
            }
            else
            {
                comboBox1.Visible = false;
            }
        }

        private void rdSelectFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSelectFile.Checked)
            {
                panelButtons.Visible = rdSelectFile.Checked;
                btnBrowse.Enabled = rdSelectFile.Checked || rdCreateFile.Checked;
                txtPath.Text = string.Empty;
                txtBaseName.Text = string.Empty;
            }
        }

        private void rdCreateFile_CheckedChanged(object sender, EventArgs e)
        {
            panelNewFile.Visible = rdCreateFile.Checked;
            btnBrowse.Enabled = rdSelectFile.Checked || rdCreateFile.Checked;
            txtPath.Text = string.Empty;
        }

        private async void btnCreateFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                lblSuccess.Text = "Please Enter Something as Input!";
                lblSuccess.ForeColor = Color.DarkRed;
                lblSuccess.Visible = true;
                Visual.MakeLabelGo(3000, lblSuccess);
            }
            else
            {
                if (txtPath.Text.Length == 0)
                {
                    lblSuccess.Text = "Path is Empty";
                    lblSuccess.ForeColor = Color.DarkRed;
                    lblSuccess.Visible = true;
                    Visual.MakeLabelGo(3000, lblSuccess);
                }
                else
                {
                    txtResult.Text = string.Empty;
                    lblSuccess.Text = "Success!";
                    lblSuccess.ForeColor = Color.SeaGreen;
                    lblSuccess.Visible = true;
                    Visual.MakeLabelGo(5000, lblSuccess);
                    var result = LegacyFuncs.ConvertToBase64(txtInput.Text, chckbxIOS.Checked);
                    txtResult.Text = result;

                    resultFile = await LegacyFuncs.WriteToFileAsync(txtPath.Text, result, txtBaseName.Text, chckUnique.Checked, useNumberAndLetter);
                    btnShowInFolder.Visible = true;
                }
            }
        }

        private void btnShowInFolder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resultFile))
                Process.Start("explorer.exe", $"/select,\"{resultFile}\"");
        }
    }
}