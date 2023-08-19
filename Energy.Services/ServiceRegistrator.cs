using Energy.DAL.Context;
using Energy.Services.Services;
using Energy.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Energy.Services
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddDataBaseServices(this IServiceCollection services, string connectionString) => services
            .AddDbContext<EnergyContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped)
            .AddTransient<IDataBaseService, DataBaseService>()
            
            ;
    }
}
