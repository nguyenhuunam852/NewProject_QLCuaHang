namespace WindowsFormsApp1.Views
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cntmsTag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.đóngTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đóngTrangHiệnTạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabHienThi = new System.Windows.Forms.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.TabHoatDong = new System.Windows.Forms.Label();
            this.TabQlDatGhe = new System.Windows.Forms.Label();
            this.TabThongTinCaNhan = new System.Windows.Forms.Label();
            this.Tabthongtinchinhanh = new System.Windows.Forms.Label();
            this.TabThongKe = new System.Windows.Forms.Label();
            this.TabQuanLi = new System.Windows.Forms.Label();
            this.TabGhe = new System.Windows.Forms.Label();
            this.TabKhachHang = new System.Windows.Forms.Label();
            this.TabLoaiKhachHang = new System.Windows.Forms.Label();
            this.TabSucKhoe = new System.Windows.Forms.Label();
            this.TabUsers = new System.Windows.Forms.Label();
            this.TabGroupUsers = new System.Windows.Forms.Label();
            this.TabCaiDat = new System.Windows.Forms.Label();
            this.TabSettings = new System.Windows.Forms.Label();
            this.TabBackUps = new System.Windows.Forms.Label();
            this.TabUpdate = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cntmsTag.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cntmsTag
            // 
            this.cntmsTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đóngTấtCảToolStripMenuItem,
            this.đóngTrangHiệnTạiToolStripMenuItem});
            this.cntmsTag.Name = "cntmsTag";
            this.cntmsTag.Size = new System.Drawing.Size(177, 48);
            // 
            // đóngTấtCảToolStripMenuItem
            // 
            this.đóngTấtCảToolStripMenuItem.Name = "đóngTấtCảToolStripMenuItem";
            this.đóngTấtCảToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.đóngTấtCảToolStripMenuItem.Text = "Đóng tất cả";
            this.đóngTấtCảToolStripMenuItem.Click += new System.EventHandler(this.đóngTấtCảToolStripMenuItem_Click);
            // 
            // đóngTrangHiệnTạiToolStripMenuItem
            // 
            this.đóngTrangHiệnTạiToolStripMenuItem.Name = "đóngTrangHiệnTạiToolStripMenuItem";
            this.đóngTrangHiệnTạiToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.đóngTrangHiệnTạiToolStripMenuItem.Text = "Đóng trang hiện tại";
            // 
            // TabHienThi
            // 
            this.TabHienThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabHienThi.ContextMenuStrip = this.cntmsTag;
            this.TabHienThi.Location = new System.Drawing.Point(147, 0);
            this.TabHienThi.Name = "TabHienThi";
            this.TabHienThi.SelectedIndex = 0;
            this.TabHienThi.Size = new System.Drawing.Size(638, 562);
            this.TabHienThi.TabIndex = 3;
            this.TabHienThi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TabHienThi_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(-1, -7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 574);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.TabHoatDong);
            this.flowLayoutPanel1.Controls.Add(this.TabQlDatGhe);
            this.flowLayoutPanel1.Controls.Add(this.TabThongTinCaNhan);
            this.flowLayoutPanel1.Controls.Add(this.Tabthongtinchinhanh);
            this.flowLayoutPanel1.Controls.Add(this.TabThongKe);
            this.flowLayoutPanel1.Controls.Add(this.TabQuanLi);
            this.flowLayoutPanel1.Controls.Add(this.TabGhe);
            this.flowLayoutPanel1.Controls.Add(this.TabKhachHang);
            this.flowLayoutPanel1.Controls.Add(this.TabLoaiKhachHang);
            this.flowLayoutPanel1.Controls.Add(this.TabSucKhoe);
            this.flowLayoutPanel1.Controls.Add(this.TabUsers);
            this.flowLayoutPanel1.Controls.Add(this.TabGroupUsers);
            this.flowLayoutPanel1.Controls.Add(this.TabCaiDat);
            this.flowLayoutPanel1.Controls.Add(this.TabSettings);
            this.flowLayoutPanel1.Controls.Add(this.TabBackUps);
            this.flowLayoutPanel1.Controls.Add(this.TabUpdate);
            this.flowLayoutPanel1.Controls.Add(this.label17);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 115);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(148, 454);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // TabHoatDong
            // 
            this.TabHoatDong.BackColor = System.Drawing.Color.SlateBlue;
            this.TabHoatDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabHoatDong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabHoatDong.Location = new System.Drawing.Point(3, 0);
            this.TabHoatDong.Name = "TabHoatDong";
            this.TabHoatDong.Size = new System.Drawing.Size(144, 23);
            this.TabHoatDong.TabIndex = 0;
            this.TabHoatDong.Text = "Hoạt Động";
            this.TabHoatDong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabHoatDong.Click += new System.EventHandler(this.TabHoatDong_Click);
            // 
            // TabQlDatGhe
            // 
            this.TabQlDatGhe.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabQlDatGhe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabQlDatGhe.Location = new System.Drawing.Point(3, 23);
            this.TabQlDatGhe.Name = "TabQlDatGhe";
            this.TabQlDatGhe.Size = new System.Drawing.Size(142, 23);
            this.TabQlDatGhe.TabIndex = 1;
            this.TabQlDatGhe.Text = "QL Đặt Ghế";
            this.TabQlDatGhe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabQlDatGhe.Visible = false;
            this.TabQlDatGhe.Click += new System.EventHandler(this.TabQlDatGhe_Click);
            this.TabQlDatGhe.MouseHover += new System.EventHandler(this.TabQlDatGhe_MouseHover);
            // 
            // TabThongTinCaNhan
            // 
            this.TabThongTinCaNhan.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabThongTinCaNhan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabThongTinCaNhan.Location = new System.Drawing.Point(3, 46);
            this.TabThongTinCaNhan.Name = "TabThongTinCaNhan";
            this.TabThongTinCaNhan.Size = new System.Drawing.Size(142, 23);
            this.TabThongTinCaNhan.TabIndex = 2;
            this.TabThongTinCaNhan.Text = "Thông Tin Cá Nhân";
            this.TabThongTinCaNhan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabThongTinCaNhan.Click += new System.EventHandler(this.TabThongTinCaNhan_Click);
            this.TabThongTinCaNhan.MouseHover += new System.EventHandler(this.TabThongTinCaNhan_MouseHover);
            // 
            // Tabthongtinchinhanh
            // 
            this.Tabthongtinchinhanh.BackColor = System.Drawing.Color.MidnightBlue;
            this.Tabthongtinchinhanh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Tabthongtinchinhanh.Location = new System.Drawing.Point(3, 69);
            this.Tabthongtinchinhanh.Name = "Tabthongtinchinhanh";
            this.Tabthongtinchinhanh.Size = new System.Drawing.Size(142, 23);
            this.Tabthongtinchinhanh.TabIndex = 3;
            this.Tabthongtinchinhanh.Text = "Thông Tin Chi Nhánh";
            this.Tabthongtinchinhanh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tabthongtinchinhanh.Click += new System.EventHandler(this.Tabthongtinchinhanh_Click);
            this.Tabthongtinchinhanh.MouseHover += new System.EventHandler(this.Tabthongtinchinhanh_MouseHover);
            // 
            // TabThongKe
            // 
            this.TabThongKe.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabThongKe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabThongKe.Location = new System.Drawing.Point(3, 92);
            this.TabThongKe.Name = "TabThongKe";
            this.TabThongKe.Size = new System.Drawing.Size(142, 23);
            this.TabThongKe.TabIndex = 9;
            this.TabThongKe.Text = "Thống kê";
            this.TabThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabThongKe.Visible = false;
            this.TabThongKe.Click += new System.EventHandler(this.TabThongKe_Click);
            this.TabThongKe.MouseHover += new System.EventHandler(this.TabThongKe_MouseHover);
            // 
            // TabQuanLi
            // 
            this.TabQuanLi.BackColor = System.Drawing.Color.SlateBlue;
            this.TabQuanLi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabQuanLi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabQuanLi.Location = new System.Drawing.Point(3, 115);
            this.TabQuanLi.Name = "TabQuanLi";
            this.TabQuanLi.Size = new System.Drawing.Size(144, 23);
            this.TabQuanLi.TabIndex = 4;
            this.TabQuanLi.Text = "Quản lí ";
            this.TabQuanLi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabQuanLi.Click += new System.EventHandler(this.TabQuanLi_Click);
            // 
            // TabGhe
            // 
            this.TabGhe.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabGhe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabGhe.Location = new System.Drawing.Point(3, 138);
            this.TabGhe.Name = "TabGhe";
            this.TabGhe.Size = new System.Drawing.Size(142, 23);
            this.TabGhe.TabIndex = 5;
            this.TabGhe.Text = "QL Ghế";
            this.TabGhe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabGhe.Visible = false;
            this.TabGhe.Click += new System.EventHandler(this.TabGhe_Click);
            this.TabGhe.MouseHover += new System.EventHandler(this.TabGhe_MouseHover);
            // 
            // TabKhachHang
            // 
            this.TabKhachHang.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabKhachHang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabKhachHang.Location = new System.Drawing.Point(3, 161);
            this.TabKhachHang.Name = "TabKhachHang";
            this.TabKhachHang.Size = new System.Drawing.Size(142, 23);
            this.TabKhachHang.TabIndex = 6;
            this.TabKhachHang.Text = "QL Khách Hàng";
            this.TabKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabKhachHang.Visible = false;
            this.TabKhachHang.Click += new System.EventHandler(this.TabKhachHang_Click);
            this.TabKhachHang.MouseHover += new System.EventHandler(this.TabKhachHang_MouseHover);
            // 
            // TabLoaiKhachHang
            // 
            this.TabLoaiKhachHang.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabLoaiKhachHang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabLoaiKhachHang.Location = new System.Drawing.Point(3, 184);
            this.TabLoaiKhachHang.Name = "TabLoaiKhachHang";
            this.TabLoaiKhachHang.Size = new System.Drawing.Size(142, 23);
            this.TabLoaiKhachHang.TabIndex = 7;
            this.TabLoaiKhachHang.Text = "QL Loại Khách Hàng";
            this.TabLoaiKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabLoaiKhachHang.Visible = false;
            this.TabLoaiKhachHang.Click += new System.EventHandler(this.TabLoaiKhachHang_Click);
            this.TabLoaiKhachHang.MouseHover += new System.EventHandler(this.TabLoaiKhachHang_MouseHover);
            // 
            // TabSucKhoe
            // 
            this.TabSucKhoe.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabSucKhoe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabSucKhoe.Location = new System.Drawing.Point(3, 207);
            this.TabSucKhoe.Name = "TabSucKhoe";
            this.TabSucKhoe.Size = new System.Drawing.Size(142, 23);
            this.TabSucKhoe.TabIndex = 8;
            this.TabSucKhoe.Text = "QL Sức Khỏe";
            this.TabSucKhoe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabSucKhoe.Visible = false;
            this.TabSucKhoe.Click += new System.EventHandler(this.TabSucKhoe_Click);
            this.TabSucKhoe.MouseHover += new System.EventHandler(this.TabSucKhoe_MouseHover);
            // 
            // TabUsers
            // 
            this.TabUsers.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabUsers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabUsers.Location = new System.Drawing.Point(3, 230);
            this.TabUsers.Name = "TabUsers";
            this.TabUsers.Size = new System.Drawing.Size(142, 23);
            this.TabUsers.TabIndex = 10;
            this.TabUsers.Text = "QL Users";
            this.TabUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabUsers.Visible = false;
            this.TabUsers.Click += new System.EventHandler(this.TabUsers_Click);
            this.TabUsers.MouseHover += new System.EventHandler(this.TabUsers_MouseHover);
            // 
            // TabGroupUsers
            // 
            this.TabGroupUsers.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabGroupUsers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabGroupUsers.Location = new System.Drawing.Point(3, 253);
            this.TabGroupUsers.Name = "TabGroupUsers";
            this.TabGroupUsers.Size = new System.Drawing.Size(142, 23);
            this.TabGroupUsers.TabIndex = 11;
            this.TabGroupUsers.Text = "QL Group Users";
            this.TabGroupUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabGroupUsers.Visible = false;
            this.TabGroupUsers.Click += new System.EventHandler(this.TabGroupUsers_Click);
            this.TabGroupUsers.Move += new System.EventHandler(this.TabGroupUsers_Move);
            // 
            // TabCaiDat
            // 
            this.TabCaiDat.BackColor = System.Drawing.Color.SlateBlue;
            this.TabCaiDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabCaiDat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabCaiDat.Location = new System.Drawing.Point(3, 276);
            this.TabCaiDat.Name = "TabCaiDat";
            this.TabCaiDat.Size = new System.Drawing.Size(144, 23);
            this.TabCaiDat.TabIndex = 12;
            this.TabCaiDat.Text = "Cài Đặt";
            this.TabCaiDat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabCaiDat.Click += new System.EventHandler(this.TabCaiDat_Click);
            // 
            // TabSettings
            // 
            this.TabSettings.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabSettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabSettings.Location = new System.Drawing.Point(3, 299);
            this.TabSettings.Name = "TabSettings";
            this.TabSettings.Size = new System.Drawing.Size(142, 23);
            this.TabSettings.TabIndex = 13;
            this.TabSettings.Text = "Settings";
            this.TabSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabSettings.Visible = false;
            this.TabSettings.Click += new System.EventHandler(this.TabSettings_Click);
            this.TabSettings.MouseHover += new System.EventHandler(this.TabSettings_MouseHover);
            // 
            // TabBackUps
            // 
            this.TabBackUps.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabBackUps.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabBackUps.Location = new System.Drawing.Point(3, 322);
            this.TabBackUps.Name = "TabBackUps";
            this.TabBackUps.Size = new System.Drawing.Size(142, 23);
            this.TabBackUps.TabIndex = 14;
            this.TabBackUps.Text = "Backups";
            this.TabBackUps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabBackUps.Visible = false;
            this.TabBackUps.Click += new System.EventHandler(this.TabBackUps_Click);
            this.TabBackUps.MouseHover += new System.EventHandler(this.TabBackUps_MouseHover);
            // 
            // TabUpdate
            // 
            this.TabUpdate.BackColor = System.Drawing.Color.MidnightBlue;
            this.TabUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabUpdate.Location = new System.Drawing.Point(3, 345);
            this.TabUpdate.Name = "TabUpdate";
            this.TabUpdate.Size = new System.Drawing.Size(142, 23);
            this.TabUpdate.TabIndex = 16;
            this.TabUpdate.Text = "Update";
            this.TabUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabUpdate.Visible = false;
            this.TabUpdate.Click += new System.EventHandler(this.TabUpdate_Click);
            this.TabUpdate.MouseHover += new System.EventHandler(this.TabUpdate_MouseHover);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Red;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(3, 368);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 23);
            this.label17.TabIndex = 15;
            this.label17.Text = "Đăng Xuất";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 80);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 562);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TabHienThi);
            this.Name = "FrmMain";
            this.Text = "FromMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            this.cntmsTag.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cntmsTag;
        private System.Windows.Forms.ToolStripMenuItem đóngTấtCảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đóngTrangHiệnTạiToolStripMenuItem;
        private System.Windows.Forms.TabControl TabHienThi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label TabHoatDong;
        private System.Windows.Forms.Label TabQlDatGhe;
        private System.Windows.Forms.Label TabThongTinCaNhan;
        private System.Windows.Forms.Label Tabthongtinchinhanh;
        private System.Windows.Forms.Label TabQuanLi;
        private System.Windows.Forms.Label TabGhe;
        private System.Windows.Forms.Label TabKhachHang;
        private System.Windows.Forms.Label TabLoaiKhachHang;
        private System.Windows.Forms.Label TabSucKhoe;
        private System.Windows.Forms.Label TabThongKe;
        private System.Windows.Forms.Label TabUsers;
        private System.Windows.Forms.Label TabGroupUsers;
        private System.Windows.Forms.Label TabCaiDat;
        private System.Windows.Forms.Label TabSettings;
        private System.Windows.Forms.Label TabBackUps;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label TabUpdate;
    }
}