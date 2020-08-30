﻿using Newtonsoft.Json;
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

namespace WindowsFormsApp1.Views
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        int close = 0;
        private static FrmMain frm;
        public object[] list_countDown = new object[2];
        int setting = 0;
        public int firstsetting = 0;
        internal static List<byte> typePages = new List<byte>();
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
            ThemTabPages(GheViews.dv, 2 , "Quản lí ghế");
        }
        
        public void getSetting()
        {
           
            DateTime dateTime = DateTime.Now;
            RemoveAll();
            loadAllPage();
            msUserControl.Visible = false;
            groupBox1.Visible = true;
            if (getFirstSetting() == 1)
            {
               
                if (SettingsControllers.getInformation() != null)
                {
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

                        groupBox1.Controls.Add(new firstpage());
                        
                        DialogResult dlr = FrmDangNhap.getFrom().ShowDialog();
                        if (dlr == DialogResult.OK)
                        {
                            groupBox1.Visible = false;
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
                            msUserControl.Visible = true;
                        }
                        else if (dlr == DialogResult.Abort)
                        {
                            MessageBox.Show("Sai tài khoản và mật khẩu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else if (dlr == DialogResult.Cancel)
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
            if (MyPermission.getpermission("DeskCustomer", "view") == 1)
            {
                ThemTabPages(DatGheViews.getView(), 1, "Quản lí đặt ghế");
            }
          
            if (MyPermission.getpermission("Desk", "view") == 0)
            {
                QLGhe.Visible = false;
            }
            if (MyPermission.getpermission("Customer", "view") == 0)
            {
                QLkhachhang.Visible = false;
            }
            if (MyPermission.getpermission("TypeCustomer", "view") == 0)
            {
                QLloaiKH.Visible = false;
            }
            if (MyPermission.getpermission("Health", "view") == 0)
            {
                QLsk.Visible = false;
            }
            if (MyPermission.getpermission("History", "view") == 0 && MyPermission.getpermission("Statical","view")==0)
            {
                QLlichSu.Visible = false;
            }
            if (MyPermission.getpermission("User", "view") == 0)
            {
                QLuser.Visible = false;
            }
            if (MyPermission.getpermission("Groupuser", "view") == 0)
            {
                QlGroupUser.Visible = false;
            }
           
          
        }
        public void lostConnect()
        {
            groupBox1.Visible = false;
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
            groupBox1.Visible = false;
            dongALL();
            ThemTabPages(SettingViews.stv, 1, "Settings");
        }
        public void gotoQLUser()
        {
            groupBox1.Visible = false;
            dongALL();
            ViewsUser v = ViewsUser.vu;
            v.firstSettings = 1;
            ThemTabPages(ViewsUser.vu, 1, "Users");
        }

        public void khoiphucdatabase()
        {
            groupBox1.Visible = false;
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
        public void khoiphucdatabase1()
        {
            groupBox1.Visible = false;
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
            groupBox1.Visible = false;
            foreach(ToolStripMenuItem tsmi in msUserControl.Items)
            {
                tsmi.Visible = true;
            }

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
            foreach (ToolStripMenuItem ts in msUserControl.Items)
            {
                ts.AutoSize = false;
                ts.Size = new Size(118, 50);
                //ts.BackColor = Color.Black;
                //ts.ForeColor = Color.White;
            }
            setting = 0;
            getSetting();

            if (User.getUser().pid == null && close != 1 && setting !=1)
            {
                FrmMain_Load(sender, e);
            }
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
            ThemTabPages(KhachHangViews.khv, 3, "Khách Hàng");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void lịchSửVàThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(ThongKeViews.tkv, 4, "Thống kê");
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
            MainControllers.DangXuat();
            loadAllPage();
            FrmMain_Load(sender, e);
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
    }
}
