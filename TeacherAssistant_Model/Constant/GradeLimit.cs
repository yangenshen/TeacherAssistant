using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAssistant_Model
{
    public class GradeLimit
    {
        public readonly static double AofU = 0.3;               //本科生A限制
        public readonly static string AofU_AlertMs = "本科生A类不得超过30%";       //警告信息

        public readonly static double AofMBA = 0.5;             //MBA的A限制
        public readonly static string AofMBA_AlertMs = "MBA的A类不得超过50%";
        public readonly static int LowofMBA = 2;                //MBA的低等级人数限制（D和F）
        public readonly static string LowofMBA_AlertMs = "MBA的C类以下至少有2人";

        public readonly static double AofP = 0.8;    //研究生A限制
        public readonly static string AofP_AlertMs = "研究生A类比例不得超过80%";

    }
}
