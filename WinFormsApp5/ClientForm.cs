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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            Repo rc = new Repo();
            rc.Database.EnsureCreated();

            dataGridViewClient.DataSource = rc.clients.ToList();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClintFormcs a = new AddClintFormcs();
            a.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewClient.SelectedRows.Count > 0)
            {

                Repo rc = new Repo();
                rc.Database.EnsureCreated();


                int id = int.Parse(dataGridViewClient.SelectedRows[0].Cells[0].Value.ToString());

                var clients = from r in rc.clients.ToList()
                            where r.Id == id
                            select r;

                Client client = clients.FirstOrDefault();

                EditClintFrom f = new EditClintFrom(client);
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
            if (dataGridViewClient.SelectedRows.Count > 0)
            {

                Repo rc = new Repo();
                rc.Database.EnsureCreated();


                int id = int.Parse(dataGridViewClient.SelectedRows[0].Cells[0].Value.ToString());

                var Clients = from r in rc.clients.ToList()
                            where r.Id == id
                            select r;

                Client client = Clients.FirstOrDefault();

                if (client != null)
                {
                    rc.Remove(client);
                    MessageBox.Show(" Are you sure ?");
                    rc.SaveChanges();
                    Load();

                }

            }
            else
            {
                MessageBox.Show(" You must select row to delete ");
            }
            MessageBox.Show(" Done ");
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
