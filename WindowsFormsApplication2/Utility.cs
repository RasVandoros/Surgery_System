using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
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
