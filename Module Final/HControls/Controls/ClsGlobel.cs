using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace HControls
{
    /// <summary>TextType
    /// -تحدد هل نوع التيكست بوكس رقم -تاريخ - تليفون - ايميل 
    /// </summary>
    public enum TextType
    {
        IsString = 0,
        IsNumber = 1,
        IsdateTime = 2,
        IsTel = 3,
        IsMail = 4,


    }
    /// <summary>
    /// 
    /// </summary>
    public enum DataType
    {
        String = 0,
        Integer = 1,
        Decimal = 2,
        DateTime = 3,
        Boolean = 4,
        Binary = 5,
        Time = 6,
        Hexadecimal = 7
    }
    public enum Languages
    {
        Arabic=0,
        English=1,
        French=2,
        Spanish=3,

    }
    public static class ClsGlobel
    {
        public static Languages _Language = Languages.English ;
        public static void ShowErrorToolTip(string message, Point location)
        {
            ToolTip _tooltip = new ToolTip();
            _tooltip.IsBalloon = true;
            _tooltip.UseAnimation = true;
            _tooltip.BackColor = Color.MistyRose;
            _tooltip.ToolTipTitle = "خطأ";
            location.X += 10;
            location.Y -= 40;
            _tooltip.Show(message, Application.OpenForms[Application.OpenForms.Count - 1], location, 500);





        }
        public static void handleNumberkeyDown(TextType _texttype, ref  KeyEventArgs e, NumberType _NumberType, NumberPower __NumberPower)
        {
            bool result = true;

            bool numericKeys = (
                ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
                && e.Modifiers != Keys.Shift);

            bool ctrlA = e.KeyCode == Keys.A && e.Modifiers == Keys.Control;
            bool mark = (e.KeyCode == Keys.OemMinus && __NumberPower != NumberPower.positiveOnly) || (e.KeyCode == Keys.Oemplus && __NumberPower != NumberPower.NegativeOnly);
            bool comma = (_NumberType != NumberType.Integer && (e.KeyData == Keys.Decimal || e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.OemPeriod));
            bool editKeys = (
                (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control) ||
                (e.KeyCode == Keys.X && e.Modifiers == Keys.Control) ||
                (e.KeyCode == Keys.C && e.Modifiers == Keys.Control) ||
                (e.KeyCode == Keys.V && e.Modifiers == Keys.Control) ||
                e.KeyCode == Keys.Delete ||
                e.KeyCode == Keys.Back);

            bool navigationKeys = (
                e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left ||
                e.KeyCode == Keys.Home ||
                e.KeyCode == Keys.End);
            switch (_texttype)
            {
                case TextType.IsNumber:
                    {
                        if (!(numericKeys || editKeys || navigationKeys || mark || comma))
                        {

                            if (ctrlA) // Do select all as OS/Framework does not always seem to implement this.
                                //   SelectAll();
                                result = false;
                        }
                        if (!result) // If not valid key then suppress and handle.
                        {
                            e.SuppressKeyPress = true;
                            e.Handled = true;
                            if (ctrlA) { } // Do Nothing!



                        }


                        break;
                    }
                case TextType.IsdateTime: break;
                case TextType.IsMail: break;
                case TextType.IsString: break;
                case TextType.IsTel: break;

            }

        }
       
    }
}
