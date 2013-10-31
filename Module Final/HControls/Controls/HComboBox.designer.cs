namespace HControls
{
    partial class HComboBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HComboBox
            // 
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //hemaily 5october2013
            this.SelectionChangeCommitted += new System.EventHandler(this.HComboBox_SelectedValueChangedComit);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HComboBox_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
