namespace WindowsFormsApp1.Views
{
    partial class BranchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tennhanhlb = new System.Windows.Forms.Label();
            this.manhanhlb = new System.Windows.Forms.Label();
            this.dclable = new System.Windows.Forms.Label();
            this.apptokentxt = new System.Windows.Forms.TextBox();
            this.usetokentxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.savebutton = new System.Windows.Forms.Button();
            this.dctxt = new System.Windows.Forms.TextBox();
            this.codetxt = new System.Windows.Forms.TextBox();
            this.tennhanhtxt = new System.Windows.Forms.TextBox();
            this.closebutton = new System.Windows.Forms.Button();
            this.updatebutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Nhánh ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Nhánh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa Chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Use Token";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "App Token";
            // 
            // tennhanhlb
            // 
            this.tennhanhlb.AutoSize = true;
            this.tennhanhlb.Location = new System.Drawing.Point(120, 46);
            this.tennhanhlb.Name = "tennhanhlb";
            this.tennhanhlb.Size = new System.Drawing.Size(35, 13);
            this.tennhanhlb.TabIndex = 4;
            this.tennhanhlb.Text = "label6";
            // 
            // manhanhlb
            // 
            this.manhanhlb.AutoSize = true;
            this.manhanhlb.Location = new System.Drawing.Point(120, 93);
            this.manhanhlb.Name = "manhanhlb";
            this.manhanhlb.Size = new System.Drawing.Size(35, 13);
            this.manhanhlb.TabIndex = 5;
            this.manhanhlb.Text = "label7";
            // 
            // dclable
            // 
            this.dclable.AutoSize = true;
            this.dclable.Location = new System.Drawing.Point(120, 142);
            this.dclable.Name = "dclable";
            this.dclable.Size = new System.Drawing.Size(35, 13);
            this.dclable.TabIndex = 6;
            this.dclable.Text = "label8";
            this.dclable.Click += new System.EventHandler(this.label8_Click);
            // 
            // apptokentxt
            // 
            this.apptokentxt.Location = new System.Drawing.Point(123, 181);
            this.apptokentxt.Name = "apptokentxt";
            this.apptokentxt.Size = new System.Drawing.Size(255, 20);
            this.apptokentxt.TabIndex = 7;
            // 
            // usetokentxt
            // 
            this.usetokentxt.Location = new System.Drawing.Point(123, 226);
            this.usetokentxt.Name = "usetokentxt";
            this.usetokentxt.Size = new System.Drawing.Size(255, 20);
            this.usetokentxt.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.savebutton);
            this.groupBox1.Controls.Add(this.dctxt);
            this.groupBox1.Controls.Add(this.codetxt);
            this.groupBox1.Controls.Add(this.tennhanhtxt);
            this.groupBox1.Controls.Add(this.closebutton);
            this.groupBox1.Controls.Add(this.updatebutton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.usetokentxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.apptokentxt);
            this.groupBox1.Controls.Add(this.tennhanhlb);
            this.groupBox1.Controls.Add(this.dclable);
            this.groupBox1.Controls.Add(this.manhanhlb);
            this.groupBox1.Location = new System.Drawing.Point(24, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 396);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tên chi nhánh";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(294, 298);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 29);
            this.savebutton.TabIndex = 16;
            this.savebutton.Text = "Lưu";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // dctxt
            // 
            this.dctxt.Location = new System.Drawing.Point(123, 135);
            this.dctxt.Name = "dctxt";
            this.dctxt.Size = new System.Drawing.Size(255, 20);
            this.dctxt.TabIndex = 15;
            // 
            // codetxt
            // 
            this.codetxt.Location = new System.Drawing.Point(123, 86);
            this.codetxt.Name = "codetxt";
            this.codetxt.Size = new System.Drawing.Size(255, 20);
            this.codetxt.TabIndex = 14;
            // 
            // tennhanhtxt
            // 
            this.tennhanhtxt.Location = new System.Drawing.Point(123, 39);
            this.tennhanhtxt.Name = "tennhanhtxt";
            this.tennhanhtxt.Size = new System.Drawing.Size(255, 20);
            this.tennhanhtxt.TabIndex = 13;
            // 
            // closebutton
            // 
            this.closebutton.Location = new System.Drawing.Point(294, 333);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(75, 29);
            this.closebutton.TabIndex = 12;
            this.closebutton.Text = "Hủy";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // updatebutton
            // 
            this.updatebutton.Location = new System.Drawing.Point(26, 313);
            this.updatebutton.Name = "updatebutton";
            this.updatebutton.Size = new System.Drawing.Size(75, 49);
            this.updatebutton.TabIndex = 11;
            this.updatebutton.Text = "Sửa thông tin";
            this.updatebutton.UseVisualStyleBackColor = true;
            this.updatebutton.Click += new System.EventHandler(this.button3_Click);
            // 
            // BranchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.groupBox1);
            this.Name = "BranchForm";
            this.Size = new System.Drawing.Size(784, 536);
            this.Load += new System.EventHandler(this.BranchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label tennhanhlb;
        private System.Windows.Forms.Label manhanhlb;
        private System.Windows.Forms.Label dclable;
        private System.Windows.Forms.TextBox apptokentxt;
        private System.Windows.Forms.TextBox usetokentxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.Button updatebutton;
        private System.Windows.Forms.TextBox dctxt;
        private System.Windows.Forms.TextBox codetxt;
        private System.Windows.Forms.TextBox tennhanhtxt;
        private System.Windows.Forms.Button savebutton;
    }
}
