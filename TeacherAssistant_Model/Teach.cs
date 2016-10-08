using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAssistant_Model
{
    public class Teach
    {
        public string CourseNo { get; set; }

        public string TeacherNo { get; set; }
        public string Semester { get; set; }        //格式：2016.上(下)
        public int Credit { get; set; }             //学分
        public string RuleNo { get; set; }
        public string ExamNo { get; set; }          //考试编号
    }
}
