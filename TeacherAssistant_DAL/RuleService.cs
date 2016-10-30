using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_Model;
using TeacherAssistant_DAL;
using System.Data;

namespace TeacherAssistant_DAL
{
    public class RuleService
    {
        public static bool CreateRule(string cNo, string sem)
        {
            string sql = string.Format("insert into Rule(CourseNo,Semester) values ('{0}','{1}')", cNo, sem);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public static TeacherAssistant_Model.Rule GetRule(string cNo, string sem)
        {
            string sql = string.Format("select * from Rule where CourseNo = '{0}' and Semester = '{1}'", cNo, sem);
            TeacherAssistant_Model.Rule rule = new TeacherAssistant_Model.Rule();
            DataTable dt = DBHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count == 1)
            {
                rule.CourseNo = cNo;
                rule.Semester = sem;
                rule.Description = dt.Rows[0]["Description"].ToString();
                rule.NumDetails = dt.Rows[0]["NumDetails"].ToString();
                rule.PointDetails = dt.Rows[0]["PointDetails"].ToString();
                rule.RuleNo = int.Parse(dt.Rows[0]["RuleNo"].ToString());
                rule.Version = int.Parse(dt.Rows[0]["Version"].ToString());
                rule.RuleType = int.Parse(dt.Rows[0]["RuleType"].ToString());
            }
            return rule;
        }

        public static bool UpdateRuleNumDetails(string cNo, string sem, string numDetails)
        {
            string sql = string.Format("Update Rule set NumDetails = '{0}' where CourseNo = '{1}' and Semester = '{2}'", numDetails, cNo, sem);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public static bool UpdateRulePointDetails(string cNo, string sem, string pointDetails)
        {
            string sql = string.Format("Update Rule set PointDetails = '{0}' where CourseNo = '{1}' and Semester = '{2}'", pointDetails, cNo, sem);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public static bool UpdateRuleVersion(string cNo, string sem, int v)
        {
            string sql = string.Format("Update Rule set Version = {0} where CourseNo = '{1}' and Semester = '{2}'", v, cNo, sem);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public static bool UpdateRuleType(string cNo, string sem, int t)
        {
            string sql = string.Format("Update Rule set RuleType = {0} where CourseNo = '{1}' and Semester = '{2}'", t, cNo, sem);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
