using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.Models;

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
            if(check==null)
            {
                this.DialogResult = DialogResult.No;
            }
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
                    FrmMain.getFrmMain().ThemUser();
                }
   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void FrmDangNhap_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://dev.hahe.vn/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(30.0);

            var values = new JObject();
            values.Add("totalcustome", "10");
            values.Add("totalnewcustome", "11");
            values.Add("apptoken", "123456789");
            values.Add("usetoken", "abc");

            // this is not set!!!
            HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

            var response = client.PostAsJsonAsync("devapi", content).Result;
            return;
        }
    }
}
