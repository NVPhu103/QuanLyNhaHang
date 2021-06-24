using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19110430_NguyenVanPhu_Day01
{
    class Global
    {
        public static int GlobalUserID { get; private set; }
        public static string Status { get; set; }
        public static void SetGlobalUserID(int UserID)
        {
            GlobalUserID = UserID;
        }
    }
}
