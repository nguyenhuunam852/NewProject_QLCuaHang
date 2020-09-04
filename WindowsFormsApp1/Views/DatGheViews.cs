using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using WindowsFormsApp1.Controllers;
using System.IO;
using WindowsFormsApp1.Models;
using System.Collections.Specialized;
using WindowsFormsApp1.Views.ViewsThongKe;

namespace WindowsFormsApp1.Views
{
    public partial class DatGheViews : UserControl
    {
        public DatGheViews()
        {
            InitializeComponent();
        }
        public static DatGheViews fdg = new DatGheViews();
        static List<Label> lbs = new List<Label>();
        public DataSet dts = new DataSet();
        public DataSet check = new DataSet();
        public List<Label> count_down = new List<Label>();
        public Dictionary<string, Label> truyxuat = new Dictionary<string, Label>();
        public static DatGheViews getView()
        {
            if (fdg == null)
            {
                fdg = new DatGheViews();
                return fdg;
            }
            return fdg;
        }
        public static void setTextBox(string id)
        {
            FrmMain.getFrmMain().changetoDatGhe();
        }

        //Hàm sử lí Load
        public Label createLabelfrmLabel(Label ctr)
        {
            Label lb = new Label();
            lb.Name = ctr.Name;
            lb.BackColor = ctr.BackColor;
            lb.Location = ctr.Location;
            lb.Size = ctr.Size;
            lb.TextAlign = ctr.TextAlign;
            lb.Text = ctr.Text;

            return lb;
        }
        private void DataBinding()
        {
            txtId.DataBindings.Clear();
            txtId.DataBindings.Add("Text", check.Tables[0], "id");
            txtCode.DataBindings.Clear();
            txtCode.DataBindings.Add("Text", check.Tables[0], "code");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", check.Tables[0], "hoten");
            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", check.Tables[0], "phone");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", check.Tables[0], "email");
            txtDC.DataBindings.Clear();
            txtDC.DataBindings.Add("Text", check.Tables[0], "address");
            MtxtNS.DataBindings.Clear();
            MtxtNS.DataBindings.Add("Text", check.Tables[0], "birthday");
            txtType.DataBindings.Clear();
            txtType.DataBindings.Add("Text", check.Tables[0], "typename");
            txtSex.DataBindings.Clear();
            txtSex.DataBindings.Add("Text", check.Tables[0], "sex");
        }
        private void loadPermission()
        {
            if (MyPermission.getpermission("Customer", "insert") == 0)
            {
                button2.Visible = false;
            }
            if (MyPermission.getpermission("DeskCustomer", "insert") == 0)
            {
                button1.Visible = false;
            }
            if (MyPermission.getpermission("DeskCustomer", "delete") == 0)
            {
                button8.Visible = false;
            }
            if (MyPermission.getpermission("Statical", "insert") == 0)
            {
                button3.Visible = false;
            }
        }
        public void themSuKien(Label lb)
        {
            lb.Click += Lb_Click;
        }
        public static List<Label> getgroupBox()
        {
            lbs = new List<Label>();
            if (fdg != null)
            {
                if (fdg.groupBox1.Controls.Count == 0)
                {
                    return new List<Label>();
                }
                foreach (Label ctr in fdg.groupBox1.Controls)
                {
                    lbs.Add(fdg.createLabelfrmLabel(ctr));
                }
            }
            return lbs;
        }
        public static List<Label> getCountDownList()
        {
            return fdg.count_down;
        }
        public static void refreshGroupBox()
        {
            lbs = GheViews.getgroupBox();
            foreach (Label ctr in lbs)
            {
                int sig = 0;
                foreach (Label lb in fdg.groupBox1.Controls)
                {
                    if (lb.Name == ctr.Name)
                    {
                        sig = 1;
                        lb.Location = ctr.Location;
                        lb.BackColor = ctr.BackColor;
                        if(fdg.count_down.Contains(lb)==false)
                        {
                            lb.Text = ctr.Text;
                        }
                        break;
                    }
                }
                if (sig == 0)
                {
                    Label lb = new Label();
                    lb = fdg.createLabelfrmLabel(ctr);
                    fdg.truyxuat.Add(ctr.Name, lb);
                    fdg.groupBox1.Controls.Add(lb);
                    fdg.themSuKien(lb);
                }
                fdg.LoadDuLieu();
            }
        }
        public static void deleteGroupBox(string id)
        {
            fdg.groupBox1.Controls.Remove(fdg.truyxuat[id]);
            fdg.truyxuat.Remove(id);
        }
        private void reloadUI()
        {
            int c = groupBox1.Controls.Count;
            for (int i = c - 1; i >= 0; i--)
                groupBox1.Controls.Remove(groupBox1.Controls[i]);
        }

