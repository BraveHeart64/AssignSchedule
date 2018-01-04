using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssignSchedule.Conn
{



    public class ShiftData
    {
        private int postid;
        private string post;
        private string shifts;
        private string day;
        private string employeename;

      public ShiftData() { }


        public int PostId
        {
            get
            {
                return postid;
            }
            set
            {
                this.postid = value;
            }
        }
        
        public string Post
        {
            get
            {
                return post;
            }
            set
            {
                this.post = value;
            }

        }
            public string Shifts
        {
            get
            {
                return shifts;
            }
            set
            {
                this.shifts = value;
            }
        }



            public string Day
        {
            get
            {
                return day;
            }
            set
            {
                this.day = value;
            }

        }

            public string Employeename
        {
            get
            {
                return employeename;
            }
            set
            {
                this.employeename = value;
            }

        }


    }
    
}
