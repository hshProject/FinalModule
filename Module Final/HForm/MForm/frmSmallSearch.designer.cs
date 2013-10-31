namespace HForm
{
    partial class frmSmallSearch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearchfor = new HControls.HTextBox();
            this.lblSearchfor = new System.Windows.Forms.Label();
            this.cmbCritria = new HControls.HComboBox();
            this.cmbSFields = new HControls.HComboBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtSearchfor);
            this.groupBox1.Controls.Add(this.lblSearchfor);
            this.groupBox1.Controls.Add(this.cmbCritria);
            this.groupBox1.Controls.Add(this.cmbSFields);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 83);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "البحث بواسطة";
            // 
            // txtSearchfor
            // 
            this.txtSearchfor.ComboBoxRelatedWith = null;
            this.txtSearchfor.FieldName = null;
            this.txtSearchfor.key = false;
            this.txtSearchfor.Location = new System.Drawing.Point(6, 49);
            this.txtSearchfor.Name = "txtSearchfor";
            this.txtSearchfor.required = false;
            this.txtSearchfor.SerachFields = null;
            this.txtSearchfor.SerachFilter = null;
            this.txtSearchfor.SerachTable = null;
            this.txtSearchfor.Size = new System.Drawing.Size(365, 23);
            this.txtSearchfor.TabIndex = 4;
            this.txtSearchfor.TextBoxRelatedWith = null;
            this.txtSearchfor.TextChanged += new System.EventHandler(this.txtSearchfor_TextChanged);
            this.txtSearchfor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchfor_KeyDown);
            // 
            // lblSearchfor
            // 
            this.lblSearchfor.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSearchfor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSearchfor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchfor.Location = new System.Drawing.Point(374, 49);
            this.lblSearchfor.Name = "lblSearchfor";
            this.lblSearchfor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSearchfor.Size = new System.Drawing.Size(100, 23);
            this.lblSearchfor.TabIndex = 22;
            this.lblSearchfor.Text = "البحث عن";
            // 
            // cmbCritria
            // 
            this.cmbCritria.DisplayMember = "Name";
            this.cmbCritria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCritria.FieldName = null;
            this.cmbCritria.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCritria.FormattingEnabled = true;
            this.cmbCritria.Items.AddRange(new object[] {
            "يساوى",
            "يبدا ب",
            "ينتهى ب",
            "يحتوى على",
            "لا يحتوى على"});
            this.cmbCritria.key = false;
            this.cmbCritria.Location = new System.Drawing.Point(6, 22);
            this.cmbCritria.MyDisplayMember = "Name";
            this.cmbCritria.MyValueMember = "SeasCode";
            this.cmbCritria.Name = "cmbCritria";
            this.cmbCritria.required = false;
            this.cmbCritria.SearchFilter = null;
            this.cmbCritria.Size = new System.Drawing.Size(259, 24);
            this.cmbCritria.TabIndex = 8;
            this.cmbCritria.TableName = "Seasons";
            this.cmbCritria.TextBoxRelatedWith = null;
            this.cmbCritria.ValueMember = "SeasCode";
            // 
            // cmbSFields
            // 
            this.cmbSFields.DisplayMember = "Name";
            this.cmbSFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSFields.FieldName = null;
            this.cmbSFields.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSFields.FormattingEnabled = true;
            this.cmbSFields.key = false;
            this.cmbSFields.Location = new System.Drawing.Point(271, 22);
            this.cmbSFields.MyDisplayMember = "Name";
            this.cmbSFields.MyValueMember = "SeasCode";
            this.cmbSFields.Name = "cmbSFields";
            this.cmbSFields.required = false;
            this.cmbSFields.SearchFilter = null;
            this.cmbSFields.Size = new System.Drawing.Size(206, 24);
            this.cmbSFields.TabIndex = 7;
            this.cmbSFields.TableName = "Seasons";
            this.cmbSFields.TextBoxRelatedWith = null;
            this.cmbSFields.ValueMember = "SeasCode";
            this.cmbSFields.SelectedIndexChanged += new System.EventHandler(this.cmbSFields_SelectedIndexChanged);
            
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 101);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(483, 322);
            this.grid.TabIndex = 3;
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // frmSmallSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(507, 435);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSmallSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "بحث";
            this.Load += new System.EventHandler(this.frmSmallSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid;
        private HControls.HTextBox txtSearchfor;
        private System.Windows.Forms.Label lblSearchfor;
        private HControls.HComboBox cmbCritria;
        private HControls.HComboBox cmbSFields;
    }
}