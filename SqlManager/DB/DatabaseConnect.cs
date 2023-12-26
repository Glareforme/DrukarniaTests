using Dapper;
using DrukarniaTests.SqlManager.Models;
using SqlDataManager.DB.Queries;
using System.Data.SqlClient;

namespace DrukarniaTests.SqlManager.DB
{
    internal class DatabaseConnect
    {
        private static readonly SqlConnection dbConnection =
           new SqlConnection(Configuration.GetSqlModel().DBConString);

        public DatabaseConnect()
        {
            dbConnection.Open();
        }

        public static void InsertPost(CreatePostModel postData)
        {
            dbConnection.Query(Queries.InsertPost, new
            {
                postData.PostName,
                postData.PostText,
                postData.FileType,
                postData.Attachments
            }
                );
            CloseConnection();
        }

        /*     public static void SelectPost()
             {
                 dbConnection
             }
     */
        public static void CleanUpTable()
        {
            dbConnection.Query(Queries.CleanTable);
        }

        public static void CloseConnection()
        {
            dbConnection.Close();
        }
    }
}
