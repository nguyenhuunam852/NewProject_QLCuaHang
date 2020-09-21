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
    public partial class ViewsUser : UserControl
    {
        public ViewsUser()
        {
            InitializeComponent();
        }
        public static ViewsUser vu = new ViewsUser();
        string action = "";
        public int firstSettings = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            savebutton.Focus();
            dataGridView1.Enabled = false;

            deletebutton.Enabled = false;
            addbutton.Enabled = false;
            updatebutton.Enabled = false;
            savebutton.Enabled = true;
            button6.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;

            enableTextBox();
            clearTExtBox();
            action = "insert";
            label10.Text = "";
        }
        private void enableTextBox()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            txtTen.Enabled = true;
            txtHo.Enabled = true;
            maskedTextBox1.Enabled = true;
        }
        private void clearTExtBox()
        {
            txtTen.Text = "";
            txtHo.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Clear();
        }
        private void loadermisssion()
        {
            if (MyPermission.getpermission("User", "insert") == 0)
            {
                addbutton.Visible = false;
            }
            if (MyPermission.getpermission("User", "update") == 0)
            {
                updatebutton.Visible = false;
            }
            if (MyPermission.getpermission("User", "update") == 0 && MyPermission.getpermission("User", "insert") == 0)
            {
                savebutton.Visible = false;
                button6.Visible = false;
            }
            if (MyPermission.getpermission("User", "delete") == 0)
            {
                deletebutton.Visible = false;
            }
         
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                savebutton.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void UserViews_Load(object sender, EventArgs e)
        {
            updatebutton = buttonStyle.updateBtn(updatebutton);
            addbutton = buttonStyle.createBtn(addbutton);
            deletebutton = buttonStyle.deleteBtn(deletebutton);
            closebutton = buttonStyle.closeBtn(closebutton);
            savebutton = buttonStyle.saveBtn(savebutton);
            if (firstSettings == 1)
            {
                textBox5.Text = "1";
                button1.Enabled = false;
            }
            else
            {
                loadermisssion(); 
            }
            textBox5.Visible = false;
            maskedTextBox1.Clear();
            loadButton();
            loadDataGridView();
            loadDataGridViewTenLoai();
            label10.Visible = true;
            txtTen.Text = "";
            txtHo.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dataGridView1.Enabled = true;
            label10.Visible = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
       
            label10.Text = "";
            DataBinding();

           
            
        }
        private void C_TextChanged1(object sender, EventArgs e)
        {
            MaskedTextBox mtb = sender as MaskedTextBox;
            mtb.ForeColor = Color.Black;
        }

        private void C_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.ForeColor = Color.Black;
        }
        private void DataBinding()
        {
            label10.DataBindings.Clear();
            label10.DataBindings.Add("Text", dataGridView1.DataSource, "id", false, DataSourceUpdateMode.Never);
            txtHo.DataBindings.Clear();
            txtHo.DataBindings.Add("Text", dataGridView1.DataSource, "lastname", false, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dataGridView1.DataSource, "firstname", false, DataSourceUpdateMode.Never);
      
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "phone", false, DataSourceUpdateMode.Never);
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "email", false, DataSourceUpdateMode.Never);
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "address", false, DataSourceUpdateMode.Never);
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add("Text", dataGridView1.DataSource, "available", false, DataSourceUpdateMode.Never);
            maskedTextBox1.DataBindings.Clear();
            maskedTextBox1.DataBindings.Add("Text", dataGridView1.DataSource, "birthday", false, DataSourceUpdateMode.Never);
            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("SelectedValue", dataGridView1.DataSource, "idgroup", false, DataSourceUpdateMode.Never);
            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add("Text", dataGridView1.DataSource, "sex", false, DataSourceUpdateMode.Never);
            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add("Text", dataGridView1.DataSource, "sex", false, DataSourceUpdateMode.Never);
        }
        private void loadDataGridView()
        {
            dataGridView1.DataSource = Controllers.UserControllers.getData();
        }
        private void loadDataGridViewTenLoai()
        {

            comboBox1.DataSource = Controllers.GroupUserControllers.getData1().Tables[0];
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.Insert(0, "Nam");
            comboBox2.Items.Insert(1, "Nữ");
            comboBox2.Items.Insert(2, "None");
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            label10.DataBindings.Clear();
            label10.DataBindings.Add("Text", dataGridView1.DataSource, "id");
        }

        private void loadButton()
        {
            deletebutton.Enabled = true;
            addbutton.Enabled = true;
            updatebutton.Enabled = true;
            savebutton.Enabled = false;
            button6.Enabled = false;
            txtTen.Enabled = false;
            txtHo.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            maskedTextBox1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int t = 0;
            foreach (Control c in groupBox3.Controls)
            {
                if (c is TextBox && c.Name!="textBox5")
                {
                    if (c.Text == "")
                    {
                        c.Text = "Điền thêm thông tin";
                        c.ForeColor = Color.Red;
                        t += 1;
                    }
                }
                if (c is MaskedTextBox)
                {
                    if (c.Text == "00/00/0000")
                    {
                        c.Text = "00/00/0000";
                        c.ForeColor = Color.Red;
                        t += 1;
                    }
                }
            }
            if (t > 0)
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string ten = txtTen.Text;
            string ho = txtHo.Text;
            string sdt = textBox2.Text;
            string email = textBox3.Text;
            string dc = textBox4.Text;
            string ns = maskedTextBox1.Text;
            int gt = 1;
            if (comboBox2.Text == "Nữ")
            {
                gt = 0;
            }
            if (comboBox2.Text == "Nam")
            {
                gt = 1;
            }
            if (comboBox2.Text == "None")
            {
                gt = 0;
            }
            string idlkh = comboBox1.SelectedValue.ToString();
            if (action == "insert")
            {
                int check = Controllers.UserControllers.insertUser(ten,ho, sdt, email, dc, ns, idlkh, gt);
                if (check > 0)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    action = "";
                    if (firstSettings == 0)
                    {
                        UserViews_Load(sender, e);
                    }
                    if(firstSettings==1)
                    {
                        button1.Enabled = false;
                        SettingViews.stv = null;
                        FrmMain.dongALL();
                        FrmMain.getFrmMain().firstsetting = 1;
                        FrmMain.getFrmMain().getSetting();
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int check = Controllers.UserControllers.updateUser(int.Parse(label10.Text), ten,ho, sdt, email, dc, ns, idlkh, gt);
                if (check > 0)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    action = "";
                    UserViews_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserViews_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            dataGridView1.Enabled = false;
            deletebutton.Enabled = false;
            addbutton.Enabled = false;
            updatebutton.Enabled = false;
            savebutton.Enabled = true;
            button6.Enabled = true;
            enableTextBox();
            action = "update";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label10.Text);
            int check = Controllers.UserControllers.deleteUser(id);
            if (check > 0)
            {
                MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                action = "";
                UserViews_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau(label10.Text);
            DialogResult dlr = dmk.ShowDialog();
            if (dlr == DialogResult.OK)
            {
                MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            if(label10.Text=="")
            {
               
                    button1.Enabled = false;
                    deletebutton.Enabled = false;
                    updatebutton.Enabled = false;
                
            }
            else
            {
                if (textBox5.Text == "0")
                {
                    button1.Enabled = false;
                    deletebutton.Enabled = false;
                    updatebutton.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                    deletebutton.Enabled = true;
                    updatebutton.Enabled = true;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "0")
            {
                button7.Enabled = true;
                deletebutton.Enabled = false;
                updatebutton.Enabled = false;
                savebutton.Enabled = false;
                button6.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                button7.Enabled = false;
                deletebutton.Enabled = true;
                updatebutton.Enabled = true;
                button1.Enabled = true;
            }
        }
        public void load()
        {
            loadButton();
            loadDataGridView();
            loadDataGridViewTenLoai();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (UserControllers.RestoreUser(label10.Text) > 0)
            {
                MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                UserViews_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserViews_Load(sender, e);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            UserViews_Load(sender, e);
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            UserViews_Load(sender, e);
        }
    }
}
