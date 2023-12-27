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

        public static CreatePostModel SelectPost()
        {
            string sqlCommand = Queries.SelectPostContent;
            var respModel = new CreatePostModel();

            using (SqlCommand command = new SqlCommand(sqlCommand, dbConnection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    respModel.PostName = reader["PostName"].ToString();
                    respModel.PostText = reader["PostText"].ToString();
                    respModel.FileType = reader["FileType"].ToString();
                    respModel.Attachments = (byte[])reader["Attachments"];
                }
            }

            CloseConnection();
            return respModel;
        }

        public static void CleanUpTable()
        {
            dbConnection.Query(Queries.CleanTable);
            CloseConnection();
        }

        private static void CloseConnection()
        {
            dbConnection.Close();
        }
    }
}

