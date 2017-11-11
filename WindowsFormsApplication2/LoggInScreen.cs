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
    public partial class LoggInScreen : Form
    {
        


        public LoggInScreen()
        {
            InitializeComponent();
        }

        public void LoggInScreen_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 30);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            foreach (Control c in this.Controls)
            {
                c.Anchor = AnchorStyles.None;
            }
            this.MaximizeBox = false;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {


            if (UIManager.Instance.ClickLogIn(usernameTxtBox.Text, passwordTxtBox.Text) == true)
            {
                UIManager.Instance.swapVisibility();
                passwordTxtBox.Text = "";
                invalidTextBox.Visible = false;
            }
            else
            {
                invalidTextBox.Visible = true;

            }
            
        }

        private void showPassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassCheckBox.Checked)
            {
                passwordTxtBox.UseSystemPasswordChar = false;
            }
            else
            {
                passwordTxtBox.UseSystemPasswordChar = true;
            }
        }

        private void logginScreen_SizeChanged(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {

            }
        }
    }
}
