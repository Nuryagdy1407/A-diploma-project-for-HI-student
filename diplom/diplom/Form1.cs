using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection ms = new MySqlConnection(baglanmysql.baglanmakucin());

        public static PhysicalAddress mac_al()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

        //public string GetMACAddress() 
        //{
        //    ManagementObjectSearcher obj = new ManagementObjectSearcher("Win32_NetworkAdapterConfiguration");
        //    ManagementObjectCollection objcol = obj.Get();
        //    string ad = String.Empty;
        //    foreach(ManagementObject objman in objcol)
        //    {
        //        if(ad==String.Empty)
        //        {
        //            ad = objman["MacAddress"].ToString();
        //        }
        //        objman.Dispose();
        //    }
        //    ad = ad.Replace("-","");
        //    return ad;
        //}

        private void kabul_et_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ms.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_ulanyjylar WHERE ulanyjy_parol='" + ulanyjy_parol_txt.Text + "' AND ulanyjy_ad='"+ulanyjy_ad_txt.Text+"' ", ms);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    if (rd[3].ToString() == ulanyjy_parol_txt.Text && rd[2].ToString() == ulanyjy_ad_txt.Text && rd[6].ToString() == mac_txt.Text)
                    {
                        MessageBox.Show("kompyuter dogry ulanyjyda");
                    }
                    else if (rd[3].ToString() == ulanyjy_parol_txt.Text && rd[2].ToString() == ulanyjy_ad_txt.Text && rd[6].ToString() != mac_txt.Text)
                    {
                        MessageBox.Show("kompyuter dogry ulanyjyda dal!!!");
                        ms.Close();
                    }
                    else 
                    {
                        MessageBox.Show("hic zat yok...");
                    }
                }
                else
                {
                    MessageBox.Show("!!!!","!!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
               ms.Open();
               MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM tb_ulanyjylar WHERE mac_address='"+mac_txt.Text+"'");
               cmd3.CommandType = CommandType.Text;
               MySqlDataReader rd2 = cmd.ExecuteReader();
                if(rd2.Read())
                    {
                     string ady = rd2[2].ToString();
                     string nomer = rd2[4].ToString();  
                     string mac = rd2[6].ToString();
                     ms.Close();
                     string sene = DateTime.Now.ToLongDateString();
                        //ms.Open();
                        //MySqlCommand cmd2 = new MySqlCommand("INSERT INTO  tb_sms(ady,tel,mac_address,sene,sms) VALUES('"+ady+"','" + nomer + "','" + mac + "','" + sene + "','0')", ms);
                        //cmd2.ExecuteNonQuery();
                        //ms.Close();
                        MessageBox.Show(ady);
                    }
              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mac_txt.Text = mac_al().ToString();
            label9.ResetText();
            ComboBox port = new ComboBox();
            ManagementObjectSearcher mss = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_POTSModem");
            foreach (ManagementObject obj in mss.Get())
            {

                port.Items.Add(obj["AttachedTo"].ToString());
            }
            if (port.Items.Count > 0)
            {
                label9.Text = port.Items[0].ToString();
                label9.ForeColor = Color.LimeGreen;
            }
            else
            {
                label9.Text = "Baglanmady...";
                label9.ForeColor = Color.Red;
            }
        }

        void sms_ugrat() 
        {
            string tel = "";
            try
            {
                //serial port nomeri
                SerialPort sp = new SerialPort();
                sp.PortName = label9.Text;
                sp.Open();
                //AT kod bilen sms ugrat
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGS=\"" + tel + "\"" + Environment.NewLine);//Tel nomer
                Thread.Sleep(100);
                sp.WriteLine(ulanyjy_ad_txt.Text + Environment.NewLine);//sms tekst
                Thread.Sleep(100);
                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);
                var response = sp.ReadExisting();
                if (response.Contains("Ýalňyş"))
                { }
                else
                { }
                sp.Close();
                MessageBox.Show("SMS ugradyldy", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baza_sal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        void baza_sal() 
        {
            string sene = DateTime.Now.ToLongDateString();
            ms.Open();
            MySqlCommand cmd2 = new MySqlCommand("INSERT INTO  tb_sms(tel,mac_address,sene,sms) VALUES('0','" + sene + "','" + ulanyjy_ad_txt.Text + "')", ms);
            cmd2.ExecuteNonQuery();
            ms.Close();
        }
    }
}
