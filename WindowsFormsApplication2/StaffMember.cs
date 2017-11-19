using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class StaffMember
    {
        private int id;
        private string name;
        private Job job;


        public int Id
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

        public Job Job
        {
            get
            {
                return this.job;
            }
        }

        /// <summary>
        /// This whole class was design to provide extendability to the software. At the moment it is not utilized within the code.
        /// </summary>
        /// <param name="data"></param>
        public StaffMember(DataSet data)
        {
            this.id = Int32.Parse(data.Tables[0].Rows[0][0].ToString().Trim(' '));
            this.name = data.Tables[0].Rows[0][1].ToString().Trim(' ');
            Dictionary<string, Job> dictionary = new Dictionary<string, Job>();
            dictionary.Add("Nurse", Job.Nurse);
            dictionary.Add("Doctor", Job.Doctor);
            string test = data.Tables[0].Rows[0][3].ToString().Trim(' ');
            this.job = dictionary[test];

        }
    }
}
