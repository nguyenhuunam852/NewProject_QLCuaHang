namespace WindowsFormsApp1.Views
{
    partial class ThongKeViews
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabHienThi = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.TabHienThi.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabHienThi
            // 
            this.TabHienThi.Controls.Add(this.tabPage5);
            this.TabHienThi.Controls.Add(this.tabPage1);
            this.TabHienThi.Controls.Add(this.tabPage2);
            this.TabHienThi.Controls.Add(this.tabPage3);
            this.TabHienThi.Controls.Add(this.tabPage4);
            this.TabHienThi.Location = new System.Drawing.Point(4, 3);
            this.TabHienThi.Name = "TabHienThi";
            this.TabHienThi.SelectedIndex = 0;
            this.TabHienThi.Size = new System.Drawing.Size(1350, 768);
            this.TabHienThi.TabIndex = 7;
            this.TabHienThi.SelectedIndexChanged += new System.EventHandler(this.TabHienThi_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1342, 742);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Lịch sử theo ngày";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1339, 658);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống kê theo tuần";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1339, 658);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thống kê theo tháng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1339, 658);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Thống kê theo quý";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1339, 658);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Thống kê theo năm";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ThongKeViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabHienThi);
            this.Name = "ThongKeViews";
            this.Size = new System.Drawing.Size(1354, 687);
            this.Load += new System.EventHandler(this.ThongKeViews_Load);
            this.TabHienThi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TabHienThi;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
    }
}
