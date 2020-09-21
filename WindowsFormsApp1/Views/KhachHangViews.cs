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
using System.Drawing.Drawing2D;

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

            textBoxTen.Text = "";
            textBoxHo.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Clear();
        }
        private void loadButton()
        {
            deletebutton.Enabled = false;
            addbutton.Enabled = true;
            updatebutton.Enabled = false;
            savebutton.Enabled = false;
            closebutton.Enabled = false;
            textBoxTen.Enabled = false;
            textBoxHo.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            maskedTextBox1.Enabled = false;
        }
        public void load()
        {
            loadAgain();
        }
        public void load1()
        {
            loadAgain();
        }
        private void loadAgain()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox)
                {
                    c.TextChanged += C_TextChanged;
                }
                if (c is MaskedTextBox)
                {
                    c.TextChanged += C_TextChanged1;
                }
            }
            button11.Enabled = false;
            LoadPermission();
            label10.Text = "";
            label10.Visible = true;
            textBoxHo.Text = "";
            textBoxTen.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Clear();
            loadButton();
            loadDataGridView();
            loadDataGridViewTenLoai();
            DataBinding();
            groupBox2.Enabled = false;
            dataGridView1.Enabled = true;
            label10.Visible = false;
            typecustomercbb.Enabled = false;
            comboBox2.Enabled = false;
            textBox10.Visible = false;
            dataGridView1 = MyDataGridViews.MyDataGridView.getMyDataGridView(dataGridView1);
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

        private void KhachHangViews_Load(object sender, EventArgs e)
        {
            LoadPermission();
            typecustomerbtn = buttonStyle.createBtn(typecustomerbtn);
            updatebutton = buttonStyle.updateBtn(updatebutton);
            addbutton = buttonStyle.createBtn(addbutton);
            deletebutton = buttonStyle.deleteBtn(deletebutton);
            closebutton = buttonStyle.closeBtn(closebutton);
            savebutton = buttonStyle.saveBtn(savebutton);
            warnDC.Visible = false;
            loadAgain();
        }

        private void LoadPermission()
        {
            if (MyPermission.getpermission("Customer", "insert") == 0)
            {
                addbutton.Visible = false;
            }
            if (MyPermission.getpermission("Customer", "update") == 0)
            {
                updatebutton.Visible = false;
                button11.Visible = false;
            }
            if (MyPermission.getpermission("Customer", "update") == 0 && MyPermission.getpermission("Customer", "insert") == 0)
            {
                savebutton.Visible = false;
                closebutton.Visible = false;
            }
            if (MyPermission.getpermission("Customer", "delete") == 0)
            {
                deletebutton.Visible = false;
            }
            if (MyPermission.getpermission("HealCustomer", "view") == 0)
            {
                groupBox2.Visible = false;
            }
            if (MyPermission.getpermission("HealCustomer", "insert") == 0)
            {
                textBox1.Enabled = false;
            }
            if (MyPermission.getpermission("HealCustomer", "delete") == 0)
            {
            }
            if (MyPermission.getpermission("Health", "view") == 0)
            {
            }
         
            if (MyPermission.getpermission("TypeCustomer", "view") == 0)
            {
                typecustomercbb.Enabled = false;
            }
            if (MyPermission.getpermission("TypeCustomer", "insert") == 0)
            {
                typecustomerbtn.Visible = false;
            }
        }

        private void loadDataGridViewTenLoai()
        {
            typecustomercbb.DataSource = Controllers.KhachHangControllers.LoadLoaiKh1().Tables[0];
            typecustomercbb.DisplayMember = "name";
            typecustomercbb.ValueMember = "id";
            typecustomercbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.Insert(0, "Nam");
            comboBox2.Items.Insert(1, "Nữ");
            comboBox2.Items.Insert(2, "None");
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            label10.DataBindings.Clear();
            label10.DataBindings.Add("Text", dataGridView1.DataSource, "id", false, DataSourceUpdateMode.Never);
        }

        private void loadDataGridView()
        {
            dataGridView1.DataSource = Controllers.KhachHangControllers.getData().Tables[0];

            listhealth = Controllers.KhachHangControllers.getAllBenhLi1().Tables[0];

        }
        private void enableTextBox()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBoxHo.Enabled = true;
            textBoxTen.Enabled = true;
            maskedTextBox1.Enabled = true;
        }
        private void DataBinding()
        {
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add("Text", dataGridView1.DataSource, "code", false, DataSourceUpdateMode.Never);
            textBoxHo.DataBindings.Clear();
            textBoxHo.DataBindings.Add("Text", dataGridView1.DataSource, "lastname", false, DataSourceUpdateMode.Never);
            textBoxTen.DataBindings.Clear();
            textBoxTen.DataBindings.Add("Text", dataGridView1.DataSource, "firstname", false, DataSourceUpdateMode.Never);
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "phone", false, DataSourceUpdateMode.Never);
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "email", false, DataSourceUpdateMode.Never);
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "address", false, DataSourceUpdateMode.Never);
            maskedTextBox1.DataBindings.Clear();
            maskedTextBox1.DataBindings.Add("Text", dataGridView1.DataSource, "birthday", false, DataSourceUpdateMode.Never);
            typecustomercbb.DataBindings.Clear();
            typecustomercbb.DataBindings.Add("SelectedValue", dataGridView1.DataSource, "idlkh", false, DataSourceUpdateMode.Never);
            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add("Text", dataGridView1.DataSource, "sex", false, DataSourceUpdateMode.Never);
            textBox10.DataBindings.Clear();
            textBox10.DataBindings.Add("Text", dataGridView1.DataSource, "available", false, DataSourceUpdateMode.Never);
            textBox7.DataBindings.Clear();
            textBox7.DataBindings.Add("Text", dataGridView1.DataSource, "customerid", false, DataSourceUpdateMode.Never);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Enabled = false;
            groupBox2.Enabled = true;
            deletebutton.Enabled = false;
            addbutton.Enabled = false;
            updatebutton.Enabled = false;
            savebutton.Enabled = true;
            closebutton.Enabled = true;
            typecustomercbb.Enabled = true;
            comboBox2.Enabled = true;
            textBox5.Text = KhachHangControllers.getMaMoi();
            textBox7.Text = KhachHangControllers.getMaKHMoi();
            enableTextBox();
            clearTExtBox();
            action = "insert";
            label10.Text = "";
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
     
            if (textBoxTen.Text==""|| textBoxHo.Text=="" || textBox2.Text=="" || textBox4.Text=="")
            {
                warnDC.Visible =true;
                return;
            }
            string id = textBox5.Text;
            string ten = textBoxTen.Text;
            string ho = textBoxHo.Text;
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
            if (typecustomercbb.SelectedValue == null)
            {
                MessageBox.Show("Them loai khach hang", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string idlkh = typecustomercbb.SelectedValue.ToString();

            if (action == "insert")
            {
                int check = Controllers.KhachHangControllers.insertKhachHang(id, ten, ho, sdt, email, dc, ns, idlkh, gt, pdtb,textBox7.Text);
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
                int check = Controllers.KhachHangControllers.updateKhachHang(int.Parse(label10.Text), id, ten, ho, sdt, email, dc, ns, idlkh, gt, pdtb, textBox7.Text);
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
            typecustomercbb.Enabled = true;
            comboBox2.Enabled = true;
            dataGridView1.Enabled = false;
            groupBox2.Enabled = true;
            deletebutton.Enabled = false;
            addbutton.Enabled = false;
            updatebutton.Enabled = false;
            savebutton.Enabled = true;
            closebutton.Enabled = true;
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
                    if (action == "")
                    {
                        KhachHangViews_Load(sender, e);
                    }
                    if (action == "insert" || action == "update")
                    {
                        listhealth = Controllers.KhachHangControllers.getAllBenhLi1().Tables[0];
                        //pdtb

                    }
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void loadpdtb()
        {
          
            flowLayoutPanel1.Controls.Clear();
            foreach (DataRow dtr in pdtb.Rows)
            {
                Label btn = new Label();
                btn.Click += Btn_Click;
                myTab.MyTab mt = new myTab.MyTab();
                btn.Name = dtr["idhealth"].ToString();
                btn = mt.getbuttonx(btn);
                Label slb = new Label();
                slb.Text = dtr["name"].ToString();
                slb = mt.getLabel(slb);
                Panel pn = new Panel();
               
                pn = mt.createTab(slb, btn);
                pn.Margin = new Padding(0, 0, 0, 0);
                flowLayoutPanel1.Controls.Add(pn);
            }
        }
        

       
        private void label10_TextChanged_1(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (lb.Text != "")
            {
              
                pdtb = Controllers.KhachHangControllers.getBenhLiData(int.Parse(lb.Text)).Tables[0];
                loadpdtb();
                deletebutton.Enabled = true;
                updatebutton.Enabled = true;
            }
            else
            {
                pdtb = new DataTable();
                pdtb.Columns.Add("idcustomer", typeof(int));
                pdtb.Columns.Add("idhealth", typeof(int));
                pdtb.Columns.Add("name", typeof(String));
                pdtb.Columns.Add("createat", typeof(DateTime));
                deletebutton.Enabled = false;
                updatebutton.Enabled = false;
            }


        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (MyPermission.getpermission("HealCustomer", "delete") == 1)
            {
                Label lb = sender as Label;
                foreach (DataRow ctr in pdtb.Rows)
                {
                    if (ctr["idhealth"].ToString() == lb.Name)
                    {
                        pdtb.Rows.Remove(ctr);
                        break;
                    }
                }
                loadpdtb();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ThemNhanhLoaiKH tn = new ThemNhanhLoaiKH();
            if (tn.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Thêm thanh cong", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataGridViewTenLoai();
            }
         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (KhachHangControllers.khoiphucKH(label10.Text) > 0)
            {
                MessageBox.Show("thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox3.Enabled = true;
                KhachHangViews_Load(sender, e);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                button11.Enabled = true;
                groupBox3.Enabled = false;
            }
            else
            {
                button11.Enabled = false;
                groupBox3.Enabled = true;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        DataTable dtb = new DataTable();
        int sig = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (sig == 0)
            {
                TextBox txt = sender as TextBox;
               
                dtb = SucKhoeControllers.timkiem(txt.Text, pdtb).Tables[0];
                if (txt.Text == "" || dtb.Rows.Count == 0)
                {
                    comboBox3.Enabled = false;
                    comboBox3.Text = "";

                }
                else
                {
                    comboBox3.Enabled = true;
                    comboBox3.DataSource = dtb;
                    comboBox3.DisplayMember = "name";
                    comboBox3.ValueMember = "id";
                    comboBox3.DroppedDown = true;
                }

                comboBox3.SelectedIndex = -1;
                Cursor.Current = Cursors.Default;
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


        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
          
            if (dtb.Rows.Count > 0 && textBox1.Text != "")
            {
                sig = 1;
                textBox1.Text = comboBox3.Text;
            }
            textBox1.Focus();
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (sig == 1)
            {
                textBox1.Text = comboBox3.Text;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sig == 1)
            {
                if (comboBox3.SelectedValue != null)
                {
             
                    sig = 0;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox3.SelectedIndex != -1)
                {
                              
                    comboBox3.Enabled = false;
                    sig = 0;
                    if(dtb.Rows.Count==0)
                    {
                        DataRow dtr = pdtb.NewRow();
                        if (label10.Text == "")
                        {
                            dtr["idcustomer"] = 0;
                        }
                        else
                        {
                            dtr["idcustomer"] = label10.Text;
                        }
                        dtr["idhealth"] = 0;
                        dtr["name"] = textBox1.Text;
                        dtr["createat"] = DateTime.Now;
                        pdtb.Rows.Add(dtr);
                       
                    }
                    else
                    {
                        DataRow dtr = pdtb.NewRow();
                        if (label10.Text == "")
                        {
                            dtr["idcustomer"] = 0;
                        }
                        else
                        {
                            dtr["idcustomer"] = label10.Text;
                        }
                        dtr["idhealth"] = comboBox3.SelectedValue.ToString();
                        dtr["name"] = textBox1.Text;
                        dtr["createat"] = DateTime.Now;
                        pdtb.Rows.Add(dtr);

                    }
                }
                else
                {
                    if (MyPermission.getpermission("Health", "insert") == 1)
                    {

                        DataRow dtr = pdtb.NewRow();
                        if (label10.Text == "")
                        {
                            dtr["idcustomer"] = 0;
                        }
                        else
                        {
                            dtr["idcustomer"] = label10.Text;
                        }
                        dtr["idhealth"] = 0;
                        dtr["name"] = textBox1.Text;
                        dtr["createat"] = DateTime.Now;
                        pdtb.Rows.Add(dtr);
                    }
                    else
                    {
                        MessageBox.Show("don't have permission", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        KhachHangViews_Load(sender, e);
                    }

                       
                }
                textBox1.Text = "";
          
                comboBox3.Enabled = true;
                loadpdtb();
            }
            if (e.KeyCode == Keys.Up)
            {
                if (comboBox3.SelectedIndex == 0)
                {
                    comboBox3.SelectedIndex = 0;
                }
                else
                {
                    comboBox3.SelectedIndex -= 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (comboBox3.SelectedIndex == comboBox3.Items.Count - 1)
                {
                    comboBox3.SelectedIndex = 0;
                }
                else
                {
                    comboBox3.SelectedIndex += 1;
                }
            }
        }

      
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                savebutton.PerformClick();
            }

            return true;
        }
      
    }
}