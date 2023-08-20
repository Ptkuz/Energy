using Energy.DAL.Context;
using Energy.Services.Services;
using Energy.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Energy.Services
{

    /// <summary>
    /// Регистрокатор сервисов
    /// </summary>
    public static class ServiceRegistrator
    {
        /// <summary>
        /// Добавить контекст и сервис работы с БД
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="connectionString">Строка подключения к БД</param>
        /// <returns></returns>
        public static IServiceCollection AddDataBaseServices(this IServiceCollection services, string connectionString) => services
            .AddDbContext<EnergyContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped)
            .AddTransient<IDataBaseService, DataBaseService>()
            
            ;
    }
}
