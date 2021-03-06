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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            load();

        }
        void load()
        {
            Repo rd = new Repo();
            rd.Database.EnsureCreated();

            dataGridViewOrder.DataSource = rd.orders.ToList();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            f.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrderForm f = new AddOrderForm();
            f.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrder.SelectedRows.Count > 0)
            {

                Repo rd = new Repo();
                rd.Database.EnsureCreated();


                int id = int.Parse(dataGridViewOrder.SelectedRows[0].Cells[0].Value.ToString());

                var orders = from r in rd.orders.ToList()
                             where r.Id == id
                             select r;

                order order = orders.FirstOrDefault();

                EditOrderForm f = new EditOrderForm(order);
                f.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(" You must select row to edit ");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrder.SelectedRows.Count > 0)
            {

                Repo rd = new Repo();
                rd.Database.EnsureCreated();


                int id = int.Parse(dataGridViewOrder.SelectedRows[0].Cells[0].Value.ToString());

                var orders = from r in rd.orders.ToList()
                             where r.Id == id
                             select r;

                order order = orders.FirstOrDefault();

                if (order != null)
                {
                    rd.Remove(order);
                    MessageBox.Show(" Are you sure ? ");
                    rd.SaveChanges();
                    load();
                }

            }
            else
            {
                MessageBox.Show(" You must select row to delete ");
               
            }
            MessageBox.Show(" Done ");
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }
    }
}

