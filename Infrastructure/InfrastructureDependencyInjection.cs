using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Mongo;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
  public static class InfrastructureDependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

      services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<IOrderRepository, OrderRepository>();
      services.AddScoped<IOrderItemRepository, OrderItemRepository>();
      services.AddScoped<IOrderDetailsMongoRepository, OrderDetailsMongoRepository>();

      return services;
    }
  }
}
