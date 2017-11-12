using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class BookAppointmentForm : Form
    {
        public ComboBox StffComboBox
        {
            get
            {
                return stffNameComboBox;
            }
            set
            {
                stffNameComboBox = value;
            }
        }

        public DateTimePicker DatePicker
        {
            get
            {
                return datePicker;
            }
            set
            {
                datePicker = value;
            }
        }

        public DateTimePicker TimePicker
        {
            get
            {
                return timePicker;
            }
            set
            {
                timePicker = value;
            }
        }



        public BookAppointmentForm()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.timePicker.ShowUpDown = true;
            this.timePicker.CustomFormat = "hh:mm";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            this.datePicker.ShowUpDown = true;
            this.datePicker.CustomFormat = "yyyy / MM / dd";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            if(UIManager.Instance.ActivePatient != null)
            {
                this.patientNameTxtbox.Text = UIManager.Instance.ActivePatient.PatientName;
            }
        }

        private void findPatient_Click(object sender, EventArgs e)
        {
            UIManager.Instance.showFindPatientForm();
            if(UIManager.Instance.ActivePatient != null)
            {
                this.patientNameTxtbox.Text = UIManager.Instance.ActivePatient.PatientName;
            }
        }

        private void chooseTime_Click(object sender, EventArgs e)
        {

        }

        private void OnComboBoxClick(object sender, EventArgs e)
        {
            UIManager.Instance.FillStaffMembersComboBox();
            
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            UIManager.Instance.BookAppointmentForm.StffComboBox.SelectedItem = null;
        }

    }
}
