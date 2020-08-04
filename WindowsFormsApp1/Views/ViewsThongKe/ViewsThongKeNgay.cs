using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1.Views.ViewsThongKe
{
    public partial class ViewsThongKeNgay : UserControl
    {
        public ViewsThongKeNgay()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            MonthCalendar mcl = sender as MonthCalendar;
            DateTime dt = Convert.ToDateTime(mcl.SelectionRange.Start.ToString());
            getData(dt);
            dataGridView1.DataSource = ThongKeControllers.getHistoryinDay(dt).Tables[0];

        }

        private void ViewsThongKeNgay_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            getData(dt);
            dataGridView1.DataSource = ThongKeControllers.getHistoryinDay(dt).Tables[0];
         
           
        }
        private void getData(DateTime dateTime)
        {
            DataTable a = ThongKeControllers.getStaticinDay(dateTime).Tables[0];
            if (a.Rows.Count > 0)
            {
                lbTVM.Text = a.Rows[0][0].ToString();
                lbLTV.Text = a.Rows[0][1].ToString();
                dataGridView3.DataSource = ThongKeControllers.getTypeCustomerbyDay(a.Rows[0][2].ToString());
            }
            else
            {
                lbTVM.Text = "0";
                lbLTV.Text = "0";
            }
           
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
