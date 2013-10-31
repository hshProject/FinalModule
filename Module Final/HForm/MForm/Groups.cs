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
    public partial class Groups : DataForm
    {

        public Groups()
        {
            InitializeComponent();
        }

        private void Groups_Load(object sender, EventArgs e)
        {
            this.NextCodeControl = txtGroupID.Name;
            binder.NextCode(NextCodeControl, "");

        }

        private void txtGroupID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtGroupID.Text != "")
            { GetRecord(); }
        }
    }
}
