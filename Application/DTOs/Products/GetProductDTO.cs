using Application.Commons.Mappers;
using AutoMapper;
using Domain.Models;

namespace Application.DTOs.Products
{
    public class GetProductDTO : MapFrom<Product>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? CategoryName { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetProductDTO>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category != null ? s.Category.Name : ""));
        }
    }
}
