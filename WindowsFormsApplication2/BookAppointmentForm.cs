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

        public Button SubmitButton
        {
            get
            {
                return submitButton;
            }
            set
            {
                submitButton = value;
            }
        }

        public DataGridView ShiftsGrid
        {
            get
            {
                return shiftsGrid;
            }
            set
            {
                shiftsGrid = value;
            }
        }

        public BookAppointmentForm()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            
            this.timePicker.ShowUpDown = true;
            this.timePicker.CustomFormat = "HH:mm";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            this.datePicker.ShowUpDown = true;
            this.datePicker.CustomFormat = "yyyy / MM / dd";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Value = UIManager.Instance.MyCalendarForm.MyCalendarOb.SelectionStart;

            if (UIManager.Instance.ActivePatient != null)
            {
                this.patientNameTxtbox.Text = UIManager.Instance.ActivePatient.PatientName;

            }

            UIManager.Instance.UpdateShiftsDataGrid();
            shiftsGrid.AutoResizeColumns();

        }

        private void findPatient_Click(object sender, EventArgs e)
        {
            UIManager.Instance.showFindPatientForm();
            if(UIManager.Instance.ActivePatient != null)
            {
                this.patientNameTxtbox.Text = UIManager.Instance.ActivePatient.PatientName;
            }
            if (StffComboBox.SelectedItem != null)
            {
                if (DatePicker.Checked || TimePicker.Checked)
                {
                    submitButton.Enabled = true;
                }

            }
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Find Patient button click")));

        }

        private void OnComboBoxClick(object sender, EventArgs e)
        {
            string selectedDate = UIManager.Instance.BookAppointmentForm.DatePicker.Value.ToString("yyyy_MM_dd");
            string selectedTime = UIManager.Instance.BookAppointmentForm.TimePicker.Value.ToString("HH_mm");

            DataSet ds =  UIManager.Instance.GetComboBoxDs(selectedDate, selectedTime);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                foreach (object id in row.ItemArray)
                {
                    UIManager.Instance.BookAppointmentForm.StffComboBox.Items.Add(id.ToString());
                }
            }
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Combo box click")));


        }

        private void OnCalendarValueChanged(object sender, EventArgs e)
        {
            UIManager.Instance.BookAppointmentForm.StffComboBox.SelectedItem = null;
            UIManager.Instance.BookAppointmentForm.submitButton.Enabled = false;
            UIManager.Instance.UpdateShiftsDataGrid();

        }

        private void stffNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Utility.UpdateSubmitButton();
            UIManager.Instance.UpdateShiftsDataGrid();


        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            UIManager.Instance.SubmitAppointmentRequest();
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Appointment request submited successfully")));

        }
    }
}