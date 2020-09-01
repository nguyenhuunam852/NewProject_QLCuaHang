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
            this.dangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QLGhe = new System.Windows.Forms.ToolStripMenuItem();
            this.QLkhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.QLloaiKH = new System.Windows.Forms.ToolStripMenuItem();
            this.QLsk = new System.Windows.Forms.ToolStripMenuItem();
            this.QLlichSu = new System.Windows.Forms.ToolStripMenuItem();
            this.QLuser = new System.Windows.Forms.ToolStripMenuItem();
            this.QlGroupUser = new System.Windows.Forms.ToolStripMenuItem();
            this.QLsetting = new System.Windows.Forms.ToolStripMenuItem();
            this.QLbackUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cntmsTag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.đóngTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đóngTrangHiệnTạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabHienThi = new System.Windows.Forms.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.msUserControl.SuspendLayout();
            this.cntmsTag.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msUserControl
            // 
            this.msUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.msUserControl.AutoSize = false;
            this.msUserControl.BackColor = System.Drawing.Color.RoyalBlue;
            this.msUserControl.Dock = System.Windows.Forms.DockStyle.None;
            this.msUserControl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.msUserControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.msUserControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.QLGhe,
            this.QLkhachhang,
            this.QLloaiKH,
            this.QLsk,
            this.QLlichSu,
            this.QLuser,
            this.QlGroupUser,
            this.QLsetting,
            this.QLbackUp,
            this.dangToolStripMenuItem});
            this.msUserControl.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.msUserControl.Location = new System.Drawing.Point(2, 121);
            this.msUserControl.Name = "msUserControl";
            this.msUserControl.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msUserControl.Size = new System.Drawing.Size(143, 441);
            this.msUserControl.TabIndex = 1;
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.thôngTinCáNhânToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.thôngTinCáNhânToolStripMenuItem.Text = "CÁ NHÂN";
            this.thôngTinCáNhânToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // dangToolStripMenuItem
            // 
            this.dangToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.dangToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dangToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dangToolStripMenuItem.Name = "dangToolStripMenuItem";
            this.dangToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.dangToolStripMenuItem.Text = "ĐĂNG XUẤT";
            this.dangToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dangToolStripMenuItem.Click += new System.EventHandler(this.dangToolStripMenuItem_Click);
            // 
            // QLGhe
            // 
            this.QLGhe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLGhe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QLGhe.Name = "QLGhe";
            this.QLGhe.Size = new System.Drawing.Size(139, 24);
            this.QLGhe.Text = "GHẾ";
            this.QLGhe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLGhe.Click += new System.EventHandler(this.quảnLíBànToolStripMenuItem_Click);
            // 
            // QLkhachhang
            // 
            this.QLkhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLkhachhang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QLkhachhang.Name = "QLkhachhang";
            this.QLkhachhang.Size = new System.Drawing.Size(139, 24);
            this.QLkhachhang.Text = "KHÁCH HÀNG";
            this.QLkhachhang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLkhachhang.Click += new System.EventHandler(this.quảnLíKháchHàngToolStripMenuItem_Click);
            // 
            // QLloaiKH
            // 
            this.QLloaiKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLloaiKH.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QLloaiKH.Name = "QLloaiKH";
            this.QLloaiKH.Size = new System.Drawing.Size(139, 24);
            this.QLloaiKH.Text = "LOẠI KH";
            this.QLloaiKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLloaiKH.Click += new System.EventHandler(this.quảnLíTypeKháchHàngToolStripMenuItem_Click);
            // 
            // QLsk
            // 
            this.QLsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLsk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QLsk.Name = "QLsk";
            this.QLsk.Size = new System.Drawing.Size(139, 24);
            this.QLsk.Text = "SỨC KHỎE";
            this.QLsk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLsk.Click += new System.EventHandler(this.QLsk_Click);
            // 
            // QLlichSu
            // 
            this.QLlichSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLlichSu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QLlichSu.Name = "QLlichSu";
            this.QLlichSu.Size = new System.Drawing.Size(139, 24);
            this.QLlichSu.Text = "THỐNG KÊ";
            this.QLlichSu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLlichSu.Click += new System.EventHandler(this.lịchSửVàThốngKêToolStripMenuItem_Click);
            // 
            // QLuser
            // 
            this.QLuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLuser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QLuser.Name = "QLuser";
            this.QLuser.Size = new System.Drawing.Size(139, 24);
            this.QLuser.Text = "USERS";
            this.QLuser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLuser.Click += new System.EventHandler(this.quảnLíUserToolStripMenuItem_Click);
            // 
            // QlGroupUser
            // 
            this.QlGroupUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QlGroupUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QlGroupUser.Name = "QlGroupUser";
            this.QlGroupUser.Size = new System.Drawing.Size(139, 24);
            this.QlGroupUser.Text = "GROUP USER";
            this.QlGroupUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QlGroupUser.Click += new System.EventHandler(this.quảnLíGroupUSerToolStripMenuItem_Click);
            // 
            // QLsetting
            // 
            this.QLsetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLsetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QLsetting.Name = "QLsetting";
            this.QLsetting.Size = new System.Drawing.Size(139, 24);
            this.QLsetting.Text = "SETTINGS";
            this.QLsetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLsetting.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // QLbackUp
            // 
            this.QLbackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLbackUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QLbackUp.Name = "QLbackUp";
            this.QLbackUp.Size = new System.Drawing.Size(139, 24);
            this.QLbackUp.Text = "BACKUP";
            this.QLbackUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLbackUp.Click += new System.EventHandler(this.backUpToolStripMenuItem_Click);
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
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.msUserControl);
            this.groupBox1.Location = new System.Drawing.Point(-1, -7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 574);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
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
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 562);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TabHienThi);
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
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}