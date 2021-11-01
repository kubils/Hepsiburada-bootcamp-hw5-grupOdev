using Domain.Dtos.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.Users
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {

    }
}