using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Domain.Dtos.Orders;
using Domain.Dtos.Products;
using Domain.Queries.Products;
using MediatR;

namespace Domain.Queries.Orders
{
  public class OrderQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
  {
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
      _orderRepository = orderRepository;
      _mapper = mapper;
    }

    public Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
      var orders = _orderRepository.GetOrdersWithOrderItems();

      return Task.FromResult(_mapper.Map<List<OrderDto>>(orders));
    }
  }
}