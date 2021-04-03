using Qurre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Stats
{
    public class Configs
    {
        public static string JoinMsg;
        public static ushort JoinMsgTime;
        public static int NTFCadetHP;
        public static int NTFLieutenantHP;
        public static int NTFCommanderHP;
        public static int CIHP;
        public static int CDPHP;
        public static int FGHP;
        public static int NTFScientistHP;
        public static int RSCHP;
        public static int SCP049HP;
        public static int SCP0492HP;
        public static int SCP096HP;
        public static int SCP106HP;
        public static int SCP173HP;
        public static int SCP93953HP;
        public static int SCP93989HP;
        public static int TUTHP;
        public static List<int> CIItem;
        public static List<int> NTFCadetItem;
        public static List<int> NTFLieutenantItem;
        public static List<int> NTFCommanderItem;
        public static List<int> CDPItem;
        public static List<int> RSCItem;
        public static List<int> FGItem;
        public static List<int> NTFScientistItem;
        public static List<int> TUTItem;
        public static bool LeaveProtect;
        public static bool returnHP;
        public static float returnHPTime;
        public static int returnHPvalue;
        public static bool Debug;
        public static bool AutoNuck;
        public static int AutoNuckTime;
        public static int DEscapeRole;
        public static int REscapeRole;
        public static void Reload()
        {
            JoinMsg = Plugin.Config.GetString("JoinMsg", "");
            JoinMsgTime = Plugin.Config.GetUShort("JoinMsgTime", 5);
            NTFCadetHP = Plugin.Config.GetInt("NTFCadetHP", 100);
            NTFCommanderHP = Plugin.Config.GetInt("NTFCommanderHP", 150);
            NTFLieutenantHP = Plugin.Config.GetInt("NTFLieutenantHP", 100);
            NTFScientistHP = Plugin.Config.GetInt("NTFScientistHP", 120);
            RSCHP = Plugin.Config.GetInt("RSCHP", 100);
            FGHP = Plugin.Config.GetInt("FGHP", 100);
            CIHP = Plugin.Config.GetInt("CIHP", 120);
            CDPHP = Plugin.Config.GetInt("CDP", 100);
            SCP049HP = Plugin.Config.GetInt("SCP049HP", 1700);
            SCP0492HP = Plugin.Config.GetInt("SCP0492HP", 300);
            SCP096HP = Plugin.Config.GetInt("SCP096HP", 500);
            SCP106HP = Plugin.Config.GetInt("SCP106HP", 650);
            SCP173HP = Plugin.Config.GetInt("SCP173HP", 3200);
            SCP93989HP = Plugin.Config.GetInt("SCP93989HP", 2200);
            SCP93953HP = Plugin.Config.GetInt("SCP93953", 2800);
            CIItem = Plugin.Config.GetIntList("CIItem");
            CDPItem = Plugin.Config.GetIntList("CDPItem");
            NTFCadetItem = Plugin.Config.GetIntList("NTFCadetItem");
            NTFCommanderItem = Plugin.Config.GetIntList("NTFCommanderItem");
            NTFLieutenantItem = Plugin.Config.GetIntList("NTFLieutemamtItem");
            NTFScientistItem = Plugin.Config.GetIntList("NTFScientistItem");
            RSCItem = Plugin.Config.GetIntList("RSCItem");
            TUTItem = Plugin.Config.GetIntList("TUTItem");
            Debug = Plugin.Config.GetBool("Debug", false);
            returnHP = Plugin.Config.GetBool("returnHP", false);
            returnHPTime = Plugin.Config.GetInt("returnHPTime", 2);
            returnHPvalue = Plugin.Config.GetInt("returnHPValue", 20);
            AutoNuck = Plugin.Config.GetBool("AutoNuck");
            AutoNuckTime = Plugin.Config.GetInt("AutoNuckTime", 600);
            DEscapeRole = Plugin.Config.GetInt("ClassD-Escape-Role", 8);
            REscapeRole = Plugin.Config.GetInt("Scientist-Escape-Role", 13);
        }
    }
}
