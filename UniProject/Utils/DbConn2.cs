using System;
using System.Data;
using System.Net.NetworkInformation;
using MySqlConnector;

namespace UniProject.Utils
{
    public class DbConn2
    {
        // To those of you wondering how to use this:
        // Format your base query string with @1, @2, etc standing in for each parameter.
        // Pass that and what you want to replace each stand-in with, in order. 
        // See SchoolViewModel.cs for a sample usage.
        public static DataTable Query(string query, params object[] args)
        {
            DataTable dt = new DataTable();
            int count = 1;
            
            // Create command
            var cmd = new MySqlCommand();
            cmd.CommandText = query;
            foreach(object item in args)
            {
                cmd.Parameters.AddWithValue("@" + count, item); // To mitigate the risk of SQL injection
                count++;
            }

            // Connect to database and execute command
            using (var dbConn2 = new MySqlConnection(Utilities.UserConnString))
            {
                dbConn2.Open();
                cmd.Connection = dbConn2;
                using (var result = cmd.ExecuteReader())
                {
                    dt.Load(result);
                }
            }

            return dt;
        }

        public static object Addquery(string query, params object[] args)
        {
            int count = 1;
            // Create command
            var cmd = new MySqlCommand();
            cmd.CommandText = query;
            foreach (object item in args)
            {
                cmd.Parameters.AddWithValue("@" + count, item); // To mitigate the risk of SQL injection
                count++;
            }

            // Connect to database and execute command
            using (var dbConn2 = new MySqlConnection(Utilities.UserConnString))
            {
                dbConn2.Open();
                cmd.Connection = dbConn2;
                return "added";
            }
        }

        public static object QueryScalar(string query, params object[] args)
        {
            int count = 1;
            
            // Create command
            var cmd = new MySqlCommand();
            cmd.CommandText = query;
            foreach(object item in args)
            {
                cmd.Parameters.AddWithValue("@" + count, item); // To mitigate the risk of SQL injection
                count++;
            }
            
            // Connect to database and execute command
            using (var dbConn2 = new MySqlConnection(Utilities.UserConnString))
            {
                dbConn2.Open();
                cmd.Connection = dbConn2;
                var result = cmd.ExecuteScalar();
                return result;
            }
        }
    }
}