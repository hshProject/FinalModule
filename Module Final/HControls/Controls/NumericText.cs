using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace HControls
{
    /// <summary>
    /// Defines the editing control for the NumericCell custom cell type.
    /// </summary>
    class NumericText : HNumericTextBox  , IDataGridViewEditingControl
    {
        // Needed to forward keyboard messages to the child TextBox control.
        [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        // The grid that owns this editing control
        private DataGridView dataGridView;
        // Stores whether the editing control's value has changed or not
        private bool valueChanged;
        // Stores the row index in which the editing control resides
        private int rowIndex;
       
         

         
        



        /// <summary>
        /// Constructor of the editing control class
        /// </summary>
        /// 
        public NumericText()
        {
            // The editing control must not be part of the tabbing loop
            this.TabStop = false;
            _minValue = -1000000;
            _maxValue = 10000000;
        }

        // Beginning of the IDataGridViewEditingControl interface implementation

        /// <summary>
        /// Property which caches the grid that uses this editing control
        /// </summary>
        public virtual DataGridView EditingControlDataGridView
        {
            get
            {
                return this.dataGridView;
            }
            set
            {
                this.dataGridView = value;
            }
        }

        /// <summary>
        /// Property which represents the current formatted value of the editing control
        /// </summary>
        public virtual object EditingControlFormattedValue
        {
            get
            {
                return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                this.Text = (string) value;
            }
        }

        /// <summary>
        /// Property which represents the row in which the editing control resides
        /// </summary>
        public virtual int EditingControlRowIndex
        {
            get
            {
                return this.rowIndex;
            }
            set
            {
                this.rowIndex = value;
            }
        }

        /// <summary>
        /// Property which indicates whether the value of the editing control has changed or not
        /// </summary>
        public virtual bool EditingControlValueChanged
        {
            get
            {
                return this.valueChanged;
            }
            set
            {
                this.valueChanged = value;
            }
        }

        /// <summary>
        /// Property which determines which cursor must be used for the editing panel,
        /// i.e. the parent of the editing control.
        /// </summary>
        public virtual Cursor EditingPanelCursor
        {
            get
            {
                return Cursors.Default;
            }
        }

        /// <summary>
        /// Property which indicates whether the editing control needs to be repositioned 
        /// when its value changes.
        /// </summary>
        public virtual bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Method called by the grid before the editing control is shown so it can adapt to the 
        /// provided cell style.
        /// </summary>
        public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            if (dataGridViewCellStyle.BackColor.A < 255)
            {
                // The NumericUpDown control does not support transparent back colors
                Color opaqueBackColor = Color.FromArgb(255, dataGridViewCellStyle.BackColor);
                this.BackColor = opaqueBackColor;
                this.dataGridView.EditingPanel.BackColor = opaqueBackColor;
            }
            else
            {
                this.BackColor = dataGridViewCellStyle.BackColor;
            }
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            
        }

        /// <summary>
        /// Method called by the grid on keystrokes to determine if the editing control is
        /// interested in the key or not.
        /// </summary>
        public virtual bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Right:
                {
                   
                    if ( this != null)
                    {
                        // If the end of the selection is at the end of the string,
                        // let the DataGridView treat the key message
                        if ((this.RightToLeft == RightToLeft.No && !(this.SelectionLength == 0 && this.SelectionStart == this.Text.Length)) ||
                            (this.RightToLeft == RightToLeft.Yes && !(this.SelectionLength == 0 && this.SelectionStart == 0)))
                        {
                            return true;
                        }
                    }
                    break;
                }

                case Keys.Left:
                {
 
                    if ( this != null)
                    {
                        // If the end of the selection is at the begining of the string
                        // or if the entire text is selected and we did not start editing,
                        // send this character to the dataGridView, else process the key message
                        if ((this.RightToLeft == RightToLeft.No && !(this.SelectionLength == 0 && this.SelectionStart == 0)) ||
                            (this.RightToLeft == RightToLeft.Yes && !(this.SelectionLength == 0 && this.SelectionStart == this.Text.Length)))
                        {
                            return true;
                        }
                    }
                    break;
                }

                case Keys.Down:
                    // If the current value hasn't reached its minimum yet, handle the key. Otherwise let
                    // the grid handle it.
                    if (this._value  > this._minValue )
                    {
                        return true;
                    }
                    break;

                case Keys.Up:
                    // If the current value hasn't reached its maximum yet, handle the key. Otherwise let
                    // the grid handle it.
                    if (this.value < this._maxValue )
                    {
                        return true;
                    }
                    break;

                case Keys.Home:
                case Keys.End:
                {
                    // Let the grid handle the key if the entire text is selected.

                    if (this != null)
                    {
                        if (this.SelectionLength != this.Text.Length)
                        {
                            return true;
                        }
                    }
                    break;
                }

                case Keys.Delete:
                {
                    // Let the grid handle the key if the carret is at the end of the text.

                    if (this != null)
                    {
                        if (this.SelectionLength > 0 ||
                            this.SelectionStart < this.Text.Length)
                        {
                            return true;
                        }
                    }
                    break;
                }
            }
            return !dataGridViewWantsInputKey;
        }

        /// <summary>
        /// Returns the current value of the editing control.
        /// </summary>
        public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            //bool userEdit = this.UserEdit;
            //try
            //{   
            //    // Prevent the Value from being set to Maximum or Minimum when the cell is being painted.
            //    this.UserEdit = (context & DataGridViewDataErrorContexts.Display) == 0;
            //    return this.Value.ToString((this.ThousandsSeparator ? "N" : "F") + this.DecimalPlaces.ToString());
            //}
            //finally
            //{
            //    this.UserEdit = userEdit;
            //}
            return this.value.ToString();
        }

        /// <summary>
        /// Called by the grid to give the editing control a chance to prepare itself for
        /// the editing session.
        /// </summary>
        public virtual void PrepareEditingControlForEdit(bool selectAll)
        {
              if (selectAll)
                {
                    this.SelectAll();
                }
                else
                {
                    // Do not select all the text, but
                    // position the caret at the end of the text
                    this.SelectionStart = this.Text.Length;
                }
            
        }

        // End of the IDataGridViewEditingControl interface implementation

        /// <summary>
        /// Small utility function that updates the local dirty state and 
        /// notifies the grid of the value change.
        /// </summary>
        private void NotifyDataGridViewOfValueChange()
        {
            if (!this.valueChanged)
            {
                this.valueChanged = true;
                this.dataGridView.NotifyCurrentCellDirty(true);
            }
        }

        /// <summary>
        /// Listen to the KeyPress notification to know when the value changed, and 
        /// notify the grid of the change.
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            // The value changes when a digit, the decimal separator, the group separator or
            // the negative sign is pressed.
            bool notifyValueChange = false;
            if (char.IsDigit(e.KeyChar))
            {
                notifyValueChange = true;
            }
            else
            {
                System.Globalization.NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
                string decimalSeparatorStr = numberFormatInfo.NumberDecimalSeparator;
                string groupSeparatorStr = numberFormatInfo.NumberGroupSeparator;
                string negativeSignStr = numberFormatInfo.NegativeSign;
                if (!string.IsNullOrEmpty(decimalSeparatorStr) && decimalSeparatorStr.Length == 1)
                {
                    notifyValueChange = decimalSeparatorStr[0] == e.KeyChar;
                }
                if (!notifyValueChange && !string.IsNullOrEmpty(groupSeparatorStr) && groupSeparatorStr.Length == 1)
                {
                    notifyValueChange = groupSeparatorStr[0] == e.KeyChar;
                }
                if (!notifyValueChange && !string.IsNullOrEmpty(negativeSignStr) && negativeSignStr.Length == 1)
                {
                    notifyValueChange = negativeSignStr[0] == e.KeyChar;
                }
            }

            if (notifyValueChange)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
            }
        }

        /// <summary>
        /// Listen to the ValueChanged notification to forward the change to the grid.
        /// </summary>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (this.Focused)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
            }
        }

        /// <summary>
        /// A few keyboard messages need to be forwarded to the inner textbox of the
        /// NumericUpDown control so that the first character pressed appears in it.
        /// </summary>
        //protected override bool ProcessKeyEventArgs(ref Message m)
        //{
            
        //        //SendMessage(this.Handle, m.Msg, m.WParam, m.LParam);
        //        return true;
           
        //}
    }
}
