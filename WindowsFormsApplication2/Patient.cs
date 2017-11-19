using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Patient
    {
        private string patientID;
        private string patientName;
        private string patientDateOfBirth; 
        private string patientAddress;

        public string PatientId
        {
            get
            {
                return this.patientID;
            }
        }

        public string PatientName
        {
            get
            {
                return this.patientName;
            }
        }

        public string PatientDateOfBirth
        {
            get
            {
                return this.patientDateOfBirth;
            }
        }

        public string PatientAddress
        {
            get
            {
                return this.patientAddress;
            }
        }


        public Patient(DataSet data)
        {
            this.patientID = data.Tables[0].Rows[0][0].ToString().Trim(' ');
            this.patientName = data.Tables[0].Rows[0][1].ToString().Trim(' ');
            this.patientDateOfBirth = data.Tables[0].Rows[0][2].ToString().Trim(' ');
            this.patientAddress = data.Tables[0].Rows[0][3].ToString().Trim(' ');

            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Patient ob instantiated")));

        }
    }
}

