using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseCourt
{
    class helper
    {
        public static string password="";
        public static int ID = 0;
        public static int order_id = 0;
        public static int selectedTableId = 0;
        public static string selectedTableNum = "";
        public static string customerName = "";
        public static string customerNum = "";
        public static string customerAdr = "";
        public static string customerInfo = "";
        public static DataTable dt = new DataTable();
        public static bool if_cancel = false;
    }
}
