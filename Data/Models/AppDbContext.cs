using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Date> Dates { get; set; }
    }
}
