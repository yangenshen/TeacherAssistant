using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAssistant_Model
{
    public class Rule
    {
        public int RuleNo { get; set; }
        public string CourseNo { get; set; }
        public string Semester { get; set; }
        public int Version { get; set; }
        public string NumDetails { get; set; }
        public int RuleType { get; set; }
        public string PointDetails { get; set; }
        public string Description { get; set; }
    }
}
