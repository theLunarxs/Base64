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
    }
}
