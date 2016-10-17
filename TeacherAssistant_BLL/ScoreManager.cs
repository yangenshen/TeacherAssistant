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

        public static double CalcuAssessAverage(CourseAssess ca)
        {
            var listSS = ScoreService.GetScores(ca.CourseNo, ca.Semester);

            double final = 0.0;
            int stuCount = listSS.Count;
            foreach (var ss in listSS)
            {
                final += GetPoint(ca, ss);
            }
            return final / stuCount;
        }

        public static void CalcuFinalScore(string cNo, string sem)
        {
            //获取所有CourseAssess
            var listCA = TeachService.GetCoureseAssessments(cNo, sem);
            //获取所有StuScore
            var listSS = ScoreService.GetScores(cNo, sem);
            //对于每一个StuScore,将所有ScoreAssess换成point，再乘以prop
            foreach (var ss in listSS)
            {
                double finalScore = 0.0;
                foreach (var ca in listCA)
                {
                    finalScore += (double)ca.Prop / 100 * GetPoint(ca, ss);
                }
                //更新数据库
                ScoreService.UpdateFinalScoreForStu(ss.StuNo, cNo, sem, finalScore);
            }
        }
    }
}
