using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Catalog;
public class OpportunitySubSkill : AuditableEntity, IAggregateRoot
{
    [Column("OpportunityId")]
    public Guid OpportunityId { get; set; }
    public Opportunity Opportunity { get; set; }
    [Column("SubSkillId")]
    public Guid SubSkillId { get; set; }
    public SubSkill SubSkill { get; set; }
}
