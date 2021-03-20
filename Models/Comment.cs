using System;
namespace MyShop.Models
{
    public class Comment
    {
        public string Letter { get; set; }
        public int Id { get; set; }
        public string NameUser { get; set; }
        public DateTime CommentDate { get; private set; }
        public Comment()
        {
            CommentDate = DateTime.UtcNow;
        }
    }
}
