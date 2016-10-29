using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_DAL;
using TeacherAssistant_Model;

namespace TeacherAssistant_BLL
{
    public class RuleManager
    {
        public static bool CreateRule(string cNo,string sem)
        {
            return RuleService.CreateRule(cNo, sem);
        }

        public static bool ExistRule(string cNo, string sem)
        {
            Rule rule = GetRule(cNo, sem);
            return rule.CourseNo != null ;
        }

        public static Rule GetRule(string cNo, string sem)
        {
            return RuleService.GetRule(cNo, sem);
        }

    }
}
