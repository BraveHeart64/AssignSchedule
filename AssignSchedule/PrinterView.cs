using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace AssignSchedule
{
    class PrinterView
    {
        // need to add a border automatically with data
        private System.Windows.Controls.ListBox listview;
        private Point point;
        private String datastring;
        
        private PrintDocument doc = new PrintDocument();

     

        public PrinterView(System.Windows.Controls.ListBox listbox)
        {
           this.listview = listbox;
        }
    }
}
