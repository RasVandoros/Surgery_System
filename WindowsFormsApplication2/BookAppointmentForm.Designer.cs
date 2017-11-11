namespace WindowsFormsApplication2
{
    partial class BookAppointmentForm
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
            this.patientNameLabel = new System.Windows.Forms.Label();
            this.staffMember = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.patientNameTxtbox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.time = new System.Windows.Forms.Label();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.chooseTime = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.findPatient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // patientNameLabel
            // 
            this.patientNameLabel.AutoSize = true;
            this.patientNameLabel.Location = new System.Drawing.Point(59, 85);
            this.patientNameLabel.Name = "patientNameLabel";
            this.patientNameLabel.Size = new System.Drawing.Size(71, 13);
            this.patientNameLabel.TabIndex = 0;
            this.patientNameLabel.Text = "Patient Name";
            // 
            // staffMember
            // 
            this.staffMember.AutoSize = true;
            this.staffMember.Location = new System.Drawing.Point(59, 152);
            this.staffMember.Name = "staffMember";
            this.staffMember.Size = new System.Drawing.Size(101, 13);
            this.staffMember.TabIndex = 1;
            this.staffMember.Text = "Staff Member Name";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(59, 212);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(30, 13);
            this.date.TabIndex = 2;
            this.date.Text = "Date";
            // 
            // patientNameTxtbox
            // 
            this.patientNameTxtbox.Location = new System.Drawing.Point(191, 82);
            this.patientNameTxtbox.Name = "patientNameTxtbox";
            this.patientNameTxtbox.ReadOnly = true;
            this.patientNameTxtbox.Size = new System.Drawing.Size(151, 20);
            this.patientNameTxtbox.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(191, 145);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(151, 20);
            this.textBox2.TabIndex = 5;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(191, 205);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(151, 20);
            this.datePicker.TabIndex = 8;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(59, 272);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(30, 13);
            this.time.TabIndex = 3;
            this.time.Text = "Time";
            // 
            // timePicker
            // 
            this.timePicker.Location = new System.Drawing.Point(191, 265);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(151, 20);
            this.timePicker.TabIndex = 9;
            // 
            // chooseTime
            // 
            this.chooseTime.Location = new System.Drawing.Point(291, 291);
            this.chooseTime.Name = "chooseTime";
            this.chooseTime.Size = new System.Drawing.Size(51, 23);
            this.chooseTime.TabIndex = 10;
            this.chooseTime.Text = "Choose";
            this.chooseTime.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(166, 340);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(51, 23);
            this.submitButton.TabIndex = 11;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // findPatient
            // 
            this.findPatient.Location = new System.Drawing.Point(291, 108);
            this.findPatient.Name = "findPatient";
            this.findPatient.Size = new System.Drawing.Size(51, 23);
            this.findPatient.TabIndex = 13;
            this.findPatient.Text = "Find";
            this.findPatient.UseVisualStyleBackColor = true;
            this.findPatient.Click += new System.EventHandler(this.findPatient_Click);
            // 
            // BookAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 403);
            this.Controls.Add(this.findPatient);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.chooseTime);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.patientNameTxtbox);
            this.Controls.Add(this.time);
            this.Controls.Add(this.date);
            this.Controls.Add(this.staffMember);
            this.Controls.Add(this.patientNameLabel);
            this.Name = "BookAppointmentForm";
            this.Text = "ModifyAppointmentForm";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label patientNameLabel;
        private System.Windows.Forms.Label staffMember;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.TextBox patientNameTxtbox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Button chooseTime;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button findPatient;
    }
}