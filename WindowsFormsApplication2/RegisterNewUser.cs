using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class RegisterNewUser : Form
    {
        /// <summary>
        /// Default constructor of the class
        /// </summary>
        public RegisterNewUser()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Event triggering on Confirm Register new user button click, checking the user input for the set clauses
        /// If the user has provided correct input the UIManager is called to Insert the new user info in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmRegButton_Click(object sender, EventArgs e)
        {
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Confirm button pressed")));

            if (!String.IsNullOrEmpty(usernametextBox.Text) && !String.IsNullOrEmpty(passwordTxt.Text))
            {
                Regex re = new Regex("^[-'a-zA-Z]*$");//used to to define if the inputed string contains special characters
                if (re.IsMatch(usernametextBox.Text))
                {
                    UIManager.Instance.RegisterUser(usernametextBox.Text, passwordTxt.Text, jobComboBox.Text);
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

        /// <summary>
        /// On load of this for the max length of the textboxes is being set and the Logger class is called to create a log entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, EventArgs e)
        {
            usernametextBox.MaxLength = 15;
            passwordTxt.MaxLength = 15;
            Logger.Instance.WriteLog(new Logger.Logg(Logger.Type.Flow, new Message("Register new user form loaded")));


        }
    }
}
