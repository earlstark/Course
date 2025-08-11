using System.Security.Claims;
using Course.Data;
using Course.Dtos;
using Course.Repositories;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Course.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task CreateAsync(UserDto data)
        {
            return _userRepository.CreateAsync(MapToModel(data));
        }

        public Task<bool> DeleteAsync(int id)
            => _userRepository.DeleteAsync(id);

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            
            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return user != null ? MapToDto(user) : null;
        }

        public async Task<UserDto?> UpdateAsync(int id, UserDto data)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user != null)
            {
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;

                await _userRepository.UpdateAsync();
            }

            return user != null ? MapToDto(user) : null;
        }

        public async Task<UserDto?> GetCurrentUserAsync()
        {
            var userId = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return null;
            }

            var user = await GetByIdAsync(int.Parse(userId));

            return user;
        }

        private static UserDto MapToDto(User user) => new()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password,
        };

        private static User MapToModel(UserDto userDto) => new()
        {
            Id = userDto.Id,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Password = new PasswordHasher<User>().HashPassword(null, userDto.Password),
        };

    }
}
