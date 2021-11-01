using Core.Filters;
using Domain.Dtos.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.Products
{
    public class GetProductsQuery: IRequest<List<ProductDto>>
    {
        public readonly ProductParameters _parameters;
        public GetProductsQuery(ProductParameters parameters)
        {
            _parameters = parameters;
        }
    }
}
