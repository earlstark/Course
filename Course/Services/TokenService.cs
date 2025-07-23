using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Course.Data;
using Course.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Course.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;

        public TokenService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value; 
        }

        public string CreateToken(User user)
        {

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.Role, user.Role ?? string.Empty)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentinals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.Add(new TimeSpan(0, 30, 0));

            var tokenDescriptor = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Issuer,
                claims,
                expires: expires,
                signingCredentials: credentinals
            
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
    }
}
