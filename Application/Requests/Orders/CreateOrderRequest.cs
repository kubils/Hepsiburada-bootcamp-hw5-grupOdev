using Domain.Dtos.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Orders
{
  public class CreateOrderRequest
  {
    public List<OrderItemDto> OrderItems { get; set; }
  }

}
