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
            year = DateTime.ParseExact(time, "yyyy_MM_dd", CultureInfo.InvariantCulture).Year;
            month = DateTime.ParseExact(time, "yyyy_MM_dd", CultureInfo.InvariantCulture).Month;
            day = DateTime.ParseExact(time, "yyyy_MM_dd", CultureInfo.InvariantCulture).Day;
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

        private int hours;
        private int minutes;
        private int length;

        public Time(string time)
        {
            hours = DateTime.ParseExact(time, "HH_mm", CultureInfo.InvariantCulture).Hour;
            minutes = DateTime.ParseExact(time, "HH_mm", CultureInfo.InvariantCulture).Minute;
            length = hours * 60 + minutes;
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

        public static int operator -(Time t1, Time t2)
        {

            Time t3 = new Time("00_00");
            if (t2.length > t1.length)
            {
                Time t4 = t1;
                t1 = t2;
                t2 = t4;
            }
            t3.Minutes = t1.Minutes - t2.Minutes;
            t3.Hours += t1.Hours - t2.Hours;
            int timeDifference = t3.Hours * 60 + t3.Minutes;
            return timeDifference;

        }
    }

    public static class Utility
    {
        public static void SwapVisibility()
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

        internal static void UpdateSubmitButton()
        {
            if (UIManager.Instance.ActivePatient != null)
            {
                UIManager.Instance.BookAppointmentForm.SubmitButton.Enabled = true;
            }
        }

        public static void ConfirmPrescriptionAction(string medID, string patientId, string extendDate)
        {
            string medName = UIManager.Instance.LoadNotes(medID).Tables[0].Rows[0][0].ToString();
            string notes = UIManager.Instance.LoadNotes(medID).Tables[0].Rows[0][1].ToString();
            string message = "Notes:{0} " + notes + "{0}{0}{0}{0}Confirm and Authorise prescription extention?";
            DialogResult answer = MessageBox.Show(string.Format(message, Environment.NewLine), medName, MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                UIManager.Instance.ExtendPrescrption(medID, patientId, extendDate);
            }

        }
    }
}
