using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TeacherAssistant_BLL;
using TeacherAssistant_Model;

namespace TeacherAssistant
{
    public partial class Assessment : Form
    {

        private string resetProp = string.Empty;    //改变比例时记录改变前数值

        public Assessment()
        {
            InitializeComponent();
            GetAssessments();
            GetScoreMethods();
            DisplayAssessments();
            ScoreMethods_SelectedIndexChanged(ScoreMethods, new EventArgs());
        }

        private void DisplayAssessments()
        {
            List<CourseAssess> listCA = TeachManager.GetCoureseAssessments(UserInfo.CourseNo, UserInfo.Semester);
            foreach (var ca in listCA)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = ca.AssessName;
                dataGridView1.Rows[index].Cells[1].Value = ca.Prop;
                dataGridView1.Rows[index].Cells[2].Value = (AssessType)ca.AssessType;
                //计算平均值
                dataGridView1.Rows[index].Cells[3].Value = ScoreManager.CalcuAssessAverage(ca);
            }
        }

        private DataGridViewCell AddChangePropButton()
        {
            throw new NotImplementedException();
        }

        private void GetScoreMethods()
        {
            ScoreMethods.DataSource = TeachManager.GetScoreMethods();
            ScoreMethods.ValueMember = "ScoreType";
            ScoreMethods.DisplayMember = "ScoreName";
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
            if (ValidateAllTextBoxValue())
            {
                string aName = AssessName.Text;
                int aType = int.Parse(Assessments.SelectedValue.ToString());

                //判断是否已经存在同名考核
                if (!TeachManager.ExistAssess(UserInfo.CourseNo, UserInfo.Semester, aName))
                {
                    //如果考核方式对应的给分形式不是百分制，将"等级:对应百分制分数"储存成一个长字符串,等级之间用分号隔开
                    string type = ScoreMethods.SelectedValue.ToString();
                    string pointDetails = string.Empty;
                    string defalutPoint = DefaultPoint.Text;
                    if (type != "2")
                    {
                        defalutPoint = DefaultGrade.SelectedItem.ToString();
                        if (type == "1")
                        {
                            pointDetails += "P:" + PTextBox.Text + ";F:" + FTextBox.Text + ";";
                        }
                        else if (type == "3")
                        {
                            pointDetails += "A:" + ATextBox.Text + ";B:" + BTextBox.Text + ";C:" + CTextBox.Text + ";D:" + DTextBox.Text + ";F:" + FTextBox.Text + ";";
                        }
                        else if (type == "4")
                        {
                            pointDetails += "A:" + ATextBox.Text + ";A-:" + AmTextBox.Text + ";B+:" + BpTextBox.Text + ";B:" + BTextBox.Text +
                                            ";B-:" + BmTextBox.Text + "C+:" + CpTextBox.Text + ";C:" + CTextBox.Text + ";C-:" + CmTextBox.Text +
                                            ";D:" + DTextBox.Text + ";F:" + FTextBox.Text + ";";
                        }
                    }
                    int sType = int.Parse(type);
                    TeachManager.AddAssess(aName, aType, sType, defalutPoint, UserInfo.CourseNo, UserInfo.Semester, pointDetails);
                    ScoreManager.AddAssessForStu(UserInfo.CourseNo, UserInfo.Semester, aName, defalutPoint);
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = aName;
                    dataGridView1.Rows[index].Cells[1].Value = 0;
                    dataGridView1.Rows[index].Cells[2].Value = (AssessType)aType;
                    dataGridView1.Rows[index].Cells[3].Value = defalutPoint;
                }
                else
                {
                    MessageBox.Show("已存在同一名称的考核项");
                }
            }
        }

        /// <summary>
        /// 判断值大小是否为空,是否大于100
        /// </summary>
        private bool ValidateAllTextBoxValue()
        {
            //判断考核名称
            if (AssessName.Text == "")
            {
                MessageBox.Show("考核名称不可为空");
                return false;
            }
            if (AssessName.Text.ToString().IndexOf('#') != -1)
            {
                MessageBox.Show("考核名称不能包含保留字符‘#’");
                return false;
            }
            //判断默认得分和各个等级对应得分
            string type = ScoreMethods.SelectedValue.ToString();
            if (type == "2")
            {
                if (DefaultPoint.Text == "")
                {
                    MessageBox.Show("默认得分不可为空");
                    return false;
                }
                if (int.Parse(DefaultPoint.Text) > 100)
                {
                    MessageBox.Show("默认得分不可大于100");
                    return false;
                }
            }
            else if (type == "1")
            {
                if (PTextBox.Text == "" || FTextBox.Text == "")
                {
                    MessageBox.Show("对应得分不可为空");
                    return false;
                }
                if (int.Parse(PTextBox.Text) > 100)
                {
                    MessageBox.Show("P的对应得分不可大于100");
                    return false;
                }
            }
            else if (type == "3")
            {
                if (ATextBox.Text == "" || BTextBox.Text == "" ||
                    CTextBox.Text == "" || DTextBox.Text == "" ||
                    FTextBox.Text == "")
                {
                    MessageBox.Show("对应得分不可为空");
                    return false;
                }
                if (int.Parse(ATextBox.Text) > 100)
                {
                    MessageBox.Show("A的对应得分不可大于100");
                    return false;
                }
            }
            else if (type == "4")
            {
                if (ATextBox.Text == "" || AmTextBox.Text == "" ||
                    BTextBox.Text == "" || BpTextBox.Text == "" ||
                    CTextBox.Text == "" || BmTextBox.Text == "" ||
                    DTextBox.Text == "" || CpTextBox.Text == "" ||
                    FTextBox.Text == "" || CmTextBox.Text == "")
                {
                    MessageBox.Show("对应得分不可为空");
                    return false;
                }
                if (int.Parse(ATextBox.Text) > 100)
                {
                    MessageBox.Show("A的对应得分不可大于100");
                    return false;
                }
            }
            return true;
        }

