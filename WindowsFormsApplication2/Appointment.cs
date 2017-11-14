using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class Appointment
    {
        private string appointmentID;
        private string patientID;
        private string staffID;
        private string appointmentDate;
        private string appointmentTime;
        private Date date;
        private Time time;

        public string AppointmentID
        {
            get { return appointmentID; }
            set { this.appointmentID = value; }
        }
        public string PatientID
        {
            get { return patientID; }
            set { this.patientID = value; }
        }
        public string StaffID
        {
            get { return staffID; }
            set { this.staffID = value; }
        }
        public string AppointmentDate
        {
            get { return appointmentDate; }
            set { this.appointmentDate = value; }
        }
        public string AppointmentTime
        {
            get { return appointmentTime; }
            set { this.appointmentTime = value; }
        }
        public Date Date
        {
            get { return date; }
            set { date = value; }
        }
        public Time Time
        {
            get { return time; }
            set { time = value; }
        }


        /// <summary>
        /// Normal Constructor
        /// </summary>
        /// <param name="apID"></param>
        /// <param name="pID"></param>
        /// <param name="stID"></param>
        /// <param name="apDate"></param>
        /// <param name="apTime"></param>
        public Appointment(string apID, string pID, string stID, string apDate, string apTime)
        {
            appointmentTime = apTime;
            appointmentDate = apDate;
            appointmentID = apID;
            patientID = pID;
            staffID = stID;
            time = new Time(appointmentTime);
            date = new Date(appointmentDate);
        }

        /// <summary>
        /// This constructor is specifically used to generate the selected appointment object
        /// </summary>
        /// <param name="data"></param>
        public Appointment(DataSet data)
        {
            appointmentTime = data.Tables[0].Rows[0][2].ToString().Trim(' ');
            appointmentDate = data.Tables[0].Rows[0][1].ToString().Trim(' ');
            appointmentID = data.Tables[0].Rows[0][0].ToString().Trim(' ');
            patientID = data.Tables[0].Rows[0][4].ToString().Trim(' ');
            staffID = data.Tables[0].Rows[0][3].ToString().Trim(' ');
            try
            {
                time = new Time(appointmentTime);
                date = new Date(appointmentDate);
            }
            catch
            {
                MessageBox.Show("Appointment date and time could not be parsed");
            }
        }

    }
}
