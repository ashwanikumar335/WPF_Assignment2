using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WPF_Assignment2.GenericMessages;
using System.Data.Common;
using System.Configuration;

namespace WPF_Assignment2.Model
{
    public class DatabaseConnection
    {
        public static string CS = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public static int ExecuteNonQuery(SqlCommand command) =>
            ExecuteCommand(command, cmd => cmd.ExecuteNonQuery());

        public static string ExecuteScalar(SqlCommand command) =>
            ExecuteCommand(command, cmd => cmd.ExecuteScalar().ToString());

        public static DataTable GetDataTable(SqlCommand command) =>
            ExecuteCommand(command, cmd =>
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            });
        private static T ExecuteCommand<T>(SqlCommand command, Func<SqlCommand, T> resultRetriever)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CS))
                {
                    command.Connection = connection;
                    command.Connection.Open();

                    return resultRetriever(command);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

        }
        private static SqlCommand CheckIfSqlCommand(DbCommand command)
        {
            SqlCommand sqlCommand = command as SqlCommand;
            if (sqlCommand == null)
                throw new ArgumentException("Invalid command format");
            return sqlCommand;
        }
    }

    public static class IEnumerableHelper
    {
        public static IEnumerable<T> ToEnumerable<T>(params T[] parameters)
        {
            return parameters;
        }
    }
}
