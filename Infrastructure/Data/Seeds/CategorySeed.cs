using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Seeds
{
    public static class CategorySeed
    {
        public static DataBuilder GenerateCategorySeed(this EntityTypeBuilder entity)
        {
            var categorySeed = Enum
                .GetValues(typeof(CategoryEnum))
                .Cast<CategoryEnum>()
                .Select(x => new Category
                {
                    Id = (int)x,
                    Name = x.ToString()
                });
            return entity.HasData(categorySeed);
        }
    }
}
