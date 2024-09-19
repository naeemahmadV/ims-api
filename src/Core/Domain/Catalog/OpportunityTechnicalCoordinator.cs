using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Catalog;
public class OpportunityTechnicalCoordinator : AuditableEntity, IAggregateRoot
{
    [Column("OpportunityId")]
    public Guid OpportunityId { get; set; }
    public Opportunity Opportunity { get; set; }

    [Column("UserId")]
    public Guid UserId { get; set; }
}
