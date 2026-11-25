using HelpDesk.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HelpDesk.Data
{
    public static class Database
    {
        private const string ConnectionString =
            @"Server=localhost\SQLEXPRESS;Database=HelpDesk_Muhamadeev;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
