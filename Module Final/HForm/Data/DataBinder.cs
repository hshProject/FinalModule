using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using System.Data;

using System.Data.SqlClient;
using HControls;

namespace HForm
{
    public class DataBinder
    {
        public DataForm frm;
        #region "LoadTableData"
        public DataBinder()
        {
        }
        public DataBinder(DataForm form)
        {
            frm = form;
            LaodControlsProperites();
        }
        public void LaodControlsProperites()
        {
            //hemaily
            string sql = @"SELECT     TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, IS_NULLABLE, DATA_TYPE, NUMERIC_PRECISION, DATETIME_PRECISION, CASE WHEN (IS_NULLABLE = 'YES') 
                      THEN 0 ELSE 1 END AS Required, 
                      CASE WHEN COLUMN_NAME IN
                          (SELECT     COLUMN_NAME
                             FROM         INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                             WHERE     (OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_NAME), 'IsPrimaryKey') = 1) AND (TABLE_NAME = '" + frm.TableName + @"')) THEN 1 ELSE 0 END AS IsKey
FROM         INFORMATION_SCHEMA.COLUMNS
WHERE     (TABLE_NAME ='" + frm.TableName + "')";
            frm.TControls = DataLayer.executeDataTable(sql);


            frm.TControls.Columns.Add("Control_Name");
            // frm.TControls.Columns.Add("IsKey", Type.GetType("System.Boolean"));
            //frm.TControls.Columns.Add("Required", Type.GetType("System.Boolean"));
            frm.TControls.Columns.Add("MinValue", Type.GetType("System.Decimal"));
            frm.TControls.Columns.Add("MaxValue", Type.GetType("System.Decimal"));


