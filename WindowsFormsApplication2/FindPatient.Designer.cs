namespace WindowsFormsApplication2
{
    partial class FindPatient
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
            this.confirmSearchbutton = new System.Windows.Forms.Button();
            this.addresstextBox = new System.Windows.Forms.TextBox();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.iDtextBox = new System.Windows.Forms.TextBox();
            this.radioButtonName = new System.Windows.Forms.RadioButton();
            this.radioButtonID = new System.Windows.Forms.RadioButton();
            this.dObLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // confirmSearchbutton
            // 
            this.confirmSearchbutton.Location = new System.Drawing.Point(236, 289);
            this.confirmSearchbutton.Name = "confirmSearchbutton";
            this.confirmSearchbutton.Size = new System.Drawing.Size(75, 23);
            this.confirmSearchbutton.TabIndex = 35;
            this.confirmSearchbutton.Text = "Confirm";
            this.confirmSearchbutton.UseVisualStyleBackColor = true;
            this.confirmSearchbutton.Click += new System.EventHandler(this.confirmSearchbutton_Click);
            // 
            // addresstextBox
            // 
            this.addresstextBox.Location = new System.Drawing.Point(274, 169);
            this.addresstextBox.Name = "addresstextBox";
            this.addresstextBox.Size = new System.Drawing.Size(100, 20);
            this.addresstextBox.TabIndex = 33;
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(274, 133);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(100, 20);
            this.nametextBox.TabIndex = 32;
            // 
            // iDtextBox
            // 
            this.iDtextBox.Location = new System.Drawing.Point(274, 93);
            this.iDtextBox.Name = "iDtextBox";
            this.iDtextBox.Size = new System.Drawing.Size(100, 20);
            this.iDtextBox.TabIndex = 31;
            // 
            // radioButtonName
            // 
            this.radioButtonName.AutoSize = true;
            this.radioButtonName.Location = new System.Drawing.Point(47, 141);
            this.radioButtonName.Name = "radioButtonName";
            this.radioButtonName.Size = new System.Drawing.Size(14, 13);
            this.radioButtonName.TabIndex = 30;
            this.radioButtonName.TabStop = true;
            this.radioButtonName.UseVisualStyleBackColor = true;
            this.radioButtonName.CheckedChanged += new System.EventHandler(this.radioButtonID_CheckedChanged);
            // 
            // radioButtonID
            // 
            this.radioButtonID.AutoSize = true;
            this.radioButtonID.Location = new System.Drawing.Point(47, 97);
            this.radioButtonID.Name = "radioButtonID";
            this.radioButtonID.Size = new System.Drawing.Size(14, 13);
            this.radioButtonID.TabIndex = 29;
            this.radioButtonID.TabStop = true;
            this.radioButtonID.UseVisualStyleBackColor = true;
            this.radioButtonID.CheckedChanged += new System.EventHandler(this.radioButtonID_CheckedChanged);
            // 
            // dObLabel
            // 
            this.dObLabel.AutoSize = true;
            this.dObLabel.Location = new System.Drawing.Point(132, 217);
            this.dObLabel.Name = "dObLabel";
            this.dObLabel.Size = new System.Drawing.Size(68, 13);
            this.dObLabel.TabIndex = 28;
            this.dObLabel.Text = "Date Of Birth";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(132, 179);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.TabIndex = 27;
            this.addressLabel.Text = "Address";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(132, 141);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 26;
            this.nameLabel.Text = "Name";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(132, 101);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 25;
            this.idLabel.Text = "ID";
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(271, 31);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(41, 13);
            this.SearchLabel.TabIndex = 24;
            this.SearchLabel.Text = "Search";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(274, 210);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(117, 20);
            this.datePicker.TabIndex = 36;
            // 
            // FindPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 350);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.confirmSearchbutton);
            this.Controls.Add(this.addresstextBox);
            this.Controls.Add(this.nametextBox);
            this.Controls.Add(this.iDtextBox);
            this.Controls.Add(this.radioButtonName);
            this.Controls.Add(this.radioButtonID);
            this.Controls.Add(this.dObLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.SearchLabel);
            this.Name = "FindPatient";
            this.Text = "FindPatient";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmSearchbutton;
        private System.Windows.Forms.TextBox addresstextBox;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.TextBox iDtextBox;
        private System.Windows.Forms.RadioButton radioButtonName;
        private System.Windows.Forms.RadioButton radioButtonID;
        private System.Windows.Forms.Label dObLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.DateTimePicker datePicker;
    }
}