﻿using Application.Contracts.Persistence;
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
                .AddTransient<IGenericRepository<Person>, PersonRepository>()
                .AddTransient<IGenericRepository<Bill>, BillRepository>()
                .AddTransient<IGenericRepository<BillDetail>, BillDetailRepository>()
                .AddTransient<IGenericRepository<Product>, ProductRepository>()
                .AddTransient<IGenericRepository<Tax>, TaxRepository>()
                .AddTransient<IGenericRepository<Discount>, DiscountRepository>()
                .AddTransient<IGenericRepository<Message>, MessageRepository>();

            return services;
        }

    }
}
