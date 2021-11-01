using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
  public class Product : BaseEntity
  {
    public Product()
    {
    }

    public Product(string name, int price, string description, CategoryEnum categoryId)
    {
      Name = name;
      Price = price;
      Description = description;
      CategoryId = categoryId;
    }
    public string Name { get; protected set; }
    public int Price { get; protected set; }
    public string Description { get; protected set; }
    public CategoryEnum CategoryId { get; protected set; }
  }
}
