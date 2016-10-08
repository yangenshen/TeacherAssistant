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
        public static List<Course> GetTeachCourses(string tNo, string sem)
        {
            List<Course> listC = new List<Course>();
            string sql = string.Format("select T.CourseNo,CourseName from Course as C,Teach as T where T.CourseNo = C.CourseNo and T.Semester = '{0}' and T.TeacherNo = '{1}'", sem, tNo);
            DataTable dt = DBHelper.GetDataTable(sql);
            foreach (DataRow dtRow in dt.Rows)
            {
                Course c = new Course();
                c.CourseNo = dtRow["CourseNo"].ToString();
                c.CourseName = dtRow["CourseName"].ToString();
                listC.Add(c);
            }
            return listC;
        }

        public static Course GetCourseByCourseNo(string cNo)
        {
            string sql = string.Format("select * from Course where CourseNo = '{0}'", cNo);
            DataTable dt = DBHelper.GetDataTable(sql);
            Course c = new Course();
            if (dt != null && dt.Rows.Count == 1)
            {
                c.CourseNo = dt.Rows[0]["CourseNo"].ToString();
                c.CourseName = dt.Rows[0]["CourseName"].ToString();
                c.Type = (CourseType)int.Parse(dt.Rows[0]["CourseType"].ToString());
            }
            return c;
        }
    }
}
