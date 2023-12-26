using DrukarniaTests.SqlManager.Models;

namespace DrukarniaTests.SqlManager.Data
{
    public class DataReqest
    {
        public static CreatePostModel ColectAllDataForPost()
        {
            var postData = new CreatePostModel();
            try
            {
                Console.WriteLine("Enter Post name");
                postData.PostName = Console.ReadLine();

                Console.WriteLine("Enter Post text");
                postData.PostText = Console.ReadLine();

                Console.WriteLine("Enter type of file");
                postData.FileType = Console.ReadLine();

                Console.WriteLine("Enter path for text");
                string imagePath = Console.ReadLine();// "C:\\Users\\ronpo\\Downloads\\pawel-nolbert-4u2U8EO9OzY-unsplash.jpg";

                postData.Attachments = File.ReadAllBytes(imagePath);

                return postData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
