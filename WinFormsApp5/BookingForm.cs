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
    public partial class BookingForm : Form
    {
        private object bookings;

        public BookingForm()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            Repo re = new Repo();
            re.Database.EnsureCreated();

            dataGridViewBooking.DataSource = re.bookings.ToList();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home h=new Home();
            h.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddBookingForm a=new AddBookingForm();
            a.Show();
            Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooking.SelectedRows.Count > 0)
            {

                Repo rm = new Repo();
                rm.Database.EnsureCreated();

                //selecting row from the data gridview and assign it to variable id. 
                int id = int.Parse(dataGridViewBooking.SelectedRows[0].Cells[0].Value.ToString()); 
                
                var booking = from r in rm.bookings.ToList()
                            where r.Id == id
                            select r; // select the id if the id from the booking class is the same at the variable booking 

                Booking bo = booking.FirstOrDefault(); //return the first id.

                EditBookingForm b = new EditBookingForm(bo); //creating variable b from edit booking form.
                b.Show(); //show edit booking form.
                Hide(); //hide booking form.
            }
            else
            {
                MessageBox.Show(" You must select row to edit  "); //if user doesn't select any row this message will appear.
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooking.SelectedRows.Count > 0)
            {

                Repo re = new Repo();
                re.Database.EnsureCreated();


                int id = int.Parse(dataGridViewBooking.SelectedRows[0].Cells[0].Value.ToString());

                var rooms = from r in re.roomTypes.ToList()
                            where r.ID == id
                            select r;

                RoomType room = rooms.FirstOrDefault();

                if (room != null)
                {
                    re.Remove(room);
                    MessageBox.Show(" Are you sure ? ");
                    re.SaveChanges();
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
