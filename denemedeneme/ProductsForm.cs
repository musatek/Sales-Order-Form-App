using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denemedeneme
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter adp;
        SqlCommand cmd;

        DataSet ds;
        DataTable dt;
        DataRow dr;

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'denemeDBDataSet.ProductTBL' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.productTBLTableAdapter.Fill(this.denemeDBDataSet.ProductTBL);
            SqlConnection baglanti = new SqlConnection("Data Source=PC;Initial Catalog=DenemeDB;Integrated Security=True");
            adp = new SqlDataAdapter();
            ds = new DataSet();
            adp.SelectCommand = new SqlCommand("select * from ProductTBL", baglanti);

            adp.Fill(ds, "mydata");
            dt = ds.Tables["mydata"];
            dr = dt.Rows[0];

            dataGridView1.ReadOnly = true;

            dataGridView1.DataSource = ds.Tables["mydata"];
        }
    }
}
