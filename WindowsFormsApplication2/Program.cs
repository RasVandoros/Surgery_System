using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public enum Job
    {
        Receptionist,
        Manager,
        Doctor,
        Nurse
        
    };


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Logger.Instance.WriteLog(Logger.Type.Flow, new Message("Entry point"), UIManager.Instance.ID.ToString());

            UIManager.Instance.CallLoginScreen();
            
        }
    }
}
