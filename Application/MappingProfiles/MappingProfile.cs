using Application.Requests.Orders;
using Application.Requests.Products;
using Application.Requests.Users;
using AutoMapper;
using Core.Entities;
using Domain.Commands.Orders;
using Domain.Commands.Products;
using Domain.Commands.Users;
using Domain.Dtos.OderDetails;
using Domain.Dtos.Products;
using Domain.Dtos.Users;
using Domain.Queries.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos.OrderItems;
using Domain.Dtos.Orders;
using Core.Enums;
using Domain.Queries.Users;

namespace Application.MappingProfiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      #region DomainToResponse

      CreateMap<User, UserDto>();
      CreateMap<UserDetail, UserDto>();
      CreateMap<Product, ProductDto>()
        .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (CategoryEnum)src.CategoryId));

      CreateMap<User, UserDetail>()
          .ForMember(dest => dest.Id, opt =>
              opt.MapFrom(src => src.Id.ToString()));

      CreateMap<OrderDetail, OrderDetailsDto>();
      CreateMap<OrderItem, OrderItemDto>();

      CreateMap<Order, OrderDto>()
          .ForMember(dest => dest.TotalPrice, opt =>
              opt.MapFrom(src => src.OrderItems.Sum(x => x.Price * x.Quantity)));

      #endregion

      #region RequestToDomain

      CreateMap<CreateOrderRequest, CreateOrderCommand>();
      CreateMap<CreateProductRequest, CreateProductCommand>();
      CreateMap<CreateUserRequest, CreateUserCommand>();
      CreateMap<GetOrderByIdRequest, GetOrderByIdQuery>();
      CreateMap<LoginRequest, LoginQuery>();

      #endregion

      #region Mongo

      CreateMap<ProductDto, MongoProduct>();
      CreateMap<OrderItemDto, MongoOrderItem>();
      #endregion
    }
  }
}
