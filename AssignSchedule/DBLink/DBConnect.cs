using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignSchedule.DBLink
{
    class DBConnect
    {//RLCREATED-PC\SQLEXPRESS   
        // String connection = "Data Source=RL-LAPTOP\\SQLEXPRESS;Initial Catalog=SimmonsDB;Integrated Security=True";
        public static SqlConnection GetConnection() {
            String connection = "Data Source=RLCREATED-PC\\SQLEXPRESS; Initial Catalog=SimmonsDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            return con;
        }
    }
}
