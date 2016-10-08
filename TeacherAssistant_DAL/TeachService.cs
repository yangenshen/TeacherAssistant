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

        public static Teach GetTeachInfo(string cNo,string tNo,string sem)
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
    }
}
