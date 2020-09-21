namespace WindowsFormsApp1.Views
{
    partial class ViewsLoaiKhachHang
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.closebutton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.savebutton = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.updatebutton = new System.Windows.Forms.Button();
            this.deletebutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.available = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.closebutton);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.savebutton);
            this.groupBox3.Controls.Add(this.addbutton);
            this.groupBox3.Controls.Add(this.updatebutton);
            this.groupBox3.Controls.Add(this.deletebutton);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 87);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(31, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(25, 26);
            this.textBox2.TabIndex = 19;
            this.textBox2.Text = "afs";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // closebutton
            // 
            this.closebutton.Location = new System.Drawing.Point(308, 20);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(30, 27);
            this.closebutton.TabIndex = 18;
            this.closebutton.Text = "Hủy";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "id";
            this.label8.TextChanged += new System.EventHandler(this.label8_TextChanged);
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(278, 20);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(30, 27);
            this.savebutton.TabIndex = 14;
            this.savebutton.Text = "Lưu";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.button5_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(187, 20);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(30, 27);
            this.addbutton.TabIndex = 11;
            this.addbutton.Text = "Thêm";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // updatebutton
            // 
            this.updatebutton.Location = new System.Drawing.Point(247, 20);
            this.updatebutton.Name = "updatebutton";
            this.updatebutton.Size = new System.Drawing.Size(30, 27);
            this.updatebutton.TabIndex = 13;
            this.updatebutton.Text = "Sửa";
            this.updatebutton.UseVisualStyleBackColor = true;
            this.updatebutton.Click += new System.EventHandler(this.button4_Click);
            // 
            // deletebutton
            // 
            this.deletebutton.Location = new System.Drawing.Point(217, 20);
            this.deletebutton.Name = "deletebutton";
            this.deletebutton.Size = new System.Drawing.Size(30, 27);
            this.deletebutton.TabIndex = 12;
            this.deletebutton.Text = "Xóa";
            this.deletebutton.UseVisualStyleBackColor = true;
            this.deletebutton.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(31, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.idbranch,
            this.createat,
            this.updateat,
            this.available});
            this.dataGridView1.Location = new System.Drawing.Point(0, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(784, 448);
            this.dataGridView1.TabIndex = 5;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "name";
            this.name.Name = "name";
            // 
            // idbranch
            // 
            this.idbranch.DataPropertyName = "idbranch";
            this.idbranch.HeaderText = "idbranch";
            this.idbranch.Name = "idbranch";
            this.idbranch.Visible = false;
            // 
            // createat
            // 
            this.createat.DataPropertyName = "createat";
            this.createat.HeaderText = "ngày tạo";
            this.createat.Name = "createat";
            // 
            // updateat
            // 
            this.updateat.DataPropertyName = "updateat";
            this.updateat.HeaderText = "updateat";
            this.updateat.Name = "updateat";
            this.updateat.Visible = false;
            // 
            // available
            // 
            this.available.DataPropertyName = "available";
            this.available.FalseValue = "0";
            this.available.HeaderText = "available";
            this.available.Name = "available";
            this.available.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.available.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.available.TrueValue = "1";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 96);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(174, 26);
            this.button6.TabIndex = 15;
            this.button6.Text = "Khôi phục";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(188, 96);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(153, 26);
            this.button7.TabIndex = 16;
            this.button7.Text = "Reload";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // ViewsLoaiKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Name = "ViewsLoaiKhachHang";
            this.Size = new System.Drawing.Size(784, 604);
            this.Load += new System.EventHandler(this.ViewsLoaiKhachHang_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.Button updatebutton;
        private System.Windows.Forms.Button deletebutton;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn createat;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn available;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button7;
    }
}
