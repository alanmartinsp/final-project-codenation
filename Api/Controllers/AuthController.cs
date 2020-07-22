using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using Api.Request;
using Api.Security;
using Business.Models;
using Business.Repositories;
using Business.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class AuthController : GenericController
    {

        private readonly IConfiguration _configuration;
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly UserService _userService;

        public AuthController(IConfiguration configuration,
                              IUserRepository userRepository,
                              TokenConfiguration tokenConfiguration)
        {
            _configuration = configuration;
            _tokenConfiguration = tokenConfiguration;
            _userService = new UserService(userRepository);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public IActionResult Auth([FromBody] AuthRequest request)
        {
            ValidationResult result = (new AuthValidator()).Validate(request);
            if (!result.IsValid)
            {
                var erros = result.Errors.ToList().Select(x => new { Key = x.PropertyName, Error = x.ErrorMessage }).ToList();
                return BadRequest(erros);
            }

            User user = _userService.Auth(request.Email, request.Password);
            if (user == null)
                return Forbid();

            return GenerateToken(user);
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private OkObjectResult GenerateToken(User user)
        {
            var claims = new[]
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("userEmail", user.Email),
                    new Claim("userName", user.Name)
                };


            var key = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: _tokenConfiguration.Issuer,
                    audience: _tokenConfiguration.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(_tokenConfiguration.Seconds),
                    signingCredentials: creds
                );

            return Ok(new 
            { 
                token = new JwtSecurityTokenHandler().WriteToken(token), 
                user = new { Name = user.Name, Email = user.Email } 
            });
        }
    }
}
