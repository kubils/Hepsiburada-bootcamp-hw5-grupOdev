using AutoMapper;
using Core.Interfaces;
using Domain.Dtos.OderDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Queries.OrderDetails
{
  public class OrderDetailsQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailsDto>,
                                              IRequestHandler<GetOrderByUserIdQuery, List<OrderDetailsDto>>
  {
    private readonly IOrderDetailsMongoRepository _orderDetailsMongoRepository;
    private readonly IMapper _mapper;

    public OrderDetailsQueryHandler(IOrderDetailsMongoRepository orderDetailsMongoRepository, IMapper mapper)
    {
      _orderDetailsMongoRepository = orderDetailsMongoRepository;
      _mapper = mapper;
    }
    public Task<OrderDetailsDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
      var orderdetail = _orderDetailsMongoRepository.GetOrderDetailByOrderId(request.OrderId);
      return Task.FromResult(_mapper.Map<OrderDetailsDto>(orderdetail));
    }


    public Task<List<OrderDetailsDto>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
    {
      var userDetail = _orderDetailsMongoRepository.GetOrderDetailByUserId(request.UserId);
      return Task.FromResult(_mapper.Map<List<OrderDetailsDto>>(userDetail));
    }
  }
}
