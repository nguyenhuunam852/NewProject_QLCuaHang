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

namespace WindowsFormsApp1.Views
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private static FrmMain frm;
        public object[] list_countDown = new object[2];


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
            msUserControl.Visible = false;
            if (getFirstSetting() == 1)
            {

                
                SettingsControllers.getInformation();
                FrmDangNhap fdn = new FrmDangNhap();
                DialogResult dlr = fdn.ShowDialog();
                if (dlr == DialogResult.OK)
                {
                    int sig = 0;
                    int check;
                    while ((check=MainControllers.checkExist(dateTime))!=3)
                    {
                        if(check==1)
                        {
                            DialogResult dlr1;
                            if (sig == 0)
                            {
                                dlr1 = MessageBox.Show("Bạn chưa chốt ca những ngày gần đây,tiến hành chốt ca để tiếp tục làm việc Ngày:"+dateTime.Day.ToString() + '/' + dateTime.Month.ToString() + '/' + dateTime.Year.ToString(),"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                dlr1 = MessageBox.Show("tiến hành chốt ca cho ngày:"+dateTime.Day.ToString()+'/'+dateTime.Month.ToString()+'/'+dateTime.Year.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (dlr1 == DialogResult.OK)
                            {
                                FrmTongKet ftk = new FrmTongKet(dateTime);
                                DialogResult wait = ftk.ShowDialog();
                                if (wait == DialogResult.OK)
                                {
                                    int check1 = Controllers.ThongKeControllers.ChotCaTheoNgay(dateTime);
                                    if (check1 >0)
                                    {
                                        MessageBox.Show("Chốt ca thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                if(sig==0)
                                {
                                    sig = 1;
                                }
                            }
                        }
                        dateTime = dateTime.AddDays(-1);
                    }
                    DataRow dr = User.getUser().ppermission.AsEnumerable().SingleOrDefault(r => r.Field<string>("name") == "DeskCustomer");
                    if(dr["view"].ToString()=="1")
                    {
                        ThemTabPages(DatGheViews.getView(), 1, "Quản lí đặt ghế");
                    }
                    msUserControl.Visible = true;
                }
                else if (dlr == DialogResult.Abort)
                {
                    MessageBox.Show("Sai tài khoản và mật khẩu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dlr == DialogResult.Cancel)
                {
                    this.Close();
                }

            }
            else
            {
                msUserControl.Visible = false;

                ThemTabPages(SettingViews.getViews(0), 5, "First Settings");
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
            getSetting();
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
                if (typePages[i] != 1)
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
                if(typePages[i]!=1)
                {
                    TabHienThi.TabPages.Remove(TabHienThi.TabPages[i]);
                }
                
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
            ThemTabPages(SettingViews.getViews(1), 5, "Settings");
        }

        private void quảnLíTypeKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíGroupUSerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(GroupUserViews.guv, 6, "Group Users") ;
        }

        private void quảnLíUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(ViewsUser.vu, 7, "Users");
        }
    }
}
