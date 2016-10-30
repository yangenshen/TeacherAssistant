using System;
using System.Windows.Forms;
using TeacherAssistant_Model;
using TeacherAssistant_BLL;

namespace TeacherAssistant
{
    public partial class CourseRule : Form
    {

        private int GradeLevels;            //成绩分等级数
        private string resetValue = string.Empty;   //修改之前的人数值
        private int readyNum;              //已经分配的人数
        private bool newRule = false;       //是否新建的规则
        private int oldType;                //原来的依据原则 1代表根据人数/比例，2代表根据得分

        public CourseRule()
        {
            InitializeComponent();
            ShowDetails();
        }

        private void ShowDetails()
        {
            //如果还未存在，则新建一个
            if (!RuleManager.ExistRule(UserInfo.CourseNo, UserInfo.Semester))
            {
                RuleManager.CreateRule(UserInfo.CourseNo, UserInfo.Semester);
                newRule = true;
            }
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
            oldType = rule.RuleType;

            //解析人数 A:3;B:4;C:5...
            if (rule.NumDetails != "")
            {
                string[] nums = rule.NumDetails.Split(';');
                double upperTol = 0.0;
                for (int i = 0; i < GradeLevels; i++)
                {
                    int n = int.Parse(nums[i].Split(':')[1]);
                    dataGridView1.Rows[i].Cells[1].Value = n;
                    readyNum += n;
                    double prop = Math.Round(n / (double)UserInfo.NumOfStu * 100, 2);
                    dataGridView1.Rows[i].Cells[2].Value = prop + "%";
                    upperTol += prop;
                    dataGridView1.Rows[i].Cells[4].Value = upperTol + "%";
                    dataGridView1.Rows[i].Cells[5].Value = (100 - prop) + "%";
                }
            }
            else
            {
                readyNum = 0;
                for (int i = 0; i < GradeLevels; i++)
                    dataGridView1.Rows[i].Cells[1].Value = 0;
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
            else
            {
                for (int i = 0; i < GradeLevels; i++)
                    dataGridView1.Rows[i].Cells[2].Value = "0.00%";
            }

            RuleNoLabel.Text = rule.RuleNo.ToString();
            VersionLabel.Text = rule.Version.ToString();
            DescriptionLabel.Text = rule.Description;
            TotalNumLabel.Text = UserInfo.NumOfStu.ToString();
            ReadyLabel.Text = readyNum.ToString();
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
                    if (UserInfo.NumOfStu - readyNum < result)
                    {
                        MessageBox.Show("剩余人数为" + (UserInfo.NumOfStu - readyNum) + ",小于设置人数");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = resetValue;
                        readyNum += int.Parse(resetValue);
                        return;
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = Math.Round(result / (double)UserInfo.NumOfStu * 100, 2) + "%";
                        readyNum += result;
                        ReadyLabel.Text = readyNum.ToString();
                        RefreshUpperAndLower();
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
                    readyNum += int.Parse(resetValue);
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
                readyNum -= int.Parse(resetValue);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int newTyep;
            if (radioButton1.Checked)       //按照人数来
            {
                newTyep = 1;
                if (readyNum != UserInfo.NumOfStu)
                {
                    MessageBox.Show("请将人数全部安排");
                    return;
                }
                string numDetails = string.Empty;
                for (int i = 0; i < GradeLevels; i++)
                    numDetails += dataGridView1.Rows[i].Cells[0].Value.ToString() + ":" + dataGridView1.Rows[i].Cells[1].Value.ToString() + ";";
                //更新数据库
                RuleManager.UpdateRule(UserInfo.CourseNo, UserInfo.Semester, numDetails, 0);
            }
            else                            //按照得分来
            {
                newTyep = 2;
                for (int i = 0; i < GradeLevels; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value == null)
                    {
                        MessageBox.Show("得分下限不能为空");
                        return;
                    }
                }
                int pre = int.Parse(dataGridView1.Rows[0].Cells[3].Value.ToString());
                int now = 0;
                for (int i = 1; i < GradeLevels; i++)
                {
                    now = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    if (pre <= now)
                    {
                        MessageBox.Show("高等级的得分下限要比低等级的高");
                        return;
                    }
                    pre = now;
                }
                string pointDetails = string.Empty;
                for (int i = 0; i < GradeLevels; i++)
                    pointDetails += dataGridView1.Rows[i].Cells[0].Value.ToString() + ":" + dataGridView1.Rows[i].Cells[3].Value.ToString() + ";";
                //更新数据库
                RuleManager.UpdateRule(UserInfo.CourseNo, UserInfo.Semester, pointDetails, 1);
            }
            if (newRule == false)
            {
                int newVersion = int.Parse(VersionLabel.Text.ToString()) + 1;
                RuleManager.UpdateRule(UserInfo.CourseNo, UserInfo.Semester, newVersion.ToString(), 2);
            }
            if (oldType != newTyep)
            {
                RuleManager.UpdateRule(UserInfo.CourseNo, UserInfo.Semester, newTyep.ToString(), 3);
            }
            MessageBox.Show("更新完成");
        }

        private void RefreshUpperAndLower()
        {
            for (int i = 0; i < GradeLevels; i++)
            {
                int upperNum = 0;
                int lowerNum = 0;
                for (int j = 0; j <= i; j++)
                    upperNum += int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString());
                for (int j = i + 1; j < GradeLevels; j++)
                    lowerNum += int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString());
                dataGridView1.Rows[i].Cells[4].Value = Math.Round(upperNum / (double)UserInfo.NumOfStu * 100, 2) + "%";
                dataGridView1.Rows[i].Cells[5].Value = Math.Round(lowerNum / (double)UserInfo.NumOfStu * 100, 2) + "%";
            }
        }
    }
}
