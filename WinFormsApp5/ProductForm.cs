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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            Repo rp = new Repo();
            rp.Database.EnsureCreated();

            dataGridViewProduct.DataSource = rp.products.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddProductForm f = new AddProductForm();
            f.Show();
            Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count > 0)
            {

                Repo rp = new Repo();
                rp.Database.EnsureCreated();


                int id = int.Parse(dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString());

                var products = from r in rp.products.ToList()
                            where r.Id == id
                            select r;
                
                Product product = products.FirstOrDefault();

                EditProduct f = new EditProduct(product);
                f.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(" You must select row to edit ");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            Hide();
            
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count > 0)
            {

                Repo rp = new Repo();
                rp.Database.EnsureCreated();

                int id = int.Parse(dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString());

                var products = from r in rp.products.ToList()
                            where r.Id == id
                            select r;

                Product pro = products.FirstOrDefault();
               //MessageBox.Show(pro.productName);
                if (pro != null)
                {
                    rp.Remove(pro);
                    MessageBox.Show(" Are you sure ? ");
                    rp.SaveChanges();
                    load();
                }

            }
            else
            {
                MessageBox.Show(" You must select row to delete ");
            }
            MessageBox.Show(" Done");
        }
    }
}
