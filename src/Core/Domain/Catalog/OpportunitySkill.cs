using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Catalog;
public class OpportunitySkill : AuditableEntity, IAggregateRoot
{
    [Column("OpportunityId")]
    public Guid OpportunityId { get; set; }
    public Opportunity Opportunity { get; set; }
    [Column("SkillId")]
    public Guid SkillId { get; set; }
    public virtual Skill Skill { get; set; }
}
