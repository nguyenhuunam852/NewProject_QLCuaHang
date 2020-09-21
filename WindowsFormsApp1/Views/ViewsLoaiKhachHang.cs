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
    public partial class ViewsLoaiKhachHang : UserControl
    {
        public ViewsLoaiKhachHang()
        {
            InitializeComponent();
        }
        public static ViewsLoaiKhachHang vlkh = new ViewsLoaiKhachHang();
        private string act;
        public void load()
        {
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView1.DataSource = KhachHangControllers.LoadLoaiKh().Tables[0];
        }
        private void ViewsLoaiKhachHang_Load(object sender, EventArgs e)
        {
            updatebutton = buttonStyle.updateBtn(updatebutton);
            addbutton = buttonStyle.createBtn(addbutton);
            deletebutton = buttonStyle.deleteBtn(deletebutton);
            closebutton = buttonStyle.closeBtn(closebutton);
            savebutton = buttonStyle.saveBtn(savebutton);
            loadPermission();
            loadbutton();

            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView1.DataSource = KhachHangControllers.LoadLoaiKh().Tables[0];
            label8.Visible = false;
            textBox2.Text = "";
            textBox2.Visible = false;
            DataBinding();
          
        }
        private void loadbutton()
        {
            deletebutton.Enabled = false;
            addbutton.Enabled = true;
            updatebutton.Enabled = false;
            savebutton.Enabled = false;
            closebutton.Enabled = false;
            textBox1.Enabled = false;
        }
        private void DataBinding()
        {

            label8.DataBindings.Clear();
            label8.DataBindings.Add("Text", dataGridView1.DataSource, "id", false, DataSourceUpdateMode.Never);

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "name", false, DataSourceUpdateMode.Never);

            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "available", false, DataSourceUpdateMode.Never);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            act = "insert";
            textBox1.Text = "";
            deletebutton.Enabled = false;
            addbutton.Enabled = false;
            updatebutton.Enabled = false;
            savebutton.Enabled = true;
            closebutton.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            act = "update";
            deletebutton.Enabled = false;
            addbutton.Enabled = false;
            updatebutton.Enabled = false;
            savebutton.Enabled = true;
            closebutton.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (act == "insert")
            {
                int check = Controllers.KhachHangControllers.ThemLoaiKhachHang(textBox1.Text);
                if (check > 0)
                {
                    MessageBox.Show("Thêm tinh trang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    act = "";
                    KhachHangViews.khv.load();
                    ViewsLoaiKhachHang_Load(sender, e);
                    

                }
            }
            if (act == "update")
            {
                int check = Controllers.KhachHangControllers.SuaLoaiKhachHang(label8.Text, textBox1.Text);
                if (check > 0)
                {
                    MessageBox.Show("Thay đổi tinh trang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    act = "";
                    KhachHangViews.khv.load();
                    ViewsLoaiKhachHang_Load(sender, e);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int check = Controllers.KhachHangControllers.XoaLoaiKhachHang(label8.Text);
            if (check > 0)
            {
                MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhachHangViews.khv.load();
                ViewsLoaiKhachHang_Load(sender, e);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && act=="")
            {
                deletebutton.Enabled = true;
                updatebutton.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewsLoaiKhachHang_Load(sender, e);
        }
        private void loadPermission()
        {

            if (MyPermission.getpermission("TypeCustomer", "insert") == 0)
            {
                addbutton.Visible = false;
            }
            if (MyPermission.getpermission("TypeCustomer", "update") == 0)
            {
                updatebutton.Visible = false;
                button6.Visible = false;
            }
            if (MyPermission.getpermission("TypeCustomer", "delete") == 0)
            {
                deletebutton.Visible = false;
            }
            if (MyPermission.getpermission("TypeCustomer", "update") == 0 && MyPermission.getpermission("TypeCustomer", "insert") == 0)
            {
                savebutton.Visible = false;
                closebutton.Visible = false;
            }
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text != "")
            {
         
                if (textBox2.Text == "0")
                {
                    deletebutton.Enabled = false;
                    updatebutton.Enabled = false;
                }
                else
                {
                    deletebutton.Enabled = true;
                    updatebutton.Enabled = true;
                }
            }
            else
            {
              
               deletebutton.Enabled = false;
               updatebutton.Enabled = false;
                
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
            {
                button6.Enabled = true;
                addbutton.Enabled = true;
                deletebutton.Enabled = false;
                updatebutton.Enabled = false;
                savebutton.Enabled = false;
                closebutton.Enabled = false;
            }
            else
            {
                button6.Enabled = false;
                deletebutton.Enabled = true;
                updatebutton.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(KhachHangControllers.restoreTypeCustomer(label8.Text)>0)
            {
                MessageBox.Show("Phục hồi thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhachHangViews.khv.load();
                ViewsLoaiKhachHang_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ViewsLoaiKhachHang_Load(sender, e);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewsLoaiKhachHang_Load(sender, e);
        }
    }
}
