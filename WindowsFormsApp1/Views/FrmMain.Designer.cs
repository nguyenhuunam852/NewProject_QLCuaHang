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
            this.msUserControl = new System.Windows.Forms.MenuStrip();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QLbackUp = new System.Windows.Forms.ToolStripMenuItem();
            this.QLGhe = new System.Windows.Forms.ToolStripMenuItem();
            this.QLkhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.QLloaiKH = new System.Windows.Forms.ToolStripMenuItem();
            this.QLsk = new System.Windows.Forms.ToolStripMenuItem();
            this.QLlichSu = new System.Windows.Forms.ToolStripMenuItem();
            this.QLsetting = new System.Windows.Forms.ToolStripMenuItem();
            this.QLuser = new System.Windows.Forms.ToolStripMenuItem();
            this.QlGroupUser = new System.Windows.Forms.ToolStripMenuItem();
            this.dangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cntmsTag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.đóngTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đóngTrangHiệnTạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabHienThi = new System.Windows.Forms.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.msUserControl.SuspendLayout();
            this.cntmsTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // msUserControl
            // 
            this.msUserControl.AutoSize = false;
            this.msUserControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.msUserControl.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msUserControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.QLbackUp,
            this.QLGhe,
            this.QLkhachhang,
            this.QLloaiKH,
            this.QLsk,
            this.QLlichSu,
            this.QLsetting,
            this.QLuser,
            this.QlGroupUser,
            this.dangToolStripMenuItem});
            this.msUserControl.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.msUserControl.Location = new System.Drawing.Point(0, 0);
            this.msUserControl.Name = "msUserControl";
            this.msUserControl.Size = new System.Drawing.Size(1350, 30);
            this.msUserControl.TabIndex = 1;
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông Tin Cá Nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // QLbackUp
            // 
            this.QLbackUp.Name = "QLbackUp";
            this.QLbackUp.Size = new System.Drawing.Size(59, 26);
            this.QLbackUp.Text = "BackUp";
            this.QLbackUp.Click += new System.EventHandler(this.backUpToolStripMenuItem_Click);
            // 
            // QLGhe
            // 
            this.QLGhe.AutoSize = false;
            this.QLGhe.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QLGhe.Name = "QLGhe";
            this.QLGhe.Size = new System.Drawing.Size(118, 18);
            this.QLGhe.Text = "Quản lí ghế";
            this.QLGhe.Click += new System.EventHandler(this.quảnLíBànToolStripMenuItem_Click);
            // 
            // QLkhachhang
            // 
            this.QLkhachhang.Name = "QLkhachhang";
            this.QLkhachhang.Size = new System.Drawing.Size(124, 26);
            this.QLkhachhang.Text = "Quản lí khách hàng";
            this.QLkhachhang.Click += new System.EventHandler(this.quảnLíKháchHàngToolStripMenuItem_Click);
            // 
            // QLloaiKH
            // 
            this.QLloaiKH.Name = "QLloaiKH";
            this.QLloaiKH.Size = new System.Drawing.Size(110, 26);
            this.QLloaiKH.Text = "Loại Khách Hàng";
            this.QLloaiKH.Click += new System.EventHandler(this.quảnLíTypeKháchHàngToolStripMenuItem_Click);
            // 
            // QLsk
            // 
            this.QLsk.Name = "QLsk";
            this.QLsk.Size = new System.Drawing.Size(68, 26);
            this.QLsk.Text = "Sức khỏe";
            this.QLsk.Click += new System.EventHandler(this.QLsk_Click);
            // 
            // QLlichSu
            // 
            this.QLlichSu.Name = "QLlichSu";
            this.QLlichSu.Size = new System.Drawing.Size(120, 26);
            this.QLlichSu.Text = "Lịch sử và thống kê";
            this.QLlichSu.Click += new System.EventHandler(this.lịchSửVàThốngKêToolStripMenuItem_Click);
            // 
            // QLsetting
            // 
            this.QLsetting.Name = "QLsetting";
            this.QLsetting.Size = new System.Drawing.Size(63, 26);
            this.QLsetting.Text = "Settings";
            this.QLsetting.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // QLuser
            // 
            this.QLuser.Name = "QLuser";
            this.QLuser.Size = new System.Drawing.Size(87, 26);
            this.QLuser.Text = "Quản lí User";
            this.QLuser.Click += new System.EventHandler(this.quảnLíUserToolStripMenuItem_Click);
            // 
            // QlGroupUser
            // 
            this.QlGroupUser.Name = "QlGroupUser";
            this.QlGroupUser.Size = new System.Drawing.Size(123, 26);
            this.QlGroupUser.Text = "Quản lí Group User";
            this.QlGroupUser.Click += new System.EventHandler(this.quảnLíGroupUSerToolStripMenuItem_Click);
            // 
            // dangToolStripMenuItem
            // 
            this.dangToolStripMenuItem.Name = "dangToolStripMenuItem";
            this.dangToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            this.dangToolStripMenuItem.Text = "Đăng Xuất";
            this.dangToolStripMenuItem.Click += new System.EventHandler(this.dangToolStripMenuItem_Click);
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
            this.TabHienThi.Location = new System.Drawing.Point(0, 30);
            this.TabHienThi.Name = "TabHienThi";
            this.TabHienThi.SelectedIndex = 0;
            this.TabHienThi.Size = new System.Drawing.Size(1350, 768);
            this.TabHienThi.TabIndex = 3;
            this.TabHienThi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TabHienThi_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1350, 699);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TabHienThi);
            this.Controls.Add(this.msUserControl);
            this.MainMenuStrip = this.msUserControl;
            this.Name = "FrmMain";
            this.Text = "FromMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            this.msUserControl.ResumeLayout(false);
            this.msUserControl.PerformLayout();
            this.cntmsTag.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip msUserControl;
        private System.Windows.Forms.ToolStripMenuItem QLGhe;
        private System.Windows.Forms.ContextMenuStrip cntmsTag;
        private System.Windows.Forms.ToolStripMenuItem đóngTấtCảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đóngTrangHiệnTạiToolStripMenuItem;
        private System.Windows.Forms.TabControl TabHienThi;
        private System.Windows.Forms.ToolStripMenuItem QLkhachhang;
        private System.Windows.Forms.ToolStripMenuItem QLlichSu;
        private System.Windows.Forms.ToolStripMenuItem QLsetting;
        private System.Windows.Forms.ToolStripMenuItem QLuser;
        private System.Windows.Forms.ToolStripMenuItem QlGroupUser;
        private System.Windows.Forms.ToolStripMenuItem QLloaiKH;
        private System.Windows.Forms.ToolStripMenuItem QLsk;
        private System.Windows.Forms.ToolStripMenuItem dangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QLbackUp;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}