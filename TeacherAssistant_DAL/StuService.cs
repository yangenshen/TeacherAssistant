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
        public static bool ImportStu(string sNo,string sName,string major)
        {
            string sql = string.Format("insert into Stu values('{0}','{1}','{2}')", sNo, sName, major);
            DBHelper.ExecuteNonQuery(sql);
            sql = string.Format("insert into StuScore(StuNo,CourseId) values('{0}',{1})", sNo, UserInfo.CourseId);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
