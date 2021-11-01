using Domain.Dtos.OrderItems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Orders
{
  public class CreateOrderCommand : IRequest
  {
    public CreateOrderCommand(List<OrderItemDto> orderItems)
    {
      OrderItems = orderItems;
    }
    public List<OrderItemDto> OrderItems { get; set; }
  }
}
