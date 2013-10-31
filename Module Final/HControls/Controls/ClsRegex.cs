using System;
using System.Collections.Generic;
using System.Text;

namespace HControls 
{
    public   class ClsRegex
    {
         public const string negativePt = @"^-";
         public const string PositivePt = @"^+";
         public const string IntegerPt = @"[0-9]*";
         
         public const string DecimalPt = @"[,|.]?[0-9]+";
         public static string GetRegex()
         {
             string Regex = @"\w";
            
             return Regex;
         }

         public static   string numericGetRegex(TextType _TextType, NumberType _numbertype, NumberPower _NumberPower )
        {
           string  Regex = "";
            if (_TextType == TextType.IsNumber)
            {
                ///جزء العلامة  الاشارة
                switch (_NumberPower)
                {
                    case NumberPower.positiveOrNegative: Regex +="("+PositivePt +"|"+ negativePt +")"; break;
                    case NumberPower.NegativeOnly: Regex +=  negativePt ; break;
                    case NumberPower.positiveOnly: Regex += PositivePt; break;
                }
                 ///  جزء العلامة العشرية
                switch (_numbertype )
                {
                    case NumberType.Integer: Regex += IntegerPt; break;
                    case NumberType.Decimalonly: Regex += DecimalPt; break;
                    case NumberType.Decimal : Regex +="("+IntegerPt+"|"+ IntegerPt + DecimalPt+")"; break;
                }
                Regex += "$";
            }
            return Regex ;
        }
    }
}
