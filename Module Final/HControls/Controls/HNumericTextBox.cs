using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Design;
namespace HControls 
{
    /// <summary>
    /// A TextBox that only allows digits to be entered.
    /// </summary>
    [Description("A TextBox that only allows digits to be entered.")]
    public class HNumericTextBox : HTextBox 
    {
       

        #region Constants
 
        #endregion

        #region Events

        

        #endregion

        #region Private Variables

        /// <summary>
        /// The last Text of the control.
        /// </summary>
       public  decimal _value;
       public  decimal   _minValue;
       public  decimal _maxValue;
       public  int __Precision=2;
       public  NumberPower _NumberPower;
       public  NumberType _NumberType;
       

        #endregion
        
      

         

        #region Constructor

        /// <summary>
        /// Creates a new instance of the NumericTextBox
        /// </summary>
        public HNumericTextBox()
        {
            TextAlign = HorizontalAlignment.Right;
            TextType = TextType.IsNumber;
            _NumberType =NumberType.Decimal;
            _NumberPower = NumberPower.positiveOrNegative;
            regex = ClsRegex.numericGetRegex(TextType.IsNumber, _NumberType, _NumberPower);
            _minValue = -10000000;
            _maxValue = 10000000;
            if (_required == true) BackColor = _requiredColor; 
        }

        #endregion

        #region Overridden Methods

        /// <summary>
        /// Raises the OnGotFocus event.
        /// </summary>
        /// <param name="e">A System.EventArgs that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            // Select all text everytime control gets focus.
            SelectAll();
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Raises the KeyDownEvent.
        /// </summary>
        /// <param name="e">A System.Windows.Forms.KeyEventArgs that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            bool result = true;

            bool numericKeys = (
                ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
                && e.Modifiers != Keys.Shift);

            bool ctrlA = e.KeyCode == Keys.A && e.Modifiers == Keys.Control;
            bool mark = (e.KeyCode == Keys.OemMinus && NumberPower != NumberPower.positiveOnly) || (e.KeyCode == Keys.Oemplus && _NumberPower != NumberPower.NegativeOnly);
            bool comma = ( _NumberType != NumberType.Integer && (  e.KeyData == Keys.Decimal ||e.KeyCode  == Keys.Oemcomma ||e.KeyCode == Keys.OemPeriod));
            bool editKeys = (
                e.KeyCode == Keys.Back);

            bool navigationKeys = (  e.KeyCode ==  Keys .Enter );

            if (!(numericKeys || editKeys || mark || comma ))
            {
                if (ctrlA) // Do select all as OS/Framework does not always seem to implement this.
                    SelectAll();
                result = false;
            }
            if (e.KeyData ==  Keys.Enter )
            {
                SendKeys.Send("{TAB}");
                // this .OnKeyDown (new KeyEventArgs (Keys .Tab ));
                result = true ;
                

            }
            if (e.KeyData == Keys.Tab )
            {

               
                result = true;


            }
            if (e.KeyData == Keys.Escape )
            {
                SendKeys.Send("{Escape}");
               
                 
            }
            if (!result) // If not valid key then suppress and handle.
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                if (ctrlA) { } // Do Nothing!
                 
                    
            }
            else
                base.OnKeyDown(e);
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
                {
                    this.BackColor = Color.White;
                }
             
            base.OnLostFocus(e);
        }
        /// <summary>OnValidating
        /// Raises the LostFoOnValidating  event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void  OnValidating(CancelEventArgs e)
 
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
                    ClsGlobel.ShowErrorToolTip(   " البيان المدخل غير صحيح", this.Location);
                    e.Cancel = true;
                }
                else
                {
                    decimal _newvalue = Convert.ToDecimal(Text);
                    if (_newvalue > _maxValue || _newvalue < _minValue)
                    {
                        ClsGlobel.ShowErrorToolTip("القيمة غير صحيحة", this.Location);
                        this.BackColor = Color.Red;
                        e.Cancel = true;
                    }
                    else
                    {
                        this.BackColor = Color.White;
                        _value = _newvalue;
                    }
                }


            }
        }


       
        
        /// <summary>
        /// Raises the TextChanged event.
        /// </summary>
        /// <param name="e">A System.EventArgs that contains the event data.</param>
      

      

        #endregion

        

        #region Properties
        /// <summary>minValue
        ///    تحدد  اقل قيمة
        /// </summary>
        [Category("|Data|")]
        [Description(" min value   of this control type")]
        [DefaultValue( typeof ( decimal) ,  "-10000000")]
        [Browsable (true )]
        public decimal minValue
        {
            get { return this._minValue; }
            set { _minValue = value; }
        }
        /// <summary>maxvalue
        ///    تحدد   اكبر قيمة
        /// </summary>
        [Category("|Data|")]
        [Description(" max  value    of this control type")]
        [DefaultValue(typeof(decimal), "10000000")]
        [Browsable(true)]
        public decimal maxValue
        {
            get { return this._maxValue; }
            set { _maxValue = value; }
        }

        /// <summary>Precision
        ///    تحدد   اكبر قيمة
        /// </summary>
        [Category("|Data|")]
        [Description(" Precision   number    of this control type")]
        [DefaultValue(typeof(int), "2")]
        [Browsable(true)]
        public int Precision
        {
            get { return this.__Precision; }
            set { __Precision  = value; }
        }
        /// <summary>value
        /// تحدد القيمة فة التكست بوكس
        /// </summary>
        [Category("|Data|")]
        [Description("value    of this control type")]
        public decimal value
        {
            get { return this._value; }

        }


        /// <summary>NumberType
        ///    تحدد  نوع الرقم
        /// </summary>
        [Category("|Data|")]
        [Description("    NumberType    of this control type")]
        [DefaultValue(typeof(NumberType), "2")]
        [Browsable(true)]
        public NumberType NumberType
        {
            get { return this._NumberType ; }
            set { _NumberType = value; }
        }


        /// <summary>NumberPower
        ///    تحدد  نوع الرقم
        /// </summary>
        [Category("|Data|")]
        [Description("    NumberPower    of this control type")]
        [DefaultValue(typeof(NumberPower), "3")]
        [Browsable(true)]
        public NumberPower NumberPower
        {
            get { return this._NumberPower ; }
            set { _NumberPower = value; }
        }
        #endregion

        #region Event Raise Methods

       
        #endregion

      
    }
}