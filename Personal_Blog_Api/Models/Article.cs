namespace Personal_Blog_Api.Models
{
    public class Article
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }

    }
}
