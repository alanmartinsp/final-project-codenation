using Api.AppConfig;
using Business.Repositories;
using Database.Context;
using Database.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Api
{
    public class Startup
    {
        private RepositoriesConfig _repositoriesConfig;
        private AuthConfig _authConfig;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            // DatabaseConfig
            services.AddDbContext<LocalContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("Database")));

            // Repositories
            _repositoriesConfig = new RepositoriesConfig(ref services);
            _repositoriesConfig.AddRepositoriesOnStartup();

            // Authentication
            _authConfig = new AuthConfig(ref services, Configuration);
            _authConfig.AddAuthOnStartup();

            // Swagger
            services.AddSwaggerGen(x => x.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "CodenationLog", Version = "v1" }));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("AllowAllOrigins");

            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Log"));

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
