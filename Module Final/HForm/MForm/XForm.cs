using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace HForm
{
    public partial class XForm : Form
    {
        public DataBinder binder = new DataBinder();
        public DataTable TControls;
        public Dictionary<string, int> dicControls = new Dictionary<string, int>();

        public XForm()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

        }
        private string myTableName;
        private string myformType;

        [CategoryAttribute("DataBase"), DescriptionAttribute("Gets/Sets a value of TableName of Form.")]
        [Bindable(true), Browsable(true)]
        public string TableName
        {
            get
            {
                return myTableName;
            }
            set
            {
                myTableName = value;
            }
        }

        [CategoryAttribute("DataBase"), DescriptionAttribute("Gets/Sets a value of TableName of Form.")]
        [Bindable(true), Browsable(true)]
        public string FormType
        {
            get
            {
                return myformType;
            }
            set
            {
                myformType = value;
            }
        }


        public virtual bool BeforeSave()
        {
            return true;
        }
        public virtual bool AnotherLoad()
        {
            return AnotherLoad();
        }
        public virtual bool AnotherSave()
        {
            return AnotherSave();
        }
        public virtual bool AnotherDelete()
        {
            return AnotherDelete();
        }
        public virtual bool BeforeDelete()
        {
            return true;
        }


        public virtual void GetRecord()
        {
            binder.getRecord();
        }
        public virtual void ApplyChanges()
        {

        }
        public virtual void Print()
        {

        }
        public virtual void AfterGetRecord()
        {

        }
    }

}