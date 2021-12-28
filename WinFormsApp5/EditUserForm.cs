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
    public partial class EditUserForm : Form
    {
        User user;
        public EditUserForm(User u)
        {
            InitializeComponent();
            user = u;
            textBox3.Text = u.UserName;
            textBox2.Text = (string)u.Password;
            textBox1.Text = u.PhoneNumber;

        }
        //public EditUserForm(User user)
        //{
         //   InitializeComponent();
        //}

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            Repo rm = new Repo();
            comboBox2.DataSource =
             rm.Employees.ToList().
             Select(c => c.Id).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserForm f=new UserForm();
            f.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Repo re = new Repo();
            re.Database.EnsureCreated();

            user.UserName = textBox3.Text;
            user.Password = textBox2.Text;
            user.PhoneNumber = textBox1.Text;

            re.Employees.Update(user);
            re.SaveChanges();
            MessageBox.Show("Done");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
