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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repo rg = new Repo();//making object from database 
            rg.Database.EnsureCreated();//making database
            string name = textBox1.Text;//variable name put in textbox1

            string password = textBox2.Text;//variable password put in textbox2
            User u = (from c in rg.Employees.ToList()//using system linQ ,, taking name from user class 
                      where c.UserName == name && c.Password == password// if username from user class equal the name the user input
                      select c).FirstOrDefault();// and password from the user class equal to the pass the user input,,and select them
            if (u == null) // textbox equall null
            {
                MessageBox.Show("Login Falied");//tell the user login failed
            }
            else
            {
                Home h = new Home();
                h.Show();
                Hide();
            }
               
           

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterForm r= new RegisterForm();
            r.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form2 r = new Form2();
            r.Show();
            Hide();
        }
    }
}