namespace TeacherAssistant
{
    partial class Assessment
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmTextBox = new System.Windows.Forms.TextBox();
            this.CpTextBox = new System.Windows.Forms.TextBox();
            this.BmTextBox = new System.Windows.Forms.TextBox();
            this.BpTextBox = new System.Windows.Forms.TextBox();
            this.AmTextBox = new System.Windows.Forms.TextBox();
            this.PTextBox = new System.Windows.Forms.TextBox();
            this.FTextBox = new System.Windows.Forms.TextBox();
            this.DTextBox = new System.Windows.Forms.TextBox();
            this.CTextBox = new System.Windows.Forms.TextBox();
            this.BTextBox = new System.Windows.Forms.TextBox();
            this.ATextBox = new System.Windows.Forms.TextBox();
            this.PLabel = new System.Windows.Forms.Label();
            this.CmLabel = new System.Windows.Forms.Label();
            this.CpLabel = new System.Windows.Forms.Label();
            this.BmLabel = new System.Windows.Forms.Label();
            this.BpLabel = new System.Windows.Forms.Label();
            this.AmLabel = new System.Windows.Forms.Label();
            this.FLabel = new System.Windows.Forms.Label();
            this.DLabel = new System.Windows.Forms.Label();
            this.CLabel = new System.Windows.Forms.Label();
            this.BLabel = new System.Windows.Forms.Label();
            this.ALabel = new System.Windows.Forms.Label();
            this.ScoreMethods = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DefaultPoint = new System.Windows.Forms.TextBox();
            this.DefaultGrade = new System.Windows.Forms.ComboBox();
            this.Assessments = new System.Windows.Forms.ComboBox();
            this.AssessName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddAssessButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "考核比例设置";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(11, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(465, 187);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "考核名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "考核所占比例";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "考核方式";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "平均分";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.CmTextBox);
            this.groupBox1.Controls.Add(this.CpTextBox);
            this.groupBox1.Controls.Add(this.BmTextBox);
            this.groupBox1.Controls.Add(this.BpTextBox);
            this.groupBox1.Controls.Add(this.AmTextBox);
            this.groupBox1.Controls.Add(this.PTextBox);
            this.groupBox1.Controls.Add(this.FTextBox);
            this.groupBox1.Controls.Add(this.DTextBox);
            this.groupBox1.Controls.Add(this.CTextBox);
            this.groupBox1.Controls.Add(this.BTextBox);
            this.groupBox1.Controls.Add(this.ATextBox);
            this.groupBox1.Controls.Add(this.PLabel);
            this.groupBox1.Controls.Add(this.CmLabel);
            this.groupBox1.Controls.Add(this.CpLabel);
            this.groupBox1.Controls.Add(this.BmLabel);
            this.groupBox1.Controls.Add(this.BpLabel);
            this.groupBox1.Controls.Add(this.AmLabel);
            this.groupBox1.Controls.Add(this.FLabel);
            this.groupBox1.Controls.Add(this.DLabel);
            this.groupBox1.Controls.Add(this.CLabel);
            this.groupBox1.Controls.Add(this.BLabel);
            this.groupBox1.Controls.Add(this.ALabel);
            this.groupBox1.Controls.Add(this.ScoreMethods);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DefaultPoint);
            this.groupBox1.Controls.Add(this.DefaultGrade);
            this.groupBox1.Controls.Add(this.Assessments);
            this.groupBox1.Controls.Add(this.AssessName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(11, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 318);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "增加考核";
            // 
            // CmTextBox
            // 
            this.CmTextBox.Location = new System.Drawing.Point(392, 262);
            this.CmTextBox.MaxLength = 2;
            this.CmTextBox.Multiline = true;
            this.CmTextBox.Name = "CmTextBox";
            this.CmTextBox.Size = new System.Drawing.Size(40, 20);
            this.CmTextBox.TabIndex = 30;
            this.CmTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // CpTextBox
            // 
            this.CpTextBox.Location = new System.Drawing.Point(311, 262);
            this.CpTextBox.MaxLength = 2;
            this.CpTextBox.Multiline = true;
            this.CpTextBox.Name = "CpTextBox";
            this.CpTextBox.Size = new System.Drawing.Size(40, 20);
            this.CpTextBox.TabIndex = 29;
            this.CpTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // BmTextBox
            // 
            this.BmTextBox.Location = new System.Drawing.Point(230, 262);
            this.BmTextBox.MaxLength = 2;
            this.BmTextBox.Multiline = true;
            this.BmTextBox.Name = "BmTextBox";
            this.BmTextBox.Size = new System.Drawing.Size(40, 20);
            this.BmTextBox.TabIndex = 28;
            this.BmTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // BpTextBox
            // 
            this.BpTextBox.Location = new System.Drawing.Point(149, 262);
            this.BpTextBox.MaxLength = 2;
            this.BpTextBox.Multiline = true;
            this.BpTextBox.Name = "BpTextBox";
            this.BpTextBox.Size = new System.Drawing.Size(40, 20);
            this.BpTextBox.TabIndex = 27;
            this.BpTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // AmTextBox
            // 
            this.AmTextBox.Location = new System.Drawing.Point(56, 262);
            this.AmTextBox.MaxLength = 2;
            this.AmTextBox.Multiline = true;
            this.AmTextBox.Name = "AmTextBox";
            this.AmTextBox.Size = new System.Drawing.Size(40, 20);
            this.AmTextBox.TabIndex = 26;
            this.AmTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // PTextBox
            // 
            this.PTextBox.Location = new System.Drawing.Point(392, 194);
            this.PTextBox.MaxLength = 3;
            this.PTextBox.Multiline = true;
            this.PTextBox.Name = "PTextBox";
            this.PTextBox.Size = new System.Drawing.Size(40, 20);
            this.PTextBox.TabIndex = 25;
            this.PTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // FTextBox
            // 
            this.FTextBox.Location = new System.Drawing.Point(392, 234);
            this.FTextBox.MaxLength = 2;
            this.FTextBox.Multiline = true;
            this.FTextBox.Name = "FTextBox";
            this.FTextBox.Size = new System.Drawing.Size(40, 20);
            this.FTextBox.TabIndex = 24;
            this.FTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // DTextBox
            // 
            this.DTextBox.Location = new System.Drawing.Point(311, 234);
            this.DTextBox.MaxLength = 2;
            this.DTextBox.Multiline = true;
            this.DTextBox.Name = "DTextBox";
            this.DTextBox.Size = new System.Drawing.Size(40, 20);
            this.DTextBox.TabIndex = 23;
            this.DTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // CTextBox
            // 
            this.CTextBox.Location = new System.Drawing.Point(230, 234);
            this.CTextBox.MaxLength = 2;
            this.CTextBox.Multiline = true;
            this.CTextBox.Name = "CTextBox";
            this.CTextBox.Size = new System.Drawing.Size(40, 20);
            this.CTextBox.TabIndex = 22;
            this.CTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // BTextBox
            // 
            this.BTextBox.Location = new System.Drawing.Point(148, 234);
            this.BTextBox.MaxLength = 2;
            this.BTextBox.Multiline = true;
            this.BTextBox.Name = "BTextBox";
            this.BTextBox.Size = new System.Drawing.Size(40, 20);
            this.BTextBox.TabIndex = 21;
            this.BTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // ATextBox
            // 
            this.ATextBox.Location = new System.Drawing.Point(56, 234);
            this.ATextBox.MaxLength = 3;
            this.ATextBox.Multiline = true;
            this.ATextBox.Name = "ATextBox";
            this.ATextBox.Size = new System.Drawing.Size(40, 20);
            this.ATextBox.TabIndex = 20;
            this.ATextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // PLabel
            // 
            this.PLabel.AutoSize = true;
            this.PLabel.Location = new System.Drawing.Point(362, 194);
            this.PLabel.Name = "PLabel";
            this.PLabel.Size = new System.Drawing.Size(19, 20);
            this.PLabel.TabIndex = 19;
            this.PLabel.Text = "P";
            // 
            // CmLabel
            // 
            this.CmLabel.AutoSize = true;
            this.CmLabel.Location = new System.Drawing.Point(362, 262);
            this.CmLabel.Name = "CmLabel";
            this.CmLabel.Size = new System.Drawing.Size(29, 20);
            this.CmLabel.TabIndex = 18;
            this.CmLabel.Text = "C-";
            // 
            // CpLabel
            // 
            this.CpLabel.AutoSize = true;
            this.CpLabel.Location = new System.Drawing.Point(286, 262);
            this.CpLabel.Name = "CpLabel";
            this.CpLabel.Size = new System.Drawing.Size(29, 20);
            this.CpLabel.TabIndex = 17;
            this.CpLabel.Text = "C+";
            // 
            // BmLabel
            // 
            this.BmLabel.AutoSize = true;
            this.BmLabel.Location = new System.Drawing.Point(197, 262);
            this.BmLabel.Name = "BmLabel";
            this.BmLabel.Size = new System.Drawing.Size(29, 20);
            this.BmLabel.TabIndex = 16;
            this.BmLabel.Text = "B-";
            // 
            // BpLabel
            // 
            this.BpLabel.AutoSize = true;
            this.BpLabel.Location = new System.Drawing.Point(114, 262);
            this.BpLabel.Name = "BpLabel";
            this.BpLabel.Size = new System.Drawing.Size(29, 20);
            this.BpLabel.TabIndex = 15;
            this.BpLabel.Text = "B+";
            // 
            // AmLabel
            // 
            this.AmLabel.AutoSize = true;
            this.AmLabel.Location = new System.Drawing.Point(21, 262);
            this.AmLabel.Name = "AmLabel";
            this.AmLabel.Size = new System.Drawing.Size(29, 20);
            this.AmLabel.TabIndex = 14;
            this.AmLabel.Text = "A-";
            // 
            // FLabel
            // 
            this.FLabel.AutoSize = true;
            this.FLabel.Location = new System.Drawing.Point(362, 234);
            this.FLabel.Name = "FLabel";
            this.FLabel.Size = new System.Drawing.Size(19, 20);
            this.FLabel.TabIndex = 13;
            this.FLabel.Text = "F";
            // 
            // DLabel
            // 
            this.DLabel.AutoSize = true;
            this.DLabel.Location = new System.Drawing.Point(286, 234);
            this.DLabel.Name = "DLabel";
            this.DLabel.Size = new System.Drawing.Size(19, 20);
            this.DLabel.TabIndex = 12;
            this.DLabel.Text = "D";
            // 
            // CLabel
            // 
            this.CLabel.AutoSize = true;
            this.CLabel.Location = new System.Drawing.Point(197, 234);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(19, 20);
            this.CLabel.TabIndex = 11;
            this.CLabel.Text = "C";
            // 
            // BLabel
            // 
            this.BLabel.AutoSize = true;
            this.BLabel.Location = new System.Drawing.Point(114, 234);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(19, 20);
            this.BLabel.TabIndex = 10;
            this.BLabel.Text = "B";
            // 
            // ALabel
            // 
            this.ALabel.AutoSize = true;
            this.ALabel.Location = new System.Drawing.Point(21, 234);
            this.ALabel.Name = "ALabel";
            this.ALabel.Size = new System.Drawing.Size(19, 20);
            this.ALabel.TabIndex = 9;
            this.ALabel.Text = "A";
            // 
            // ScoreMethods
            // 
            this.ScoreMethods.FormattingEnabled = true;
            this.ScoreMethods.Location = new System.Drawing.Point(145, 140);
            this.ScoreMethods.Name = "ScoreMethods";
            this.ScoreMethods.Size = new System.Drawing.Size(209, 28);
            this.ScoreMethods.TabIndex = 8;
            this.ScoreMethods.SelectedIndexChanged += new System.EventHandler(this.ScoreMethods_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "给分形式";
            // 
            // DefaultPoint
            // 
            this.DefaultPoint.Location = new System.Drawing.Point(145, 184);
            this.DefaultPoint.MaxLength = 3;
            this.DefaultPoint.Name = "DefaultPoint";
            this.DefaultPoint.Size = new System.Drawing.Size(71, 30);
            this.DefaultPoint.TabIndex = 5;
            this.DefaultPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberKeyPress);
            // 
            // DefaultGrade
            // 
            this.DefaultGrade.Location = new System.Drawing.Point(145, 184);
            this.DefaultGrade.Name = "DefaultGrade";
            this.DefaultGrade.Size = new System.Drawing.Size(91, 28);
            this.DefaultGrade.TabIndex = 6;
            // 
            // Assessments
            // 
            this.Assessments.FormattingEnabled = true;
            this.Assessments.Location = new System.Drawing.Point(145, 91);
            this.Assessments.Name = "Assessments";
            this.Assessments.Size = new System.Drawing.Size(209, 28);
            this.Assessments.TabIndex = 4;
            // 
            // AssessName
            // 
            this.AssessName.Location = new System.Drawing.Point(145, 40);
            this.AssessName.Name = "AssessName";
            this.AssessName.Size = new System.Drawing.Size(209, 30);
            this.AssessName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "默认得分";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "考核形式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "考核名称";
            // 
            // AddAssessButton
            // 
            this.AddAssessButton.Location = new System.Drawing.Point(96, 561);
            this.AddAssessButton.Name = "AddAssessButton";
            this.AddAssessButton.Size = new System.Drawing.Size(115, 36);
            this.AddAssessButton.TabIndex = 6;
            this.AddAssessButton.Text = "添加";
            this.AddAssessButton.UseVisualStyleBackColor = true;
            this.AddAssessButton.Click += new System.EventHandler(this.AddAssessButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(251, 561);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(114, 36);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "关闭";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Assessment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(502, 597);
            this.ControlBox = false;
            this.Controls.Add(this.AddAssessButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Assessment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考核设置";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DefaultPoint;
        private System.Windows.Forms.ComboBox DefaultGrade;
        private System.Windows.Forms.ComboBox Assessments;
        private System.Windows.Forms.TextBox AssessName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddAssessButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ComboBox ScoreMethods;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label PLabel;
        private System.Windows.Forms.Label CmLabel;
        private System.Windows.Forms.Label CpLabel;
        private System.Windows.Forms.Label BmLabel;
        private System.Windows.Forms.Label BpLabel;
        private System.Windows.Forms.Label AmLabel;
        private System.Windows.Forms.Label FLabel;
        private System.Windows.Forms.Label DLabel;
        private System.Windows.Forms.Label CLabel;
        private System.Windows.Forms.Label BLabel;
        private System.Windows.Forms.Label ALabel;
        private System.Windows.Forms.TextBox CmTextBox;
        private System.Windows.Forms.TextBox CpTextBox;
        private System.Windows.Forms.TextBox BmTextBox;
        private System.Windows.Forms.TextBox BpTextBox;
        private System.Windows.Forms.TextBox AmTextBox;
        private System.Windows.Forms.TextBox PTextBox;
        private System.Windows.Forms.TextBox FTextBox;
        private System.Windows.Forms.TextBox DTextBox;
        private System.Windows.Forms.TextBox CTextBox;
        private System.Windows.Forms.TextBox BTextBox;
        private System.Windows.Forms.TextBox ATextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}