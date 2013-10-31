using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace HForm
{
    public static class GlobalVariables
    {
        public static string exeFile = Application.StartupPath + "\\" + Application.ProductName + ".exe";
        public static string ConfigFilePath = Application.StartupPath + "\\" + Application.ProductName + ".exe" + ".config";
        public static bool SaveMode;
        public static string BranchName;
        public static int BranchCode;
        public static int sysLang;
        public static string RefrenceFilePath;
        public static string ReportPath = Application.StartupPath;
        public static string Server;
        public static string DBName;
        public static string DBSecName;
        public static string UserName;
        public static int UserId = 0;
        public static string password;
        public static int UserInsert = 1;
        public static DateTime InsertTime = DateTime.Now;
        public static int UserUpdate = 1;
        public static DateTime UpdateTime = DateTime.Now;



    }
}
 