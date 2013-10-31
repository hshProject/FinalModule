using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;
using System.Management.Instrumentation;
using System.Net.NetworkInformation;
using HForm;


    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }



        private void Register_Load(object sender, EventArgs e)
        {
            string data = "";

          #region Operating Sysetm
           // ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
           //foreach (ManagementObject managementObject in mos.Get())
           // {
           //     //if (managementObject["Caption"] != null)
           //     //{
           //     //    data += managementObject["Caption"].ToString();   //Display operating system caption
           //     //}
           //     //if (managementObject["OSArchitecture"] != null)
           //     //{
           //     //    data += managementObject["OSArchitecture"].ToString();   //Display operating system architecture.
           //     //}

           // }
            #endregion

          #region Serial HardDisk
           ManagementObjectSearcher mosa = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
           foreach (ManagementObject managementObjecta in mosa.Get())
           {
               if (managementObjecta["SerialNumber"] != null)
               {
                   data += managementObjecta["SerialNumber"].ToString();
               }
           }
            #endregion

          #region ProcessorSerial
            //RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.
            //if (processor_name != null)
            //{
            //    if (processor_name.GetValue("ProcessorNameString") != null)
            //    {
            //        data+= processor_name.GetValue("ProcessorNameString");   //Display processor ingo.
            //    }
            //}
            #endregion

          #region MacAddress
            //string MacAddress = "";
            //foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            //{
            //     if( nic.OperationalStatus == OperationalStatus.Up)
            //     {
            //       MacAddress =  nic.GetPhysicalAddress().ToString();
            //     }
            //}

            #endregion

            //data += MacAddress;

          
            txtSerial.Text = SecurityHelper_Lat.Encrypt(data);
            //txtSerial.Text = SecurityHelper_Lat.Encrypt_Serial(txtSerial.Text);

        }

        #region OldmacAddress


        //var macAddr =
        //     (
        //from nic in NetworkInterface.GetAllNetworkInterfaces()
        //    where nic.OperationalStatus == OperationalStatus.Up
        //    select nic.GetPhysicalAddress().ToString()
        //).FirstOrDefault();

        //public string GetMACAddress()
        //{
        //    ManagementObjectSearcher objMOS = new ManagementObjectSearcher("select * from Win32_NetworkAdapterConfiguration");
        //    ManagementObjectCollection objMOC = objMOS.Get();
        //    string MACAddress = String.Empty;
        //    foreach (ManagementObject objMO in objMOC)
        //    {
        //        if (MACAddress == String.Empty) // only return MAC Address from first card   
        //        {
        //            MACAddress = objMO["MacAddress"].ToString();
        //        }
        //        objMO.Dispose();
        //    }
        //    MACAddress = MACAddress.Replace(":", "");
        //    return MACAddress;
        //}
        

        //private string GetMacAddress()
        //{
        //    const int MIN_MAC_ADDR_LENGTH = 12;
        //    string macAddress = string.Empty;
        //    long maxSpeed = -1;

        //    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        //    {
        //        log.Debug(
        //            "Found MAC Address: " + nic.GetPhysicalAddress() +
        //            " Type: " + nic.NetworkInterfaceType);

        //        string tempMac = nic.GetPhysicalAddress().ToString();
        //        if (nic.Speed > maxSpeed &&
        //            !string.IsNullOrEmpty(tempMac) &&
        //            tempMac.Length >= MIN_MAC_ADDR_LENGTH)
        //        {
        //            log.Debug("New Max Speed = " + nic.Speed + ", MAC: " + tempMac);
        //            maxSpeed = nic.Speed;
        //            macAddress = tempMac;
        //        }
        //    }

        //    return macAddress;
        //}
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtRegisterCode.Text != "" && txtSerial.Text != "")
            {
                string register = SecurityHelper_Lat.Encrypt_Serial(txtSerial.Text);
                if (txtRegisterCode.Text.Trim() == register.Trim())
                {
                    MessageBox.Show("لقد تم التسجيل بنجاح");
                    Login login = new Login();
                    login.Show();
                   string sql = "insert into Serial values ('"+txtSerial.Text+"','"+txtRegisterCode.Text+"',0)";
                    DataLayer.executeNonQuery(sql);
                    // insert Into Serial
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("رقم التسجيل غير صحيح");
                    string select = "Select Attemptnumber+1 as Attemptnumber from Serial";
                    DataTable attempt = DataLayer.executeDataTable(select);

                    string delete = "Delete from Serial";
                    DataLayer.executeNonQuery(delete);
                    if (attempt.Rows.Count == 0)
                    {
                        string sql = "insert into Serial values ('1','1',1)";
                        DataLayer.executeNonQuery(sql);

                    }
                    else
                    {
                        string sql = "insert into Serial values ('1','1'," + attempt.Rows[0]["Attemptnumber"] + ")";
                        DataLayer.executeNonQuery(sql);

                    }

                    txtRegisterCode.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("من فضلك ادخل البيانات كاملة");
            }
        }
    } 


    
