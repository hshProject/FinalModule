using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace HForm
{

    public class clasReference
    {
        public DataTable getDataRefernc(Form frm)
        {
            //clasMain obj = new clasMain();
            DataTable dt = new DataTable();
            if (frm.Tag != null)
            {
                string sql = "select FieldName,ArabicCaption from ReferenceFile where TableName='" + frm.Tag.ToString() + "'";
                dt = DataLayer.executeDataTable(sql);
            }
            return dt;
        }

        string[] getControlNames(Panel pnlBody)
        {
            int index = 0;
            string[] arr1 = new string[pnlBody.Controls.Count];
            foreach (Control ctrl in pnlBody.Controls)
            {
                arr1[index] = ctrl.Text;
                index++;
            }
            return arr1;
        }

        public void makeJob(Form frm)
        {
            DataTable dt = getDataRefernc(frm);
            #region    فى حالة رمى الكنترولز ف الفورمة على طول
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is Label)
                {
                    string nam = ctrl.Name.Remove(0, 3);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (nam == dt.Rows[i]["FieldName"].ToString())
                            ctrl.Text = dt.Rows[i]["ArabicCaption"].ToString();
                    }
                }
            }
            #endregion
            #region فى حالة وضعهم ف البنل
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is Panel)
                {
                    foreach (Control ctrl2 in ctrl.Controls)
                    {
                        if (ctrl2 is Label)
                        {
                            string nam = ctrl2.Name.Remove(0, 3);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (nam == dt.Rows[i]["FieldName"].ToString())
                                    ctrl2.Text = dt.Rows[i]["ArabicCaption"].ToString();
                            }
                        }
                    }
                }
            }
            #endregion
        }


    }

}