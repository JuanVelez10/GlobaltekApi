using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBillServices, BillServices>();
            services.AddTransient<IPersonServices, PersonServices>();
            services.AddTransient<IMessageServices, MessageServices>();
            services.AddTransient<IBillDetailServices, BillDetailServices>();
            services.AddTransient<IDiscountServices, DiscountServices>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<ITaxServices, TaxServices>();

            return services;
        }

    }
}
