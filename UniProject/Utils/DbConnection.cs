// Class for future mysql integration to be used by ViewModels to populate lists
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
            dao = new MySqlConnection(connString);
        }

        public MySqlDataReader Query(string query)
        {
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