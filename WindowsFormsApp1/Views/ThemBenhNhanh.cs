using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class ThemBenhNhanh : Form
    {
        public ThemBenhNhanh()
        {
            InitializeComponent();
        }
        public string tenbenh;
        private void button1_Click(object sender, EventArgs e)
        {
            tenbenh = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
