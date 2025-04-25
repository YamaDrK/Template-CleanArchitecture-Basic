using Application.Commons.Mappers;
using Domain.Models;

namespace Application.DTOs.Products
{
    public class UpsertProductDTO : MapTo<Product>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int CategoryId { get; set; }
    }
}
