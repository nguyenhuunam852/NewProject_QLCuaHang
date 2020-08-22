﻿using System;
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
    public partial class ViewsSucKhoe : UserControl
    {
        public ViewsSucKhoe()
        {
            InitializeComponent();
        }
        string act = "";
        public static ViewsSucKhoe vsk = new ViewsSucKhoe();
        private void ViewsSucKhoe_Load(object sender, EventArgs e)
        {
            loadPermission();
            loadbutton();

            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView1.DataSource = SucKhoeControllers.getData().Tables[0];
            label8.Visible = false;
          
            DataBinding();
        }
        private void loadbutton()
        {
            button3.Enabled = false;
            button2.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            button1.Enabled = false;
            textBox1.Enabled = false;
        }
        private void DataBinding()
        {

            label8.DataBindings.Clear();
            label8.DataBindings.Add("Text", dataGridView1.DataSource, "id", false, DataSourceUpdateMode.Never);

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "name", false, DataSourceUpdateMode.Never);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            act = "insert";
            textBox1.Text = "";
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button1.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (act == "insert")
            {
                int check = Controllers.SucKhoeControllers.insertSucKhoe(textBox1.Text);
                if (check > 0)
                {
                    MessageBox.Show("Thêm tinh trang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    act = "";
                    ViewsSucKhoe_Load(sender, e);
          
                }
            }
            if (act == "update")
            {
                int check = Controllers.SucKhoeControllers.updateSucKhoe(label8.Text,textBox1.Text);
                if (check > 0)
                {
                    MessageBox.Show("Thay đổi tinh trang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    act = "";
                    ViewsSucKhoe_Load(sender, e);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            act = "update";
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button1.Enabled = true;
            textBox1.Enabled = true;
        }
        private void loadPermission()
        {
        
            if (MyPermission.getpermission("Health", "insert") == 0)
            {
                button2.Visible = false;
            }
            if (MyPermission.getpermission("Health", "update") == 0)
            {
                button4.Visible = false;
            }
            if (MyPermission.getpermission("Health", "delete") == 0)
            {
                button3.Visible = false;
            }
            if (MyPermission.getpermission("Health", "update") == 0 && MyPermission.getpermission("Health", "insert") == 0)
            {
                button5.Visible = false;
                button1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewsSucKhoe_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && act == "")
            {
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int check = Controllers.SucKhoeControllers.deleteSucKhoe(label8.Text);
            if (check > 0)
            {
                MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                act = "";
                ViewsSucKhoe_Load(sender, e);

            }
        }
    }
}
