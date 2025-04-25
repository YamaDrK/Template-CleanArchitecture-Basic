using Application.Commons.Mappers;
using Domain.Models;

namespace Application.DTOs.Products
{
    public class GetProductDTO : MapFrom<Product>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
    }
}
