using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace HForm
{
    public static class ClasConfig
    {
        //   public static string server;
        // public static string dataBase;
        //public static string userID;
        // public static string passWord;

        public static void updateConfiguration()
        {
            string path = GlobalVariables.ConfigFilePath;

            string app = @"<?xml version=" + "\"1.0\"" + @"?>
                        <configuration>
                           <configSections>
                          </configSections>
                        
 <appSettings>
    
 <add key=""dataBases"" value=""" + GlobalVariables.DBName + @"""/>
<add key=""Server"" value=""" + GlobalVariables.Server + @"""/>
<add key=""UserID"" value=""" + GlobalVariables.UserName + @"""/>
<add key=""Password"" value=""" + GlobalVariables.password + @"""/>
      </appSettings>


                        <startup useLegacyV2RuntimeActivationPolicy=" + "\"true\"" + @">
                        <supportedRuntime version=" + "\"v4.0\"" + " sku=" + "\".NETFramework,Version=v4.0\"" + @"/></startup>
                        </configuration>";

            /////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////
            //        string app = @"<?xml version="+"\"1.0\""+ @"  ?>
            //<configuration>
            //  <connectionStrings>
            //    <add name=""clienetConnString""
            //        connectionString=""Data Source=HOSAM-PC;Initial Catalog=Law_Dat;Integrated Security=True;User ID=sa;Password=123 ""
            //        providerName=""System.Data.SqlClient"" />
            //  </connectionStrings>
            //  <appSettings>
            //    <!--ادخل كود الفرع الحالى هنا-->
            //    <add key=""BranchCode"" value=""6""/>
            //    <!--ادخل القيمة( 1 ) تفيد تشغيل الخدمة للبيع و(0)عدم تشغيلها-->
            //    <add key=""ForSell"" value=""1""/>
            //    <!--ادخل القيمة( 1 ) تفيد تشغيل الخدمة للإيجار و(0)عدم تشغيلها-->
            //    <add key=""ForRent"" value=""1""/>
            //    <!--(,) ادخل اسماء قواعد البيانات مفصولا بينها بـ-->
            //    <add key=""dataBases"" value=""Law_Dat""/>
            //<add key=""Server"" value=""HOSAM-PC""/>
            //<add key=""UserID"" value=""sa""/>
            //<add key=""Password"" value=""123""/>
            //      </appSettings>
            //</configuration>
            //";
            File.WriteAllText(path, app);
        }

    }

}