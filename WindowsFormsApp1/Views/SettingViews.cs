using System;
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

namespace WindowsFormsApp1.Views
{
    public partial class SettingViews : UserControl
    {
        private int kt;
        public SettingViews()
        {
            InitializeComponent();
        }
        public SettingViews(int check)
        {
            InitializeComponent();
            kt = check;
        }
        public static SettingViews stv;
        public static SettingViews getViews(int check)
        {
             return new SettingViews(check);
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
            txtServerName.Text = Environment.MachineName;
            txtDataBase.Text = "";
            if(kt==1)
            {
                Dictionary<string, string> dic = SettingsControllers.getInformation();
                txtDataBase.Text = dic["txtDataBase"];
                txtServerName.Text = dic["txtServerName"];
                txtDV.Text = dic["txtDV"];
                txtTGBD.Text = dic["txtTGBD"];
                txtTGHD.Text = dic["txtTGHD"];
                txtTGKT.Text = dic["txtTGKT"];

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            object[] param = new object[] { "txtServerName", "txtDataBase","txtDV","txtTGBD","txtTGHD","txtTGKT" };
            object[] value = new object[] { txtServerName.Text, txtDataBase.Text,txtDV.Text,txtTGBD.Text,txtTGHD.Text,txtTGKT.Text };
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
            if(kt==0)
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
    }
}
