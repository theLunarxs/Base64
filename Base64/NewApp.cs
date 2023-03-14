using Base64.Utility;
using Base64.Utility.Models;
using System.Diagnostics;

namespace Base64
{
    public partial class NewApp : Form
    {
        public NewApp()
        {
            InitializeComponent();
            this.lblDisclosure.Text = $"Please note that we won't be storing your server's Info (IP Address, Username, Password)" +
                $"{Environment.NewLine}" + "as you can read in our code stored on github";

        }

        private void btnResDirectory_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog FD = new())
            {
                if (FD.ShowDialog() == DialogResult.OK)
                {
                    txtResPath.Text = FD.FileName;
                }
                else
                {
                    MessageBox.Show("Error in File");
                }
            }
        }

        //Displaying different parts based on radioButtons/Checkboxes being checked
        private void chckCustomName_CheckedChanged(object sender, EventArgs e) => txtCustomName.Visible = chckCustomName.Checked;
        private void chckUnique_CheckedChanged(object sender, EventArgs e) => panelIndividualize.Visible = chckUnique.Checked;
        private void chckIPService_CheckedChanged(object sender, EventArgs e)
        {
            PanelIPSource.Visible = chckIPService.Checked;
            rdInputFile.Checked = false;
            rdInputRaw.Checked = false;
            txtFilePath.Text = string.Empty;
            txtFilePath.Text = string.Empty;
            PanelStoreOptions.Visible = false;
        }
        private void rdCustomIP_CheckedChanged(object sender, EventArgs e)
        {
            PanelIPDirectory.Visible = rdCustomIP.Checked;
            rdInputFile.Checked = false;
            rdInputRaw.Checked = false;
            txtFilePath.Text = string.Empty;
            txtFilePath.Text = string.Empty;
            PanelStoreOptions.Visible = false;

        }
        private void txtFilePath_TextChanged(object sender, EventArgs e) => PanelStoreOptions.Visible = !string.IsNullOrEmpty(txtFilePath.Text);
        private void txtIPInput_TextChanged(object sender, EventArgs e) => PanelStoreOptions.Visible = !string.IsNullOrEmpty(txtIPInput.Text);
        private void chckCustomPathtoDb_CheckedChanged(object sender, EventArgs e) => txtCustomPathtoDb.Visible = chckCustomPathtoDb.Checked;
        private void rdInputFile_CheckedChanged(object sender, EventArgs e)
        {
            txtIPInput.Text = string.Empty;
            panelInputPath.Visible = rdInputFile.Checked;
        }
        private void rdInputRaw_CheckedChanged(object sender, EventArgs e)
        {
            txtFilePath.Text = string.Empty;
            txtIPInput.Visible = rdInputRaw.Checked;
        }

        private void btnInputFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog FD = new())
            {
                if (FD.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = FD.FileName;
                }
                else
                {
                    MessageBox.Show("Error in File");
                }
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            Tools.Server Clientserver = new Tools.Server()
            {
                IP = txtIPAddress.Text.Trim(),
                Port = txtPort.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };
            MessageBox.Show(await Tools.FetchDBFromServer(Clientserver));
        }

        private void btnLegacy_Click(object sender, EventArgs e)
        {
            var legacyForm = new LegacyForm();

            legacyForm.Show();
        }
    }
}
