using Course.Data;

namespace Course.Services
{
    public interface ITokenService
    {

        public string CreateToken(User user);

    }
}
