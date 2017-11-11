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
    public partial class RegisterNewUser : Form
    {
        public RegisterNewUser()
        {
            InitializeComponent();
        }

        private void confirmRegButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(usernametextBox.Text) && !String.IsNullOrEmpty(passwordTxt.Text))
            {
                if (!usernametextBox.Text.All(Char.IsSymbol))
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

        private void OnLoad(object sender, EventArgs e)
        {
            usernametextBox.MaxLength = 15;
            passwordTxt.MaxLength = 15;
            

        }
    }
}
