using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Globalization;

namespace WindowsFormsApplication2
{
    #region
    public partial class MainForm : Form
    {
        #region properties
        public string IdLabelTxt
        {
            set
            {
                idTxt.Text = value;
            }
        }

        public DataGridView PrescriptionsGrid
        {
            get { return prescriptions; }
            set { prescriptions = value; }
        }

        public string NameLabelText
        {
            set
            {
                nameTxt.Text = value;
            }
        }

        public string DoBLabelTxt
        {
            set
            {
                dobTxt.Text = value;
            }
        }

        public string AddressLabelTxt
        {
            set
            {
                addressTxt.Text = value;
            }
        }

        public bool RegisterNewUserVisibility
        {
            set
            {
                registerNewUserButton.Visible = value;
            }
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();

        }

        #region Events

        private void MainMenu_Load(object sender, EventArgs e)
        {

            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            foreach (Control c in this.Controls)
            {
                c.Anchor = AnchorStyles.None;
            }
            if (UIManager.Instance.ActiveUser.Job != Job.Manager)
            {
                registerNewUserButton.Visible = false;
            }
            UIManager.Instance.UpdatePrescriptionsDataGrid();

            prescriptions.AutoResizeColumns();

            foreach (DataGridViewColumn c in prescriptions.Columns)
            {
                c.ReadOnly = true;
            }
            prescriptions.Columns[4].ReadOnly = false;

        }

        private void emptyActivePatButton_Click(object sender, EventArgs e)
        {
            UIManager.Instance.ActivePatient = null;
            UIManager.Instance.UpdatePrescriptionsDataGrid();
            Utility.UpdateActivePatientLabels();
        }
        private void logOffBut_Click(object sender, EventArgs e)
        {
            UIManager.Instance.logOffBut_ClickUi(e);
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            UIManager.Instance.showCalendar();
        }

        private void findPatient_Click(object sender, EventArgs e)
        {
            UIManager.Instance.showFindPatientForm();

        }

        private void registerNewPatientButton_Click(object sender, EventArgs e)
        {
            UIManager.Instance.ShowRegisterNewPatientForm();
        }

        private void registerNewUserButton_Click(object sender, EventArgs e)
        {
            UIManager.Instance.ShowRegisterNewUserForm();
        }

        private void OnPrescriptionGridDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (row >= 0)
            {
                if (col == 0)
                {
                    
                    string selectedMedID = prescriptions.Rows[row].Cells[col].Value.ToString();
                    string medName = UIManager.Instance.LoadMedNameAndNotes(selectedMedID).Tables[0].Rows[0][0].ToString();
                    string notes = UIManager.Instance.LoadMedNameAndNotes(selectedMedID).Tables[0].Rows[0][1].ToString();
                    string message = "Medication name: {0}" + medName + "{0}{0}Notes:{0}" + notes + ".";
                    System.Windows.Forms.MessageBox.Show(string.Format(message, Environment.NewLine), "Medication Information");

                }
                else if (col == 1)
                {
                    string selectedPatId = prescriptions.Rows[row].Cells[col].Value.ToString();
                    DataSet ds = UIManager.Instance.LoadPatient(selectedPatId);
                    Patient mp = new Patient(ds);
                    string message = "Patient name: " + mp.PatientName + "{0}Date of Birth: " + mp.PatientDateOfBirth + "{0}Address: " + mp.PatientAddress;
                    System.Windows.Forms.MessageBox.Show(string.Format(message, Environment.NewLine), "Patient Information");

                }

            }
        }

        private void OnPrescriptionsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int column = e.ColumnIndex;
            int row = e.RowIndex;

            string medID = prescriptions[column - 4, row].Value.ToString();
            string patientId = prescriptions[column - 3, row].Value.ToString();
            string dateFrom = prescriptions[column - 2, row].Value.ToString();
            string originalTo = prescriptions[column - 1, row].Value.ToString();
            string extendDate = prescriptions[column, row].Value.ToString();

            if (prescriptions[column, row].Value.ToString() != "")
            {


                DateTime result;
                bool formatValidity = DateTime.TryParseExact(extendDate, "yyyy_MM_dd", new CultureInfo("en-US"), DateTimeStyles.None, out result);
                bool dateValidity = false;

                if (formatValidity)
                {
                    dateValidity = Int32.Parse(extendDate.Replace("_", "")) > Int32.Parse((originalTo.Replace("_", ""))) ? true : false;

                    if (dateValidity)
                    {
                        Utility.ConfirmPrescriptionAction(medID, patientId, extendDate);
                        BeginInvoke(new MethodInvoker(UIManager.Instance.UpdatePrescriptionsDataGrid));
                    }
                    else
                    {
                        if (UIManager.Instance.ActiveUser.Job == Job.Receptionist)
                        {
                            System.Windows.Forms.MessageBox.Show("Date Requested is earlier than the originally assigned date. Authorisation by manager is required");
                            BeginInvoke(new MethodInvoker(UIManager.Instance.UpdatePrescriptionsDataGrid));
                        }
                        else
                        {
                            Utility.ConfirmPrescriptionAction(medID, patientId, extendDate);
                            BeginInvoke(new MethodInvoker(UIManager.Instance.UpdatePrescriptionsDataGrid));
                        }
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Wrong Input inserted. Please make sure the requested extention is in the specified format. (yyyy_MM_dd)");
                    BeginInvoke(new MethodInvoker(UIManager.Instance.UpdatePrescriptionsDataGrid));
                }
            }
            else
            {
                string message = "Delete extention?";
                DialogResult answer = System.Windows.Forms.MessageBox.Show(message, "Attention", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    UIManager.Instance.DeleteExtention(medID, patientId);
                    BeginInvoke(new MethodInvoker(UIManager.Instance.UpdatePrescriptionsDataGrid));
                }
                else
                {
                    BeginInvoke(new MethodInvoker(UIManager.Instance.UpdatePrescriptionsDataGrid));
                }

            }


        }
        
        #endregion

    }
    #endregion

}
