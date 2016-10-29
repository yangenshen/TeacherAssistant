using System;
using System.Windows.Forms;
using TeacherAssistant_Model;
using TeacherAssistant_BLL;

namespace TeacherAssistant
{
    public partial class CourseRule : Form
    {

        private int GradeLevels;
        private string resetValue = string.Empty;
        private int readeyNum;


        public CourseRule()
        {
            InitializeComponent();
            ShowDetails();
        }

        private void ShowDetails()
        {
            readeyNum = UserInfo.NumOfStu;
            //如果还未存在，则新建一个
            if (!RuleManager.ExistRule(UserInfo.CourseNo, UserInfo.Semester))
            {
                RuleManager.CreateRule(UserInfo.CourseNo, UserInfo.Semester);
                readeyNum = 0;
            }
            readeyNum = 0;
            Rule rule = RuleManager.GetRule(UserInfo.CourseNo, UserInfo.Semester);
            #region 判断成绩等级制
            switch (UserInfo.Type)
            {
                case CourseType.本科课程:
                    GradeLevels = 10;
                    GradeLabel.Text = "十分制";
                    break;
                case CourseType.MBA课程:
                    GradeLevels = 5;
                    GradeLabel.Text = "五分制";
                    break;
                case CourseType.研究生课程:
                    GradeLevels = 5;
                    GradeLabel.Text = "五分制";
                    break;
                default:
                    break;
            }
            if (GradeLevels == 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = GradeList.gradesTen[i];
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = GradeList.gradesFive[i];
                }
            }
            #endregion
            if (rule.RuleType == 1)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

            RuleNoLabel.Text = rule.RuleNo.ToString();
            VersionLabel.Text = rule.Version.ToString();
            DescriptionLabel.Text = rule.Description;
            TotalNumLabel.Text = UserInfo.NumOfStu.ToString();
            ReadyLabel.Text = readeyNum.ToString();

            //解析人数 A:3;B:4;C:5...
            if (rule.NumDetails != "")
            {
                string[] nums = rule.NumDetails.Split(';');
                for (int i = 0; i < GradeLevels; i++)
                {
                    int n = int.Parse(nums[i].Split(':')[1]);
                    dataGridView1.Rows[i].Cells[1].Value = n;
                    dataGridView1.Rows[i].Cells[2].Value = Math.Round(n / (double)UserInfo.NumOfStu, 2) + "%";
                }
            }
            //解析分数
            if (rule.PointDetails != "")
            {
                string[] points = rule.PointDetails.Split(';');
                for (int i = 0; i < GradeLevels; i++)
                {
                    int p = int.Parse(points[i].Split(':')[1]);
                    dataGridView1.Rows[i].Cells[3].Value = p;
                }
            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            int result = 0;
            if (int.TryParse(value, out result))
            {
                if (e.ColumnIndex == 1)
                {
                    if (UserInfo.NumOfStu - readeyNum < result)
                    {
                        MessageBox.Show("剩余人数为" + (UserInfo.NumOfStu - readeyNum) + ",小于设置人数");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = resetValue;
                        readeyNum += int.Parse(resetValue);
                        return;
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = Math.Round(result / (double)UserInfo.NumOfStu * 100, 2) + "%";
                        readeyNum += result;
                        ReadyLabel.Text = readeyNum.ToString();
                        return;
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    if (result < 0 || result > 100)
                    {
                        MessageBox.Show("不是正确的得分范围");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = resetValue;
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("只能为整数");
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = resetValue;
                if (e.ColumnIndex == 1)
                    readeyNum += int.Parse(resetValue);
                return;
            }
        }

        /// <summary>
        /// 验证数字输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            resetValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            if (e.ColumnIndex == 1)
            {
                if (resetValue == null)//初始的时候
                    resetValue = "0";
                readeyNum -= int.Parse(resetValue);
            }
        }
    }
}
