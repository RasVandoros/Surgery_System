﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Calendar : Form
    {
        public Calendar()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(this.Width + 50, this.Height + 50);

            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            if (UIManager.Instance.ChosenAppointment != null)
            {
                selectedAppointment.Text = "Appointment ID: " + UIManager.Instance.ChosenAppointment.AppointmentID + "\n";
                selectedAppointment.Text += "Appointment Time: " + UIManager.Instance.ChosenAppointment.AppointmentTime + "\n";
                selectedAppointment.Text += "Appointment Date: " + UIManager.Instance.ChosenAppointment.AppointmentDate + "\n";
                selectedAppointment.Text += "Patient ID: " + UIManager.Instance.ChosenAppointment.PatientID + "\n";
                selectedAppointment.Text += "Staff Member ID: " + UIManager.Instance.ChosenAppointment.StaffID;
            }
            

            foreach (Control c in this.Controls)
            {
                c.Anchor = AnchorStyles.None;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet1.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter1.Fill(this.databaseDataSet1.Appointments);
            myGrid.DataSource = UIManager.Instance.ProjectSelectedDateToCalendar(myCalendar.SelectionRange.Start.ToString("yyyy/MM/dd").Replace('/', '_')).Tables[0];
            myGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void OnDateSelected(object sender, DateRangeEventArgs e)
        {
            myGrid.DataSource = UIManager.Instance.ProjectSelectedDateToCalendar(myCalendar.SelectionRange.Start.ToString("yyyy_MM_dd")).Tables[0];
        }

        private void myGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string selectedApID = myGrid.Rows[row].Cells[0].Value.ToString();
            
            UIManager.Instance.InstantiateAppointment(selectedApID);
            
            selectedAppointment.Text = "Appointment ID: " + UIManager.Instance.ChosenAppointment.AppointmentID + "\n";
            selectedAppointment.Text += "Appointment Time: " + UIManager.Instance.ChosenAppointment.AppointmentTime + "\n";
            selectedAppointment.Text += "Appointment Date: " + UIManager.Instance.ChosenAppointment.AppointmentDate + "\n";
            selectedAppointment.Text += "Patient ID: " + UIManager.Instance.ChosenAppointment.PatientID + "\n";
            selectedAppointment.Text += "Staff Member ID: " + UIManager.Instance.ChosenAppointment.StaffID ;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            UIManager.Instance.DeleteAppointment();
            myGrid.DataSource = UIManager.Instance.ProjectSelectedDateToCalendar(myCalendar.SelectionRange.Start.ToString("yyyy/MM/dd").Replace('/', '_')).Tables[0];
            selectedAppointment.Text = "None";
        }

        private void bookAppointment_Click(object sender, EventArgs e)
        {
            UIManager.Instance.ShowBookAppointmentForm();
        }
    }
}

