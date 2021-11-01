using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using MediatR;

namespace Domain.Commands.Products
{
  public class ProductCommandHandler : IRequestHandler<CreateProductCommand>
  {
    private readonly IProductRepository _productRepository;

    public ProductCommandHandler(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
      Product product = new Product(request.Name, request.Price, request.Description, request.CategoryId);

      _productRepository.CreateDapper(product);

      

      return Unit.Task;
    }
  }
}
