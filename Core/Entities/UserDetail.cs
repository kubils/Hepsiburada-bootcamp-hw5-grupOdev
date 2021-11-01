using System;
using System.Collections.Generic;

namespace Core.Entities
{
  public class UserDetail
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{Name} {LastName}";

    public DateTime CreatedOn { get; set; }

    public string Email { get; set; }
  }
}