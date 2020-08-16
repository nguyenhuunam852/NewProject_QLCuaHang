using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views.MyDataGridViews
{
    class MyDataGridView
    {
        public static DataGridView getMyDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.HeaderCell.Style.BackColor = Color.Aqua;
                column.HeaderCell.Style.ForeColor = Color.Black;
            }
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            return dgv;
        }
    }
}
