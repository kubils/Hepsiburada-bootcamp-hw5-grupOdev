
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
  public class User : IdentityUser<Guid>
  {
    public User()
    {
    }

    public User(string name, string lastName, string email, string userName) :base(email)
    {
      Name = name;
      LastName = lastName;
      Email = email;
      UserName = userName;
      IsActive = true;
      CreatedOn = DateTime.Now;
    }
    public string Name { get; protected set; }
    public string LastName { get; protected set; }
    //public string Email { get; set; }
    public string FullName => $"{Name} {FullName}";
    public bool IsActive { get; protected set; }
    public DateTime CreatedOn { get; protected set; }
    public ICollection<Order> Orders { get; protected set; }
  }
}
