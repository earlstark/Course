using Course.Data;
using Course.Dtos;
using Course.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Course.Services
{
    public class AccountService : IAccountService
    {

        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return null;
            }

            var hasher = new PasswordHasher<User>();
            var loginResult = hasher.VerifyHashedPassword(user, user.Password, loginDto.Password);

            if (loginResult == PasswordVerificationResult.Success)
            {
                return user;
            }

            return null;
        }
    }
}
