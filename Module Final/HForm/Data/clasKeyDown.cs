using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace HForm
{
    public static class clasKeyDown
    {
        // public static void keyDown4Txt (PanelEx panl)
        //{
        //    foreach (Control ctrl in panl.Controls)
        //    {
        //        if (ctrl is TextBox || ctrl is TextBoxX || ctrl is ComboBox || ctrl is ComboBoxEx)
        //       ctrl.KeyDown+=new KeyEventHandler(ctrl_KeyDown);
        //    }
        //}

        public static void keyDown4Txt(Form frm)
        {
            //foreach (Control ctrl in frm.Controls)
            //{
            //    if (ctrl is TextBox || ctrl is TextBoxX || ctrl is ComboBox || ctrl is ComboBoxEx)
            //        ctrl.KeyDown += new KeyEventHandler(ctrl_KeyDown);
            //    if (ctrl is Panel)
            //    {
            //        foreach (Control ctrl2 in ctrl.Controls)
            //        {

            //            ctrl2.KeyDown += new KeyEventHandler(ctrl_KeyDown);
            //        }
            //    }
            //}
        }

        public static void keyDown4Txt(Panel panl)
        {
            foreach (Control ctrl in panl.Controls)
            {
                //if (ctrl is TextBox || ctrl is TextBoxX || ctrl is ComboBox || ctrl is ComboBoxEx)
                //    ctrl.KeyDown += new KeyEventHandler(ctrl_KeyDown);
            }
        }

        public static void ctrl_KeyDown(object Sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }
    }

}