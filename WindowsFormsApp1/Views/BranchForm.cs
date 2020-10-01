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
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1.Views
{
    public partial class BranchForm : UserControl
    {
        public BranchForm()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
         
        }
        public static BranchForm brf;
        public static BranchForm GetBranchForm()
        {
            if(brf==null)
            {
                brf = new BranchForm();
            }
            return brf;
        }

        private void BranchForm_Load(object sender, EventArgs e)
        {
            savebutton = buttonStyle.saveBtn(savebutton);
            closebutton = buttonStyle.closeBtn(closebutton);

            apptokentxt.Enabled = false;
            usetokentxt.Enabled = false;
            tennhanhtxt.Enabled = false;
            codetxt.Enabled = false;
            dctxt.Enabled = false;
            tennhanhtxt.Text = Branch.getBranch().pname;
            codetxt.Text = Branch.getBranch().pcode;
            dctxt.Text = Branch.getBranch().paddress;
            apptokentxt.Text = Branch.getBranch().ptoken1;
            usetokentxt.Text = Branch.getBranch().ptoken2;
            updatebutton.Enabled = true;
            savebutton.Enabled = false;
            closebutton.Enabled = false ;
            if (MyPermission.getpermission("Branch", "update") == 0)
            {
                updatebutton.Visible = false;
                savebutton.Visible = false;
                closebutton.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            apptokentxt.Enabled = true;
            usetokentxt.Enabled = true;
            tennhanhtxt.Enabled = true;
            codetxt.Enabled = true;
            dctxt.Enabled = true;
            savebutton.Enabled = true;
            closebutton.Enabled = true;
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if(BranchControllers.updateBranch(tennhanhtxt.Text, codetxt.Text, dctxt.Text, apptokentxt.Text, usetokentxt.Text)>0)
            {
                MessageBox.Show("Thay đổi thông tin thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BranchForm_Load(sender, e);
            }
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            BranchForm_Load(sender, e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
       
        }
    }
}
