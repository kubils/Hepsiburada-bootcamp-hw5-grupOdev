using Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Users
{
  public class CreateUserCommand : IRequest
  {
    public CreateUserCommand(string name, string lastName, string email)
    {
      Name = name;
      LastName = lastName;
      Email = email;
    }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }

  }
}
