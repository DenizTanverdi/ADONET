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

namespace CommandBuilder
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
        SqlDataAdapter cmd;
        DataSet ds;
        DataTable dt;
        SqlCommandBuilder cmb;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd = new SqlDataAdapter("Select * from customers",con);
            ds = new DataSet();
            cmd.Fill(ds);
            cmb = new SqlCommandBuilder(cmd);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cmd.Update(ds);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd.Update(ds);
        }
    }
}
