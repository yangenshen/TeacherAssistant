using System;
using System.Windows.Forms;
using TeacherAssistant_BLL;
using TeacherAssistant_Model;

namespace TeacherAssistant
{
    public partial class Assessment : Form
    {
        public Assessment()
        {
            InitializeComponent();
            GetAssessments();
        }

        private void GetAssessments()
        {
            Assessments.DataSource = TeachManager.GetAssessments();
            Assessments.ValueMember = "AssessType";
            Assessments.DisplayMember = "AssessName";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAssessButton_Click(object sender, EventArgs e)
        {
            string aName = AssessName.Text;
            int aType = int.Parse(Assessments.SelectedValue.ToString());
            float defalutPoint = float.Parse(DefaultPoint.ToString());
            TeachManager.AddAssess(aName, aType, defalutPoint, UserInfo.CourseNo, UserInfo.Semester);
            ScoreManager.AddAssessForStu(UserInfo.CourseNo, UserInfo.Semester,aName,defalutPoint);
        }

        /// <summary>
        /// 验证数字输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }
    }
}
