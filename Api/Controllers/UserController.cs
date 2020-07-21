using System;
using System.Collections.Generic;
using System.Linq;
using Api.Request;
using Business.Models;
using Business.Repositories;
using Business.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController
    {

        private UserValidator _userValidator;
        private UserService _userService;

        public UserController(IUserRepository userRepository)
        {
            _userValidator = new UserValidator();
            _userService = new UserService(userRepository);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public void Post([FromBody] User request)
        {
            ValidationResult result = _userValidator.Validate(request);
            if (!result.IsValid)
                throw new Exception(result.ToString());

            _userService.Save(request);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.GetAll().ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Ok(_userService.Get(id));
        }
    }
}
