using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1.Views
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }
        public static FrmDangNhap fdn;
        public static FrmDangNhap getFrom()
        {
            if (fdn == null)
            {
                fdn = new FrmDangNhap();
            }
            return fdn; 
        }
        public void close()
        {
            fdn.DialogResult = DialogResult.None;
            fdn.Close();
        }
        private string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string hpassword = CreateMD5Hash(password);
            string check = UserControllers.DangNhap(username, hpassword);
            if (check=="1")
            {
                this.DialogResult = DialogResult.OK;
                UserControllers.getAllInformation();
            }
            if (check== "0")
            {
                this.DialogResult = DialogResult.Abort;
            }
            if (check == "-1")
            {
                DialogResult dlr = MessageBox.Show("Hiện tại không có tài khoản nào trong database hãy khôi phục ngay", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dlr == DialogResult.OK)
                {
                  
                    
                        
                        FrmMain.getFrmMain().khoiphucdatabase1();
                    
                }
   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
