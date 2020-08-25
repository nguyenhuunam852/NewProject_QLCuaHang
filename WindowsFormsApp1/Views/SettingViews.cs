﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Views
{
    public partial class SettingViews : UserControl
    {
        public int kt;
       
        public SettingViews()
        {
            InitializeComponent();
        }
        
        public static SettingViews stv;
        public int firstsetting = 0;
        public static SettingViews getViews()
        {
            if(stv==null)
            {
                stv = new SettingViews();
            }
            return stv;
        }
        private void loadPermission()
        {
            if (MyPermission.getpermission("Setting", "update") == 0)
            {
                button3.Visible = false;
            }
        }
        private void SettingViews_Load(object sender, EventArgs e)
        {

            txtServerName.Enabled = false;
            txtInstance.Enabled = false;

            txtServerName.Text = Environment.MachineName;
            txtInstance.Text = Settings.GetDataSources();
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtDataBase.Text = "";
            button5.Enabled = false;
            button6.Enabled = false;
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            if (kt == 1)
            {
                Dictionary<string, string> dic = SettingsControllers.getInformation();
                txtDataBase.Text = dic["txtDataBase"];
                txtServerName.Text = dic["txtServerName"];
                txtDV.Text = dic["txtDV"];
                txtTGBD.Text = dic["txtTGBD"];
                txtTGHD.Text = dic["txtTGHD"];
                txtTGKT.Text = dic["txtTGKT"];
                txtUsername.Text = dic["txtUsername"];
                txtPassword.Text = dic["txtPass"];
                textBox1.Text = dic["txtSave"];
                textBox2.Text = dic["txtPicture"];
            }
            if (firstsetting == 1)
            {
                label15.Visible = true;
                label16.Visible = false;
                label18.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "\\backup\\");
                textBox1.Text = path;

            }
            else
            {
                label15.Visible = false;
                label16.Visible = false;
            }
          
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            object[] param = new object[] { "txtServerName", "txtDataBase","txtDV","txtTGBD","txtTGHD","txtTGKT", "txtUsername", "txtPass", "txtSave", "txtPicture" };
            object[] value = new object[] { txtServerName.Text, txtDataBase.Text,txtDV.Text,txtTGBD.Text,txtTGHD.Text,txtTGKT.Text,txtUsername.Text,txtPassword.Text,textBox1.Text,textBox2.Text };
            if (checkFormat(txtTGBD.Text) == false && checkFormat(txtTGHD.Text) == false && checkFormat(txtTGKT.Text) == false)
            {
                MessageBox.Show("Điền đúng Format", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (validDate(txtTGBD.Text,txtTGKT.Text)==false)
            {
                MessageBox.Show("Thời gian kết thúc nhỏ hơn thời gian bắt đầu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            foreach (object obj in value)
            {
                if((String)obj == "")
                {
                    MessageBox.Show("Điền đủ thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    
                }   
            }
            SettingsControllers.WriteFileTxt(param, value);

            MessageBox.Show("thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(firstsetting==1)
            {
                FrmMain.dongALL();
                FrmMain.getFrmMain().getSetting();
            }
            kt = 1;
            SettingViews_Load(sender, e);

        }
        private bool validDate(string a,string b)
        {
            string[] hd = a.Split(':');
            string[] kt = b.Split(':');
            int h1 = int.Parse(hd[0]) * 60 + int.Parse(hd[1]);
            int h2=  int.Parse(kt[0]) * 60 + int.Parse(kt[1]);
            if(h2<=h1)
            {
                return false;
            }
            return true;

        }
        private bool checkFormat(string a)
        {
            string[] time = a.Split(':');
            int h = int.Parse(time[0]);
            int m = int.Parse(time[1]);

            if(h>=24 || h<0)
            {
                return false;
            }
            if(m>=60 || m<0)
            {
                return false;
            }
          
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingViews_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(SettingsControllers.testConnect(txtUsername.Text, txtPassword.Text, txtServerName.Text, txtInstance.Text)>0)
            {
                MessageBox.Show("thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDataBase.DataSource = Settings.GetAllDatabase();
                txtDataBase.DisplayMember = "name";
                txtDataBase.ValueMember= "name";
                button5.Enabled = true;
                button6.Enabled = true;
                label15.Visible = false;
                label16.Visible = true;
            }
            else
            {
                MessageBox.Show("thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(SettingsControllers.testConnect(txtDataBase.Text)>0)
            {
                DataTable a = GroupUserControllers.getlistpermisson();
                if(a==null)
                {
                    MessageBox.Show("Đây có vẻ không phải là database phù hợp", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dataGridView1.DataSource = a;
                }
            }
            else
            {
                MessageBox.Show("thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BackupViews.bu.defaultPath=textBox1.Text;

            FrmMain.getFrmMain().khoiphucdatabase();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dbd = new FolderBrowserDialog();
            DialogResult dlr= dbd.ShowDialog();
            if(dlr==DialogResult.OK)
            {
                textBox1.Text = dbd.SelectedPath;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dlr = sfd.ShowDialog();
            if (dlr == DialogResult.OK)
            {
                
            }
        }
        public void loadCombobox()
        {
            txtDataBase.DataSource = Settings.GetAllDatabase();
            txtDataBase.DisplayMember = "name";
            txtDataBase.ValueMember = "name";
        }


        private void txtDV_TextChanged(object sender, EventArgs e)
        {
            if(txtDV.Text!="")
            {
                label18.Visible = false;
            }
            else
            {
                label18.Visible = true;
            }
        }

        private void label20_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTGBD_TextChanged(object sender, EventArgs e)
        {
            if(txtTGBD.Text!="00:00")
            {
                label21.Visible = false;
            }
            else
            {
                label21.Visible = true;
            }
        }

        private void txtTGKT_TextChanged(object sender, EventArgs e)
        {
            if (txtTGKT.Text != "00:00")
            {
                label22.Visible = false;
            }
            else
            {
                label22.Visible = true;
            }
        }

        private void txtTGHD_TextChanged(object sender, EventArgs e)
        {
            if (txtTGHD.Text != "")
            {
                label20.Visible = false;
            }
            else
            {
                label20.Visible = true;
            }
        }
    }
}
