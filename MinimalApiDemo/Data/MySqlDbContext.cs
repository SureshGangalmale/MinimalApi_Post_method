using System.Data;
using MySql.Data.MySqlClient;

namespace MinimalApiDemo.Data
{
    public class MySqlDbContext
    {
        private readonly string _connectionString;

        public MySqlDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        public MySqlCommand CreateCommand(string spName, MySqlConnection conn)
        {
            var cmd = new MySqlCommand(spName, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            return cmd;
        }
    }
}
