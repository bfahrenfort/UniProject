// Connection to be used by ViewModels to populate lists

using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace UniProject.Utils
{
    public class DbConnection
    {
        private MySqlConnection dao;

        public DbConnection(string connString)
        {
            // Create a connection with the connection string
            dao = new MySqlConnection(connString);
        }

        public MySqlDataReader Query(string query)
        {
            // Create and execute a command from a query.
            // May be modified later to support direct parameter injection for security.
            MySqlCommand cmd = new MySqlCommand(query, dao);
            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        
        ~DbConnection()
        {
            dao.Close();
        }
    }
}