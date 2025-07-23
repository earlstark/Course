using Microsoft.EntityFrameworkCore;

namespace Course.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string DbPath;

        public ApplicationDbContext(DbContextOptions options): base (options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
