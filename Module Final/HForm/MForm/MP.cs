using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HForm
{
    public partial class MP : Form
    {
        // FileManager file;
        public MP()
        {
            InitializeComponent();
            FileManager.fillMenu(menu);

        }

        DataTable Items = new DataTable();
        private void MP_Load(object sender, EventArgs e)
        {

        }

        private void MP_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



    }

}