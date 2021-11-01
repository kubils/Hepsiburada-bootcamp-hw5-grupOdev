using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Domain.Dtos.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Queries.Products
{
  public class ProductQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
  {
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;


    public ProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
      _productRepository = productRepository;
      _mapper = mapper;
    }

    public Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
      var products = _productRepository.GetByParameters(request._parameters);

      return Task.FromResult(_mapper.Map<List<ProductDto>>(products));
    }
  }
}
