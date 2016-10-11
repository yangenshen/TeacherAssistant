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

        public static bool AddAssessForStu(string cNo, string sem, string aName, float point)
        {
            string detail = string.Format("{0}:{1};", aName, point);
            var listSS = ScoreService.GetScores(cNo, sem);
            foreach (var ss in listSS)
            {
                string newDetails = ss.AssessDetails + detail;
                try
                {
                    ScoreService.AddAssessForStu(ss.StuNo, cNo, sem, newDetails);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ImportStuScore(string cNo, string sNo, string sem)
        {

            if (ScoreService.GetStuCourseScore(cNo, sNo, sem).Grade == null)
            {
                return ScoreService.ImportStuScore(sNo, cNo, sem);
            }
            return true;
        }
    }
}
