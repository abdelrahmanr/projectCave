﻿using System;
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
    public partial class RoomTypeFrom : Form
    {
        public RoomTypeFrom()
        {
            InitializeComponent();
            load();
        }

        void load()
        {
            Repo re = new Repo();
            re.Database.EnsureCreated();

            dataGridView1.DataSource = re.roomTypes.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           AddRoomTypeForm g = new AddRoomTypeForm();
            g.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           Home a = new Home ();
            a.Show();
            Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                Repo re = new Repo();
                re.Database.EnsureCreated();


                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                var rooms = from r in re.roomTypes.ToList()
                            where r.ID == id
                            select r;

                RoomType room = rooms.FirstOrDefault();

                EditRoomTypeForm f = new EditRoomTypeForm(room);
                f.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(" You must select row to edit ");
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 )
            {

                Repo re = new Repo();
                re.Database.EnsureCreated();


                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                var rooms =  from r in re.roomTypes.ToList()
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
            MessageBox.Show(" Done ");
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RoomTypeFrom_Load(object sender, EventArgs e)
        {

        }
    }
}
