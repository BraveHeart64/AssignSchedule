using AssignSchedule.DBLink;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Drawing;

namespace AssignSchedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // need to update as things are being added on all menus
    // need to make it so you cant add a duplicate Post  just change time 
    //

 

    public partial class MainWindow : Window
    {

        public String name1; // o(1)
        public String shift;
        public String post;
        public String day;

        public struct Assigmndata
        {

            public String Day
            {
                get;
                set;

            }

            public String Name
            {
                get;
                set;


            }

            public String Shift
            {
                get;
                set;
                
            }

            public String Post
            {
                get;
                set;
                
            }
            



        }




        private Officer off = new Officer();
       private String procedure = "";
       private bool added = true;
       private String  setaday;
        bool printemployees = false;
      

        //  private List<WriteSchedule> data = new List<WriteSchedule>();

        public MainWindow()
        {
            
            InitializeComponent();
            LoadGrids();
            SetDays();
            SchEmployee(cbxemp);
            CreateANewPost();
            DisplayWorkers();
            //ShowContract();
        }


        private void  LoadGrids()
        {
           
            // working
            Grid.Columns.Add(new DataGridTextColumn { Header = "Day", Binding = new Binding("Day") });
            Grid.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
            Grid.Columns.Add(new DataGridTextColumn { Header = "Post", Binding = new Binding("Post") });
            Grid.Columns.Add(new DataGridTextColumn { Header = "Shift", Binding = new Binding("Shift") });
            Grid.IsReadOnly = true;
            
           

            /*
              DataGridTextColumn posttext = new DataGridTextColumn();
              DataGridTextColumn shifttext = new DataGridTextColumn();
              DataGridTextColumn daytext = new DataGridTextColumn();
              DataGridTextColumn nametext = new DataGridTextColumn();
              addpostgrid.Columns.Add(daytext);
              addpostgrid.Columns.Add(posttext);
              addpostgrid.Columns.Add(nametext);
              addpostgrid.Columns.Add(shifttext);
              posttext.Header = "Post"; posttext.Width = 100; 
              shifttext.Header = "Shift"; shifttext.Width = 150;
              daytext.Header = "Day"; daytext.Width = 100;// subject to change
              nametext.Header = "Employee"; nametext.Width = 150;
        */

        }

        


     



        private void MenuItem_Click_1(object sender, RoutedEventArgs e)// prints the data grid
        {
            //PrintDialog printlog = new PrintDialog();
            // UserControl control = new UserControl();
            // printlog.PrintVisual(this, "Test");
            PrinterView printer = new PrinterView(this.listbox);
            PrinterView sorter = new PrinterView(showcontracts);
            PrintWindow print = new PrintWindow();
            
            print.Show();
          
        }

       


        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }


        private  void SetDays()
        {
            //C:\Users\Ryan\Desktop\AssignSchedule\AssignSchedule\DBLink
             
            
            ObservableCollection<string> days = new ObservableCollection<String>();
            days.Add("Monday");
            days.Add("Tuesday");
            days.Add("Wednesday");
            days.Add("Thursday");
            days.Add("Friday");
            days.Add("Saturday");
            days.Add("Sunday");
            this.cbxday.ItemsSource = days;
            this.cbxday.SelectedItem = days[0];
         
        }

        private void SchEmployee(ComboBox box)
        {
            //DisplayEmployee
            // employeID must be chosen for this method
           
            procedure = "DisplayEmployee";
            using (SqlConnection connection = new SqlConnection(DBConnect.GetConnection().ConnectionString))
            {
               
                try
                {
                   
                    ObservableCollection<string> emps = new ObservableCollection<String>(); // emps retrieve employee name when making new shifts
                    using (SqlCommand cmd = new SqlCommand(procedure, connection))
                    {
                        Officer offname = new Officer();
                        connection.Open();
                       
                        SqlDataReader read = cmd.ExecuteReader();
                        int employeecounter = 0;
                        while (read.Read())
                        {
                          
                            offname.Name =(String)read["Name"].ToString();
                            emps.Add(offname.Name);

                            if (printemployees == true) {
                                emplistbox.ItemsSource = emps;
                            }
                            box.ItemsSource = emps;
                            
                            box.SelectedItem = emps[employeecounter];
                           

                            employeecounter += 1;
                        }

                         read.Close();
                        cmd.ExecuteReader();
                        connection.Close();

                       
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }

        }

        private void SchShift()
        {

        }



      


        private void SelectedNewSch()
        {
            setaday = this.cbxday.SelectedValue.ToString();
            
            /* setnewpost = 
            setnewshift = 
            setapost =
           */
        }





        public void CreateANewPost()
        {
            String procedure = "DisplayPost";
            ObservableCollection<string> emps = new ObservableCollection<String>(); // emps retrieve employee name when making new shifts


            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(DBConnect.GetConnection().ConnectionString))
            {

                try
                {


                    using (SqlCommand cmd = new SqlCommand(procedure, connection))
                    {
                        Officer offname = new Officer();
                        connection.Open();
                        SqlDataReader read = cmd.ExecuteReader();
                        int employeecounter = 0;
                        while (read.Read())
                        {

                            offname.Post = (String)read["Post"].ToString();
                            emps.Add(offname.Post);

                              this.showcontracts.ItemsSource = emps;
                              this.cbxpost.ItemsSource = emps;
                              this.cbxpost.SelectedItem = emps[employeecounter];
                            

                            employeecounter += 1;
                        }

                        read.Close();
                        cmd.ExecuteReader();
                        connection.Close();


                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }

        }



       
        public void DisplayWorkers()
        {
            printemployees = true;
            SchEmployee(cbxemp);
            this.emplistbox.SelectedItems.Add(this.cbxemp);
            printemployees = false;


        }

        public void DisplayScheduleOnGrid()
        {
            //   Grid

        }



        private String AddEmployee(String name)
        {
            procedure = "sp_AssignOfficer";
           // List<Officer> emp = new List<Officer>();
            try
            {
               
                using ( SqlConnection connection = new SqlConnection(DBConnect.GetConnection().ConnectionString))
                {
                    using (SqlCommand cmmd = new SqlCommand(procedure, connection))
                    {
                        try
                        {
                            cmmd.CommandType = CommandType.StoredProcedure;
                            
                          
                            cmmd.Parameters.AddWithValue("@Name", Tbox.Text);

                            connection.Open();
                            cmmd.ExecuteNonQuery();
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
                    MessageBox.Show("You added an employee to the database");
                }
            }


            return name;
        }












        private void create_Click(object sender, RoutedEventArgs e)
        {
            
           
            name1 = cbxemp.SelectedValue.ToString();
            day = cbxday.SelectedValue.ToString();
            post = cbxpost.SelectedValue.ToString();
            shift = CustomShift.Text.ToString();

            //AssignSchedule




            Grid.Items.Add(new Assigmndata { Day = day.ToString(), Name = name1.ToString(), Shift = shift.ToString(),  Post = post.ToString() });
           
            //day.ToString(), name.ToString(), post.ToString(), shift.ToString())
            SelectedNewSch();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            off.Name = Tbox.Text;
            AddEmployee(off.Name);
            SchEmployee(cbxemp);
            Tbox.Clear();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tbox.Clear();
        }




        private void addpost_Click(object sender, RoutedEventArgs e)
        {
            CreatePost creationpost = new CreatePost();
            
            creationpost.AddPostToDataBase(Apost.Text, Ashift.Text, Aday.Text);

            Apost.Clear();
            Ashift.Clear();
            Aday.Clear();



        }

        private void viewshift_DropDownOpened(object sender, EventArgs e)
        {
            SchEmployee(viewshift);
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
