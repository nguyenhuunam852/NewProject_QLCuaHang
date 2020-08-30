using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Views
{
    public partial class PersonalInforViews : UserControl
    {
        public PersonalInforViews()
        {
            InitializeComponent();
        }
        public static PersonalInforViews piv = new PersonalInforViews();
        private void PersonalInforViews_Load(object sender, EventArgs e)
        {
            label8.Visible = false;
            loadDataGridViewTenLoai();
            label8.Text = User.getUser().pid;
            txtHo.Text = User.getUser().pho;
            txtTen.Text = User.getUser().pten;
            txtTen.Enabled = false;
            sdtText.Text = User.getUser().psdt;
            emailText.Text = User.getUser().pemail;
            dcText.Text = User.getUser().pdc;
            nsText.Text = User.getUser().pns;
            TypeText.SelectedValue = User.getUser().pgroup;
            gtText.SelectedValue = User.getUser().pgroup;
            txtHo.Enabled = false;
            sdtText.Enabled=false;
            emailText.Enabled = false ;
            dcText.Enabled = false ;
            nsText.Enabled=false;
            TypeText.Enabled=false;
            gtText.Enabled=false;
            button3.Enabled =false;
            button4.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;

        }
        private void loadDataGridViewTenLoai()
        {

            TypeText.DataSource = Controllers.GroupUserControllers.getData().Tables[0];
            TypeText.DisplayMember = "name";
            TypeText.ValueMember = "id";
            TypeText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            gtText.Items.Clear();
            gtText.Items.Insert(0, "Nam");
            gtText.Items.Insert(1, "Nữ");
            gtText.Items.Insert(2, "None");
            gtText.SelectedIndex = 0;
            gtText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtHo.Enabled = true;
            sdtText.Enabled =true;
            emailText.Enabled = true;
            dcText.Enabled = true;
            nsText.Enabled = true;
            gtText.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            string ho = txtHo.Text;
            string sdt = sdtText.Text;
            string email = emailText.Text;
            string dc = dcText.Text;
            string ns = nsText.Text;
            int gt = 1;
            if (gtText.Text == "Nữ")
            {
                gt = 0;
            }
            if (gtText.Text == "Nam")
            {
                gt = 1;
            }
            if (gtText.Text == "None")
            {
                gt = 2;
            }
            string idlkh = TypeText.SelectedValue.ToString();
            int check = Controllers.UserControllers.updateUser(int.Parse(label8.Text), ten,ho, sdt, email, dc, ns, idlkh, gt);
            if (check > 0)
            {
                MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                User.getUser().getAllinfor();
                PersonalInforViews_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            DialogResult dlr = dmk.ShowDialog();
            if(dlr==DialogResult.OK)
            {
                MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PersonalInforViews_Load(sender, e);
        }
    }
}
