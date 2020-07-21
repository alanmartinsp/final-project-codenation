using Business.Repositories;
using Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.AppConfig
{
    public class RepositoriesConfig
    {
        protected IServiceCollection _services;
        public RepositoriesConfig(ref IServiceCollection services)
        {
            _services = services;
        }

        public void AddRepositoriesOnStartup()
        {
            _services.AddScoped<ILogRepository, LogRepository>();
            _services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
