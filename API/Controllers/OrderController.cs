using Application.Requests.Orders;
using AutoMapper;
using Domain.Commands.Orders;
using Domain.Queries.OrderDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Queries.Orders;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrderController : ApiControllerBase
  {
    public OrderController(IMapper mapper) : base(mapper)
    {
    }

    [HttpPost]
    [Authorize(Roles = "user")]

    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
      
      return Ok(await Mediator.Send(_mapper.Map<CreateOrderCommand>(request)));
    }

    [HttpGet("{OrderId}")]
    public async Task<IActionResult> Get(string OrderId)
    {
      GetOrderByIdRequest request = new GetOrderByIdRequest();
      request.OrderId = OrderId;
      var result = await Mediator.Send(_mapper.Map<GetOrderByIdQuery>(request));
      return Ok(result);
    }

    [HttpGet("userId={UserId}")]
    public async Task<IActionResult> GetOrderByUserId(string UserId)
    {

      var result = await Mediator.Send(new GetOrderByUserIdQuery(UserId));
      return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
      var result = await Mediator.Send(new GetOrdersQuery());
      return Ok(result);
    }

  }
}
