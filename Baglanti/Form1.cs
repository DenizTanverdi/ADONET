using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baglanti
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
       // DataSet ds = new DataSet();
       // DataTable dt;
       // SqlDataAdapter adap = new SqlDataAdapter();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                //con.Close();
                MessageBox.Show("Database Acık");
            }
            else
            {
          
                MessageBox.Show("Database Kapalı.");

                con.Open();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                MessageBox.Show("Database Kapatıldı");
            }
            else
            {

                MessageBox.Show("Database Kapalı.");

              //  con.Open();
            }
        }
    }
}
