using AutoMapper;
using GerenciadorDePedidos.Application.Interfaces;
using GerenciadorDePedidos.Application.Mappings;
using GerenciadorDePedidos.Application.Services;
using GerenciadorDePedidos.Domain.Interfaces;
using GerenciadorDePedidos.Infrastructure.Context;
using GerenciadorDePedidos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region EF config
            string connectionString = configuration["ConnectionStrings:DbConnection"];

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            #endregion

            #region Container DI
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            #endregion

            #region AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile(new AutoMapping());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            return services;
        }
    }
}
