using Course.Data;
using Microsoft.EntityFrameworkCore;

namespace Course.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Course.Data.Course>> GetAllAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public Task<Course.Data.Course?> GetByIdAsync(int id)
        {
            return _context.Courses.FirstOrDefaultAsync(course => course.Id == id);
        }

        public async Task CreateAsync(Course.Data.Course data)
        {
            await _context.Courses.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public Task<int> UpdateAsync()
            => _context.SaveChangesAsync();

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(user => user.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
