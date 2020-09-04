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
using System.Windows.Controls.Primitives;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.Views.ViewsThongKe;

namespace WindowsFormsApp1.Views
{
    public partial class ThongKeViews : UserControl
    {
        public static ThongKeViews tkv = new ThongKeViews();
        public ThongKeViews()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string date = maskedTextBox1.Text;
            //dataGridView1.DataSource = ThongKeControllers.GetHistoryinDay(date).Tables[0];
        }
        private void TaoSoDo()
        {

        }
        internal static List<byte> typePages = new List<byte>();
        private void TaoComboBox1()
        {
            //comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            //int numofIte = ThongKeControllers.GetActiveWeek();
            //for (int i = 0; i < numofIte; i++)
            //{
            //    comboBox1.Items.Add("Tuần " + (i + 1).ToString());
            //}
            //if (comboBox1.Items.Count > 0)
            //{
            //    comboBox1.SelectedIndex = 0;
            //    comboBox1.SelectedIndex = numofIte - 1;
            //}
        }
        private void TaoComboBox2()
        {
            //comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox2.DataSource = ThongKeControllers.getMonth();
            //comboBox2.DisplayMember="thang";
            //comboBox2.ValueMember = "thang";
            //if (comboBox2.Items.Count > 0)
            //{
            //    comboBox2.SelectedIndex = 0;
            //}
        }


        private void ThongKeViews_Load(object sender, EventArgs e)
        {
            
            TabHienThi.TabPages[1].Controls.Add(ViewsThongKe.Views.GetViews(0));
            TabHienThi.TabPages[2].Controls.Add(ViewsThongKe.Views.GetViews(1));
            TabHienThi.TabPages[3].Controls.Add(ViewsThongKe.Views.GetViews(2));
            TabHienThi.TabPages[4].Controls.Add(ViewsThongKe.Views.GetViews(3));
            TabHienThi.TabPages[0].Controls.Add(ViewsThongKeNgay.vtkngay);
            if (MyPermission.getpermission("History", "view") == 1 && MyPermission.getpermission("Statical", "view")==0)
            {
                int i = 1;
                while(TabHienThi.TabPages.Count!=1)
                { 
                    TabHienThi.TabPages.Remove(TabHienThi.TabPages[i]);
                }
            }
            if (MyPermission.getpermission("History", "view") == 0 && MyPermission.getpermission("Statical", "view") == 1)
            {
                TabHienThi.TabPages.Remove(TabHienThi.TabPages[0]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThongKeViews_Load(sender, e);
        }
        private void getThongKeinWeek(int a)
        {
          
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            getThongKeinWeek(cb.SelectedIndex);

        }

        private void button3_Click(object sender, EventArgs e)
        {
   
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TabHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TabHienThi.SelectedIndex==0)
            {
               
            }
             
            
        }

        private void TabHienThi_SizeChanged(object sender, EventArgs e)
        {
            if (TabHienThi.TabPages.Count > 1)
            {
                for (int i = 0; i <= 4; i++)
                {
                    TabHienThi.TabPages[i].Controls[0].Size = TabHienThi.TabPages[0].Size;
                }
            }
            else
            {
                TabHienThi.TabPages[0].Controls[0].Size = TabHienThi.TabPages[0].Size;
            }
        }
    }
}
