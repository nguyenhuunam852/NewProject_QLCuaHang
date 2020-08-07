﻿using System;
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
    public partial class FrmTongKet : Form
    {
        public FrmTongKet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTongKet_Load(object sender, EventArgs e)
        {
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView3 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView3);
            DateTime dt = DateTime.Now;
            getData(dt);
            dataGridView1.DataSource = ThongKeControllers.getHistoryinDay(dt).Tables[0];
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
