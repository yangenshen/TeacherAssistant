﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_DAL;
using TeacherAssistant_Model;

namespace TeacherAssistant_BLL
{
    public class TeachManager
    {
        public static Exam GetExamByExamNo(string eNo)
        {
            return TeachService.GetExamByExamNo(eNo);
        }

        public static List<string> GetSemesters(string tNo)
        {
            return TeachService.GetSemesters(tNo);
        }

        public static Teach GetTeachInfo(string cNo, string tNo, string sem)
        {
            return TeachService.GetTeachInfo(cNo, tNo, sem);
        }

        public static List<Assessment> GetAssessments()
        {
            return TeachService.GetAssessments();
        }

        public static bool AddAssess(string aName, int aType, string point, string cNo, string sem, string pointDetails)
        {
            return TeachService.AddAssess(aName, aType, point, cNo, sem, pointDetails);
        }

        public static List<ScoreMethod> GetScoreMethods()
        {
            return TeachService.GetScoreMethods();
        }

        public CourseAssess GetCourseAssessByName(string cNo, string sem, string aName)
        {
            return TeachService.GetCourseAssessByName(cNo, sem, aName);
        }

        public static bool ExistAssess(string cNo, string sem, string aName)
        {
            if (TeachService.GetCourseAssessByName(cNo, sem, aName).DefaultPoint == null)
            {
                return false;
            }
            return true;
        }
    }
}
