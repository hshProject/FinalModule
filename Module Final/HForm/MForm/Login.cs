using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;



namespace HForm
{

    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {


            cmbBranch.DataSource = DataLayer.ExecuteDataTable("select BranchCode,BranchName from Branches");
            cmbBranch.DisplayMember = "BranchName";
            cmbBranch.ValueMember = "BranchCode";
            UserName.Focus();
            this.AcceptButton = btnlogin;
            UserName.Focus();


        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            if (cmbBranch.SelectedValue == null || cmbBranch.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("لابد من اختيار الفرع");
                cmbBranch.Focus();
                return;
            }
            else
            {

                string Name = UserName.Text;
                string pass = Password.Text;
                DataTable password = DataLayer.validUserName(Name);
                if (password.Rows.Count > 0 && password.Rows[0]["UserPassword"].ToString() == pass)
                {
                    lblInvaild.Visible = false;
                    GlobalVariables.UserId = int.Parse(DataLayer.ExecuteDataTable("SELECT     UserId, UserAraName FROM         Users WHERE     (UserAraName = N'" + Name + "')").Rows[0][0].ToString());
                    GlobalVariables.UserName = UserName.Text;
                    GlobalVariables.BranchCode = int.Parse(cmbBranch.SelectedValue.ToString());
                    GlobalVariables.BranchName = cmbBranch.SelectedText.ToString();
                    SetGlobalVariables();
                    MP main = new MP();
                    main.Show();
                    this.Hide();

                }
                else
                {
                    lblInvaild.Visible = true;
                    GlobalVariables.UserName = "";
                    GlobalVariables.BranchCode = 0;
                    GlobalVariables.BranchName = "";
                }


            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            Password.Text = "";
            this.Close();
            Application.Exit();

        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                UserName.Text = "Admin";
                Password.Text = "123";
                cmbBranch.SelectedIndex = 0;
                btnlogin_Click(null, null);
            }
        }

        /*  public  bool CreateSqlExpressDatabase(string filename)
          {
              try
              {
               
                  string databaseName = System.IO.Path.GetFileNameWithoutExtension(filename);
                  using (var connection = new SqlConnection(
                      "Data Source=.;Initial Catalog=tempdb;" +
                      "Integrated Security=true;"))
                  {
                      connection.Open();
                      using (var command = connection.CreateCommand())
                      {

                          command.CommandText = @"RESTORE FILELISTONLY FROM DISK='"+filename+"'";
                          command.ExecuteNonQuery();

                          command.CommandText = @" RESTORE DATABASE "+databaseName+@"
    FROM DISK='"+filename+@"'

    WITH MOVE'hsh' TO '" + Application.StartupPath + "\\" + databaseName + @"_Data.MDF',
    MOVE 'hsh_log' TO'" + Application.StartupPath + "\\" + databaseName + @"_LOG.LDF'";
                          command.ExecuteNonQuery();
              
                      }
                  }
                  return true;
              }
              catch (Exception)
              {
                  MessageBox.Show("Can't Create dataBase");
                  return false;

              }
           
          }
          */
        void SetGlobalVariables()
        {
            NameValueCollection appSettings = ConfigurationSettings.AppSettings;
            GlobalVariables.DBName = appSettings[0];
            GlobalVariables.Server = appSettings[1];
            GlobalVariables.UserName = appSettings[2];
            GlobalVariables.password = appSettings[3];
        }
    }



}