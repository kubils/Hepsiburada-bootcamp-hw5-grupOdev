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
    public class Repository<Tentity> : BaseRepository, IRepository<Tentity> where Tentity : class
    {
        private readonly ECommerceDbContext _dbContext;
        DbSet<Tentity> _dbSet;
        public Repository(ECommerceDbContext dbContext, IConfiguration configuration) : base(configuration)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Tentity>();
        }

        public void Create(Tentity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges() ;
        }

        public List<Tentity> GetAll()
        {
            return _dbSet.Where(x => true).ToList();
        }

        public void Remove(Tentity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Tentity entity)
        {
            throw new NotImplementedException();
        }
    }
}
