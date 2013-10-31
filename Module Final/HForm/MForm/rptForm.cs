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
    public partial class rptForm : Form
    {
        public rptForm()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        public virtual void Print()
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rptForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnPrint_Click(null, null);
            }
            if (e.KeyCode == Keys.F10)
            {
                btnExit_Click(null, null);
            }
        }

    }

}