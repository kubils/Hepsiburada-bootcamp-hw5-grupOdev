using Core.Entities;
using Core.Interfaces;
using Infrastructure.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  public class OrderDetailsMongoRepository : IOrderDetailsMongoRepository
  {
    private readonly IMongoCollection<OrderDetail> _orderDetails;
    public OrderDetailsMongoRepository(IECommerceMongoDbSettings settings)
    {
      MongoClient client = new MongoClient(settings.ConnectionString);
      IMongoDatabase db = client.GetDatabase(settings.DatabaseName);
      _orderDetails = db.GetCollection<OrderDetail>(settings.OrderDetailsCollectionName);
    }

    public List<OrderDetail> GetAllOrderDetails()
    {
      return _orderDetails.Find(_ => true).ToList();
    }

    public List<OrderDetail> GetOrderDetailByUserId(string userId)
    {
      return _orderDetails.Find(x => x.User.Id.Equals(userId)).ToList();
    }

    public OrderDetail GetOrderDetailByOrderId(string orderId)
    {
      var order = _orderDetails.Find(x => x.OrderId == orderId).SingleOrDefault();
      return order;
    }

    public void AddOrderDetail(OrderDetail order)
    {
      _orderDetails.InsertOne(order);
    }

    public List<OrderDetail> GetFirstTenOrderFromUser(string orderId)
    {
      var order = _orderDetails.Find(x => x.OrderId == orderId).Limit(10);
      throw new NotImplementedException();
    }

    public List<OrderDetail> GetFirstTenOrder(string orderId)
    {
      throw new NotImplementedException();
    }

    public void AddFirstTenOrderedItemFromUser(List<OrderItem> order)
    {
      throw new NotImplementedException();
    }

    public void AddFirstTenOrderedItem(List<OrderItem> order)
    {
      throw new NotImplementedException();
    }
  }
}
