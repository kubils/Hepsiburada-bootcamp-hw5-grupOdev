using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filters
{
  public class ProductParameters
  {
    private int _maxPageSize = 50;
    private int _minPageSize = 1;
    private int _pageSize = 10;
    public string Name { get; set; }
    public int MaxPrice { get; set; } = int.MaxValue;
    public int MinPrice { get; set; } = 0;
    public int PageSize
    {
      get
      {
        return _pageSize;
      }
      set
      {
        if(value <= _maxPageSize && value >= _minPageSize)
          _pageSize = value;
      }
    }
    public int PageNumber { get; set; } = 1;

    public CategoryEnum CategoryId { get; set; }
  }
}
