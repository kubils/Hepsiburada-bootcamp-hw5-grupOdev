using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Products
{
  public class ProductDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }

    public DateTime CreatedOn { get; set; }
  }
}
