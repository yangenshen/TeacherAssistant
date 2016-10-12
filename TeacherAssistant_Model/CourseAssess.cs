﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAssistant_Model
{
    public class CourseAssess
    {
        public string CourseNo { get; set; }
        public string Semster { get; set; }
        public string AssessName { get; set; }
        public int AssessType { get; set; }
        public float Prop { get; set; }
        public string DefaultPoint { get; set; }
        public string PointDetails { get; set; }
    }
}
