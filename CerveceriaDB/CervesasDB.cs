using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerveceriaDB
{
    class CervesasDB : ConnectionDB
    {
        public CervesasDB(string Server, string Db, string User, string Password) : base(Server, Db, User, Password)
        {
        }
        public List<Cervesas> ListBeer()
        {
            Conectar();
            List<Cervesas> Beers = new List<Cervesas>();
            string query = "Select * from Beer;";
            SqlCommand Comando = new SqlCommand(query,_Connection);
            SqlDataReader reader = Comando.ExecuteReader();
            while (reader.Read())
            {
                int Id = reader.GetInt32(0);
                string Name = reader.GetString(1);
                int MarcaId = reader.GetInt32(2);
                Beers.Add(new Cervesas(Id, Name, MarcaId));
            }
            Desconectar();
            return Beers;

        }

        public void AddBeer(Cervesas Beer)
        {
            Conectar();
            string query = "insert into Beer(name, BrandID) values(@name,@marcaid);";
            SqlCommand Comando = new SqlCommand(query, _Connection);
            Comando.Parameters.AddWithValue("name", Beer.Name);
            Comando.Parameters.AddWithValue("marcaid", Beer.MarcaId);

            Comando.ExecuteNonQuery();

            Desconectar();
        }
    }
}
