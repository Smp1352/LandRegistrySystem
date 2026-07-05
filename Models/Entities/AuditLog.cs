

namespace LandRegistrySystem.Models.Entities;

public class AuditLog : BaseEntity
{
    public string TableName { get; set; } = "";

    public string Action { get; set; } = "";

    public string? KeyValues { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? UserName { get; set; }

    public DateTime ActionDate { get; set; } = DateTime.Now;
}