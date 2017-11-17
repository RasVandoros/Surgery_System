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
        #region attributes and properties
        private string appointmentID;
        private string patientID;
        private string staffID;
        private string appointmentDate;
        private string appointmentTime;
        private int duration;
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
        public int Duration
        {
            get { return duration; }
            set { this.duration = value; }
        }

        #endregion

        /// <summary>
        /// Normal Constructor
        /// </summary>
        /// <param name="apID"></param>
        /// <param name="pID"></param>
        /// <param name="stID"></param>
        /// <param name="apDate"></param>
        /// <param name="apTime"></param>
        public Appointment(string pID, string stID, string apDate, string apTime)
        {
            appointmentTime = apTime;
            appointmentDate = apDate;
            appointmentID = "";
            patientID = pID;
            staffID = stID;
            time = new Time(appointmentTime);
            date = new Date(appointmentDate);
            duration = 30;
            Logger.Instance.WriteLog(Logger.Type.Flow, new Message("Appointment object created"), UIManager.Instance.ID.ToString());
        }

        /// <summary>
        /// This constructor is specifically used to generate the selected appointment object
        /// </summary>
        /// <param name="data"></param>
        public Appointment(DataSet data) //this is probably useless at this point. Need to update the software to always work with the other constructor
        {
            
            appointmentTime = data.Tables[0].Rows[0][2].ToString().Trim(' ');
            appointmentDate = data.Tables[0].Rows[0][1].ToString().Trim(' ');
            appointmentID = data.Tables[0].Rows[0][0].ToString().Trim(' ');
            patientID = data.Tables[0].Rows[0][4].ToString().Trim(' ');
            staffID = data.Tables[0].Rows[0][3].ToString().Trim(' ');

            try
            {
                duration = Int32.Parse(data.Tables[0].Rows[0][5].ToString().Trim(' '));
                time = new Time(appointmentTime);
                date = new Date(appointmentDate);
            }
            catch
            {
                MessageBox.Show("Appointment date, time or duration could not be parsed");
            }
        }

        public Appointment(DataRow datarow)
        {
            

            appointmentTime = datarow[2].ToString().Trim(' ');
            appointmentDate = datarow[1].ToString().Trim(' ');
            appointmentID = datarow[0].ToString().Trim(' ');
            patientID = datarow[4].ToString().Trim(' ');
            staffID = datarow[3].ToString().Trim(' ');

            try
            {
                duration = Int32.Parse(datarow[5].ToString().Trim(' '));
                time = new Time(appointmentTime);
                date = new Date(appointmentDate);
            }
            catch
            {
                MessageBox.Show("Appointment date, time or duration could not be parsed");
            }
        }
    }
}
