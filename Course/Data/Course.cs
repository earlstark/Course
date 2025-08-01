using System.ComponentModel.DataAnnotations.Schema;

namespace Course.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<User> Users { get; set; } = [];
        public int AuthorId { get; set; }
        public User Author { get; set; } = default!;

    }
}
