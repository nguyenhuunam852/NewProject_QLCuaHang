using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers;
using System.IO;
using System.Xaml.Permissions;

namespace WindowsFormsApp1.Views
{
    public partial class BackupViews : UserControl
    {
        public BackupViews()
        {
            InitializeComponent();
        }
        public static BackupViews bu = new BackupViews();
        private void button1_Click(object sender, EventArgs e)
        {
            if(BackupControllers.backupData()>0)
            {
                MessageBox.Show("Backup thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BackupViews_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Backup thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BackupViews_Load(sender, e);
            }

        }

        private void BackupViews_Load(object sender, EventArgs e)
        {
          
            textBox1.Enabled = false;
            textBox3.Visible = false;

            string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "\\backup\\");
            string[] filePaths = Directory.GetFiles(path, "*.bak",
                                         SearchOption.TopDirectoryOnly);
            DataTable dtb = new DataTable();
            dtb.Columns.Add("name", typeof(String));
            foreach(string a in filePaths)
            {
                DataRow dtr = dtb.NewRow();
                dtr["name"] = Path.GetFileName(a);
                dtb.Rows.Add(dtr);
            }
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView1.DataSource = dtb;
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = GetDateTime(row.Cells["name"].Value.ToString());
            textBox3.Text = row.Cells["name"].Value.ToString();
        }
        private string GetDateTime(string a)
        {
            string[] text = a.Split('_');
            string day = text[0].Substring(0,2);
            string month = text[0].Substring(2, 2);
            string year = text[0].Substring(4, 4);
            string hour = text[1].Substring(0, 2);
            string minute = text[1].Substring(2, 2);
            string second = text[1].Substring(4, 2);
            return day + '/' + month + '/' + year + ' ' + hour + ':' + minute + ':' + second;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if( BackupControllers.restoreData(textBox3.Text) > 0)
            {
                MessageBox.Show("Restore thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatGheViews.fdg = null;
                GheViews.dv = new GheViews();
                GroupUserViews.guv = new GroupUserViews();
                KhachHangViews.khv = new KhachHangViews();
                PersonalInforViews.piv = new PersonalInforViews();
                SettingViews.stv = new SettingViews();
                ThongKeViews.tkv = new ThongKeViews();
                ViewsUser.vu = new ViewsUser();
                ViewsSucKhoe.vsk = new ViewsSucKhoe();
                ViewsLoaiKhachHang.vlkh = new ViewsLoaiKhachHang();
                BackupViews.bu = new BackupViews();
                FrmMain.getFrmMain().reload();
                BackupViews_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Restore thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BackupViews_Load(sender, e);
            }
        }
    }
}
