using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db;

namespace DB_Conection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BeerDB db = new BeerDB("LAPTOP-3MN70QT8", "CursoCsharp", "Milton", "123456");

                List<Beer> Cervezas = db.GetAll();

                foreach (var cerveza in Cervezas)
                {
                    Console.WriteLine(cerveza.MarcaId);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
