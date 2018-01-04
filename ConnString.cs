using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace AssignSchedule.Conn
{

    public class ConString
    {
        public ConString()
        {

            SetUpString();


        }

        private void setUpString()
        {

            String connectionString = " Data Source=RLCREATED-PC\\SQLEXPRESS;Initial Catalog=ScheduleMaker;Integrated Security=True";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();


        }

        private void CloseConnection()
        {

            connection.close();

        }




    }
}