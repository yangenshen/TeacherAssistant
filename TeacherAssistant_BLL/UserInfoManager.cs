using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_DAL;
namespace TeacherAssistant_BLL
{
    public class UserInfoManager
    {
        public static bool CheckLogin(string name,string pwd)
        {
            return UserInfoService.CheckUserLogin(name, pwd);
        }
    }
}
