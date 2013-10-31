using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
//using DevComponents.DotNetBar.Controls;
//using DevComponents.DotNetBar;
using System.Configuration;

namespace HForm
{
    public class clasMain
    {

        public clasMain()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public clasMain(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        SqlConnection connection;
        SqlCommand command;
        DataTable datatable;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        string connectionString;
        bool commandCase;
        static List<Form> FormsOpen;

        public SqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public SqlCommand Command
        {
            get { return command; }
            set { command = value; }
        }

        public DataTable dataTable
        {
            get { return datatable; }
            set { datatable = value; }
        }

        public SqlDataReader Reader
        {
            get { return reader; }
            set { reader = value; }
        }

        public SqlDataAdapter Adapter
        {
            get { return adapter; }
            set { adapter = value; }
        }

        public static Form FormOpen
        {
            get;
            set;
        }

        public bool CommandCase
        {
            get { return commandCase; }
            set { commandCase = value; }
        }

        public static void AlignControl(Panel bodyPanel, Button backButton)
        {
            bodyPanel.Top = (Screen.PrimaryScreen.Bounds.Height - bodyPanel.Height) / 2;
            bodyPanel.Left = (Screen.PrimaryScreen.Bounds.Width - bodyPanel.Width) / 2;

            backButton.Top = (Screen.PrimaryScreen.Bounds.Height - backButton.Height) - 25;
            backButton.Left = (Screen.PrimaryScreen.Bounds.Width - backButton.Width) - 25;
        }


        public static void AlignControl(Panel bodyPanel, Button backButton, UserControl userControl)
        {
            bodyPanel.Top = ((Screen.PrimaryScreen.Bounds.Height - bodyPanel.Height) / 2);
            bodyPanel.Left = (Screen.PrimaryScreen.Bounds.Width - (bodyPanel.Width + userControl.Width)) / 2;

            backButton.Top = (Screen.PrimaryScreen.Bounds.Height - backButton.Height) - 65;
            backButton.Left = (Screen.PrimaryScreen.Bounds.Width - backButton.Width) - 25;

            userControl.Top = ((Screen.PrimaryScreen.Bounds.Height - userControl.Height) / 2) - 40;
            userControl.Left = (Screen.PrimaryScreen.Bounds.Width - userControl.Width) - 25;
        }


        public static void SaveError(string formName, int errorNumber, string errorMessage)
        {
            string message = string.Format("{0}  {1}  {2}  {3}", formName, DateTime.Now, errorNumber, errorMessage);
            StreamWriter sw = new StreamWriter(@"c:\Lawer\Errors.txt", true);
            sw.WriteLine(message);
            sw.WriteLine("------------------------------------------------------");
            sw.Close();
        }

        public DataTable SelectAllData(string SqlStatmnt)
        {
            command = new SqlCommand();
            command.CommandText = SqlStatmnt;
            datatable = new DataTable();
            connection.Close();
            command.Connection = connection;
            connection.Open();
            datatable.Load(command.ExecuteReader());
            connection.Close();

            return datatable;
        }

        public void SelectAllData(string SqlStatmnt, ComboBox myCombo, string DisplayMember, string ValueMember)
        {
            command = new SqlCommand();
            command.CommandText = SqlStatmnt;
            datatable = new DataTable();
            connection.Close();
            command.Connection = connection;
            connection.Open();
            datatable.Load(command.ExecuteReader());
            connection.Close();
            if (datatable.Rows.Count > 0)
            {
                myCombo.DataSource = datatable;
                myCombo.DisplayMember = DisplayMember;
                myCombo.ValueMember = ValueMember;
                myCombo.SelectedIndex = -1;
            }

        }

        //public void SelectAllData(string SqlStatmnt, ComboBoxEx myCombo, string DisplayMember, string ValueMember)
        // {
        //     command = new SqlCommand();
        //     command.CommandText = SqlStatmnt;
        //     datatable = new DataTable();
        //     connection.Close();
        //     command.Connection = connection;
        //     connection.Open();
        //     datatable.Load(command.ExecuteReader());
        //     connection.Close();
        //     if (datatable.Rows.Count > 0)
        //     {

        //         myCombo.DataSource = datatable;
        //         myCombo.DisplayMember = DisplayMember;
        //         myCombo.ValueMember = ValueMember;
        //         myCombo.SelectedIndex = -1;
        //     }
        //     else
        //         myCombo.DataSource = datatable;

        // }

        public bool IsExpire()
        {
            commandCase = false;
            command.CommandText = "Select IsExpires from Setting";
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                commandCase = bool.Parse(reader[0].ToString());
            }
            reader.Close();
            connection.Close();
            return commandCase;
        }

        public void CheckExpire()
        {
            command.CommandText = "Select ExpiresDate from Setting";
            connection.Open();
            reader = command.ExecuteReader();
            DateTime date = DateTime.Now.Date;
            if (reader.Read())
            {
                date = Convert.ToDateTime(reader[0].ToString());
            }
            reader.Close();
            if (DateTime.Now.Date > date)
            {
                command.CommandText = "UPDATE Setting SET IsExpires = 1";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void ButtonStyle(Form form)
        {
            foreach (Control control in form.Controls)
            {
                Button button = control as Button;
                Panel panel = control as Panel;
                if (button != null)
                {
                    button.MouseHover += new EventHandler(ButtonMouseOver);
                    button.MouseUp += new MouseEventHandler(ButtonMouseUp);

                }
            }
        }

        public void RunQuery(string query)
        {
            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void AddFormsOpen(Form form)
        {
            FormsOpen = new List<Form>();
            FormsOpen.Add(form);
        }

        public static Form FormBack()
        {
            return FormsOpen[FormsOpen.Count - 1];
        }

        private static void ButtonMouseOver(object sender, EventArgs e)
        {

        }

        private static void ButtonMouseUp(object sender, EventArgs e)
        {

        }

    }

}