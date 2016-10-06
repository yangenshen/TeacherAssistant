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
        public static IList<Course> GetCoursesByTeacher(string tNo)
        {
            var listC = CourseService.GetCoursesByTeacher(tNo);
            foreach (var c in listC)
            {
                c.CourseName += "-" + c.Semester;
            }
            if (listC.Count == 0)
            {
                listC.Add(new Course { CourseId = -1, CourseName = "暂无课程信息" });
            }
            else
            {
                listC.Add(new Course { CourseId = -1, CourseName = "请选择课程" });
            }
            return listC;
        }

        public static Course GetCoursesByCourseId(int cId)
        {
            return CourseService.GetCourseByCourseId(cId);
        }

        public static Exam GetExamByCourseId(int cId)
        {
            return CourseService.GetExamByCourseId(cId);
        }
    }
}
