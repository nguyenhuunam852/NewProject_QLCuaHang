using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            label11.Visible = false;
           
            textBox8.Visible = false;
            textBox9.Visible = false;
            groupBox3.Enabled = true;
            groupBox2.Enabled = true;
            textBox5.Text = KhachHangControllers.getMaMoi();
            textBox5.Enabled = false;
            listhealth = Controllers.KhachHangControllers.getAllBenhLi1().Tables[0];
            dataGridView3.DataSource = listhealth;
            pdtb = new DataTable();
            pdtb.Columns.Add("idcustomer", typeof(int));
            pdtb.Columns.Add("idhealth", typeof(int));
            pdtb.Columns.Add("name", typeof(String));
            pdtb.Columns.Add("createat", typeof(DateTime));
            dataGridView2.DataSource = pdtb;
            textBox9.DataBindings.Clear();
            textBox9.DataBindings.Add("Text", dataGridView2.DataSource, "idhealth", true, DataSourceUpdateMode.Never);
            textBox8.DataBindings.Clear();
            textBox8.DataBindings.Add("Text", dataGridView3.DataSource, "id", true, DataSourceUpdateMode.Never);
            loadDataGridViewTenLoai();
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
            string id = textBox5.Text;
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
            int check = Controllers.KhachHangControllers.insertKhachHang(id, ten,ho, sdt, email, dc, ns, idlkh, gt, pdtb);
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

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in listhealth.Rows)
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

        private void button8_Click(object sender, EventArgs e)
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            dataGridView3.DataSource = Controllers.SucKhoeControllers.timkiem(tb.Text, pdtb).Tables[0];
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
                    dataGridView3.DataSource = Controllers.SucKhoeControllers.getBenhAvailable(pdtb).Tables[0];
                    textBox9.DataBindings.Clear();
                    textBox9.DataBindings.Add("Text", dataGridView2.DataSource, "idhealth", true, DataSourceUpdateMode.Never);
                    textBox8.DataBindings.Clear();
                    textBox8.DataBindings.Add("Text", dataGridView3.DataSource, "id", true, DataSourceUpdateMode.Never);
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

        private void textBox8_Enter(object sender, EventArgs e)
        {
            label11.Visible = true;
        }

        private void txtHo_Enter(object sender, EventArgs e)
        {
            return;
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            label11.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label11.Visible = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            label11.Visible = false;
        }
    }
}
