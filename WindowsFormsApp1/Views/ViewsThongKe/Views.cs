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
using System.Globalization;
using System.Windows.Controls.Primitives;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1.Views.ViewsThongKe
{
    public partial class Views : UserControl
    {
        public Views()
        {
            InitializeComponent();
        }
        public static Views vtt;
        public int signal;
        public static Views GetViews(int sig)
        {
            vtt = new Views();
            vtt.signal = sig;
            return vtt;
        }
        public void setMonth(string month)
        {
            comboBox1.Text = month;
            comboBox1.Enabled = false;
            setChart();
        }
        private void setChart()
        {
           
        }
        public void load()
        {
            textBox1.Visible = false;
            chart1.ChartAreas[0].AxisY.IntervalOffsetType = DateTimeIntervalType.Number;
            if (signal == 0)
            {
                comboBox1.Items.Clear();
                lbTVM.Text = "0";
                lbLTV.Text = "0";
                TaoComboBox1();
                dataGridView2.Visible = false;
                dataGridView4.Visible = false;
                dataGridView5.Visible = false;
                thietlapSignal0(DateTime.Now.ToString());
                dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            }
            if (signal == 1)
            {
                lbTVM.Text = "0";
                lbLTV.Text = "0";
                comboBox1.Items.Clear();
                TaoComboBox1();
                dataGridView1.Visible = false;
                dataGridView4.Visible = false;
                dataGridView5.Visible = false;
                thietlapSignal1(comboBox1.Text);
            }
            if (signal == 2)
            {
                comboBox1.Items.Clear();
                TaoComboBox1();
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                dataGridView5.Visible = false;
            }
            if (signal == 3)
            {
                comboBox1.Items.Clear();
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                dataGridView4.Visible = false;
                TaoComboBox1();
            }

        }
        private void ViewsTheoTuan_Load(object sender, EventArgs e)
        {
            load();
        }

        private void thietlapSignal1(string v)
        {
            DataTable dtb= ThongKeControllers.getStaticalinEachMonth(v).Tables[0];
            dataGridView2.DataSource = dtb;
            foreach(DataGridViewColumn column in dataGridView2.Columns)
            {
                column.HeaderCell.Style.BackColor = Color.Aqua;
                column.HeaderCell.Style.ForeColor = Color.Black;
            }
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;

        
            if (comboBox1.Text!="")
            { 
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    chart1.Series["ngay"].Points.AddXY(dtb.Rows[i]["month"].ToString(), int.Parse(dtb.Rows[i]["sum"].ToString()));
                  
                }
                chart1.Series[0]["PointWidth"] = "1";
                chart1.ChartAreas[0].AxisX.Interval = 1;
            }
            

        }

        List<int> gd=new List<int>(); 
        DataTable table;
        private void TaoComboBox1()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
         
            if (signal == 0)
            {
                List<DateTime> ldt = GetWeeks(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DayOfWeek.Sunday);
                if (DateTime.Now.Date < ldt[0].Date)
                {
                    int month = DateTime.Now.Month - 1;
                    int year = DateTime.Now.Year;
                    if (month == 0)
                    {
                        month = 12;
                        year = year - 1;
                    }
                    DataTable db = ThongKeControllers.getMonth();
                    DataRow dtr = db.NewRow();
                    dtr[0] = 0;
                    dtr[1] = month.ToString() + "/" + year.ToString();
                    db.Rows.InsertAt(dtr, 0);
                    comboBox1.DataSource = db;
                    comboBox1.DisplayMember = "thang";
                    comboBox1.ValueMember = "thang";
                    comboBox1.SelectedIndex = db.Rows.Count - 1;
                }
              
                getThongKeinWeek();
            }
            if(signal==1|| signal == 2)
            {
                DataTable dtb = ThongKeControllers.getMinYearandMaxYear().Tables[0];
                if (dtb.Rows[0][0].ToString() != "")
                {
                    int min = int.Parse(dtb.Rows[0][0].ToString());
                    int max = int.Parse(dtb.Rows[0][1].ToString());
                    for (int i = min; i <= max; i++)
                    {
                        comboBox1.Items.Add(i);
                    }
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 2;
                }
                GetStaticalinMonth();
            }
            if(signal==3)
            {
                DataTable dtb = ThongKeControllers.getMinYearandMaxYear().Tables[0];
                if (dtb.Rows[0][0].ToString() != "")
                {
                    int min = int.Parse(dtb.Rows[0][0].ToString());
                    int max = int.Parse(dtb.Rows[0][1].ToString());
                    int a = min;
                    int b = a + 10;
                    comboBox1.Items.Add("Giai đoạn " + a.ToString() + "-" + b.ToString());
                    gd.Add(a);
                    for (int i = min; i <= max; i++)
                    {

                        if (i % 10 == 0)
                        {
                            a = i ;
                            b = a + 10;
                            comboBox1.Items.Add("Giai đoạn " + a.ToString() + "-" + b.ToString());
                            gd.Add(a);
                        }
                    }
                    comboBox1.SelectedIndex = comboBox1.Items.Count -1;
                }
            }
        }

        private void GetStaticalinMonth()
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(signal==1)
            {
                thietlapSignal1(comboBox1.Text);
            }
            if(signal==2)
            {
                if (comboBox1.Text != "")
                {
                    DataTable dtb = ThongKeControllers.getSLKHinQuarter(int.Parse(comboBox1.Text)).Tables[0];
                    dataGridView4.DataSource = dtb;
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        chart1.Series["ngay"].Points.AddXY("Quý " + dtb.Rows[i][0].ToString(), int.Parse(dtb.Rows[i][1].ToString()));
                    }
                }
            }
            if (signal == 3)
            {
                if (comboBox1.Text != "")
                {
                    DataTable dtb = ThongKeControllers.getAllStaticalinYear(gd[comboBox1.SelectedIndex]).Tables[0];
                    dataGridView5.DataSource = dtb;
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        chart1.Series["ngay"].Points.AddXY(dtb.Rows[i][0].ToString(), int.Parse(dtb.Rows[i][1].ToString()));
                    }
                }

            }
        }
        private string getThang(string a)
        {
            int i = 0;
            string rs = "";
            while(a[i]!='/')
            {
                rs += a[i];
                i += 1;
            }
            return rs;
        }
        private string getNam(string a)
        {
            string rs = "";
            int thang = getThang(a).Length;
            int slong = a.Length;
            rs = a.Substring(thang+1, slong-2);

            return rs;
        }
        private void getThongKeinWeek()
        {
            table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("day", typeof(DateTime));
            int save = 0;
            int i = 0;
            if (comboBox1.SelectedValue != null)
            {
                List<DateTime> ldt = GetWeeks(new DateTime(int.Parse(getNam(comboBox1.SelectedValue.ToString())), int.Parse(getThang(comboBox1.SelectedValue.ToString())), 1), DayOfWeek.Sunday);
                foreach (DateTime dt in ldt)
                {
                    DataRow dtr = table.NewRow();
                    dtr["id"] = i;
                    dtr["day"] = dt;
                    if (dt.Day <= DateTime.Now.Day && dt.Month <= DateTime.Now.Month)
                    {
                        save = i;
                    }
                    i += 1;
                    table.Rows.Add(dtr);
                }
                
               
            }
           
            dataGridView1.DataSource = ThongKeControllers.getStaticalInWeekofMonth(table).Tables[0];
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell=dataGridView1.Rows[save].Cells[0];
        }
   
       
       
        public List<DateTime> GetWeeks(DateTime date, DayOfWeek startOfWeek)
        {

            // first generate all dates in the month of 'date'
            var dates = Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month)).Select(n => new DateTime(date.Year, date.Month, n));
            // then filter the only the start of weeks
            var weekends = from d in dates
                           where d.DayOfWeek == startOfWeek
                           select d;
            return weekends.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (signal == 0)
            {
                getThongKeinWeek();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtgv = sender as DataGridView;
            if (signal == 0)
            {
                thietlapSignal0(dtgv.Rows[e.RowIndex].Cells["ngaybatdau"].Value.ToString());
            }
         
           
          
        }
        private void thietlapSignal0(string a)
        {
            DataTable dtb = ThongKeControllers.getSLKHinDay(Convert.ToDateTime(a));
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                DateTime dt = Convert.ToDateTime(dtb.Rows[i][0].ToString());
                chart1.Series["ngay"].Points.AddXY(dt.Day + "/" + dt.Month + "/" + dt.Year, int.Parse(dtb.Rows[i][1].ToString()));
            }

            lbTVM.Text = dataGridView1.CurrentRow.Cells["soluong"].Value.ToString();
            lbLTV.Text = dataGridView1.CurrentRow.Cells["soluongkhmoi"].Value.ToString();
            dataGridView3.DataSource = ThongKeControllers.getTypeOfCusmtomerinWeek(Convert.ToDateTime(a)).Tables[0];

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtgv = sender as DataGridView;
            if (signal==1)
            {
                lbLTV.Text = dtgv.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
                lbTVM.Text = dtgv.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                int month = int.Parse(dtgv.Rows[e.RowIndex].Cells["Column1"].Value.ToString());
                int year = int.Parse(comboBox1.Text);
                dataGridView3.DataSource = ThongKeControllers.getTypeCustomerofMonth(month, year).Tables[0];
            }
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtgv = sender as DataGridView;
            if (signal == 2)
            {
                lbLTV.Text = dtgv.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
                lbTVM.Text = dtgv.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
                int quarter = int.Parse(dtgv.Rows[e.RowIndex].Cells["Column6"].Value.ToString());
                int year = int.Parse(comboBox1.Text);
                dataGridView3.DataSource = ThongKeControllers.getTypeCustomerofQuarter(quarter, year).Tables[0];
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtgv = sender as DataGridView;
            if (signal == 3)
            {
                lbLTV.Text = dtgv.Rows[e.RowIndex].Cells["Column9"].Value.ToString();
                lbTVM.Text = dtgv.Rows[e.RowIndex].Cells["Column8"].Value.ToString();
                int year = int.Parse(dtgv.Rows[e.RowIndex].Cells["Column7"].Value.ToString());
                dataGridView3.DataSource = ThongKeControllers.getTypeCustomerofYear(year).Tables[0];
            }
        }
    }
}
