using Course.Dtos;

namespace Course.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserDto data);
        Task<bool> DeleteAsync(int id);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> UpdateAsync(int id, UserDto data);
    }
}
