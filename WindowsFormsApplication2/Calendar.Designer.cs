namespace WindowsFormsApplication2
{
    partial class Calendar
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
            this.components = new System.ComponentModel.Container();
            this.myCalendar = new System.Windows.Forms.MonthCalendar();
            this.myGrid = new System.Windows.Forms.DataGridView();
            this.databaseDataSet = new WindowsFormsApplication2.DatabaseDataSet();
            this.appointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentsTableAdapter = new WindowsFormsApplication2.DatabaseDataSetTableAdapters.AppointmentsTableAdapter();
            this.selectedAppointment = new System.Windows.Forms.Label();
            this.bookAppointment = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.appointmentsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.selApHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // myCalendar
            // 
            this.myCalendar.Location = new System.Drawing.Point(22, 18);
            this.myCalendar.MaxSelectionCount = 1;
            this.myCalendar.Name = "myCalendar";
            this.myCalendar.TabIndex = 0;
            this.myCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.OnDateSelected);
            // 
            // myGrid
            // 
            this.myGrid.AllowUserToAddRows = false;
            this.myGrid.AllowUserToDeleteRows = false;
            this.myGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGrid.Location = new System.Drawing.Point(22, 229);
            this.myGrid.Name = "myGrid";
            this.myGrid.ReadOnly = true;
            this.myGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.myGrid.Size = new System.Drawing.Size(443, 243);
            this.myGrid.TabIndex = 2;
            this.myGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myGrid_CellClick);
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "DatabaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // appointmentsBindingSource
            // 
            this.appointmentsBindingSource.DataMember = "Appointments";
            this.appointmentsBindingSource.DataSource = this.databaseDataSet;
            // 
            // appointmentsTableAdapter
            // 
            this.appointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // selectedAppointment
            // 
            this.selectedAppointment.AutoSize = true;
            this.selectedAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedAppointment.Location = new System.Drawing.Point(262, 53);
            this.selectedAppointment.Name = "selectedAppointment";
            this.selectedAppointment.Size = new System.Drawing.Size(42, 17);
            this.selectedAppointment.TabIndex = 3;
            this.selectedAppointment.Text = "None";
            // 
            // bookAppointment
            // 
            this.bookAppointment.Location = new System.Drawing.Point(261, 157);
            this.bookAppointment.Name = "bookAppointment";
            this.bookAppointment.Size = new System.Drawing.Size(104, 23);
            this.bookAppointment.TabIndex = 4;
            this.bookAppointment.Text = "New Appointment";
            this.bookAppointment.UseVisualStyleBackColor = true;
            this.bookAppointment.Click += new System.EventHandler(this.bookAppointment_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(371, 157);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(104, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // selApHeader
            // 
            this.selApHeader.AutoSize = true;
            this.selApHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selApHeader.Location = new System.Drawing.Point(261, 18);
            this.selApHeader.Name = "selApHeader";
            this.selApHeader.Size = new System.Drawing.Size(187, 20);
            this.selApHeader.TabIndex = 6;
            this.selApHeader.Text = "Selected Appointment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Appointments List:";
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selApHeader);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.bookAppointment);
            this.Controls.Add(this.selectedAppointment);
            this.Controls.Add(this.myGrid);
            this.Controls.Add(this.myCalendar);
            this.Name = "Calendar";
            this.Text = "Calendar";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.myGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar myCalendar;
        private System.Windows.Forms.DataGridView myGrid;
        private DatabaseDataSet databaseDataSet;
        private System.Windows.Forms.BindingSource appointmentsBindingSource;
        private DatabaseDataSetTableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private System.Windows.Forms.Label selectedAppointment;
        private System.Windows.Forms.Button bookAppointment;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.BindingSource appointmentsBindingSource1;
        private System.Windows.Forms.Label selApHeader;
        private System.Windows.Forms.Label label1;
    }
}