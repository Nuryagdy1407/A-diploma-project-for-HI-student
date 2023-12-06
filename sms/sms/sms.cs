using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace sms
{
    public partial class sms : Form
    {
        public sms()
        {
            InitializeComponent();
        }

       

        private void sms_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            sms_al();

        }

        private void sms_al()
        {
            ComboBox port = new ComboBox();
            ManagementObjectSearcher ms = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_POTSModem");
            foreach (ManagementObject obj in ms.Get())
            {
                //MessageBox.Show(obj["AttachedTo"].ToString());
                port.Items.Add(obj["AttachedTo"].ToString());
            }
            if (port.Items.Count > 0)
            {
                SerialPort sp = new SerialPort(port.Items[0].ToString(), 115200);
                sp.Parity = Parity.None;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.Handshake = Handshake.XOnXOff;

                sp.DtrEnable = true;
                sp.RtsEnable = true;
                sp.NewLine = Environment.NewLine;

                sp.Open();

                sp.Write("AT" + System.Environment.NewLine);
                Thread.Sleep(1000);

                sp.WriteLine("AT+CMGF=1" + System.Environment.NewLine);
                Thread.Sleep(1000);

                sp.WriteLine("AT+CMGL=\"ALL\"\r" + System.Environment.NewLine);
                Thread.Sleep(3000);

                //MessageBox.Show(sp.ReadExisting());

                Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");
                Match m = r.Match(sp.ReadExisting());

                while (m.Success)
                {
                    string a = m.Groups[1].Value;
                    string b = m.Groups[2].Value;
                    string c = m.Groups[3].Value;
                    string d = m.Groups[4].Value;
                    string ee = m.Groups[5].Value;
                    string f = m.Groups[6].Value;

                    ListViewItem item = new ListViewItem(new string[] { a, b, c, d, ee, f });
                    listView1.Items.Add(item);
                    m = m.NextMatch();
                }

                sp.Close();
               
                listView1.Refresh();
                //listView1.Items.Clear();
                //sms_al();
            }

            else
            {
                MessageBox.Show("Modem dakylmadyk ýada ulgam işlänok...","Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            listView1.Refresh();
            listView1.Items.Clear();
            sms_al();
        }

       
    }
}
