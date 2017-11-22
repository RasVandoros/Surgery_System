using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication2
{
    public sealed class Logger
    {
        private List<Logg> runtimeLogs = new List<Logg>();
        private string logName;


        public static string LogName
        {
            get
            {
                if (Logger.Instance.logName == null)
                {
                    Logger.Instance.logName = string.Format(DateTime.Now.ToString("yyyy_MM_dd"));
                }

                return Logger.Instance.logName;
            }
            set { Logger.Instance.logName = value; }
        }
        public List<Logg> RunTimeLogs
        {
            get
            {
                return this.runtimeLogs;
            }
            set
            {
                runtimeLogs = value;
            }
        }


        #region Singleton
        static Logger instance = null;
        static readonly object myLock = new object();

        Logger()
        {

        }

        public static Logger Instance
        {
            get
            {
                lock (myLock)
                {
                    if (instance == null)
                    {

                        instance = new Logger();
                    }
                }
                return instance;
            }


        }

        #endregion

        /// <summary>
        /// Creates a log file, containing the type of log, a custom message and an id that is specific to the current runtime
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="id"></param>
        public void WriteLog(Logg log)
        {
            
            string line = ""; //this line is going to be the full entry
            line += log.D.ToString();//It contains the cur date
            line += "||";//seperated by this
            line += log.T;//It contains the cur time
            line += "||";//seperated by this
            line += log.Type;//the Type of entry
            line += "||";//seperated by this
            line += log.M.message;//and the message passed from outside the class

            using (var sw = new StreamWriter(LogName, true))
            {
                sw.WriteLine(line);
            }
        }


        #region Logg Class
        public class Logg
        {
            private string t;
            private Type type;
            private Message m;
            private Date d;
     

            public Date D
            {
                get { return d; }
            }

            public Type Type
            {
                get { return type; }
            }

            public Message M
            {
                get { return m; }
            }

            public string T
            {
                get { return t; }
            }


            public Logg(Type type, Message message)
            {
                DateTime dt = DateTime.Now;
                this.d= new Date(DateTime.Now.ToString("yyyy_MM_dd"));
                this.t =DateTime.Now.ToString("HH_mm_ss_fff");
                this.type = type;
                this.m = message;      
                Logger.Instance.runtimeLogs.Add(this);
            }

        }

        #endregion 

        public enum Type
        {
            Info,
            Flow,
            Exception
        }

    }
}


