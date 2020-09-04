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
        public static ViewsThongKeNgay vtkngay = new ViewsThongKeNgay();

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            MonthCalendar mcl = sender as MonthCalendar;
            DateTime dt = Convert.ToDateTime(mcl.SelectionRange.Start.ToString());
            getData(dt);
            dataGridView1.DataSource = ThongKeControllers.getHistoryinDay(dt).Tables[0];

        }
        public void load()
        {
            DateTime dt = DateTime.Now;
            getData(dt);
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView3 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView3);
            dataGridView1.DataSource = ThongKeControllers.getHistoryinDay(dt).Tables[0];
        }
        private void ViewsThongKeNgay_Load(object sender, EventArgs e)
        {
            load();
         
           
        }
        private void getData(DateTime dateTime)
        {
            DataTable a = ThongKeControllers.getTempData(dateTime).Tables[0];
            DataTable b = ThongKeControllers.getTempData(dateTime).Tables[1];
            DataTable c = ThongKeControllers.getTempData(dateTime).Tables[2];
            if (a.Rows.Count > 0)
            {
                lbLTV.Text = a.Rows[0][0].ToString();
                lbTVM.Text = c.Rows[0][0].ToString();
                dataGridView3.DataSource = b;
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
