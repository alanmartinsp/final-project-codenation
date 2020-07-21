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
    public class LogController : GenericController
    {

        private LogValidator _logValidator;
        private LogService _logService;

        public LogController(ILogRepository logRepository)
        {
            _logValidator = new LogValidator();
            _logService = new LogService(logRepository);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public void Post([FromBody] Log request)
        {
            ValidationResult result = _logValidator.Validate(request);
            if (!result.IsValid)
                throw new Exception(result.ToString());

            _logService.Save(request);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Log>> Get()
        {
            return _logService.GetAll().ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Log> Get(int id)
        {
            return _logService.Get(id);
        }
    }
}
