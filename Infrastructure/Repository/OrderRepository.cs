using Dapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  public class OrderRepository : Repository<Order>, IOrderRepository
  {
    private readonly ECommerceDbContext _dbContext;
    DbSet<Order> _dbSet;
    public OrderRepository(ECommerceDbContext dbContext, IConfiguration configuration) : base(dbContext, configuration)
    {
      _dbContext = dbContext;
      _dbSet = dbContext.Set<Order>();
    }

    public void CreateDapper(Order order)
    {
      try
      {
        var query = @"INSERT INTO ""Orders"" (""Id"", ""UserId"", ""CreatedOn"", ""IsActive"")
                    VALUES 
                    (@Id, @UserId, @CreatedOn, @IsActive)";

        var parameters = new DynamicParameters();
        parameters.Add("Id", order.Id);
        parameters.Add("UserId", order.UserId);
        parameters.Add("CreatedOn", order.CreatedOn);
        parameters.Add("IsActive", order.IsActive);

        using(var connection = CreateConnection())
        {
          if(connection.State != System.Data.ConnectionState.Open)
          {
            connection.Open();
          }

          connection.Execute(query, parameters);
        }

      }
      catch(Exception ex)
      {
        throw new Exception(ex.Message, ex);
      }
    }

    public List<Order> GetOrdersWithOrderItems()
    {
      return _dbSet.Include(x => x.OrderItems).ToList();
    }
  }
}
