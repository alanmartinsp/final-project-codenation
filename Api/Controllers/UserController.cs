using System;
using System.Collections.Generic;
using System.Linq;
using Api.Request;
using Business.Models;
using Business.Repositories;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private LogValidator _logValidator;
        private UserService _logService;

        public UserController(IUserRepository logRepository)
        {
            _logValidator = new LogValidator();
            _logService = new UserService(logRepository);
        }

    }
}
