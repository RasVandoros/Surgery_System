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

        public void WriteLog(Type type, Message message, string id)
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy_MM_dd");
            string line = "";
            line += dt.ToString("HH_mm_ss_fff");
            line += "//";
            line += type;
            line += "//";
            line += message.message;

            using (var sw = new StreamWriter(logName, true))
            {
                sw.WriteLine(line);
            }
        }

        private class Logg
        {
            private string dateTime;
            private Type type;
            private string message;

            public string DateTime
            {
                get { return dateTime; }
            }

            public Type Type
            {
                get { return type; }
            }

            public string Message
            {
                get { return message; }
            }


            public Logg(DateTime dateTime, Type type, string message)
            {
                this.dateTime = dateTime.ToString("hh_MM_ss_fff");
                this.type = type;
                this.message = message;
                Logger.Instance.runtimeLogs.Add(this);
            }

        }

        public enum Type
        {
            Info,
            Flow,
            Exception
        }

    }
}


