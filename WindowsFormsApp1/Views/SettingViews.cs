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

        private void SettingViews_Load(object sender, EventArgs e)
        {
            txtServerName.Enabled = false;
            txtServerName.Text = Environment.MachineName;
            txtDataBase.Text = "";
            if(kt==1)
            {
                Dictionary<string, string> dic = SettingsControllers.infor();
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
            foreach(object obj in value)
            {
                if((String)obj == "" || (String)obj == "00:00:00")
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
    

        }
    }
}
