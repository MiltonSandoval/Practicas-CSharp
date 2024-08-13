using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerveceriaDB
{
    abstract class ConnectionDB
    {
        private string _connectionString;
        protected SqlConnection _Connection;

        public ConnectionDB(string Server, string Db, string User, string Password)
        {
            _connectionString = $"Data Source={Server};Initial Catalog={Db};" +
                $"User={User}; Password={Password}";
        }

        public void Conectar()
        {
            _Connection = new SqlConnection(_connectionString);
            _Connection.Open();
        }

        public void Desconectar()
        {
            if( _Connection != null && _Connection.State == System.Data.ConnectionState.Open)
            {
                _Connection.Close();
            }
        }
    }
}
