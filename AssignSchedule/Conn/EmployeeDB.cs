using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AssignSchedule.Conn
{
    class EmployeeDB: MainWindow
    {

        public static List<ShiftData> getList()
        {
            List<ShiftData> data = new List<ShiftData>();

            String procedure = "spAddEmployee";

            SqlConnection connection = Conn.contact();
             
            
                SqlCommand selectCommand = new SqlCommand(procedure, connection);
            try
            {
                   
                selectCommand.CommandText = procedure;
                using (SqlCommand command = new SqlCommand(procedure, connection))
                {
                    try
                    {
                       

                        command.CommandType = CommandType.StoredProcedure;
                       // command.Parameters.AddWithValue("@PostID",);
                        //command.Parameters.AddWithValue("@Post",);
                        //command.Parameters.AddWithValue("@Day",);
                        command.Parameters.AddWithValue("@EmployeeName", Reg.SelectedText);
                        

                        connection.Open();

                        command.ExecuteNonQuery();
                    }

                }
                
            }
            catch(SqlConnection x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                connection.Close();
            }

            return data;
        }

    }
}
