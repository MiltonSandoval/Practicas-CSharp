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
                DBSQL db = new DBSQL("LAPTOP-3MN70QT8", "CursoCsharp", "Milton", "123456");
                db.Open();

                db.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