        private void themUI()
        {
            reloadUI();
            foreach (DataRow row in dts.Tables[0].Rows)
            {
                string id = row["id"].ToString();
                string tinhtrang = row["status"].ToString();
                string lx = row["locationX"].ToString();
                string ly = row["locationY"].ToString();
                string tenban = row["name"].ToString();
                object[] ghe = { id, tinhtrang, lx, ly, tenban };
                truyxuat.Add(id, createLabel(ghe));
                groupBox1.Controls.Add(truyxuat[id]);
            }
            LoadText();
        }
        private void LoadText()
        {
            DataTable dtb = DatGheControllers.layDSHoatDong().Tables[0];
            
            foreach (DataRow row in dtb.Rows)
            {
                string id = row["iddesk"].ToString();
                string tg = row["createat"].ToString();
                string activetime = row["activetime"].ToString()+":00";
                DateTime dt = Convert.ToDateTime(activetime);
                TimeSpan value = DateTime.Now.Subtract(Convert.ToDateTime(tg));
                DateTime hd = new DateTime(1977,1,1,hour:0,minute:0,second:0) + value;
                if (dt.Hour <= hd.Hour && dt.Minute<=hd.Minute && dt.Second<=hd.Second)
                {
                    string txt = "00:00:00";
                    truyxuat[id].Text = txt;
                    count_down.Add(truyxuat[id]);
                }
                else
                {
                    TimeSpan tghd = dt.Subtract(hd);
                    DateTime r = new DateTime(1977, 1, 1, hour: 0, minute: 0, second: 0) + tghd;
                    string txt = GetNumberString(r.Hour) + ":" + GetNumberString(r.Minute) + ":" + GetNumberString(r.Second);
                    truyxuat[id].Text = txt;
                    count_down.Add(truyxuat[id]);
                }
            }
        }
        private Label createLabel(object[] infor)
        {
            Label lb = new Label();
            if (infor[1].ToString() == "1")
            {
                //hoat động là màu xanh 
                lb.BackColor = Color.FromArgb(135, 206, 250);
            }
            else
            {
                //Bảo trì là màu đỏ
                lb.BackColor = Color.FromArgb(240, 128, 128);
            }
            lb.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            lb.Location = new System.Drawing.Point(int.Parse(infor[2].ToString()), int.Parse(infor[3].ToString()));
            lb.Name = infor[0].ToString();
            lb.Text = infor[4].ToString();//Lấy số trong id Bàn
            lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lb.Size = new Size(groupBox1.Size.Width / 10, groupBox1.Size.Height / 10);
            lb.Click += Lb_Click;
            return lb;
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            label2.Text = lbl.Name;
            check = Controllers.DatGheControllers.laytinhtrangHoatDong(label2.Text);
            if (check.Tables[0].Rows.Count > 0)
            {
                DataBinding();
                button1.Enabled = false;
                button8.Enabled = true;
                label12.Text = check.Tables[0].Rows[0]["tenghe"].ToString();
            }
            else if(textBox5.Text!="")
            {
                button1.Enabled = true;
                button8.Enabled = false;
                label12.Text = lbl.Text;
                return;
            }
            else if (check.Tables[0].Rows.Count == 0)
            {
                txtCode.Text = "";
                txtTen.Text = "";
                txtSdt.Text = "";
                txtEmail.Text = "";
                txtDC.Text = "";
                MtxtNS.Text = "";
                button1.Enabled = true;
                button8.Enabled = false;
                label12.Text = lbl.Text;
            }
            
        }




        public void LoadDuLieu()
        {
            dts = Controllers.GheControllers.LayThongTinGhe();
        }
        private void taoTrangThai()
        {
            button2.Enabled = true;
            button4.Enabled = true;
            button1.Enabled = false;
            button8.Enabled = false;
        }

