namespace cs432_project_step1_server
{
    partial class Form1
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
            this.consoleText = new System.Windows.Forms.RichTextBox();
            this.runServerButton = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.shutdownServerButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rsaKeyText = new System.Windows.Forms.TextBox();
            this.rsaSignKeyText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.aesIVText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.aesKeyText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.enrollSignatureText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loginSignText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.randomNumberText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.hmacValueText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // consoleText
            // 
            this.consoleText.Location = new System.Drawing.Point(1146, 62);
            this.consoleText.Margin = new System.Windows.Forms.Padding(6);
            this.consoleText.Name = "consoleText";
            this.consoleText.Size = new System.Drawing.Size(560, 855);
            this.consoleText.TabIndex = 0;
            this.consoleText.Text = "";
            this.consoleText.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // runServerButton
            // 
            this.runServerButton.Location = new System.Drawing.Point(398, 380);
            this.runServerButton.Margin = new System.Windows.Forms.Padding(6);
            this.runServerButton.Name = "runServerButton";
            this.runServerButton.Size = new System.Drawing.Size(352, 66);
            this.runServerButton.TabIndex = 1;
            this.runServerButton.Text = "Run Server";
            this.runServerButton.UseVisualStyleBackColor = true;
            this.runServerButton.Click += new System.EventHandler(this.runServerButton_Click);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(398, 308);
            this.portBox.Margin = new System.Windows.Forms.Padding(6);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(128, 38);
            this.portBox.TabIndex = 2;
            this.portBox.TextChanged += new System.EventHandler(this.portBox_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(316, 314);
            this.textBox3.Margin = new System.Windows.Forms.Padding(6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 31);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Port:";
            // 
            // shutdownServerButton
            // 
            this.shutdownServerButton.Location = new System.Drawing.Point(398, 475);
            this.shutdownServerButton.Margin = new System.Windows.Forms.Padding(6);
            this.shutdownServerButton.Name = "shutdownServerButton";
            this.shutdownServerButton.Size = new System.Drawing.Size(352, 81);
            this.shutdownServerButton.TabIndex = 5;
            this.shutdownServerButton.Text = "Shutdown Server";
            this.shutdownServerButton.UseVisualStyleBackColor = true;
            this.shutdownServerButton.Click += new System.EventHandler(this.shutdownServerButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(1544, 926);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(154, 58);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(1146, 937);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(392, 38);
            this.inputText.TabIndex = 7;
            this.inputText.TextChanged += new System.EventHandler(this.inputText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 648);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "RSA Decryption Key";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rsaKeyText
            // 
            this.rsaKeyText.Location = new System.Drawing.Point(316, 642);
            this.rsaKeyText.Name = "rsaKeyText";
            this.rsaKeyText.ReadOnly = true;
            this.rsaKeyText.Size = new System.Drawing.Size(426, 38);
            this.rsaKeyText.TabIndex = 9;
            // 
            // rsaSignKeyText
            // 
            this.rsaSignKeyText.Location = new System.Drawing.Point(316, 686);
            this.rsaSignKeyText.Name = "rsaSignKeyText";
            this.rsaSignKeyText.ReadOnly = true;
            this.rsaSignKeyText.Size = new System.Drawing.Size(426, 38);
            this.rsaSignKeyText.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 692);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "RSA Signature Key";
            // 
            // aesIVText
            // 
            this.aesIVText.Location = new System.Drawing.Point(316, 739);
            this.aesIVText.Name = "aesIVText";
            this.aesIVText.ReadOnly = true;
            this.aesIVText.Size = new System.Drawing.Size(426, 38);
            this.aesIVText.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 745);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "AES IV";
            // 
            // aesKeyText
            // 
            this.aesKeyText.Location = new System.Drawing.Point(316, 796);
            this.aesKeyText.Name = "aesKeyText";
            this.aesKeyText.ReadOnly = true;
            this.aesKeyText.Size = new System.Drawing.Size(426, 38);
            this.aesKeyText.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 802);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "AES Key";
            // 
            // enrollSignatureText
            // 
            this.enrollSignatureText.Location = new System.Drawing.Point(316, 856);
            this.enrollSignatureText.Name = "enrollSignatureText";
            this.enrollSignatureText.ReadOnly = true;
            this.enrollSignatureText.Size = new System.Drawing.Size(426, 38);
            this.enrollSignatureText.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 862);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(282, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "Enrollment Signature";
            // 
            // loginSignText
            // 
            this.loginSignText.Location = new System.Drawing.Point(316, 916);
            this.loginSignText.Name = "loginSignText";
            this.loginSignText.ReadOnly = true;
            this.loginSignText.Size = new System.Drawing.Size(426, 38);
            this.loginSignText.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 916);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 32);
            this.label6.TabIndex = 18;
            this.label6.Text = "Login Signature";
            // 
            // randomNumberText
            // 
            this.randomNumberText.Location = new System.Drawing.Point(316, 979);
            this.randomNumberText.Name = "randomNumberText";
            this.randomNumberText.ReadOnly = true;
            this.randomNumberText.Size = new System.Drawing.Size(426, 38);
            this.randomNumberText.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 979);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 32);
            this.label7.TabIndex = 20;
            this.label7.Text = "Random Number";
            // 
            // hmacValueText
            // 
            this.hmacValueText.Location = new System.Drawing.Point(316, 1032);
            this.hmacValueText.Name = "hmacValueText";
            this.hmacValueText.ReadOnly = true;
            this.hmacValueText.Size = new System.Drawing.Size(426, 38);
            this.hmacValueText.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 1032);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 32);
            this.label8.TabIndex = 22;
            this.label8.Text = "HMAC Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1710, 1345);
            this.Controls.Add(this.hmacValueText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.randomNumberText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.loginSignText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.enrollSignatureText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.aesKeyText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.aesIVText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rsaSignKeyText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rsaKeyText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.shutdownServerButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.runServerButton);
            this.Controls.Add(this.consoleText);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox consoleText;
        private System.Windows.Forms.Button runServerButton;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button shutdownServerButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rsaKeyText;
        private System.Windows.Forms.TextBox rsaSignKeyText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox aesIVText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox aesKeyText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox enrollSignatureText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox loginSignText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox randomNumberText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox hmacValueText;
        private System.Windows.Forms.Label label8;
    }
}

