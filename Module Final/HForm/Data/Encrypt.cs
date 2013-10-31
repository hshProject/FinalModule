using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

public static class SecurityHelper
{
    public static byte[] Key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
    public static byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8 };

    public static string Encrypt(string strData)
    {
        #region // Replace Words
        string datas = strData;
       // string[] dataArray = datas.Split(' ');
        
      
            if (datas.Contains("ا") || datas.Contains("أ") || datas.Contains("إ"))
            {
                datas = datas.Replace("ا", "a11d");
                datas = datas.Replace("أ", "a11s");
                datas = datas.Replace("إ", "a11m");

            }
            if (datas.Contains("ب"))
            {
               datas=  datas.Replace("ب", "l22k");

            }
            if (datas.Contains("ت"))
            {
                datas = datas.Replace("ت", "o33i");

            }
            if (datas.Contains("ث"))
            {
                datas = datas.Replace("ث", "t44r");

            }
            if (datas.Contains("ج"))
            {
                datas = datas.Replace("ج", "r55e");

            }
            if (datas.Contains("ح"))
            {
                datas = datas.Replace("ح", "u66y");

            }
            if (datas.Contains("خ"))
            {
                datas = datas.Replace("خ", "r77e");

            }
            if (datas.Contains("د"))
            {
                datas = datas.Replace("د", "d88s");

            }
            if (datas.Contains("ذ"))
            {
                datas = datas.Replace("ذ", "t99t");

            }
            if (datas.Contains("ر"))
            {
                datas = datas.Replace("ر", "e101w");

            }
            if (datas.Contains("ز"))
            {
                datas = datas.Replace("ز", "p111o");

            }
            if (datas.Contains("س"))
            {
                datas = datas.Replace("س", "y121t");

            }
            if (datas.Contains("ش"))
            {
                datas = datas.Replace("ش", "v131c");

            }
            if (datas.Contains("ص"))
            {
                datas = datas.Replace("ص", "t141r");

            }
            if (datas.Contains("ض"))
            {
                datas = datas.Replace("ض", "l151k");

            }
            if (datas.Contains("ط"))
            {
                datas = datas.Replace("ط", "t161r");

            }
            if (datas.Contains("ظ"))
            {
                datas.Replace("ظ", "e171w");

            }
            if (datas.Contains("ع"))
            {
                datas.Replace("ع", "f181d");

            }
            if (datas.Contains("غ"))
            {
                datas = datas.Replace("غ", "b191v");

            }
            if (datas.Contains("ف"))
            {
                datas = datas.Replace("ف", "n202b");

            }
            if (datas.Contains("ق"))
            {
                datas = datas.Replace("ق", "m212n");

            }
            if (datas.Contains("ك"))
            {
                datas = datas.Replace("ك", "h222g");

            }
            if (datas.Contains("ل"))
            {
                datas = datas.Replace("ل", "f232d");

            }
            if (datas.Contains("م"))
            {
                datas = datas.Replace("م", "r242e");

            }
            if (datas.Contains("ن"))
            {
                datas = datas.Replace("ن", "y252t");

            }
            if (datas.Contains("ه"))
            {
                datas = datas.Replace("ه", "w262q");

            }
            if (datas.Contains("و"))
            {
                datas = datas.Replace("و", "p272o");

            }
            if (datas.Contains("ي") || datas.Contains("ى"))
            {
                datas = datas.Replace("ي", "p282o");
                datas = datas.Replace("ى", "p282u");
            }

        #endregion

        byte[] data = ASCIIEncoding.ASCII.GetBytes(datas);
		TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
		if (Key == null)
        {
			tdes.GenerateKey();
			tdes.GenerateIV();
			Key = tdes.Key;
			IV = tdes.IV;
		} 
        else
        {
			tdes.Key = Key;
			tdes.IV = IV;
		}

		ICryptoTransform encryptor = tdes.CreateEncryptor();
		MemoryStream ms = new MemoryStream();
		CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
		cs.Write(data, 0, data.Length);
		cs.FlushFinalBlock();
		ms.Position = 0;
		byte[] result = new byte[ms.Length];
        ms.Read(result, 0, int.Parse(ms.Length.ToString()));
		cs.Close();
		string y = "";
		for (int i = 0; i <= result.Length - 1; i++) 
        {
			string x = result.GetValue(i).ToString();
			if (x.Length == 0) {
				x = "000" + x;
			}
            else if (x.Length == 1)
            {
				x = "00" + x;
			} 
            else if (x.Length == 2)
            {
				x = "0" + x;
			}
			y = y + x;
		}
		return y;
	}

    public static string Decrypt(string data)
	{
        byte[] z = new byte[(data.Length / 3)];
        for ( int i = 0; i <= (data.Length / 3) - 1; i++)
        {
            z[i] = Convert.ToByte(data.Substring(i * 3, 3));
		}

		TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
		tdes.Key = Key;
		tdes.IV = IV;
		ICryptoTransform decryptor = tdes.CreateDecryptor();
		MemoryStream ms = new MemoryStream();
		CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write);
		cs.Write(z, 0, z.Length);
		cs.FlushFinalBlock();
		ms.Position = 0;
		byte[] result = new byte[ms.Length];
		ms.Read(result, 0, int.Parse(ms.Length.ToString()));
		cs.Close();

        #region Replace Words
        string  dataArray =  ASCIIEncoding.UTF7.GetString(result);
       // data = "";

        if (dataArray.Contains("a11d") || dataArray.Contains("a11s") || dataArray.Contains("a11m"))
            {
                dataArray = dataArray.Replace("a11d", "ا"); 
                dataArray = dataArray.Replace("a11s", "أ");
               dataArray = dataArray.Replace("a11m", "إ");

            }
        if (dataArray.Contains("l22k"))
            {
                dataArray = dataArray.Replace("l22k", "ب");

            }
        if (dataArray.Contains("o33i"))
            {
                dataArray = dataArray.Replace("o33i", "ت");

            }
        if (dataArray.Contains("t44r"))
            {
                dataArray = dataArray.Replace("t44r", "ث");

            }
        if (dataArray.Contains("r55e"))
            {
                dataArray = dataArray.Replace("r55e", "ج");

            }
        if (dataArray.Contains("u66y"))
            {
                dataArray = dataArray.Replace("u66y", "ح");

            }
        if (dataArray.Contains("r77e"))
            {
                dataArray = dataArray.Replace("r77e", "خ");

            }
        if (dataArray.Contains("d88s"))
            {
                dataArray = dataArray.Replace("d88s", "د");

            }
        if (dataArray.Contains("t99t"))
            {
                dataArray = dataArray.Replace("t99t", "ذ");

            }
        if (dataArray.Contains("e101w"))
            {
                dataArray = dataArray.Replace("e101w", "ر");

            }
        if (dataArray.Contains("p111o"))
            {
                dataArray = dataArray.Replace("p111o", "ز");

            }
        if (dataArray.Contains("y121t"))
            {
                dataArray = dataArray.Replace("y121t", "س");

            }
        if (dataArray.Contains("v131c"))
            {
                dataArray = dataArray.Replace("v131c", "ش");

            }
        if (dataArray.Contains("t141r"))
            {
                dataArray = dataArray.Replace("t141r", "ص");

            }
        if (dataArray.Contains("l151k"))
            {
                dataArray = dataArray.Replace("l151k", "ض");

            }
        if (dataArray.Contains("t161r"))
            {
                dataArray = dataArray.Replace("t161r", "ط");

            }
        if (dataArray.Contains("e171w"))
            {
                dataArray = dataArray.Replace("e171w", "ظ");

            }
        if (dataArray.Contains("f181d"))
            {
                dataArray = dataArray.Replace("f181d", "ع");

            }
        if (dataArray.Contains("b191v"))
            {
                dataArray = dataArray.Replace("b191v", "غ");

            }
        if (dataArray.Contains("n202b"))
            {
                dataArray = dataArray.Replace("n202b", "ف");

            }
        if (dataArray.Contains("m212n"))
            {
                dataArray = dataArray.Replace("m212n", "ق");

            }
        if (dataArray.Contains("h222g"))
            {
                dataArray = dataArray.Replace("h222g", "ك");

            }
        if (dataArray.Contains("f232d"))
            {
                dataArray = dataArray.Replace("f232d", "ل");

            }
        if (dataArray.Contains("r242e"))
            {
                dataArray = dataArray.Replace("r242e", "م");

            }
        if (dataArray.Contains("y252t"))
            {
                dataArray = dataArray.Replace("y252t", "ن");

            }
        if (dataArray.Contains("w262q"))
            {
                dataArray = dataArray.Replace("w262q", "ه");

            }
        if (dataArray.Contains("p272o"))
            {
                dataArray = dataArray.Replace("p272o", "و");

            }
        if (dataArray.Contains("p282o") || dataArray.Contains("p282u"))
            {
                dataArray = dataArray.Replace("p282o", "ي");
                dataArray = dataArray.Replace("p282u", "ى");
            }
            
        
        #endregion

        return dataArray;
	}

    }

