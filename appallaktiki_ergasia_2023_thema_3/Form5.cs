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
    public partial class Form5 : Form
    {
        String connectionString = "Data source=kep.db;Version=3";
        SQLiteConnection connection;

        public Form5()
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
            bool flag = true;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                flag = false;
                MessageBox.Show("Συμπληρώστε όλα τα πεδία!");
            }

            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false)
            {
                flag = false;
                MessageBox.Show("Επιλέξτε το στοιχείο που θέλετε να τροποποιήσετε!");
            }

            if (flag)
            {
                if(checkBox1.Checked == true)
                {
                    connection.Open();
                    String updateSQL = "Update Kep set Name=@name where Surname=@surname and Telephone=@telephone and EidosAitimatos=@eidos_aitimatos";
                    SQLiteCommand command = new SQLiteCommand(updateSQL, connection);
                    command.Parameters.AddWithValue("surname", textBox1.Text);
                    command.Parameters.AddWithValue("telephone", textBox2.Text);
                    command.Parameters.AddWithValue("eidos_aitimatos", textBox3.Text);
                    command.Parameters.AddWithValue("name", textBox4.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (checkBox2.Checked == true)
                {
                    connection.Open();
                    String updateSQL = "Update Kep set Surname=@surname2 where Surname=@surname1 and Telephone=@telephone and EidosAitimatos=@eidos_aitimatos";
                    SQLiteCommand command = new SQLiteCommand(updateSQL, connection);
                    command.Parameters.AddWithValue("surname1", textBox1.Text);
                    command.Parameters.AddWithValue("telephone", textBox2.Text);
                    command.Parameters.AddWithValue("eidos_aitimatos", textBox3.Text);
                    command.Parameters.AddWithValue("surname2", textBox4.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (checkBox3.Checked == true)
                {
                    connection.Open();
                    String updateSQL = "Update Kep set Email=@email where Surname=@surname and Telephone=@telephone and EidosAitimatos=@eidos_aitimatos";
                    SQLiteCommand command = new SQLiteCommand(updateSQL, connection);
                    command.Parameters.AddWithValue("surname", textBox1.Text);
                    command.Parameters.AddWithValue("telephone", textBox2.Text);
                    command.Parameters.AddWithValue("eidos_aitimatos", textBox3.Text);
                    command.Parameters.AddWithValue("email", textBox4.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (checkBox4.Checked == true)
                {
                    connection.Open();
                    String updateSQL = "Update Kep set Telephone=@telephone2 where Surname=@surname and Telephone=@telephone1 and EidosAitimatos=@eidos_aitimatos";
                    SQLiteCommand command = new SQLiteCommand(updateSQL, connection);
                    command.Parameters.AddWithValue("surname", textBox1.Text);
                    command.Parameters.AddWithValue("telephone1", textBox2.Text);
                    command.Parameters.AddWithValue("eidos_aitimatos", textBox3.Text);
                    command.Parameters.AddWithValue("telephone2", textBox4.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (checkBox5.Checked == true)
                {
                    connection.Open();
                    String updateSQL = "Update Kep set DateOfBirth=@date_of_birth where Surname=@surname and Telephone=@telephone and EidosAitimatos=@eidos_aitimatos";
                    SQLiteCommand command = new SQLiteCommand(updateSQL, connection);
                    command.Parameters.AddWithValue("surname", textBox1.Text);
                    command.Parameters.AddWithValue("telephone", textBox2.Text);
                    command.Parameters.AddWithValue("eidos_aitimatos", textBox3.Text);
                    command.Parameters.AddWithValue("date_of_birth", textBox4.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (checkBox6.Checked == true)
                {
                    connection.Open();
                    String updateSQL = "Update Kep set Address=@address where Surname=@surname and Telephone=@telephone and EidosAitimatos=@eidos_aitimatos";
                    SQLiteCommand command = new SQLiteCommand(updateSQL, connection);
                    command.Parameters.AddWithValue("surname", textBox1.Text);
                    command.Parameters.AddWithValue("telephone", textBox2.Text);
                    command.Parameters.AddWithValue("eidos_aitimatos", textBox3.Text);
                    command.Parameters.AddWithValue("address", textBox4.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else if (checkBox7.Checked == true)
                {
                    connection.Open();
                    String updateSQL = "Update Kep set EidosAitimatos=@eidos_aitimatos2 where Surname=@surname and Telephone=@telephone and EidosAitimatos=@eidos_aitimatos1";
                    SQLiteCommand command = new SQLiteCommand(updateSQL, connection);
                    command.Parameters.AddWithValue("surname", textBox1.Text);
                    command.Parameters.AddWithValue("telephone", textBox2.Text);
                    command.Parameters.AddWithValue("eidos_aitimatos1", textBox3.Text);
                    command.Parameters.AddWithValue("eidos_aitimatos2", textBox4.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Επιτυχής Τροποποίηση Εγγραφής!");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }
    }
}
