using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignSchedule
{
    public class ColumnSortor : IComparer<ListViewGroup>
    {
        public int Compare(System.Windows.Forms.ListViewGroup row, System.Windows.Forms.ListViewGroup Cols)
        {
            return row.Name.CompareTo(Cols.Name);
        }

    }
}
