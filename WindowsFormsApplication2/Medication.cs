using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Medication
    {
        private string id;
        private string name;
        private string notes;


        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Notes
        {
            get
            {
                return this.notes;
            }
        }

        /// <summary>
        /// This class was not utilized for the creation of the project. It was created to provide extendability later on.
        /// </summary>
        /// <param name="data"></param>
        public Medication(DataSet data)
        {
            this.id = data.Tables[0].Rows[0][0].ToString().Trim(' ');
            this.name = data.Tables[0].Rows[0][1].ToString().Trim(' ');
            this.notes = data.Tables[0].Rows[0][2].ToString().Trim(' ');


            Logger.Instance.WriteLog(Logger.Type.Flow, new Message("Med object instantiated"), UIManager.Instance.ID.ToString());

        }
    }
}
