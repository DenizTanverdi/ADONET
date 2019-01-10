using Dapper;
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

namespace WinDapper
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);

        SqlDataAdapter cmd;
        DataSet ds;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            var cat = new Categories();
          /*  cat.CategoryName = "deniz";
            cat.Description = "deneme";
            string sql = "insert into Categories(CategoryName,description) values(@categoryName,@description)";
            con.Execute(sql, cat);*/
            var category = con.Query<Categories>("Select * from Categories");
            comboBox1.DataSource = category;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";

          /*  var customer = con.Query<Customer>("Select CustomerId,CompanyName from Customers ");
            listBox1.DataSource = customer;
            listBox1.DisplayMember = "CompanyName";
            listBox1.ValueMember = "CustomerId";*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sp = "8";
                var customer = con.Query<Products>("Select * from Products where CategoryId=@categoryId  ",comboBox1.SelectedItem );
                listBox1.DataSource = customer;
                listBox1.DisplayMember = "ProductName";
                listBox1.ValueMember = "ProductId";
            }
            catch (Exception)
            {

                
            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Siparis s = new Siparis();
            DynamicParameters param = new DynamicParameters();
            param.Add(" @productId", listBox1.SelectedItem);

            try
            {
                //var param = 
                var siparis = con.Execute("UrunSiparisleri", param , commandType: CommandType.StoredProcedure);
                dataGridView1.DataSource = siparis;
                
               

            }
            catch (Exception)
            {

               
            }
           
        }
    }
}
