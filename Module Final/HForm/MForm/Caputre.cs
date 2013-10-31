using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;



namespace HForm
{
    public partial class Caputre : Form
    {
        public int fileCode;
        public Caputre(int _file_Code)
        {
            InitializeComponent();
            InitializeDevicesList();
            fileCode = _file_Code;
        }

        private void InitializeDevicesList()
        {


            foreach (CaptureDevice device in CaptureDevice.GetDevices())
            {
                cboDevices.Items.Add(device);
            }

            if (cboDevices.Items.Count > 0)
            {
                cboDevices.SelectedIndex = 0;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            int index = cboDevices.SelectedIndex;
            if (index != -1)
            {

                ((CaptureDevice)cboDevices.SelectedItem).Attach(pbImage);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            ((CaptureDevice)cboDevices.SelectedItem).Detach();
        }

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            try
            {
                Image image = ((CaptureDevice)cboDevices.SelectedItem).Capture();
                bool isExists = System.IO.Directory.Exists(Application.StartupPath + @"\Docs");

                if (!isExists)
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Docs");

                isExists = System.IO.Directory.Exists(Application.StartupPath + @"\Docs\" + fileCode);

                if (!isExists)
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Docs\" + fileCode);
                grid.Rows.Add(1);
                grid.Rows[grid.Rows.Count - 1].Cells["col_image"].Value = image;
                //   image.Save(Application.StartupPath + @"\Docs\" + fileCode + @"\"+fileCode+".png", ImageFormat.Png);
            }
            catch (Exception ex)
            {
                // catch { MessageBox.Show("مسار الماسح الضوئى خاطىء"); }
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }






    }
}