using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignSchedule.DBLink
{
    static class DisplayOfficerdBInfo
    {

        

        public  static List<Officer> GetOfficer()
        {
           
            Officer employee = new Officer();
            List<Officer> officer = new List<Officer>();
            SqlConnection conn = DBConnect.GetConnection();
            String selectStatement = "SELECT PostID,Shift,Post,Day"+
                "From Post"+
                "Order By PostID";
            SqlCommand SelectCommand = new SqlCommand(selectStatement, conn);
            try
            {
                conn.Open();
                SqlDataReader read = SelectCommand.ExecuteReader();
                while (read.Read())
                {
                    // need to preform an inner join with Post and EmployeeList
                    Officer offiicer = new Officer();
                    employee.Shift = read["Shift"].ToString();
                    employee.Post = read["Post"].ToString();
                    employee.Day = read["Day"].ToString();
                    employee.Name = read["Name"].ToString();
                    officer.Add(employee);
                    
                }
                read.Close();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }


            return null;
        }

      public static void AddEmployee()
    {
            
            SqlConnection conn = DBConnect.GetConnection();
            SqlCommand insert = new SqlCommand();
            insert.Connection = conn;
            
          //  insert.CommandText = "Insert Officer" + "Values(  )   ";
    }

    }

    
}
