using Core.Entities;
using Core.Interfaces;
using Dapper;
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
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly ECommerceDbContext _dbContext;
        DbSet<OrderItem> _dbSet;
        public OrderItemRepository(ECommerceDbContext dbContext, IConfiguration configuration) : base(dbContext, configuration)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<OrderItem>();
        }

        public void CreateDapper(OrderItem orderItem)
        {
            try
            {
                var query = @"INSERT INTO ""OrderItems"" (""Id"", ""ProductId"", ""OrderId"", ""Price"", ""Quantity"", ""CreatedOn"", ""IsActive"")
                    VALUES 
                    (@Id, @ProductId, @OrderId, @Price, @Quantity, @CreatedOn, @IsActive)";

                var parameters = new DynamicParameters();
                parameters.Add("Id", orderItem.Id);
                parameters.Add("ProductId", orderItem.ProductId);
                parameters.Add("OrderId", orderItem.OrderId);
                parameters.Add("Price", orderItem.Price);
                parameters.Add("Quantity", orderItem.Quantity);
                parameters.Add("CreatedOn", orderItem.CreatedOn);
                parameters.Add("IsActive", orderItem.IsActive);


                using (var connection = CreateConnection())
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    connection.Execute(query, parameters);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
