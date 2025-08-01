using Course.Data;

namespace Course.Repositories
{
    public interface ICourseRepository
    {

        Task CreateAsync(Course.Data.Course data);
        Task<bool> DeleteAsync(int id);
        Task<List<Course.Data.Course>> GetAllAsync();
        Task<Course.Data.Course?> GetByIdAsync(int id);
        public Task<int> UpdateAsync();

    }
}
