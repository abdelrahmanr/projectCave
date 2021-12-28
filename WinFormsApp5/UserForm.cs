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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            Repo rw = new Repo();
            rw.Database.EnsureCreated();

            dataGridViewUser.DataSource = rw.Employees.ToList();
            dataGridViewUser.Columns[2].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home r = new Home();    
            r.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddUserForm f=new AddUserForm();
            f.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" delete clicked ");
            if (dataGridViewUser.SelectedRows.Count > 0)
            {

                Repo rr = new Repo();
                rr.Database.EnsureCreated();


                int id = int.Parse(dataGridViewUser.SelectedRows[0].Cells[3].Value.ToString());

                var users = from r in rr.Employees.ToList()
                            where r.Id == id
                            select r;

                User user = users.FirstOrDefault();

                EditUserForm d = new EditUserForm(user);
                d.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(" You must select row to edit ");
            }

        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridViewUser.SelectedRows.Count > 0)
            {

                Repo rq = new Repo();
                rq.Database.EnsureCreated();


                int id = int.Parse(dataGridViewUser.SelectedRows[0].Cells[3].Value.ToString());

                var users = from r in rq.Employees.ToList()
                            where r.Id == id
                            select r;

                User user = users.FirstOrDefault();


                if (user != null)
                {
                    rq.Remove(user);
                    MessageBox.Show(" Are you sure ? ");
                    rq.SaveChanges();
                    load();
                }
                

            }
            else
            {
                MessageBox.Show(" You must select row to delete ");
            }
           // MessageBox.Show(" Done ");
        }

        private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
