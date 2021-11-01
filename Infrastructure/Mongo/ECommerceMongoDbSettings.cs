using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mongo
{
  public class ECommerceMongoDbSettings : IECommerceMongoDbSettings
  {
    public string OrderDetailsCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }

  public interface IECommerceMongoDbSettings
  {
    public string OrderDetailsCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }
}
