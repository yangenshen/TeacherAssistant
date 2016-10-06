using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_DAL;

namespace TeacherAssistant_BLL
{
    public class StuManager
    {
        public static bool ImportStu(string sNo, string sName, string major)
        {
            return StuService.ImportStu(sNo, sName, major);
        }
    }
}
