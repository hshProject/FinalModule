using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using HControls;
using System.Management;

namespace HForm
{
    public static class DataLayer
    {

        private static SqlCommand _cmd = new SqlCommand();
        public static SqlConnection Connection = new SqlConnection();
        public static SqlDataAdapter DA = new SqlDataAdapter();
        public static string _conString;


        public static bool register_()
        {
            string data = "";
            #region Serial HardDisk

            ManagementObjectSearcher mosa = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            foreach (ManagementObject managementObjecta in mosa.Get())
            {
                if (managementObjecta["SerialNumber"] != null)
                {
                    data += managementObjecta["SerialNumber"].ToString();
                }
            }

            data = SecurityHelper_Lat.Encrypt(data);
            #endregion
            bool exist = false;
            string sql = "Select * from Serial";
            DataTable dt = DataLayer.ExecuteDataTable(sql);
            if (dt.Rows.Count > 0)
            {
               // string serial = dt.Rows[0]["Serial"].ToString();
                string registercode = dt.Rows[0]["RegisterCode"].ToString();
                int attempt = int.Parse(dt.Rows[0]["Attempt"].ToString());

                if (attempt >= 5)
                {
                    Application.Exit();
                    exist = false;
                }
                string register = SecurityHelper_Lat.Encrypt_Serial(data);
                if (registercode.Trim() == register.Trim())
                {
                    exist = true;
                }
            }
            return exist;
        }


        public static void CreateConnectionString()
        {
            //_conString += "Data Source=" + ConfigurationSettings.AppSettings["Server"];
            //_conString += ";Initial Catalog=" + ConfigurationSettings.AppSettings["dataBases"];
            //_conString += "; User ID=" + ConfigurationSettings.AppSettings["UserID"];
            //_conString += "; Password=" + ConfigurationSettings.AppSettings["Password"];
            //ConString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
            //Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            //_conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            _conString = ProcessXML.clientConnectionString();


        }

        public static SqlCommand Cmd
        {
            get { return _cmd; }
            set
            {
                Connection = new SqlConnection();
                _cmd = new SqlCommand("", Connection);

            }

        }

        public static void executeNonQuery(string sql)
        {
            Cmd = new SqlCommand();
            Cmd.CommandText = sql;
            DataTable datatable = new DataTable();
            Connection.Close();
            Connection = new SqlConnection(_conString);
            Cmd.Connection = Connection;
            Connection.Open();
            Cmd.ExecuteNonQuery();
            Connection.Close();

            // return datatable;
        }

        public static DataTable executeDataTable(string sql)
        {
            try
            {
                //_conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                //_conString=ConfigurationSettings.AppSettings["name"].ToString();
                Cmd = new SqlCommand();
                Cmd.CommandText = sql;
                DataTable datatable = new DataTable();
                Connection.Close();
                Connection = new SqlConnection(_conString);
                Cmd.Connection = Connection;
                Connection.Open();
                datatable.Load(Cmd.ExecuteReader());
                Connection.Close();
                return datatable;
            }
            catch (Exception)
            {

                MessageBox.Show("Ex : executeDataTable ()");
                return null;
            }


        }


        public static bool goodConfiguration()
        {
            //_conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            // _conString = "Data Source=+" + GlobalVariables.Server + ";Initial Catalog=" + GlobalVariables.DBName + ";User ID=" + GlobalVariables.UserName + ";Password=" + GlobalVariables.password + "\"";
            NameValueCollection appSettings = ConfigurationSettings.AppSettings;
            if (appSettings.Count == 0)
            {
                //hemaily 20Oct2013
                return false;
            }
            else
            {
                _conString = "Data Source=" + appSettings[1] + ";Initial Catalog=" + appSettings[0] + ";User ID=" + appSettings[2] + ";Password=" + appSettings[3] + "";
                Connection = new SqlConnection(_conString);
                try { Connection.Open(); return true; }
                catch { return false; }
                finally { Connection.Close(); }
            }
        }

        public static void fillCombo(HComboBox cmb, string criteria)
        {
            try
            {

                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                DataTable datatable = new DataTable();
                // Connection.Open();
                string sql = "select * from " + cmb.TableName + " Where 1 = 1 ";
                if (criteria != "")
                {
                    sql += "And " + criteria;
                }
                DataTable dt = DataLayer.executeDataTable(sql);
                cmb.DataSource = dt;
                //  cmb.DataSource = datatable;
                cmb.SelectedIndex = -1;
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(" Exception FillCombo");
                return;
            }

        }

