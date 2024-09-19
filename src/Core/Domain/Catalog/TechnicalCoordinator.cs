using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Catalog;
public class TechnicalCoordinator : AuditableEntity, IAggregateRoot
{
    [Column("LeadId")]
    public Guid LeadId { get; set; }
    public Lead Lead { get; set; }

    [Column("UserId")]
    public Guid? UserId { get; set; }
}
