using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public sealed class UIManager
    {

        private MainForm mainForm = new MainForm();
        private LoggInScreen myLoggInScreen = new LoggInScreen();
        private User activeUser;
        private Patient activePatient;
        private Calendar calendarForm;
        private Appointment chosenAppointment;
        private BookAppointmentForm bookAppointmentForm;
        private FindPatient findPatientForm;
        private RegisterNewPatientForm registerNewPatientForm;
        private RegisterNewUser registerNewUserForm;

        public RegisterNewUser RegisterNewUserForm
        {
            get { return registerNewUserForm; }
            set { registerNewUserForm = value; }
        }


        public BookAppointmentForm BookAppointmentForm
        {
            get { return bookAppointmentForm; }
            set { bookAppointmentForm = value; }
        }

        public RegisterNewPatientForm RegisterNewPatientForm
        {
            get { return registerNewPatientForm; }
            set { registerNewPatientForm = value; }
        }


        public FindPatient FindPatientForm
        {
            get { return findPatientForm; }
            set { findPatientForm = value; }
        }

        public Appointment ChosenAppointment
        {
            get { return chosenAppointment; }
            set { chosenAppointment = value; }
        }

        

        public User ActiveUser
        {
            get { return activeUser; }
            set
            {
                activeUser = value;
                
            }
           
        }

        public Patient ActivePatient
        {
            get { return activePatient; }
            set
            {
                activePatient = value;

            }

        }


        public MainForm MainForm
        {
            get { return mainForm; }
            set
            {
                mainForm = value;

            }

        }

        private static readonly UIManager instance = new UIManager();
        

        static UIManager()
        {
        }

        private UIManager()
        {
        }

        public static UIManager Instance
        {
            get
            {
                return instance;
            }
        }

        internal void ShowRegisterNewPatientForm()
        {
            registerNewPatientForm = new RegisterNewPatientForm();
            registerNewPatientForm.ShowDialog();
        }

        public void callLoginScreen()
        {
            myLoggInScreen.FormClosing += Form_FormClosing;
            
            mainForm.Visible = false;
            mainForm.FormClosing += Form_FormClosing;
           
            Application.Run(myLoggInScreen);   
        }

        internal void ShowRegisterNewUserForm()
        {
            registerNewUserForm = new RegisterNewUser();
            registerNewUserForm.ShowDialog();
        }

        
        internal void FillStaffMembersComboBox()
        {
            BookAppointmentForm.StffComboBox.Items.Clear();
            
            if (bookAppointmentForm.DatePicker.Checked) 
            {
                if (bookAppointmentForm.TimePicker.Checked) //both checked
                {
                    string selectedDate = BookAppointmentForm.DatePicker.Value.ToString("yyyy/MM/dd");
                    string selectedTime = BookAppointmentForm.TimePicker.Value.ToString("hhmm");

                    //NEEDS FIX
                    string sql = @"SELECT StaffID FROM Shifts WHERE Date = '" + selectedDate + "' AND StartTime <  '" + selectedTime + "' AND FinishTime > '" + selectedTime + "' EXCEPT SELECT StaffID FROM Appointments WHERE AppointmentDate = '" + selectedDate + "'AND AppointmentTime = '" + selectedTime + "'";

                    
                    DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
                    List<string> myListOfIds = new List<string>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        foreach (object id in row.ItemArray)
                        {
                            BookAppointmentForm.StffComboBox.Items.Add(id.ToString());
                        }
                    }
                    
                }
                else //only date checked
                {

                }
            }
            else
            {
                if (bookAppointmentForm.TimePicker.Checked) //only time checked
                {

                }
                else //none checked
                {

                }
            }
            
        }


        internal void RegisterUser(string username, string password, string jobTitle)
        {

            if (!ClickLogIn(username, password))
            {
                string sql = @"INSERT INTO Users (Username, Password, JobTitle) VALUES ('" + username + "', '" + password + "', '" + jobTitle + "')";
                try
                {
                    DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
                    MessageBox.Show("User Registered Successfully");
                }
                catch
                {
                    MessageBox.Show("Error while inserting");

                }
            }
            else
            {
                MessageBox.Show("User Already exists in the database");

            }
        }


        internal void RegisterPatient(string patientName, string postcode, string dob)
        {
            if(!ConfirmSearchPatientClick(patientName, postcode, dob))
            {
                string sql = @"INSERT INTO Patients (PatientName, dateOfBirth, Address) VALUES ('" + patientName + "', '" + dob + "', '" + postcode + "')";
                try
                {
                    DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
                    MessageBox.Show("Patient Registered Successfully");
                }
                catch
                {
                    MessageBox.Show("Error while inserting");

                }
            }
            else
            {
                MessageBox.Show("Patient Already exists in the database");

            }
        }


        internal DataSet ProjectSelectedDateToCalendar(string selectedDate)
        {
            string sql = @"SELECT DISTINCT a.ID, a.AppointmentTime, s.StaffMemberName, p.PatientName FROM Appointments a INNER JOIN StaffMembers s on a.StaffID = s.Id INNER JOIN Patients p on a.PatientID = p.Id WHERE a.AppointmentDate = '" + selectedDate + "'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        internal void InstantiateAppointment(string appointmentID)
        {
            string sql = @"SELECT * FROM Appointments WHERE ID = '" + appointmentID + "'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            try
            {
                UIManager.Instance.chosenAppointment = new Appointment(ds);
                
            }
            catch
            {
                MessageBox.Show("Appointment Data Corrupted");
            }
            

            
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCancel(e);
        }

        public void swapVisibility()
        {
            if(myLoggInScreen.Visible == true)
            {
                myLoggInScreen.Visible = false;
                mainForm.Visible = true;
            }
            else if(mainForm.Visible == true)
            {
                mainForm.Visible = false;
                myLoggInScreen.Visible = true;
                
            }
        }

        internal void showFindPatientForm()
        {
            findPatientForm = new FindPatient();
            findPatientForm.ShowDialog();
        }

        internal void DeleteAppointment()
        {
            if(chosenAppointment != null)
            {
                string sql = @"DELETE FROM Appointments WHERE Id = '" + chosenAppointment.AppointmentID + "'";

                try
                {
                    DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
                    chosenAppointment = null;
                }
                catch
                {
                    MessageBox.Show("Appointment ID could not be found in the database");

                }
            }
           else
            {
                MessageBox.Show("No appointmnet was selected");

            }
            
        }

        internal void ShowBookAppointmentForm()
        {
            bookAppointmentForm = new BookAppointmentForm();
            bookAppointmentForm.ShowDialog();
        }
    

        public void logOffBut_ClickUi(EventArgs e)
        {
            const string message = "Are you sure that you would like to log out?";
            const string caption = "Log Out";
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Instance.swapVisibility();
                activeUser = null;
                activePatient = null;
                chosenAppointment = null;
                
                
            }
        }

        public void CloseCancel(FormClosingEventArgs e)
        {

                const string message = "Are you sure that you would like to exit?";
                const string caption = "Attention";
                var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                myLoggInScreen.FormClosing -= Form_FormClosing;
                mainForm.FormClosing -= Form_FormClosing;
                Application.Exit();
            }
        }

        internal void showCalendar()
        {
            calendarForm = new Calendar();
            calendarForm.ShowDialog();
        }

        internal bool ConfirmSearchPatientClick(string name, string postcode, string dOb)
        {
            string sql = @"SELECT * FROM Patients WHERE PatientName = '" + name + "'AND Address = '" + postcode + "'AND dateOfBirth = '" + dOb + "'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.activePatient = new Patient(ds);
                return true;
            }
            else return false;

        }
        
        internal bool ConfirmSearchPatientClick(string id)
        {
            string sql = @"SELECT * FROM Patients WHERE Id = '" + id + "'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.activePatient = new Patient(ds);
                return true;
            }
            else return false;
        }

        public bool ClickLogIn(string userName, string password)
        {
            
            string sql = @"SELECT * FROM Users WHERE Username = '" + userName + "'AND Password = '" + password +"'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.activeUser = new User(ds);
                return true;
            }
            else return false;
           
             
        }

        
    }
    public static class Utility
    {
        public static bool CheckFind(DataSet ds)
        {

            if (ds.Tables[0].Rows.Count == 1)
            {
                return true;
            }
            else if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Multiple Entries with the same credentials");
                Console.ReadLine();
                return false;
            }
        }

        public static void UpdateActivePatientLabels()
        {
            UIManager.Instance.MainForm.NameLabelText = UIManager.Instance.ActivePatient.PatientName;
            UIManager.Instance.MainForm.AddressLabelTxt = UIManager.Instance.ActivePatient.PatientAddress;
            UIManager.Instance.MainForm.DoBLabelTxt = UIManager.Instance.ActivePatient.PatientDateOfBirth;
            UIManager.Instance.MainForm.IdLabelTxt = UIManager.Instance.ActivePatient.PatientId;
            
        }
    }
}
