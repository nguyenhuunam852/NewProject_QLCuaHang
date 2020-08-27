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
            if(BackupControllers.backupData(folderBrowserDialog1.SelectedPath)>=-1)
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
        private void DataBinding()
        {
            txtFileName.DataBindings.Clear();
            txtFileName.DataBindings.Add("Text", dataGridView1.DataSource, "name", false, DataSourceUpdateMode.Never);

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "time", false, DataSourceUpdateMode.Never);

        }
        private void BackupViews_Load(object sender, EventArgs e)
        {
           
            txtFolder.Enabled = false;
            groupBox1.Enabled = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            button3.Visible = false;
            if (sig==1)
            {
                label2.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
            }
          
            textBox1.Enabled = false;
            txtFileName.Enabled = false;
            if (defaultPath != null)
            {
                folderBrowserDialog1.SelectedPath = defaultPath;
            }
            else
            {
                folderBrowserDialog1.SelectedPath = Settings.getSettings().psavebakfile;
            }
            
           
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView1.DataSource = loadFile();
           


            txtFolder.Text = folderBrowserDialog1.SelectedPath;
            DataBinding();
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            label2.Visible = false;
         
          

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
            if(txtDtbName.Text=="")
            {
                txtDtbName.Enabled = true;
              
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dlr=folderBrowserDialog1.ShowDialog();
            if (dlr == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
                loadFile();
                dataGridView1.DataSource = loadFile();
                defaultPath = folderBrowserDialog1.SelectedPath;
                DataBinding();
            }
        }
        private DataTable loadFile()
        {
            string path = folderBrowserDialog1.SelectedPath;
            string[] filePaths = Directory.GetFiles(path, "*.bak",
                                         SearchOption.TopDirectoryOnly);
            DataTable dtb = new DataTable();
            dtb.Columns.Add("name", typeof(String));
            dtb.Columns.Add("time", typeof(String));
            foreach (string a in filePaths)
            {
                DataRow dtr = dtb.NewRow();
                dtr["name"] = Path.GetFileName(a);
                dtr["time"] = GetDateTime(dtr["name"].ToString());
                dtb.Rows.Add(dtr);
            }
            return dtb;
        }
        int s = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (GetDateTime(txtFileName.Text) != "")
            {
                DataTable dtb = BackupControllers.getDatabaseIfExist(txtFileName.Text, txtFolder.Text);
                string database = BackupControllers.getBase(dtb.Rows[0][1].ToString());
                if (database != null)
                {
                    txtDtbName.Text = database;
                    txtDtbName.Enabled = false;
                    s = 1;
                    label8.Visible = true;
                    label9.Visible = false;
                }
                else
                {
                    s = 2;
                    txtDtbName.Text = "";
                    txtDtbName.Enabled = false;
                    label8.Visible = false;
                    label9.Visible = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int ncheck=0;
            if(s==1)
            {
                ncheck=BackupControllers.restoreData(txtDtbName.Text,txtFileName.Text,txtFolder.Text);
            }
            else
            {
                 ncheck=BackupControllers.restoreData1(txtDtbName.Text,txtFileName.Text,txtFolder.Text);
            }
            if ( ncheck>=-1)
            {
                MessageBox.Show("Restore thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (sig == 2)
                {
                    FrmMain.getFrmMain().getSetting();
                }
                else
                {
                    SettingViews.stv.loadCombobox();

                    FrmMain.getFrmMain().reload();
                }
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

        private void button7_Click(object sender, EventArgs e)
        {
            Settings.getSettings().dic["txtSave"]= folderBrowserDialog1.SelectedPath;
            SettingsControllers.saveSettings();
            DialogResult dlr = MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dlr == DialogResult.OK)
            {
                Settings.getInformation();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
