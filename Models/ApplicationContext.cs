using Microsoft.EntityFrameworkCore;

namespace LinkApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Link> Links { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
