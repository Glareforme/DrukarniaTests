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

        public static void InsertPostSQL(CreatePostModel postData)
        {
            dbConnection.Open();
            using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[PostContent] (PostName, PostText, FileType, Attachments) VALUES (@PostName, @PostText, @FileType, @Attachments)", dbConnection))
            {
                command.Parameters.AddWithValue("@PostName", postData.PostName);
                command.Parameters.AddWithValue("@PostText", postData.PostText);
                command.Parameters.AddWithValue("@FileType", postData.FileType);
                command.Parameters.AddWithValue("@Attachments", postData.Attachments);

                // Execute the command
                command.ExecuteNonQuery();
            }
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

