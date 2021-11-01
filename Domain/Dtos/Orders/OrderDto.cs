using System;
using System.Collections.Generic;
using Core.Entities;
using Domain.Dtos.OrderItems;

namespace Domain.Dtos.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get;  set; }
        public List<OrderItemDto> OrderItems { get;  set; }

        public DateTime CreatedOn { get; set; }

        public int TotalPrice { get; set; }
    }
}