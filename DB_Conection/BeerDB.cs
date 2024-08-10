using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db;

namespace DB_Conection
{
    public class BeerDB : DBSQL
    {
        public BeerDB(string Server, string Db, string User, string Password) : base(Server, Db, User, Password)
        {

        }

        public List<Beer> GetAll() 
        {
            Open();
            string Query = "Select * from Beer";
            List<Beer> beers = new List<Beer>();

            SqlCommand sqlcomando = new SqlCommand(Query, _Connection);

            SqlDataReader reader = sqlcomando.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int MarcaId = reader.GetInt32(2);
                
                beers.Add(new Beer(id,name, MarcaId));
            }
            Close();
            return beers;

            
        }

    }
}
