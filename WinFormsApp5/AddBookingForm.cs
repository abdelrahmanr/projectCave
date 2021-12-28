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
    public partial class AddBookingForm : Form
    {
        public AddBookingForm()
        {
            InitializeComponent();
        }

        private void AddBookingForm_Load(object sender, EventArgs e)
        {
            //taking the username from class users and put it in combobox2.
            Repo rm = new Repo();
            comboBox2.DataSource =
             rm.Employees.ToList().
             Select(c => c.UserName).ToList();

            //taking the name from class clients and put it in combobox3.
            comboBox3.DataSource =
             rm.clients.ToList().
             Select(c => c.Name).ToList();

            //taking the name from class rooms and put it in combobox1.
            comboBox1.DataSource =
             rm.rooms.ToList().
             Select(c => c.name).ToList();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            BookingForm v = new BookingForm(); //creating object from booking form.
            v.Show(); //show booking form.
            Hide(); //hiding add booking form.

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking a = new Booking(); //create object from booking class.
            Repo rm = new Repo(); //creating object from the database.
            rm.Database.EnsureCreated(); // ensure making database.
            a.time = textBox2.Text; //read time in textbox2.
            a.NumberOfChairs = int.Parse(textBox5.Text); //read number of chairs in textbox5.
            a.TotalPrice = int.Parse(textBox6.Text); //read total price in textbox6.
            a.UserID = rm.Employees.
                ToList().Where(c => c.UserName == comboBox2.Text).
                 FirstOrDefault().Id; // checking if the username is the same at combobox2 ..if yes ..return the first ID.

            a.ClientID = rm.clients.
                ToList().Where(c => c.Name == comboBox3.Text).
                 FirstOrDefault().Id; // checking if the name is the same at combobox3 ..if yes ..return the first ID.
            a.RoomID = rm.rooms.
                ToList().Where(c => c.name == comboBox1.Text).
                 FirstOrDefault().Id; // checking if the name is the same at combobox1 ..if yes ..return the first ID.

            a.NumberOfHours = int.Parse(textBox7.Text); //reading the number of hours in textbox7.
            rm.bookings.Add(a); //adding.
            rm.SaveChanges(); //saving.
            MessageBox.Show("Done"); // by clicking save .. this message will appear

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
