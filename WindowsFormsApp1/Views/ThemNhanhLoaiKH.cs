using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;
namespace WindowsFormsApp1.Views
{
    public partial class ThemNhanhLoaiKH : Form
    {
        public ThemNhanhLoaiKH()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int check = Controllers.KhachHangControllers.ThemLoaiKhachHang(textBox1.Text);
            if (check > 0)
            {
                MessageBox.Show("Thêm tinh trang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
