using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_Model;
namespace TeacherAssistant_DAL
{
    public class StuService
    {
        public static bool ImportStu(string sNo, string sName, string major)
        {
            if (GetStuByStuNo(sNo).StuName == null)
            {
                string sql = string.Format("insert into Stu values('{0}','{1}','{2}')", sNo, sName, major);
                DBHelper.ExecuteNonQuery(sql);
            }
            if (ScoreService.GetStuCourseScore(UserInfo.CourseNo, sNo, UserInfo.Semester).Grade == null)
            {
                string sql = string.Format("insert into StuScore(StuNo,CourseNo,Semester) values('{0}','{1}','{2}')", sNo, UserInfo.CourseNo, UserInfo.Semester);
                return DBHelper.ExecuteNonQuery(sql);
            }
            return true;
        }

        public static Stu GetStuByStuNo(string sNo)
        {
            string sql = string.Format("select * from Stu where StuNo = '{0}'", sNo);
            DataTable dt = DBHelper.GetDataTable(sql);
            Stu s = new Stu();
            if (dt != null && dt.Rows.Count == 1)
            {
                s.StuNo = sNo;
                s.StuName = dt.Rows[0]["StuName"].ToString();
                s.Major = dt.Rows[0]["Major"].ToString();
            }
            return s;
        }
    }
}
