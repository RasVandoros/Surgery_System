using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace WindowsFormsApplication2
{
    #region UIManager
    public sealed class UIManager
    {
        #region Singleton

        static UIManager instance = null;
        static readonly object myLock = new object();
        private int id;
        
        UIManager()
        {
            try
            {
                string curFile = "";
                id = 0;
                do
                {
                    id++;
                    curFile = string.Format(String.IsNullOrEmpty(id.ToString()) ? "{0}.log" : "{0}_{1}.log", DateTime.Now.ToString("yyyy_MM_dd"), id);
                }
                while (File.Exists(curFile));
                Logger.LogName = curFile;

            }
            catch(Exception e)
            {
                Logger.Instance.WriteLog(Logger.Type.Exception, new Message(e, "Error while searching for the run ID, inside the constructor"), null);
            }
        }
        
        public static UIManager Instance
        {
            get
            {
                lock (myLock)
                {
                    if (instance == null)
                    {
                        instance = new UIManager();
                        
                    }
                }
                return instance;
            }

            
        }

        #endregion

        #region Attributes

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

        #endregion

        #region Properties
        public int ID
        {
            get
            {
                return id;
            }
        }
        public LoggInScreen MyLogginScreen
        {
            get { return myLoggInScreen; }
            set { myLoggInScreen = value; }
        }
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
                Utility.UpdateActivePatientLabels();
                UIManager.Instance.UpdatePrescriptionsDataGrid();
            }

        }
        public Calendar MyCalendarForm
        {
            get
            {
                return calendarForm;
            }
            set
            {
                calendarForm = value;
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

        #endregion

        #region Call Forms Methods

        internal void ShowRegisterNewPatientForm()
        {
            registerNewPatientForm = new RegisterNewPatientForm();
            registerNewPatientForm.ShowDialog();
        }

        public void CallLoginScreen()
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

        internal void showCalendar()
        {
            calendarForm = new Calendar();
            calendarForm.ShowDialog();
        }

        #endregion

        #region Update Methods

        internal void UpdatePrescriptionsDataGrid()
        {
            if (ActivePatient != null)
            {
                mainForm.PrescriptionsGrid.DataSource = LoadPrescriptions(ActivePatient.PatientId).Tables[0];

            }
            else
            {
                mainForm.PrescriptionsGrid.DataSource = LoadPrescriptions().Tables[0];

            }
            

        }

        internal DataSet GetComboBoxDs(string selectedDate, string selectedTIme)
        {
            BookAppointmentForm.StffComboBox.Items.Clear();
            DataSet ds;
            if (bookAppointmentForm.DatePicker.Checked)
            {
                if (bookAppointmentForm.TimePicker.Checked) //both checked
                {


                    ds = UIManager.instance.LoadShiftsIdByDateTime(selectedDate, selectedTIme);
                }
                else //only date checked
                {
                    ds = UIManager.instance.LoadShiftsIdByDate(selectedDate);
                }
            }
            else
            {
                if (bookAppointmentForm.TimePicker.Checked) //only time checked
                {
                    ds = UIManager.instance.LoadShiftsIdByTime(selectedTIme);
                }
                else //none checked
                {
                    ds = UIManager.instance.LoadShiftsIdDistinct();
                }
            }


            return ds;

        }

        internal void UpdateShiftsDataGrid()
        {

            if (BookAppointmentForm.StffComboBox.SelectedItem != null)
            {
                if (bookAppointmentForm.DatePicker.Checked)
                {

                    if (bookAppointmentForm.TimePicker.Checked) //staff+date+time
                    {
                        BookAppointmentForm.ShiftsGrid.DataSource = 
                            LoadShifts(new Date(BookAppointmentForm.DatePicker.Value.ToString("yyyy_MM_dd")), 
                            new Time(BookAppointmentForm.TimePicker.Value.ToString("HH_mm")), 
                            BookAppointmentForm.StffComboBox.SelectedItem.ToString()).Tables[0];
                    }
                    else //staff+date
                    {
                        BookAppointmentForm.ShiftsGrid.DataSource = 
                            LoadShifts(new Date(BookAppointmentForm.DatePicker.Value.ToString("yyyy_MM_dd")), 
                            BookAppointmentForm.StffComboBox.SelectedItem.ToString()).Tables[0];
                    }
                }
                else
                {
                    if (bookAppointmentForm.TimePicker.Checked) //staff+time
                    {
                        BookAppointmentForm.ShiftsGrid.DataSource = 
                            LoadShifts(new Time(BookAppointmentForm.TimePicker.Value.ToString("HH_mm")), 
                            BookAppointmentForm.StffComboBox.SelectedItem.ToString()).Tables[0];
                    }
                    else //staff
                    {
                        BookAppointmentForm.ShiftsGrid.DataSource = 
                            LoadShifts(BookAppointmentForm.StffComboBox.SelectedItem.ToString()).Tables[0];
                    }
                }
            }
            else
            {
                if (bookAppointmentForm.DatePicker.Checked)
                {

                    if (bookAppointmentForm.TimePicker.Checked) //date+time
                    {
                        BookAppointmentForm.ShiftsGrid.DataSource = 
                            LoadShifts(new Date(BookAppointmentForm.DatePicker.Value.ToString("yyyy_MM_dd")), 
                            new Time(BookAppointmentForm.TimePicker.Value.ToString("HH_mm"))).Tables[0];
                    }
                    else //date
                    {
                        BookAppointmentForm.ShiftsGrid.DataSource = 
                            LoadShifts(new Date(BookAppointmentForm.DatePicker.Value.ToString("yyyy_MM_dd"))).Tables[0];
                    }
                }
                else
                {
                    if (bookAppointmentForm.TimePicker.Checked) //time
                    {
                        UIManager.instance.BookAppointmentForm.ShiftsGrid.DataSource = 
                            LoadShifts(new Time(BookAppointmentForm.TimePicker.Value.ToString("HH_mm"))).Tables[0];
                    }
                    else //none
                    {
                        UIManager.instance.BookAppointmentForm.ShiftsGrid.DataSource = LoadShifts().Tables[0];
                    }
                }
            }
        }

        internal void InstantiateAppointment(string appointmentID)
        {

            DataSet ds = LoadAppointment(appointmentID);
            try
            {
                UIManager.Instance.chosenAppointment = new Appointment(ds);

            }
            catch
            {
                MessageBox.Show("Appointment Data Corrupted");
            }
        }

        internal void SubmitAppointmentRequest()
        {
            string stffID = BookAppointmentForm.StffComboBox.SelectedItem.ToString();
            string patientID = ActivePatient.PatientId;
            string appointmentDate = "";
            string appointmentTime = "";

            if (BookAppointmentForm.DatePicker.Checked == true)
            {
                if (BookAppointmentForm.TimePicker.Checked == true)//both
                {
                    appointmentDate = BookAppointmentForm.DatePicker.Value.ToString("yyyy_MM_dd");
                    appointmentTime = BookAppointmentForm.TimePicker.Value.ToString("HH_mm");
                    InsertFull(appointmentDate, appointmentTime, stffID, patientID);

                    MessageBox.Show("Appointment booked successfully!");
                    Form.ActiveForm.Close();
                }
                else//only date
                {
                    OnlyDateInsert(stffID);
                }
            }
            else//only time
            {
                OnlyTimeInsert(stffID);
            }
        }

        
        private void OnlyTimeInsert(string stffID)
        {
            Date appointmentDate = new Date(DateTime.Now.ToString("yyyy_MM_dd"));
            Time appointmentTime = new Time(BookAppointmentForm.TimePicker.Value.ToString("HH_mm"));
            int  counter = 0;
            bool found = false;
            Appointment newAppointment = null;
            List<Appointment> temp = new List<Appointment>();
            DataSet ds = new DataSet();
            


        
            do
            {

                ds = LoadAppointment(appointmentDate, appointmentTime, stffID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    appointmentDate.Day = appointmentDate.Day + 1;
                }
                else
                {
                    
                    counter = 15;
                    found = true;
                }

            }
            while (counter < 15);
            if (found == false)
            {
                MessageBox.Show("Chosen day is completelly booked");
            }
            else
            {
                DialogResult dl = MessageBox.Show(String.Format
                    ("You have not selected a time, therefore you appointment will be booked for the first available day, which is:{0}{1}.",
                            Environment.NewLine, appointmentDate.ToString()), "Attention!", MessageBoxButtons.YesNo);
                if (dl == DialogResult.Yes)
                {
                    try
                    {
                        InsertFull(appointmentDate.ToString(), appointmentTime.ToString(), stffID, activePatient.PatientId);
                        MessageBox.Show("Appointment booked successfully!");
                        Form.ActiveForm.Close();

                    }
                    catch (Exception e)
                    {
                        Logger.Instance.WriteLog(Logger.Type.Exception, new Message(e, "Trying to find appointment slot, and save it to the db."), UIManager.Instance.id.ToString());
                        throw;
                    }
                }
                else
                {
                    Form.ActiveForm.Close();
                }
            }
        }

        private void OnlyDateInsert(string stffID) 
        {
            string appointmentDate = BookAppointmentForm.DatePicker.Value.ToString("yyyy_MM_dd");
            string appointmentTime = "";
            
            Appointment newAppointment = null;
            bool check = false;
            List<Appointment> temp = new List<Appointment>();
            Date reqDate = new Date(appointmentDate);
            Time nowTime = new Time(DateTime.Now.ToString("HH_mm"));

            Date nowDate = new Date(DateTime.Now.ToString("yyyy_MM_dd"));
            DataSet shiftDs = LoadShifts(reqDate ,stffID);
            Time startLook = new Time(shiftDs.Tables[0].Rows[0][2].ToString());
            Time endLook = new Time(shiftDs.Tables[0].Rows[0][3].ToString());

            if(nowDate.ToString() == reqDate.ToString())
            {
                startLook = nowTime;
            }

            DataSet appointmentsDs = LoadAppointment(new Date(appointmentDate), stffID);
            if (appointmentsDs.Tables[0].Rows.Count > 0)
            {
                
                foreach (DataRow dr in appointmentsDs.Tables[0].Rows)
                {
                    temp.Add(new Appointment(dr));
                }
                temp.OrderBy(x => x.Time.Raw);
                
                for (int i = 0; i < temp.Count; i++)
                {

                    if (i == 0)
                    {
                        int mydif = temp[i].Time - startLook;
                        if (mydif >= 30)//we just need to fit the new appointment
                        {
                            appointmentTime = startLook.ToString();
                            newAppointment = new Appointment(activePatient.PatientId, stffID, appointmentDate, appointmentTime);
                            check = true;
                            i = temp.Count;
                        }
                    }

                    else if (i == temp.Count)
                    {
                        int mydif = endLook - temp[i].Time;
                        if (mydif >= 60)//we need to fit the appointment at temp[i].Time and the new one
                        {
                            appointmentTime = (temp[i].Time + (int)30).ToString();
                            newAppointment = new Appointment(activePatient.PatientId, stffID, appointmentDate, appointmentTime);
                            check = true;

                        }
                    }

                    else
                    {
                        int dif = temp[i + 1].Time - temp[i].Time;
                        if (dif >= 60)//30+30 in to fit both the new appointment and the one that has a start time at at tem[i].Time
                        {
                            appointmentTime = (temp[i].Time + (int)30).ToString();
                            newAppointment = new Appointment(activePatient.PatientId, stffID, appointmentDate, appointmentTime);
                            check = true;
                            i = temp.Count;
                        }
                    } 
                }
            }
            else
            {
                InsertFull(appointmentDate, startLook.ToString(), stffID, activePatient.PatientId);
                check = true;
            }

            if (check == false)
            {
                MessageBox.Show("Chosen day is completelly booked");
            }
            else
            {
                DialogResult dl = MessageBox.Show(String.Format
                    ("You have not selected a time, therefore you appointment will be booked for the first available timeslot, which is:{0}{1}.",
                            Environment.NewLine, appointmentTime), "Attention!", MessageBoxButtons.YesNo);
                if (dl == DialogResult.Yes)
                {
                    try
                    {
                        InsertFull(appointmentDate, newAppointment.AppointmentTime, stffID, activePatient.PatientId);
                        MessageBox.Show("Appointment booked successfully!");
                        Form.ActiveForm.Close();

                    }
                    catch (Exception e)
                    {
                        Logger.Instance.WriteLog(Logger.Type.Exception, new Message(e, "Trying to find appointment slot, and save it to the db."), UIManager.Instance.id.ToString());
                        throw;
                    }
                }
                else
                {
                    Form.ActiveForm.Close();
                }
            }

        }
    


        internal void showFindPatientForm()
        {
            findPatientForm = new FindPatient();
            findPatientForm.ShowDialog();
        }

        internal void ShowBookAppointmentForm()
        {
            bookAppointmentForm = new BookAppointmentForm();
            bookAppointmentForm.ShowDialog();
        }

        internal bool ConfirmSearchPatientClick(string name, string postcode, string dOb)
        {
            DataSet ds = LoadPatient(name, postcode, dOb);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.ActivePatient = new Patient(ds);
                return true;
            }
            else return false;

        }

        internal bool ConfirmSearchPatientClick(string id)
        {
            int myId;
            if (Int32.TryParse(id, out myId))
            {
                DataSet ds = UIManager.instance.LoadPatient(id);
                if (Utility.CheckFind(ds))
                {
                    UIManager.Instance.ActivePatient = new Patient(ds);
                    return true;
                }
                else return false;
            }
            else return false;

        }

        public bool ClickLogIn(string userName, string password)
        {
            DataSet ds = LoadUser(userName, password);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.activeUser = new User(ds);
                return true;
            }
            else return false;

        }


        #endregion

        #region GetDataset Methods

        internal DataSet LoadPatient(string id)
        {
            string sql = @"SELECT * FROM Patients WHERE Id = '" + id + "'";
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        internal DataSet LoadPatient(string name, string postcode, string dob)
        {
            string sql = @"SELECT * FROM Patients WHERE PatientName = '" + name + "'AND Address = '" + postcode + "'AND dateOfBirth = '" + dob + "'";
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }




        internal DataSet LoadMedNameAndNotes(string medID)
        {
            
            string sql = @"SELECT MedName, Notes  FROM Meds WHERE Id = '" + medID + "'";

            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }



        private DataSet LoadPrescriptions(string id)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM PatientsMeds WHERE PatientID = '" + id + "' ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        private DataSet LoadPrescriptions()
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM  PatientsMeds ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }



        public DataSet LoadShiftsIdForTime(string selectedTIme)
        {
            Time t = new Time(selectedTIme); //TO DO: Read the duration of each appointment from the file to allow non constant durations
            t.Minutes += 29;
            string selectedTimePlusDuration = t.ToString();
            string sql = @"SELECT StaffID FROM Shifts WHERE StartTime <=  '" + selectedTIme + "' AND FinishTime >= '" + selectedTimePlusDuration + "'";


            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }




        private DataSet LoadShifts(Time selectedTime)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE StartTime <= '" + selectedTime.ToString() + "' AND FinishTime >= '" + selectedTime.ToString() + "' ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        private DataSet LoadShifts(Date selectedDate)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE Date = '" + selectedDate.ToString() + "' ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        private DataSet LoadShifts(string staffID)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE StaffId = '" + staffID + "' ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        private DataSet LoadShifts(Date selectedDate, Time selectedTime)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE Date = '" + selectedDate.ToString()
                + "' AND StartTime <= '" + selectedTime.ToString() + "' AND FinishTime >= '" + selectedTime.ToString() + "' ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        private DataSet LoadShifts(Time selectedTime, string staffID)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE StartTime <= '" + selectedTime.ToString() + "' AND FinishTime >= '" + selectedTime.ToString() + "' AND StaffId = '" + staffID + "' ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        private DataSet LoadShifts(Date selectedDate, string staffID)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE Date = '" + selectedDate.ToString() + "' AND StaffId = '" + staffID + "' ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        private DataSet LoadShifts(Date selectedDate, Time selectedTime, string staffID)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE Date = '" + selectedDate.ToString() +
                "' AND StartTime <= '" + selectedTime.ToString() + "' AND FinishTime >= '" + 
                selectedTime.ToString() + "' AND StaffId = '" + staffID + "' ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        private DataSet LoadShifts()
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);

            return ds;
        }
           





        private DataSet LoadShiftsIdDistinct ()
        {
            string sql = @"SELECT DISTINCT StaffID FROM Shifts";
            
            return DBManager.getDBConnectionInstance().getDataSet(sql);

        }






        public DataSet LoadShiftsIdByDate(string selectedDate)
        {
            //This statement grabs all StaffIds that are on duty during selected date
            string sql = @"SELECT StaffID FROM Shifts WHERE Date = '" + selectedDate + "'";

            return  DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        /// <summary>
        ///  The sql grabs all the StaffIds from the Shifts table that have a 
        ///  starting time earlier than the selected time and 
        ///  finish time later than the selected time
        ///  and selected date equal to the selected date
        ///  Then it excludes from them, those IDs that have an appointment already booked for the selected date AND time
        /// </summary>
        /// <param name="selectedDate"></param>
        /// <param name="selectedTime"></param>
        /// <returns></returns>
        public DataSet LoadShiftsIdByDateTime(string selectedDate, string selectedTime)
        {
            Time t = new Time(selectedTime); //TO DO: Read the duration of each appointment from the file to allow non constant durations
            t.Minutes += 29;
            string selectedTimePlusDuration = t.ToString();
            t.Minutes -= 58;
            string selectedTimeMinusDuration = t.ToString();

            string sql = @"SELECT StaffID FROM Shifts WHERE Date = '" + selectedDate + "' AND StartTime <=  '" + selectedTime + "' AND FinishTime >= '"  + "' EXCEPT SELECT StaffID FROM Appointments WHERE AppointmentDate = '" + selectedDate + "'AND AppointmentTime >= '" + selectedTimeMinusDuration + "'AND AppointmentTime <= '" + selectedTimePlusDuration + "'";


            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        private DataSet LoadShiftsIdByTime(string time)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT DISTINCT StaffID FROM Shifts WHERE StartTime <= '" + time + "' AND FinishTime >= '" + time + "' ";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }





        internal DataSet CalendarDataset(string selectedDate)
        {
            string sql = @"SELECT DISTINCT a.ID, a.AppointmentTime, s.StaffMemberName, p.PatientName FROM Appointments a INNER JOIN StaffMembers s on a.StaffID = s.Id INNER JOIN Patients p on a.PatientID = p.Id WHERE a.AppointmentDate = '" + selectedDate + "'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        internal DataSet InsertFull(string appointmentDate, string appointmentTime, string stffID, string patientID)
        {
            string sql = @"INSERT INTO Appointments (AppointmentDate, AppointmentTime, StaffID, PatientID, Duration) VALUES  ( '" + appointmentDate + "', '" + appointmentTime + "', '" + stffID + "', '" + patientID + "', 30)";
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        internal DataSet LoadAppointment(string id)
        {
            string sql = @"SELECT * FROM Appointments WHERE ID = '" + id + "'";
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        private DataSet LoadAppointment(Date date, string stffID)
        {
            string sql;
            Time now = new Time(DateTime.Now.ToString("HH_mm"));

            if (date.ToString() != DateTime.Now.ToString("yyyy_MM_dd"))
            {
                 sql = @"SELECT * FROM Appointments WHERE AppointmentDate = '" + date.ToString() + "' AND StaffId = '" + stffID + "'";
            }
            else
            {
                sql = @"SELECT * FROM Appointments WHERE AppointmentDate = '" + date.ToString() + "' AND StaffId = '" + stffID + "' AND AppointmentTime >= '" + (now.Minutes-30) + "'";

            }
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        private DataSet LoadAppointment(Date date, Time time, string stffID)
        {
            Time minus = time;
            minus.Minutes = minus.Minutes - 30;
            Time plus = time;
            plus.Minutes = plus.Minutes + 30;

            string sql;
            sql = @"SELECT StaffID FROM Appointments WHERE AppointmentDate = '" + date.ToString() + "' AND StaffId = '" + stffID + "' AND AppointmentTime >= '" + minus.ToString() + "' AND AppointmentTime <= '" + plus.ToString() + "' INTERSECT SELECT StaffID FROM Shifts WHERE StartTime <= '" + time.ToString() + "' AND FinishTime >= '" + time.ToString() + "' AND StaffId = '" + stffID + "'";
            
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }


        private DataSet LoadAppointment(Date date)
        {
            string sql = @"SELECT * FROM Appointments WHERE AppointmentDate = '" + date.ToString() + "'";
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }





        internal DataSet LoadUser(string username, string password)
        {
            string sql = @"SELECT * FROM Users WHERE Username = '" + username + "'AND Password = '" + password + "'";
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }





        internal void DeleteAppointment()
        {
            if (chosenAppointment != null)
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
            if (!ConfirmSearchPatientClick(patientName, postcode, dob))
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

        internal void ExtendPrescrption(string medID, string patientID, string extendDate)
        {

            DataSet ds = new DataSet();
            string sql = @"UPDATE PatientsMeds SET ExtentionDate = '" + extendDate + "' WHERE MedId = '" + medID + "' AND PatientID = '" + patientID + "'";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);

        }

        internal void DeleteExtention(string medID, string patientId)
        {
            DataSet ds = new DataSet();
            string sql = @"UPDATE PatientsMeds SET ExtentionDate = NULL WHERE MedId = '" + medID + "' AND PatientID = '" + patientId + "'";

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
        }
        #endregion

        #region Events Methods

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCancel(e);
            Logger.Instance.WriteLog(Logger.Type.Flow, new Message("Form Was closed"), id.ToString());
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
                Utility.SwapVisibility();
                activeUser = null;
                ActivePatient = null;
                chosenAppointment = null;
                //Utility.UpdateActivePatientLabels();
                
                
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

        #endregion

    }
    #endregion
}
