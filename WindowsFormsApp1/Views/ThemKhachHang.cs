﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1.Views
{
    public partial class ThemKhachHang : Form
    {
        public ThemKhachHang()
        {
            InitializeComponent();
        }
        DataTable pdtb = new DataTable();
        DataTable listhealth = new DataTable();
        private void ThemKhachHang_Load(object sender, EventArgs e)
        {
        
            groupBox3.Enabled = true;
            groupBox2.Enabled = true;
            textBox6.Text = KhachHangControllers.getMaKHMoi();
            textBox5.Text = KhachHangControllers.getMaMoi();
            textBox5.Enabled = false;
            listhealth = Controllers.KhachHangControllers.getAllBenhLi1().Tables[0];
            pdtb = new DataTable();
            pdtb.Columns.Add("idcustomer", typeof(int));
            pdtb.Columns.Add("idhealth", typeof(int));
            pdtb.Columns.Add("name", typeof(String));
            pdtb.Columns.Add("createat", typeof(DateTime));
            loadDataGridViewTenLoai();
            warnHo.Visible = false;
            warnSDT.Visible = false;
            warnTen.Visible = false;
            warnDC.Visible = false;
            addbutton = buttonStyle.createBtn(addbutton);
            savebutton = buttonStyle.saveBtn(savebutton);
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
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsPhoneNumber(string number)
        {
            foreach (var a in number)
            {
                var isNumeric = int.TryParse(a.ToString(), out int n);
                if (isNumeric == false)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsName(string name)
        {
            return Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$");
        }
        public static bool IsDate(string tempDate)
        {
            DateTime fromDateValue;
            var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
            if (DateTime.TryParseExact(tempDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void loadDataGridViewTenLoai()
        {

            comboBox1.DataSource = Controllers.KhachHangControllers.LoadLoaiKh1().Tables[0];
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.Insert(0, "Nam");
            comboBox2.Items.Insert(1, "Nữ");
            comboBox2.Items.Insert(2, "None");
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int t = 0;
            if (txtHo.Text == "")
            {
                warnHo.Visible = true;
                return;
            }
            if (txtTen.Text == "")
            {
                warnTen.Visible = true;
                return;
            }
            if (txtDC.Text == "")
            {
                warnDC.Visible = true;
                return;
            }
            if(textBox2.Text=="")
            {
                warnSDT.Visible = true;
                return;
            }
            if(t>0)
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string id = textBox5.Text;
            string ten = txtTen.Text;
            string ho = txtHo.Text;
            string sdt = textBox2.Text;
            string email = textBox3.Text;
            string dc = txtDC.Text;
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
            int check = Controllers.KhachHangControllers.insertKhachHang(id, ten,ho, sdt, email, dc, ns, idlkh, gt, pdtb, textBox6.Text);
            if (check > 0)
            {
                MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhachHangViews.khv.load1();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
                    listhealth = Controllers.KhachHangControllers.getAllBenhLi1().Tables[0];
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            else
            {
                MessageBox.Show("Thêm that bai", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_TabIndexChanged(object sender, EventArgs e)
        {
          
        }

     

        private void txtHo_Enter(object sender, EventArgs e)
        {
            return;
        }

        private void LoadPermission()
        {
            if (MyPermission.getpermission("Customer", "insert") == 0)
            {
                savebutton.Visible = false;
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
                addbutton.Enabled = false;
            }
            if (MyPermission.getpermission("TypeCustomer", "insert") == 0)
            {
                addbutton.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        DataTable dtb = new DataTable();
        int sig = 0;
        private void textBox1_TextChanged_1(object sender, EventArgs e)
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

        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
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
                    if (dtb.Rows.Count == 0)
                    {
                        DataRow dtr = pdtb.NewRow();
                        
                        dtr["idcustomer"] = 0;
                        
    
            
                        dtr["idhealth"] = 0;
                        dtr["name"] = textBox1.Text;
                        dtr["createat"] = DateTime.Now;
                        pdtb.Rows.Add(dtr);

                    }
                    else
                    {
                        DataRow dtr = pdtb.NewRow();
                        dtr["idcustomer"] = 0;
                        dtr["idhealth"] = comboBox3.SelectedValue.ToString();
                        dtr["name"] = textBox1.Text;
                        dtr["createat"] = DateTime.Now;
                        pdtb.Rows.Add(dtr);

                    }
                }
                else
                {
                    DataRow dtr = pdtb.NewRow();                
                    dtr["idcustomer"] = 0;
                    dtr["idhealth"] = (DateTime.Now.Hour * 10000 + DateTime.Now.Minute * 10 + DateTime.Now.Millisecond).ToString();
                    dtr["name"] = textBox1.Text;
                    dtr["createat"] = DateTime.Now;
                    pdtb.Rows.Add(dtr);

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

        private void txtHo_Leave(object sender, EventArgs e)
        {
            if (txtHo.Text != "" && IsName(txtHo.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại Họ vì Họ không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHo.Text = "";
                txtHo.Focus();
            }
        }

        private void txtTen_Leave(object sender, EventArgs e)
        { 
            if (txtTen.Text != "" && IsName(txtTen.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại Tên vì Tên không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Text = "";
                txtTen.Focus();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && IsPhoneNumber(textBox2.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại Sdt vì Sdt không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && IsValidEmail(textBox3.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại Email vì email không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Text = "";
                textBox3.Focus();
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (IsDate(maskedTextBox1.Text) == false && maskedTextBox1.Text != "00/00/0000")
            {
                MessageBox.Show("kiểm tra lại ngày vì không đúng Format hoặc ngày sinh không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox1.Text = "00/00/0000";
                maskedTextBox1.Focus();
            }
        }
    }

}
