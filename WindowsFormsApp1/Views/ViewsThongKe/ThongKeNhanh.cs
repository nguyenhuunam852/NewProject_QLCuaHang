using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views.ViewsThongKe
{
    public partial class ThongKeNhanh : Form
    {
        public ThongKeNhanh()
        {
            InitializeComponent();
        }
        public string month;
        private void ThongKeNhanh_Load(object sender, EventArgs e)
        {
            Views v = ViewsThongKe.Views.GetViews(4);
            v.setMonth(month);
            groupBox1.Controls.Add(v);
        }
    }
}
