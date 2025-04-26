using Domain.EntityAbstractions;
using Domain.EntityAnnotations;

namespace Domain.Models
{
    public class Category : BaseEntity
    {
        [MessageRequired]
        [MessageMaxLength(255)]
        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
