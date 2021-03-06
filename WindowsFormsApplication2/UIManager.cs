﻿using System;
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
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Exception, new Message(e, "Error while searching for the run ID, inside the constructor")));
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
        private Appointment newAppointment; //created for testing purposes

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
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Updated active patient labels and grid")));

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

        public Appointment NewAppointment
        {
            get { return newAppointment; }
            set { newAppointment = value; }
        }

        #endregion

        #region Call Forms Methods

        public void ShowRegisterNewPatientForm()
        {
            registerNewPatientForm = new RegisterNewPatientForm();
            registerNewPatientForm.ShowDialog();
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Showed Register Patient Form.")));

        }

        /// <summary>
        /// Subscribes the Form_Closing Event to both the log ine screen and the main menu, which pop the messagebox when the user tries to close the form
        /// Makes the login screen invisible, and requests the application to run the LogInScreen form, initiating the visuals.
        /// </summary>
        public void CallLoginScreen()
        {
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Call Log In Screen Form.")));
            myLoggInScreen.FormClosing += Form_FormClosing;
            
            mainForm.Visible = false;
            mainForm.FormClosing += Form_FormClosing;
           
            Application.Run(myLoggInScreen);

        }

        /// <summary>
        /// Instantiates the register new user form and shows the dialog
        /// </summary>
        public void ShowRegisterNewUserForm()
        {
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Call Register new user form.")));
            registerNewUserForm = new RegisterNewUser();
            registerNewUserForm.ShowDialog();

        }

        public void showCalendar()
        {
            calendarForm = new Calendar();
            calendarForm.ShowDialog();

            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Call Calendar Form.")));

        }

        #endregion

        #region Update Methods

        public void UpdatePrescriptionsDataGrid()
        {
            if (ActivePatient != null)
            {
                mainForm.PrescriptionsGrid.DataSource = LoadPrescriptions(ActivePatient.PatientId).Tables[0];

            }
            else
            {
                mainForm.PrescriptionsGrid.DataSource = LoadPrescriptions().Tables[0];

            }

            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Prescriptions grid update.")));

        }

        public DataSet GetComboBoxDs(string selectedDate, string selectedTIme)
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

            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Combo box options method run.")));

            return ds;

        }

        public void UpdateShiftsDataGrid()
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

            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Shifts grid update.")));

        }

        public void InstantiateAppointment(string appointmentID)
        {

            DataSet ds = LoadAppointment(appointmentID);
            try
            {
                UIManager.Instance.chosenAppointment = new Appointment(ds);

            }
            catch (Exception e)
            {
                MessageBox.Show("Appointment Data Corrupted");
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Exception, new Message(e, "On appointment instanistiation")));

            }
        }

        public void SubmitAppointmentRequest()
        {
            try
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
                        string appointmentDate1 = BookAppointmentForm.DatePicker.Value.ToString("yyyy_MM_dd");
                        OnlyDateInsert(stffID, appointmentDate1);
                    }
                }
                else
                {
                    Time appointmentTime1 = new Time(BookAppointmentForm.TimePicker.Value.ToString("HH_mm"));
                    OnlyTimeInsert(stffID, appointmentTime1, new Date(DateTime.Now.ToString("yyyy_MM_dd")));

                }
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Appoinment Requesting method finished")));

            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Exception, new Message(e, "Trying to submit request for appointment")));

            }
        }




        public void OnlyTimeInsert(string stffID, Time appointmentTime, Date appointmentDate)
        {
            try
            {

                
                int counter = 0;
                bool found = false;
                newAppointment = null;
                List<Appointment> temp = new List<Appointment>();
                DataSet ds = new DataSet();




                do
                {
                    counter++;
                    ds = LoadAppointment(appointmentDate, appointmentTime, stffID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        appointmentDate.Day = appointmentDate.Day + 1;
                    }
                    else
                    {

                        if(Utility.CheckFind(LoadShiftsByDateTimeID(appointmentDate, appointmentTime, stffID)))
                        {
                            counter = 15;
                            found = true;
                        }
                        else
                        {
                            appointmentDate.Day = appointmentDate.Day + 1;
                        }

                    }

                }
                while (counter < 15);
                if (found == false)
                {
                    MessageBox.Show("Chosen time is completelly booked over the next 2 weeks");
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
                            NewAppointment = new Appointment(ActivePatient.PatientId, stffID, appointmentDate.ToString(), appointmentTime.ToString());
                            Form.ActiveForm.Close();

                        }
                        catch (Exception e)
                        {
                            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Exception, new Message(e, "Trying to find appointment slot, and save it to the db.")));
                            throw;
                        }
                    }
                    else
                    {
                        Form.ActiveForm.Close();
                    }
                }
            }
            catch(Exception e)
            {
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Exception, new Message(e, "Requesting to book by time only bug")));

            }
        }

        public void OnlyDateInsert(string stffID, string appointmentDate)
        {
            try
            {


                string appointmentTime = "";
                NewAppointment = null;
                bool check = false;
                List<Appointment> temp = new List<Appointment>();
                Date reqDate = new Date(appointmentDate);
                Time nowTime = new Time(DateTime.Now.ToString("HH_mm"));

                Date nowDate = new Date(DateTime.Now.ToString("yyyy_MM_dd"));
                DataSet shiftDs = LoadShifts(reqDate, stffID);
                Time startLook = new Time(shiftDs.Tables[0].Rows[0][2].ToString());
                Time endLook = new Time(shiftDs.Tables[0].Rows[0][3].ToString());

                if (nowDate.Raw == reqDate.Raw)
                {
                    if (nowTime.Raw > startLook.Raw && nowTime.Raw < endLook.Raw)
                        startLook = nowTime;
                    else if (nowTime.Raw > endLook.Raw)
                    {
                        startLook = endLook;
                    }
                }

                DataSet appointmentsDs = LoadAppointment(new Date(appointmentDate), stffID);
                if (appointmentsDs.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in appointmentsDs.Tables[0].Rows)
                    {
                        temp.Add(new Appointment(dr));
                    }
                    temp.OrderBy(x => x.Time.Raw);

                    for (int i = 0; i <= temp.Count; i++)
                    {

                        if (i == 0)
                        {
                            int mydif = temp[i].Time - startLook;
                            if (mydif >= 30)//we just need to fit the new appointment
                            {
                                appointmentTime = startLook.ToString();
                                NewAppointment = new Appointment(activePatient.PatientId, stffID, appointmentDate, appointmentTime);
                                check = true;
                                i = temp.Count;
                            }
                        }

                        else if (i == temp.Count)
                        {
                            int mydif = endLook - temp[i - 1].Time;
                            if (mydif >= 60)//we need to fit the appointment at temp[i].Time and the new one
                            {
                                appointmentTime = (temp[i-1].Time + (int)30).ToString();
                                NewAppointment = new Appointment(activePatient.PatientId, stffID, appointmentDate, appointmentTime);
                                check = true;

                            }
                        }

                        else
                        {
                            int dif = temp[i].Time - temp[i - 1].Time;
                            if (dif >= 60)//30+30 in to fit both the new appointment and the one that has a start time at at tem[i].Time
                            {
                                appointmentTime = (temp[i - 1].Time + (int)30).ToString();
                                NewAppointment = new Appointment(activePatient.PatientId, stffID, appointmentDate, appointmentTime);
                                check = true;
                                i = temp.Count;
                            }
                        }
                    }
                }
                else
                {
                    NewAppointment = new Appointment(activePatient.PatientId, stffID, appointmentDate, startLook.ToString());

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
                                Environment.NewLine, NewAppointment.AppointmentTime), "Attention!", MessageBoxButtons.YesNo);
                    if (dl == DialogResult.Yes)
                    {


                        InsertFull(appointmentDate, NewAppointment.AppointmentTime, stffID, activePatient.PatientId);
                        MessageBox.Show("Appointment booked successfully!");
                        Form.ActiveForm.Close();


                    }
                    else
                    {
                        Form.ActiveForm.Close();
                    }
                }

            }
            catch(Exception e)
            {
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Exception, new Message(e, "Requesting to book by date only bug")));

            }
        }


        public void showFindPatientForm()
        {
            findPatientForm = new FindPatient();
            findPatientForm.ShowDialog();

            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Showed Find Patient form")));

        }

        public void ShowBookAppointmentForm()
        {
            bookAppointmentForm = new BookAppointmentForm();
            bookAppointmentForm.ShowDialog();

            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Showed book appoinment form")));

        }

        /// <summary>
        /// Looks for a patient matching the parameters, returns true if it finds one, false if it finds 0 or many,
        /// </summary>
        /// <param name="name"></param>
        /// <param name="postcode"></param>
        /// <param name="dOb"></param>
        /// <returns></returns>
        public bool ConfirmSearchPatientClick(string name, string postcode, string dOb)
        {
            DataSet ds = LoadPatient(name, postcode, dOb);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.ActivePatient = new Patient(ds);
                return true;
            }
            else return false;

        }

        public bool ConfirmSearchPatientClick(string id)
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

        /// <summary>
        /// Checks if the user exists in the database
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ClickLogIn(string userName, string password)
        {
            DataSet ds = LoadUser(userName, password);
            if (Utility.CheckFind(ds))
            {
                UIManager.Instance.ActiveUser = new User(ds);
                return true;
            }
            else return false;

        }


        #endregion

        #region GetDataset Methods

        public DataSet LoadPatient(string id)
        {
            string sql = @"SELECT * FROM Patients WHERE Id = '" + id + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            return DBManager.getDBConnectionInstance().getDataSet(sql);


        }

        public DataSet LoadPatient(string name, string postcode, string dob)
        {
            string sql = @"SELECT * FROM Patients WHERE PatientName = '" + name + "'AND Address = '" + postcode + "'AND dateOfBirth = '" + dob + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }




        public DataSet LoadMedNameAndNotes(string medID)
        {
            
            string sql = @"SELECT MedName, Notes  FROM Meds WHERE Id = '" + medID + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }



        public DataSet LoadPrescriptions(string id)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM PatientsMeds WHERE PatientID = '" + id + "' ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadPrescriptions()
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM  PatientsMeds ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }



        public DataSet LoadShiftsIdForTime(string selectedTIme)
        {
            Time t = new Time(selectedTIme); //TO DO: Read the duration of each appointment from the file to allow non constant durations
            t.Minutes += 29;
            string selectedTimePlusDuration = t.ToString();
            string sql = @"SELECT StaffID FROM Shifts WHERE StartTime <=  '" + selectedTIme + "' AND FinishTime >= '" + selectedTimePlusDuration + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));

            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }




        public DataSet LoadShifts(Time selectedTime)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE StartTime <= '" + selectedTime.ToString() + "' AND FinishTime >= '" + selectedTime.ToString() + "' ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadShifts(Date selectedDate)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE Date = '" + selectedDate.ToString() + "' ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadShifts(string staffID)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE StaffId = '" + staffID + "' ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadShifts(Date selectedDate, Time selectedTime)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE Date = '" + selectedDate.ToString()
                + "' AND StartTime <= '" + selectedTime.ToString() + "' AND FinishTime >= '" + selectedTime.ToString() + "' ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadShifts(Time selectedTime, string staffID)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE StartTime <= '" + selectedTime.ToString() + "' AND FinishTime >= '" + selectedTime.ToString() + "' AND StaffId = '" + staffID + "' ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadShifts(Date selectedDate, string staffID)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE Date = '" + selectedDate.ToString() + "' AND StaffId = '" + staffID + "' ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadShifts(Date selectedDate, Time selectedTime, string staffID)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts WHERE Date = '" + selectedDate.ToString() +
                "' AND StartTime <= '" + selectedTime.ToString() + "' AND FinishTime >= '" + 
                selectedTime.ToString() + "' AND StaffId = '" + staffID + "' ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadShifts()
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM Shifts";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);

            return ds;
        }






        public DataSet LoadShiftsIdDistinct ()
        {
            string sql = @"SELECT DISTINCT StaffID FROM Shifts";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            return DBManager.getDBConnectionInstance().getDataSet(sql);

        }






        public DataSet LoadShiftsIdByDate(string selectedDate)
        {
            //This statement grabs all StaffIds that are on duty during selected date
            string sql = @"SELECT StaffID FROM Shifts WHERE Date = '" + selectedDate + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
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

            string sql = @"SELECT StaffID FROM Shifts WHERE Date = '" + selectedDate + "' AND StartTime <=  '" + selectedTime + "' AND FinishTime >= '" 
                 + selectedTimePlusDuration + "' EXCEPT SELECT StaffID FROM Appointments WHERE AppointmentDate = '" + selectedDate + "'AND AppointmentTime >= '" + selectedTimeMinusDuration + "'AND AppointmentTime <= '" + selectedTimePlusDuration + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));

            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        public DataSet LoadShiftsIdByTime(string time)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT DISTINCT StaffID FROM Shifts WHERE StartTime <= '" + time + "' AND FinishTime >= '" + time + "' ";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadShiftsByDateTimeID(Date selectedDate, Time selectedTime, string ID)
        {
            Time t = selectedTime; //TO DO: Read the duration of each appointment from the file to allow non constant durations
            t.Minutes += 29;
            string selectedTimePlusDuration = t.ToString();
            DataSet ds=  new DataSet();

            try
            {
                string sql = @"SELECT StaffID FROM Shifts WHERE Date = '" + selectedDate.ToString() + "' AND StartTime <=  '" + selectedTime.ToString() + "' AND FinishTime >= '"
                 + selectedTimePlusDuration + "' AND StaffID = '" + ID + "'";
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
                ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }


            return ds;
        }



        public DataSet CalendarDataset(string selectedDate)
        {
            string sql = @"SELECT DISTINCT a.ID, a.AppointmentTime, s.StaffMemberName, p.PatientName 
            FROM Appointments a INNER JOIN StaffMembers s on a.StaffID = s.Id INNER JOIN Patients p on a.PatientID = p.Id 
            WHERE a.AppointmentDate = '" + selectedDate + "'";
            DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            return ds;
        }

        public DataSet InsertFull(string appointmentDate, string appointmentTime, string stffID, string patientID)
        {
            string sql = @"INSERT INTO Appointments (AppointmentDate, AppointmentTime, StaffID, PatientID, Duration) VALUES  ( '" + appointmentDate + "', '" + appointmentTime + "', '" + stffID + "', '" + patientID + "', 30)";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        public DataSet LoadAppointment(string id)
        {
            string sql = @"SELECT * FROM Appointments WHERE ID = '" + id + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        public DataSet LoadAppointment(Date date, string stffID)
        {
            string sql;
            Time now = new Time(DateTime.Now.ToString("HH_mm"));

            if (date.ToString() != DateTime.Now.ToString("yyyy_MM_dd"))
            {
                    sql = @"SELECT * FROM Appointments WHERE AppointmentDate = '" + date.ToString() + "' AND StaffId = '" + stffID + "'";
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            }
            else
            {
                    now.Minutes = now.Minutes - 30;
                    sql = @"SELECT * FROM Appointments WHERE AppointmentDate = '" + date.ToString() + "' AND StaffId = '" + stffID + "' AND AppointmentTime >= '" + now.ToString() + "'";
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));

            }
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        public DataSet LoadAppointment(Date date, Time time, string stffID)
        {
            Time minus = time;
            minus.Minutes = minus.Minutes - 30;
            Time plus = time;
            plus.Minutes = plus.Minutes + 30;
            DataSet ds = new DataSet();
            string sql;
            sql = @"SELECT StaffID FROM Appointments WHERE AppointmentDate = '" + date.ToString() + "' AND StaffId = '" + stffID + "' AND AppointmentTime >= '" + minus.ToString() + "' AND AppointmentTime <= '" + plus.ToString() + "' INTERSECT SELECT StaffID FROM Shifts WHERE StartTime <= '" + time.ToString() + "' AND FinishTime >= '" + time.ToString() + "' AND StaffId = '" + stffID + "' AND Date = '" + date.ToString() + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            try
            {
                ds = DBManager.getDBConnectionInstance().getDataSet(sql);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return ds;
        }


        public DataSet LoadAppointment(Date date)
        {
            string sql = @"SELECT * FROM Appointments WHERE AppointmentDate = '" + date.ToString() + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }

        


        /// <summary>
        /// Selects all the data from the Users table in the database, where the username AND the password
        /// is the same as the username inserted by the user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal DataSet LoadUser(string username, string password)
        {
            string sql = @"SELECT * FROM Users WHERE Username = '" + username + "'AND Password = '" + password + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
            return DBManager.getDBConnectionInstance().getDataSet(sql);
        }





        internal void DeleteAppointment()
        {
            if (chosenAppointment != null)
            {
                string sql = @"DELETE FROM Appointments WHERE Id = '" + chosenAppointment.AppointmentID + "'";
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));
                try
                {
                    DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
                    chosenAppointment = null;
                }
                catch (Exception e)
                {
                    Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Exception, new Message(e, "Error deleting")));
                }
            }
            else
            {
                MessageBox.Show("No appointmnet was selected");

            }

        }
        /// <summary>
        /// If a user matching the input data, does not exist in the database, inserts into the Users table, the appopriate values
        /// If the user is already registered, the appropriate messagebox is poped to the user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="jobTitle"></param>
        public void RegisterUser(string username, string password, string jobTitle)
        {

            if (!ClickLogIn(username, password))
            {
                string sql = @"INSERT INTO Users (Username, Password, JobTitle) VALUES ('" + username + "', '" + password + "', '" + jobTitle + "')";
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));

                try
                {
                    DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
                    MessageBox.Show("User Registered Successfully");
                }
                catch(Exception e)
                {
                    
                    Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Exception, new Message(e, "Error on registering new user")));


                }
            }
            else
            {
                MessageBox.Show("User Already exists in the database");

            }
        }

        public void RegisterPatient(string patientName, string postcode, string dob)
        {
            if (!ConfirmSearchPatientClick(patientName, postcode, dob))
            {
                string sql = @"INSERT INTO Patients (PatientName, dateOfBirth, Address) VALUES ('" + patientName + "', '" + dob + "', '" + postcode + "')";
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message("SQL= " + sql)));

                try
                {
                    DataSet ds = DBManager.getDBConnectionInstance().getDataSet(sql);
                    MessageBox.Show("Patient Registered Successfully");
                }
                catch(Exception e)
                {
                    Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Exception, new Message(e, "Error on registering new patient")));

                }
            }
            else
            {
                MessageBox.Show("Patient Already exists in the database");

            }
        }

        public void ExtendPrescrption(string medID, string patientID, string extendDate)
        {

            DataSet ds = new DataSet();
            string sql = @"UPDATE PatientsMeds SET ExtentionDate = '" + extendDate + "' WHERE MedId = '" + medID + "' AND PatientID = '" + patientID + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message(sql)));

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);

        }

        public void DeleteExtention(string medID, string patientId)
        {
            DataSet ds = new DataSet();
            string sql = @"UPDATE PatientsMeds SET ExtentionDate = NULL WHERE MedId = '" + medID + "' AND PatientID = '" + patientId + "'";
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Info, new Message(sql)));

            ds = DBManager.getDBConnectionInstance().getDataSet(sql);
        }
        #endregion

        #region Events Methods

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCancel(e);

        }

        public void logOffBut_ClickUi(EventArgs e)
        {
            const string message = "Are you sure that you would like to log out?";
            const string caption = "Log Out";
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Log off request.")));
            if (result == DialogResult.Yes)
            {
                Utility.SwapVisibility();
                ActiveUser = null;
                ActivePatient = null;
                chosenAppointment = null;
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Log off confirmed.")));


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
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Cancelled close.")));

            }
            else
            {
                myLoggInScreen.FormClosing -= Form_FormClosing;
                mainForm.FormClosing -= Form_FormClosing;
                Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Form Was closed")));
                Application.Exit();
            }
        }

        #endregion

    }
    #endregion
}
