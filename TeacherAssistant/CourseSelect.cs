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
namespace TeacherAssistant
{
    public partial class CourseSelect : Form
    {
        public CourseSelect()
        {
            InitializeComponent();
            DataBinding();
            Courses.SelectedItem = Courses.Items[Courses.Items.Count - 1];
            if (Courses.Items.Count == 1)
            {
                CourseSelectButton.Visible = false;
            }
        }

        private void DataBinding()
        {
            IList<Course> listC = TeacherAssistant_BLL.CourseManager.GetCoursesByTeacher(UserInfo.TeacherNo);
            Courses.DataSource = listC;
            Courses.ValueMember = "CourseId";
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
            UserInfo.CourseId = int.Parse(Courses.SelectedValue.ToString());
            this.Hide();
            Main main = new Main();
            main.Show();
        }
    }
}
