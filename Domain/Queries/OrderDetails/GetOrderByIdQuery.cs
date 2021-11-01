using Domain.Dtos.OderDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.OrderDetails
{
    public class GetOrderByIdQuery : IRequest<OrderDetailsDto>
    {
        public string OrderId { get; set; }
    }
}
