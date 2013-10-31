namespace HForm
{

    partial class Login
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
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblInvaild = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(202, 126);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(75, 23);
            this.btnlogin.TabIndex = 3;
            this.btnlogin.Text = "دخول";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(76, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "الغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.Color.Black;
            this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(287, 42);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(100, 20);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "المستخدم";
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Black;
            this.lblPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(287, 80);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPassword.Size = new System.Drawing.Size(100, 20);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "كلمة المرور";
            // 
            // lblInvaild
            // 
            this.lblInvaild.BackColor = System.Drawing.Color.Transparent;
            this.lblInvaild.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvaild.ForeColor = System.Drawing.Color.Red;
            this.lblInvaild.Location = new System.Drawing.Point(-45, 9);
            this.lblInvaild.Name = "lblInvaild";
            this.lblInvaild.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInvaild.Size = new System.Drawing.Size(422, 23);
            this.lblInvaild.TabIndex = 4;
            this.lblInvaild.Text = "المستخدم او كلمة المرور غير صحيح";
            this.lblInvaild.Visible = false;
            // 
            // UserName
            // 
            this.UserName.BackColor = System.Drawing.SystemColors.Info;
            this.UserName.Location = new System.Drawing.Point(76, 42);
            this.UserName.Name = "UserName";
            this.UserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UserName.Size = new System.Drawing.Size(201, 20);
            this.UserName.TabIndex = 1;
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.SystemColors.Info;
            this.Password.Location = new System.Drawing.Point(76, 80);
            this.Password.Name = "Password";
            this.Password.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Password.Size = new System.Drawing.Size(201, 20);
            this.Password.TabIndex = 2;
            this.Password.UseSystemPasswordChar = true;
            // 
            // lblBranch
            // 
            this.lblBranch.BackColor = System.Drawing.Color.Black;
            this.lblBranch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBranch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBranch.Location = new System.Drawing.Point(287, 106);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBranch.Size = new System.Drawing.Size(100, 20);
            this.lblBranch.TabIndex = 42;
            this.lblBranch.Text = "الفرع";
            this.lblBranch.Visible = false;
            // 
            // cmbBranch
            // 
            this.cmbBranch.AccessibleName = "Integer";
            this.cmbBranch.BackColor = System.Drawing.SystemColors.Window;
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(76, 106);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBranch.Size = new System.Drawing.Size(201, 21);
            this.cmbBranch.TabIndex = 41;
            this.cmbBranch.Tag = "City";
            this.cmbBranch.Visible = false;
            // 
            // Login
            // 
            this.AcceptButton = this.btnlogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(425, 175);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.lblInvaild);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnlogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;

        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label lblInvaild;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbBranch;

    }


}