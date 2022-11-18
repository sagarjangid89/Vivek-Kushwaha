using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Tiko_Business.Abstract.Dapper;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_Business.Concrete.Dapper;
using Tiko_Business.Concrete.EntityFramework;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_DataAccess.Concrete.Dapper;
using Tiko_DataAccess.Concrete.EntityFramework;

namespace Tiko_WebAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<TikoDbContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tiko_WebAPI", Version = "v1" });
            });

            services.AddScoped<IEfAgentService, EfAgentManager>();
            services.AddScoped<IEfAgentDal, EfAgentDal>();

            services.AddScoped<IDpAgentService, DpAgentManager>();
            services.AddScoped<IDpAgentDal, DpAgentDal>();

            

            services.AddMemoryCache();

            services.AddControllers();

            return services;
        }
    }
}