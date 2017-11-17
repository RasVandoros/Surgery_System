using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsFormsApplication2
{
    class DBManager
    {
        //attributes
        private static DBManager _instance;

        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;Connect Timeout=30";

        private SqlConnection connectioToDB;

        private SqlDataAdapter dataAdapter;

        //properties
        public static string ConnectionStr
        {
            
            set
            {
                connectionString = value;
            }
        }

        //methods
        public static DBManager getDBConnectionInstance()
        {
            if (_instance == null)
                _instance = new DBManager();

            return _instance;
        }

        // Open the connection
        public void openConnection()
        {
            // create the connection to the database as an instance of SqlConnection
            connectioToDB = new SqlConnection(connectionString);

            //open connection
            connectioToDB.Open();

            Logger.Instance.WriteLog(Logger.Type.Flow, new Message("db con open."), UIManager.Instance.ID.ToString());

        }

        public void closeConnection()
        {
            connectioToDB.Close();
            Logger.Instance.WriteLog(Logger.Type.Flow, new Message("db con closed."), UIManager.Instance.ID.ToString());

        }

        //create a data set for a certain request
        public DataSet getDataSet(String sqlStatement)
        {
            DataSet dataSet = new DataSet();

            //open connection
            openConnection();

            //create the data adapter object
            dataAdapter = new SqlDataAdapter(sqlStatement, connectioToDB);
           
            //fill in the data set

            dataAdapter.Fill(dataSet);
            
            //close connection
            closeConnection();
            Logger.Instance.WriteLog(Logger.Type.Flow, new Message("Got dataset successfully."), UIManager.Instance.ID.ToString());

            return dataSet;
        }
    }
}

