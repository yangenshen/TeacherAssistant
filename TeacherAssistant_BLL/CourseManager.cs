using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_DAL;
using TeacherAssistant_Model;

namespace TeacherAssistant_BLL
{
    public class CourseManager
    {
        public static List<Course> GetTeachCourses(string tNo,string sem)
        {
            var listC = CourseService.GetTeachCourses(tNo,sem);
            if (listC.Count == 0)
            {
                listC.Add(new Course { CourseNo = "-1", CourseName = "暂无课程信息" });
            }
            return listC;
        }

        

        public static Course GetCourseByCourseNo(string cNo)
        {
            return CourseService.GetCourseByCourseNo(cNo);
        }
    }
}
