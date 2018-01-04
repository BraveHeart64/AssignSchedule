using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AssignSchedule.Conn
{
   public class Conn
    {
      

    public static SqlConnection contact()
      {

        string connectionString = "Data Source=RLCREATED-PC\\SQLEXPRESS;Initial Catalog=TechSupport;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            return connect;
        }


    }

    
}





