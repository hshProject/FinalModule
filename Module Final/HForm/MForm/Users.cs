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
    public partial class Users : DataForm
    {
        public Users()
        {
            InitializeComponent();
            SetGrid();
        }
        void anotherLoad()
        {
            this.btnlist.Enabled = false;

        }

        private void Users_Load(object sender, EventArgs e)
        {
            this.NextCodeControl = txtUserId.Name;
            binder.NextCode(NextCodeControl, "");
            anotherLoad();
        }
        public override void NextCode()
        {
            base.NextCode();
            this.btnlist.Enabled = false;
        }
        void SetGrid()
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.ValueMember = "GroupID";
            column.DisplayMember = "GroupAraName";
            DataTable dt = DataLayer.executeDataTable("select * from Groups");

            column.DataSource = dt;

            column.HeaderText = "المجموعة";
            column.Name = "GroupId";
            column.ValueType = typeof(int);
            hGrid.Columns.Add(column);


        }

        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtUserId.Text != "")
            { GetRecord(); hGrid.Enabled = true; }
        }

        public override bool BeforeSave()
        {
            string sql = "select UserAraName from Users where UserAraName ='" + txtUserAraName.Text + "' and UserId!="+txtUserId.Text+"";
            object UserAraName= DataLayer.Executescalar(sql);
            if (UserAraName == null) return true;
            else { MessageBox.Show("عفوا لا يجوز تكرار اسم المستخدم"); } return false;
            
        }

    }

}