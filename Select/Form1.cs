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

namespace Select
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            string sql = "Select LastName ,FirstName,BirthDate  from Employees";
            SqlCommand cmd = new SqlCommand(sql,con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            
           // con.Open();
            
            
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox1.Items.Add($"{dr["FirstName"]} {dr["LastName"]} {dr["BirthDate"]}");
                }
               
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


        }
    }
}
