
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sms
{
    public partial class baglan : Form
    {
        public baglan()
        {
            InitializeComponent();
            
        }
          
        MySqlConnection ms = new MySqlConnection(baglanmysql.baglanmakucin());
           
        private void button1_Click(object sender, EventArgs e)
        { 
            
            ms.Open();
            try
            {
                if (ms.State == ConnectionState.Open)
                {
                    MessageBox.Show("baglandy");
                    test_al();
                }
                else 
                {
                    MessageBox.Show("baglanmady entak....");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("baglanyp bilmedi yalnyslyk : "+ ex.ToString() +"");
                ms.Close();
            }


           
        }

        public void test_al()
        {
            try
            {
                DataSet dss = new DataSet();
                System.Data.DataTable dtt = new System.Data.DataTable();
               
                dss.Tables.Add(dtt);
                MySqlDataAdapter daa = new MySqlDataAdapter("select * from inbox", ms);
                daa.Fill(dtt);
                dataGridView1.DataSource = dtt.DefaultView; 
                
            }
            catch (Exception error)
            { 
                MessageBox.Show("Näsazlyk ýüze çykdy : " + error.Message); 
            } 
            ms.Close();
            
        }
    }
}
