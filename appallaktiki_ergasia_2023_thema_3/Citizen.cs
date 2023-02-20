using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appallaktiki_ergasia_2023_thema_3
{
    internal class Citizen
    {
        protected string name, surname, email, telephone, date_of_birth, address;

        String connectionString = "Data source=kep.db;Version=3";
        SQLiteConnection connection;

        public Citizen()
        {

        }

        public Citizen(string name, string surname, string email, string telephone, string date_of_birth, string address)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.telephone = telephone;
            this.date_of_birth = date_of_birth;
            this.address = address;

            connection = new SQLiteConnection(connectionString);
        }

        public void NeoAitimaPoliti(string eidos_aitimatos)
        {
            try {
                connection.Open();
                String insertSQL = "Insert into Kep(Name,Surname,Email,Telephone,DateOfBirth,EidosAitimatos,Address,DateTime) values(@name,@surname,@email,@telephone,@dateofbirth,@eidosaitimatos,@address,@datetime)";
                SQLiteCommand command = new SQLiteCommand(insertSQL, connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("surname", surname);
                command.Parameters.AddWithValue("email", email);
                command.Parameters.AddWithValue("telephone", telephone);
                command.Parameters.AddWithValue("dateofbirth", date_of_birth);
                command.Parameters.AddWithValue("eidosaitimatos", eidos_aitimatos);
                command.Parameters.AddWithValue("address", address);
                command.Parameters.AddWithValue("datetime", (DateTime.Now).ToString());
                command.ExecuteNonQuery();
                connection.Close();
            } catch (Exception exception) {
                MessageBox.Show("Exception caught: " + exception.Message);
            }
        }
    }
}
