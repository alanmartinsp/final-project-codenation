using Api.Filters;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repositories
{
    public interface ILogRepository : IRepository<Log>
    {
        IEnumerable<Log> Get(LogFilter filter);
    }
}
