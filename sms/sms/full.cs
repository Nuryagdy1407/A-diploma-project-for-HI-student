using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sms
{
    public partial class full : Form
    {
        public full()
        {
            InitializeComponent();
        }
        MySqlConnection ms = new MySqlConnection(baglanmysql.baglanmakucin());
        private void yap_btn_Click(object sender, EventArgs e)
        {
            DialogResult netije = MessageBox.Show("Ulgamdan çykmakçymy?", "Duýduryş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (netije == DialogResult.Yes) { Application.Exit(); }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuFlatButton1.Textcolor = Color.White;
            bunifuFlatButton2.Textcolor = Color.Gray;
            bunifuFlatButton4.Textcolor = Color.Gray;
            bunifuFlatButton3.Textcolor = Color.Gray;
            bunifuFlatButton1.Width = 240; bunifuFlatButton2.Width = 225; bunifuFlatButton3.Width = 225; bunifuFlatButton4.Width = 225;
            //bunifuFlatButton1.Font = new Font("Century Gothic", 10, FontStyle.Bold);

            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            ms.Open();
            String query = "select ad from tb_okuwcy  where (ad) like '%" + textBox1.Text + "%'";
            MySqlCommand cmd = new MySqlCommand(query, ms);
            MySqlDataReader rr = cmd.ExecuteReader();
            rr.Read();
            while (rr.Read())
                namesCollection.Add(rr["ad"].ToString());
            rr.Close();
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = namesCollection;
            ms.Close();
           
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuFlatButton2.Textcolor = Color.White;
            bunifuFlatButton1.Textcolor = Color.Gray;
            bunifuFlatButton4.Textcolor = Color.Gray;
            bunifuFlatButton3.Textcolor = Color.Gray;
            bunifuFlatButton2.Width = 240; bunifuFlatButton1.Width = 225; bunifuFlatButton3.Width = 225; bunifuFlatButton4.Width = 225;
            //bunifuFlatButton2.Font = new Font("Century Gothic", 10, FontStyle.Bold);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bunifuFlatButton3.Textcolor = Color.White;
            bunifuFlatButton2.Textcolor = Color.Gray;
            bunifuFlatButton4.Textcolor = Color.Gray;
            bunifuFlatButton1.Textcolor = Color.Gray;
            bunifuFlatButton3.Width = 240; bunifuFlatButton2.Width = 225; bunifuFlatButton1.Width = 225; bunifuFlatButton4.Width = 225;
            //bunifuFlatButton3.Font = new Font("Century Gothic", 10, FontStyle.Bold);
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuFlatButton4.Textcolor = Color.White;
            bunifuFlatButton2.Textcolor = Color.Gray;
            bunifuFlatButton1.Textcolor = Color.Gray;
            bunifuFlatButton3.Textcolor = Color.Gray;
            bunifuFlatButton4.Width = 240; bunifuFlatButton2.Width = 225; bunifuFlatButton1.Width = 225; bunifuFlatButton3.Width = 225;
            //bunifuFlatButton4.Font = new Font("Century Gothic", 10, FontStyle.Bold);
        }
        public string ip;
        private void full_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            ms.Open();
            String query = "select ad from tb_okuwcy  where (ad) like '%" + textBox1.Text + "%'";
            MySqlCommand cmd = new MySqlCommand(query, ms);
            MySqlDataReader rr = cmd.ExecuteReader();
            rr.Read();
            while (rr.Read())
                namesCollection.Add(rr["ad"].ToString());
            rr.Close();
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = namesCollection;
            ms.Close();
            okuwcy_pnl.Visible = true;
            ComboBox port = new ComboBox();
            ManagementObjectSearcher mss = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_POTSModem");
            foreach (ManagementObject obj in mss.Get())
            {
                
                port.Items.Add(obj["AttachedTo"].ToString());
            }
            if (port.Items.Count > 0)
            { 
              label9.Text = port.Items[0].ToString();
              label9.ForeColor = Color.Olive;
            }
            else
            {
                label9.Text = "Baglanmady...";
                label9.ForeColor = Color.Red;
            }

            label20.Text = "■  " + Dns.GetHostName();
            foreach (IPAddress adres in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                ip = "" + adres;
                label20.Text = ip;
            }
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Enter)
            { 
               
            //bunifuMaterialTextbox1.Text = textBox1.Text;
            label4.ResetText();
            label3.ResetText();
            label5.ResetText();
            label13.ResetText();
            label15.ResetText();
            ay2_grd.DataSource = null;
            gun_grd.DataSource = null;
            caryek_grd.DataSource = null;
                ms.Open();
                MySqlCommand cmd1 = new MySqlCommand("select No,ID,ad,synp,rota,wzwod,tel_kaka from tb_okuwcy where ad='" + textBox1.Text + "'", ms);
                cmd1.CommandType = CommandType.Text;
                MySqlDataReader rd = cmd1.ExecuteReader();

                //label4.Visible = true;
                //label5.Visible = true;
                //label13.Visible = true; label15.Visible = true;
               
                if (rd.Read())
                {
                    // MyCollection.Add(rd.GetString(1));
                    label13.Text = rd[1].ToString();
                    label5.Text = rd[2].ToString();
                    label4.Text = rd[3].ToString();
                    label3.Text = rd[4].ToString(); label15.Text = rd[5].ToString(); label24.Text = rd[6].ToString();
                }
                //textBox1.AutoCompleteCustomSource = MyCollection;
                else
                {

                }
                ms.Close();
            }
        }


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            label4.ResetText();
            label3.ResetText();
            label5.ResetText();
            label13.ResetText();
            label15.ResetText();

            ms.Open();
            MySqlCommand cmd2 = new MySqlCommand("select No,ID,ad,synp,rota,wzwod,telno from tb_okuwcy where ad='" + textBox1.Text + "'", ms);
            //SqlCommand cmd = new SqlCommand("select * from okuwcylar_gysga", bag);
            cmd2.CommandType = CommandType.Text;
            //AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            MySqlDataReader rd2 = cmd2.ExecuteReader();

            //label4.Visible = true;
            //label5.Visible = true;
            //label13.Visible = true; label15.Visible = true;

            if (rd2.Read())
            {
                // MyCollection.Add(rd.GetString(1));
                label13.Text = rd2[1].ToString();
                label5.Text = rd2[2].ToString();
                label4.Text = rd2[3].ToString();
                label3.Text = rd2[4].ToString(); label15.Text = rd2[5].ToString(); label24.Text = rd2[6].ToString();
            }
            //textBox1.AutoCompleteCustomSource = MyCollection;
            else
            {

            }
            ms.Close();
        }

        private void sene_pckr_ValueChanged(object sender, EventArgs e)
        {
            gun_grd.DataSource = null;
            flowLayoutPanel1.Controls.Clear(); 
            string gun =  sene_pckr.Value.Day.ToString();
            if (Convert.ToInt16(gun)<10)
            {
                gun = "0" + gun + "";
            }
            string ay = sene_pckr.Value.Month.ToString();
            if (Convert.ToInt16(ay) < 10)
            {
                ay = "0" + ay + "";
            }
            string yyl = sene_pckr.Value.Year.ToString();
            string umumy_sene=""+yyl+"-"+ay+"-"+gun+"";
            if (textBox1.Text=="")
            {
                Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                tx.Text = "Baha ýok...";
                tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                tx.ForeColor = Color.Red;
                tx.BorderThickness = 0;
                flowLayoutPanel1.Controls.Add(tx);
            }
            else
            {
                       try
                           {   
                            ms.Open();
                            DataSet dss = new DataSet();
                            System.Data.DataTable dtt = new System.Data.DataTable();
                            dss.Tables.Add(dtt);
                            MySqlDataAdapter daa = new MySqlDataAdapter("SELECT ders,baha FROM marks WHERE ad='" + label5.Text + "' AND sene='" + umumy_sene.ToString() + "'", ms);
                            daa.Fill(dtt);
                            gun_grd.DataSource = dtt.DefaultView;
                            ms.Close();
                            }
                        catch (Exception error)
                            {
                                MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                            }
                        if (gun_grd.Rows.Count>0 )
                        {
                                for (int i = 0; i < gun_grd.Rows.Count; i++)
                            {
                                Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                                bn.Text = gun_grd.Rows[i].Cells[0].Value.ToString()+" : "+gun_grd.Rows[i].Cells[1].Value.ToString();
                                bn.AutoSize = true;
                                bn.Width = 100;
                                bn.Height = 30;
                                bn.Enabled = true;
                                //bn.TextAlign = HorizontalAlignment.Right;
                                bn.ShadowDecoration.Color = Color.Black;
                                bn.BorderRadius = 2;
                                bn.ShadowDecoration.Depth = 60;
                                bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                                if (gun_grd.Rows[i].Cells[1].Value.ToString() == "5")
                                {
                                    gun_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                                    gun_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    bn.FillColor = Color.SeaGreen;
                                    bn.BackColor = Color.Transparent;
                                    bn.ForeColor = Color.White;
                                    bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                                }
                                else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "4")
                                {
                                    gun_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                                    gun_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    bn.FillColor = Color.LightSeaGreen;
                                    bn.BackColor = Color.Transparent;
                                    bn.ForeColor = Color.White;
                                    bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                                }
                                else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "3")
                                {
                                    gun_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                                    gun_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    bn.FillColor = Color.Orange;
                                    bn.BackColor = Color.Transparent;
                                    bn.ForeColor = Color.White;
                                    bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                                }
                                else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "2")
                                {
                                    gun_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                                    gun_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    bn.FillColor = Color.Red;
                                    bn.BackColor = Color.Transparent;
                                    bn.ForeColor = Color.White;
                                    bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                                }
                                
                                bn.CheckedState.FillColor = Color.Black;
                                bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                                bn.CheckedState.ForeColor = Color.White;
                                //bn.DoubleClick += new EventHandler(this.buton);
                                flowLayoutPanel1.Controls.Add(bn);

                            }
                        }
                        else
                        {

                            Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                            tx.Text = "Baha ýok...";
                            tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                            tx.ForeColor = Color.Red;
                            tx.BorderThickness = 0;
                            flowLayoutPanel1.Controls.Add(tx);
                        }
            }
            

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            
            
        }

        private void xuiSegment1_IndexChanged(object sender, EventArgs e)
        {
           
            if (xuiSegment1.SelectedIndex==2)
            {
                okuwcy_pnl.Visible = true;
            }
        }

        private void hepde_pckr_ValueChanged(object sender, EventArgs e)
        {
           

            //DateTime bas = DateTime.Today.AddDays((int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)DateTime.Today.DayOfWeek);
            //string result = string.Join("," + Environment.NewLine, Enumerable.Range(0, 7).Select(i => bas.AddDays(i).ToString("yyyy-MM-dd").gunler_grd.Rows[i].Cells[0].Value.ToString()));
            //string result = string.Join("," + Environment.NewLine, Enumerable.Range(0, 7).Select(i => bas.AddDays(i).ToString("yyyy-MM-dd"))); 
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

                //while (m.Success)
                //{
                //    string a = m.Groups[1].Value;
                //    string b = m.Groups[2].Value;
                //    string c = m.Groups[3].Value;
                //    string d = m.Groups[4].Value;
                //    string ee = m.Groups[5].Value;
                //    string f = m.Groups[6].Value;

                //    ListViewItem item = new ListViewItem(new string[] { a, b, c, d, ee, f });
                //    listView1.Items.Add(item);
                //    m = m.NextMatch();
                //}

                sp.Close();
                //listView1.Items.Clear();
                //sms_al();
            }

            else
            {
                MessageBox.Show("Modem dakylmadyk ýada ulgam işlänok...", "Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void caryek_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel3.Controls.Clear();

            #region sentyabr
            if (caryek_cmb.SelectedIndex==0)
            {
               
                 string  bas_gun ="01";
                 string  bas_ay ="09";
                 string son_gun = "30";

                //string yyl = DateTime.Now.Year.ToString();
                 string yyl = yyl_cmb.Text;
                string bas_sene = "" + yyl + "-" + bas_ay + "-" + bas_gun + "";
                string son_sene = "" + yyl + "-" + bas_ay + "-" + son_gun + "";
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders_gysga,baha,sene FROM marks WHERE  ad='"+label5.Text+"' AND sene BETWEEN '"+bas_sene+"' AND '"+son_sene+"' order by sene ASC", ms);
                    daaa.Fill(dttt);
                    ay2_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (ay2_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < ay2_grd.Rows.Count; i++)
                    {
                        Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                        bn.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " : " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                        ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        bn.AutoSize = true;
                        bn.Width = 100;
                        bn.Height = 30;
                        bn.Enabled = true;
                        bn.ShadowDecoration.Color = Color.Black;
                        bn.BorderRadius = 2;
                        bn.ShadowDecoration.Depth = 60;
                        bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                        if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                            ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            bn.FillColor = Color.SeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                            ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            bn.FillColor = Color.LightSeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                            ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            bn.FillColor = Color.Orange;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            bn.FillColor = Color.Red;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }

                        bn.CheckedState.FillColor = Color.Black;
                        bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                        bn.CheckedState.ForeColor = Color.White;
                        //bn.DoubleClick += new EventHandler(this.buton);
                        flowLayoutPanel3.Controls.Add(bn);

                    }
                }
                else
                {

                    Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                    tx.Text = "Baha ýok...";
                    tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                    tx.ForeColor = Color.Red;
                    tx.BorderThickness = 0;
                    flowLayoutPanel3.Controls.Add(tx);
                }

            }
            #endregion
            #region oktyabr
            else if (caryek_cmb.SelectedIndex == 1)
            {
                string bas_gun = "01";
                string bas_ay = "10";
                string son_gun = "31";

                //string yyl = DateTime.Now.Year.ToString();
                string yyl = yyl_cmb.Text;
                string bas_sene = "" + yyl + "-" + bas_ay + "-" + bas_gun + "";
                string son_sene = "" + yyl + "-" + bas_ay + "-" + son_gun + "";
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders_gysga,baha,sene FROM marks WHERE  ad='" + label5.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                    daaa.Fill(dttt);
                    ay2_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (ay2_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < ay2_grd.Rows.Count; i++)
                    {
                        ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                        bn.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " : " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                        bn.AutoSize = true;
                        bn.Width = 100;
                        bn.Height = 30;
                        bn.Enabled = true;
                        bn.ShadowDecoration.Color = Color.Black;
                        bn.BorderRadius = 2;
                        bn.ShadowDecoration.Depth = 60;
                        bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                        if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                            bn.FillColor = Color.SeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                            bn.FillColor = Color.LightSeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                            bn.FillColor = Color.Orange;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            bn.FillColor = Color.Red;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }

                        bn.CheckedState.FillColor = Color.Black;
                        bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                        bn.CheckedState.ForeColor = Color.White;
                        //bn.DoubleClick += new EventHandler(this.buton);
                        flowLayoutPanel3.Controls.Add(bn);

                    }
                }
                else
                {

                    Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                    tx.Text = "Baha ýok...";
                    tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                    tx.ForeColor = Color.Red;
                    tx.BorderThickness = 0;
                    flowLayoutPanel3.Controls.Add(tx);
                }
            }
            #endregion
            #region noyabr
            else if (caryek_cmb.SelectedIndex == 2)
            {
                string bas_gun = "01";
                string bas_ay = "11";
                string son_gun = "30";

                //string yyl = DateTime.Now.Year.ToString();
                string yyl = yyl_cmb.Text;
                string bas_sene = "" + yyl + "-" + bas_ay + "-" + bas_gun + "";
                string son_sene = "" + yyl + "-" + bas_ay + "-" + son_gun + "";
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders_gysga,baha,sene FROM marks WHERE  ad='" + label5.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                    daaa.Fill(dttt);
                    ay2_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (ay2_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < ay2_grd.Rows.Count; i++)
                    {
                        ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                        bn.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " : " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                        bn.AutoSize = true;
                        bn.Width = 100;
                        bn.Height = 30;
                        bn.Enabled = true;
                        bn.ShadowDecoration.Color = Color.Black;
                        bn.BorderRadius = 2;
                        bn.ShadowDecoration.Depth = 60;
                        bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                        if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                            bn.FillColor = Color.SeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                            bn.FillColor = Color.LightSeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                            bn.FillColor = Color.Orange;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            bn.FillColor = Color.Red;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }

                        bn.CheckedState.FillColor = Color.Black;
                        bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                        bn.CheckedState.ForeColor = Color.White;
                        //bn.DoubleClick += new EventHandler(this.buton);
                        flowLayoutPanel3.Controls.Add(bn);

                    }
                }
                else
                {

                    Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                    tx.Text = "Baha ýok...";
                    tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                    tx.ForeColor = Color.Red;
                    tx.BorderThickness = 0;
                    flowLayoutPanel3.Controls.Add(tx);
                }
            }
            #endregion
            #region dekabr
            else if (caryek_cmb.SelectedIndex == 3)
            {
                string bas_gun = "01";
                string bas_ay = "12";
                string son_gun = "31";

                //string yyl = DateTime.Now.Year.ToString();
                string yyl = yyl_cmb.Text;
                string bas_sene = "" + yyl + "-" + bas_ay + "-" + bas_gun + "";
                string son_sene = "" + yyl + "-" + bas_ay + "-" + son_gun + "";
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders_gysga,baha,sene FROM marks WHERE  ad='" + label5.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                    daaa.Fill(dttt);
                    ay2_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (ay2_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < ay2_grd.Rows.Count; i++)
                    {
                        ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                        bn.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " : " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                        bn.AutoSize = true;
                        bn.Width = 100;
                        bn.Height = 30;
                        bn.Enabled = true;
                        bn.ShadowDecoration.Color = Color.Black;
                        bn.BorderRadius = 2;
                        bn.ShadowDecoration.Depth = 60;
                        bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                        if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                            bn.FillColor = Color.SeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                            bn.FillColor = Color.LightSeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                            bn.FillColor = Color.Orange;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            bn.FillColor = Color.Red;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }

                        bn.CheckedState.FillColor = Color.Black;
                        bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                        bn.CheckedState.ForeColor = Color.White;
                        //bn.DoubleClick += new EventHandler(this.buton);
                        flowLayoutPanel3.Controls.Add(bn);

                    }
                }
                else
                {

                    Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                    tx.Text = "Baha ýok...";
                    tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                    tx.ForeColor = Color.Red;
                    tx.BorderThickness = 0;
                    flowLayoutPanel3.Controls.Add(tx);
                }
            }
            #endregion
            #region yanwar
            else if (caryek_cmb.SelectedIndex == 4)
            {
                string bas_gun = "01";
                string bas_ay = "01";
                string son_gun = "31";

                //string yyl = DateTime.Now.Year.ToString();
                string yyl = yyl_cmb.Text;
                string bas_sene = "" + yyl + "-" + bas_ay + "-" + bas_gun + "";
                string son_sene = "" + yyl + "-" + bas_ay + "-" + son_gun + "";
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders_gysga,baha,sene FROM marks WHERE  ad='" + label5.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                    daaa.Fill(dttt);
                    ay2_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (ay2_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < ay2_grd.Rows.Count; i++)
                    {
                        ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                        bn.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " : " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                        bn.AutoSize = true;
                        bn.Width = 100;
                        bn.Height = 30;
                        bn.Enabled = true;
                        bn.ShadowDecoration.Color = Color.Black;
                        bn.BorderRadius = 2;
                        bn.ShadowDecoration.Depth = 60;
                        bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                        if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                            bn.FillColor = Color.SeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                            bn.FillColor = Color.LightSeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                            bn.FillColor = Color.Orange;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            bn.FillColor = Color.Red;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }

                        bn.CheckedState.FillColor = Color.Black;
                        bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                        bn.CheckedState.ForeColor = Color.White;
                        //bn.DoubleClick += new EventHandler(this.buton);
                        flowLayoutPanel3.Controls.Add(bn);

                    }
                }
                else
                {

                    Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                    tx.Text = "Baha ýok...";
                    tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                    tx.ForeColor = Color.Red;
                    tx.BorderThickness = 0;
                    flowLayoutPanel3.Controls.Add(tx);
                }
            }
            #endregion
            #region fewral
            else if (caryek_cmb.SelectedIndex == 5)
            {
                string bas_gun = "01";
                string bas_ay = "02";
                string son_gun = "29";

                //string yyl = DateTime.Now.Year.ToString();
                string yyl = yyl_cmb.Text;
                string bas_sene = "" + yyl + "-" + bas_ay + "-" + bas_gun + "";
                string son_sene = "" + yyl + "-" + bas_ay + "-" + son_gun + "";
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders_gysga,baha,sene FROM marks WHERE  ad='" + label5.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                    daaa.Fill(dttt);
                    ay2_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (ay2_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < ay2_grd.Rows.Count; i++)
                    {
                        ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                        bn.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " : " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                        bn.AutoSize = true;
                        bn.Width = 100;
                        bn.Height = 30;
                        bn.Enabled = true;
                        bn.ShadowDecoration.Color = Color.Black;
                        bn.BorderRadius = 2;
                        bn.ShadowDecoration.Depth = 60;
                        bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                        if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                            bn.FillColor = Color.SeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                            bn.FillColor = Color.LightSeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                            bn.FillColor = Color.Orange;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            bn.FillColor = Color.Red;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }

                        bn.CheckedState.FillColor = Color.Black;
                        bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                        bn.CheckedState.ForeColor = Color.White;
                        //bn.DoubleClick += new EventHandler(this.buton);
                        flowLayoutPanel3.Controls.Add(bn);

                    }
                }
                else
                {

                    Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                    tx.Text = "Baha ýok...";
                    tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                    tx.ForeColor = Color.Red;
                    tx.BorderThickness = 0;
                    flowLayoutPanel3.Controls.Add(tx);
                }
            }
            #endregion
            #region mart
            else if (caryek_cmb.SelectedIndex == 6)
            {
                string bas_gun = "01";
                string bas_ay = "03";
                string son_gun = "31";

                //string yyl = DateTime.Now.Year.ToString();
                string yyl = yyl_cmb.Text;
                string bas_sene = "" + yyl + "-" + bas_ay + "-" + bas_gun + "";
                string son_sene = "" + yyl + "-" + bas_ay + "-" + son_gun + "";
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders_gysga,baha,sene FROM marks WHERE  ad='" + label5.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                    daaa.Fill(dttt);
                    ay2_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (ay2_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < ay2_grd.Rows.Count; i++)
                    {
                        ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                        bn.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " : " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                        bn.AutoSize = true;
                        bn.Width = 100;
                        bn.Height = 30;
                        bn.Enabled = true;
                        bn.ShadowDecoration.Color = Color.Black;
                        bn.BorderRadius = 2;
                        bn.ShadowDecoration.Depth = 60;
                        bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                        if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                            bn.FillColor = Color.SeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                            bn.FillColor = Color.LightSeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                            bn.FillColor = Color.Orange;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            bn.FillColor = Color.Red;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }

                        bn.CheckedState.FillColor = Color.Black;
                        bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                        bn.CheckedState.ForeColor = Color.White;
                        //bn.DoubleClick += new EventHandler(this.buton);
                        flowLayoutPanel3.Controls.Add(bn);

                    }
                }
                else
                {

                    Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                    tx.Text = "Baha ýok...";
                    tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                    tx.ForeColor = Color.Red;
                    tx.BorderThickness = 0;
                    flowLayoutPanel3.Controls.Add(tx);
                }
            }
            #endregion
            #region aprel
            else if (caryek_cmb.SelectedIndex == 7)
            {
                string bas_gun = "01";
                string bas_ay = "04";
                string son_gun = "30";

                //string yyl = DateTime.Now.Year.ToString();
                string yyl = yyl_cmb.Text;
                string bas_sene = "" + yyl + "-" + bas_ay + "-" + bas_gun + "";
                string son_sene = "" + yyl + "-" + bas_ay + "-" + son_gun + "";
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders_gysga,baha,sene FROM marks WHERE  ad='" + label5.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                    daaa.Fill(dttt);
                    ay2_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (ay2_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < ay2_grd.Rows.Count; i++)
                    {
                        ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                        bn.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " : " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                        bn.AutoSize = true;
                        bn.Width = 100;
                        bn.Height = 30;
                        bn.Enabled = true;
                        bn.ShadowDecoration.Color = Color.Black;
                        bn.BorderRadius = 2;
                        bn.ShadowDecoration.Depth = 60;
                        bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                        if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                            bn.FillColor = Color.SeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                            bn.FillColor = Color.LightSeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                            bn.FillColor = Color.Orange;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            bn.FillColor = Color.Red;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }

                        bn.CheckedState.FillColor = Color.Black;
                        bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                        bn.CheckedState.ForeColor = Color.White;
                        //bn.DoubleClick += new EventHandler(this.buton);
                        flowLayoutPanel3.Controls.Add(bn);

                    }
                }
                else
                {

                    Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                    tx.Text = "Baha ýok...";
                    tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                    tx.ForeColor = Color.Red;
                    tx.BorderThickness = 0;
                    flowLayoutPanel3.Controls.Add(tx);
                }
            }
            #endregion
            #region may
            else if (caryek_cmb.SelectedIndex == 8)
            {
                string bas_gun = "01";
                string bas_ay = "05";
                string son_gun = "31";

                //string yyl = DateTime.Now.Year.ToString();
                string yyl = yyl_cmb.Text;
                string bas_sene = "" + yyl + "-" + bas_ay + "-" + bas_gun + "";
                string son_sene = "" + yyl + "-" + bas_ay + "-" + son_gun + "";
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders_gysga,baha,sene FROM marks WHERE  ad='" + label5.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                    daaa.Fill(dttt);
                    ay2_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (ay2_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < ay2_grd.Rows.Count; i++)
                    {
                        ay2_grd.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Guna.UI2.WinForms.Guna2Button bn = new Guna.UI2.WinForms.Guna2Button();
                        bn.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " : " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                        bn.AutoSize = true;
                        bn.Width = 100;
                        bn.Height = 30;
                        bn.Enabled = true;
                        bn.ShadowDecoration.Color = Color.Black;
                        bn.BorderRadius = 2;
                        bn.ShadowDecoration.Depth = 60;
                        bn.Font = new Font("Tw Cen MT", 9, FontStyle.Regular);
                        if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.SeaGreen;
                            bn.FillColor = Color.SeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.LightSeaGreen;
                            bn.FillColor = Color.LightSeaGreen;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Orange;
                            bn.FillColor = Color.Orange;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }
                        else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {
                            ay2_grd.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            bn.FillColor = Color.Red;
                            bn.BackColor = Color.Transparent;
                            bn.ForeColor = Color.White;
                            bn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        }

                        bn.CheckedState.FillColor = Color.Black;
                        bn.CheckedState.Font = new Font("Tw Cen MT", 10, FontStyle.Regular);
                        bn.CheckedState.ForeColor = Color.White;
                        //bn.DoubleClick += new EventHandler(this.buton);
                        flowLayoutPanel3.Controls.Add(bn);

                    }
                }
                else
                {

                    Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                    tx.Text = "Baha ýok...";
                    tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                    tx.ForeColor = Color.Red;
                    tx.BorderThickness = 0;
                    flowLayoutPanel3.Controls.Add(tx);
                }
            }
            #endregion
            else
            {

            }
        }

        private void caryeklik_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            caryek_grd.DataSource = null;
            if (caryeklik_cmb.SelectedIndex==0)
            {
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT no,ders_gysga, ROUND(AVG(baha),0) as cjemi FROM marks WHERE  ad='" + label5.Text + "' AND caryek='1_caryek' group by ders_gysga order by ders_gysga ASC", ms);
                    daaa.Fill(dttt);
                    caryek_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }


                if (caryek_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < caryek_grd.Rows.Count; i++)
                    {
                        caryek_grd.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "5")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.SeaGreen;
                          
                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "4")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.LightSeaGreen;
                           
                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "3")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.Orange;
                           
                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "2")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                          
                        }

                      
                    }
                }
                else
                {

                }

            }
            else if (caryeklik_cmb.SelectedIndex==1)
            {
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT no,ders_gysga, ROUND(AVG(baha),0) as cjemi FROM marks WHERE  ad='" + label5.Text + "' AND caryek='2_caryek' group by ders_gysga order by ders_gysga ASC", ms);
                    daaa.Fill(dttt);
                    caryek_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }


                if (caryek_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < caryek_grd.Rows.Count; i++)
                    {
                        caryek_grd.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "5")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.SeaGreen;

                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "4")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.LightSeaGreen;

                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "3")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.Orange;

                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "2")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.Red;

                        }


                    }
                }
                else
                {

                }
            }
            else if (caryeklik_cmb.SelectedIndex == 2)
            {
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT no,ders_gysga, ROUND(AVG(baha),0) as cjemi FROM marks WHERE  ad='" + label5.Text + "' AND caryek='3_caryek' group by ders_gysga order by ders_gysga ASC", ms);
                    daaa.Fill(dttt);
                    caryek_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }


                if (caryek_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < caryek_grd.Rows.Count; i++)
                    {
                        caryek_grd.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "5")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.SeaGreen;

                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "4")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.LightSeaGreen;

                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "3")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.Orange;

                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "2")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.Red;

                        }


                    }
                }
                else
                {

                }
            }
            else if (caryeklik_cmb.SelectedIndex == 3)
            {
                try
                {
                    ms.Open();
                    DataSet dsss = new DataSet();
                    System.Data.DataTable dttt = new System.Data.DataTable();
                    dsss.Tables.Add(dttt);
                    MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT no,ders_gysga, ROUND(AVG(baha),0) as cjemi FROM marks WHERE  ad='" + label5.Text + "' AND caryek='4_caryek' group by ders_gysga order by ders_gysga ASC", ms);
                    daaa.Fill(dttt);
                    caryek_grd.DataSource = dttt.DefaultView;
                    ms.Close();
                    //
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }


                if (caryek_grd.Rows.Count > 0)
                {
                    for (int i = 0; i < caryek_grd.Rows.Count; i++)
                    {
                        caryek_grd.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "5")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.SeaGreen;

                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "4")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.LightSeaGreen;

                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "3")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.Orange;

                        }
                        else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "2")
                        {
                            caryek_grd.Rows[i].Cells[2].Style.ForeColor = Color.Red;

                        }


                    }
                }
                else
                {

                }
            }

        }

        private void sms_gun_btn_Click(object sender, EventArgs e)
        {
            int a =Convert.ToInt32(gun_grd.Rows.Count);
            
            try
            {
                for (int i = 0; i < a; i++)
                {
                    string gun = gun_grd.Rows[i].Cells[0].Value.ToString();
                    string tere = "_";
                    string bosluk = " ";
                    string taze = gun.Replace(tere,bosluk);
                    gun = taze;
                    string sms = taze + " - " + gun_grd.Rows[i].Cells[1].Value.ToString();
                    richTextBox1.Text += sms+"\n";
                }
                //serial port nomeri
                SerialPort sp = new SerialPort();
                sp.PortName = label9.Text;
                sp.Open();
                //AT kod bilen sms ugrat
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGS=\"" + label24.Text + "\"" + Environment.NewLine);//Tel nomer
                Thread.Sleep(100);
                sp.WriteLine(richTextBox1.Text + Environment.NewLine);//sms tekst
                Thread.Sleep(100);
                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);
                var response = sp.ReadExisting();
                if (response.Contains("Ýalňyş"))
                { }
                else
                {  }
                sp.Close();
                MessageBox.Show("SMS ugradyldy","Bildiriş",MessageBoxButtons.OK,MessageBoxIcon.Information);
                richTextBox1.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ay_btn_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(ay2_grd.Rows.Count);

            try
            {
                for (int i = 0; i < a; i++)
                {
                    string gun = ay2_grd.Rows[i].Cells[0].Value.ToString();
                    string tere = "_";
                    string bosluk = " ";
                    string taze = gun.Replace(tere, bosluk);
                    gun = taze;
                    string sms = taze + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                    richTextBox2.Text += sms + ";";
                }
                //serial port nomeri
                SerialPort sp = new SerialPort();
                sp.PortName = label9.Text;
                sp.Open();
                //AT kod bilen sms ugrat
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGS=\"" + label24.Text + "\"" + Environment.NewLine);//Tel nomer
                Thread.Sleep(100);
                sp.WriteLine(richTextBox2.Text + Environment.NewLine);//sms tekst
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
                richTextBox2.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hepde_pckr_ValueChanged_1(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            string[] gun = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] gun1 = { "Du", "Si", "Ça", "Pe", "An", "Şe", "Ýe" };

            DateTime sene = Convert.ToDateTime(hepde_pckr.Text);
            DateTime basy = Convert.ToDateTime("01.01." + DateTime.Now.Year);

            int a = 0;
            for (int k = 0; k < gun.Length; k++)
            {
                if (hepde_pckr.Value.DayOfWeek.ToString() == gun[k].ToString())
                { a = k + 1; }
            }

            int g = Convert.ToInt32(hepde_pckr.Value.Day.ToString());
            int ay = Convert.ToInt32(hepde_pckr.Value.Month.ToString());

            var daysInMonth = DateTime.DaysInMonth(Convert.ToInt32(hepde_pckr.Value.Year.ToString()), Convert.ToInt32(hepde_pckr.Value.Month.ToString()));
            int ayda = Convert.ToInt32(daysInMonth.ToString());

            int bas = (g - a + 1);
            int sony = (g - a + 7);

            //hepde ayin icinde bolsa;
            if (bas > 1 && sony < ayda)
            {
                int s = 0;
                for (int j = bas; j <= sony; j++)
                {
                    s++;
                    string gunn="";
                    if (j < 10)
                    {
                        gunn = "0" + j + "";
                    }
                    else
                    {
                        gunn = j.ToString();
                    }
                    string ayy="";
                    if (ay < 10)
                    {
                        ayy = "0" + ay + "";
                    }
                    dataGridView1.Rows.Add(gun1[s - 1].ToString(), (hepde_pckr.Value.Year +"-"+ ayy +"-"+gunn).ToString());
                }
            }

            //hepde ayyn basynda bolsa; 
            else if (bas < 1)
            {
                int ay_0 = Convert.ToInt32(DateTime.DaysInMonth(Convert.ToInt32(hepde_pckr.Value.Year.ToString()), ay - 1));
                int bas_0 = ay_0 + bas;
                int s = 0;
                for (int k = bas_0; k <= ay_0; k++)
                {
                    s++;
                    string gunn = "";
                    if (k < 10)
                    {
                        gunn = "0" + k + "";
                    }
                    else
                    {
                        gunn = k.ToString();
                    }
                    string ayy = "";
                    if (ay < 10)
                    {
                        ayy = "0" + (ay-1) + "";
                    }
                    dataGridView1.Rows.Add(gun1[s - 1].ToString(), (hepde_pckr.Value.Year+"-"+ ayy+"-"+gunn).ToString());
                }

                for (int u = 1; u < 7 + bas; u++)
                {
                    s++;
                    string gunn = "";
                    if (u < 10)
                    {
                        gunn = "0" + u + "";
                    }
                    else
                    {
                        gunn = u.ToString();
                    }
                    string ayy = "";
                    if (ay < 10)
                    {
                        ayy = "0" + ay + "";
                    }
                    dataGridView1.Rows.Add(gun1[s - 1].ToString(), (hepde_pckr.Value.Year + "-" + ayy + "-" + gunn).ToString());
                }
            }

            //hepde ayyn sonunda bolsa;
            else if (sony > ayda)
            {
                int l = 0;
                int s = 0;
                for (int u = bas; u <= ayda; u++)
                {
                    l++; s++;
                    string gunn = "";
                    if (u < 10)
                    {
                        gunn = "0" + u + "";
                    }
                    else
                    {
                        gunn = u.ToString();
                    }
                    string ayy = "";
                    if (ay < 10)
                    {
                        ayy = "0" + ay + "";
                    }
                    dataGridView1.Rows.Add(gun1[s - 1].ToString(), (hepde_pckr.Value.Year+"-"+ayy+"-"+gunn).ToString());
                }

                for (int d = 1; d <= 7 - l; d++)
                {
                    s++;
                    string gunn = "";
                    if (d < 10)
                    {
                        gunn = "0" + d + "";
                    }
                    else
                    {
                        gunn = d.ToString();
                    }
                    string ayy = "";
                    if (ay < 10)
                    {
                        ayy = "0" + (ay+1) + "";
                    }
                    dataGridView1.Rows.Add(gun1[s - 1].ToString(), (hepde_pckr.Value.Year+"-"+ayy+"-"+gunn).ToString());
                }
            }
        }

       
    }
}
