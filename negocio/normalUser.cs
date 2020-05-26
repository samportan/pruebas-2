using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;

namespace negocio
{
    public partial class normalUser : Form
    {
        private string username = "";
        public normalUser(string nombre)
        {
            InitializeComponent();
            username = nombre;
        }
        
        private void normalUser_Load(object sender, EventArgs e)
        {
            var products = ConnectionDB.ExecuteQuery("SELECT \"productName\" FROM public.inventory");
            var productsCombo = new List<string>();
                        
            foreach (DataRow dr in products.Rows)
            {
                productsCombo.Add(dr[0].ToString());
            }
            
            ProductComboBox.DataSource = productsCombo;
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            string productname = ProductComboBox.GetItemText(ProductComboBox.SelectedItem);
                string qr = $"SELECT id_product FROM public.inventory WHERE \"productName\" = '{productname}'";
                var sl = ConnectionDB.ExecuteQuery(qr);
                int id = int.Parse(sl.Rows[0][2].ToString());
                var q = textBox1.Text;
                int quantity =  int.Parse(q);
            
                ConnectionDB.ExecuteNonQuery($"INSERT INTO public.orders(username, id_product, quantity)" +
                                             $" VALUES('{username}', {id}, {quantity})");

                MessageBox.Show("La orden ha sido registrada!!");
           
        }
    }
}