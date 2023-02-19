namespace Base64
{
    partial class Base64Converter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEnterVPN = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.RichTextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblEncoded = new System.Windows.Forms.Label();
            this.chckbxIOS = new System.Windows.Forms.CheckBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOverWrite = new System.Windows.Forms.Button();
            this.btnAppend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEnterVPN
            // 
            this.lblEnterVPN.AutoSize = true;
            this.lblEnterVPN.Location = new System.Drawing.Point(40, 65);
            this.lblEnterVPN.Name = "lblEnterVPN";
            this.lblEnterVPN.Size = new System.Drawing.Size(54, 15);
            this.lblEnterVPN.TabIndex = 0;
            this.lblEnterVPN.Text = "Input(s) :";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(126, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(662, 163);
            this.txtInput.TabIndex = 2;
            this.txtInput.Text = "";
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(363, 221);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(84, 32);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert ";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblEncoded
            // 
            this.lblEncoded.AutoSize = true;
            this.lblEncoded.Location = new System.Drawing.Point(8, 348);
            this.lblEncoded.Name = "lblEncoded";
            this.lblEncoded.Size = new System.Drawing.Size(112, 15);
            this.lblEncoded.TabIndex = 4;
            this.lblEncoded.Text = "Encoded to Base64 :";
            // 
            // chckbxIOS
            // 
            this.chckbxIOS.AutoSize = true;
            this.chckbxIOS.Location = new System.Drawing.Point(12, 181);
            this.chckbxIOS.Name = "chckbxIOS";
            this.chckbxIOS.Size = new System.Drawing.Size(268, 19);
            this.chckbxIOS.TabIndex = 5;
            this.chckbxIOS.Text = "IOS Compatible (Encode each Line seperately)";
            this.chckbxIOS.UseVisualStyleBackColor = true;
            this.chckbxIOS.CheckedChanged += new System.EventHandler(this.chckbxIOS_CheckedChanged);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(126, 265);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(662, 157);
            this.txtResult.TabIndex = 6;
            this.txtResult.Text = "";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSuccess.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblSuccess.Location = new System.Drawing.Point(12, 228);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(82, 25);
            this.lblSuccess.TabIndex = 7;
            this.lblSuccess.Text = "Success!";
            this.lblSuccess.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(700, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "By Lunarxs";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(372, 181);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(463, 181);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(313, 23);
            this.txtPath.TabIndex = 10;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnOverWrite
            // 
            this.btnOverWrite.Location = new System.Drawing.Point(463, 221);
            this.btnOverWrite.Name = "btnOverWrite";
            this.btnOverWrite.Size = new System.Drawing.Size(147, 32);
            this.btnOverWrite.TabIndex = 11;
            this.btnOverWrite.Text = "Convert and Overwrite";
            this.btnOverWrite.UseVisualStyleBackColor = true;
            this.btnOverWrite.Click += new System.EventHandler(this.btnOverWrite_Click);
            // 
            // btnAppend
            // 
            this.btnAppend.Location = new System.Drawing.Point(629, 221);
            this.btnAppend.Name = "btnAppend";
            this.btnAppend.Size = new System.Drawing.Size(147, 32);
            this.btnAppend.TabIndex = 12;
            this.btnAppend.Text = "Convert and Append";
            this.btnAppend.UseVisualStyleBackColor = true;
            this.btnAppend.Click += new System.EventHandler(this.btnAppend_Click);
            // 
            // Base64Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAppend);
            this.Controls.Add(this.btnOverWrite);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.chckbxIOS);
            this.Controls.Add(this.lblEncoded);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblEnterVPN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Base64Converter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base64Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblEnterVPN;
        private RichTextBox txtInput;
        private Button btnConvert;
        private Label lblEncoded;
        private CheckBox chckbxIOS;
        private RichTextBox txtResult;
        private Label lblSuccess;
        private Label label1;
        private Button btnBrowse;
        private TextBox txtPath;
        private Button btnOverWrite;
        private Button btnAppend;
    }
}