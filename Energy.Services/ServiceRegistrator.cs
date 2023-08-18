using Energy.DAL.Context;
using Energy.DAL.Context.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.Services
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddEnergyServices(this IServiceCollection services) => services
            .AddTransient<IContextInitializer, ContextInitializer>()
            ;
    }
}
