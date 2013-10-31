using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
 
 
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
namespace HForm
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void getConfigurations()
        {
            //string _conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        void setConfigurations()
        {
            GlobalVariables.Server = txtServer.Text;
            GlobalVariables.DBName = txtDBName.Text;
            GlobalVariables.UserName = txtUserName.Text;
            GlobalVariables.password = txtPassword.Text;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            setConfigurations();

            ClasConfig.updateConfiguration();
            if (DataLayer.goodConfiguration())
            {
                this.Hide();
                MP frm = new MP();
                frm.Show();

            }
            else
            {
                //MyModule.MP frm = new MyModule.MP();
                //frm.Show();

            }
            MessageBox.Show("تم الحفظ");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            NameValueCollection appSettings = ConfigurationSettings.AppSettings;
            if (appSettings.Count>0 && appSettings[0] != null && appSettings[1] != "")
                txtDBName.Text = appSettings[0];
            if (appSettings.Count>1 && appSettings[1] != null && appSettings[1] != "")
                txtServer.Text = appSettings[1];
            if (appSettings.Count>2 && appSettings[2] != null && appSettings[2] != "")
                txtUserName.Text = appSettings[2];
            if (appSettings.Count>3 && appSettings[3] != null && appSettings[3] != "")
                txtPassword.Text = appSettings[3];
            txtDBSecName.Text = txtDBName.Text;
        }


    }

}