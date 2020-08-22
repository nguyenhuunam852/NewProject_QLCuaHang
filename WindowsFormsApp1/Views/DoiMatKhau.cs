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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Views
{
    public partial class DoiMatKhau : Form
    {
        string id="";
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        public DoiMatKhau(string pass)
        {
            InitializeComponent();
            id = pass;
            mkcu.Visible = false;
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(mkmoi.Text==xacnhan.Text)
            {
                if (id == "")
                {
                    if (UserControllers.DoiMatKhau(User.getUser().pid, mkcu.Text, mkmoi.Text) > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (UserControllers.DoiMatKhau(id, mkmoi.Text) > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không khớp mật khẩu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
