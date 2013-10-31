using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
using HControls;


namespace HForm
{
    public partial class DataForm : XForm
    {
        #region Enums
        public enum RecordMode
        {
            None = 0,
            Insert = 1,
            Update = 3,
            Delete = 4,

        }
        #endregion
        HGrid List = new HGrid();

        public Dictionary<string, string> dicKeys = new Dictionary<string, string>();

        public string NextCodeControl = "";
        //HEMAILY
        //public string TableName = "";
        public RecordMode recordMode = RecordMode.None;
        // Mohamed Samir 8/6/2013
        public int ProgId;
        public DataTable userpermission;
        // Mohamed Samir 8/6/2013
        public DataForm()
        {
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
        }

        //void clear()
        //{
        //    foreach (Control co in this.Controls)
        //    {
        //        if (co is HTextBox)
        //        {
        //            co.Text = "";
        //        }
        //    }
        //}

        private void DataForm_Load(object sender, EventArgs e)
        {



            if (!this.DesignMode)
            {
                binder.frm = this;
                binder.LaodControlsProperites();
                clasReference obj = new clasReference();
                obj.makeJob(this);
                // DataBinder obj2 = new DataBinder();
                binder.fillCombo(this);
                // Mohamed Samir 8/6/2013
                ProgId = binder.get_progId(this.Name);
                userpermission = binder.Get_User_Permission(GlobalVariables.UserId, ProgId);
                RecordsNo.Text = binder.Get_Records_num(this.TableName).ToString();
                // Mohamed Samir 8/6/2013
                updateButtonsStatus();

                List.Width = 360;
                List.Top = this.toolStrip1.Height;
                List.Height = this.Height - (this.toolStrip1.Height + statusStrip1.Height + 40);
                //List.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
                //List.Left = this.Width - 50;
                //hemaily 5aug
                List.CellClick += List_RowEnter;
                List.AllowUserToDeleteRows = false;
                List.AllowUserToAddRows = false;
                // List.Enabled = false;

            }

            binder.frm = this;
            List.Name = "List";
            List.Visible = false;
            this.Controls.Add(List);
            List.Left = this.Width + 5;
            this.List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Top)));

        }

        public void updateButtonsStatus()
        {
            if (recordMode == RecordMode.Insert)
            {
                btnSave.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnDelete.Enabled = false;
            }
            else if (recordMode == RecordMode.Update)
            {
                btnSave.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnDelete.Enabled = true;
            }

            else
            {
                btnSave.Enabled = false;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnDelete.Enabled = false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //hemaily25may2013
            if (BeforeSave())
            {
                if (binder.Save(this))
                {
                  //  fillFooterTable(this.Controls);
                    DataBinder.Clear(this.Controls);
                    // 
                    //hemaily 22may2013
                    // this.AnotherSave();
                    updateButtonsStatus();
                    fillList();
                    NextCode();
                    //hemaily 5aug
                    RecordsNo.Text = binder.Get_Records_num(this.TableName).ToString();
                }
                else
                {

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (BeforeDelete())
            {
                this.recordMode = RecordMode.Delete;
                DialogResult dr = MessageBox.Show("هل أنت متأكد من الحذف ؟",
                    "تأكيد الحذف", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    binder.Delete(this);
                    this.recordMode = RecordMode.None;
                    updateButtonsStatus();
                    fillList();
                    //hemaily 5aug
                    RecordsNo.Text = binder.Get_Records_num(this.TableName).ToString();
                }
                else
                    return;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            ((HTextBox)this.Controls[NextCodeControl]).Text = binder.Next(this.TableName, ((HTextBox)this.Controls[NextCodeControl]), "", "");
            GetRecord();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            ((HTextBox)this.Controls[NextCodeControl]).Text = binder.Previous(this.TableName, ((HTextBox)this.Controls[NextCodeControl]), ((HTextBox)this.Controls[NextCodeControl]).Text, "");
            GetRecord();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ((HTextBox)this.Controls[NextCodeControl]).Text = binder.Next(this.TableName, ((HTextBox)this.Controls[NextCodeControl]), ((HTextBox)this.Controls[NextCodeControl]).Text, "");
            GetRecord();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            ((HTextBox)this.Controls[NextCodeControl]).Text = binder.Previous(this.TableName, ((HTextBox)this.Controls[NextCodeControl]), "", "");
            GetRecord();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            NextCode();

        }
        public virtual void NextCode()
        {
            DataBinder.Clear(this.Controls);
            binder.NextCode(this.NextCodeControl, "");
            this.Controls[NextCodeControl].Focus();

            this.recordMode = RecordMode.None;
            updateButtonsStatus();
        }


        protected void DataForm_KeyDown(object sender, KeyEventArgs e)
        {

            bool ctrls = e.KeyCode == Keys.F10;
            if (btnNew.Enabled && e.KeyCode == Keys.Escape)
            {
                btnNew_Click(btnNew, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnSave_Click(btnSave, null);
            }
            else if (btnDelete.Enabled && e.KeyCode == Keys.F1)
            {
                btnDelete_Click(btnDelete, null);
            }

            else if (btnPrevious.Enabled && e.KeyCode == Keys.F11)
            {
                btnPrevious_Click(btnPrevious, null);
            }
            else if (btnNext.Enabled && e.KeyCode == Keys.F12)
            {
                btnNext_Click(btnNext, null);
            }
            else if (btnExit.Enabled && e.KeyCode == Keys.F10)
            {
                btnExit_Click(btnExit, null);
            }
            else if (btnFirst.Enabled && e.KeyCode == Keys.Home && (Control.ModifierKeys & Keys.Control) != 0)
            {
                btnFirst_Click(btnFirst, null);
            }
            else if (btnLast.Enabled && e.KeyCode == Keys.End && (Control.ModifierKeys & Keys.Control) != 0)
            {
                btnLast_Click(btnLast, null);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            binder = new DataBinder(this);
            binder.LaodControlsProperites();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        //hemaily 22may2013

       


        void fillList()
        {
            string sql = " select ";
            foreach (DataRow row in TControls.Rows)
            {

                if (row["Control_Name"].ToString() != "")
                {

                    sql += row["Column_Name"].ToString() + " ,";
                }




            }
            //foreach (Control lb in this.Controls)
            //{
            //    if (lb is HLabel)
            //    {


            //        if (((HLabel)lb).FieldName != null)



            //    }

            //}
            sql = sql.Remove(sql.Length - 1);

            int width = 0;

            List.DataSource = DataLayer.executeDataTable(sql + " From " + this.TableName);
            foreach (DataGridViewColumn col in List.Columns)
            {
                if (col.Visible == true)
                {
                    width += col.Width;
                }
            }
            if (List.Visible)
                this.Width = List.Left + width + 200;
            else
                this.Width = List.Left;
            foreach (Control lb in this.Controls)
            {
                if (lb is HLabel)
                {
                    foreach (DataGridViewColumn col in List.Columns)
                    {
                        if (col.Name == ((HLabel)lb).FieldName)

                            col.HeaderText = ((HLabel)lb).Text;
                    }

                }

            }

            List.Width = this.Width - List.Left - 20;
            NextCode();

        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            if (List.Visible)
            {
                this.Width = List.Left;
                List.Visible = false; this.WindowState = FormWindowState.Normal ;
                this.CenterToParent();
            }
            else
            {
                List.Visible = true; List.BringToFront();
                this.WindowState = FormWindowState.Maximized; fillList();
                List.ReadOnly = true;
                this.Location = new Point(100, this.Location.Y);

            }
        }

        private void List_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                try
                {
                    DataRow[] rows = this.TControls.Select("IsKey =1", "");
                    foreach (DataRow row in rows)
                    {
                        if (row["Control_Name"] != null && row["Control_Name"].ToString() != "" && row["Control_Name"] != DBNull.Value)
                        {
                            HTextBox co = this.Controls[row["Control_Name"].ToString()] as HTextBox;
                            //hemaily 5Oct2013
                            if (co.DataType.ToString() != "DateTime")
                                co.Text = List.Rows[e.RowIndex].Cells[row["Column_name"].ToString()].Value.ToString();
                            else
                                co.Text = Convert.ToDateTime(List.Rows[e.RowIndex].Cells[row["Column_name"].ToString()].Value).ToShortDateString();
                        }
                    }
                    this.Controls[NextCodeControl].Text = List.Rows[e.RowIndex].Cells[((HTextBox)this.Controls[NextCodeControl]).FieldName].Value.ToString();
                    GetRecord();
                    this.updateButtonsStatus();
                }
                catch (Exception ex)
                {
                   
                }

            }
        }


    }


}
