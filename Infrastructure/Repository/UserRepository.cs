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
  public class UserRepository : Repository<User>, IUserRepository
  {
    private readonly ECommerceDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public UserRepository(ECommerceDbContext dbContext, IConfiguration configuration) : base(dbContext, configuration)
    {
      _dbContext = dbContext;
      _configuration = configuration;
    }

    public new List<User> GetAll()
    {
      return _dbContext.Users.ToList();
    }

    public User GetById(Guid userId)
    {
      return _dbContext.Users.FirstOrDefault(x => x.Id == userId);
    }

    public List<User> GetAllDapper()
    {
      try
      {
        var query = @"SELECT * FROM ""Users"" ";

        using(var connection = CreateConnection())
        {
          if(connection.State != System.Data.ConnectionState.Open)
          {
            connection.Open();
          }

          return connection.Query<User>(query).ToList();
        }

      }
      catch(Exception ex)
      {
        throw new Exception(ex.Message, ex);
      }
    }


    public void CreateDapper(User user)
    {
      try
      {
        var query = @"INSERT INTO ""Users"" (""Id"", ""Name"", ""LastName"", ""Email"", ""CreatedOn"", ""IsActive"") VALUES (@Id, @Name, @LastName, @Email, @CreatedOn, @IsActive)";

        var parameters = new DynamicParameters();
        parameters.Add("Id", user.Id);
        parameters.Add("Name", user.Name);
        parameters.Add("LastName", user.LastName);
        parameters.Add("Email", user.Email);
        parameters.Add("CreatedOn", user.CreatedOn);
        parameters.Add("IsActive", user.IsActive);

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



  }
}
