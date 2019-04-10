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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter adp;
        SqlCommand cmd;

        DataSet ds;
        DataTable dt;
        DataRow dr;

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=PC;Initial Catalog=DenemeDB;Integrated Security=True");
            adp = new SqlDataAdapter();
            ds = new DataSet();
            adp.SelectCommand = new SqlCommand("SELECT * FROM OrderTBL", baglanti);

            adp.Fill(ds, "mydata");
            dt = ds.Tables["mydata"];
            dr = dt.Rows[0];

            dataGridView2.ReadOnly = true;

            dataGridView2.DataSource = ds.Tables["mydata"];
        }
    }
}
