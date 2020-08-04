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
        private string smonth="";
        public static Views GetViews(int sig)
        {
            Views v = new Views();
            v.signal = sig;
            return v;
        }
        public void setMonth(string month)
        {
            comboBox1.Text = month;
            comboBox1.Enabled = false;
            setChart();
        }

        private void setChart()
        {
            if (comboBox1.DisplayMember!="" && signal==1 || comboBox1.Text!="" && signal==4)
            {
                DataTable dtb = ThongKeControllers.getSLKHinMonth(comboBox1.Text).Tables[0];
                comboBox2.Items.Clear();
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    chart1.Series["ngay"].Points.AddXY(dtb.Rows[i]["DATE"].ToString() + "/" + dtb.Rows[i]["MONTH"].ToString() + "/" + dtb.Rows[i]["YEAR"].ToString(), int.Parse(dtb.Rows[i]["TONG"].ToString()));
                    comboBox2.Items.Add(getStringFm(dtb.Rows[i]["DATE"].ToString()) + "/" + getStringFm(dtb.Rows[i]["MONTH"].ToString()) + "/" + getStringFm(dtb.Rows[i]["YEAR"].ToString()));
                }
                chart1.Series[0]["PointWidth"] = "1";
                chart1.ChartAreas[0].AxisX.Interval = 1;

                comboBox2.SelectedIndex = comboBox2.Items.Count-2;
            }
        }

        public void setView(int sig)
        {

        }
        private void DataBinding()
        {
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView2.DataSource, "month");
        }
        private void ViewsTheoTuan_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            button1.Visible = false;
            
            if(signal==0)
            {
                comboBox1.Items.Clear();
                TaoComboBox1();
                TaoComboBox2();
                dataGridView2.Visible = false;
                thietlapSignal0(DateTime.Now.ToString());
            }
            if(signal==1)
            {
                comboBox1.Items.Clear();
                TaoComboBox1();
                TaoComboBox2();
                dataGridView2.Visible = false;
            }
            if (signal == 2 || signal==3)
            {
                comboBox1.Items.Clear();
                TaoComboBox1();
                dataGridView1.Visible = false;
                button1.Visible = true;
            }
            if (signal == 4)
            {
                comboBox1.Items.Clear();
                dataGridView2.Visible = false;
            }

        }
        private void TaoComboBox2()
        {
           
            if (signal == 2)
            {

                comboBox2.Items.Clear();
                for (int i=1;i<=4;i++)
                {
                    comboBox2.Items.Add("Quý " + i.ToString());
                    if(i>Convert.ToDouble(DateTime.Now.Month-1)/3 && i<Convert.ToDouble(DateTime.Now.Month+3)/3)
                    {
                        comboBox2.SelectedIndex = i - 1;
                    }

                }
                
            }
            if(signal==3)
            {
                comboBox2.Items.Clear();
                for (int i = 1; i <= 12; i++)
                {
                    comboBox2.Items.Add("Tháng " + i.ToString());
                }
                comboBox2.SelectedIndex = 0;
            }
           
        }
        DataTable table;
        private void TaoComboBox1()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
         
            if (signal == 0)
            {

                comboBox1.DataSource = ThongKeControllers.getMonth();
                comboBox1.DisplayMember = "thang";
                comboBox1.ValueMember = "thang";
                comboBox1.SelectedIndex = 0;
                getThongKeinWeek();


            }
            if(signal==1)
            {
                comboBox1.DataSource = ThongKeControllers.getMonth();
                comboBox1.DisplayMember = "thang";
                comboBox1.ValueMember = "thang";
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = comboBox1.Items.Count-1;
                }
            }
            if(signal==2||signal==3)
            {
                DataTable dtb = ThongKeControllers.getMinYearandMaxYear().Tables[0];
                if (dtb.Rows[0][0].ToString()!="")
                {
                    int min = int.Parse(dtb.Rows[0][0].ToString());
                    int max = int.Parse(dtb.Rows[0][1].ToString());
                    for (int i = min; i <= max; i++)
                    {
                        comboBox1.Items.Add(i);
                    }
                    comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(signal==1)
            {
                setChart();
            }
            if(signal==2)
            {
                if (comboBox1.Text != "")
                {
                    DataTable dtb = ThongKeControllers.getSLKHinQuarter(int.Parse(comboBox1.Text)).Tables[0];
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        chart1.Series["ngay"].Points.AddXY("Quý " + dtb.Rows[i][0].ToString(), int.Parse(dtb.Rows[i][1].ToString()));
                    }
                    TaoComboBox2();
                }
            }
            if (signal == 3)
            {
                if (comboBox1.Text != "")
                {
                    comboBox2.Visible = false;
                    DataTable dtb = ThongKeControllers.getAllStaticalinYear(int.Parse(comboBox1.Text)).Tables[0];
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        chart1.Series["ngay"].Points.AddXY("Tháng " + dtb.Rows[i][0].ToString(), int.Parse(dtb.Rows[i][1].ToString()));
                    }
                    chart1.Series[0]["PointWidth"] = "1";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    TaoComboBox2();
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
            comboBox2.Visible = false;

            table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("day", typeof(DateTime));
            int i = 0;
            List<DateTime> ldt = GetWeeks(new DateTime(int.Parse(getNam(comboBox1.SelectedValue.ToString())), int.Parse(getThang(comboBox1.SelectedValue.ToString())), 1), DayOfWeek.Sunday);
            foreach (DateTime dt in ldt)
            {
                DataRow dtr = table.NewRow();
                dtr["id"] = i;
                dtr["day"] = dt;
                i += 1;
                table.Rows.Add(dtr);
            }
            dataGridView1.DataSource = ThongKeControllers.getStaticalInWeekofMonth(table).Tables[0];
            dataGridView1.Rows[0].Selected = true ;
            
        }
        private string getStringFm(string a)
        {
            int kt = int.Parse(a);
            if (kt < 10)
            {
                return "0" + a;
            }
            else return a;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (signal == 0 || signal == 1||signal==4)
            {
                DateTime dt = DateTime.ParseExact(cb.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dataGridView1.DataSource = ThongKeControllers.getHistoryinDay(dt).Tables[0];

            }
            if(signal==2)
            {
                int val = getInterget(cb.Text);
                int year = int.Parse(comboBox1.Text);
                dataGridView2.DataSource = ThongKeControllers.getStaticalMonthinQuater(val, year).Tables[0];
                DataBinding();
            }
            if (signal==3)
            {
                int val = getInterget(cb.Text);
                int year = int.Parse(comboBox1.Text);
                dataGridView2.DataSource = ThongKeControllers.getStaticalMonthinYear(year).Tables[0];
                DataBinding();
            }
        }
        private int getInterget(string a)
        {
            string b = "";
            int val = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }

            if (b.Length > 0)
                val = int.Parse(b);
            return val;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThongKeNhanh tkn = new ThongKeNhanh();
            tkn.month = textBox1.Text + "/" + comboBox1.Text;
            tkn.ShowDialog();
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
            thietlapSignal0(dtgv.Rows[e.RowIndex].Cells["ngaybatdau"].Value.ToString());
           
          
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
            txtKHM.Text = dataGridView1.CurrentRow.Cells["soluong"].Value.ToString();
            txtLKH.Text = dataGridView1.CurrentRow.Cells["soluongkhmoi"].Value.ToString();
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
    }
}
