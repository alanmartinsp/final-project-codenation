using Business.Repositories;
using Database.Context;
using Database.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            DefinedScoped(services);

            services.AddDbContext<LocalContext>(options =>
                options.UseMySql("Server=127.0.0.1;Port=3306;Database=codenationlog;Uid=root;SslMode=None"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        private void DefinedScoped(IServiceCollection services)
        {
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
