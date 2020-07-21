using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.Request;
using Api.Security;
using Business.Models;
using Business.Repositories;
using Business.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : GenericController
    {

        private Authenticate _authenticate;

        public AuthController(IUserRepository userRepository)
        {
            _authenticate = new Authenticate(userRepository);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public IActionResult Auth([FromBody] User request)
        {
            try
            {
                object userAuth = _authenticate.Auth(request.Email, request.Password);
                return Ok(userAuth);
            }
            catch (Exception e)
            {
                ObjectResult obj = new ObjectResult(e.Message)
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };

                return obj;
            }
        }
    }
}