            foreach (DataRow row in frm.TControls.Rows)
            {

                foreach (Control co in this.frm.Controls)
                {
                    #region HTextBox
                    if (co is HTextBox)
                    {
                        HTextBox ht = co as HTextBox;
                        if (ht.FieldName == row["COLUMN_NAME"].ToString())
                        {

                            row["Control_Name"] = ht.Name;
                            //get keys
                            if ((int)row["IsKey"] == 1)
                            {
                                ht.key = true;
                            }
                            else
                            {
                                ht.key = false;
                            }
                            //check Nullable columns (requred)
                            if (row["IS_NULLABLE"].ToString() == "YES")
                            {
                                // ht.required = false;
                            }
                            else
                            {
                                ht.required = true;
                            }
                            if (row["DATA_TYPE"].ToString() == "Deciaml" || row["DATA_TYPE"].ToString() == "numeric" || row["DATA_TYPE"].ToString() == "float")
                            {
                                row["MinValue"] = -9999999999; row["MaxValue"] = 99999999999999;
                                ht._DataType = DataType.Decimal;
                            }
                            else if (row["DATA_TYPE"].ToString() == "int" || row["DATA_TYPE"].ToString() == "smallint" || row["DATA_TYPE"].ToString() == "bigint")
                            {
                                row["MinValue"] = 0; row["MaxValue"] = 99999999999999;
                                ht._DataType = HControls.DataType.Integer;
                            }
                            else if (row["DATA_TYPE"].ToString() == "datetime" || row["DATA_TYPE"].ToString() == "date")
                            {
                                ht._DataType = DataType.DateTime;
                            }

                        }
                    }
                    #endregion
                    #region Hcheckbox

                    else if (co is HCheckbox)
                    {
                        HCheckbox ht = co as HCheckbox;
                        if (ht._FieldName == row["COLUMN_NAME"].ToString())
                        {

                            row["Control_Name"] = ht.Name;



                        }
                    }
                    #endregion

                }
            }
        }
        #endregion
        #region"SaveData"
        #region CreateStatement"
        string CreateSqlStatement()
        {
            string sql = "";
            string fieldName = "";
            string fieldValue = "";
            string critria = "";
            if (frm.recordMode == DataForm.RecordMode.Insert)
                sql = "insert Into  " + frm.TableName + "  ";
            else if (frm.recordMode == DataForm.RecordMode.Update)
                sql = "Update " + frm.TableName + " set ";
            else if (frm.recordMode == DataForm.RecordMode.Delete)
                sql = "Delete From " + frm.TableName;

            if (frm.recordMode == DataForm.RecordMode.Insert)
            {
                fieldName += " (";
                fieldValue += " Values (";
            }

            // Mohamed samir 22/5/2013
            string Exist = "0";
            Exist = DataLayer.Executescalar(@"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = '" + frm.TableName + "' and column_name =  'BranchCode'");
            if (frm.TableName != "Branches" && Exist == "1")
            {
                if (frm.recordMode == DataForm.RecordMode.Insert)
                {
                    fieldName += " BranchCode,";
                    fieldValue += GlobalVariables.BranchCode + ",";
                }
                else if (frm.recordMode == DataForm.RecordMode.Update)
                {
                    critria += " and BranchCode = " + GlobalVariables.BranchCode;
                }
                else if (frm.recordMode == DataForm.RecordMode.Delete)
                {
                    critria += " and BranchCode = " + GlobalVariables.BranchCode;
                }
            }
            // Mohamed samir 22/5/2013

            foreach (Control co in frm.Controls)
            {
                #region textbox

                if (co is HTextBox)
                {

                    HTextBox ht = co as HTextBox;
                    if (ht.FieldName != null & ht.FieldName != "")//21-10-2013//علشان لو مالهاش فيلد نيم ما تتحطش فى جملة الانسرت (علشان الFooterformWithControls)
                    {
                        if (frm.recordMode == DataForm.RecordMode.Insert)
                        {

                            if (ht._DataType == DataType.Integer || ht._DataType == DataType.Decimal)
                            {
                                if (ht.Text.Trim() == "")
                                {
                                    fieldValue += "NULL,";
                                }
                                else
                                {
                                    fieldValue += ht.Text + ",";
                                }
                                fieldName += ht.FieldName + ",";


                            }
                            else if (ht._DataType == DataType.String || ht._DataType == DataType.DateTime)
                            {

                                if (ht.Text.Trim() == "")
                                {
                                    fieldValue += "NULL,";
                                }
                                else
                                {
                                    fieldValue += "'" + ht.Text + "',";
                                }
                                fieldName += ht.FieldName + ",";

                            }


                        }

                        else if (frm.recordMode == DataForm.RecordMode.Update)
                        {
                            if (ht.key == true)
                            {

                                critria += " and " + ht.FieldName + " = " + ht.Text;
                            }
                            else
                            {
                                if (ht._DataType == DataType.Integer || ht._DataType == DataType.Decimal)
                                {
                                    if (ht.Text.Trim() == "")
                                    {
                                        fieldValue += ht.FieldName + "= NULL,";
                                    }
                                    else
                                    {
                                        fieldValue += ht.FieldName + "=" + ht.Text + ",";
                                    }



                                }
                                else if (ht._DataType == DataType.String || ht._DataType == DataType.DateTime)
                                {
                                    if (ht.Text.Trim() == "")
                                    {

                                        fieldValue += ht.FieldName + "= NULL,";
                                    }
                                    else
                                    {
                                        fieldValue += ht.FieldName + "='" + ht.Text + "',";
                                    }


                                }
                            }
                        }

                        else if (frm.recordMode == DataForm.RecordMode.Delete)
                        {



                            if (frm.recordMode == DataForm.RecordMode.Delete)
                            {
                                if (ht.key == true)
                                    critria += " and " + ht.FieldName + " = " + ht.Text;
                            }



                        }
                    }


                }

                #endregion
                #region checkBox
                else if (co is HCheckbox)
                {

                    HCheckbox ht = co as HCheckbox;
                    if (ht.FieldName != "")
                    {
                        if (frm.recordMode == DataForm.RecordMode.Insert)
                        {

                            fieldName += ht.FieldName + ",";
                            fieldValue += (ht.Checked == true ? "1" : "0") + ",";

                        }

                        else if (frm.recordMode == DataForm.RecordMode.Update)
                        {
                            fieldValue += ht.FieldName + "=" + (ht.Checked == true ? "1" : "0") + ",";

                        }


                    }


                }

                #endregion
            }
            #region Compelete Statement

            if (frm.recordMode == DataForm.RecordMode.Insert)
            {
                if (fieldName != "")
                {
                    fieldName = fieldName.Remove(fieldName.Length - 1);
                    fieldName += ")";
                }
                if (fieldValue != "")
                {
                    fieldValue = fieldValue.Remove(fieldValue.Length - 1);
                    fieldValue += ")";
                }
                sql += fieldName + fieldValue;

            }
            else if (frm.recordMode == DataForm.RecordMode.Update)
            {
                fieldValue = fieldValue.Remove(fieldValue.Length - 1);
                sql += fieldName + fieldValue + " where 1=1 " + critria;
            }
            else if (frm.recordMode == DataForm.RecordMode.Delete)
            {
                if (critria != "")
                    sql += " where 1=1 " + critria;
            }
            #endregion
            return sql;
        }
        string createDeleteStatementForGrid(HGrid grd)
        {
            string sql = "";
            string fieldName = "";
            string fieldValue = "";
            string critria = "";


            if (frm.recordMode == DataForm.RecordMode.Delete && grd.TableName != null)
            {
                sql = "Delete From " + grd.TableName + "";


                // Mohamed samir 22/5/2013
                string Exist = "0";
                Exist = DataLayer.Executescalar(@"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = '" + grd.TableName + "' and column_name =  'BranchCode'");
                if (Exist == "1")
                {
                    if (frm.recordMode == DataForm.RecordMode.Delete)
                    {
                        critria += " and BranchCode = " + GlobalVariables.BranchCode;
                    }
                }
                // Mohamed samir 22/5/2013

                foreach (Control co in frm.Controls)
                {
                    #region textbox

                    if (co is HTextBox)
                    {

                        HTextBox ht = co as HTextBox;
                        if (ht.FieldName != "" && ht.Text != "")
                        {
                            if (frm.recordMode == DataForm.RecordMode.Insert)
                            {

                                if (ht._DataType == DataType.Integer || ht._DataType == DataType.Decimal)
                                {
                                    fieldName += ht.FieldName + ",";
                                    fieldValue += ht.Text + ",";

                                }
                                else if (ht._DataType == DataType.String || ht._DataType == DataType.DateTime)
                                {
                                    fieldName += ht.FieldName + ",";
                                    fieldValue += "'" + ht.Text + "',";
                                }


                            }

                            else if (frm.recordMode == DataForm.RecordMode.Update)
                            {
                                if (ht.key == true)
                                {

                                    critria += " and " + ht.FieldName + " = " + ht.Text;
                                }
                                else
                                {
                                    if (ht._DataType == DataType.Integer || ht._DataType == DataType.Decimal)
                                    {

                                        fieldValue += ht.FieldName + "=" + ht.Text + ",";

                                    }
                                    else if (ht._DataType == DataType.String || ht._DataType == DataType.DateTime)
                                    {

                                        fieldValue += ht.FieldName + "='" + ht.Text + "',";
                                    }
                                }
                            }

                            else if (frm.recordMode == DataForm.RecordMode.Delete)
                            {



                                if (frm.recordMode == DataForm.RecordMode.Delete)
                                {
                                    if (ht.key == true)
                                        critria += " and " + ht.FieldName + " = " + ht.Text;
                                }



                            }
                        }


                    }

                    #endregion
                    #region checkBox
                    else if (co is HCheckbox)
                    {

                        HCheckbox ht = co as HCheckbox;
                        if (ht.FieldName != "")
                        {
                            if (frm.recordMode == DataForm.RecordMode.Insert)
                            {

                                fieldName += ht.FieldName + ",";
                                fieldValue += (ht.Checked == true ? "1" : "0") + ",";

                            }

                            else if (frm.recordMode == DataForm.RecordMode.Update)
                            {
                                fieldValue += ht.FieldName + "=" + (ht.Checked == true ? "1" : "0") + ",";

                            }


                        }


                    }

                    #endregion
                }
                #region Compelete Statement

                if (frm.recordMode == DataForm.RecordMode.Insert)
                {
                    if (fieldName != "")
                    {
                        fieldName = fieldName.Remove(fieldName.Length - 1);
                        fieldName += ")";
                    }
                    if (fieldValue != "")
                    {
                        fieldValue = fieldValue.Remove(fieldValue.Length - 1);
                        fieldValue += ")";
                    }
                    sql += fieldName + fieldValue;

                }
                else if (frm.recordMode == DataForm.RecordMode.Update)
                {
                    fieldValue = fieldValue.Remove(fieldValue.Length - 1);
                    sql += fieldName + fieldValue + " where 1=1 " + critria;
                }
                else if (frm.recordMode == DataForm.RecordMode.Delete)
                {
                    if (critria != "")
                        sql += " where 1=1 " + critria;
                }
                #endregion
                return sql;
            }
            else return sql;
        }
        public Boolean Save(DataForm Sfrm)
        {
            if (isRequired() == false)
            {
                //hemaily 18may2013
                if (Sfrm.FormType == "FooterFormWithOutContol")
                {

                    //hassan 28-9-2013
                    foreach (Control ctrl in frm.Controls)
                        if (ctrl is HGrid)
                        {
                            HGrid grd = ctrl as HGrid;
                            if (grd.TableName != null && grd.TableName != "")
                                updateFooterTable(frm.TableName, grd.TableName, frm);
                        }
                    //end heamily 18may2013
                    Clear(frm.Controls);
                    //MessageBox.Show("تم الحفظ");
                    frm.binder.NextCode(frm.NextCodeControl);
                    return true;
                }
                else if (Sfrm.FormType == "HeaderFooterContol")
                {
                    // Mohamed samir 22/5/2013
                    if (Sfrm.recordMode == DataForm.RecordMode.None)
                        Sfrm.recordMode = DataForm.RecordMode.Insert;
                    frm = Sfrm;

                    string sql = CreateSqlStatement();
                    if (DataLayer.ExecuteNonQuery(sql) > 0)
                    {
                        if (Sfrm.recordMode == DataForm.RecordMode.Insert)
                        {
                            Sfrm.recordMode = DataForm.RecordMode.Update;

                        }

                        //  hemail 18may2013
                        //foreach (Control ctrl in frm.Controls)
                        //    if (ctrl is HGrid)
                        //    {
                        //        HGrid grd = ctrl as HGrid;
                        //        if (grd.TableName != null && grd.TableName != "")
                        //            updateFooterTable(frm.TableName, grd.TableName, frm);
                        //    }
                        //// end heamily 18may2013
                        fillFooterTable(frm, frm.Controls);
                        Clear(frm.Controls);
                        MessageBox.Show("تم الحفظ");
                        frm.binder.NextCode(frm.NextCodeControl);
                        return true;
                        //  Mohamed samir 22/5/2013
                    }
                    else
                        return false;

                }
                else if (Sfrm.FormType == "FooterFormWithContol")
                {
                    // Mohamed samir 22/5/2013
                    if (Sfrm.recordMode == DataForm.RecordMode.None)
                        Sfrm.recordMode = DataForm.RecordMode.Insert;
                    frm = Sfrm;

                    updateFooterTable(frm.TableName, frm.TableName, frm);

                    // end heamily 18may2013
                    Clear(frm.Controls);
                    MessageBox.Show("تم الحفظ");
                    frm.binder.NextCode(frm.NextCodeControl);
                    return true;
                    //  Mohamed samir 22/5/2013


                }
                else
                //end hemaily 18may2013
                {
                    if (Sfrm.recordMode == DataForm.RecordMode.None)
                        Sfrm.recordMode = DataForm.RecordMode.Insert;
                    frm = Sfrm;

                    string sql = CreateSqlStatement();
                    if (DataLayer.ExecuteNonQuery(sql) > 0)
                    {
                        if (Sfrm.recordMode == DataForm.RecordMode.Insert)
                        {
                            Sfrm.recordMode = DataForm.RecordMode.Update;

                        }

                        MessageBox.Show("تم الحفظ");
                        //  frm.binder.NextCode(frm.NextCodeControl);


                        return true;
                    }
                    else
                        return true;

                }

            }

            else
            { return false; }
        }

        #endregion
        #endregion
        #region "Valiadations"
        bool isRequired()
        {
            bool isRequired = false;
            foreach (Control co in frm.Controls)
            {
                if (co is HTextBox)
                {
                    HTextBox ht = co as HTextBox;
                    if (ht.required == true)
                    {

                        if (ht.Text == null || ht.Text.Trim() == "")//ABUBAKR  23/9/2013 .Trim()  علشان ما يقبلش مسافات فقط 
                        {

                            frm.errorProvider1.SetError(ht, " text Required");
                            return true;
                        }

                    }
                    if (ht.ComboBoxRelatedWith != null && ht.ComboBoxRelatedWith != "")
                    {
                        if (ht.Text.Trim() != "" && (frm.Controls[ht.ComboBoxRelatedWith] as HComboBox).SelectedValue == null)
                        {
                            frm.errorProvider1.SetError(ht, " text Required");
                            return true;
                        }
                    }

                }

            }
            return isRequired;
        }
        #endregion
        #region"DeleteData"
        #region CreateStatement"

        public void Delete(DataForm Sfrm)
        {

            frm = Sfrm;
            foreach (Control ctrl in Sfrm.Controls)
            {
                string sql = CreateSqlStatement();
                DataLayer.ExecuteNonQuery(sql);

                //hemaily 8june 2013
                if (ctrl is HGrid)
                {
                    HGrid MyGrid = ctrl as HGrid;
                    sql = createDeleteStatementForGrid(MyGrid);
                    if (sql != "")
                        DataLayer.ExecuteNonQuery(sql);
                }
                //endhemaily
            }

            //frm.binder.Clear(frm.Controls);
            Clear(frm.Controls);

            //  MessageBox.Show("تم الحذف");
            NextCode(frm.NextCodeControl);
            frm.recordMode = DataForm.RecordMode.Insert;



        }
        #endregion
        #endregion
        # region ShowData
        public void NextCode(string NextControlCode, String critiria = "")
        {
            try
            {
                frm.errorProvider1.Clear();
                HTextBox co = frm.Controls[NextControlCode] as HTextBox;
                DataRow[] key = frm.TControls.Select("IsKey=1");

                // mohamed samir 22/5/2013
                string Exist = "0";
                Exist = DataLayer.Executescalar(@"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = '" + frm.TableName + "' and column_name =  'BranchCode'");
                string cri = "";
                if (Exist == "1")
                {
                    cri += " AND BranchCode = " + GlobalVariables.BranchCode;
                }
                // mohamed samir 22/5/2013


                string sql = "Select  isnull(Max(" + co.FieldName + ") ,0)+1 from " + frm.TableName.ToString() + " where 1=1 " + cri;
                foreach (DataRow dr in key)
                {
                    //hassan
                    if (dr["Control_Name"] != "" && dr["Control_Name"] != frm.NextCodeControl && dr["Control_Name"] != null && dr["Control_Name"] != DBNull.Value && frm.Controls[dr["Control_Name"].ToString()].Text != null && frm.Controls[dr["Control_Name"].ToString()].Text != "")
                        sql += " and " + dr["Column_Name"] + "= " + frm.Controls[dr["Control_Name"].ToString()].Text;

                }
                co.Text = DataLayer.Executescalar(sql).ToString();

                foreach (Control ht in frm.Controls)
                {
                    if (ht is HTextBox)
                    {

                        if (((HTextBox)ht).key == true)
                            ht.Enabled = true;
                        else
                            ht.Enabled = false;

                    }
                    else if (ht is HComboBox || ht is HCheckbox) ht.Enabled = false;
                    else if (ht is HGrid && ht.Name != "List")
                        ht.Enabled = false;



                }
                frm.recordMode = DataForm.RecordMode.None;
                // SendKeys.Send("{TAB}");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void Clear(Control.ControlCollection myControl)
        {
            foreach (Control co in myControl)
            {
                if (co.Controls.Count != 0 && !(co is HGrid))
                    Clear(co.Controls);

                if (co is HTextBox)
                {
                    if (((HTextBox)co).key == false)
                        co.Text = "";
                }
                if (co is HComboBox)
                {

                    (co as HComboBox).SelectedIndex = -1;
                }
                if (co is HCheckbox)
                {

                    { (co as CheckBox).Checked = false; }
                }
                if (co is HGrid)
                {
                    if (co.Name != "List")
                        (co as HGrid).Rows.Clear();
                }
                if (co is DataGridView)
                {
                    if (co.Name != "List")
                        (co as DataGridView).Rows.Clear();
                }
            }
        }

        public void getRecord()
        {
            //try { SendKeys.Send("+{TAB}"); }
            //catch { }

            // Mohamed samir 22/5/2013
            string Exist = "0";
            Exist = DataLayer.Executescalar(@"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = '" + frm.TableName + "' and column_name =  'BranchCode'");
            string cri = "";
            if (frm.TableName != "Branches" && Exist == "1")
            {
                cri += " And BranchCode = " + GlobalVariables.BranchCode;
            }
            // Mohamed samir 22/5/2013

            string sql = "Select * from " + frm.TableName + " where 1=1" + cri;
            DataRow[] rows = frm.TControls.Select("IsKey =1", "");
            foreach (DataRow row in rows)
            {
                if (row["Control_Name"] != null && row["Control_Name"].ToString() != "" && row["Control_Name"] != DBNull.Value)
                {
                    HTextBox co = frm.Controls[row["Control_Name"].ToString()] as HTextBox;
                    //hemaily 5october
                    if (co.DataType.ToString() != "DateTime")
                        sql += " and " + co.FieldName + " ='" + co.Text + "'";
                    else sql += " and " + co.FieldName + " =convert(datetime, '" + Convert.ToDateTime(co.Text).ToString("dd/MM/yyyy") + "',103)";
                    if (co.Text == "") ;
                }
            }
            DataTable dt = DataLayer.ExecuteDataTable(sql);
            if (dt.Rows.Count != 0)
            {
                foreach (DataColumn col in dt.Columns)
                {

                    rows = frm.TControls.Select("Column_name ='" + col.ColumnName + "'", "");
                    if (rows.Length != 0)
                    {
                        if (frm.Controls[rows[0]["Control_Name"].ToString()] is HTextBox)
                        {
                            HTextBox co = frm.Controls[rows[0]["Control_Name"].ToString()] as HTextBox;
                            co.Text = dt.Rows[0][col].ToString();
                            //hemaily 31may 2013
                            if (co._DataType == DataType.DateTime && co.Text != null && co.Text != "")
                                co.Text = Convert.ToDateTime(dt.Rows[0][col]).ToString("yyyy/MM/dd");
                            if (Convert.ToBoolean(rows[0]["IsKey"]) == true) co.Enabled = false; else co.Enabled = true;
                            if (co._ComboBoxRelatedWith != null && co._ComboBoxRelatedWith != "")
                            {
                                HComboBox com = frm.Controls[co._ComboBoxRelatedWith] as HComboBox;
                                if (Convert.ToBoolean(rows[0]["IsKey"]) == true)
                                    com.Enabled = false;
                                else
                                    com.Enabled = true;

                            }

                        }
                        else if (frm.Controls[rows[0]["Control_Name"].ToString()] is HCheckbox)
                        {
                            HCheckbox co = frm.Controls[rows[0]["Control_Name"].ToString()] as HCheckbox;
                            //hemaily
                            if (dt.Rows[0][col] != DBNull.Value) co.Checked = Convert.ToBoolean(dt.Rows[0][col].ToString()); else { co.Checked = false; };
                            if (Convert.ToBoolean(rows[0]["IsKey"]) == true) co.Enabled = false; else co.Enabled = true;
                        }

                    }
                }
                if (frm.FormType != "FooterFormWithContol")
                    frm.recordMode = DataForm.RecordMode.Update;
                else if (frm.FormType == "FooterFormWithContol")
                {
                    HGrid grid;
                    foreach (Control ctrl in frm.Controls)
                    {
                        if (ctrl is HGrid && ctrl.Name != "list")
                        {
                            grid = ctrl as HGrid;
                            if (grid.TableName == frm.TableName)
                            {
                                grid.Rows.Clear();

                                foreach (DataRow row in dt.Rows)
                                {
                                    grid.Rows.Add(1);
                                    foreach (DataGridViewColumn col in grid.Columns)
                                    {
                                        if (dt.Columns.Contains(col.Name))
                                        {
                                            if (grid.Columns[col.Name].ValueType == typeof(DateTime))
                                                grid.Rows[grid.Rows.Count - 1].Cells[col.Name].Value = Convert.ToDateTime(row[col.Name].ToString()).ToString("dd/MM/yyyy");
                                            else
                                                grid.Rows[grid.Rows.Count - 1].Cells[col.Name].Value = row[col.Name];
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    frm.recordMode = DataForm.RecordMode.Update;

                }
            }
            else
            {
                frm.recordMode = DataForm.RecordMode.Insert;
                //foreach (DataRow row in frm.TControls.Rows)
                //{
                //    if (Convert.ToBoolean(row["ISKey"]) == false)
                //    {
                //        if (frm.Controls[row["Control_Name"].ToString()] is HCheckbox) (frm.Controls[row["Control_Name"].ToString()] as HCheckbox).Enabled = false;
                //        else if (frm.Controls[row["Control_Name"].ToString()] is HCheckbox) (frm.Controls[row["Control_Name"].ToString()] as HCheckbox).Enabled = false;
                //        else if (frm.Controls[row["Control_Name"].ToString()] is HComboBox) (frm.Controls[row["Control_Name"].ToString()] as HComboBox).Enabled = false;



                //    }
                //    else
                //    {
                //          if (frm.Controls[row["Control_Name"].ToString()] is HCheckbox) (frm.Controls[row["Control_Name"].ToString()] as HCheckbox).Enabled  = true ;
                //          else if (frm.Controls[row["Control_Name"].ToString()] is HTextBox ) (frm.Controls[row["Control_Name"].ToString()] as HTextBox ).Enabled = true;
                //        else if (frm.Controls[row["Control_Name"].ToString()] is HComboBox) (frm.Controls[row["Control_Name"].ToString()] as HComboBox).Enabled = true ;


                //    }

                //}


                //  Clear(frm.Controls);


            }
            foreach (Control co in frm.Controls)
            {
                if (co is HTextBox)
                {
                    HTextBox ht = co as HTextBox;
                    if (ht.key == true) ht.Enabled = false; else ht.Enabled = true;


                }
                else if (co is HCheckbox)
                {
                    HCheckbox ht = co as HCheckbox;
                    ht.Enabled = true;


                }
                else if (co is HComboBox)
                {
                    HComboBox ht = co as HComboBox;
                    ht.Enabled = true;


                }
                else if (co is HGrid && co.Name != "List")
                    co.Enabled = true;
            }
            //hemaily 20may2013
            fillGrid(frm.Controls);

            frm.updateButtonsStatus();
            //hassan 26-6-2013
            frm.Controls[frm.NextCodeControl].Enabled = true;
            frm.Controls[frm.NextCodeControl].Focus();
            SendKeys.Send("+{TAB}");//ABUBAKR بتهنج الشاشة لم تدوس على زرارا الليست أول ما الشاشة تفتح لأول مرة 20-7-2013
            frm.Controls[frm.NextCodeControl].Enabled = false;
            frm.AfterGetRecord();
        }
        //heamily 20may2013
        void fillGrid(Control.ControlCollection control)
        {
            string sql = "select * from ";
            foreach (Control ctrl in control)
            {
                if (ctrl is HGrid)
                {
                    HGrid grd = ctrl as HGrid;
                    //hemaily 1june 2013
                    if (grd.Name != "List") grd.Rows.Clear(); //hassan 8/6 
                    if (grd.Name != "list" && grd.TableName != "" && grd.TableName != null)
                    {
                        #region البيانات التى ينطبق عليها الجملة من الشاشة
                        sql += " " + grd.TableName + "";
                        //sql += " where BranchCode=1 and InstCode=2";
                        sql += " where 1=1 " + getCriteria(frm) + "";
                        DataTable AllData = DataLayer.executeDataTable(sql);
                        #endregion

                        DataTable grdColumns = new DataTable();
                        foreach (DataGridViewColumn col in grd.Columns)
                        {
                            grdColumns.Columns.Add(col.Name);
                        }

                        int i = 0;
                        #region
                        foreach (DataRow dr in AllData.Rows)
                        {
                            grdColumns.Rows.Add(1);
                            foreach (DataColumn Allcol in AllData.Columns)
                            {
                                #region عمل لووب على كل عمود فى الداتا تابل الصغيرة التى بها الهيكل للجريد

                                foreach (DataColumn grdCol in grdColumns.Columns)
                                {

                                    if (grdCol.ColumnName == Allcol.ColumnName)
                                    {

                                        // grdColumns.Rows.Add(1);
                                        grdColumns.Rows[i][grdCol.ColumnName] = dr[Allcol.ColumnName];

                                    }

                                }
                                #endregion
                            }
                            i++;
                        }
                        #endregion
                        #region
                        int u = 0;
                        foreach (DataRow r in grdColumns.Rows)
                        {
                            grd.Rows.Add(1);
                            foreach (DataColumn col in grdColumns.Columns)
                            {
                                foreach (DataGridViewColumn grdcol in grd.Columns)
                                {
                                    if (col.ColumnName == grdcol.Name)
                                    {

                                        //if (grd.Columns[grdcol.Name].ValueType==DataType.Integer)
                                        if (grd.Columns[grdcol.Name].ValueType.Name == "Int32")
                                            grd.Rows[u].Cells[grdcol.Name].Value = Convert.ToInt32(grdColumns.Rows[u][grdcol.Name]);
                                        else if (grd.Columns[grdcol.Name].ValueType.Name == "DateTime")
                                        {
                                            grd.Rows[u].Cells[grdcol.Name].Value = Convert.ToDateTime(grdColumns.Rows[u][grdcol.Name]).ToString("dd/MM/yyyy");
                                        }
                                        else
                                        {
                                            grd.Rows[u].Cells[grdcol.Name].Value = grdColumns.Rows[u][grdcol.Name];
                                        }

                                    }
                                }
                            }
                            u++;
                        }
                        #endregion
                    }
            }
                else if (ctrl.Controls.Count != 0)
                {
                    fillGrid(ctrl.Controls);
                }
            }


        }

        public string Previous(string tableName, HTextBox co, string value, string criteria = "")
        {
            string code = "";
            try
            {
                if (value != "")
                {
                    string sql = @"Select top(1) isnull(" + co._FieldName + ",0) As PrevCode from " + tableName + " Where " + co._FieldName + " < " + value;
                    if (criteria != "") sql += " AND " + criteria;
                    sql += " Order BY " + co._FieldName + " desc";
                    code = DataLayer.Executescalar(sql);
                    if (code == null || code == "")
                    {
                        string sql2 = @"Select isnull(MIN(" + co._FieldName + "),0) As PrevCode  from " + tableName + " ";
                        if (criteria != "") sql2 += " Where " + criteria;
                        code = DataLayer.Executescalar(sql2);
                    }
                }
                else
                {
                    string sql = @"Select isnull(MIN(" + co._FieldName + "),0) As PrevCode  from " + tableName + " ";
                    if (criteria != "") sql += " Where " + criteria;
                    code = DataLayer.Executescalar(sql);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Exception : Previous()");
            }


            return code;

        }
        public string Next(string tableName, HTextBox co, string value, string criteria = "")
        {
            string code = "";

            try
            {
                if (value != "")
                {
                    string sql = @"Select top(1) isnull(" + co._FieldName + ",0) As NextCode from " + tableName + " Where " + co._FieldName + " > " + value + " ";
                    if (criteria != "") sql += " AND " + criteria;
                    code = DataLayer.Executescalar(sql);
                    if (code == null || code == "")
                    {
                        string sql2 = @"Select isnull(MAX(" + co._FieldName + "),0) As NextCode from " + tableName + " ";
                        if (criteria != "") sql2 += " Where " + criteria;
                        code = DataLayer.Executescalar(sql2);
                    }
                }
                else
                {
                    string sql = @"Select isnull(MAX(" + co._FieldName + "),0) As NextCode from " + tableName + " ";
                    if (criteria != "") sql += " Where " + criteria;
                    code = DataLayer.Executescalar(sql);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Exception : Next()");

            }

            return code;

        }
        #endregion
        #region FillCombo
        public void fillCombo(DataForm frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is HComboBox)
                {
                    HComboBox co = ctrl as HComboBox;
                    if (co.TableName == "" || co.TableName == null) return;
                    else
                    {
                        string sql = @"   SELECT     COLUMN_NAME
                             FROM         INFORMATION_SCHEMA.COLUMNS
                             WHERE      (TABLE_NAME = '" + co.TableName + @"') and COLUMN_NAME = 'NotActive' ";
                        DataTable dt = DataLayer.executeDataTable(sql);


                        sql = "select * from " + co.TableName + " where 1=1 ";
                        if (dt.Rows.Count != 0)
                            sql += "  and isnull (NotActive,0) =0";
                        dt = DataLayer.executeDataTable(sql);
                        co.DataSource = dt;
                        //hemaily
                        co.SelectedIndex = -1;
                    }

                }
            }
        }
        #endregion
        #region updateFooterTable
        public void updateFooterTable(string header, string footer, DataForm frm)
        {
            string sql = "";

            if (frm.FormType == "FooterFormWithContol")
            {


                frm.recordMode = DataForm.RecordMode.Insert;


                #region  Create insert stament
                try
                {
                    foreach (Control ctrl in frm.Controls)
                        if (ctrl is HGrid && ctrl.Name != "List")
                        {
                            HGrid grd = ctrl as HGrid;
                            string sql_del = "delete from " + frm.TableName + " where 1=1 " + getCriteria(frm) + "";
                            DataLayer.executeNonQuery(sql_del);
                            // mohamed samir 28/9/2013
                            foreach (DataGridViewRow r in grd.Rows)
                            {
                                string[] InsStr = CreateSqlStatement().Split(new string[] { "(", "Values", ")" }, StringSplitOptions.None);



                                if (isEmptyRow(grd, r.Index) == false)
                                {

                                    foreach (DataGridViewColumn col in grd.Columns)
                                    {
                                        InsStr[1] += "," + col.Name;
                                        //hemaily 31may2013 اضافة سينجل كوت
                                        if (col.ValueType == typeof(string) || col.ValueType == null)
                                            InsStr[4] += ",'" + r.Cells[col.Name].Value + "'";
                                        if (col.ValueType == typeof(DateTime))
                                            InsStr[4] += ",'" + Convert.ToDateTime(r.Cells[col.Name].Value.ToString()).ToString("dd/MM/yyyy") + "'";
                                        else if (col.ValueType == typeof(Single) || col.ValueType == typeof(decimal) || col.ValueType == typeof(int) || col.ValueType == typeof(Boolean))
                                        {
                                            InsStr[4] += "," + r.Cells[col.Name].Value + "";
                                        }
                                    }
                                    DataLayer.executeNonQuery(InsStr[0] + "(" + InsStr[1] + ") values (" + InsStr[4] + ")");

                                }
                            }
                        }
                }
                catch (Exception ex) { }
                #endregion

            }
            else
            {
                try
                {

                    // Mohamed samir 22/5/2013
                    string Exist = "0";
                    Exist = DataLayer.Executescalar(@"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = '" + footer + "' and column_name =  'BranchCode'");
                    string cri = "";
                    if (Exist == "1")
                    {
                        cri += " AND BranchCode = " + GlobalVariables.BranchCode;
                    }
                    // Mohamed samir 22/5/2013
                    sql = "delete from " + footer + " where 1=1 " + getCriteria(frm) + cri + "";
                    DataLayer.executeNonQuery(sql);
                    updateFooter(frm.Controls, header, footer);

                }
                catch (Exception ex) { }
            }
        }
        void updateFooter(Control.ControlCollection controls, string header, string footer)
        {
            DataTable keysAndValues = new DataTable();
            DataTable FieldsAndValues = new DataTable();
            //DataTable keysAndValues = new DataTable();
            int rowNumber = 0;
            string sql = "";
            string ExistFooter = "0";
            string ExistHeadre = "0";

            if (header != footer)
            {

                string sqlstat = CreateSqlStatement();
                DataLayer.ExecuteNonQuery(sqlstat);

            }

            #region فى حالة جدول واحد فقط
            ExistFooter = DataLayer.Executescalar(@"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = '" + footer + "' and column_name =  'BranchCode'");
            foreach (Control ctrl in controls)
            {
                //hemaily 18may2013

                if (ctrl is HGrid)
                {

                    HGrid grd = ctrl as HGrid;

                    // mohamed samir 28/9/2013
                    string Exist = "0";
                    Exist = DataLayer.Executescalar(@"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = '" + grd.TableName + "' and column_name =  'BranchCode'");
                    string cri = "";
                    if (Exist == "1")
                    {
                        cri += " AND BranchCode = " + GlobalVariables.BranchCode;
                    }

                    string sql_del = "delete from " + grd.TableName + " where 1=1 " + getCriteria(frm) + cri + "";
                    DataLayer.executeNonQuery(sql_del);
                    // mohamed samir 28/9/2013
                    foreach (DataGridViewRow r in grd.Rows)
                    {
                        if (isEmptyRow(grd, r.Index) == false)
                        {
                            sql = "insert into " + grd.TableName + "(";
                            if (frm.FormType == "FooterFormWithContol")
                            {
                                if (header == grd.TableName)
                                {
                                    FieldsAndValues = getFieldsAndValues();
                                    for (int i = 0; i < FieldsAndValues.Rows.Count; i++)
                                    {
                                        sql += "" + FieldsAndValues.Rows[i]["FieldName"] + ",";
                                    }
                                }
                                else
                                {
                                    keysAndValues = getKeysAndValues();
                                    for (int i = 0; i < keysAndValues.Rows.Count; i++)
                                    {
                                        sql += "" + keysAndValues.Rows[i]["KeyName"] + ",";
                                    }
                                }
                            }
                            else
                            {

                                keysAndValues = getKeysAndValues();
                                for (int i = 0; i < keysAndValues.Rows.Count; i++)
                                {
                                    sql += "" + keysAndValues.Rows[i]["KeyName"] + ",";
                                }
                            }
                            foreach (DataGridViewColumn col in grd.Columns)
                            {
                                if (col.Tag != "dontSafe")
                                sql += "" + col.Name + ",";

                            }

                            // Mohamed samir 22/5/2013
                            if (ExistFooter == "1")
                            {
                                sql += "BranchCode,";
                            }
                            // Mohamed samir 22/5/2013

                            sql = sql.Remove(sql.Length - 1); sql += ")";
                            sql += " values(";

                            if (frm.FormType == "FooterFormWithContol")
                            {
                                if (header == grd.TableName)
                                {
                                    for (int i = 0; i < FieldsAndValues.Rows.Count; i++)
                                    {
                                        sql += "'" + FieldsAndValues.Rows[i]["FieldValue"] + "',";
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < keysAndValues.Rows.Count; i++)
                                    {
                                        sql += "'" + keysAndValues.Rows[i]["KeyValue"] + "',";
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < keysAndValues.Rows.Count; i++)
                                {
                                    sql += "" + keysAndValues.Rows[i]["KeyValue"] + ",";
                                }
                            }
                            //int y = 0;
                            foreach (DataGridViewColumn col in grd.Columns)
                            {
                                //hemaily 31may2013 اضافة سينجل كوت
                                if (col.Tag != "dontSafe")
                                {

                                    if (col.ValueType == typeof(string))
                                        sql += "'" + grd.Rows[rowNumber].Cells[col.Name].Value + "',";
                                    else sql += "" + grd.Rows[rowNumber].Cells[col.Name].Value + ",";
                                }
                            }
                            // Mohamed samir 22/5/2013
                            if (ExistFooter == "1")
                            {
                                sql += "" + GlobalVariables.BranchCode + ",";
                            }
                            // Mohamed samir 22/5/2013
                            sql = sql.Remove(sql.Length - 1); sql += ")";
                            //sql = sql.Remove(sql.Length - 1);
                            //sql += ")";
                            DataLayer.executeNonQuery(sql);
                            rowNumber++;
                        }
                    }
                }
            #endregion

                else if (ctrl.Controls.Count != 0 && !(ctrl is HGrid))
                {
                    updateFooter(ctrl.Controls, header, footer);
                }



            }




        }
        public void fillFooterTable(DataForm frm, Control.ControlCollection Control)
        {
            foreach (Control ctrl in Control)
            {
                if (ctrl is HGrid)
                {
                    HGrid grd = ctrl as HGrid;
                    if(grd.TableName != null)
                    updateFooterTable(frm.TableName, grd.TableName, frm);
                }
                if (ctrl.Controls.Count != 0 && !(ctrl is HGrid))
                {
                    fillFooterTable(frm, ctrl.Controls);
                }

            }
        }
        #endregion


        // Mohamed Samir 8/6/2012
        #region User Permission

        public DataTable Get_User_Permission(int Userid, int ProgId)
        {
            DataTable dt = new DataTable();
            dt = DataLayer.ExecuteDataTable("Select [Insert],[Edit],[Delete] from PrgPer where UserId =" + GlobalVariables.UserId + " and ProgId= " + ProgId + " ");
            return dt;

        }

        public int get_progId(string Formname)
        {
            //hemaily 13aug
            int progid = 0;
            string sql = "select isnull(ProgId,0) from Programs where FormName = '" + Formname + "'";
            DataTable dt = DataLayer.ExecuteDataTable(sql);
            if (dt.Rows.Count != 0)
            { progid = Convert.ToInt16(dt.Rows[0][0].ToString()); return progid; }
            else { return progid; }
        }

        public int Get_Records_num(string frmName)
        {
            int count = int.Parse(DataLayer.Executescalar(" Select isnull(Count(*),0) from " + frmName, ""));
            return count;
        }
        #endregion
        // Mohamed Samir 8/6/2012


        public string getCriteria(DataForm frm)
        {
            string critria = "";
            string Exist = "0";
            Exist = DataLayer.Executescalar(@"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = '" + frm.TableName + "' and column_name =  'BranchCode'");

            if (Exist == "1")
            {
                critria += " AND BranchCode = " + GlobalVariables.BranchCode;
            }
            foreach (Control co in frm.Controls)
            {
                #region textbox

                if (co is HTextBox)
                {

                    HTextBox ht = co as HTextBox;
                    if (ht.FieldName != "" && ht.Text != "")
                    {
                        if (ht.key == true)
                        {
                            if (ht.DataType.ToString() != "DateTime")
                                critria += " and " + ht.FieldName + " = '" + ht.Text + "'";
                            //  else critria += " and "+ht.FieldName+"=convert(datetime,'"+ht.Text +"',102)";
                            else critria += " and " + ht.FieldName + "=convert(datetime,'" + Convert.ToDateTime(ht.Text).ToString("dd/MM/yyyy") + "',103)";
                        }
                    }
                }
                #endregion
            }
            return critria;
        }

        DataTable getKeysAndValues()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            List<string> keys = new List<string>();
            DataTable dt = new DataTable();
            dt.Columns.Add("KeyName");
            dt.Columns.Add("KeyValue");
            foreach (Control co in frm.Controls)
            {
                #region textbox

                if (co is HTextBox)
                {

                    HTextBox ht = co as HTextBox;
                    if (ht.key == true)
                    {
                        keys.Add(ht._FieldName);
                        dic.Add(ht._FieldName, ht.Text);
                        DataRow dr = dt.NewRow();
                        dr["KeyName"] = ht.FieldName;
                        dr["KeyValue"] = ht.Text;
                        dt.Rows.Add(dr);

                    }
                }
                #endregion
            }
            return dt;
        }

        DataTable getFieldsAndValues()
        {
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //List<string> Fields = new List<string>();
            DataTable dt = new DataTable();
            dt.Columns.Add("FieldName");
            dt.Columns.Add("FieldValue");
            foreach (Control co in frm.Controls)
            {
                #region textbox

                if (co is HTextBox)
                {

                    HTextBox ht = co as HTextBox;
                    if (!(ht is HGrid) && ht.FieldName != null && (ht is HTextBox || ht is HCheckbox))
                    {
                        DataRow dr = dt.NewRow();
                        dr["FieldName"] = ht.FieldName;
                        dr["FieldValue"] = ht.Text;
                        dt.Rows.Add(dr);
                    }
                    //        
                }
                #endregion
            }
            return dt;
        }

        bool isEmptyRow(HGrid grd, int RowIndex)
        {
            if (grd.Rows[RowIndex].Cells[0].Value == null)
            {
                return true;
            }
            return false;
        }
    }

}