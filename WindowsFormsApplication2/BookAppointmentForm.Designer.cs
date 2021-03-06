﻿namespace WindowsFormsApplication2
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
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.time = new System.Windows.Forms.Label();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.submitButton = new System.Windows.Forms.Button();
            this.findPatient = new System.Windows.Forms.Button();
            this.stffNameComboBox = new System.Windows.Forms.ComboBox();
            this.shiftsGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.shiftsGrid)).BeginInit();
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
            // datePicker
            // 
            this.datePicker.Checked = false;
            this.datePicker.Location = new System.Drawing.Point(191, 205);
            this.datePicker.Name = "datePicker";
            this.datePicker.ShowCheckBox = true;
            this.datePicker.Size = new System.Drawing.Size(151, 20);
            this.datePicker.TabIndex = 8;
            this.datePicker.ValueChanged += new System.EventHandler(this.OnCalendarValueChanged);
            this.datePicker.MouseCaptureChanged += new System.EventHandler(this.OnCalendarValueChanged);
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
            this.timePicker.Checked = false;
            this.timePicker.Location = new System.Drawing.Point(191, 265);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowCheckBox = true;
            this.timePicker.Size = new System.Drawing.Size(151, 20);
            this.timePicker.TabIndex = 9;
            this.timePicker.ValueChanged += new System.EventHandler(this.OnCalendarValueChanged);
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
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
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
            // stffNameComboBox
            // 
            this.stffNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stffNameComboBox.FormattingEnabled = true;
            this.stffNameComboBox.Location = new System.Drawing.Point(191, 152);
            this.stffNameComboBox.Name = "stffNameComboBox";
            this.stffNameComboBox.Size = new System.Drawing.Size(151, 21);
            this.stffNameComboBox.TabIndex = 14;
            this.stffNameComboBox.SelectionChangeCommitted += new System.EventHandler(this.stffNameComboBox_SelectionChangeCommitted);
            this.stffNameComboBox.Click += new System.EventHandler(this.OnComboBoxClick);
            // 
            // shiftsGrid
            // 
            this.shiftsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shiftsGrid.Location = new System.Drawing.Point(392, 43);
            this.shiftsGrid.Name = "shiftsGrid";
            this.shiftsGrid.ReadOnly = true;
            this.shiftsGrid.Size = new System.Drawing.Size(375, 338);
            this.shiftsGrid.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(389, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Shifts:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(390, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(388, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "*The table shows all the shifts that cover the data and time of the selections ma" +
    "de";
            // 
            // BookAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 443);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shiftsGrid);
            this.Controls.Add(this.stffNameComboBox);
            this.Controls.Add(this.findPatient);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.patientNameTxtbox);
            this.Controls.Add(this.time);
            this.Controls.Add(this.date);
            this.Controls.Add(this.staffMember);
            this.Controls.Add(this.patientNameLabel);
            this.Name = "BookAppointmentForm";
            this.Text = "ModifyAppointmentForm";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.shiftsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label patientNameLabel;
        private System.Windows.Forms.Label staffMember;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.TextBox patientNameTxtbox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button findPatient;
        private System.Windows.Forms.ComboBox stffNameComboBox;
        private System.Windows.Forms.DataGridView shiftsGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}