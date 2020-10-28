namespace GroupProject223
{
    partial class LoginPage
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.ReqID = new System.Windows.Forms.Label();
            this.ReqPassword = new System.Windows.Forms.Label();
            this.ReqConPassword = new System.Windows.Forms.Label();
            this.clickForget = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UpdateAccount = new System.Windows.Forms.LinkLabel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnExxit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pukkie Airways\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(517, 318);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(236, 82);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1030, 664);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 65);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(195, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(651, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please fill in the following login details :\r\n";
            // 
            // tbUserID
            // 
            this.tbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.26957F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserID.Location = new System.Drawing.Point(503, 174);
            this.tbUserID.Margin = new System.Windows.Forms.Padding(4);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(84, 29);
            this.tbUserID.TabIndex = 6;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.26957F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(414, 230);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(276, 29);
            this.tbPassword.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(359, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "System ID :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(232, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "User Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 270);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 27);
            this.label5.TabIndex = 10;
            this.label5.Text = "Confirm Password:";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.26957F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPassword.Location = new System.Drawing.Point(414, 268);
            this.tbConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(276, 29);
            this.tbConfirmPassword.TabIndex = 11;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(715, 513);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(118, 38);
            this.btnHelp.TabIndex = 12;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.button3_Click);
            // 
            // ReqID
            // 
            this.ReqID.AutoSize = true;
            this.ReqID.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReqID.ForeColor = System.Drawing.Color.Red;
            this.ReqID.Location = new System.Drawing.Point(595, 182);
            this.ReqID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ReqID.Name = "ReqID";
            this.ReqID.Size = new System.Drawing.Size(120, 16);
            this.ReqID.TabIndex = 18;
            this.ReqID.Text = "Required Field !";
            // 
            // ReqPassword
            // 
            this.ReqPassword.AutoSize = true;
            this.ReqPassword.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReqPassword.ForeColor = System.Drawing.Color.Red;
            this.ReqPassword.Location = new System.Drawing.Point(698, 238);
            this.ReqPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ReqPassword.Name = "ReqPassword";
            this.ReqPassword.Size = new System.Drawing.Size(120, 16);
            this.ReqPassword.TabIndex = 19;
            this.ReqPassword.Text = "Required Field !";
            // 
            // ReqConPassword
            // 
            this.ReqConPassword.AutoSize = true;
            this.ReqConPassword.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReqConPassword.ForeColor = System.Drawing.Color.Red;
            this.ReqConPassword.Location = new System.Drawing.Point(698, 277);
            this.ReqConPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ReqConPassword.Name = "ReqConPassword";
            this.ReqConPassword.Size = new System.Drawing.Size(120, 16);
            this.ReqConPassword.TabIndex = 20;
            this.ReqConPassword.Text = "Required Field !";
            // 
            // clickForget
            // 
            this.clickForget.AutoSize = true;
            this.clickForget.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clickForget.Location = new System.Drawing.Point(619, 417);
            this.clickForget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clickForget.Name = "clickForget";
            this.clickForget.Size = new System.Drawing.Size(97, 23);
            this.clickForget.TabIndex = 21;
            this.clickForget.TabStop = true;
            this.clickForget.Text = "Click here";
            this.clickForget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clickForget_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(274, 417);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(338, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "I Forgot My Username or Password :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F);
            this.label8.Location = new System.Drawing.Point(216, 460);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(396, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "I want to update or edit my account details :";
            // 
            // UpdateAccount
            // 
            this.UpdateAccount.AutoSize = true;
            this.UpdateAccount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateAccount.Location = new System.Drawing.Point(620, 460);
            this.UpdateAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdateAccount.Name = "UpdateAccount";
            this.UpdateAccount.Size = new System.Drawing.Size(97, 23);
            this.UpdateAccount.TabIndex = 25;
            this.UpdateAccount.TabStop = true;
            this.UpdateAccount.Text = "Click here";
            this.UpdateAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UpdateAccount_LinkClicked);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(278, 318);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(231, 82);
            this.btnRegister.TabIndex = 26;
            this.btnRegister.Text = "Register New Account";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnExxit
            // 
            this.btnExxit.Location = new System.Drawing.Point(841, 513);
            this.btnExxit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExxit.Name = "btnExxit";
            this.btnExxit.Size = new System.Drawing.Size(118, 38);
            this.btnExxit.TabIndex = 28;
            this.btnExxit.Text = "Exit";
            this.btnExxit.UseVisualStyleBackColor = true;
            this.btnExxit.Click += new System.EventHandler(this.btnExxit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 469);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 49;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(12, 110);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 75);
            this.button1.TabIndex = 29;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExxit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.UpdateAccount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.clickForget);
            this.Controls.Add(this.ReqConPassword);
            this.Controls.Add(this.ReqPassword);
            this.Controls.Add(this.ReqID);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.26957F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginPage";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label ReqID;
        private System.Windows.Forms.Label ReqPassword;
        private System.Windows.Forms.Label ReqConPassword;
        private System.Windows.Forms.LinkLabel clickForget;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel UpdateAccount;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnExxit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}

