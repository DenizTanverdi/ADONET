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
    public partial class Insert : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
        public Insert()
        {
            InitializeComponent();
        }

        private void Insert_Load(object sender, EventArgs e)
        {
            var category = con.Query<Categories>("Select * from Categories");
            CmbBxCateg.DataSource = category;
            CmbBxCateg.DisplayMember = "CategoryName";
            CmbBxCateg.ValueMember = "CategoryId";
            var sup = con.Query<Suppliers>("Select * from Suppliers");
            cmbBxSup.DataSource = sup;
            cmbBxSup.DisplayMember = "CompanyName";
            cmbBxSup.ValueMember = "SupplierID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s= ((WinDapper.Suppliers)(cmbBxSup.SelectedItem)).SupplierID;
            var c= ((WinDapper.Categories)(CmbBxCateg.SelectedItem)).CategoryId;
            var insert = con.Query("Insert Into Products (ProductName, SupplierID, CategoryID, UnitPrice) Values(@pName,@sId,@cId,@Unit)",new {pName=txtBxName.Text,sId=s,cId=c,Unit=txtBxPrice.Text});
            MessageBox.Show("Eklendi.");

        }
    }
}
