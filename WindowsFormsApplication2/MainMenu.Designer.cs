namespace WindowsFormsApplication2
{
    partial class MainForm
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
            this.logOffBut = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.registerNewUserButton = new System.Windows.Forms.Button();
            this.CalendarButton = new System.Windows.Forms.Button();
            this.findPatient = new System.Windows.Forms.Button();
            this.addressLabel = new System.Windows.Forms.Label();
            this.dobLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.registerNewPatientButton = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTxt = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.Label();
            this.dobTxt = new System.Windows.Forms.Label();
            this.addressTxt = new System.Windows.Forms.Label();
            this.prescriptions = new System.Windows.Forms.DataGridView();
            this.emptyActivePatButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.prescriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // logOffBut
            // 
            this.logOffBut.Location = new System.Drawing.Point(369, 460);
            this.logOffBut.Name = "logOffBut";
            this.logOffBut.Size = new System.Drawing.Size(70, 23);
            this.logOffBut.TabIndex = 0;
            this.logOffBut.Text = "Log Off";
            this.logOffBut.UseVisualStyleBackColor = true;
            this.logOffBut.Click += new System.EventHandler(this.logOffBut_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(96, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(259, 26);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Oval Surgery Database";
            // 
            // registerNewUserButton
            // 
            this.registerNewUserButton.Location = new System.Drawing.Point(12, 460);
            this.registerNewUserButton.Name = "registerNewUserButton";
            this.registerNewUserButton.Size = new System.Drawing.Size(106, 23);
            this.registerNewUserButton.TabIndex = 25;
            this.registerNewUserButton.Text = "Register New User";
            this.registerNewUserButton.UseVisualStyleBackColor = true;
            this.registerNewUserButton.Click += new System.EventHandler(this.registerNewUserButton_Click);
            // 
            // CalendarButton
            // 
            this.CalendarButton.Location = new System.Drawing.Point(23, 65);
            this.CalendarButton.Name = "CalendarButton";
            this.CalendarButton.Size = new System.Drawing.Size(62, 61);
            this.CalendarButton.TabIndex = 26;
            this.CalendarButton.Text = "Calendar";
            this.CalendarButton.UseVisualStyleBackColor = true;
            this.CalendarButton.Click += new System.EventHandler(this.CalendarButton_Click);
            // 
            // findPatient
            // 
            this.findPatient.Location = new System.Drawing.Point(257, 255);
            this.findPatient.Name = "findPatient";
            this.findPatient.Size = new System.Drawing.Size(84, 23);
            this.findPatient.TabIndex = 27;
            this.findPatient.Text = "Find Patient";
            this.findPatient.UseVisualStyleBackColor = true;
            this.findPatient.Click += new System.EventHandler(this.findPatient_Click);
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(254, 220);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.TabIndex = 31;
            this.addressLabel.Text = "Address";
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.Location = new System.Drawing.Point(254, 179);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(65, 13);
            this.dobLabel.TabIndex = 30;
            this.dobLabel.Text = "Date of brith";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(254, 140);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 29;
            this.nameLabel.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Patient:";
            // 
            // registerNewPatientButton
            // 
            this.registerNewPatientButton.Location = new System.Drawing.Point(355, 255);
            this.registerNewPatientButton.Name = "registerNewPatientButton";
            this.registerNewPatientButton.Size = new System.Drawing.Size(84, 23);
            this.registerNewPatientButton.TabIndex = 38;
            this.registerNewPatientButton.Text = "Register New";
            this.registerNewPatientButton.UseVisualStyleBackColor = true;
            this.registerNewPatientButton.Click += new System.EventHandler(this.registerNewPatientButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(254, 100);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 43;
            this.idLabel.Text = "ID";
            // 
            // idTxt
            // 
            this.idTxt.AutoSize = true;
            this.idTxt.Location = new System.Drawing.Point(382, 100);
            this.idTxt.Name = "idTxt";
            this.idTxt.Size = new System.Drawing.Size(36, 13);
            this.idTxt.TabIndex = 45;
            this.idTxt.Text = "Empty";
            // 
            // nameTxt
            // 
            this.nameTxt.AutoSize = true;
            this.nameTxt.Location = new System.Drawing.Point(382, 140);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(36, 13);
            this.nameTxt.TabIndex = 46;
            this.nameTxt.Text = "Empty";
            // 
            // dobTxt
            // 
            this.dobTxt.AutoSize = true;
            this.dobTxt.Location = new System.Drawing.Point(382, 179);
            this.dobTxt.Name = "dobTxt";
            this.dobTxt.Size = new System.Drawing.Size(36, 13);
            this.dobTxt.TabIndex = 47;
            this.dobTxt.Text = "Empty";
            // 
            // addressTxt
            // 
            this.addressTxt.AutoSize = true;
            this.addressTxt.Location = new System.Drawing.Point(382, 220);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(36, 13);
            this.addressTxt.TabIndex = 48;
            this.addressTxt.Text = "Empty";
            // 
            // prescriptions
            // 
            this.prescriptions.AllowUserToAddRows = false;
            this.prescriptions.AllowUserToDeleteRows = false;
            this.prescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prescriptions.Location = new System.Drawing.Point(12, 293);
            this.prescriptions.Name = "prescriptions";
            this.prescriptions.Size = new System.Drawing.Size(427, 150);
            this.prescriptions.TabIndex = 49;
            this.prescriptions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnPrescriptionGridDoubleClick);
            this.prescriptions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnPrescriptionsCellValueChanged);
            // 
            // emptyActivePatButton
            // 
            this.emptyActivePatButton.Location = new System.Drawing.Point(283, 60);
            this.emptyActivePatButton.Name = "emptyActivePatButton";
            this.emptyActivePatButton.Size = new System.Drawing.Size(23, 23);
            this.emptyActivePatButton.TabIndex = 50;
            this.emptyActivePatButton.Text = "X";
            this.emptyActivePatButton.UseVisualStyleBackColor = true;
            this.emptyActivePatButton.Click += new System.EventHandler(this.emptyActivePatButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(455, 495);
            this.Controls.Add(this.emptyActivePatButton);
            this.Controls.Add(this.prescriptions);
            this.Controls.Add(this.addressTxt);
            this.Controls.Add(this.dobTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.registerNewPatientButton);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.findPatient);
            this.Controls.Add(this.CalendarButton);
            this.Controls.Add(this.registerNewUserButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.logOffBut);
            this.Name = "MainForm";
            this.Text = "Over Surgery Software";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prescriptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logOffBut;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button registerNewUserButton;
        private System.Windows.Forms.Button CalendarButton;
        private System.Windows.Forms.Button findPatient;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button registerNewPatientButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label idTxt;
        private System.Windows.Forms.Label nameTxt;
        private System.Windows.Forms.Label dobTxt;
        private System.Windows.Forms.Label addressTxt;
        private System.Windows.Forms.DataGridView prescriptions;
        private System.Windows.Forms.Button emptyActivePatButton;
    }
}

