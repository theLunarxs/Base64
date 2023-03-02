using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void chckIPService_CheckedChanged(object sender, EventArgs e) => PanelIPSource.Visible = chckIPService.Checked;
        private void rdCustomIP_CheckedChanged(object sender, EventArgs e) => PanelIPDirectory.Visible = rdCustomIP.Checked;
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

    }
}
