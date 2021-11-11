using System.Data;
using MySqlConnector;

namespace UniProject.Utils
{
    public class DbConn
    {
        // To those of you wondering how to use this:
        // Format your base query string with @1, @2, etc standing in for each parameter.
        // Pass that and what you want to replace each stand-in with, in order. 
        // See SchoolViewModel.cs for a sample usage.
        public static DataTable query(string query, params object[] args)
        {
            DataTable dt = new DataTable();
            int count = 1;
            
            // Create command
            var cmd = new MySqlCommand();
            cmd.CommandText = query;
            foreach(object item in args)
            {
                // Populate the placeholders in the query to mitigate the risk of SQL injection
                cmd.Parameters.AddWithValue("@" + count, item);
                count++;
            }

            // Connect to database and execute command
            using (var dbConn = new MySqlConnection(Utilities.UniConnString))
            {
                dbConn.Open();
                cmd.Connection = dbConn;
                using (var result = cmd.ExecuteReader())
                {
                    dt.Load(result);
                }
            }

            return dt;
        }
    }
}