        private void ScoreMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = ScoreMethods.SelectedValue.ToString();
            if (type != "2")//不是百分计
            {
                DefaultPoint.Hide();
                DefaultGrade.Items.Clear();
                DefaultGrade.Show();
                if (type == "1")
                {

                    DefaultGrade.Items.AddRange(GradeList.gradesPorF);
                    //show
                    PLabel.Show(); PTextBox.Text = ""; PTextBox.Show();
                    FLabel.Show(); FTextBox.Text = ""; FTextBox.Show();
                    //hide
                    ALabel.Hide(); ATextBox.Hide();
                    AmLabel.Hide(); AmTextBox.Hide();
                    BpLabel.Hide(); BpTextBox.Hide();
                    BLabel.Hide(); BTextBox.Hide();
                    BmLabel.Hide(); BmTextBox.Hide();
                    CpLabel.Hide(); CpTextBox.Hide();
                    CLabel.Hide(); CTextBox.Hide();
                    CmLabel.Hide(); CmTextBox.Hide();
                    DLabel.Hide(); DTextBox.Hide();
                }
                else if (type == "3")
                {
                    
                    DefaultGrade.Items.AddRange(GradeList.gradesFive);
                    //show
                    ALabel.Show(); ATextBox.Text = ""; ATextBox.Show();
                    BLabel.Show(); BTextBox.Text = ""; BTextBox.Show();
                    CLabel.Show(); CTextBox.Text = ""; CTextBox.Show();
                    DLabel.Show(); DTextBox.Text = ""; DTextBox.Show();
                    FLabel.Show(); FTextBox.Text = ""; FTextBox.Show();
                    //hide
                    AmLabel.Hide(); AmTextBox.Hide();
                    BpLabel.Hide(); BpTextBox.Hide();
                    BmLabel.Hide(); BmTextBox.Hide();
                    CpLabel.Hide(); CpTextBox.Hide();
                    CmLabel.Hide(); CmTextBox.Hide();
                    PLabel.Hide(); PTextBox.Hide();
                }
                else if (type == "4")
                {
                    
                    DefaultGrade.Items.AddRange(GradeList.gradesTen);
                    //show
                    ALabel.Show(); ATextBox.Text = ""; ATextBox.Show();
                    BLabel.Show(); BTextBox.Text = ""; BTextBox.Show();
                    CLabel.Show(); CTextBox.Text = ""; CTextBox.Show();
                    DLabel.Show(); DTextBox.Text = ""; DTextBox.Show();
                    FLabel.Show(); FTextBox.Text = ""; FTextBox.Show();
                    AmLabel.Show(); AmTextBox.Text = ""; AmTextBox.Show();
                    BpLabel.Show(); BpTextBox.Text = ""; BpTextBox.Show();
                    BmLabel.Show(); BmTextBox.Text = ""; BmTextBox.Show();
                    CpLabel.Show(); CpTextBox.Text = ""; CpTextBox.Show();
                    CmLabel.Show(); CmTextBox.Text = ""; CmTextBox.Show();
                    //hide
                    PLabel.Hide(); PTextBox.Hide();
                }
                if (DefaultGrade.Items.Count != 0)
                    DefaultGrade.SelectedIndex = 0;
            }
            else
            {
                DefaultPoint.Show();
                DefaultGrade.Hide();
                //show

                //hide
                ALabel.Hide(); ATextBox.Hide();
                AmLabel.Hide(); AmTextBox.Hide();
                BpLabel.Hide(); BpTextBox.Hide();
                BLabel.Hide(); BTextBox.Hide();
                BmLabel.Hide(); BmTextBox.Hide();
                CpLabel.Hide(); CpTextBox.Hide();
                CLabel.Hide(); CTextBox.Hide();
                CmLabel.Hide(); CmTextBox.Hide();
                DLabel.Hide(); DTextBox.Hide();
                PLabel.Hide(); PTextBox.Hide();
                FLabel.Hide(); FTextBox.Hide();
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (value == resetProp)
                    return;
                int result = 0;
                if (int.TryParse(value, out result))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Index != e.RowIndex)
                            result += int.Parse(dataGridView1.Rows[row.Index].Cells[e.ColumnIndex].Value.ToString());
                    }
                    if (result > 100)
                    {
                        MessageBox.Show("比例超出限额" + (result - 100).ToString());
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = resetProp;
                        return;
                    }
                    //改变比例
                    if (TeachManager.UpdateAssessProp(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), int.Parse(value), UserInfo.CourseNo, UserInfo.Semester))
                    {
                        MessageBox.Show("调整比例成功！可在主页面重载得分");
                        //重新计算学生综合得分
                        ScoreManager.CalcuAllFinalScore(UserInfo.CourseNo, UserInfo.Semester);
                        
                    }
                    else
                    {
                        MessageBox.Show("调整比例失败！请稍后重试");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = resetProp;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("只能输入整数数字");
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = resetProp;
                    return;
                }

            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            resetProp = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
    }
}
