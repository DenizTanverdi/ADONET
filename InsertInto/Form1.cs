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

namespace InsertInto
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //string name = txtBxName.Text;
            string sql = "Insert Into Categories(CategoryName,Description)Values('"+txtBxName.Text+"','"+txtBxAc.Text+"') ";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kaydınız Eklendi.");
        }

        private void btnPro_Click(object sender, EventArgs e)
        {
            /* string sql = "Insert Into Categories(CategoryName,Description)Values(@catName,@desc) select @@IDENTITY";
             SqlCommand cmd = new SqlCommand(sql, con);

             con.Open();
             //düzenleme yapılmıstır.
             cmd.Parameters.AddWithValue("@catName", txtBxName.Text);
             cmd.Parameters.AddWithValue("@desc", txtBxAc.Text);

             cmd.ExecuteNonQuery();
            int k = Convert.ToInt32(cmd.ExecuteScalar());
            LblId.Text = "Id: " + k.ToString();
            con.Close();*/
           con.Open();
            SqlCommand cmd = new SqlCommand("DEklecat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", txtBxName.Text);
            cmd.Parameters.AddWithValue("@description", txtBxAc.Text);

            
            cmd.ExecuteNonQuery();
            con.Close();


        }
    }
}
