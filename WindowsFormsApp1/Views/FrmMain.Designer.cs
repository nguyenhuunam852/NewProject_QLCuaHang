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
            this.quảnLíBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíTypeKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sứcKhỏeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửVàThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíGroupUSerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.msUserControl.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.msUserControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.msUserControl.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msUserControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.msUserControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLíBànToolStripMenuItem,
            this.quảnLíKháchHàngToolStripMenuItem,
            this.quảnLíTypeKháchHàngToolStripMenuItem,
            this.sứcKhỏeToolStripMenuItem,
            this.lịchSửVàThốngKêToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.quảnLíUserToolStripMenuItem,
            this.quảnLíGroupUSerToolStripMenuItem});
            this.msUserControl.Location = new System.Drawing.Point(0, 0);
            this.msUserControl.Name = "msUserControl";
            this.msUserControl.Size = new System.Drawing.Size(122, 749);
            this.msUserControl.TabIndex = 1;
            // 
            // quảnLíBànToolStripMenuItem
            // 
            this.quảnLíBànToolStripMenuItem.AutoSize = false;
            this.quảnLíBànToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quảnLíBànToolStripMenuItem.Name = "quảnLíBànToolStripMenuItem";
            this.quảnLíBànToolStripMenuItem.Size = new System.Drawing.Size(118, 18);
            this.quảnLíBànToolStripMenuItem.Text = "Quản lí ghế";
            this.quảnLíBànToolStripMenuItem.Click += new System.EventHandler(this.quảnLíBànToolStripMenuItem_Click);
            // 
            // quảnLíKháchHàngToolStripMenuItem
            // 
            this.quảnLíKháchHàngToolStripMenuItem.Name = "quảnLíKháchHàngToolStripMenuItem";
            this.quảnLíKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(118, 19);
            this.quảnLíKháchHàngToolStripMenuItem.Text = "Quản lí khách hàng";
            this.quảnLíKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLíKháchHàngToolStripMenuItem_Click);
            // 
            // quảnLíTypeKháchHàngToolStripMenuItem
            // 
            this.quảnLíTypeKháchHàngToolStripMenuItem.Name = "quảnLíTypeKháchHàngToolStripMenuItem";
            this.quảnLíTypeKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(118, 19);
            this.quảnLíTypeKháchHàngToolStripMenuItem.Text = "Loại Khách Hàng";
            this.quảnLíTypeKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLíTypeKháchHàngToolStripMenuItem_Click);
            // 
            // sứcKhỏeToolStripMenuItem
            // 
            this.sứcKhỏeToolStripMenuItem.Name = "sứcKhỏeToolStripMenuItem";
            this.sứcKhỏeToolStripMenuItem.Size = new System.Drawing.Size(118, 19);
            this.sứcKhỏeToolStripMenuItem.Text = "Sức khỏe";
            // 
            // lịchSửVàThốngKêToolStripMenuItem
            // 
            this.lịchSửVàThốngKêToolStripMenuItem.Name = "lịchSửVàThốngKêToolStripMenuItem";
            this.lịchSửVàThốngKêToolStripMenuItem.Size = new System.Drawing.Size(118, 19);
            this.lịchSửVàThốngKêToolStripMenuItem.Text = "Lịch sử và thống kê";
            this.lịchSửVàThốngKêToolStripMenuItem.Click += new System.EventHandler(this.lịchSửVàThốngKêToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(118, 19);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // quảnLíUserToolStripMenuItem
            // 
            this.quảnLíUserToolStripMenuItem.Name = "quảnLíUserToolStripMenuItem";
            this.quảnLíUserToolStripMenuItem.Size = new System.Drawing.Size(118, 19);
            this.quảnLíUserToolStripMenuItem.Text = "Quản lí User";
            // 
            // quảnLíGroupUSerToolStripMenuItem
            // 
            this.quảnLíGroupUSerToolStripMenuItem.Name = "quảnLíGroupUSerToolStripMenuItem";
            this.quảnLíGroupUSerToolStripMenuItem.Size = new System.Drawing.Size(118, 19);
            this.quảnLíGroupUSerToolStripMenuItem.Text = "Quản lí Group User";
            this.quảnLíGroupUSerToolStripMenuItem.Click += new System.EventHandler(this.quảnLíGroupUSerToolStripMenuItem_Click);
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
            this.TabHienThi.ContextMenuStrip = this.cntmsTag;
            this.TabHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabHienThi.Location = new System.Drawing.Point(122, 0);
            this.TabHienThi.Name = "TabHienThi";
            this.TabHienThi.SelectedIndex = 0;
            this.TabHienThi.Size = new System.Drawing.Size(1121, 749);
            this.TabHienThi.TabIndex = 3;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 749);
            this.Controls.Add(this.TabHienThi);
            this.Controls.Add(this.msUserControl);
            this.MainMenuStrip = this.msUserControl;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "FromMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.msUserControl.ResumeLayout(false);
            this.msUserControl.PerformLayout();
            this.cntmsTag.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip msUserControl;
        private System.Windows.Forms.ToolStripMenuItem quảnLíBànToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cntmsTag;
        private System.Windows.Forms.ToolStripMenuItem đóngTấtCảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đóngTrangHiệnTạiToolStripMenuItem;
        private System.Windows.Forms.TabControl TabHienThi;
        private System.Windows.Forms.ToolStripMenuItem quảnLíKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửVàThốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíGroupUSerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíTypeKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sứcKhỏeToolStripMenuItem;
    }
}