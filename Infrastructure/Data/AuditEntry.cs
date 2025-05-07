using System.Text.Json;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data
{
    public class AuditEntry(EntityEntry entry)
    {
        public EntityEntry Entry { get; } = entry;
        public string? UserId { get; set; }
        public string? TableName { get; set; }
        public Dictionary<string, object?> KeyValues { get; } = [];
        public Dictionary<string, object?> OldValues { get; } = [];
        public Dictionary<string, object?> NewValues { get; } = [];
        public AuditTypeEnum AuditType { get; set; }
        public List<string> ChangedColumns { get; } = [];

        public Audit ToAudit()
        {
            return new Audit
            {
                UserId = UserId,
                Type = AuditType.ToString(),
                TableName = TableName,
                DateTime = DateTime.Now,
                PrimaryKey = KeyValues.Count switch
                {
                    0 => null,
                    1 => $"{KeyValues.First().Key}: {KeyValues.First().Value}",
                    _ => string.Join(", ", KeyValues.Select(kv => $"{kv.Key}: {kv.Value}"))
                },
                OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues),
                AffectedColumns = ChangedColumns.Count == 0 ? null : JsonSerializer.Serialize(ChangedColumns)
            };
        }
    }
}
