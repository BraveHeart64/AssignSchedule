using AssignSchedule.DBLink;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AssignSchedule
{
    class CreatePost
    {
        private bool added = true;
        
            public void AddPostToDataBase(Object TextBox, Object TextBox1, Object TextBox2)
            {
            
                String  procedure = "sp_SetPost";
                try
                {

                    using (SqlConnection connection = new SqlConnection(DBConnect.GetConnection().ConnectionString))
                    {
                    
                        using (SqlCommand cmd = new SqlCommand(procedure, connection))
                        {
                            try
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                            //TextBox
                                cmd.Parameters.AddWithValue("@Post", TextBox.ToString());
                                cmd.Parameters.AddWithValue("@Shift", TextBox1.ToString());
                                cmd.Parameters.AddWithValue("@Day", TextBox2.ToString());
                                connection.Open();
                                cmd.ExecuteNonQuery();
                            connection.Close();
                            }
                            catch (DuplicateNameException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }

                    }

                 

                }
                catch (Exception ex)
                {
                    added = false;
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (added == true)
                    {
                        MessageBox.Show("A Post has been added to the archieve!");
                    }
                }

            
             
            }
        }

    

}
