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

        //0表示更新人数，1表示更新得分下限,2表示更新版本,3表示更新类型
        public static bool UpdateRule(string cNo, string sem,string details,int type)
        {
            switch (type)
            {
                case 0:
                    return RuleService.UpdateRuleNumDetails(cNo, sem, details);
                case 1:
                    return RuleService.UpdateRulePointDetails(cNo, sem, details);
                case 2:
                    return RuleService.UpdateRuleVersion(cNo,sem,int.Parse(details));
                case 3:
                    return RuleService.UpdateRuleType(cNo, sem, int.Parse(details));
                default:
                    return false;
            }
        }
    }
}
