using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HControls;

namespace HForm
{
    public partial class frmSmallSearch : Form
    {
        HTextBox ht;
        string sql = "";
        DataTable dt;
        DataRow[] dr;
        Dictionary<string, string> field = new Dictionary<string, string>();
        public frmSmallSearch(HTextBox textboxSearch)
        {
            InitializeComponent();
            ht = textboxSearch;
            if (ht._SearchTable != null)
            {
                sql = "Select ";

                string[] column = ht._SearchFields.Split('&');
                foreach (string a in column)
                {
                    field.Add(a.Split(':')[0], a.Split(':')[1]);
                    sql += " " + a.Split(':')[0] + ",";
                }
                sql = sql.Remove(sql.Length - 1);
                sql += " from " + ht._SearchTable + " where 1=1 ";
                //-----------------
                #region SearchFilter ABUBAKR 10 Sept 2013
                if (txtSearchfor.Text.Trim() != "" && ht._SearchFilter != null && ht._SearchFilter != "")
                    sql += " and " + ht._SearchFilter;
                #endregion

              string   NotActivesql = @"   SELECT     COLUMN_NAME
                             FROM         INFORMATION_SCHEMA.COLUMNS
                             WHERE      (TABLE_NAME = '" + ht._SearchTable + @"') and COLUMN_NAME = 'NotActive' ";
                DataTable dt = DataLayer.executeDataTable(NotActivesql);
                if (dt.Rows.Count != 0)
                    sql += "  and isnull( NotActive ,0) =0";

                dt = DataLayer.executeDataTable(sql);
                grid.DataSource = dt;
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    
                    col.HeaderText = field[col.Name];
                }
            }
        }

        void fillcmbSfields()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Header");
            foreach (string a in field.Keys)
            {
                dt.Rows.Add(new string[] { a, field[a] });


            }
            cmbSFields.DisplayMember = "Header";
            cmbSFields.ValueMember = "Name";
            cmbSFields.DataSource = dt;


        }
        private void txtSearchfor_TextChanged(object sender, EventArgs e)
        {
            if (cmbSFields.SelectedValue != null && txtSearchfor.Text != null && txtSearchfor.Text != "")
            {
                #region SearchFilter ABUBAKR 10 Sept 2013
                if (txtSearchfor.Text.Trim() != "" && ht._SearchFilter != null && ht._SearchFilter != "")
                    txtSearchfor.Text += " and " + ht._SearchFilter;
                #endregion
                switch (cmbCritria.Text)
                {
                    case "":
                        break;
                    case "يساوى":
                        grid.DataSource = DataLayer.executeDataTable(sql + " where 1=1 and " + cmbSFields.SelectedValue + "  ='" + txtSearchfor.Text + "'");
                        break;
                    case "يبدا ب":
                        grid.DataSource = DataLayer.executeDataTable(sql + " where 1=1 and " + cmbSFields.SelectedValue + "  like '%" + txtSearchfor.Text + "'");
                        break;
                    case "ينتهى ب":
                        grid.DataSource = DataLayer.executeDataTable(sql + " where 1=1 and " + cmbSFields.SelectedValue + "  like'" + txtSearchfor.Text + "%'");
                        break;
                    case "يحتوى على":
                        grid.DataSource = DataLayer.executeDataTable(sql + " where 1=1 and " + cmbSFields.SelectedValue + "  like '%" + txtSearchfor.Text + "%'");

                        break;
                    case "لا يحتوى على":
                        grid.DataSource = DataLayer.executeDataTable(sql + " where 1=1 and " + cmbSFields.SelectedValue + " Not like'%" + txtSearchfor.Text + "%'");

                        break;


                }
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    col.HeaderText = field[col.Name];
                }
            }
            else if (cmbSFields.SelectedValue != null && txtSearchfor.Text != null && txtSearchfor.Text == "")
            {
                grid.DataSource = DataLayer.executeDataTable(sql);


            }

        }

        private void frmSmallSearch_Load(object sender, EventArgs e)
        {
            fillcmbSfields();
            cmbCritria.SelectedItem = cmbCritria.Items[0];
            cmbSFields.SelectedItem = cmbSFields.Items[0];
        }

        private void txtSearchfor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && grid.Rows.Count != 0)
            {
                grid.Focus();
                grid.CurrentCell = grid.Rows[0].Cells[0];
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && grid.CurrentCell != null)
            {
                ht.Text = grid.CurrentRow.Cells[0].Value.ToString();
                this.Close();
                this.Dispose();
            }
        }

               private void cmbSFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grid.Columns[cmbSFields.SelectedValue.ToString()].ValueType == typeof(string))
            {
                txtSearchfor._DataType = DataType.String;
            }
            if (grid.Columns[cmbSFields.SelectedValue.ToString()].ValueType == typeof(int))
            {
                txtSearchfor._DataType = DataType.Integer;
            }
            if (grid.Columns[cmbSFields.SelectedValue.ToString()].ValueType == typeof(decimal))
            {
                txtSearchfor._DataType = DataType.Decimal;
            }
        }
 

    }

}