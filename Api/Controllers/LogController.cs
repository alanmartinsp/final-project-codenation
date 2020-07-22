using System;
using System.Collections.Generic;
using System.Linq;
using Api.Filters;
using Api.Request;
using Business.Models;
using Business.Repositories;
using Business.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class LogController : GenericController
    {

        private LogService _logService;

        public LogController(ILogRepository logRepository)
        {
            _logService = new LogService(logRepository);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public IActionResult Post([FromBody] Log request)
        {
            ValidationResult result = (new LogValidator()).Validate(request);
            if (!result.IsValid)
            {
                var erros = result.Errors.ToList().Select(x => new { Key = x.PropertyName, Error = x.ErrorMessage }).ToList();
                return BadRequest(erros);
            }

            request.UserId = int.Parse(User.Claims.Where(x => x.Type == "userId").FirstOrDefault().Value);
            _logService.Save(request);
            return Ok();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Log> Get(int id)
        {
            return Ok(_logService.Get(id));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery]LogFilter filter = null)
        {
            if (filter != null)
                return Ok(_logService.Get(filter));

            return Ok(_logService.GetAll());
        }
    }
}
