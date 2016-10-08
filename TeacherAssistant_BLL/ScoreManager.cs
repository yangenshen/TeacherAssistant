using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherAssistant_Model;
using TeacherAssistant_DAL;
namespace TeacherAssistant_BLL
{
   public class ScoreManager
    {
        public static List<StuScore> GetScores(string cNo,string sem)
        {
            return ScoreService.GetScores(cNo,sem);
        }
             
    }
}
