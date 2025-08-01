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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Author)
                .WithMany(u => u.AuthoredCourses)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Users)
                .WithMany(u => u.Courses);
        }
    }
}
