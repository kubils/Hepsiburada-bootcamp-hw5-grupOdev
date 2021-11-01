using System.Collections.Generic;
using Domain.Dtos.OderDetails;
using MediatR;

namespace Domain.Queries.OrderDetails
{
    public class GetOrderByUserIdQuery : IRequest<List<OrderDetailsDto>>
    {
        
        public GetOrderByUserIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }

    }
}