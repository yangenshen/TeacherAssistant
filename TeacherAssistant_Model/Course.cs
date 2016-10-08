using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAssistant_Model
{
    public class Course
    {
        public string CourseNo { get; set; }
        public string CourseName { get; set; }
        public CourseType Type { get; set; }        //课程类型：本科，MBA和硕士   
    }
}
