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
    public partial class HComboBox : ComboBox
    {
        public HComboBox()
        {
            InitializeComponent();
            if (HControls.ClsGlobel._Language == HControls.Languages.Arabic)
            {

                this.RightToLeft = RightToLeft.Yes;

            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        #region Private Variables

        /// <summary>
        /// The last Text of the control.
        /// </summary>


        public string _FieldName;
        public string _TableName;
        public string _SearchFilter;
        public string _TextBoxRelatedWith;
        public bool _key;
        public bool _required;
        public Color _requiredColor = Color.RosyBrown;
        public Languages _Language = Languages.Arabic;


        #endregion
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

        /// <summary>TableaNme
        /// Gets or sets the  TableaNme.
        /// </summary>
        [DefaultValue(typeof(string), ""),
        Category("|Data|")]
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        /// <summary>TableaNme
        /// Gets or sets the  TableaNme.
        /// </summary>
        [DefaultValue(typeof(string), ""),
        Category("|Data|")]
        public string MyDisplayMember
        {
            get { return DisplayMember; }
            set { DisplayMember = value; }
        }
        /// <summary>TableaNme
        /// Gets or sets the  TableaNme.
        /// </summary>
        [DefaultValue(typeof(string), ""),
        Category("|Data|")]
        public string MyValueMember
        {


            get { return ValueMember; }
            set { ValueMember = value; }
        }
        /// <summary>key
        /// يحدد هل العنصر  بريمرى كى على الفورمة ام
        /// </summary>
        [DefaultValue(typeof(bool), "0"),
        Category("|Data|")]
        public bool key
        {
            get { return _key; }
            set { _key = value; }
        }

        [DefaultValue(typeof(string), ""),
        Category("|Data|")]
        public string SearchFilter
        {
            get { return _SearchFilter; }
            set { _SearchFilter = value; }
        }

        /// <summary>key
        /// يحدد  لغة التكست بوكس على الفورمة ام
        /// </summary>
        [DefaultValue(typeof(Languages), "0"),
        Category("|Data|")]
        public Languages Language
        {
            get { return _Language; }
            set { _Language = value; }
        }

        /// <summary>key
        /// يحدد التكست المرتبط الفورمة ام
        /// </summary>
        [DefaultValue(typeof(string), ""),
        Category("|Data|")]
        public string TextBoxRelatedWith
        {
            get { return _TextBoxRelatedWith; }
            set { _TextBoxRelatedWith = value; }
        }


        /// <summary>required
        /// يحدد التكست مطلوب ام لا  
        /// </summary>
        [DefaultValue(typeof(bool), ""),
        Category("|Data|")]
        public bool required
        {
            get { return _required; }
            set { _required = value; }
        }
        #endregion
        //hemaily 5october2013
        private void HComboBox_SelectedValueChangedComit(object sender, EventArgs e)
    { // hassan 18-5
            if (this.SelectedValue != null && this.SelectedValue != "" && this.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                if (this.TextBoxRelatedWith != null && this.TextBoxRelatedWith != "")
                {
                    (this.FindForm().Controls[TextBoxRelatedWith] as HTextBox).Text = this.SelectedValue.ToString();
                }
            }
            else
            {
                if (this.TextBoxRelatedWith != null && this.TextBoxRelatedWith != "")
                {
                    (this.FindForm().Controls[TextBoxRelatedWith] as HTextBox).Text = null;
                }
            }
        }

        private void HComboBox_KeyDown(object sender, KeyEventArgs e)
            {
            //hassan 18-5
            if (e.KeyData == Keys.Enter)
            {
                //  base.OnKeyDown(e);
                SendKeys.Send("{TAB}");


            }
        }
    }
}
