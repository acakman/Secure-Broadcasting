namespace cs432_project_step1_client
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
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.enrollButton = new System.Windows.Forms.Button();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.dcButton = new System.Windows.Forms.Button();
            this.publicKeyRSA = new System.Windows.Forms.RichTextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.publicKeySign = new System.Windows.Forms.RichTextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.enrollSignText = new System.Windows.Forms.TextBox();
            this.loginSignText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.enrollSignVerification = new System.Windows.Forms.TextBox();
            this.loginSignVerification = new System.Windows.Forms.TextBox();
            this.hmacValueText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.randomNumberText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(540, 205);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(6);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(356, 38);
            this.passwordBox.TabIndex = 0;
            this.passwordBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.Location = new System.Drawing.Point(328, 211);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Password:";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(540, 151);
            this.nameBox.Margin = new System.Windows.Forms.Padding(6);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(356, 38);
            this.nameBox.TabIndex = 2;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox2.Location = new System.Drawing.Point(328, 157);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 31);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Username:";
            // 
            // enrollButton
            // 
            this.enrollButton.Location = new System.Drawing.Point(540, 260);
            this.enrollButton.Margin = new System.Windows.Forms.Padding(6);
            this.enrollButton.Name = "enrollButton";
            this.enrollButton.Size = new System.Drawing.Size(360, 56);
            this.enrollButton.TabIndex = 4;
            this.enrollButton.Text = "Enroll";
            this.enrollButton.UseVisualStyleBackColor = true;
            this.enrollButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(540, 43);
            this.ipBox.Margin = new System.Windows.Forms.Padding(6);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(356, 38);
            this.ipBox.TabIndex = 5;
            this.ipBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(540, 97);
            this.portBox.Margin = new System.Windows.Forms.Padding(6);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(90, 38);
            this.portBox.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox5.Location = new System.Drawing.Point(328, 48);
            this.textBox5.Margin = new System.Windows.Forms.Padding(6);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(200, 31);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "IPv4:";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox6.Location = new System.Drawing.Point(328, 103);
            this.textBox6.Margin = new System.Windows.Forms.Padding(6);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(200, 31);
            this.textBox6.TabIndex = 8;
            this.textBox6.Text = "Port:";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(328, 459);
            this.consoleBox.Margin = new System.Windows.Forms.Padding(6);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(1316, 316);
            this.consoleBox.TabIndex = 9;
            this.consoleBox.Text = "";
            this.consoleBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox7.Location = new System.Drawing.Point(328, 418);
            this.textBox7.Margin = new System.Windows.Forms.Padding(6);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(200, 31);
            this.textBox7.TabIndex = 10;
            this.textBox7.Text = "Console";
            // 
            // dcButton
            // 
            this.dcButton.Location = new System.Drawing.Point(540, 375);
            this.dcButton.Margin = new System.Windows.Forms.Padding(6);
            this.dcButton.Name = "dcButton";
            this.dcButton.Size = new System.Drawing.Size(360, 58);
            this.dcButton.TabIndex = 11;
            this.dcButton.Text = "Disconnect";
            this.dcButton.UseVisualStyleBackColor = true;
            this.dcButton.Click += new System.EventHandler(this.dcButton_Click);
            // 
            // publicKeyRSA
            // 
            this.publicKeyRSA.BackColor = System.Drawing.SystemColors.Control;
            this.publicKeyRSA.Location = new System.Drawing.Point(1300, 43);
            this.publicKeyRSA.Margin = new System.Windows.Forms.Padding(6);
            this.publicKeyRSA.Name = "publicKeyRSA";
            this.publicKeyRSA.ReadOnly = true;
            this.publicKeyRSA.Size = new System.Drawing.Size(344, 39);
            this.publicKeyRSA.TabIndex = 12;
            this.publicKeyRSA.Text = "";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox8.Location = new System.Drawing.Point(1012, 51);
            this.textBox8.Margin = new System.Windows.Forms.Padding(6);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(200, 31);
            this.textBox8.TabIndex = 13;
            this.textBox8.Text = "RSA Public Key";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox9.Location = new System.Drawing.Point(1012, 108);
            this.textBox9.Margin = new System.Windows.Forms.Padding(6);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(200, 31);
            this.textBox9.TabIndex = 14;
            this.textBox9.Text = "Sign Public Key";
            // 
            // publicKeySign
            // 
            this.publicKeySign.BackColor = System.Drawing.SystemColors.Control;
            this.publicKeySign.Location = new System.Drawing.Point(1300, 105);
            this.publicKeySign.Margin = new System.Windows.Forms.Padding(6);
            this.publicKeySign.Name = "publicKeySign";
            this.publicKeySign.ReadOnly = true;
            this.publicKeySign.Size = new System.Drawing.Size(344, 39);
            this.publicKeySign.TabIndex = 15;
            this.publicKeySign.Text = "";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(540, 325);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(360, 41);
            this.loginButton.TabIndex = 17;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1006, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Enrollment Signature";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // enrollSignText
            // 
            this.enrollSignText.Location = new System.Drawing.Point(1300, 150);
            this.enrollSignText.Name = "enrollSignText";
            this.enrollSignText.ReadOnly = true;
            this.enrollSignText.Size = new System.Drawing.Size(344, 38);
            this.enrollSignText.TabIndex = 19;
            // 
            // loginSignText
            // 
            this.loginSignText.Location = new System.Drawing.Point(1300, 194);
            this.loginSignText.Name = "loginSignText";
            this.loginSignText.ReadOnly = true;
            this.loginSignText.Size = new System.Drawing.Size(344, 38);
            this.loginSignText.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1006, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 32);
            this.label2.TabIndex = 20;
            this.label2.Text = "Login Signature";
            // 
            // enrollSignVerification
            // 
            this.enrollSignVerification.Location = new System.Drawing.Point(1678, 150);
            this.enrollSignVerification.Name = "enrollSignVerification";
            this.enrollSignVerification.ReadOnly = true;
            this.enrollSignVerification.Size = new System.Drawing.Size(100, 38);
            this.enrollSignVerification.TabIndex = 22;
            // 
            // loginSignVerification
            // 
            this.loginSignVerification.Location = new System.Drawing.Point(1678, 197);
            this.loginSignVerification.Name = "loginSignVerification";
            this.loginSignVerification.ReadOnly = true;
            this.loginSignVerification.Size = new System.Drawing.Size(100, 38);
            this.loginSignVerification.TabIndex = 23;
            // 
            // hmacValueText
            // 
            this.hmacValueText.Location = new System.Drawing.Point(1300, 238);
            this.hmacValueText.Name = "hmacValueText";
            this.hmacValueText.ReadOnly = true;
            this.hmacValueText.Size = new System.Drawing.Size(344, 38);
            this.hmacValueText.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1006, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 32);
            this.label3.TabIndex = 25;
            this.label3.Text = "HMAC Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1006, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 32);
            this.label4.TabIndex = 27;
            this.label4.Text = "Random Number";
            // 
            // randomNumberText
            // 
            this.randomNumberText.Location = new System.Drawing.Point(1300, 282);
            this.randomNumberText.Name = "randomNumberText";
            this.randomNumberText.ReadOnly = true;
            this.randomNumberText.Size = new System.Drawing.Size(344, 38);
            this.randomNumberText.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1946, 1321);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.randomNumberText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hmacValueText);
            this.Controls.Add(this.loginSignVerification);
            this.Controls.Add(this.enrollSignVerification);
            this.Controls.Add(this.loginSignText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.enrollSignText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.publicKeySign);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.publicKeyRSA);
            this.Controls.Add(this.dcButton);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.enrollButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.passwordBox);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button enrollButton;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button dcButton;
        private System.Windows.Forms.RichTextBox publicKeyRSA;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.RichTextBox publicKeySign;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox enrollSignText;
        private System.Windows.Forms.TextBox loginSignText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox enrollSignVerification;
        private System.Windows.Forms.TextBox loginSignVerification;
        private System.Windows.Forms.TextBox hmacValueText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox randomNumberText;
    }
}

