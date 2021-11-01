using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Products
{
  public class CreateProductRequest
  {
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public CategoryEnum CategoryId { get; set; }

  }
}
