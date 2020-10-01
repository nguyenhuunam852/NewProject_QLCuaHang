using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.Models;
using System.Text.RegularExpressions;
using SharpUpdate;
using System.Reflection;

namespace WindowsFormsApp1.Views
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        int close = 0;
        private static FrmMain frm;
        public object[] list_countDown = new object[2];
        int setting = 0;
        public int firstsetting = 0;
        internal static List<byte> typePages = new List<byte>();
        private List<Label> not_active_tab = new List<Label>();
        public static FrmMain getFrmMain()
        {
            if(frm==null)
            {
                frm = new FrmMain();
                return frm;
            }
            return frm;
        }
        public void changetoKhachHang()
        {
            frm.ThemTabPages(KhachHangViews.khv, 3, "Quản lí kh");
        }
        public void changetoDatGhe()
        {
            frm.ThemTabPages(DatGheViews.getView(), 1, "Quản lí đặt ghế");
        }
        public static object[] getListCountDown()
        {
            return frm.list_countDown;
        }
        public void ThemTabPages(UserControl uct, byte typeControl, string tenTab)
        {
            // Kiểm tra tồn tại trang này chưa
            for (int i = 0; i < TabHienThi.TabPages.Count; i++)
            {
                if (TabHienThi.TabPages[i].Contains(uct) == true)
                {
                    TabHienThi.SelectedTab = TabHienThi.TabPages[i];
                    return;
                }
            }
            TabPage tab = new TabPage();
            typePages.Add(typeControl);
            tab.Name = uct.Name;
            tab.Size = TabHienThi.Size;
            tab.Text = tenTab;
            TabHienThi.TabPages.Add(tab);
            TabHienThi.SelectedTab = tab;
            uct.Dock = DockStyle.Fill;
            tab.Controls.Add(uct);
            uct.Focus();

        }
        private void quảnLíBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        public void ThemUser()
        {
            FrmDangNhap.getFrom().Hide();
            BranchSelection bs = new BranchSelection();
            DialogResult dlr1 = bs.ShowDialog();
            setting = 1;
            if (dlr1 == DialogResult.OK)
            {
                SettingViews.stv = null;
                FrmMain.dongALL();
                FrmMain.getFrmMain().firstsetting = 1;

                while (User.getUser().pid == null)
                {
                    FrmMain.getFrmMain().getSetting();
                }

            }
            if (dlr1 == DialogResult.Abort)
            {
                GroupUserControllers.insertAdmin(bs.br);
                SettingViews.stv = null;
                FrmMain.dongALL();

                FrmMain.getFrmMain().gotoQLUser();

            }

        }
        private bool checkPath(string path)
        {
            Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
            if (string.IsNullOrWhiteSpace(path) || path.Length < 3)
            {
                return false;
            }

            if (!driveCheck.IsMatch(path.Substring(0, 3)))
            {
                return false;
            }
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
            strTheseAreInvalidFileNameChars += @":/?*" + "\"";
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
            if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
            {
                return false;
            }
            return true;

        }
        public void getSetting()
        {
           
            DateTime dateTime = DateTime.Now;
            RemoveAll();
            loadAllPage();
            flowLayoutPanel1.Visible = false;
            groupBox2.Visible =true;

            if (getFirstSetting() == 1)
            {
               
                if (SettingsControllers.getInformation() != null)
                {

                    if (checkPath(Settings.getSettings().ppicture) == true)
                    {
                        Image img = Image.FromFile(Settings.getSettings().ppicture);
                        pictureBox1.Image = img;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                     
                    SettingViews.getViews().kt = 1;
                    if (firstsetting == 1)
                    {
                        MessageBox.Show("Đây là lần Config đầu tiên của bạn chúng tôi sẽ tiến hành Backup tại " + Settings.getSettings().psavebakfile, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (BackupControllers.backupData(Settings.getSettings().psavebakfile) >= -1)
                        {
                            MessageBox.Show("Backup thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            firstsetting = 0;
                        }
                        else
                        {
                            MessageBox.Show("Backup thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                    if (User.getUser().pid == null)
                    {

                  
                        
                        DialogResult dlr = FrmDangNhap.getFrom().ShowDialog();
                        if (dlr == DialogResult.OK)
                        {
                            BranchControllers.getInformationofBranch(User.getUser().pbranch);
                            groupBox2.Visible = false;
                            int sig = 0;
                            int check;
                            while ((check = MainControllers.checkExist(dateTime)) != 3)
                            {
                                if(check==4)
                                {
                                    MessageBox.Show("Có vẻ thời gian trong hệ thống không đồng bộ, hãy kiểm tra lại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                if (check == 1)
                                {
                                    DialogResult dlr1;
                                    if (sig == 0)
                                    {
                                        dlr1 = MessageBox.Show("Bạn chưa chốt ca những ngày gần đây,tiến hành chốt ca để tiếp tục làm việc Ngày:" + dateTime.Day.ToString() + '/' + dateTime.Month.ToString() + '/' + dateTime.Year.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        dlr1 = MessageBox.Show("tiến hành chốt ca cho ngày:" + dateTime.Day.ToString() + '/' + dateTime.Month.ToString() + '/' + dateTime.Year.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    if (dlr1 == DialogResult.OK)
                                    {
                                        FrmTongKet ftk = new FrmTongKet(dateTime);
                                        DialogResult wait = ftk.ShowDialog();
                                        if (wait == DialogResult.OK)
                                        {
                                            int check1 = Controllers.ThongKeControllers.ChotCaTheoNgay(dateTime);
                                            if (check1 > 0)
                                            {
                                                MessageBox.Show("Chốt ca thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        if (sig == 0)
                                        {
                                            sig = 1;
                                        }
                                    }
                                }
                                dateTime = dateTime.AddDays(-1);
                            }
                            if (MyPermission.getpermission("DeskCustomer", "view") == 1)
                            {
                                ThemTabPages(DatGheViews.getView(), 1, "Quản lí đặt ghế");
                            }
                            LoadAgain();
                            loadPermissionMs();
                            foreach (Control control in flowLayoutPanel1.Controls)
                            {
                                Label lb = control as Label;
                                if (control.BackColor == Color.MidnightBlue)
                                {
                                    if (not_active_tab.Contains(lb) == false)
                                    {
                                        lb.Visible = false;
                                        lb.MouseHover += Control_MouseHover;
                                        lb.MouseLeave += Control_MouseLeave;
                                    }
                                    else
                                    {
                                        lb.Visible = false;
                                    }
                                }
                            }
                            flowLayoutPanel1.Visible = true;
                        }
                        else if (dlr == DialogResult.Abort)
                        {
                            MessageBox.Show("Sai tài khoản và mật khẩu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                        }
                        else if (dlr == DialogResult.No)
                        {
                            this.Close();
                            close = 1;
                        }
                    }
                }
            }
           
        }

        private void loadPermissionMs()
        {
            if (MyPermission.getpermission("DeskCustomer", "view") == 0)
            {
                not_active_tab.Add(TabQlDatGhe);
            }
          
            if (MyPermission.getpermission("Desk", "view") == 0)
            {
                not_active_tab.Add(TabGhe);
            }
            if (MyPermission.getpermission("Branch", "view") == 0)
            {
                not_active_tab.Add(Tabthongtinchinhanh);
            }
            if (MyPermission.getpermission("Customer", "view") == 0)
            {
                not_active_tab.Add(TabKhachHang);
            }
            if (MyPermission.getpermission("TypeCustomer", "view") == 0)
            {
                not_active_tab.Add(TabLoaiKhachHang);
            }
            if (MyPermission.getpermission("Health", "view") == 0)
            {
                not_active_tab.Add(TabSucKhoe);
            }
            if (MyPermission.getpermission("History", "view") == 0 && MyPermission.getpermission("Statical","view")==0)
            {
                not_active_tab.Add(TabThongKe);
            }
            if (MyPermission.getpermission("User", "view") == 0)
            {
                not_active_tab.Add(TabUsers);
            }
            if (MyPermission.getpermission("Groupuser", "view") == 0)
            {
                not_active_tab.Add(TabGroupUsers);
            }
           
          
        }
        public void lostConnect()
        {
            groupBox2.Hide();
            DialogResult dlr = MessageBox.Show("không thể kết nối tới DataBase,bạn sẽ được chuyển hướng tới trang Settings", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (dlr == DialogResult.OK)
            {

                dongALL();
                loadAllPage();
                FrmDangNhap.getFrom().Hide();
                
                setting = 1;
                SettingViews s = SettingViews.getViews();
                s.firstsetting = 1;
             
                ThemTabPages(SettingViews.stv, 1, "Settings");
            }
            else
            {
                this.Close();
            }
        }
        public void gotoSettings()
        {
            dongALL();
            ThemTabPages(SettingViews.stv, 1, "Settings");
        }
        public void gotoQLUser()
        {
            groupBox2.Hide();
            dongALL();
            ViewsUser v = ViewsUser.vu;
            v.firstSettings = 1;
            ThemTabPages(ViewsUser.vu, 1, "Users");
        }

        public void khoiphucdatabase()
        {
            groupBox2.Hide();
            DialogResult dlr = MessageBox.Show("Bạn cần tìm tới danh sách các file .Bak đã lưu để khôi phục lại database của bạn", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dlr == DialogResult.OK)
            {
                FrmDangNhap.getFrom().Hide();
                setting = 1;
                BackupViews buv = BackupViews.bu;
                buv.sig = 1;
                
                ThemTabPages(buv, 1, "Backup");
            }
            else
            {
                this.Close();
            }
        }
        public void themTk()
        {
            groupBox2.Hide();
            FrmDangNhap.getFrom().Hide();
            setting = 1;
            ViewsUser buv = ViewsUser.getUserView();
            buv.firstSettings = 1;
            ThemTabPages(buv, 1, "Backup");
            
        }
        public void khoiphucdatabase1()
        {
            groupBox2.Hide();
            DialogResult dlr = MessageBox.Show("Bạn cần tìm tới danh sách các file .Bak đã lưu để khôi phục lại database của bạn", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dlr == DialogResult.OK)
            {
                FrmDangNhap.getFrom().Hide();
                setting = 1;
                BackupViews buv = BackupViews.bu;
                buv.sig = 2;
                buv.defaultPath = Settings.getSettings().psavebakfile;
                ThemTabPages(buv, 1, "Backup");
            }
            else
            {
                this.Close();
            }
        }
        private void LoadAgain()
        {
            foreach(Control tsmi in flowLayoutPanel1.Controls)
            {
                tsmi.Visible = true;
            }

        }
        private SharpUpdater updater;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            label1.Text = ProductVersion;
        
            
          

            Image myimage = new Bitmap(Directory.GetCurrentDirectory()+"\\picture\\bgp.jpg");
            groupBox2.BackgroundImage = myimage;
          
            setting = 0;
            getSetting();

          

            if (User.getUser().pid == null && close != 1 && setting !=1)
            {
                FrmMain_Load(sender, e);
            }
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            lb.BackColor = Color.MidnightBlue;
            lb.ForeColor = Color.White;
        }

        private void Control_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            lb.BackColor = Color.White;
            lb.ForeColor = Color.Black;
        }

        private int getFirstSetting()
        {
           return MainControllers.ReadFile();
        }


        public void DongTabHienTai()
        {
            TabHienThi.TabPages.Remove(TabHienThi.SelectedTab);
        }
        public static void dongALL()
        {
            int i = 0;
            while (frm.TabHienThi.TabPages.Count > 0)
            {
                if (i==0)
                {
                    frm.TabHienThi.TabPages.Remove(frm.TabHienThi.TabPages[i]);
                    
                }
            }
        }
        private void đóngTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 1;
            while(TabHienThi.TabPages.Count>1)
            {
                if(i==1)
                {
                    TabHienThi.TabPages.Remove(TabHienThi.TabPages[i]);
                }
                
            }
        }
        public void reload()
        {
            int i = 1;
            while (TabHienThi.TabPages.Count > 1)
            {
                if (i == 1)
                {
                    TabHienThi.TabPages.Remove(TabHienThi.TabPages[i]);
                }

            }
        }
        private void RemoveAll()
        {
            int i = 0;
            while (TabHienThi.TabPages.Count > 0)
            {
                    TabHienThi.TabPages.Remove(TabHienThi.TabPages[i]);
            }
        }

        private void quảnLíKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void lịchSửVàThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingViews st = SettingViews.getViews();
            st.kt = 1;
            ThemTabPages(st, 5, "Settings");
        }

        private void quảnLíTypeKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(ViewsLoaiKhachHang.vlkh, 10, "Loại khách hàng");
        }

        private void quảnLíGroupUSerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(GroupUserViews.guv, 6, "Group Users") ;
        }

        private void quảnLíUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(ViewsUser.vu, 7, "Users");
        }
        private void loadAllPage()
        {
            DatGheViews.fdg = null;
            GheViews.dv = new GheViews();
            GroupUserViews.guv = new GroupUserViews();
            KhachHangViews.khv = new KhachHangViews();
            PersonalInforViews.piv = new PersonalInforViews();
            
            ThongKeViews.tkv = new ThongKeViews();
            ViewsUser.vu = new ViewsUser();
            ViewsSucKhoe.vsk = new ViewsSucKhoe();
            ViewsLoaiKhachHang.vlkh = new ViewsLoaiKhachHang();
            BackupViews.bu = new BackupViews();
        }
        private void dangToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(PersonalInforViews.piv, 8, "Personal Information");
        }

        private void QLsk_Click(object sender, EventArgs e)
        {
            ThemTabPages(ViewsSucKhoe.vsk, 9, "Sức khỏe");
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(BackupViews.bu,11, "Backup");
        }
        
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void TabHienThi_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }
        int thd = 0;
        private void TabHoatDong_Click(object sender, EventArgs e)
        {
            if(thd==0)
            {
                if (!not_active_tab.Contains(TabQlDatGhe))
                {
                    TabQlDatGhe.Visible = true;
                }
                if (!not_active_tab.Contains(TabThongTinCaNhan))
                {
                    TabThongTinCaNhan.Visible = true;
                }
                if (!not_active_tab.Contains(Tabthongtinchinhanh))
                {
                    Tabthongtinchinhanh.Visible = true;
                }
                if (!not_active_tab.Contains(TabThongKe))
                {
                    TabThongKe.Visible = true;
                }
                thd += 1;
            }
            else if(thd==1)
            {
                TabQlDatGhe.Visible = false;
                TabThongTinCaNhan.Visible = false;
                Tabthongtinchinhanh.Visible = false;
                TabThongKe.Visible = false;
                thd -= 1;
            }
        }
        int tql = 0;
        private void TabQuanLi_Click(object sender, EventArgs e)
        {
            if (tql == 0)
            {
                if (!not_active_tab.Contains(TabGhe))
                {
                    TabGhe.Visible = true;
                }
                if (!not_active_tab.Contains(TabKhachHang))
                {
                    TabKhachHang.Visible = true;
                }
                if (!not_active_tab.Contains(TabLoaiKhachHang))
                {
                    TabLoaiKhachHang.Visible = true;
                }
                if (!not_active_tab.Contains(TabSucKhoe))
                {
                    TabSucKhoe.Visible = true;
                }
                if (!not_active_tab.Contains(TabUsers))
                {
                    TabUsers.Visible = true;
                }
                if (!not_active_tab.Contains(TabGroupUsers))
                {
                    TabGroupUsers.Visible = true;
                }
                tql += 1;
            }
            else if(tql==1)
            {
                TabGhe.Visible = false;
                TabKhachHang.Visible = false;
                TabLoaiKhachHang.Visible = false;
                TabSucKhoe.Visible = false;
                TabUsers.Visible = false;
                TabGroupUsers.Visible = false;
                tql -= 1;
            }
        }
        int tcd = 0;
        private void TabCaiDat_Click(object sender, EventArgs e)
        {
            if (tcd == 0)
            {
                TabSettings.Visible = true;
                TabBackUps.Visible = true;
                TabUpdate.Visible = true;
                tcd += 1;
            }
            else if(tcd==1)
            {
                TabSettings.Visible = false;
                TabBackUps.Visible = false;
                TabUpdate.Visible = false;
                tcd -= 1;
            }

        }

        private void TabQlDatGhe_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void TabThongTinCaNhan_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void Tabthongtinchinhanh_Click(object sender, EventArgs e)
        {
            ThemTabPages(BranchForm.GetBranchForm(), 12, "Chi nhánh");
        }

        private void TabThongKe_Click(object sender, EventArgs e)
        {
            ThemTabPages(ThongKeViews.tkv, 4, "Thống kê");
        }

        private void TabGhe_Click(object sender, EventArgs e)
        {
            ThemTabPages(GheViews.dv, 2, "Quản lí ghế");
        }

        private void TabKhachHang_Click(object sender, EventArgs e)
        {
            ThemTabPages(KhachHangViews.khv, 3, "Khách Hàng");
        }

        private void TabThongTinCaNhan_Click(object sender, EventArgs e)
        {
            ThemTabPages(PersonalInforViews.piv, 8, "Personal Information");
        }

        private void Tabthongtinchinhanh_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void TabThongKe_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void TabGhe_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void TabKhachHang_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void TabLoaiKhachHang_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void TabSucKhoe_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void TabUsers_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void TabGroupUsers_Move(object sender, EventArgs e)
        {
          
        }

        private void TabSettings_Click(object sender, EventArgs e)
        {
            SettingViews st = SettingViews.getViews();
            st.kt = 1;
            ThemTabPages(st, 5, "Settings");
        }

        private void TabSettings_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void TabBackUps_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void TabUpdate_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void TabQlDatGhe_Click(object sender, EventArgs e)
        {
            ThemTabPages(DatGheViews.getView(), 1, "Quản lí đặt ghế");
        }

        private void TabLoaiKhachHang_Click(object sender, EventArgs e)
        {
            ThemTabPages(ViewsLoaiKhachHang.vlkh, 10, "Loại khách hàng");
        }

        private void TabSucKhoe_Click(object sender, EventArgs e)
        {
            ThemTabPages(ViewsSucKhoe.vsk, 9, "Sức khỏe");
        }

        private void TabUsers_Click(object sender, EventArgs e)
        {
            ThemTabPages(ViewsUser.vu, 7, "Users");
        }

        private void TabGroupUsers_Click(object sender, EventArgs e)
        {
            ThemTabPages(GroupUserViews.guv, 6, "Group Users");
        }

        private void TabBackUps_Click(object sender, EventArgs e)
        {
            ThemTabPages(BackupViews.bu, 11, "Backup");
        }

        private void TabUpdate_Click(object sender, EventArgs e)
        {
            updater = new SharpUpdater(Assembly.GetExecutingAssembly(), this, new Uri("https://namute17110185.000webhostapp.com/vietnhatjp/update.xml"));
            updater.DoUpdate();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            MainControllers.DangXuat();
            loadAllPage();
            not_active_tab = new List<Label>();
            FrmMain_Load(sender, e);
        }
    }
}
