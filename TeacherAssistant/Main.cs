using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TeacherAssistant_BLL;
using TeacherAssistant_Model;

namespace TeacherAssistant
{
    public partial class Main : Form
    {
        private bool ExistImpress = false;                                              //是否已经存在印象分一栏
        private Dictionary<string, int> Grade_Num = new Dictionary<string, int>();      //等级人数
        private double oldImpress;                                                      //原印象分        

        public Main()
        {
            InitializeComponent();
            ShowLabels();
            InitlGradeNum();
            ShowDataGridView();
            ShowGradeNum();
        }

        private void InitlGradeNum()
        {
            switch (UserInfo.Type)
            {
                case 5:
                    foreach (var i in GradeList.gradesFive)
                        Grade_Num.Add(i, 0);
                    break;
                case 10:
                    foreach (var i in GradeList.gradesTen)
                        Grade_Num.Add(i, 0);
                    break;
                default:
                    break;
            }
        }

        private void AddAssessColumn(string text, int sType)
        {
            if (sType == (int)ScoreType.Percentage)
            {
                DataGridViewTextBoxColumn textColumnn = new DataGridViewTextBoxColumn();
                textColumnn.ReadOnly = false;
                textColumnn.HeaderText = text;
                textColumnn.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView1.Columns.Add(textColumnn);
            }
            else
            {
                DataGridViewComboBoxColumn comoboColumn = new DataGridViewComboBoxColumn();
                comoboColumn.ReadOnly = false;
                comoboColumn.HeaderText = text;
                if (sType == (int)ScoreType.PorF)
                    comoboColumn.Items.AddRange(GradeList.gradesPorF);
                else if (sType == (int)ScoreType.FiveLevel)
                    comoboColumn.Items.AddRange(GradeList.gradesFive);
                else if (sType == (int)ScoreType.TenLevel)
                    comoboColumn.Items.AddRange(GradeList.gradesTen);
                comoboColumn.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                comoboColumn.FlatStyle = FlatStyle.Flat;

                dataGridView1.Columns.Add(comoboColumn);
            }
        }

