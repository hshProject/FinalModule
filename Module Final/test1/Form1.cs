using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(@"Quarterly_orders.xml");
            // Databinding
            hGrid1 .DataSource = ds.Tables[0];

            // Use of the DataGridViewColumnSelector
            
           
        }

        private void hGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hGrid1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void hGrid1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
