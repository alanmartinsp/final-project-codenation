using Api.Filters;
using Business.Models;
using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class LogService : GenericService<Log>
    {
        public LogService(ILogRepository repository) : base(repository)
        {
        }

        public IEnumerable<Log> Get(LogFilter filter)
        {
            return (_repository as ILogRepository).Get(filter);
        }
    }
}
