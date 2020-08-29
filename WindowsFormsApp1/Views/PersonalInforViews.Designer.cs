namespace WindowsFormsApp1.Views
{
    partial class PersonalInforViews
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nsText = new System.Windows.Forms.MaskedTextBox();
            this.TypeText = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gtText = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dcText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sdtText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hovatenText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.nsText);
            this.groupBox1.Controls.Add(this.TypeText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.gtText);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dcText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.emailText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.sdtText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.hovatenText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(41, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 621);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cá nhân";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(431, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "label8";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(577, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 67);
            this.button4.TabIndex = 30;
            this.button4.Text = "Hủy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(455, 186);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 67);
            this.button3.TabIndex = 29;
            this.button3.Text = "Lưu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(577, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 67);
            this.button2.TabIndex = 28;
            this.button2.Text = "Đổi mật khẩu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 67);
            this.button1.TabIndex = 27;
            this.button1.Text = "Sửa thông tin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nsText
            // 
            this.nsText.Culture = new System.Globalization.CultureInfo("vi-VN");
            this.nsText.Location = new System.Drawing.Point(176, 258);
            this.nsText.Mask = "00/00/0000";
            this.nsText.Name = "nsText";
            this.nsText.Size = new System.Drawing.Size(71, 20);
            this.nsText.TabIndex = 26;
            this.nsText.ValidatingType = typeof(System.DateTime);
            // 
            // TypeText
            // 
            this.TypeText.FormattingEnabled = true;
            this.TypeText.Location = new System.Drawing.Point(176, 353);
            this.TypeText.Name = "TypeText";
            this.TypeText.Size = new System.Drawing.Size(70, 21);
            this.TypeText.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(51, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 21);
            this.label7.TabIndex = 24;
            this.label7.Text = "Loại User";
            // 
            // gtText
            // 
            this.gtText.FormattingEnabled = true;
            this.gtText.Location = new System.Drawing.Point(176, 306);
            this.gtText.Name = "gtText";
            this.gtText.Size = new System.Drawing.Size(70, 21);
            this.gtText.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giới tính";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày sinh";
            // 
            // dcText
            // 
            this.dcText.Location = new System.Drawing.Point(176, 208);
            this.dcText.Name = "dcText";
            this.dcText.Size = new System.Drawing.Size(190, 20);
            this.dcText.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa chỉ";
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(176, 156);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(190, 20);
            this.emailText.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email";
            // 
            // sdtText
            // 
            this.sdtText.Location = new System.Drawing.Point(176, 107);
            this.sdtText.Name = "sdtText";
            this.sdtText.Size = new System.Drawing.Size(190, 20);
            this.sdtText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại";
            // 
            // hovatenText
            // 
            this.hovatenText.Location = new System.Drawing.Point(176, 59);
            this.hovatenText.Name = "hovatenText";
            this.hovatenText.Size = new System.Drawing.Size(190, 20);
            this.hovatenText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và Tên";
            // 
            // PersonalInforViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.groupBox1);
            this.Name = "PersonalInforViews";
            this.Size = new System.Drawing.Size(1232, 788);
            this.Load += new System.EventHandler(this.PersonalInforViews_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hovatenText;
        private System.Windows.Forms.TextBox sdtText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dcText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox gtText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TypeText;
        private System.Windows.Forms.MaskedTextBox nsText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
    }
}
