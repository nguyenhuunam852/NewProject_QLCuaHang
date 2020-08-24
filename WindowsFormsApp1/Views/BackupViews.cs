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
        public int sig = 0;
        public string defaultPath;
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
            txtFolder.Enabled = false;
            groupBox1.Enabled = false;
            label6.Visible = false;
            if (sig==1)
            {
                label2.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
            }
            textBox1.Enabled = false;
            txtFileName.Enabled = false;

            folderBrowserDialog1.SelectedPath = defaultPath;
           
           
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView1.DataSource = loadFile();
            txtFolder.Text = folderBrowserDialog1.SelectedPath;
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
                label2.Visible = false;
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = GetDateTime(row.Cells["name"].Value.ToString());
                txtFileName.Text = row.Cells["name"].Value.ToString();
                
        }
        private string GetDateTime(string a)
        {
            string rstext;
            try
            {
                string[] text = a.Split('_');
                string day = text[0].Substring(0, 2);
                string month = text[0].Substring(2, 2);
                string year = text[0].Substring(4, 4);
                string hour = text[1].Substring(0, 2);
                string minute = text[1].Substring(2, 2);
                string second = text[1].Substring(4, 2);
                rstext= day + '/' + month + '/' + year + ' ' + hour + ':' + minute + ':' + second;
                textBox1.ForeColor = Color.Black;
                label6.Visible = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            catch
            {
                label6.Visible = true;
                label6.Text = "*File không hợp lệ";
                rstext = "";
                label6.ForeColor = Color.Red;
                button2.Enabled = false;
                button3.Enabled = false;
                txtFileName.Text = "";
            }
            return rstext;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dlr=folderBrowserDialog1.ShowDialog();
            if (dlr == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
                loadFile();
                dataGridView1.DataSource = loadFile();
            }
        }
        private DataTable loadFile()
        {
            string path = folderBrowserDialog1.SelectedPath;
            string[] filePaths = Directory.GetFiles(path, "*.bak",
                                         SearchOption.TopDirectoryOnly);
            DataTable dtb = new DataTable();
            dtb.Columns.Add("name", typeof(String));
            foreach (string a in filePaths)
            {
                DataRow dtr = dtb.NewRow();
                dtr["name"] = Path.GetFileName(a);
                dtb.Rows.Add(dtr);
            }
            return dtb;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (BackupControllers.restoreData(txtDtbName.Text,txtFileName.Text,txtFolder.Text) > 0)
            {
                MessageBox.Show("Restore thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SettingViews.stv.loadCombobox();
                FrmMain.getFrmMain().reload();
            }
            else
            {
                MessageBox.Show("Restore thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BackupViews_Load(sender, e);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtDtbName.Text = "";
            groupBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn thoát không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlr == DialogResult.Yes)
            {
                FrmMain.getFrmMain().reload();
            }
        }
    }
}
