﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class UserViews : UserControl
    {
        public UserViews()
        {
            InitializeComponent();
        }
        string action = "";
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
   
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            
            enableTextBox();
            clearTExtBox();
            action = "insert";
            label10.Text = "";
        }
        private void enableTextBox()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox1.Enabled = true;
            maskedTextBox1.Enabled = true;
        }
        private void clearTExtBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Clear();
        }

        private void UserViews_Load(object sender, EventArgs e)
        {
            label10.Text = "";
            label10.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Clear();
            loadButton();
            loadDataGridView();
            loadDataGridViewTenLoai();
            DataBinding();
            
            dataGridView1.Enabled = true;
            label10.Visible = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
        }
        private void DataBinding()
        {
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "hoten", false, DataSourceUpdateMode.Never);
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "phone", false, DataSourceUpdateMode.Never);
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "email", false, DataSourceUpdateMode.Never);
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "address", false, DataSourceUpdateMode.Never);
            maskedTextBox1.DataBindings.Clear();
            maskedTextBox1.DataBindings.Add("Text", dataGridView1.DataSource, "birthday", false, DataSourceUpdateMode.Never);
            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("SelectedValue", dataGridView1.DataSource, "idlkh", false, DataSourceUpdateMode.Never);
            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add("Text", dataGridView1.DataSource, "sex", false, DataSourceUpdateMode.Never);
        }
        private void loadDataGridView()
        {
            dataGridView1.DataSource = Controllers.UserControllers.getData();
        }
        private void loadDataGridViewTenLoai()
        {

            comboBox1.DataSource = Controllers.GroupUserControllers.getData().Tables[0];
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.Insert(0, "Nam");
            comboBox2.Items.Insert(1, "Nữ");
            comboBox2.Items.Insert(2, "None");
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            label10.DataBindings.Clear();
            label10.DataBindings.Add("Text", dataGridView1.DataSource, "id");
        }

        private void loadButton()
        {
            button3.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            maskedTextBox1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            string sdt = textBox2.Text;
            string email = textBox3.Text;
            string dc = textBox4.Text;
            string ns = maskedTextBox1.Text;
            int gt = 1;
            if (comboBox2.Text == "Nữ")
            {
                gt = 0;
            }
            if (comboBox2.Text == "Nam")
            {
                gt = 1;
            }
            if (comboBox2.Text == "None")
            {
                gt = 0;
            }
            string idlkh = comboBox1.SelectedValue.ToString();
            if (action == "insert")
            {
                int check = Controllers.UserControllers.insertUser(ten, sdt, email, dc, ns, idlkh, gt);
                if (check > 0)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    action = "";
                    UserViews_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int check = Controllers.UserControllers.updateUser(int.Parse(label10.Text), ten, sdt, email, dc, ns, idlkh, gt);
                if (check > 0)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    action = "";
                    UserViews_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
