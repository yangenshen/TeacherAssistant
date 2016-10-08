using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAssistant_Model
{
    public class StuScore
    {
        public int ID { get; set; }
        public bool Auto { get; set; }
        public string StuNo { get; set; }
        public string StuName { get; set; }
        public string CourseNo { get; set; }
        public string Semester { get; set; }
        public float ImpressPoints { get; set; }
        public float FinalScore { get; set; }
        public string Grade { get; set; }
    }
}
