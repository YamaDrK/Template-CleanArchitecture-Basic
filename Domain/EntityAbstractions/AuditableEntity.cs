namespace Domain.EntityAbstractions
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public DateTime? DeletionDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public void SetAuditableProperties() => CreationDate = DateTime.Now;

        public void UpdateAuditableProperties() => ModificationDate = DateTime.Now;

        public void DeleteEntity()
        {
            IsDeleted = true;
            DeletionDate = DateTime.Now;
        }
    }
}
