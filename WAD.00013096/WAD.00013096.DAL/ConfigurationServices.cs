using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD._00013096.Data;
using WAD._00013096.Interfaces;
using WAD._00013096.Repositories;

namespace WAD._00013096.DAL
{
    public static class ConfigurationServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IEstateRepository, EstateRepository>();

            return services;
        }
    }
}
