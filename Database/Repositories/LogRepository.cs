using Business.Models;
using Business.Repositories;
using Database.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Repositories
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(LocalContext context) : base(context)
        {
        }
    }
}
