using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Views
{
    public partial class GroupUserViews : UserControl
    {
        public GroupUserViews()
        {
            InitializeComponent();
        }
        int sig = 1;
        public static GroupUserViews guv = new GroupUserViews();
        DataTable dtb = new DataTable();
        DataTable savedtb = new DataTable();
        DataTable listpermission = new DataTable();
        string signal = "";
        private void GroupUserViews_Load(object sender, EventArgs e)
        {
            listpermission = GroupUserControllers.getlistpermisson();
            loadPermission();
            dtb = new DataTable();
            savedtb = new DataTable();

            loadbutton();
            
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView2 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView2);
            loadDatatable();
            dataGridView2.DataSource = dtb;
            dataGridView1.DataSource = GroupUserControllers.getData().Tables[0];
            label8.Visible = false;
            dataGridView2.Enabled = false;
            DataBinding();
        }
        private void loadPermission()
        {
            if (MyPermission.getpermission("Permission", "view") == 0)
            {
                dataGridView2.Visible = false;
            }
            if (MyPermission.getpermission("Permission", "update") == 0)
            {
                sig = 0;
            }
            if (MyPermission.getpermission("Groupuser", "insert") == 0)
            {
                button2.Visible = false;
            }
            if (MyPermission.getpermission("Groupuser", "update") == 0)
            {
                button4.Visible = false;
            }
            if (MyPermission.getpermission("Groupuser", "delete") == 0)
            {
                button3.Visible = false;
            }
            if (MyPermission.getpermission("Groupuser", "update") == 0 && MyPermission.getpermission("Groupuser", "insert") == 0)
            {
                button5.Visible = false;
                button1.Visible = false;
            }
        }
        private void loadDatatable()
        {
            dtb = new DataTable();
            dtb.Columns.Add("id", typeof(System.Int32));
            dtb.Columns.Add("permission", typeof(String));
            dtb.Columns.Add("view", typeof(System.Int32));
            dtb.Columns.Add("insert", typeof(System.Int32));
            dtb.Columns.Add("update", typeof(System.Int32));
            dtb.Columns.Add("delete", typeof(System.Int32));
            dtb.Columns.Add("option", typeof(System.Int32));
            foreach(DataRow data in listpermission.Rows)
            {
                DataRow dataRow = dtb.NewRow();
                dataRow["id"] = data["id"];
                dataRow["permission"] = data["name"];
                dataRow["view"] = 0;
                dataRow["insert"] = 0;
                dataRow["update"] = 0;
                dataRow["delete"] = 0;
                dataRow["option"] = 0;
                dtb.Rows.Add(dataRow);
            }
          
        }
        private void DataBinding()
        {
           
            label8.DataBindings.Clear();
            label8.DataBindings.Add("Text", dataGridView1.DataSource, "id", false, DataSourceUpdateMode.Never);

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "name", false, DataSourceUpdateMode.Never);
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


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sig != 0)
            {
                dataGridView2.Enabled = true;
                dataGridView2.ReadOnly = false;
            }
            loadDatatable();
            dataGridView2.DataSource = dtb;
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button1.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            savedtb = new DataTable();
            loadSaveData();
            if (signal == "insert")
            {
                if (GroupUserControllers.insertGroupUser(name, savedtb) > 0)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GroupUserViews_Load(sender, e);
                }
            }
            if (signal == "update")
            {
                if (GroupUserControllers.UpdateGroupUser(label8.Text, savedtb) > 0)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GroupUserViews_Load(sender, e);
                }
            }

        }

        private void loadSaveData()
        {
            savedtb.Columns.Add("iduser", typeof(System.Int32));
            savedtb.Columns.Add("idtable", typeof(String));
            savedtb.Columns.Add("view", typeof(String));
            savedtb.Columns.Add("insert", typeof(String));
            savedtb.Columns.Add("update", typeof(String));
            savedtb.Columns.Add("delete", typeof(String));
            savedtb.Columns.Add("option", typeof(String));
            for(int i=0;i<listpermission.Rows.Count;i++)
            {
                DataRow row = savedtb.NewRow();
                if (signal == "insert")
                {
                    row["iduser"] = 0;
                }
                else
                {
                    row["iduser"] = label8.Text;
                }
                row["idtable"] = dataGridView2.Rows[i].Cells["id1"].Value;
                row["view"] = dataGridView2.Rows[i].Cells["view"].Value;
                row["insert"] = dataGridView2.Rows[i].Cells["insert"].Value.ToString();
                row["update"] = dataGridView2.Rows[i].Cells["update"].Value.ToString();
                row["delete"] = dataGridView2.Rows[i].Cells["delete"].Value.ToString();
                row["option"] = dataGridView2.Rows[i].Cells["option"].Value.ToString();
                savedtb.Rows.Add(row);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GroupUserViews_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string a=label8.Text;
            DataTable newdtb = GroupUserControllers.getListPermissionbyId(a);
            if(listpermission.Rows.Count>newdtb.Rows.Count)
            {
                foreach(DataRow data in listpermission.Rows)
                {
                    string name = data["name"].ToString();
                    DataRow dr = newdtb.AsEnumerable().SingleOrDefault(r => r.Field<string>("permission") == name);
                    if(dr==null)
                    {
                        DataRow row = newdtb.NewRow();
                        row["id"] = data["id"];
                        row["permission"] = name;
                        row["view"] = 0;
                        row["insert"] = 0;
                        row["update"] = 0;
                        row["delete"] = 0;
                        row["option"] = 0;
                        newdtb.Rows.Add(row);
          
                    }

                }
            }
            dataGridView2.DataSource = newdtb;

            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            signal = "update";
            if (sig != 0)
            {
                dataGridView2.Enabled = true;
                dataGridView2.ReadOnly = false;
            }
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button1.Enabled = true;
            textBox1.Enabled = true;
            listpermission = GroupUserControllers.getlistpermisson();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = label8.Text;
            if(GroupUserControllers.deleteGrouUser(a)>0)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroupUserViews_Load(sender, e);
        }
    }
}
