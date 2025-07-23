using Course.Data;
using Course.Dtos;

namespace Course.Services
{
    public interface IAccountService
    {

        Task<User?> LoginAsync(LoginDto loginDto);

    }
}
