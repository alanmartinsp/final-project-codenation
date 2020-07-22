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
            List<string> parameters = new List<string>();

            if (!string.IsNullOrEmpty(filter.Enviroment.ToString()))
            {
                query += "AND Enviroment = ? ";
                parameters.Add(filter.Enviroment.ToString());
            }


            if (!string.IsNullOrEmpty(filter.Field))
            {
                query += $"AND {filter.Field} like ? ";
                parameters.Add($"%{filter.FieldDescription}%");
            }

            if (!string.IsNullOrEmpty(filter.OrderBy))
                query += $"ORDER BY {filter.OrderBy} DESC";

            return _context.Logs.FromSqlRaw(query, parameters.ToArray()).ToList();
        }
    }
}
