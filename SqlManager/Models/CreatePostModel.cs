namespace DrukarniaTests.SqlManager.Models
{
    public class CreatePostModel
    {
        public string PostName { get; set; }

        public string PostText { get; set; }

        public string FileType { get; set; }

        public byte[] Attachments { get; set; }
    }
}
