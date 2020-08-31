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
            this.msUserControl.SuspendLayout();
            this.cntmsTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // msUserControl
            // 
            this.msUserControl.AutoSize = false;
            this.msUserControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.msUserControl.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.msUserControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.dangToolStripMenuItem,
            this.QLGhe,
            this.QLkhachhang,
            this.QLloaiKH,
            this.QLsk,
            this.QLlichSu,
            this.QLuser,
            this.QlGroupUser,
            this.QLsetting,
            this.QLbackUp});
            this.msUserControl.Location = new System.Drawing.Point(0, 0);
            this.msUserControl.Name = "msUserControl";
            this.msUserControl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.msUserControl.Size = new System.Drawing.Size(784, 24);
            this.msUserControl.TabIndex = 1;
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.thôngTinCáNhânToolStripMenuItem.Text = "CÁ NHÂN";
            this.thôngTinCáNhânToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // dangToolStripMenuItem
            // 
            this.dangToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dangToolStripMenuItem.Name = "dangToolStripMenuItem";
            this.dangToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.dangToolStripMenuItem.Text = "ĐĂNG XUẤT";
            this.dangToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dangToolStripMenuItem.Click += new System.EventHandler(this.dangToolStripMenuItem_Click);
            // 
            // QLGhe
            // 
            this.QLGhe.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLGhe.Name = "QLGhe";
            this.QLGhe.Size = new System.Drawing.Size(37, 20);
            this.QLGhe.Text = "GHẾ";
            this.QLGhe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLGhe.Click += new System.EventHandler(this.quảnLíBànToolStripMenuItem_Click);
            // 
            // QLkhachhang
            // 
            this.QLkhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLkhachhang.Name = "QLkhachhang";
            this.QLkhachhang.Size = new System.Drawing.Size(81, 20);
            this.QLkhachhang.Text = "KHÁCH HÀNG";
            this.QLkhachhang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLkhachhang.Click += new System.EventHandler(this.quảnLíKháchHàngToolStripMenuItem_Click);
            // 
            // QLloaiKH
            // 
            this.QLloaiKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLloaiKH.Name = "QLloaiKH";
            this.QLloaiKH.Size = new System.Drawing.Size(105, 20);
            this.QLloaiKH.Text = "LOẠI KHÁCH HÀNG";
            this.QLloaiKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLloaiKH.Click += new System.EventHandler(this.quảnLíTypeKháchHàngToolStripMenuItem_Click);
            // 
            // QLsk
            // 
            this.QLsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLsk.Name = "QLsk";
            this.QLsk.Size = new System.Drawing.Size(65, 20);
            this.QLsk.Text = "SỨC KHỎE";
            this.QLsk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLsk.Click += new System.EventHandler(this.QLsk_Click);
            // 
            // QLlichSu
            // 
            this.QLlichSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLlichSu.Name = "QLlichSu";
            this.QLlichSu.Size = new System.Drawing.Size(64, 20);
            this.QLlichSu.Text = "THỐNG KÊ";
            this.QLlichSu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLlichSu.Click += new System.EventHandler(this.lịchSửVàThốngKêToolStripMenuItem_Click);
            // 
            // QLuser
            // 
            this.QLuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLuser.Name = "QLuser";
            this.QLuser.Size = new System.Drawing.Size(49, 20);
            this.QLuser.Text = "USERS";
            this.QLuser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLuser.Click += new System.EventHandler(this.quảnLíUserToolStripMenuItem_Click);
            // 
            // QlGroupUser
            // 
            this.QlGroupUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QlGroupUser.Name = "QlGroupUser";
            this.QlGroupUser.Size = new System.Drawing.Size(79, 20);
            this.QlGroupUser.Text = "GROUP USER";
            this.QlGroupUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QlGroupUser.Click += new System.EventHandler(this.quảnLíGroupUSerToolStripMenuItem_Click);
            // 
            // QLsetting
            // 
            this.QLsetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLsetting.Name = "QLsetting";
            this.QLsetting.Size = new System.Drawing.Size(62, 20);
            this.QLsetting.Text = "SETTINGS";
            this.QLsetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QLsetting.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // QLbackUp
            // 
            this.QLbackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.QLbackUp.Name = "QLbackUp";
            this.QLbackUp.Size = new System.Drawing.Size(56, 20);
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
            this.TabHienThi.Location = new System.Drawing.Point(0, 27);
            this.TabHienThi.Name = "TabHienThi";
            this.TabHienThi.SelectedIndex = 0;
            this.TabHienThi.Size = new System.Drawing.Size(784, 604);
            this.TabHienThi.TabIndex = 3;
            this.TabHienThi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TabHienThi_MouseMove);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
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
    }
}