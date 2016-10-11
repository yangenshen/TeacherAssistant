using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherAssistant_DAL;
using TeacherAssistant_BLL;
using TeacherAssistant;

namespace TeacherAssistant_UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string name = NameValue.Text;
            string pwd = PwdValue.Text;
            if (UserInfoManager.CheckLogin(name, pwd))
            {
                this.Hide();
                CourseSelect courseSelect = new CourseSelect();
                courseSelect.Show();
            }
            else
            {
                MessageBox.Show("账号或密码错误");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Environment.Exit(0);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.Visible == true)
            {
                this.Hide();
                Application.Exit();
            }
        }

        private void PwdValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }
    }
}
