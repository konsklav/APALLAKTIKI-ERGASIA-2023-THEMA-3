using System;
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
    public partial class Form1 : Form
    {
        String connectionString = "Data source=kep.db;Version=3";
        SQLiteConnection connection;

        public Form1()
        {
            InitializeComponent();
            connection = new SQLiteConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            String createSQL = "Create table if not exists Kep(ID integer auto increment primary key,Name Text,Surname Text,Email Text,Telephone Text,DateOfBirth Text,EidosAitimatos Text,Address Text,DateTime Text)";
            SQLiteCommand command = new SQLiteCommand(createSQL, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void νέοΑίτημαToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void προβολήΑιτημάτωνToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void διαγραφήΕγγραφήςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void τροποποίησηΕγγραφήςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void αναζήτησηΑιτήματοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }
    }
}
