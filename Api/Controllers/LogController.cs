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
    public class LogController : ControllerBase
    {

        private LogValidator _logValidator;
        private LogService _logService;

        public LogController(ILogRepository logRepository)
        {
            _logValidator = new LogValidator();
            _logService = new LogService(logRepository);
        }

        [HttpPost]
        public void Post([FromBody] Log request)
        {
            ValidationResult result = _logValidator.Validate(request);
            if (!result.IsValid)
                throw new Exception(result.ToString());

            _logService.Save(request);
        }

        [HttpPost]
        [Route("{id}")]
        public void Put(string id, [FromBody] Log request)
        {
            try
            {
            }
            catch (Exception e)
            {
            }
        }

        [HttpGet]
        public ActionResult<List<Log>> Get()
        {
            return _logService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Log> Get(string hash)
        {
            return Ok(_logService.Get(hash));
        }
    }
}
