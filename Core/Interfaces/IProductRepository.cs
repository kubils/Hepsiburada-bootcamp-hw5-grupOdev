using Core.Entities;
using Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
  public interface IProductRepository : IRepository<Product>
  {
    void CreateDapper(Product product);
    List<Product> GetAllDapper();
    Product GetById(Guid productId);
    List<Product> GetByParameters(ProductParameters parameters);
  }
}
