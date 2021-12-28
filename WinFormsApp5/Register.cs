using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp5;

namespace TheCave
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Repo rm = new Repo();//making object from database
            rm.Database.EnsureCreated();//making Database
            if (txtname.Text == "")//if textname is null 
            {
                MessageBox.Show("Please Enter your UserName", "The Cave", MessageBoxButtons.OK);//tell him/her to enter his / her name
            }
            else if (txtpass.Text == "")//if textpass is null
            {
                MessageBox.Show("Please Enter your Password", "The Cave", MessageBoxButtons.OK);//tell him/her to enter his/her password

            }
            else if (txtpass.Text != txtcpass.Text)//if textpass not equal text confrimation pass 
            {
                MessageBox.Show("Please Enter your Correct Password", "The Cave", MessageBoxButtons.OK);//tell the user to enter the correct password 

            }
            else if (txtnumber.Text == "")//if textnum is null 
            {
                MessageBox.Show("Please Enter your Number ", "The Cave", MessageBoxButtons.OK);//tell the user to enter the phone number

            }
            else if ((txtnumber.Text).Length != 11)//if text length num not equal 11  
            {
                MessageBox.Show("Please Enter your Correct Phone Number", "The Cave", MessageBoxButtons.OK); //tell the user to enter the correct phone number

            }
            try
            {
                User s = new User();// making object from class user 
                s.UserName = txtname.Text;// enter the username in txtname
                s.Password=txtpass.Text;//enter password in txtpass
                s.Password=txtcpass.Text;   //enter confirmation password in txtcpass
                s.PhoneNumber=txtnumber.Text;//enter phone number in txtnumber
                rm.Employees.Add(s);//add account from user class 
                rm.SaveChanges();//save changes
                var res = MessageBox.Show("Sucess\n Do you want to login ", "Created", MessageBoxButtons.YesNo);
                if(res== DialogResult.Yes)// created ,, make the user go to login form 
                {
                    Form1 t = new Form1();  
                    t.Show();
                    Hide();
                }
                else
                {
                    txtname.Text = "";//textname eqal null
                    txtpass.Text = "";//textpass eqall null
                    txtcpass.Text = "";//text confirmation pass equall null
                    txtnumber.Text = "";//text number equall null
                }
            }catch (Exception ex)// take the errors in the try code 
            {
                MessageBox.Show("Error");//show to the user "Error!"
            }

          

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Hide();
        }
    }
}
