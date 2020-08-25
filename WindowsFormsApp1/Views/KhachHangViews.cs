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
using System.Drawing.Text;
using System.Xaml.Permissions;

namespace WindowsFormsApp1.Views
{
    public partial class KhachHangViews : UserControl
    {
        public KhachHangViews()
        {
            InitializeComponent();
        }
        public static KhachHangViews khv = new KhachHangViews();
        string action = "";
        DataTable pdtb = new DataTable();
        DataTable listhealth = new DataTable();
        private void clearTExtBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Clear();
        }
        private void loadButton()
        {
            button3.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            maskedTextBox1.Enabled = false;
        }
        private void KhachHangViews_Load(object sender, EventArgs e)
        {
            LoadPermission();
            label10.Text = "";
            label10.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Clear();
            loadButton();
            loadDataGridView();
            loadDataGridViewTenLoai();
            DataBinding();
            groupBox2.Enabled = false ;
            dataGridView1.Enabled = true;
            textBox8.Visible = false;
            textBox9.Visible = false;
            label10.Visible = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
            dataGridView2 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView2);
            dataGridView3 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView3);
        }

        private void LoadPermission()
        {
            if (MyPermission.getpermission("Customer", "insert") == 0)
            {
                button2.Visible = false;
            }
            if (MyPermission.getpermission("Customer", "update") == 0)
            {
                button4.Visible = false;
            }
            if(MyPermission.getpermission("Customer", "update") == 0 && MyPermission.getpermission("Customer", "insert") == 0)
            {
                button5.Visible = false;
                button6.Visible = false;
            }
            if (MyPermission.getpermission("Customer", "delete") == 0)
            {
                button3.Visible = false;
            }
            if (MyPermission.getpermission("HealCustomer", "view") == 0)
            {
                dataGridView2.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                label2.Visible = false;
            }
            if (MyPermission.getpermission("HealCustomer", "insert") == 0)
            {
                button7.Visible = false;
            }
            if (MyPermission.getpermission("HealCustomer", "delete") == 0)
            {
                button8.Visible = false;
            }
            if (MyPermission.getpermission("Health", "view") == 0)
            {
                dataGridView3.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                textBox7.Visible = false;
                label12.Visible = false;
            }
            if (MyPermission.getpermission("Health", "insert") == 0)
            {
                button9.Visible = false;
            }
        }

        private void loadDataGridViewTenLoai()
        {

            comboBox1.DataSource = Controllers.KhachHangControllers.LoadLoaiKh().Tables[0];
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.Insert(0,"Nam");
            comboBox2.Items.Insert(1,"Nữ");
            comboBox2.Items.Insert(2,"None");
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            textBox8.DataBindings.Clear();
            textBox8.DataBindings.Add("Text", dataGridView3.DataSource, "id");
            label10.DataBindings.Clear();
            label10.DataBindings.Add("Text", dataGridView1.DataSource, "id");
        }

        private void loadDataGridView()
        {
            dataGridView1.DataSource = Controllers.KhachHangControllers.getData().Tables[0];
            listhealth = Controllers.KhachHangControllers.getAllBenhLi().Tables[0];
            dataGridView3.DataSource = listhealth;
        }
        private void enableTextBox()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox1.Enabled = true;
            maskedTextBox1.Enabled = true;
        }
        private void DataBinding()
        {
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add("Text", dataGridView1.DataSource, "code",false, DataSourceUpdateMode.Never);
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "hoten", false, DataSourceUpdateMode.Never);
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "phone", false, DataSourceUpdateMode.Never);
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "email", false, DataSourceUpdateMode.Never);
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "address", false, DataSourceUpdateMode.Never);
            maskedTextBox1.DataBindings.Clear();
            maskedTextBox1.DataBindings.Add("Text", dataGridView1.DataSource, "birthday", false, DataSourceUpdateMode.Never);
            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("SelectedValue", dataGridView1.DataSource, "idlkh", false, DataSourceUpdateMode.Never);
            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add("Text", dataGridView1.DataSource, "sex", false, DataSourceUpdateMode.Never);
            textBox9.DataBindings.Clear();
            textBox9.DataBindings.Add("Text", dataGridView2.DataSource, "idhealth", false, DataSourceUpdateMode.Never);
            textBox8.DataBindings.Clear();
            textBox8.DataBindings.Add("Text", dataGridView3.DataSource, "id", false, DataSourceUpdateMode.Never);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            groupBox2.Enabled = true;
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            textBox5.Text = KhachHangControllers.getMaMoi();
            enableTextBox();
            clearTExtBox();
            action = "insert";
            label10.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = textBox5.Text;
            string ten = textBox1.Text;
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
            if(comboBox1.SelectedValue==null)
            {
                MessageBox.Show("Them loai khach hang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string idlkh = comboBox1.SelectedValue.ToString();
            
            if (action == "insert")
            {
                int check = Controllers.KhachHangControllers.insertKhachHang(id, ten, sdt, email, dc, ns,idlkh,gt,pdtb);
                if (check > 0)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    action = "";
                    KhachHangViews_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int check = Controllers.KhachHangControllers.updateKhachHang(int.Parse(label10.Text),id, ten, sdt, email, dc, ns,idlkh,gt,pdtb);
                if (check > 0)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    action = "";
                    KhachHangViews_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            dataGridView1.Enabled = false;
            groupBox2.Enabled = true;
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            enableTextBox();
            action = "update";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label10.Text);
            int check = Controllers.KhachHangControllers.xoaKhachHang(id);
            if (check > 0)
            {
                MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhachHangViews_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KhachHangViews_Load(sender, e);
        }

        private void textBox6_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBox a = sender as TextBox;
            dataGridView1.DataSource = Controllers.KhachHangControllers.TimKiemTatCa(a.Text).Tables[0];
            DataBinding();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DatGheViews.setTextBox(textBox5.Text);
        }

     
        private void button6_Click(object sender, EventArgs e)
        {
            KhachHangViews_Load(sender, e);
        }

  

        private void button9_Click(object sender, EventArgs e)
        {
            ThemBenhNhanh tbn = new ThemBenhNhanh();
            if (tbn.ShowDialog() == DialogResult.OK)
            {
                int check = Controllers.SucKhoeControllers.insertSucKhoe(tbn.tenbenh);
                if (check > 0)
                {
                    MessageBox.Show("Thêm tinh trang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (action =="")
                    {
                        KhachHangViews_Load(sender, e);
                    }
                    if (action == "insert" || action=="update")
                    {
                        listhealth = Controllers.KhachHangControllers.getAllBenhLi().Tables[0];
                        dataGridView3.DataSource = Controllers.SucKhoeControllers.getBenhAvailable(pdtb).Tables[0];
                        textBox9.DataBindings.Clear();
                        textBox9.DataBindings.Add("Text", dataGridView2.DataSource, "idhealth", true, DataSourceUpdateMode.Never);
                        textBox8.DataBindings.Clear();
                        textBox8.DataBindings.Add("Text", dataGridView3.DataSource, "id", true, DataSourceUpdateMode.Never);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
                foreach(DataRow row in listhealth.Rows)
                {
                    if (row["id"].ToString() == textBox8.Text)
                    {
                        DataRow newrow = pdtb.NewRow();
                        newrow["idhealth"] = row["id"].ToString();
                        newrow["name"] = row["name"].ToString();
                        newrow["createat"] = DateTime.Now.ToString();
                        pdtb.Rows.Add(newrow);
                        break;
                    }
                }
                dataGridView3.DataSource = Controllers.SucKhoeControllers.getBenhAvailable(pdtb).Tables[0];
                dataGridView2.DataSource = pdtb;
                textBox9.DataBindings.Clear();
                textBox9.DataBindings.Add("Text", dataGridView2.DataSource, "idhealth", true, DataSourceUpdateMode.Never);
                textBox8.DataBindings.Clear();
                textBox8.DataBindings.Add("Text", dataGridView3.DataSource, "id", true, DataSourceUpdateMode.Never);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
                foreach (DataRow row in pdtb.Rows)
                {
                    if (row["idhealth"].ToString() == textBox9.Text)
                    {
                        pdtb.Rows.Remove(row);
                        break;
                    }
                }
                dataGridView3.DataSource = Controllers.SucKhoeControllers.getBenhAvailable(pdtb).Tables[0];
                dataGridView2.DataSource = pdtb;
                textBox9.DataBindings.Clear();
                textBox9.DataBindings.Add("Text", dataGridView2.DataSource, "idhealth", true, DataSourceUpdateMode.Never);
                textBox8.DataBindings.Clear();
                textBox8.DataBindings.Add("Text", dataGridView3.DataSource, "id", true, DataSourceUpdateMode.Never);
        }

        private void label10_TextChanged_1(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (lb.Text != "")
            {
                pdtb = Controllers.KhachHangControllers.getBenhLiData(int.Parse(lb.Text)).Tables[0];
                dataGridView2.DataSource = pdtb;
            }
            else
            {
                pdtb = new DataTable();
                pdtb.Columns.Add("idcustomer", typeof(int));
                pdtb.Columns.Add("idhealth", typeof(int));
                pdtb.Columns.Add("name", typeof(String));
                pdtb.Columns.Add("createat", typeof(DateTime));
                dataGridView2.DataSource = pdtb;
            }
            dataGridView3.DataSource = Controllers.SucKhoeControllers.getBenhAvailable(pdtb).Tables[0];
            textBox9.DataBindings.Clear();
            textBox9.DataBindings.Add("Text", dataGridView2.DataSource, "idhealth", true, DataSourceUpdateMode.Never);
            textBox8.DataBindings.Clear();
            textBox8.DataBindings.Add("Text", dataGridView3.DataSource, "id", true, DataSourceUpdateMode.Never);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            dataGridView3.DataSource = Controllers.SucKhoeControllers.timkiem(tb.Text,pdtb).Tables[0];
            DataBinding();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ThemNhanhLoaiKH tn = new ThemNhanhLoaiKH();
            if(tn.ShowDialog()==DialogResult.OK)
            {
                MessageBox.Show("Thêm thanh cong", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhachHangViews_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm that bai", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void button9_Click(object sender, EventArgs e)
        //{
        //    KhachHangControllers.ThemLoaiKhachHang(txtTenLoaiKH.Text);
        //    KhachHangViews_Load(sender, e);
        //}

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    KhachHangControllers.XoaLoaiKhachHang(txtTenLKH.Text);
        //    KhachHangViews_Load(sender, e);
        //}
    }
}