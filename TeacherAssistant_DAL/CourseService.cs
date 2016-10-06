using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_Model;

namespace TeacherAssistant_DAL
{
    public class CourseService
    {
        public static IList<Course> GetCoursesByTeacher(string tNo)
        {
            List<Course> listC = new List<Course>();
            string sql = string.Format("select CourseId,CourseName,Semester from Course where TeacherNo = '{0}'", tNo);
            DataTable dt = DBHelper.GetDataTable(sql);
            foreach (DataRow dtRow in dt.Rows)
            {
                Course c = new Course();
                c.CourseId = int.Parse(dtRow["CourseId"].ToString());
                c.CourseName = dtRow["CourseName"].ToString();
                c.Semester = dtRow["Semester"].ToString();
                listC.Add(c);
            }
            return listC;
        }

        public static Course GetCourseByCourseId(int cId)
        {
            string sql = string.Format("select * from Course where CourseId = {0}", cId);
            DataTable dt = DBHelper.GetDataTable(sql);
            Course c = new Course();
            if (dt != null && dt.Rows.Count == 1)
            {
                c.Semester = dt.Rows[0]["Semester"].ToString();
                c.ExamNo = dt.Rows[0]["ExamNo"].ToString();
                c.Credit = int.Parse(dt.Rows[0]["Credit"].ToString());
                c.CourseNo = dt.Rows[0]["CourseNo"].ToString();
                c.CourseName = dt.Rows[0]["CourseName"].ToString();
                c.Type = (CourseType)int.Parse(dt.Rows[0]["CourseType"].ToString());
            }
            return c;
        }

        public static Exam GetExamByCourseId(int cId)
        {
            string sql = string.Format("select * from Exam where CourseId = {0}", cId);
            DataTable dt = DBHelper.GetDataTable(sql);
            Exam e = new Exam();
            if (dt != null && dt.Rows.Count == 1)
            {
                e.ExamNo = dt.Rows[0]["ExamNo"].ToString();
                e.ExamTime = DateTime.Parse(dt.Rows[0]["ExamTime"].ToString());
            }
            return e;
        }
    }
}
