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

namespace Customer
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
        SqlDataAdapter cmd;
        public Form1()
        {
            InitializeComponent();
        }
        DataTable tbl;
        private void Form1_Load(object sender, EventArgs e)
        {
            tbl = new DataTable();
            string sql = "Select CompanyName,ShipperId from Shippers ";
            cmd = new SqlDataAdapter(sql, con);
            con.Open();
            cmd.Fill(tbl);


            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "CompanyName";
            comboBox1.ValueMember = "ShipperId";
            tbl = new DataTable();
            string sql2 = "Select CompanyName,CustomerId from Customers ";

            cmd = new SqlDataAdapter(sql2, con);
            
            cmd.Fill(tbl);
            listBox1.DataSource = tbl;
            listBox1.DisplayMember = "CompanyName";
            listBox1.ValueMember = "CustomerId";
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 tbl = new DataTable();
                string sql = "Select	( Convert(nvarchar(20),OrderID)++' '+ Convert(nvarchar(20),OrderDate,10)) as Display,OrderId  from Orders  Where Orders.CustomerId=@Id and Orders.ShipVia=@SId";
                cmd = new SqlDataAdapter(sql, con);
                cmd.SelectCommand.Parameters.AddWithValue("@Id", listBox1.SelectedValue);
                cmd.SelectCommand.Parameters.AddWithValue("@SId", comboBox1.SelectedValue);
                cmd.Fill(tbl);
                listBox2.DataSource = tbl;

                listBox2.DisplayMember = tbl.Columns["Display"].ToString();
                listBox2.ValueMember = "OrderId";
                dataGridView1.DataSource = tbl;
               
            }
            catch (Exception)
            {

                
            }
        }

        
    }
}
