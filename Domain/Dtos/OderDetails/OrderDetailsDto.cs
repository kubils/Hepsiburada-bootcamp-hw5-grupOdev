using Core.Entities;
using Domain.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.OderDetails
{
  public class OrderDetailsDto
  {

    public Guid OrderId { get; set; }

    public List<MongoOrderItem> OrderItems { get; set; }
    public int TotalPrice { get; set; }
    public UserDto User { get; set; }
    public DateTime OrderDate { get; set; }
  }
}
