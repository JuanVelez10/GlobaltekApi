using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataBase;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<GlobaltekContext>(options => options.UseSqlServer(configuration.GetConnectionString("GobaltekDB"), b => b.MigrationsAssembly("Api")));


            services
                .AddTransient<IPersonRepository, PersonRepository>()
                .AddTransient<IBillRepository, BillRepository>()
                .AddTransient<IBillDetailRepository, BillDetailRepository>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<ITaxRepository, TaxRepository>()
                .AddTransient<IDiscountRepository, DiscountRepository>()
                .AddTransient<IMessageRepository, MessageRepository>();

            return services;
        }

    }
}
