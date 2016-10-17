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
                    ScoreService.UpdateAssessForStu(ss.StuNo, cNo, sem, newDetails);
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

        public static double CalcuAssessAverage(CourseAssess ca)
        {
            // "#我:23;#的:F"
            ca.AssessName = "#" + ca.AssessName;
            var listSS = ScoreService.GetScores(ca.CourseNo, ca.Semster);

            double final = 0.0;
            int stuCount = listSS.Count;
            foreach (var ss in listSS)
            {
                var details = ss.AssessDetails;
                int index = details.IndexOf(ca.AssessName);
                if (index == -1)
                    return -1;
                var score = string.Empty;
                for (int i = index + ca.AssessName.Length + 1; details[i] != ';'; i++)
                {
                    score += details[i];
                }

                if (ca.ScoreType == (int)ScoreType.Percentage)
                {
                    final += double.Parse(score);
                }
                else
                {
                    int pos = ca.PointDetails.IndexOf(string.Format("{0}:", score));
                    if (pos == -1)
                        return -1;
                    string score2point = string.Empty;
                    for(int i = pos + score.Length + 1; ca.PointDetails[i] != ';'; i++)
                    {
                        score2point += ca.PointDetails[i];
                    }
                    final += double.Parse(score2point);
                }
            }
            return final / stuCount;
        }
    }
}
