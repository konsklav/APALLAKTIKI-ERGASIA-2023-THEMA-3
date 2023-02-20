﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appallaktiki_ergasia_2023_thema_3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            ProvoliAitimatos p1 = new ProvoliAitimatos("Provoli Olwn");
            richTextBox1.Text = p1.Provoli();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                ProvoliAitimatos p2 = new ProvoliAitimatos("Provoli Aitimatos Politi", textBox1.Text, textBox2.Text);
                richTextBox1.Text = p2.Provoli();

                textBox1.Text = "";
                textBox2.Text = "";
            }
            else 
            {
                MessageBox.Show("Πληκτρολογήστε τα στοιχεία του πολίτη!");
            }
        }
    }
}
