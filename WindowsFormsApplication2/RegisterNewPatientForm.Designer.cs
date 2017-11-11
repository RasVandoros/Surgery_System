namespace WindowsFormsApplication2
{
    partial class RegisterNewPatientForm
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
            this.postcodeRegtextBox = new System.Windows.Forms.TextBox();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.fnameLabel = new System.Windows.Forms.Label();
            this.addressReglabel = new System.Windows.Forms.Label();
            this.dObRegLabel = new System.Windows.Forms.Label();
            this.registerLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // confirmRegButton
            // 
            this.confirmRegButton.Location = new System.Drawing.Point(185, 296);
            this.confirmRegButton.Name = "confirmRegButton";
            this.confirmRegButton.Size = new System.Drawing.Size(75, 23);
            this.confirmRegButton.TabIndex = 34;
            this.confirmRegButton.Text = "Confirm";
            this.confirmRegButton.UseVisualStyleBackColor = true;
            this.confirmRegButton.Click += new System.EventHandler(this.confirmRegButton_Click);
            // 
            // postcodeRegtextBox
            // 
            this.postcodeRegtextBox.Location = new System.Drawing.Point(217, 181);
            this.postcodeRegtextBox.Name = "postcodeRegtextBox";
            this.postcodeRegtextBox.Size = new System.Drawing.Size(100, 20);
            this.postcodeRegtextBox.TabIndex = 33;
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(217, 101);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(100, 20);
            this.nametextBox.TabIndex = 30;
            // 
            // fnameLabel
            // 
            this.fnameLabel.AutoSize = true;
            this.fnameLabel.Location = new System.Drawing.Point(108, 108);
            this.fnameLabel.Name = "fnameLabel";
            this.fnameLabel.Size = new System.Drawing.Size(35, 13);
            this.fnameLabel.TabIndex = 29;
            this.fnameLabel.Text = "Name";
            // 
            // addressReglabel
            // 
            this.addressReglabel.AutoSize = true;
            this.addressReglabel.Location = new System.Drawing.Point(108, 188);
            this.addressReglabel.Name = "addressReglabel";
            this.addressReglabel.Size = new System.Drawing.Size(53, 13);
            this.addressReglabel.TabIndex = 28;
            this.addressReglabel.Text = "PostCode";
            // 
            // dObRegLabel
            // 
            this.dObRegLabel.AutoSize = true;
            this.dObRegLabel.Location = new System.Drawing.Point(108, 150);
            this.dObRegLabel.Name = "dObRegLabel";
            this.dObRegLabel.Size = new System.Drawing.Size(65, 13);
            this.dObRegLabel.TabIndex = 27;
            this.dObRegLabel.Text = "Date of brith";
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Location = new System.Drawing.Point(238, 38);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(46, 13);
            this.registerLabel.TabIndex = 25;
            this.registerLabel.Text = "Register";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(217, 144);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(134, 20);
            this.datePicker.TabIndex = 35;
            // 
            // RegisterNewPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 346);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.confirmRegButton);
            this.Controls.Add(this.postcodeRegtextBox);
            this.Controls.Add(this.nametextBox);
            this.Controls.Add(this.fnameLabel);
            this.Controls.Add(this.addressReglabel);
            this.Controls.Add(this.dObRegLabel);
            this.Controls.Add(this.registerLabel);
            this.Name = "RegisterNewPatientForm";
            this.Text = "RegisterNewPatientForm";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmRegButton;
        private System.Windows.Forms.TextBox postcodeRegtextBox;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.Label fnameLabel;
        private System.Windows.Forms.Label addressReglabel;
        private System.Windows.Forms.Label dObRegLabel;
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.DateTimePicker datePicker;
    }
}