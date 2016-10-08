using System;
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

    }
}
