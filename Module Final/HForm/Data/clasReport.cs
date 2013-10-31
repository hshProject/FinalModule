using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;


namespace HForm
{
    public static class clasReport
    {
        //public static void ShowReport(string ReportName,string sql,Dictionary<string, string> Formulas )
        //{

        //   // ReportDocument rd = new ReportDocument();


        //     DataTable dt = new DataTable();
        //       dt = DataLayer.ExecuteDataTable(sql);

        //    ViewReports frm = new ViewReports();
        //    frm.crystalReportViewer1.RefreshReport();
        //        ReportDocument doc = new ReportDocument();
        //        doc.Load(GlobalVariables.ReportPath + @"\" + ReportName + "");   
        //        //D:\projects\Dropbox\ModuleFinal\Module\bin\Debug
        //      //  doc.Load(@"D:\projects\MyModule1june\MyModule\MyModule\MyModule\rptRevenues.rpt");  
        //       // string Connection = DataLayer.Connection.ConnectionString;
        //        string Connection = " Data Source =197.161.38.89;Connect Timeout=10; Initial Catalog = Module ; Integrated Security = False; User ID= sa;password= hellonewsystem";
        //        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Connection);
        //        doc.SetDatabaseLogon(builder.UserID, builder.Password, builder.DataSource, builder.InitialCatalog);
        //        doc.SetDataSource(dt);

        //       foreach (KeyValuePair<string, string> Form in Formulas)
        //       {
        //           doc.DataDefinition.FormulaFields[Form.Key].Text = "'" + Form.Value + "'";
        //       }

        //       frm.crystalReportViewer1.ReportSource = doc;
        //       //frm.crystalReportViewer1.ReportSource = GlobalVariables.ReportPath + @"\" + ReportName + "";
        //       frm.ShowDialog();
        //}

        public static void ShowReport(string ReportName, string sql, Dictionary<string, string> Formulas)
        {

            DataTable dt = new DataTable();
            dt = DataLayer.ExecuteDataTable(sql);

            ViewReports frm = new ViewReports();

            ReportDocument doc = new ReportDocument();
            doc.Load(GlobalVariables.ReportPath + @"\" + ReportName + "");
            doc.SetDataSource(dt);

            foreach (KeyValuePair<string, string> Form in Formulas)
            {
                doc.DataDefinition.FormulaFields[Form.Key].Text = "'" + Form.Value + "'";
            }
            frm.crystalReportViewer1.ReportSource = doc;
            frm.ShowDialog();
        }
    }

}