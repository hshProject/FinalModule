using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Design;

using System.Text.RegularExpressions;
using System.Globalization;
using HControls;
namespace HControls
{
    /// <summary>
    /// A TextBox that only allows digits to be entered.
    /// </summary>
    [Description("A TextBox that only allows digits to be entered.")]
    public class HTextBox : TextBox
    {
        #region Enums

        /// <summary>
        /// A enum of reasons why a paste was rejected.
        /// </summary>
        public enum PasteRejectReasons
        {
            Unknown = 0,
            NoData,
            InvalidCharacter,
            Accepted
        }

        #endregion

        #region Constants

        /// <summary>
        /// Windows message that is sent when a paste event occurs.
        /// </summary>


        #endregion

        #region Events
        /// <summary>
        /// Occurs whenever a KeyDown event is suppressed.
        /// </summary>
        [Category("Behavior"),
        Description("Occurs whenever a KeyDown event is suppressed.")]
        public event EventHandler<KeyRejectedEventArgs> KeyRejected;

        /// <summary>
        /// Occurs whenever a paste attempt is suppressed.
        /// </summary>
        [Category("Behavior"),
        Description("Occurs whenever a paste attempt is suppressed.")]
        public event EventHandler<PasteEventArgs> PasteRejected;

        #endregion

        #region Private Variables

        /// <summary>
        /// The last Text of the control.
        /// </summary>
        public string _defaultText;
        public DataType _DataType;
        public string _regex = "";
        public TextType _TextType;
        public string _FieldName;
        public string _ComboBoxRelatedWith;
        public bool _key;
        public bool _required;
        public Color _requiredColor = Color.RosyBrown;
        public Languages _Language = Languages.Arabic;
        public decimal _value;
        public decimal _minValue;
        public decimal _maxValue;
        public int __Precision = 2;
        public NumberPower _NumberPower;
        public NumberType _NumberType;
        public string _TextBoxRelatedWith;

        public string _SearchTable;
        public string _SearchFields;
        public string _SearchFilter; //ABUBAKR 10-9-2013


        #endregion

        #region Properties
        /// <summary>regex
        ///regular experssion تحدد ال
        /// </summary>
        [Category("|Data|")]
        [Description("regular experssion    of this control type")]
        [DefaultValue(@"")]
        [Browsable(false)]
        public string regex
        {
            get { return this._regex; }
            set
            {
                this._regex = ClsRegex.GetRegex();


            }
        }
        /// <summary>DataType
        ///تحدد نوع التيكست بوكس
        /// </summary>
        [Category("|Data|")]
        [Description("Data Type of this control")]
        [DefaultValue(typeof(DataType), "0")]
        public DataType DataType
        {
            get { return this._DataType; }
            set
            {
                this._DataType = value;
                this._defaultText = "";

            }
        }

        /// <summary>TextType
        ///تحدد نوع التيكست بوكس
        /// </summary>
        [Category("|Data|")]
        [Description("Data Type of this control")]
        [DefaultValue(typeof(TextType), "0")]
        public TextType TextType
        {
            get { return this._TextType; }
            set
            {
                this._TextType = value;

            }
        }
        /// <summary>DefaultText
        /// Gets or sets the default value for the control.
        /// </summary>
        [Category("|Data|")]
        [DefaultValue(""),
         Browsable(true)]
        public string DefaultText
        {
            get { return _defaultText; }
            set
            {
                string oldValue = _defaultText;
                if (_defaultText != value)
                {

                    _defaultText = value;
                    if (Text == oldValue)
                        Text = _defaultText;


                }
            }
        }

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



        /// <summary>key
        /// يحدد  لغة التكست بوكس على الفورمة ام
        /// </summary>
        [DefaultValue(typeof(Languages), "0"),
        Category("|Data|")]
        public Languages Language
        {
            get { return _Language; }
            set
            {
                _Language = value;



            }
        }

        /// <summary>key
        /// يحدد  الكومبو المرتبط 
        /// </summary>
        [DefaultValue(typeof(string), ""),
        Category("|Data|")]
        public string ComboBoxRelatedWith
        {
            get { return _ComboBoxRelatedWith; }
            set { _ComboBoxRelatedWith = value; }
        }
        /// <summary>key
        /// يحدد  الكومبو المرتبط 
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