        private string GetNumberString(int n)
        {
            if (n < 10)
            {
                return "0" + n.ToString();
            }
            else
            {
                return n.ToString();
            }
        }
        private void DatGheViews_Load(object sender, EventArgs e)
        {
            
            loadPermission();
            label2.Visible = false;
            txtId.Visible = false;
            groupBox4.Enabled = false;
            LoadDuLieu();
            taoTrangThai();
            lbs = GheViews.getgroupBox();
            txtCode.Enabled = false;
            txtTen.Enabled = false;
            txtSdt.Enabled = false;
            txtEmail.Enabled = false;
            txtDC.Enabled = false;
            MtxtNS.Enabled = false;

            if (lbs.Count == 0)
            {
                themUI();
            }
            Timer time = new Timer()
            {
                Interval = 1000
            };


            time.Start();
            time.Tick += Time_Tick;
        }
        private void countdown(Label lb)
        {
            string[] time = lb.Text.Split(':');
            int hh = Convert.ToInt32(time[0]);
            int mm = Convert.ToInt32(time[1]);
            int ss = Convert.ToInt32(time[2]);
            if (ss == 0 && mm == 0 && hh == 0) { }
            else
            {
                ss -= 1;
                if (ss < 0) { mm -= 1; ss = 59; }
                if (mm < 0) { hh -= 1; mm = 59; }

                string hour = hh.ToString();
                if (hh < 10) { hour = "0" + hour; }
                string minute = mm.ToString();
                if (mm < 10) { minute = "0" + minute; }
                string second = ss.ToString();
                if (ss < 10)
                {
                    second = "0" + second;
                }

                lb.Text = hour + ":" + minute + ":" + second;
            }

        }

