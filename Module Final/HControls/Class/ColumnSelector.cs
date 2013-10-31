//  *****************************************
//  ** DataGridViewColumnSelector ver 1.0  **
//  **                                     **
//  ** Author : Vincenzo Rossi             **
//  ** Country: Naples, Italy              **
//  ** Year   : 2008                       **
//  ** Mail   : redmaster@tiscali.it       **
//  **                                     **
//  ** Released under                      **
//  **   The Code Project Open License     **
//  **                                     **
//  **   Please do not remove this header, **
//  **   I will be grateful if you mention **
//  **   me in your credits. Thank you     **
//  **                                     **
//  *****************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HControls
{
    /// <summary>
    /// Add column show/hide capability to a DataGridView. When user right-clicks 
    /// the cell origin a popup, containing a list of checkbox and column names, is
    /// shown. 
    /// </summary>
    class ColumnSelector
    {
        // the DataGridView to which the DataGridViewColumnSelector is attached
        public HGrid mgrid = null;
        // a CheckedListBox containing the column header text and checkboxes
        public CheckedListBox mCheckedListBox;
        // a ToolStripDropDown object used to show the popup
        public ToolStripDropDown mPopup;

        /// <summary>
        /// The max height of the popup
        /// </summary>
        public int MaxHeight = 300;
        /// <summary>
        /// The width of the popup
        /// </summary>
        public int Width = 200;

        /// <summary>
        /// Gets or sets the DataGridView to which the DataGridViewColumnSelector is attached
        /// </summary>
        public HGrid Grid
        {
            get { return mgrid; }
            set
            {
                // If any, remove handler from current DataGridView 
                if (mgrid != null) mgrid.ColumnHeaderMouseDoubleClick -= new DataGridViewCellMouseEventHandler(mgrid_ColumnHeaderMouseDoubleClick);
                // Set the new DataGridView
                mgrid = value;
                // Attach CellMouseClick handler to DataGridView
                if (mgrid != null) mgrid.ColumnHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(mgrid_ColumnHeaderMouseDoubleClick);
            }
        }

        // When user right-clicks the cell origin, it clears and fill the CheckedListBox with
        // columns header text. Then it shows the popup. 
        // In this way the CheckedListBox items are always refreshed to reflect changes occurred in 
        // DataGridView columns (column additions or name changes and so on).


        // The constructor creates an instance of CheckedListBox and ToolStripDropDown.
        // the CheckedListBox is hosted by ToolStripControlHost, which in turn is
        // added to ToolStripDropDown.
        public ColumnSelector()
        {
            mCheckedListBox = new CheckedListBox();
            mCheckedListBox.CheckOnClick = true;
            mCheckedListBox.ItemCheck += new ItemCheckEventHandler(mCheckedListBox_ItemCheck);

            ToolStripControlHost mControlHost = new ToolStripControlHost(mCheckedListBox);
            mControlHost.Padding = Padding.Empty;
            mControlHost.Margin = Padding.Empty;
            mControlHost.AutoSize = false;

            mPopup = new ToolStripDropDown();
            mPopup.Padding = Padding.Empty;
            mPopup.Items.Add(mControlHost);
        }

        public ColumnSelector(HGrid dgv)
            : this()
        {
            this.Grid = dgv;
        }

        // When user checks / unchecks a checkbox, the related column visibility is 
        // switched.
        void mCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            mgrid.Columns[e.Index].Visible = (e.NewValue == CheckState.Checked);
        }
        private void mgrid_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right )
            {
                mCheckedListBox.Items.Clear();
                foreach (DataGridViewColumn c in mgrid.Columns)
                {
                    mCheckedListBox.Items.Add(c.HeaderText, c.Visible);
                }
                int PreferredHeight = (mCheckedListBox.Items.Count * 16) + 7;
                mCheckedListBox.Height = (PreferredHeight < MaxHeight) ? PreferredHeight : MaxHeight;
                mCheckedListBox.Width = this.Width;
                mPopup.Show( mgrid.Parent .PointToScreen(new Point(e.X-100 , e.Y)));
            }
        }
         

    }
    class RowEvents
    {
        // the DataGridView to which the DataGridViewColumnSelector is attached
        public HGrid mgrid = null;
        // a CheckedListBox containing the column header text and checkboxes
        public CheckedListBox mCheckedListBox;
        // a ToolStripDropDown object used to show the popup
        public ToolStripDropDown mPopup;

        /// <summary>
        /// The max height of the popup
        /// </summary>
        public int MaxHeight = 300;
        /// <summary>
        /// The width of the popup
        /// </summary>
        public int Width = 200;

        /// <summary>
        /// Gets or sets the DataGridView to which the DataGridViewColumnSelector is attached
        /// </summary>
        public HGrid Grid
        {
            get { return mgrid; }
            set
            {
                // If any, remove handler from current DataGridView 
                if (mgrid != null) mgrid.RowHeaderMouseDoubleClick -= new DataGridViewCellMouseEventHandler(mgrid_RowHeaderMouseDoubleClick);
                // Set the new DataGridView
                mgrid = value;
                // Attach CellMouseClick handler to DataGridView
                if (mgrid != null) mgrid.RowHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(mgrid_RowHeaderMouseDoubleClick);
            }
        }

        // When user right-clicks the cell origin, it clears and fill the CheckedListBox with
        // columns header text. Then it shows the popup. 
        // In this way the CheckedListBox items are always refreshed to reflect changes occurred in 
        // DataGridView columns (column additions or name changes and so on).


        // The constructor creates an instance of CheckedListBox and ToolStripDropDown.
        // the CheckedListBox is hosted by ToolStripControlHost, which in turn is
        // added to ToolStripDropDown.
        public RowEvents()
        {
            mCheckedListBox = new CheckedListBox();
            mCheckedListBox.Items.Add("Delete", true );
            mCheckedListBox.CheckOnClick = true;
            mCheckedListBox.ItemCheck += new ItemCheckEventHandler(mCheckedListBox_ItemCheck);

            ToolStripControlHost mControlHost = new ToolStripControlHost(mCheckedListBox);
            mControlHost.Padding = Padding.Empty;
            mControlHost.Margin = Padding.Empty;
            mControlHost.AutoSize = false;

            mPopup = new ToolStripDropDown();
            mPopup.Padding = Padding.Empty;
            mPopup.Items.Add(mControlHost);
        }

        public RowEvents(HGrid dgv)
            : this()
        {
            this.Grid = dgv;
           
        }

        // When user checks / unchecks a checkbox, the related column visibility is 
        // switched.
        void mCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {


            if (mgrid.CurrentRow != null && e.NewValue == CheckState.Unchecked && mCheckedListBox.Items[e.Index].ToString() == "Delete")
            {
                mgrid.CurrentRow.Visible = false;
            }
        }


        private void mgrid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right )
            {
                int PreferredHeight = (mCheckedListBox.Items.Count * 16) + 7;
                mCheckedListBox.Height = (PreferredHeight < MaxHeight) ? PreferredHeight : MaxHeight;
                mCheckedListBox.Width = this.Width;
                mPopup.Show(mgrid.Parent.PointToScreen(new Point(e.X , e.Y)));


              
               

               
            }
        }




    }
}
