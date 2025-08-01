using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Course.Data
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public required string Email { get; set; }

        public required string Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Role { get; set; }

        public ICollection<Course> Courses { get; set; } = [];
        public ICollection<Course> AuthoredCourses { get; set; } = new List<Course>();

    }
}
