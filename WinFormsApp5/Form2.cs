using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 r = new Form1();
            r.Show();
            Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