        public static DataTable ExecuteDataTable(string sql, string criteria = "")
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            if (criteria != "")
            { sql += " Where 1=1  And " + criteria + ""; }
            Connection = new SqlConnection(_conString);
            SqlCommand Cmd = new SqlCommand(sql, Connection);
            Cmd.CommandType = CommandType.Text;
            SqlDataAdapter dt = new SqlDataAdapter(Cmd);
            DataTable data = new DataTable();
            dt.Fill(data);
            dt.Dispose();
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            return data;
        }

        public static string Executescalar(string sql, string criteria = "")
        {

            if (criteria != "")
            { sql += " Where 1=1  And " + criteria + ""; }
            Connection = new SqlConnection(_conString);
            SqlCommand Cmd = new SqlCommand(sql, Connection);
            Cmd.CommandType = CommandType.Text;
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            SqlDataAdapter dt = new SqlDataAdapter(Cmd);
            DataTable data = new DataTable();
            Cmd.ExecuteScalar();
            string code;
            dt.Fill(data);
            if (data.Rows.Count > 0)
                code = data.Rows[0][0].ToString();
            else
                code = null;
            dt.Dispose();
            Connection.Close();
            return code;
        }

        public static int ExecuteNonQuery(string sql, string criteria = "")
        {
            try
            {
                Connection = new SqlConnection(_conString);
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                if (criteria != "")
                { sql += " Where 1=1  And " + criteria + ""; }
                SqlCommand Cmd = new SqlCommand(sql, Connection);
                Cmd.CommandType = CommandType.Text;
                int rows = Cmd.ExecuteNonQuery();
                return rows;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString()); return 0;
            }
            //            MessageBox.Show(ex.Number.ToString()); return 0; }
        }

        public static void SelectAllData(string SqlStatmnt, ComboBox myCombo, string DisplayMember, string ValueMember)
        {
            SqlCommand command = new SqlCommand(SqlStatmnt, Connection);
            command.CommandText = SqlStatmnt;
            DataTable datatable = new DataTable();
            Connection = new SqlConnection(_conString);
            Connection.Close();
            command.Connection = Connection;
            Connection.Open();
            datatable.Load(command.ExecuteReader());
            Connection.Close();
            if (datatable.Rows.Count > 0)
            {
                myCombo.DataSource = datatable;
                myCombo.DisplayMember = DisplayMember;
                myCombo.ValueMember = ValueMember;
                myCombo.SelectedIndex = -1;
            }
        }

        public static DataTable validUserName(string UserName)
        {
            DataTable data = new DataTable();
            try
            {
                string sql = @"Select  UserPassword from Users where UserAraName = '" + UserName + "' and isnull(NotActive,0) = 0";
                data = ExecuteDataTable(sql);
                return data;
            }
            catch (Exception)
            {
                MessageBox.Show("Exception : validUserName ()");
                return data;

            }

        }

        #region Create DataBase Stored Procedures

        public static bool CreateInsertStoredProcedures()
        {
            try
            {
                string table = "SELECT name FROM sys.Tables";
                DataTable tables = ExecuteDataTable(table);
                if (tables.Rows.Count > 0)
                {
                    for (int i = 0; i < tables.Rows.Count; i++)
                    {
                        string column = @"SELECT column_name,DATA_TYPE,is_nullable,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = " + tables.Rows[i]["name"];
                        DataTable columns = ExecuteDataTable(column);
                        string procedure = @" Create Procedure SP_Insert_" + tables.Rows[i]["name"] + " ( ";
                        for (int c = 0; c < columns.Rows.Count; c++)
                        {
                            procedure += "   @" + columns.Rows[c]["column_name"] + "   " + columns.Rows[c]["DATA_TYPE"] + "";

                            // if column without precition
                            if (columns.Rows[c]["DATA_TYPE"].ToString() == "bigint" || columns.Rows[c]["DATA_TYPE"].ToString() == "int" || columns.Rows[c]["DATA_TYPE"].ToString() == "smallint" || columns.Rows[c]["DATA_TYPE"].ToString() == "tinyint"
                                || columns.Rows[c]["DATA_TYPE"].ToString() == "bit" || columns.Rows[c]["DATA_TYPE"].ToString() == "datetime" || columns.Rows[c]["DATA_TYPE"].ToString() == "smalldatetime" || columns.Rows[c]["DATA_TYPE"].ToString() == "smallmoney"
                                || columns.Rows[c]["DATA_TYPE"].ToString() == "money" || columns.Rows[c]["DATA_TYPE"].ToString() == "real" || columns.Rows[c]["DATA_TYPE"].ToString() == "text")
                            {
                                procedure += " ";
                            }
                            else
                            {
                                // if column with precision and scale
                                if (columns.Rows[c]["DATA_TYPE"].ToString() == "numeric" || columns.Rows[c]["DATA_TYPE"].ToString() == "decimal")
                                {
                                    procedure += "(" + columns.Rows[c]["NUMERIC_PRECISION"] + "," + columns.Rows[c]["NUMERIC_SCALE"] + ")";
                                }
                                else
                                {
                                    // if column with precision 
                                    if (columns.Rows[c]["NUMERIC_PRECISION"].ToString() == "-1")
                                    { procedure += "(MAX)"; }
                                    else
                                    {
                                        procedure += "(" + columns.Rows[c]["NUMERIC_PRECISION"] + ") ";
                                    }
                                }
                            }

                            if (columns.Rows[c]["is_nullable"].ToString() == "YES")
                            {
                                procedure += " = null ";
                            }
                            procedure += " ,";
                        }
                        procedure = procedure.Remove(procedure.Length - 1);
                        procedure += " )  As   Begin  ";
                        procedure += "Insert into " + tables.Rows[i]["name"] + " (";
                        for (int l = 0; l < columns.Rows.Count; l++)
                        {
                            procedure += "" + columns.Rows[l]["column_name"] + ",";
                        }
                        procedure = procedure.Remove(procedure.Length - 1);
                        procedure += ") Values (";
                        for (int m = 0; m < columns.Rows.Count; m++)
                        {
                            procedure += "   @" + columns.Rows[m]["column_name"] + ",";
                        }
                        procedure = procedure.Remove(procedure.Length - 1);
                        procedure += " )  End ";

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can'\t Create Insert Procedures for tables");
                return false;
            }
            return true;
        }

        public static bool CreateUpdateStoredProcedures()
        {
            try
            {
                string table = "SELECT name FROM sys.Tables";
                DataTable tables = ExecuteDataTable(table);
                if (tables.Rows.Count > 0)
                {
                    for (int i = 0; i < tables.Rows.Count; i++)
                    {
                        string column = @"SELECT column_name,DATA_TYPE,is_nullable,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE table_name = " + tables.Rows[i]["name"];
                        DataTable columns = ExecuteDataTable(column);
                        string procedure = @" Create Procedure SP_Update_" + tables.Rows[i]["name"] + " ( ";
                        for (int c = 0; c < columns.Rows.Count; c++)
                        {
                            procedure += "   @" + columns.Rows[c]["column_name"] + "   " + columns.Rows[c]["DATA_TYPE"] + "";

                            // if column without precition
                            if (columns.Rows[c]["DATA_TYPE"].ToString() == "bigint" || columns.Rows[c]["DATA_TYPE"].ToString() == "int" || columns.Rows[c]["DATA_TYPE"].ToString() == "smallint" || columns.Rows[c]["DATA_TYPE"].ToString() == "tinyint"
                                || columns.Rows[c]["DATA_TYPE"].ToString() == "bit" || columns.Rows[c]["DATA_TYPE"].ToString() == "datetime" || columns.Rows[c]["DATA_TYPE"].ToString() == "smalldatetime" || columns.Rows[c]["DATA_TYPE"].ToString() == "smallmoney"
                                || columns.Rows[c]["DATA_TYPE"].ToString() == "money" || columns.Rows[c]["DATA_TYPE"].ToString() == "real" || columns.Rows[c]["DATA_TYPE"].ToString() == "text")
                            {
                                procedure += " ";
                            }
                            else
                            {
                                // if column with precision and scale
                                if (columns.Rows[c]["DATA_TYPE"].ToString() == "numeric" || columns.Rows[c]["DATA_TYPE"].ToString() == "decimal")
                                {
                                    procedure += "(" + columns.Rows[c]["NUMERIC_PRECISION"] + "," + columns.Rows[c]["NUMERIC_SCALE"] + ")";
                                }
                                else
                                {
                                    // if column with precision 
                                    if (columns.Rows[c]["NUMERIC_PRECISION"].ToString() == "-1")
                                    { procedure += "(MAX)"; }
                                    else
                                    {
                                        procedure += "(" + columns.Rows[c]["NUMERIC_PRECISION"] + ") ";
                                    }
                                }
                            }

                            if (columns.Rows[c]["is_nullable"].ToString() == "YES")
                            {
                                procedure += " = null ";
                            }
                            procedure += " ,";
                        }
                        procedure = procedure.Remove(procedure.Length - 1);
                        procedure += " )  As   Begin  ";
                        procedure += " Update " + tables.Rows[i]["name"] + "  SET ";
                        for (int l = 0; l < columns.Rows.Count; l++)
                        {
                            procedure += "" + columns.Rows[l]["column_name"] + " = @" + columns.Rows[l]["column_name"] + ",";
                        }
                        procedure = procedure.Remove(procedure.Length - 1);
                        string KEY = @"SELECT column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                           WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1
                           AND table_name = '" + tables.Rows[i]["name"] + "'";
                        DataTable keys = executeDataTable(KEY);
                        if (keys.Rows.Count > 0)
                        {
                            procedure += " where  ";
                            for (int k = 0; k < keys.Rows.Count; k++)
                            {
                                procedure += " " + keys.Rows[i]["column_name"] + " =  @" + keys.Rows[i]["column_name"] + " And";
                            }
                            procedure = procedure.Remove(procedure.Length - 3);
                        }
                        procedure += "  End ";

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can'\t Create Update Procedures for tables");
                return false;
            }
            return true;
        }

        public static bool CreateDeleteStoredProcedures()
        {
            try
            {
                string table = "SELECT name FROM sys.Tables";
                DataTable tables = ExecuteDataTable(table);
                if (tables.Rows.Count > 0)
                {
                    for (int i = 0; i < tables.Rows.Count; i++)
                    {
                        string key = @"SELECT     INFORMATION_SCHEMA.KEY_COLUMN_USAGE.COLUMN_NAME, INFORMATION_SCHEMA.COLUMNS.NUMERIC_PRECISION, INFORMATION_SCHEMA.COLUMNS.NUMERIC_SCALE, 
                      INFORMATION_SCHEMA.COLUMNS.DATA_TYPE, INFORMATION_SCHEMA.COLUMNS.IS_NULLABLE, INFORMATION_SCHEMA.COLUMNS.CHARACTER_MAXIMUM_LENGTH, 
                      INFORMATION_SCHEMA.COLUMNS.TABLE_NAME
FROM         INFORMATION_SCHEMA.KEY_COLUMN_USAGE INNER JOIN
                      INFORMATION_SCHEMA.COLUMNS ON INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_SCHEMA = INFORMATION_SCHEMA.COLUMNS.TABLE_SCHEMA AND 
                      INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_CATALOG = INFORMATION_SCHEMA.COLUMNS.TABLE_CATALOG AND 
                      INFORMATION_SCHEMA.KEY_COLUMN_USAGE.COLUMN_NAME = INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME
WHERE     (OBJECTPROPERTY(OBJECT_ID(INFORMATION_SCHEMA.KEY_COLUMN_USAGE.CONSTRAINT_NAME), 'IsPrimaryKey') = 1)
AND INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = '" + tables.Rows[i]["name"] + "'";
                        DataTable columns = ExecuteDataTable(key);
                        string procedure = @" Create Procedure SP_Delete_" + tables.Rows[i]["name"] + " ( ";

                        if (columns.Rows.Count > 0)
                        {
                            for (int c = 0; c < columns.Rows.Count; c++)
                            {
                                procedure += "   @" + columns.Rows[c]["column_name"] + "   " + columns.Rows[c]["DATA_TYPE"] + "";

                                // if column without precition
                                if (columns.Rows[c]["DATA_TYPE"].ToString() == "bigint" || columns.Rows[c]["DATA_TYPE"].ToString() == "int" || columns.Rows[c]["DATA_TYPE"].ToString() == "smallint" || columns.Rows[c]["DATA_TYPE"].ToString() == "tinyint"
                                    || columns.Rows[c]["DATA_TYPE"].ToString() == "bit" || columns.Rows[c]["DATA_TYPE"].ToString() == "datetime" || columns.Rows[c]["DATA_TYPE"].ToString() == "smalldatetime" || columns.Rows[c]["DATA_TYPE"].ToString() == "smallmoney"
                                    || columns.Rows[c]["DATA_TYPE"].ToString() == "money" || columns.Rows[c]["DATA_TYPE"].ToString() == "real" || columns.Rows[c]["DATA_TYPE"].ToString() == "text")
                                {
                                    procedure += " ";
                                }
                                else
                                {
                                    // if column with precision and scale
                                    if (columns.Rows[c]["DATA_TYPE"].ToString() == "numeric" || columns.Rows[c]["DATA_TYPE"].ToString() == "decimal")
                                    {
                                        procedure += "(" + columns.Rows[c]["NUMERIC_PRECISION"] + "," + columns.Rows[c]["NUMERIC_SCALE"] + ")";
                                    }
                                    else
                                    {
                                        // if column with precision 
                                        if (columns.Rows[c]["NUMERIC_PRECISION"].ToString() == "-1")
                                        { procedure += "(MAX)"; }
                                        else
                                        {
                                            procedure += "(" + columns.Rows[c]["NUMERIC_PRECISION"] + ") ";
                                        }
                                    }
                                }

                                if (columns.Rows[c]["is_nullable"].ToString() == "YES")
                                {
                                    procedure += " = null ";
                                }
                                procedure += " ,";
                            }
                            procedure = procedure.Remove(procedure.Length - 1);
                            procedure += " )  As   Begin  ";
                        }
                        procedure += " Delete from " + tables.Rows[i]["name"] + " Where ";
                        if (columns.Rows.Count > 0)
                        {
                            for (int k = 0; k < columns.Rows.Count; k++)
                            {
                                procedure += " " + columns.Rows[i]["column_name"] + " =  @" + columns.Rows[i]["column_name"] + " And";
                            }
                        }
                        procedure = procedure.Remove(procedure.Length - 3);
                        procedure += "  End ";

                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Can'\t Create Delete Procedures for tables");
                return false;
            }
            return true;
        }


        #endregion
    }

    public class ProcessXML
    {
        public static void AddAppSettingElement(string elementName, string NewValue)
        {
            string element = (elementName + "En");
            string value = (NewValue + "St");
            // Open App.Config of executable
            System.Configuration.Configuration config =
    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Add an Application Setting.
            config.AppSettings.Settings.Add(element, value);
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified, true);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");

        }

        public static void updateAppSettingsElement(string elementName, string NewValue)
        {
            string element = (elementName + "En");
            string value = (NewValue + "St");
            // Open App.Config of executable
            System.Configuration.Configuration config =
    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Add an Application Setting.
            config.AppSettings.Settings[element].Value = value;
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified, true);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");

        }

        public static string getAppSettingsElement(string elementName)
        {
            if (IsExcist(elementName))
            {
                string element = (elementName + "En");
                NameValueCollection name_values
                     = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection("appSettings");
                string elementValue = (name_values[element].ToString());
                elementValue = elementValue.Remove(elementValue.Length - 2);
                return elementValue;
            }
            else
                return "";
        }

        public static string[,] getAppSettingsElements()
        {
            try
            {
                NameValueCollection name_values
                  = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection("appSettings");
                string[] keys = name_values.AllKeys;

                string[,] elements = new string[name_values.Count, 2];
                //----
                for (int i = 0; i < keys.Length; i++)
                {
                    string elementName = "";
                    try
                    {
                        elementName = elementName.Remove(elementName.Length - 2);
                    }
                    catch (Exception)
                    {

                        elementName = keys[i];
                    }


                    elements[i, 0] = elementName;
                    elements[i, 1] = getAppSettingsElement(elementName);
                }

                return elements;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return null;
            }


        }

        public static bool IsExcist(string elementName)
        {
            string element = (elementName + "En");
            NameValueCollection name_values
                  = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection("appSettings");
            string[] keys = name_values.AllKeys;
            foreach (string item in keys)
            {
                if (item == element)
                {
                    return true;
                }
            }
            return false;
        }

        public static string saveAppSettingElement(string elementName, string NewValue)
        {
            if (IsExcist(elementName))
            {
                updateAppSettingsElement(elementName, NewValue);
                return null;
            }
            else
            {
                AddAppSettingElement(elementName, NewValue);

            }
            return null;
        }

        public static void removeAppSettingElement(string elementName)
        {
            if (IsExcist(elementName))
            {
                string element = (elementName + "En");
                System.Configuration.Configuration config =
    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Remove an Application Setting.
                config.AppSettings.Settings.Remove(element);
                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified, true);
                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");

            }
        }

        public static string clientConnectionString()
        {
            string Connstr = "Data Source=" + getAppSettingsElement("ServerName").Trim() + ";Initial Catalog=" + getAppSettingsElement("DataBase").Trim() + "; ";
            if (IsExcist("UserId") || IsExcist("UserPassword"))
            {
                Connstr += "User ID=" + getAppSettingsElement("UserId").Trim() + ";Password=" + getAppSettingsElement("UserPassword") + "";
            }
            else
            {
                Connstr += "Integrated Security=True";

            }
            return Connstr;
        }
        

    }
}

