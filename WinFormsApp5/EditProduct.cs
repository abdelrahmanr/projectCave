using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheCave;

namespace WinFormsApp5
{
    public partial class EditProduct : Form
    {
        Product product;
        public EditProduct(Product p)
        {
            InitializeComponent();
            product = p;
           
            comboBox2.Text = p.productName;
            textBox4.Text = p.sellPrice.ToString();
            textBox2.Text = p.buyPrice.ToString();

        }   
        public EditProduct(IEnumerable<Product> products)
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm p=new ProductForm();
            p.Show();
            Hide(); 
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            Repo rm = new Repo();
            comboBox1.DataSource =
             rm.products.ToList().
             Select(c => c.Id).ToList();

            comboBox2.DataSource =
             rm.products.ToList().
             Select(c => c.productName).ToList();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Repo rp = new Repo();
            rp.Database.EnsureCreated();

           // product.productName = comboBox2.Text;
            product.sellPrice = int.Parse(textBox4.Text);
            product.buyPrice = int.Parse(textBox2.Text);
           
            
            rp.products.Update(product);
            rp.SaveChanges();
            MessageBox.Show("Done");
        }
    }
}
