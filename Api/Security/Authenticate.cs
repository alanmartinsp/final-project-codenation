using Business.Models;
using Business.Repositories;
using Business.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Security
{
    public class Authenticate
    {

        protected AuthService _authService;

        public Authenticate(IUserRepository userRepository)
        {
            _authService = new AuthService(userRepository);
        }

        /// <summary>
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public object Auth(string login, string password)
        {
            User user = _authService.Auth(login, password);
            if (user == null)
                throw new Exception("User not found");

            var token = GenerateToken(user);
            return new
            {
                token = token,
                user = new { Name = user.Name, Email = user.Email }
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("xecretKeywqejane");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