        [DefaultValue(typeof(string), ""),
        Category("|Data|")]
        public string SerachTable
        {
            get { return _SearchTable; }
            set { _SearchTable = value; }
        }
        /// <summary>
        /// add fieldvalue then : then headertext then &&
        /// </summary>
        [DefaultValue(typeof(string), ""),
       Category("|Data|")]
        public string SerachFields
        {
            get { return _SearchFields; }
            set { _SearchFields = value; }
        }
        [DefaultValue(typeof(string), ""),
      Category("|Data|")]
        public string SerachFilter //ABUBAKR 10-9-2013
        {
            get { return _SearchFilter; }
            set { _SearchFilter = value; }
        }




        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the NumericTextBox
        /// </summary>
        public HTextBox()
        {
            //TextAlign = HorizontalAlignment.Right;
            _defaultText = "";
            Text = _defaultText;
            if (_required == true) BackColor = _requiredColor;

        }

        #endregion

        #region Overridden Methods

        #region Overridden Methods

        /// <summary>
        /// Raises the OnGotFocus event.
        /// </summary>
        /// <param name="e">A System.EventArgs that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            // Select all text everytime control gets focus.
            SelectAll();
            if (_Language == Languages.Arabic)
            {
                Application.CurrentCulture = new CultureInfo("ar-EG");
                //    Application.CurrentCulture = new CultureInfo("ar-EG");

            }
            else
            {
                Application.CurrentCulture = new CultureInfo("en");
            }
            base.OnGotFocus(e);
        }
        /// <summary>
        /// Raises the KeyDownEvent.
        /// </summary>
        /// <param name="e">A System.Windows.Forms.KeyEventArgs that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            #region KeysType
            bool numericKeys = (
                  ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                  (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
                  && e.Modifiers != Keys.Shift);

            bool ctrlA = e.KeyCode == Keys.A && e.Modifiers == Keys.Control;
            bool mark = (e.KeyCode == Keys.OemMinus) || (e.KeyCode == Keys.Oemplus && _NumberPower != NumberPower.NegativeOnly);
            bool comma = (_NumberType != NumberType.Integer && (e.KeyData == Keys.Decimal || e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.OemPeriod));
            bool editKeys = (
                (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control) ||
                (e.KeyCode == Keys.X && e.Modifiers == Keys.Control) ||
                (e.KeyCode == Keys.C && e.Modifiers == Keys.Control) ||
                (e.KeyCode == Keys.V && e.Modifiers == Keys.Control) ||
                e.KeyCode == Keys.Delete ||
                e.KeyCode == Keys.Back);
            bool funKeys = (
               (e.KeyCode == Keys.S && e.Modifiers == Keys.Control) ||
               (e.KeyCode == Keys.Delete) ||
               (e.KeyCode == Keys.Escape));

            bool navigationKeys = (
                e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left ||
                e.KeyCode == Keys.Home ||
                e.KeyCode == Keys.End);
            #endregion

            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                base.OnKeyDown(e);
            }
            else if (e.KeyData == Keys.F9)
            {
                if (_SearchTable != null && _SearchFields != null)
                {
                    //frmSmallSearch fss = new frmSmallSearch(this);
                    //fss.ShowDialog();
                }
                base.OnKeyDown(e);
            }
            else if (funKeys)
            {
            }
            else
            {
                bool result = true;
                if (this.DataType ==  DataType.String || this.DataType == DataType.DateTime)
                {
                    result = true;
                }
                else
                {
                    if (!(numericKeys || editKeys || navigationKeys || mark || comma))
                    {
                        if (ctrlA) // Do select all as OS/Framework does not always seem to implement this.
                            SelectAll();
                        result = false;
                    }
                    if (!result) // If not valid key then suppress and handle.
                    {
                        e.SuppressKeyPress = true;
                        e.Handled = true;
                        if (ctrlA) { } // Do Nothing!
                    }
                }
            }
        }

        /// <summary>OnLostFocus
        /// Raises the LostFocus event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
                Text = _defaultText;
            else
                if (!Regex.IsMatch(Text, ClsRegex.numericGetRegex(TextType.IsNumber, _NumberType, _NumberPower)))
                {
                    this.BackColor = Color.Red;
                }
                else
                {                    this.BackColor = Color.White;
                }

            base.OnLostFocus(e);
        }
        /// <summary>OnValidating
        /// Raises the LostFoOnValidating  event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnValidating(CancelEventArgs e)
        {
            if (this._DataType == HControls.DataType.String)
            {

            }
            else if (this._DataType == HControls.DataType.Decimal || this._DataType == HControls.DataType.Integer)
            {

                if (string.IsNullOrEmpty(Text))
                {
                    this.BackColor = Color.White;
                    Text = _defaultText;
                }
                else
                {
                    if (!Regex.IsMatch(Text, ClsRegex.numericGetRegex(TextType.IsNumber, _NumberType, _NumberPower)))
                    {
                        this.BackColor = Color.Red;
                        ClsGlobel.ShowErrorToolTip(" البيان المدخل غير صحيح", this.Location);
                        e.Cancel = true;
                    }
                    else
                    {
                        decimal _newvalue = Convert.ToDecimal(Text);
                        //if (_newvalue > _maxValue || _newvalue < _minValue)
                        //{
                        //    ClsGlobel.ShowErrorToolTip("القيمة غير صحيحة", this.Location);
                        //    this.BackColor = Color.Red;
                        //    e.Cancel = true;
                        //}
                        //else
                        //{
                        //    this.BackColor = Color.White;
                        //    _value = _newvalue;
                        //}
                    }
                }

            }
            else if (this._DataType == DataType.DateTime && Text != null && Text != "")
            {

                try
                {
                    this.Text = Convert.ToDateTime(Text).ToString("yyyy/MM/dd");

                }
                catch (Exception)
                {

                    if (Regex.IsMatch(Text, @"^(0?[1-9]|[1][0-9]|[2][0-9]|30|31)$"))
                    {

                        this.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(this.Text)).ToString("yyyy/MM/dd");
                    }
                    else if (Regex.IsMatch(Text, @"^(0?[1-9]|[1][0-9]|[2][0-9]|30|31)[- /.](0?[1-9]|10|11|12)$"))
                    {
                        this.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(this.Text)).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        this.BackColor = Color.Red;
                        ClsGlobel.ShowErrorToolTip(" البيان المدخل غير صحيح", this.Location);
                        e.Cancel = true;
                    }
                }


            }
        }





        /// <summary>
        /// Raises the TextChanged event.
        /// </summary>
        /// <param name="e">A System.EventArgs that contains the event data.</param>




        #endregion



        #endregion

        #region Private Methods

        /// <summary>
        /// Checks if the data on the clipboard contains text that is valid.
        /// </summary>
        /// <returns>A PasteEventArgs instance containing the relevant data.</returns>
        private PasteEventArgs CheckPasteValid()
        {
            // Default values.
            PasteRejectReasons rejectReason = PasteRejectReasons.Accepted;
            string originalText = Text;
            string clipboardText = string.Empty;
            string textResult = string.Empty;

            try
            {
                clipboardText = Clipboard.GetText(TextDataFormat.Text);
                if (clipboardText.Length > 0) // Does clipboard contain text?
                {
                    // Store text value as it will be post paste assuming it is valid.
                    textResult = (
                        Text.Remove(SelectionStart, SelectionLength).Insert(SelectionStart, clipboardText));
                    foreach (char c in clipboardText) // Check for any non digit characters.
                    {
                        if (!char.IsDigit(c))
                        {
                            rejectReason = PasteRejectReasons.InvalidCharacter;
                            break;
                        }
                    }
                }
                else
                    rejectReason = PasteRejectReasons.NoData;
            }
            catch
            {
                rejectReason = PasteRejectReasons.Unknown;
            }
            return new PasteEventArgs(originalText, clipboardText, textResult, rejectReason);
        }
        bool validateDate()
        {
            return Regex.IsMatch(Text, @"(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d'");
        }
        #endregion

        #region Event Raise Methods

        /// <summary>
        /// Raises the KeyRejected event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnKeyRejected(KeyRejectedEventArgs e)
        {
            EventHandler<KeyRejectedEventArgs> handler = KeyRejected;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Raises the PasteRejected event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnPasteRejected(PasteEventArgs e)
        {
            EventHandler<PasteEventArgs> handler = PasteRejected;
            if (handler != null)
                handler(this, e);
        }

        #endregion

        #region EventArg Classes

        /// <summary>
        /// Event arguments class for the KeyRejected event.
        /// </summary>
        public class KeyRejectedEventArgs : EventArgs
        {
            #region Private Variables

            private Keys m_Key;

            #endregion

            #region Properties

            /// <summary>
            /// Gets the rejected key.
            /// </summary>
            [ReadOnly(true)]
            public Keys Key
            {
                get { return m_Key; }
            }

            #endregion

            #region Constructor

            /// <summary>
            /// Creates a new instance of the KeyRejectedEventArgs class.
            /// </summary>
            /// <param name="key">The rejected key.</param>
            public KeyRejectedEventArgs(Keys key)
            {
                m_Key = key;
            }

            #endregion

            #region Overridden Methods

            /// <summary>
            /// Converts this KeyRejectedEventArgs instance into it's string representation.
            /// </summary>
            /// <returns>A string indicating the rejected key.</returns>
            public override string ToString()
            {
                return string.Format("Rejected Key: {0}", Key.ToString());
            }

            #endregion
        }

        /// <summary>
        /// Event arguments class for the PasteRejected event.
        /// </summary>
        public class PasteEventArgs : EventArgs
        {
            #region Private Variables

            private string m_OriginalText;
            private string m_ClipboardText;
            private string m_TextResult;
            private PasteRejectReasons m_RejectReason;

            #endregion

            #region Properties

            /// <summary>
            /// Gets the original text.
            /// </summary>
            [ReadOnly(true)]
            public string OriginalText
            {
                get { return m_OriginalText; }
            }

            /// <summary>
            /// Gets the text from the clipboard.
            /// </summary>
            [ReadOnly(true)]
            public string ClipboardText
            {
                get { return m_ClipboardText; }
            }

            /// <summary>
            /// Gets the resulting text.
            /// </summary>
            [ReadOnly(true)]
            public string TextResult
            {
                get { return m_TextResult; }
            }

            /// <summary>
            /// Gets the reason for the paste rejection.
            /// </summary>
            [ReadOnly(true)]
            public PasteRejectReasons RejectReason
            {
                get { return m_RejectReason; }
            }

            #endregion

            #region Constructor

            /// <summary>
            /// Creates a new instance of the PasteRejectedEventArgs class.
            /// </summary>
            /// <param name="originalText">The original textl.</param>
            /// <param name="clipboardText">The text from the clipboard.</param>
            /// <param name="textResult">The resulting text.</param>
            /// <param name="rejectReason">The reason for the paste rejection.</param>
            public PasteEventArgs(string originalText, string clipboardText, string textResult,
                PasteRejectReasons rejectReason)
            {
                m_OriginalText = originalText;
                m_ClipboardText = clipboardText;
                m_TextResult = textResult;
                m_RejectReason = rejectReason;
            }

            #endregion

            #region Overridden Methods

            /// <summary>
            /// Converts this PasteRejectedEventArgs instance into it's string representation.
            /// </summary>
            /// <returns>A string indicating the rejected reason.</returns>
            public override string ToString()
            {
                return string.Format("Rejected reason: {0}", RejectReason.ToString());
            }

            #endregion
        }

        #endregion

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HTextBox));
            this.SuspendLayout();
            // 
            // HTextBox
            // 
            resources.ApplyResources(this, "$this");
            this.Enter += new System.EventHandler(this.HTextBox_Enter);
            this.ResumeLayout(false);

        }

        private void HTextBox_Enter(object sender, EventArgs e)
        {
            this.SelectionStart = 0;
            this.SelectionLength = this.Text.Length;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            //hemaily 26may2013
            try
            {

                if (this.Text != "" && this.Text != null && ComboBoxRelatedWith != null && ComboBoxRelatedWith != "")
                {
                    (this.FindForm().Controls[ComboBoxRelatedWith] as HComboBox).SelectedValue = Convert.ToInt32(this.Text);
                }
                else if (ComboBoxRelatedWith != null && ComboBoxRelatedWith != "")
                {
                    (this.FindForm().Controls[ComboBoxRelatedWith] as HComboBox).SelectedValue = -1;
                }
            }
            catch { }
        }







    }
}