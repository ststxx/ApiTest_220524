using ApiTest.Repositories.Interfaces;
using ApiTest.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiTest.Services.Implements
{
    public class JwtAuthService : AuthService
    {
        UserRepository _userRepository;
        string _salt;
        int _tokenExpireSeconds;
        string _tokenResponseHeader;
        public JwtAuthService(UserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _salt = config.GetSection("tokens").GetValue<string>("salt");
            _tokenExpireSeconds = config.GetSection("tokens").GetValue<int>("expire_seconds");
            _tokenResponseHeader = config.GetSection("tokens").GetValue<string>("token_response_header");
        }

        public string Login(string name, string password, HttpContext httpContext)
        {
            var user = _userRepository.FindByName(name);
            if (user == null)
                throw new Exception("name not exist...");
            if (user.Password != password)
                throw new Exception("password wrong...");
            var token = CreateToken(name);
            httpContext.Response.Headers.Add(_tokenResponseHeader, token);
            return token;
        }

        private string CreateToken(string name)
        {
            var key = Encoding.ASCII.GetBytes(_salt);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, name));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(_tokenExpireSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
