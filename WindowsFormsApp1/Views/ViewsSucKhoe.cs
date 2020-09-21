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

namespace WindowsFormsApp1.Views
{
    public partial class ViewsSucKhoe : UserControl
    {
        public ViewsSucKhoe()
        {
            InitializeComponent();
        }
        string act = "";
        public static ViewsSucKhoe vsk = new ViewsSucKhoe();
        public void load()
        {
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView1.DataSource = SucKhoeControllers.getData().Tables[0];
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                savebtn.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ViewsSucKhoe_Load(object sender, EventArgs e)
        {

            textBox2.Visible = false;
            loadPermission();
            loadbutton();

            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView1.DataSource = SucKhoeControllers.getData().Tables[0];
            label8.Visible = false;
            label8.Text = "";
            DataBinding();

        }
        private void loadbutton()
        {
            btnUpdate = buttonStyle.updateBtn(btnUpdate);
            addbutton = buttonStyle.createBtn(addbutton);
            deletebtn = buttonStyle.deleteBtn(deletebtn);
            cancelbutton = buttonStyle.closeBtn(cancelbutton);
            savebtn = buttonStyle.saveBtn(savebtn);
            deletebtn.Enabled = false;
            addbutton.Enabled = true;
            btnUpdate.Enabled = false;
            savebtn.Enabled = false;
            cancelbutton.Enabled = false;
            txtThem.Enabled = false;
        }
        private void DataBinding()
        {

            label8.DataBindings.Clear();
            label8.DataBindings.Add("Text", dataGridView1.DataSource, "id", false, DataSourceUpdateMode.Never);

            txtThem.DataBindings.Clear();
            txtThem.DataBindings.Add("Text", dataGridView1.DataSource, "name", false, DataSourceUpdateMode.Never);

            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "available", false, DataSourceUpdateMode.Never);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            act = "insert";
            txtThem.Focus();
            txtThem.Text = "";
            deletebtn.Enabled = false;
            addbutton.Enabled = false;
            btnUpdate.Enabled = false;
            savebtn.Enabled = true;
            cancelbutton.Enabled = true;
            txtThem.Enabled = true;
        }
        private void Save()
        {
            if(txtThem.Text=="")
            {
                MessageBox.Show("Thêm tinh trang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (act == "insert")
            {
                
                int check = Controllers.SucKhoeControllers.insertSucKhoe(txtThem.Text);
                if (check > 0)
                {
                    act = "";
                    KhachHangViews.khv.load();
                }
            }
            if (act == "update")
            {
                int check = Controllers.SucKhoeControllers.updateSucKhoe(label8.Text, txtThem.Text);
                if (check > 0)
                {
                    MessageBox.Show("Thay đổi tinh trang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    act = "";
                    KhachHangViews.khv.load();
                

                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Save();
            ViewsSucKhoe_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            act = "update";
            deletebtn.Enabled = false;
            addbutton.Enabled = false;
            btnUpdate.Enabled = false;
            savebtn.Enabled = true;
            cancelbutton.Enabled = true;
            txtThem.Enabled = true;
        }
        private void loadPermission()
        {
        
            if (MyPermission.getpermission("Health", "insert") == 0)
            {
                addbutton.Visible = false;
            }
            if (MyPermission.getpermission("Health", "update") == 0)
            {
                btnUpdate.Visible = false;
                button6.Visible = false;
            }
            if (MyPermission.getpermission("Health", "delete") == 0)
            {
                deletebtn.Visible = false;
            }
            if (MyPermission.getpermission("Health", "update") == 0 && MyPermission.getpermission("Health", "insert") == 0)
            {
                savebtn.Visible = false;
                cancelbutton.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewsSucKhoe_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtThem.Text != "" && act == "")
            {
                deletebtn.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int check = Controllers.SucKhoeControllers.deleteSucKhoe(label8.Text);
            if (check > 0)
            {
                MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                act = "";
                KhachHangViews.khv.load();
                ViewsSucKhoe_Load(sender, e);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
            {
                button6.Enabled = true;
                addbutton.Enabled = true;
                deletebtn.Enabled = false;
                btnUpdate.Enabled = false;
                savebtn.Enabled = false;
                cancelbutton.Enabled = false;
            }
            else
            {
                button6.Enabled = false;
                deletebtn.Enabled =true;
                btnUpdate.Enabled = true;
               
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(SucKhoeControllers.restoreSK(label8.Text)>0)
            {
                MessageBox.Show("Phục hồi thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewsSucKhoe_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ViewsSucKhoe_Load(sender, e);
            }
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text != "")
            {

                if (textBox2.Text == "0")
                {
                    deletebtn.Enabled = false;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    deletebtn.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
            else
            {

                deletebtn.Enabled = false;
                btnUpdate.Enabled = false;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ViewsSucKhoe_Load(sender, e);
        }

        private void ViewsSucKhoe_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
                ViewsSucKhoe_Load(sender, e);
            }
        }
    }
}
