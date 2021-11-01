using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
  [BsonIgnoreExtraElements]
  public class OrderDetail
  {
    // [BsonElement("OrderId")]
    public string OrderId { get; set; }

    [BsonId]
    public ObjectId _id { get; set; }

    [BsonElement("OrderItems")]
    public List<MongoOrderItem> OrderItems;
    [BsonElement("TotalPrice")]
    public int TotalPrice => OrderItems.Sum(x => x.TotalPrice);
    [BsonElement("User")]
    public UserDetail User { get; set; }
    [BsonElement("OrderDate")]
    public DateTime OrderDate { get; set; }
  }
  public class MongoProduct
  {
    [BsonElement("Name")]
    public string Name { get; set; }
    [BsonElement("Price")]
    public int Price { get; set; }

    [BsonElement("Category")]
    public string Category { get; set; }
  }
  public class MongoOrderItem
  {
    [BsonElement("Product")]
    public MongoProduct Product { get; set; }
    [BsonElement("Quantity")]
    public int Quantity { get; set; }
    [BsonElement("TotalPrice")]
    public int TotalPrice => Product.Price * Quantity;

  }
}
