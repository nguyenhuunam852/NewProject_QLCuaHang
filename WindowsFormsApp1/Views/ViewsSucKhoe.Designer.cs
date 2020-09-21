namespace WindowsFormsApp1.Views
{
    partial class ViewsSucKhoe
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
            this.cancelbutton = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThem = new System.Windows.Forms.TextBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.available = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.cancelbutton);
            this.groupBox3.Controls.Add(this.savebtn);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.deletebtn);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtThem);
            this.groupBox3.Controls.Add(this.addbutton);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(525, 76);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin";
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(361, 26);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(30, 27);
            this.cancelbutton.TabIndex = 18;
            this.cancelbutton.Text = "Hủy";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(331, 26);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(30, 27);
            this.savebtn.TabIndex = 14;
            this.savebtn.Text = "Lưu";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightGray;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Location = new System.Drawing.Point(271, 26);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(30, 27);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.button4_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(301, 26);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(30, 27);
            this.deletebtn.TabIndex = 12;
            this.deletebtn.Text = "Xóa";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 1;
            // 
            // txtThem
            // 
            this.txtThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThem.Location = new System.Drawing.Point(26, 27);
            this.txtThem.Name = "txtThem";
            this.txtThem.Size = new System.Drawing.Size(151, 26);
            this.txtThem.TabIndex = 0;
            this.txtThem.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtThem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.txtThem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            // 
            // addbutton
            // 
            this.addbutton.BackColor = System.Drawing.Color.Gainsboro;
            this.addbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.Location = new System.Drawing.Point(241, 26);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(30, 27);
            this.addbutton.TabIndex = 11;
            this.addbutton.Text = "12";
            this.addbutton.UseVisualStyleBackColor = false;
            this.addbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(718, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "id";
            this.label8.TextChanged += new System.EventHandler(this.label8_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(699, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(34, 26);
            this.textBox2.TabIndex = 19;
            this.textBox2.Text = "gasg";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1350, 623);
            this.dataGridView1.TabIndex = 4;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
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
            this.button6.Location = new System.Drawing.Point(157, 85);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(149, 24);
            this.button6.TabIndex = 19;
            this.button6.Text = "Khôi phục";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(312, 85);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(145, 24);
            this.button8.TabIndex = 29;
            this.button8.Text = "Reload";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 26);
            this.textBox1.TabIndex = 19;
            // 
            // ViewsSucKhoe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Name = "ViewsSucKhoe";
            this.Size = new System.Drawing.Size(1350, 768);
            this.Load += new System.EventHandler(this.ViewsSucKhoe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewsSucKhoe_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn createat;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn available;
        private System.Windows.Forms.TextBox textBox1;
    }
}
