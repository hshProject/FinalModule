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

    public partial class frmBranches : DataForm
    {
        public frmBranches()
        {
            InitializeComponent();
        }

        private void frmBranches_Load(object sender, EventArgs e)
        {
            this.NextCodeControl = txtBranchCode.Name;
            binder.NextCode(this.NextCodeControl, "");
        }

        private void txtRelationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBranchCode.Text != null && txtBranchCode.Text != "")
                GetRecord();
        }

    }
}
