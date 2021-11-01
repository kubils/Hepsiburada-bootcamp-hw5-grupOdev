using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Users
{
  public class UserCommandHandler : IRequestHandler<CreateUserCommand>
  {
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<Role> _roleManager;

    public UserCommandHandler(IUserRepository userRepository, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
    {
      _userRepository = userRepository;
      _userManager = userManager;
      _signInManager = signInManager;
      _roleManager = roleManager;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      // Son parametre UserName'dir. Ekstra göndermemek için email'e eşitledik.
      User user = new User(request.Name, request.LastName, request.Email, request.Email);

      IdentityResult result = await _userManager.CreateAsync(user, request.Password);

      if(!_roleManager.RoleExistsAsync("user").Result)
      {
        Role userRole = new Role()
        {
          Name = "user"
        };
        IdentityResult userRoleResult = await _roleManager.CreateAsync(userRole);
      }
      if(!_roleManager.RoleExistsAsync("seller").Result)
      {
        Role sellerRole = new Role()
        {
          Name = "seller"
        };
        IdentityResult sellerRoleResult = await _roleManager.CreateAsync(sellerRole);
      }

      if(result.Succeeded)
      {
        await _userManager.AddToRoleAsync(user, request.Role.ToString());
      }

      return Unit.Value;
    }
  }
}
