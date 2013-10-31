using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HControls
{
    public delegate void degkeypressdialog(Keys key, ref object sender);
    public partial class HGrid : DataGridView
    {
        ColumnSelector cs;
        RowEvents rv;
        //hemaily 20may 2013
        private string _TableName;

        [DefaultValue(typeof(string), ""),
       Category("|Data|")]
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
       

        public HGrid()
        {
            InitializeComponent();
            // Use of the DataGridViewColumnSelector
             cs = new ColumnSelector(this);
             rv = new RowEvents(this);
             rv.MaxHeight = cs.MaxHeight = 100;
             rv.Width = cs.Width = 110;
           
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void HGrid_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyData == Keys.Enter) 
            {
            e.Handled  = true ;
            base.ProcessDialogKey(Keys.Tab);
            }
        }

       
 
	protected override bool ProcessDialogKey(Keys keyData)
	{
		if (keyData == Keys.Enter)
		{
			keyData = Keys.Tab;
		}
		
		return base.ProcessDialogKey(keyData);
		
	}

    private void HGrid_Enter(object sender, EventArgs e)
    {
        if (this.Rows.Count != 0 && this.Columns.Count != 0)
        {
            
            this.Rows[0].Cells[0].Selected = true;

        }


    }

     

    }
}
