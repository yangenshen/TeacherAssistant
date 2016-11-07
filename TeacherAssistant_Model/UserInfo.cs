using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAssistant_Model
{
    public class UserInfo
    {
        public static string TeacherNo { get; set; }
        public static string TeacherName { get; set; }
        public static int Type { get; set; }            //成绩分等级数
        public static CourseType CType { get; set; }           //
        public static string Semester { get; set; }
        public static string CourseNo { get; set; }
        public static string CourseName { get; set; }
        public static int NumOfStu { get; set; }
    }
}
