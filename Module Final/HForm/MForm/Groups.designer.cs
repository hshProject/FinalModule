namespace HForm
{
    partial class Groups
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
            this.lblGroupID = new HControls.HLabel();
            this.txtGroupID = new HControls.HTextBox();
            this.lblInstCode = new HControls.HLabel();
            this.txtGroupAraName = new HControls.HTextBox();
            this.hLabel2 = new HControls.HLabel();
            this.txtGroupLatName = new HControls.HTextBox();
            this.chkNotActive = new HControls.HCheckbox();
            this.lblNotActive = new HControls.HLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGroupID
            // 
            this.lblGroupID.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblGroupID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGroupID.FieldName = "GroupID";
            this.lblGroupID.Location = new System.Drawing.Point(16, 76);
            this.lblGroupID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupID.Name = "lblGroupID";
            this.lblGroupID.Size = new System.Drawing.Size(133, 25);
            this.lblGroupID.TabIndex = 9;
            this.lblGroupID.Text = "كود المجموعة";
            // 
            // txtGroupID
            // 
            this.txtGroupID.ComboBoxRelatedWith = null;
            this.txtGroupID.FieldName = "GroupID";
            this.txtGroupID.key = false;
            this.txtGroupID.Location = new System.Drawing.Point(157, 76);
            this.txtGroupID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.required = true;
            this.txtGroupID.SerachFields = null;
            this.txtGroupID.SerachFilter = null;
            this.txtGroupID.SerachTable = null;
            this.txtGroupID.Size = new System.Drawing.Size(81, 23);
            this.txtGroupID.TabIndex = 10;
            this.txtGroupID.TextBoxRelatedWith = null;
            this.txtGroupID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupID_KeyDown);
            // 
            // lblInstCode
            // 
            this.lblInstCode.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInstCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInstCode.FieldName = "GroupAraName";
            this.lblInstCode.Location = new System.Drawing.Point(16, 108);
            this.lblInstCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstCode.Name = "lblInstCode";
            this.lblInstCode.Size = new System.Drawing.Size(133, 28);
            this.lblInstCode.TabIndex = 12;
            this.lblInstCode.Text = "الاسم العربى";
            // 
            // txtGroupAraName
            // 
            this.txtGroupAraName.ComboBoxRelatedWith = null;
            this.txtGroupAraName.FieldName = "GroupAraName";
            this.txtGroupAraName.key = false;
            this.txtGroupAraName.Location = new System.Drawing.Point(157, 108);
            this.txtGroupAraName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGroupAraName.Name = "txtGroupAraName";
            this.txtGroupAraName.required = false;
            this.txtGroupAraName.SerachFields = null;
            this.txtGroupAraName.SerachFilter = null;
            this.txtGroupAraName.SerachTable = null;
            this.txtGroupAraName.Size = new System.Drawing.Size(231, 23);
            this.txtGroupAraName.TabIndex = 13;
            this.txtGroupAraName.TextBoxRelatedWith = null;
            // 
            // hLabel2
            // 
            this.hLabel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.hLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hLabel2.FieldName = "GroupLatName";
            this.hLabel2.Location = new System.Drawing.Point(16, 143);
            this.hLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hLabel2.Name = "hLabel2";
            this.hLabel2.Size = new System.Drawing.Size(133, 28);
            this.hLabel2.TabIndex = 14;
            this.hLabel2.Text = "الاسم الانجليزى";
            // 
            // txtGroupLatName
            // 
            this.txtGroupLatName.ComboBoxRelatedWith = null;
            this.txtGroupLatName.FieldName = "GroupLatName";
            this.txtGroupLatName.key = false;
            this.txtGroupLatName.Language = HControls.Languages.English;
            this.txtGroupLatName.Location = new System.Drawing.Point(157, 140);
            this.txtGroupLatName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGroupLatName.Name = "txtGroupLatName";
            this.txtGroupLatName.required = false;
            this.txtGroupLatName.SerachFields = null;
            this.txtGroupLatName.SerachFilter = null;
            this.txtGroupLatName.SerachTable = null;
            this.txtGroupLatName.Size = new System.Drawing.Size(231, 23);
            this.txtGroupLatName.TabIndex = 15;
            this.txtGroupLatName.TextBoxRelatedWith = null;
            // 
            // chkNotActive
            // 
            this.chkNotActive.AutoSize = true;
            this.chkNotActive.FieldName = "NotActive";
            this.chkNotActive.Location = new System.Drawing.Point(157, 172);
            this.chkNotActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNotActive.Name = "chkNotActive";
            this.chkNotActive.Size = new System.Drawing.Size(15, 14);
            this.chkNotActive.TabIndex = 21;
            this.chkNotActive.UseVisualStyleBackColor = true;
            // 
            // lblNotActive
            // 
            this.lblNotActive.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblNotActive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNotActive.FieldName = "NotActive";
            this.lblNotActive.Location = new System.Drawing.Point(16, 172);
            this.lblNotActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotActive.Name = "lblNotActive";
            this.lblNotActive.Size = new System.Drawing.Size(133, 28);
            this.lblNotActive.TabIndex = 20;
            this.lblNotActive.Text = "ايقاف تعامل";
            // 
            // Groups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 288);
            this.Controls.Add(this.chkNotActive);
            this.Controls.Add(this.lblNotActive);
            this.Controls.Add(this.hLabel2);
            this.Controls.Add(this.txtGroupLatName);
            this.Controls.Add(this.lblInstCode);
            this.Controls.Add(this.txtGroupAraName);
            this.Controls.Add(this.lblGroupID);
            this.Controls.Add(this.txtGroupID);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Groups";
            this.TableName = "Groups";
            this.Text = "المجموعات";
            this.Load += new System.EventHandler(this.Groups_Load);
            this.Controls.SetChildIndex(this.txtGroupID, 0);
            this.Controls.SetChildIndex(this.lblGroupID, 0);
            this.Controls.SetChildIndex(this.txtGroupAraName, 0);
            this.Controls.SetChildIndex(this.lblInstCode, 0);
            this.Controls.SetChildIndex(this.txtGroupLatName, 0);
            this.Controls.SetChildIndex(this.hLabel2, 0);
            this.Controls.SetChildIndex(this.lblNotActive, 0);
            this.Controls.SetChildIndex(this.chkNotActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HControls.HLabel lblGroupID;
        private HControls.HTextBox txtGroupID;
        private HControls.HLabel lblInstCode;
        private HControls.HTextBox txtGroupAraName;
        private HControls.HLabel hLabel2;
        private HControls.HTextBox txtGroupLatName;
        private HControls.HCheckbox chkNotActive;
        private HControls.HLabel lblNotActive;

    }
}