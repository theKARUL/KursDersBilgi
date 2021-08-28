using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace EdukeyLearning.Model
{
    class Kurs
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Detay { get; set; }
        public string Sure { get; set; }
        public string Egitmen { get; set; }

        MySqlConnection _baglan = new MySqlConnection("Server=localhost;Database=edukey;Uid=root;Pwd='134679onc'");

        public void Connect()
        {
            if (_baglan.State == ConnectionState.Closed)
            {
                _baglan.Open();
            }
        }

        public List<Kurs> Get()
        {
            Connect();
            MySqlCommand command = new MySqlCommand("Select * From Kurs order by Id DESC", _baglan);
            MySqlDataReader reader = command.ExecuteReader();

            List<Kurs> kurslar = new List<Kurs>();
            while (reader.Read())
            {
                Kurs kurs = new Kurs();

                kurs.Id = Convert.ToInt32(reader["Id"]);
                kurs.Ad = Convert.ToString(reader["Ad"]);
                kurs.Detay = Convert.ToString(reader["Detay"]);
                kurs.Sure = Convert.ToString(reader["Sure"]);
                kurs.Egitmen = Convert.ToString(reader["Egitmen"]);

                kurslar.Add(kurs); // Listeye Ekleme
            }

            reader.Close();
            _baglan.Close();

            return kurslar;


        }

        public List<Kurs> Get(string arama)
        {
            Connect();
            MySqlCommand command = new MySqlCommand("Select * From Kurs where Ad like '%" + @arama + "%' order by Id DESC", _baglan);
            MySqlDataReader reader = command.ExecuteReader();

            command.Parameters.AddWithValue("@arama", arama);

            List<Kurs> kurslar = new List<Kurs>();
            while (reader.Read())
            {
                Kurs kurs = new Kurs();

                kurs.Id = Convert.ToInt32(reader["Id"]);
                kurs.Ad = Convert.ToString(reader["Ad"]);
                kurs.Detay = Convert.ToString(reader["Detay"]);
                kurs.Sure = Convert.ToString(reader["Sure"]);
                kurs.Egitmen = Convert.ToString(reader["Egitmen"]);

                kurslar.Add(kurs); // Listeye Ekleme
            }

            reader.Close();
            _baglan.Close();

            return kurslar;


        }

        public void Kaydet(Kurs Model)
        {
            Connect();
            MySqlCommand command = new MySqlCommand("Insert Into Kurs values(@Ad,@Detay,@Sure,@Egitmen)", _baglan);

            command.Parameters.AddWithValue("@ad", Model.Ad);
            command.Parameters.AddWithValue("@Detay", Model.Detay);
            command.Parameters.AddWithValue("@Sure", Model.Sure);
            command.Parameters.AddWithValue("@Egitmen", Model.Egitmen);

            command.ExecuteNonQuery();

            _baglan.Close();

        }

        public void Guncelle(Kurs Model)
        {
            Connect();
            MySqlCommand command = new MySqlCommand("Update Kurs set Ad=@ad, Detay=@Detay, Sure=@Sure, Egitmen=@Egitmen where Id=@Id", _baglan);

            command.Parameters.AddWithValue("@ad", Model.Ad);
            command.Parameters.AddWithValue("@Detay", Model.Detay);
            command.Parameters.AddWithValue("@Sure", Model.Sure);
            command.Parameters.AddWithValue("@Egitmen", Model.Egitmen);
            command.Parameters.AddWithValue("@Id", Model.Id);


            command.ExecuteNonQuery();

            _baglan.Close();

        }

        public void Sil(Kurs Model)
        {
            Connect();
            MySqlCommand command = new MySqlCommand("Delete from Kurs where Id=@Id", _baglan);

            command.Parameters.AddWithValue("@Id", Model.Id);


            command.ExecuteNonQuery();

            _baglan.Close();

        }


    }
}
