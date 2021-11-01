using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
  public class Order : BaseEntity
  {
    public Order()
    {
    }

    public Order(Guid userId)
    {
      UserId = userId;
    }
    public Guid UserId { get; protected set; }

    [ForeignKey("UserId")]
    public User User { get; protected set; }
    public ICollection<OrderItem> OrderItems { get; protected set; }
  }
}
