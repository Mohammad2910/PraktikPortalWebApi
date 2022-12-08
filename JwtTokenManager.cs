using Microsoft.IdentityModel.Tokens;
using PraktikPortalWebApi.EfCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PraktikPortalWebApi.Models
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly DbHelper _dbHelper;

        public JwtTokenManager(IConfiguration configuration, EF_DataContext dataContext)
        {
            _configuration = configuration;
            _dbHelper = new DbHelper(dataContext);
        }
            
        public string Authenticate(string username, string password)
        {
            if (!_dbHelper.GetUsers().Any(x=> x.username.Equals(username) && x.password.Equals(password)))
            {
                return null;
            }

            var key = _configuration.GetValue<string>("JwtConfig:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
