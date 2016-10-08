using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_Model;
namespace TeacherAssistant_DAL
{
    public class ScoreService
    {
        public static List<StuScore> GetScores(string cNo, string sem)
        {
            string sql = string.Format("select * from StuScore where CourseNo = '{0}' and Semester = '{1}'", cNo, sem);
            DataTable dt = DBHelper.GetDataTable(sql);
            List<StuScore> listScore = new List<StuScore>();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    StuScore score = new StuScore();
                    score.ID = int.Parse(row["ID"].ToString());
                    score.CourseNo = cNo;
                    score.Semester = sem;
                    score.Auto = (bool)row["Auto"];
                    var impressPoints = row["ImpressPoints"].ToString();
                    score.ImpressPoints = impressPoints == "" ? 0 : float.Parse(impressPoints);
                    var finalScore = row["FinalScore"].ToString();
                    score.FinalScore = finalScore == "" ? 0 : float.Parse(finalScore);
                    score.StuNo = row["StuNo"].ToString();
                    score.Grade = row["Grade"].ToString();
                    score.StuName = StuService.GetStuByStuNo(score.StuNo).StuName;
                    listScore.Add(score);
                }
            }
            return listScore;
        }

        public static StuScore GetStuCourseScore(string cNo, string sNo, string sem)
        {
            string sql = string.Format("select * from StuScore where CourseNo = '{0}' and StuNo = '{1}' and Semester = '{2}'", cNo, sNo, sem);
            DataTable dt = DBHelper.GetDataTable(sql);
            StuScore score = new StuScore();
            if (dt != null && dt.Rows.Count == 1)
            {
                score.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                score.CourseNo = cNo;
                score.Semester = sem;
                score.Auto = (bool)(dt.Rows[0]["Auto"]);
                var impressPoints = dt.Rows[0]["ImpressPoints"].ToString();
                score.ImpressPoints = impressPoints == "" ? 0 : float.Parse(impressPoints);
                var finalScore = dt.Rows[0]["FinalScore"].ToString();
                score.FinalScore = finalScore == "" ? 0 : float.Parse(finalScore);
                score.StuNo = sNo;
                score.Grade = dt.Rows[0]["Grade"].ToString();
                score.StuName = StuService.GetStuByStuNo(sNo).StuName;
            }
            return score;
        }
    }
}
