using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Data
{
    internal class Conexión
    {
        private readonly string _connectionString;

        public Conexión(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<SqlConnection> AbrirConexiónAsync()
        {     
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }

        public async Task CerrarConexiónAsync(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }
}
