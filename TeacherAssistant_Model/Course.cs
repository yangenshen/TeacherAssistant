using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAssistant_Model
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseNo { get; set; }
        public string CourseName { get; set; }
        public string TeacherNo { get; set; }
        public string Semester { get; set; }        //格式：2016.上(下)
        public CourseType Type { get; set; }        //课程类型：本科，MBA和硕士
        public int Credit { get; set; }             //学分
        public string ExamNo { get; set; }          //考试编号
    }
}
