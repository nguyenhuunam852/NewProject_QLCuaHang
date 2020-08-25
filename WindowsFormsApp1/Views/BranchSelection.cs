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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Views
{
    public partial class BranchSelection : Form
    {
        public BranchSelection()
        {
            InitializeComponent();
        }
        public int br;
        private void BranchSelection_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            groupBox1.Enabled = false;
            comboBox1.DataSource = BranchControllers.getData();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BranchSelection_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int check=BranchControllers.insertBranch(textBox1.Text, textBox2.Text);
            if(check>0)
            {
                MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BranchSelection_Load(sender, e);
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = UserControllers.CountUserinBranch(int.Parse(comboBox1.SelectedValue.ToString()));
            if(count>0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult dlr= MessageBox.Show("Có vẻ chi nhánh này chưa có tài khoản hãy tạo ngay", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(dlr==DialogResult.Yes)
                {
                    br = int.Parse(comboBox1.SelectedValue.ToString());
                    User.getUser().pbranch = br;
                    this.DialogResult = DialogResult.Abort;
                }    
            }
        }
    }
}
