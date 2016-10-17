using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
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
        public Main()
        {
            InitializeComponent();
            ShowLabels();
            ShowDataGridView();
        }

        private void ShowDataGridView()
        {
            ///显示具体得分情况
            dataGridView1.Rows.Clear();
            var listScore = ScoreManager.GetScores(UserInfo.CourseNo, UserInfo.Semester);
            //多少考核方式
            var details = listScore[0].AssessDetails;
            string[] detailCol = details.Split(';');
            int cols = detailCol.Length - 1;
            for (int i = 0; i < cols; i++)
            {
                var assess = detailCol[i].Split(':');
                //DataGridViewComboBoxColumn
                //int col = dataGridView1.Columns.Add();
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
                    break;
                case CourseType.MBA课程:
                    GradeLabel.Text = "五分制";
                    break;
                case CourseType.研究生课程:
                    GradeLabel.Text = "五分制";
                    break;
                default:
                    MessageBox.Show("不存在该类型的课程");
                    break;
            }
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.Visible == true)
            {
                this.Hide();
                Application.Exit();
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
            Assessment assm = new Assessment();
            assm.ShowDialog();
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            ShowDataGridView();
        }
    }
}
