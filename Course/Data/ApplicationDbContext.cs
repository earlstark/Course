using Microsoft.EntityFrameworkCore;

namespace Course.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string DbPath;

        public ApplicationDbContext()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DbPath = Path.Combine(path, "course_db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            =>  optionsBuilder.UseSqlite($"Data Source={DbPath}");

        public DbSet<User> Users { get; set; }

    }
}
