using Microsoft.EntityFrameworkCore;

namespace Personal_Blog_Api.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
