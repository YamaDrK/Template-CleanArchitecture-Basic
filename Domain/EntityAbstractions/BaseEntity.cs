using System.ComponentModel.DataAnnotations;

namespace Domain.EntityAbstractions
{
    public abstract class BaseEntity
    {
        [Key]        
        public int Id { get; set; }
    }
}
