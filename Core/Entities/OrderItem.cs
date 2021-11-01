using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(Guid productId, Guid orderId, int price, int quantity)
        {
            ProductId = productId;
            OrderId = orderId;
            Price = price;
            Quantity = quantity;
        }
        public Guid ProductId { get; protected set; }
        public Guid OrderId { get; protected set; }
        public int Price { get; protected set; }
        public int Quantity { get; protected set; }

        [ForeignKey("ProductId")]
        public Product Product { get; protected set; }

        [ForeignKey("OrderId")]
        public Order Order { get; protected set; }
    }
}
