using Application.Requests.Users;
using AutoMapper;
using Domain.Commands.Users;
using Domain.Dtos.Users;
using Domain.Queries.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Requests.Orders;
using Domain.Queries.OrderDetails;
using Microsoft.AspNetCore.Identity;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ApiControllerBase
  {
    public UserController(IMapper mapper) : base(mapper)
    {
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
      return Ok(await Mediator.Send(new GetUsersQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
      return Ok(await Mediator.Send(_mapper.Map<CreateUserCommand>(request)));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
      var query = _mapper.Map<LoginQuery>(request);
      var token = await Mediator.Send(query);
      return Ok(token);
    }
  }
}
