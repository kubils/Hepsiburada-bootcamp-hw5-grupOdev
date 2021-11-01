using Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Products
{
  public class CreateProductCommand : IRequest
  {
    public CreateProductCommand(string name, int price, string description)
    {
      Name = name;
      Price = price;
      Description = description;
    }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public CategoryEnum CategoryId { get; set; }
  }
}
