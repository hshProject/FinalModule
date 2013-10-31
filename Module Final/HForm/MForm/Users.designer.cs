namespace HForm
{
    partial class Users
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
            this.lblUserId = new HControls.HLabel();
            this.txtUserId = new HControls.HTextBox();
            this.lblUserAraName = new HControls.HLabel();
            this.txtUserAraName = new HControls.HTextBox();
            this.lblUserPassword = new HControls.HLabel();
            this.txtUserPassword = new HControls.HTextBox();
            this.chkNotActive = new HControls.HCheckbox();
            this.lblNotActive = new HControls.HLabel();
            this.hGrid = new HControls.HGrid();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.lblUserId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserId.FieldName = "UserId";
            this.lblUserId.ForeColor = System.Drawing.Color.White;
            this.lblUserId.Location = new System.Drawing.Point(24, 69);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(133, 23);
            this.lblUserId.TabIndex = 9;
            this.lblUserId.Text = "كود المستخدم";
            // 
            // txtUserId
            // 
            this.txtUserId.ComboBoxRelatedWith = null;
            this.txtUserId.FieldName = "UserId";
            this.txtUserId.key = false;
            this.txtUserId.Language = HControls.Languages.English;
            this.txtUserId.Location = new System.Drawing.Point(172, 73);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.required = false;
            this.txtUserId.SerachFields = null;
            this.txtUserId.SerachFilter = null;
            this.txtUserId.SerachTable = null;
            this.txtUserId.Size = new System.Drawing.Size(81, 23);
            this.txtUserId.TabIndex = 10;
            this.txtUserId.TextBoxRelatedWith = null;
            this.txtUserId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserId_KeyDown);
            // 
            // lblUserAraName
            // 
            this.lblUserAraName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.lblUserAraName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserAraName.FieldName = "UserAraName";
            this.lblUserAraName.ForeColor = System.Drawing.Color.White;
            this.lblUserAraName.Location = new System.Drawing.Point(24, 101);
            this.lblUserAraName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserAraName.Name = "lblUserAraName";
            this.lblUserAraName.Size = new System.Drawing.Size(133, 23);
            this.lblUserAraName.TabIndex = 11;
            this.lblUserAraName.Text = "الاسم العربى";
            // 
            // txtUserAraName
            // 
            this.txtUserAraName.ComboBoxRelatedWith = null;
            this.txtUserAraName.FieldName = "UserAraName";
            this.txtUserAraName.key = false;
            this.txtUserAraName.Location = new System.Drawing.Point(172, 105);
            this.txtUserAraName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserAraName.Name = "txtUserAraName";
            this.txtUserAraName.required = true;
            this.txtUserAraName.SerachFields = null;
            this.txtUserAraName.SerachFilter = null;
            this.txtUserAraName.SerachTable = null;
            this.txtUserAraName.Size = new System.Drawing.Size(365, 23);
            this.txtUserAraName.TabIndex = 12;
            this.txtUserAraName.TextBoxRelatedWith = null;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.lblUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserPassword.FieldName = "UserPassword";
            this.lblUserPassword.ForeColor = System.Drawing.Color.White;
            this.lblUserPassword.Location = new System.Drawing.Point(24, 135);
            this.lblUserPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(133, 23);
            this.lblUserPassword.TabIndex = 13;
            this.lblUserPassword.Text = "كلمة المرور";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.ComboBoxRelatedWith = null;
            this.txtUserPassword.FieldName = "UserPassword";
            this.txtUserPassword.key = false;
            this.txtUserPassword.Location = new System.Drawing.Point(172, 139);
            this.txtUserPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.required = true;
            this.txtUserPassword.SerachFields = null;
            this.txtUserPassword.SerachFilter = null;
            this.txtUserPassword.SerachTable = null;
            this.txtUserPassword.Size = new System.Drawing.Size(365, 23);
            this.txtUserPassword.TabIndex = 14;
            this.txtUserPassword.TextBoxRelatedWith = null;
            // 
            // chkNotActive
            // 
            this.chkNotActive.AutoSize = true;
            this.chkNotActive.FieldName = "NotActive";
            this.chkNotActive.Location = new System.Drawing.Point(180, 178);
            this.chkNotActive.Margin = new System.Windows.Forms.Padding(4);
            this.chkNotActive.Name = "chkNotActive";
            this.chkNotActive.Size = new System.Drawing.Size(15, 14);
            this.chkNotActive.TabIndex = 16;
            this.chkNotActive.UseVisualStyleBackColor = true;
            // 
            // lblNotActive
            // 
            this.lblNotActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.lblNotActive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNotActive.FieldName = "NotActive";
            this.lblNotActive.ForeColor = System.Drawing.Color.White;
            this.lblNotActive.Location = new System.Drawing.Point(24, 167);
            this.lblNotActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotActive.Name = "lblNotActive";
            this.lblNotActive.Size = new System.Drawing.Size(133, 23);
            this.lblNotActive.TabIndex = 15;
            this.lblNotActive.Text = "ايقاف تعامل";
            // 
            // hGrid
            // 
            this.hGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hGrid.Enabled = false;
            this.hGrid.Location = new System.Drawing.Point(24, 203);
            this.hGrid.Margin = new System.Windows.Forms.Padding(4);
            this.hGrid.Name = "hGrid";
            this.hGrid.Size = new System.Drawing.Size(355, 32);
            this.hGrid.TabIndex = 21;
            this.hGrid.TableName = "UsersGroups";
            this.hGrid.Visible = false;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 262);
            this.Controls.Add(this.hGrid);
            this.Controls.Add(this.chkNotActive);
            this.Controls.Add(this.lblNotActive);
            this.Controls.Add(this.lblUserPassword);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.lblUserAraName);
            this.Controls.Add(this.txtUserAraName);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtUserId);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Users";
            this.TableName = "Users";
            this.Text = "المستخدمين";
            this.Load += new System.EventHandler(this.Users_Load);
            this.Controls.SetChildIndex(this.txtUserId, 0);
            this.Controls.SetChildIndex(this.lblUserId, 0);
            this.Controls.SetChildIndex(this.txtUserAraName, 0);
            this.Controls.SetChildIndex(this.lblUserAraName, 0);
            this.Controls.SetChildIndex(this.txtUserPassword, 0);
            this.Controls.SetChildIndex(this.lblUserPassword, 0);
            this.Controls.SetChildIndex(this.lblNotActive, 0);
            this.Controls.SetChildIndex(this.chkNotActive, 0);
            this.Controls.SetChildIndex(this.hGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HControls.HLabel lblUserId;
        private HControls.HTextBox txtUserId;
        private HControls.HLabel lblUserAraName;
        private HControls.HTextBox txtUserAraName;
        private HControls.HLabel lblUserPassword;
        private HControls.HTextBox txtUserPassword;
        private HControls.HCheckbox chkNotActive;
        private HControls.HLabel lblNotActive;
        private HControls.HGrid hGrid;

    }
}