public static class SecurityHelper_Lat
{
    public static byte[] Key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
    public static byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8 };

    public static string Encrypt(string strData)
    {
        #region // Replace Words
        string datas = strData;
        // string[] dataArray = datas.Split(' ');

        datas = datas.ToUpper();
        if (datas.Contains("A"))
        {
            datas = datas.Replace("A", "a11d");
            

        }
        if (datas.Contains("B"))
        {
            datas = datas.Replace("B", "l22k");

        }
        if (datas.Contains("C"))
        {
            datas = datas.Replace("C", "o33i");

        }
        if (datas.Contains("D"))
        {
            datas = datas.Replace("D", "t44r");

        }
        if (datas.Contains("E"))
        {
            datas = datas.Replace("E", "r55e");

        }
        if (datas.Contains("F"))
        {
            datas = datas.Replace("F", "u66y");

        }
        if (datas.Contains("G"))
        {
            datas = datas.Replace("G", "r77e");

        }
        if (datas.Contains("H"))
        {
            datas = datas.Replace("H", "d88s");

        }
        if (datas.Contains("I"))
        {
            datas = datas.Replace("I", "t99t");

        }
        if (datas.Contains("J"))
        {
            datas = datas.Replace("J", "e101w");

        }
        if (datas.Contains("K"))
        {
            datas = datas.Replace("K", "p111o");

        }
        if (datas.Contains("L"))
        {
            datas = datas.Replace("L", "y121t");

        }
        if (datas.Contains("M"))
        {
            datas = datas.Replace("M", "v131c");

        }
        if (datas.Contains("N"))
        {
            datas = datas.Replace("N", "t141r");

        }
        if (datas.Contains("O"))
        {
            datas = datas.Replace("O", "l151k");

        }
        if (datas.Contains("P"))
        {
            datas = datas.Replace("P", "t161r");

        }
        if (datas.Contains("Q"))
        {
            datas.Replace("Q", "e171w");

        }
        if (datas.Contains("R"))
        {
            datas.Replace("R", "f181d");

        }
        if (datas.Contains("S"))
        {
            datas = datas.Replace("S", "b191v");

        }
        if (datas.Contains("T"))
        {
            datas = datas.Replace("T", "n202b");

        }
        if (datas.Contains("U"))
        {
            datas = datas.Replace("U", "m212n");

        }
        if (datas.Contains("V"))
        {
            datas = datas.Replace("V", "h222g");

        }
        if (datas.Contains("W"))
        {
            datas = datas.Replace("W", "f232d");

        }
        if (datas.Contains("X"))
        {
            datas = datas.Replace("X", "r242e");

        }
        if (datas.Contains("Y"))
        {
            datas = datas.Replace("Y", "y252t");

        }
        if (datas.Contains("Z"))
        {
            datas = datas.Replace("Z", "w262q");

        }
       

        #endregion

        byte[] data = ASCIIEncoding.ASCII.GetBytes(datas);
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        if (Key == null)
        {
            tdes.GenerateKey();
            tdes.GenerateIV();
            Key = tdes.Key;
            IV = tdes.IV;
        }
        else
        {
            tdes.Key = Key;
            tdes.IV = IV;
        }

        ICryptoTransform encryptor = tdes.CreateEncryptor();
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        cs.Write(data, 0, data.Length);
        cs.FlushFinalBlock();
        ms.Position = 0;
        byte[] result = new byte[ms.Length];
        ms.Read(result, 0, int.Parse(ms.Length.ToString()));
        cs.Close();
        string y = "";
        for (int i = 0; i <= result.Length - 1; i++)
        {
            string x = result.GetValue(i).ToString();
            if (x.Length == 0)
            {
                x = "000" + x;
            }
            else if (x.Length == 1)
            {
                x = "00" + x;
            }
            else if (x.Length == 2)
            {
                x = "0" + x;
            }
            y = y + x;
        }
        y = y.Substring(0,20);
        return y;
    }

    public static string Decrypt(string data)
    {
        byte[] z = new byte[(data.Length / 3)];
        for (int i = 0; i <= (data.Length / 3) - 1; i++)
        {
            z[i] = Convert.ToByte(data.Substring(i * 3, 3));
        }

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = Key;
        tdes.IV = IV;
        ICryptoTransform decryptor = tdes.CreateDecryptor();
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write);
        cs.Write(z, 0, z.Length);
        cs.FlushFinalBlock();
        ms.Position = 0;
        byte[] result = new byte[ms.Length];
        ms.Read(result, 0, int.Parse(ms.Length.ToString()));
        cs.Close();

        #region Replace Words
        string dataArray = ASCIIEncoding.UTF7.GetString(result);
        // data = "";

        if (dataArray.Contains("a11d"))
        {
            dataArray = dataArray.Replace("a11d", "A");
            

        }
        if (dataArray.Contains("l22k"))
        {
            dataArray = dataArray.Replace("l22k", "B");

        }
        if (dataArray.Contains("o33i"))
        {
            dataArray = dataArray.Replace("o33i", "C");

        }
        if (dataArray.Contains("t44r"))
        {
            dataArray = dataArray.Replace("t44r", "D");

        }
        if (dataArray.Contains("r55e"))
        {
            dataArray = dataArray.Replace("r55e", "E");

        }
        if (dataArray.Contains("u66y"))
        {
            dataArray = dataArray.Replace("u66y", "F");

        }
        if (dataArray.Contains("r77e"))
        {
            dataArray = dataArray.Replace("r77e", "G");

        }
        if (dataArray.Contains("d88s"))
        {
            dataArray = dataArray.Replace("d88s", "H");

        }
        if (dataArray.Contains("t99t"))
        {
            dataArray = dataArray.Replace("t99t", "I");

        }
        if (dataArray.Contains("e101w"))
        {
            dataArray = dataArray.Replace("e101w", "J");

        }
        if (dataArray.Contains("p111o"))
        {
            dataArray = dataArray.Replace("p111o", "K");

        }
        if (dataArray.Contains("y121t"))
        {
            dataArray = dataArray.Replace("y121t", "L");

        }
        if (dataArray.Contains("v131c"))
        {
            dataArray = dataArray.Replace("v131c", "M");

        }
        if (dataArray.Contains("t141r"))
        {
            dataArray = dataArray.Replace("t141r", "N");

        }
        if (dataArray.Contains("l151k"))
        {
            dataArray = dataArray.Replace("l151k", "O");

        }
        if (dataArray.Contains("t161r"))
        {
            dataArray = dataArray.Replace("t161r", "P");

        }
        if (dataArray.Contains("e171w"))
        {
            dataArray = dataArray.Replace("e171w", "Q");

        }
        if (dataArray.Contains("f181d"))
        {
            dataArray = dataArray.Replace("f181d", "R");

        }
        if (dataArray.Contains("b191v"))
        {
            dataArray = dataArray.Replace("b191v", "S");

        }
        if (dataArray.Contains("n202b"))
        {
            dataArray = dataArray.Replace("n202b", "T");

        }
        if (dataArray.Contains("m212n"))
        {
            dataArray = dataArray.Replace("m212n", "U");

        }
        if (dataArray.Contains("h222g"))
        {
            dataArray = dataArray.Replace("h222g", "V");

        }
        if (dataArray.Contains("f232d"))
        {
            dataArray = dataArray.Replace("f232d", "W");

        }
        if (dataArray.Contains("r242e"))
        {
            dataArray = dataArray.Replace("r242e", "X");

        }
        if (dataArray.Contains("y252t"))
        {
            dataArray = dataArray.Replace("y252t", "Y");

        }
        if (dataArray.Contains("w262q"))
        {
            dataArray = dataArray.Replace("w262q", "Z");

        }
        


        #endregion

        return dataArray;
    }

    public static string Encrypt_Serial(string data)
    {
        decimal num = 0;
        if (data != "")
        {
            List<int> list = new List<int>();
            num = Convert.ToDecimal(data);
            num = num / num.ToString().Length;
            num = num * (num.ToString().Length - 15);
        }

        string n = num.ToString();
        if (n.Contains('5'))
        {
            n = n.Replace('5', 'K');
        }

        if (n.Contains('8'))
        {
            n = n.Replace('8', 'S');
        }

        if (n.Contains('7'))
        {
            n = n.Replace('7', 'G');
        }

        if (n.Contains('9'))
        {
            n = n.Replace('9', 'E');
        }

        if ((n.Length % 2) == 0)
        {
            return n.Substring(0, 6) + "MHAH"+n.Length.ToString();
        }
        else
        {
            return n.Substring(0, 6) + "HMHA" + n.Length.ToString();
        }

    }

}

