using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AssignSchedule.DBLink
{

    class Officer
    {
        private string shift;
        private string post;
        private string day;
        private string name;
        private int officerid;


        public Officer() { } 

        public String Shift
        {
            get
            {
                return shift;
            }
            set
            {
                shift = value;
            }
        }

        public String Post
        {
            get
            {
                return post;
            }
            set
            {
                post = value;
            }
        }

        public String Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int OfficerID
        {
            get
            {
                return officerid;
            }
            set
            {
                 this.officerid = value;
            }
        }

       
    }
}
