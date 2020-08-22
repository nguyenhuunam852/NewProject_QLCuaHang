﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1.Views
{
    public partial class GheViews : UserControl
    {
       
        public GheViews()
        {
            InitializeComponent();
            
            
        }
        private string id;
        private Point MouseDownLocation;
        public static GheViews dv = new GheViews();
        public DataSet dts = new DataSet();
        static List<Label> lbs = new List<Label>();
        string signal = "insert";

        //Hàm sử lí Load
        public static List<Label> getgroupBox()
        {
            lbs = new List<Label>();
            if (dv.groupBox1.Controls.Count == 0)
            {
                return new List<Label>();
            }
            foreach (Label ctr in dv.groupBox1.Controls)
            {
                Label lb = new Label();
                lb.Name = ctr.Name;
                lb.BackColor = ctr.BackColor;
                lb.Location = ctr.Location;
                lb.Size = ctr.Size;
                lb.TextAlign = ctr.TextAlign;
                lb.Text = ctr.Text;
                lbs.Add(lb);
            }
            return lbs;
        }
        private void GheViews_Load(object sender, EventArgs e)
        {
            loadPermissionMs();
            LoadDuLieuDataGridView();
            themUI();
            thietlapbandau();
        }
        //Xóa tất cả các thành phần trên Màn Hình UI
        private void reloadUI()
        {
            int c = groupBox1.Controls.Count;
            for (int i = c - 1; i >= 0; i--)
                groupBox1.Controls.Remove(groupBox1.Controls[i]);
        }
        private void themUI()
        {
            reloadUI();
            List<Label> lbs1 = DatGheViews.getgroupBox();
            if (lbs.Count == 0 && lbs== lbs1)
            {
                
                foreach (Label lb in lbs1)
                {
                    groupBox1.Controls.Add(lb);
                    lb.Text = lb.Text;
                    lb.MouseDown += Lb_MouseDown;
                    lb.MouseMove += Lb_MouseMove;
                    lb.MouseUp += Lb_MouseUp1;
                    lb.Click += Lb_Click;
                }
            }
            else
            {

                foreach (DataRow row in dts.Tables[0].Rows)
                {
                    string id = row["id"].ToString();
                    string tinhtrang = row["status"].ToString();
                    string lx = row["locationx"].ToString();
                    string ly = row["locationy"].ToString();
                    string tenban = row["name"].ToString();
                    object[] ghe = { id, tinhtrang, lx, ly,tenban };
                    groupBox1.Controls.Add(createLabel(ghe));
                }
            }
        }
        private void loadPermissionMs()
        {
            if (MyPermission.getpermission("Desk", "insert") == 0)
            {
                btnThem.Visible = false;
            }
            if (MyPermission.getpermission("Desk", "update") == 0)
            {
                btnSua.Visible = false;
            }
            if (MyPermission.getpermission("Desk", "update") == 0 && MyPermission.getpermission("Desk", "insert") == 0)
            {
                btnLuu.Visible = false;
                btnHuy.Visible = false;
            }
            if (MyPermission.getpermission("Desk", "delete") == 0)
            {
                btnXoa.Visible = false;
            }

        }

        private void Lb_MouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

      
        private void LoadDuLieuDataGridView()
        {
            dts = Controllers.GheControllers.LayThongTinGhe();
            dataGridView1.DataSource = dts.Tables[0];
        }
        private void thietlapbandau()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtTenGhe.Enabled = false;
            txtTenGhe.Text = "";
            txtId.Visible = false;
            cbbtrangthai.Enabled = false;
            cbbtrangthai.Items.Clear();
            cbbtrangthai.Items.Insert(0,"Hoạt động");
            cbbtrangthai.Items.Insert(1,"Bảo Trì");
            cbbtrangthai.SelectedIndex = 0;
        }




        //Thêm mới một ghế
        // Cấu trúc object { ghe.pid, ghe.ptinhtrang, ghe.ptrangthai, ghe.plx, ghe.ply };
        private void button1_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTenGhe.Enabled = true;
            signal = "insert";
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
            lb.Location = new System.Drawing.Point(int.Parse(infor[2].ToString()),int.Parse(infor[3].ToString()));
            lb.Name = infor[0].ToString();
            lb.Size = new System.Drawing.Size(100, 100);
            lb.Text = infor[4].ToString();//Lấy số trong id Bàn
            lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lb.MouseDown += Lb_MouseDown;
            lb.MouseMove += Lb_MouseMove;
            lb.MouseUp += Lb_MouseUp1; 
            lb.Click += Lb_Click;
            return lb;
        }

        private void Lb_MouseUp1(object sender, MouseEventArgs e)
        {
            DataTable dtb = new DataTable();
            dtb.Clear();
            dtb.Columns.Add("id");
            dtb.Columns.Add("LX");
            dtb.Columns.Add("LY");
            foreach (Label lb in groupBox1.Controls)
            {
                DataRow row = dtb.NewRow();
                row["id"] = lb.Name;
                row["LX"] = lb.Location.X;
                row["LY"] = lb.Location.Y;
                dtb.Rows.Add(row);
            }
            int check = Controllers.GheControllers.LuuTrangThai(dtb);
            if (check > 0)
            {
                DatGheViews.refreshGroupBox();
            }
        }

     

        private void Lb_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtTenGhe.Text = lb.Text;
            txtId.Text = lb.Name;
            if(lb.BackColor== Color.FromArgb(135, 206, 250))
            {
                cbbtrangthai.SelectedIndex = 0;
            }
            else
            {
                cbbtrangthai.SelectedIndex = 1;
            }
        }

        private void Lb_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

      

        //Lưu trạng thái ghế tại UI
        private void button3_Click(object sender, EventArgs e)
        {
         
      
        }
        //Các hàm sử lí đồ họa và di chuyển
        private void Lb_MouseMove(object sender, MouseEventArgs e)
        {
            if (MyPermission.getpermission("Desk", "update") == 1)
            {
                Label lbl = sender as Label;
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    lbl.Left = e.X + lbl.Left - MouseDownLocation.X;
                    lbl.Top = e.Y + lbl.Top - MouseDownLocation.Y;
                    if (lbl.Location.X < groupBox1.Location.X + 480 && lbl.Location.Y < groupBox1.Location.Y + 642)
                    {
                        groupBox1.Controls.Add(lbl);
                    }

                }
            }
        }
        private void Lb_MouseDown(object sender, MouseEventArgs e)
        {
          
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Label lbl = sender as Label;
                id = lbl.Name;
                ContextMenu cm = new ContextMenu();
                if (MyPermission.getpermission("Desk", "delete") == 1)
                {
                    MenuItem item = cm.MenuItems.Add("Xóa ghế");
                    item.Click += Item_Click;
                }
                if (MyPermission.getpermission("Desk", "update") == 1)
                {
                    MenuItem item1 = cm.MenuItems.Add("Bảo trì");
                    item1.Click += Item1_Click;
                    MenuItem item2 = cm.MenuItems.Add("Đưa vào hoạt động");
                    item2.Click += Item2_Click;
                    lbl.ContextMenu = cm;
                }
            }
        }

        private void Item2_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muôn đưa vào hoạt động không không?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dlr == DialogResult.OK)
            {
                int check = Controllers.GheControllers.DuaVaoHoatDong(id);
                if (check > 0)
                {
                    MessageBox.Show("thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GheViews_Load(sender, e);
                    DatGheViews.refreshGroupBox();
                    return;
                }
                if (check == -2)
                {
                    MessageBox.Show("Hiện tại ghế đang hoạt động", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GheViews_Load(sender, e);
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Item1_Click(object sender, EventArgs e)
        {
            
            DialogResult dlr = MessageBox.Show("Bạn có muôn bảo trì không?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(dlr==DialogResult.OK)
            {
                int check = Controllers.GheControllers.BaoTri(id);
                if(check >0)
                {
                    MessageBox.Show("thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GheViews_Load(sender, e);
                    DatGheViews.refreshGroupBox();
                    return;
                }
                if (check == -2)
                {
                    MessageBox.Show("Hiện tại ghế đang được bảo trì", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GheViews_Load(sender, e);
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            DialogResult dlr=MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dlr == DialogResult.OK)
            {
                int check = Controllers.GheControllers.XoaGhe(id);
                if (check > 0)
                {
                    MessageBox.Show("thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GheViews_Load(sender, e);
                    DatGheViews.deleteGroupBox(id);
                    return;
                }
                if(check==-5)
                {
                    MessageBox.Show("ghế đang hoạt động", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Phải thêm tình trạng của ghế là đang hoạt động hay đang bảo trì
            string tt = "0";
            if (txtTenGhe.Text == "")
            {
                MessageBox.Show("Thêm tên ghế", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(cbbtrangthai.SelectedIndex==0)
            {
                tt = "1";
            }
            
            //Gọi Controller để thêm ghế
            if (signal == "insert")
            {
                object[] ghe = Controllers.GheControllers.themGhe(tt, txtTenGhe.Text);
                if (ghe != null)
                {
                    groupBox3.Controls.Add(createLabel(ghe));
                    DatGheViews.refreshGroupBox();
                    txtTenGhe.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int check = Controllers.GheControllers.suathongtinGhe(txtId.Text,tt, txtTenGhe.Text);
                if(check>0)
                {
                    GheViews_Load(sender, e);
                    DatGheViews.refreshGroupBox();
                    return;
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTenGhe.Enabled = true;
            cbbtrangthai.Enabled = true;
            signal = "update";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn xóa không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlr == DialogResult.Yes)
            {
                int check = Controllers.GheControllers.XoaGhe(id);
                if (check > 0)
                {
                    MessageBox.Show("thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GheViews_Load(sender, e);
                    DatGheViews.deleteGroupBox(id);
                    return;
                }
                if (check == -5)
                {
                    MessageBox.Show("ghế đang hoạt động", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GheViews_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            GheViews_Load(sender, e);
        }
    }
}
