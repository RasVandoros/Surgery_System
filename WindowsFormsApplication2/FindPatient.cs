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
    public partial class FindPatient : Form
    {
        public FindPatient()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            radioButtonID.Checked = true;
            this.datePicker.ShowUpDown = true;
            this.datePicker.CustomFormat = "yyyy / MM / dd";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

        }

        private void radioButtonID_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonID.Checked == true)
            {
                nameLabel.Enabled = false;
                nametextBox.Enabled = false;
                addressLabel.Enabled = false;
                addresstextBox.Enabled = false;
                dObLabel.Enabled = false;
                datePicker.Enabled = false;
                idLabel.Enabled = true;
                iDtextBox.Enabled = true;
            }
            else
            {
                nameLabel.Enabled = true;
                nametextBox.Enabled = true;
                addressLabel.Enabled = true;
                addresstextBox.Enabled = true;
                dObLabel.Enabled = true;
                datePicker.Enabled = true;
                idLabel.Enabled = false;
                iDtextBox.Enabled = false;
            }
        }

        

        private void confirmSearchbutton_Click(object sender, EventArgs e)
        {

            if (radioButtonID.Checked)
            {
                if (iDtextBox.Text != "")
                {
                    if (UIManager.Instance.ConfirmSearchPatientClick(iDtextBox.Text))
                    {
                        //Utility.UpdateActivePatientLabels();
                        System.Windows.MessageBox.Show("Patient found.");
                        //UIManager.Instance.UpdatePrescriptionsDataGrid();
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Patient ID not found. Please try again.");

                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Please fill all required fields and try again.");
                }


            }
            else
            {
                if(nametextBox.Text != "" && addresstextBox.Text != "" && datePicker.Text != "")
                {
                    if (UIManager.Instance.ConfirmSearchPatientClick(nametextBox.Text, addresstextBox.Text, datePicker.Value.ToString("yyyy/MM/dd").Replace('/', '_')))
                    {
                        //Utility.UpdateActivePatientLabels();
                        System.Windows.MessageBox.Show("Patient found.");
                        //UIManager.Instance.UpdatePrescriptionsDataGrid();
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Patient not found. Please try again.");

                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Please fill all required fields and try again.");
                }

            }
        }

        
    }
}
