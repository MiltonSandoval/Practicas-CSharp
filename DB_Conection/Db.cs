
using System.Data.SqlClient;

namespace Db
{
    public class DBSQL 
    {
        private string _ConnectionString;
        protected SqlConnection _Connection;

        public DBSQL(string Server, string Db, string User, string Password)
        {
            _ConnectionString = $"Data Source={Server}; Initial Catalog={Db};" +
                $"User={User}; Password={Password}";
        }

        public void Open()
        {
            _Connection = new SqlConnection(_ConnectionString);
            _Connection.Open();
        }

        public void Close()
        {
            if (_Connection != null && _Connection.State == System.Data.ConnectionState.Open) 
            _Connection.Close();
        }
    }
}