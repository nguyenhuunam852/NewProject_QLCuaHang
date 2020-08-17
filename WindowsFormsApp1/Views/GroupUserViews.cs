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

namespace WindowsFormsApp1.Views
{
    public partial class GroupUserViews : UserControl
    {
        public GroupUserViews()
        {
            InitializeComponent();
        }

        private void GroupUserViews_Load(object sender, EventArgs e)
        {
            loadbutton();
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView1.DataSource = GroupUserControllers.getData().Tables[0];
            label8.Visible = false;
        }
        private void loadbutton()
        {
            button3.Enabled = false;
            button2.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            textBox1.Enabled = false;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            textBox1.Enabled = true;
        }
    }
}