        private void Time_Tick(object sender, EventArgs e)
        {
            foreach (Label lb in count_down)
            {
               
                if (lb.Text == "00:00:00")
                {
                    lb.BackColor = Color.Green;
                }
                else
                {
                    countdown(lb);
                }
            }
            string[] th = Settings.getSettings().ptgbd.Split(':');
            DateTime a = DateTime.Now;
            string[] ho = a.ToString("HH:mm").Split(':');


            if (int.Parse(ho[0]) > int.Parse(th[0]) && int.Parse(ho[1])>int.Parse(th[1]))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }
        private void create_Label(Label lb)
        {
            lb.Text = Settings.getSettings().ptghd+":00";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                if (label2.Text != "")
                {
                    
                    int check2 = DatGheControllers.CheckKH(txtId.Text);
                    if (check2> 0)
                    {
                        DialogResult dlr2 = MessageBox.Show("Khách hàng đã dùng dịch vụ trong hôm nay bạn sẽ cho họ dùng lại chứ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dlr2 == DialogResult.Yes)
                        {
                            check2 = 0;
                        }
                    }
                 
                    if (check2==0)
                    {
                       
                        int check = DatGheControllers.InsertHoatDong(txtId.Text, label2.Text);
                        if (check > 0)
                        {
                            DialogResult dlr = MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dlr == DialogResult.OK)
                            {
                                create_Label(truyxuat[label2.Text]);
                                count_down.Add(truyxuat[label2.Text]);
                                textBoxbuttonRefessh();
                            }
                        }
                        if (check == -1)
                        {
                            MessageBox.Show("Ghế đang bảo trì", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (check == -2)
                        {
                            MessageBox.Show("Ghế đang phục vụ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                   

                }
                else
                {
                    MessageBox.Show("Chọn ghế chỉ định", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Thêm thông tin khách hàng", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThemKhachHang tkh = new ThemKhachHang();
            if(tkh.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxbuttonRefessh();
        }
        private void textBoxbuttonRefessh()
        {
            label12.Text = "";
            txtType.Text = "";
            txtSex.Text = "";
            textBox5.Text = "";
            txtCode.Text = "";
            txtTen.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
            txtDC.Text = "";
            txtId.Text = "";
            MtxtNS.Text = "";
            label2.Text = "";
            taoTrangThai();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (txtCode.Text != "")
            {
                int check = Controllers.DatGheControllers.Ketthucdatghe(label2.Text, txtId.Text, truyxuat[label2.Text].Text,Settings.getSettings().ptghd);
                if (check > 0)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (DataRow row in dts.Tables[0].Rows)
                    {
                        if (label2.Text == row["id"].ToString())
                        {
                            truyxuat[label2.Text].Text = row["name"].ToString();
                            truyxuat[label2.Text].BackColor = Color.FromArgb(135, 206, 250);
                        }
                    }
                    count_down.Remove(truyxuat[label2.Text]);
                    textBoxbuttonRefessh();
                    ViewsThongKeNgay.vtkngay.load();
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Chọn Bàn trước", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Controllers.DatGheControllers.Ketthucdatghe(label2.Text, textBox5.Text, "00:20:00");
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }




        DataTable a;
        int sig = 0;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            if (MyPermission.getpermission("Customer", "view") == 1)
            {

                if (sig == 0)
                {
                    TextBox txt = sender as TextBox;
                    a = KhachHangControllers.TimKiemTatCa1(txt.Text).Tables[0];
                    if (txt.Text == "" || a.Rows.Count == 0)
                    {
                        comboBox1.Enabled = false;
                        comboBox1.Text = "";
                        txtCode.Text = "";
                        txtTen.Text = "";
                        txtSdt.Text = "";
                        txtDC.Text = "";
                        txtEmail.Text = "";
                        txtType.Text = "";
                        txtSex.Text = "";
                        txtId.Text = "";
                    }
                    else
                    {
                        comboBox1.Enabled = true;
                        comboBox1.DataSource = a;
                        comboBox1.DisplayMember = "hoten";
                        comboBox1.ValueMember = "id";
                        comboBox1.DroppedDown = true;
                    }


                    Cursor.Current = Cursors.Default;
                }
            }
    
        }


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (a.Rows.Count>0 && textBox5.Text!="")
            {
                sig = 1;
                textBox5.Text = comboBox1.Text;
            }
        }
      
        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {
            if(sig==1)
            {
                textBox5.Text = comboBox1.Text;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sig == 1)
            {
                if (comboBox1.SelectedValue != null)
                {
                    DataTable a = KhachHangControllers.LayThongTinKH(int.Parse(comboBox1.SelectedValue.ToString())).Tables[0];
                    txtId.Text = a.Rows[0]["id"].ToString();
                    txtCode.Text = a.Rows[0]["code"].ToString();
                    txtTen.Text = a.Rows[0]["hoten"].ToString();
                    txtSdt.Text = a.Rows[0]["phone"].ToString();
                    txtDC.Text = a.Rows[0]["address"].ToString();
                    txtEmail.Text = a.Rows[0]["email"].ToString();
                    txtType.Text = a.Rows[0]["typename"].ToString();
                    txtSex.Text = a.Rows[0]["sex"].ToString();
                    MtxtNS.Text = a.Rows[0]["birthday"].ToString();
                    sig = 0;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            FrmTongKet ftk = new FrmTongKet(dt);
            DialogResult wait = ftk.ShowDialog();
            if (wait == DialogResult.OK)
            {
                int check = Controllers.ThongKeControllers.KTChotCa();
                if (check == 0)
                {
                    int check1 = Controllers.ThongKeControllers.ChotCa();
                    if (check1 > 0)
                    {
                        DialogResult dlr = MessageBox.Show("Chốt ca thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewsThongKe.Views.GetViews(0).load();
                        ViewsThongKe.Views.GetViews(1).load();
                        ViewsThongKe.Views.GetViews(2).load();
                        ViewsThongKe.Views.GetViews(3).load();
                    }
                    else
                    {
                        DialogResult dlr = MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    DialogResult dlr = MessageBox.Show("Bạn đã chốt ca hôm nay,bạn có muốn làm lại", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlr == DialogResult.Yes)
                    {
                        int check1 = Controllers.ThongKeControllers.ChotCa();
                        if (check1 > 0)
                        {
                            MessageBox.Show("Chốt ca thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DatGheViews_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void groupBox1_SizeChanged(object sender, EventArgs e)
        {
            foreach (Label lb in groupBox1.Controls)
            {
                lb.Size = new Size(groupBox1.Size.Width / 10, groupBox1.Size.Height / 10);
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
             
              
                    if (comboBox1.SelectedValue != null)
                    {
                       
                        DataTable a = KhachHangControllers.LayThongTinKH(int.Parse(comboBox1.SelectedValue.ToString())).Tables[0];
                        txtId.Text = a.Rows[0]["id"].ToString();
                        txtCode.Text = a.Rows[0]["code"].ToString();
                        txtTen.Text = a.Rows[0]["hoten"].ToString();
                        txtSdt.Text = a.Rows[0]["phone"].ToString();
                        txtDC.Text = a.Rows[0]["address"].ToString();
                        txtEmail.Text = a.Rows[0]["email"].ToString();
                        txtType.Text = a.Rows[0]["typename"].ToString();
                        txtSex.Text = a.Rows[0]["sex"].ToString();
                        textBox5.Text = txtTen.Text;    
                        MtxtNS.Text = a.Rows[0]["birthday"].ToString();
                        comboBox1.Enabled = false;
                        sig = 0;
                    }
                comboBox1.Enabled = true;

            }
            if(e.KeyCode==Keys.Up)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex -= 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (comboBox1.SelectedIndex == comboBox1.Items.Count-1)
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex += 1;
                }
            }
        }
    }
}
