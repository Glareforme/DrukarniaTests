using System.Data.SqlClient;

namespace DrukarniaTests.Helpers
{
    internal class DatabaseController
    {
        private static readonly SqlConnection DbConnection =
            new SqlConnection(ConfiguratorHelper.GetSqlSectionModel().ConnectionString);

        public DatabaseController()
        {
            DbConnection.Open();
        }

        public static void CloseConnection()
        {
            DbConnection.Close();
        }
    }
}
