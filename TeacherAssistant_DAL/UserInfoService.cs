using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_Model;
namespace TeacherAssistant_DAL
{
    public class UserInfoService
    {
        public static bool CheckUserLogin(string userName, string password)
        {
            string sql = string.Format("select * from Teacher where TeacherNo = '{0}' and Password = '{1}'", userName, password);
            DataTable dt = DBHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count == 1)
            {
                UserInfo.TeacherNo = userName;
                UserInfo.Password = password;
                UserInfo.TeacherName = dt.Rows[0]["TeacherName"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
