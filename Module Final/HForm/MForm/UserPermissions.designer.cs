namespace HForm
{
    partial class UserPermissions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUserId = new System.Windows.Forms.Label();
            this.GridMenus = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.hLabel1 = new HControls.HLabel();
            this.txtUser = new HControls.HTextBox();
            this.x = new System.Windows.Forms.ComboBox();
            this.cmbUserId = new HControls.HComboBox();
            this.chkSelectAll = new HControls.HCheckbox();
            this.hLabel2 = new HControls.HLabel();
            ((System.ComponentModel.ISupportInitialize)(this.GridMenus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.Location = new System.Drawing.Point(459, 45);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(100, 23);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "كود المستخدم";
            this.lblUserId.Visible = false;
            // 
            // GridMenus
            // 
            this.GridMenus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridMenus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMenus.Location = new System.Drawing.Point(12, 79);
            this.GridMenus.Name = "GridMenus";
            this.GridMenus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GridMenus.Size = new System.Drawing.Size(769, 403);
            this.GridMenus.TabIndex = 2;
            this.GridMenus.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridMenus_RowHeaderMouseDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(314, 43);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 27);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // hLabel1
            // 
            this.hLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.hLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hLabel1.FieldName = null;
            this.hLabel1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.hLabel1.ForeColor = System.Drawing.Color.White;
            this.hLabel1.Location = new System.Drawing.Point(4, 43);
            this.hLabel1.Name = "hLabel1";
            this.hLabel1.Size = new System.Drawing.Size(100, 27);
            this.hLabel1.TabIndex = 10;
            this.hLabel1.Text = "كود المستخدم";
            // 
            // txtUser
            // 
            this.txtUser.ComboBoxRelatedWith = null;
            this.txtUser.FieldName = "UserId";
            this.txtUser.key = false;
            this.txtUser.Language = HControls.Languages.English;
            this.txtUser.Location = new System.Drawing.Point(110, 46);
            this.txtUser.Name = "txtUser";
            this.txtUser.required = false;
            this.txtUser.SerachFields = null;
            this.txtUser.SerachFilter = null;
            this.txtUser.SerachTable = null;
            this.txtUser.Size = new System.Drawing.Size(62, 20);
            this.txtUser.TabIndex = 11;
            this.txtUser.TextBoxRelatedWith = null;
            // 
            // x
            // 
            this.x.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.x.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.x.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.x.FormattingEnabled = true;
            this.x.Location = new System.Drawing.Point(541, 12);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(121, 21);
            this.x.TabIndex = 3;
            this.x.Visible = false;
            this.x.SelectedIndexChanged += new System.EventHandler(this.cmbUserId_SelectedIndexChanged);
            this.x.SelectionChangeCommitted += new System.EventHandler(this.cmbUserId_SelectionChangeCommitted);
            // 
            // cmbUserId
            // 
            this.cmbUserId.DisplayMember = "UserAraName";
            this.cmbUserId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserId.FieldName = null;
            this.cmbUserId.FormattingEnabled = true;
            this.cmbUserId.key = false;
            this.cmbUserId.Location = new System.Drawing.Point(178, 46);
            this.cmbUserId.MyDisplayMember = "UserAraName";
            this.cmbUserId.MyValueMember = "UserId";
            this.cmbUserId.Name = "cmbUserId";
            this.cmbUserId.required = false;
            this.cmbUserId.SearchFilter = null;
            this.cmbUserId.Size = new System.Drawing.Size(121, 21);
            this.cmbUserId.TabIndex = 12;
            this.cmbUserId.TableName = "Users";
            this.cmbUserId.TextBoxRelatedWith = "txtUser";
            this.cmbUserId.ValueMember = "UserId";
            this.cmbUserId.SelectionChangeCommitted += new System.EventHandler(this.cmbUserId_SelectionChangeCommitted);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.FieldName = null;
            this.chkSelectAll.Location = new System.Drawing.Point(564, 49);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAll.TabIndex = 13;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // hLabel2
            // 
            this.hLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.hLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hLabel2.FieldName = null;
            this.hLabel2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.hLabel2.ForeColor = System.Drawing.Color.White;
            this.hLabel2.Location = new System.Drawing.Point(458, 45);
            this.hLabel2.Name = "hLabel2";
            this.hLabel2.Size = new System.Drawing.Size(96, 23);
            this.hLabel2.TabIndex = 14;
            this.hLabel2.Text = "اختر الكل";
            // 
            // UserPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 509);
            this.Controls.Add(this.hLabel2);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.cmbUserId);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.hLabel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.x);
            this.Controls.Add(this.GridMenus);
            this.Controls.Add(this.lblUserId);
            this.Name = "UserPermissions";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صلاحيات مستحدمين";
            this.Load += new System.EventHandler(this.UserPermissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridMenus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.DataGridView GridMenus;
        private System.Windows.Forms.Button btnSave;
        private HControls.HLabel hLabel1;
        private HControls.HTextBox txtUser;
        private System.Windows.Forms.ComboBox x;
        private HControls.HComboBox cmbUserId;
        private HControls.HCheckbox chkSelectAll;
        private HControls.HLabel hLabel2;
    }
}