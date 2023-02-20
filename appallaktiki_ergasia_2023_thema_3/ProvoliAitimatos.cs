using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appallaktiki_ergasia_2023_thema_3
{
    internal class ProvoliAitimatos
    {
        protected string eidos_provolis;
        protected string citizens_surname, citizens_telephone;
        protected string eidos_aitimatos;

        String connectionString = "Data source=kep.db;Version=3";
        SQLiteConnection connection;

        public ProvoliAitimatos() 
        {
        
        }

        public ProvoliAitimatos(string eidos_provolis)
        {
            this.eidos_provolis = eidos_provolis;

            connection = new SQLiteConnection(connectionString);
        }

        public ProvoliAitimatos(string eidos_provolis, string citizens_surname, string citizens_telephone)
        {
            this.eidos_provolis = eidos_provolis;
            this.citizens_surname = citizens_surname;
            this.citizens_telephone= citizens_telephone;

            connection = new SQLiteConnection(connectionString);
        }

        public ProvoliAitimatos(string eidos_provolis, string citizens_surname, string citizens_telephone, string eidos_aitimatos)
        {
            this.eidos_provolis = eidos_provolis;
            this.citizens_surname = citizens_surname;
            this.citizens_telephone = citizens_telephone;
            this.eidos_aitimatos =  eidos_aitimatos;

            connection = new SQLiteConnection(connectionString);
        }

        public string Provoli()
        {
            string result = "";

            if (eidos_provolis == "Provoli Olwn")
            {
                int i = 0;

                connection.Open();
                String selectSQL = "Select * from Kep";
                SQLiteCommand command = new SQLiteCommand(selectSQL, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                    result += i + ") " + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetString(3) + ", " + reader.GetString(4) + ", " + reader.GetString(5) + ", " + reader.GetString(6) + ", " + reader.GetString(7) + ", " + reader.GetString(8) + "\r\n\r\n";
                }
                connection.Close();
            }
            else if (eidos_provolis == "Provoli Aitimatos Politi") 
            {
                int i = 0;

                connection.Open();
                String selectSQL = "Select * from Kep where Surname=@surname and Telephone=@telephone";
                SQLiteCommand command = new SQLiteCommand(selectSQL, connection);
                command.Parameters.AddWithValue("surname", citizens_surname);
                command.Parameters.AddWithValue("telephone", citizens_telephone);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                    result += i + ") " + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetString(3) + ", " + reader.GetString(4) + ", " + reader.GetString(5) + ", " + reader.GetString(6) + ", " + reader.GetString(7) + ", " + reader.GetString(8) + "\r\n\r\n";
                }
                connection.Close();
            }

            if (result == "" && eidos_provolis == "Provoli Olwn")
            {
                result = "Δεν υπάρχουν καταχωρημένα αιτήματα!";
            }
            else if (result == "" && eidos_provolis == "Provoli Aitimatos Politi")
            {
                result = "Δεν υπάρχουν καταχωρημένα αιτήματα με τα στοιχεία που εκχωρήσατε!";
            }

            return result;
        }

        public string Anazitisi()
        {
            string result = "Βρέθηκε Αίτημα με τα στοιχεία που εκχωρήσατε:";

            connection.Open();
            String selectSQL = "Select * from Kep where Surname=@surname and Telephone=@telephone and EidosAitimatos=@eidos_aitimatos";
            SQLiteCommand command = new SQLiteCommand(selectSQL, connection);
            command.Parameters.AddWithValue("surname", citizens_surname);
            command.Parameters.AddWithValue("telephone", citizens_telephone);
            command.Parameters.AddWithValue("eidos_aitimatos", eidos_aitimatos);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += "\r\n" + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetString(3) + ", " + reader.GetString(4) + ", " + reader.GetString(5) + ", " + reader.GetString(6) + ", " + reader.GetString(7) + ", " + reader.GetString(8) + "\r\n";
            }
            connection.Close();

            if (result == "Βρέθηκε Αίτημα με τα στοιχεία που εκχωρήσατε:")
            {
                result = "Δεν βρέθηκε αναζήτηση με τα στοιχεία που εκχωρήσατε!";
            }

            return result;
        }

    }
}
