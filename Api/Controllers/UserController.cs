using System;
using System.Collections.Generic;
using System.Linq;
using Api.Request;
using Business.Models;
using Business.Repositories;
using Business.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserController : GenericController
    {
        private UserService _userService;

        public UserController(IUserRepository userRepository)
        {
            _userService = new UserService(userRepository);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] UserRequest request)
        {
            ValidationResult result = (new UserValidator()).Validate(request);
            if (!result.IsValid)
            {
                var erros = result.Errors.ToList().Select(x => new { Key = x.PropertyName, Error = x.ErrorMessage }).ToList();
                return BadRequest(erros);
            }

            User user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };

            _userService.Save(user);
            return Ok();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll().ToList());
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }
    }
}
