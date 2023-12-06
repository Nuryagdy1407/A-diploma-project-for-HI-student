using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Management;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace sms
{
    public partial class full_2 : Form
    {
        public full_2()
        {
            InitializeComponent();
        }
        MySqlConnection ms = new MySqlConnection(baglanmysql.baglanmakucin());
        private void yap_btn_Click(object sender, EventArgs e)
        {
            DialogResult netije = MessageBox.Show("Ulgamdan çykmakçymy?", "Duýduryş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (netije == DialogResult.Yes) { Application.Exit(); }
        }

        private void gun_btn_Click(object sender, EventArgs e)
        {
            calysh_txt.ResetText();
            calysh_txt.Text = gun_btn.Text;
            gun_pnl.Visible = true;
            hepde_pnl.Visible = false;
            ay_pnl.Visible = false;
            caryek_pnl.Visible = false;
            flowLayoutPanel1.Controls.Clear();
            ders_synp_pnl.Visible = true;
        }

        private void hepde_btn_Click(object sender, EventArgs e)
        {
            calysh_txt.ResetText();
            calysh_txt.Text = hepde_btn.Text;
            gun_pnl.Visible = false;
            hepde_pnl.Visible = true;
            ay_pnl.Visible = false;
            caryek_pnl.Visible = false;
            flowLayoutPanel1.Controls.Clear();
            ders_synp_pnl.Visible = true;
        }

        private void ay_btn_Click(object sender, EventArgs e)
        {
            calysh_txt.ResetText();
            calysh_txt.Text = ay_btn.Text;
            gun_pnl.Visible = false;
            hepde_pnl.Visible = false;
            ay_pnl.Visible = true;
            caryek_pnl.Visible = false;
            flowLayoutPanel1.Controls.Clear();
            ders_synp_pnl.Visible = true;
        }

        private void caryek_btn_Click(object sender, EventArgs e)
        {
            calysh_txt.ResetText();
            calysh_txt.Text = caryek_btn.Text;
            gun_pnl.Visible = false;
            hepde_pnl.Visible = false;
            ay_pnl.Visible = false;
            caryek_pnl.Visible = true;
            flowLayoutPanel1.Controls.Clear();
            ders_synp_pnl.Visible = true;
        }

        private void xuiSegment1_IndexChanged(object sender, EventArgs e)
        {
            if (xuiSegment1.SelectedIndex == 0)
            {
                ay_pnl.Enabled = false;
                caryek_pnl.Enabled = false;
                gun_pnl.Enabled = true;
                textBox1.ResetText();
                flowLayoutPanel1.Controls.Clear();
                label24.ResetText();
                label29.ResetText();
                gunaShadowPanel4.Visible = true;
                gunaShadowPanel1.Visible = true;
                calysh_txt.ResetText();
                calysh_txt.Text = "Günler";
                try
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Servere baglanyp bilmedi..." + "\n\n" + ex.ToString(), "Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            if (xuiSegment1.SelectedIndex == 1)
            {
                ay_pnl.Enabled = true;
                caryek_pnl.Enabled = false;
                gun_pnl.Enabled = false;
                textBox1.ResetText();
                flowLayoutPanel1.Controls.Clear();
                label24.ResetText();
                label29.ResetText();
                gunaShadowPanel4.Visible = true;
                gunaShadowPanel1.Visible = true;
                calysh_txt.ResetText();
                calysh_txt.Text = "Aýlar";
                try
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Servere baglanyp bilmedi..." + "\n\n" + ex.ToString(), "Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            if (xuiSegment1.SelectedIndex == 2)
            {
                ay_pnl.Enabled = false;
                caryek_pnl.Enabled = true;
                gun_pnl.Enabled = false;
                textBox1.ResetText();
                flowLayoutPanel1.Controls.Clear();
                label24.ResetText();
                label29.ResetText();
                gunaShadowPanel4.Visible = true;
                gunaShadowPanel1.Visible = true;
                calysh_txt.ResetText();
                calysh_txt.Text = "Çärýek";
                try
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Servere baglanyp bilmedi..." + "\n\n" + ex.ToString(), "Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                
            }
            if (xuiSegment1.SelectedIndex == 3)
            {
                textBox1.ResetText();
                gunaShadowPanel1.Visible = false;
                gunaShadowPanel4.Visible = false;
                flowLayoutPanel1.Controls.Clear();
                label24.ResetText();
                label29.ResetText();
            }
        }
      
        public string ip;
        private void full_2_Load(object sender, EventArgs e)
        {
            try
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
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Servere baglanyp bilmedi..."+"\n\n"+ex.ToString(),"Ýalňyşlyk",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
               
            } 
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
              baglandy_pct.Visible = true;
              sms_btn_ugrat_btn.Enabled = true;
            }
            else
            {
                //label9.Text = "Baglanmady...";
                //label9.ForeColor = Color.Red;
                sms_btn_ugrat_btn.Enabled = false;
                baglanmady_pct.Visible = true;
            }

            label20.Text = "■  " + Dns.GetHostName();
            foreach (IPAddress adres in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                ip = "" + adres;
                label20.Text = ip;
            }
           
        }

        private void gun_pckr_ValueChanged(object sender, EventArgs e)
        {
           
            //kompyuterde baza sene gornusini nahili gosduryan bolsak shona gora sazlanan
            flowLayoutPanel1.Controls.Clear();
            gun_grd.DataSource = null;
            string gun = gun_pckr.Value.Day.ToString();
            label29.Text = "0";
            if (Convert.ToInt16(gun) < 10)
            {
                gun = "0" + gun + "";
            }
            string ay = gun_pckr.Value.Month.ToString();
            if (Convert.ToInt16(ay) < 10)
            {
                ay = "0" + ay + "";
            }
            string yyl = gun_pckr.Value.Year.ToString();
            string umumy_sene = "" + yyl + "-" + ay + "-" + gun + "";
          
            if (bunifuCheckbox1.Checked == true && bunifuCheckbox2.Checked == true)
            {
                try
                {
                    ms.Open();
                    DataSet dss = new DataSet();
                    System.Data.DataTable dtt = new System.Data.DataTable();
                    dss.Tables.Add(dtt);
                    MySqlDataAdapter daa = new MySqlDataAdapter("SELECT ders,baha,ad FROM marks WHERE synp='"+synp_cmb.Text+"' AND ders='"+ders_cmb.Text+"' AND sene='" + umumy_sene.ToString() + "'", ms);
                    daa.Fill(dtt);
                    gun_grd.DataSource = dtt.DefaultView;
                    ms.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (gun_grd.Rows.Count > 0)
                {
                    label29.Text = gun_grd.Rows.Count.ToString();
                    for (int i = 0; i < gun_grd.Rows.Count; i++)
                    {
                        Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                        gpb.CustomBorderColor = Color.White;

                        if (gun_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {

                            gpb.ForeColor = Color.MediumSeaGreen;

                        }
                        else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {

                            gpb.ForeColor = Color.SlateBlue;

                        }
                        else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {

                            gpb.ForeColor = Color.DarkOrange;

                        }
                        else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {

                            gpb.ForeColor = Color.Red;

                        }
                        gpb.Text = gun_grd.Rows[i].Cells[0].Value.ToString() + " - " + gun_grd.Rows[i].Cells[1].Value.ToString() + " ( "+gun_grd.Rows[i].Cells[2].Value.ToString() + " )";
                        gpb.BorderRadius = 4;
                        gpb.ShadowDecoration.Enabled = true;
                        gpb.ShadowDecoration.Color = Color.Black;
                        gpb.ShadowDecoration.Depth = 4;
                        gpb.BorderColor = Color.White;
                        gpb.Height = 40;
                        gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                        Label lbl = new Label();
                        lbl.Text = gun_grd.Rows[i].Cells[1].Value.ToString();
                        //lbl.Location =new Point( 250,350);
                        //gpb.Controls.Add(lbl);

                        flowLayoutPanel1.Controls.Add(gpb);
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
            else if (bunifuCheckbox1.Checked == true)
            {
                try
                {
                    ms.Open();
                    DataSet dss = new DataSet();
                    System.Data.DataTable dtt = new System.Data.DataTable();
                    dss.Tables.Add(dtt);
                    MySqlDataAdapter daa = new MySqlDataAdapter("SELECT ders,baha,ad FROM marks WHERE synp='" + synp_cmb.Text + "' AND sene='" + umumy_sene.ToString() + "'", ms);
                    daa.Fill(dtt);
                    gun_grd.DataSource = dtt.DefaultView;
                    ms.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                }

                if (gun_grd.Rows.Count > 0)
                {
                    label29.Text = gun_grd.Rows.Count.ToString();
                    for (int i = 0; i < gun_grd.Rows.Count; i++)
                    {
                        Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                        gpb.CustomBorderColor = Color.White;

                        if (gun_grd.Rows[i].Cells[1].Value.ToString() == "5")
                        {

                            gpb.ForeColor = Color.MediumSeaGreen;

                        }
                        else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "4")
                        {

                            gpb.ForeColor = Color.SlateBlue;

                        }
                        else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "3")
                        {

                            gpb.ForeColor = Color.DarkOrange;

                        }
                        else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "2")
                        {

                            gpb.ForeColor = Color.Red;

                        }
                        gpb.Text = gun_grd.Rows[i].Cells[0].Value.ToString() + " - " + gun_grd.Rows[i].Cells[1].Value.ToString() + " ( " + gun_grd.Rows[i].Cells[2].Value.ToString() + " )";
                        gpb.BorderRadius = 4;
                        gpb.ShadowDecoration.Enabled = true;
                        gpb.ShadowDecoration.Color = Color.Black;
                        gpb.ShadowDecoration.Depth = 4;
                        gpb.BorderColor = Color.White;
                        gpb.Height = 40;
                        gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                        Label lbl = new Label();
                        lbl.Text = gun_grd.Rows[i].Cells[1].Value.ToString();
                        //lbl.Location =new Point( 250,350);
                        //gpb.Controls.Add(lbl);

                        flowLayoutPanel1.Controls.Add(gpb);
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
            else 
            { 
            // baha yok bar barlamak ucin
                    if (textBox1.Text == "")
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
                            MySqlDataAdapter daa = new MySqlDataAdapter("SELECT ders,baha FROM marks WHERE ad='" + textBox1.Text + "' AND sene='" + umumy_sene.ToString() + "'", ms);
                            daa.Fill(dtt);
                            gun_grd.DataSource = dtt.DefaultView;
                            ms.Close();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                        }

                        if (gun_grd.Rows.Count > 0)
                        {
                            label29.Text = gun_grd.Rows.Count.ToString();
                            for (int i = 0; i < gun_grd.Rows.Count; i++)
                            {
                                Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                                gpb.CustomBorderColor = Color.White;
                       
                                if (gun_grd.Rows[i].Cells[1].Value.ToString() == "5")
                                {

                                    gpb.ForeColor = Color.MediumSeaGreen;
                           
                                }
                                else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "4")
                                {

                                    gpb.ForeColor = Color.SlateBlue;
                           
                                }
                                else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "3")
                                {

                                    gpb.ForeColor = Color.DarkOrange;
                           
                                }
                                else if (gun_grd.Rows[i].Cells[1].Value.ToString() == "2")
                                {

                                    gpb.ForeColor = Color.Red;
                           
                                }
                                gpb.Text =gun_grd.Rows[i].Cells[0].Value.ToString() + " - " + gun_grd.Rows[i].Cells[1].Value.ToString();
                                gpb.BorderRadius = 4;
                                gpb.ShadowDecoration.Enabled = true;
                                gpb.ShadowDecoration.Color = Color.Black;
                                gpb.ShadowDecoration.Depth = 4;
                                gpb.BorderColor = Color.White;
                                gpb.Height = 40;
                                gpb.Font = new System.Drawing.Font("Century Gothic",9,FontStyle.Bold);
                                Label lbl = new Label();
                                lbl.Text = gun_grd.Rows[i].Cells[1].Value.ToString(); 
                                //lbl.Location =new Point( 250,350);
                                //gpb.Controls.Add(lbl);
                       
                                flowLayoutPanel1.Controls.Add(gpb);
                            }
                        }
                        else
                        {

                        }
                    }
            }
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

     

        private void ulalt_btn_Click_1(object sender, EventArgs e)
        {
            if (ulalt_btn.Text == "1")
            {
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                ulalt_btn.Text = "2";
                ders_cmb.Width=210;
                panel9.Width = 265;
            }
            else
            {
                this.Height = 760;
                this.Width = 1200;
                ulalt_btn.Text = "1";
                this.StartPosition = FormStartPosition.CenterScreen;
                ders_cmb.Width = 88;
                panel9.Width = 145;
            }
        }

        private void caryek_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            if (textBox1.Text == "")
            {
                Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                tx.Text = "Okuwçy adyny ýazyň...";
                tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                tx.ForeColor = Color.Red;
                tx.BorderThickness = 0;
                flowLayoutPanel1.Controls.Add(tx);
            }
            else
            {
                #region sentyabr
                if (caryek_cmb.SelectedIndex == 0)
                {
                    label29.Text = "0";
                    string bas_gun = "01";
                    string bas_ay = "09";
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
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                        daaa.Fill(dttt);
                        ay2_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    label29.Text = ay2_grd.Rows.Count.ToString();
                    if (ay2_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < ay2_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = ay2_grd.Rows[i].Cells[1].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
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
                #endregion
                #region oktyabr
                else if (caryek_cmb.SelectedIndex == 1)
                {
                    label29.Text = "0";
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
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                        daaa.Fill(dttt);
                        ay2_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    label29.Text = ay2_grd.Rows.Count.ToString();
                    if (ay2_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < ay2_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = ay2_grd.Rows[i].Cells[1].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
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
                #endregion
                #region noyabr
                else if (caryek_cmb.SelectedIndex == 2)
                {
                    label29.Text = "0";
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
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                        daaa.Fill(dttt);
                        ay2_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    label29.Text = ay2_grd.Rows.Count.ToString();
                    if (ay2_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < ay2_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = ay2_grd.Rows[i].Cells[1].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
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
                #endregion
                #region dekabr
                else if (caryek_cmb.SelectedIndex == 3)
                {
                    label29.Text = "0";
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
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                        daaa.Fill(dttt);
                        ay2_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    label29.Text = ay2_grd.Rows.Count.ToString();
                    if (ay2_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < ay2_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = ay2_grd.Rows[i].Cells[1].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
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
                #endregion
                #region yanwar
                else if (caryek_cmb.SelectedIndex == 4)
                {
                    label29.Text = "0";
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
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                        daaa.Fill(dttt);
                        ay2_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    label29.Text = ay2_grd.Rows.Count.ToString();
                    if (ay2_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < ay2_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = ay2_grd.Rows[i].Cells[1].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
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
                #endregion
                #region fewral
                else if (caryek_cmb.SelectedIndex == 5)
                {
                    label29.Text = "0";
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
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                        daaa.Fill(dttt);
                        ay2_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    label29.Text = ay2_grd.Rows.Count.ToString();
                    if (ay2_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < ay2_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = ay2_grd.Rows[i].Cells[1].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
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
                #endregion
                #region mart
                else if (caryek_cmb.SelectedIndex == 6)
                {
                    label29.Text = "0";
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
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                        daaa.Fill(dttt);
                        ay2_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    label29.Text = ay2_grd.Rows.Count.ToString();
                    if (ay2_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < ay2_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = ay2_grd.Rows[i].Cells[1].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
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
                #endregion
                #region aprel
                else if (caryek_cmb.SelectedIndex == 7)
                {
                    label29.Text = "0";
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
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                        daaa.Fill(dttt);
                        ay2_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    label29.Text = ay2_grd.Rows.Count.ToString();
                    if (ay2_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < ay2_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = ay2_grd.Rows[i].Cells[1].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
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
                #endregion
                #region may
                else if (caryek_cmb.SelectedIndex == 8)
                {
                    label29.Text = "0";
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
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + bas_sene + "' AND '" + son_sene + "' order by sene ASC", ms);
                        daaa.Fill(dttt);
                        ay2_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    label29.Text = ay2_grd.Rows.Count.ToString();
                    if (ay2_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < ay2_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (ay2_grd.Rows[i].Cells[1].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = ay2_grd.Rows[i].Cells[0].Value.ToString() + " - " + ay2_grd.Rows[i].Cells[1].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = ay2_grd.Rows[i].Cells[1].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
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
                #endregion
                else
                {

                }
            }
          
        }

        private void hepde_pckr_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            flowLayoutPanel1.Controls.Clear();
            hepde_grd.DataSource = null;
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
                    string gunn = "";
                    if (j < 10)
                    {
                        gunn = "0" + j + "";
                    }
                    else
                    {
                        gunn = j.ToString();
                    }
                    string ayy = "";
                    if (ay < 10)
                    {
                        ayy = "0" + ay + "";
                    }
                    else
                    {
                        ayy = ay.ToString();
                    }
                    dataGridView1.Rows.Add(gun1[s - 1].ToString(), (hepde_pckr.Value.Year + "-" + ayy + "-" + gunn).ToString());
                }
               
            }

            //hepde ayyn basynda bolsa; 
            else if (bas < 1)
            {
                int ay_0 = 0;
                if (Convert.ToInt32(DateTime.DaysInMonth(Convert.ToInt32(hepde_pckr.Value.Year.ToString()), ay - 1))!=0)
                {
                   
                    ay_0 = Convert.ToInt32(DateTime.DaysInMonth(Convert.ToInt32(hepde_pckr.Value.Year.ToString()), ay - 1));
                }
                else
                {
                     ay_0 = 1;
                }
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
                    if (ay <= 9)
                    {
                        ayy = "0" + (ay - 1) + "";
                    }
                    else if (ay == 13)
                    {
                        ayy = "01";
                    }
                    if(ay==10 || ay > 10)
                    {
                        ayy = (ay-1).ToString();
                    }
                    dataGridView1.Rows.Add(gun1[s - 1].ToString(), (hepde_pckr.Value.Year + "-" + ayy + "-" + gunn).ToString());
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
                    else if (ay == 13)
                    {
                        ayy = "01";
                    }
                    else
                    {
                        ayy = ay.ToString();
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
                    else
                    {
                        ayy = ay.ToString();
                    }
                    dataGridView1.Rows.Add(gun1[s - 1].ToString(), (hepde_pckr.Value.Year + "-" + ayy + "-" + gunn).ToString());
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
                    if (ay <= 9)
                    {
                        //ayy = "0" + (ay+1) + "";
                        ayy = (ay + 1).ToString();
                    }
                    else if(ay==13)
                    {
                        ayy = "01";
                    }
                    else
                    {
                        ayy=(ay+1).ToString();
                    }
                    dataGridView1.Rows.Add(gun1[s - 1].ToString(), (hepde_pckr.Value.Year + "-" + ayy + "-" + gunn).ToString());
                }
            }

            try
            {
                ms.Open();
                DataSet dsss = new DataSet();
                System.Data.DataTable dttt = new System.Data.DataTable();
                dsss.Tables.Add(dttt);
                MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT ders,baha,sene FROM marks WHERE  ad='" + textBox1.Text + "' AND sene BETWEEN '" + dataGridView1.Rows[0].Cells[1].Value.ToString() + "' AND '" + dataGridView1.Rows[6].Cells[1].Value.ToString() + "' order by sene ASC", ms);
                daaa.Fill(dttt);
                hepde_grd.DataSource = dttt.DefaultView;
                ms.Close();
                //
            }
            catch (Exception error)
            {
                MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
            }
           
            if (hepde_grd.Rows.Count > 0)
            { 
                
                for (int i = 0; i < hepde_grd.Rows.Count; i++)
                {
                    Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                    gpb.CustomBorderColor = Color.WhiteSmoke;

                    if (hepde_grd.Rows[i].Cells[1].Value.ToString() == "5")
                    {

                        gpb.ForeColor = Color.MediumSeaGreen;

                    }
                    else if (hepde_grd.Rows[i].Cells[1].Value.ToString() == "4")
                    {

                        gpb.ForeColor = Color.SlateBlue;

                    }
                    else if (hepde_grd.Rows[i].Cells[1].Value.ToString() == "3")
                    {

                        gpb.ForeColor = Color.DarkOrange;

                    }
                    else if (hepde_grd.Rows[i].Cells[1].Value.ToString() == "2")
                    {

                        gpb.ForeColor = Color.Red;

                    }
                    gpb.Text = hepde_grd.Rows[i].Cells[0].Value.ToString() + " - " + hepde_grd.Rows[i].Cells[1].Value.ToString();
                    gpb.BorderRadius = 4;
                    gpb.ShadowDecoration.Enabled = true;
                    gpb.ShadowDecoration.Color = Color.Black;
                    gpb.ShadowDecoration.Depth = 4;
                    gpb.BorderColor = Color.White;
                    gpb.Height = 40;
                    gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                    Label lbl = new Label();
                    lbl.Text = hepde_grd.Rows[i].Cells[1].Value.ToString();
                    //lbl.Location =new Point( 250,350);
                    //gpb.Controls.Add(lbl);

                    flowLayoutPanel1.Controls.Add(gpb);
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

        private void caryeklik_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            caryek_grd.DataSource = null;
            flowLayoutPanel1.Controls.Clear();
            label29.Text = "0";
            if (textBox1.Text == "")
            {
                Guna.UI2.WinForms.Guna2TextBox tx = new Guna.UI2.WinForms.Guna2TextBox();
                tx.Text = "Okuwçy adyny ýazyň...";
                tx.Font = new Font("Tw Cen MT", 11, FontStyle.Italic);
                tx.ForeColor = Color.Red;
                tx.BorderThickness = 0;
                flowLayoutPanel1.Controls.Add(tx);
            }
            else
            { 
                if (caryeklik_cmb.SelectedIndex == 0)
                {
                    label29.Text = "0";
                    try
                    {
                        ms.Open();
                        DataSet dsss = new DataSet();
                        System.Data.DataTable dttt = new System.Data.DataTable();
                        dsss.Tables.Add(dttt);
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT no,ders, ROUND(AVG(baha),0) as cjemi FROM marks WHERE  ad='" + textBox1.Text + "' AND caryek='1_caryek' group by ders order by ders ASC", ms);
                        daaa.Fill(dttt);
                        caryek_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }

                    label29.Text = caryek_grd.Rows.Count.ToString();
                    if (caryek_grd.Rows.Count > 0)
                    {

                        for (int i = 0; i < caryek_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = caryek_grd.Rows[i].Cells[1].Value.ToString() + " - " + caryek_grd.Rows[i].Cells[2].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = caryek_grd.Rows[i].Cells[2].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
                        }
                    }
                    else
                    {

                    }

                }
                else if (caryeklik_cmb.SelectedIndex == 1)
                {
                    label29.Text="0";
                    try
                    {
                        ms.Open();
                        DataSet dsss = new DataSet();
                        System.Data.DataTable dttt = new System.Data.DataTable();
                        dsss.Tables.Add(dttt);
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT no,ders, ROUND(AVG(baha),0) as cjemi FROM marks WHERE  ad='" + textBox1.Text + "' AND caryek='2_caryek' group by ders order by ders ASC", ms);
                        daaa.Fill(dttt);
                        caryek_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }

                    label29.Text = caryek_grd.Rows.Count.ToString();
                    if (caryek_grd.Rows.Count > 0)
                    {
                        for (int i = 0; i < caryek_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = caryek_grd.Rows[i].Cells[1].Value.ToString() + " - " + caryek_grd.Rows[i].Cells[2].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = caryek_grd.Rows[i].Cells[2].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
                        }
                    }
                    else
                    {

                    }
                }
                else if (caryeklik_cmb.SelectedIndex == 2)
                {
                    label29.Text = "0";
                    try
                    {
                        ms.Open();
                        DataSet dsss = new DataSet();
                        System.Data.DataTable dttt = new System.Data.DataTable();
                        dsss.Tables.Add(dttt);
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT no,ders, ROUND(AVG(baha),0) as cjemi FROM marks WHERE  ad='" + textBox1.Text + "' AND caryek='3_caryek' group by ders order by ders ASC", ms);
                        daaa.Fill(dttt);
                        caryek_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }

                    label29.Text = caryek_grd.Rows.Count.ToString();
                    if (caryek_grd.Rows.Count > 0)
                    {
                        for (int i = 0; i < caryek_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = caryek_grd.Rows[i].Cells[1].Value.ToString() + " - " + caryek_grd.Rows[i].Cells[2].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = caryek_grd.Rows[i].Cells[2].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
                        }
                    }
                    else
                    {

                    }
                }
                else if (caryeklik_cmb.SelectedIndex == 3)
                {
                    label29.Text = "0";
                    try
                    {
                        ms.Open();
                        DataSet dsss = new DataSet();
                        System.Data.DataTable dttt = new System.Data.DataTable();
                        dsss.Tables.Add(dttt);
                        MySqlDataAdapter daaa = new MySqlDataAdapter("SELECT no,ders, ROUND(AVG(baha),0) as cjemi FROM marks WHERE  ad='" + textBox1.Text + "' AND caryek='4_caryek' group by ders order by ders ASC", ms);
                        daaa.Fill(dttt);
                        caryek_grd.DataSource = dttt.DefaultView;
                        ms.Close();
                        //
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }

                    label29.Text = caryek_grd.Rows.Count.ToString();
                    if (caryek_grd.Rows.Count > 0)
                    {
                        for (int i = 0; i < caryek_grd.Rows.Count; i++)
                        {
                            Guna.UI2.WinForms.Guna2GroupBox gpb = new Guna.UI2.WinForms.Guna2GroupBox();
                            gpb.CustomBorderColor = Color.White;

                            if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "5")
                            {

                                gpb.ForeColor = Color.MediumSeaGreen;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "4")
                            {

                                gpb.ForeColor = Color.SlateBlue;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "3")
                            {

                                gpb.ForeColor = Color.DarkOrange;

                            }
                            else if (caryek_grd.Rows[i].Cells[2].Value.ToString() == "2")
                            {

                                gpb.ForeColor = Color.Red;

                            }
                            gpb.Text = caryek_grd.Rows[i].Cells[1].Value.ToString() + " - " + caryek_grd.Rows[i].Cells[2].Value.ToString();
                            gpb.BorderRadius = 4;
                            gpb.ShadowDecoration.Enabled = true;
                            gpb.ShadowDecoration.Color = Color.Black;
                            gpb.ShadowDecoration.Depth = 4;
                            gpb.BorderColor = Color.White;
                            gpb.Height = 40;
                            gpb.Font = new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold);
                            Label lbl = new Label();
                            lbl.Text = caryek_grd.Rows[i].Cells[2].Value.ToString();
                            //lbl.Location =new Point( 250,350);
                            //gpb.Controls.Add(lbl);

                            flowLayoutPanel1.Controls.Add(gpb);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void xuiSegment1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked == true)
            {
                panel8.Width = 150;
                synp_cmb.Visible = true;
                DataSet ds1 = new DataSet();
                System.Data.DataTable dt1 = new System.Data.DataTable();
                ms.Open();
                ds1.Tables.Add(dt1);
                MySqlDataAdapter da1 = new MySqlDataAdapter("select  synp_ady from tb_synp", ms);
                da1.Fill(dt1);
                DataRow dr = dt1.NewRow();
                dr["synp_ady"] = "";
                dt1.Rows.InsertAt(dr, 0);
                synp_cmb.ValueMember = "no";
                synp_cmb.DisplayMember = "synp_ady";
                synp_cmb.DataSource = dt1;
                ms.Close();
                gozle_pnl.Enabled = false;
            }
            else 
            {
                //panel8.Width = 70;
                flowLayoutPanel1.Controls.Clear();
                synp_cmb.Visible = false;
                if (bunifuCheckbox1.Checked == false && bunifuCheckbox2.Checked == false)
                {
                    gozle_pnl.Enabled = true;
                    flowLayoutPanel1.Controls.Clear();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
           
        }

		private void textBox1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            label24.ResetText();
            label29.ResetText();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                //bunifuMaterialTextbox1.Text = textBox1.Text;
                label7.ResetText();
                label12.ResetText();
                label15.ResetText();
                label19.ResetText();
                label22.ResetText();
                label24.ResetText();
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
                    label19.Text = rd[1].ToString();
                    label22.Text = rd[2].ToString();
                    label12.Text = rd[3].ToString();
                    label7.Text = rd[4].ToString(); label15.Text = rd[5].ToString(); label24.Text = rd[6].ToString();
                }
                //textBox1.AutoCompleteCustomSource = MyCollection;
                else
                {

                }
                ms.Close();
            }
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox2.Checked == true)
            {
                //panel9.Width = 300;
                ders_cmb.Visible = true;
                DataSet ds2 = new DataSet();
                System.Data.DataTable dt2 = new System.Data.DataTable();
                ms.Open();
                ds2.Tables.Add(dt2);
                MySqlDataAdapter da2 = new MySqlDataAdapter("select ders_ady from tb_ders group by ders_ady", ms);
                da2.Fill(dt2);
                DataRow dr1 = dt2.NewRow();
                dr1["ders_ady"] = "";
                dt2.Rows.InsertAt(dr1, 0);
                ders_cmb.ValueMember = "no";
                ders_cmb.DisplayMember = "ders_ady";
                ders_cmb.DataSource = dt2;
                ms.Close();
                gozle_pnl.Enabled = false;
            }
            else
            {
                panel9.Width = 70;
                ders_cmb.Visible = false;
                if (bunifuCheckbox1.Checked==false && bunifuCheckbox2.Checked==false)
                {
                     gozle_pnl.Enabled = true;
                }
            }
        }

        private void synp_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void ders_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sms_btn_ugrat_btn_Click(object sender, EventArgs e)
        {
            if (basga_belgi_chk.Checked==true)
            {
                
                string tell2 = bashga_belgi_txt.Text;
                string tell1 = "";
                richTextBox1.ResetText();
                sortla_grd.DataSource = null;
            #region gunler
                if (calysh_txt.Text=="Günler" && bunifuCheckbox1.Checked==true)
                    {
                        string gun = gun_pckr.Value.Day.ToString();
                        label29.Text = "0";
                        if (Convert.ToInt16(gun) < 10)
                        {
                            gun = "0" + gun + "";
                        }
                        string ay = gun_pckr.Value.Month.ToString();
                        if (Convert.ToInt16(ay) < 10)
                        {
                            ay = "0" + ay + "";
                        }
                        string yyl = gun_pckr.Value.Year.ToString();
                        string umumy_sene = "" + yyl + "-" + ay + "-" + gun + "";
                        try
                        {
                            ms.Open();
                            DataSet dss = new DataSet();
                            System.Data.DataTable dtt = new System.Data.DataTable();
                            dss.Tables.Add(dtt);
                            MySqlDataAdapter daa = new MySqlDataAdapter("SELECT ad FROM marks WHERE synp='" + synp_cmb.Text + "' AND sene='" + umumy_sene.ToString() + "' group by ad", ms);
                            daa.Fill(dtt);
                            sortla_grd.DataSource = dtt.DefaultView;
                            ms.Close();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                        }
                        int san = Convert.ToInt32(sortla_grd.Rows.Count);

                        for (int i = 0; i < san; i++)
                        {
                             try
                                {
                                    doldr_grd.DataSource = null;
                                    ms.Open();
                                    DataSet dss = new DataSet();
                                    System.Data.DataTable dtt = new System.Data.DataTable();
                                    dss.Tables.Add(dtt);
                                    MySqlDataAdapter daa = new MySqlDataAdapter("SELECT ders,baha FROM marks WHERE synp='" + synp_cmb.Text + "' AND sene='" + umumy_sene.ToString() + "' AND ad='"+sortla_grd.Rows[i].Cells[0].Value.ToString()+"'", ms);
                                    daa.Fill(dtt);
                                    doldr_grd.DataSource = dtt.DefaultView;
                                    ms.Close();
                                }
                             catch (Exception error)
                                {
                                    MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                                }

                             ms.Open();
                             MySqlCommand cmd2 = new MySqlCommand("select tel_kaka from tb_okuwcy where ad='" + sortla_grd.Rows[i].Cells[0].Value.ToString() + "'", ms);
                             cmd2.CommandType = CommandType.Text;
                             MySqlDataReader rd2 = cmd2.ExecuteReader();

                             if (rd2.Read())
                             {
                                 tell1 = rd2[0].ToString();
                             }

                             else
                             {

                             }
                             ms.Close();

                             int doldr_san = Convert.ToInt32(doldr_grd.Rows.Count);
                             for (int w= 0; w < doldr_san; w++)
                             {
                                 string gun1 = doldr_grd.Rows[w].Cells[0].Value.ToString();
                                string tere = "_";
                                string bosluk = " ";
                                string taze = gun1.Replace(tere, bosluk);
                                gun1 = taze;
                                string sms = taze + " - " + doldr_grd.Rows[w].Cells[1].Value.ToString();
                                richTextBox1.Text += sms + ",";
                             }
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
                                sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                                Thread.Sleep(100);
                                sp.WriteLine("AT+CMGS=\"" + tell2 + "\"" + Environment.NewLine);//Tel nomer
                                Thread.Sleep(100);
                                sp.WriteLine(richTextBox1.Text + Environment.NewLine);//sms tekst
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
                                richTextBox1.ResetText();
                             }
                             catch (Exception ex)
                             {
                                 MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         
                             }
                        }
               
                    }


                 if (calysh_txt.Text == "Günler" && bunifuCheckbox1.Checked==false)
                    {
                        int a = Convert.ToInt32(gun_grd.Rows.Count);

                        try
                        {
                            for (int i = 0; i < a; i++)
                            {
                                string gun = gun_grd.Rows[i].Cells[0].Value.ToString();
                                string tere = "_";
                                string bosluk = " ";
                                string taze = gun.Replace(tere, bosluk);
                                gun = taze;
                                string sms = taze + " - " + gun_grd.Rows[i].Cells[1].Value.ToString();
                                richTextBox1.Text += sms + ",";
                            }
                            ms.Open();
                            MySqlCommand cmd2 = new MySqlCommand("select No,ID,ad,synp,rota,wzwod,telno from tb_okuwcy where ad='" + textBox1.Text + "'", ms);
                            cmd2.CommandType = CommandType.Text;
                            MySqlDataReader rd2 = cmd2.ExecuteReader();

                            if (rd2.Read())
                            {
                                tell1 = rd2[6].ToString();
                            }

                            else
                            {

                            }
                            ms.Close();
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
                            sp.WriteLine("AT+CMGS=\"" + tell1 + "\"" + Environment.NewLine);//Tel nomer
                            Thread.Sleep(100);
                            sp.WriteLine(richTextBox1.Text + Environment.NewLine);//sms tekst
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
                            richTextBox1.ResetText();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            #endregion
            #region aylar
            else if (calysh_txt.Text == "Aýlar")
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
                        richTextBox1.Text += sms + ",";
                    }
                    ms.Open();
                    MySqlCommand cmd2 = new MySqlCommand("select No,ID,ad,synp,rota,wzwod,telno from tb_okuwcy where ad='" + textBox1.Text + "'", ms);
                    cmd2.CommandType = CommandType.Text;
                    MySqlDataReader rd2 = cmd2.ExecuteReader();

                    if (rd2.Read())
                    {
                        tell1 = rd2[6].ToString();
                    }

                    else
                    {

                    }
                    ms.Close();
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
                    sp.WriteLine("AT+CMGS=\"" + tell1 + "\"" + Environment.NewLine);//Tel nomer
                    Thread.Sleep(100);
                    sp.WriteLine(richTextBox1.Text + Environment.NewLine);//sms tekst
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
                    richTextBox1.ResetText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
            #region caryek
            else if (calysh_txt.Text == "Çärýek")
            {
                int a = Convert.ToInt32(caryek_grd.Rows.Count);

                try
                {
                    for (int i = 0; i < a; i++)
                    {
                        string gun = caryek_grd.Rows[i].Cells[1].Value.ToString();
                        string tere = "_";
                        string bosluk = " ";
                        string taze = gun.Replace(tere, bosluk);
                        gun = taze;
                        string sms = taze + " - " + caryek_grd.Rows[i].Cells[2].Value.ToString();
                        richTextBox1.Text += sms + ",";
                    }
                    ms.Open();
                    MySqlCommand cmd2 = new MySqlCommand("select No,ID,ad,synp,rota,wzwod,telno from tb_okuwcy where ad='" + textBox1.Text + "'", ms);
                    cmd2.CommandType = CommandType.Text;
                    MySqlDataReader rd2 = cmd2.ExecuteReader();

                    if (rd2.Read())
                    {
                        tell1 = rd2[6].ToString();
                    }

                    else
                    {

                    }
                    ms.Close();
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
                    sp.WriteLine("AT+CMGS=\"" + tell1 + "\"" + Environment.NewLine);//Tel nomer
                    Thread.Sleep(100);
                    sp.WriteLine(richTextBox1.Text + Environment.NewLine);//sms tekst
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
                    richTextBox1.ResetText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
                else
                {
                    MessageBox.Show("SMS ugradyp bolmady...", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string tell = "";
                string tell1 = "";
                richTextBox1.ResetText();
                sortla_grd.DataSource = null;
                #region gunler
                if (calysh_txt.Text == "Günler" && bunifuCheckbox1.Checked == true)
                {
                    string gun = gun_pckr.Value.Day.ToString();
                    label29.Text = "0";
                    if (Convert.ToInt16(gun) < 10)
                    {
                        gun = "0" + gun + "";
                    }
                    string ay = gun_pckr.Value.Month.ToString();
                    if (Convert.ToInt16(ay) < 10)
                    {
                        ay = "0" + ay + "";
                    }
                    string yyl = gun_pckr.Value.Year.ToString();
                    string umumy_sene = "" + yyl + "-" + ay + "-" + gun + "";
                    try
                    {
                        ms.Open();
                        DataSet dss = new DataSet();
                        System.Data.DataTable dtt = new System.Data.DataTable();
                        dss.Tables.Add(dtt);
                        MySqlDataAdapter daa = new MySqlDataAdapter("SELECT ad FROM marks WHERE synp='" + synp_cmb.Text + "' AND sene='" + umumy_sene.ToString() + "' group by ad", ms);
                        daa.Fill(dtt);
                        sortla_grd.DataSource = dtt.DefaultView;
                        ms.Close();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                    }
                    int san = Convert.ToInt32(sortla_grd.Rows.Count);

                    for (int i = 0; i < san; i++)
                    {
                        try
                        {
                            doldr_grd.DataSource = null;
                            ms.Open();
                            DataSet dss = new DataSet();
                            System.Data.DataTable dtt = new System.Data.DataTable();
                            dss.Tables.Add(dtt);
                            MySqlDataAdapter daa = new MySqlDataAdapter("SELECT ders,baha FROM marks WHERE synp='" + synp_cmb.Text + "' AND sene='" + umumy_sene.ToString() + "' AND ad='" + sortla_grd.Rows[i].Cells[0].Value.ToString() + "'", ms);
                            daa.Fill(dtt);
                            doldr_grd.DataSource = dtt.DefaultView;
                            ms.Close();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message);
                        }

                        ms.Open();
                        MySqlCommand cmd2 = new MySqlCommand("select telno from tb_okuwcy where ad='" + sortla_grd.Rows[i].Cells[0].Value.ToString() + "'", ms);
                        cmd2.CommandType = CommandType.Text;
                        MySqlDataReader rd2 = cmd2.ExecuteReader();

                        if (rd2.Read())
                        {
                            tell1 = rd2[0].ToString();
                        }

                        else
                        {

                        }
                        ms.Close();

                        int doldr_san = Convert.ToInt32(doldr_grd.Rows.Count);
                        for (int w = 0; w < doldr_san; w++)
                        {
                            string gun1 = doldr_grd.Rows[w].Cells[0].Value.ToString();
                            string tere = "_";
                            string bosluk = " ";
                            string taze = gun1.Replace(tere, bosluk);
                            gun1 = taze;
                            string sms = taze + " - " + doldr_grd.Rows[w].Cells[1].Value.ToString();
                            richTextBox1.Text += sms + ",";
                        }
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
                            sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                            Thread.Sleep(100);
                            sp.WriteLine("AT+CMGS=\"" + tell1 + "\"" + Environment.NewLine);//Tel nomer
                            Thread.Sleep(100);
                            sp.WriteLine(richTextBox1.Text + Environment.NewLine);//sms tekst
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
                            richTextBox1.ResetText();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                }


                if (calysh_txt.Text == "Günler" && bunifuCheckbox1.Checked == false)
                {
                    int a = Convert.ToInt32(gun_grd.Rows.Count);

                    try
                    {
                        for (int i = 0; i < a; i++)
                        {
                            string gun = gun_grd.Rows[i].Cells[0].Value.ToString();
                            string tere = "_";
                            string bosluk = " ";
                            string taze = gun.Replace(tere, bosluk);
                            gun = taze;
                            string sms = taze + " - " + gun_grd.Rows[i].Cells[1].Value.ToString();
                            richTextBox1.Text += sms + ",";
                        }
                        ms.Open();
                        MySqlCommand cmd2 = new MySqlCommand("select No,ID,ad,synp,rota,wzwod,telno from tb_okuwcy where ad='" + textBox1.Text + "'", ms);
                        cmd2.CommandType = CommandType.Text;
                        MySqlDataReader rd2 = cmd2.ExecuteReader();

                        if (rd2.Read())
                        {
                            tell = rd2[6].ToString();
                        }

                        else
                        {

                        }
                        ms.Close();
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
                        sp.WriteLine("AT+CMGS=\"" + tell + "\"" + Environment.NewLine);//Tel nomer
                        Thread.Sleep(100);
                        sp.WriteLine(richTextBox1.Text + Environment.NewLine);//sms tekst
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
                        richTextBox1.ResetText();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion
                #region aylar
                else if (calysh_txt.Text == "Aýlar")
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
                            richTextBox1.Text += sms + ",";
                        }
                        ms.Open();
                        MySqlCommand cmd2 = new MySqlCommand("select No,ID,ad,synp,rota,wzwod,telno from tb_okuwcy where ad='" + textBox1.Text + "'", ms);
                        cmd2.CommandType = CommandType.Text;
                        MySqlDataReader rd2 = cmd2.ExecuteReader();

                        if (rd2.Read())
                        {
                            tell = rd2[6].ToString();
                        }

                        else
                        {

                        }
                        ms.Close();
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
                        sp.WriteLine("AT+CMGS=\"" + tell + "\"" + Environment.NewLine);//Tel nomer
                        Thread.Sleep(100);
                        sp.WriteLine(richTextBox1.Text + Environment.NewLine);//sms tekst
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
                        richTextBox1.ResetText();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion
                #region caryek
                else if (calysh_txt.Text == "Çärýek")
                {
                    int a = Convert.ToInt32(caryek_grd.Rows.Count);

                    try
                    {
                        for (int i = 0; i < a; i++)
                        {
                            string gun = caryek_grd.Rows[i].Cells[1].Value.ToString();
                            string tere = "_";
                            string bosluk = " ";
                            string taze = gun.Replace(tere, bosluk);
                            gun = taze;
                            string sms = taze + " - " + caryek_grd.Rows[i].Cells[2].Value.ToString();
                            richTextBox1.Text += sms + ",";
                        }
                        ms.Open();
                        MySqlCommand cmd2 = new MySqlCommand("select No,ID,ad,synp,rota,wzwod,telno from tb_okuwcy where ad='" + textBox1.Text + "'", ms);
                        cmd2.CommandType = CommandType.Text;
                        MySqlDataReader rd2 = cmd2.ExecuteReader();

                        if (rd2.Read())
                        {
                            tell = rd2[6].ToString();
                        }

                        else
                        {

                        }
                        ms.Close();
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
                        sp.WriteLine("AT+CMGS=\"" + tell + "\"" + Environment.NewLine);//Tel nomer
                        Thread.Sleep(100);
                        sp.WriteLine(richTextBox1.Text + Environment.NewLine);//sms tekst
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
                        richTextBox1.ResetText();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion
                else
                {
                    MessageBox.Show("SMS ugradyp bolmady...", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void basga_belgi_chk_OnChange(object sender, EventArgs e)
        {
            if (basga_belgi_chk.Checked==true)
            {
                bashga_belgi_txt.Visible = true;
                bashga_belgi_txt.ResetText();
            }
            else
            {
                bashga_belgi_txt.Visible = false;
                bashga_belgi_txt.ResetText();
            }
        }

      
    }
}
