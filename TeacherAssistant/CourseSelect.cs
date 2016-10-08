using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherAssistant_Model;
using TeacherAssistant_BLL;
namespace TeacherAssistant
{
    public partial class CourseSelect : Form
    {
        public CourseSelect()
        {
            InitializeComponent();
            ShowSemesters();
            ShowCourses();
        }

        private void ShowSemesters()
        {
            List<string> listS = TeachManager.GetSemesters(UserInfo.TeacherNo);
            Semesters.DataSource = listS;
        }

        private void ShowCourses()
        {
            List<Course> listC = CourseManager.GetTeachCourses(UserInfo.TeacherNo,Semesters.SelectedItem.ToString());
            Courses.DataSource = listC;
            Courses.ValueMember = "CourseNo";
            Courses.DisplayMember = "CourseName";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.Visible == true)
            {
                this.Hide();
                Application.Exit();
            }
        }

        private void CourseSelectButton_Click(object sender, EventArgs e)
        {
            if (Courses.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("请选择课程信息");
                return;
            }
            UserInfo.Semester = Semesters.SelectedItem.ToString();
            UserInfo.CourseNo = Courses.SelectedValue.ToString();
            UserInfo.CourseName = Courses.SelectedItem.ToString();
            this.Hide();
            Main main = new Main();
            main.Show();
        }

        private void Semesters_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCourses();
        }
    }
}
