using System.ComponentModel.DataAnnotations;
using Course.Data;

namespace Course.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        
        [Required]
        public int AuthorId { get; set; }
    }
}
