namespace Base64
{
    partial class NewApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnResDirectory = new System.Windows.Forms.Button();
            this.txtResPath = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdNumbers = new System.Windows.Forms.RadioButton();
            this.rdNumbersLetters = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.chckCustomName = new System.Windows.Forms.CheckBox();
            this.chckIOS = new System.Windows.Forms.CheckBox();
            this.chckUnique = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chckIPService = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdInputRaw = new System.Windows.Forms.RadioButton();
            this.rdInputFile = new System.Windows.Forms.RadioButton();
            this.txtIPInput = new System.Windows.Forms.RichTextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.rdStoredIP = new System.Windows.Forms.RadioButton();
            this.rdCustomIP = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdStoreSeperate = new System.Windows.Forms.RadioButton();
            this.rdStoreSingleFile = new System.Windows.Forms.RadioButton();
            this.btnLegacy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDisclosure = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(115, 60);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(168, 23);
            this.txtIPAddress.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(115, 103);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(168, 23);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(115, 142);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(168, 23);
            this.txtPassword.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 520);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 45);
            this.button1.TabIndex = 6;
            this.button1.Text = "Connect and Fetch DB";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnResDirectory
            // 
            this.btnResDirectory.Location = new System.Drawing.Point(307, 59);
            this.btnResDirectory.Name = "btnResDirectory";
            this.btnResDirectory.Size = new System.Drawing.Size(122, 23);
            this.btnResDirectory.TabIndex = 7;
            this.btnResDirectory.Text = "Result Directory";
            this.btnResDirectory.UseVisualStyleBackColor = true;
            // 
            // txtResPath
            // 
            this.txtResPath.Location = new System.Drawing.Point(435, 59);
            this.txtResPath.Name = "txtResPath";
            this.txtResPath.Size = new System.Drawing.Size(339, 23);
            this.txtResPath.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCustomName);
            this.panel1.Controls.Add(this.chckCustomName);
            this.panel1.Controls.Add(this.chckIOS);
            this.panel1.Controls.Add(this.chckUnique);
            this.panel1.Location = new System.Drawing.Point(14, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 283);
            this.panel1.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdNumbers);
            this.panel4.Controls.Add(this.rdNumbersLetters);
            this.panel4.Location = new System.Drawing.Point(146, 132);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(179, 67);
            this.panel4.TabIndex = 18;
            // 
            // rdNumbers
            // 
            this.rdNumbers.AutoSize = true;
            this.rdNumbers.Location = new System.Drawing.Point(14, 13);
            this.rdNumbers.Name = "rdNumbers";
            this.rdNumbers.Size = new System.Drawing.Size(96, 19);
            this.rdNumbers.TabIndex = 16;
            this.rdNumbers.TabStop = true;
            this.rdNumbers.Text = "Use Numbers";
            this.rdNumbers.UseVisualStyleBackColor = true;
            this.rdNumbers.Visible = false;
            // 
            // rdNumbersLetters
            // 
            this.rdNumbersLetters.AutoSize = true;
            this.rdNumbersLetters.Location = new System.Drawing.Point(14, 38);
            this.rdNumbersLetters.Name = "rdNumbersLetters";
            this.rdNumbersLetters.Size = new System.Drawing.Size(157, 19);
            this.rdNumbersLetters.TabIndex = 17;
            this.rdNumbersLetters.TabStop = true;
            this.rdNumbersLetters.Text = "Use Numbers and Letters";
            this.rdNumbersLetters.UseVisualStyleBackColor = true;
            this.rdNumbersLetters.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(186, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Otherwise it will be result.txt";
            // 
            // txtCustomName
            // 
            this.txtCustomName.Location = new System.Drawing.Point(34, 80);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.Size = new System.Drawing.Size(265, 23);
            this.txtCustomName.TabIndex = 1;
            this.txtCustomName.Visible = false;
            // 
            // chckCustomName
            // 
            this.chckCustomName.AutoSize = true;
            this.chckCustomName.Location = new System.Drawing.Point(13, 55);
            this.chckCustomName.Name = "chckCustomName";
            this.chckCustomName.Size = new System.Drawing.Size(171, 19);
            this.chckCustomName.TabIndex = 0;
            this.chckCustomName.Text = "Customize Result File name";
            this.chckCustomName.UseVisualStyleBackColor = true;
            // 
            // chckIOS
            // 
            this.chckIOS.AutoSize = true;
            this.chckIOS.Location = new System.Drawing.Point(13, 16);
            this.chckIOS.Name = "chckIOS";
            this.chckIOS.Size = new System.Drawing.Size(247, 19);
            this.chckIOS.TabIndex = 11;
            this.chckIOS.Text = "IOS Compatible ( Encode Each Seperately)";
            this.chckIOS.UseVisualStyleBackColor = true;
            // 
            // chckUnique
            // 
            this.chckUnique.AutoSize = true;
            this.chckUnique.Location = new System.Drawing.Point(13, 145);
            this.chckUnique.Name = "chckUnique";
            this.chckUnique.Size = new System.Drawing.Size(127, 19);
            this.chckUnique.TabIndex = 12;
            this.chckUnique.Text = "Individualize Name";
            this.chckUnique.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chckIPService);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(382, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(406, 283);
            this.panel2.TabIndex = 10;
            // 
            // chckIPService
            // 
            this.chckIPService.AutoSize = true;
            this.chckIPService.Location = new System.Drawing.Point(18, 16);
            this.chckIPService.Name = "chckIPService";
            this.chckIPService.Size = new System.Drawing.Size(98, 19);
            this.chckIPService.TabIndex = 1;
            this.chckIPService.Text = "Use IP Service";
            this.chckIPService.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(3, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 239);
            this.panel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rdInputRaw);
            this.panel6.Controls.Add(this.rdInputFile);
            this.panel6.Controls.Add(this.txtIPInput);
            this.panel6.Controls.Add(this.txtFilePath);
            this.panel6.Controls.Add(this.btnInputFile);
            this.panel6.Location = new System.Drawing.Point(6, 58);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(383, 117);
            this.panel6.TabIndex = 25;
            this.panel6.Visible = false;
            // 
            // rdInputRaw
            // 
            this.rdInputRaw.AllowDrop = true;
            this.rdInputRaw.AutoSize = true;
            this.rdInputRaw.Location = new System.Drawing.Point(6, 50);
            this.rdInputRaw.Name = "rdInputRaw";
            this.rdInputRaw.Size = new System.Drawing.Size(78, 19);
            this.rdInputRaw.TabIndex = 25;
            this.rdInputRaw.TabStop = true;
            this.rdInputRaw.Text = "Input Raw";
            this.rdInputRaw.UseVisualStyleBackColor = true;
            // 
            // rdInputFile
            // 
            this.rdInputFile.AutoSize = true;
            this.rdInputFile.Location = new System.Drawing.Point(6, 2);
            this.rdInputFile.Name = "rdInputFile";
            this.rdInputFile.Size = new System.Drawing.Size(74, 19);
            this.rdInputFile.TabIndex = 24;
            this.rdInputFile.TabStop = true;
            this.rdInputFile.Text = "Input File";
            this.rdInputFile.UseVisualStyleBackColor = true;
            // 
            // txtIPInput
            // 
            this.txtIPInput.Location = new System.Drawing.Point(3, 70);
            this.txtIPInput.Name = "txtIPInput";
            this.txtIPInput.Size = new System.Drawing.Size(368, 41);
            this.txtIPInput.TabIndex = 21;
            this.txtIPInput.Text = "";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(87, 23);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(284, 23);
            this.txtFilePath.TabIndex = 23;
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(6, 23);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(75, 23);
            this.btnInputFile.TabIndex = 22;
            this.btnInputFile.Text = "Browse";
            this.btnInputFile.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.rdStoredIP);
            this.panel5.Controls.Add(this.rdCustomIP);
            this.panel5.Location = new System.Drawing.Point(9, 14);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(380, 35);
            this.panel5.TabIndex = 24;
            this.panel5.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 15);
            this.label9.TabIndex = 26;
            this.label9.Text = "Where to get the IPs?";
            // 
            // rdStoredIP
            // 
            this.rdStoredIP.AutoSize = true;
            this.rdStoredIP.Location = new System.Drawing.Point(267, 9);
            this.rdStoredIP.Name = "rdStoredIP";
            this.rdStoredIP.Size = new System.Drawing.Size(77, 19);
            this.rdStoredIP.TabIndex = 20;
            this.rdStoredIP.TabStop = true;
            this.rdStoredIP.Text = "Stored IPs";
            this.rdStoredIP.UseVisualStyleBackColor = true;
            // 
            // rdCustomIP
            // 
            this.rdCustomIP.AutoSize = true;
            this.rdCustomIP.Location = new System.Drawing.Point(135, 9);
            this.rdCustomIP.Name = "rdCustomIP";
            this.rdCustomIP.Size = new System.Drawing.Size(85, 19);
            this.rdCustomIP.TabIndex = 19;
            this.rdCustomIP.TabStop = true;
            this.rdCustomIP.Text = "Custom IPs";
            this.rdCustomIP.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rdStoreSeperate);
            this.flowLayoutPanel1.Controls.Add(this.rdStoreSingleFile);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 181);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(386, 55);
            this.flowLayoutPanel1.TabIndex = 18;
            this.flowLayoutPanel1.Visible = false;
            // 
            // rdStoreSeperate
            // 
            this.rdStoreSeperate.AutoSize = true;
            this.rdStoreSeperate.Location = new System.Drawing.Point(3, 3);
            this.rdStoreSeperate.Name = "rdStoreSeperate";
            this.rdStoreSeperate.Size = new System.Drawing.Size(301, 19);
            this.rdStoreSeperate.TabIndex = 0;
            this.rdStoreSeperate.TabStop = true;
            this.rdStoreSeperate.Text = "Store Each Inbound\'s Permutations In a Seperate File";
            this.rdStoreSeperate.UseVisualStyleBackColor = true;
            // 
            // rdStoreSingleFile
            // 
            this.rdStoreSingleFile.AutoSize = true;
            this.rdStoreSingleFile.Location = new System.Drawing.Point(3, 28);
            this.rdStoreSingleFile.Name = "rdStoreSingleFile";
            this.rdStoreSingleFile.Size = new System.Drawing.Size(182, 19);
            this.rdStoreSingleFile.TabIndex = 1;
            this.rdStoreSingleFile.TabStop = true;
            this.rdStoreSingleFile.Text = "Store Them All In A Single File";
            this.rdStoreSingleFile.UseVisualStyleBackColor = true;
            // 
            // btnLegacy
            // 
            this.btnLegacy.Location = new System.Drawing.Point(691, 11);
            this.btnLegacy.Name = "btnLegacy";
            this.btnLegacy.Size = new System.Drawing.Size(97, 23);
            this.btnLegacy.TabIndex = 13;
            this.btnLegacy.Text = "Use Legacy";
            this.btnLegacy.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(382, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "IP Management Section";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(14, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Encode Section";
            // 
            // lblDisclosure
            // 
            this.lblDisclosure.AutoSize = true;
            this.lblDisclosure.Location = new System.Drawing.Point(290, 106);
            this.lblDisclosure.Name = "lblDisclosure";
            this.lblDisclosure.Size = new System.Drawing.Size(61, 15);
            this.lblDisclosure.TabIndex = 17;
            this.lblDisclosure.Text = "Disclusure";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(438, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(247, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Use This Button if you want the old version";
            // 
            // NewApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDisclosure);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLegacy);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtResPath);
            this.Controls.Add(this.btnResDirectory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewApp";
            this.Text = "NewApp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtIPAddress;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button button1;
        private Button btnResDirectory;
        private TextBox txtResPath;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel1;
        private Panel panel2;
        private CheckBox chckIOS;
        private CheckBox chckUnique;
        private Button btnLegacy;
        private Label label4;
        private Label label5;
        private RadioButton rdNumbersLetters;
        private RadioButton rdNumbers;
        private Label label6;
        private TextBox txtCustomName;
        private CheckBox chckCustomName;
        private Panel panel4;
        private CheckBox chckIPService;
        private Panel panel3;
        private Panel panel6;
        private RadioButton rdInputRaw;
        private RadioButton rdInputFile;
        private RichTextBox txtIPInput;
        private TextBox txtFilePath;
        private Button btnInputFile;
        private Panel panel5;
        private Label label9;
        private RadioButton rdStoredIP;
        private RadioButton rdCustomIP;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton rdStoreSeperate;
        private RadioButton rdStoreSingleFile;
        private Label lblDisclosure;
        private Label label8;
    }
}