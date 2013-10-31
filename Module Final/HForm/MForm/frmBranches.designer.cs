namespace HForm
{
    partial class frmBranches
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
            this.chkNotActive = new HControls.HCheckbox();
            this.lblNotActive = new HControls.HLabel();
            this.lblFirstName = new HControls.HLabel();
            this.txtBranchName = new HControls.HTextBox();
            this.lblInstCode = new HControls.HLabel();
            this.txtBranchCode = new HControls.HTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkNotActive
            // 
            this.chkNotActive.AutoSize = true;
            this.chkNotActive.FieldName = "NotActive";
            this.chkNotActive.Location = new System.Drawing.Point(236, 156);
            this.chkNotActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNotActive.Name = "chkNotActive";
            this.chkNotActive.Size = new System.Drawing.Size(15, 14);
            this.chkNotActive.TabIndex = 23;
            this.chkNotActive.UseVisualStyleBackColor = true;
            // 
            // lblNotActive
            // 
            this.lblNotActive.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblNotActive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNotActive.FieldName = "NotActive";
            this.lblNotActive.Location = new System.Drawing.Point(16, 145);
            this.lblNotActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotActive.Name = "lblNotActive";
            this.lblNotActive.Size = new System.Drawing.Size(212, 28);
            this.lblNotActive.TabIndex = 22;
            this.lblNotActive.Text = "ايقاف تعامل";
            // 
            // lblFirstName
            // 
            this.lblFirstName.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblFirstName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFirstName.FieldName = "CenterName";
            this.lblFirstName.Location = new System.Drawing.Point(16, 107);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(212, 28);
            this.lblFirstName.TabIndex = 20;
            this.lblFirstName.Text = "الاسم العربى";
            // 
            // txtBranchName
            // 
            this.txtBranchName.ComboBoxRelatedWith = null;
            this.txtBranchName.FieldName = "BranchName";
            this.txtBranchName.key = false;
            this.txtBranchName.Location = new System.Drawing.Point(236, 111);
            this.txtBranchName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.required = true;
            this.txtBranchName.SerachFields = null;
            this.txtBranchName.SerachFilter = null;
            this.txtBranchName.SerachTable = null;
            this.txtBranchName.Size = new System.Drawing.Size(299, 23);
            this.txtBranchName.TabIndex = 21;
            this.txtBranchName.TextBoxRelatedWith = null;
            // 
            // lblInstCode
            // 
            this.lblInstCode.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInstCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInstCode.FieldName = "CenterCode";
            this.lblInstCode.Location = new System.Drawing.Point(16, 71);
            this.lblInstCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstCode.Name = "lblInstCode";
            this.lblInstCode.Size = new System.Drawing.Size(212, 28);
            this.lblInstCode.TabIndex = 18;
            this.lblInstCode.Text = "كود الفرع";
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.ComboBoxRelatedWith = null;
            this.txtBranchCode.FieldName = "BranchCode";
            this.txtBranchCode.key = false;
            this.txtBranchCode.Location = new System.Drawing.Point(236, 75);
            this.txtBranchCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.required = false;
            this.txtBranchCode.SerachFields = null;
            this.txtBranchCode.SerachFilter = null;
            this.txtBranchCode.SerachTable = null;
            this.txtBranchCode.Size = new System.Drawing.Size(81, 23);
            this.txtBranchCode.TabIndex = 19;
            this.txtBranchCode.TextBoxRelatedWith = null;
            this.txtBranchCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRelationCode_KeyDown);
            // 
            // frmBranches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 276);
            this.Controls.Add(this.chkNotActive);
            this.Controls.Add(this.lblNotActive);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtBranchName);
            this.Controls.Add(this.lblInstCode);
            this.Controls.Add(this.txtBranchCode);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBranches";
            this.TableName = "Branches";
            this.Text = "الفروع";
            this.Load += new System.EventHandler(this.frmBranches_Load);
            this.Controls.SetChildIndex(this.txtBranchCode, 0);
            this.Controls.SetChildIndex(this.lblInstCode, 0);
            this.Controls.SetChildIndex(this.txtBranchName, 0);
            this.Controls.SetChildIndex(this.lblFirstName, 0);
            this.Controls.SetChildIndex(this.lblNotActive, 0);
            this.Controls.SetChildIndex(this.chkNotActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HControls.HCheckbox chkNotActive;
        private HControls.HLabel lblNotActive;
        private HControls.HLabel lblFirstName;
        private HControls.HTextBox txtBranchName;
        private HControls.HLabel lblInstCode;
        private HControls.HTextBox txtBranchCode;
    }
}