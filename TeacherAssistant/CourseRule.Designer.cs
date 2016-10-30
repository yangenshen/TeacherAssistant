namespace TeacherAssistant
{
    partial class CourseRule
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.RuleNoLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GradeLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Exit = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ReadyLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TotalNumLabel = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(19, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "成绩规则";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(12, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(641, 225);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "规则编号";
            // 
            // RuleNoLabel
            // 
            this.RuleNoLabel.AutoSize = true;
            this.RuleNoLabel.Location = new System.Drawing.Point(132, 221);
            this.RuleNoLabel.Name = "RuleNoLabel";
            this.RuleNoLabel.Size = new System.Drawing.Size(55, 15);
            this.RuleNoLabel.TabIndex = 2;
            this.RuleNoLabel.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "是否检验";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "是";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "规则描述";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(132, 257);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(55, 15);
            this.DescriptionLabel.TabIndex = 6;
            this.DescriptionLabel.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "目标分制";
            // 
            // GradeLabel
            // 
            this.GradeLabel.AutoSize = true;
            this.GradeLabel.Location = new System.Drawing.Point(422, 257);
            this.GradeLabel.Name = "GradeLabel";
            this.GradeLabel.Size = new System.Drawing.Size(55, 15);
            this.GradeLabel.TabIndex = 8;
            this.GradeLabel.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 648);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "规则版本号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.GradeLabel);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.DescriptionLabel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.RuleNoLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(20, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(657, 290);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "规则详细";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(11, 33);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(640, 142);
            this.dataGridView2.TabIndex = 9;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(529, 647);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(108, 32);
            this.Exit.TabIndex = 11;
            this.Exit.Text = "关闭";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(150, 645);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(63, 15);
            this.VersionLabel.TabIndex = 12;
            this.VersionLabel.Text = "label10";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(186, 19);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "根据人数/比例给定成绩";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(22, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(148, 19);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "根据得分给定成绩";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(56, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 51);
            this.panel1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "已安排人数";
            // 
            // ReadyLabel
            // 
            this.ReadyLabel.AutoSize = true;
            this.ReadyLabel.Location = new System.Drawing.Point(430, 293);
            this.ReadyLabel.Name = "ReadyLabel";
            this.ReadyLabel.Size = new System.Drawing.Size(15, 15);
            this.ReadyLabel.TabIndex = 17;
            this.ReadyLabel.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "/";
            // 
            // TotalNumLabel
            // 
            this.TotalNumLabel.AutoSize = true;
            this.TotalNumLabel.Location = new System.Drawing.Point(489, 293);
            this.TotalNumLabel.Name = "TotalNumLabel";
            this.TotalNumLabel.Size = new System.Drawing.Size(15, 15);
            this.TotalNumLabel.TabIndex = 19;
            this.TotalNumLabel.Text = "0";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(433, 648);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(74, 31);
            this.UpdateButton.TabIndex = 20;
            this.UpdateButton.Text = "更改";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "成绩";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "人数";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "人数比例";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "得分下限";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "向上累积";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "向下累积";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // CourseRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 693);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.TotalNumLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ReadyLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Name = "CourseRule";
            this.Text = "a";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RuleNoLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label GradeLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ReadyLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label TotalNumLabel;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}