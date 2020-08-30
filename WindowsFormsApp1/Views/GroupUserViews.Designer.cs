namespace WindowsFormsApp1.Views
{
    partial class GroupUserViews
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.available = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.view = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.insert = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.option = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.idbranch,
            this.createat,
            this.updateat,
            this.available});
            this.dataGridView1.Location = new System.Drawing.Point(3, 287);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(495, 481);
            this.dataGridView1.TabIndex = 0;
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
            this.createat.Visible = false;
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
            this.available.HeaderText = "Hoat dong";
            this.available.Name = "available";
            this.available.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.available.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.available.TrueValue = "1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 241);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Group User";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(201, 176);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 19;
            this.textBox2.Text = "agss";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Hủy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "id";
            this.label8.TextChanged += new System.EventHandler(this.label8_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(265, 99);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Lưu";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(414, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Sửa";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(320, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Thêm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id1,
            this.permission,
            this.view,
            this.insert,
            this.update,
            this.delete,
            this.option});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView2.Location = new System.Drawing.Point(511, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(839, 768);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // id1
            // 
            this.id1.DataPropertyName = "id";
            this.id1.HeaderText = "id1";
            this.id1.Name = "id1";
            this.id1.Visible = false;
            // 
            // permission
            // 
            this.permission.DataPropertyName = "permission";
            this.permission.HeaderText = "permission";
            this.permission.Name = "permission";
            // 
            // view
            // 
            this.view.DataPropertyName = "view";
            this.view.FalseValue = "0";
            this.view.HeaderText = "view";
            this.view.Name = "view";
            this.view.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.view.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.view.TrueValue = "1";
            // 
            // insert
            // 
            this.insert.DataPropertyName = "insert";
            this.insert.FalseValue = "0";
            this.insert.HeaderText = "insert";
            this.insert.Name = "insert";
            this.insert.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.insert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.insert.TrueValue = "1";
            // 
            // update
            // 
            this.update.DataPropertyName = "update";
            this.update.FalseValue = "0";
            this.update.HeaderText = "update";
            this.update.Name = "update";
            this.update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.update.TrueValue = "1";
            // 
            // delete
            // 
            this.delete.DataPropertyName = "delete";
            this.delete.FalseValue = "0";
            this.delete.HeaderText = "delete";
            this.delete.Name = "delete";
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete.TrueValue = "1";
            // 
            // option
            // 
            this.option.DataPropertyName = "option";
            this.option.FalseValue = "0";
            this.option.HeaderText = "option";
            this.option.Name = "option";
            this.option.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.option.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.option.TrueValue = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quyền này không khả dụng";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(396, 250);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(102, 31);
            this.button6.TabIndex = 19;
            this.button6.Text = "Khôi phục";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // GroupUserViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GroupUserViews";
            this.Size = new System.Drawing.Size(1350, 768);
            this.Load += new System.EventHandler(this.GroupUserViews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn permission;
        private System.Windows.Forms.DataGridViewCheckBoxColumn view;
        private System.Windows.Forms.DataGridViewCheckBoxColumn insert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn update;
        private System.Windows.Forms.DataGridViewCheckBoxColumn delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn option;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn createat;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn available;
        private System.Windows.Forms.TextBox textBox2;
    }
}
