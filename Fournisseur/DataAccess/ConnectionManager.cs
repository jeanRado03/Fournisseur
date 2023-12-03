using Npgsql;
using System;
using System.Data;
namespace Fournisseur.DataAccess
{
    public class ConnectionManager
    {
        private string connectionString;
        private NpgsqlConnection _connection;

        public ConnectionManager(string database)
        {
            connectionString = $"Server=localhost;Username=postgres;Password=1413;Database={database};";
            _connection = new NpgsqlConnection(connectionString);
        }

        public NpgsqlConnection OpenConnection()
        {
            if(_connection.State == ConnectionState.Closed) { _connection.Open(); }
            return _connection;
        }

        public void CloseConnection()
        {
            if(_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
