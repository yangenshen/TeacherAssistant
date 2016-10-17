using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_Model;

namespace TeacherAssistant_DAL
{
    public class TeachService
    {
        public static Exam GetExamByExamNo(string eNo)
        {
            string sql = string.Format("select * from Exam where ExamNo = '{0}'", eNo);
            DataTable dt = DBHelper.GetDataTable(sql);
            Exam e = new Exam();
            if (dt != null && dt.Rows.Count == 1)
            {
                e.ExamNo = eNo;
                e.ExamTime = DateTime.Parse(dt.Rows[0]["ExamTime"].ToString());
            }
            return e;
        }

        public static List<string> GetSemesters(string tNo)
        {
            string sql = string.Format("select distinct(Semester) from Teach where TeacherNo = '{0}'", tNo);
            DataTable dt = DBHelper.GetDataTable(sql);
            List<string> listS = new List<string>();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    listS.Add(row[0].ToString());
                }
            }
            return listS;
        }

        public static List<ScoreMethod> GetScoreMethods()
        {
            string sql = string.Format("select * from ScoreMethod");
            DataTable dt = DBHelper.GetDataTable(sql);
            List<ScoreMethod> listS = new List<ScoreMethod>();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    listS.Add(new ScoreMethod()
                    {
                        ScoreType = int.Parse(row["ScoreType"].ToString()),
                        ScoreName = row["ScoreName"].ToString()
                    });
                }
            }
            return listS;
        }

        public static Teach GetTeachInfo(string cNo, string tNo, string sem)
        {
            string sql = string.Format("select * from Teach where CourseNo = '{0}' and TeacherNo = '{1}' and Semester = '{2}'", cNo, tNo, sem);
            DataTable dt = DBHelper.GetDataTable(sql);
            Teach t = new Teach();
            if (dt != null && dt.Rows.Count == 1)
            {
                t.CourseNo = cNo;
                t.Credit = int.Parse(dt.Rows[0]["Credit"].ToString());
                t.ExamNo = dt.Rows[0]["ExamNo"].ToString();
                t.RuleNo = dt.Rows[0]["RuleNo"].ToString();
                t.Semester = sem;
                t.TeacherNo = tNo;
            }
            return t;
        }

        #region Assess
        public static List<Assessment> GetAssessments()
        {
            string sql = string.Format("select * from Assessment");
            DataTable dt = DBHelper.GetDataTable(sql);
            List<Assessment> listA = new List<Assessment>();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    listA.Add(new Assessment()
                    {
                        AssessType = int.Parse(row["AssessType"].ToString()),
                        AssessName = row["AssessName"].ToString()
                    });
                }
            }
            return listA;
        }

        public static bool AddAssess(string aName, int aType, int sType, string point, string cNo, string sem, string pointDetails)
        {
            string sql = string.Format("insert into CourseAssess(AssessName,AssessType,DefaultPoint,CourseNo,Semester,PointDetails,ScoreType) values('{0}',{1},'{2}','{3}','{4}','{5}',{6})", aName, aType, point, cNo, sem, pointDetails, sType);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public static bool UpdateAssessProp(string aName, int aProp, string cNo, string sem)
        {
            string sql = string.Format("update CourseAssess set Prop = {0} where AssessName = '{1}' and CourseNo = '{2}' and Semster = '{3}'", aProp, aName, cNo, sem);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public static List<CourseAssess> GetCoureseAssessments(string cNo, string sem)
        {
            string sql = string.Format("select * from CourseAssess where CourseNo = '{0}' and Semester = '{1}'", cNo, sem);
            DataTable dt = DBHelper.GetDataTable(sql);
            List<CourseAssess> listCA = new List<CourseAssess>();
            if (dt.Rows != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CourseAssess ca = new CourseAssess();
                    ca.CourseNo = cNo;
                    ca.Semster = sem;
                    ca.AssessName = row["AssessName"].ToString();
                    ca.AssessType = int.Parse(row["AssessType"].ToString());
                    ca.Prop = int.Parse(row["Prop"].ToString());
                    ca.PointDetails = row["PointDetails"].ToString();
                    ca.ScoreType = int.Parse(row["ScoreType"].ToString());
                    listCA.Add(ca);
                }
            }
            return listCA;
        }

        public static CourseAssess GetCourseAssessByName(string cNo, string sem, string aName)
        {
            string sql = string.Format("select * from CourseAssess where CourseNo = '{0}' and Semester = '{1}' and AssessName = '{2}'", cNo, sem, aName);
            DataTable dt = DBHelper.GetDataTable(sql);
            CourseAssess ca = new CourseAssess();
            if (dt.Rows != null && dt.Rows.Count == 1)
            {
                ca.CourseNo = cNo;
                ca.Semster = sem;
                ca.AssessName = aName;
                ca.AssessType = int.Parse(dt.Rows[0]["AssessType"].ToString());
                ca.DefaultPoint = dt.Rows[0]["DefaultPoint"].ToString();
                ca.PointDetails = dt.Rows[0]["PointDetails"].ToString();
            }
            return ca;
        }
        #endregion
    }
}
