using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication2;

namespace Over_Surgery_Unit_Tests
{
    [TestClass]
    public class UserStory3Tests
    {


        /// <summary>
        /// This method tests the whether the combo box gets the correct dataset when clicked, with both date and time pickers checked.
        /// The date and time passed has shifts allocated to only 1 staff member, and no appointment collides with the requested time, 
        /// therefore, his ID only is expected to show up.
        /// </summary>
        [TestMethod]
        public void DateTimeComboBoxDs()
        {
            //arrange
            int expected = 1;
            int actual;
            string selectedDate = "2017_11_03";
            string selectedTime = "09_00";

            //act
            UIManager.Instance.BookAppointmentForm = new BookAppointmentForm();
            UIManager.Instance.BookAppointmentForm.DatePicker = new System.Windows.Forms.DateTimePicker();
            UIManager.Instance.BookAppointmentForm.DatePicker.Checked = true;

            UIManager.Instance.BookAppointmentForm.TimePicker = new System.Windows.Forms.DateTimePicker();
            UIManager.Instance.BookAppointmentForm.TimePicker.Checked = true;

            actual = UIManager.Instance.GetComboBoxDs(selectedDate, selectedTime).Tables[0].Rows.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This method tests the whether the combo box gets the correct dataset when clicked, with ony the date picker checked.
        /// The date  passed has shifts allocated to 2 staff members, and the the shift is not booked out. Both IDs are expected to show up.
        /// </summary>
        [TestMethod]
        public void DateComboBoxDs()
        {
            //arrange
            int expected = 2;
            int actual;
            string selectedDate = "2017_11_03";
            string selectedTime = "13_00";

            //act
            UIManager.Instance.BookAppointmentForm = new BookAppointmentForm();
            UIManager.Instance.BookAppointmentForm.DatePicker.Checked = true;
            UIManager.Instance.BookAppointmentForm.TimePicker.Checked = false;

            actual = UIManager.Instance.GetComboBoxDs(selectedDate, selectedTime).Tables[0].Rows.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// This method tests the OnlyDateInsert in the UIMananager. Staff Id 1, has a 09_00 - 17_00 shift on the 17th of november
        /// and appointments already booked at 09_00 and 10_00. Therefore the algorith is expected to determine that the new appointment 
        /// should be at 9.30.
        /// </summary>
        [TestMethod]
        public void TestNewBookingOnDate()
        {
            //arrange
            string pID = "2";
            string stID = "1";
            string apDate = "2017_11_17";
            string apTime = "09_30";
            Appointment expected = new Appointment(pID, stID, apDate, apTime);

            //act
            UIManager.Instance.ActivePatient = new Patient(UIManager.Instance.LoadPatient("2"));
            UIManager.Instance.OnlyDateInsert(stID, apDate);
            Appointment actual = UIManager.Instance.NewAppointment;


            //assert
            Assert.AreEqual(expected.AppointmentDate, actual.AppointmentDate);
            Assert.AreEqual(expected.AppointmentTime, actual.AppointmentTime);
            Assert.AreEqual(expected.PatientID, actual.PatientID);

        }



        /// <summary>
        /// This method tests the OnlyTime insert in the UIMananager. Staff Id 1, has a 09_00 - 17_00 shift on the 17th, 18th and the 19th of november
        /// and appointments already booked at 09_00 on the first two. Therefore the algorith is expected to determine that the new appointment 
        /// should be on the first available day that has a shift and no appointment booked at the time, which is the 19th.
        /// </summary>
        [TestMethod]
        public void TestNewBookingOnTime()
        {
            //arrange
            string pID = "2";
            string stID = "1";
            string nowDate = "2017_11_17";
            string expDate = "2017_11_19";
            string apTime = "09_00";
            Appointment expected = new Appointment(pID, stID, expDate, apTime);

            //act
            UIManager.Instance.ActivePatient = new Patient(UIManager.Instance.LoadPatient("2"));
            UIManager.Instance.OnlyTimeInsert(stID, new Time(apTime), new Date(nowDate));
            Appointment actual = UIManager.Instance.NewAppointment;


            //assert
            Assert.AreEqual(expected.AppointmentDate, actual.AppointmentDate);
            Assert.AreEqual(expected.AppointmentTime, actual.AppointmentTime);
            Assert.AreEqual(expected.PatientID, actual.PatientID);

        }

    }
}