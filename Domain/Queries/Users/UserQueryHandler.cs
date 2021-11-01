using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Domain.Dtos.Users;
using Domain.Token;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Queries.Users
{
  public class UserQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>,
                                  IRequestHandler<LoginQuery, string>
  {
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;


    private readonly IMapper _mapper;

    public UserQueryHandler(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
      _userRepository = userRepository;
      _mapper = mapper;
      _userManager = userManager;
      _configuration = configuration;
    }

    public Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
      //RoleManager
      var users = _userRepository.GetAll();

      return Task.FromResult(_mapper.Map<List<UserDto>>(users));
    }

    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
      User user = await _userManager.FindByEmailAsync(request.Email.Trim());
      if(user == null || !(await _userManager.CheckPasswordAsync(user, request.Password.Trim())))
      {
        throw new ApplicationException("Invalid credentials");
      }

      GenerateJwtToken tokenGenerator = new(_userManager, _configuration);

      return await tokenGenerator.GenerateToken(user);
    }
  }
}