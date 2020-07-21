using Api.Filters;
using Business.Models;
using Business.Repositories;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Repositories
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(LocalContext context) : base(context)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Log Get(int id)
        {
            return _context.Logs.Where(x => x.Id == id)
                           .Include(x => x.User)
                           .AsNoTracking()
                           .FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<Log> Get(LogFilter filter)
        {
            string query = "SELECT * FROM Logs WHERE 1 = 1 ";
            var user = new SqlParameter("user", "johndoe");

            if (!string.IsNullOrEmpty(filter.Enviroment.ToString()))
            {
                query += "AND Enviroment = @enviroment";
                parameters.Add(new SqlParameter("@enviroment", filter.Enviroment));
            }


            if (!string.IsNullOrEmpty(filter.Filter))
            {
                query += $"AND {filter.Filter} = @filter";
                parameters.Add(new SqlParameter("@filter", filter.FilterDescription));
            }

            if (!string.IsNullOrEmpty(filter.OrderBy))
                query += $"ORDER BY {filter.OrderBy}";

            return _context.Logs.FromSqlRaw(query, parameters.ToArray()).ToList();
        }
    }
}
