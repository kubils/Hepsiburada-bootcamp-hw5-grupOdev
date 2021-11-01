using Application;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public abstract class ApiControllerBase : ControllerBase
  {
    private ISender _mediator;
    protected readonly IMapper _mapper;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    public ApiControllerBase(IMapper mapper)
    {
      _mapper = mapper;
    }
  }
}
