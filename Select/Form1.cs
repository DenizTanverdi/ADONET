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
            listBox1.Items.Clear();
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
                    listBox1.Items.Add($"{dr["FirstName"]} {dr["LastName"]} -> {dr["BirthDate"]}");
                }
               
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime? datetime = null;
            string ad, soyad;
            listBox1.Items.Clear();
            DataSet ds = new DataSet();
            string sql = "Select LastName ,FirstName,BirthDate  from Employees";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            cmd.Fill(ds);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ad = item["FirstName"].ToString();
                soyad = item["LastName"].ToString();
                var deneme = item["BirthDate"].ToString();
                if (deneme!="")
                {
                    datetime = Convert.ToDateTime(item["BirthDate"].ToString());
                    listBox1.Items.Add($"{ad} ->> {soyad} ->> {datetime}");
                }
                else
                {
                    listBox1.Items.Add($"{ad} ->> {soyad} ->>");
                }
                //if(isNull(item["BirthDate"]}))
                // listBox1.Items.Add($"{item["FirstName"]} ->> {item["LastName"]} ->> {item["BirthDate"]}");
               

            }
          //  SqlDataReader rdr = cmd.SelectCommand.ExecuteReader();
        }
    }
}
