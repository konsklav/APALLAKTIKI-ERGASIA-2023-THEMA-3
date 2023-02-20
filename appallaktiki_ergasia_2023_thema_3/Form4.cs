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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace appallaktiki_ergasia_2023_thema_3
{
    public partial class Form4 : Form
    {
        String connectionString = "Data source=kep.db;Version=3";
        SQLiteConnection connection;

        public Form4()
        {
            InitializeComponent();
            connection = new SQLiteConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                connection.Open();
                String deleteSQL = "Delete from Kep where Surname=@surname and Telephone=@telephone and EidosAitimatos=@eidos_aitimatos";
                SQLiteCommand command = new SQLiteCommand(deleteSQL, connection);
                command.Parameters.AddWithValue("surname", textBox1.Text);
                command.Parameters.AddWithValue("telephone", textBox2.Text);
                command.Parameters.AddWithValue("eidos_aitimatos", textBox3.Text);
                command.ExecuteNonQuery();
                connection.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                MessageBox.Show("Επιτυχής Διαγραφή Εγγραφής!");
            }
            else
            {
                MessageBox.Show("Συμπληρώστε όλα τα πεδία για Διαγραφή της Εγγραφής!");
            }
        }
    }
}
