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
    public partial class UserPermissions : Form
    {
        public UserPermissions()
        {
            InitializeComponent();
            SetGrid();
            //   AnotherLoad();
        }

        void AnotherLoad()
        {
            //   lblUserId.Text = "اسم الستخدم";
            // Class1.startConnection();
            //DataLayer.SelectAllData("select UserId,UserAraName from Users", x, "UserAraName", "UserId");
            DataLayer.fillCombo(cmbUserId, "");

        }

        //public override bool  BeforeSave()
        //{
        //string sql = "delete from PrgPer where UserId=1 and ProgId=100";
        //DataLayer.executeNonQuery(sql);
        ////insert  Permission row by row
        //foreach (DataGridViewRow row in GridMenus.Rows)
        //{
        //    string sql2 = "insert into PrgPer values(1,101,true,true,true,true) ";
        //    DataLayer.ExecuteNonQuery(sql2);
        //}
        //return true;
        //}

        void SetGrid()
        {
            string sql = @"select Programs.ProgId as 'كودالشاشة',ArabicName  as 'اسم الشاشة',[Read] as 'قراءة',[Insert] as 'ادخال',[Edit] as 'تعديل',[Delete] as 'مسح' from Programs 
left join PrgPer on 1=2";
            DataTable dt = DataLayer.ExecuteDataTable(sql);
            GridMenus.DataSource = dt;
            GridMenus.EndEdit();
            // GridMenus.Columns[0].Width = 100;

        }

        private void UserPermissions_Load(object sender, EventArgs e)
        {
            AnotherLoad();
        }

        private void GridMenus_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // foreach (DataGridViewRow r in GridMenus.Rows)
            //{
            //   r.Cells["Read"].Value = true;

            //}
            GridMenus.SelectedRows[0].Cells["Read"].Value = true;
            GridMenus.SelectedRows[0].Cells["Insert"].Value = true;
            GridMenus.SelectedRows[0].Cells["Edit"].Value = true;
            GridMenus.SelectedRows[0].Cells["Delete"].Value = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUserId.SelectedValue != null)
                {
                    string sql = "delete from PrgPer where UserId=" + cmbUserId.SelectedValue + "";
                    DataLayer.executeNonQuery(sql);
                    foreach (DataGridViewRow r in GridMenus.Rows)
                    {
                        if (r.Cells["قراءة"].Value != null && r.Cells["ادخال"].Value != null && r.Cells["تعديل"].Value != null && r.Cells["مسح"].Value != null && r.Cells["قراءة"].Value.ToString() == "True" && r.Cells["ادخال"].Value.ToString() == "True" && r.Cells["تعديل"].Value.ToString() == "True" && r.Cells["مسح"].Value.ToString() == "True")
                        {
                            string sql2 = "insert into PrgPer values (" + cmbUserId.SelectedValue + "," + r.Cells["كودالشاشة"].Value + @",
'" + r.Cells["قراءة"].Value + "','" + r.Cells["ادخال"].Value + "','" + r.Cells["تعديل"].Value + "','" + r.Cells["مسح"].Value + "')";
                            DataLayer.executeNonQuery(sql2);
                        }

                    }
                    MessageBox.Show("تم الحفظ");
                    cmbUserId.SelectedValue = DBNull.Value;
                }
            }
            catch { };
        }

        private void cmbUserId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbUserId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbUserId.SelectedValue != null)
            {
                string sql = @"select Programs.ProgId as 'كودالشاشة',ArabicName  as 'اسم الشاشة',[Read] as 'قراءة',[Insert] as 'ادخال',[Edit] as 'تعديل',[Delete] as 'مسح' from Programs left join PrgPer on Programs.ProgId=PrgPer.ProgId and UserId=
" + cmbUserId.SelectedValue + "";
                DataTable dt2 = DataLayer.ExecuteDataTable(sql);
                DataTable dtNull = new DataTable();
                GridMenus.DataSource = dtNull;

                GridMenus.DataSource = dt2;
                //   txtUserId.Text = cmbUserId.SelectedValue.ToString();
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                foreach (DataGridViewRow r in GridMenus.Rows)
                {
                    r.Cells["قراءة"].Value = 1;
                    r.Cells["تعديل"].Value = 1;
                    r.Cells["مسح"].Value = 1;
                    r.Cells["ادخال"].Value = 1;
                }

            }
            else
            {
                foreach (DataGridViewRow r in GridMenus.Rows)
                {
                    r.Cells["قراءة"].Value = 0;
                    r.Cells["تعديل"].Value = 0;
                    r.Cells["ادخال"].Value = 0;
                    r.Cells["مسح"].Value = 0;
                }
            }
        }
        //delete all permissions 
    }

}
