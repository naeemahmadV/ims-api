using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Catalog;
public class SubSkill : AuditableEntity, IAggregateRoot
{
    public string? SubSkillName { get; set; }
    [Column("SkillId")]
    public Guid? SkillId { get; set; }
    public Skill? Skill { get; set; }

    public IList<LeadSubSkill>? LeadSubSkills { get; set; }

    public SubSkill(string? subSkillName, Guid? skillId)
    {
        SubSkillName = subSkillName;
        SkillId = skillId;
    }

    public SubSkill Update(string? name, Guid? skillId)
    {
        if (name is not null && SubSkillName?.Equals(name) is not true) SubSkillName = name;
        if (SkillId.Equals(skillId) is not true) SkillId = skillId;
        return this;
    }

}
