using Application.DTOs.Products;
using Application.Interfaces.Base;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Models;
using Infrastructure.Implements.Base;

namespace Infrastructure.Implements.Services
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper)
        : CrudService<Product, UpsertProductDTO, UpsertProductDTO, GetProductDTO>(_unitOfWork, _mapper, ["Category"]),
        IProductService;
}
