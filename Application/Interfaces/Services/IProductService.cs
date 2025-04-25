using Application.DTOs.Products;
using Application.Interfaces.Base;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IProductService : ICrudService<Product, UpsertProductDTO, UpsertProductDTO, GetProductDTO>;
}
