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
            this.timePicker.CustomFormat = "hh:mm";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            this.datePicker.ShowUpDown = true;
            this.datePicker.CustomFormat = "yyyy / MM / dd";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            if(UIManager.Instance.ActivePatient != null)
            {
                this.patientNameTxtbox.Text = UIManager.Instance.ActivePatient.PatientName;

            }
            this.shiftsGrid.DataSource = UIManager.Instance.LoadShifts().Tables[0];

            shiftsGrid.AutoResizeColumns();

        }


        private void OnComboboxSelectionChange(object sender, EventArgs e)
        {
            //UIManager.Instance.UpdateDataGrid();
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
                submitButton.Enabled = true;
            }
        }

        private void chooseTime_Click(object sender, EventArgs e)
        {

            UIManager.Instance.UpdateDataGrid();
            /*try
            {
                if (UIManager.Instance.BookAppointmentForm.StffComboBox.SelectedItem != null)
                {
                    MessageBox.Show(UIManager.Instance.BookAppointmentForm.StffComboBox.SelectedItem.ToString());

                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            */
        }

        private void OnComboBoxClick(object sender, EventArgs e)
        {
            string selectedDate = UIManager.Instance.BookAppointmentForm.DatePicker.Value.ToString("yyyy_MM_dd");
            string selectedTime = UIManager.Instance.BookAppointmentForm.TimePicker.Value.ToString("hh_mm");

            DataSet ds =  UIManager.Instance.GetComboBoxDs(selectedDate, selectedTime);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                foreach (object id in row.ItemArray)
                {
                    UIManager.Instance.BookAppointmentForm.StffComboBox.Items.Add(id.ToString());
                }
            }

        }

        private void OnCalendarValueChanged(object sender, EventArgs e)
        {
            UIManager.Instance.BookAppointmentForm.StffComboBox.SelectedItem = null;
            UIManager.Instance.BookAppointmentForm.submitButton.Enabled = false;

        }

        private void stffNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Utility.UpdateSubmitButton();
            
        }
    }
}