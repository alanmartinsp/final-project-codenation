using Api.Filters;
using Business.Extensions;
using Business.Models;
using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Business.Models.Log;

namespace Tests.Repositories
{
    public class LogRepository : ILogRepository
    {
        protected List<Log> _logs = new List<Log>();

        public LogRepository() {
        }

        public LogRepository(List<Log> logs) {
            _logs = logs;
        }

        public void Delete(Log log)
        {
            _logs.Remove(log);
        }

        public void Dispose()
        {
        }

        public Log Get(int id)
        {
            return _logs.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Log> Get(LogFilter filter)
        {
            var query = _logs.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Enviroment.ToString()))
                query = query.Where(x => x.Enviroment == (TypeEnviroment)filter.Enviroment).AsQueryable();

            if (!string.IsNullOrEmpty(filter.Field))
            {
                if (filter.Field == "level")
                    query = query.Where(x => x.Level == filter.FieldDescription.ToEnum<Log.Type>()).AsQueryable();
                else if (filter.Field == "title")
                    query = query.Where(x => x.Title.Contains(filter.FieldDescription)).AsQueryable();
                else
                    query = query.Where(x => x.Origin.Contains(filter.FieldDescription)).AsQueryable();
            }

            if (!string.IsNullOrEmpty(filter.OrderBy))
                query = query.Where(x => x.Level == filter.OrderBy.ToEnum<Log.Type>());

            return query.ToList();
        }

        public IEnumerable<Log> GetAll()
        {
            return _logs.ToList();
        }

        public void Save(Log entity)
        {
            _logs.Add(entity);
        }

        public void Update(Log entity)
        {
        }
    }
}
