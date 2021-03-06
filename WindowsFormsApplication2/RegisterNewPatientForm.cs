﻿using System;
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
    public partial class RegisterNewPatientForm : Form
    {
        public RegisterNewPatientForm()
        {
            InitializeComponent();
        }

        private void confirmRegButton_Click(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(nametextBox.Text) && !String.IsNullOrEmpty(postcodeRegtextBox.Text) && datePicker.Value < DateTime.Now)
            {
                if (nametextBox.Text.All(Char.IsLetter))
                {
                    UIManager.Instance.RegisterPatient(nametextBox.Text, postcodeRegtextBox.Text, datePicker.Value.ToString("yyyy/MM/dd").Replace('/', '_'));
                }
                else
                {
                    MessageBox.Show("Name cannot contain special characters");

                }

            }
            else
            {
                MessageBox.Show("Please fill all the required fields and try again.");
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            nametextBox.MaxLength = 30;
            postcodeRegtextBox.MaxLength = 10;
            this.datePicker.ShowUpDown = true;
            this.datePicker.CustomFormat = "yyyy/MM/dd";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }
    }
}