        private void ShowDataGridView()
        {
            //重载之前消除一切
            dataGridView1.Rows.Clear();
            var end = dataGridView1.Columns.Count;
            //从后向前
            for (int i = end - 1; i > 5; i--)
                dataGridView1.Columns.Remove(dataGridView1.Columns[i]);

            //显示具体得分情况
            var listScore = ScoreManager.GetScores(UserInfo.CourseNo, UserInfo.Semester);
            if (listScore.Count != 0)
            {
                UserInfo.NumOfStu = listScore.Count;
                //多少考核方式
                var detailString = listScore[0].AssessDetails;
                string[] details = detailString.Split(';');
                //减去最后一个空的
                int colCount = details.Length - 1;
                for (int i = 0; i < colCount; i++)
                {
                    //dUnit[0]就是名称
                    var dUnit = details[i].Split(':');
                    //根据名称获取考核项
                    var assess = TeachManager.GetCourseAssessByName(UserInfo.CourseNo, UserInfo.Semester, dUnit[0]);
                    AddAssessColumn(dUnit[0].Substring(1, dUnit[0].Length - 1), assess.ScoreType);
                }
                //已经存在印象分就继续显示出来
                if (ExistImpress == true)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.HeaderText = "印象分";
                    column.ReadOnly = false;
                    dataGridView1.Columns.Add(column);
                }
                //显示数据
                foreach (var score in listScore)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = index;
                    dataGridView1.Rows[index].Cells[1].Value = score.Auto == true ? "自动" : "手动";
                    dataGridView1.Rows[index].Cells[2].Value = score.StuNo;
                    dataGridView1.Rows[index].Cells[3].Value = score.StuName;
                    dataGridView1.Rows[index].Cells[4].Value = score.FinalScore;
                    dataGridView1.Rows[index].Cells[5].Value = score.Grade;
                    if (!string.IsNullOrEmpty(score.Grade))
                    {
                        Grade_Num[score.Grade]++;
                    }
                    detailString = score.AssessDetails;
                    details = detailString.Split(';');
                    for (int i = 0; i < colCount; i++)
                    {
                        //dUnit[1]就是得分
                        var dUnit = details[i].Split(':');
                        dataGridView1.Rows[index].Cells[6 + i].Value = dUnit[1];
                    }
                    if (ExistImpress == true)
                        dataGridView1.Rows[index].Cells[6 + colCount].Value = score.ImpressPoints;

                }

            }
        }

        private void ShowLabels()
        {
            Course c = CourseManager.GetCourseByCourseNo(UserInfo.CourseNo);
            Teach t = TeachManager.GetTeachInfo(UserInfo.CourseNo, UserInfo.TeacherNo, UserInfo.Semester);
            Exam e = TeachManager.GetExamByExamNo(t.ExamNo);

            ExamNoLabel.Text = e.ExamNo;
            CourseNameLabel.Text = c.CourseName;
            CourseNoLabel.Text = c.CourseNo;
            SemesterLabel.Text = UserInfo.Semester;
            CreditLabel.Text = t.Credit.ToString();
            CourseTypeLabel.Text = c.Type.ToString();
            RuleLabel.Text = t.RuleNo.ToString();
            TeacherNameLable.Text = UserInfo.TeacherName;
            ExamTimeLabel.Text = e.ExamTime.ToString();
            switch (c.Type)
            {
                case CourseType.本科课程:
                    GradeLabel.Text = "十分制";
                    UserInfo.Type = 10;
                    UserInfo.CType = CourseType.本科课程;
                    ((DataGridViewComboBoxColumn)dataGridView1.Columns[5]).Items.AddRange(GradeList.gradesTen);
                    break;
                case CourseType.MBA课程:
                    UserInfo.Type = 5;
                    GradeLabel.Text = "五分制";
                    UserInfo.CType = CourseType.MBA课程;
                    ((DataGridViewComboBoxColumn)dataGridView1.Columns[5]).Items.AddRange(GradeList.gradesFive);
                    break;
                case CourseType.研究生课程:
                    UserInfo.Type = 5;
                    UserInfo.CType = CourseType.研究生课程;
                    ((DataGridViewComboBoxColumn)dataGridView1.Columns[5]).Items.AddRange(GradeList.gradesFive);
                    GradeLabel.Text = "五分制";
                    break;
                default:
                    MessageBox.Show("不存在该类型的课程");
                    break;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            var obey = CheckRule();
            if (obey == false)
            {
                if (MessageBox.Show("目前给定的成绩与学校规则相违背，确定离开吗", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (this.Visible == true)
                    {
                        this.Hide();
                        Application.Exit();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (this.Visible == true)
                {
                    this.Hide();
                    Application.Exit();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择学生excel文件";
            ofd.Filter = "excel文件|*.xls|excel文件|*.xlsx";
            ofd.FileOk += Ofd_FileOk;
            ofd.ShowDialog();


        }

        private void Ofd_FileOk(object sender, CancelEventArgs e)
        {
            var ofd = (OpenFileDialog)sender;
            var filePath = ofd.FileName;
            using (FileStream fs = File.Open(filePath, FileMode.Open,
FileAccess.Read, FileShare.ReadWrite))
            {
                HSSFWorkbook wk = new HSSFWorkbook(fs);   //把xls文件中的数据写入wk中
                var sheet = wk.GetSheetAt(0);             //读取第一个sheet

                #region ProgressBar
                Form a = new Form();
                ProgressBar bar = new ProgressBar();
                bar.Value = 0;
                bar.Minimum = 0;
                bar.Maximum = sheet.LastRowNum - 3;
                bar.Location = new System.Drawing.Point(50, 10);
                bar.Width = 200;
                bar.Parent = a;
                a.Text = "导入学生数据";
                a.Width = 300;
                a.Height = 100;
                a.StartPosition = FormStartPosition.CenterScreen;
                a.Show();
                a.TopMost = true;
                bar.Show();
                #endregion

                for (int j = 4; j <= sheet.LastRowNum; j++)  //从第五行开始是学生数据格式为“学号/姓名(专业)”
                {
                    IRow row = sheet.GetRow(j);  //读取当前行数据
                    if (row != null)
                    {
                        ICell cell = row.GetCell(0);
                        string s = cell.ToString();
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            int pos1 = s.IndexOf('/');
                            int pos2 = s.IndexOf('(');
                            int pos3 = s.IndexOf(')');
                            string stuNo = s.Substring(0, pos1);
                            string stuName = s.Substring(pos1 + 1, pos2 - pos1 - 1);
                            string major = s.Substring(pos2 + 1, pos3 - pos2 - 1);
                            StuManager.ImportStu(stuNo, stuName, major);
                            ScoreManager.ImportStuScore(UserInfo.CourseNo, stuNo, UserInfo.Semester);
                        }
                    }
                    bar.Value += 1;
                    bar.Refresh();
                }

                if (MessageBox.Show("导入完成", "Confirm Message", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    a.Close();
                }
                ShowDataGridView();
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (UserInfo.NumOfStu == 0)
            {
                MessageBox.Show("尚未导入学生数据");
                return;
            }
            Assessment assm = new Assessment();
            assm.ShowDialog();
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            ShowDataGridView();
            MessageBox.Show("重载完毕");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "印象分")
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value != null)
                {
                    double impress = 0.0;
                    if (double.TryParse(value.ToString(), out impress))
                    {
                        if (impress == oldImpress)
                            return;
                        if (impress > 5 || impress < 0)
                        {
                            MessageBox.Show("印象分应该在0-5之间");
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldImpress;
                            return;
                        }

                        double originPoint = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                        double newPoint = Math.Round(originPoint + impress - oldImpress, 2);
                        if (newPoint > 100)
                        {
                            MessageBox.Show("总分超过100了");
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldImpress;
                            return;
                        }
                        //将新的总分和印象分写入数据库
                        string cNo = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        ScoreManager.AddImpress(cNo, UserInfo.CourseNo, UserInfo.Semester, impress, newPoint);
                        //更新显示
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = newPoint;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("只能输入数字");
                        return;
                    }
                }
            }
            else if (e.ColumnIndex != 5)//修改考核得分
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value != null)
                {
                    string point = value.ToString();
                    string sNo = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string aName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = ScoreManager.UpdateAssessScoreForStu(UserInfo.CourseNo, UserInfo.Semester, sNo, aName, point);

                }
            }
            else//手动修改成绩
            {
                var grade = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var sNo = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                ScoreManager.ManualUpdateGrade(UserInfo.CourseNo, UserInfo.Semester, sNo, grade);
                Grade_Num[grade]++;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (UserInfo.NumOfStu == 0)
            {
                MessageBox.Show("尚未导入学生数据");
                return;
            }
            CourseRule rule = new CourseRule();
            rule.ShowDialog();
        }

        private void AutoGradeLabel_Click(object sender, EventArgs e)
        {
            //先判断有没有规则
            if (!RuleManager.ExistRule(UserInfo.CourseNo, UserInfo.Semester))
            {
                MessageBox.Show("尚未存在规则");
            }
            else
            {
                //将原来存的等级：人数清空
                Grade_Num.Clear();
                //对应等级
                string[] gradeList;
                if (UserInfo.Type == 5)
                    gradeList = GradeList.gradesFive;
                else
                    gradeList = GradeList.gradesTen;
                Rule rule = RuleManager.GetRule(UserInfo.CourseNo, UserInfo.Semester);
                if (rule.RuleType == 1)//按照人数
                {
                    string[] nums = rule.NumDetails.Split(';');
                    List<int> amounts = new List<int>();
                    //记录各个等级人数
                    for (int i = 0; i < UserInfo.Type; i++)
                    {
                        int n = int.Parse(nums[i].Split(':')[1]);
                        amounts.Add(n);
                    }

                    //按照综合得分将每一个等级学生取出并赋予相应成绩
                    var listSNo = RuleManager.GetSNoByScoreDesc(UserInfo.Semester, UserInfo.CourseNo);
                    int beginIndex = 0, endIndex = 0;
                    for (int i = 0; i < UserInfo.Type; i++)
                    {
                        string grade = gradeList[i];//应得等级
                        int amount = amounts[i];//人数

                        //记录
                        Grade_Num.Add(grade, 0);

                        beginIndex += i == 0 ? 0 : amounts[i - 1];
                        endIndex = beginIndex + amount;
                        for (int j = beginIndex; j < endIndex; j++)
                        {
                            ScoreManager.UpdateGrade(UserInfo.CourseNo, UserInfo.Semester, listSNo[j], grade);
                        }
                    }
                }
                else    //按照得分
                {
                    string[] details = rule.PointDetails.Split(';');
                    List<int> points = new List<int>();
                    for (int i = 0; i < UserInfo.Type; i++)
                    {
                        int p = int.Parse(details[i].Split(':')[1]);
                        points.Add(p);
                    }
                    //按照得分段将每一个等级学生取出并赋予相应成绩
                    int highPoint = 0, lowPoint = 0;
                    for (int i = 0; i < UserInfo.Type; i++)
                    {
                        string grade = gradeList[i];//应得等级

                        highPoint = i == 0 ? 101 : points[i - 1];
                        lowPoint = i == UserInfo.Type - 1 ? -1 : points[i];
                        var listSNo = RuleManager.GetSNoByScoreLimit(UserInfo.CourseNo, UserInfo.Semester, lowPoint, highPoint);
                        //记录
                        Grade_Num.Add(grade, 0);
                        foreach (var sNo in listSNo)
                            ScoreManager.UpdateGrade(UserInfo.CourseNo, UserInfo.Semester, sNo, grade);
                    }
                }
                MessageBox.Show("设置成功，在提示可以继续操作之前请勿操作");
                //重载得分
                ShowDataGridView();
                //更改显示
                ShowGradeNum();
                //检测成绩是否符合学校规定
                CheckRule();
                //END
                //显示印象分一栏
                if (ExistImpress == false)
                {
                    ExistImpress = true;
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.HeaderText = "印象分";
                    column.ReadOnly = false;
                    int endIndex = dataGridView1.Columns.Add(column);
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                        row.Cells[endIndex].Value = ScoreManager.GetStuScore(UserInfo.CourseNo, row.Cells[2].Value.ToString(), UserInfo.Semester).ImpressPoints;
                }
                MessageBox.Show("可以继续操作");
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "印象分")
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (string.IsNullOrWhiteSpace(value))
                    oldImpress = 0.0;
                else
                    oldImpress = double.Parse(value);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "成绩")
            {
                var grade = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Grade_Num[grade]--;
            }
        }

        private void ShowGradeNum()
        {
            dataGridView2.Rows.Clear();
            foreach (var i in Grade_Num)
            {
                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = i.Key;
                dataGridView2.Rows[index].Cells[1].Value = i.Value;
            }
        }

        /// <summary>
        /// 导出到excel   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("无数据！");
                return;
            }
            //设置对象
            HSSFWorkbook wk = new HSSFWorkbook();
            HSSFSheet st = (HSSFSheet)wk.CreateSheet("Weight");
            //设置字体等
            HSSFCellStyle style = (HSSFCellStyle)wk.CreateCellStyle();
            HSSFFont font = (HSSFFont)wk.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 16;
            style.SetFont(font);
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center; //居中对齐
            //添加表头
            HSSFRow dataRow = (HSSFRow)st.CreateRow(0);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataRow.CreateCell(i).SetCellValue(dataGridView1.Columns[i].HeaderText);
                dataRow.GetCell(i).CellStyle = style;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataRow = (HSSFRow)st.CreateRow(i + 1);
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    string Value = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    dataRow.CreateCell(j).SetCellValue(Value);
                }
            }
            //自适应列宽度
            for (int i = 0; i < dataGridView1.Rows.Count + 1; i++)
            {
                st.AutoSizeColumn(i);
            }
            string saveFileName = string.Empty;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = "成绩.xls";
            MemoryStream ms = new MemoryStream();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                saveFileName = saveDialog.FileName;
                wk.Write(ms);
                FileStream file = new FileStream(saveFileName, FileMode.Create);
                wk.Write(file);
                file.Close();
                wk = null;
                ms.Close();
                ms.Dispose();
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
            }
        }

        private void ReportLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report rt = new Report(Grade_Num);
            rt.ShowDialog();
        }

        private bool CheckRule()
        {
            double pro = 0.0;
            bool result = true;
            switch (UserInfo.CType)
            {
                case CourseType.本科课程:
                    //A和A-不能超过30%
                    pro = (Grade_Num["A"] + Grade_Num["A-"]) / (double)UserInfo.NumOfStu;
                    if (pro > GradeLimit.AofU)
                    {
                        MessageBox.Show(GradeLimit.AofU_AlertMs);
                        result = false;
                    }
                    break;
                case CourseType.MBA课程:
                    pro = Grade_Num["A"] / (double)UserInfo.NumOfStu;
                    if (pro > GradeLimit.AofMBA)
                    {
                        MessageBox.Show(GradeLimit.AofMBA_AlertMs);
                        result = false;
                    }
                    if (Grade_Num["D"] + Grade_Num["F"] < GradeLimit.LowofMBA)
                    {
                        MessageBox.Show(GradeLimit.LowofMBA_AlertMs);
                        result = false;
                    }
                    break;
                case CourseType.研究生课程:
                    pro = Grade_Num["A"] / (double)UserInfo.NumOfStu;
                    if (pro > GradeLimit.AofP)
                    {
                        MessageBox.Show(GradeLimit.AofP_AlertMs);
                        result = false;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
