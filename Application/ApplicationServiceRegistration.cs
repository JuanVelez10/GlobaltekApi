using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services
            //    .AddTransient<IParametersService, ParametersService>()
            //    .AddTransient<IOrdersService, OrdersService>()
            //    .AddTransient<ITemplateService, TemplateService>()
            //    .AddTransient<IAwardsInventoryService, AwardsInventoryService>()
            //    .AddTransient<IAwardsService, AwardsService>()
            //    .AddTransient<IRepositoryService, RepositoryService>()
            //    .AddSingleton<ILoggerService, LoggerService>();
            return services;
        }

    }
}
