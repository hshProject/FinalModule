using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace HForm
{

    public static class FileManager
    {
        static DataTable Items = new DataTable();

        public static DataTable getPrograms()
        {

            string sql = @"select * from Programs inner join PrgPer on Programs.ProgId=PrgPer.ProgId
where UserId=" + GlobalVariables.UserId + @"
order by Programs.ProgId";
            DataTable dt = DataLayer.executeDataTable(sql);
            return dt;
        }

        public static DataTable getPrograms(string Criteria)
        {
            string sql = "select * from Programs ";
            sql += Criteria;
            DataTable dt = DataLayer.ExecuteDataTable(sql);
            return dt;
        }


        public static void fillMenu(MenuStrip Menu)
        {
            ToolStripMenuItem itemMenu;
            Items = getPrograms();
            foreach (DataRow dr in Items.Select("ParentID=0"))
            {
                itemMenu = SetMenuItem(dr);
                Menu.Items.Add(itemMenu);
            }
        }

        private static ToolStripMenuItem SetMenuItem(DataRow dr)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Name = "MI_" + dr["FormName"].ToString() + "_" + dr["ProgId"].ToString() + "";
            menuItem.Text = dr["ArabicName"].ToString();
            foreach (DataRow cdr in Items.Select("[ParentID]=" + dr["ProgId"].ToString()))
            {
                menuItem.DropDownItems.Add(SetMenuItem(cdr));

            }
            if (dr["FormName"] != null && dr["FormName"].ToString() != "")
            {
                menuItem.Click += new EventHandler(menuItemClick);
            }
            return menuItem;
        }

        private static void menuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            string str = mi.Name;
            int startIndex = str.IndexOf('_');
            int lastIndex = str.LastIndexOf('_');
            int lenth = lastIndex - startIndex;
            str = str.Substring(startIndex + 1, lenth - 1);
            string name = mi.Name;
            string progid = name.Substring(lastIndex);
            name.TrimStart('_');
            progid = progid.TrimStart('_');
            string Criteria = " where ProgId=" + progid + "";
            DataTable dt = getPrograms(Criteria);
            object[] Parameters = null;
            if (dt.Rows[0]["Parameters"] == null || dt.Rows[0]["Parameters"] == DBNull.Value)
            { FormsTasks.openForm(str, null); }
            else
            {
                // string[] TempPara = dt.Rows[0]["Parameters"].ToString().Split('_');
                //Parameters = TempPara;
                // string test = Parameters.GetValue(0).ToString();
                //   test = test.Remove(0, 5);
                // string[] test2 = test.Split('=');
                // Parameters = test2;
                Parameters = FormsTasks.PrepareParameters(dt.Rows[0]["Parameters"].ToString());
                FormsTasks.openForm(str, Parameters);
            }
        }
    }

}