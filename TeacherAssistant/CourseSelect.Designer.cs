namespace TeacherAssistant
{
    partial class CourseSelect
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
            this.Courses = new System.Windows.Forms.ComboBox();
            this.CourseSelectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择课程：";
            // 
            // Courses
            // 
            this.Courses.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Courses.FormattingEnabled = true;
            this.Courses.Location = new System.Drawing.Point(202, 95);
            this.Courses.Name = "Courses";
            this.Courses.Size = new System.Drawing.Size(255, 23);
            this.Courses.TabIndex = 1;
            // 
            // CourseSelectButton
            // 
            this.CourseSelectButton.Location = new System.Drawing.Point(173, 210);
            this.CourseSelectButton.Name = "CourseSelectButton";
            this.CourseSelectButton.Size = new System.Drawing.Size(112, 45);
            this.CourseSelectButton.TabIndex = 2;
            this.CourseSelectButton.Text = "确定";
            this.CourseSelectButton.UseVisualStyleBackColor = true;
            this.CourseSelectButton.Click += new System.EventHandler(this.CourseSelectButton_Click);
            // 
            // CourseSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 310);
            this.Controls.Add(this.CourseSelectButton);
            this.Controls.Add(this.Courses);
            this.Controls.Add(this.label1);
            this.Name = "CourseSelect";
            this.Text = "CourseSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Courses;
        private System.Windows.Forms.Button CourseSelectButton;
    }
}