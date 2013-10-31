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
    public partial class HLabel : Label 
    {
        public HLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        #region Properties
       

        /// <summary>FieldName
        /// Gets or sets the horizontal alignment of the text.
        /// </summary>
        [DefaultValue(typeof(string), ""),
        Category("|Data|")]
        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }


       
        #endregion
        #region Private Variables

        public string _FieldName;
        
        #endregion
    }
}
