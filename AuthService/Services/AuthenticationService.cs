using AuthService.Entities;
using AuthService.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public class AuthenticationService
    {
        private readonly IUsers _users;
        private readonly AppSettings _appSettings;

        public AuthenticationService(IUsers users, IOptions<AppSettings> appSettings)
        {
            _users = users;
            _appSettings = appSettings.Value;
        }

        public string Authenticate(string login, string pwd)
        {
            var user = _users.FindByLogin(login);

            if (user == null)
                return null;

            if (!user.PasswordMatches(pwd))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("sub", user.Login),
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, "SALESMAN"),
                    new Claim(ClaimTypes.Role, "USER"),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim("avatar", user.Avatar),
                    new Claim("userType", "SALESMAN"),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Users GetUserFromLogin(string login)
        {
            return _users.FindByLogin(login);
        }
    }
}
