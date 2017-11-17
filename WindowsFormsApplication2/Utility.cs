using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public struct Date
    {
        private int year;
        private int month;
        private int day;
        private int raw;


        public int Raw
        {
            get { return raw; }
            set
            {
                raw = value;

            }
        }


        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                this.Refresh(); 
            }
        }
        public int Month
        {
            get { return month; }
            set
            {
                month= value;
                this.Refresh();
            }
        }
        public int Day
        {
            get { return day; }
            set
            {
                day = value;
                this.Refresh();
            }
        }



        public Date(string time)
        {
            year = DateTime.ParseExact(time.Trim(' '), "yyyy_MM_dd", CultureInfo.InvariantCulture).Year;
            month = DateTime.ParseExact(time.Trim(' '), "yyyy_MM_dd", CultureInfo.InvariantCulture).Month;
            day = DateTime.ParseExact(time.Trim(' '), "yyyy_MM_dd", CultureInfo.InvariantCulture).Day;
            raw = year * 10000 + month * 100 + day;
        }

        
        private void Refresh()
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);

            if (this.day >= daysInMonth)
            {
                this.day = day - daysInMonth;
                this.month++;
            }
            else if (this.day < 0)
            {
                this.day = day + 365;
                this.month--;
            }
            if (this.month >= 12)
            {
                this.month = month - 12;
                this.year++;
            }
            else if (this.month < 0)
            {
                this.month = month + 12;
                this.year--;
            }
        }

        public override string ToString()
        {
            string result = "";
            if (this.year < 1000)
            {
                if(this.year < 100)
                {
                    if(this.year < 10)
                    {
                        result += "000";   
                    }
                    else
                    {
                        result += "00";
                    }
                }
                else
                {
                    result += "0";
                }
            }
            result += year;
            result += "_";

            if (this.month < 10)
            {
                if (this.day < 10)
                {
                    result += String.Format("0{0}_0{1}", this.month, this.day);
                }
                else
                {
                    result += String.Format("0{0}_{1}", this.month, this.day);
                }
            }
            else
            {
                if (this.day < 10)
                {
                    result += String.Format("{0}_0{1}", this.month, this.day);
                }
                else
                {
                    result += String.Format("{0}_{1}", this.month, this.day);
                }
            }

            return result;

        }
    }

    public struct Time
    {
        public int Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                this.Refresh();
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                minutes = value;
                this.Refresh();
            }
        }

        public int Raw
        {
            get { return raw; }
            set
            {
                raw = value;
                
            }
        }

        public int Length
        {
            get { return length; }
            set
            {
                length = value;

            }
        }


        private int hours;
        private int minutes;
        private int length;
        private int raw;

        public Time(string time)
        {
            
            hours = DateTime.ParseExact(time.Trim(' '), "HH_mm", CultureInfo.InvariantCulture).Hour;
            minutes = DateTime.ParseExact(time.Trim(' '), "HH_mm", CultureInfo.InvariantCulture).Minute;
            length = hours * 60 + minutes;
            raw = hours * 100 + minutes;
        }

        private void Refresh()
        {
            if (this.minutes >= 60)
            {
                this.minutes = minutes - 60;
                this.hours++;
            }
            else if (this.minutes < 0)
            {
                this.minutes = minutes + 60;
                this.hours--;
            }
            if (this.hours >= 24)
            {
                this.hours = hours - 24;
            }
            else if (this.hours < 0)
            {
                this.hours = hours + 24;
            }
        }

        public static int operator -(Time t1, Time t2)// substracting to to Time objects returns the time difference in minutes
        {

            Time t3 = new Time("00_00");
           
            t3.Minutes = t1.Minutes - t2.Minutes;
            t3.Hours += t1.Hours - t2.Hours;
            int timeDifference = t3.Hours * 60 + t3.Minutes;
            return timeDifference;

        }

        public static Time operator +(Time t1, int min)
        {

            t1.Minutes += min;
            return t1;

        }/// <summary>
        /// adding Time with int returns the Time after min number on minutes
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            string result = "";
            if(this.hours < 10)
            {
                if (this.minutes < 10)
                {
                    result = String.Format("0{0}_0{1}", this.hours, this.minutes);
                }
                else
                {
                    result = String.Format("0{0}_{1}", this.hours, this.minutes);
                }
            }
            else
            {
                if (this.minutes < 10)
                {
                    result = String.Format("{0}_0{1}", this.hours, this.minutes);
                }
                else
                {
                    result = String.Format("{0}_{1}", this.hours, this.minutes);
                }
            }
            return result;

        }// overide for ToString() to allow for correct string transformations of the Time struct
    }

    public struct Message// used by the logger class, basically to make string formating easier
    {
        public string message;

        public Message(Exception e, string info)
        {
            message = String.Format("{0}{1}Exception information:{1}Target Site: {2}{1}Message: {3}", info, Environment.NewLine, e.TargetSite, e.Message);
        }

        public Message(Exception e)
        {
            message = String.Format("Exception information:{1}Target Site: {2}{1}Message: {3}", Environment.NewLine, e.TargetSite, e.Message);
        }

        public Message(string info)
        {
            message = String.Format("{0}", info, Environment.NewLine);
        }
    }

    public static class Utility
    {
        public static void SwapVisibility()//swaps the visibility between Logg in screen and the main form
        {
            if (UIManager.Instance.MyLogginScreen.Visible == true)
            {
                UIManager.Instance.MyLogginScreen.Visible = false;
                UIManager.Instance.MainForm.Visible = true;
            }
            else if (UIManager.Instance.MainForm.Visible == true)
            {
                UIManager.Instance.MainForm.Visible = false;
                UIManager.Instance.MyLogginScreen.Visible = true;

            }
        }

        public static bool CheckFind(DataSet ds)// checks if a dataset contains specifically 1 row
        {

            if (ds.Tables[0].Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void UpdateActivePatientLabels()//Updates the labels for the active patient, according to the UIManager property
        {
            if (UIManager.Instance.ActivePatient != null)
            {
                UIManager.Instance.MainForm.NameLabelText = UIManager.Instance.ActivePatient.PatientName;
                UIManager.Instance.MainForm.AddressLabelTxt = UIManager.Instance.ActivePatient.PatientAddress;
                UIManager.Instance.MainForm.DoBLabelTxt = UIManager.Instance.ActivePatient.PatientDateOfBirth;
                UIManager.Instance.MainForm.IdLabelTxt = UIManager.Instance.ActivePatient.PatientId;
            }
            else
            {
                UIManager.Instance.MainForm.NameLabelText = "";
                UIManager.Instance.MainForm.AddressLabelTxt = "";
                UIManager.Instance.MainForm.DoBLabelTxt = "";
                UIManager.Instance.MainForm.IdLabelTxt = "";
            }
        }

        internal static void UpdateSubmitButton()//Updates the submit button in the book appointment form
        {
            if (UIManager.Instance.ActivePatient != null)
            {
                UIManager.Instance.BookAppointmentForm.SubmitButton.Enabled = true;// by checking if a patient is selected. 

            }
        }

        public static void ConfirmPrescriptionAction(string medID, string patientId, string extendDate)//Asks for confirmation for the extention request by showing the notes
        {
            DataSet ds = UIManager.Instance.LoadMedNameAndNotes(medID);
            string medName = ds.Tables[0].Rows[0][0].ToString();
            string notes = ds.Tables[0].Rows[0][1].ToString();
            string message = "Notes:{0} " + notes + "{0}{0}{0}{0}Confirm and Authorise prescription extention?";
            DialogResult answer = MessageBox.Show(string.Format(message, Environment.NewLine), medName, MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                UIManager.Instance.ExtendPrescrption(medID, patientId, extendDate);
            }

        }

       
    }
}
