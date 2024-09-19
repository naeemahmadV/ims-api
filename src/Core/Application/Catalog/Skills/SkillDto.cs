namespace FSH.WebApi.Application.Catalog.Skills;
public class SkillDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public IList<LeadSkill>? LeadSkills { get; set; }

}
