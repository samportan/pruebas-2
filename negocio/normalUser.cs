using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;

namespace negocio
{
    public partial class normalUser : Form
    {
        public normalUser(string nombre)
        {
            InitializeComponent();
        }
        

        private void lblProductName_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblQuantity_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void labelTotal_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
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
    }
}