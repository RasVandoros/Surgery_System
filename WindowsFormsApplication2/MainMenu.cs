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

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
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

        public MainForm()
        {
            InitializeComponent();
               
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
            this.MinimumSize = new System.Drawing.Size(this.Width + 50, this.Height + 50);
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

        private void OnPrescriptionGridClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                string selectedPatientMedID = prescriptions.Rows[row].Cells[0].Value.ToString();

                
            }
        }

        private void OnPrescriptionsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int column = e.ColumnIndex;
            int row = e.RowIndex;
            string value = prescriptions[column, row].Value.ToString();
            DateTime result;
            bool check = DateTime.TryParse(value, out result);
        }
    }
}
