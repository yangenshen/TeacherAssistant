﻿namespace TeacherAssistant_UI
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PwdLabel = new System.Windows.Forms.Label();
            this.NameValue = new System.Windows.Forms.TextBox();
            this.PwdValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(128, 209);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(58, 25);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "登陆";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(248, 208);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(52, 25);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "退出";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(146, 65);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 12);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "工号";
            // 
            // PwdLabel
            // 
            this.PwdLabel.AutoSize = true;
            this.PwdLabel.Location = new System.Drawing.Point(140, 106);
            this.PwdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PwdLabel.Name = "PwdLabel";
            this.PwdLabel.Size = new System.Drawing.Size(29, 12);
            this.PwdLabel.TabIndex = 3;
            this.PwdLabel.Text = "密码";
            // 
            // NameValue
            // 
            this.NameValue.Location = new System.Drawing.Point(278, 57);
            this.NameValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NameValue.Name = "NameValue";
            this.NameValue.Size = new System.Drawing.Size(121, 21);
            this.NameValue.TabIndex = 0;
            // 
            // PwdValue
            // 
            this.PwdValue.Location = new System.Drawing.Point(276, 98);
            this.PwdValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PwdValue.Name = "PwdValue";
            this.PwdValue.Size = new System.Drawing.Size(131, 21);
            this.PwdValue.TabIndex = 1;
            this.PwdValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PwdValue_KeyDown);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 318);
            this.Controls.Add(this.PwdValue);
            this.Controls.Add(this.NameValue);
            this.Controls.Add(this.PwdLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LoginButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Login";
            this.Text = "欢迎登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PwdLabel;
        private System.Windows.Forms.TextBox NameValue;
        private System.Windows.Forms.TextBox PwdValue;
    }
}

