using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


namespace HForm
{
    public static class FormsTasks
    {
        public static object o;
        public static Form frm;

        public static void openForm(string formName, object[] Parameters)
        {
            if (Parameters == null)
            {
                o = FormsTasks.createInstance(formName, null);
                (o as Form).Show();
                frm = (o as Form);
            }
            else
            {
                o = FormsTasks.createInstance(formName, Parameters);
                (o as Form).Show();
                frm = (o as Form);
            }
        }

        public static Type GetTypeForm(string formName)
        {
            Type typForm = null;
            Assembly asm = Assembly.LoadFrom(GlobalVariables.exeFile);
            try
            {
                foreach (Type t in asm.GetTypes())
                {
                    if (t.Name == formName)
                    {
                        typForm = t;
                        break;
                    }
                }
                return typForm;
            }
            catch { return typForm; }
        }

        public static object createInstance(string str, object[] Parameters)
        {
            if (Parameters == null)
            {
                o = Activator.CreateInstance(GetTypeForm(str));
            }
            else
                o = Activator.CreateInstance(GetTypeForm(str), Parameters);
            return o;
        }

        public static void CreateInstance()
        {

        }

        public static object getInstance()
        {
            return o;
        }

        public static object[] PrepareParameters(string ParameterData)
        {
            Dictionary<string, object> MyDictionary = new Dictionary<string, object>();
            object[] Parameters = null;
            string ParameterName;
            string ParameterValue;
            ParameterName = ParameterData.Substring(0, ParameterData.IndexOf('='));
            int FirstIndex = ParameterData.IndexOf('=') + 1;
            ParameterValue = ParameterData.Substring(FirstIndex, ParameterData.Length - FirstIndex);
            MyDictionary.Add(ParameterName, ParameterValue);
            Parameters = new object[1];
            Parameters[0] = ParameterValue;
            return Parameters;
        }

    }

}