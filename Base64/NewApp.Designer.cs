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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnResDirectory = new System.Windows.Forms.Button();
            this.txtResPath = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelIndividualize = new System.Windows.Forms.Panel();
            this.rdNumbers = new System.Windows.Forms.RadioButton();
            this.rdNumbersLetters = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.chckCustomName = new System.Windows.Forms.CheckBox();
            this.chckIOS = new System.Windows.Forms.CheckBox();
            this.chckUnique = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chckIPService = new System.Windows.Forms.CheckBox();
            this.PanelParentIP = new System.Windows.Forms.Panel();
            this.PanelIPDirectory = new System.Windows.Forms.Panel();
            this.panelInputPath = new System.Windows.Forms.Panel();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.rdInputRaw = new System.Windows.Forms.RadioButton();
            this.rdInputFile = new System.Windows.Forms.RadioButton();
            this.txtIPInput = new System.Windows.Forms.RichTextBox();
            this.PanelIPSource = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.rdStoredIP = new System.Windows.Forms.RadioButton();
            this.rdCustomIP = new System.Windows.Forms.RadioButton();
            this.PanelStoreOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.rdStoreSeperate = new System.Windows.Forms.RadioButton();
            this.rdStoreSingleFile = new System.Windows.Forms.RadioButton();
            this.btnLegacy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDisclosure = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chckCustomPathtoDb = new System.Windows.Forms.CheckBox();
            this.txtCustomPathtoDb = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelIndividualize.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PanelParentIP.SuspendLayout();
            this.PanelIPDirectory.SuspendLayout();
            this.panelInputPath.SuspendLayout();
            this.PanelIPSource.SuspendLayout();
            this.PanelStoreOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
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
            this.txtIPAddress.Location = new System.Drawing.Point(115, 48);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(168, 23);
            this.txtIPAddress.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(115, 113);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(168, 23);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(115, 142);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(168, 23);
            this.txtPassword.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(307, 496);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(143, 45);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect and Fetch DB";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnResDirectory
            // 
            this.btnResDirectory.Location = new System.Drawing.Point(307, 59);
            this.btnResDirectory.Name = "btnResDirectory";
            this.btnResDirectory.Size = new System.Drawing.Size(122, 23);
            this.btnResDirectory.TabIndex = 7;
            this.btnResDirectory.Text = "Result Directory";
            this.btnResDirectory.UseVisualStyleBackColor = true;
            this.btnResDirectory.Click += new System.EventHandler(this.btnResDirectory_Click);
            // 
            // txtResPath
            // 
            this.txtResPath.Location = new System.Drawing.Point(435, 59);
            this.txtResPath.Name = "txtResPath";
            this.txtResPath.ReadOnly = true;
            this.txtResPath.Size = new System.Drawing.Size(353, 23);
            this.txtResPath.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelIndividualize);
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
            // panelIndividualize
            // 
            this.panelIndividualize.Controls.Add(this.rdNumbers);
            this.panelIndividualize.Controls.Add(this.rdNumbersLetters);
            this.panelIndividualize.Location = new System.Drawing.Point(146, 122);
            this.panelIndividualize.Name = "panelIndividualize";
            this.panelIndividualize.Size = new System.Drawing.Size(179, 67);
            this.panelIndividualize.TabIndex = 18;
            this.panelIndividualize.Visible = false;
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
            this.chckCustomName.CheckedChanged += new System.EventHandler(this.chckCustomName_CheckedChanged);
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
            this.chckUnique.CheckedChanged += new System.EventHandler(this.chckUnique_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chckIPService);
            this.panel2.Controls.Add(this.PanelParentIP);
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
            this.chckIPService.CheckedChanged += new System.EventHandler(this.chckIPService_CheckedChanged);
            // 
            // PanelParentIP
            // 
            this.PanelParentIP.Controls.Add(this.PanelIPDirectory);
            this.PanelParentIP.Controls.Add(this.PanelIPSource);
            this.PanelParentIP.Controls.Add(this.PanelStoreOptions);
            this.PanelParentIP.Location = new System.Drawing.Point(3, 41);
            this.PanelParentIP.Name = "PanelParentIP";
            this.PanelParentIP.Size = new System.Drawing.Size(400, 239);
            this.PanelParentIP.TabIndex = 0;
            // 
            // PanelIPDirectory
            // 
            this.PanelIPDirectory.Controls.Add(this.panelInputPath);
            this.PanelIPDirectory.Controls.Add(this.rdInputRaw);
            this.PanelIPDirectory.Controls.Add(this.rdInputFile);
            this.PanelIPDirectory.Controls.Add(this.txtIPInput);
            this.PanelIPDirectory.Location = new System.Drawing.Point(6, 58);
            this.PanelIPDirectory.Name = "PanelIPDirectory";
            this.PanelIPDirectory.Size = new System.Drawing.Size(383, 127);
            this.PanelIPDirectory.TabIndex = 25;
            this.PanelIPDirectory.Visible = false;
            // 
            // panelInputPath
            // 
            this.panelInputPath.Controls.Add(this.txtFilePath);
            this.panelInputPath.Controls.Add(this.btnInputFile);
            this.panelInputPath.Location = new System.Drawing.Point(6, 23);
            this.panelInputPath.Name = "panelInputPath";
            this.panelInputPath.Size = new System.Drawing.Size(371, 32);
            this.panelInputPath.TabIndex = 19;
            this.panelInputPath.Visible = false;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(87, 3);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(284, 23);
            this.txtFilePath.TabIndex = 23;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(6, 3);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(75, 23);
            this.btnInputFile.TabIndex = 22;
            this.btnInputFile.Text = "Browse";
            this.btnInputFile.UseVisualStyleBackColor = true;
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // rdInputRaw
            // 
            this.rdInputRaw.AllowDrop = true;
            this.rdInputRaw.AutoSize = true;
            this.rdInputRaw.Location = new System.Drawing.Point(6, 61);
            this.rdInputRaw.Name = "rdInputRaw";
            this.rdInputRaw.Size = new System.Drawing.Size(78, 19);
            this.rdInputRaw.TabIndex = 25;
            this.rdInputRaw.TabStop = true;
            this.rdInputRaw.Text = "Input Raw";
            this.rdInputRaw.UseVisualStyleBackColor = true;
            this.rdInputRaw.CheckedChanged += new System.EventHandler(this.rdInputRaw_CheckedChanged);
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
            this.rdInputFile.CheckedChanged += new System.EventHandler(this.rdInputFile_CheckedChanged);
            // 
            // txtIPInput
            // 
            this.txtIPInput.Location = new System.Drawing.Point(3, 81);
            this.txtIPInput.Name = "txtIPInput";
            this.txtIPInput.Size = new System.Drawing.Size(368, 41);
            this.txtIPInput.TabIndex = 21;
            this.txtIPInput.Text = "";
            this.txtIPInput.Visible = false;
            this.txtIPInput.TextChanged += new System.EventHandler(this.txtIPInput_TextChanged);
            // 
            // PanelIPSource
            // 
            this.PanelIPSource.Controls.Add(this.label9);
            this.PanelIPSource.Controls.Add(this.rdStoredIP);
            this.PanelIPSource.Controls.Add(this.rdCustomIP);
            this.PanelIPSource.Location = new System.Drawing.Point(9, 14);
            this.PanelIPSource.Name = "PanelIPSource";
            this.PanelIPSource.Size = new System.Drawing.Size(380, 35);
            this.PanelIPSource.TabIndex = 24;
            this.PanelIPSource.Visible = false;
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
            this.rdCustomIP.CheckedChanged += new System.EventHandler(this.rdCustomIP_CheckedChanged);
            // 
            // PanelStoreOptions
            // 
            this.PanelStoreOptions.Controls.Add(this.rdStoreSeperate);
            this.PanelStoreOptions.Controls.Add(this.rdStoreSingleFile);
            this.PanelStoreOptions.Location = new System.Drawing.Point(3, 191);
            this.PanelStoreOptions.Name = "PanelStoreOptions";
            this.PanelStoreOptions.Size = new System.Drawing.Size(386, 45);
            this.PanelStoreOptions.TabIndex = 18;
            this.PanelStoreOptions.Visible = false;
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
            this.lblDisclosure.Location = new System.Drawing.Point(290, 142);
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
            // chckCustomPathtoDb
            // 
            this.chckCustomPathtoDb.AutoSize = true;
            this.chckCustomPathtoDb.Location = new System.Drawing.Point(307, 102);
            this.chckCustomPathtoDb.Name = "chckCustomPathtoDb";
            this.chckCustomPathtoDb.Size = new System.Drawing.Size(132, 19);
            this.chckCustomPathtoDb.TabIndex = 19;
            this.chckCustomPathtoDb.Text = "Custom Path to DB?";
            this.chckCustomPathtoDb.UseVisualStyleBackColor = true;
            this.chckCustomPathtoDb.CheckedChanged += new System.EventHandler(this.chckCustomPathtoDb_CheckedChanged);
            // 
            // txtCustomPathtoDb
            // 
            this.txtCustomPathtoDb.Location = new System.Drawing.Point(438, 100);
            this.txtCustomPathtoDb.Name = "txtCustomPathtoDb";
            this.txtCustomPathtoDb.Size = new System.Drawing.Size(350, 23);
            this.txtCustomPathtoDb.TabIndex = 20;
            this.txtCustomPathtoDb.Visible = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(115, 77);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(56, 23);
            this.txtPort.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Port";
            // 
            // NewApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCustomPathtoDb);
            this.Controls.Add(this.chckCustomPathtoDb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDisclosure);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLegacy);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtResPath);
            this.Controls.Add(this.btnResDirectory);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewApp";
            this.Text = "NewApp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelIndividualize.ResumeLayout(false);
            this.panelIndividualize.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PanelParentIP.ResumeLayout(false);
            this.PanelIPDirectory.ResumeLayout(false);
            this.PanelIPDirectory.PerformLayout();
            this.panelInputPath.ResumeLayout(false);
            this.panelInputPath.PerformLayout();
            this.PanelIPSource.ResumeLayout(false);
            this.PanelIPSource.PerformLayout();
            this.PanelStoreOptions.ResumeLayout(false);
            this.PanelStoreOptions.PerformLayout();
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
        private Button btnConnect;
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
        private Panel panelIndividualize;
        private CheckBox chckIPService;
        private Panel PanelParentIP;
        private Panel PanelIPDirectory;
        private RadioButton rdInputRaw;
        private RadioButton rdInputFile;
        private RichTextBox txtIPInput;
        private TextBox txtFilePath;
        private Button btnInputFile;
        private Panel PanelIPSource;
        private Label label9;
        private RadioButton rdStoredIP;
        private RadioButton rdCustomIP;
        private FlowLayoutPanel PanelStoreOptions;
        private RadioButton rdStoreSeperate;
        private RadioButton rdStoreSingleFile;
        private Label lblDisclosure;
        private Label label8;
        private Panel panelInputPath;
        private CheckBox chckCustomPathtoDb;
        private TextBox txtCustomPathtoDb;
        private TextBox txtPort;
        private Label label7;
    }
}