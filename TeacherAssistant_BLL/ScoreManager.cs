using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_Model;
using TeacherAssistant_DAL;
namespace TeacherAssistant_BLL
{
    public class ScoreManager
    {
        public static List<StuScore> GetScores(string cNo, string sem)
        {
            var listSS = ScoreService.GetScores(cNo, sem);
            foreach (var ss in listSS)
            {
                ss.StuName = StuService.GetStuByStuNo(ss.StuNo).StuName;
            }
            return listSS;
        }

        public static bool AddAssessForStu(string cNo, string sem, string aName, string point)
        {
            string detail = string.Format("#{0}:{1};", aName, point);
            var listSS = ScoreService.GetScores(cNo, sem);
            foreach (var ss in listSS)
            {
                string newDetails = ss.AssessDetails + detail;
                try
                {
                    ScoreService.UpdateAssessDetailForStu(ss.StuNo, cNo, sem, newDetails);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        public static double UpdateAssessScoreForStu(string cNo, string sem, string sNo, string aName, string point)
        {
            var ss = GetStuScore(cNo, sNo, sem);
            var details = ss.AssessDetails;
            var oldaName = "#" + aName;
            var newaName = string.Format("#{0}:{1}", aName, point);
            int index1 = details.IndexOf(oldaName);
            for (int i = index1 + aName.Length + 1; details[i] != ';'; i++)
                oldaName += ss.AssessDetails[i];
            details = details.Replace(oldaName, newaName);
            //更新details
            ScoreService.UpdateAssessDetailForStu(sNo, cNo, sem, details);
            //重新计算FinalScore
            //不必重新获取StuScore,改变一下原有的detail就行
            ss.AssessDetails = details;
            return CalcuFinalScore(cNo, sem, ss);
        }

        public static StuScore GetStuScore(string cNo, string sNo, string sem)
        {
            return ScoreService.GetStuCourseScore(cNo, sNo, sem);
        }

        public static bool ImportStuScore(string cNo, string sNo, string sem)
        {

            if (GetStuScore(cNo, sNo, sem).Grade == null)
            {
                return ScoreService.ImportStuScore(sNo, cNo, sem);
            }
            return true;
        }


        public static double CalcuAssessAverage(CourseAssess ca)
        {
            var listSS = ScoreService.GetScores(ca.CourseNo, ca.Semester);

            double final = 0.0;
            int stuCount = listSS.Count;
            foreach (var ss in listSS)
            {
                final += GetPoint(ca, ss);
            }
            //保留两位小数
            return Math.Round(final / stuCount, 2);
        }

        public static void CalcuAllFinalScore(string cNo, string sem)
        {
            //获取所有StuScore
            var listSS = ScoreService.GetScores(cNo, sem);

            foreach (var ss in listSS)
            {
                CalcuFinalScore(cNo, sem, ss);
            }
        }

        private static double GetPoint(CourseAssess ca, StuScore ss)
        {
            var details = ss.AssessDetails;
            int index = details.IndexOf("#" + ca.AssessName);
            if (index == -1)
                return -1;
            var score = string.Empty;
            for (int i = 1 + index + ca.AssessName.Length + 1; details[i] != ';'; i++)
            {
                score += details[i];
            }
            if (ca.ScoreType == (int)ScoreType.Percentage)
            {
                return double.Parse(score);
            }
            else
            {
                int pos = ca.PointDetails.IndexOf(string.Format("{0}:", score));
                if (pos == -1)
                    return -1;
                string score2point = string.Empty;
                for (int i = pos + score.Length + 1; ca.PointDetails[i] != ';'; i++)
                {
                    score2point += ca.PointDetails[i];
                }
                return double.Parse(score2point);
            }
        }

        public static double CalcuFinalScore(string cNo, string sem, StuScore ss)
        {
            //获取所有CourseAssess
            var listCA = TeachService.GetCoureseAssessments(cNo, sem);
            double finalScore = 0.0;
            //将所有CourseAssess换成point，再乘以prop
            foreach (var ca in listCA)
            {
                finalScore += (double)ca.Prop / 100 * GetPoint(ca, ss);
            }
            //更新数据库
            ScoreService.UpdateFinalScoreForStu(ss.StuNo, cNo, sem, finalScore);
            return finalScore;
        }


        public static bool AddImpress(string sNo, string cNo, string sem, double impress, double newPoint)
        {
            return ScoreService.AddImpress(sNo, cNo, sem, impress, newPoint);
        }

        public static bool UpdateGrade(string cNo, string sem, string sNo, string grade)
        {
            return ScoreService.UpdateGrade(cNo, sem, sNo, grade);
        }

        public static bool ManualUpdateGrade(string cNo, string sem, string sNo, string grade)
        {
            return ScoreService.ManualUpdateGrade(cNo, sem, sNo, grade);
        }
    }
}
