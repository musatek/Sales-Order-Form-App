using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace denemedeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        SqlConnection baglanti;
        double tax = 0;
        double subTotal = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("Data Source=PC;Initial Catalog=DenemeDB;Integrated Security=True");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ProductsForm form = new ProductsForm();
            form.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string productID = productIDEntry.Text.Trim();
            string productQuantity = productQuantityEntry.Text.Trim();
            
            baglanti.Open();
            
            String productName = queryForGettingProductInfos("Product_Name", productID);
            String productComment = queryForGettingProductInfos("Product_Comment", productID);
            String productCost = queryForGettingProductInfos("Product_Cost", productID);

            if (productName.Equals("") || productComment.Equals("") || productCost.Equals(""))
            {
                MessageBox.Show("Geçersiz Ürün ID");
                baglanti.Close();
            }
            else
            {
                double totalCost = Convert.ToInt32(productCost) * Convert.ToInt32(productQuantity);
                tax = tax + ((totalCost * 10) / 100);
                textBox3.Text = Convert.ToString(tax);
                subTotal = subTotal + totalCost + tax;
                textBox4.Text = Convert.ToString(subTotal);

                ListViewItem item = new ListViewItem(productName);
                item.SubItems.Add(productComment);
                item.SubItems.Add(productCost);
                item.SubItems.Add(productQuantity);
                item.SubItems.Add(Convert.ToString(totalCost));
                listView1.Items.Add(item);
                baglanti.Close();
            }

            productIDEntry.Clear();
            productQuantityEntry.Clear();
            productIDEntry.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string OrderIdQuery = "SELECT Max(Order_ID) FROM ORDERTBL";
            SqlCommand cmd2 = new SqlCommand(OrderIdQuery, baglanti);
            String field4 = Convert.ToString(cmd2.ExecuteScalar());

            int orderId = Convert.ToInt32(field4) + 1;
            string BillComName = textBox1.Text.Trim();
            string BillAddress = textBox2.Text.Trim();
            string BillPhone = textBox6.Text.Trim();
            string ShipComName = textBox12.Text.Trim();
            string ShipAddress = textBox11.Text.Trim();
            string ShipPhone = textBox7.Text.Trim();

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string productNameFromLV = listView1.Items[i].SubItems[0].Text;
                string productCommentFromLV = listView1.Items[i].SubItems[1].Text;
                string productQuantityFromLV = listView1.Items[i].SubItems[3].Text;
                string productCostFromLV = listView1.Items[i].SubItems[2].Text;
                string totalCostFromLV = listView1.Items[i].SubItems[4].Text;


                string ProductIdQuery = "SELECT Product_Id FROM ProductTBL WHERE Product_Name = '" + productNameFromLV + "'";
                SqlCommand cmd3 = new SqlCommand(ProductIdQuery, baglanti);
                String field3 = Convert.ToString(cmd3.ExecuteScalar());

                int productId = Convert.ToInt32(field3);
                string tax = textBox3.Text;
                string subTotal = textBox4.Text;

                #region Insert OrderTBL Query

                cmd = new SqlCommand("INSERT INTO OrderTBL (" +
                    "Order_ID, Order_Date, Bill_Com_Name, Bill_Address, Bill_Phone, Ship_Com_Name, Ship_Address, Ship_Phone, Product_Id, Product_Name, Product_Quantity, Product_Unit_Cost, Product_Net_Total, Tax, Sub_Total)  VALUES (" +
                    + orderId + ", GETDATE(),'" + BillComName + "','" + BillAddress + "','" + BillPhone + "','" + ShipComName + "','" + ShipAddress + "','" + ShipPhone + "'," + productId + ",'" + productNameFromLV + "'," + productQuantityFromLV + "," + productCostFromLV + "," + totalCostFromLV + "," + tax + "," + subTotal + ")", baglanti);
                #endregion

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception E)
                {
                    MessageBox.Show("Hata meydana geldi : " + E.Message);
                }
            }

            clearAllEntries();
            baglanti.Close();
        }

        public String queryForGettingProductInfos(string fieldName, string productID)
        {
            string productQuery = "SELECT " + fieldName + " FROM ProductTBL WHERE Product_Id = " + productID;
            SqlCommand cmd = new SqlCommand(productQuery, baglanti);
            String field = Convert.ToString(cmd.ExecuteScalar());
            
            return field;
        }

        public void clearAllEntries()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox7.Clear();
            textBox3.Clear();
            textBox4.Clear();
            listView1.Items.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrdersForm form = new OrdersForm();
            form.Show();
        }
    }
}
