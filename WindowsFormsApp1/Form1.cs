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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
        SqlDataAdapter cmd;
        public Form1()
        {
            InitializeComponent();
        }
        DataTable tbl ;
        private void Form1_Load(object sender, EventArgs e)
        { tbl = new DataTable();
            tbl = new DataTable();
            string sql = "Select CategoryName,CategoryId from Categories ";
             cmd = new SqlDataAdapter(sql, con);
            con.Open();
            cmd.Fill(tbl);
          
            
                comboBox1.DataSource=tbl;
                comboBox1.DisplayMember = "CategoryName";
                comboBox1.ValueMember = "CategoryId";


            
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               // string Id = comboBox1.SelectedValue.ToString(); ;
                string sql = "Select ProductId,ProductName from Products  Where Products.CategoryID=@Id";
                cmd = new SqlDataAdapter(sql, con);
                cmd.SelectCommand.Parameters.AddWithValue("@Id", comboBox1.SelectedValue);
                tbl = new DataTable();
                cmd.Fill(tbl);


                listBox1.DataSource = tbl;
                listBox1.DisplayMember = "ProductName";
                listBox1.ValueMember = "ProductId";
            }
            catch (Exception )
            {

                
            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "UrunSiparisleri";
                cmd = new SqlDataAdapter(sql, con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@productId", listBox1.SelectedValue);
                tbl = new DataTable();
                cmd.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {

            } 
        }
    }
}
