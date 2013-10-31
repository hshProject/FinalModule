using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HForm
{
    static class ClasSpecialTasks
    {
        public static bool CanDelete(string TableName, string FieldName, string FieldValue)
        {
            string sql = "select count(" + FieldName + ") from " + TableName + " where " + FieldName + "=" + FieldValue + "";
            int count = Convert.ToInt16(DataLayer.Executescalar(sql));
            if (count == 0) return true; else { MessageBox.Show("لا يجوز مسح هذا الصف لانة مرتبط ببيانات اخرى"); return false; }
        }

    }

}