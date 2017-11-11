using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Appointment
    {
        private string appointmentID;
        private string patientID;
        private string staffID;
        private string appointmentDate;
        private string appointmentTime;

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
        }

        public Appointment(DataSet data)
        {
            appointmentTime = data.Tables[0].Rows[0][2].ToString().Trim(' ');
            appointmentDate = data.Tables[0].Rows[0][1].ToString().Trim(' ');
            appointmentID = data.Tables[0].Rows[0][0].ToString().Trim(' ');
            patientID = data.Tables[0].Rows[0][4].ToString().Trim(' ');
            staffID = data.Tables[0].Rows[0][3].ToString().Trim(' ');
        }

    }
}
