using System;
using System.Runtime.InteropServices;


namespace HForm
{
    partial class Caputre
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

            // free unmanaged resources
            // clean up capture devices

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboDevices = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_image = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDevices
            // 
            this.cboDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDevices.FormattingEnabled = true;
            this.cboDevices.Location = new System.Drawing.Point(12, 8);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Size = new System.Drawing.Size(374, 21);
            this.cboDevices.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(392, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 21);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "بدء";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(727, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 21);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "ايقاف";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnapshot.Location = new System.Drawing.Point(552, 7);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(75, 21);
            this.btnSnapshot.TabIndex = 9;
            this.btnSnapshot.Text = "حفظ";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pbImage.Location = new System.Drawing.Point(12, 34);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(374, 375);
            this.pbImage.TabIndex = 7;
            this.pbImage.TabStop = false;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.col_image});
            this.grid.Location = new System.Drawing.Point(392, 34);
            this.grid.Name = "grid";
            this.grid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grid.Size = new System.Drawing.Size(410, 375);
            this.grid.TabIndex = 10;
            // 
            // Name
            // 
            this.Name.HeaderText = "الاسم";
            this.Name.Name = "Name";
            // 
            // col_image
            // 
            this.col_image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_image.HeaderText = "الصورة";
            this.col_image.Name = "col_image";
            // 
            // Caputre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 421);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.cboDevices);
            this.Controls.Add(this.btnSnapshot);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);

            this.Text = "TestAvicap32";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDevices;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewImageColumn col_image;
    }
}

