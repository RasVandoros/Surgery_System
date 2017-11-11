namespace WindowsFormsApplication2
{
    partial class RegisterNewUser
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
            this.confirmRegButton = new System.Windows.Forms.Button();
            this.usernametextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.jobTitleLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.registerLabel = new System.Windows.Forms.Label();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.jobComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // confirmRegButton
            // 
            this.confirmRegButton.Location = new System.Drawing.Point(206, 314);
            this.confirmRegButton.Name = "confirmRegButton";
            this.confirmRegButton.Size = new System.Drawing.Size(75, 23);
            this.confirmRegButton.TabIndex = 42;
            this.confirmRegButton.Text = "Confirm";
            this.confirmRegButton.UseVisualStyleBackColor = true;
            this.confirmRegButton.Click += new System.EventHandler(this.confirmRegButton_Click);
            // 
            // usernametextBox
            // 
            this.usernametextBox.Location = new System.Drawing.Point(238, 119);
            this.usernametextBox.Name = "usernametextBox";
            this.usernametextBox.Size = new System.Drawing.Size(100, 20);
            this.usernametextBox.TabIndex = 40;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(129, 126);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(57, 13);
            this.usernameLabel.TabIndex = 39;
            this.usernameLabel.Text = "UserName";
            // 
            // jobTitleLabel
            // 
            this.jobTitleLabel.AutoSize = true;
            this.jobTitleLabel.Location = new System.Drawing.Point(129, 206);
            this.jobTitleLabel.Name = "jobTitleLabel";
            this.jobTitleLabel.Size = new System.Drawing.Size(47, 13);
            this.jobTitleLabel.TabIndex = 38;
            this.jobTitleLabel.Text = "Job Title";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(129, 168);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 37;
            this.passwordLabel.Text = "Password";
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Location = new System.Drawing.Point(259, 56);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(46, 13);
            this.registerLabel.TabIndex = 36;
            this.registerLabel.Text = "Register";
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(238, 165);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(100, 20);
            this.passwordTxt.TabIndex = 43;
            // 
            // jobComboBox
            // 
            this.jobComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobComboBox.FormattingEnabled = true;
            this.jobComboBox.Items.AddRange(new object[] {
            "Manager",
            "Receptionist"});
            this.jobComboBox.Location = new System.Drawing.Point(238, 198);
            this.jobComboBox.Name = "jobComboBox";
            this.jobComboBox.Size = new System.Drawing.Size(121, 21);
            this.jobComboBox.TabIndex = 44;
            // 
            // RegisterNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 440);
            this.Controls.Add(this.jobComboBox);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.confirmRegButton);
            this.Controls.Add(this.usernametextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.jobTitleLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.registerLabel);
            this.Name = "RegisterNewUser";
            this.Text = "RegisterNewUser";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button confirmRegButton;
        private System.Windows.Forms.TextBox usernametextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label jobTitleLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.ComboBox jobComboBox;
    }
}